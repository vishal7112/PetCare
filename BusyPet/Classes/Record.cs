/* Alivia Houdek */
/* March 22, 2019 */

/* Cameron Curry */
/* March 31, 2019 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusyPet.Classes
{
    public class Record
    {
        Utilities utils = new Utilities();

        private User user { get; set; }
        private Pet pet { get; set; }
        private int recordId { get; set; }
        private string recordName { get; set; }
        private string recordDate { get; set; }
        private string recordDescription { get; set; }

        public Record(User userObject, Pet petObject, string name,  string description)
        {
            // Saves record to DB, returns record ID and throws error if the file was not successfully saved
            if (CreateRecord() == -1)
            {
                // TODO display user error

                // throws server-side error to the next catch to be handled
                throw new Exception("Record could not be saved for an unknown reason.");
            }
        }
        private int CreateRecord()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("UserId", user.userId);
            parameters.Add("PetId", pet.petId);
            parameters.Add("RecordName", recordName);
            parameters.Add("RecordDescription", recordDescription);

            try
            {
                int recId = (int)(utils.Insert("spCreatepetHealthRecord", parameters));
                recordId = recId;
                return recId;
            }
            catch (Exception e)
            {
                utils.WriteErrorLog(e, "Record.CreateRecord");
                return -1;
            }
        }
        private bool DeleteRecord()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("RecordId", recordId);

            try
            {
                int recId = (int)(utils.Insert("spDeleteRecord", parameters));
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