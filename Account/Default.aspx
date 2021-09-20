<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Account_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">


        <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta1/dist/css/bootstrap.min.css" rel="stylesheet">
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet">


    <link href="/assets/css/landingPage.css" rel="stylesheet" type="text/css">   
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.1/css/all.min.css" />



  <style>

.site-header {
    position: absolute;
    width: 100%;
    background: #282828;
}

    .section {
       
        margin-bottom:50px;
        float: left;
        width: 100%;
    }

.breadcrumb > li + li::before {
    position: relative;
    content: '\203A';
    margin: 0 10px;
    font-size: 18px;
    color: inherit;
    opacity: .7;
    display: inline-block;
}

        .breadcrumb {
            background: transparent;
            padding: 0;
            margin: 0;
            color: #fff;
        }

        .inner_banner_section {
    background: url('https://images.unsplash.com/photo-1584237863847-b21b4f7ccd4f?ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=1161&q=80');
    min-height: 245px;
    background-size: cover;
    background-position: center center;
    margin-top: 100px;
}

        .full {
    width: 100%;
    float: left;
    margin: 0;
    padding: 0;
}

        .title-holder {
    margin: 80px 0 0;
}


.filter-widget .fw-brand-check .bc-item label .checkmark {
    position: absolute;
    left: 0;
    top: -11px;
    height: 15px;
    width: 15px;
    border: 2px solid #ebebeb;
    border-radius: 2px;
}

.product-item .pi-text .product-price {
    color: #76BC42;
    font-size: 20px;
    margin: 0;
    font-weight: 700;
}

.page-title{
    color:#fff;
}

.product-item {
    margin-bottom: 40px;
}
.product-item .pi-text .catagory-name {
    font-size: 10px;
    color: #b2b2b2;
    font-weight: 700;
    letter-spacing: 2px;
    text-transform: uppercase;
    margin-bottom: 0;
}

.product-item .pi-text {
    text-align: center;
    padding-top: 5px;
}

.info_ span {
    margin-right:10px;
}

.info{
    padding:0; margin:0;
}

