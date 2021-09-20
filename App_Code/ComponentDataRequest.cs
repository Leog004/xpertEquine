using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

/***********************************************
* Equibrand Corporations | XPERT EQUINE
*
* 5/18 2021
*
* Authors: Leo Garza, Justin Johnson,  
*          Andrew Stockson, Dylan Turner 
* 
*
* File: ComponentDataRequest.cs
* DATABASE: GRA-WEB5: XpertEquine
* TABLES: Page_Pages, Page_Contents
* Store Procedures: get_Page_Content_ByPage_Location | get_Page_Content_Images
*
* Description: Implements a class that is used
*              for fetching and recieving data to be passed down to Component
*
***********************************************/

public class ComponentDataRequest
{

    private List<Dictionary<string, object>> _Outerdata; // data that will be returned from get_Page_Content_ByPage_Location
    private List<Dictionary<string, object>> _Innnerdata; // data that will be returned from get_Page_Content_Images


    // ---------------------SETTERS------------------

    /** SetOuterData - private
     * Description: Sets the given List Dictionary
     * Parameter 0: A List Dictionary that will contain our Outer Data | Content that is on Page_Page table
     * Return: nothing
    */
    private void SetOuterData(List<Dictionary<string, object>> Adata)
    {
        _Outerdata = Adata;
    }

    /** SetInnerData - private
     * Description: Sets the given List Dictionary
     * Parameter 0: A List Dictionary that will contain our Inner Data | Content that is on Page_Contents table
     * Return: nothing
    */
    private void SetInnerData(List<Dictionary<string, object>> Adata)
    {
        _Innnerdata = Adata;
    }


    // ---------------------GETTERS------------------


    /** GetOuterData - public
     * Description: gets our outer data that is retrieved from store procedure get_Page_Content_ByPage_Location
     * Parameter: none
     * Return: List<Dictionary<string, object>>
    */
    public List<Dictionary<string, object>> GetOuterData()
    {
        return _Outerdata;
    }


    /** GetInnerData - public
     * Description: gets our Inner data that is retrieved from store procedure get_Page_Content_Images
     * Parameter: none
     * Return: List<Dictionary<string, object>>
    */
    public List<Dictionary<string, object>> GetInnerData()
    {
        return _Innnerdata;
    }


    // ---------------------Default Constructors------------------

    /** Default Constructor - public
        * Description: Constructs a componentDataRequest with given settings. 
        * If left to defaults, it will initialize _OuterData and _Innerdata to empty
        * Return: nothing
    */
    public ComponentDataRequest()
    {
        //
        // TODO: Initialize _InnerData and _Outerdata to be emptied
        //
    }



    // ---------------------Helper Functions------------------

    /** genericRequest - public
     * Description: constructs a method that recieves the page, location and requested data from class Component.
     * With this information, it will then run store procedure get_Page_Content_ByPage_Location and store the data fetch into _OuterData List.
     * Which it will then be called in Class component initializing data to be passed back to Page. 
     * Example: Page -> Component -> ComponentDataRequested -> Component -> Page
     * Parameter 0: a string containing the page
     * Parameter 1: a string containing the location
     * Parameter 2: a string array containing the requested fields
     * Return: nothing
    */
    public void genericRequest(string Apage, string Alocation, string[] AdataRequested)
    {

        try
        {
            DataTable g = Access.get_Page_Content_ByPage_Location(Apage, Alocation); // Using our store procedure to fetch data

            if (g.Rows.Count <= 0 || AdataRequested.Length <= 0) Console.WriteLine("Error");  // checking if we have any data or not we return null

            List<Dictionary<string, object>> List = new List<Dictionary<string, object>>(); // Creating A list of our fetch data: Key: "Title", value: "Data"       
            Dictionary<string, object> FetchData = new Dictionary<string, object>(); // creating a temp variable that will contain data for our specif fields that we are looking for

            // Our data has more than one row, then we will traverse through all the rows
            for (int x = 0; x < g.Rows.Count; x++)
            {
                foreach (var items in AdataRequested)
                {
                    try
                    {
                        FetchData.Add(items, g.Rows[x][items].ToString());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }

                List.Add(FetchData);
               
            }

            SetOuterData(List);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }

    }


    /** InnerRequest - public
     * Description: constructs a method that recieves the content ID, and requested data from class Component.
     * With this information, it will then run store procedure get_Page_Content_Images and store the data fetch into _InnerData List.
     * Which it will then be called in Class component initializing data to be passed back to Page. 
     * Example: Page -> Component -> ComponentDataRequested -> Component -> Page
     * Parameter 0: a string containing the content ID
     * Parameter 1: a string array containing the requested fields
     * Return: nothing
    */
    public void InnerRequest(string id, string[] adataRequeusted)
    {
       
        try {

            DataTable g = Access.get_Page_Content_Images(id); // Using our store procedure to fetch data

            List<Dictionary<string, object>> List = new List<Dictionary<string, object>>(); // Creating A list of our fetch data: Key: "Title", value: "Data"           
            Dictionary<string, object> FetchData = new Dictionary<string, object>(); // creating a temp variable that will contain data for our specif fields that we are looking for


            if (g.Rows.Count <= 0 && adataRequeusted.Length <= 0) throw new Exception("There is no data"); // checking if we have any data or not we return null


            // Our data has more than one row, then we will traverse through all the rows
            for (int x = 0; x < g.Rows.Count; x++)
            {
                foreach (var items in adataRequeusted)
                {
                    try
                    {
                        FetchData.Add(items, g.Rows[x][items].ToString());
                       
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }

                List.Add(new Dictionary<string, object>(FetchData));
                FetchData.Clear();
            }

            
            SetInnerData(List); // initializes _InnerData

        }catch(Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }

    }

}