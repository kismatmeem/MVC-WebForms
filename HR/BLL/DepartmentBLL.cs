using HR.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HR.BLL
{
    public class DepartmentBLL
    {
        DepartmentDAL ObjDepartmentDAL = new DepartmentDAL();
        private string DepartmentName;

        public void AddDepartment(string DepartmentName, string DepartmentHead, string Location)
        {
            ObjDepartmentDAL = new DepartmentDAL();
            ObjDepartmentDAL.InsertDepartment(DepartmentName, DepartmentHead, Location);


        }

        internal void RemoveDepartment(string DepartmentName)
        {
            ObjDepartmentDAL = new DepartmentDAL();
            ObjDepartmentDAL.DeleteDepartment(DepartmentName);
        }
    }
}