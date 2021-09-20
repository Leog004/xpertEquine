using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ToastError
/// </summary>
public class ToastError
{
    
    public string status { get; set; }
    public string message { get; set; }

    List<ToastError> error = new List<ToastError>();
  

    public void setStatus(string status)
    {
        this.status = status;
    }

    public void setMessage(string message)
    {
        this.message = message;
    }

    public string getStatus()
    {
        return status;
    }

    public string getMessage()
    {
        return message;
    }

    public object passwordError()
    {
        error.Add(new ToastError("error", "Please double check your password"));
        return error;
    }

    public object EmailError()
    {
        error.Add(new ToastError("error", "Please enter a valid email"));
        return error;
    }

    public object EmptyStringError()
    {
        error.Add(new ToastError("error", "Please make sure all fields are filled"));
        return error;
    }

    public object AlreadyInsertError()
    {
        error.Add(new ToastError("error", "This email is already registered"));
        return error;
    }

    public object success()
    {
        error.Add(new ToastError("success", "Account has been added successfully!"));
        return error;
    }


    public object customError(string Aerror)
    {
        error.Add(new ToastError("Error", Aerror));
        return error;
    }

    public object customSuccess(string Amessage)
    {
        error.Add(new ToastError("Success", Amessage));
        return error;
    }

    // default constructor
    public ToastError()
    {

    }

    // constructor with two pramaters
    public ToastError(string status, string message)
    {
        this.status = status;
        this.message = message;
    }
}