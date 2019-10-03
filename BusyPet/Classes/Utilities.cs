/* Alivia Houdek */
/* March 22, 2019 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace BusyPet.Classes
{
    // Change Made 04.11.2019 by Alivia Houdek to inherit logging so two classes do not have to be initialized in all cs documents.

    public class Utilities : Logging
    {
        /// <summary>
        /// Converts a date/datetime string to a datetime variable and returns it. If the string cannot be converted, it will return the date 1/1/1700.
        /// </summary>
        /// <param name="inString"></param>
        /// <returns></returns>
        public DateTime ConvertStringToDateTime(string inString)
        {
            try
            {
                if (inString != null)
                {
                    return Convert.ToDateTime(inString);
                } else
                {
                    throw new Exception("Null date string in ConvertStringToDateTime");
                }
            }
            catch (Exception e)
            {
                return Convert.ToDateTime("1/1/1700");
            }
        }

        /// <summary>
        /// Converts a string to a UTF8-encoded byte array and returns that byte array.
        /// </summary>
        /// <param name="inString"></param>
        /// <returns></returns>
        public byte[] ConvertStringToBytes(string inString)
        {
            /* UTF8 ENCODING ONLY! */
            return System.Text.Encoding.UTF8.GetBytes(inString);
        }

        /// <summary>
        /// Converts a UTF8-encoded byte array to a string and returns that string.
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        private string ConvertBytesToString(byte[] bytes)
        {
            /* UTF8 ENCODING ONLY! */
            return System.Text.Encoding.UTF8.GetString(bytes);
        }

        /// <summary>
        /// Returns whether the two passwords are the same. Compares two byte arrays and returns bool representing whether the two arrays are the same.
        /// </summary>
        /// <param name="storedPassword"></param>
        /// <param name="inPassword"></param>
        /// <returns></returns>
        public bool ValidatePassword(byte[] storedPassword, byte[] inPassword)
        {
            if (storedPassword == inPassword)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Converts a readable string to a hashed, unreadable string.
        /// </summary>
        /// <param name="originalUnhashed"></param>
        /// <returns></returns>
        public string HashString(string originalUnhashed)
        {
            // TODO @Cameron

            return "";
        }

        /// <summary>
        /// Converts a hashed string back to a readable string.
        /// </summary>
        /// <param name="originalHashed"></param>
        /// <returns></returns>
        public string UnHashString(string originalHashed)
        {
            // TODO @Cameron

            return "";
        }

        /// <summary>
        /// Removes any special, non-alpha, non-numeric characters from a string or returns the original string if there are no special characters. Used for names, usernames, etc.
        /// </summary>
        /// <param name="originalString"></param>
        /// <returns></returns>
        public string ScrubStringOfSpecialCharacters(string originalString)
        {
            // TODO

            return "";
        }

        /// <summary>
        /// Returns whether the passed-in email address is a valid email address using a Regex pattern.
        /// </summary>
        /// <param name="inEmailAddress"></param>
        /// <returns></returns>
        public bool IsValidEmail(string inEmailAddress)
        {
            // Regex pattern for email addresses
            Regex newRegex = new Regex(@"^(\w{2,})+@([a-zA-Z/_/-]{2,})+?\.[a-zA-Z]{2,}$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

            // Find matches
            MatchCollection matches = newRegex.Matches(inEmailAddress);

            if (matches.Count > 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inUsername"></param>
        /// <returns></returns>
        public bool IsValidUsername(string inUsername)
        {
            // TODO

            // Regex pattern for email addresses
            Regex newRegex = new Regex(@"^(\w{2,})$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

            return false;
        }

        /// <summary>
        /// Returns whether the password entered is an acceptable password in terms of length and characters.
        /// </summary>
        /// <param name="inPassword"></param>
        /// <returns></returns>
        public bool IsValidPassword(byte[] inPassword)
        {
            // TODO

            // No "<" or ">" or other weird characters.
            // Minimum 6 characters.

            return false;
        }
    }
}