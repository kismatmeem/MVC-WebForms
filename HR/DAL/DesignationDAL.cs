using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HR.DAL
{
    public class DesignationDAL
    {
        private readonly string _connectionString;

        public DesignationDAL()
        {

            _connectionString = ConfigurationManager.ConnectionStrings["dberp"].ToString();
        }


        public void InsertDesignation(string DesignationName, string Department, string Email)
        {
            try
            {
                const string sql = "INSERT INTO [dbo].[Designation] ([DesignationName], [Department], [Email]) VALUES (@DesignationName, @Department, @Email)";

                using (var con = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.Add(new SqlParameter("@DesignationName", System.Data.SqlDbType.VarChar, 50) { Value = (object)DesignationName ?? DBNull.Value });
                    cmd.Parameters.Add(new SqlParameter("@Department", System.Data.SqlDbType.VarChar, 50) { Value = (object)Department ?? DBNull.Value });
                    cmd.Parameters.Add(new SqlParameter("@Email", System.Data.SqlDbType.VarChar, 50) { Value = (object)Email ?? DBNull.Value });

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }

        }







        public void UpdateDesignation(int D_ID, string DesignationName, string Department, string Email)
        {
            const string sql = @"UPDATE Designation 
                                     SET DesignationName = @DesignationName ,Department=@Department, Email = @Email where ID=@ID;";

            using (var con = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.Add(new SqlParameter("@D_ID", System.Data.SqlDbType.Int) { Value = D_ID });
                cmd.Parameters.Add(new SqlParameter("@DesignationName", System.Data.SqlDbType.VarChar, 50) { Value = (object)DesignationName ?? DBNull.Value });
                cmd.Parameters.Add(new SqlParameter("@Department", System.Data.SqlDbType.VarChar, 50) { Value = (object)Department ?? DBNull.Value });
                cmd.Parameters.Add(new SqlParameter("@Email", System.Data.SqlDbType.VarChar, 50) { Value = (object)Email ?? DBNull.Value });

                con.Open();
                cmd.ExecuteNonQuery();

            }

        }
        public void DeleteDesignation(string D_ID)
        {
            try
            {
                string sql = @"DELETE FROM [dbo].[Designation] 
                               WHERE D_ID =@D_ID";


                using (SqlConnection myConnection = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, myConnection))
                    {
                        cmd.Parameters.AddWithValue("@D_ID", D_ID);

                        myConnection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
                throw;
            }
        }

    }

}
