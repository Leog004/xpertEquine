using System;
using System.Net;
using System.Net.Mail;
using System.Globalization;
using System.Threading;
using System.Collections;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Data;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using SecurityLib;
/// <summary>
/// Class contains miscellaneous functionality 
/// </summary>
public static class Utilities
{
    static Utilities()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    // Generic method for sending emails

    public static void SendMail(string from, string to, string subject, string body)
    {
        // Configure mail client
        SmtpClient mailClient = new SmtpClient(Configuration.MailServer);
        // Set credentials (for SMTP servers that require authentication)
        mailClient.Credentials = new NetworkCredential(Configuration.MailUsername, Configuration.MailPassword);
        // Create the mail message
        MailMessage mailMessage = new MailMessage(ConfigurationManager.AppSettings["ErrorLogEmail"], to, subject, body);
        // Send mail
        //mailClient.Send(mailMessage);
    }
    public static void LogError(Exception ex)
    {

        // get the current date and time
        string dateTime = DateTime.Now.ToLongDateString() + ", at "
                  + DateTime.Now.ToShortTimeString();
        // stores the error message
        string errorMessage = "Exception generated on " + dateTime;
        // obtain the page that generated the error
        System.Web.HttpContext context = System.Web.HttpContext.Current;
        errorMessage += "\n\n Page location: " + context.Request.RawUrl;
        // build the error message
        errorMessage += "\n\n Message: " + ex.Message;
        errorMessage += "\n\n Source: " + ex.Source;
        errorMessage += "\n\n Method: " + ex.TargetSite;
        errorMessage += "\n\n Stack Trace: \n\n" + ex.StackTrace;
        // send error email in case the option is activated in Web.Config
        if (Configuration.EnableErrorLogEmail)
        {
            string from = Configuration.ErrorLogEmail;
            string to = Configuration.ErrorLogEmail;
            string subject = " Error Report";
            string body = errorMessage;
            SendMail(ConfigurationManager.AppSettings["ErrorLogEmail"], to, subject, body);
        }
    }
    public static void errorLog(string error)
    {
        string to1 = ConfigurationManager.AppSettings["ErrorLogEmail"];
        string from = ConfigurationManager.AppSettings["ErrorLogEmail"];
        string subject = " Error Report1";
        // Configure mail client
        SmtpClient mailClient = new SmtpClient(Configuration.MailServer);
        // Set credentials (for SMTP servers that require authentication)
        mailClient.Credentials = new NetworkCredential(Configuration.MailUsername, Configuration.MailPassword);
        // Create the mail message
        // get the current date and time
        // get the current date and time
        string dateTime = DateTime.Now.ToLongDateString() + ", at "
                      + DateTime.Now.ToShortTimeString();
        // stores the error message
        string eMessage = "Exception generated on " + dateTime;
        // obtain the page that generated the error
        System.Web.HttpContext context = System.Web.HttpContext.Current;
        eMessage = "PAGE LOCATION: " + context.Request.RawUrl;
        // stores the error message
        eMessage += "\n\n DATE SENT:\n" + dateTime;
        eMessage += "\n\n ERROR:\n" + error;

        MailMessage mailMessage1 = new MailMessage(ConfigurationManager.AppSettings["ErrorLogEmail"], to1, subject, eMessage);
        // Send mail
        
            mailClient.Send(mailMessage1);
        

    }


    public static void SendPassword(string recepientEmail, string subject, string body)
    {
        SmtpClient mailClient = new SmtpClient(Configuration.MailServer);
        mailClient.Credentials = new NetworkCredential(Configuration.MailUsername, Configuration.MailPassword);
        string dateTime = DateTime.Now.ToLongDateString() + ", at " + DateTime.Now.ToShortTimeString();

        MailMessage mailMessage = new MailMessage();
        mailMessage.From = new MailAddress(ConfigurationManager.AppSettings["CustomerServiceEmail"], "ExpertEquine.com");
        mailMessage.Subject = subject;
        mailMessage.Body = body;
        mailMessage.IsBodyHtml = true;
        mailMessage.To.Add(new MailAddress(recepientEmail));

        mailClient.Send(mailMessage);
    }

    public static void SendCustomerMessage(string recepientEmail, string subject, string body)
    {
        SmtpClient mailClient = new SmtpClient(Configuration.MailServer);
        mailClient.Credentials = new NetworkCredential(Configuration.MailUsername, Configuration.MailPassword);
        string dateTime = DateTime.Now.ToLongDateString() + ", at " + DateTime.Now.ToShortTimeString();

        MailMessage mailMessage = new MailMessage();
        mailMessage.From = new MailAddress(ConfigurationManager.AppSettings["CustomerServiceEmail"], "ExpertEquine.com");
        mailMessage.Subject = subject;
        mailMessage.Body = body;
        mailMessage.IsBodyHtml = true;
        mailMessage.To.Add(new MailAddress(recepientEmail));

        mailClient.Send(mailMessage);


        MailMessage mailMessage1 = new MailMessage();
        mailMessage1.From = new MailAddress(ConfigurationManager.AppSettings["CustomerServiceEmail"], "ExpertEquine.com");
        mailMessage1.Subject = subject;
        mailMessage1.Body = body;
        mailMessage1.IsBodyHtml = true;
        mailMessage1.To.Add(new MailAddress(ConfigurationManager.AppSettings["OrderProcessorEmail"]));

        mailClient.Send(mailMessage1);

    }

    public static void SendCustomerContactMessage(string recepientEmail, string subject, string body)
    {
        SmtpClient mailClient = new SmtpClient(Configuration.MailServer);
        mailClient.Credentials = new NetworkCredential(Configuration.MailUsername, Configuration.MailPassword);
        string dateTime = DateTime.Now.ToLongDateString() + ", at " + DateTime.Now.ToShortTimeString();

        MailMessage mailMessage = new MailMessage();
        mailMessage.From = new MailAddress(ConfigurationManager.AppSettings["CustomerService"], "ExpertEquine.com");
        mailMessage.Subject = subject;
        mailMessage.Body = body;
        mailMessage.IsBodyHtml = true;
        mailMessage.To.Add(new MailAddress(recepientEmail));

        mailClient.Send(mailMessage);


        MailMessage mailMessage1 = new MailMessage();
        mailMessage1.From = new MailAddress(ConfigurationManager.AppSettings["CustomerService"], "ExpertEquine.com");
        mailMessage1.Subject = subject;
        mailMessage1.Body = body;
        mailMessage1.IsBodyHtml = true;
        mailMessage1.To.Add("lgarza@equibrand.com");

        mailClient.Send(mailMessage1);

    }


}
