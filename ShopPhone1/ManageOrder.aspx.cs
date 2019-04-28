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
    public partial class ManageOrder : System.Web.UI.Page
    {
        protected static string show = "";
        protected static List<Order> listOrder;

        protected void Page_Load(object sender, EventArgs e)
        {

            
            string connStr = "Server=BT; Database=PhoneShop; User=sa; Password=12345678";
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            String queryStr = "SELECT shopName, orderId, customerName, employeeName, Orders.dateCreate, status FROM Orders, Customers, Employees, Shops WHERE Orders.employeeId=Employees.employeeId AND Orders.customerId=Customers.customerId AND status='0' AND Shops.shopId=Employees.shopId";
            SqlCommand cmd = new SqlCommand(queryStr);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = conn;

            SqlDataReader reader = cmd.ExecuteReader();
            listOrder= new List<Order>();

            while (reader.Read())
            {
                Order order = new Order();
                order.OrderId = Int32.Parse(reader["orderId"].ToString().Trim());
                order.CustomerName = reader["customerName"].ToString().Trim();
                order.EmployeeName = reader["employeeName"].ToString().Trim();
                order.Status = Int32.Parse(reader["status"].ToString().Trim());
                order.DateCreate = reader["dateCreate"].ToString().Trim();
                //order.ShopId = Int32.Parse(reader["shopId"].ToString().Trim());
                order.ShopName = reader["shopName"].ToString().Trim();
                listOrder.Add(order);
            }
            conn.Close();

            int stt = 1;
            foreach (Order order in listOrder)
            {
                show += "<tr>";
                show += "<td>" + stt + "</td>";
                show += "<td>" + order.ShopName + "</td>";
                show += "<td>" + order.OrderId+ "</a></td>";
                show += "<td>" + order.CustomerName + "</td>";
                 show += "<td>" + order.EmployeeName + "</td>";
                show += "<td>" + order.DateCreate + "</td>";
               show += "<td><a href='DetailOrder.aspx?orderId=" + order.OrderId + "' >Chi tiết  </a></td>";
                show += "<td><a href='CancelOrder.aspx?orderId=" + order.OrderId + "' >Hủy  </a></td>";
                

                show += "</tr>";
                stt++;
            }


        }
    }
}