.pro_sel{
    display:inline-block !important;
}

        .cart .quantity {
            display: inline-block;
            float: left;
           
        }

        .qtybtn{
            padding: 5px;
            border-radius: 4px;
            border: 1px solid;
            cursor: pointer;
        }

        .qtybtn:hover{
            background:#eee;
        }

        .info_ label{
            margin-right:20px;
        }

        .pro_sel{
            display:inline-block;
            margin-top:20px;
            padding: 2px;
            width:100%;
        }

        .product-detail-side {
             border-bottom: none; 
            text-align: left;
             padding: 0; 
            margin: 0;
        }

        .share-post {
    float: left;
    width: 100%;
    padding: 15px 25px;
    background: #fffdfd;
    box-shadow: 1px 13px 50px -12px rgba(0, 0, 0, 0.2);
    color:#333;
}
        .xpertequine-wrapper a {
    color: #333;
    text-decoration: none;
    transition: color 150ms ease;
}
        .fixed-header .site-nav-wrapper .nav-container .site-nav ul.nav-list li a {
    height: 100%;
    color: #fff;
    display: flex;
    align-items: center;
    justify-content: center;
    font-weight: 700;
    text-transform: uppercase;
}

    .select{
        border: solid #e1e1e1 1px;
        width: 100%;
        background: #f8f8f8;
        min-height: 50px;
        padding: 5px 20px;
        line-height: normal;
        border-radius: 0px;
        margin-bottom: 10px;
        font-size: 14px;
        color: #737373;
    }

    @media only screen and (max-width: 600px) {
    .inner_banner_section {
        margin-top: 80px;
    }
}
    </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

         <!-- inner page banner -->
      <div id="inner_banner" class="section inner_banner_section">
         <div class="container">
            <div class="row">
               <div class="col-md-12">
                  <div class="full">
                     <div class="title-holder">
                        <div class="title-holder-cell text-left">
                           <h1 class="page-title">Your Account</h1>
                           <ol class="breadcrumb">
                              <li style="display:inline-block;"><a href="/">Home</a></li>
                              <li style="display:inline-block;" class="active">Account</li>
                           </ol>
                        </div>
                     </div>
                  </div>
               </div>
            </div>
         </div>
      </div>
      <!-- end inner page banner -->


 <div class="section padding_layout_1">
     <div class="container">
         <div class="row justify-content-center">
			            <div class="col-md-12">
                          <div class="full">
                             <div class="main_heading text_align_center">
                                <h2><span>Account Information</span></h2>
                             </div>
                          </div>
                       </div>
              <button class="btn btn-primary" style="background:#333; border-color:#333; " type="button" data-toggle="collapse" data-target="#collapseInfo" aria-expanded="false" aria-controls="collapseExample">
                Shipping/Billing Address
              </button>
              <button class="btn btn-primary" type="button" data-toggle="collapse" data-target="#collapseOrders" aria-expanded="false" aria-controls="collapseExample">
                View Orders
              </button>
            </div>
     </div>
    <div class="collapse" id="collapseInfo" style="margin: 100px 0;">
        <div class="container">
                    <div class="row"> 
                       <div class="col-xl-6 col-lg-6 col-md-12 col-sm-12 col-xs-12">
                          <div class="row">
                             <div class="full">
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 contant_form">

                                   <div class="form_section">
                                      <h5 class="text-center"><span>Billing Information</span></h5>
                                         <fieldset>
                                            <div class="row">
                                               <div class="field col-lg-6 col-md-6 col-sm-12 col-xs-12">
                                                   <label style="font-size:12px; font-weight:600" for="bill_first">First Name</label>
                                                  <input class="field_custom" id="bill_first" placeholder="First Name" type="text" value="<%=Bill_FirstName %>" required="">
                                               </div>
									           <div class="field col-lg-6 col-md-6 col-sm-12 col-xs-12">
                                                   <label style="font-size:12px; font-weight:600" for="bill_last">Last Name</label>
                                                 <input class="field_custom" id="bill_last" placeholder="Last Name" type="text" value="<%=Bill_LastName %>" required="">
                                               </div>
                                               <div class="field col-lg-5 col-md-6 col-sm-12 col-xs-12">
                                                   <label style="font-size:12px; font-weight:600" for="bill_city">City</label>
                                                  <input class="field_custom" id="bill_city" placeholder="City" value="<%=Bill_City %>" type="text" required="">
                                               </div>
                                               <div class="field col-lg-3 col-md-6 col-sm-12 col-xs-12">
                                                   <label style="font-size:12px; font-weight:600" for="bill_zip">Zip</label>
                                                  <input class="field_custom" id="bill_zip" placeholder="Zip" type="text" value="<%=Bill_Zip %>" required="">
                                               </div>
                                               <div class="field col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                                   <label style="font-size:12px; font-weight:600" for="bill_phone">Phone</label>
                                                  <input class="field_custom" id="bill_phone" placeholder="Phone number" value="<%=Bill_Phone %>" type="text" required="">
                                               </div>
                                               <div class="field col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                   <label style="font-size:12px; font-weight:600" for="bill_address">Address</label>
                                                  <input class="field_custom" id="bill_address" placeholder="Address" type="text" value="<%=Bill_Address %>" required="">
                                               </div>
                                                <div class="field col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                    <label style="font-size:12px; font-weight:600" for="bill_state">Select State</label>
                                                    <select class="field_custom select" id="bill_state" name="cn">
                                                        <option selected="selected" value="<%=Bill_State %>"><%=Bill_State %></option>
	                                                    <option value="AL">Alabama</option>
	                                                    <option value="AK">Alaska</option>
	                                                    <option value="AZ">Arizona</option>
	                                                    <option value="AR">Arkansas</option>
	                                                    <option value="CA">California</option>
	                                                    <option value="CO">Colorado</option>
	                                                    <option value="CT">Connecticut</option>
	                                                    <option value="DE">Delaware</option>
	                                                    <option value="DC">District Of Columbia</option>
	                                                    <option value="FL">Florida</option>
	                                                    <option value="GA">Georgia</option>
	                                                    <option value="HI">Hawaii</option>
	                                                    <option value="ID">Idaho</option>
	                                                    <option value="IL">Illinois</option>
	                                                    <option value="IN">Indiana</option>
	                                                    <option value="IA">Iowa</option>
	                                                    <option value="KS">Kansas</option>
	                                                    <option value="KY">Kentucky</option>
	                                                    <option value="LA">Louisiana</option>
	                                                    <option value="ME">Maine</option>
	                                                    <option value="MD">Maryland</option>
	                                                    <option value="MA">Massachusetts</option>
	                                                    <option value="MI">Michigan</option>
	                                                    <option value="MN">Minnesota</option>
	                                                    <option value="MS">Mississippi</option>
	                                                    <option value="MO">Missouri</option>
	                                                    <option value="MT">Montana</option>
	                                                    <option value="NE">Nebraska</option>
	                                                    <option value="NV">Nevada</option>
	                                                    <option value="NH">New Hampshire</option>
	                                                    <option value="NJ">New Jersey</option>
	                                                    <option value="NM">New Mexico</option>
	                                                    <option value="NY">New York</option>
	                                                    <option value="NC">North Carolina</option>
	                                                    <option value="ND">North Dakota</option>
	                                                    <option value="OH">Ohio</option>
	                                                    <option value="OK">Oklahoma</option>
	                                                    <option value="OR">Oregon</option>
	                                                    <option value="PA">Pennsylvania</option>
	                                                    <option value="RI">Rhode Island</option>
	                                                    <option value="SC">South Carolina</option>
	                                                    <option value="SD">South Dakota</option>
	                                                    <option value="TN">Tennessee</option>
	                                                    <option value="TX">Texas</option>
	                                                    <option value="UT">Utah</option>
	                                                    <option value="VT">Vermont</option>
	                                                    <option value="VA">Virginia</option>
	                                                    <option value="WA">Washington</option>
	                                                    <option value="WV">West Virginia</option>
	                                                    <option value="WI">Wisconsin</option>
	                                                    <option value="WY">Wyoming</option>
                                                    </select>	
                                                </div>
                                               <div class="center"><input type="button" value="Save" class="btn btn-lg btn-custom_" style="margin-top: 20px;" onclick="updateAddress('bill')"></div>
                                            </div>
                                         </fieldset>
			                              
                                   </div>
                                </div>
                             </div>
                          </div>
                       </div>
                       <div class="col-xl-6 col-lg-6 col-md-12 col-sm-12 col-xs-12">
                          <div class="row">
                             <div class="full">
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 contant_form">
                                   <div class="form_section">
                                      <h5 class="text-center"><span>Shipping Information</span></h5>
                                         <fieldset>
                                            <div class="row">
                                               <div class="field col-lg-6 col-md-6 col-sm-12 col-xs-12">
                                                   <label style="font-size:12px; font-weight:600" for="ship_first">First Name</label>
                                                  <input class="field_custom" id="ship_first" placeholder="First Name" type="text" value="<%=Ship_FirstName %>" required="">
                                               </div>
									           <div class="field col-lg-6 col-md-6 col-sm-12 col-xs-12">
                                                   <label style="font-size:12px; font-weight:600" for="ship_last">Last Name</label>
                                                 <input class="field_custom" id="ship_last" placeholder="Last Name" value="<%=Ship_LastName %>" type="text" required="">
                                               </div>
                                               <div class="field col-lg-5 col-md-6 col-sm-12 col-xs-12">
                                                   <label style="font-size:12px; font-weight:600" for="ship_city">City</label>
                                                  <input class="field_custom" id="ship_city" placeholder="City" type="text" value="<%=Ship_City %>" required="">
                                               </div>
                                               <div class="field col-lg-3 col-md-6 col-sm-12 col-xs-12">
                                                   <label style="font-size:12px; font-weight:600" for="ship_zip">Zip</label>
                                                  <input class="field_custom" id="ship_zip" placeholder="Zip" type="text" value="<%=Ship_Zip %>" required="">
                                               </div>
                                               <div class="field col-lg-4 col-md-6 col-sm-12 col-xs-12">
                                                   <label style="font-size:12px; font-weight:600" for="ship_phone">Phone</label>
                                                  <input class="field_custom" id="ship_phone" placeholder="Phone number" value="<%=Ship_Phone %>" type="text" required="">
                                               </div>
                                               <div class="field col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                   <label style="font-size:12px; font-weight:600" for="ship_address">Address</label>
                                                  <input class="field_custom" id="ship_address" placeholder="Address" value="<%=Ship_Address %>" type="text" required="">
                                               </div>
                                                <div class="field col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                    <label style="font-size:12px; font-weight:600" for="ship_state">Select State</label>
                                                    <select class="field_custom select" name="cn" id="ship_state">
                                                        <option selected="selected" value="<%=Ship_State %>"><%=Ship_State %></option>
	                                                    <option value="AL">Alabama</option>
	                                                    <option value="AK">Alaska</option>
	                                                    <option value="AZ">Arizona</option>
	                                                    <option value="AR">Arkansas</option>
	                                                    <option value="CA">California</option>
	                                                    <option value="CO">Colorado</option>
	                                                    <option value="CT">Connecticut</option>
	                                                    <option value="DE">Delaware</option>
	                                                    <option value="DC">District Of Columbia</option>
	                                                    <option value="FL">Florida</option>
	                                                    <option value="GA">Georgia</option>
	                                                    <option value="HI">Hawaii</option>
	                                                    <option value="ID">Idaho</option>
	                                                    <option value="IL">Illinois</option>
	                                                    <option value="IN">Indiana</option>
	                                                    <option value="IA">Iowa</option>
	                                                    <option value="KS">Kansas</option>
	                                                    <option value="KY">Kentucky</option>
	                                                    <option value="LA">Louisiana</option>
	                                                    <option value="ME">Maine</option>
	                                                    <option value="MD">Maryland</option>
	                                                    <option value="MA">Massachusetts</option>
	                                                    <option value="MI">Michigan</option>
	                                                    <option value="MN">Minnesota</option>
	                                                    <option value="MS">Mississippi</option>
	                                                    <option value="MO">Missouri</option>
	                                                    <option value="MT">Montana</option>
	                                                    <option value="NE">Nebraska</option>
	                                                    <option value="NV">Nevada</option>
	                                                    <option value="NH">New Hampshire</option>
	                                                    <option value="NJ">New Jersey</option>
	                                                    <option value="NM">New Mexico</option>
	                                                    <option value="NY">New York</option>
	                                                    <option value="NC">North Carolina</option>
	                                                    <option value="ND">North Dakota</option>
	                                                    <option value="OH">Ohio</option>
	                                                    <option value="OK">Oklahoma</option>
	                                                    <option value="OR">Oregon</option>
	                                                    <option value="PA">Pennsylvania</option>
	                                                    <option value="RI">Rhode Island</option>
	                                                    <option value="SC">South Carolina</option>
	                                                    <option value="SD">South Dakota</option>
	                                                    <option value="TN">Tennessee</option>
	                                                    <option value="TX">Texas</option>
	                                                    <option value="UT">Utah</option>
	                                                    <option value="VT">Vermont</option>
	                                                    <option value="VA">Virginia</option>
	                                                    <option value="WA">Washington</option>
	                                                    <option value="WV">West Virginia</option>
	                                                    <option value="WI">Wisconsin</option>
	                                                    <option value="WY">Wyoming</option>
                                                    </select>	
                                                </div>
                                               <div class="center"><input type="button" value="Save" class="btn btn-lg btn-custom_" style="margin-top:20px;" onclick="updateAddress('ship')"></div>
                                            </div>
                                         </fieldset>
			                              
                                   </div>
                                </div>
                             </div>
                          </div>
                       </div>
                    </div>
                 </div>
    </div>

    <div class="collapse" id="collapseOrders" style="margin: 100px 0;">
        <div class="container">
                    <div class="row"> 
