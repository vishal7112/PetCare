/* Alivia Houdek */
/* March 22, 2019 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusyPet.Classes
{
    public class Pet
    {
        // initialize instance of utilities class so we can use the functions it contains
        private Utilities utils = new Utilities();

        // initialize properties of this class
        public User petUser { get; set; }
        public int petId { get; set; }
        public string petName { get; set; }
        public string petType { get; set; }
        public string petSex { get; set; }
        public string petDateOfBirth { get; set; }

        /// <summary>
        /// Constructor that is used when the pet's ID and user are already known.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="pId"></param>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="sex"></param>
        /// <param name="dob"></param>
        public Pet(User user, int pId, string name, string type, string sex, string dob)
        {
            // store information entered by the user in the instance properties
            petUser = user;
            petName = name;
            petType = type;
            petSex = sex.ToString();
            petDateOfBirth = utils.ConvertStringToDateTime(dob).ToShortDateString();
            petId = pId;
        }

        /// <summary>
        /// Constructor that is called when a new pet is created. Calls function that inserts the pet's information into the Pet table of the database.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="sex"></param>
        /// <param name="dob"></param>
        public Pet(User user, string name, string type, string sex, string dob)
        {
            // TODO validate user input here

            // store information entered by the user in the instance properties
            petUser = user;
            petName = name;
            petType = type;
            petSex = sex.ToString();
            petDateOfBirth = utils.ConvertStringToDateTime(dob).ToShortDateString();
            
            // stores new pet's information in the database and returns the new pet's auto-incremented ID from the Pet table
            int id = CreatePet();
            petId = id;
        }

        /// <summary>
        /// Create a new entry in the Pet table of the database with the values stored in the current pet class instance.
        /// </summary>
        /// <returns></returns>
        private int CreatePet()
        {
            try
            {
                if (petUser != null && petName != null && petType != null && petSex != null && petDateOfBirth != null)
                {
                    // TODO validate user data here

                    Dictionary<string, object> parameters = new Dictionary<string, object>();
                    parameters.Add("userId", petUser.userId);
                    parameters.Add("petName", petName);
                    parameters.Add("petType", petType);
                    parameters.Add("sex", petSex);
                    parameters.Add("dob", petDateOfBirth);

                    var petId = utils.Insert("spCreatePet", parameters);
                    if (petId != null)
                    {
                        // find all pets tied to this user and update the user's pet dictionary
                        petUser.GetPets();

                        // return the user's id
                        return Convert.ToInt16(petId);
                    }
                }
                return -1;
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        /// <summary>
        /// Alter the data of an existing pet by passing in new values to replace the old in the database.
        /// </summary>
        /// <param name="newName"></param>
        /// <param name="newType"></param>
        /// <param name="newSex"></param>
        /// <param name="newDob"></param>
        /// <returns></returns>
        public bool UpdatePet(string newName = null, string newType = null, string newSex = null, string newDob = null)
        {
            try
            {
                if (newName != null)
                {
                    utils.LogFieldChange(petUser, "PetName", petName, newName);
                    petName = newName;
                }
                if (newType != null)
                {
                    utils.LogFieldChange(petUser, "PetType", petType, newType);
                    petType = newType;
                }
                if (newSex != null)
                {
                    utils.LogFieldChange(petUser, "Sex", petSex, newSex);
                    petSex = newSex;
                }
                if (newDob != null)
                {
                    utils.LogFieldChange(petUser, "DateOfBirth", petDateOfBirth, newDob);
                    petDateOfBirth = utils.ConvertStringToDateTime(newDob).ToShortDateString();
                }

                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Delete pet from the database via pet's ID as stored in the instance it's called on.
        /// </summary>
        /// <returns></returns>
        public bool RemovePet()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("PetId", petId);

            try
            {
                int recId = (int)(utils.Insert("spDeletePet", parameters));
                if (recId != -1)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                utils.WriteErrorLog(e, "Record.DeleteRecord");
                return false;
            }
        }
    }
}