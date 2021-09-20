
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for GlobalClass
/// </summary>
public class GlobalClass
{
    public static SqlDataAdapter adap;
    public static DataTable dt;
    // Stored image path before updating the record
    public static string imgEditPath;
	public GlobalClass()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}