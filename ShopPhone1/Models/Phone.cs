using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Phone
/// </summary>
public class Phone
{
    private int phoneId;

    public int PhoneId
    {
        get { return phoneId; }
        set { phoneId = value; }
    }
    private string phoneName;

    public string PhoneName
    {
        get { return phoneName; }
        set { phoneName = value; }
    }
    private string manufacturer;

    public string Manufacturer
    {
        get { return manufacturer; }
        set { manufacturer = value; }
    }

    private int phoneQuantity;

    public int PhoneQuantity
    {
        get { return phoneQuantity; }
        set { phoneQuantity = value; }
    }

    private int shopId;

    public int ShopId
    {
        get { return shopId; }
        set { shopId = value; }
    }

    private int phonePrice;
    public int PhonePrice
    {
        get { return phonePrice; }
        set { phonePrice = value; }
    }
    private string phoneDescrible;

    public string PhoneDescrible
    {
        get { return phoneDescrible; }
        set { phoneDescrible = value; }
    }
    private string imageLink;

    public string ImageLink
    {
        get { return imageLink; }
        set { imageLink = value; }
    }
   
    public Phone()
    {
        //
        // TODO: Add constructor logic here
        //
    }



}