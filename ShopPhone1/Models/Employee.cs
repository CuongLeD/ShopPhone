using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopPhone1.Models
{
    public class Employee
    {
        private int shopId;

        public int ShopId
        {
            get { return shopId; }
            set { shopId = value; }
        }
        private int employeeId;

        public int EmployeeId
        {
            get { return employeeId; }
            set { employeeId = value; }
        }
        private string employeeName;

        public string EmployeeName
        {
            get { return employeeName; }
            set { employeeName = value; }
        }
        private string employeeAddress;

        public string EmployeeAddress
        {
            get { return employeeAddress; }
            set { employeeAddress = value; }
        }
        private string employeePosition;

        public string EmployeePosition
        {
            get { return employeePosition; }
            set { employeePosition = value; }
        }
        private string employeePhone;

        public string EmployeePhone
        {
            get { return employeePhone; }
            set { employeePhone = value; }
        }
        private string dateBegin;

        public string DateBegin
        {
            get { return dateBegin; }
            set { dateBegin = value; }
        }
    }
}