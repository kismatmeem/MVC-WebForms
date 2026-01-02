using HR.BLL;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace HR.UI
{
    public partial class EmployeeInformation : System.Web.UI.Page
    {
        EmployeeBLL ObjEmployeeBLL = new EmployeeBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        protected void btnShow_Click(object sender, EventArgs e)
        {
            ShowEmployee();
        }

        private void ShowEmployee()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["dberp"].ToString();
                DataTable dtEmployee = new DataTable();
                string query = @"SELECT [Employee Name],[Email],[Mobile No],[ID] FROM [dbo].[Employee]";

                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, con))
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))

                {
                    da.Fill(dtEmployee);
                }
                grdEmployee.DataSource = dtEmployee;
                grdEmployee.DataBind();
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
                string EmployeeName = txtEmployeeName.Text;
                string EmployeeEmail = txtEmail.Text;
                string EmployeeMobileNo = txtMobileNo.Text;
                 ObjEmployeeBLL = new EmployeeBLL();
                ObjEmployeeBLL.AddEmployee(EmployeeName, EmployeeEmail, EmployeeMobileNo);
              
                clear();
            }

             catch(Exception )
            {
                throw;
            }
        }


        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string employeeName = txtEmployeeName.Text;
                string employeeEmail = txtEmail.Text;
                string employeeMobileNo = txtMobileNo.Text;
                int employeeID = Convert.ToInt32(txtID.Text);

                string sql = @"UPDATE [dbo].[Employee]
               SET [Employee Name] = @Name,
                   [Mobile No] = @MobileNo,
                   [Email] = @Email
               WHERE ID = @ID";

                string connectionString = ConfigurationManager.ConnectionStrings["dberp"].ToString();


                using (SqlConnection myConnection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, myConnection))
                    {
                        cmd.Parameters.AddWithValue("@Name", employeeName);
                        cmd.Parameters.AddWithValue("@Email", employeeEmail);
                        cmd.Parameters.AddWithValue("@MobileNo", employeeMobileNo);
                        cmd.Parameters.AddWithValue("@ID", employeeID);

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
                int employeeID = Convert.ToInt32(txtID.Text);
                string sql = @"DELETE FROM [dbo].[Employee] 
                               WHERE ID =@ID";


                string connectionString = ConfigurationManager.ConnectionStrings["dberp"].ToString();


                using (SqlConnection myConnection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, myConnection))
                    {
                        cmd.Parameters.AddWithValue("@ID",employeeID);

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
            txtEmployeeName.Text = string.Empty;
            txtMobileNo.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtID.Text = string.Empty;
        }

        private static void ExecuteSql(string sql)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["dberp"].ConnectionString;
                var myConnection = new SqlConnection(connectionString);
                myConnection.Open();
                new SqlCommand(sql, myConnection).ExecuteNonQuery();
            }
             catch(Exception)
            {
                throw;
            }
            
        }

        protected void grdEmployee_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int selectIndex = Convert.ToInt32(e.CommandArgument.ToString());

            string employeeID= ((Label)grdEmployee.Rows[selectIndex].FindControl("lblEmployeeID")).Text;
           // string employeeID = grdEmployee.Rows[selectIndex].Cells[6].Text.ToString();

            if (e.CommandName.Equals("Select"))

            {

                txtEmployeeName.Text = ((Label)grdEmployee.Rows[selectIndex].FindControl("lblEmployeeName")).Text;
                txtEmail.Text = ((Label)grdEmployee.Rows[selectIndex].FindControl("lblEmail")).Text;
                txtMobileNo.Text = ((Label)grdEmployee.Rows[selectIndex].FindControl("lblMobileNo")).Text;
                txtID.Text = ((Label)grdEmployee.Rows[selectIndex].FindControl("lblEmployeeID")).Text;
            }
            else if (e.CommandName.Equals("Delete"))
            {

                ObjEmployeeBLL = new EmployeeBLL();
                ObjEmployeeBLL.RemoveEmployee( employeeID);
                ShowEmployee();
            }
        }

        protected void grdEmployee_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void grdEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }

    }
}