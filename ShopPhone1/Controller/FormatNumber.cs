using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopPhone1.Controller
{
    public class FormatNumber
    {
        public static string FormatPrice(int price)
        {
            string priceStr = price.ToString();
            int numberDot = 0;
            while ((price/1000) > 0 )
            {
                price /= 1000;
                numberDot++;
            }

            int length = priceStr.Length;
            string result = "";
            int count = 0;
            for (int i = length - 1; i >= 0; i--)
            {
                count++;
                result += priceStr[i];
                if((count % 3 == 0) && (count/3 <= numberDot) )
                {
                    result += '.';
                }
            }

            char[] array = result.ToCharArray();
            Array.Reverse(array);

             return new string(array);
        }
    }
}