using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Address
/// </summary>
public class Address
{
    public string name { get; set; }
    public string stAddress { get; set; }
    public string stAddress2 { get; set; }
    public string city { get; set; }
    public string zipCode { get; set; }
    public string state { get; set; }
    public string phone { get; set; }




    public Address(string name, string stAddress, string stAddress2, string city, string zipCode, string state, string phone)
    {
        this.name = name;
        this.stAddress = stAddress;
        this.stAddress2 = stAddress2;
        this.city = city;
        this.zipCode = zipCode;
        //State: Two character abbreviation
        this.state = state;
        this.phone = phone;
    }
}