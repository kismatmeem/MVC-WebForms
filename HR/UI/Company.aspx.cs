using HR.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HR.UI
{
    public partial class Company : System.Web.UI.Page
    {
       CompanyBLL ObjCompanyBLL = new CompanyBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnShow_Click(object sender, EventArgs e)
        {
            ShowCompany();
        }

        private void ShowCompany()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["dberp"].ToString();
                DataTable dtCompany = new DataTable();
                string query = @"SELECT [CompanyID],[CompanyName],[Address],[Email] FROM [dbo].[Company]";

                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, con))
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))

                {
                    da.Fill(dtCompany);
                }
                grdCompany.DataSource = dtCompany;
                grdCompany.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        protected void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
               // int CompanyID = Convert.ToInt32(txtCompanyID.Text);
                string CompanyName = txtCompanyName.Text;
                string Address = txtAddress.Text;
                string Email = txtEmail.Text;
                ObjCompanyBLL = new CompanyBLL();
                ObjCompanyBLL.AddCompany(CompanyName, Address,Email);

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
                string CompanyName = txtCompanyName.Text;
                string Address = txtAddress.Text;
                string Email = txtEmail.Text;
                //int CompanyID = Convert.ToInt32(txtCompanyID.Text);
                if (!int.TryParse(txtCompanyID.Text, out int CompanyID))
                {
                    // handle invalid/missing ID: show message or log and return
                    // e.g. lblError.Text = "Select a company before updating.";
                    return;
                }

                string sql = @"UPDATE [dbo].[Company]
               SET [CompanyName] = @CompanyName,
                   [Address] = @Address,
                   [Email] = @Email
               WHERE CompanyID = @CompanyID";

                string connectionString = ConfigurationManager.ConnectionStrings["dberp"].ToString();


                using (SqlConnection myConnection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, myConnection))
                    {
                        cmd.Parameters.AddWithValue("@CompanyName", CompanyName);
                        cmd.Parameters.AddWithValue("@Email", Email);
                        cmd.Parameters.AddWithValue("@Address", Address);
                        cmd.Parameters.AddWithValue("@CompanyID", CompanyID);

                        myConnection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                ShowCompany();
                clear();
            }

            catch (Exception ex )
            {
                throw ex;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int CompanyID = Convert.ToInt32(txtCompanyID.Text);
                string sql = @"DELETE FROM [dbo].[Company] 
                               WHERE CompanyID =@CompanyID";


                string connectionString = ConfigurationManager.ConnectionStrings["dberp"].ToString();


                using (SqlConnection myConnection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, myConnection))
                    {
                        cmd.Parameters.AddWithValue("@CompanyID", CompanyID);

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
            txtCompanyName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtCompanyID.Text = string.Empty;
        }

        protected void grdCompany_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            int selectIndex = Convert.ToInt32(e.CommandArgument.ToString());

            string CompanyID = ((Label)grdCompany.Rows[selectIndex].FindControl("lblCompanyID")).Text;
          

            if (e.CommandName.Equals("Select"))

            {

                txtCompanyName.Text = ((Label)grdCompany.Rows[selectIndex].FindControl("lblCompanyName")).Text;
                txtAddress.Text = ((Label)grdCompany.Rows[selectIndex].FindControl("lblAddress")).Text;
                txtEmail.Text = ((Label)grdCompany.Rows[selectIndex].FindControl("lblEmail")).Text;
                txtCompanyID.Text = ((Label)grdCompany.Rows[selectIndex].FindControl("lblCompanyID")).Text;
            }
            else if (e.CommandName.Equals("Delete"))
            {

                ObjCompanyBLL = new CompanyBLL();
                ObjCompanyBLL.RemoveCompany(CompanyID);
                ShowCompany();
            }
        }

        protected void grdCompany_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }

        protected void grdCompany_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }






        //protected void btnShow_Click(object sender, EventArgs e)
        //{
        //    string CompanyName = txtCompanyName.Text;
        //    lblCompanyName.Text = CompanyName;

        //    string Address = txtAddress.Text;
        //    lblAddress.Text = Address;


        //    string Email = txtEmail.Text;
        //    lblEmail.Text = Email;


        //}
    }
}