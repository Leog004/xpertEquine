using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Contact : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        getHeader();
    }

    protected void getHeader()
    {

    }


    public static bool recieveUserEmail(string name, string email, string phone, string subject, string message)
    {
        DataTable a = Access._A_CustomerMessage(name, email, phone, message);

        string body = HTMLEmail.SendCustomerMessage(email, name, phone, message);

        Utilities.SendCustomerContactMessage(ConfigurationManager.AppSettings["CustomerService"], "Xpert Equine Web Message", body);

        return true;
    }


    [System.Web.Services.WebMethod]
    public static object sendEmail(string name, string email, string phone, string subject, string message)
    {
        
        return recieveUserEmail(name, email, phone, subject, message);

    }


    [System.Web.Services.WebMethod]
    public static object newSubscriber(string email)
    {
        var list = new List<Dictionary<string, object>>();


        if (String.IsNullOrEmpty(email))
        {
            list.Add(new Dictionary<string, object> { { "result", false }, { "message", "Please enter an email!" } });
            return list;
        }

        if (!Regex.IsMatch(email, @"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))" + @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$"))
        {
            list.Add(new Dictionary<string, object> { { "result", false }, { "message", "Please enter a valid email!" } });
            return list;
        }


        DataTable add = Access._Add_User_Subscriber(email);
        if (!Convert.ToBoolean(add.Rows[0]["Inserted"]))
        {
            list.Add(new Dictionary<string, object> { { "result", false }, { "message", "This email has already been submitted. Thank you!" } });
            return list;
        }


        list.Add(new Dictionary<string, object> { { "result", true }, { "message", null } });
        return list;
    }
}