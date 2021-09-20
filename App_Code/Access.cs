using System;
using System.Data;
using System.Data.Common;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Net;
using SalesAPI;
using System.Collections.Generic;
using SalesOrder;

/// <summary>
/// Summary description for Access
/// </summary>
public class Access
{
    public Access()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static DataTable _A_ToOrder(string CartID, string CustomerID, string CustomerOrderNumber,
    int BillingAddressID, int ShippingAddressID, double SubTotalAmt, double ShippingAmt, double ShippingDiscount,
    double TaxAmt, double ProductDiscount, int DiscountID, string Comments)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "_A_ToOrder";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@CartID";
        param.Value = CartID;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@CustomerID";
        param.Value = CustomerID;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@CustomerOrderNumber";
        param.Value = CustomerOrderNumber;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@BillingAddressID";
        param.Value = BillingAddressID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@ShippingAddressID";
        param.Value = ShippingAddressID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@SubTotalAmt";
        param.Value = SubTotalAmt;
        param.DbType = DbType.Double;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@ShippingAmt";
        param.Value = ShippingAmt;
        param.DbType = DbType.Double;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@ShippingDiscount";
        param.Value = ShippingDiscount;
        param.DbType = DbType.Double;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@TaxAmt";
        param.Value = TaxAmt;
        param.DbType = DbType.Double;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@ProductDiscount";
        param.Value = ProductDiscount;
        param.DbType = DbType.Double;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@DiscountID";
        param.Value = DiscountID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@Comments";
        param.Value = Comments;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
        return table;
    }

    public static string createNavSalesOrder(Address billing, Address shipping, List<WebItem> items, string creditCardNo, string expMonth, string expYear, string shState)
    {

        navSalesOrder_Service salesService = new navSalesOrder_Service();
        salesService.UseDefaultCredentials = false;
        salesService.Credentials = new NetworkCredential("navuserv", "NSNav1515");
        salesService.Url = ConfigurationManager.AppSettings["SalesOrder.navSalesOrder"];
        //salesService.Url = ConfigurationManager.AppSettings["navSalesOrder.navSalesOrder"];
       

        navSalesAPI api = new navSalesAPI();
        api.UseDefaultCredentials = false;
        api.Credentials = new NetworkCredential("navuserv", "NSNav1515");
        api.Url = ConfigurationManager.AppSettings["SalesAPI.navSalesAPI"]; 
        //api.Url = ConfigurationManager.AppSettings["navSalesAPI.navSalesAPI"];


        string order = api.CreateRetailWebOrder();
        //string order = api.CreateJebOrder();

        navSalesOrder saleOrder = salesService.Read(order);

        saleOrder.Location_Code = "GR";

        saleOrder.Account_Number_CL = creditCardNo.Replace("-", "");
        saleOrder.Expiration_Month_CL = expMonth;
        saleOrder.Expiration_Year_CL = expYear;

        //saleOrder.Account_Number = creditCardNo.Replace("-","");
        //saleOrder.Expiration_Month = expMonth;
        //saleOrder.Expiration_Year = expYear;

        saleOrder.Payment_Method_Code = "CREDITCARD";
        saleOrder.Ship_to_Address = shipping.stAddress;
        saleOrder.Ship_to_Address_2 = shipping.stAddress2;
        saleOrder.Ship_to_City = shipping.city;
        saleOrder.Ship_to_Name = shipping.name;
        saleOrder.Ship_to_Phone_No = shipping.phone;
        saleOrder.Ship_to_Post_Code = shipping.zipCode;
        saleOrder.Ship_to_County = shipping.state;

        saleOrder.Sell_to_Address = shipping.stAddress;
        saleOrder.Sell_to_Address_2 = shipping.stAddress2;
        saleOrder.Sell_to_City = shipping.city;
        saleOrder.Sell_to_Customer_Name = shipping.name;
        saleOrder.Sell_to_Post_Code = shipping.zipCode;
        saleOrder.Sell_to_County = shipping.state;

        saleOrder.Bill_to_Address = billing.stAddress;
        saleOrder.Bill_to_Address_2 = billing.stAddress2;
        saleOrder.Bill_to_City = billing.city;
        saleOrder.Bill_to_Name = billing.name;
        saleOrder.Bill_to_Post_Code = billing.zipCode;
        saleOrder.Bill_to_County = billing.state;

        saleOrder.Tax_Liable = false;
        saleOrder.Tax_LiableSpecified = true;
        saleOrder.Tax_Area_Code = "";
        if (shState == "Texas" || shState == "TX")
        {
            saleOrder.Tax_Liable = true;
            saleOrder.Tax_LiableSpecified = true;
            saleOrder.Tax_Area_Code = "TX";
        }
        else if (shState == "Washington" || shState == "WA")
        {
            saleOrder.Tax_Liable = true;
            saleOrder.Tax_LiableSpecified = true;
            saleOrder.Tax_Area_Code = "WA";
        }
        else if (shState == "Iowa" || shState == "IA")
        {
            saleOrder.Tax_Liable = true;
            saleOrder.Tax_LiableSpecified = true;
            saleOrder.Tax_Area_Code = "IA";
        }

        List<Sales_Order_Line> saleLines = new List<Sales_Order_Line>();

        foreach (WebItem wItem in items)
        {

            Sales_Order_Line saleLine = new Sales_Order_Line();
            if (wItem.itemNo == "461200")
            {
                saleLine.Type = SalesOrder.Type.G_L_Account;
                saleLine.Shortcut_Dimension_1_Code = "GENERAL";
            }
            else
            {
                saleLine.Type = SalesOrder.Type.Item;
            }


            saleLine.TypeSpecified = true;
            saleLine.Quantity = wItem.quantity;
            saleLine.QuantitySpecified = true;
            saleLine.Unit_Price = wItem.price;
            saleLine.Unit_PriceSpecified = true;
            saleLine.No = wItem.itemNo;

            saleLines.Add(saleLine);
        }

        saleOrder.SalesLines = saleLines.ToArray();
        salesService.Update(ref saleOrder);


        return saleOrder.No;
    }


    public static DataTable _A_Address(string CustomerID, string Type, string Name, string Address,
    string Address2, string City, string State, string Zip, string phone)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "_A_Address";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@CustomerID";
        param.Value = CustomerID;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@Type";
        param.Value = Type;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@Name";
        param.Value = Name;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@Address";
        param.Value = Address;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@Address2";
        param.Value = Address2;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@City";
        param.Value = City;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@State";
        param.Value = State;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@Zip";
        param.Value = Zip;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@Phone";
        param.Value = phone;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
        return table;
    }

    public static DataTable _Add_User_Subscriber(string email)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "Add_User_Subscriber";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@email";
        param.Value = email;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
        return table;

    }


    public static DataTable get_Product_Search(string search, int page, int show, int orderBy, string filter)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "get_Product_Search";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@search";
        param.Value = search;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@page";
        param.Value = page;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@show";
        param.Value = show;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@orderBy";
        param.Value = orderBy;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@filter";
        param.Value = filter;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
        return table;

    }
    


    public static DataTable _G_ProductsByCategory(string Category)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "_G_ProductsByCategory";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@Category";
        param.Value = Category;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
        return table;

    }


    public static DataTable _G_ProductsByCategory_new(string Category, int OrderBy)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "_G_ProductsByCategory_new";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@Category";
        param.Value = Category;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@OrderBy";
        param.Value = OrderBy;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);


        DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
        return table;

    }


    public static DataTable _G_Freight(string CartID)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "_G_Freight";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@CartID";
        param.Value = CartID;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
        return table;

    }


    public static DataTable _G_Tax(string StateCode)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "_G_Tax";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@StateCode";
        param.Value = StateCode;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
        return table;
    }

    public static DataTable _G_Cart_ByCartID(string CartID)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "_G_Cart_ByCartID";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@CartID";
        param.Value = CartID;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);


        DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
        return table;

    }

    public static DataTable _U_CartQuantity(string CartID, string Quantity)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "_U_CartQuantity";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@CartID";
        param.Value = CartID;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@Quantity";
        param.Value = Quantity;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
        return table;

    }

    public static DataTable get_Page_Content_Images(string ID)
    {

        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "get_Page_Content_Images_ByID";

        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@ID";
        param.Value = ID;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);


        // execute the stored procedure and return the results
        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable get_Page_Content_ByPage_Location(string Page, string Location)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "get_Page_Content_ByPage_Location";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@Page";
        param.Value = Page;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@Location";
        param.Value = Location;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
        return table;

    }

    public static DataTable _G_Page_Content_Images_ByContentID(int ID)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "_G_Page_Content_Images_ByContentID";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@ID";
        param.Value = ID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
        return table;

    }


    public static DataTable get_Cart_By_ID(string ID)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "get_Cart_By_ID";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@ID";
        param.Value = ID;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
        return table;

    }

    public static DataTable _D_Cart_ByShoppingCartID(string CartID)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "_D_Cart_ByShoppingCartID";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@CartID";
        param.Value = CartID;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
        return table;

    }

    public static DataTable _A_ToCart(string CartID, string No_, string Name, int Quantity, decimal Price)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "_A_ToCart";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@CartID";
        param.Value = CartID;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@No_";
        param.Value = No_;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@Name";
        param.Value = Name;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@Quantity";
        param.Value = Quantity;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@Price";
        param.Value = Price;
        param.DbType = DbType.Decimal;
        comm.Parameters.Add(param);
        DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
        return table;

    }


    public static string GetCartID(string CartID)
    {
        if (HttpContext.Current.Request.Cookies["REM_CartID"] != null)
        {
            CartID = HttpContext.Current.Request.Cookies["REM_CartID"].Value;
        }
        else
        {
            Guid g;
            // Create and display the value of two GUIDs.
            g = Guid.NewGuid();
            CartID = g.ToString();
            HttpCookie A_CartID = new HttpCookie("REM_CartID");
            A_CartID.Value = CartID;
            A_CartID.Expires = DateTime.Now.AddDays(Convert.ToDouble(ConfigurationManager.AppSettings["ShoppingCartSaveDays"]));
            HttpContext.Current.Response.Cookies.Add(A_CartID);
        }
        return CartID;
    }

    public static DataTable _A_CustomerMessage(string Name, string Email, string Phone, string Message)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "_A_CustomerMessage";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@Name";
        param.Value = Name;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@Email";
        param.Value = Email;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@Phone";
        param.Value = Phone;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@Message";
        param.Value = Message;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);


        DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
        return table;
    }

    public static DataTable _G_Customer(string Email, string Password)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "_G_Customer";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@Email";
        param.Value = Email;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@Password";
        param.Value = Password;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
        return table;
    }

    public static DataTable _G_All_Types()
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        //// set the stored procedure name
        comm.CommandText = "_G_ALL_Types";

        //// create a new parameter
        //DbParameter param = comm.CreateParameter();
        //param.ParameterName = "@brand";
        //param.Value = brand;
        //param.DbType = DbType.String;
        //comm.Parameters.Add(param);


        // execute the stored procedure and return the results
        return GenericDataAccess.ExecuteSelectCommand(comm);
    }


    public static DataTable _G_All_Types_New_Sort(int OrderBy)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        //// set the stored procedure name
        comm.CommandText = "_G_All_Types_New_Sort";

        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@OrderBy";
        param.Value = OrderBy;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);


        // execute the stored procedure and return the results
        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable _G_GetProductTypes_ByStyle(string Name, string Style)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        //// set the stored procedure name
        comm.CommandText = "_G_GetProductTypes_ByStyle";

        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@Name";
        param.Value = Name;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);


        param = comm.CreateParameter();
        param.ParameterName = "@Style";
        param.Value = Style;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        // execute the stored procedure and return the results
        return GenericDataAccess.ExecuteSelectCommand(comm);
    }


    public static DataTable get_Products_ByNo(string No_)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        //// set the stored procedure name
        comm.CommandText = "get_Products_ByNo";

        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@No_";
        param.Value = No_;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);


        // execute the stored procedure and return the results
        return GenericDataAccess.ExecuteSelectCommand(comm);
    }


    public static DataTable get_Products_Sizes(string No_)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        //// set the stored procedure name
        comm.CommandText = "get_Products_Sizes";

        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@No_";
        param.Value = No_;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);


        // execute the stored procedure and return the results
        return GenericDataAccess.ExecuteSelectCommand(comm);
    }
    public static DataTable get_Products_Type(string No_)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        //// set the stored procedure name
        comm.CommandText = "get_Products_Type";

        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@No_";
        param.Value = No_;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);


        // execute the stored procedure and return the results
        return GenericDataAccess.ExecuteSelectCommand(comm);
    }


    public static DataTable _G_Users()
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        //// set the stored procedure name
        comm.CommandText = "_G_Users";

        //// create a new parameter
        //DbParameter param = comm.CreateParameter();
        //param.ParameterName = "@brand";
        //param.Value = brand;
        //param.DbType = DbType.String;
        //comm.Parameters.Add(param);


        // execute the stored procedure and return the results
        return GenericDataAccess.ExecuteSelectCommand(comm);
    }


    public static DataTable _G_videos()
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        //// set the stored procedure name
        comm.CommandText = "_G_videos";

        //// create a new parameter
        //DbParameter param = comm.CreateParameter();
        //param.ParameterName = "@brand";
        //param.Value = brand;
        //param.DbType = DbType.String;
        //comm.Parameters.Add(param);


        // execute the stored procedure and return the results
        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable _G_All_Types_New()
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        //// set the stored procedure name
        comm.CommandText = "_G_All_Types_New";

        //// create a new parameter
        //DbParameter param = comm.CreateParameter();
        //param.ParameterName = "@brand";
        //param.Value = brand;
        //param.DbType = DbType.String;
        //comm.Parameters.Add(param);


        // execute the stored procedure and return the results
        return GenericDataAccess.ExecuteSelectCommand(comm);
    }


    public static DataTable _G_GetReviews()
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        //// set the stored procedure name
        comm.CommandText = "_G_GetReviews";

        //// create a new parameter
        //DbParameter param = comm.CreateParameter();
        //param.ParameterName = "@brand";
        //param.Value = brand;
        //param.DbType = DbType.String;
        //comm.Parameters.Add(param);


        // execute the stored procedure and return the results
        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable _G_Get_MouthPiece_ByType(string type)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        //// set the stored procedure name
        comm.CommandText = "_G_Get_MouthPiece_ByType";

        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@type";
        param.Value = type;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);


        // execute the stored procedure and return the results
        return GenericDataAccess.ExecuteSelectCommand(comm);
    }


    public static DataTable _G_Get_MouthPiece_ByNo_(string No_)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        //// set the stored procedure name
        comm.CommandText = "_G_Get_MouthPiece_ByNo_";

        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@No_";
        param.Value = No_;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);


        // execute the stored procedure and return the results
        return GenericDataAccess.ExecuteSelectCommand(comm);
    }


    public static DataTable _G_Customer_ByCustomerID(string CustomerID)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        //// set the stored procedure name
        comm.CommandText = "_G_Customer_ByCustomerID";

        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@CustomerID";
        param.Value = CustomerID;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);


        // execute the stored procedure and return the results
        return GenericDataAccess.ExecuteSelectCommand(comm);
    }


    public static DataTable _G_GetReviews_ByNo_(string No_)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        //// set the stored procedure name
        comm.CommandText = "_G_GetReviews_ByNo_";

        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@No_";
        param.Value = No_;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);


        // execute the stored procedure and return the results
        return GenericDataAccess.ExecuteSelectCommand(comm);
    }


    public static DataTable _G_GetOrdersBy_Email(string email)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        //// set the stored procedure name
        comm.CommandText = "_G_GetOrdersBy_Email";

        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@email";
        param.Value = email;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);


        // execute the stored procedure and return the results
        return GenericDataAccess.ExecuteSelectCommand(comm);
    }


    public static DataTable _G_Get_CustomerInformation_By_Review_No_(string No_, string customerID)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        //// set the stored procedure name
        comm.CommandText = "_G_Get_CustomerInformation_By_Review_No_";

        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@No_";
        param.Value = No_;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@customerID";
        param.Value = customerID;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);


        // execute the stored procedure and return the results
        return GenericDataAccess.ExecuteSelectCommand(comm);
    }


    public static DataTable _G_Get_MouthPieceLength_ByTypeAndStyle(string MouthPiece, string Type, string Style)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        //// set the stored procedure name
        comm.CommandText = "_G_Get_MouthPieceLength_ByTypeAndStyle";

        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@MouthPiece";
        param.Value = MouthPiece;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@Type";
        param.Value = Type;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);


        param = comm.CreateParameter();
        param.ParameterName = "@Style";
        param.Value = Style;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);


        // execute the stored procedure and return the results
        return GenericDataAccess.ExecuteSelectCommand(comm);
    }



    public static DataTable _G_Get_ProductLength_ByTypeAndStyle(string Name, string Type, string Style)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        //// set the stored procedure name
        comm.CommandText = "_G_Get_ProductLength_ByTypeAndStyle";

        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@Name";
        param.Value = Name;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@Type";
        param.Value = Type;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@Style";
        param.Value = Style;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);


        // execute the stored procedure and return the results
        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable _G_Get_MouthpieceStyle_ByType(string MouthPiece, string Type)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        //// set the stored procedure name
        comm.CommandText = "_G_Get_MouthpieceStyle_ByType";

        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@MouthPiece";
        param.Value = MouthPiece;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@Type";
        param.Value = Type;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);



        // execute the stored procedure and return the results
        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable _G_Get_ProductStyle_ByType(string Name, string Type)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        //// set the stored procedure name
        comm.CommandText = "_G_Get_ProductStyle_ByType";

        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@Name";
        param.Value = Name;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@Type";
        param.Value = Type;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);



        // execute the stored procedure and return the results
        return GenericDataAccess.ExecuteSelectCommand(comm);
    }



    public static DataTable _A_Review(string CustomerID, string No_, string Text, int StarRating)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        //// set the stored procedure name
        comm.CommandText = "_A_Review";

        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@CustomerID";
        param.Value = CustomerID;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@No_";
        param.Value = No_;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@Text";
        param.Value = Text;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@StarRating";
        param.Value = StarRating;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);



        // execute the stored procedure and return the results
        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static string LogIn(string Email, string Password)
    {
        DataTable get = _G_Customer(Email, Password);
        if (get.Rows.Count > 0)
        {
            HttpCookie A_CustomerEmail = new HttpCookie("Xpert_CustomerEmail");
            A_CustomerEmail.Value = Email;
            A_CustomerEmail.Expires = DateTime.Now.AddDays(Convert.ToDouble(ConfigurationManager.AppSettings["ShoppingCartSaveDays"]));
            HttpContext.Current.Response.Cookies.Add(A_CustomerEmail);

            HttpCookie A_CustomerID = new HttpCookie("Xpert_CustomerID");
            A_CustomerID.Value = get.Rows[0]["UserID"].ToString();
            A_CustomerID.Expires = DateTime.Now.AddDays(Convert.ToDouble(ConfigurationManager.AppSettings["ShoppingCartSaveDays"]));
            HttpContext.Current.Response.Cookies.Add(A_CustomerID);


            return get.Rows[0]["UserID"].ToString();
        }
        else
        {
            return "0";
        }
    }

    public static DataTable _G_Customer_ByEmail(string Email)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "_G_Customer_ByEmail";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@Email";
        param.Value = Email;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
        return table;
    }

    public static DataTable _G_Address_ByAddressID(string AddressID)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "_G_Address_ByAddressID";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@AddressID";
        param.Value = AddressID;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
        return table;
    }


    public static DataTable _G_Address_ByCustomerID(string CustomerID)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "_G_Address_ByCustomerID";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@CustomerID";
        param.Value = CustomerID;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
        return table;
    }

    public static DataTable _G_Order_ByOrderID(string OrderID)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "_G_Order_ByOrderID";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@OrderID";
        param.Value = OrderID;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
        return table;
    }


    public static DataTable _G_Order_ByCustomerID(string CustomerID)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "_G_Order_ByCustomerID";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@CustomerID";
        param.Value = CustomerID;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
        return table;
    }


    public static DataTable _U_Customer_Password_ByEmail(string Email, string Password)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "_U_Customer_Password_ByEmail";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@Email";
        param.Value = Email;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@Password";
        param.Value = Password;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
        return table;
    }


    public static DataTable _U_Customer_AccountDetails(string Email, string FirstName, string LastName, string DisplayName)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "_U_Customer_AccountDetails";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@Email";
        param.Value = Email;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@FirstName";
        param.Value = FirstName;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@LastName";
        param.Value = LastName;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@DisplayName";
        param.Value = DisplayName;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
        return table;
    }

    public static DataTable _U_Customer_Address(string Name, string Address, string State, string City, string Zip, string Type, string Phone, string CustomerID)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "_U_Customer_Address";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@Name";
        param.Value = Name;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@Address";
        param.Value = Address;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);


        param = comm.CreateParameter();
        param.ParameterName = "@State";
        param.Value = State;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@City";
        param.Value = City;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@Zip";
        param.Value = Zip;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@Type";
        param.Value = Type;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@Phone";
        param.Value = Phone;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@CustomerID";
        param.Value = CustomerID;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);



        DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
        return table;
    }



    public static DataTable _G_Customer_Password(string FirstName, string LastName, string Email)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "_G_Customer_Password";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@FirstName";
        param.Value = FirstName;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@LastName";
        param.Value = LastName;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@Email";
        param.Value = Email;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
        return table;
    }


    public static DataTable _A_Customer(string FirstName, string LastName, string Email, string Password, string Phone, string Notifications)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "_A_Customer";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@FirstName";
        param.Value = FirstName;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@LastName";
        param.Value = LastName;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@Email";
        param.Value = Email;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@Password";
        param.Value = Password;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@Phone";
        param.Value = Phone;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@Notifications";
        param.Value = Notifications;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
        return table;
    }


    public static DataTable _G_Bits(string Type, string Style, string Mouthpiece, string Length, string Product)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        //// set the stored procedure name
        comm.CommandText = "_G_Bits";

        //// create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@Type";
        param.Value = Type;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);


        param = comm.CreateParameter();
        param.ParameterName = "@Style";
        param.Value = Style;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@MouthPiece";
        param.Value = Mouthpiece;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@Length";
        param.Value = Length;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@Product";
        param.Value = Product;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        // execute the stored procedure and return the results
        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DataTable _G_MostPopular()
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        //// set the stored procedure name
        comm.CommandText = "_G_MostPopular";

        //// create a new parameter
        //DbParameter param = comm.CreateParameter();
        //param.ParameterName = "@brand";
        //param.Value = brand;
        //param.DbType = DbType.String;
        //comm.Parameters.Add(param);


        // execute the stored procedure and return the results
        return GenericDataAccess.ExecuteSelectCommand(comm);
    }
}
