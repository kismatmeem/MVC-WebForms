using HR.DAL;
using HR.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HR.BLL
{
    public class CompanyBLL
    {
        CompanyDAL ObjCompanyDAL = new CompanyDAL();
        private string CompanyID;

        public void AddCompany(string CompanyName, string Address, string Email)
        {
            ObjCompanyDAL = new CompanyDAL();
            ObjCompanyDAL.InsertCompany(CompanyName, Address, Email);


        }

        internal void RemoveCompany(string CompanyID)
        {
            ObjCompanyDAL = new CompanyDAL();
            ObjCompanyDAL.DeleteCompany(CompanyID);
        }
    }
}