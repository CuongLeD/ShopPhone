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
    public partial class AddCustomer : System.Web.UI.Page
    {
        protected static int employeeId;
        protected void Page_Load(object sender, EventArgs e)
        {


        }


        protected void btnAdd_onclick(object sender, EventArgs e)
        {


            
            string connStr = "Server=BT; Database=PhoneShop; User=sa; Password=12345678";
            SqlConnection conn = new SqlConnection(connStr);
           


            conn.Open();
            string queryStr = "INSERT INTO Employees(customerName, customerAddress, customerPhoneNumber, dateCreate) VALUES ( @name, @address, @phone, @date)";
            SqlCommand cmdUpdate = new SqlCommand();
            cmdUpdate.Connection = conn;
            cmdUpdate.CommandText = queryStr;
            
            cmdUpdate.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = Text1.Value;
            cmdUpdate.Parameters.Add("@address", SqlDbType.NVarChar, 100).Value = txtAddress.Value;
            cmdUpdate.Parameters.Add("@phone", SqlDbType.VarChar, 100).Value = txtPhoneNumber.Value;
            cmdUpdate.Parameters.Add("@date", SqlDbType.DateTime).Value = DateTime.Now;
            cmdUpdate.ExecuteNonQuery();

            conn.Close();
            Response.Redirect("ManageCusotmer.aspx");
        }

    }
}