<div class="product-table">
                     <table class="table">
                        <thead>
                           <tr>
                              <th style="width:30%; vertical-align: inherit;">Order Number</th>
                              
                              <th style="vertical-align: inherit;">Date</th>
                              <th style="vertical-align: inherit;" class="text-center">Status</th>
                              <th style="vertical-align: inherit;" class="text-center">Total</th>
                              <th style="vertical-align: inherit;">View</th>
                           </tr>
                        </thead>
                        <tbody>
                            <asp:Panel ID="orders_panel" runat="server"></asp:Panel>
                         <%--  <tr>
                              <td class="col-sm-8 col-md-6">
                                 <div class="media" style="display:inline-block;">
                                    <div class="media-body" style="display:inline-block;">
                                       <h5 class="media-heading text-center">abc1231<a href="#"></a></h5>
                                    </div>
                                 </div>
                              </td>
                               
                              <td class="col-sm-1 col-md-1" style="text-align: left">
                                  <h5 class="media-heading">12/30/2020<a href="#"></a></h5>
                              </td>
                              <td class="col-sm-1 col-md-1 text-center">
                                 <h5 class="media-heading text-center">In Proccess<a href="#"></a></h5>
                              </td>
                              <td class="col-sm-1 col-md-1 text-center">
                                 <h5 class="media-heading text-center">$100<a href="#"></a></h5>
                              </td>
                              <td class="col-sm-1 col-md-1"><button type="button" class="bt_main" style="margin:0;"><i class="fa fa-view"></i> View More</button></td>
                           </tr>--%>
                           
                        </tbody>
                     </table>
                  </div>
                    </div>
                 </div>
    </div>

