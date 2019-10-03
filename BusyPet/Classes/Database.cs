/* Alivia Houdek */
/* March 22, 2019 */

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BusyPet.Classes;

namespace BusyPet.Classes
{
    public class Database
    {
        // initialize properties of this class
        private static string connectionString = @"Server=busypet.cszmh29tevsm.us-east-2.rds.amazonaws.com,1433\rent;Database=busypet;User Id=bpetadmin;Password=busypet00;";

        /// <summary>
        /// Call the database using a stored procedure with passed-in parameters to return a queried field value.
        /// </summary>
        /// <param name="storedProc"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public object Query(string storedProc, Dictionary<string, object> parameters)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(storedProc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        foreach (KeyValuePair<string, object> param in parameters)
                        {
                            if (param.Key == null || param.Value == null)
                            {
                                cmd.Parameters.AddWithValue(param.Key, "null");
                            }
                            else
                            {
                                if (param.Value.ToString().Contains(@"'"))
                                {
                                    cmd.Parameters.AddWithValue(param.Key, param.Value.ToString().Replace("'", ""));
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue(param.Key, param.Value);
                                }
                            }
                        }

                        con.Open();
                        return cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// Call the database using a stored procedure with passed-in parameters to return a queried data table.
        /// </summary>
        /// <param name="storedProc"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public DataTable TableQuery(string storedProc, Dictionary<string, object> parameters)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(storedProc, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        foreach (KeyValuePair<string, object> param in parameters)
                        {
                            if (param.Key == null || param.Value == null)
                            {
                                cmd.Parameters.AddWithValue(param.Key, "null");
                            }
                            else
                            {
                                if (param.Value.ToString().Contains(@"'"))
                                {
                                    cmd.Parameters.AddWithValue(param.Key, param.Value.ToString().Replace("'", ""));
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue(param.Key, param.Value);
                                }
                            }
                        }

                        con.Open();

                        DataTable data = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        // query database and return the result to datatable
                        da.Fill(data);
                        da.Dispose();
                        return data;
                    }
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// Call the database using a stored procedure to write to a table with passed-in parameters.
        /// </summary>
        /// <param name="storedProc"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public object Insert(string storedProc, Dictionary<string, object> parameters)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(storedProc, con))
                    {
                        // Form parameterized command/query
                        cmd.CommandType = CommandType.StoredProcedure;

                        foreach (KeyValuePair<string, object> param in parameters)
                        {
                            if (param.Value.ToString() == "")
                            {
                                cmd.Parameters.AddWithValue(param.Key, "null");
                            }
                            else
                            {
                                if (param.Value.ToString().Contains(@"'"))
                                {
                                    cmd.Parameters.AddWithValue(param.Key, param.Value.ToString().Replace("'", ""));
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue(param.Key, param.Value);
                                }
                            }
                        }

                        con.Open();
                        var retval = cmd.ExecuteScalar();
                        return retval;
                    }
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}