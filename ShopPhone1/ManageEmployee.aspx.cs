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
    public partial class ManageEmployee : System.Web.UI.Page
    {
        protected static string  show = "";
        protected static List<Phone> listPhone;

        protected void Page_Load(object sender, EventArgs e)
        {

            int idAdmin = (int)Session["employeeId"];
            string connStr = "Server=BT; Database=PhoneShop; User=sa; Password=12345678";
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            String queryStr = "SELECT employeeId, shopId, employeeName, employeeAddress, employeePhoneNumber, dateBegin FROM Employees WHERE shopId=(SELECT TOP 1 shopId FROM Employees) ";
            SqlCommand cmd = new SqlCommand(queryStr);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = conn;

            SqlDataReader reader = cmd.ExecuteReader();
            List<Employee> listEmployee = new List<Employee>();

            while (reader.Read())
            {
                Employee employee = new Employee();
                employee.EmployeeId = Int32.Parse(reader["employeeId"].ToString().Trim());
                employee.ShopId = Int32.Parse(reader["shopId"].ToString().Trim());
                employee.EmployeeName = reader["employeeName"].ToString().Trim();
                employee.EmployeeAddress = reader["employeeAddress"].ToString().Trim();
                employee.EmployeePhone = reader["employeePhoneNumber"].ToString().Trim();
                employee.DateBegin = reader["dateBegin"].ToString().Trim();

                listEmployee.Add(employee);
            }
            conn.Close();

            foreach (Employee employee in listEmployee)
            {
                show += "<tr>";
                show += "<td>" + employee.EmployeeId + "</a></td>";
                show += "<td>" + employee.ShopId + "</td>";
                show += "<td>" + employee.EmployeeName + "</td>";
                show += "<td>" + employee.EmployeeAddress + "</td>";
                show += "<td>" + employee.EmployeePhone + "</td>";
                show += "<td>" + employee.DateBegin + "</td>";                
                show += "<td><a href='EditEmPloyee.aspx?id=" + employee.EmployeeId + "'>Sửa </a></td>";
                
                show += "</tr>";
            }


        }
    }
}