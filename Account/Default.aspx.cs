using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_Default : System.Web.UI.Page
{
    // Billing Information
    public string Bill_FirstName = "";
    public string Bill_LastName = "";
    public string Email = "";
    public string Bill_City = "";
    public string Bill_State = "";
    public string Bill_Zip = "";
    public string Bill_Phone = "";
    public string Bill_Address = "";

    // Shipping Information
    public string Ship_FirstName = "";
    public string Ship_LastName = "";
    public string Ship_City = "";
    public string Ship_State = "";
    public string Ship_Zip = "";
    public string Ship_Phone = "";
    public string Ship_Address = "";


    public static string Cookie = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        get_Header();


        if (HttpContext.Current.Request.Cookies["Xpert_CustomerID"] != null)
        {

            string cookie = Request.Cookies["Xpert_CustomerID"].Value;
            get_information(cookie);

            Cookie = cookie;

        }
        else
        {
            redirectToLogin();
        }
    }

    protected void get_Header()
    {

    }


    protected void redirectToLogin()
    {
        Response.Redirect("~/login/");
    }
    protected void get_information(string cookie)
    {

        Label shipping = new Label(); Label billing = new Label();
        DataTable g1 = Access._G_Address_ByCustomerID(cookie);
        if (g1.Rows.Count > 0)
        {

            for (int x = 0; x < g1.Rows.Count; x++)
            {
                if (g1.Rows[x]["Type"].ToString() == "Billing" && !String.IsNullOrEmpty(g1.Rows[x]["Type"].ToString()))
                {
                    string Name = g1.Rows[x]["Name"].ToString();

                    if(Name.Contains(" "))
                    {
                        Bill_FirstName = g1.Rows[x]["Name"].ToString().Split(' ')[0];
                        Bill_LastName = g1.Rows[x]["Name"].ToString().Split(' ')[1];
                    }
                    else
                    {
                        Bill_FirstName = g1.Rows[x]["Name"].ToString();
                    }


                    Bill_City = g1.Rows[x]["City"].ToString();
                    Bill_Zip = g1.Rows[x]["Zip"].ToString();
                    Bill_Phone = g1.Rows[x]["Phone"].ToString();
                    Bill_Address = g1.Rows[x]["Address"].ToString();
                    Bill_State = g1.Rows[x]["State"].ToString();
                }
                else if (g1.Rows[x]["Type"].ToString() == "Shipping" && !String.IsNullOrEmpty(g1.Rows[x]["Type"].ToString()))
                {
                    string Name = g1.Rows[x]["Name"].ToString();

                    if (Name.Contains(" "))
                    {
                        Ship_FirstName = g1.Rows[x]["Name"].ToString().Split(' ')[0];
                        Ship_LastName = g1.Rows[x]["Name"].ToString().Split(' ')[1];
                    }
                    else
                    {
                        Ship_FirstName = g1.Rows[x]["Name"].ToString();
                    }


                    Ship_City = g1.Rows[x]["City"].ToString();
                    Ship_Zip = g1.Rows[x]["Zip"].ToString();
                    Ship_Phone = g1.Rows[x]["Phone"].ToString();
                    Ship_Address = g1.Rows[x]["Address"].ToString();
                    Ship_State = g1.Rows[x]["State"].ToString();
                }
                else
                {
                    billing.Text = "No Information has been provided! </br>";
                    shipping.Text = "No Information has been provided! </br>";
                }

            }
        }
        else
        {
            billing.Text = "No Information has been provided! </br>";
            shipping.Text = "No Information has been provided! </br>";
        }


        DataTable g2 = Access._G_Order_ByCustomerID(cookie);
        if (g2.Rows.Count > 0)
        {
            Label orders = new Label();
            System.Web.Script.Serialization.JavaScriptSerializer javaScriptSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            int count = 0;

            for (int x = 0; x < g2.Rows.Count; x++)
            {
                string status = String.IsNullOrEmpty(g2.Rows[x]["Status"].ToString()) ? "In Process" : g2.Rows[x]["Status"].ToString();

                orders.Text += "<tr>";
                orders.Text += String.Format("<td class='col-sm-1 col-md-1 text-left' style='vertical-align: inherit;'><h5>{0}</h5></td> <td class='col-sm-1 col-md-1 text-left' style='vertical-align: inherit;'>{1}</td> <td class='col-sm-1 col-md-1 text-center' style='vertical-align: inherit;'>{2}</td><td class='col-sm-1 col-md-1 text-center' style='vertical-align: inherit;'>{3}</td>", g2.Rows[x]["CustomerOrderNumber"].ToString(), Convert.ToDateTime(g2.Rows[x]["DateAdded"].ToString()).ToString("MM/dd/yyyy"), status, g2.Rows[x]["Total"].ToString());
                orders.Text += "<td><a onclick='getOrderDetails(" + javaScriptSerializer.Serialize(g2.Rows[x]["CustomerOrderNumber"].ToString()) + ", " + javaScriptSerializer.Serialize(status) + ");' href='#' class='bt_main' style='margin: 10px 0;'> View</a>";
                orders.Text += "</tr>";

            }
            orders_panel.Controls.Add(orders);
        }


        //billing_address_panel.Controls.Add(billing);
        //shipping_address_panel.Controls.Add(shipping);

    }


    public static bool updateUserAddress(string Name, string Address, string State, string City, string Zip, string Phone, string Type)
    {
        Type = Type == "bill" ? "Billing" : "Shipping";

        DataTable u = Access._U_Customer_Address(Name, Address, State, City, Zip, Type, Phone, Cookie);
        return Convert.ToBoolean(u.Rows[0]["INSERTED"]);
    }


    public static bool updateUserAccountDetails(string firstName, string lastName, string displayName, string emailAddress)
    {
        DataTable u = Access._U_Customer_AccountDetails(emailAddress, firstName, lastName, displayName);
        return Convert.ToBoolean(u.Rows[0]["INSERTED"]);
    }

    public static object getUserOrderDetailsByOrderID(string orderID)
    {
        DataTable g = Access._G_Order_ByOrderID(orderID);
        var list = new List<Dictionary<string, object>>();
        var row = new List<Dictionary<string, object>>();
        if (g.Rows.Count > 0)
        {

            list.Add(new Dictionary<string, object> {
                    { "IsRow", false },
                    { "Name", g.Rows[0].Field<string>("Name") },
                    { "No_", g.Rows[0].Field<string>("No_") },
                    { "Style",  g.Rows[0].Field<string>("Style") },
                    { "Type", g.Rows[0].Field<string>("Type")},
                    { "Size",g.Rows[0].Field<string>("Size")},
                    {"Shipping", g.Rows[0].Field<decimal>("ShippingAmount").ToString().Trim() },
                    {"Tax", g.Rows[0].Field<decimal>("Tax").ToString().Trim() },
                    {"SubTotal", g.Rows[0].Field<decimal>("SubTotalAmount").ToString().Trim() },
                    {"Total", g.Rows[0].Field<decimal>("TotalAmount").ToString().Trim() },
                    {"Date", g.Rows[0].Field<DateTime>("DateAdded").ToString("MM/dd/yyyy") },
                    {"Email", g.Rows[0].Field<string>("email") },
                    {"Address", g.Rows[0].Field<string>("Address").ToUpper() },
                    {"City", g.Rows[0].Field<string>("city").ToUpper() },
                    {"Zip", g.Rows[0].Field<string>("Zip").ToUpper() },
                    {"State", g.Rows[0].Field<string>("state").ToUpper() }
            });


            for (int x = 0; x < g.Rows.Count; x++)
            {
                row.Add(new Dictionary<string, object>
                {
                    { "IsRow", true },
                    { "Name", g.Rows[x].Field<string>("Name") },
                    { "ProductNumber", g.Rows[x].Field<string>("No_") },
                    { "Style",  g.Rows[x].Field<string>("Style") },
                    { "Type", g.Rows[x].Field<string>("Type")},
                    {"Price", g.Rows[x].Field<decimal>("UnitPrice").ToString() },
                    { "QTY", g.Rows[x].Field<int>("UnitQuantity").ToString() },
                });
            }

            list.AddRange(row);
        }

        return list;
    }


    [System.Web.Services.WebMethod]
    public static object getOrderDetails(string OrderID)
    {
        return getUserOrderDetailsByOrderID(OrderID);
    }


    [System.Web.Services.WebMethod]
    public static object updateAccountDetails(string firstName, string lastName, string displayName, string emailAddress)
    {
        //return String.Format("Firstname: {0}, Lastname: {1}, DisplayName: {2}, EmailAddress: {3}", firstName, lastName, displayName, emailAddress);
        return updateUserAccountDetails(firstName, lastName, displayName, emailAddress);
    }


    [System.Web.Services.WebMethod]
    public static object updateAddress(string firstName, string lastName, string Address, string State, string City, string Zip, string Phone, string Type)
    {
        //return String.Format("firstName: {0}, Address: {1}, State: {2}, State: {3}, Zip: {4}, Type: {5}", firstName, Address, State, City, Zip, Type);
        string Name = firstName + " " + lastName;

        return updateUserAddress(Name, Address, State, City, Zip, Phone, Type);
    }

}