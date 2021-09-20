<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPage.master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" %>



<asp:Content ID="Header" ContentPlaceHolderID="head"  runat="server">

        <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta1/dist/css/bootstrap.min.css" rel="stylesheet">
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet">
    <link href="/assets/css/landingPage.css" rel="stylesheet" type="text/css">   
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.1/css/all.min.css" />
   


  
    <style>
        @media (min-width: 1200px){
            .fixed-header .site-nav-wrapper {
                width: 100%;
                max-width: 1440px;
                margin: 0 auto;
                padding: 0 1.5em;
                background: #282828;
            }

            .inner_banner_section {
                background: url('/images/XpertEquneHeaderD.jpg');
                min-height: 245px;
                background-size: cover;
                background-position: center center;
                margin-top: 100px;
                text-shadow: 2px 2px 4px #000000;
            }
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
                           <h1 class="page-title">Contact Us</h1>
                           <ol class="breadcrumb">
                              <li style="display:inline-block;"><a href="/">Home</a></li>
                              <li style="display:inline-block;" class="active">Contact</li>
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
                        <h2><span>GET IN TOUCH</span></h2>
                     </div>
                  </div>
               </div>
               <div class="col-xl-2 col-lg-2 col-md-12 col-sm-12 col-xs-12"></div>
               <div class="col-xl-8 col-lg-8 col-md-12 col-sm-12 col-xs-12">
                  <div class="row">
                     <div class="full">
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 contant_form">
                           <div class="form_section">
                              <form class="form_contant" action="contact.php">
                                 <fieldset>
                                    <div class="row">
                                       <div class="field col-lg-6 col-md-6 col-sm-12 col-xs-12">
                                          <input id="contact-form-name" class="field_custom" placeholder="Your Name" type="text" required="">
                                       </div>
									   <div class="field col-lg-6 col-md-6 col-sm-12 col-xs-12">
                                          <input  id="contact-form-email" class="field_custom" placeholder="Email adress" type="email" required="">
                                       </div>
                                       <div class="field col-lg-6 col-md-6 col-sm-12 col-xs-12">
                                          <input  id="contact-form-subject" class="field_custom" placeholder="Subject" type="text" required="">
                                       </div>
                                       <div class="field col-lg-6 col-md-6 col-sm-12 col-xs-12">
                                          <input  id="contact-form-phone" class="field_custom" placeholder="Phone number" type="text" required="">
                                       </div>
                                       <div class="field col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                          <textarea  id="contact-form-message" class="field_custom" placeholder="Messager"></textarea>
                                       </div>
                                       <div class="center"><input type="button" onclick="sendEmail()" value="SUBMIT NOW" class="btn btn-lg btn-custom_" style="margin-top: 20px;" href="#"></div>
                                    </div>
                                 </fieldset>
                              </form>
                           </div>
                        </div>
                     </div>
                  </div>
               </div>
            </div>
         </div>
      </div>


        <script>
        var success, isValidated, emailSent;

        async function sendEmail() {
            var name = document.getElementById('contact-form-name').value;
            var email = document.getElementById('contact-form-email').value;
            var phone = document.getElementById('contact-form-phone').value;
            var subject = document.getElementById('contact-form-subject').value;
            var message = document.getElementById('contact-form-message').value;


            success = await checkIfFilled_contact(name, email, message);
            isValidated = await checkEmailValidation(email);
            emailSent = await sendEmailToUser(name, email, phone, subject, message);

            if (!success)
                return displayMessage('error', 'Please Fill Required Information');

            if (!isValidated)
                return displayMessage('error', 'Please Re-Enter Your Email');

            if (!emailSent)
                return displayMessage('error', 'Something went wrong, please try again!');


            return displayMessage_contact('success', 'We have recieved your email. Thank You!');
        }


        function displayMessage_contact(type, message) {

            const Toast = Swal.mixin({
                toast: true,
                position: 'top-end',
                showConfirmButton: false,
                timer: 8000,
                timerProgressBar: true,
                onOpen: (toast) => {
                    toast.addEventListener('mouseenter', Swal.stopTimer)
                    toast.addEventListener('mouseleave', Swal.resumeTimer)
                }
            })

            Toast.fire({
                type: type,
                title: message
            })

            if (type === 'success') {
                document.getElementById('contact-form-name').value = '';
                document.getElementById('contact-form-email').value = '';
                document.getElementById('contact-form-phone').value = '';
                document.getElementById('contact-form-subject').value = '';
                document.getElementById('contact-form-message').value = '';
            }

        }


        function checkIfFilled_contact(name, email, message) {

            var name_style = document.getElementById('contact-form-name');
            var email_style = document.getElementById('contact-form-email');
            var message_style = document.getElementById('contact-form-message');

            name_style.style.border = '1px solid #d2d2d2';
            email_style.style.border = '1px solid #d2d2d2';
            message_style.style.border = '1px solid #d2d2d2';

            if (!name || !email || !message) {

                if (!name) name_style.style.border = '1px solid red';            

                if (!email) email_style.style.border = '1px solid red';  

                if (!message) message_style.style.border = '1px solid red';  

                return false;
            }

            return true;
        }


        function checkEmailValidation(email) {

            const re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
            if (!re.test(email)) {
                document.getElementById('contact-form-email').style.border = '1px solid red';
                return false;
            }

            return true;
        }

        async function sendEmailToUser(name, email, phone, subject, message) {

            var data_ = { "name": name, "email": email, "phone": phone, "subject": subject, "message": message };

            try {
                if (success && isValidated) {
                    var myBoolean = await $.ajax({
                        method: 'POST',
                        url: '/contact.aspx/sendEmail',
                        contentType: 'application/json',
                        data: JSON.stringify(data_),
                        headers: {
                            'Accept': 'application/json, text/plain, *',
                            'Content-type': 'application/json',
                            'dataType': 'json'
                        },
                        success: function (data) {
                            console.log(data.d);

                        },
                        error: function (error) { console.log(error); }
                    });
                }
            } catch (err) {
                return false;
            }

            return myBoolean;
        }


        </script>


</asp:Content>