</div>

    <style>
        .purchase
{
    position: relative;
    background-color: #FFF;
    min-height: 450px;
    padding: 15px;
}
.purchase header
{
    padding: 0px 0px 0px 0px;
    margin-bottom: 0px;
    border-bottom: 1px solid #3989c6;
}
.purchase header img
{
    max-width: 200px;
    margin-top: 0;
    margin-bottom: 0;
}
.purchase .company-details
{
    text-align: right;
    margin-top: 0;
    margin-bottom: 0;
}
.purchase main
{
    padding: 0px 0px;
    margin-bottom: 0px;
}
.purchase .to-details
{
    margin: 10px 0;
    text-align: left;
}
.purchase .to-name
{
    font-weight: bold;
}
.purchase .to-name .to-address .to-city
{
    margin-top: 0;
    margin-bottom: 0;
}
.purchase .purchase-info
{
    margin: 10px 0;
    text-align: right;
}
.purchase-info .info-code
{
    font-weight: bold;
}
.purchase-info .info-code .info-date
{
    margin-top: 0;
    margin-bottom: 0;
}
.table thead th
{
    margin: 0 !important;
    padding-top: 0 !important;
    padding-bottom: 0 !important;
    border:none;
}
.table td
{
    margin: 0 !important;
    padding-top: 0 !important;
    padding-bottom: 0 !important;
    border: none;
}
.table .blank-row
{
    height: 25px !important;
    background-color: #FFFFFF;
    border: none;
}
.table tbody
{
    min-height: 1000px !important;
}

