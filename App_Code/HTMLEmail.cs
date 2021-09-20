using SecurityLib;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Web;

/// <summary>
/// Summary description for HTMLEmail
/// </summary>
public class HTMLEmail
{
    public HTMLEmail()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public static string PopulateBody(string email, string password, string htmlEmailTemp)
    {
        string body = string.Empty;
        using (StreamReader reader = new StreamReader(htmlEmailTemp))
        {
            body = reader.ReadToEnd();
        }
        body = body.Replace("{Email}", email);
        body = body.Replace("{Password}", password);
        return body;

    }
    public static string SendPassword(string email)
    {
        DataTable g = Access._G_Customer_ByEmail(email);
        string password = "";
        if (!String.IsNullOrEmpty(g.Rows[0]["Password"].ToString()))
        {
            password = StringEncryptor.Decrypt(g.Rows[0]["Password"].ToString());
        }
        else
        {
            password = "TEMP" + Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 5).ToString().ToUpper();
            DataTable up = Access._U_Customer_Password_ByEmail(email, StringEncryptor.Encrypt((password)));
        }
        string htmlEmailTemp = ConfigurationManager.AppSettings["EmailTemplates"] + "SendPassword.html";
        string body = string.Empty;
        using (StreamReader reader = new StreamReader(htmlEmailTemp))
        {
            body = reader.ReadToEnd();
        }
        body = body.Replace("{Email}", email);
        body = body.Replace("{Password}", password);
        return body;

    }
    public static string SendCustomerMessage(string fromemail, string name, string phone, string message)
    {
        string htmlEmailTemp = ConfigurationManager.AppSettings["EmailTemplates"] + "CustomerMessageTemplate.html";
        string body = string.Empty;

        string dateTime = DateTime.Now.ToLongDateString() + ", at " + DateTime.Now.ToShortTimeString();
        using (StreamReader reader = new StreamReader(htmlEmailTemp))
        {
            body = reader.ReadToEnd();
        }
        body = body.Replace("{email}", fromemail);
        body = body.Replace("{name}", name);
        body = body.Replace("{message}", message);
        body = body.Replace("{phone}", phone);
        body = body.Replace("{date}", dateTime);
        return body;
    }
    public static string SendOrderDetails(string email, string OrderID, string billingaddress, string shippingaddress)
    {
        DataTable getBillAddress = Access._G_Address_ByAddressID(billingaddress);
        DataTable getShipAddress = Access._G_Address_ByAddressID(shippingaddress);
        string shipname = "";
        string shipaddress = "";
        string shipcity = "";
        string shipstate = "";
        string shipzip = "";
        string OrderDate = "";
        if (getShipAddress.Rows.Count > 0)
        {
            shipname = getShipAddress.Rows[0]["Name"].ToString();
            shipaddress += getShipAddress.Rows[0]["Address"].ToString();
            if (!String.IsNullOrEmpty(getShipAddress.Rows[0]["Address 2"].ToString()))
            {
                shipaddress += "<br/>" + getShipAddress.Rows[0]["Address 2"].ToString();
            }
            shipcity = getShipAddress.Rows[0]["City"].ToString();
            shipstate = getShipAddress.Rows[0]["State"].ToString();
            shipzip = getShipAddress.Rows[0]["Zip"].ToString();
        }
        string billname = "";
        string billaddress = "";
        string billcity = "";
        string billstate = "";
        string billzip = "";
        if (getBillAddress.Rows.Count > 0)
        {
            billname = getBillAddress.Rows[0]["Name"].ToString();
            billaddress += getBillAddress.Rows[0]["Address"].ToString();
            if (!String.IsNullOrEmpty(getBillAddress.Rows[0]["Address 2"].ToString()))
            {
                billaddress += "<br/>" + getBillAddress.Rows[0]["Address 2"].ToString();
            }
            billcity = getBillAddress.Rows[0]["City"].ToString();
            billstate = getBillAddress.Rows[0]["State"].ToString();
            billzip = getBillAddress.Rows[0]["Zip"].ToString();
        }
        decimal _subtotal = 0;
        decimal _shipping = 0;
        decimal _tax = 0;
        decimal _total = 0;
        DataTable getOrder = Access._G_Order_ByOrderID(OrderID);
        string pNumber = "";
        string pName = "";
        string pQty = "";
        string pSubTotal = "";
        string pPrice = "";

        if (getOrder.Rows.Count > 0)
        {
            //OrderDate = Convert.ToDateTime(getOrder.Rows[0]["OrderDate"]).ToString("MM/dd/yyyy");
            for (int i = 0; i < getOrder.Rows.Count; i++)
            {
                pNumber = getOrder.Rows[i]["No_"].ToString().ToUpper() + "<br/>";
                pName += "<div style='border-bottom:solid 1px #CCC; font-size:10px'>" + getOrder.Rows[i]["Name"].ToString().ToUpper() + "</div>";
                pQty += "<div style='border-bottom:solid 1px #CCC; font-size:10px'>" + getOrder.Rows[i]["UnitQuantity"].ToString() + "</div>";
                pPrice += "<div style='border-bottom:solid 1px #CCC; font-size:10px'>" + "$" + getOrder.Rows[i]["UnitPrice"].ToString() + "</div>";
                pSubTotal += "<div style='border-bottom:solid 1px #CCC; font-size:10px'>" + "$" + getOrder.Rows[i]["UnitTotal"].ToString() + "</div>";
            }
            _subtotal = Convert.ToDecimal(getOrder.Rows[0]["SubTotalAmount"]);
            _shipping = Convert.ToDecimal(getOrder.Rows[0]["ShippingAmount"]);
            _tax = Convert.ToDecimal(getOrder.Rows[0]["Tax"]);
            _total = Convert.ToDecimal(getOrder.Rows[0]["TotalAmount"]);

            //_subtotal = subTotal;
            //_shipping = shipAmount;
            //_tax = tax;
            //_total = total;

        }
        string htmlEmailTemp = ConfigurationManager.AppSettings["EmailTemplates"] + "OrderSubmitted.html";
        string body = string.Empty;
        using (StreamReader reader = new StreamReader(htmlEmailTemp))
        {
            body = reader.ReadToEnd();
        }
        body = body.Replace("{OrderNumber}", OrderID);
        body = body.Replace("{OrderDate}", OrderDate);
        body = body.Replace("{Email}", email.ToUpper());
        body = body.Replace("{shippingName}", shipname);
        body = body.Replace("{shippingAddress}", shipaddress);
        body = body.Replace("{shippingCity}", shipcity);
        body = body.Replace("{shippingState}", shipstate);
        body = body.Replace("{shippingZip}", shipzip);

        body = body.Replace("{BillingName}", billname);
        body = body.Replace("{BillingAddress}", billaddress);
        body = body.Replace("{BillingCity}", billcity);
        body = body.Replace("{BillingState}", billstate);
        body = body.Replace("{BillingZip}", billzip);
        body = body.Replace("{subtotal}", String.Format("{0:C}", _subtotal));
        body = body.Replace("{shipping}", String.Format("{0:C}", _shipping));
        body = body.Replace("{tax}", String.Format("{0:C}", _tax));
        body = body.Replace("{total}", String.Format("{0:C}", _total));
        body = body.Replace("{pNumber}", pNumber);
        body = body.Replace("{pName}", pName);
        body = body.Replace("{pQuantity}", pQty);
        body = body.Replace("{pPrice}",pPrice);
        body = body.Replace("{pTotal}", pSubTotal);
        return body;

    }
}