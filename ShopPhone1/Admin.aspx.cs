using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using ShopPhone1.Controller;
using ShopPhone1.Models;

namespace ShopPhone1
{
    public partial class Admin : System.Web.UI.Page
    {

        protected string show = "";
        protected static List<Phone> listPhone;

        protected void Page_Load(object sender, EventArgs e)
        {

            int idAdmin = (int)Session["employeeId"];
            string connStr = "Server=BT; Database=PhoneShop; User=sa; Password=12345678";
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            String queryStr = "SELECT shopId,Phones.phoneId, phoneName, manufacturer, phonePrice, imageLink, phoneDescrible, quantity FROM dbo.Phones, PhoneOfShop WHERE (PhoneOfShop.shopId=(SELECT TOP 1 shopId FROM Employees WHERE employeeId='" + idAdmin + "'))  AND (Phones.phoneId=PhoneOfShop.phoneId)";
            SqlCommand cmd = new SqlCommand(queryStr);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = conn;

            SqlDataReader reader = cmd.ExecuteReader();

            listPhone = new List<Phone>();

            while (reader.Read())
            {
                Phone phone = new Phone();
                phone.PhoneId = Int32.Parse(reader["phoneId"].ToString().Trim());
                phone.PhoneName = reader["phoneName"].ToString().Trim();
                phone.PhonePrice = Int32.Parse(reader["phonePrice"].ToString().Trim());
                phone.Manufacturer = reader["manufacturer"].ToString().Trim();
                phone.ImageLink = reader["imageLink"].ToString().Trim();
                phone.PhoneDescrible = reader["phoneDescrible"].ToString().Trim();
                phone.PhoneQuantity = Int32.Parse(reader["quantity"].ToString().Trim());
                phone.ShopId = Int32.Parse(reader["shopId"].ToString().Trim());
                listPhone.Add(phone);


            }
            conn.Close();

            foreach (Phone phone in listPhone)
            {
                show += "<tr>";
                show += "<td><a href='DetailPhone.aspx?id=" + phone.PhoneId + "'>" + phone.PhoneId + "</a></td>";
                show += "<td>" + phone.PhoneName + "</td>";
                show += "<td>" + FormatNumber.FormatPrice(phone.PhonePrice) + "</td>";
                show += "<td>" + phone.PhoneQuantity + "</td>";
                show += "<td>" + phone.Manufacturer + "</td>";
                show += "<td>" + phone.ShopId + "</td>";
                show += "<td><a href='AddAmountPhone.aspx?id=" + phone.PhoneId + "'>Thêm </a></td>";
                show += "<td><a href='EditPhone.aspx?id=" + phone.PhoneId + "'>Sửa </a></td>";
                show += "<td><a href='DeletePhone.aspx?id=" + phone.PhoneId + "'>Xóa </a></td>";
                show += "</tr>";
            }


        }
    }
}