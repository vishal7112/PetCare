/* Cameron Curry */
/* March 31, 2019 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusyPet.Classes
{
    public class Routine
    {
        // initialize instance of utilities class so we can use the functions it contains
        private Utilities utils = new Utilities();

        // initialize properties of this class
        private User user { get; set; }
        private Pet pet { get; set; }
        private int routineId { get; set; }
        public string petName { get; set; }
        public string type { get; set; }
        public string creationDate { get; set; }
        public bool isActive { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string category { get; set; }
        public DateTime startDateTime { get; set; }
        public bool repeatDaily { get; set; }
        public bool repeatWeekly { get; set; }
        public bool repeatMonthly { get; set; }
        public bool repeatYearly { get; set; }

        public Routine(User user, Pet pet, string title, string discription, string catigory)
        {
            // Saves record to DB, returns record ID and throws error if the file was not successfully saved
            if (CreateRoutine() == -1)
            {
                // TODO display user error

                // throws server-side error to the next catch to be handled
                throw new Exception("Record could not be saved for an unknown reason.");
            }
        }

        private int CreateRoutine()
        {
            try
            {
                if (user != null && petName != null && description != null && title != null && category != null)
                {
                    // TODO validate user data here

                    // Convert object properties to parameter values
                    Dictionary<string, object> parameters = new Dictionary<string, object>();
                    parameters.Add("userId", user.userId);
                    parameters.Add("petId", pet.petId);
                    parameters.Add("category", category);
                    parameters.Add("title", title);
                    parameters.Add("description", description);
                    parameters.Add("startDateTime", startDateTime);
                    parameters.Add("repeatDaily", repeatDaily);
                    parameters.Add("repeatWeekly", repeatWeekly);
                    parameters.Add("repeatMonthly", repeatMonthly);
                    parameters.Add("repeatYearly", repeatYearly);

                    // Call the database to insert the new pet in the DB using the stored procedure
                    var petId = utils.Insert("spCreatePetRoutine", parameters);

                    // If the insertion was successful...
                    if (petId != null)
                    {
                        // Return the new pet's ID in the database
                        return Convert.ToInt16(petId);
                    }
                }
                return -1;
            }
            catch (Exception e)
            {
                // Log error to our DB
                utils.WriteErrorLog(e, "Record.CreateRoutine");
                return -1;
            }
        }

        private int DeleteRoutine()
        {
            // Convert object properties to parameter values (the only parameter needed here is the ID of the row in the DB that will be removed)
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("routineId", routineId);

            try
            {
                // Call database to perform the deletion and return the ID of the routine that was deleted
                int recId = (int)(utils.Insert("spDeleteRoutine", parameters));
                routineId = recId;
                return recId;
            }
            catch (Exception e)
            {
                // Log error to our DB
                utils.WriteErrorLog(e, "Record.DeleteRoutine");
                return -1;
            }
        }
        
        public bool UpdateRoutine(Pet newPet = null, string newCategory = null, string newTitle = null, string newDescription = null, string newStartDateTimeString = null /* TODO: ALL attributes except ID should be passed in here (in order) with a default of null or the equivalent so they can all be updated */)
        {
            try
            {
                // Update values in our object for any parameters that were passed in to replace existing values and log the changes to our database
                if (newTitle != null)
                {
                    utils.LogFieldChange(user, "RoutineTitle", title, newTitle);
                    title = newTitle;
                }
                if (newCategory != null)
                {
                    utils.LogFieldChange(user, "RoutineCategory", category, newCategory);
                    category = newCategory;
                }
                if (newDescription != null)
                {
                    utils.LogFieldChange(user, "RoutineDescription", description, newDescription);
                    description = newDescription;
                }
                if (newStartDateTimeString != null)
                {
                    utils.LogFieldChange(user, "RoutineStartDateTime", startDateTime.ToString(), newStartDateTimeString);
                    startDateTime = utils.ConvertStringToDateTime(newStartDateTimeString);
                }
                if (newStartDateTimeString != null)
                {
                    utils.LogFieldChange(user, "RoutineStartDateTime", startDateTime.ToString(), newStartDateTimeString);
                    startDateTime = utils.ConvertStringToDateTime(newStartDateTimeString);
                }
                // TODO: Continue adding these if clauses to log and update for each attribute passed in to the method as a parameter


                // Call the DB to perform the update with the stored procedure using the existing CreateRoutine method
                int returnedVal = CreateRoutine();

                // Check if the database returned a value indicating that the operation was successful
                if (returnedVal != -1)
                {
                    // Return an indication that there was a successful update performed
                    return true;
                }

                // Return an indication that there was not a successful update performed
                return false;
            }
            catch (Exception e)
            {
                // Return an indication that there was not a successful update performed
                return false;
            }
        }
    }
}