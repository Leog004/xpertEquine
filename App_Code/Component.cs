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
* File: Component.cs
* DATABASE: GRA-WEB5: XpertEquine
* TABLES: Page_Pages, Page_Contents
* Store Procedures: None
*
* Description: Implements a class that is used
*              for fetching and recieving data to be passed down to Component
*
***********************************************/
public class Component
{

    // ---------------Variables-------------------

    private string Page { get; set; } // gets the content page
    private string Location { get; set; } // gets the content location

    private string[] RequestedDataOuter { get; set; } // request fields list

    private string[] RequestedDataInnner { get; set; } // request fields list

    public List<Dictionary<string, object>> OuterData { get; set; } // data fetched 
    public List<Dictionary<string, object>> InnerData { get; set; } // data fetched 
    public bool Result { get; set; } // result of our request || TODO: Error Handling


    private ComponentDataRequest request = new ComponentDataRequest(); // creates and object of class to have access to functions






    // ---------------Constructors-------------------



    /** Component - public
     * Description: If left to its defaults, the default constructor will initialize our page and location to empty. 
     * It will initialize our Page and Location string variables if user inserts them, 
     * and if they have their requested data, the user can also choose to insert that data
     * Parameter 0: A string that will contain the content page from Table: Pages_pages | store procedure: get_Page_Content_ByPage_Location
     * Parameter 1: A string that will contain the content location from Table: Pages_pages | store procedure: get_Page_Content_ByPage_Location
     * Parameter 2: A string array that will contain user requested fields: Pages_pages | store procedure: get_Page_Content_ByPage_Location
     * Parameter 3: A string that will contain user requested fields from Table: Pages_Contents | store procedure: get_Page_Content_Images
     * Return: nothing
    */

    public Component()
    {
        Result = false;
        SetPage("");
        SetLocation("");
        SetRequestedDataInner(new string[0]);
        SetRequestedDataOuter(new string[0]);
    }


    public Component(string Apage, string Alocation)
    {
        Result = false;
        SetPage(Apage);
        SetLocation(Alocation);
        SetRequestedDataInner(new string[0]);
        SetRequestedDataOuter(new string[0]);
    }


    public Component(string Apage, string Alocation, string[] ArequestedDataOuter = null, string[] ArequestedDataInner = null)
    {
        Result = false;

        SetPage(Apage);
        SetLocation(Alocation);

        ArequestedDataOuter = ArequestedDataOuter ?? new string[0]; // if array is null, it will initialize a size of 0 else it will take in the array
        ArequestedDataInner = ArequestedDataInner ?? new string[0]; // if array is null, it will initialize a size of 0 else it will take in the array

        SetRequestedDataOuter(ArequestedDataOuter);
        SetRequestedDataInner(ArequestedDataInner);

        sendData();
    }







    // ---------------Setters-------------------

    /** SetPage - public
     * Description: Sets the content page
     * Parameter 0: A string that will contain the content page from Table: Pages_pages | store procedure: get_Page_Content_ByPage_Location
     * Return: nothing
    */
    public void SetPage(string Apage)
    {
        Page = Apage;
    }

   
    /** SetLocation - public
     * Description: Sets the content location
     * Parameter 0: A string that will contain the content location from Table: Pages_pages | store procedure: get_Page_Content_ByPage_Location
     * Return: nothing
    */
    public void SetLocation(string Alocation)
    {
        Location = Alocation;
    }

   
    /** SetResult - private
     * Description: Sets the results status from our fetch data
     * Parameter 0: a boolean that return a true or false of our data length is greater than 0
     * Return: nothing
    */
    private void SetResult(bool Aresult)
    {
        Result = Aresult;
    }

   
    /** SetOuterData - private
     * Description: Sets the given List Dictionary with the user requested data from table page_page
     * Parameter 0: A List Dictionary that will contain our Outer Data | Content that is on Page_Page table
     * Return: nothing
    */
    private void SetOuterData(List<Dictionary<string, object>> Adata)
    {
        OuterData = Adata;
    }

    
    /** SetInnerData - private
     * Description: Sets the given List Dictionary with the user requested inner data from table page_content
     * Parameter 0: A List Dictionary that will contain our Inner Data | Content that is on Page_Page table
     * Return: nothing
    */
    private void SetInnerData(List<Dictionary<string, object>> Adata)
    {
        InnerData = Adata;
    }

   
    /** SetRequestedDataOuter - private
     * Description: Sets the given List Dictionary
     * Parameter 0: A List Dictionary that will contain our Outer Data | Content that is on Page_Page table
     * Return: nothing
    */
    public void SetRequestedDataOuter(string[] ArequestedDataOuter)
    {
        RequestedDataOuter = ArequestedDataOuter;        
    }

    
    /** SetRequestedDataInner - private
     * Description: Sets the given List Dictionary
     * Parameter 0: A List Dictionary that will contain our Outer Data | Content that is on Page_Page table
     * Return: nothing
    */
    public void SetRequestedDataInner(string[] ArequestedDataInner)
    {
        RequestedDataInnner = ArequestedDataInner;
    }







    // ---------------Getters-------------------

    /** GetLocation - private
     * Description: gets the page location
     * Parameter: none
     * Return: string location
    */
    private string GetLocation()
    {
        return Location;
    }


    /** GetPage - private
     * Description: gets the page content location
     * Parameter: none
     * Return: string page
    */
    private string GetPage()
    {
        return Page;
    }


    /** GetRequestedDataOuter - private
     * Description: gets the user requested outer data
     * Parameter: none
     * Return: string array
    */
    private string[] GetRequestedDataOuter()
    {
        return RequestedDataOuter;
    }


    /** GetRequestedDataInnner - private
     * Description: gets the user requested inner data
     * Parameter: none
     * Return: string array
    */
    private string[] GetRequestedDataInnner()
    {
        return RequestedDataInnner;
    }


    /** GetResult - public
     * Description: gets the status of our data
     * Parameter: none
     * Return: boolean
    */
    public bool GetResult()
    {
        return Result;
    }


    /** GetOuterData - public
     * Description: gets our fetch data from our outer request
     * Parameter: none
     * Return: List<Dictionary>
    */
    public List<Dictionary<string, object>> GetOuterData()
    {
        return OuterData;
    }


    /** GetInnerData - public
     * Description: gets our fetch data from our inner request
     * Parameter: none
     * Return: List<Dictionary>
    */
    public List<Dictionary<string, object>> GetInnerData()
    {
        return InnerData;
    }





    // ---------------Helper-------------------

    /** sendData - public
     * Description: this function is repsonsible for sending and recieving data from ComponentDataRequest object
     * It will then set our Outer and InnerData from our fetch data that we recieved.
     * Parameter none
     * Return: nothing
    */
    public void sendData()
    {
        try
        {
            if (GetRequestedDataOuter().Length > 0 && GetRequestedDataInnner().Length > 0)
            {
                request.genericRequest(GetPage(), GetLocation(), GetRequestedDataOuter());
                SetOuterData(request.GetOuterData());


                request.InnerRequest(GetOuterData()[0]["ID"].ToString(), GetRequestedDataInnner());
                SetInnerData(request.GetInnerData());

                if (GetOuterData().Count > 0 && GetInnerData().Count > 0) SetResult(true);

            }
            else if(GetRequestedDataOuter().Length > 0 && GetRequestedDataInnner().Length <= 0)
            {
                request.genericRequest(GetPage(), GetLocation(), GetRequestedDataOuter());
                SetOuterData(request.GetOuterData());

                if (GetOuterData().Count > 0) SetResult(true);
            }
            else
            {
                throw new Exception("No Data is implemented to send");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }





}