using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/***********************************************
* Equibrand Corporations | XPERT EQUINE
*
* 5/18 2021
*
* Authors: Justin Johnson, Leo Garza, 
*          Andrew Stockson, Dylan Turner 
* 
*
* File: HtmlComponents.cs
* DATABASE: GRA-WEB5: XpertEquine
* TABLES: None
* Store Procedures: None
* 
*
* Description: Implements functions that returns a html snippet. Keeping it abstracted from the intended page
*
***********************************************/
public class HtmlComponents
{

    public HtmlComponents()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public string returnHeader(List<Dictionary<string, object>> data)
    {

        if (data.Count <= 0) return "";

        return String.Format(
            "<section class='background-dark naked'>"
              + "<div class='hero-basic' style='background:url({0}) no-repeat center center;background-size:cover;'>"
              + "<div class='overlay-mobile'></div>"
              + "<div class='content-wrapper left'>"
              + "<div class='content'>"
              + "<div data-aos='fade-up'>"
              + "<img src='{1}' class='hero-logo' />"
              + "<h1>{2}</h1>"
              + "<div class='patent'>"
              + "<p>{3}</p>"
              + "</div>"
              + " <div class='button-group'>"
              + "<a href='{4}' class='button transparent-white'>{5}</a>"
              + "</div>"
              + "</div>"
              + "</div>"
              + "</div>"
              + "<div class='hero-footer'>"
              + "<div class='arrow-container'>"
              + "<a href='#hero-basic'>"
              + "<div class='chevron-down-basic'></div>"
              + "</a>"
              + "</div>"
              + "</div>"
              + "</div>"
              + "</section>", data[0]["ImageURL"], data[0]["LogoImageURL"], data[0]["Title"], data[0]["SpanText"], data[0]["ButtonURL"], data[0]["ButtonText"]);
    }



    public string returnBlock(List<Dictionary<string, object>> data)
    {

        if (data.Count <= 0) return "";

        return String.Format(
            "<div class='tout-side-image-wrapper'>"
               + "<div class='tout-side-image'>"
               + "<div class='item content-wrapper'>"
               + "<div class='content' data-aos='fade-up'>"
               + "<h2>{0}</h2>"
               + "<p class='subheading'>{1}</p>"
               + "<p> {2}</p>"
               + "</div>"
               + "</div>"
               + "<div class='item image' style='background: url({3}) no-repeat right center; -webkit-background-size: cover; -moz-background-size: cover; -o-background-size: cover; background-size: cover;'>"
               + "</div>"
               + "</div>"
             + "</div>", data[0]["Title"], data[0]["SubTitle"], data[0]["Paragraph"], data[0]["ImageURL"]);
    }



    public string returnCards(List<Dictionary<string, object>> outer, List<Dictionary<string, object>> inner)
    {
        string html = String.Format(
           "<section class='background-dark'>"
           + "<div class='outer-container'>"
           + "<header class='text-center'>"
           + "<h2>{0}</h2>"
            + "</header>"
            + "<div class='equal-height-cards column-three'>", outer[0]["Title"]);

        for (int x = 0; x < inner.Count; x++)
        {

            html += String.Format(
                "<div class='card'>"
            + "<div class='card-border'>"
            + "<div class='content-wrapper'>"
            + "<div class='img-wrapper'>"
            + "<img src='{0}' alt='' class='card-icon' data-aos='fade-up' />"
            + "</div>"
            + "<div class='content-block'>"
            + "<div class='content'>"
            + "<h4>{1}</h4>"
            + "<p>{2}</p>"
            + "</div>"
            + "</div>"
            + "</div>"
            + "</div>"
            + "</div>", inner[x]["ImageURL"], inner[x]["Title"], inner[x]["Paragraph"]);
        }

        html += String.Format(
              "</div>"
       + "</div>"
       + "</section>");

        return html;
    }



