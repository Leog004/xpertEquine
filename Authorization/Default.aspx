<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Authorization_Default" %>

<asp:Content ID="Header" ContentPlaceHolderID="head"  runat="server">
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


<asp:Content ID="Content" ContentPlaceHolderID="ContentPlaceHolder1"  runat="server">



    
    <div id="inner_banner" class="section inner_banner_section">
         <div class="container">
            <div class="row">
               <div class="col-md-12">
                  <div class="full">
                     <div class="title-holder">
                        <div class="title-holder-cell text-left">
                           <h1 class="page-title">Login</h1>
                           <ol class="breadcrumb">
                              <li style="display:inline-block;"><a href="/">Home</a></li>
                              <li style="display:inline-block;" class="active">Login</li>
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
                        <h2><span>Login</span></h2>
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
                                          <input id="email" class="field_custom" placeholder="Email adress" type="email" required="">
                                       </div>
									   <div class="field col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                          <input id="password" class="field_custom" placeholder="Password" type="password" required="">
                                       </div>
									   <div class="field col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                <a class="account create" href="/login/new">Create an account</a>
                                                <a class="account forgot" href="#">Forgot Password?</a>                                       
                                       </div>
                                       <div class="center"><input onclick="login()" type="button" value="Login" class="btn btn-lg btn-custom_" style="margin-top:20px;"</div>
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



    <script>
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
        });

        login = () => {


            var user_fields = [
                document.getElementById('email'),
                document.getElementById('password')
            ];

            for (var values of user_fields) {
                values.style.border = 'solid #e1e1e1 1px';
                if (checkValidation(values.value)) return Error_toUser('error', 'Something went wrong! Please Try Again!', values);
            }

            var data = {
                "email": document.getElementById('email').value,
                "password": document.getElementById('password').value
            };

            login_request(data);

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


        login_request = (data) => {

            $.ajax({
                method: 'POST',
                url: '/Authorization/default.aspx/login',
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
                        setTimeout(function () { window.location.href = "/account/default.aspx" }, 3000);
                    }


                    Toast.fire({
                        type: data[0].status,
                        title: data[0].message
                    })

                    setTimeout(function () { window.location.href = "/account/default.aspx" }, 3000);

                },
                error: function (error) { console.log("FAIL....================="); console.log(error); }
            });

        }


    </script>


</asp:Content>