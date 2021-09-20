using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SalesOrder;
using SalesAPI;
using System.Configuration;
using System.Net;

/// <summary>
/// Summary description for OrderAccess
/// </summary>
public class OrderAccess
{
    public OrderAccess()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    //public static string createNavSalesOrder(Address billing, Address shipping, List<WebItem> items, string creditCardNo, string expMonth, string expYear, string locationcode, string shState)
    //{

    //    navSalesOrder_Service salesService = new navSalesOrder_Service();
    //    salesService.UseDefaultCredentials = false;
    //    salesService.Credentials = new NetworkCredential("navuserv", "NSNav1515");
    //    salesService.Url = ConfigurationManager.AppSettings["SalesOrder.navSalesOrder"];



    //    navSalesAPI api = new navSalesAPI();
    //    api.UseDefaultCredentials = false;
    //    api.Credentials = new NetworkCredential("navuserv", "NSNav1515");
    //    api.Url = ConfigurationManager.AppSettings["SalesAPI.navSalesAPI"];

    //    string order = api.CreateRetailWebOrder();

    //    navSalesOrder saleOrder = salesService.Read(order);
    //    saleOrder.Location_Code = locationcode;

    //    saleOrder.Account_Number_CL = creditCardNo;
    //    saleOrder.Expiration_Month_CL = expMonth;
    //    saleOrder.Expiration_Year_CL = expYear;

    //    saleOrder.Payment_Method_Code = "CREDITCARD";
    //    saleOrder.Ship_to_Address = shipping.stAddress;
    //    saleOrder.Ship_to_Address_2 = shipping.stAddress2;
    //    saleOrder.Ship_to_City = shipping.city;
    //    saleOrder.Ship_to_Name = shipping.name;
    //    saleOrder.Ship_to_Phone_No = shipping.phone;
    //    saleOrder.Ship_to_Post_Code = shipping.zipCode;
    //    saleOrder.Ship_to_County = shipping.state;

    //    saleOrder.Sell_to_Address = shipping.stAddress;
    //    saleOrder.Sell_to_Address_2 = shipping.stAddress2;
    //    saleOrder.Sell_to_City = shipping.city;
    //    saleOrder.Sell_to_Customer_Name = shipping.name;
    //    saleOrder.Sell_to_Post_Code = shipping.zipCode;
    //    saleOrder.Sell_to_County = shipping.state;

    //    saleOrder.Bill_to_Address = billing.stAddress;
    //    saleOrder.Bill_to_Address_2 = billing.stAddress2;
    //    saleOrder.Bill_to_City = billing.city;
    //    saleOrder.Bill_to_Name = billing.name;
    //    saleOrder.Bill_to_Post_Code = billing.zipCode;
    //    saleOrder.Bill_to_County = billing.state;


    //    saleOrder.Tax_Liable = false;
    //    saleOrder.Tax_LiableSpecified = true;
    //    saleOrder.Tax_Area_Code = "";

    //    if (shState == "Texas" || shState == "TX")
    //    {
    //        saleOrder.Tax_Liable = true;
    //        saleOrder.Tax_LiableSpecified = true;
    //        saleOrder.Tax_Area_Code = "TX";
    //    }
    //    else if (shState == "Washington" || shState == "WA")
    //    {
    //        saleOrder.Tax_Liable = true;
    //        saleOrder.Tax_LiableSpecified = true;
    //        saleOrder.Tax_Area_Code = "WA";
    //    }


    //    //DataTable taxLiable = AccessWeb.AccessWeb_G_TaxLiable(shState);
    //    //if (taxLiable.Rows.Count > 0)
    //    //{
    //    //    if (Convert.ToBoolean(taxLiable.Rows[0]["Nexus"]))
    //    //    {
    //    //        saleOrder.Tax_Liable = true;
    //    //        saleOrder.Tax_LiableSpecified = true;
    //    //        saleOrder.Tax_Area_Code = taxLiable.Rows[0]["State"].ToString();
    //    //    }
    //    //}

    //    saleOrder.Free_Freight = true;
    //    saleOrder.Free_Freight_TypeSpecified = true;


    //    List<Sales_Order_Line> saleLines = new List<Sales_Order_Line>();

    //    foreach (WebItem wItem in items)
    //    {

    //        Sales_Order_Line saleLine = new Sales_Order_Line();
    //        if (wItem.itemNo == "461200")
    //        {
    //            saleLine.Type = SalesOrder.Type.G_L_Account;
    //            saleLine.Shortcut_Dimension_1_Code = "GENERAL";
    //        }
    //        else
    //        {
    //            saleLine.Type = SalesOrder.Type.Item;
    //        }

    //        saleLine.TypeSpecified = true;
    //        saleLine.Quantity = wItem.quantity;
    //        saleLine.QuantitySpecified = true;
    //        saleLine.No = wItem.itemNo;
    //        saleLine.Unit_Price = wItem.price;
    //        saleLine.Unit_PriceSpecified = true;

    //        saleLines.Add(saleLine);
    //    }

    //    saleOrder.SalesLines = saleLines.ToArray();
    //    salesService.Update(ref saleOrder);


    //    return saleOrder.No;
    //}
}