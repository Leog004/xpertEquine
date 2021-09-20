using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Controls_Nav : System.Web.UI.UserControl
{
    public string Name = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Request.Cookies["Xpert_CustomerID"] != null)
        {

            if (Request.Cookies["Xpert_CustomerID"].Value == "Logout")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "signOut", "signOut()", true);

                HttpCookie c_Password = new HttpCookie("Xpert_CustomerID");
                c_Password.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(c_Password);
            }

            else if (Request.Cookies["Xpert_CustomerID"].Value == "NoItems")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "noItems", "noItems()", true);

                HttpCookie c_Password = new HttpCookie("Xpert_CustomerID");
                c_Password.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(c_Password);
            }

            else
            {

                logout_head.Visible = true;
                logOut_mobile.Visible = true;


                login_head.Visible = false;
                login_mobile.Visible = false;

                var cookie = Request.Cookies["Xpert_CustomerID"].Value;


                DataTable g = Access._G_Customer_ByCustomerID(cookie);
                if (g.Rows.Count > 0)
                {

                    //Name = String.IsNullOrEmpty(g.Rows[0]["DisplayName"].ToString())
                    //    ? String.Format("{0} {1}", g.Rows[0]["FirstName"].ToString(), g.Rows[0]["LastName"].ToString())
                    //    : g.Rows[0]["DisplayName"].ToString();
                }
            }


        }

        if (HttpContext.Current.Request.Cookies["REM_CartID"] != null)
        {
            string cart = Access.GetCartID("");
            DataTable myCartID = Access._G_Cart_ByCartID(cart);

            if (myCartID.Rows.Count > 0)
            {
                cart_span.Attributes.Remove("class");
                cart_span.Attributes.Add("class", "mycart fas fa-cart-plus");

                cart_span_mobile.Attributes.Remove("class");
                cart_span_mobile.Attributes.Add("class", "mycart fas fa-cart-plus");
            }
            else
            {
                cart_span.Attributes.Remove("class");
                cart_span.Attributes.Add("class", "mycart fas fa-shopping-cart");

                cart_span_mobile.Attributes.Remove("class");
                cart_span_mobile.Attributes.Add("class", "mycart fas fa-shopping-cart");
            }

        }
        else
        {
            cart_span.Attributes.Remove("class");
            cart_span.Attributes.Add("class", "mycart fas fa-shopping-cart");

            cart_span_mobile.Attributes.Remove("class");
            cart_span_mobile.Attributes.Add("class", "mycart fas fa-shopping-cart");
        }

    }

 
    protected void logout_Click(object sender, EventArgs e)
    {
        HttpCookie c_Email = new HttpCookie("Xpert_CustomerEmail");
        HttpCookie c_Password = new HttpCookie("Xpert_CustomerID");

        c_Email.Expires = DateTime.Now.AddDays(-1);
        c_Password.Expires = DateTime.Now.AddDays(1);

        c_Password.Value = "Logout";

        Response.Cookies.Add(c_Email);
        Response.Cookies.Add(c_Password);



        Response.Redirect("/");
    }
}