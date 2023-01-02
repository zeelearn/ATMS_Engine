using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ShoppingCart.BL;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf.draw;
using System.Net.Mail;
using System.Net;

public partial class Print_Sticker : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {


            ControlVisibility("Search");
            FillDDL_TransferType();
            FillDDL_Division();
            FillDDL_Godown();
            FillDDL_Function();
            //  FillDDL_Logistic();
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            Label lblHeader_User_Code = default(Label);
            lblHeader_User_Code = (Label)Master.FindControl("lblHeader_User_Code");
            lblHeader_User_Code.Text = UserID;

        }
    }
    private void FillDDL_TransferType()
    {
        //Search DDL
        DataSet dsTransfer_Tp = ProductController.GetAllTransferType(1);
        BindDDL(ddlTransferFR_SR, dsTransfer_Tp, "Transfer_Location_Type_Name", "Transfer_Location_Type_ID");
        ddlTransferFR_SR.Items.Insert(0, "Select Transfer From");
        ddlTransferFR_SR.SelectedIndex = 0;

        //BindDDL(ddlTransferTO_SR, dsTransfer_Tp, "Transfer_Location_Type_Name", "Transfer_Location_Type_ID");
        //ddlTransferTO_SR.Items.Insert(0, "Select Transfer To");
        //ddlTransferTO_SR.SelectedIndex = 0;



    }
    private void BindDDL(DropDownList ddl, DataSet ds, string txtField, string valField)
    {
        ddl.DataSource = ds;
        ddl.DataTextField = txtField;
        ddl.DataValueField = valField;
        ddl.DataBind();
    }
    private void FillDDL_Division()
    {
        string Company_Code = "MT";
        string DBname = "CDB";

        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];

        //Search DDL
        DataSet dsDivision = ProductController.GetAllActiveUser_Company_Division_Zone_Center(UserID, Company_Code, "", "", "2", DBname);
        BindDDL(ddlDivisionFR_SR, dsDivision, "Division_Name", "Division_Code");
        ddlDivisionFR_SR.Items.Insert(0, "Select");
        ddlDivisionFR_SR.SelectedIndex = 0;

        //BindDDL(ddlDivisionTO_SR, dsDivision, "Division_Name", "Division_Code");
        //ddlDivisionTO_SR.Items.Insert(0, "Select");
        //ddlDivisionTO_SR.SelectedIndex = 0;


    }

    private void FillDDL_Godown()
    {

        DataSet dsGodown = ProductController.GetGodown_Function_Logistic_Assests_Type(1);

        //BindDDL(ddlgodownTO_SR, dsGodown, "Godown_Name", "Godown_Id");
        //ddlgodownTO_SR.Items.Insert(0, "Select");
        //ddlgodownTO_SR.SelectedIndex = 0;


        BindDDL(ddlgodownFR_SR, dsGodown, "Godown_Name", "Godown_Id");
        ddlgodownFR_SR.Items.Insert(0, "Select");
        ddlgodownFR_SR.SelectedIndex = 0;


    }
    private void FillDDL_Function()
    {

        DataSet dsFunction = ProductController.GetGodown_Function_Logistic_Assests_Type(2);

        //BindDDL(ddlFunctionTO_SR, dsFunction, "Function_Name", "Function_Id");
        //ddlFunctionTO_SR.Items.Insert(0, "Select");
        //ddlFunctionTO_SR.SelectedIndex = 0;


        BindDDL(ddlFunctionFR_SR, dsFunction, "Function_Name", "Function_Id");
        ddlFunctionFR_SR.Items.Insert(0, "Select");
        ddlFunctionFR_SR.SelectedIndex = 0;
    }
    protected void ddlDivisionFR_SR_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlCenterFR_SR.Items.Clear();
        FillDDL_FRSearch_Centre();
    }
    private void FillDDL_FRSearch_Centre()
    {
        string Company_Code = "MT";
        string DBname = "CDB";

        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];

        string Div_Code = null;
        Div_Code = ddlDivisionFR_SR.SelectedValue;

        DataSet dsCentre = ProductController.GetAllActiveUser_Company_Division_Zone_Center(UserID, Company_Code, Div_Code, "", "5", DBname);

        BindDDL(ddlCenterFR_SR, dsCentre, "Center_Name", "Center_Code");
        ddlCenterFR_SR.Items.Insert(0, "Select");
        ddlCenterFR_SR.SelectedIndex = 0;
    }
    //protected void ddlTransferTO_SR_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddlTransferTO_SR.SelectedItem.ToString().Trim() == "Godown")
    //    {
    //        tblTO_Godown.Visible = true;
    //        tblTO_Function.Visible = false;
    //        tblTO_Division.Visible = false;
    //        tblTO_Center.Visible = false;
    //    }
    //    else if (ddlTransferTO_SR.SelectedItem.ToString().Trim() == "Function")
    //    {
    //        tblTO_Function.Visible = true;
    //        tblTO_Godown.Visible = false;
    //        tblTO_Division.Visible = false;
    //        tblTO_Center.Visible = false;
    //    }
    //    else if (ddlTransferTO_SR.SelectedItem.ToString().Trim() == "Center")
    //    {
    //        tblTO_Division.Visible = true;
    //        tblTO_Center.Visible = true;
    //        tblTO_Function.Visible = false;
    //        tblTO_Godown.Visible = false;
    //    }
    //    else if (ddlTransferTO_SR.SelectedIndex == 0 || ddlTransferTO_SR.SelectedIndex == -1)
    //    {
    //        tblTO_Godown.Visible = false;
    //        tblTO_Function.Visible = false;
    //        tblTO_Division.Visible = false;
    //        tblTO_Center.Visible = false;
    //    }
    //}
    //protected void ddlDivisionTO_SR_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    ddlCenterTO_SR.Items.Clear();
    //    FillDDL_TOSearch_Centre();
    //}
    private void ControlVisibility(string Mode)
    {
        if (Mode == "Search")
        {
            // DivAddPanel.Visible = false;
            DivSearchPanel.Visible = true;
            //  BtnAdd.Visible = true;
            // BtnSaveAdd.Visible = true;
            // BtnSaveEdit.Visible = false;
            //  btnPrint.Visible = false;
            DivResultPanel.Visible = false;
            // DivAuthorise.Visible = false;
        }
        else if (Mode == "Result")
        {
            //  DivAddPanel.Visible = false;
            DivSearchPanel.Visible = false;
            //  BtnAdd.Visible = true;
            DivResultPanel.Visible = true;
            // lblPkey.Text = "";
            // DivAuthorise.Visible = false;

        }
        else if (Mode == "Add")
        {
            // DivAddPanel.Visible = true;
            DivSearchPanel.Visible = false;
            //  BtnAdd.Visible = false;
            DivResultPanel.Visible = false;
            // lblPkey.Text = "";
            // BtnSaveEdit.Visible = false;
            // btnPrint.Visible = false;
            // BtnSaveAdd.Visible = true;
            // DivAuthorise.Visible = false;


        }
        else if (Mode == "Edit")
        {
            // DivAddPanel.Visible = false;
            DivSearchPanel.Visible = false;
            //  BtnAdd.Visible = false;
            DivResultPanel.Visible = false;
            //  DivAuthorise.Visible = false;
        }
        else if (Mode == "Details")
        {
            //  DivAddPanel.Visible = false;
            DivSearchPanel.Visible = false;
            // BtnAdd.Visible = true;
            DivResultPanel.Visible = false;
            //  DivAuthorise.Visible = false;
        }


    }

    //private void FillDDL_TOSearch_Centre()
    //{
    //    string Company_Code = "MT";
    //    string DBname = "CDB";

    //    HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
    //    string UserID = cookie.Values["UserID"];
    //    string UserName = cookie.Values["UserName"];

    //    string Div_Code = null;
    //    Div_Code = ddlDivisionTO_SR.SelectedValue;

    //    DataSet dsCentre = ProductController.GetAllActiveUser_Company_Division_Zone_Center(UserID, Company_Code, Div_Code, "", "5", DBname);

    //    BindDDL(ddlCenterTO_SR, dsCentre, "Center_Name", "Center_Code");
    //    ddlCenterTO_SR.Items.Insert(0, "Select");
    //    ddlCenterTO_SR.SelectedIndex = 0;
    //}
    protected void ddlTransferFR_SR_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTransferFR_SR.SelectedItem.ToString().Trim() == "Godown")
        {
            tblFr_Godown.Visible = true;
            tblFr_Function.Visible = false;
            tblFr_Division.Visible = false;
            tblFr_Center.Visible = false;
        }
        else if (ddlTransferFR_SR.SelectedItem.ToString().Trim() == "Function")
        {
            tblFr_Function.Visible = true;
            tblFr_Godown.Visible = false;
            tblFr_Division.Visible = false;
            tblFr_Center.Visible = false;
        }
        else if (ddlTransferFR_SR.SelectedItem.ToString().Trim() == "Center")
        {
            tblFr_Division.Visible = true;
            tblFr_Center.Visible = true;
            tblFr_Function.Visible = false;
            tblFr_Godown.Visible = false;

            //Fill Division
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];

        }
        else if (ddlTransferFR_SR.SelectedIndex == 0 || ddlTransferFR_SR.SelectedIndex == -1)
        {
            tblFr_Godown.Visible = false;
            tblFr_Function.Visible = false;
            tblFr_Division.Visible = false;
            tblFr_Center.Visible = false;
        }
    }

    private void Clear_Error_Success_Box()
    {
        Msg_Error.Visible = false;
        Msg_Success.Visible = false;
        lblSuccess.Text = "";
        lblerror.Text = "";
        UpdatePanelMsgBox.Update();
    }


    private void Show_Error_Success_Box(string BoxType, string Error_Code)
    {
        if (BoxType == "E")
        {
            Msg_Error.Visible = true;
            Msg_Success.Visible = false;
            lblerror.Text = ProductController.Raise_Error(Error_Code);
            UpdatePanelMsgBox.Update();
            Msg_Error.Focus();
        }
        else
        {
            Msg_Success.Visible = true;
            Msg_Error.Visible = false;
            lblSuccess.Text = ProductController.Raise_Error(Error_Code);
            UpdatePanelMsgBox.Update();
        }
    }
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        Clear_Error_Success_Box();

        if (ddlTransferFR_SR.SelectedValue == "Select Transfer From")
        {
            Show_Error_Success_Box("E", "Select Transfer From");
            ddlTransferFR_SR.Focus();
            return;

        }

        else if (ddlTransferFR_SR.SelectedItem.Text == "Godown" && ddlgodownFR_SR.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "Select Transfer From Godown");
            ddlTransferFR_SR.Focus();
            return;
        }

        else if (ddlTransferFR_SR.SelectedItem.Text == "Function" && ddlFunctionFR_SR.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "Select Transfer From Function");
            ddlFunctionFR_SR.Focus();
            return;

        }
        else if (ddlTransferFR_SR.SelectedItem.Text == "Center" && ddlDivisionFR_SR.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "Select Transfer From Division");
            ddlDivisionFR_SR.Focus();
            return;
        }
        else if (ddlTransferFR_SR.SelectedItem.Text == "Center" && ddlCenterFR_SR.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "Select Transfer From Center");
            ddlCenterFR_SR.Focus();
            return;
        }
        else if (ddlDivisionFR_SR.SelectedIndex != 0 && ddlCenterFR_SR.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "Select Transfer From Center");
            ddlCenterFR_SR.Focus();
            return;
        }


        string From_Location_Type_Code = "";
        string From_Location_Code = "";
        From_Location_Type_Code = ddlTransferFR_SR.SelectedValue;

        if (ddlTransferFR_SR.SelectedItem.Text == "Godown")
        {
            From_Location_Code = ddlgodownFR_SR.SelectedValue;
        }
        else if (ddlTransferFR_SR.SelectedItem.Text == "Function")
        {
            From_Location_Code = ddlFunctionFR_SR.SelectedValue;
        }
        else if (ddlTransferFR_SR.SelectedItem.Text == "Center")
        {
            From_Location_Code = ddlCenterFR_SR.SelectedValue;
        }




        Label lblHeader_User_Code = default(Label);
        lblHeader_User_Code = (Label)Master.FindControl("lblHeader_User_Code");

        string CreatedBy = null;
        CreatedBy = lblHeader_User_Code.Text;
        lblPkey.Text = "";
        string ResultId = ProductController.Insert_OpeningStock_Inward(1, ddlTransferFR_SR.SelectedValue, From_Location_Code, CreatedBy);
        lblPkey.Text = ResultId;


        //DataSet dsItems = ProductController.Get_Edit_GRNDetails(29, lblPkey.Text.Trim());   
        DataSet dsItems = ProductController.Get_Edit_GRNDetails_Print(29, From_Location_Type_Code, From_Location_Code);//26-08-2016 (for all location)

     
        if (dsItems != null)
        {
            if (dsItems.Tables.Count != 0)
            {
                if (dsItems.Tables[0].Rows.Count != 0)
                {
                    dlGridDisplay.DataSource = dsItems;
                    dlGridDisplay.DataBind();

                    DataList1.DataSource = dsItems;
                    DataList1.DataBind();
                     ControlVisibility("Result");
                    //BtnSaveAdd.Visible = true;
                }
                else
                {
                    dlGridDisplay.DataSource = null;
                    dlGridDisplay.DataBind();


                    DataList1.DataSource = null;
                    DataList1.DataBind();
                    Show_Error_Success_Box("E", "No Records Found");
                }

            }

        }
        if (dsItems != null)
        {
            if (dsItems.Tables.Count != 0)
            {
                if (dsItems.Tables[0].Rows.Count != 0)
                {
                    lbltotalcount.Text = (dsItems.Tables[0].Rows.Count).ToString();
                }
                else
                {
                    lbltotalcount.Text = "0";
                }
            }
            else
            {
                lbltotalcount.Text = "0";
            }
        }
        else
        {
            lbltotalcount.Text = "0";
        }
    }


    public void AllChk_Selected(object sender, System.EventArgs e)
    {

        CheckBox s = sender as CheckBox;

        //Set checked status of hidden check box to items in grid
        foreach (DataListItem dtlItem in dlGridDisplay.Items)
        {
            CheckBox chkitemck = (CheckBox)dtlItem.FindControl("chkItem");

            chkitemck.Checked = s.Checked;
        }

      

    }
    protected void BtnCloseAdd_Click(object sender, EventArgs e)
    {
        DivSearchPanel.Visible = true;
        DivResultPanel.Visible = false;
        ClearSearchPanel();

    }
    protected void Btprint_Click(object sender, EventArgs e)
    {


        string Asset_No = "";

        {

            foreach (DataListItem item in dlGridDisplay.Items)
            {
                Label lblMenuParentcode = (Label)item.FindControl("lblMenuParentcode");
                Label lblName = (Label)item.FindControl("lblName");
                Label lblSerialNo = (Label)item.FindControl("lblSerialNo");
                Label lblSap_Asset_No = (Label)item.FindControl("lblSap_Asset_No");
                Label lblAsset_No = (Label)item.FindControl("lblAsset_No");
                CheckBox chkItem = (CheckBox)item.FindControl("chkItem");


                if (chkItem.Checked)
                {
                    if (lblAsset_No.Text != "")
                    {
                        Asset_No = Asset_No + lblAsset_No.Text + ",";
                    }

                }

            }

            if (Asset_No == "")
            {
                Show_Error_Success_Box("E", "Asset No Blank");
                return;
            }

            else if (Asset_No != "")
            {
                Label lblHeader_User_Code = default(Label);
                lblHeader_User_Code = (Label)Master.FindControl("lblHeader_User_Code");
                string CreatedBy = null;
                CreatedBy = lblHeader_User_Code.Text;
                DataSet ds = ProductController.Get_Print(1, CreatedBy, Asset_No);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        Response.Redirect("Print_Sticker_Hidden.aspx?Job_Id=" + ds.Tables[0].Rows[0]["Job_Id"].ToString());
                    }
                }
            }
            else
            {

                lblerror.Visible = true;
                Show_Error_Success_Box("E", "select Atleast One Record");
                // lblerror.Text = "Asset No Is Blank";
               

            }
        }
    }





    protected void BtnShowSearchPanel_Click(object sender, EventArgs e)
    {
        DivSearchPanel.Visible = true;
        DivResultPanel.Visible = false;
        ClearSearchPanel();


    }
    protected void BtnClearSearch_Click(object sender, EventArgs e)
    {
        DivSearchPanel.Visible = true;
        DivResultPanel.Visible = false;
        ClearSearchPanel();
    }

    private void ClearSearchPanel()
    {
        //From Content
        ddlTransferFR_SR.SelectedIndex = 0;
        ddlgodownFR_SR.SelectedIndex = 0;
        ddlDivisionFR_SR.SelectedIndex = 0;
        ddlFunctionFR_SR.SelectedIndex = 0;
        ddlCenterFR_SR.Items.Clear();
        Msg_Error.Visible = false;
        //To Content

        //date_range_SR.Value = "";
        //txtChallan_SR.Text = "";

        //Visible False from Table
        tblFr_Godown.Visible = false;
        tblFr_Division.Visible = false;
        tblFr_Function.Visible = false;
        tblFr_Center.Visible = false;
    }

    protected void HLExport_Click(object sender, EventArgs e)
    {
        DataList1.Visible = true;

   

        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        string filenamexls1 = "Print_Sticker_" + DateTime.Now + ".xls";
        Response.AddHeader("Content-Disposition", "inline;filename=" + filenamexls1);
        HttpContext.Current.Response.Charset = "utf-8";
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");
        //sets font
        HttpContext.Current.Response.Write("<font style='font-size:10.0pt; font-family:Calibri;'>");
        HttpContext.Current.Response.Write("<BR><BR><BR>");
        HttpContext.Current.Response.Write("<Table border='1'  borderColor='#000000' cellSpacing='0' cellPadding='0' style='font-size:10.0pt; font-family:Calibri; text-align:center;'> <TR style='color: #fff; background: black;text-align:center;'><TD Colspan='9'>Print_Sticker</b></TD></TR>");
        Response.Charset = "";
        this.EnableViewState = false;
        System.IO.StringWriter oStringWriter1 = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter oHtmlTextWriter1 = new System.Web.UI.HtmlTextWriter(oStringWriter1);
        //this.ClearControls(dladmissioncount)
        DataList1.RenderControl(oHtmlTextWriter1);
        Response.Write(oStringWriter1.ToString());
        Response.Flush();
        Response.End();


    }
}
