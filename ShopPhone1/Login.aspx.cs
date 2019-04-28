using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopPhone1.Models;
using System.Data.SqlClient;
using System.Data;

namespace ShopPhone1
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void login_Click(object sender, EventArgs e)
        {
            string user = inputUser.Text.Trim();
            string pwd = inputPassword.Value.Trim();
            Response.Write(user + pwd);


            string strConnection = "Server=BT; Database=PhoneShop; User=sa; Password=12345678";
            SqlConnection conn = new SqlConnection(strConnection);
            conn.Open();
            string sqlCommand = "SELECT username, pass, permission, employeeId FROM Accounts WHERE username=@username AND pass=@password";
            SqlCommand command = new SqlCommand();
            command.CommandText = sqlCommand;
            command.Connection = conn;
            command.Parameters.Add("@username", SqlDbType.VarChar, 20).Value = user;
            command.Parameters.Add("@password", SqlDbType.VarChar, 30).Value = pwd;
            SqlDataReader reader = command.ExecuteReader();

            int employeeId;
            string permission = "";
            if (reader.Read())
            {
                employeeId = Int32.Parse(reader["employeeId"].ToString().Trim());
                permission = reader["permission"].ToString().Trim();
                Session["employeeId"] = employeeId;
                Response.Redirect("Admin.aspx?id=" + employeeId);


            }
            else
            {
                Response.Write("</br>Sai thông tin đăng nhập</br>");
                Response.Write(user + pwd);
            }
            conn.Close();
        }
    }
}