.to-details div{
    padding:10px;
}

.purchase-info div{
    padding:10px;
}

.swal2-shown{
    z-index:9999999999999 !important;
}
    </style>

<div class="modal fade" id="invoiceModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
  <div class="modal-dialog modal-dialog-centered modal-lg" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
      <div class="invoice-box">
        <table>
            <tr class="top">
                <td colspan="2">
                    <table>
                        <tr>
                            <td class="title">
                                <img src="/images/newImages/JElogoblbk.jpg" style="width:100%; max-width:300px;">
                            </td>
                            
                            <td>
                                <strong>OrderID</strong><span id="invoice_orderID">: 123</span><br>
                                <strong>Date Ordered</strong><span id="invoice_date">: January 1, 2015</span><br>
                                <strong>Status</strong><span id="invoice_status">: January 1, 2015</span><br>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            
            <tr class="information">
                <td colspan="2">
                    <table>
                        <tr>
                            <td>
                                <strong style="text-decoration:underline;">Address</strong><br />                       
                                <span id="invoice_address">12345 Sunny Road</span><br>
                                <span id="invoice_state_city_zip">Sunnyville, CA 12345</span>
                            </td>
                            
                            <td>
                                <strong style="text-decoration:underline;">Customer</strong><br>
                                <span id="invoice_customerName">John Doe</span><br>
                                <span id="invoice_email">john@example.com</span>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            
            
            <tr class="heading" id="invoice_item_rows">
                <td>
                    Item
                </td>
                  <td>
                    Quantity
                </td>              
                <td>
                    Price
                </td>
            </tr>
            <tr class="total">
                <td id="invoice_subtotal"></td>
                
                <td id="invoice_total">
                   Total: $385.00
                </td>
            </tr>
        </table>
    </div>      
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
      </div>
    </div>
  </div>
