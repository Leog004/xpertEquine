<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Nav.ascx.cs" Inherits="_Controls_Nav" %>

<div class="fixed-header">
        <header id="masthead" class="site-header">
          <div class="site-nav-wrapper" id="main-nav">
            <div class="header-logo"><a href="/"><img src="/assets/images/XpertEquineWH.png"></a>
            </div>
            <div class="nav-container">
              <div class="site-nav">
                <div class="nav">
                  <ul class="nav-list" id="navList">
                    <li><a href="/Details/REM/REM-M" class="nav__link" >Shop</a></li>
<%--                    <li><a href="/about.aspx" class="nav__link">About</a></li>
                    <li><a href="/contact/" class="nav__link link-work">Contact</a></li>--%>
                    <li runat="server" id="login_head"><a href="/login/" class="nav__link link-work">Login</a></li>
                    <li runat="server" id="logout_head" visible="false"><asp:LinkButton ID="logout" OnClick="logout_Click"  class="nav__link link-work" runat="server">Log Out</asp:LinkButton></li>
                    <li><a  href="/shop/cart.aspx" class="nav__link link-work"><i  id="cart_span" runat="server" class="mycart fas fa-shopping-cart"></i></a></li>
                  </ul>
                </div>
              </div>
            </div>
            <div class="utility-wrapper">
              <div class="utility-trigger">
                <a class="js-utility-trigger" href="#0"><span class="cd-menu-icon"></span></a>
              </div>
            </div>
          </div>
        </header>
        <div class="nav-mobile-wrapper">
          <div class="nav-mobile-content">
            <div class="mobile-nav">
              <div class="nav">
                <ul class="nav-list" id="navList">
                    <li><a href="/Details/REM/REM-M" class="nav__link" >Shop</a></li>
<%--                    <li><a href="/about.aspx" class="nav__link">About</a></li>
                    <li><a href="/contact/" class="nav__link link-work">Contact</a></li>--%>
                    <li runat="server" id="login_mobile"><a href="/login/" class="nav__link link-work">Login</a></li>
                    <li runat="server" id="logOut_mobile" visible="false"><asp:LinkButton ID="LogOutMobile" OnClick="logout_Click"  class="nav__link link-work" runat="server">Log Out</asp:LinkButton></li>
                    <li ><a href="/shop/cart.aspx" class="nav__link link-work"><i  id="cart_span_mobile" runat="server" class="mycart fas fa-shopping-cart"></i></a></li>
                </ul>
              </div>
            </div>
            <div class="mobile-nav-footer">
              <div class="content">
                <div class="nav-social"><a href="#"> <img src="/assets/images/icon-facebook.svg" class="social-icon" /></a>
                  <a href="#"> <img src="/assets/images/icon-instagram.svg" class="social-icon" /></a>
                  <a href="#"> <img src="/assets/images/icon-youtube.svg" class="social-icon" /></a>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>


<script>
    function signOut(){

        setTimeout(function(){ 

            const Toast = Swal.mixin({
                toast: true,
                position: 'bottom-end',
                showConfirmButton: false,
                timer: 5000,
                timerProgressBar: true,
                onOpen: (toast) => {
                    toast.addEventListener('mouseenter', Swal.stopTimer)
                    toast.addEventListener('mouseleave', Swal.resumeTimer)
                }
            })



            Toast.fire({
                type: 'warning',
                title: 'Signed Out Successfully'
            })

        }, 1000);
    }
</script>