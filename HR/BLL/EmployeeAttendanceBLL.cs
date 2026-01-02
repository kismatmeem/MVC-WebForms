using HR.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HR.BLL
{
    public class EmployeeAttendanceBLL
    {
        EmployeeAttendanceDAL ObjEmployeeAttendanceDal = new EmployeeAttendanceDAL();
        private string AttendanceID;

        public void AddEmployeeAttendance(int EmployeeID, DateTime Date, string Status)
        {
            ObjEmployeeAttendanceDal = new EmployeeAttendanceDAL();
            ObjEmployeeAttendanceDal.InsertEmployeeAttendance(EmployeeID, Date, Status);


        }

        internal void RemoveEmployeeAttendance(int AttendanceID)
        {
            ObjEmployeeAttendanceDal = new EmployeeAttendanceDAL();
            ObjEmployeeAttendanceDal.DeleteAttendance(AttendanceID);
        }
    }
}