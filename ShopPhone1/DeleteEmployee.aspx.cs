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
    public partial class DeteleEmployee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["employeeId"] != null)
            {
                
                int employeeId = Int32.Parse(Request.Params["id"]);
                string connStr = "Server=BT; Database=PhoneShop; User=sa; Password=12345678";
                SqlConnection conn = new SqlConnection(connStr);
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT TOP 1 shopId FROM Employees WHERE employeeId='" + employeeId + "'");
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = conn;
                int shopId = 0;
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                    shopId = Int32.Parse(reader["shopId"].ToString().Trim());
                conn.Close();

                conn.Open();
                SqlCommand cmdDeleteAccount = new SqlCommand("DELETE FROM Accounts WHERE employeeId=@employeeId");
                cmdDeleteAccount.CommandType = System.Data.CommandType.Text;
                cmdDeleteAccount.Connection = conn;               
                cmdDeleteAccount.Parameters.Add("@employeeId", SqlDbType.Int).Value = employeeId;
                cmdDeleteAccount.ExecuteNonQuery();
                conn.Close();

                conn.Open();
                SqlCommand cmdDelete = new SqlCommand("DELETE FROM Employees WHERE shopId=@shopId AND employeeId=@employeeId");
                cmdDelete.CommandType = System.Data.CommandType.Text;
                cmdDelete.Connection = conn;
                cmdDelete.Parameters.Add("@shopId", SqlDbType.Int).Value = shopId;
                cmdDelete.Parameters.Add("@employeeId", SqlDbType.Int).Value = employeeId;
                cmdDelete.ExecuteNonQuery();
                conn.Close();
            }

            Response.Redirect("ManageEmployee.Aspx");
        }
    }
}