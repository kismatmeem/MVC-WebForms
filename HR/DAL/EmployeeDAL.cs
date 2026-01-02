using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace HR.DAL
{

    public class EmployeeDAL
    {
        private readonly string _connectionString;

        public EmployeeDAL()
        {

            _connectionString = ConfigurationManager.ConnectionStrings["dberp"].ToString();
        }


        public void InsertEmployee(string EmployeeName, string Email, string MobileNo)
        {
            try
            {
                const string sql = "INSERT INTO [dbo].[Employee] ([Employee Name], [Mobile No], [Email]) VALUES (@EmployeeName, @MobileNo, @Email)";

                using (var con = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.Add(new SqlParameter("@EmployeeName", System.Data.SqlDbType.NVarChar, 50) { Value = (object)EmployeeName ?? DBNull.Value });
                    cmd.Parameters.Add(new SqlParameter("@Email", System.Data.SqlDbType.NVarChar, 50) { Value = (object)Email ?? DBNull.Value });
                    cmd.Parameters.Add(new SqlParameter("@MobileNo", System.Data.SqlDbType.NVarChar, 50) { Value = (object)MobileNo ?? DBNull.Value });

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }

        }







        public void UpdateEmployee(int id, string EmployeeName, string Email, string MobileNo)
        {
            const string sql = @"UPDATE Employee 
                                     SET Employee Name = @EmployeeName ,Email=@Email, Mobile No = @MobileNo where ID=@ID;";

            using (var con = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.Add(new SqlParameter("@ID", System.Data.SqlDbType.Int) { Value = id });
                cmd.Parameters.Add(new SqlParameter("@EmployeeName", System.Data.SqlDbType.NVarChar, 50) { Value = (object)EmployeeName ?? DBNull.Value });
                cmd.Parameters.Add(new SqlParameter("@Email", System.Data.SqlDbType.NVarChar, 50) { Value = (object)Email ?? DBNull.Value });
                cmd.Parameters.Add(new SqlParameter("@MobileNo", System.Data.SqlDbType.NVarChar, 50) { Value = (object)MobileNo ?? DBNull.Value });

                con.Open();
                cmd.ExecuteNonQuery();

            }

        }
        public void DeleteEmployee(string EmployeeID)
        {
            try
            {
                string sql = @"DELETE FROM [dbo].[Employee] 
                               WHERE ID =@ID";


                using (SqlConnection myConnection = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, myConnection))
                    {
                        cmd.Parameters.AddWithValue("@ID", EmployeeID);

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

    