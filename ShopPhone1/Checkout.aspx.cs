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
    public partial class Checkout : System.Web.UI.Page
    {
        public static string categories = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            categories = "";
            string connStr = "Server=BT; Database=PhoneShop; User=sa; Password=12345678";
            SqlConnection conn = new SqlConnection(connStr);

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

        public void btnPaymentClick(object sender, EventArgs e)
        {

            Customer customer = new Customer();
               // customer.Name = Request.Form["name"].ToString().Trim();
                //customer.PhoneNumber = Request.Form["contact"].ToString().Trim();
                //customer.Address = Request.Form["address"].ToString().Trim();
            customer.Name = txtname.Value.Trim();
            customer.Address = txtAddress.Value.Trim();
            customer.PhoneNumber = txtPhone.Value.Trim();
            customer.Id = Database.AddCustomer(customer);



                int employeeId = 11;

                if (Session["shop_id"] != null )
                {
                    int shopId = (int)Session["shop_id"];
                    
                    string conStr = "Server=BT; Database=PhoneShop; User=sa; Password=12345678";
                    SqlConnection conn = new SqlConnection(conStr);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT TOP 1 employeeId FROM Employees WHERE shopId=@shopId");
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Connection = conn;
                    cmd.Parameters.Add("@shopId", SqlDbType.NVarChar, 100).Value = shopId;
                    SqlDataReader readerId = cmd.ExecuteReader();
                    if (readerId.Read())
                    {
                        employeeId = Int32.Parse(readerId["employeeId"].ToString());
                    }
                }
                

                //Add item on order
                int count = 0;
                if (Session["cart"] != null)
                {
                    int orderId = Database.AddOrder(customer.Id, employeeId);
                    List<ItemCart> listPhone = new List<ItemCart>((List<ItemCart>)Session["cart"]);
                    foreach (ItemCart item in listPhone)
                    {
                        string conStr = "Server=BT; Database=PhoneShop; User=sa; Password=12345678";
                        SqlConnection conn = new SqlConnection(conStr);
                        conn.Open();
                        string insertOrder = "INSERT INTO PhoneOfOrder(orderId, phoneId, quantity) VALUES (@orderId, @phoneId, @quantity)";
                        SqlCommand queryAddOrder = new SqlCommand();
                        queryAddOrder.Connection = conn;
                        queryAddOrder.CommandText = insertOrder;
                        queryAddOrder.Parameters.Add("@orderId", SqlDbType.Int).Value = orderId;
                        queryAddOrder.Parameters.Add("@phoneId", SqlDbType.Int).Value = item.ItemId;
                        queryAddOrder.Parameters.Add("@quantity", SqlDbType.Int).Value = item.Quantity;
                        queryAddOrder.ExecuteNonQuery();
                        conn.Close();

                        count++;
                    }
                }

                Response.Write("<script>alert('Bạn đã đặt hàng thành công')</script");
               // Session["listItem"]
                Session.Remove("cart");
                Response.Redirect("Checkout.aspx");
            }

            
        

    }
}