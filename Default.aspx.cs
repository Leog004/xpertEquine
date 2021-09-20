using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    HtmlComponents html = new HtmlComponents();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        RunProgram();
    }

    protected void RunProgram()
    {
        GetHeader();
        GetBlock();
        GetCards();
        GetImageCards();
        GetImageGrid();
        GetTestemonials();
        GetBanner();
        GetCopy();
        GetVideo();
    }


    /* GetHeader - protected
     * Description: Send our requested data to the class Component to display header html information. 
     *      The component will then initialize our request and return our results, 
     *      as well as our data that corresponds to the data we requested.
     *      Following that, our data will be sent to our html component to be rendered.
     *      
     *      Touchables: rData, and html. 
     *      
     * Parameters: none 
     * Return: nothing
     */
    protected void GetHeader()
    {
        Label LabelHtml = new Label();
        string[] rData = { "Title", "SpanText", "ButtonText", "ButtonURL", "ImageURL", "LogoImageURL" }; // The fields we are looking for in our dataBase

        Component component = new Component("Expert Home", "Header", rData); // Initializing our component | Page, location, requested data
        if (!component.GetResult()) Console.WriteLine("An error has occured"); // checking whether we returned data, if not. Something must have gone wrong


        LabelHtml.Text = html.returnHeader(component.GetOuterData()); // sending our returned data to our html component so it can be rendered. 
        header_panel.Controls.Add(LabelHtml); // display html
    }


    /* GetBlock - protected
     * Description: Send our requested data to the class Component to display block html information. 
     *      The component will then initialize our request and return our results, 
     *      as well as our data that corresponds to the data we requested.
     *      Following that, our data will be sent to our html component to be rendered.
     * Parameters: none 
     * Return: nothing
     */
    protected void GetBlock()
    {
        Label LabelHtml = new Label();
        string[] rData = { "Title", "SubTitle", "Paragraph", "ImageURL" }; // The fields we are looking for in our dataBase

        Component component = new Component("Expert Home", "Block", rData); // Initializing our component | Page, location, requested data
        if (!component.GetResult()) Console.WriteLine("An error has occured"); // checking whether we returned data, if not. Something must have gone wrong


        LabelHtml.Text = html.returnBlock(component.GetOuterData()); // sending our returned data to our html component so it can be rendered. 
        block_panel.Controls.Add(LabelHtml); // display html
    }


    /* GetCards - protected
     * Description: Send our requested data to the class Component to display cards html information. 
     *      The component will then initialize our request and return our results, 
     *      as well as our data that corresponds to the data we requested.
     *      Following that, our data will be sent to our html component to be rendered.
     * Parameters: none 
     * Return: nothing
     */
    protected void GetCards()
    {
        Label LabelHtml = new Label();
        string[] rDataOuter = { "ID","Title" }; // The fields we are looking for in our dataBase
        string[] rDataInner = { "Title", "Paragraph", "ImageURL"}; // The fields we are looking for in our dataBase

        Component component = new Component("Expert Home", "Cards", rDataOuter, rDataInner); // Initializing our component | Page, location, Inner and Outer requested data
        if (!component.GetResult()) Console.WriteLine("An error has occured"); // checking whether we returned data, if not. Something must have gone wrong

        LabelHtml.Text = html.returnCards(component.GetOuterData(), component.GetInnerData()); // sending our returned data to our html component so it can be rendered. 
        cards_panel.Controls.Add(LabelHtml); // display html
    }


    /* GetImageCards - protected
     * Description: Send our requested data to the class Component to display Imagecards html information. 
     *      The component will then initialize our request and return our results, 
     *      as well as our data that corresponds to the data we requested.
     *      Following that, our data will be sent to our html component to be rendered.
     * Parameters: none 
     * Return: nothing
     */
    protected void GetImageCards()
    {
        Label LabelHtml = new Label();
        string[] rDataOuter = { "ID", "Title", "TitleText" }; // The fields we are looking for in our dataBase
        string[] rDataInner = { "ImageURL" }; // The fields we are looking for in our dataBase


        Component component = new Component("Expert Home", "ImageCards", rDataOuter, rDataInner);
        if (!component.GetResult()) Console.WriteLine("An error has occured"); // checking whether we returned data, if not. Something must have gone wrong


        LabelHtml.Text = html.returnImageCards(component.GetOuterData(), component.GetInnerData()); // sending our returned data to our html component so it can be rendered.
        imageCards_panel.Controls.Add(LabelHtml); // display html

    }


    /* ImageGrid - protected
     * Description: Send our requested data to the class Component to display ImageGrid html information. 
     *      The component will then initialize our request and return our results, 
     *      as well as our data that corresponds to the data we requested.
     *      Following that, our data will be sent to our html component to be rendered.
     * Parameters: none 
     * Return: nothing
     */
    protected void GetImageGrid()
    {
        Label LabelHtml = new Label();
        string[] rDataOuter = { "ID"}; // The fields we are looking for in our dataBase
        string[] rDataInner = { "ImageURL" }; // The fields we are looking for in our dataBase


        Component component = new Component("Expert Home", "ImageGrid", rDataOuter, rDataInner);
        if (!component.GetResult()) Console.WriteLine("An error has occured"); // checking whether we returned data, if not. Something must have gone wrong


        LabelHtml.Text = html.returnImageGrid(component.GetInnerData()); // sending our returned data to our html component so it can be rendered.
        ImageGrid_panel.Controls.Add(LabelHtml); // display html

    }


    /* Testemonials - protected
     * Description: Send our requested data to the class Component to display Testemonials html information. 
     *      The component will then initialize our request and return our results, 
     *      as well as our data that corresponds to the data we requested.
     *      Following that, our data will be sent to our html component to be rendered.
     * Parameters: none 
     * Return: nothing
     */
    protected void GetTestemonials()
    {
        Label LabelHtml = new Label();
        string[] rDataOuter = { "ID", "Title" }; // The fields we are looking for in our dataBase
        string[] rDataInner = { "Title", "Paragraph" }; // The fields we are looking for in our dataBase


        Component component = new Component("Expert Home", "Testimonials", rDataOuter, rDataInner);
        if (!component.GetResult()) Console.WriteLine("An error has occured"); // checking whether we returned data, if not. Something must have gone wrong


        LabelHtml.Text = html.returnTestimonials(component.GetOuterData(), component.GetInnerData()); // sending our returned data to our html component so it can be rendered.
        Testimonials_panel.Controls.Add(LabelHtml); // display html

    }


    /* GetBanner - protected
     * Description: Send our requested data to the class Component to display Banner html information. 
     *      The component will then initialize our request and return our results, 
     *      as well as our data that corresponds to the data we requested.
     *      Following that, our data will be sent to our html component to be rendered.
     * Parameters: none 
     * Return: nothing
     */
    protected void GetBanner()
    {
        Label LabelHtml = new Label();
        string[] rDataOuter = { "ID", "Title", "ImageURL", "ButtonText", "ButtonURL" }; // The fields we are looking for in our dataBase

        Component component = new Component("Expert Home", "Banner", rDataOuter);
        if (!component.GetResult()) Console.WriteLine("An error has occured"); // checking whether we returned data, if not. Something must have gone wrong


        LabelHtml.Text = html.returnBanner(component.GetOuterData()); // sending our returned data to our html component so it can be rendered.
        Banner_panel.Controls.Add(LabelHtml); // display html

    }


    /* GetCopy - protected
     * Description: Send our requested data to the class Component to display copy html information. 
     *      The component will then initialize our request and return our results, 
     *      as well as our data that corresponds to the data we requested.
     *      Following that, our data will be sent to our html component to be rendered.
     * Parameters: none 
     * Return: nothing
     */
    protected void GetCopy()
    {
        Label LabelHtml = new Label();
        string[] rDataOuter = { "Paragraph" }; // The fields we are looking for in our dataBase

        Component component = new Component("Expert Home", "Copy", rDataOuter);
        if (!component.GetResult()) Console.WriteLine("An error has occured"); // checking whether we returned data, if not. Something must have gone wrong


        LabelHtml.Text = html.returnCopy(component.GetOuterData()); // sending our returned data to our html component so it can be rendered.
        Copy_panel.Controls.Add(LabelHtml); // display html

    }


    /* GetCopy - protected
     * Description: Send our requested data to the class Component to display video html information. 
     *      The component will then initialize our request and return our results, 
     *      as well as our data that corresponds to the data we requested.
     *      Following that, our data will be sent to our html component to be rendered.
     * Parameters: none 
     * Return: nothing
     */
    protected void GetVideo()
    {
        Label Labelhtml = new Label();
        string[] rOuterData = { "ID", "Title", "TitleText" };
        string[] rInnerData = { "VideoURL", "Title" };

        Component component = new Component("Expert Home", "Video", rOuterData, rInnerData);
        if(!component.GetResult()) Console.WriteLine("An error has occurred");

        Labelhtml.Text = html.returnVideo(component.GetOuterData(), component.GetInnerData());
        Video_panel.Controls.Add(Labelhtml);
    }
}