</div>


    <script>

        function updateAddress(Type) {

            var firstName = document.querySelector(`#${Type}_first`).value;
            var lastName = document.querySelector(`#${Type}_last`).value;
            var city = document.querySelector(`#${Type}_city`).value;
            var zip = document.querySelector(`#${Type}_zip`).value;
            var phone = document.querySelector(`#${Type}_phone`).value;
            var address = document.querySelector(`#${Type}_address`).value;
            var state = document.querySelector(`#${Type}_state`).value;

            console.log(firstName, lastName, city, zip, phone, address, state);

            var status = "error", message = `${Type} update has failed! Please try again.`;
            var data_ = { "firstName": firstName, "lastName": lastName, "State": state, "City": city, "Zip": zip, "Phone": phone, "Address": address, "Type": Type };

            console.log(data_);

            $.ajax({
                method: 'POST',
                url: '/Account/default.aspx/updateAddress',
                contentType: 'application/json',
                data: JSON.stringify(data_),
                headers: {
                    'Accept': 'application/json, text/plain, *',
                    'Content-type': 'application/json',
                    'dataType': 'json'
                },
                success: function (data) {
                    var data = data.d;


                    if (data) {
                        status = "success";
                        message = `${Type} address has been updated successfuly!`;
                        setTimeout(function () { location.reload() }, 3000);
                    }

                    const Toast = Swal.mixin({
                        toast: true,
                        position: 'top-end',
                        showConfirmButton: false,
                        timer: 5000,
                        timerProgressBar: true,
                        onOpen: (toast) => {
                            toast.addEventListener('mouseenter', Swal.stopTimer)
                            toast.addEventListener('mouseleave', Swal.resumeTimer)
                        }
                    })



                    Toast.fire({
                        type: status,
                        title: message
                    })


                },
                error: function (error) { console.log("FAIL....================="); console.log(error); }
            });




        }    


        function getOrderDetails(orderID, orderStatus) {

           

            var No_ = document.getElementById("invoice_orderID");
            var date = document.getElementById("invoice_date");
            var customerName = document.getElementById("invoice_customerName");
            var email = document.getElementById("invoice_email");
            var address = document.getElementById("invoice_address");
            var state = document.getElementById("invoice_state_city_zip");
            var total = document.getElementById("invoice_total");
            var subTotal = document.getElementById("invoice_subtotal");
            var status = document.getElementById("invoice_status");

            const position = "afterend";
            var rows = document.getElementById("invoice_item_rows");
            var data_ = { "OrderID": orderID };
            var myhtml = '';

            $.ajax({
                method: 'POST',
                url: '/account/default.aspx/getOrderDetails',
                contentType: 'application/json',
                data: JSON.stringify(data_),
                headers: {
                    'Accept': 'application/json, text/plain, *',
                    'Content-type': 'application/json',
                    'dataType': 'json'
                },
                success: function (data) {
                    var data = data.d;
                    console.log(data);
                    status.innerHTML = `: ${orderStatus}`
                    No_.innerHTML = `: ${data[0].No_}`
                    date.innerHTML = `: ${data[0].Date}`;
                    customerName.innerHTML = `${data[0].CustomerName}`
                    email.innerHTML = `${data[0].Email}`
                    address.innerHTML = `${data[0].Address}`
                    state.innerHTML = `<b>City</b>: ${data[0].City} <span style='margin:0 10px;'> <b>State</b>: ${data[0].State}</span> <span style='margin:0 10px;'> <b>Zip</b>: ${data[0].Zip}</span>`
                    total.innerHTML = `SubTotal: $${data[0].SubTotal} <br>
                                       Shipping: $${data[0].Shipping} <br>
                                       Tax: $${data[0].Tax} <br>
                                       Total: $${data[0].Total}`;

                    data.forEach(function (newData, key) {
                        if (newData.IsRow && key != 0) {

                            myhtml += ` <tr class='item insertedRow'>
                                            <td>  ${newData.Name} </td>
                                            <td>  ${newData.QTY} </td>
                                            <td>  ${newData.Price}</td>
                                      </tr>`;
                        }
                    });


                    rows.insertAdjacentHTML(position, myhtml)
                    var myHtml = '';
                    myHtml +=`<div>
    <div class="purchase overflow-auto">
        <!--<div style="min-width: 600px">-->
            <header>
                <div class="row">
            	    <div class="col-sm-3 col-xs-3">
                	   <h1>Expert Equine</h1>
                	</div>
                	<div class="col-sm-9 col-xs-9 company-details">
                	    <div><b style='font-weight:600'>Order ID</b> :${data[0].No_} </div>
                	    <div><b style='font-weight:600'>Date Ordered</b>: ${data[0].Date} </div>
                	    <div><b style='font-weight:600'>Status</b>: ${orderStatus} </div>
                	</div>
            	</div>
            </header>
            <main>
                <div class="row" style='border-bottom: 1px solid #000;'>
                    <div class="col-sm-8 col-xs-12 to-details">
                        <div> <h1 style='text-decoration:underline;'>ADDRESS</h1> </div>
                        <div>${data[0].Address}</div>
                        <div class="to-address"><b style='font-weight:600'>City</b>: ${data[0].City} | <b style='font-weight:600'>State</b>: ${data[0].State} | <b style='font-weight:600'>Zip</b>: ${data[0].Zip}</div>
                    </div>
                    <div class="col-sm-4 col-xs-12 purchase-info">
                        <div> <h1 style='text-decoration:underline;'>CUSTOMER</h1> </div>
                        
                        <div class="info-date">Email: ${data[0].Email}</div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-12 col-xs-12 table-responsive" style='margin:10px 0;'>
                        <table class="table table-condensed" border="0" cellspacing="0" cellpadding="0" width="100%">
                        <thead style='background:#eee;'>
                            <tr>
                                <th class="text-left" style='width:70%; font-weight:600'>Item</th>
                                <th class="text-left" style='width:25%; font-weight:600'>Qty</th>
                                <th class="text-right" style='width:5%; font-weight:600'>Amount</th>
                            </tr>
                        </thead>
                        <tbody style='background:#eee;'>`;

                    data.forEach(function (newData, key) {
                        if (newData.IsRow && key != 0) {

                            myHtml += `<tr>
                                            <td class="text-left">${newData.Name}</td>
                                            <td class="text-left">${newData.QTY}</td>
                                            <td class="text-right">${newData.Price}</td>
                                        </tr>`;
                        }
                    });


                    myHtml += `</tbody>
                                <tfoot>
                                    <tr>
                                        <th colspan="1" class='text-left'>
                                            <label style='font-weight:600'>Description</label>
                                            <br/>
                                            Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas
                                        </th>
                                        <th colspan="2" class="text-right">
                                            <p style='line-height: 0.25px; margin: 12px 0;'><label style='font-weight:600'>SubTotal</label>: ${data[0].SubTotal}</p>
                                            <p style='line-height: 0.25px; margin: 12px 0;'><label style='font-weight:600'>Shipping</label>: ${data[0].Shipping}</p>
                                            <p style='line-height: 0.25px; margin: 12px 0;'><label style='font-weight:600'>Tax</label>: ${data[0].Tax}</p>
                                            <p style='line-height: 0.25px; margin: 12px 0;'><label style='font-weight:600'>Total</label>: ${data[0].Total}</p>
                                        </th>
                                    </tr>
                                </tfoot>
                            </table>
                            </div>
                        </div>
                    </main>
                        <!--</div>-->
                    </div>
                </div>`;







                    Swal.fire(
                        'Good job!',
                        'You clicked the button!',
                        'success'
                    )

                    Swal.fire({
                        title: 'Your Order',
                        html: myHtml,
                        width: 1000,
                        padding: '3em',
                        backdrop: `rgba(0,0,0,0.4)`
                    });

                    $('#invoiceModal').css("dispay", "block");


                },
                error: function (error) { console.log("FAIL....================="); console.log(error); }
            });

            $('.insertedRow').html('');

        }

    </script>



</asp:Content>