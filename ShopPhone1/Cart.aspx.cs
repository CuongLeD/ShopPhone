using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using ShopPhone1.Controller;
using System.Data;
using ShopPhone1.Models;
namespace ShopPhone1
{
    public partial class Cart : System.Web.UI.Page
    {
        public static string categories = "";
        protected static int total = 0;
        protected static string totalPayment = "";
        protected static string showListPhone = "";
        protected static string showSimilarPhone = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            showSimilarPhone = "";
            showListPhone = "";
            categories = "";
            totalPayment = "";
            total = 0;
            string connStr = "Server=BT; Database=PhoneShop; User=sa; Password=12345678";
            SqlConnection conn = new SqlConnection(connStr);
            if (Session["cart"] != null)
            {
                
                List<ItemCart> listItem = new List<ItemCart>((List<ItemCart>)Session["cart"]);
                
                foreach (ItemCart item in listItem)
                {
                   
                    showListPhone += "<tr>";
                    showListPhone += "<td><img class='img-responsive' src='" + item.ItemImage + "' alt='' /></td>"; 
                    showListPhone += "<td>" + item.ItemName +  "</a></td>";
                    showListPhone += "<td>" + item.Quantity + " </td>";
                    showListPhone += "<td>" + FormatNumber.FormatPrice(item.ItemPrice) + "</td>";
                    showListPhone += "<td>" + FormatNumber.FormatPrice(item.Quantity * item.ItemPrice) + "</td>";
                    showListPhone += "<td><a href='DeletePhoneFromCart.aspx?id=" + item.ItemId + "'>Xóa</td>";
                    showListPhone += "</tr>";
                    total += (item.ItemPrice * item.Quantity);
                    
                }

                totalPayment = FormatNumber.FormatPrice(total);
            }
            else
            {
                Response.Write("Session null");
            }

            //show similar phone
            conn.Open();
            SqlCommand cmdSimilarPhone = new SqlCommand("SELECT TOP 4 [phoneId],[phoneName],[manufacturer],[phonePrice],[imageLink],[phoneDescrible] FROM Phones");
            cmdSimilarPhone.CommandType = System.Data.CommandType.Text;
            cmdSimilarPhone.Connection = conn;
            
            SqlDataReader readerSimilarPhone = cmdSimilarPhone.ExecuteReader();
            List<Phone> listPhone = new List<Phone>();
            while (readerSimilarPhone.Read())
            {
                Phone phoneSimilar = new Phone();
                phoneSimilar.PhoneId = Int32.Parse(readerSimilarPhone["phoneId"].ToString().Trim());
                phoneSimilar.PhoneName = readerSimilarPhone["phoneName"].ToString().Trim();
                phoneSimilar.PhonePrice = Int32.Parse(readerSimilarPhone["phonePrice"].ToString().Trim());
                phoneSimilar.Manufacturer = readerSimilarPhone["manufacturer"].ToString().Trim();
                phoneSimilar.ImageLink = readerSimilarPhone["imageLink"].ToString().Trim();
                phoneSimilar.PhoneDescrible = readerSimilarPhone["phoneDescrible"].ToString().Trim();

                listPhone.Add(phoneSimilar);
            }
            conn.Close();

            foreach (Phone phone1 in listPhone)
            {
                showSimilarPhone += "<div class='col-md-3 col-sm-6 center-responsive'>";
                showSimilarPhone += "<div class='product same-height'>";
                showSimilarPhone += "<a href='Detail.aspx?id=" + phone1.PhoneId + "' >";
                showSimilarPhone += "<img class='img-responsive' src='" + phone1.ImageLink + "' alt='' />";
                showSimilarPhone += "<div class='text'>";
                showSimilarPhone += "<h3>";
                showSimilarPhone += phone1.PhoneName;
                showSimilarPhone += "</h3>";
                showSimilarPhone += "<p class='price'>" + FormatNumber.FormatPrice(phone1.PhonePrice) + " VNĐ" + "</p>";
                showSimilarPhone += "<p class='button' align = 'center'<a class='btn btn-primary' href='Detail.aspx?id=" + phone1.PhoneId + "'>" + "Xem chi tiết</a></p>";
                showSimilarPhone += "</div>";
                showSimilarPhone += "</a>";
                showSimilarPhone += "</div>";
                showSimilarPhone += "</div>";
            }


            //take categories from database
            conn.Open();
            SqlCommand cmdCategories = new SqlCommand("SELECT DISTINCT [manufacturer] FROM Phones");
            cmdCategories.CommandType = System.Data.CommandType.Text;
            cmdCategories.Connection = conn;
            SqlDataReader readerCategories = cmdCategories.ExecuteReader();
            while (readerCategories.Read())
            {
                categories += "<li>";
                categories += "<a href='Shop.aspx?category=" + readerCategories["manufacturer"] + "'>" + readerCategories["manufacturer"] + "</a>";
                categories += "<li>";

            }
            conn.Close();

        }
        
    }
}