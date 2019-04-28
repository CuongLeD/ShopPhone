using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using ShopPhone1.Models;



namespace ShopPhone1.Controller
{
    public class Database
    {
        private static string conStr = "Server=BT; Database=PhoneShop; user=sa; password=12345678";

        public static void AddP(string name, string manufacturer, int price, string imgLink, string describle)
        {
            SqlConnection conn = new SqlConnection(conStr);
            conn.Open();
            string insertPhone = "INSERT INTO [PhoneShop].[dbo].[Phones]([phoneName],[manufacturer],[phonePrice],[imageLink],[phoneDescrible]) VALUES (@name, @manufacturer, @price, @imageLink, @describle)";
            SqlCommand queryAddPhone = new SqlCommand();
            
            queryAddPhone.Connection = conn;
            queryAddPhone.CommandText = insertPhone;
            queryAddPhone.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = name;
            queryAddPhone.Parameters.Add("@manufacturer", SqlDbType.NVarChar, 100).Value = manufacturer;
            queryAddPhone.Parameters.Add("@price", SqlDbType.Int).Value = price;
            queryAddPhone.Parameters.Add("@imageLink", SqlDbType.VarChar, 100).Value = imgLink;
            queryAddPhone.Parameters.Add("@describle", SqlDbType.NVarChar, 255).Value = describle;
            queryAddPhone.ExecuteNonQuery();
            
            conn.Close();
           
        }

        
        public static int AddCustomer(Customer customer)
        {
            int customerId = 0; ;
            SqlConnection conn = new SqlConnection(conStr);
            conn.Open();
            string insertCustomer = "INSERT INTO Customers(customerName, customerPhoneNumber, customerAddress, dateCreate) VALUES (@name, @phone, @address, @date)";
            SqlCommand queryAddPhone = new SqlCommand();
            queryAddPhone.Connection = conn;
            queryAddPhone.CommandText = insertCustomer;
            queryAddPhone.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = customer.Name;
            queryAddPhone.Parameters.Add("@phone", SqlDbType.NVarChar, 100).Value = customer.PhoneNumber;
            queryAddPhone.Parameters.Add("@address", SqlDbType.NVarChar, 100).Value = customer.Address;
            queryAddPhone.Parameters.Add("@date", SqlDbType.DateTime).Value = DateTime.Now;            
            queryAddPhone.ExecuteNonQuery();
            conn.Close();


            conn.Open();
            string customrIdStr = "SELECT TOP 1 customerId FROM Customers WHERE customerName=@name AND customerPhoneNumber=@phone";
            SqlCommand querySelectId = new SqlCommand();
            querySelectId.Connection = conn;
            querySelectId.CommandText = customrIdStr;
            querySelectId.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = customer.Name;
            querySelectId.Parameters.Add("@phone", SqlDbType.VarChar, 100).Value = customer.PhoneNumber;
            SqlDataReader reader = querySelectId.ExecuteReader();
            while (reader.Read())
            {
                customerId = Int32.Parse(reader["customerId"].ToString().Trim());
            }

            return customerId;
        }
        

        public static int AddOrder(int customerId, int employeeId)
        {
            int orderId = 0;
            SqlConnection conn = new SqlConnection(conStr);
            
            //Insert order on database
            conn.Open();
            string insertOrder = "INSERT INTO Orders(customerId, employeeId, dateCreate, status) VALUES (@customerId, @employeeId, @date, @status)";
            SqlCommand queryAddOrder = new SqlCommand();
            queryAddOrder.Connection = conn;
            queryAddOrder.CommandText = insertOrder;
            queryAddOrder.Parameters.Add("@customerId", SqlDbType.Int).Value = customerId;
            queryAddOrder.Parameters.Add("@employeeId", SqlDbType.Int).Value = employeeId;
            queryAddOrder.Parameters.Add("@date", SqlDbType.DateTime).Value = DateTime.Now;
            queryAddOrder.Parameters.Add("@status", SqlDbType.Bit).Value = 0;
            queryAddOrder.ExecuteNonQuery();
            conn.Close();

            //Take  orderId 
            conn.Open();
            string customrIdStr = "SELECT TOP 1 orderId FROM Orders WHERE customerId=@customerId AND employeeId=@employeeId";
            SqlCommand querySelectId = new SqlCommand();
            querySelectId.Connection = conn;
            querySelectId.CommandText = customrIdStr;
            querySelectId.Parameters.Add("@customerId", SqlDbType.Int).Value = customerId;
            querySelectId.Parameters.Add("@employeeId", SqlDbType.Int).Value = employeeId;
            SqlDataReader reader = querySelectId.ExecuteReader();
            while (reader.Read())
            {
                orderId = Int32.Parse(reader["orderId"].ToString().Trim());
            }
            conn.Close();
            return orderId;
        }

        public static void addItemToOrder(int orderId, int phoneId, int quantity)
        {
            SqlConnection conn = new SqlConnection(conStr);
            conn.Open();
            string insertOrder = "INSERT INTO PhoneOfOrder(orderId, phoneId, quantity) VALUES (@orderId, @phoneId, @quantity)";
            SqlCommand queryAddOrder = new SqlCommand();
            queryAddOrder.Connection = conn;
            queryAddOrder.CommandText = insertOrder;
            queryAddOrder.Parameters.Add("@orderId", SqlDbType.Int).Value = orderId;
            queryAddOrder.Parameters.Add("@phoneId", SqlDbType.Int).Value = phoneId;
            queryAddOrder.Parameters.Add("@quantity", SqlDbType.Int).Value = quantity;
            queryAddOrder.ExecuteNonQuery();
            conn.Close();

        }


    }


}