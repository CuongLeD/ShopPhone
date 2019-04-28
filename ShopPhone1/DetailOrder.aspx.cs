using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using ShopPhone1.Models;
using System.Data;
using ShopPhone1.Controller;
namespace ShopPhone1
{
    public partial class DetailOrder : System.Web.UI.Page
    {
        protected static string show = "";
        protected static string customerName = "";
        protected static string employeeName = "";
        protected static List<Phone> listPhone;
        protected static int totalPayment = 0;
        protected static int orderId = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            //int idAdmin = (int)Session["employeeId"];
            orderId = Int32.Parse(Request.QueryString["orderId"]);
            string connStr = "Server=BT; Database=PhoneShop; User=sa; Password=12345678";
            SqlConnection conn = new SqlConnection(connStr);

            //take data of customer and employee
            conn.Open();
            String queryStr = "SELECT  employeeName, customerName FROM Customers, Employees, Orders WHERE Orders.orderId=@orderId AND Customers.customerId=Orders.customerId AND Employees.employeeId=Orders.employeeId; ";
            SqlCommand cmd = new SqlCommand(queryStr);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = conn;
            cmd.Parameters.Add("@orderId", SqlDbType.Int).Value = orderId;
            SqlDataReader reader = cmd.ExecuteReader();
           
            while (reader.Read())
            {
                customerName = reader["customerName"].ToString().Trim();
                employeeName = reader["employeeName"].ToString().Trim();
            }
            conn.Close();

            //take data of PhoneOfOrder from database. 
            conn.Open();
            String queryStrPhone = "SELECT  phoneName, phonePrice, quantity FROM Phones, PhoneOfOrder, Orders WHERE Orders.orderId=@orderId AND Phones.phoneId=PhoneOfOrder.phoneId AND Orders.orderId=PhoneOfOrder.orderId; ";
            SqlCommand cmdListPhone = new SqlCommand(queryStrPhone);
            cmdListPhone.CommandType = System.Data.CommandType.Text;
            cmdListPhone.Connection = conn;
            cmdListPhone.Parameters.Add("@orderId", SqlDbType.Int).Value = orderId;
            SqlDataReader readerListPhone = cmdListPhone.ExecuteReader();
            listPhone = new List<Phone>();
            while (readerListPhone.Read())
            {
                Phone phone = new Phone();                
                phone.PhoneName = readerListPhone["phoneName"].ToString().Trim();
                phone.PhonePrice = Int32.Parse(readerListPhone["phonePrice"].ToString().Trim());                
                phone.PhoneQuantity = Int32.Parse(readerListPhone["quantity"].ToString().Trim());
                //phone.ShopId = Int32.Parse(reader["shopId"].ToString().Trim());
                listPhone.Add(phone);
            }
            conn.Close();

            int stt = 1;
            foreach (Phone phone in listPhone)
            {
                show += "<tr>";
                show += "<td>" + stt + "</td>";
                show += "<td>" + phone.PhoneName + "</a></td>";
                show += "<td>" + phone.PhoneQuantity + "</td>";
                show += "<td>" + FormatNumber.FormatPrice(phone.PhonePrice) + "</td>";
                show += "<td>" + FormatNumber.FormatPrice(phone.PhoneQuantity*phone.PhonePrice) + "</td>";                
                show += "</tr>";

                totalPayment += phone.PhonePrice * phone.PhoneQuantity;
            }


        }
    }
}