/* Alivia Houdek */
/* March 22, 2019 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;

namespace BusyPet.Classes
{
    public class Logging : Database
    {
        private string storedProc { get; set; }
        private Dictionary<string, object> parameters { get; set; }

        public Logging()
        {
            // initialize
            storedProc = String.Empty;
            parameters = new Dictionary<string, object>();
        }

        public void WriteSuccessLog()
        {
            // set parameters
            parameters.Add("success", 1);
            parameters.Add("method", "BusyPet");
            parameters.Add("exception", String.Empty);
            parameters.Add("stackTrace", String.Empty);

            // write log to DB
            storedProc = "spCreateAppLog";
            Insert(storedProc, parameters);

            // clean up
            storedProc = "";
            parameters.Clear();
        }

        public void WriteErrorLog(Exception exception, string methodName)
        {
            if (exception != null && methodName != null)
            {
                // set parameters
                parameters.Add("success", 0);
                parameters.Add("method", methodName);
                parameters.Add("exception", exception.Message);
                parameters.Add("stackTrace", exception.StackTrace);

                // write log to DB
                storedProc = "spCreateAppLog";
                Insert(storedProc, parameters);

                // clean up
                storedProc = "";
                parameters.Clear();
            }
        }

        public void LogFieldChange(User userObj, string columnChanged, string originalField, string newField)
        {
            if (userObj != null)
            {
                // TODO finish this method

                // set parameters
                parameters.Add("userId", userObj.userId);
                parameters.Add("columnChanged", columnChanged);
                parameters.Add("originalField", originalField);
                parameters.Add("newField", newField);

                // write log to DB
                storedProc = "spUpdateField";
                Insert(storedProc, parameters);

                // clean up
                storedProc = "";
                parameters.Clear();
            }
        }
    }
}