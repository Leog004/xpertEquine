using SecurityLib;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Authorization_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    [System.Web.Services.WebMethod]
    public static object login(string email, string password)
    {
        string[] fields = { email, password };
        ToastError error = new ToastError();


        if (!Validate_email(email)) return error.EmailError(); // validating email

        if (!Validate_fields(fields)) return error.EmptyStringError(); // checking for any null values

        string passwordEncrypted = StringEncryptor.Encrypt(password);
        DataTable g = Access._G_Customer(email, passwordEncrypted);

        if (Convert.ToBoolean(g.Rows[0]["completed"]))
        {
            if (Access.LogIn(email, passwordEncrypted) != "0")
            {
                return error.success();
            }
        }
        else
        {
            return error.EmailError();
        }
       


        return error.success(); // sending a success message back to user
    }

    private static bool Validate_fields(string[] field)
    {

        foreach (var values in field)
            if (String.IsNullOrEmpty(values)) return false;

        return true;
    }


    private static bool Validate_email(string email)
    {
        var validate = new EmailAddressAttribute();

        bool isValid = validate.IsValid(email);

        return isValid;
    }
}