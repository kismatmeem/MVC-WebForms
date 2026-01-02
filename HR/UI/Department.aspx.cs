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
    public partial class Department : System.Web.UI.Page
    {
        DepartmentBLL ObjDepartmentBLL = new DepartmentBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            ShowDepartment();
        }

        private void ShowDepartment()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["dberp"].ToString();
                DataTable dtDepartment = new DataTable();
                string query = @"SELECT [DepartmentName],[DepartmentHead],[Location],[Dep_ID] FROM [dbo].[Department]";

                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, con))
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))

                {
                    da.Fill(dtDepartment);
                }
                grdDepartment.DataSource = dtDepartment;
                grdDepartment.DataBind();
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
                string DepartmentName = txtDepartmentName.Text;
                string DepartmentHead = txtDepartmentHead.Text;
                string Location = txtLocation.Text;
                ObjDepartmentBLL = new DepartmentBLL();
                ObjDepartmentBLL.AddDepartment(DepartmentName, DepartmentHead, Location);

                clear();
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }


        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string DepartmentName = txtDepartmentName.Text;
                string DepartmentHead = txtDepartmentHead.Text;
                string Location = txtLocation.Text;

                string sql = @"UPDATE [dbo].[Department]
               SET [DepartmentName] = @NewDepartmentName,
                   [DepartmentHead] = @DepartmentHead,
                   [Location] = @Location
               WHERE [DepartmentName] = @OldDepartmentName";

                


                //string sql = @"UPDATE [dbo].[Department]
                //SET [DepartmentName] = @DepartmentName,
                //    [DepartmentHead] = @DepartmentHead,
                //    [Location] = @Location
                //WHERE [Department Name] = @DepartmentName";



                string connectionString = ConfigurationManager.ConnectionStrings["dberp"].ToString();


                using (SqlConnection myConnection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, myConnection))
                    {
                        //cmd.Parameters.AddWithValue("@DepartmentName", DepartmentName);
                        //cmd.Parameters.AddWithValue("@DepartmentHead", DepartmentHead);
                        //cmd.Parameters.AddWithValue("@Location", Location);

                        cmd.Parameters.AddWithValue("@NewDepartmentName", txtDepartmentName.Text);
                        cmd.Parameters.AddWithValue("@DepartmentHead", txtDepartmentHead.Text);
                        cmd.Parameters.AddWithValue("@Location", txtLocation.Text);
                        cmd.Parameters.AddWithValue("@OldDepartmentName", lblDepartmentName.Text);


                        myConnection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                clear();
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }



        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                
                string sql = @"DELETE FROM [dbo].[Department] 
                               WHERE DepartmentName =@DepartmentName";


                string connectionString = ConfigurationManager.ConnectionStrings["dberp"].ToString();


                using (SqlConnection myConnection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, myConnection))
                    {
                        cmd.Parameters.AddWithValue("@DepartmentName", lblDepartmentName.Text);

                        myConnection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                clear();

            }

            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void clear()
        {
            txtDepartmentName.Text = string.Empty;
            txtDepartmentHead.Text = string.Empty;
            txtLocation.Text = string.Empty;
            txtDep_ID.Text = string.Empty;
           
        }

        protected void grdDepartment_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int selectIndex = Convert.ToInt32(e.CommandArgument.ToString());

            string departmentName = ((Label)grdDepartment.Rows[selectIndex].FindControl("lblgrdDepartmentName")).Text;

            if (e.CommandName.Equals("Select"))
            {
                txtDepartmentName.Text = ((Label)grdDepartment.Rows[selectIndex].FindControl("lblgrdDepartmentName")).Text;
                lblDepartmentName.Text = ((Label)grdDepartment.Rows[selectIndex].FindControl("lblgrdDepartmentName")).Text;

                txtDepartmentHead.Text = ((Label)grdDepartment.Rows[selectIndex].FindControl("lblgrdDepartmentHead")).Text;
                txtLocation.Text = ((Label)grdDepartment.Rows[selectIndex].FindControl("lblgrdLocation")).Text;
                txtDep_ID.Text = ((Label)grdDepartment.Rows[selectIndex].FindControl("lblgrdDep_ID")).Text;
            }
            else if (e.CommandName.Equals("Delete"))
            {
                ObjDepartmentBLL = new DepartmentBLL();
                ObjDepartmentBLL.RemoveDepartment(departmentName);
                ShowDepartment();
            }
        }

        protected void grdDepartment_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void grdDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //private static void ExecuteSql(string sql)
        //{
        //    try
        //    {
        //        string connectionString = ConfigurationManager.ConnectionStrings["dberp"].ConnectionString;
        //        var myConnection = new SqlConnection(connectionString);
        //        myConnection.Open();
        //        new SqlCommand(sql, myConnection).ExecuteNonQuery();
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }

        //}

        //protected void btnShow_Click(object sender, EventArgs e)
        //{
        //    string DepartmentName = txtDepartmentName.Text;
        //    lblDepartmentName.Text = DepartmentName;

        //    string DepartmentHead = txtDepartmentHead.Text;
        //    lblDepartmentHead.Text = DepartmentHead;

        //    string Location = txtLocation.Text;
        //    lblLocation.Text = Location;
        //}
    }
}