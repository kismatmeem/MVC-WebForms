using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HR.UI
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            string CompanyName = txtCompanyName.Text;
            lblcompanyname.Text = CompanyName;

            string Address = txtAddress.Text;
            lblAdress.Text = Address;

            string Email = txtEmail.Text;
            lblEmail.Text = Email;

            string CompanyType = txtCompanyType.Text;
            lblCompanyType.Text = CompanyType;

            string Website = txtWebsite.Text;
            lblWebsite.Text = Website;



        }
    }
}