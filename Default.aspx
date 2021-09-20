<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPage.master"  AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>


<asp:Content ID="Header" ContentPlaceHolderID="head" runat="server">


</asp:Content>

<asp:Content ID="content" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <asp:Panel ID="header_panel" runat="server"></asp:Panel>

    <span id="hero-basic"></span>

    <asp:Panel ID="block_panel" runat="server" style="margin-top:0;"></asp:Panel>

    <asp:Panel ID="cards_panel" runat="server"  style="margin-top:0;"></asp:Panel>

    <section class="naked" style="background:url('assets/images/remrp-03.jpg') no-repeat center center;background-size:cover;">
        <div class="overlay-wrapper">
          <div class="overlay"></div>
          <div class="outer-container">
            <div class="grid-columns">
              <div class="content" data-aos="fade-up">
                <div class="grid-item">
                  <h2>Rest Assured</h2>
                  <p>The Restoration Equine Mask is perfect for use on horses who are stalled indoors where lights stay on and for travel.</p>
                </div>
                <div class="grid-item">
                  <ul class="unstyled" data-aos="fade-up">
                    <li>
                      <h4>Performance</h4>
                      <p>Facilitates the melatonin rise needed for sleep and recovery improving overall performance</p>
                    </li>
                    <li>
                      <h4>Stress Relief</h4>
                      <p>Ease your horses anxiety when traveling</p>
                    </li>
                    <li>
                      <h4>Recovery</h4>
                      <p>Aids horses with eye injuries with patched styles available</p>
                    </li>
                  </ul>
                </div>
              </div>
            </div>
          </div>
        </div>
      </section>


    <asp:Panel ID="imageCards_panel" runat="server"  style="margin-top:0;"></asp:Panel>


    <asp:Panel ID="ImageGrid_panel" runat="server"  style="margin-top:0;"></asp:Panel>


    <asp:Panel ID="Video_panel" runat="server"  style="margin-top:0;"></asp:Panel>

      <!-- Swiper Testimonials -->
    <asp:Panel ID="Testimonials_panel" runat="server"  style="margin-top:0;"></asp:Panel>
      
    <asp:Panel ID="Banner_panel" runat="server"  style="margin-top:0;"></asp:Panel>
    

    <asp:Panel ID="Copy_panel" runat="server"  style="margin-top:0;"></asp:Panel>





</asp:Content>