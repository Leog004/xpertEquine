using SecurityLib;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Authorization_newUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    [System.Web.Services.WebMethod]
    public static object add_newUser(string email, string firstName, string lastName, string phone, string password, string passwordConfirm, string Notifications)
    {
        string[] fields = { firstName, lastName, phone };
        ToastError error = new ToastError();

        if (passwordConfirm != password) return error.passwordError(); // confirming password

        if (!Validate_email(email)) return error.EmailError(); // validating email

        if (!Validate_fields(fields)) return error.EmptyStringError(); // checking for any null values

        string passwordEncrypted = StringEncryptor.Encrypt(password);
        DataTable a = Access._A_Customer(firstName, lastName, email, passwordEncrypted, phone, Notifications); // adding new user to database
        if (!Convert.ToBoolean(a.Rows[0]["completed"])) return error.AlreadyInsertError(); // checking for duplicates


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