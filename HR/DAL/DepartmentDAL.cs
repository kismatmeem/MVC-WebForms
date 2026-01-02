using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HR.DAL
{
    public class DepartmentDAL
    {
        private readonly string _connectionString;

        public DepartmentDAL()
        {

            _connectionString = ConfigurationManager.ConnectionStrings["dberp"].ToString();
        }


        public void InsertDepartment(string DepartmentName, string DepartmentHead, string Location)
        {
            try
            {
                const string sql = "INSERT INTO [dbo].[Department] ([DepartmentName], [DepartmentHead], [Location]) VALUES (@DepartmentName, @DepartmentHead, @Location)";

                using (var con = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.Add(new SqlParameter("@DepartmentName", System.Data.SqlDbType.VarChar, 50) { Value = (object)DepartmentName ?? DBNull.Value });
                    cmd.Parameters.Add(new SqlParameter("@DepartmentHead", System.Data.SqlDbType.VarChar, 50) { Value = (object)DepartmentHead ?? DBNull.Value });
                    cmd.Parameters.Add(new SqlParameter("@Location", System.Data.SqlDbType.VarChar, 50) { Value = (object)Location ?? DBNull.Value });

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }

        }







        public void UpdateDepartment(string DepartmentName, string DepartmentHead, string Location)
        {
            const string sql = @"UPDATE Department 
                                     SET [DepartmentName] = @DepartmentName ,[DepartmentHead]=@DepartmentHead, [Location]= @Location where [Department Name]=@DepartmentName;";

            using (var con = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(sql, con))
            {
               
                
                cmd.Parameters.Add(new SqlParameter("@DepartmentHead", System.Data.SqlDbType.NVarChar, 50) { Value = (object)DepartmentHead ?? DBNull.Value });
                cmd.Parameters.Add(new SqlParameter("@Location", System.Data.SqlDbType.NVarChar, 50) { Value = (object)Location ?? DBNull.Value });

                con.Open();
                cmd.ExecuteNonQuery();

            }

        }
        public void DeleteDepartment(string DepartmentName)
        {
            try
            {
                string sql = @"DELETE FROM [dbo].[Department] 
                               WHERE [DepartmentName]=@DepartmentName";


                using (SqlConnection myConnection = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, myConnection))
                    {
                        cmd.Parameters.AddWithValue("@DepartmentName", DepartmentName);

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