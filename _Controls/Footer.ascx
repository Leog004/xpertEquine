<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Footer.ascx.cs" Inherits="_Controls_Footer" %>

      <footer class="site-footer background-dark">
        <div class="content-wrapper">
          <div class="content-left" style="position:relative;">
            <img src="/assets/images/XpertEquineWH.png" class="footer-logo" /> &copy; <script type="text/javascript">
                                                                                             document.write(new Date().getFullYear());
            </script> XpertEquine. All Rights Reserved.
          </div>
          <div class="content-right">
            <div class="legal" style="margin:1em 1em 0 0"><a href="/account/default.aspx">Your Account</a> | </div>
              <div class="legal" style="margin:1em 1em 0 0"><a href="contact.aspx">Contact</a> </div>
            <%--<div class="legal"><a href="#">Privacy</a> | <a href="#">Legal</a></div>--%>
            <div class="social-icons"><a href="#"> <img src="/assets/images/icon-facebook.svg" class="social-icon" /></a>
              <a href="#"> <img src="/assets/images/icon-instagram.svg" class="social-icon" /></a>
              <a href="#"> <img src="/assets/images/icon-youtube.svg" class="social-icon" /></a></div>
              
          </div>
        </div>
      </footer>

<style>
    .back-to-top {
    position: fixed !important;
    bottom: 25px !important;
    right: 25px !important;
    display: none;
}

.btn-light {
    color: #ccc;
    background-color: #f8f9fa;
    border-color: #f8f9fa;
}

.btn {
    color:#333;
    display: inline-block;
    font-weight: 400;
    text-align: center;
    white-space: nowrap;
    vertical-align: middle;
    -webkit-user-select: none;
    -moz-user-select: none;
    -ms-user-select: none;
    user-select: none;
    border: 1px solid transparent;
    padding: .375rem .75rem;
    font-size: 1rem;
    line-height: 1.5;
    border-radius: .25rem;
    transition: color .15s ease-in-out,background-color .15s ease-in-out,border-color .15s ease-in-out,box-shadow .15s ease-in-out;
}

</style>

<a id="back-to-top" href="/shop/cart.aspx" class="btn btn-light btn-lg back-to-top" role="button" style="color:#333; display:none;">View Cart <i class="fas fa-shopping-cart" style="color:#333;"></i></a>

<script>

    function getCookie(name) {

        var dc = document.cookie;
        var prefix = name + "=";
        var begin = dc.indexOf("; " + prefix);
        if (begin == -1) {
            begin = dc.indexOf(prefix);
            if (begin != 0) return null;
        }
        else {
            begin += 2;
            var end = document.cookie.indexOf(";", begin);
            if (end == -1) {
                end = dc.length;
            }
        }
        // because unescape has been deprecated, replaced with decodeURI
        //return unescape(dc.substring(begin + prefix.length, end));
        return decodeURI(dc.substring(begin + prefix.length, end));
    }

</script>