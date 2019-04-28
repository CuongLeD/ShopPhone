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
using ShopPhone1.Controller;

namespace ShopPhone1
{
    public partial class Detail : System.Web.UI.Page
    {
        protected static Phone phone;
        protected static string categories = "";
        protected static string showDetailPhone = "";
            protected static string showPricePhone = "";
        protected static string showSimilarPhone = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["cart"] == null)
            {
                Session["cart"] = new List<ItemCart>();
            }          
           
            if (Request.QueryString["id"] != null)
            {
                showPricePhone = "";
                 categories = "";
                showDetailPhone = "";
                showSimilarPhone = "";
                string connStr = "Server=BT; Database=PhoneShop; User=sa; Password=12345678";
                SqlConnection conn = new SqlConnection(connStr);
                int phoneId = Int32.Parse(Request.QueryString["id"].Trim());
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT [phoneId],[phoneName],[manufacturer],[phonePrice],[imageLink],[phoneDescrible] FROM Phones  WHERE phoneId=@phoneId");
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = conn;
                cmd.Parameters.Add("@phoneId", SqlDbType.Int).Value = phoneId;
                SqlDataReader reader = cmd.ExecuteReader();
                phone = new Phone();

                while (reader.Read())
                {
                    
                    phone.PhoneId = Int32.Parse(reader["phoneId"].ToString().Trim());
                    phone.PhoneName = reader["phoneName"].ToString().Trim();
                    phone.PhonePrice = Int32.Parse(reader["phonePrice"].ToString().Trim());
                    phone.Manufacturer = reader["manufacturer"].ToString().Trim();
                    phone.ImageLink = reader["imageLink"].ToString().Trim();
                    phone.PhoneDescrible = reader["phoneDescrible"].ToString().Trim();

                    break;
                }
                conn.Close();




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
                showDetailPhone += ShowPhone.showPhone(phone);
                showPricePhone += FormatNumber.FormatPrice(phone.PhonePrice ) + " VNĐ";

                //show similar phone
                conn.Open();
                SqlCommand cmdSimilarPhone = new SqlCommand("SELECT [phoneId],[phoneName],[manufacturer],[phonePrice],[imageLink],[phoneDescrible] FROM Phones  WHERE manufacturer=@manufacturer");
                cmdSimilarPhone.CommandType = System.Data.CommandType.Text;
                cmdSimilarPhone.Connection = conn;
                cmdSimilarPhone.Parameters.Add("@manufacturer", SqlDbType.VarChar).Value = phone.Manufacturer;
                SqlDataReader readerSimilarPhone = cmdSimilarPhone.ExecuteReader();
                List <Phone> listPhone = new List <Phone>();
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

            }
            else
            {
                Response.Redirect("Shop.aspx");
            }



        }

        public void btnAddCartClick(object sender, EventArgs e)
        {
            ItemCart item = new ItemCart();
            item.ItemId = phone.PhoneId;
            item.ItemName = phone.PhoneName;
            item.ItemPrice = phone.PhonePrice;
            item.ItemImage = phone.ImageLink;
            // item.Quantity = Int32.Parse(select.Value.Trim());
            item.Quantity = Int32.Parse(Request.Form["product_qty"].ToString().Trim());

            List<ItemCart> listItem = new List<ItemCart>();
            listItem = (List<ItemCart>)Session["cart"];
            listItem.Add(item);
            Session["cart"] = listItem;
            Response.Redirect("Cart.aspx");
        }
        
    }
}