/* Alivia Houdek */
/* March 22, 2019 */

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BusyPet.Classes
{
    public class User
    {
        // initialize instance of classes we will need to use
        private Utilities utils = new Utilities();

        // initialize properties of this class
        public int userId { get; set; }
        public string loginName { get; set; }
        public string emailAddress { get; set; }
        public byte[] passwordBytes { get; set; }
        public Dictionary<int, Pet> pets { get; set; }

        /// <summary>
        /// Creates a user by storing their entered information in the instance properties, as well as in the User table of the database.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        public User(string username, string email, byte[] password)
        {
            // store variables in instance
            loginName = username;
            emailAddress = email;
            passwordBytes = password;
            userId = CreateUser();
            pets = null;
        }

        /// <summary>
        /// Initialize a returning user by passing in only the logon credentials and then retreiving the rest from the database upon initialization.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        public User(string email, byte[] password)
        {
            emailAddress = email;
            passwordBytes = password;

            // find the rest of the information for the user
            FindUser();
        }

        /// <summary>
        /// Private method that enters a new user's information into the User table of the database using the information in the instance it is called on.
        /// </summary>
        /// <returns></returns>
        private int CreateUser()
        {
            try
            {
                // TODO validate user data here

                if (loginName != null && emailAddress != null && passwordBytes != null)
                {
                    // set parameters
                    Dictionary<string, object> parameters = new Dictionary<string, object>();
                    parameters.Add("LoginName", loginName);
                    parameters.Add("EmailAddress", emailAddress);
                    parameters.Add("Password", passwordBytes);

                    // insert new user into the database using a stored procedure
                    var retVal = utils.Insert("spCreateUser", parameters);
                    if (retVal != null)
                    {
                        return Convert.ToInt16(retVal);
                    }
                }

                throw new Exception("Could not create new user.");
            }
            catch (Exception e)
            {
                throw new Exception("Could not create new user.");
            }
        }

        public void FindUser()
        {
            try
            {
                // set query parameters for sql
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("emailAddress", emailAddress);
                parameters.Add("password", passwordBytes);

                // call database with stored procedure and parameters for userID
                var retVal = utils.Query("spGetUserId", parameters);
                userId = (int)retVal;

                // call database with different stored procedure and the same parameters for username
                var retValE = utils.Query("spGetLoginName", parameters);
                loginName = (string)retValE;

                // throw an exception if the email and password do not match the existing ones in the database
                if (this.ValidateLogin(emailAddress, passwordBytes) == false)
                {
                    throw new Exception("Login credentials invalid.");
                }
            }
            catch (Exception e)
            {
                utils.WriteErrorLog(e, "User.FindUser");

                this.userId = -1;
            }
        }

        /// <summary>
        /// Updates the email address of the user instance it is called on with the passed-in, new email address. Returns whether the update was successful.
        /// </summary>
        /// <param name="newEmailAddress"></param>
        /// <returns></returns>
        public bool UpdateEmail(string newEmailAddress)
        {
            try
            {
                if (userId != -1 && userId != 0 && loginName != null && emailAddress != null && passwordBytes != null)
                {
                    // TODO validate user data here

                    if (utils.IsValidEmail(emailAddress) == true)
                    {
                        // set parameters
                        Dictionary<string, object> parameters = new Dictionary<string, object>();
                        parameters.Add("userId", userId);
                        parameters.Add("oldEmailAddress", emailAddress);
                        parameters.Add("newEmailAddress", newEmailAddress);

                        // insert new user into the database using a stored procedure
                        var returnedVal = utils.Insert("spUpdateEmail", parameters);

                        if (returnedVal != null)
                        {
                            utils.LogFieldChange(this, "EmailAddress", emailAddress, newEmailAddress);
                            return true;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                return false;
            }

            return false;
        }

        /// <summary>
        /// Updates the password of the user instance it is called on with the passed-in, new password. Returns whether the update was successful.
        /// </summary>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        public bool UpdatePassword(byte[] newPassword)
        {
            try
            {
                if (userId != -1 && userId != 0 && passwordBytes != null && newPassword != null)
                {
                    // TODO validate user data here

                    // set parameters
                    Dictionary<string, object> parameters = new Dictionary<string, object>();
                    parameters.Add("userId", userId);
                    parameters.Add("oldPassword", passwordBytes);
                    parameters.Add("newPassword", newPassword);

                    var returnedVal = utils.Insert("spUpdatePassword", parameters);

                    if (returnedVal != null)
                    {
                        utils.LogFieldChange(this, "Password", passwordBytes.ToString(), newPassword.ToString());
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                return false;
            }

            return false;
        }

        /// <summary>
        /// Returns whether the passed-in username and password byte[] matches the username and password of the user instance it was called on without converting the password to plain text.
        /// </summary>
        /// <param name="enteredEmail"></param>
        /// <param name="enteredPassword"></param>
        /// <returns></returns>
        public bool ValidateLogin(string enteredEmail, byte[] enteredPassword)
        {
            if (userId != -1 && userId != 0)
            {
                if (emailAddress.ToLower() == enteredEmail.ToLower())
                {
                    if (utils.ValidatePassword(passwordBytes, enteredPassword) == true)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Returns a user ID for the user instance it is called on by searching the database for the user's information.
        /// </summary>
        /// <returns></returns>
        public int GetUserId()
        {
            if (userId != -1 && userId != 0 && emailAddress != null && loginName != null && passwordBytes != null)
            {
                // TODO finish

                return 1;
            }

            return -1;
        }

        public Dictionary<int, Pet> GetPets()
        {
            try
            {
                Dictionary<int, Pet> tempPets = new Dictionary<int, Pet>();

                // set parameters
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("userId", userId);

                // insert new user into the database using a stored procedure
                var returned = utils.TableQuery("spGetPetsByUser", parameters);

                if ((DataTable)returned != null)
                {
                    // set data table headers
                    ((DataTable)returned).Columns[0].ColumnName = "PetId";
                    ((DataTable)returned).Columns[1].ColumnName = "PetName";
                    ((DataTable)returned).Columns[2].ColumnName = "PetType";
                    ((DataTable)returned).Columns[3].ColumnName = "PetDob";
                    ((DataTable)returned).Columns[4].ColumnName = "PetSex";

                    // loop through each row (pet) returned
                    for (int i = 0; i < ((DataTable)returned).Rows.Count; i++)
                    {
                        // store values for each pet from the datatable to the pet instance 
                        Pet pet = new Pet(this, Convert.ToInt16(((DataTable)returned).Rows[i]["PetId"].ToString()), ((DataTable)returned).Rows[i]["PetName"].ToString(), ((DataTable)returned).Rows[i]["PetType"].ToString(),
                            ((DataTable)returned).Rows[i]["PetSex"].ToString(), ((DataTable)returned).Rows[i]["PetDob"].ToString());

                        // add pet to the dictionary to assign retrieved pets to user
                        tempPets.Add(i, pet);
                    }

                    this.pets = tempPets;
                }

                return tempPets;
            }
            catch (Exception ex)
            {
                // log error

                return null;
            }
        }
    }
}
