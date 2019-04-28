using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using ShopPhone1.Models;
using ShopPhone1.Controller;

namespace ShopPhone1
{
    public partial class AddAmountPhone : System.Web.UI.Page
    {
        protected static int phoneId;
        protected void Page_Load(object sender, EventArgs e)
        {
            phoneId = Int32.Parse(Request.Params["id"].Trim());
            string connStr = "Server=BT; Database=PhoneShop; User=sa; Password=12345678";
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT TOP 1 [phoneId],[phoneName],[manufacturer],[phonePrice],[imageLink],[phoneDescrible] FROM Phones WHERE phoneId='" + phoneId + "'");
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = conn;
            SqlDataReader reader = cmd.ExecuteReader();
            Phone phone = new Phone();
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

            txtName.Value = phone.PhoneName;
            txtPrice.Value = phone.PhonePrice.ToString();
            txtDescrible.Value = phone.PhoneDescrible;
            selectManufacturer.Value = phone.Manufacturer;

            txtName.Disabled = true;
            txtPrice.Disabled = true;
            txtDescrible.Disabled = true;
            selectManufacturer.Disabled = true;

        }


        protected void btnAdd_onclick(object sender, EventArgs e)
        {
            Response.Write("OK");
            int quantity = Int32.Parse(txtAddAmount.Value.Trim());

            string connStr = "Server=BT; Database=PhoneShop; User=sa; Password=12345678";
            SqlConnection conn = new SqlConnection(connStr);
            int shopId=1;
            if (Session["employeeId"] != null)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT TOP 1 shopId FROM Employees WHERE employeeId='" + (int)Session["employeeId"] + "'");
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = conn;
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read())
                    shopId = Int32.Parse(reader["shopId"].ToString());
                conn.Close();


            }


            conn.Open();
            string queryStr = "UPDATE PhoneOfShop SET quantity=@quantity WHERE phoneId=@id AND shopId=@shopId";
            SqlCommand cmdUpdate = new SqlCommand();
            cmdUpdate.Connection = conn;
            cmdUpdate.CommandText = queryStr;
            cmdUpdate.Parameters.Add("@quantity", SqlDbType.Int).Value = quantity;
            cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = phoneId;
            cmdUpdate.Parameters.Add("@shopId", SqlDbType.Int).Value = shopId;
            try
            {
                cmdUpdate.ExecuteNonQuery();
            }catch(Exception ex)
            {
                ex.Message.ToString();
            }
           
            conn.Close();
            Response.Redirect("Admin.aspx");
        }

    }
}