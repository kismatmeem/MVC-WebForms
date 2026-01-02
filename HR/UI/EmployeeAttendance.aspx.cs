using HR.BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HR.UI
{
    public partial class EmployeeAttendance : System.Web.UI.Page
    {
        EmployeeAttendanceBLL ObjEmployeeAttendanceBLL = new EmployeeAttendanceBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            ShowEmployeeAttendance();
        }

        private void ShowEmployeeAttendance()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["dberp"].ToString();
                DataTable dtAttendance = new DataTable();
                string query = @"SELECT [EmployeeID],[Date],[Status],[AttendanceID] FROM [dbo].[EmployeeAttendance]";

                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, con))
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))

                {
                    da.Fill(dtAttendance);
                }
                grdAttendance.DataSource = dtAttendance;
                grdAttendance.DataBind();
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                int EmployeeID = Convert.ToInt32(txtEmployeeID.Text);
                DateTime Date = Convert.ToDateTime(txtDate.Text);
                string Status = ddlStatus.SelectedValue;

                ObjEmployeeAttendanceBLL = new EmployeeAttendanceBLL();
                ObjEmployeeAttendanceBLL.AddEmployeeAttendance(EmployeeID, Date, Status);

                clear();
            }

            catch (Exception)
            {
                throw;
            }
        }


        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int EmployeeID = Convert.ToInt32(txtEmployeeID.Text);
                DateTime Date = Convert.ToDateTime(txtDate.Text);
                string Status = ddlStatus.SelectedValue;

                string sql = @"UPDATE [dbo].[EmployeeAttendance]
               SET [EmployeeID] = @EmployeeID,
                   [Date] = @Date,
                   [Status] = @Status
               WHERE AttendanceID = @AttendanceID";

                string connectionString = ConfigurationManager.ConnectionStrings["dberp"].ToString();


                using (SqlConnection myConnection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, myConnection))
                    {
                        cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                        cmd.Parameters.AddWithValue("@Date", Date);
                        cmd.Parameters.AddWithValue("@Status", Status);
                        
                        myConnection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                clear();
            }

            catch (Exception)
            {
                throw;
            }
        }



        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int AttendanceID = Convert.ToInt32(txtAttendanceID.Text);
                string sql = @"DELETE FROM [dbo].[EmployeeAttendance] 
                               WHERE AttendanceID =@AttendanceID";


                string connectionString = ConfigurationManager.ConnectionStrings["dberp"].ToString();


                using (SqlConnection myConnection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, myConnection))
                    {
                        cmd.Parameters.AddWithValue("@AttendanceID", AttendanceID);

                        myConnection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                clear();

            }

            catch (Exception)
            {
                throw;
            }
        }


        private void clear()
        {
            txtAttendanceID.Text = string.Empty;
            txtEmployeeID.Text = string.Empty;
            txtDate.Text = string.Empty;
            ddlStatus.SelectedIndex = 0;
        }


        protected void grdAttendance_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int selectIndex = Convert.ToInt32(e.CommandArgument.ToString());

            
            string AttendanceID = ((Label)grdAttendance.Rows[selectIndex].FindControl("lblgrdAttendanceId")).Text;

            if (e.CommandName.Equals("Select"))
            {
               txtAttendanceID.Text = ((Label)grdAttendance.Rows[selectIndex].FindControl("lblgrdAttendanceId")).Text;
               txtEmployeeID.Text = ((Label)grdAttendance.Rows[selectIndex].FindControl("lblgrdEmployeeID")).Text;
                //    txtDate.Text = ((Label)grdAttendance.Rows[selectIndex].FindControl("lblgrdDate")).Text;
                //    ddlStatus.SelectedValue = ((Label)grdAttendance.Rows[selectIndex].FindControl("lblgrdStatus")).Text;
               
                DateTime selectedDate = Convert.ToDateTime(((Label)grdAttendance.Rows[selectIndex].FindControl("lblgrdDate")).Text);
                txtDate.Text = selectedDate.ToString("yyyy-MM-dd");

                // Fix Status dropdown
                string status = ((Label)grdAttendance.Rows[selectIndex].FindControl("lblgrdStatus")).Text.Trim();
                ddlStatus.ClearSelection();
                if (ddlStatus.Items.FindByValue(status) != null)
                {
                    ddlStatus.SelectedValue = status;
                }

            }
                     
            
        
            else if (e.CommandName.Equals("Delete"))
            {
                ObjEmployeeAttendanceBLL = new EmployeeAttendanceBLL();
                ObjEmployeeAttendanceBLL.RemoveEmployeeAttendance(Convert.ToInt32(AttendanceID));

                ShowEmployeeAttendance();
                clear();
            }
        }


        protected void grdAttendance_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void grdAttendance_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}