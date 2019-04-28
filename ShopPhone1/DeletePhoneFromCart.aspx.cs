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
    public partial class DeletePhoneFromCart : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
        
            
            string connStr = "Server=BT; Database=PhoneShop; User=sa; Password=12345678";
            SqlConnection conn = new SqlConnection(connStr);
            
            if (Request.QueryString["id"] != null && Session["cart"] != null)
            {
                int phoneId = Int32.Parse(Request.QueryString["id"].Trim());
                List<ItemCart> listItem = new List<ItemCart>((List<ItemCart>)Session["cart"]);

                foreach (ItemCart item in listItem)
                {
                    if (item.ItemId == phoneId)
                    {
                        listItem.Remove(item);
                        break;
                    }
                }

                Session["cart"] = listItem;
            }
            else
            {
                Response.Redirect("Cart.aspx");
            }
            Response.Redirect("Cart.aspx");
        }
    }
}