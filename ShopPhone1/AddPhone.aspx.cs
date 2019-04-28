using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using ShopPhone1.Controller;

namespace ShopPhone1
{
    public partial class AddPhone : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnAddClick(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string manufacturer = select1.Value.Trim();
            int price = 0;
            bool result= Int32.TryParse(txtPrice.Text.Trim(), out price);
            string describle = txtDescrible.Text.Trim();
            string suffix = "";
           
            string ext = uploadImg.PostedFile.FileName;
            for (int i = ext.Length - 1; i >= 0; i--)
            {
                if (ext[i] != '.')
                    suffix += ext[i];
                else
                    break;
            }

            char[] arr = suffix.ToCharArray();
            Array.Reverse(arr);
            suffix = new string(arr);



                if (price == 0 || name.Equals("") || manufacturer.Equals("") || (!suffix.Equals("jpg") && !suffix.Equals("png")))
                {

                    Response.Write("<h3>Định dạng nhập không hợp lệ</h3></br>");
                    Response.Write(name + "<br>");
                    Response.Write(manufacturer + "<br>");
                    Response.Write(price + "<br>");
                    Response.Write(suffix + "<br>");
                    Response.Write(describle + "<br>");
                }
                else
                {

                    string strFolder = Server.MapPath("./");
                    if (!Directory.Exists(strFolder))
                    {
                        Directory.CreateDirectory(strFolder);
                    }
                    string strImgName = Path.GetFileName(ext);
                    string imgLink = strFolder + "./image/" + strImgName;
                    if (File.Exists(imgLink))
                    {
                        Response.Write("<h3>Ảnh đã tồn Tại</h3>");
                        
                    }
                    else
                    {
                        uploadImg.PostedFile.SaveAs(imgLink);
                    }

                    Database.AddP(name, manufacturer, price, "image/"+strImgName, describle);

                    Response.Write("<h3>Thêm điện thoại thành công</h3></br>" + "image/" + strImgName);
                    
                }
        }
       
    }
}