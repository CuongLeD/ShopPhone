using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using ShopPhone1.Models;
using System.Data;

namespace ShopPhone1
{
    public partial class EditCustomer : System.Web.UI.Page
    {
        protected static int customerId;
        protected static Customer customer;
        protected void Page_Load(object sender, EventArgs e)
        {
            customerId = Int32.Parse(Request.Params["id"].Trim());
            string connStr = "Server=BT; Database=PhoneShop; User=sa; Password=12345678";
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT TOP 1 customerId, customerName, customerPhoneNumber, customerAddress, dateCreate FROM Customers WHERE customerId=@customerId");
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = conn;
            cmd.Parameters.Add("@customerId", SqlDbType.Int).Value = customerId;
            SqlDataReader reader = cmd.ExecuteReader();
            customer = new Customer();
            while (reader.Read())
            {
                customer.Id = Int32.Parse(reader["customerId"].ToString().Trim());
                customer.Name = reader["customerName"].ToString().Trim();
                customer.Address = reader["customerAddress"].ToString().Trim();
                customer.PhoneNumber = reader["customerPhoneNumber"].ToString().Trim();
                customer.DateCreate = reader["customerName"].ToString().Trim();
                break;
            }
            conn.Close();




        }


        protected void btnEdit_onclick(object sender, EventArgs e)
        {
            customer.Name= txtName.Text;
            customer.Address = txtAddress.Text;
            customer.PhoneNumber = txtPhoneNumber.Text;

           
            string connStr = "Server=BT; Database=PhoneShop; User=sa; Password=12345678";
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            string queryStr = "UPDATE Customers SET customerName=@name, customerAddress=@address, customerPhoneNumber=@phone WHERE customerId=@id";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = queryStr;
            cmd.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = customer.Name;
            cmd.Parameters.Add("@address", SqlDbType.NVarChar, 100).Value = customer.Address;
            cmd.Parameters.Add("@phone", SqlDbType.NVarChar, 100).Value = customer.PhoneNumber;

            cmd.Parameters.Add("@id", SqlDbType.Int, 100).Value = customer.Id;
            int row = cmd.ExecuteNonQuery();
            Response.Redirect("ManageCustomer.aspx");
            conn.Close();

        }

    }
}