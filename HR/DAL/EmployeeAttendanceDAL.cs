using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HR.DAL
{
    public class EmployeeAttendanceDAL
    {
        private readonly string _connectionString;

        public EmployeeAttendanceDAL()
        {

            _connectionString = ConfigurationManager.ConnectionStrings["dberp"].ToString();
        }

        public void InsertEmployeeAttendance(int EmployeeID,DateTime Date,string Status)
        {
            try
            {
                const string sql = "INSERT INTO [dbo].[EmployeeAttendance] ([EmployeeID], [Date], [Status]) VALUES (@EmployeeID, @Date, @Status)";

                using (var con = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.Add(new SqlParameter("@EmployeeID", System.Data.SqlDbType.Int) { Value = (object)EmployeeID ?? DBNull.Value });
                    cmd.Parameters.Add(new SqlParameter("@Date", System.Data.SqlDbType.DateTime) { Value = (object)Date ?? DBNull.Value });
                    cmd.Parameters.Add(new SqlParameter("@Status", System.Data.SqlDbType.NVarChar, 50) { Value = (object)Status ?? DBNull.Value });

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public void UpdateAttendance(int AttendanceID, int EmployeeID, DateTime Date, string Status)
        {
            try
            {
                string sql = @"UPDATE [dbo].[EmployeeAttendance] 
                               SET [EmployeeID] = @EmployeeID, 
                                   [Date] = @Date, 
                                   [Status] = @Status
                               WHERE [AttendanceID] = @AttendanceID";

                using (SqlConnection con = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@AttendanceID", AttendanceID);
                    cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                    cmd.Parameters.AddWithValue("@Date", Date);
                    cmd.Parameters.AddWithValue("@Status", Status);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void DeleteAttendance(int AttendanceID)
        {
            try
            {
                string sql = @"DELETE FROM [dbo].[EmployeeAttendance] 
                               WHERE [AttendanceID] = @AttendanceID";

                using (SqlConnection con = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@AttendanceID", AttendanceID);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }

}
