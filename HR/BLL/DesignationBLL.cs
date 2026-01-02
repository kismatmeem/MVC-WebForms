using HR.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HR.BLL
{
    public class DesignationBLL
    {
        DesignationDAL ObjDesignationDal = new DesignationDAL();
        private string D_ID;

        public string DesignationName { get; private set; }

        public void AddDesignation(string DesignationName, string Department, string Email)
        {
            ObjDesignationDal = new DesignationDAL();
            ObjDesignationDal.InsertDesignation(DesignationName,Department, Email);


        }

        internal void RemoveDesignation(string D_ID)
        {
            ObjDesignationDal = new DesignationDAL();
            ObjDesignationDal.DeleteDesignation(D_ID);
        }

    }
}
