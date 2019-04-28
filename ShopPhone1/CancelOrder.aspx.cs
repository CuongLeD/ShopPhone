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
    public partial class CancelOrder : System.Web.UI.Page
    {
        protected static List<Phone> listPhone;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["employeeId"] != null && Request.QueryString["orderId"] != null)
            {

                int orderId = Int32.Parse(Request.QueryString["orderId"].Trim());                
                string connStr = "Server=BT; Database=PhoneShop; User=sa; Password=12345678";
                SqlConnection conn = new SqlConnection(connStr);
                
                

                
                List<int> listPhoneId = new List<int>();
                conn.Open();
                SqlCommand cmdPhoneId = new SqlCommand("SELECT phoneId FROM PhoneOfOrder WHERE orderId=@orderId");
                cmdPhoneId.CommandType = System.Data.CommandType.Text;
                cmdPhoneId.Connection = conn;
                cmdPhoneId.Parameters.Add("@orderId", SqlDbType.Int).Value = orderId;
                SqlDataReader reader = cmdPhoneId.ExecuteReader();
                while (reader.Read())
                {
                    int phoneId = Int32.Parse(reader["phoneId"].ToString().Trim());
                    listPhoneId.Add(phoneId);
                }
                conn.Close();

                
                // Delete phone from PhoneOfOrder   
                foreach (int phoneid in listPhoneId)
                {
                    conn.Open();
                    SqlCommand cmdDelete = new SqlCommand("DELETE FROM PhoneOfOrder WHERE orderId=@orderId AND phoneId=@id");
                    cmdDelete.CommandType = System.Data.CommandType.Text;
                    cmdDelete.Connection = conn;
                    cmdDelete.Parameters.Add("@orderId", SqlDbType.Int).Value = orderId;
                    cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = phoneid;
                    cmdDelete.ExecuteNonQuery();
                    conn.Close();
                }

                //Delete Order

                conn.Open();
                SqlCommand cmdDeleteOrder = new SqlCommand("DELETE FROM Orders WHERE orderId=@orderId");
                cmdDeleteOrder.CommandType = System.Data.CommandType.Text;
                cmdDeleteOrder.Connection = conn;
                cmdDeleteOrder.Parameters.Add("@orderId", SqlDbType.Int).Value = orderId;
                cmdDeleteOrder.ExecuteNonQuery();
                conn.Close();
                conn.Close();


            }

            Response.Redirect("ManageOrder.Aspx");
        }
    }
}