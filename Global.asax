<%@ Application Language="C#" %>

    <%@ Import Namespace="System.Web.Routing"%>
<script runat="server">

    private void RoutingData(RouteCollection routeCollection)
    {

        //PAGES
        //Response.RedirectToRoute("Home");
        routeCollection.MapPageRoute("Home", "Home", "~/Default.aspx");
        //Response.RedirectToRoute("Home", new { Id = 1 });
        routeCollection.MapPageRoute("HomeWid", "Home/{Id}", "~/Default.aspx");


        // SHOP ROUTES
        routeCollection.MapPageRoute("Shop SubCategory", "Shop/{type}/{style}", "~/shop/default.aspx");
        routeCollection.MapPageRoute("Shop Category", "Shop/{type}", "~/shop/default.aspx");
        routeCollection.MapPageRoute("Shop", "shop/", "~/shop/default.aspx");
        routeCollection.MapPageRoute("Product Details", "Details/{name}/{no}", "~/shop/shop_details.aspx");


        routeCollection.MapPageRoute("Invoice", "checkout/invoice/{order}", "~/shop/invoice.aspx");


        routeCollection.MapPageRoute("About", "about/", "~/about.aspx");
        routeCollection.MapPageRoute("Contact", "contact/", "~/contact.aspx");


        routeCollection.MapPageRoute("Login", "Login/", "~/Authorization/default.aspx");
        routeCollection.MapPageRoute("New User", "Login/New", "~/Authorization/newUser.aspx");



        // Search ROUTES
        routeCollection.MapPageRoute("Search", "Search/{search}", "~/search.aspx");



    }



    void Application_Start(object sender, EventArgs e)
    {
        // Code that runs on application startup
        RoutingData(RouteTable.Routes);

    }

    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown

    }

    void Application_Error(object sender, EventArgs e)
    {

        HttpUnhandledException httpUnhandledException =
        new HttpUnhandledException(Server.GetLastError().Message, Server.GetLastError());
        //Utilities.errorLog(Server.GetLastError().ToString());

    }

    void Session_Start(object sender, EventArgs e)
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e)
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }


    protected void Application_BeginRequest(Object sender, EventArgs e)
    {
        Response.AppendHeader("Access-Control-Allow-Origin", "*");
        Response.AppendHeader("Access-Control-Allow-Methods", "*");



        string host = HttpContext.Current.Request.Url.Host;
        if (host == "xpertequine.com")
        {
            if (HttpContext.Current.Request.IsSecureConnection.Equals(false))
            {
                Response.Redirect("https://" + Request.ServerVariables["HTTP_HOST"] + HttpContext.Current.Request.RawUrl);
            }
        }
        else if (host =="www.xpertequine.com")
        {
            if (HttpContext.Current.Request.IsSecureConnection.Equals(false))
            {
                Response.Redirect("https://" + Request.ServerVariables["HTTP_HOST"] + HttpContext.Current.Request.RawUrl);
            }
        }
    }

</script>