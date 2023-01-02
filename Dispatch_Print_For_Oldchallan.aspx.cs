using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using ShoppingCart.BL;
using System.Data;

//public partial class Dispatch_Print_For_Oldchallan : System.Web.UI.Page
//{
//    protected void Page_Load(object sender, EventArgs e)
//    {

//    }
//}

public partial class Dispatch_Print_For_Oldchallan : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillDDL_TransferType();
            FillDDL_Godown();
            FillDDL_Function();

            string DispatchCode = null, UserID = null;
            DispatchCode = Request.QueryString["DispatchCode"];
            UserID = Request.QueryString["UserID"];
            DataSet ds = null;
            ds = ProductController.Get_DispatchChallan_Report_Old(1, DispatchCode, UserID);
            if (ds.Tables[0].Rows.Count > 0)
            {

                lblChallanNo.Text = ds.Tables[0].Rows[0]["Challan_No"].ToString();
                lblChallanDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["Challan_Date"].ToString()).ToString("dd-MMM-yyyy");
                lblPreparedBy.Text = ds.Tables[0].Rows[0]["UserName"].ToString();

                ddlLocationType.SelectedValue = ds.Tables[0].Rows[0]["From_Location_Type_Code"].ToString();
                if (ds.Tables[0].Rows[0]["From_Location_Type_Code"].ToString() == "TL0000001")//Godown
                {
                    ddlgodownFR_SRSearch.SelectedValue = ds.Tables[0].Rows[0]["From_Location_Code"].ToString();
                    lblTransferFrom.Text = ddlLocationType.SelectedItem.ToString() + " ( " + ddlgodownFR_SRSearch.SelectedItem.ToString() + " )";
                }
                else if (ds.Tables[0].Rows[0]["From_Location_Type_Code"].ToString() == "TL0000002")//Function
                {
                    ddlFunctionFR_SRSearch.SelectedValue = ds.Tables[0].Rows[0]["From_Location_Code"].ToString();
                    lblTransferFrom.Text = ddlLocationType.SelectedItem.ToString() + " ( " + ddlFunctionFR_SRSearch.SelectedItem.ToString() + " )";
                }
                else //Center
                {
                    lblTransferFrom.Text = ddlLocationType.SelectedItem.ToString() + " ( " + ds.Tables[0].Rows[0]["FromCenterName"].ToString() + " )";
                }

                ddlLocationType.SelectedValue = ds.Tables[0].Rows[0]["To_Location_Type_Code"].ToString();
                if (ds.Tables[0].Rows[0]["To_Location_Type_Code"].ToString() == "TL0000001")//Godown
                {
                    ddlgodownFR_SRSearch.SelectedValue = ds.Tables[0].Rows[0]["To_Location_Code"].ToString();
                    lblTransferTo.Text = ddlLocationType.SelectedItem.ToString() + " ( " + ddlgodownFR_SRSearch.SelectedItem.ToString() + " )";
                }
                else if (ds.Tables[0].Rows[0]["To_Location_Type_Code"].ToString() == "TL0000002")//Function
                {
                    ddlFunctionFR_SRSearch.SelectedValue = ds.Tables[0].Rows[0]["To_Location_Code"].ToString();
                    lblTransferTo.Text = ddlLocationType.SelectedItem.ToString() + " ( " + ddlFunctionFR_SRSearch.SelectedItem.ToString() + " )";
                }
                else //Center
                {
                    lblTransferTo.Text = ddlLocationType.SelectedItem.ToString() + " ( " + ds.Tables[0].Rows[0]["ToCenterName"].ToString() + " )";
                }

                //DLItemList
                if (ds.Tables[1].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["Option_No"] == "")
                    {
                        dldispatch.DataSource = ds.Tables[1];
                        dldispatch.DataBind();
                        dldispatch.Visible = true;
                        DLItemList.Visible = false;
                    }
                    else
                    {

                        DLItemList.DataSource = ds.Tables[1];
                        DLItemList.DataBind();
                        dldispatch.Visible = false;
                        DLItemList.Visible = true;
                    }
                }
                else
                {
                    DLItemList.DataSource = null;
                    DLItemList.DataBind();
                }
            }

        }
    }


    protected void btnprint_Click(object sender, EventArgs e)
    {
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=DispatchPrint.pdf");
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



    private void BindDDL(DropDownList ddl, DataSet ds, string txtField, string valField)
    {
        ddl.DataSource = ds;
        ddl.DataTextField = txtField;
        ddl.DataValueField = valField;
        ddl.DataBind();
    }

    private void FillDDL_TransferType()
    {
        //Search DDL
        DataSet dsTransfer_Tp = ProductController.GetAllTransferType(1);
        BindDDL(ddlLocationType, dsTransfer_Tp, "Transfer_Location_Type_Name", "Transfer_Location_Type_ID");
        ddlLocationType.Items.Insert(0, "Select Location");
        ddlLocationType.SelectedIndex = 0;
    }

    private void FillDDL_Godown()
    {
        ddlgodownFR_SRSearch.Items.Clear();
        DataSet dsTransfer_Tp = ProductController.GetGodown_Function_Logistic_Assests_Type(1);
        BindDDL(ddlgodownFR_SRSearch, dsTransfer_Tp, "Godown_Name", "Godown_Id");
        ddlgodownFR_SRSearch.Items.Insert(0, "Select Godown");
        ddlgodownFR_SRSearch.SelectedIndex = 0;
    }


    private void FillDDL_Function()
    {
        ddlFunctionFR_SRSearch.Items.Clear();
        DataSet dsTransfer_Tp = ProductController.GetGodown_Function_Logistic_Assests_Type(2);
        BindDDL(ddlFunctionFR_SRSearch, dsTransfer_Tp, "Function_Name", "Function_Id");
        ddlFunctionFR_SRSearch.Items.Insert(0, "Select Function");
        ddlFunctionFR_SRSearch.SelectedIndex = 0;
    }

}