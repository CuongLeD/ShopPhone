using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using ShopPhone1.Models;
using System.Data;

namespace ShopPhone1
{
    public partial class EditPhone : System.Web.UI.Page
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

           
        }


        protected void btnEdit_onclick(object sender, EventArgs e)
        {
            Response.Write("OK");
            Phone phone1 = new Phone();
            phone1.PhoneName = txtName.Value.Trim();
            phone1.PhonePrice = Int32.Parse(txtPrice.Value.Trim());
            phone1.Manufacturer = selectManufacturer.Value.Trim();
            phone1.PhoneDescrible = txtDescrible.Value.Trim();

            string connStr = "Server=BT; Database=PhoneShop; User=sa; Password=12345678";
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            string queryStr = "UPDATE Phones SET phoneName=@name, phonePrice=@price, manufacturer=@manufacturer, phoneDescrible=@describle WHERE phoneId=@id";
            SqlCommand cmd = new SqlCommand();            
            cmd.Connection = conn;
            cmd.CommandText = queryStr;
            cmd.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = phone1.PhoneName;
            cmd.Parameters.Add("@price", SqlDbType.Int).Value = phone1.PhonePrice;
            cmd.Parameters.Add("@manufacturer", SqlDbType.NVarChar, 100).Value = phone1.Manufacturer;
            cmd.Parameters.Add("@describle", SqlDbType.NVarChar, 100).Value = phone1.PhoneDescrible;
            cmd.Parameters.Add("@id", SqlDbType.Int, 100).Value = phoneId;
            int row = cmd.ExecuteNonQuery();
            Response.Write( "</br>" +phone1.PhoneName + "</br>"  + phone1.PhonePrice + "</br>" + phoneId + "OK");
            conn.Close();
            Response.Redirect("Admin.aspx");
        }

    }
}