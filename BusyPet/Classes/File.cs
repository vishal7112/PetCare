/* Alivia Houdek */
/* March 22, 2019 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusyPet.Classes
{
    public class File
    {
        Utilities utils = new Utilities();

        private User user { get; set; }
        private Pet pet { get; set; }
        private int fileId { get; set; }
        private string fileType { get; set; }
        private string fileName { get; set; }
        private byte[] fileContents { get; set; }

        public File(User userObject, Pet petObject, string extension, string name, byte[] contents)
        {
            // Saves file to DB, returns file ID and throws error if the file was not successfully saved
            if (SaveNewFile() == -1)
            {
                // TODO display user error

                // throws server-side error to the next catch to be handled
                throw new Exception("File could not be saved for an unknown reason.");
            }
        }

        private int SaveNewFile()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("UserId", user.userId);
            parameters.Add("PetId", pet.petId);
            parameters.Add("FileType", fileType);
            parameters.Add("FileName", fileName);
            parameters.Add("FileContents", fileContents);

            try
            {
                int retId = (int)(utils.Insert("spCreateFile", parameters));
                fileId = retId;
                return retId;
            }
            catch (Exception e)
            {
                utils.WriteErrorLog(e, "File.SaveFile");
                return -1;
            }
        }
    }
}