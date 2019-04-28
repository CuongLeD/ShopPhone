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
    public partial class Shop : System.Web.UI.Page
    {
        protected static string showProduct = "";
        protected static string showProductCat = "";
        protected static List<Phone> listPhone;
        public static string categories = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            showProduct = "";
            showProductCat = "";
            categories = "";
            string connStr = "Server=BT; Database=PhoneShop; User=sa; Password=12345678";
            SqlConnection conn = new SqlConnection(connStr);
            if (Session["area"] != null)
            {
                string area = (string)Session["area"];

                if (Request.QueryString["category"] == null)
                {
                    int perPage = 6;
                    int page;
                    if (Request.QueryString["page"] != null)
                        page = Int32.Parse(Request.QueryString["page"].Trim());
                    else
                        page = 1;
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT shopId,Phones.phoneId, phoneName, manufacturer, phonePrice, imageLink, phoneDescrible, quantity FROM dbo.Phones, PhoneOfShop WHERE (PhoneOfShop.shopId=(SELECT TOP 1 shopId FROM Shops WHERE shopAddress=@address)  AND (Phones.phoneId=PhoneOfShop.phoneId))");
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Connection = conn;
                    cmd.Parameters.Add("@address", SqlDbType.NVarChar, 100).Value = area;
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

                    //show listphone
                    for (int i = ((page - 1) * perPage); i < page * perPage; i++)
                    {
                        if (listPhone.Count > ((page - 1) * perPage))
                        {
                            showProduct += "<div class='col-md-4 col-sm-6 center-responsive'>";
                            showProduct += "<div class='product'>";
                            showProduct += "<a href='Detail.aspx?id=" + listPhone[i].PhoneId + "&quantity=" + listPhone[i].PhoneQuantity +  "'>";
                            showProduct += "<img class='img-responsive' src='" + listPhone[i].ImageLink + "'>";
                            showProduct += "<div class='text'>";
                            showProduct += "<h3>" + listPhone[i].PhoneName + "</h3>";
                            showProduct += "<p class='price'>" + FormatNumber.FormatPrice(listPhone[i].PhonePrice) + " VNĐ</p>";
                            showProduct += "<p class='button' align = 'center'<a class='btn btn-primary' href='Detail.aspx?id=" + listPhone[i].PhoneId + "&quantity=" + listPhone[i].PhoneQuantity + "'>" + "Xem chi tiết</a></p>";
                            showProduct += "</div>";
                            showProduct += "</a>";
                            showProduct += "</div>";
                            showProduct += "</div>";
                        }
                        if (listPhone.Count == i + 1)
                            break;
                    }

                }

                if (Request.QueryString["category"] != null)
                {
                    string manufacturer = Request.QueryString["category"].Trim();
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT [phoneId],[phoneName],[manufacturer],[phonePrice],[imageLink],[phoneDescrible] FROM Phones WHERE manufacturer=@manufacturer");
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Connection = conn;
                    cmd.Parameters.Add("@manufacturer", SqlDbType.VarChar, 100).Value = manufacturer;
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

                    //show listphone
                    if (listPhone.Count == 0)
                    {
                        showProductCat += "<div class='box'><h1> No Product Found In This Product Categories </h1></div>";
                    }
                    else
                    {
                        showProductCat += "<div class='box'><h1>" + manufacturer + "</h1></div>";
                    }
                    for (int i = 0; i < listPhone.Count; i++)
                    {
                        if (listPhone.Count > 0)
                        {
                            showProductCat += "<div class='col-md-4 col-sm-6 center-responsive'>";
                            showProductCat += "<div class='product'>";
                            showProductCat += "<a href='Detail.aspx?id=" + listPhone[i].PhoneId + "'>";
                            showProductCat += "<img class='img-responsive' src='" + listPhone[i].ImageLink + "'>";
                            showProductCat += "<div class='text'>";
                            showProductCat += "<h3>" + listPhone[i].PhoneName + "</h3>";
                            showProductCat += "<p class='price'>" + FormatNumber.FormatPrice(listPhone[i].PhonePrice) + " VNĐ</p>";
                            showProductCat += "<p class='button' align = 'center'<a class='btn btn-primary' href='Detail.aspx?id=" + listPhone[i].PhoneId + "'>" + "Xem chi tiết</a></p>";
                            showProductCat += "</div>";
                            showProductCat += "</a>";
                            showProductCat += "</div>";
                            showProductCat += "</div>";

                        }
                        if (listPhone.Count == i + 1)
                            break;
                    }

                }
            }
            else
            {
                if (Request.QueryString["category"] == null)
                {
                    int perPage = 6;
                    int page;
                    if (Request.QueryString["page"] != null)
                        page = Int32.Parse(Request.QueryString["page"].Trim());
                    else
                        page = 1;
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT [phoneId],[phoneName],[manufacturer],[phonePrice],[imageLink],[phoneDescrible] FROM Phones");
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
                        phone.PhoneQuantity = -1;

                        listPhone.Add(phone);
                    }
                    conn.Close();

                    //show listphone
                    for (int i = ((page - 1) * perPage); i < page * perPage; i++)
                    {
                        if (listPhone.Count > ((page - 1) * perPage))
                        {
                            showProduct += "<div class='col-md-4 col-sm-6 center-responsive'>";
                            showProduct += "<div class='product'>";
                            showProduct += "<a href='Detail.aspx?id=" + listPhone[i].PhoneId + "'>";
                            showProduct += "<img class='img-responsive' src='" + listPhone[i].ImageLink + "'>";
                            showProduct += "<div class='text'>";
                            showProduct += "<h3>" + listPhone[i].PhoneName + "</h3>";
                            showProduct += "<p class='price'>" + FormatNumber.FormatPrice(listPhone[i].PhonePrice) + " VNĐ</p>";
                            showProduct += "<p class='button' align = 'center'<a class='btn btn-primary' href='Detail.aspx?id=" + listPhone[i].PhoneId + "'>" + "Xem chi tiết</a></p>";
                            showProduct += "</div>";
                            showProduct += "</a>";
                            showProduct += "</div>";
                            showProduct += "</div>";
                        }
                        if (listPhone.Count == i + 1)
                            break;
                    }

                }

                if (Request.QueryString["category"] != null)
                {
                    string manufacturer = Request.QueryString["category"].Trim();
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT [phoneId],[phoneName],[manufacturer],[phonePrice],[imageLink],[phoneDescrible] FROM Phones WHERE manufacturer=@manufacturer");
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Connection = conn;
                    cmd.Parameters.Add("@manufacturer", SqlDbType.VarChar, 100).Value = manufacturer;
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

                    //show listphone
                    if (listPhone.Count == 0)
                    {
                        showProductCat += "<div class='box'><h1> No Product Found In This Product Categories </h1></div>";
                    }
                    else
                    {
                        showProductCat += "<div class='box'><h1>" + manufacturer + "</h1></div>";
                    }
                    for (int i = 0; i < listPhone.Count; i++)
                    {
                        if (listPhone.Count > 0)
                        {
                            showProductCat += "<div class='col-md-4 col-sm-6 center-responsive'>";
                            showProductCat += "<div class='product'>";
                            showProductCat += "<a href='Detail.aspx?id=" + listPhone[i].PhoneId + "'>";
                            showProductCat += "<img class='img-responsive' src='" + listPhone[i].ImageLink + "'>";
                            showProductCat += "<div class='text'>";
                            showProductCat += "<h3>" + listPhone[i].PhoneName + "</h3>";
                            showProductCat += "<p class='price'>" + FormatNumber.FormatPrice(listPhone[i].PhonePrice) + " VNĐ</p>";
                            showProductCat += "<p class='button' align = 'center'<a class='btn btn-primary' href='Detail.aspx?id=" + listPhone[i].PhoneId + "'>" + "Xem chi tiết</a></p>";
                            showProductCat += "</div>";
                            showProductCat += "</a>";
                            showProductCat += "</div>";
                            showProductCat += "</div>";

                        }
                        if (listPhone.Count == i + 1)
                            break;
                    }

                }
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