using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopPhone1.Models
{
    public class Order
    {
        private string shopName;

        public string ShopName
        {
            get { return shopName; }
            set { shopName = value; }
        }
        private int shopId;

        public int ShopId
        {
            get { return shopId; }
            set { shopId = value; }
        }
        private int orderId;

        public int OrderId
        {
            get { return orderId; }
            set { orderId = value; }
        }
        private string customerName;

        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value; }
        }
        private string employeeName;

        public string EmployeeName
        {
            get { return employeeName; }
            set { employeeName = value; }
        }
        private int status;

        public int Status
        {
            get { return status; }
            set { status = value; }
        }
        private string dateCreate;

        public string DateCreate
        {
            get { return dateCreate; }
            set { dateCreate = value; }
        }
    }
}