using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using System.IO;
using System.util;
using System.Text.RegularExpressions;
using ShoppingCart.BL;


public partial class GRN_Print : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string InwardCode = null;
        InwardCode = Request.QueryString["InwardCode"];
        //InwardCode = "I1510000129";

        DataSet dsGrid = ProductController.Get_Print(27, InwardCode);
        string InvoiceDate = "";

        lblGRNNo.Text = dsGrid.Tables[0].Rows[0]["Inward_Code"].ToString();
        lblGrnDate.Text = dsGrid.Tables[0].Rows[0]["Inward_Date"].ToString();
        lblPONO.Text = dsGrid.Tables[0].Rows[0]["PONo"].ToString();
        lblPoDate.Text = dsGrid.Tables[0].Rows[0]["PurchaseOrder_Date"].ToString();
        lblSuppName.Text = dsGrid.Tables[0].Rows[0]["Vendor_Name"].ToString();
        lblDelChalNO.Text = dsGrid.Tables[0].Rows[0]["Challan_No"].ToString();
        lblChalaDate.Text = dsGrid.Tables[0].Rows[0]["Challan_Date"].ToString();
        lblInvoiceValue.Text  = dsGrid.Tables[0].Rows[0]["Invoice_Value"].ToString();
        lblInvoiceNo.Text = dsGrid.Tables[0].Rows[0]["Invoice_No"].ToString();
        //lblInvoiceDate.Text = dsGrid.Tables[0].Rows[0]["Invoice_date"].ToString();

        InvoiceDate = dsGrid.Tables[0].Rows[0]["Invoice_date"].ToString();
        if (InvoiceDate == "01-01-1900")
        {
            lblInvoiceDate.Text = "";
        }
        else
        {
            lblInvoiceDate.Text = dsGrid.Tables[0].Rows[0]["Invoice_date"].ToString();
        }

        DLItemList.DataSource = dsGrid.Tables[1];
        DLItemList.DataBind();
    }

    protected void btnprint_Click(object sender, EventArgs e)
    {
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=GRN.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        pnlPerson.RenderControl(hw);
        StringReader sr = new StringReader(sw.ToString());
        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        pdfDoc.Open();
        htmlparser.Parse(sr);
        pdfDoc.Close();
        Response.Write(pdfDoc);
        Response.End();

    }
}
       