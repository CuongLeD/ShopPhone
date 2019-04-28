using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using ShopPhone1.Models;

namespace ShopPhone1
{
    public partial class ManageCustomer : System.Web.UI.Page
    {
        protected static string show = "";
        protected static List<Customer> listCustomer;

        protected void Page_Load(object sender, EventArgs e)
        {

            
            string connStr = "Server=BT; Database=PhoneShop; User=sa; Password=12345678";
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            String queryStr = "SELECT customerId, customerName, customerPhoneNumber, customerAddress, dateCreate FROM Customers";
            SqlCommand cmd = new SqlCommand(queryStr);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = conn;
            SqlDataReader reader = cmd.ExecuteReader();
            listCustomer = new List<Customer>();

            while (reader.Read())
            {
                Customer customer = new Customer();
                customer.Id = Int32.Parse(reader["customerId"].ToString().Trim());
                customer.Name = reader["customerName"].ToString().Trim();
                customer.Address = reader["customerAddress"].ToString().Trim();
                customer.PhoneNumber = reader["customerPhoneNumber"].ToString().Trim();
                customer.DateCreate = reader["dateCreate"].ToString().Trim();
                listCustomer.Add(customer);
            }
            conn.Close();

            int stt = 1;
            foreach (Customer customer in listCustomer)
            {
                show += "<tr>";
                show += "<td>" + stt + "</td>";
                show += "<td>" + customer.Id + "</a></td>";
                show += "<td>" + customer.Name + "</td>";
                show += "<td>" +customer.Address + "</td>";
                show += "<td>" + customer.PhoneNumber + "</td>";
                show += "<td>" + customer.DateCreate + "</td>";               
                show += "<td><a href='EditCustomer.aspx?id=" + customer.Id + "'>Sửa </a></td>";
                stt++;
                show += "</tr>";
            }


        }
    }
}