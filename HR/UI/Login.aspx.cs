using System;
using System.Web.UI;

namespace HR.UI
{
    public partial class Login : Page
    {
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string fixedUsername = "kismat";
            string fixedPassword = "1234";

            if (txtUsername.Text == fixedUsername && txtPassword.Text == fixedPassword)
            {
                // Save session
                Session["username"] = txtUsername.Text;

                // Redirect to Home page
                Response.Redirect("HomePage.aspx");
            }
            else
            {
                lblMessage.Text = "Invalid Username or Password";
            }
        }
    }
}
