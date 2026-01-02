using HR.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HR.BLL
{
    public class EmployeeBLL
    {
        EmployeeDAL ObjEmployeeDal = new EmployeeDAL();
        private string EmployeeID;

        public void AddEmployee( string EmployeeName, string Email,string MobileNo)
            {
            ObjEmployeeDal = new EmployeeDAL();
            ObjEmployeeDal.InsertEmployee( EmployeeName, Email, MobileNo);


        }

        internal void RemoveEmployee(string EmployeeID)
        {
            ObjEmployeeDal = new EmployeeDAL();
            ObjEmployeeDal.DeleteEmployee(EmployeeID);
        }

    }
}