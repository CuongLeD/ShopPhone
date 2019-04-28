using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopPhone1.Controller
{
    public class ShowPhone
    {
        public static string showListPhone(List<Phone> listPhone)
        {
            string show = "";
            foreach(Phone phone in listPhone)
            {
                if(phone.PhoneQuantity >= 0)
                    show += "<a href='DetailPhone.aspx?cuong=5&id=" + phone.PhoneId + "&helloquantity=" + phone.PhoneQuantity + "'>";
                else
                    show += "<a href='DetailPhone.aspx?name=cuong&id=" + phone.PhoneId +  "'>";
                show += "<div class='item-product-home'>";
                show += "<img src='" + phone.ImageLink + "' alt='" + phone.PhoneName + "' />";
                show += "<p>" + phone.PhoneName + "</p>";
               // show += "<h4>" + FormatNumber.FormatPrice(phone.PhonePrice) + " VNĐ</h4>";
                show += "</div>";
                show += "</a>";
            }

            return show;
        }

        public static string showPhone(Phone phone)
        {
            string show = "<h1>Thông tin kỹ thuật</h1>";
            string[] features = phone.PhoneDescrible.Split(';'); 
            show += "<table>";
            foreach (string feature in features)
            {
                string[]  row = feature.Split(':');
                if (row.Length == 2)
                {
                    show += "<tr><th>" + row[0] + ":" + "</th>";
                    show += "<td>" + row[1] + "</td></tr>";
                }
                
                
            }
            show += "</table>";          

            return show;
        }
    }

    
}