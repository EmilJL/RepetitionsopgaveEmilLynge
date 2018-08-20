using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace joyride.DataAccess
{
    public class CommonDB
    {
        string connectionString;
        CommonDB(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool ExecuteNonQuery(string query)
        {
            int rowsAffected = 0;
            bool result = false;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        result = true;
                    }
                    cmd.Dispose();
                }
                con.Close();
            }

            return result;
        }
        public DataSet ExecuteQuery(string query)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = query;
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();

            con.Open();
            da.Fill(ds);
            con.Close();
            da.Dispose();
            cmd.Dispose();

            return ds;
        }
    }
}
