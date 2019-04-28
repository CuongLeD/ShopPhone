using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopPhone1.Models
{
    public class ItemCart
    {
        private int itemId;

        public int ItemId
        {
            get { return itemId; }
            set { itemId = value; }
        }
        private int quantity;

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        private string itemName;

        public string ItemName
        {
            get { return itemName; }
            set { itemName = value; }
        }
        private int itemPrice;

        public int ItemPrice
        {
            get { return itemPrice; }
            set { itemPrice = value; }
        }

        private string itemImage;

        public string ItemImage
        {
            get { return itemImage; }
            set { itemImage = value; }
        }


    }
}