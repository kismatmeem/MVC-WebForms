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
    public partial class Designation : System.Web.UI.Page
    {
        DesignationBLL ObjDesignationBLL = new DesignationBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            ShowDesignation();
        }

        private void ShowDesignation()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["dberp"].ToString();
                DataTable dtDesignation = new DataTable();
                string query = @"SELECT [DesignationName],[Department],[Email],[D_ID] FROM [dbo].[Designation]";

                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, con))
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))

                {
                    da.Fill(dtDesignation);
                }
                grdDesignation.DataSource = dtDesignation;
                grdDesignation.DataBind();
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
                string DesignationName = txtDesignationName.Text;
                string Department = txtDepartment.Text;
                string Email = txtEmail.Text;
                ObjDesignationBLL = new DesignationBLL();
                ObjDesignationBLL.AddDesignation(DesignationName,Department,Email);

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
                string DesignationName = txtDesignationName.Text;
                string Department = txtDepartment.Text;
                string Email = txtEmail.Text;
                int D_ID = Convert.ToInt32(txtD_ID.Text);

                string sql = @"UPDATE [dbo].[Designation]
               SET [DesignationName] = @DesignationName,
                   [Department] = @Department,
                   [Email] = @Email
               WHERE D_ID = @D_ID";

                string connectionString = ConfigurationManager.ConnectionStrings["dberp"].ToString();


                using (SqlConnection myConnection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, myConnection))
                    {
                        cmd.Parameters.AddWithValue("@DesignationName", DesignationName);
                        cmd.Parameters.AddWithValue("@Department", Department);
                        cmd.Parameters.AddWithValue("@Email", Email);
                        cmd.Parameters.AddWithValue("@D_ID", D_ID);

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
                int D_ID = Convert.ToInt32(txtD_ID.Text);
                string sql = @"DELETE FROM [dbo].[Designation] 
                               WHERE D_ID =@D_ID";


                string connectionString = ConfigurationManager.ConnectionStrings["dberp"].ToString();


                using (SqlConnection myConnection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, myConnection))
                    {
                        cmd.Parameters.AddWithValue("@D_ID", D_ID);

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
            txtDesignationName.Text = string.Empty;
            txtDepartment.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtD_ID.Text = string.Empty;
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
            catch (Exception)
            {
                throw;
            }

        }
        protected void grdDesignation_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void grdDesignation_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int selectIndex = Convert.ToInt32(e.CommandArgument.ToString());

            string D_ID = ((Label)grdDesignation.Rows[selectIndex].FindControl("lblD_ID")).Text;
            

            if (e.CommandName.Equals("Select"))

            {

                txtDesignationName.Text = ((Label)grdDesignation.Rows[selectIndex].FindControl("lblDesignationName")).Text;
                txtDepartment.Text = ((Label)grdDesignation.Rows[selectIndex].FindControl("lblDepartment")).Text;
                txtEmail.Text = ((Label)grdDesignation.Rows[selectIndex].FindControl("lblEmail")).Text;
                txtD_ID.Text = ((Label)grdDesignation.Rows[selectIndex].FindControl("lblD_ID")).Text;
            }
            else if (e.CommandName.Equals("Delete"))
            {
                
                ObjDesignationBLL = new DesignationBLL();
                ObjDesignationBLL.RemoveDesignation(D_ID);
                ShowDesignation();
            }
        }
    }
}