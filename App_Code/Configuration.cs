using System.Configuration;

/// <summary>
/// Summary description for MyConfiguration
/// </summary>
public class Configuration
{
    // Caches the connection string
    private static string dbConnectionString;
    // Caches the data provider name 
    private static string dbProviderName;
    // Store the name of your shop
    private readonly static string siteName;
    private readonly static string NewCustomerEmailFrom;

    static Configuration()
    {

        dbConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        dbProviderName = ConfigurationManager.ConnectionStrings["ConnectionString"].ProviderName;
        siteName = ConfigurationManager.AppSettings["SiteName"];
    }

    // Returns the connection string for the My database

    public static string ReviewApprovalEmail
    {
        get
        {
            return ConfigurationManager.AppSettings["ReviewApprovalEmail"];
        }
    }
    public static string DbConnectionString
    {
        get
        {
            return dbConnectionString;
        }
    }

    // Returns the data provider name
    public static string DbProviderName
    {
        get
        {
            return dbProviderName;
        }
    }
    // Returns the address of the mail server
    public static string MailServer
    {
        get
        {
            return ConfigurationManager.AppSettings["MailServer"];
        }
    }

    // Returns the email username
    public static string MailUsername
    {
        get
        {
            return ConfigurationManager.AppSettings["MailUsername"];
        }
    }

    // Returns the email password
    public static string MailPassword
    {
        get
        {
            return ConfigurationManager.AppSettings["MailPassword"];
        }
    }

    // Returns the email password
    public static string MailFrom
    {
        get
        {
            return ConfigurationManager.AppSettings["MailFrom"];
        }
    }

    // Send error log emails?
    public static bool EnableErrorLogEmail
    {
        get
        {
            return bool.Parse(ConfigurationManager.AppSettings
            ["EnableErrorLogEmail"]);
        }
    }

    // Returns the email address where to send error reports
    public static string ErrorLogEmail
    {
        get
        {
            return ConfigurationManager.AppSettings["ErrorLogEmail"];
        }
    }

    // Returns the length of product descriptions in products lists
    public static string SiteName
    {
        get
        {
            return siteName;
        }
    }

}
