using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HR.DAL
{
    public class CompanyDAL
    {
        private readonly string _connectionString;

        public CompanyDAL()
        {

            _connectionString = ConfigurationManager.ConnectionStrings["dberp"].ToString();
        }


        public void InsertCompany(string CompanyName, string Address, string Email)
        {
            try
            {
                const string sql = "INSERT INTO [dbo].[Company] ([CompanyName], [Address], [Email]) VALUES (@CompanyName, @Address, @Email)";

                using (var con = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.Add(new SqlParameter("@CompanyName", System.Data.SqlDbType.NVarChar, 50) { Value = (object)CompanyName ?? DBNull.Value });
                    cmd.Parameters.Add(new SqlParameter("@Address", System.Data.SqlDbType.NVarChar, 50) { Value = (object)Address ?? DBNull.Value });
                    cmd.Parameters.Add(new SqlParameter("@Email", System.Data.SqlDbType.NVarChar, 50) { Value = (object)Email?? DBNull.Value });

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }

        }







        public void UpdateCompany(int id, string CompanyName, string Address, string Email)
        {
            const string sql = @"UPDATE Company 
                                     SET [CompanyName] = @CompanyName ,[Address]=@Address,[Email]=@Email;";

            using (var con = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(sql, con))
            {
                //cmd.Parameters.Add(new SqlParameter("@CompanyID", System.Data.SqlDbType.Int) { Value = CompanyID });
                cmd.Parameters.Add(new SqlParameter("@CompanyName", System.Data.SqlDbType.NVarChar, 50) { Value = (object)CompanyName ?? DBNull.Value });
                cmd.Parameters.Add(new SqlParameter("@Address", System.Data.SqlDbType.NVarChar, 50) { Value = (object)Address ?? DBNull.Value });
                cmd.Parameters.Add(new SqlParameter("@Email", System.Data.SqlDbType.NVarChar, 50) { Value = (object)Email ?? DBNull.Value });

                con.Open();
                cmd.ExecuteNonQuery();

            }

        }
        public void DeleteCompany(string CompanyID)
        {
            try
            {
                string sql = @"DELETE FROM [dbo].[Company] 
                               WHERE CompanyID =@CompanyID";


                using (SqlConnection myConnection = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, myConnection))
                    {
                        cmd.Parameters.AddWithValue("@CompanyID",CompanyID);

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