    public string returnImageCards(List<Dictionary<string, object>> outer, List<Dictionary<string, object>> inner)
    {
         string html = String.Format(
                    "<section class='background-light'>"
                   + "<div class='outer-container'>"
                   +   "<header class='text-center'>"
                   +     "<h2>Mask Styles</h2>"
                   +     "<p>The Restoration Equine Mask comes in three styles:</p>"
                   +   "</header>"
                 + "<div class='style-columns'>", outer[0]["Title"], outer[0]["TitleText"]);

                    for(int x = 0; x < inner.Count; x++)
                        html += String.Format("<div class='item'><img src='{0}' data-aos='fade-up'></div>", inner[x]["ImageURL"]);


                 html += "</div>"
                + "</div>"
               +"</section>";


        return html;
    
    }



    public string returnImageGrid(List<Dictionary<string, object>> inner)
    {
        string html = "<div class='image-columns'>";

        for (int x = 0; x < inner.Count; x++)
        {
            html += String.Format("<div class='item'><img src='{0}'></div>", inner[x]["ImageURL"]);
        }

        html += "</div>";

        return html;
    }


    public string returnTestimonials(List<Dictionary<string, object>> outer, List<Dictionary<string, object>> inner)
    {
        string html =
            String.Format(
           "<section class=' background-dark'>"
            +"<div class='swiper-testimonial-wrapper'>"
            +  "<div class='swiper-container swiper-testimonials' data-aos='fade-up'>"
            +    "<header class='text-center'>"
            +      "<h2>{0}</h2>"
            +    "</header>" 
            +"<div class='swiper-wrapper'>", outer[0]["Title"]);


            for(int x = 0; x < inner.Count; x++) { 
                    html += 
                    String.Format(
                        "<div class='swiper-slide'>"
                      +  "<div class='content-wrapper'>"
                      +    "<div class='swiper-content'>"
                      +      "<p>{0}</p>"
                      +      "<div class='name'>{1}</div>"
                      +    "</div>"
                      +  "</div>"
                      +"</div>", inner[x]["Paragraph"], inner[x]["Title"]);
            }

            html +=    
            "</div>" +
                "<div class='swiper-nav-testimonials'>"
                 + "<div class='swiper-button-prev prev-testimonials'></div>"
                 + "<div class='swiper-button-next next-testimonials'></div>"
               + "</div>"
              +  "<div class='swiper-pagination'></div>"
            +  "</div>"
          + "</div>"
         + "</section>";

        return html;
    }


    public string returnBanner(List<Dictionary<string, object>> outer)
    {

        return String.Format(

            "<section class='naked'>"
                +"<div class='header' style='background:url({0}) no-repeat center center;background-size:cover;'>"
                 + "<div class='overlay'></div>"
                 + "<div class='content-wrapper left'>"
                 +   "<div class='content' data-aos='fade-up'>"
                 +     "<div class='grid-item'>"
                 +       "<h2>{1}</h2>"
                 +      "<a href='{3}' class='button'>{2}</a>"
                 +     "</div>"
                 +   "</div>"
                +  "</div>"
              +  "</div>"
             + "</section>",outer[0]["ImageURL"], outer[0]["Title"], outer[0]["ButtonText"], outer[0]["ButtonURL"]);

    }



    public string returnCopy(List<Dictionary<string, object>> outer)
    {
        return String.Format(
            "<section class=' background-dark' style='padding-bottom: 0;'>"
              +"<div class='container' style='width:50%; margin: 0 auto; justify-content:center;'>"
              +  "<i>{0}</i>"
              +  "</div>"
            +"</section>",outer[0]["Paragraph"]);
       
    }


    public string returnVideo(List<Dictionary<string, object>> outer, List<Dictionary<string, object>> inner) 
    {

        string html = String.Format(
            "<section class='background-light'>"
               + "<div class='outer-container'>"
               +   "<header class='text-center'>"
               +     "<h2>{0}</h2>"
               +       "<p>{1} </p>"
               +   "</header>"
               + "<div class='content' data-aos='fade-up' style='text-align: center;'>", outer[0]["Title"], outer[0]["TitleText"]);


                 for(int x = 0; x < inner.Count; x++)
                     html += String.Format("<iframe width = '600' height='315' src='{0}' title='{1}' frameborder='0' allow='accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture' allowfullscreen></iframe>", inner[x]["VideoURL"], inner[x]["Title"]);
               


              html +=  "</div>" 
                   + "</div>"
             + "</section>";


        return html;
    }

}