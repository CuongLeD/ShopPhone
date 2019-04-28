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
    public partial class EditEmployee : System.Web.UI.Page
    {
        protected static int employeeId;
        protected static Employee employee;
        protected void Page_Load(object sender, EventArgs e)
        {
            employeeId = Int32.Parse(Request.Params["id"].Trim());
            string connStr = "Server=BT; Database=PhoneShop; User=sa; Password=12345678";
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT TOP 1 employeeId, employeeName, employeeAddress, employeePhoneNumber, dateBegin, shopId FROM Employees WHERE employeeId='" + employeeId + "'");
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = conn;
            SqlDataReader reader = cmd.ExecuteReader();
            employee = new Employee();
            while (reader.Read())
            {
                employee.EmployeeId = Int32.Parse(reader["employeeId"].ToString().Trim());
                employee.ShopId = Int32.Parse(reader["shopId"].ToString().Trim());
                employee.EmployeeName = reader["employeeName"].ToString().Trim();
                employee.EmployeeAddress = reader["employeeAddress"].ToString().Trim();
                employee.EmployeePhone = reader["employeePhoneNumber"].ToString().Trim();
                employee.DateBegin = reader["dateBegin"].ToString().Trim();                
                break;
            }
            conn.Close();

           
          
            
        }


        protected void btnEdit_onclick(object sender, EventArgs e)
        {
//txtName.Text = "";

            Response.Write("OK" + txtName.Text);
            Employee employee = new Employee();
            
            employee.EmployeeName = txtName.Text;
            employee.EmployeeAddress = txtAddress.Text;
            employee.EmployeePhone = txtPhoneNumber.Text;
            
            employee.EmployeeId = employeeId;
            string connStr = "Server=BT; Database=PhoneShop; User=sa; Password=12345678";
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            string queryStr = "UPDATE Employees SET employeeName=@name, employeeAddress=@address, employeePhoneNumber=@phone WHERE employeeId=@id";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = queryStr;
            cmd.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = employee.EmployeeName;
            cmd.Parameters.Add("@address", SqlDbType.NVarChar, 100).Value = employee.EmployeeAddress;
            cmd.Parameters.Add("@phone", SqlDbType.NVarChar, 100).Value = employee.EmployeePhone;
           
            cmd.Parameters.Add("@id", SqlDbType.Int, 100).Value = employee.EmployeeId;
            int row = cmd.ExecuteNonQuery();
            Response.Redirect("ManageEmployee.aspx");
            conn.Close();
            
        }

    }
}