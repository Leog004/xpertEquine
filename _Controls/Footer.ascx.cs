using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Controls_Footer : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        hasItemsInCart();
    }

    protected void hasItemsInCart()
    {
        if (HttpContext.Current.Request.Cookies["REM_CartID"] != null)
        {
            //this.Controls.Add(new LiteralControl("<script>alert();</script>"));

        }
    }
}