using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopPhone1.Models
{
    public class Customer
    {

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string phoneNumber;

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }
        private string address;

        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        private string dateCreate;

        public string DateCreate
        {
            get { return dateCreate; }
            set { dateCreate = value; }
        }
    }
}