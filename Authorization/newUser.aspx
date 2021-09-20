<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterPage.master" AutoEventWireup="true" CodeFile="newUser.aspx.cs" Inherits="Authorization_newUser" %>

<asp:Content ID="header" ContentPlaceHolderID="head" Runat="Server">
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
    background: url('/images/XpertEquneHeaderB.jpg');
    min-height: 245px;
    background-size: cover;
    background-position: center center;
    margin-top: 100px;
    text-shadow: 2px 2px 4px #000000;
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

@media only screen and (max-width: 600px) {
    .inner_banner_section {
        margin-top: 80px;
    }
}
    </style>
</asp:Content>
<asp:Content ID="content" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div id="inner_banner" class="section inner_banner_section">
         <div class="container">
            <div class="row">
               <div class="col-md-12">
                  <div class="full">
                     <div class="title-holder">
                        <div class="title-holder-cell text-left">
                           <h1 class="page-title">New Account</h1>
                           <ol class="breadcrumb">
                              <li style="display:inline-block;"><a href="/">Home</a></li>
                              <li style="display:inline-block;" class="active">New Account</li>
                           </ol>
                        </div>
                     </div>
                  </div>
               </div>
            </div>
         </div>
      </div>


    <div class="section padding_layout_1">
         <div class="container">
            <div class="row"> 
			    <div class="col-md-12">
                  <div class="full">
                     <div class="main_heading text_align_center">
                        <h2><span>Create Account</span></h2>
                     </div>
                  </div>
               </div>
               <div class="col-xl-2 col-lg-2 col-md-12 col-sm-12 col-xs-12"></div>
               <div class="col-xl-8 col-lg-8 col-md-12 col-sm-12 col-xs-12">
                  <div class="row">
                     <div class="full">
                        <div class="col-lg-8 offset-lg-2 col-md-12 col-sm-12 col-xs-12 contant_form">
                           <div class="form_section">
                              <div class="form_contant">
                                 <fieldset>
                                    <div class="row">
                                       <div class="field col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                          <input class="field_custom" placeholder="Email adress" type="email" id="email"  required=""/>
                                       </div>
                                        <div class="field col-lg-6 col-md-6 col-sm-12 col-xs-12">
                                          <input class="field_custom" placeholder="First Name" type="text" id="first_name"  required=""/>
                                       </div>
                                        <div class="field col-lg-6 col-md-6 col-sm-12 col-xs-12">
                                          <input class="field_custom" placeholder="Last Name" type="text" id="last_name"  required=""/>
                                       </div>
                                       <div class="field col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                          <input class="field_custom" placeholder="Phone Number" type="text" id="phone"  required=""/>
                                       </div>

                                        <div class="field col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                            <label for="check" style="font-weight:600; color:#333;"> Would you like to recieve notifications?</label>
                                            <input class="check" type="checkbox" id="notifications" required=""/>
                                        </div>

                                        <div class="mb-5"></div>

                                        <span style="font-size:12px; color:red; margin-bottom:10px;">*Password must contain 1 special character and 1 numberic value. Must be longer than 7 characters.</span>
									   <div class="field col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                          <input class="field_custom" placeholder="Password" type="password" id="password"  required=""/>
                                       </div>
                                        
									   <div class="field col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                          <input class="field_custom" placeholder="Confirm Password" type="password" id="password_confirm"  required=""/>
                                       </div>
									   <div class="field col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                <a class="account create mb-3" href="/login/">I already have an account. Log In?</a>                                       
                                       </div>
                                       <div class="center"><a href="#" onclick="newUser();" class="btn btn-lg btn-custom_" style="margin-top:20px; border-radius:2px;" ID="create_account_btn">Create Account</a></div>                                  
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
      </div>


    <script type="text/javascript">

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

        newUser = () => {

            

            var user_fields = [
                document.getElementById('email'),
                document.getElementById('first_name'),
                document.getElementById('last_name'),
                document.getElementById('phone'),
            ];

            for (var values of user_fields) {
                values.style.border = 'solid #e1e1e1 1px';
                if (checkValidation(values.value)) return Error_toUser('error', 'Something went wrong! Please Try Again!', values); 
            }

            if (!confirmPassword(document.getElementById('password').value, document.getElementById('password_confirm').value))
                return Error_toUser('error', 'Please Double Check Your Password', document.getElementById('password')); 

            if (!checkValidPassword(document.getElementById('password').value))
                return Error_toUser('error', 'Password must conatin 1 numeric digit and 1 special character. Must be longer the 7 characters', document.getElementById('password')); 

            var data = {
                "email": document.getElementById('email').value,
                "firstName": document.getElementById('first_name').value,
                "lastName": document.getElementById('last_name').value,
                "phone": document.getElementById('phone').value,
                "password": document.getElementById('password').value,
                "passwordConfirm": document.getElementById('password_confirm').value,
                "Notifications": document.getElementById('notifications').checked,
            };

            console.log(data);

            user_request(data);

        }

        checkValidPassword = (password) => {
            var paswd = /^(?=.*[0-9])(?=.*[!@#$%^&*])[a-zA-Z0-9!@#$%^&*]{7,25}$/;
            return (password.match(paswd));
        }

        checkValidation = (fields) => {
            return (!fields || /^\s*$/.test(fields));
        };

        Error_toUser = (status, message, field) => {
            Toast.fire({
                type: status,
                title: message
            })

            field.style.border = '1px solid red';
        }

        confirmPassword = (pass, con) => {
            return ((pass === con) && (pass || con));
        }

        user_request = (data) => {

            $.ajax({
                method: 'POST',
                url: '/Authorization/newUser.aspx/add_newUser',
                contentType: 'application/json',
                data: JSON.stringify(data),
                headers: {
                    'Accept': 'application/json, text/plain, *',
                    'Content-type': 'application/json',
                    'dataType': 'json'
                },
                success: function (data) {
                    var data = data.d;
                    console.log(data[0]);

                    if (data[0].status == 'Success') {
                        status = data[0].status;
                        message = data[0].message;
                        setTimeout(function () { location.reload() }, 3000);
                    }


                    Toast.fire({
                        type: data[0].status,
                        title: data[0].message
                    })


                },
                error: function (error) { console.log("FAIL....================="); console.log(error); }
            });

        }

    </script>

</asp:Content>

