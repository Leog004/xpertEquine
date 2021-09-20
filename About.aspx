<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPage.master" AutoEventWireup="true" CodeFile="About.aspx.cs" Inherits="About" %>

<asp:Content ID="Header" ContentPlaceHolderID="head"  runat="server">

        <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta1/dist/css/bootstrap.min.css" rel="stylesheet">
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet">

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
    background: url('/images/XpertEquneHeaderC.jpg');
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

.card{
    border:none;
}
.equal-height-cards {
    display: flex;
    justify-content: center;
     flex-wrap: unset; 
    margin: -.75em;
    padding: 0;
    padding-top: 3em;
}

.equal-height-cards .card .content-wrapper .card-icon {
    width: 100%;
    height: auto;
    margin: 0 auto;
}
.equal-height-cards .card .content-wrapper {
    display: flex;
    flex-direction: column;
    justify-content: flex-start;
    width: 100%;
    height: 550px;
     background: unset; 
    color: #333;
    box-shadow: 0px 13px 50px -12px rgba(0, 0, 0, 0.1);
}

.xpertequine-wrapper h4 {
    line-height: 1.69rem;
    margin: 20px 0;
}

.equal-height-cards .card .content-wrapper .img-wrapper {
    padding: 3em 0 0;
    text-align: center;
    width: 100%;
    margin-top: 0;
    padding-top: 0;
}

.tout-side-image .item.content-wrapper:after {
    content: '';
    position: absolute;
    top: 0;
    right: -100px;
    width: 100%;
    max-width: 640px;
    height: 100%;
    background: #fff;
    transform: none;
    z-index: 99;
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
                           <h1 class="page-title">About</h1>
                           <ol class="breadcrumb">
                              <li style="display:inline-block;"><a href="/">Home</a></li>
                              <li  style="display:inline-block;" class="active">About</li>
                           </ol>
                        </div>
                     </div>
                  </div>
               </div>
            </div>
         </div>
      </div>


             <div class="tout-side-image-wrapper">
        <div class="tout-side-image">
          <div class="item content-wrapper">
            <div class="content" data-aos="fade-up">
              <h2>Have you ever tried to sleep&nbsp;with the lights on?</h2>
              <p class="subheading">The truth is, our horses are no different</p>
              <p>Whether your horse is at a show, a vet clinic or a public stable, the lights are on. They need the absence of light to produce melatonin, allowing for optimal rest and recovery. The REM mask uses blue light blocking technology to promote the natural production of melatonin for a more restful night of sleep while being exposed to artificial light. </p>
            </div>
          </div>
          <div class="item image" style="background: url('assets/images/remLabel-01.jpg')no-repeat right center; -webkit-background-size: cover; -moz-background-size: cover; -o-background-size: cover; background-size: cover;">
          </div>
        </div>
      </div>


    <section class="tout-side-image-wrapperk">
        <div class="outer-container">
          <header class="text-center">
            <h2>Restorative Equine Mask Benefits</h2>
          </header>
          <div class="equal-height-cards column-three">
            <div class="card">
              <div class="card-border">
                <div class="content-wrapper">
                  <div class="img-wrapper">
                    <img src="/assets/images/image-mask-left.jpg" alt="" class="card-icon aos-init aos-animate" data-aos="fade-up">
                  </div>
                  <div class="content-block">
                    <div class="content">
                      <h4>Ultraviolet Light</h4>
                      <p>Amber lenses block 100% of UV light</p>
                    </div>
                  </div>
                </div>
              </div>
            </div>
            <div class="card">
              <div class="card-border">
                <div class="content-wrapper">
                  <div class="img-wrapper">
                    <img src="/assets/images/image-mask-left.jpg" alt="" class="card-icon aos-init aos-animate" data-aos="fade-up" data-aos-delay="100">
                  </div>
                  <div class="content-block">
                    <div class="content">
                      <h4>Melatonin</h4>
                      <p>67% of masked horses showed a substantial increase in melatonin overnight vs non-masked horses in the same setting</p>
                    </div>
                  </div>
                </div>
              </div>
            </div>
            <div class="card">
              <div class="card-border">
                <div class="content-wrapper">
                  <div class="img-wrapper">
                    <img src="/assets/images/image-mask-left.jpg" alt="" class="card-icon aos-init aos-animate" data-aos="fade-up" data-aos-delay="200">
                  </div>
                  <div class="content-block">
                    <div class="content">
                      <h4>Blue Light</h4>
                      <p>Amber lenses block 100% of blue light</p>
                    </div>
                  </div>
                </div>
              </div>
            </div>
            <div class="card">
              <div class="card-border">
                <div class="content-wrapper">
                  <div class="img-wrapper">
                    <img src="/assets/images/image-mask-right.jpg" alt="" class="card-icon aos-init aos-animate" data-aos="fade-up" data-aos-delay="100">
                  </div>
                  <div class="content-block">
                    <div class="content">
                      <h4>Melatonin</h4>
                      <p>67% of masked horses showed a substantial increase in melatonin overnight vs non-masked horses in the same setting</p>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </section>

    


        <div class="tout-side-image-wrapper">
        <div class="tout-side-image">
          <div class="item image" style="background: url('assets/images/remLabel-01.jpg')no-repeat right center; -webkit-background-size: cover; -moz-background-size: cover; -o-background-size: cover; background-size: cover; width:47%;">
          </div>
          <div class="item content-wrapper">
            <div class="content" data-aos="fade-up">
              <h2>Have you ever tried to sleep&nbsp;with the lights on?</h2>
              <p class="subheading">The truth is, our horses are no different</p>
              <p>Whether your horse is at a show, a vet clinic or a public stable, the lights are on. They need the absence of light to produce melatonin, allowing for optimal rest and recovery. The REM mask uses blue light blocking technology to promote the natural production of melatonin for a more restful night of sleep while being exposed to artificial light. </p>
            </div>
          </div>
        </div>
      </div>

    <section class="naked">
        <div class="header" style="background:url('assets/images/rem-logo-closeup.jpg') no-repeat center center;background-size:cover;">
          <div class="overlay"></div>
          <div class="content-wrapper left">
            <div class="content aos-init aos-animate" data-aos="fade-up">
              <div class="grid-item">
                <h2>Help Your Horse<br>Get the Rest it Needs</h2>
                <a href="" class="button">Shop Now</a>
              </div>
            </div>
          </div>
        </div>
      </section>

</asp:Content>