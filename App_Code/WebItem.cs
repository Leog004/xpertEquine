using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for WebItem
/// </summary>
public class WebItem
{
    public string itemNo { get; set; }
    public decimal price { get; set; }
    public int quantity { get; set; }
    public decimal discount { get; set; }
    public string locationcodes { get; set; }
    public string description2 { get; set; }

    public WebItem(string itemNo, decimal price, int quantity, decimal discount, string locationcodes, string description2)
    {
        this.itemNo = itemNo;
        this.price = price;
        this.quantity = quantity;
        this.discount = discount;
        this.locationcodes = locationcodes;
        this.description2 = description2;
    }


    public WebItem(string itemNo, decimal price, int quantity)
    {
        this.itemNo = itemNo;
        this.price = price;
        this.quantity = quantity;
    }
}