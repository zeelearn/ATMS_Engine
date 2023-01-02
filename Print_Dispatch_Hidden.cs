using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.IO;
using ShoppingCart.BL;
using BarcodeLib.Barcode.ASP.NET;
public partial class Print_Dispatch_Hidden : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
         if (!IsPostBack)
        {
            string Menuid = "117";
            if (Request.Cookies["MyCookiesLoginInfo"] != null)
            {
                HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                string UserID = cookie.Values["UserID"];
                string UserName = cookie.Values["UserName"];


                string Asset_No = null;
                Asset_No = Request.QueryString["Job_Id"]; // Encryption_Decryption.decryptQueryString(Request.QueryString["Dispatch_Code"]);


                DataSet ds = ProductController_Report.Get_Datafordispatchprint(2, Asset_No);
                //dlstudentlabel.DataSource = ds;
                //dlstudentlabel.DataBind();

                string finaloutput = "<table style='page-break-after:always; margin-top:1px cellspacing=0px'>";
                int i = 0;
                while (ds.Tables[0].Rows.Count > i)
                {
                    //finaloutput = finaloutput + "<table style=page-break-after: always></table>";
                    finaloutput = finaloutput + "<tr>  <td style='font-size:12px' > <b>SPID : </b>  </td>  <td style='font-size:12px' align=left>" + ds.Tables[0].Rows[i]["Student_Code"].ToString() + "</td></tr>"
                        + "<tr>  <td style='font-size:12px' > <b>SBEntrycode : </b>   </td>  <td style='font-size:12px' align=left>" + ds.Tables[0].Rows[i]["User_Primary_Code"].ToString() + "</td></tr>"
                        + " <tr>  <td style='font-size:12px' > <b>Name : </b>   </td>  <td style='font-size:12px' align=left>" + ds.Tables[0].Rows[i]["Name"].ToString() + "</td></tr>"
                        + " <tr>  <td style='font-size:12px' > <b>Center : </b>   </td>  <td style='font-size:12px' align=left>" + ds.Tables[0].Rows[i]["Center"].ToString() + "</td></tr>" +
                        //"<tr><td colspan=2 TagPrefix=cc1 Assembly=BarcodeLib.Barcode.ASP.NET>  <cc1:LinearASPNET ID=LinearASPNET1 runat=server BarHeight=15 BarWidth=2 Data=" + ds.Tables[0].Rows[i]["Asset_No"].ToString() + " ShowText=false TextFontColor=black /></td></tr>";
                                   "<tr><td colspan=2 > <img src=linear.aspx?Type=2&amp;Data=" + ds.Tables[0].Rows[i]["Asset_No"].ToString() + "&amp;UOM=0&amp;BarWidth=2&amp;BarHeight=15&amp;LeftMargin=0&amp;RightMargin=0&amp;TopMargin=0&amp;BottomMargin=0&amp;Resolution=96&amp;Rotate=0&amp;ImageWidth=0&amp;ImageHeight=0&amp;BackgroundColor=Color+%5bWhite%5d&amp;BarColor=Color+%5bBlack%5d&amp;ShowText=false&amp;TextFont=Arial%7c9%7cregular&amp;TextFontColor=Color+%5bBlack%5d&amp;ImageFormat=png&amp;SData=&amp;SSeparation=12&amp;UPCENumber=0&amp;InterGap=1&amp;N=2&amp;ShowStartStopChar=True&amp;BearerBars=0&amp;ProcessTilde=False&amp;CodabarStartChar=A&amp;CodabarStopChar=A&amp;BarHeightRatio=0.4 /> </td></tr><table style=' page-break-after: always'>";


                    i++;




                }

                finaloutput = finaloutput + "</table></table>";

                Print.InnerHtml = finaloutput;



            }
            else
            {
                Response.Redirect("Logout.aspx");
            }
        }

 
    }
}