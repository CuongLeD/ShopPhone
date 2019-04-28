using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using ShopPhone1.Controller;
using System.Data;

namespace ShopPhone1
{
    public partial class Home : System.Web.UI.Page
    {
        protected static string show = "";
        protected static List<Phone> listPhone;
        public static string  categories = "";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            show = "";
            categories = "";
             string connStr = "Server=BT; Database=PhoneShop; User=sa; Password=12345678";
             SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT TOP 8 [phoneId],[phoneName],[manufacturer],[phonePrice],[imageLink],[phoneDescrible] FROM Phones");
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
               
                listPhone.Add(phone);               
            }
            conn.Close();

            foreach (Phone phone in listPhone)
            {
                show += "<div class='col-md-4 col-sm-6 single'>";                
                show += "<div class='product'>";
                show += "<a href='Detail.aspx?id=" + phone.PhoneId + "' >";
                show += "<img class='img-responsive' src='" + phone.ImageLink + "' alt='' />";                
                show += "<div class='text'>";
                show += "<h3>";                
                show += phone.PhoneName;                
                show += "</h3>";
                show += "<p class='price'>" + FormatNumber.FormatPrice(phone.PhonePrice) + " VNĐ" + "</p>";
                show += "<p class='button' align = 'center'<a class='btn btn-primary' href='Detail.aspx?id=" + phone.PhoneId + "'>" + "Xem chi tiết</a></p>";
                show += "</div>";
                show += "</a>";
                show += "</div>";
                show += "</div>";
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
                categories += "<a href='Shop.aspx?category=" + readerCategories["manufacturer"] + "'><b>" + readerCategories["manufacturer"] + "<b></a>";
                categories += "<li>";
                    
            }
        }



        public void btnSearchAreaClick(object sender, EventArgs e)
        {
            if (Request.Form["area"] != null)
            {
                string shopName = Request.Form["area"].ToString().Trim();
                Session["area"] = shopName;
                string connStr = "Server=BT; Database=PhoneShop; User=sa; Password=12345678";
                SqlConnection conn = new SqlConnection(connStr);
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT shopId FROM Shops WHERE shopAddress=@address");
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = conn;
                cmd.Parameters.Add("@address", SqlDbType.NVarChar, 100).Value = shopName;
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Session["shop_id"] = Int32.Parse(reader["shopId"].ToString());
                    Response.Redirect("Shop.aspx?area=" + shopName);

                }
            }

        }
    }
}