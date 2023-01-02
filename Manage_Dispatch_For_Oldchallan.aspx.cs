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
//using ShoppingCart.BL;
//using Exportxls.BL;
using Encryption.BL;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Security;

//public partial class Manage_Dispatch_For_Oldchallan : System.Web.UI.Page
//{
//    protected void Page_Load(object sender, EventArgs e)
//    {

//    }
//}

public partial class Manage_Dispatch_For_Oldchallan : System.Web.UI.Page
{

    #region PageLoad
    protected void Page_Load(object sender, EventArgs e)
    {


        if (!IsPostBack)
        {
            div_student.Visible = false;
            div_Employee.Visible = false;
            DivForOP3.Visible = false;
            div_Teacher.Visible = false;
            string opt = null;
            lblHeader.Text = "Dispatch Print For Old Challan ";
            opt = Request.QueryString["OptionCode"];
            if (opt == "2")
            {
                lblHeader.Text = "Dispatch Entry (Raw Goods)";
                btnprintopt2.Visible = true;
            }
            else if (opt == "3")
            {
                lblHeader.Text = "Dispatch Entry (Finished Goods)";
            }
            else if (opt == "4")
            {
                lblHeader.Text = "Dispatch Print For Old Challan ";
            }
            //NewPageLoad(opt);

            ControlVisibility("Search");
            FillDDL_TransferType();
            FillDDL_Division();
            FillDDL_Godown();
            FillDDL_Function();
            FillDDL_Logistic();
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            Label lblHeader_User_Code = default(Label);
            lblHeader_User_Code = (Label)Master.FindControl("lblHeader_User_Code");
            lblHeader_User_Code.Text = UserID;

        }

    }
    #endregion

    #region Methods

    private void BindDDL(DropDownList ddl, DataSet ds, string txtField, string valField)
    {
        ddl.DataSource = ds;
        ddl.DataTextField = txtField;
        ddl.DataValueField = valField;
        ddl.DataBind();
    }


    //private void FillDDL_Requisition_No(string Loc_Type, string DivFunCode, int Flag)
    //{

    //    ddlrequi_No.Items.Clear();
    //    DataSet dsReuisition = ProductController.GetRequisition_No(Loc_Type, DivFunCode, Flag);
    //    BindDDL(ddlrequi_No, dsReuisition, "Request_Code", "Request_Code");
    //    ddlrequi_No.Items.Insert(0, "Select Requi. No");
    //    ddlrequi_No.SelectedIndex = 0;
    //}


    private void FillDDL_TransferType()
    {
        //Search DDL
        DataSet dsTransfer_Tp = ProductController.GetAllTransferType(1);
        BindDDL(ddlTransferFR_SR, dsTransfer_Tp, "Transfer_Location_Type_Name", "Transfer_Location_Type_ID");
        ddlTransferFR_SR.Items.Insert(0, "Select Transfer From");
        ddlTransferFR_SR.SelectedIndex = 0;

        BindDDL(ddlTransferTO_SR, dsTransfer_Tp, "Transfer_Location_Type_Name", "Transfer_Location_Type_ID");
        ddlTransferTO_SR.Items.Insert(0, "Select Transfer To");
        ddlTransferTO_SR.SelectedIndex = 0;

        //Add DDL
        BindDDL(ddlTransferFR_Add, dsTransfer_Tp, "Transfer_Location_Type_Name", "Transfer_Location_Type_ID");
        ddlTransferFR_Add.Items.Insert(0, "Select Transfer From");
        ddlTransferFR_Add.SelectedIndex = 0;

        BindDDL(ddlTransferTO_Add, dsTransfer_Tp, "Transfer_Location_Type_Name", "Transfer_Location_Type_ID");
        ddlTransferTO_Add.Items.Insert(0, "Select Transfer To");
        ddlTransferTO_Add.SelectedIndex = 0;

    }


    private void FillDDL_Godown()
    {

        DataSet dsGodown = ProductController.GetGodown_Function_Logistic_Assests_Type(1);

        BindDDL(ddlGodownFR_Add, dsGodown, "Godown_Name", "Godown_Id");
        ddlGodownFR_Add.Items.Insert(0, "Select");
        ddlGodownFR_Add.SelectedIndex = 0;

        BindDDL(ddlGodownTO_Add, dsGodown, "Godown_Name", "Godown_Id");
        ddlGodownTO_Add.Items.Insert(0, "Select");
        ddlGodownTO_Add.SelectedIndex = 0;


        BindDDL(ddlgodownTO_SR, dsGodown, "Godown_Name", "Godown_Id");
        ddlgodownTO_SR.Items.Insert(0, "Select");
        ddlgodownTO_SR.SelectedIndex = 0;


        BindDDL(ddlgodownFR_SR, dsGodown, "Godown_Name", "Godown_Id");
        ddlgodownFR_SR.Items.Insert(0, "Select");
        ddlgodownFR_SR.SelectedIndex = 0;


    }


    private void FillDDL_Function()
    {

        DataSet dsFunction = ProductController.GetGodown_Function_Logistic_Assests_Type(2);
        BindDDL(ddlFunctionFR_Add, dsFunction, "Function_Name", "Function_Id");
        ddlFunctionFR_Add.Items.Insert(0, "Select");
        ddlFunctionFR_Add.SelectedIndex = 0;

        BindDDL(ddlFunctionTO_Add, dsFunction, "Function_Name", "Function_Id");
        ddlFunctionTO_Add.Items.Insert(0, "Select");
        ddlFunctionTO_Add.SelectedIndex = 0;

        BindDDL(ddlFunctionTO_SR, dsFunction, "Function_Name", "Function_Id");
        ddlFunctionTO_SR.Items.Insert(0, "Select");
        ddlFunctionTO_SR.SelectedIndex = 0;


        BindDDL(ddlFunctionFR_SR, dsFunction, "Function_Name", "Function_Id");
        ddlFunctionFR_SR.Items.Insert(0, "Select");
        ddlFunctionFR_SR.SelectedIndex = 0;
    }


    private void BindListBox(ListBox ddl, DataSet ds, string txtField, string valField)
    {
        ddl.DataSource = ds;
        ddl.DataTextField = txtField;
        ddl.DataValueField = valField;
        ddl.DataBind();
    }

    /// <summary>
    /// Clear Error Success Box
    /// </summary>
    private void Clear_Error_Success_Box()
    {
        Msg_Error.Visible = false;
        Msg_Success.Visible = false;
        lblSuccess.Text = "";
        lblerror.Text = "";
        UpdatePanelMsgBox.Update();
    }


    private void ControlVisibility(string Mode)
    {
        if (Mode == "Search")
        {
            DivPrintPanel.Visible = false;
            DivAddPanel.Visible = false;
            DivSearchPanel.Visible = true;
            BtnAdd.Visible = false;
            //BtnSaveAdd.Visible = false;
            BtnSaveEdit.Visible = false;
            btnPrint.Visible = false;
            DivResultPanel.Visible = false;
            DivAuthorise.Visible = false;
        }
        else if (Mode == "Result")
        {
            DivPrintPanel.Visible = false;
            DivAddPanel.Visible = false;
            DivSearchPanel.Visible = false;
            BtnAdd.Visible = false;
            DivResultPanel.Visible = true;
            lblPkey.Text = "";
            DivAuthorise.Visible = false;

        }
        else if (Mode == "Add")
        {
            DivPrintPanel.Visible = false;
            DivAddPanel.Visible = true;
            DivSearchPanel.Visible = false;
            BtnAdd.Visible = false;
            DivResultPanel.Visible = false;
            lblPkey.Text = "";
            lblUserType.Text = "";
            BtnSaveEdit.Visible = false;
            btnPrint.Visible = false;
            //BtnSaveAdd.Visible = true;
            DivAuthorise.Visible = false;
            lblreissue.Text = "";

            string opt = null;
            opt = Request.QueryString["OptionCode"];
            if (opt == "3" || opt == "4")
            {
                ItemDivs.Visible = false;
            }
            else
            {
                ItemDivs.Visible = true;
            }
        }
        else if (Mode == "Edit")
        {
            DivPrintPanel.Visible = false;
            DivAddPanel.Visible = false;
            DivSearchPanel.Visible = false;
            BtnAdd.Visible = false;
            DivResultPanel.Visible = false;
            DivAuthorise.Visible = false;
        }
        else if (Mode == "Details")
        {
            DivPrintPanel.Visible = false;
            DivAddPanel.Visible = false;
            DivSearchPanel.Visible = false;
            BtnAdd.Visible = false;
            DivResultPanel.Visible = false;
            DivAuthorise.Visible = false;
        }


        else if (Mode == "Authorise")
        {
            DivPrintPanel.Visible = false;
            DivAddPanel.Visible = false;
            DivSearchPanel.Visible = false;
            BtnAdd.Visible = false;
            DivResultPanel.Visible = false;
            DivAuthorise.Visible = true;
        }
        else if (Mode == "Student")
        {
            DivPrintPanel.Visible = false;
            div_student.Visible = true;

            div_Teacher.Visible = false;
            div_Employee.Visible = false;
            DivForOP3.Visible = false;

            string opt = null;
            opt = Request.QueryString["OptionCode"];
            if (opt == "3")
            {
                DivForOP3.Visible = true;
                div_student.Visible = false;
            }
            if (opt == "4")
            {
                DivForOP3.Visible = true;
                div_student.Visible = false;
            }
        }
        else if (Mode == "Teacher")
        {
            DivPrintPanel.Visible = false;
            div_Teacher.Visible = true;

            div_student.Visible = false;
            div_Employee.Visible = false;
            DivForOP3.Visible = false;

            string opt = null;
            opt = Request.QueryString["OptionCode"];
            if (opt == "3")
            {
                DivForOP3.Visible = true;
                div_Teacher.Visible = false;
            }
            if (opt == "4")
            {
                DivForOP3.Visible = true;
                div_Teacher.Visible = false;
            }
        }
        else if (Mode == "Employee")
        {
            DivPrintPanel.Visible = false;
            div_Employee.Visible = true;

            div_student.Visible = false;
            div_Teacher.Visible = false;
            DivForOP3.Visible = false;

            string opt = null;
            opt = Request.QueryString["OptionCode"];
            if (opt == "3")
            {
                DivForOP3.Visible = true;
                div_Employee.Visible = false;
            }
            if (opt == "4")
            {
                DivForOP3.Visible = true;
                div_Employee.Visible = false;
            }
        }

        else if (Mode == "Print Panel")
        {
            DivPrintPanel.Visible = true;
            div_Employee.Visible = false;
            div_student.Visible = false;
            div_Teacher.Visible = false;
            DivAddPanel.Visible = false;
            DivAuthorise.Visible = false;
            DivAuthoriseItemList.Visible = false;
            DivForOP3.Visible = false;
            DivSearchPanel.Visible = false;
            DivResultPanel.Visible = false;
            BtnAdd.Visible = false;
            lblPkey.Text = "";
        }
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


    /// <summary>
    /// Clear Add Panel 
    /// </summary>
    private void ClearAddPanel()
    {



        //From Content
        ddlTransferFR_Add.SelectedIndex = 0;
        ddlDivisionFR_Add.SelectedIndex = 0;
        ddlCenterFR_Add.Items.Clear();
        //To Content
        ddlTransferTO_Add.SelectedIndex = 0;
        ddlDivisionTO_Add.SelectedIndex = 0;
        //ddlrequi_No.Items.Clear();
        txtRequestCode.Text = "";
        ddlCenterTO_Add.Items.Clear();

        //

        txtChallanNo_Add.Text = "";

        //Visible False from Table
        tblFR_Godown_Add.Visible = false;
        tblFR_Function_Add.Visible = false;
        tblFR_Division_Add.Visible = false;
        tblFR_Center_Add.Visible = false;

        //Visible False TO Table
        tblTO_Godown_Add.Visible = false;
        tblTO_Function_Add.Visible = false;
        tblTO_Division_Add.Visible = false;
        tblTO_Center_Add.Visible = false;
        txtEmail_Add.Text = "";
        txtContactPerson_Add.Text = "";
        txtContact_Add.Text = "";
        txtChallanDate_Add.Text = DateTime.Now.ToString("dd-MMM-yyyy");

        dlQuestion.DataSource = null;
        dlQuestion.DataBind();

        DataList2.DataSource = null;
        DataList2.DataBind();

        lblTotal_Quantity.Text = "";
        lblTotal_Amount.Text = "";
        lblTotalItem.Text = "";
        lblPkey.Text = "";
        ddlLogisticType_Add.SelectedIndex = 0;
        txtLogisticDetails_Add.Text = "";
        txtVechicleNo_Add.Text = "";
        txtPODNo_Add0.Text = "";

        //
        datalist_Student.DataSource = null;
        datalist_Student.DataBind();

        datalist_Teacher.DataSource = null;
        datalist_Teacher.DataBind();
    }



    private void ClearSearchPanel()
    {
        //From Content
        ddlTransferFR_SR.SelectedIndex = 0;
        ddlgodownFR_SR.SelectedIndex = 0;
        ddlDivisionFR_SR.SelectedIndex = 0;
        ddlFunctionFR_SR.SelectedIndex = 0;
        ddlCenterFR_SR.Items.Clear();

        //To Content
        ddlTransferTO_SR.SelectedIndex = 0;
        ddlgodownTO_SR.SelectedIndex = 0;
        ddlDivisionTO_SR.SelectedIndex = 0;
        ddlFunctionTO_SR.SelectedIndex = 0;
        ddlCenterTO_SR.Items.Clear();

        //
        date_range_SR.Value = "";
        txtChallan_SR.Text = "";

        //Visible False from Table
        tblFr_Godown.Visible = false;
        tblFr_Function.Visible = false;
        tblFr_Division.Visible = false;
        tblFr_Center.Visible = false;

        //Visible False TO Table
        tblTO_Godown.Visible = false;
        tblTO_Function.Visible = false;
        tblTO_Division.Visible = false;
        tblTO_Center.Visible = false;

    }

    //private void SaveData()
    //{
    //    try
    //    {
    //        Clear_Error_Success_Box();

    //        if (DataList2.Items.Count == 0)
    //        {

    //            Show_Error_Success_Box("E", "Select atleast one material detail");
    //            return;
    //            //ddlTransferFR_Add.Focus();
    //        }

    //        Label lblHeader_User_Code = default(Label);
    //        lblHeader_User_Code = (Label)Master.FindControl("lblHeader_User_Code");

    //        string CreatedBy = null;
    //        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
    //        CreatedBy = cookie.Values["UserID"];

    //        string From_Location_Type_Code = "";
    //        string From_Location_Code = "";
    //        string To_Location_Type_Code = "";
    //        string To_Location_Code = "";
    //        DateTime Dispatch_Date = DateTime.Now;
    //        string Challan_No = "";
    //        DateTime Challan_Date;
    //        string ContactPerson = "";
    //        string ContactPersonNo = "";
    //        string ContactPersonEmailId = "";

    //        int Temp_Flag = 0;
    //        string LogisticType_Code = string.Empty;
    //        string LogisticDetails1 = string.Empty;
    //        string LogisticDetails2 = string.Empty;
    //        int IsActive = 1;

    //        string ResultId = "";

    //        int Total_Item_Count = 0;
    //        int Total_Quantity = 0;
    //        decimal Total_Amount = 0;

    //        From_Location_Type_Code = ddlTransferFR_Add.SelectedValue;
    //        To_Location_Type_Code = ddlTransferTO_Add.SelectedValue;

    //        if (ddlTransferFR_Add.SelectedItem.Text == "Godown")
    //        {
    //            From_Location_Code = ddlGodownFR_Add.SelectedValue;
    //        }
    //        else if (ddlTransferFR_Add.SelectedItem.Text == "Function")
    //        {
    //            From_Location_Code = ddlFunctionFR_Add.SelectedValue;
    //        }
    //        else if (ddlTransferFR_Add.SelectedItem.Text == "Center")
    //        {
    //            From_Location_Code = ddlCenterFR_Add.SelectedValue;
    //        }

    //        if (ddlTransferTO_Add.SelectedItem.Text == "Godown")
    //        {
    //            To_Location_Code = ddlGodownTO_Add.SelectedValue;
    //        }
    //        else if (ddlTransferTO_Add.SelectedItem.Text == "Function")
    //        {
    //            To_Location_Code = ddlFunctionTO_Add.SelectedValue;
    //        }
    //        else if (ddlTransferTO_Add.SelectedItem.Text == "Center")
    //        {
    //            To_Location_Code = ddlCenterTO_Add.SelectedValue;
    //        }

    //        Challan_No = txtChallanNo_Add.Text.Trim();
    //        Challan_Date = Convert.ToDateTime(txtChallanDate_Add.Text.Trim());
    //        ContactPerson = txtContactPerson_Add.Text.Trim();
    //        ContactPersonEmailId = txtEmail_Add.Text.Trim();
    //        ContactPersonNo = txtContact_Add.Text.Trim();
    //        LogisticType_Code = ddlLogisticType_Add.SelectedValue;



    //        if (ddlLogisticType_Add.SelectedItem.Text == "Courier")
    //        {
    //            LogisticDetails1 = txtLogisticDetails_Add.Text.Trim();
    //            LogisticDetails2 = txtPODNo_Add0.Text.Trim();
    //        }

    //        if (ddlLogisticType_Add.SelectedItem.Text == "Transport")
    //        {
    //            LogisticDetails1 = txtLogisticDetails_Add.Text.Trim();
    //            LogisticDetails2 = txtVechicleNo_Add.Text.Trim();
    //        }

    //        if (ddlLogisticType_Add.SelectedItem.Text == "In Person")
    //        {
    //            LogisticDetails1 = txtLogisticDetails_Add.Text.Trim();
    //            LogisticDetails2 = "";
    //        }


    //        if (lblTotal_Quantity.Text != "")
    //        {
    //            Total_Quantity = Convert.ToInt32(lblTotal_Quantity.Text);
    //        }

    //        if (lblTotal_Amount.Text != "")
    //        {
    //            Total_Amount = Convert.ToDecimal(lblTotal_Amount.Text);
    //        }

    //        if (lblTotalItem.Text != "")
    //        {
    //            Total_Item_Count = Convert.ToInt32(lblTotalItem.Text);
    //        }



    //        ResultId = ProductController.Insert_Update_Dispach(2, "", From_Location_Type_Code, From_Location_Code, To_Location_Type_Code
    //        , To_Location_Code, Dispatch_Date, Challan_No, Challan_Date, ContactPerson, ContactPersonNo, ContactPersonEmailId, Total_Item_Count
    //        , Total_Quantity, Total_Amount, 1, LogisticType_Code, LogisticDetails1, LogisticDetails2, IsActive, CreatedBy, "", "", "");


    //        if (ResultId == "")
    //        {

    //        }
    //        else if (ResultId == "-1")
    //        {
    //            Show_Error_Success_Box("E", "Record already exist");
    //        }
    //        else
    //        {
    //            foreach (DataListItem item in DataList2.Items)
    //            {
    //                if (item.ItemType == ListItemType.Item | item.ItemType == ListItemType.AlternatingItem)
    //                {

    //                    Label lblDispatch_Code = (Label)item.FindControl("lblDispatch_Code");
    //                    Label lblDispatchEntry_Code = (Label)item.FindControl("lblDispatchEntry_Code");
    //                    Label lblItem_Code_DT = (Label)item.FindControl("lblItem_Code_DT");
    //                    Label lblItemName_DT = (Label)item.FindControl("lblItemName_DT");
    //                    Label lblBarcode_DT = (Label)item.FindControl("lblBarcode_DT");
    //                    Label lblAssetNo_DT = (Label)item.FindControl("lblAssetNo_DT");
    //                    Label lblQty_DT = (Label)item.FindControl("lblQty_DT");
    //                    Label lblUnitPrice_DT = (Label)item.FindControl("lblUnitPrice_DT");
    //                    Label lblAmount_DT = (Label)item.FindControl("lblAmount_DT");
    //                    Label lblPkey_Code = (Label)item.FindControl("lblPkey_Code");

    //                    Label lblInward_Code = (Label)item.FindControl("lblInward_Code");
    //                    Label lblInwardEntry_Code_DL = (Label)item.FindControl("lblInwardEntry_Code_DL");
    //                    Label Inward_Qty = (Label)item.FindControl("Inward_Qty");

    //                    int iQty = Convert.ToInt32(Inward_Qty.Text);



    //                    string a = ProductController.Insert_Update_DispachItem(ResultId, lblItem_Code_DT.Text, lblAssetNo_DT.Text, Convert.ToInt32(lblQty_DT.Text), Convert.ToDecimal(lblUnitPrice_DT.Text), Convert.ToDecimal(lblAmount_DT.Text), lblInward_Code.Text.Trim(), lblInwardEntry_Code_DL.Text.Trim(), "", CreatedBy);

    //                    if (a != "1")
    //                    {
    //                        string b = ProductController.DispatchAuthorisation_ForFlat(ResultId, lblInward_Code.Text, lblItem_Code_DT.Text, lblInwardEntry_Code_DL.Text, a, lblBarcode_DT.Text, lblAssetNo_DT.Text, To_Location_Type_Code, To_Location_Code, From_Location_Type_Code, From_Location_Code, DateTime.Now, iQty, Convert.ToDecimal(lblUnitPrice_DT.Text), Convert.ToInt32(lblQty_DT.Text), Convert.ToDecimal(lblAmount_DT.Text), CreatedBy);

    //                    }

    //                }



    //            }
    //            string SendEmail = ProductController.Send_Email_Dispatch_Details(ResultId);

    //            ControlVisibility("Search");
    //            Show_Error_Success_Box("S", "Record save successfully");





    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Msg_Error.Visible = true;
    //        Msg_Success.Visible = false;
    //        lblerror.Text = ex.ToString();
    //        UpdatePanelMsgBox.Update();
    //        return;
    //    }

    //}


    //private void UpdateData()
    //{
    //    try
    //    {
    //        Clear_Error_Success_Box();

    //        Label lblHeader_User_Code = default(Label);
    //        lblHeader_User_Code = (Label)Master.FindControl("lblHeader_User_Code");

    //        string CreatedBy = null;
    //        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
    //        CreatedBy = cookie.Values["UserID"];

    //        string From_Location_Type_Code = "";
    //        string From_Location_Code = "";
    //        string To_Location_Type_Code = "";
    //        string To_Location_Code = "";
    //        DateTime Dispatch_Date = DateTime.Now;
    //        string Challan_No = "";
    //        DateTime Challan_Date;
    //        string ContactPerson = "";
    //        string ContactPersonNo = "";
    //        string ContactPersonEmailId = "";

    //        int Temp_Flag = 0;
    //        string LogisticType_Code = string.Empty;
    //        string LogisticDetails1 = string.Empty;
    //        string LogisticDetails2 = string.Empty;
    //        int IsActive = 1;

    //        string ResultId = "";

    //        int Total_Item_Count = 0;
    //        int Total_Quantity = 0;
    //        decimal Total_Amount = 0;

    //        From_Location_Type_Code = ddlTransferFR_Add.SelectedValue;
    //        To_Location_Type_Code = ddlTransferTO_Add.SelectedValue;

    //        if (ddlTransferFR_Add.SelectedItem.Text == "Godown")
    //        {
    //            From_Location_Code = ddlGodownFR_Add.SelectedValue;
    //        }
    //        else if (ddlTransferFR_Add.SelectedItem.Text == "Function")
    //        {
    //            From_Location_Code = ddlFunctionFR_Add.SelectedValue;
    //        }
    //        else if (ddlTransferFR_Add.SelectedItem.Text == "Center")
    //        {
    //            From_Location_Code = ddlCenterFR_Add.SelectedValue;
    //        }

    //        if (ddlTransferTO_Add.SelectedItem.Text == "Godown")
    //        {
    //            To_Location_Code = ddlGodownTO_Add.SelectedValue;
    //        }
    //        else if (ddlTransferTO_Add.SelectedItem.Text == "Function")
    //        {
    //            To_Location_Code = ddlFunctionTO_Add.SelectedValue;
    //        }
    //        else if (ddlTransferTO_Add.SelectedItem.Text == "Center")
    //        {
    //            To_Location_Code = ddlCenterTO_Add.SelectedValue;
    //        }

    //        Challan_No = txtChallanNo_Add.Text.Trim();
    //        Challan_Date = Convert.ToDateTime(txtChallanDate_Add.Text.Trim());
    //        ContactPerson = txtContactPerson_Add.Text.Trim();
    //        ContactPersonEmailId = txtEmail_Add.Text.Trim();
    //        ContactPersonNo = txtContact_Add.Text.Trim();
    //        LogisticType_Code = ddlLogisticType_Add.SelectedValue;



    //        if (ddlLogisticType_Add.SelectedItem.Text == "Courier")
    //        {
    //            LogisticDetails1 = txtLogisticDetails_Add.Text.Trim();
    //            LogisticDetails2 = txtPODNo_Add0.Text.Trim();
    //        }

    //        if (ddlLogisticType_Add.SelectedItem.Text == "Transport")
    //        {
    //            LogisticDetails1 = txtLogisticDetails_Add.Text.Trim();
    //            LogisticDetails2 = txtVechicleNo_Add.Text.Trim();
    //        }

    //        if (ddlLogisticType_Add.SelectedItem.Text == "In Person")
    //        {
    //            LogisticDetails1 = txtLogisticDetails_Add.Text.Trim();
    //            LogisticDetails2 = "";
    //        }


    //        if (lblTotal_Quantity.Text != "")
    //        {
    //            Total_Quantity = Convert.ToInt32(lblTotal_Quantity.Text);
    //        }

    //        if (lblTotal_Amount.Text != "")
    //        {
    //            Total_Amount = Convert.ToDecimal(lblTotal_Amount.Text);
    //        }

    //        if (lblTotalItem.Text != "")
    //        {
    //            Total_Item_Count = Convert.ToInt32(lblTotalItem.Text);
    //        }



    //        ResultId = ProductController.Insert_Update_Dispach(4, lblPkey.Text, From_Location_Type_Code, From_Location_Code, To_Location_Type_Code
    //        , To_Location_Code, Dispatch_Date, Challan_No, Challan_Date, ContactPerson, ContactPersonNo, ContactPersonEmailId, Total_Item_Count
    //        , Total_Quantity, Total_Amount, 1, LogisticType_Code, LogisticDetails1, LogisticDetails2, IsActive, CreatedBy, "", "", "");


    //        if (ResultId == "")
    //        {

    //        }
    //        else if (ResultId == "-1")
    //        {

    //        }
    //        else
    //        {


    //            string deleteItem = ProductController.Delete_Dispach_Item(3, lblPkey.Text);


    //            foreach (DataListItem item in DataList2.Items)
    //            {
    //                if (item.ItemType == ListItemType.Item | item.ItemType == ListItemType.AlternatingItem)
    //                {
    //                    Label lblDispatch_Code = (Label)item.FindControl("lblDispatch_Code");
    //                    Label lblDispatchEntry_Code = (Label)item.FindControl("lblDispatchEntry_Code");
    //                    Label lblItem_Code_DT = (Label)item.FindControl("lblItem_Code_DT");
    //                    Label lblItemName_DT = (Label)item.FindControl("lblItemName_DT");
    //                    Label lblBarcode_DT = (Label)item.FindControl("lblBarcode_DT");
    //                    Label lblAssetNo_DT = (Label)item.FindControl("lblAssetNo_DT");
    //                    Label lblQty_DT = (Label)item.FindControl("lblQty_DT");
    //                    Label lblUnitPrice_DT = (Label)item.FindControl("lblUnitPrice_DT");
    //                    Label lblAmount_DT = (Label)item.FindControl("lblAmount_DT");
    //                    Label lblPkey_Code = (Label)item.FindControl("lblPkey_Code");
    //                    Label lblInward_Code = (Label)item.FindControl("lblInward_Code");
    //                    Label lblInwardEntry_Code_DL = (Label)item.FindControl("lblInwardEntry_Code_DL");

    //                    Label Inward_Qty = (Label)item.FindControl("Inward_Qty");

    //                    int iQty = Convert.ToInt32(Inward_Qty.Text);


    //                    string a = ProductController.Insert_Update_DispachItem(lblPkey.Text, lblItem_Code_DT.Text, lblAssetNo_DT.Text, Convert.ToInt32(lblQty_DT.Text), Convert.ToDecimal(lblUnitPrice_DT.Text), Convert.ToDecimal(lblAmount_DT.Text), lblInward_Code.Text.Trim(), lblInwardEntry_Code_DL.Text.Trim(), lblDispatchEntry_Code.Text.Trim(), CreatedBy);

    //                    if (a != "1")
    //                    {
    //                        string b = ProductController.DispatchAuthorisation_ForFlat(lblPkey.Text, lblInward_Code.Text, lblItem_Code_DT.Text, lblInwardEntry_Code_DL.Text, a, lblBarcode_DT.Text, lblAssetNo_DT.Text, To_Location_Type_Code, To_Location_Code, From_Location_Type_Code, From_Location_Code, DateTime.Now, iQty, Convert.ToDecimal(lblUnitPrice_DT.Text), Convert.ToInt32(lblQty_DT.Text), Convert.ToDecimal(lblAmount_DT.Text), CreatedBy);
    //                    }

    //                }

    //            }

    //            ControlVisibility("Search");
    //            Show_Error_Success_Box("S", "Record updated successfully");

    //        }


    //    }
    //    catch (Exception ex)
    //    {
    //        Msg_Error.Visible = true;
    //        Msg_Success.Visible = false;
    //        lblerror.Text = ex.ToString();
    //        UpdatePanelMsgBox.Update();
    //        return;
    //    }

    //}

    #endregion

    #region Event's
    protected void BtnAdd_Click(object sender, EventArgs e)
    {

        BtnSearch_Click(this, e);
        ControlVisibility("Add");
        //ddlrequi_No.Enabled = true;
        lblvoucherno.Visible = false;
        txtRequestCode.Enabled = true;
        ClearAddPanel();
        ClearItemAdd();
        dlQuestion.DataSource = null;
        dlQuestion.DataBind();

        DataList2.DataSource = null;
        DataList2.DataBind();
        Clear_Error_Success_Box();
        txtChallanDate_Add.Text = DateTime.Now.ToString("dd-MMM-yyyy");
        txtChallanNo_Add.Text = ProductController.GetChallanNo();

        string opt = null;
        opt = Request.QueryString["OptionCode"];
        if (opt == "1")
        {
            forOption2.Visible = false;
            div_Teacher.Visible = false;
            div_student.Visible = false;
            div_Employee.Visible = false;
            DivForOP3.Visible = false;
        }
        else if (opt == "2")
        {
            forOption2.Visible = true;
            div_student.Visible = false;
            div_Employee.Visible = false;
            div_Teacher.Visible = false;
            DivForOP3.Visible = false;
            btnRequi_Search.Visible = true;
            //FillDDL_Requisition_No("", "", 4);
        }
        else if (opt == "3")
        {
            forOption2.Visible = true;
            div_student.Visible = false;
            div_Employee.Visible = false;
            div_Teacher.Visible = false;
            DivForOP3.Visible = false;
            btnRequi_Search.Visible = true;
            //FillDDL_Requisition_No("", "", 4);
        }
        else if (opt == "4")
        {
            forOption2.Visible = true;
            div_student.Visible = false;
            div_Employee.Visible = false;
            div_Teacher.Visible = false;
            DivForOP3.Visible = false;
            btnRequi_Search.Visible = true;
            //FillDDL_Requisition_No("", "", 4);
        }

    }

    protected void BtnShowSearchPanel_Click(object sender, EventArgs e)
    {
        ControlVisibility("Search");
        Clear_Error_Success_Box();
    }

    protected void BtnCloseAdd_Click(object sender, EventArgs e)
    {
        Clear_Error_Success_Box();

        DivSearchPanel.Visible = true;
        DivAddPanel.Visible = false;
        BtnAdd.Visible = false;
        //BtnSearch_Click(this, e);
        //ControlVisibility("Search");
        // Clear_Error_Success_Box();
    }


    //protected void BtnSaveAdd_Click(object sender, EventArgs e)
    //{
    //    Clear_Error_Success_Box();
    //    if (ddlGodownFR_Add.SelectedIndex != 0 && ddlGodownTO_Add.SelectedIndex != 0 && ddlGodownFR_Add.SelectedValue == ddlGodownTO_Add.SelectedValue)
    //    {
    //        Show_Error_Success_Box("E", "Godown Transfer From and To can't be same. ");
    //        return;
    //    }

    //    else if (ddlFunctionFR_Add.SelectedIndex != 0 && ddlFunctionTO_Add.SelectedIndex != 0 && ddlFunctionFR_Add.SelectedValue == ddlFunctionTO_Add.SelectedValue)
    //    {
    //        Show_Error_Success_Box("E", "Function Transfer From and To can't be same. ");
    //        return;
    //    }

    //    else if (ddlCenterFR_Add.SelectedIndex != -1 && ddlCenterTO_Add.SelectedIndex != -1 && ddlCenterFR_Add.SelectedIndex != 0 && ddlCenterTO_Add.SelectedIndex != 0 && ddlCenterFR_Add.SelectedValue == ddlCenterTO_Add.SelectedValue)
    //    {
    //        Show_Error_Success_Box("E", "Center Transfer From and To can't be same. ");
    //        return;
    //    }
    //    if (ControlValidation())
    //    {
    //        string opt = null;
    //        opt = Request.QueryString["OptionCode"];
    //        if (opt == "2")
    //        {
    //            if (txtRequestCode.Text == "")
    //            {
    //                Show_Error_Success_Box("E", "Enter Request Code");
    //                txtRequestCode.Focus();
    //                return;
    //            }




    //            else if (ddlGodownFR_Add.SelectedIndex != 0 && ddlGodownTO_Add.SelectedIndex != 0 && ddlGodownFR_Add.SelectedValue == ddlGodownTO_Add.SelectedValue)
    //            {
    //                Show_Error_Success_Box("E", "Godown Transfer From and To can't be same. ");
    //                return;
    //            }

    //            else if (ddlFunctionFR_Add.SelectedIndex != 0 && ddlFunctionTO_Add.SelectedIndex != 0 && ddlFunctionFR_Add.SelectedValue == ddlFunctionTO_Add.SelectedValue)
    //            {
    //                Show_Error_Success_Box("E", "Function Transfer From and To can't be same. ");
    //                return;
    //            }

    //            else if (ddlCenterFR_Add.SelectedIndex != -1 && ddlCenterTO_Add.SelectedIndex != -1 && ddlCenterFR_Add.SelectedIndex != 0 && ddlCenterTO_Add.SelectedIndex != 0 && ddlCenterFR_SR.SelectedValue == ddlCenterTO_SR.SelectedValue)
    //            {
    //                Show_Error_Success_Box("E", "Center Transfer From and To can't be same. ");
    //                return;
    //            }

    //            //For Student                
    //            if (lblusertypeCode.Text.Trim() == "UT001")
    //            {
    //                int TotalRecord = 0;
    //                foreach (DataListItem dtlItem in datalist_Student.Items)
    //                {
    //                    CheckBox chkCheck = (CheckBox)dtlItem.FindControl("chkCheck");

    //                    if (chkCheck.Checked == true)
    //                    {
    //                        TotalRecord = TotalRecord + 1;
    //                    }
    //                }
    //                if (TotalRecord == 0)
    //                {
    //                    Show_Error_Success_Box("E", "You have not Selected any Student");
    //                    return;
    //                }

    //                int Qty = 0;
    //                string item = "";
    //                foreach (DataListItem dtlItem in dlQuestion.Items)
    //                {
    //                    Label lblItem_Code_DT = (Label)dtlItem.FindControl("lblItem_Code_DT");
    //                    Label lblItemName_DT = (Label)dtlItem.FindControl("lblItemName_DT");
    //                    Label lblQty_DT = (Label)dtlItem.FindControl("lblQty_DT");

    //                    if (lblItem_Code_DT.Text.Trim() == lblItem_Code_DT.Text.Trim())
    //                    {
    //                        Qty = Qty + Convert.ToInt32(lblQty_DT.Text.Trim());
    //                    }

    //                    //}

    //                    item = lblItemName_DT.Text.Trim();

    //                }
    //                //if (TotalRecord != Qty)
    //                //{
    //                //    Show_Error_Success_Box("E", "Please Select Appropriate Quantity of Item Name ( " + item + " )");
    //                //    return;
    //                //}

    //                //SaveDataForOptionCode(lblusertypeCode.Text.Trim());
    //                if ((TotalRecord == Qty) || (Qty == 2 * TotalRecord))
    //                {

    //                    SaveDataForOptionCode(lblusertypeCode.Text.Trim());
    //                }
    //                else
    //                {
    //                    Show_Error_Success_Box("E", "Please Select Appropriate Quantity of Item Name ");
    //                    return;
    //                }
    //            }


    //            //For Teachers
    //            if (lblusertypeCode.Text.Trim() == "UT003")
    //            {
    //                int TotalRecord = 0;
    //                foreach (DataListItem dtlItem in datalist_Teacher.Items)
    //                {
    //                    CheckBox chkCheck = (CheckBox)dtlItem.FindControl("chkCheck");

    //                    if (chkCheck.Checked == true)
    //                    {
    //                        TotalRecord = TotalRecord + 1;
    //                    }
    //                }
    //                if (TotalRecord == 0)
    //                {
    //                    Show_Error_Success_Box("E", "You have not Selected any Teacher");
    //                    return;
    //                }
    //                int Qty = 0;
    //                string item = "";
    //                foreach (DataListItem dtlItem in dlQuestion.Items)
    //                {
    //                    Label lblItem_Code_DT = (Label)dtlItem.FindControl("lblItem_Code_DT");
    //                    Label lblItemName_DT = (Label)dtlItem.FindControl("lblItemName_DT");
    //                    Label lblQty_DT = (Label)dtlItem.FindControl("lblQty_DT");

    //                    if (lblItem_Code_DT.Text.Trim() == lblItem_Code_DT.Text.Trim())
    //                    {
    //                        Qty = Qty + Convert.ToInt32(lblQty_DT.Text.Trim());
    //                    }
    //                    item = lblItemName_DT.Text.Trim();

    //                }

    //                if (TotalRecord == Qty || TotalRecord == 2 * Qty)
    //                {

    //                    SaveDataForOptionCode(lblusertypeCode.Text.Trim());
    //                }
    //                else
    //                {
    //                    Show_Error_Success_Box("E", "Please Select Appropriate Quantity of Item Name ");
    //                    return;
    //                }
    //            }


    //            //For Employee
    //            if (lblusertypeCode.Text.Trim() == "UT004")
    //            {
    //                int TotalRecord = 1;
    //                int Qty = 0;
    //                string item = "";
    //                foreach (DataListItem dtlItem in dlQuestion.Items)
    //                {
    //                    Label lblItem_Code_DT = (Label)dtlItem.FindControl("lblItem_Code_DT");
    //                    Label lblItemName_DT = (Label)dtlItem.FindControl("lblItemName_DT");
    //                    Label lblQty_DT = (Label)dtlItem.FindControl("lblQty_DT");

    //                    //foreach (DataListItem dtlItem1 in dlQuestion.Items)
    //                    //{
    //                    //    Label lblItem_Code_DT1 = (Label)dtlItem1.FindControl("lblItem_Code_DT");
    //                    //    Label lblQty_DT = (Label)dtlItem1.FindControl("lblQty_DT");

    //                    if (lblItem_Code_DT.Text.Trim() == lblItem_Code_DT.Text.Trim())
    //                    {
    //                        Qty = Qty + Convert.ToInt32(lblQty_DT.Text.Trim());
    //                    }

    //                    // }
    //                    item = lblItemName_DT.Text.Trim();

    //                    //if (TotalRecord != Qty)
    //                    //{
    //                    //    Show_Error_Success_Box("E", "Please Select Appropriate Quantity of Item Name ( " + item + " )");
    //                    //    return;
    //                    //}

    //                }

    //                if ((TotalRecord == Qty) || (Qty == 2 * TotalRecord))
    //                {

    //                    SaveDataForOptionCode(lblusertypeCode.Text.Trim());
    //                }
    //                else
    //                {
    //                    Show_Error_Success_Box("E", "Please Select Appropriate Quantity of Item Name ");
    //                    return;
    //                }

    //            }

    //        }
    //        else if (opt == "3")
    //        {

    //            if (ddlGodownFR_Add.SelectedIndex != 0 && ddlGodownTO_Add.SelectedIndex != 0 && ddlGodownFR_Add.SelectedValue == ddlGodownTO_Add.SelectedValue)
    //            {
    //                Show_Error_Success_Box("E", "Godown Transfer From and To can't be same. ");
    //                return;
    //            }

    //            else if (ddlFunctionFR_Add.SelectedIndex != 0 && ddlFunctionTO_Add.SelectedIndex != 0 && ddlFunctionFR_Add.SelectedValue == ddlFunctionTO_Add.SelectedValue)
    //            {
    //                Show_Error_Success_Box("E", "Function Transfer From and To can't be same. ");
    //                return;
    //            }

    //            else if (ddlCenterFR_Add.SelectedIndex != -1 && ddlCenterTO_Add.SelectedIndex != -1 && ddlCenterFR_Add.SelectedIndex != 0 && ddlCenterTO_Add.SelectedIndex != 0 && ddlCenterFR_SR.SelectedValue == ddlCenterTO_SR.SelectedValue)
    //            {
    //                Show_Error_Success_Box("E", "Center Transfer From and To can't be same. ");
    //                return;
    //            }
    //            if (txtRequestCode.Text == "")
    //            {
    //                Show_Error_Success_Box("E", "Enter Request Code");
    //                txtRequestCode.Focus();
    //                return;
    //            }

    //            //DTOP3

    //            int TotalRecord = 0;
    //            foreach (DataListItem dtlItem in DTOP3.Items)
    //            {
    //                CheckBox chkCheck = (CheckBox)dtlItem.FindControl("chkCheck");

    //                if (chkCheck.Checked == true)
    //                {
    //                    TotalRecord = TotalRecord + 1;
    //                }
    //            }
    //            if (TotalRecord == 0)
    //            {
    //                Show_Error_Success_Box("E", "You have not Selected any Item");
    //                return;
    //            }

    //            SaveDataForOptionCode(lblusertypeCode.Text.Trim());
    //        }
    //        else if (opt == "4")
    //        {

    //            if (ddlGodownFR_Add.SelectedIndex != 0 && ddlGodownTO_Add.SelectedIndex != 0 && ddlGodownFR_Add.SelectedValue == ddlGodownTO_Add.SelectedValue)
    //            {
    //                Show_Error_Success_Box("E", "Godown Transfer From and To can't be same. ");
    //                return;
    //            }

    //            else if (ddlFunctionFR_Add.SelectedIndex != 0 && ddlFunctionTO_Add.SelectedIndex != 0 && ddlFunctionFR_Add.SelectedValue == ddlFunctionTO_Add.SelectedValue)
    //            {
    //                Show_Error_Success_Box("E", "Function Transfer From and To can't be same. ");
    //                return;
    //            }

    //            else if (ddlCenterFR_Add.SelectedIndex != -1 && ddlCenterTO_Add.SelectedIndex != -1 && ddlCenterFR_Add.SelectedIndex != 0 && ddlCenterTO_Add.SelectedIndex != 0 && ddlCenterFR_SR.SelectedValue == ddlCenterTO_SR.SelectedValue)
    //            {
    //                Show_Error_Success_Box("E", "Center Transfer From and To can't be same. ");
    //                return;
    //            }
    //            if (txtRequestCode.Text == "")
    //            {
    //                Show_Error_Success_Box("E", "Enter Request Code");
    //                txtRequestCode.Focus();
    //                return;
    //            }

    //            //DTOP3

    //            int TotalRecord = 0;
    //            foreach (DataListItem dtlItem in DTOP3.Items)
    //            {
    //                CheckBox chkCheck = (CheckBox)dtlItem.FindControl("chkCheck");

    //                if (chkCheck.Checked == true)
    //                {
    //                    TotalRecord = TotalRecord + 1;
    //                }
    //            }
    //            if (TotalRecord == 0)
    //            {
    //                Show_Error_Success_Box("E", "You have not Selected any Item");
    //                return;
    //            }

    //            SaveDataForOptionCode(lblusertypeCode.Text.Trim());
    //        }
    //        else
    //        {
    //            SaveData();
    //        }

    //    }

    //}

    //private void SaveDataForOptionCode(string UserType)
    //{
    //    try
    //    {
    //        Clear_Error_Success_Box();

    //        Label lblHeader_User_Code = default(Label);
    //        lblHeader_User_Code = (Label)Master.FindControl("lblHeader_User_Code");

    //        string CreatedBy = null;
    //        CreatedBy = lblHeader_User_Code.Text;

    //        string From_Location_Type_Code = "";
    //        string From_Location_Code = "";
    //        string To_Location_Type_Code = "";
    //        string To_Location_Code = "";
    //        DateTime Dispatch_Date = DateTime.Now;
    //        string Challan_No = "";
    //        DateTime Challan_Date;
    //        string ContactPerson = "";
    //        string ContactPersonNo = "";
    //        string ContactPersonEmailId = "";

    //        int Temp_Flag = 0;
    //        string LogisticType_Code = string.Empty;
    //        string LogisticDetails1 = string.Empty;
    //        string LogisticDetails2 = string.Empty;
    //        int IsActive = 1;

    //        string ResultId = "";

    //        int Total_Item_Count = 0;
    //        int Total_Quantity = 0;
    //        decimal Total_Amount = 0;

    //        From_Location_Type_Code = ddlTransferFR_Add.SelectedValue;
    //        To_Location_Type_Code = ddlTransferTO_Add.SelectedValue;

    //        if (ddlTransferFR_Add.SelectedItem.Text == "Godown")
    //        {
    //            From_Location_Code = ddlGodownFR_Add.SelectedValue;
    //        }
    //        else if (ddlTransferFR_Add.SelectedItem.Text == "Function")
    //        {
    //            From_Location_Code = ddlFunctionFR_Add.SelectedValue;
    //        }
    //        else if (ddlTransferFR_Add.SelectedItem.Text == "Center")
    //        {
    //            From_Location_Code = ddlCenterFR_Add.SelectedValue;
    //        }

    //        if (ddlTransferTO_Add.SelectedItem.Text == "Godown")
    //        {
    //            To_Location_Code = ddlGodownTO_Add.SelectedValue;
    //        }
    //        else if (ddlTransferTO_Add.SelectedItem.Text == "Function")
    //        {
    //            To_Location_Code = ddlFunctionTO_Add.SelectedValue;
    //        }
    //        else if (ddlTransferTO_Add.SelectedItem.Text == "Center")
    //        {
    //            To_Location_Code = ddlCenterTO_Add.SelectedValue;
    //        }

    //        Challan_No = txtChallanNo_Add.Text.Trim();
    //        Challan_Date = Convert.ToDateTime(txtChallanDate_Add.Text.Trim());
    //        ContactPerson = txtContactPerson_Add.Text.Trim();
    //        ContactPersonEmailId = txtEmail_Add.Text.Trim();
    //        ContactPersonNo = txtContact_Add.Text.Trim();
    //        LogisticType_Code = ddlLogisticType_Add.SelectedValue;



    //        if (ddlLogisticType_Add.SelectedItem.Text == "Courier")
    //        {
    //            LogisticDetails1 = txtLogisticDetails_Add.Text.Trim();
    //            LogisticDetails2 = txtPODNo_Add0.Text.Trim();
    //        }

    //        if (ddlLogisticType_Add.SelectedItem.Text == "Transport")
    //        {
    //            LogisticDetails1 = txtLogisticDetails_Add.Text.Trim();
    //            LogisticDetails2 = txtVechicleNo_Add.Text.Trim();
    //        }

    //        if (ddlLogisticType_Add.SelectedItem.Text == "In Person")
    //        {
    //            LogisticDetails1 = txtLogisticDetails_Add.Text.Trim();
    //            LogisticDetails2 = "";
    //        }


    //        if (lblTotal_Quantity.Text != "")
    //        {
    //            Total_Quantity = Convert.ToInt32(lblTotal_Quantity.Text);
    //        }

    //        if (lblTotal_Amount.Text != "")
    //        {
    //            Total_Amount = Convert.ToDecimal(lblTotal_Amount.Text);
    //        }

    //        if (lblTotalItem.Text != "")
    //        {
    //            Total_Item_Count = Convert.ToInt32(lblTotalItem.Text);
    //        }

    //        string opt = null;
    //        opt = Request.QueryString["OptionCode"];
    //        int TotalIems = 0;
    //        if (opt == "3" || opt == "4")
    //        {
    //            foreach (DataListItem dtlItem in DTOP3.Items)
    //            {

    //                CheckBox chkCheck = (CheckBox)dtlItem.FindControl("chkCheck");

    //                if (chkCheck.Checked == true)
    //                {
    //                    TotalIems = TotalIems + 1;
    //                }

    //            }

    //            Total_Item_Count = TotalIems;
    //            Total_Quantity = TotalIems;
    //            Total_Amount = 0;
    //        }

    //        ResultId = ProductController.Insert_Update_Dispach(2, "", From_Location_Type_Code, From_Location_Code, To_Location_Type_Code
    //        , To_Location_Code, Dispatch_Date, Challan_No, Challan_Date, ContactPerson, ContactPersonNo, ContactPersonEmailId, Total_Item_Count
    //        , Total_Quantity, Total_Amount, 1, LogisticType_Code, LogisticDetails1, LogisticDetails2, IsActive, CreatedBy, txtRequestCode.Text.Trim(), opt, "");


    //        if (ResultId == "")
    //        {

    //        }
    //        else if (ResultId == "-1")
    //        {
    //            Show_Error_Success_Box("E", "Record already exist");
    //            return;
    //        }
    //        else
    //        {
    //            int TotalRecord = 0;

    //            if (opt == "2")
    //            {
    //                if (UserType == "UT001")
    //                {
    //                    foreach (DataListItem dtlItem in datalist_Student.Items)
    //                    {
    //                        CheckBox chkCheck = (CheckBox)dtlItem.FindControl("chkCheck");

    //                        if (chkCheck.Checked == true)
    //                        {
    //                            TotalRecord = TotalRecord + 1;
    //                        }
    //                    }
    //                    if (TotalRecord == 0)
    //                    {
    //                        Show_Error_Success_Box("E", "You have not Selected any Student");
    //                        return;
    //                    }
    //                }

    //                if (UserType == "UT003")
    //                {
    //                    foreach (DataListItem dtlItem in datalist_Teacher.Items)
    //                    {
    //                        CheckBox chkCheck = (CheckBox)dtlItem.FindControl("chkCheck");

    //                        if (chkCheck.Checked == true)
    //                        {
    //                            TotalRecord = TotalRecord + 1;
    //                        }
    //                    }
    //                    if (TotalRecord == 0)
    //                    {
    //                        Show_Error_Success_Box("E", "You have not Selected any Teacher");
    //                        return;
    //                    }
    //                }

    //                if (UserType == "UT004")
    //                {
    //                    TotalRecord = 1;
    //                }
    //                int Qty = 0;
    //                string Materil = "";
    //                foreach (DataListItem dtlItem in DataList2.Items)
    //                {
    //                    Label lblItem_Code_DT = (Label)dtlItem.FindControl("lblItem_Code_DT");
    //                    Label lblItemName_DT = (Label)dtlItem.FindControl("lblItemName_DT");
    //                    Label lblQty_DT = (Label)dtlItem.FindControl("lblQty_DT");

    //                    // foreach (DataListItem dtlItem1 in dlQuestion.Items)
    //                    // {
    //                    // Label lblItem_Code_DT1 = (Label)dtlItem1.FindControl("lblItem_Code_DT");
    //                    // Label lblQty_DT = (Label)dtlItem1.FindControl("lblQty_DT");

    //                    if (lblItem_Code_DT.Text.Trim() == lblItem_Code_DT.Text.Trim())
    //                    {
    //                        Qty = Qty + Convert.ToInt32(lblQty_DT.Text.Trim());
    //                    }
    //                    Materil = lblItemName_DT.Text.Trim();

    //                }

    //                string ResultOP3 = "";
    //                foreach (DataListItem item in DataList2.Items)
    //                {
    //                    if (item.ItemType == ListItemType.Item | item.ItemType == ListItemType.AlternatingItem)
    //                    {

    //                        Label lblDispatch_Code = (Label)item.FindControl("lblDispatch_Code");
    //                        Label lblDispatchEntry_Code = (Label)item.FindControl("lblDispatchEntry_Code");
    //                        Label lblItem_Code_DT = (Label)item.FindControl("lblItem_Code_DT");
    //                        Label lblItemName_DT = (Label)item.FindControl("lblItemName_DT");
    //                        Label lblBarcode_DT = (Label)item.FindControl("lblBarcode_DT");
    //                        Label lblAssetNo_DT = (Label)item.FindControl("lblAssetNo_DT");
    //                        Label lblQty_DT = (Label)item.FindControl("lblQty_DT");
    //                        Label lblUnitPrice_DT = (Label)item.FindControl("lblUnitPrice_DT");
    //                        Label lblAmount_DT = (Label)item.FindControl("lblAmount_DT");
    //                        Label lblPkey_Code = (Label)item.FindControl("lblPkey_Code");

    //                        Label lblInward_Code = (Label)item.FindControl("lblInward_Code");
    //                        Label lblInwardEntry_Code_DL = (Label)item.FindControl("lblInwardEntry_Code_DL");
    //                        Label Inward_Qty = (Label)item.FindControl("Inward_Qty");
    //                        Label lblRequestEntry_Code_Grid = (Label)item.FindControl("lblRequestEntry_Code_Grid");

    //                        int iQty = Convert.ToInt32(Inward_Qty.Text);


    //                        string a = ProductController.Insert_Update_DispachItem(ResultId, lblItem_Code_DT.Text, lblAssetNo_DT.Text, Convert.ToInt32(lblQty_DT.Text), Convert.ToDecimal(lblUnitPrice_DT.Text), Convert.ToDecimal(lblAmount_DT.Text), lblInward_Code.Text.Trim(), lblInwardEntry_Code_DL.Text.Trim(), "", CreatedBy);

    //                        if (a != "1")
    //                        {
    //                            string b = ProductController.DispatchAuthorisation_ForFlat(ResultId, lblInward_Code.Text, lblItem_Code_DT.Text, lblInwardEntry_Code_DL.Text, a, lblBarcode_DT.Text, lblAssetNo_DT.Text, To_Location_Type_Code, To_Location_Code, From_Location_Type_Code, From_Location_Code, DateTime.Now, iQty, Convert.ToDecimal(lblUnitPrice_DT.Text), Convert.ToInt32(lblQty_DT.Text), Convert.ToDecimal(lblAmount_DT.Text), CreatedBy);

    //                            //if (opt == "3")
    //                            //{
    //                            //    ResultOP3 = ProductController.Insert_DispatchEntry_ReuestEntry_COdeOP3(1, ResultId, a, txtRequestCode.Text.Trim(), lblRequestEntry_Code_Grid.Text.Trim());
    //                            //}
    //                        }


    //                    }

    //                }

    //                string FinResultID = "";
    //                if (opt == "2")
    //                {
    //                    string RequestEntry_Code = "";


    //                    if (UserType == "UT001")
    //                    {
    //                        foreach (DataListItem item in datalist_Student.Items)
    //                        {
    //                            if (item.ItemType == ListItemType.Item | item.ItemType == ListItemType.AlternatingItem)
    //                            {
    //                                CheckBox chkCheck = (CheckBox)item.FindControl("chkCheck");

    //                                if (chkCheck.Checked == true)
    //                                {
    //                                    Label Request_Code = (Label)item.FindControl("lblrequCode");
    //                                    Label Request_EntryCode = (Label)item.FindControl("Request_EntryCode");

    //                                    string REBind = Request_Code.Text.Trim() + "%" + Request_EntryCode.Text.Trim();
    //                                    RequestEntry_Code = RequestEntry_Code + REBind + ",";
    //                                    //FinResultID = ProductController.Insert_DispatchEntry_ReuestEntry_COde(1, ResultId, RequestEntry_Code);
    //                                }

    //                            }

    //                        }

    //                        RequestEntry_Code = Common.RemoveComma(RequestEntry_Code);

    //                        FinResultID = ProductController.Insert_DispatchEntry_ReuestEntry_COde(1, ResultId, RequestEntry_Code);

    //                    }

    //                    else if (UserType == "UT003")
    //                    {
    //                        foreach (DataListItem item in datalist_Teacher.Items)
    //                        {
    //                            if (item.ItemType == ListItemType.Item | item.ItemType == ListItemType.AlternatingItem)
    //                            {
    //                                CheckBox chkCheck = (CheckBox)item.FindControl("chkCheck");

    //                                if (chkCheck.Checked == true)
    //                                {
    //                                    Label Request_Code = (Label)item.FindControl("lblrequCode_TH");
    //                                    Label Request_EntryCode = (Label)item.FindControl("Request_EntryCode_TH");

    //                                    string REBind = Request_Code.Text.Trim() + "%" + Request_EntryCode.Text.Trim();
    //                                    RequestEntry_Code = RequestEntry_Code + REBind + ",";
    //                                }

    //                            }

    //                        }

    //                        RequestEntry_Code = Common.RemoveComma(RequestEntry_Code);

    //                        FinResultID = ProductController.Insert_DispatchEntry_ReuestEntry_COde(1, ResultId, RequestEntry_Code);
    //                    }

    //                    else if (UserType == "UT004")
    //                    {
    //                        string REBind = lblRequ_CodeforEmp.Text.Trim() + "%" + lblRequ_EntryCodeforEMP.Text.Trim();

    //                        RequestEntry_Code = Common.RemoveComma(REBind);

    //                        FinResultID = ProductController.Insert_DispatchEntry_ReuestEntry_COde(1, ResultId, RequestEntry_Code);
    //                    }
    //                }



    //                if (FinResultID == "1" || ResultOP3 == "1")
    //                {
    //                    ControlVisibility("Search");
    //                    Show_Error_Success_Box("S", "Record save successfully");
    //                }
    //                else if (FinResultID == "0" || ResultOP3 == "0")
    //                {
    //                    Show_Error_Success_Box("E", "Error occured during save..");
    //                }

    //            }
    //            else if (opt == "3")
    //            {
    //                string Resultop4 = "";
    //                lblvoucher.Visible = true;
    //                foreach (DataListItem item in DTOP3.Items)
    //                {
    //                    if (item.ItemType == ListItemType.Item | item.ItemType == ListItemType.AlternatingItem)
    //                    {

    //                        Label lblItem_Code_DT = (Label)item.FindControl("lblItem_Code_DT");
    //                        Label lblAssetNo_DT = (Label)item.FindControl("lblAssetNo_DT");
    //                        Label lblQty_DT = (Label)item.FindControl("lblQty_DT");
    //                        Label lblInward_Code = (Label)item.FindControl("lblInward_Code");
    //                        Label lblInwardEntry_Code_DL = (Label)item.FindControl("lblInwardEntry_Code_DL");
    //                        Label lblEANNo_DT = (Label)item.FindControl("lblEANNo_DT");
    //                        Label lblRequestEntry_Code_Grid = (Label)item.FindControl("lblRequestEntry_Code_Grid");

    //                        int iQty = 0;
    //                        CheckBox chkCheck = (CheckBox)item.FindControl("chkCheck");

    //                        if (chkCheck.Checked == true)
    //                        {
    //                            iQty = Convert.ToInt32(lblQty_DT.Text);
    //                        }
    //                        else
    //                        {
    //                            iQty = 0;
    //                        }



    //                        string a = ProductController.Insert_Update_DispachItem(ResultId, lblItem_Code_DT.Text, lblAssetNo_DT.Text, iQty, 0, 0, lblInward_Code.Text.Trim(), lblInwardEntry_Code_DL.Text.Trim(), "", CreatedBy);

    //                        if (a != "1")
    //                        {
    //                            string b = ProductController.DispatchAuthorisation_ForFlat(ResultId, lblInward_Code.Text, lblItem_Code_DT.Text, lblInwardEntry_Code_DL.Text, a, lblEANNo_DT.Text, lblAssetNo_DT.Text, To_Location_Type_Code, To_Location_Code, From_Location_Type_Code, From_Location_Code, DateTime.Now, iQty, 0, iQty, 0, CreatedBy);

    //                            Resultop4 = ProductController.Insert_DispatchEntry_ReuestEntry_COdeOP3(1, ResultId, a, txtRequestCode.Text.Trim(), lblRequestEntry_Code_Grid.Text.Trim());

    //                        }


    //                    }

    //                }

    //                if (Resultop4 == "1")
    //                {
    //                    ControlVisibility("Search");
    //                    Show_Error_Success_Box("S", "Record save successfully");
    //                }
    //                else if (Resultop4 == "0")
    //                {
    //                    Show_Error_Success_Box("E", "Error occured during save..");
    //                }
    //            }
    //            else if (opt == "4")
    //            {
    //                string Resultop4 = "";
    //                lblvoucher.Visible = true;
    //                foreach (DataListItem item in DTOP3.Items)
    //                {
    //                    if (item.ItemType == ListItemType.Item | item.ItemType == ListItemType.AlternatingItem)
    //                    {

    //                        Label lblItem_Code_DT = (Label)item.FindControl("lblItem_Code_DT");
    //                        Label lblAssetNo_DT = (Label)item.FindControl("lblAssetNo_DT");
    //                        Label lblQty_DT = (Label)item.FindControl("lblQty_DT");
    //                        Label lblInward_Code = (Label)item.FindControl("lblInward_Code");
    //                        Label lblInwardEntry_Code_DL = (Label)item.FindControl("lblInwardEntry_Code_DL");
    //                        Label lblEANNo_DT = (Label)item.FindControl("lblEANNo_DT");
    //                        Label lblRequestEntry_Code_Grid = (Label)item.FindControl("lblRequestEntry_Code_Grid");

    //                        int iQty = 0;
    //                        CheckBox chkCheck = (CheckBox)item.FindControl("chkCheck");

    //                        if (chkCheck.Checked == true)
    //                        {
    //                            iQty = Convert.ToInt32(lblQty_DT.Text);
    //                        }
    //                        else
    //                        {
    //                            iQty = 0;
    //                        }



    //                        string a = ProductController.Insert_Update_DispachItem(ResultId, lblItem_Code_DT.Text, lblAssetNo_DT.Text, iQty, 0, 0, lblInward_Code.Text.Trim(), lblInwardEntry_Code_DL.Text.Trim(), "", CreatedBy);

    //                        if (a != "1")
    //                        {
    //                            string b = ProductController.DispatchAuthorisation_ForFlat(ResultId, lblInward_Code.Text, lblItem_Code_DT.Text, lblInwardEntry_Code_DL.Text, a, lblEANNo_DT.Text, lblAssetNo_DT.Text, To_Location_Type_Code, To_Location_Code, From_Location_Type_Code, From_Location_Code, DateTime.Now, iQty, 0, iQty, 0, CreatedBy);

    //                            Resultop4 = ProductController.Insert_DispatchEntry_ReuestEntry_COdeOP3(1, ResultId, a, txtRequestCode.Text.Trim(), lblRequestEntry_Code_Grid.Text.Trim());

    //                        }


    //                    }

    //                }

    //                if (Resultop4 == "1")
    //                {
    //                    ControlVisibility("Search");
    //                    Show_Error_Success_Box("S", "Record save successfully");
    //                }
    //                else if (Resultop4 == "0")
    //                {
    //                    Show_Error_Success_Box("E", "Error occured during save..");
    //                }
    //            }

    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Msg_Error.Visible = true;
    //        Msg_Success.Visible = false;
    //        lblerror.Text = ex.ToString();
    //        UpdatePanelMsgBox.Update();
    //        return;
    //    }


    //}

    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        Clear_Error_Success_Box();

        if (ddlTransferFR_SR.SelectedValue == "Select Transfer From")
        {
            Show_Error_Success_Box("E", "Select Transfer From");
            ddlTransferFR_SR.Focus();
            return;

        }

        else if (ddlTransferTO_SR.SelectedValue == "Select Transfer To")
        {
            Show_Error_Success_Box("E", "Select Transfer To");
            ddlTransferTO_SR.Focus();
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


         //---------------
        else if (ddlTransferTO_SR.SelectedItem.Text == "Godown" && ddlgodownTO_SR.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "Select Transfer To Godown");
            ddlTransferTO_SR.Focus();
            return;
        }

        else if (ddlTransferTO_SR.SelectedItem.Text == "Function" && ddlFunctionTO_SR.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "Select Transfer To Function");
            ddlTransferTO_SR.Focus();
            return;
        }
        else if (ddlTransferTO_SR.SelectedItem.Text == "Center" && ddlDivisionTO_SR.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "Select Transfer To Division");
            ddlTransferTO_SR.Focus();
            return;
        }
        else if (ddlTransferTO_SR.SelectedItem.Text == "Center" && ddlCenterTO_SR.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "Select Transfer To Center");
            ddlTransferTO_SR.Focus();
            return;
        }
        else if (ddlDivisionFR_Add.SelectedIndex != 0 && ddlCenterTO_SR.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "Select Transfer To Center");
            ddlCenterTO_SR.Focus();
            return;
        }




         //----------------------------



        else if (ddlgodownFR_SR.SelectedIndex != 0 && ddlgodownTO_SR.SelectedIndex != 0 && ddlgodownFR_SR.SelectedValue == ddlgodownTO_SR.SelectedValue)
        {
            Show_Error_Success_Box("E", "Godown Transfer From and To can't be same. ");
            return;
        }

        else if (ddlFunctionFR_SR.SelectedIndex != 0 && ddlFunctionTO_SR.SelectedIndex != 0 && ddlFunctionTO_SR.SelectedValue == ddlFunctionFR_SR.SelectedValue)
        {
            Show_Error_Success_Box("E", "Function Transfer From and To can't be same. ");
            return;
        }

        else if (ddlCenterFR_SR.SelectedIndex != -1 && ddlCenterTO_SR.SelectedIndex != -1 && ddlCenterFR_SR.SelectedIndex != 0 && ddlCenterTO_SR.SelectedIndex != 0 && ddlCenterFR_SR.SelectedValue == ddlCenterTO_SR.SelectedValue)
        {
            Show_Error_Success_Box("E", "Center Transfer From and To can't be same. ");
            return;
        }

        else if (date_range_SR.Value == "")
        {
            Show_Error_Success_Box("E", "Select date range ");
            return;
        }



        string FromDate, ToDate;
        string From_Location_Type_Code = "";
        string From_Location_Code = "";
        string To_Location_Type_Code = "";
        string To_Location_Code = "";
        string Challan_No = "";
        if (date_range_SR.Value == "")
        {
            FromDate = "";
            ToDate = "";
        }
        else
        {
            string DateRange = "";
            DateRange = date_range_SR.Value;

            FromDate = DateRange.Substring(0, 10);
            ToDate = (DateRange.Length > 9) ? DateRange.Substring(DateRange.Length - 10, 10) : DateRange;
        }

        From_Location_Type_Code = ddlTransferFR_SR.SelectedValue;
        To_Location_Type_Code = ddlTransferTO_SR.SelectedValue;

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

        if (ddlTransferTO_SR.SelectedItem.Text == "Godown")
        {
            To_Location_Code = ddlgodownTO_SR.SelectedValue;
        }
        else if (ddlTransferTO_SR.SelectedItem.Text == "Function")
        {
            To_Location_Code = ddlFunctionTO_SR.SelectedValue;
        }
        else if (ddlTransferTO_SR.SelectedItem.Text == "Center")
        {
            To_Location_Code = ddlCenterTO_SR.SelectedValue;
        }

        Challan_No = txtChallan_SR.Text.Trim();

        DataSet ds;

        string opt = Request.QueryString["OptionCode"];
        if (opt == "2" || opt == "3" || opt == "4")
        {
            ds = ProductController.Get_Dispatch_Item_For_Old_challan(15, Challan_No, From_Location_Type_Code, From_Location_Code, To_Location_Code, To_Location_Type_Code, FromDate, ToDate);
        }
        else
        {
            ds = ProductController.Get_Dispatch_Item_For_Old_challan(5, Challan_No, From_Location_Type_Code, From_Location_Code, To_Location_Code, To_Location_Type_Code, FromDate, ToDate);
        }



        ControlVisibility("Result");
        if (ds != null)
        {
            if (ds.Tables.Count != 0)
            {
                if (ds.Tables[0].Rows.Count != 0)
                {
                    dlGridDisplay.DataSource = ds;
                    dlGridDisplay.DataBind();

                    DataList1.DataSource = ds;
                    DataList1.DataBind();
                    //BtnSaveAdd.Visible = true;

                    if (opt == "2")
                    {
                        foreach (RepeaterItem dtlItem in dlGridDisplay.Items)
                        {
                            LinkButton btnPrint = (LinkButton)dtlItem.FindControl("btnPrint");
                            btnPrint.Visible = false;
                        }
                    }
                }
                else
                {
                    dlGridDisplay.DataSource = null;
                    dlGridDisplay.DataBind();

                    DataList1.DataSource = ds;
                    DataList1.DataBind();
                    //BtnSaveAdd.Visible = true;
                }

            }
            else
            {
                dlGridDisplay.DataSource = null;
                dlGridDisplay.DataBind();

                DataList1.DataSource = null;
                DataList1.DataBind();
                //BtnSaveAdd.Visible = true;

            }

        }
        else
        {
            dlGridDisplay.DataSource = null; ;
            dlGridDisplay.DataBind();

            DataList1.DataSource = null;
            DataList1.DataBind();
            //BtnSaveAdd.Visible = true;
        }
        if (ds != null)
        {
            if (ds.Tables.Count != 0)
            {
                if (ds.Tables[0].Rows.Count != 0)
                {
                    lbltotalcount.Text = (ds.Tables[0].Rows.Count).ToString();
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

    protected void BtnClearSearch_Click(object sender, EventArgs e)
    {
        ClearSearchPanel();
    }

    protected void btnEditSave_Click(object sender, EventArgs e)
    {
       // UpdateData();
    }
    #endregion
    //private void NewPageLoad(string option)
    //{

    //    //string option="";
    //    if (option == "1")
    //    {
    //        Response.Redirect("Manage_Dispatch.aspx?OptionCode=" + option);
    //    }
    //    else if (option == "2")
    //    {
    //        Response.Redirect("Manage_Dispatch.aspx?OptionCode=" + option);
    //    }
    //    else if (option == "3")
    //    {
    //        Response.Redirect("Manage_Dispatch.aspx?OptionCode=" + option);
    //    }
    //    else if (option == "4")
    //    {
    //        Response.Redirect("Manage_Dispatch.aspx?OptionCode=" + option);
    //    }
    //}
    //protected void BtnSaveEdit_Click(object sender, EventArgs e)
    //{
    //    if (ControlValidation())
    //    {
    //        string opt = null;
    //        opt = Request.QueryString["OptionCode"];
    //        if (opt == "2")
    //        {
    //            if (txtRequestCode.Text == "")
    //            {
    //                Show_Error_Success_Box("E", "Enter Request Code");
    //                txtRequestCode.Focus();
    //                return;
    //            }

    //            //For Student                
    //            if (lblusertypeCode.Text.Trim() == "UT001")
    //            {
    //                int TotalRecord = 0;
    //                foreach (DataListItem dtlItem in datalist_Student.Items)
    //                {
    //                    CheckBox chkCheck = (CheckBox)dtlItem.FindControl("chkCheck");

    //                    if (chkCheck.Checked == true)
    //                    {
    //                        TotalRecord = TotalRecord + 1;
    //                    }
    //                }
    //                if (TotalRecord == 0)
    //                {
    //                    Show_Error_Success_Box("E", "You have not Selected any Student");
    //                    return;
    //                }

    //                int Qty = 0;
    //                string item = "";
    //                foreach (DataListItem dtlItem in dlQuestion.Items)
    //                {
    //                    Label lblItem_Code_DT = (Label)dtlItem.FindControl("lblItem_Code_DT");
    //                    Label lblItemName_DT = (Label)dtlItem.FindControl("lblItemName_DT");
    //                    Label lblQty_DT = (Label)dtlItem.FindControl("lblQty_DT");

    //                    //foreach (DataListItem dtlItem1 in dlQuestion.Items)
    //                    //{
    //                    //    Label lblItem_Code_DT1 = (Label)dtlItem1.FindControl("lblItem_Code_DT");
    //                    //    Label lblQty_DT = (Label)dtlItem1.FindControl("lblQty_DT");

    //                    if (lblItem_Code_DT.Text.Trim() == lblItem_Code_DT.Text.Trim())
    //                    {
    //                        Qty = Qty + Convert.ToInt32(lblQty_DT.Text.Trim());
    //                    }

    //                    //}

    //                    item = lblItemName_DT.Text.Trim();

    //                }
    //                //if (TotalRecord != Qty)
    //                //{
    //                //    Show_Error_Success_Box("E", "Please Select Appropriate Quantity of Item Name ( " + item + " )");
    //                //    return;
    //                //}
    //                if ((TotalRecord == Qty) || (Qty == 2 * TotalRecord))
    //                {

    //                    UpdateDataForOptionCode(lblusertypeCode.Text.Trim());
    //                }
    //                else
    //                {
    //                    Show_Error_Success_Box("E", "Please Select Appropriate Quantity of Item Name ");
    //                    return;
    //                }


    //            }


    //            //For Teachers
    //            if (lblusertypeCode.Text.Trim() == "UT003")
    //            {
    //                int TotalRecord = 0;
    //                int Qty = 0;
    //                foreach (DataListItem dtlItem in datalist_Teacher.Items)
    //                {
    //                    CheckBox chkCheck = (CheckBox)dtlItem.FindControl("chkCheck");

    //                    if (chkCheck.Checked == true)
    //                    {
    //                        TotalRecord = TotalRecord + 1;
    //                    }
    //                }
    //                if (TotalRecord == 0)
    //                {
    //                    Show_Error_Success_Box("E", "You have not Selected any Teacher");
    //                    return;
    //                }

    //                foreach (DataListItem dtlItem in dlQuestion.Items)
    //                {
    //                    Label lblItem_Code_DT = (Label)dtlItem.FindControl("lblItem_Code_DT");
    //                    Label lblItemName_DT = (Label)dtlItem.FindControl("lblItemName_DT");

    //                    foreach (DataListItem dtlItem1 in dlQuestion.Items)
    //                    {
    //                        Label lblItem_Code_DT1 = (Label)dtlItem1.FindControl("lblItem_Code_DT");
    //                        Label lblQty_DT = (Label)dtlItem1.FindControl("lblQty_DT");

    //                        if (lblItem_Code_DT.Text.Trim() == lblItem_Code_DT1.Text.Trim())
    //                        {
    //                            Qty = Qty + Convert.ToInt32(lblQty_DT.Text.Trim());
    //                        }

    //                    }

    //                    //if (TotalRecord != Qty)
    //                    //{
    //                    //    Show_Error_Success_Box("E", "Please Select Appropriate Quantity of Item Name ( " + lblItemName_DT.Text.Trim() + " )");
    //                    //    return;
    //                    //}

    //                }

    //                if ((TotalRecord == Qty) || (Qty == 2 * TotalRecord))
    //                {

    //                    UpdateDataForOptionCode(lblusertypeCode.Text.Trim());
    //                }
    //                else
    //                {
    //                    Show_Error_Success_Box("E", "Please Select Appropriate Quantity of Item Name ");
    //                    return;
    //                }
    //            }


    //            //For Employee
    //            if (lblusertypeCode.Text.Trim() == "UT004")
    //            {
    //                int Qty = 0;
    //                int TotalRecord = 1;
    //                foreach (DataListItem dtlItem in dlQuestion.Items)
    //                {
    //                    Label lblItem_Code_DT = (Label)dtlItem.FindControl("lblItem_Code_DT");
    //                    Label lblItemName_DT = (Label)dtlItem.FindControl("lblItemName_DT");

    //                    foreach (DataListItem dtlItem1 in dlQuestion.Items)
    //                    {
    //                        Label lblItem_Code_DT1 = (Label)dtlItem1.FindControl("lblItem_Code_DT");
    //                        Label lblQty_DT = (Label)dtlItem1.FindControl("lblQty_DT");

    //                        if (lblItem_Code_DT.Text.Trim() == lblItem_Code_DT1.Text.Trim())
    //                        {
    //                            Qty = Qty + Convert.ToInt32(lblQty_DT.Text.Trim());
    //                        }

    //                    }

    //                    //if (TotalRecord != Qty)
    //                    //{
    //                    //    Show_Error_Success_Box("E", "Please Select Appropriate Quantity of Item Name ( " + lblItemName_DT.Text.Trim() + " )");
    //                    //    return;
    //                    //}

    //                }

    //                if ((TotalRecord == Qty) || (Qty == 2 * TotalRecord))
    //                {

    //                    UpdateDataForOptionCode(lblusertypeCode.Text.Trim());
    //                }
    //                else
    //                {
    //                    Show_Error_Success_Box("E", "Please Select Appropriate Quantity of Item Name ");
    //                    return;
    //                }
    //            }

    //        }
    //        else if (opt == "3" || opt == "4")
    //        {
    //            if (txtRequestCode.Text == "")
    //            {
    //                Show_Error_Success_Box("E", "Enter Request Code");
    //                txtRequestCode.Focus();
    //                return;
    //            }

    //            //DTOP3

    //            int TotalRecord = 0;
    //            foreach (DataListItem dtlItem in DTOP3.Items)
    //            {
    //                CheckBox chkCheck = (CheckBox)dtlItem.FindControl("chkCheck");

    //                if (chkCheck.Checked == true)
    //                {
    //                    TotalRecord = TotalRecord + 1;
    //                }
    //            }
    //            if (TotalRecord == 0)
    //            {
    //                Show_Error_Success_Box("E", "You have not Selected any Item");
    //                return;
    //            }

    //            UpdateDataForOptionCode(lblusertypeCode.Text.Trim());
    //        }
    //        else
    //        {
    //            UpdateData();
    //        }

    //    }

    //}

    //private void UpdateDataForOptionCode(string UserType)
    //{
    //    try
    //    {
    //        Clear_Error_Success_Box();

    //        Label lblHeader_User_Code = default(Label);
    //        lblHeader_User_Code = (Label)Master.FindControl("lblHeader_User_Code");

    //        string CreatedBy = null;
    //        CreatedBy = lblHeader_User_Code.Text;

    //        string From_Location_Type_Code = "";
    //        string From_Location_Code = "";
    //        string To_Location_Type_Code = "";
    //        string To_Location_Code = "";
    //        DateTime Dispatch_Date = DateTime.Now;
    //        string Challan_No = "";
    //        DateTime Challan_Date;
    //        string ContactPerson = "";
    //        string ContactPersonNo = "";
    //        string ContactPersonEmailId = "";

    //        int Temp_Flag = 0;
    //        string LogisticType_Code = string.Empty;
    //        string LogisticDetails1 = string.Empty;
    //        string LogisticDetails2 = string.Empty;
    //        int IsActive = 1;

    //        string ResultId = "";

    //        int Total_Item_Count = 0;
    //        int Total_Quantity = 0;
    //        decimal Total_Amount = 0;

    //        From_Location_Type_Code = ddlTransferFR_Add.SelectedValue;
    //        To_Location_Type_Code = ddlTransferTO_Add.SelectedValue;

    //        if (ddlTransferFR_Add.SelectedItem.Text == "Godown")
    //        {
    //            From_Location_Code = ddlGodownFR_Add.SelectedValue;
    //        }
    //        else if (ddlTransferFR_Add.SelectedItem.Text == "Function")
    //        {
    //            From_Location_Code = ddlFunctionFR_Add.SelectedValue;
    //        }
    //        else if (ddlTransferFR_Add.SelectedItem.Text == "Center")
    //        {
    //            From_Location_Code = ddlCenterFR_Add.SelectedValue;
    //        }

    //        if (ddlTransferTO_Add.SelectedItem.Text == "Godown")
    //        {
    //            To_Location_Code = ddlGodownTO_Add.SelectedValue;
    //        }
    //        else if (ddlTransferTO_Add.SelectedItem.Text == "Function")
    //        {
    //            To_Location_Code = ddlFunctionTO_Add.SelectedValue;
    //        }
    //        else if (ddlTransferTO_Add.SelectedItem.Text == "Center")
    //        {
    //            To_Location_Code = ddlCenterTO_Add.SelectedValue;
    //        }

    //        Challan_No = txtChallanNo_Add.Text.Trim();
    //        Challan_Date = Convert.ToDateTime(txtChallanDate_Add.Text.Trim());
    //        ContactPerson = txtContactPerson_Add.Text.Trim();
    //        ContactPersonEmailId = txtEmail_Add.Text.Trim();
    //        ContactPersonNo = txtContact_Add.Text.Trim();
    //        LogisticType_Code = ddlLogisticType_Add.SelectedValue;



    //        if (ddlLogisticType_Add.SelectedItem.Text == "Courier")
    //        {
    //            LogisticDetails1 = txtLogisticDetails_Add.Text.Trim();
    //            LogisticDetails2 = txtPODNo_Add0.Text.Trim();
    //        }

    //        if (ddlLogisticType_Add.SelectedItem.Text == "Transport")
    //        {
    //            LogisticDetails1 = txtLogisticDetails_Add.Text.Trim();
    //            LogisticDetails2 = txtVechicleNo_Add.Text.Trim();
    //        }

    //        if (ddlLogisticType_Add.SelectedItem.Text == "In Person")
    //        {
    //            LogisticDetails1 = txtLogisticDetails_Add.Text.Trim();
    //            LogisticDetails2 = "";
    //        }


    //        if (lblTotal_Quantity.Text != "")
    //        {
    //            Total_Quantity = Convert.ToInt32(lblTotal_Quantity.Text);
    //        }

    //        if (lblTotal_Amount.Text != "")
    //        {
    //            Total_Amount = Convert.ToDecimal(lblTotal_Amount.Text);
    //        }

    //        if (lblTotalItem.Text != "")
    //        {
    //            Total_Item_Count = Convert.ToInt32(lblTotalItem.Text);
    //        }


    //        string opt = null;
    //        opt = Request.QueryString["OptionCode"];
    //        int TotalIems = 0;
    //        if (opt == "3" || opt == "4")
    //        {
    //            foreach (DataListItem dtlItem in DTOP3.Items)
    //            {

    //                CheckBox chkCheck = (CheckBox)dtlItem.FindControl("chkCheck");

    //                if (chkCheck.Checked == true)
    //                {
    //                    TotalIems = TotalIems + 1;
    //                }

    //            }

    //            Total_Item_Count = TotalIems;
    //            Total_Quantity = TotalIems;
    //            Total_Amount = 0;
    //        }

    //        ResultId = ProductController.Insert_Update_Dispach(4, lblPkey.Text, From_Location_Type_Code, From_Location_Code, To_Location_Type_Code
    //        , To_Location_Code, Dispatch_Date, Challan_No, Challan_Date, ContactPerson, ContactPersonNo, ContactPersonEmailId, Total_Item_Count
    //        , Total_Quantity, Total_Amount, 1, LogisticType_Code, LogisticDetails1, LogisticDetails2, IsActive, CreatedBy, txtRequestCode.Text.Trim(), opt, "");


    //        if (ResultId == "")
    //        {

    //        }
    //        else if (ResultId == "-1")
    //        {

    //        }
    //        else
    //        {


    //            string deleteItem = ProductController.Delete_Dispach_Item(3, lblPkey.Text);
    //            string deleteRequestEntry = ProductController.Delete_DispatchEntry_ReuestEntry_COde(14, lblPkey.Text);


    //            if (opt == "2")
    //            {
    //                string ResultOP3 = "";


    //                foreach (DataListItem item in DataList2.Items)
    //                {
    //                    if (item.ItemType == ListItemType.Item | item.ItemType == ListItemType.AlternatingItem)
    //                    {
    //                        Label lblDispatch_Code = (Label)item.FindControl("lblDispatch_Code");
    //                        Label lblDispatchEntry_Code = (Label)item.FindControl("lblDispatchEntry_Code");
    //                        Label lblItem_Code_DT = (Label)item.FindControl("lblItem_Code_DT");
    //                        Label lblItemName_DT = (Label)item.FindControl("lblItemName_DT");
    //                        Label lblBarcode_DT = (Label)item.FindControl("lblBarcode_DT");
    //                        Label lblAssetNo_DT = (Label)item.FindControl("lblAssetNo_DT");
    //                        Label lblQty_DT = (Label)item.FindControl("lblQty_DT");
    //                        Label lblUnitPrice_DT = (Label)item.FindControl("lblUnitPrice_DT");
    //                        Label lblAmount_DT = (Label)item.FindControl("lblAmount_DT");
    //                        Label lblPkey_Code = (Label)item.FindControl("lblPkey_Code");
    //                        Label lblInward_Code = (Label)item.FindControl("lblInward_Code");
    //                        Label lblInwardEntry_Code_DL = (Label)item.FindControl("lblInwardEntry_Code_DL");

    //                        Label Inward_Qty = (Label)item.FindControl("Inward_Qty");
    //                        Label lblRequestEntry_Code_Grid = (Label)item.FindControl("lblRequestEntry_Code_Grid");

    //                        int iQty = Convert.ToInt32(Inward_Qty.Text);


    //                        string a = ProductController.Insert_Update_DispachItem(lblPkey.Text, lblItem_Code_DT.Text, lblAssetNo_DT.Text, Convert.ToInt32(lblQty_DT.Text), Convert.ToDecimal(lblUnitPrice_DT.Text), Convert.ToDecimal(lblAmount_DT.Text), lblInward_Code.Text.Trim(), lblInwardEntry_Code_DL.Text.Trim(), lblDispatchEntry_Code.Text.Trim(), CreatedBy);
    //                        if (a != "1")
    //                        {
    //                            string b = ProductController.DispatchAuthorisation_ForFlat(lblPkey.Text, lblInward_Code.Text, lblItem_Code_DT.Text, lblInwardEntry_Code_DL.Text, a, lblBarcode_DT.Text, lblAssetNo_DT.Text, To_Location_Type_Code, To_Location_Code, From_Location_Type_Code, From_Location_Code, DateTime.Now, iQty, Convert.ToDecimal(lblUnitPrice_DT.Text), Convert.ToInt32(lblQty_DT.Text), Convert.ToDecimal(lblAmount_DT.Text), CreatedBy);

    //                            //if (opt == "3")
    //                            //{
    //                            //    ResultOP3 = ProductController.Insert_DispatchEntry_ReuestEntry_COdeOP3(1, ResultId, a, txtRequestCode.Text.Trim(), lblRequestEntry_Code_Grid.Text.Trim());
    //                            //}
    //                        }


    //                    }

    //                }

    //                string FinResultID = "";
    //                if (opt == "2")
    //                {
    //                    string RequestEntry_Code = "";

    //                    if (UserType == "UT001")
    //                    {
    //                        foreach (DataListItem item in datalist_Student.Items)
    //                        {
    //                            if (item.ItemType == ListItemType.Item | item.ItemType == ListItemType.AlternatingItem)
    //                            {
    //                                CheckBox chkCheck = (CheckBox)item.FindControl("chkCheck");

    //                                if (chkCheck.Checked == true)
    //                                {
    //                                    Label Request_Code = (Label)item.FindControl("lblrequCode");
    //                                    Label Request_EntryCode = (Label)item.FindControl("Request_EntryCode");

    //                                    string REBind = Request_Code.Text.Trim() + "%" + Request_EntryCode.Text.Trim();
    //                                    RequestEntry_Code = RequestEntry_Code + REBind + ",";
    //                                }

    //                            }

    //                        }

    //                        RequestEntry_Code = Common.RemoveComma(RequestEntry_Code);

    //                        FinResultID = ProductController.Insert_DispatchEntry_ReuestEntry_COde(1, lblPkey.Text, RequestEntry_Code);

    //                    }

    //                    else if (UserType == "UT003")
    //                    {
    //                        foreach (DataListItem item in datalist_Teacher.Items)
    //                        {
    //                            if (item.ItemType == ListItemType.Item | item.ItemType == ListItemType.AlternatingItem)
    //                            {
    //                                CheckBox chkCheck = (CheckBox)item.FindControl("chkCheck");

    //                                if (chkCheck.Checked == true)
    //                                {
    //                                    Label Request_Code = (Label)item.FindControl("lblrequCode_TH");
    //                                    Label Request_EntryCode = (Label)item.FindControl("Request_EntryCode_TH");

    //                                    string REBind = Request_Code.Text.Trim() + "%" + Request_EntryCode.Text.Trim();
    //                                    RequestEntry_Code = RequestEntry_Code + REBind + ",";
    //                                }

    //                            }

    //                        }

    //                        RequestEntry_Code = Common.RemoveComma(RequestEntry_Code);

    //                        FinResultID = ProductController.Insert_DispatchEntry_ReuestEntry_COde(1, lblPkey.Text, RequestEntry_Code);
    //                    }

    //                    else if (UserType == "UT004")
    //                    {
    //                        string REBind = lblRequ_CodeforEmp.Text.Trim() + "%" + lblRequ_EntryCodeforEMP.Text.Trim();

    //                        RequestEntry_Code = Common.RemoveComma(REBind);

    //                        FinResultID = ProductController.Insert_DispatchEntry_ReuestEntry_COde(1, lblPkey.Text, RequestEntry_Code);
    //                    }
    //                }


    //                if (FinResultID == "1" || ResultOP3 == "1")
    //                {
    //                    ControlVisibility("Search");
    //                    Show_Error_Success_Box("S", "Record updated successfully");
    //                }
    //                else if (FinResultID == "0" || ResultOP3 == "0")
    //                {
    //                    Show_Error_Success_Box("E", "Error occured during save..");
    //                }
    //            }
    //            else if (opt == "3" || opt == "4")
    //            {
    //                string Resultop4 = "";
    //                foreach (DataListItem item in DTOP3.Items)
    //                {
    //                    if (item.ItemType == ListItemType.Item | item.ItemType == ListItemType.AlternatingItem)
    //                    {

    //                        Label lblItem_Code_DT = (Label)item.FindControl("lblItem_Code_DT");
    //                        Label lblAssetNo_DT = (Label)item.FindControl("lblAssetNo_DT");
    //                        Label lblQty_DT = (Label)item.FindControl("lblQty_DT");
    //                        Label lblInward_Code = (Label)item.FindControl("lblInward_Code");
    //                        Label lblInwardEntry_Code_DL = (Label)item.FindControl("lblInwardEntry_Code_DL");
    //                        Label lblEANNo_DT = (Label)item.FindControl("lblEANNo_DT");
    //                        Label lblRequestEntry_Code_Grid = (Label)item.FindControl("lblRequestEntry_Code_Grid");
    //                        Label lblDispatchEntry_Code_Grid = (Label)item.FindControl("lblDispatchEntry_Code_Grid");

    //                        int iQty = 0;
    //                        CheckBox chkCheck = (CheckBox)item.FindControl("chkCheck");

    //                        if (chkCheck.Checked == true)
    //                        {
    //                            iQty = Convert.ToInt32(lblQty_DT.Text);
    //                        }
    //                        else
    //                        {
    //                            iQty = 0;
    //                        }


    //                        //string a = ProductController.Insert_Update_DispachItem(ResultId, lblItem_Code_DT.Text, lblAssetNo_DT.Text, Convert.ToInt32(lblQty_DT.Text), 0, 0, lblInward_Code.Text.Trim(), lblInwardEntry_Code_DL.Text.Trim(), "");

    //                        //if (a != "1")
    //                        //{
    //                        //    string b = ProductController.DispatchAuthorisation_ForFlat(ResultId, lblInward_Code.Text, lblItem_Code_DT.Text, lblInwardEntry_Code_DL.Text, a, lblEANNo_DT.Text, lblAssetNo_DT.Text, To_Location_Type_Code, To_Location_Code, From_Location_Type_Code, From_Location_Code, DateTime.Now, iQty, 0, Convert.ToInt32(lblQty_DT.Text), 0);

    //                        //    Resultop4 = ProductController.Insert_DispatchEntry_ReuestEntry_COdeOP3(1, ResultId, a, txtRequestCode.Text.Trim(), lblRequestEntry_Code_Grid.Text.Trim());

    //                        //}


    //                        string a = ProductController.Insert_Update_DispachItem(lblPkey.Text, lblItem_Code_DT.Text, lblAssetNo_DT.Text, iQty, 0, 0, lblInward_Code.Text.Trim(), lblInwardEntry_Code_DL.Text.Trim(), lblDispatchEntry_Code_Grid.Text.Trim(), CreatedBy);
    //                        if (a != "1")
    //                        {
    //                            string b = ProductController.DispatchAuthorisation_ForFlat(lblPkey.Text, lblInward_Code.Text, lblItem_Code_DT.Text, lblInwardEntry_Code_DL.Text, a, lblEANNo_DT.Text, lblAssetNo_DT.Text, To_Location_Type_Code, To_Location_Code, From_Location_Type_Code, From_Location_Code, DateTime.Now, iQty, 0, iQty, 0, CreatedBy);

    //                            Resultop4 = ProductController.Insert_DispatchEntry_ReuestEntry_COdeOP3(1, lblPkey.Text, a, txtRequestCode.Text.Trim(), lblRequestEntry_Code_Grid.Text.Trim());

    //                        }



    //                    }

    //                }

    //                if (Resultop4 == "1")
    //                {
    //                    ControlVisibility("Search");
    //                    Show_Error_Success_Box("S", "Record save successfully");
    //                }
    //                else if (Resultop4 == "0")
    //                {
    //                    Show_Error_Success_Box("E", "Error occured during save..");
    //                }

    //            }


    //        }


    //    }
    //    catch (Exception ex)
    //    {
    //        Msg_Error.Visible = true;
    //        Msg_Success.Visible = false;
    //        lblerror.Text = ex.ToString();
    //        UpdatePanelMsgBox.Update();
    //        return;
    //    }

    //}

    private void Page_Validation()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];

        string Path = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
        System.IO.FileInfo Info = new System.IO.FileInfo(Path);
        string pageName = Info.Name;

        int ResultId = 0;

        ResultId = ProductController.Chk_Page_Validation(pageName, UserID, "DB00");

        if (ResultId >= 1)
        {
            //Allow
        }
        else
        {
            Response.Redirect("~/Homepage.aspx", false);
        }

    }

    protected void HLExport_Click(object sender, EventArgs e)
    {
        DataList1.Visible = true;

        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        string filenamexls1 = "DispatchDetails_" + DateTime.Now + ".xls";
        Response.AddHeader("Content-Disposition", "inline;filename=" + filenamexls1);
        HttpContext.Current.Response.Charset = "utf-8";
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");
        //sets font
        HttpContext.Current.Response.Write("<font style='font-size:10.0pt; font-family:Calibri;'>");
        HttpContext.Current.Response.Write("<BR><BR><BR>");
        HttpContext.Current.Response.Write("<Table border='1'  borderColor='#000000' cellSpacing='0' cellPadding='0' style='font-size:10.0pt; font-family:Calibri; text-align:center;'> <TR style='color: #fff; background: black;text-align:center;'><TD Colspan='9'>Dispatch Details</b></TD></TR>");
        Response.Charset = "";
        this.EnableViewState = false;
        System.IO.StringWriter oStringWriter1 = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter oHtmlTextWriter1 = new System.Web.UI.HtmlTextWriter(oStringWriter1);
        //this.ClearControls(dladmissioncount)
        DataList1.RenderControl(oHtmlTextWriter1);
        Response.Write(oStringWriter1.ToString());
        Response.Flush();
        Response.End();

        DataList1.Visible = false;
    }

    protected void btnSaveItem_ServerClick(object sender, EventArgs e)
    {
        Clear_Error_Success_Box();
        if (lblMateCode.Text.Trim() == "")
        {
            Show_Error_Success_Box("E", "Select Item");
            return;
        }

        if (txtItemQty.Text.Trim() == "")
        {
            Show_Error_Success_Box("E", "Enter Item Quantity");
            txtItemQty.Focus();
            return;
        }

        if (Convert.ToDecimal(txtItemQty.Text.Trim()) > Convert.ToDecimal(lblCurrentQty.Text))
        {
            Show_Error_Success_Box("E", "Item Quantity can't be greater than stock Quantity");
            txtItemQty.Focus();
            return;
        }


        DataTable dtCorrectEntry = new DataTable();
        DataRow NewRow = null;

        var _with1 = dtCorrectEntry;
        _with1.Columns.Add("Dispatch_Code");
        _with1.Columns.Add("DispatchEntry_Code");
        _with1.Columns.Add("Item_Code");
        _with1.Columns.Add("Item_Name");
        _with1.Columns.Add("Purchase_Amount");
        _with1.Columns.Add("Purchase_Rate");
        _with1.Columns.Add("Barcode");
        _with1.Columns.Add("Dispatch_Qty");
        _with1.Columns.Add("Asset_No");
        _with1.Columns.Add("Pkey");
        _with1.Columns.Add("InwardEntry_Code");
        _with1.Columns.Add("Inward_Code");
        _with1.Columns.Add("Inward_Qty");
        _with1.Columns.Add("is_Acknowledged");
        _with1.Columns.Add("Request_EntryCode");




        int itemcount = 0;
        int Total_Item_Count = 0;
        int Total_Quantity = 0;
        decimal Total_Amount = 0;

        foreach (DataListItem item in dlQuestion.Items)
        {
            if (item.ItemType == ListItemType.Item | item.ItemType == ListItemType.AlternatingItem)
            {
                Label lblDispatch_Code = (Label)item.FindControl("lblDispatch_Code");
                Label lblDispatchEntry_Code = (Label)item.FindControl("lblDispatchEntry_Code");
                Label lblItem_Code_DT = (Label)item.FindControl("lblItem_Code_DT");
                Label lblItemName_DT = (Label)item.FindControl("lblItemName_DT");
                Label lblBarcode_DT = (Label)item.FindControl("lblBarcode_DT");
                Label lblAssetNo_DT = (Label)item.FindControl("lblAssetNo_DT");
                Label lblQty_DT = (Label)item.FindControl("lblQty_DT");
                Label lblUnitPrice_DT = (Label)item.FindControl("lblUnitPrice_DT");
                Label lblAmount_DT = (Label)item.FindControl("lblAmount_DT");
                Label lblPkey_Code = (Label)item.FindControl("lblPkey_Code");

                Label lblInward_Code = (Label)item.FindControl("lblInward_Code");
                Label lblInwardEntry_Code_DL = (Label)item.FindControl("lblInwardEntry_Code_DL");
                Label Inward_Qty = (Label)item.FindControl("Inward_Qty");
                Label lblis_Acknowledged = (Label)item.FindControl("lblis_Acknowledged");
                Label lblRequestEntry_Code_Grid = (Label)item.FindControl("lblRequestEntry_Code_Grid");

                NewRow = dtCorrectEntry.NewRow();
                NewRow["Dispatch_Code"] = lblDispatch_Code.Text.Trim();
                NewRow["DispatchEntry_Code"] = lblDispatchEntry_Code.Text.Trim();
                NewRow["Item_Code"] = lblItem_Code_DT.Text.Trim();
                NewRow["Item_Name"] = lblItemName_DT.Text.Trim();
                NewRow["Barcode"] = lblBarcode_DT.Text.Trim();
                NewRow["Asset_No"] = lblAssetNo_DT.Text.Trim();
                NewRow["Dispatch_Qty"] = lblQty_DT.Text.Trim();
                NewRow["Purchase_Rate"] = lblUnitPrice_DT.Text.Trim();
                NewRow["Purchase_Amount"] = lblAmount_DT.Text.Trim();

                NewRow["InwardEntry_Code"] = lblInwardEntry_Code_DL.Text.Trim();
                NewRow["Inward_Code"] = lblInward_Code.Text.Trim();
                NewRow["Inward_Qty"] = Inward_Qty.Text.Trim();
                NewRow["is_Acknowledged"] = lblis_Acknowledged.Text.Trim();
                NewRow["Request_EntryCode"] = lblRequestEntry_Code_Grid.Text.Trim();

                itemcount++;


                Total_Quantity = Total_Quantity + Convert.ToInt32(lblQty_DT.Text.Trim());
                Total_Amount = Total_Amount + Convert.ToDecimal(lblAmount_DT.Text.Trim());


                NewRow["Pkey"] = itemcount.ToString();

                dtCorrectEntry.Rows.Add(NewRow);


            }
        }

        ////
        //temp data

        DataTable dtTempEntry = new DataTable();
        DataRow NewRow1 = null;


        var _with2 = dtTempEntry;
        _with2.Columns.Add("Dispatch_Code");
        _with2.Columns.Add("DispatchEntry_Code");
        _with2.Columns.Add("Item_Code");
        _with2.Columns.Add("Item_Name");
        _with2.Columns.Add("Purchase_Amount");
        _with2.Columns.Add("Purchase_Rate");
        _with2.Columns.Add("Barcode");
        _with2.Columns.Add("Dispatch_Qty");
        _with2.Columns.Add("Asset_No");
        _with2.Columns.Add("Pkey");
        _with2.Columns.Add("InwardEntry_Code");
        _with2.Columns.Add("Inward_Code");
        _with2.Columns.Add("Inward_Qty");
        _with2.Columns.Add("is_Acknowledged");
        _with2.Columns.Add("Request_EntryCode");


        int itemcount1 = 0;
        int Total_Item_Count1 = 0;
        int Total_Quantity1 = 0;
        decimal Total_Amount1 = 0;

        foreach (DataListItem item in DataList2.Items)
        {
            if (item.ItemType == ListItemType.Item | item.ItemType == ListItemType.AlternatingItem)
            {
                Label lblDispatch_Code = (Label)item.FindControl("lblDispatch_Code");
                Label lblDispatchEntry_Code = (Label)item.FindControl("lblDispatchEntry_Code");
                Label lblItem_Code_DT = (Label)item.FindControl("lblItem_Code_DT");
                Label lblItemName_DT = (Label)item.FindControl("lblItemName_DT");
                Label lblBarcode_DT = (Label)item.FindControl("lblBarcode_DT");
                Label lblAssetNo_DT = (Label)item.FindControl("lblAssetNo_DT");
                Label lblQty_DT = (Label)item.FindControl("lblQty_DT");
                Label lblUnitPrice_DT = (Label)item.FindControl("lblUnitPrice_DT");
                Label lblAmount_DT = (Label)item.FindControl("lblAmount_DT");
                Label lblPkey_Code = (Label)item.FindControl("lblPkey_Code");

                Label lblInward_Code = (Label)item.FindControl("lblInward_Code");
                Label lblInwardEntry_Code_DL = (Label)item.FindControl("lblInwardEntry_Code_DL");
                Label Inward_Qty = (Label)item.FindControl("Inward_Qty");
                Label lblis_Acknowledged = (Label)item.FindControl("lblis_Acknowledged");
                Label lblRequestEntry_Code_Grid = (Label)item.FindControl("lblRequestEntry_Code_Grid");

                NewRow1 = dtTempEntry.NewRow();
                NewRow1["Dispatch_Code"] = lblDispatch_Code.Text.Trim();
                NewRow1["DispatchEntry_Code"] = lblDispatchEntry_Code.Text.Trim();
                NewRow1["Item_Code"] = lblItem_Code_DT.Text.Trim();
                NewRow1["Item_Name"] = lblItemName_DT.Text.Trim();
                NewRow1["Barcode"] = lblBarcode_DT.Text.Trim();
                NewRow1["Asset_No"] = lblAssetNo_DT.Text.Trim();
                NewRow1["Dispatch_Qty"] = lblQty_DT.Text.Trim();
                NewRow1["Purchase_Rate"] = lblUnitPrice_DT.Text.Trim();
                NewRow1["Purchase_Amount"] = lblAmount_DT.Text.Trim();

                NewRow1["InwardEntry_Code"] = lblInwardEntry_Code_DL.Text.Trim();
                NewRow1["Inward_Code"] = lblInward_Code.Text.Trim();
                NewRow1["Inward_Qty"] = Inward_Qty.Text.Trim();
                NewRow1["is_Acknowledged"] = lblis_Acknowledged.Text.Trim();
                NewRow1["Request_EntryCode"] = lblRequestEntry_Code_Grid.Text.Trim();

                itemcount1++;


                Total_Quantity1 = Total_Quantity1 + Convert.ToInt32(lblQty_DT.Text.Trim());
                Total_Amount1 = Total_Amount1 + Convert.ToDecimal(lblAmount_DT.Text.Trim());


                NewRow1["Pkey"] = itemcount1.ToString();

                dtTempEntry.Rows.Add(NewRow1);


            }
        }


        ////



        string From_Location_Type_Code = "";
        string From_Location_Code = "";

        From_Location_Type_Code = ddlTransferFR_Add.SelectedValue;


        if (ddlTransferFR_Add.SelectedItem.Text == "Godown")
        {
            From_Location_Code = ddlGodownFR_Add.SelectedValue;
        }
        else if (ddlTransferFR_Add.SelectedItem.Text == "Function")
        {
            From_Location_Code = ddlFunctionFR_Add.SelectedValue;
        }
        else if (ddlTransferFR_Add.SelectedItem.Text == "Center")
        {
            From_Location_Code = ddlCenterFR_Add.SelectedValue;
        }




        DataSet dsSupplier = ProductController.GetItemForDispatch(lblSearchAddItem.Text, 3, From_Location_Type_Code, From_Location_Code, "", "", "");

        if (dsSupplier.Tables[0].Rows.Count > 0)
        {
            if (dsSupplier.Tables[0].Rows.Count == 1)
            {
                NewRow = dtCorrectEntry.NewRow();
                NewRow["Dispatch_Code"] = "";
                NewRow["DispatchEntry_Code"] = "";
                NewRow["Item_Code"] = lblMateCode.Text.Trim();
                NewRow["Item_Name"] = lblItemName.Text.Trim();
                NewRow["Barcode"] = dsSupplier.Tables[0].Rows[0]["Item_EAN_No"].ToString();
                NewRow["Asset_No"] = dsSupplier.Tables[0].Rows[0]["Asset_No"].ToString();
                NewRow["Dispatch_Qty"] = txtItemQty.Text.Trim();
                NewRow["Purchase_Rate"] = txtItemRate.Text;
                NewRow["Purchase_Amount"] = lblCalValue.Text;
                NewRow["Pkey"] = (itemcount + 1).ToString();


                NewRow["InwardEntry_Code"] = dsSupplier.Tables[0].Rows[0]["InwardEntry_Code"].ToString();
                NewRow["Inward_Code"] = dsSupplier.Tables[0].Rows[0]["Inward_Code"].ToString();
                NewRow["Inward_Qty"] = dsSupplier.Tables[0].Rows[0]["Inward_Qty"].ToString();
                NewRow["is_Acknowledged"] = "0";
                NewRow["Request_EntryCode"] = lblRequestEntry_Code_Item.Text.Trim();
                dtCorrectEntry.Rows.Add(NewRow);


                //

                NewRow1 = dtTempEntry.NewRow();
                NewRow1["Dispatch_Code"] = "";
                NewRow1["DispatchEntry_Code"] = "";
                NewRow1["Item_Code"] = lblMateCode.Text.Trim();
                NewRow1["Item_Name"] = lblItemName.Text.Trim();
                NewRow1["Barcode"] = dsSupplier.Tables[0].Rows[0]["Item_EAN_No"].ToString();
                NewRow1["Asset_No"] = dsSupplier.Tables[0].Rows[0]["Asset_No"].ToString();
                NewRow1["Dispatch_Qty"] = txtItemQty.Text.Trim();
                NewRow1["Purchase_Rate"] = txtItemRate.Text;
                NewRow1["Purchase_Amount"] = lblCalValue.Text;
                NewRow1["Pkey"] = (itemcount + 1).ToString();


                NewRow1["InwardEntry_Code"] = dsSupplier.Tables[0].Rows[0]["InwardEntry_Code"].ToString();
                NewRow1["Inward_Code"] = dsSupplier.Tables[0].Rows[0]["Inward_Code"].ToString();
                NewRow1["Inward_Qty"] = dsSupplier.Tables[0].Rows[0]["Inward_Qty"].ToString();
                NewRow1["is_Acknowledged"] = "0";
                NewRow1["Request_EntryCode"] = lblRequestEntry_Code_Item.Text.Trim();

                dtTempEntry.Rows.Add(NewRow1);

                Total_Quantity = Total_Quantity + Convert.ToInt32(txtItemQty.Text.Trim());
                Total_Amount = Total_Amount + Convert.ToDecimal(lblCalValue.Text);
            }
        }




        dlQuestion.DataSource = dtCorrectEntry;
        dlQuestion.DataBind();
        DataList2.DataSource = dtTempEntry;
        DataList2.DataBind();
        lblTotal_Amount.Text = Total_Amount.ToString();
        lblTotal_Quantity.Text = Total_Quantity.ToString();
        lblTotalItem.Text = (itemcount + 1).ToString();

        lblMateCode.Text = "";
        lblItemName.Text = "";
        lblUnit.Text = "";
        lblCalValue.Text = "";
        txtItemQty.Text = "";
        txtItemRate.Text = "";
        lblRequestEntry_Code_Item.Text = "";
    }

    //protected void btnSearchItem_ServerClick(object sender, EventArgs e)
    //{
    //    Clear_Error_Success_Box();

    //    if (txtItemMatCode.Text.Trim() == "")
    //    {
    //        Show_Error_Success_Box("E", "Enter Item");
    //        txtItemMatCode.Focus();
    //        return;
    //    }


    //    string From_Location_Type_Code = "";
    //    string From_Location_Code = "";

    //    From_Location_Type_Code = ddlTransferFR_Add.SelectedValue;


    //    if (ddlTransferFR_Add.SelectedItem.Text == "Godown")
    //    {
    //        From_Location_Code = ddlGodownFR_Add.SelectedValue;
    //    }
    //    else if (ddlTransferFR_Add.SelectedItem.Text == "Function")
    //    {
    //        From_Location_Code = ddlFunctionFR_Add.SelectedValue;
    //    }
    //    else if (ddlTransferFR_Add.SelectedItem.Text == "Center")
    //    {
    //        From_Location_Code = ddlCenterFR_Add.SelectedValue;
    //    }

    //    DataSet dsSupplier = null;

    //    string opt = null;
    //    opt = Request.QueryString["OptionCode"];

    //    if (opt == "3")
    //    {

    //        string RequestEntry_Code = "";

    //        //For Student                
    //        if (lblusertypeCode.Text.Trim() == "UT001")
    //        {
    //            int TotalRecord = 0;
    //            foreach (DataListItem dtlItem in datalist_Student.Items)
    //            {
    //                CheckBox chkCheck = (CheckBox)dtlItem.FindControl("chkCheck");

    //                if (chkCheck.Checked == true)
    //                {
    //                    TotalRecord = TotalRecord + 1;
    //                }
    //            }
    //            if (TotalRecord == 0)
    //            {
    //                Show_Error_Success_Box("E", "You have not Selected any Student");
    //                return;
    //            }
    //            else
    //            {
    //                foreach (DataListItem item in datalist_Student.Items)
    //                {
    //                    if (item.ItemType == ListItemType.Item | item.ItemType == ListItemType.AlternatingItem)
    //                    {
    //                        CheckBox chkCheck = (CheckBox)item.FindControl("chkCheck");

    //                        if (chkCheck.Checked == true)
    //                        {
    //                            //Label Request_Code = (Label)item.FindControl("lblrequCode");
    //                            Label Request_EntryCode = (Label)item.FindControl("Request_EntryCode");

    //                            string REBind = Request_EntryCode.Text.Trim();
    //                            RequestEntry_Code = RequestEntry_Code + REBind + ",";
    //                        }

    //                    }

    //                }

    //                RequestEntry_Code = Common.RemoveComma(RequestEntry_Code);

    //            }
    //        }

    //        //For Teachers
    //        if (lblusertypeCode.Text.Trim() == "UT003")
    //        {
    //            int TotalRecord = 0;
    //            foreach (DataListItem dtlItem in datalist_Teacher.Items)
    //            {
    //                CheckBox chkCheck = (CheckBox)dtlItem.FindControl("chkCheck");

    //                if (chkCheck.Checked == true)
    //                {
    //                    TotalRecord = TotalRecord + 1;
    //                }
    //            }
    //            if (TotalRecord == 0)
    //            {
    //                Show_Error_Success_Box("E", "You have not Selected any Teacher");
    //                return;
    //            }
    //            else
    //            {
    //                foreach (DataListItem item in datalist_Teacher.Items)
    //                {
    //                    if (item.ItemType == ListItemType.Item | item.ItemType == ListItemType.AlternatingItem)
    //                    {
    //                        CheckBox chkCheck = (CheckBox)item.FindControl("chkCheck");

    //                        if (chkCheck.Checked == true)
    //                        {
    //                            //Label Request_Code = (Label)item.FindControl("lblrequCode_TH");
    //                            Label Request_EntryCode = (Label)item.FindControl("Request_EntryCode_TH");

    //                            string REBind = Request_EntryCode.Text.Trim();
    //                            RequestEntry_Code = RequestEntry_Code + REBind + ",";
    //                        }

    //                    }

    //                }

    //                RequestEntry_Code = Common.RemoveComma(RequestEntry_Code);

    //            }
    //        }

    //        else if (lblusertypeCode.Text.Trim() == "UT004")
    //        {
    //            string REBind = lblRequ_EntryCodeforEMP.Text.Trim();

    //            RequestEntry_Code = Common.RemoveComma(REBind);

    //        }

    //        dsSupplier = ProductController.GetItemForDispatch(txtItemMatCode.Text.Trim(), 4, From_Location_Type_Code, From_Location_Code, txtRequestCode.Text.Trim(), RequestEntry_Code, "");
    //    }
    //    else if (opt == "2")
    //    {
    //        string Pkey3 = "", TempPkey1 = "";
    //        foreach (DataListItem item in dlQuestion.Items)
    //        {
    //            if (item.ItemType == ListItemType.Item | item.ItemType == ListItemType.AlternatingItem)
    //            {
    //                Label lblItem_Code_DT = (Label)item.FindControl("lblItem_Code_DT");
    //                Label lblAssetNo_DT = (Label)item.FindControl("lblAssetNo_DT");
    //                Label lblInward_Code = (Label)item.FindControl("lblInward_Code");
    //                Label lblInwardEntry_Code_DL = (Label)item.FindControl("lblInwardEntry_Code_DL");
    //                Label lblQty_DT = (Label)item.FindControl("lblQty_DT");

    //                Label lblDispatchEntry_Code = (Label)item.FindControl("lblDispatchEntry_Code");

    //                if (lblDispatchEntry_Code.Text.Trim() == "")
    //                {
    //                    TempPkey1 = lblItem_Code_DT.Text.Trim() + "%" + lblAssetNo_DT.Text.Trim() + "%" + lblInward_Code.Text.Trim() + "%" + lblInwardEntry_Code_DL.Text.Trim() + "%" + lblQty_DT.Text.Trim();
    //                    Pkey3 = Pkey3 + TempPkey1 + ",";

    //                }


    //            }

    //        }

    //        Pkey3 = Common.RemoveComma(Pkey3);
    //        if (Pkey3 != "0")
    //        {
    //            Pkey3 = Pkey3;
    //        }
    //        else
    //        {
    //            Pkey3 = "";
    //        }


    //        dsSupplier = ProductController.GetItemForDispatchopn2(txtItemMatCode.Text.Trim(), 1, From_Location_Type_Code, From_Location_Code, "", "", Pkey3);
    //    }
    //    else
    //    {
    //        string Pkey2 = "", TempPkey = "";
    //        foreach (DataListItem item in dlQuestion.Items)
    //        {
    //            if (item.ItemType == ListItemType.Item | item.ItemType == ListItemType.AlternatingItem)
    //            {
    //                Label lblItem_Code_DT = (Label)item.FindControl("lblItem_Code_DT");
    //                Label lblAssetNo_DT = (Label)item.FindControl("lblAssetNo_DT");
    //                Label lblInward_Code = (Label)item.FindControl("lblInward_Code");
    //                Label lblInwardEntry_Code_DL = (Label)item.FindControl("lblInwardEntry_Code_DL");
    //                Label lblQty_DT = (Label)item.FindControl("lblQty_DT");

    //                Label lblDispatchEntry_Code = (Label)item.FindControl("lblDispatchEntry_Code");

    //                if (lblDispatchEntry_Code.Text.Trim() == "")
    //                {
    //                    TempPkey = lblItem_Code_DT.Text.Trim() + "%" + lblAssetNo_DT.Text.Trim() + "%" + lblInward_Code.Text.Trim() + "%" + lblInwardEntry_Code_DL.Text.Trim() + "%" + lblQty_DT.Text.Trim();
    //                    Pkey2 = Pkey2 + TempPkey + ",";
    //                }


    //            }

    //        }

    //        Pkey2 = Common.RemoveComma(Pkey2);
    //        if (Pkey2 != "0")
    //        {
    //            Pkey2 = Pkey2;
    //        }
    //        else
    //        {
    //            Pkey2 = "";
    //        }

    //        dsSupplier = ProductController.GetItemForDispatch(txtItemMatCode.Text.Trim(), 1, From_Location_Type_Code, From_Location_Code, "", "", Pkey2);
    //    }



    //    ClearItemAdd();
    //    if (dsSupplier.Tables[0].Rows.Count > 0)
    //    {
    //        if (dsSupplier.Tables[0].Rows.Count == 1)
    //        {
    //            lblMateCode.Text = dsSupplier.Tables[0].Rows[0]["Item_Code"].ToString();
    //            lblItemName.Text = dsSupplier.Tables[0].Rows[0]["Item_Name"].ToString();
    //            lblUnit.Text = dsSupplier.Tables[0].Rows[0]["UOM_Name"].ToString();
    //            txtItemRate.Text = dsSupplier.Tables[0].Rows[0]["Purchase_Rate"].ToString();
    //            string itemtype = dsSupplier.Tables[0].Rows[0]["AssetsNo_Type_Id"].ToString();
    //            int Current_Qty = Convert.ToInt32(dsSupplier.Tables[0].Rows[0]["Current_Qty"].ToString());
    //            lblCurrentQty.Text = Current_Qty.ToString();

    //            lblInwardEntry_Code.Text = dsSupplier.Tables[0].Rows[0]["InwardEntry_Code"].ToString();
    //            lblInward_Code.Text = dsSupplier.Tables[0].Rows[0]["Inward_Code"].ToString();
    //            lblInward_Qty.Text = dsSupplier.Tables[0].Rows[0]["Inward_Qty"].ToString();

    //            lblSearchAddItem.Text = dsSupplier.Tables[0].Rows[0]["Pkey"].ToString();
    //            if (itemtype == "ATN00000001")
    //            {
    //                if (opt == "2")
    //                {
    //                    txtItemQty.Enabled = false;
    //                }
    //                else
    //                {
    //                    txtItemQty.Enabled = true;
    //                }
    //            }
    //            else if (itemtype == "ATN00000002")
    //            {
    //                txtItemQty.Enabled = false;
    //            }
    //            else if (itemtype == "ATN00000003")
    //            {
    //                txtItemQty.Enabled = false;
    //            }


    //            txtItemQty.Text = "1";

    //            lblCalValue.Text = "";
    //            int itemQty = 0;
    //            decimal Rate1 = 0;
    //            if (txtItemQty.Text == "")
    //            {
    //                itemQty = 1;
    //            }
    //            else
    //            {
    //                itemQty = Convert.ToInt32(txtItemQty.Text);
    //            }
    //            if (txtItemRate.Text == "")
    //            {
    //                Rate1 = 0;
    //            }
    //            else
    //            {

    //                Rate1 = Convert.ToDecimal(string.Format("{0:F2}", txtItemRate.Text));

    //            }

    //            decimal CalAns = itemQty * Rate1;

    //            lblCalValue.Text = CalAns.ToString();
    //        }
    //        else if (dsSupplier.Tables[0].Rows.Count >= 1)
    //        {
    //            if (opt == "2")
    //            {
    //                dladditem.DataSource = dsSupplier;
    //                dladditem.DataBind();
    //                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalDivOverride1();", true);
    //            }
    //            else
    //            {
    //                DataList3.DataSource = dsSupplier;
    //                DataList3.DataBind();
    //                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalDivOverride();", true);
    //            }

    //        }

    //    }
    //    else
    //    {
    //        Show_Error_Success_Box("E", "Record not found");
    //        return;
    //    }

    //    tr1.Visible = true;
    //    tr2.Visible = true;


    //}

    protected void btnClearItem_Click(object sender, EventArgs e)
    {
        //ClearItemAdd();
        //tr1.Visible = false;
        //tr2.Visible = false;
    }

    private void ClearItemAdd()
    {
        lblMateCode.Text = "";
        lblItemName.Text = "";
        lblUnit.Text = "";
        txtItemRate.Text = "";
        txtItemMatCode.Text = "";
        txtItemQty.Text = "";

    }

    protected void DataList3_ItemCommand(object source, DataListCommandEventArgs e)
    {

        if (e.CommandName == "comSetItem")
        {
            ClearItemAdd();
            Clear_Error_Success_Box();

            string MaterialCode = e.CommandArgument.ToString();
            lblSearchAddItem.Text = MaterialCode;

            string From_Location_Type_Code = "";
            string From_Location_Code = "";

            From_Location_Type_Code = ddlTransferFR_Add.SelectedValue;


            if (ddlTransferFR_Add.SelectedItem.Text == "Godown")
            {
                From_Location_Code = ddlGodownFR_Add.SelectedValue;
            }
            else if (ddlTransferFR_Add.SelectedItem.Text == "Function")
            {
                From_Location_Code = ddlFunctionFR_Add.SelectedValue;
            }
            else if (ddlTransferFR_Add.SelectedItem.Text == "Center")
            {
                From_Location_Code = ddlCenterFR_Add.SelectedValue;
            }

            //
            DataSet dsSupplier = null;

            string opt = null;
            opt = Request.QueryString["OptionCode"];

            if (opt == "3")
            {

                string RequestEntry_Code = "";

                //For Student                
                if (lblusertypeCode.Text.Trim() == "UT001")
                {
                    int TotalRecord = 0;
                    foreach (DataListItem dtlItem in datalist_Student.Items)
                    {
                        CheckBox chkCheck = (CheckBox)dtlItem.FindControl("chkCheck");

                        if (chkCheck.Checked == true)
                        {
                            TotalRecord = TotalRecord + 1;
                        }
                    }
                    if (TotalRecord == 0)
                    {
                        Show_Error_Success_Box("E", "You have not Selected any Student");
                        return;
                    }
                    else
                    {
                        foreach (DataListItem item in datalist_Student.Items)
                        {
                            if (item.ItemType == ListItemType.Item | item.ItemType == ListItemType.AlternatingItem)
                            {
                                CheckBox chkCheck = (CheckBox)item.FindControl("chkCheck");

                                if (chkCheck.Checked == true)
                                {
                                    //Label Request_Code = (Label)item.FindControl("lblrequCode");
                                    Label Request_EntryCode = (Label)item.FindControl("Request_EntryCode");

                                    string REBind = Request_EntryCode.Text.Trim();
                                    RequestEntry_Code = RequestEntry_Code + REBind + ",";
                                }

                            }

                        }

                        RequestEntry_Code = Common.RemoveComma(RequestEntry_Code);

                    }
                }

                //For Teachers
                if (lblusertypeCode.Text.Trim() == "UT003")
                {
                    int TotalRecord = 0;
                    foreach (DataListItem dtlItem in datalist_Teacher.Items)
                    {
                        CheckBox chkCheck = (CheckBox)dtlItem.FindControl("chkCheck");

                        if (chkCheck.Checked == true)
                        {
                            TotalRecord = TotalRecord + 1;
                        }
                    }
                    if (TotalRecord == 0)
                    {
                        Show_Error_Success_Box("E", "You have not Selected any Teacher");
                        return;
                    }
                    else
                    {
                        foreach (DataListItem item in datalist_Teacher.Items)
                        {
                            if (item.ItemType == ListItemType.Item | item.ItemType == ListItemType.AlternatingItem)
                            {
                                CheckBox chkCheck = (CheckBox)item.FindControl("chkCheck");

                                if (chkCheck.Checked == true)
                                {
                                    //Label Request_Code = (Label)item.FindControl("lblrequCode_TH");
                                    Label Request_EntryCode = (Label)item.FindControl("Request_EntryCode_TH");

                                    string REBind = Request_EntryCode.Text.Trim();
                                    RequestEntry_Code = RequestEntry_Code + REBind + ",";
                                }

                            }

                        }

                        RequestEntry_Code = Common.RemoveComma(RequestEntry_Code);

                    }
                }

                else if (lblusertypeCode.Text.Trim() == "UT004")
                {
                    string REBind = lblRequ_EntryCodeforEMP.Text.Trim();

                    RequestEntry_Code = Common.RemoveComma(REBind);

                }

                dsSupplier = ProductController.GetItemForDispatch(MaterialCode, 5, From_Location_Type_Code, From_Location_Code, txtRequestCode.Text.Trim(), RequestEntry_Code, "");
            }
            else
            {
                dsSupplier = ProductController.GetItemForDispatch(MaterialCode, 2, From_Location_Type_Code, From_Location_Code, "", "", "");
            }

            //

            if (dsSupplier.Tables[0].Rows.Count > 0)
            {
                lblMateCode.Text = dsSupplier.Tables[0].Rows[0]["Item_Code"].ToString();
                lblItemName.Text = dsSupplier.Tables[0].Rows[0]["Item_Name"].ToString();
                lblUnit.Text = dsSupplier.Tables[0].Rows[0]["UOM_Name"].ToString();
                txtItemRate.Text = dsSupplier.Tables[0].Rows[0]["Purchase_Rate"].ToString();
                string itemtype = dsSupplier.Tables[0].Rows[0]["AssetsNo_Type_Id"].ToString();
                int Current_Qty = Convert.ToInt32(dsSupplier.Tables[0].Rows[0]["Current_Qty"].ToString());

                lblCurrentQty.Text = Current_Qty.ToString();
                txtItemQty.Text = "1";
                lblInwardEntry_Code.Text = dsSupplier.Tables[0].Rows[0]["InwardEntry_Code"].ToString();
                lblInward_Code.Text = dsSupplier.Tables[0].Rows[0]["Inward_Code"].ToString();
                lblInward_Qty.Text = dsSupplier.Tables[0].Rows[0]["Inward_Qty"].ToString();
                lblRequestEntry_Code_Item.Text = dsSupplier.Tables[0].Rows[0]["Request_EntryCode"].ToString();

                if (itemtype == "ATN00000001")
                {
                    if (opt == "2")
                    {
                        txtItemQty.Enabled = false;
                    }
                    else
                    {
                        txtItemQty.Enabled = true;
                    }
                }
                else if (itemtype == "ATN00000002")
                {
                    txtItemQty.Enabled = false;
                }
                else if (itemtype == "ATN00000003")
                {
                    txtItemQty.Enabled = false;
                }


                lblCalValue.Text = "";
                int itemQty = 0;
                decimal Rate1 = 0;
                if (txtItemQty.Text == "")
                {
                    itemQty = 1;
                }
                else
                {
                    itemQty = Convert.ToInt32(txtItemQty.Text);
                }
                if (txtItemRate.Text == "")
                {
                    Rate1 = 0;
                }
                else
                {

                    Rate1 = Convert.ToDecimal(string.Format("{0:F2}", txtItemRate.Text));

                }

                decimal CalAns = itemQty * Rate1;

                lblCalValue.Text = CalAns.ToString();


            }
        }

    }


    protected void dlGridDisplay_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "comEdit")
        {
            string opt = "";
            opt = Request.QueryString["OptionCode"];

            lblPkey.Text = "";
            ControlVisibility("Add");
            BtnSaveEdit.Visible = false;
            btnPrint.Visible = true;
            //BtnSaveAdd.Visible = false;
            ClearAddPanel();
            ClearItemAdd();
            dlQuestion.DataSource = null;
            dlQuestion.DataBind();

            DataList2.DataSource = null;
            DataList2.DataBind();

            DTOP3.DataSource = null;
            DTOP3.DataBind();

            string Dispatch_code = "";
            Dispatch_code = e.CommandArgument.ToString();
            Session["Dispatch_code"] = e.CommandArgument.ToString();
            HtmlAnchor aprint = new HtmlAnchor();

            //Aprint.Visible = true;
            //string PPCode = "PP011";
            aprint.HRef = "Manage_DispatchPrint.aspx?Dispatch_code=" + Dispatch_code;


            Clear_Error_Success_Box();

            lblPkey.Text = e.CommandArgument.ToString();
            DataSet ds1 = null;
            ds1 = ProductController.Get_Dispatch_ItemById(6, lblPkey.Text.Trim());

            if (ds1.Tables[0].Rows.Count > 0)
            {
                txtChallanNo_Add.Text = ds1.Tables[0].Rows[0]["Challan_No"].ToString();
                txtChallanDate_Add.Text = Convert.ToDateTime(ds1.Tables[0].Rows[0]["Challan_Date"].ToString()).ToString("dd-MMM-yyyy");
                txtEmail_Add.Text = ds1.Tables[0].Rows[0]["ContactPersonEmailId"].ToString();
                txtContactPerson_Add.Text = ds1.Tables[0].Rows[0]["ContactPerson"].ToString();
                txtContact_Add.Text = ds1.Tables[0].Rows[0]["ContactPersonNo"].ToString();
                txtLogisticDetails_Add.Text = ds1.Tables[0].Rows[0]["LogisticDetails1"].ToString();
                txtPODNo_Add0.Text = ds1.Tables[0].Rows[0]["LogisticDetails2"].ToString();
                txtVechicleNo_Add.Text = ds1.Tables[0].Rows[0]["LogisticDetails2"].ToString();
                ddlLogisticType_Add.SelectedValue = ds1.Tables[0].Rows[0]["LogisticType_Code"].ToString();
                ddlTransferFR_Add.SelectedValue = ds1.Tables[0].Rows[0]["From_Location_Type_Code"].ToString();
                ddlTransferTO_Add.SelectedValue = ds1.Tables[0].Rows[0]["To_Location_Type_Code"].ToString();
                txtLogisticDetails_Add.Text = ds1.Tables[0].Rows[0]["LogisticDetails1"].ToString();

                if (ds1.Tables[0].Rows[0]["Count1"].ToString() == "0")
                {
                    BtnSaveEdit.Visible = false;
                }
                else
                {
                    BtnSaveEdit.Visible = false;
                }


                if (ddlTransferFR_Add.SelectedItem.ToString().Trim() == "Godown")
                {
                    tblFR_Godown_Add.Visible = true;
                    tblFR_Function_Add.Visible = false;
                    tblFR_Division_Add.Visible = false;
                    tblFR_Center_Add.Visible = false;
                    ddlGodownFR_Add.SelectedValue = ds1.Tables[0].Rows[0]["From_Location_Code"].ToString();
                }
                else if (ddlTransferFR_Add.SelectedItem.ToString().Trim() == "Function")
                {
                    tblFR_Function_Add.Visible = true;
                    tblFR_Godown_Add.Visible = false;
                    tblFR_Division_Add.Visible = false;
                    tblFR_Center_Add.Visible = false;
                    ddlFunctionFR_Add.SelectedValue = ds1.Tables[0].Rows[0]["From_Location_Code"].ToString();
                }
                else if (ddlTransferFR_Add.SelectedItem.ToString().Trim() == "Center")
                {
                    tblFR_Division_Add.Visible = true;
                    tblFR_Center_Add.Visible = true;
                    tblFR_Function_Add.Visible = false;
                    tblFR_Godown_Add.Visible = false;
                    ddlDivisionFR_Add.SelectedValue = ds1.Tables[0].Rows[0]["FromDivision"].ToString();

                    FillDDL_FRAdd_Centre();
                    ddlCenterFR_Add.SelectedValue = ds1.Tables[0].Rows[0]["From_Location_Code"].ToString();
                }
                else if (ddlTransferFR_Add.SelectedIndex == 0 || ddlTransferFR_Add.SelectedIndex == -1)
                {
                    tblFR_Godown_Add.Visible = false;
                    tblFR_Function_Add.Visible = false;
                    tblFR_Division_Add.Visible = false;
                    tblFR_Center_Add.Visible = false;
                }


                if (ddlTransferTO_Add.SelectedItem.ToString().Trim() == "Godown")
                {
                    tblTO_Godown_Add.Visible = true;
                    tblTO_Function_Add.Visible = false;
                    tblTO_Division_Add.Visible = false;
                    tblTO_Center_Add.Visible = false;
                    ddlGodownTO_Add.SelectedValue = ds1.Tables[0].Rows[0]["To_Location_Code"].ToString();
                }
                else if (ddlTransferTO_Add.SelectedItem.ToString().Trim() == "Function")
                {
                    tblTO_Function_Add.Visible = true;
                    tblTO_Godown_Add.Visible = false;
                    tblTO_Division_Add.Visible = false;
                    tblTO_Center_Add.Visible = false;
                    ddlFunctionTO_Add.SelectedValue = ds1.Tables[0].Rows[0]["To_Location_Code"].ToString();
                }
                else if (ddlTransferTO_Add.SelectedItem.ToString().Trim() == "Center")
                {
                    tblTO_Division_Add.Visible = true;
                    tblTO_Center_Add.Visible = true;
                    tblTO_Function_Add.Visible = false;
                    tblTO_Godown_Add.Visible = false;

                    ddlDivisionTO_Add.SelectedValue = ds1.Tables[0].Rows[0]["ToDivision"].ToString();

                    FillDDL_TOAdd_Centre();
                    ddlCenterTO_Add.SelectedValue = ds1.Tables[0].Rows[0]["To_Location_Code"].ToString();
                }
                else if (ddlTransferTO_Add.SelectedIndex == 0 || ddlTransferTO_SR.SelectedIndex == -1)
                {
                    tblTO_Godown_Add.Visible = false;
                    tblTO_Function_Add.Visible = false;
                    tblTO_Division_Add.Visible = false;
                    tblTO_Center_Add.Visible = false;
                }

                if (ddlLogisticType_Add.SelectedItem.Text == "Courier")
                {
                    tblPODNo.Visible = true;
                    tblVehNo.Visible = false;
                    txtPODNo_Add0.Text = ds1.Tables[0].Rows[0]["LogisticDetails2"].ToString();
                }

                if (ddlLogisticType_Add.SelectedItem.Text == "Transport")
                {
                    tblPODNo.Visible = false;
                    tblVehNo.Visible = true;
                    txtVechicleNo_Add.Text = ds1.Tables[0].Rows[0]["LogisticDetails2"].ToString();
                }

                if (ddlLogisticType_Add.SelectedItem.Text == "In Person")
                {
                    tblPODNo.Visible = false;
                    tblVehNo.Visible = false;
                    txtPODNo_Add0.Text = "";
                    txtVechicleNo_Add.Text = "";
                }

                string OptionCode = "";
                OptionCode = Request.QueryString["OptionCode"];

                if (OptionCode == "3")
                {
                    forOption2.Visible = true;
                    string UserT = ds1.Tables[4].Rows[0]["Usertype_Code"].ToString();
                    lblusertypeCode.Text = ds1.Tables[4].Rows[0]["Usertype_Code"].ToString();

                    txtRequestCode.Text = ds1.Tables[4].Rows[0]["Request_Code"].ToString();
                    //ddlrequi_No.Enabled = false;
                    txtRequestCode.Enabled = false;

                    btnRequi_Search.Visible = false;

                    ////


                    DataSet dsGrid = ProductController.Get_Data_ByRequNoforFinishedForEditDispatch(lblPkey.Text.Trim(), 6);
                    if (dsGrid != null)
                    {
                        if (dsGrid.Tables[0].Rows.Count > 0)
                        {
                            lblusertypeCode.Text = dsGrid.Tables[0].Rows[0]["UserTypeCode"].ToString();
                            lblreissue.Text = dsGrid.Tables[0].Rows[0]["ReIssue_Request_Code"].ToString();
                            lblUserType.Text = dsGrid.Tables[0].Rows[0]["type"].ToString();

                            if (lblusertypeCode.Text.Trim() == "UT001")
                            {
                                ControlVisibility("Student");

                                lblHeadingOP3.Text = "Student Details";
                            }
                            else if (lblusertypeCode.Text.Trim() == "UT003")
                            {
                                ControlVisibility("Teacher");
                                lblHeadingOP3.Text = "Teacher Details";
                            }
                            else if (lblusertypeCode.Text.Trim() == "UT004")
                            {
                                ControlVisibility("Employee");
                                lblHeadingOP3.Text = "Employee Details";
                            }


                            if (dsGrid.Tables[2].Rows.Count != 0)
                            {
                                DTOP3.DataSource = dsGrid.Tables[2];
                                DTOP3.DataBind();

                                ////

                                for (int cnt = 0; cnt <= ds1.Tables[1].Rows.Count - 1; cnt++)
                                {

                                    foreach (DataListItem dtlItem in DTOP3.Items)
                                    {
                                        CheckBox chkDL_Select_Centre = (CheckBox)dtlItem.FindControl("chkCheck");
                                        Label Request_EntryCode = (Label)dtlItem.FindControl("Request_EntryCode");
                                        Label lblItem_Code_DT = (Label)dtlItem.FindControl("lblItem_Code_DT");
                                        Label lblQty_DT = (Label)dtlItem.FindControl("lblQty_DT");

                                        if (dsGrid.Tables[2].Rows.Count <= cnt)
                                        {
                                            break;
                                        }

                                        if (Convert.ToString(Request_EntryCode.Text).Trim() == Convert.ToString(dsGrid.Tables[2].Rows[cnt]["Request_EntryCode"]).Trim() && Convert.ToString(lblItem_Code_DT.Text).Trim() == Convert.ToString(dsGrid.Tables[2].Rows[cnt]["Item_Code"]).Trim() && Convert.ToString(lblQty_DT.Text).Trim() == Convert.ToString(dsGrid.Tables[2].Rows[cnt]["Dispatch_Qty"]).Trim())
                                        {
                                            chkDL_Select_Centre.Checked = true;
                                            //count = count + 1;
                                            break; // TODO: might not be correct. Was : Exit For
                                        }


                                    }

                                }

                                /////
                            }
                            else
                            {
                                DTOP3.DataSource = null;
                                DTOP3.DataBind();
                            }


                        }

                    }
                    else
                    {
                        Show_Error_Success_Box("E", "Records Not Found..");
                        return;
                    }

                    ////
                }
                if (OptionCode == "4")
                {
                    forOption2.Visible = true;
                    string UserT = ds1.Tables[4].Rows[0]["Usertype_Code"].ToString();
                    lblusertypeCode.Text = ds1.Tables[4].Rows[0]["Usertype_Code"].ToString();

                    txtRequestCode.Text = ds1.Tables[4].Rows[0]["Request_Code"].ToString();
                    //ddlrequi_No.Enabled = false;
                    txtRequestCode.Enabled = false;

                    btnRequi_Search.Visible = false;

                    ////


                    DataSet dsGrid = ProductController.Get_Data_ByRequNoforFinishedForEditDispatch(lblPkey.Text.Trim(), 6);
                    if (dsGrid != null)
                    {
                        if (dsGrid.Tables[0].Rows.Count > 0)
                        {
                            lblusertypeCode.Text = dsGrid.Tables[0].Rows[0]["UserTypeCode"].ToString();
                            lblUserType.Text = dsGrid.Tables[0].Rows[0]["type"].ToString();

                            if (lblusertypeCode.Text.Trim() == "UT001")
                            {
                                ControlVisibility("Student");
                                lblHeadingOP3.Text = "Student Details";
                            }
                            else if (lblusertypeCode.Text.Trim() == "UT003")
                            {
                                ControlVisibility("Teacher");
                                lblHeadingOP3.Text = "Teacher Details";
                            }
                            else if (lblusertypeCode.Text.Trim() == "UT004")
                            {
                                ControlVisibility("Employee");
                                lblHeadingOP3.Text = "Employee Details";
                            }


                            if (dsGrid.Tables[2].Rows.Count != 0)
                            {
                                DTOP3.DataSource = dsGrid.Tables[2];
                                DTOP3.DataBind();

                                ////

                                for (int cnt = 0; cnt <= ds1.Tables[1].Rows.Count - 1; cnt++)
                                {

                                    foreach (DataListItem dtlItem in DTOP3.Items)
                                    {
                                        CheckBox chkDL_Select_Centre = (CheckBox)dtlItem.FindControl("chkCheck");
                                        Label Request_EntryCode = (Label)dtlItem.FindControl("Request_EntryCode");
                                        Label lblItem_Code_DT = (Label)dtlItem.FindControl("lblItem_Code_DT");
                                        Label lblQty_DT = (Label)dtlItem.FindControl("lblQty_DT");

                                        if (dsGrid.Tables[2].Rows.Count <= cnt)
                                        {
                                            break;
                                        }

                                        if (Convert.ToString(Request_EntryCode.Text).Trim() == Convert.ToString(dsGrid.Tables[2].Rows[cnt]["Request_EntryCode"]).Trim() && Convert.ToString(lblItem_Code_DT.Text).Trim() == Convert.ToString(dsGrid.Tables[2].Rows[cnt]["Item_Code"]).Trim() && Convert.ToString(lblQty_DT.Text).Trim() == Convert.ToString(dsGrid.Tables[2].Rows[cnt]["Dispatch_Qty"]).Trim())
                                        {
                                            chkDL_Select_Centre.Checked = true;
                                            //count = count + 1;
                                            break; // TODO: might not be correct. Was : Exit For
                                        }


                                    }

                                }

                                /////
                            }
                            else
                            {
                                DTOP3.DataSource = null;
                                DTOP3.DataBind();
                            }


                        }

                    }
                    else
                    {
                        Show_Error_Success_Box("E", "Records Not Found..");
                        return;
                    }

                    ////
                }
                else
                {
                    if (ds1.Tables[2].Rows.Count > 0)
                    {
                        lblTotal_Quantity.Text = ds1.Tables[2].Rows[0]["TotalQuantity"].ToString();
                        lblTotal_Amount.Text = ds1.Tables[2].Rows[0]["Purchase_Amount"].ToString();
                        lblTotalItem.Text = ds1.Tables[2].Rows[0]["TotalItem"].ToString();
                    }

                    if (ds1.Tables[1].Rows.Count > 0)
                    {
                        DataList2.DataSource = ds1.Tables[1];
                        DataList2.DataBind();
                    }
                    else
                    {
                        DataList2.DataSource = null;
                        DataList2.DataBind();

                    }

                    if (ds1.Tables[3].Rows.Count > 0)
                    {
                        dlQuestion.DataSource = ds1.Tables[3];
                        dlQuestion.DataBind();
                    }
                    else
                    {
                        dlQuestion.DataSource = null;
                        dlQuestion.DataBind();

                    }

                    forOption2.Visible = false;
                    if (opt == "2")
                    {
                        forOption2.Visible = true;
                        string UserT = ds1.Tables[4].Rows[0]["Usertype_Code"].ToString();
                        lblusertypeCode.Text = ds1.Tables[4].Rows[0]["Usertype_Code"].ToString();


                        lblreissue.Text = ds1.Tables[4].Rows[0]["ReIssue_Request_Code"].ToString();
                        txtRequestCode.Text = ds1.Tables[4].Rows[0]["Request_Code"].ToString();
                        //ddlrequi_No.Enabled = false;
                        txtRequestCode.Enabled = false;

                        btnRequi_Search.Visible = false;

                        if (UserT == "UT001")
                        {
                            lblUserType.Text = "Student";
                            div_student.Visible = true;
                            div_Teacher.Visible = false;
                            div_Employee.Visible = false;
                            DivForOP3.Visible = false;

                            FillGrid_Student_Edit(txtRequestCode.Text.Trim(), lblPkey.Text.Trim());

                            for (int cnt = 0; cnt <= ds1.Tables[5].Rows.Count - 1; cnt++)
                            {

                                foreach (DataListItem dtlItem in datalist_Student.Items)
                                {
                                    CheckBox chkDL_Select_Centre = (CheckBox)dtlItem.FindControl("chkCheck");
                                    Label Request_EntryCode = (Label)dtlItem.FindControl("Request_EntryCode");
                                    if (Convert.ToString(Request_EntryCode.Text).Trim() == Convert.ToString(ds1.Tables[5].Rows[cnt]["Request_EntryCode"]).Trim())
                                    {
                                        chkDL_Select_Centre.Checked = true;
                                        //count = count + 1;
                                        break; // TODO: might not be correct. Was : Exit For
                                    }
                                }

                            }

                        }
                        else if (UserT == "UT003")
                        {
                            lblUserType.Text = "Teacher";
                            div_student.Visible = false;
                            div_Teacher.Visible = true;
                            div_Employee.Visible = false;
                            DivForOP3.Visible = false;

                            FillGrid_Teacher_edit(txtRequestCode.Text.Trim(), lblPkey.Text.Trim());

                            for (int cnt = 0; cnt <= ds1.Tables[5].Rows.Count - 1; cnt++)
                            {

                                foreach (DataListItem dtlItem in datalist_Teacher.Items)
                                {
                                    CheckBox chkDL_Select_Centre = (CheckBox)dtlItem.FindControl("chkCheck");
                                    Label Request_EntryCode_TH = (Label)dtlItem.FindControl("Request_EntryCode_TH");
                                    if (Convert.ToString(Request_EntryCode_TH.Text).Trim() == Convert.ToString(ds1.Tables[5].Rows[cnt]["Request_EntryCode"]).Trim())
                                    {
                                        chkDL_Select_Centre.Checked = true;
                                        //count = count + 1;
                                        break; // TODO: might not be correct. Was : Exit For
                                    }
                                }

                            }

                        }
                        else if (UserT == "UT004")
                        {
                            lblUserType.Text = "Employee";
                            div_student.Visible = false;
                            div_Teacher.Visible = false;
                            div_Employee.Visible = true;
                            DivForOP3.Visible = false;

                            FillGrid_Employee(txtRequestCode.Text.Trim());
                        }
                    }
                }


            }


        }

        else if (e.CommandName == "comAuthorise")
        {
            lblPkey.Text = "";
            ControlVisibility("Authorise");
            Clear_Error_Success_Box();
            string pkey = e.CommandArgument.ToString();
            DataSet ds1 = null;
            ds1 = ProductController.Get_Dispatch_ItemById(6, pkey);

            if (ds1.Tables[1].Rows.Count > 0)
            {
                dlItemListAuthorise.DataSource = ds1.Tables[1];
                dlItemListAuthorise.DataBind();
            }
            else
            {
                dlItemListAuthorise.DataSource = null;
                dlItemListAuthorise.DataBind();

            }
        }
        else if (e.CommandName == "print")
        {
            string Dispatch_code = "";
            Dispatch_code = e.CommandArgument.ToString();
            Session["Dispatch_code"] = e.CommandArgument.ToString();
            //HtmlAnchor aprint = new HtmlAnchor();



            //aprint.HRef = "Manage_DispatchPrint.aspx?Dispatch_code=" + Dispatch_code;

            Response.Redirect("Dispatch_Print_For_Oldchallan.aspx?Dispatch_code=" + Dispatch_code);

        }

    }



    protected void dlQuestion_ItemCommand(object source, DataListCommandEventArgs e)
    {


        if (e.CommandName == "ItemRemove")
        {
            lblCodeRemove.Text = e.CommandArgument.ToString().Trim();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalDivCOnfirmation();", true);

        }

    }

    protected void btnDivConfirmYes_Click(object sender, System.EventArgs e)
    {
        Clear_Error_Success_Box();

        string pkeyMaterialCode_DT = "";
        DataTable dtCorrectEntry = new DataTable();
        DataRow NewRow = null;

        string TempDispatchEntry = "";

        var _with1 = dtCorrectEntry;
        _with1.Columns.Add("Dispatch_Code");
        _with1.Columns.Add("DispatchEntry_Code");
        _with1.Columns.Add("Item_Code");
        _with1.Columns.Add("Item_Name");
        _with1.Columns.Add("Purchase_Amount");
        _with1.Columns.Add("Purchase_Rate");
        _with1.Columns.Add("Barcode");
        _with1.Columns.Add("Dispatch_Qty");
        _with1.Columns.Add("Asset_No");
        _with1.Columns.Add("Pkey");
        _with1.Columns.Add("InwardEntry_Code");
        _with1.Columns.Add("Inward_Code");
        _with1.Columns.Add("Inward_Qty");
        _with1.Columns.Add("is_Acknowledged");
        _with1.Columns.Add("Request_EntryCode");

        int Total_Item_Count = 0;
        int Total_Quantity = 0;
        decimal Total_Amount = 0;

        foreach (DataListItem item in dlQuestion.Items)
        {
            if (item.ItemType == ListItemType.Item | item.ItemType == ListItemType.AlternatingItem)
            {

                Label lblDispatch_Code = (Label)item.FindControl("lblDispatch_Code");
                Label lblDispatchEntry_Code = (Label)item.FindControl("lblDispatchEntry_Code");
                Label lblItem_Code_DT = (Label)item.FindControl("lblItem_Code_DT");
                Label lblItemName_DT = (Label)item.FindControl("lblItemName_DT");
                Label lblBarcode_DT = (Label)item.FindControl("lblBarcode_DT");
                Label lblAssetNo_DT = (Label)item.FindControl("lblAssetNo_DT");
                Label lblQty_DT = (Label)item.FindControl("lblQty_DT");
                Label lblUnitPrice_DT = (Label)item.FindControl("lblUnitPrice_DT");
                Label lblAmount_DT = (Label)item.FindControl("lblAmount_DT");
                Label lblPkey_Code = (Label)item.FindControl("lblPkey_Code");
                Label lblInward_Code = (Label)item.FindControl("lblInward_Code");
                Label lblInwardEntry_Code_DL = (Label)item.FindControl("lblInwardEntry_Code_DL");
                Label Inward_Qty = (Label)item.FindControl("Inward_Qty");
                Label lblis_Acknowledged = (Label)item.FindControl("lblis_Acknowledged");
                Label lblRequestEntry_Code_Grid = (Label)item.FindControl("lblRequestEntry_Code_Grid");

                if (lblPkey_Code.Text == lblCodeRemove.Text)
                {
                    NewRow = dtCorrectEntry.NewRow();
                    NewRow["Dispatch_Code"] = lblDispatch_Code.Text.Trim();
                    NewRow["DispatchEntry_Code"] = lblDispatchEntry_Code.Text.Trim();
                    TempDispatchEntry = lblDispatchEntry_Code.Text.Trim();
                    NewRow["Item_Code"] = lblItem_Code_DT.Text.Trim();
                    NewRow["Item_Name"] = lblItemName_DT.Text.Trim();
                    NewRow["Barcode"] = lblBarcode_DT.Text.Trim();
                    NewRow["Asset_No"] = lblAssetNo_DT.Text.Trim();
                    NewRow["Dispatch_Qty"] = "0";
                    NewRow["Purchase_Rate"] = "0";
                    NewRow["Purchase_Amount"] = "0";
                    NewRow["Pkey"] = lblPkey_Code.Text.Trim();
                    NewRow["InwardEntry_Code"] = lblInwardEntry_Code_DL.Text.Trim();
                    NewRow["Inward_Code"] = lblInward_Code.Text.Trim();
                    NewRow["Inward_Qty"] = Inward_Qty.Text.Trim();
                    NewRow["is_Acknowledged"] = lblis_Acknowledged.Text.Trim();
                    NewRow["Request_EntryCode"] = lblRequestEntry_Code_Grid.Text.Trim();

                    dtCorrectEntry.Rows.Add(NewRow);
                }
                else
                {
                    NewRow = dtCorrectEntry.NewRow();
                    NewRow["Dispatch_Code"] = lblDispatch_Code.Text.Trim();
                    NewRow["DispatchEntry_Code"] = lblDispatchEntry_Code.Text.Trim();
                    NewRow["Item_Code"] = lblItem_Code_DT.Text.Trim();
                    NewRow["Item_Name"] = lblItemName_DT.Text.Trim();
                    NewRow["Barcode"] = lblBarcode_DT.Text.Trim();
                    NewRow["Asset_No"] = lblAssetNo_DT.Text.Trim();
                    NewRow["Dispatch_Qty"] = lblQty_DT.Text.Trim();
                    NewRow["Purchase_Rate"] = lblUnitPrice_DT.Text.Trim();
                    NewRow["Purchase_Amount"] = lblAmount_DT.Text.Trim();
                    NewRow["Pkey"] = lblPkey_Code.Text.Trim();
                    NewRow["InwardEntry_Code"] = lblInwardEntry_Code_DL.Text.Trim();
                    NewRow["Inward_Code"] = lblInward_Code.Text.Trim();
                    NewRow["Inward_Qty"] = Inward_Qty.Text.Trim();
                    NewRow["is_Acknowledged"] = lblis_Acknowledged.Text.Trim();
                    NewRow["Request_EntryCode"] = lblRequestEntry_Code_Grid.Text.Trim();

                    dtCorrectEntry.Rows.Add(NewRow);
                }
            }
        }

        //
        //TEmp Data
        DataTable dtTempEntry = new DataTable();
        DataRow NewRow1 = null;

        var _with2 = dtTempEntry;
        _with2.Columns.Add("Dispatch_Code");
        _with2.Columns.Add("DispatchEntry_Code");
        _with2.Columns.Add("Item_Code");
        _with2.Columns.Add("Item_Name");
        _with2.Columns.Add("Purchase_Amount");
        _with2.Columns.Add("Purchase_Rate");
        _with2.Columns.Add("Barcode");
        _with2.Columns.Add("Dispatch_Qty");
        _with2.Columns.Add("Asset_No");
        _with2.Columns.Add("Pkey");
        _with2.Columns.Add("InwardEntry_Code");
        _with2.Columns.Add("Inward_Code");
        _with2.Columns.Add("Inward_Qty");
        _with2.Columns.Add("is_Acknowledged");
        _with2.Columns.Add("Request_EntryCode");

        foreach (DataListItem item in DataList2.Items)
        {
            if (item.ItemType == ListItemType.Item | item.ItemType == ListItemType.AlternatingItem)
            {

                Label lblDispatch_Code = (Label)item.FindControl("lblDispatch_Code");
                Label lblDispatchEntry_Code = (Label)item.FindControl("lblDispatchEntry_Code");
                Label lblItem_Code_DT = (Label)item.FindControl("lblItem_Code_DT");
                Label lblItemName_DT = (Label)item.FindControl("lblItemName_DT");
                Label lblBarcode_DT = (Label)item.FindControl("lblBarcode_DT");
                Label lblAssetNo_DT = (Label)item.FindControl("lblAssetNo_DT");
                Label lblQty_DT = (Label)item.FindControl("lblQty_DT");
                Label lblUnitPrice_DT = (Label)item.FindControl("lblUnitPrice_DT");
                Label lblAmount_DT = (Label)item.FindControl("lblAmount_DT");
                Label lblPkey_Code = (Label)item.FindControl("lblPkey_Code");
                Label lblInward_Code = (Label)item.FindControl("lblInward_Code");
                Label lblInwardEntry_Code_DL = (Label)item.FindControl("lblInwardEntry_Code_DL");
                Label Inward_Qty = (Label)item.FindControl("Inward_Qty");
                Label lblis_Acknowledged = (Label)item.FindControl("lblis_Acknowledged");
                Label lblRequestEntry_Code_Grid = (Label)item.FindControl("lblRequestEntry_Code_Grid");

                //if (lblPkey_Code.Text == lblCodeRemove.Text)

                if (TempDispatchEntry != "")
                {
                    if (lblDispatchEntry_Code.Text == TempDispatchEntry)
                    //if (lblPkey_Code.Text == lblCodeRemove.Text)
                    {
                        NewRow1 = dtTempEntry.NewRow();
                        NewRow1["Dispatch_Code"] = lblDispatch_Code.Text.Trim();
                        NewRow1["DispatchEntry_Code"] = lblDispatchEntry_Code.Text.Trim();
                        NewRow1["Item_Code"] = lblItem_Code_DT.Text.Trim();
                        NewRow1["Item_Name"] = lblItemName_DT.Text.Trim();
                        NewRow1["Barcode"] = lblBarcode_DT.Text.Trim();
                        NewRow1["Asset_No"] = lblAssetNo_DT.Text.Trim();
                        NewRow1["Dispatch_Qty"] = "0";
                        NewRow1["Purchase_Rate"] = "0";
                        NewRow1["Purchase_Amount"] = "0";
                        NewRow1["Pkey"] = lblPkey_Code.Text.Trim();
                        NewRow1["InwardEntry_Code"] = lblInwardEntry_Code_DL.Text.Trim();
                        NewRow1["Inward_Code"] = lblInward_Code.Text.Trim();
                        NewRow1["Inward_Qty"] = Inward_Qty.Text.Trim();
                        NewRow1["is_Acknowledged"] = lblis_Acknowledged.Text.Trim();
                        NewRow1["Request_EntryCode"] = lblRequestEntry_Code_Grid.Text.Trim();

                        dtTempEntry.Rows.Add(NewRow1);
                    }
                    else
                    {
                        NewRow1 = dtTempEntry.NewRow();
                        NewRow1["Dispatch_Code"] = lblDispatch_Code.Text.Trim();
                        NewRow1["DispatchEntry_Code"] = lblDispatchEntry_Code.Text.Trim();
                        NewRow1["Item_Code"] = lblItem_Code_DT.Text.Trim();
                        NewRow1["Item_Name"] = lblItemName_DT.Text.Trim();
                        NewRow1["Barcode"] = lblBarcode_DT.Text.Trim();
                        NewRow1["Asset_No"] = lblAssetNo_DT.Text.Trim();
                        NewRow1["Dispatch_Qty"] = lblQty_DT.Text.Trim();
                        NewRow1["Purchase_Rate"] = lblUnitPrice_DT.Text.Trim();
                        NewRow1["Purchase_Amount"] = lblAmount_DT.Text.Trim();
                        NewRow1["Pkey"] = lblPkey_Code.Text.Trim();
                        NewRow1["InwardEntry_Code"] = lblInwardEntry_Code_DL.Text.Trim();
                        NewRow1["Inward_Code"] = lblInward_Code.Text.Trim();
                        NewRow1["Inward_Qty"] = Inward_Qty.Text.Trim();
                        NewRow1["is_Acknowledged"] = lblis_Acknowledged.Text.Trim();
                        NewRow1["Request_EntryCode"] = lblRequestEntry_Code_Grid.Text.Trim();

                        dtTempEntry.Rows.Add(NewRow1);
                    }
                }

                else
                {
                    //if (lblDispatchEntry_Code.Text == TempDispatchEntry)
                    if (lblPkey_Code.Text == lblCodeRemove.Text)
                    {
                        NewRow1 = dtTempEntry.NewRow();
                        NewRow1["Dispatch_Code"] = lblDispatch_Code.Text.Trim();
                        NewRow1["DispatchEntry_Code"] = lblDispatchEntry_Code.Text.Trim();
                        NewRow1["Item_Code"] = lblItem_Code_DT.Text.Trim();
                        NewRow1["Item_Name"] = lblItemName_DT.Text.Trim();
                        NewRow1["Barcode"] = lblBarcode_DT.Text.Trim();
                        NewRow1["Asset_No"] = lblAssetNo_DT.Text.Trim();
                        NewRow1["Dispatch_Qty"] = "0";
                        NewRow1["Purchase_Rate"] = "0";
                        NewRow1["Purchase_Amount"] = "0";
                        NewRow1["Pkey"] = lblPkey_Code.Text.Trim();
                        NewRow1["InwardEntry_Code"] = lblInwardEntry_Code_DL.Text.Trim();
                        NewRow1["Inward_Code"] = lblInward_Code.Text.Trim();
                        NewRow1["Inward_Qty"] = Inward_Qty.Text.Trim();
                        NewRow1["is_Acknowledged"] = lblis_Acknowledged.Text.Trim();
                        NewRow1["Request_EntryCode"] = lblRequestEntry_Code_Grid.Text.Trim();

                        dtTempEntry.Rows.Add(NewRow1);
                    }
                    else
                    {
                        NewRow1 = dtTempEntry.NewRow();
                        NewRow1["Dispatch_Code"] = lblDispatch_Code.Text.Trim();
                        NewRow1["DispatchEntry_Code"] = lblDispatchEntry_Code.Text.Trim();
                        NewRow1["Item_Code"] = lblItem_Code_DT.Text.Trim();
                        NewRow1["Item_Name"] = lblItemName_DT.Text.Trim();
                        NewRow1["Barcode"] = lblBarcode_DT.Text.Trim();
                        NewRow1["Asset_No"] = lblAssetNo_DT.Text.Trim();
                        NewRow1["Dispatch_Qty"] = lblQty_DT.Text.Trim();
                        NewRow1["Purchase_Rate"] = lblUnitPrice_DT.Text.Trim();
                        NewRow1["Purchase_Amount"] = lblAmount_DT.Text.Trim();
                        NewRow1["Pkey"] = lblPkey_Code.Text.Trim();
                        NewRow1["InwardEntry_Code"] = lblInwardEntry_Code_DL.Text.Trim();
                        NewRow1["Inward_Code"] = lblInward_Code.Text.Trim();
                        NewRow1["Inward_Qty"] = Inward_Qty.Text.Trim();
                        NewRow1["is_Acknowledged"] = lblis_Acknowledged.Text.Trim();
                        NewRow1["Request_EntryCode"] = lblRequestEntry_Code_Grid.Text.Trim();

                        dtTempEntry.Rows.Add(NewRow1);
                    }
                }


            }
        }


        //


        DataList2.DataSource = dtTempEntry;
        DataList2.DataBind();

        DataRow[] rows;
        rows = dtCorrectEntry.Select("Pkey = '" + lblCodeRemove.Text + "'");
        foreach (DataRow row in rows)
            dtCorrectEntry.Rows.Remove(row);



        int count = 0;
        foreach (DataRow dr in dtCorrectEntry.Rows) // search whole table
        {
            count++;
            dr["Pkey"] = count.ToString(); //change the name                  
            Total_Quantity = Total_Quantity + Convert.ToInt32(dr["Dispatch_Qty"]);
            Total_Amount = Total_Amount + Convert.ToDecimal(dr["Purchase_Amount"]);

        }
        lblTotalItem.Text = count.ToString();
        lblTotal_Quantity.Text = Total_Quantity.ToString();
        lblTotal_Amount.Text = Total_Amount.ToString();

        dlQuestion.DataSource = dtCorrectEntry;
        dlQuestion.DataBind();
    }

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

    protected void ddlTransferTO_SR_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTransferTO_SR.SelectedItem.ToString().Trim() == "Godown")
        {
            tblTO_Godown.Visible = true;
            tblTO_Function.Visible = false;
            tblTO_Division.Visible = false;
            tblTO_Center.Visible = false;
        }
        else if (ddlTransferTO_SR.SelectedItem.ToString().Trim() == "Function")
        {
            tblTO_Function.Visible = true;
            tblTO_Godown.Visible = false;
            tblTO_Division.Visible = false;
            tblTO_Center.Visible = false;
        }
        else if (ddlTransferTO_SR.SelectedItem.ToString().Trim() == "Center")
        {
            tblTO_Division.Visible = true;
            tblTO_Center.Visible = true;
            tblTO_Function.Visible = false;
            tblTO_Godown.Visible = false;
        }
        else if (ddlTransferTO_SR.SelectedIndex == 0 || ddlTransferTO_SR.SelectedIndex == -1)
        {
            tblTO_Godown.Visible = false;
            tblTO_Function.Visible = false;
            tblTO_Division.Visible = false;
            tblTO_Center.Visible = false;
        }
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

        BindDDL(ddlDivisionTO_SR, dsDivision, "Division_Name", "Division_Code");
        ddlDivisionTO_SR.Items.Insert(0, "Select");
        ddlDivisionTO_SR.SelectedIndex = 0;

        //Add DDL
        BindDDL(ddlDivisionFR_Add, dsDivision, "Division_Name", "Division_Code");
        ddlDivisionFR_Add.Items.Insert(0, "Select");
        ddlDivisionFR_Add.SelectedIndex = 0;

        BindDDL(ddlDivisionTO_Add, dsDivision, "Division_Name", "Division_Code");
        ddlDivisionTO_Add.Items.Insert(0, "Select");
        ddlDivisionTO_Add.SelectedIndex = 0;

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

    private void FillDDL_TOSearch_Centre()
    {
        string Company_Code = "MT";
        string DBname = "CDB";

        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];

        string Div_Code = null;
        Div_Code = ddlDivisionTO_SR.SelectedValue;

        DataSet dsCentre = ProductController.GetAllActiveUser_Company_Division_Zone_Center(UserID, Company_Code, Div_Code, "", "5", DBname);

        BindDDL(ddlCenterTO_SR, dsCentre, "Center_Name", "Center_Code");
        ddlCenterTO_SR.Items.Insert(0, "Select");
        ddlCenterTO_SR.SelectedIndex = 0;
    }

    protected void ddlDivisionTO_SR_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlCenterTO_SR.Items.Clear();
        FillDDL_TOSearch_Centre();
    }

    protected void ddlTransferFR_Add_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTransferFR_Add.SelectedItem.ToString().Trim() == "Godown")
        {
            tblFR_Godown_Add.Visible = true;
            tblFR_Function_Add.Visible = false;
            tblFR_Division_Add.Visible = false;
            tblFR_Center_Add.Visible = false;
        }
        else if (ddlTransferFR_Add.SelectedItem.ToString().Trim() == "Function")
        {
            tblFR_Function_Add.Visible = true;
            tblFR_Godown_Add.Visible = false;
            tblFR_Division_Add.Visible = false;
            tblFR_Center_Add.Visible = false;
        }
        else if (ddlTransferFR_Add.SelectedItem.ToString().Trim() == "Center")
        {
            tblFR_Division_Add.Visible = true;
            tblFR_Center_Add.Visible = true;
            tblFR_Function_Add.Visible = false;
            tblFR_Godown_Add.Visible = false;
        }
        else if (ddlTransferFR_Add.SelectedIndex == 0 || ddlTransferFR_Add.SelectedIndex == -1)
        {
            tblFR_Godown_Add.Visible = false;
            tblFR_Function_Add.Visible = false;
            tblFR_Division_Add.Visible = false;
            tblFR_Center_Add.Visible = false;
        }
    }

    protected void ddlTransferTO_Add_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTransferTO_Add.SelectedItem.ToString().Trim() == "Godown")
        {
            tblTO_Godown_Add.Visible = true;
            tblTO_Function_Add.Visible = false;
            tblTO_Division_Add.Visible = false;
            tblTO_Center_Add.Visible = false;
        }
        else if (ddlTransferTO_Add.SelectedItem.ToString().Trim() == "Function")
        {
            tblTO_Function_Add.Visible = true;
            tblTO_Godown_Add.Visible = false;
            tblTO_Division_Add.Visible = false;
            tblTO_Center_Add.Visible = false;
        }
        else if (ddlTransferTO_Add.SelectedItem.ToString().Trim() == "Center")
        {
            tblTO_Division_Add.Visible = true;
            tblTO_Center_Add.Visible = true;
            tblTO_Function_Add.Visible = false;
            tblTO_Godown_Add.Visible = false;
        }
        else if (ddlTransferTO_Add.SelectedIndex == 0 || ddlTransferTO_SR.SelectedIndex == -1)
        {
            tblTO_Godown_Add.Visible = false;
            tblTO_Function_Add.Visible = false;
            tblTO_Division_Add.Visible = false;
            tblTO_Center_Add.Visible = false;
        }
    }

    protected void ddlDivisionFR_Add_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlCenterFR_Add.Items.Clear();
        FillDDL_FRAdd_Centre();

    }

    protected void ddlDivisionTO_Add_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlCenterTO_Add.Items.Clear();
        FillDDL_TOAdd_Centre();
    }

    protected void txtItemRate_TextChanged(object sender, EventArgs e)
    {
        Clear_Error_Success_Box();

        //if (txtItemQty.Text.Trim() == "")
        //{
        //    Show_Error_Success_Box("E", "Enter Item Quantity");
        //    txtItemQty.Focus();
        //    return;
        //}
        //int Qty1 = 0, Rate1 = 0;
        //double Qty, Rate;
        //if (double.TryParse(txtItemQty.Text.Trim(), out Qty))
        //{
        //    Qty1 = Convert.ToInt32(txtItemQty.Text.Trim());

        //}
        //else
        //{
        //    Show_Error_Success_Box("E", "Enter Numeric only");
        //    txtItemQty.Focus();
        //    return;
        //}

        //if (double.TryParse(txtItemRate.Text.Trim(), out Rate))
        //{
        //    Rate1 = Convert.ToInt32(txtItemRate.Text.Trim());

        //}
        //else
        //{
        //    Show_Error_Success_Box("E", "Enter Numeric only");
        //    txtItemQty.Focus();
        //    return;
        //}

        //int CalAns = Qty1 * Rate1;

        //lblCalValue.Text = CalAns.ToString();

    }

    protected void ddlLogisticType_Add_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlLogisticType_Add.SelectedIndex == 0 || ddlLogisticType_Add.SelectedIndex == -1)
        {
            tblPODNo.Visible = false;
            tblVehNo.Visible = false;
        }
        else if (ddlLogisticType_Add.SelectedItem.ToString().Trim() == "Courier")
        {
            tblPODNo.Visible = true;
            tblVehNo.Visible = false;
        }
        else if (ddlLogisticType_Add.SelectedItem.ToString().Trim() == "In Person")
        {
            tblPODNo.Visible = false;
            tblVehNo.Visible = false;
        }
        else if (ddlLogisticType_Add.SelectedItem.ToString().Trim() == "Transport")
        {
            tblPODNo.Visible = false;
            tblVehNo.Visible = true;
        }
    }

    private void FillDDL_FRAdd_Centre()
    {

        ddlCenterFR_Add.Items.Clear();

        string Company_Code = "MT";
        string DBname = "CDB";

        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];

        string Div_Code = null;
        Div_Code = ddlDivisionFR_Add.SelectedValue;

        DataSet dsCentre = ProductController.GetAllActiveUser_Company_Division_Zone_Center(UserID, Company_Code, Div_Code, "", "5", DBname);

        BindDDL(ddlCenterFR_Add, dsCentre, "Center_Name", "Center_Code");
        ddlCenterFR_Add.Items.Insert(0, "Select");
        ddlCenterFR_Add.SelectedIndex = 0;
    }

    private void FillDDL_TOAdd_Centre()
    {
        ddlCenterTO_Add.Items.Clear();
        string Company_Code = "MT";
        string DBname = "CDB";

        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];

        string Div_Code = null;
        Div_Code = ddlDivisionTO_Add.SelectedValue;

        DataSet dsCentre = ProductController.GetAllActiveUser_Company_Division_Zone_Center(UserID, Company_Code, Div_Code, "", "5", DBname);

        BindDDL(ddlCenterTO_Add, dsCentre, "Center_Name", "Center_Code");
        ddlCenterTO_Add.Items.Insert(0, "Select");
        ddlCenterTO_Add.SelectedIndex = 0;
    }

    private void FillDDL_Logistic()
    {
        ddlLogisticType_Add.Items.Clear();
        DataSet dsTransfer_Tp = ProductController.GetGodown_Function_Logistic_Assests_Type(5);
        BindDDL(ddlLogisticType_Add, dsTransfer_Tp, "Logistic_Type_Name", "Logistic_Type_Id");
        ddlLogisticType_Add.Items.Insert(0, "Select Logistic");
        ddlLogisticType_Add.SelectedIndex = 0;
    }

    private bool ControlValidation()
    {
        Clear_Error_Success_Box();
        bool Flag = true;

        if (ddlTransferFR_Add.SelectedValue == "Select Transfer From")
        {
            Show_Error_Success_Box("E", "Select Transfer From");
            ddlTransferFR_Add.Focus();
            Flag = false;

        }


        else if (ddlTransferTO_Add.SelectedValue == "Select Transfer To")
        {
            Show_Error_Success_Box("E", "Select Transfer To");
            ddlTransferTO_Add.Focus();
            Flag = false;
        }

        else if (ddlTransferFR_Add.SelectedItem.Text == "Godown" && ddlGodownFR_Add.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "Select Transfer From Godown");
            ddlTransferFR_Add.Focus();
            Flag = false;
        }

        else if (ddlTransferFR_Add.SelectedItem.Text == "Function" && ddlFunctionFR_Add.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "Select Transfer From Function");
            ddlTransferFR_Add.Focus();
            Flag = false;

        }
        else if (ddlTransferFR_Add.SelectedItem.Text == "Center" && ddlDivisionFR_Add.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "Select Transfer From Division");
            ddlTransferFR_Add.Focus();
            Flag = false;
        }
        else if (ddlTransferFR_Add.SelectedItem.Text == "Center" && ddlCenterFR_Add.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "Select Transfer From Center");
            ddlTransferFR_Add.Focus();
            Flag = false;
        }
        else if (ddlDivisionFR_Add.SelectedValue != "0" && ddlCenterFR_Add.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "Select Transfer From Center");
            ddlTransferFR_Add.Focus();
            Flag = false;
        }


         //---------------
        else if (ddlTransferTO_Add.SelectedItem.Text == "Godown" && ddlGodownTO_Add.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "Select Transfer To Godown");
            ddlTransferFR_Add.Focus();
            Flag = false;
        }

        else if (ddlTransferTO_Add.SelectedItem.Text == "Function" && ddlFunctionTO_Add.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "Select Transfer To Function");
            ddlTransferFR_Add.Focus();
            Flag = false;
        }
        else if (ddlTransferTO_Add.SelectedItem.Text == "Center" && ddlDivisionTO_Add.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "Select Transfer To Division");
            ddlTransferFR_Add.Focus();
            Flag = false;
        }
        else if (ddlTransferTO_Add.SelectedItem.Text == "Center" && ddlCenterTO_Add.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "Select Transfer To Center");
            ddlTransferFR_Add.Focus();
            Flag = false;
        }
        else if (ddlDivisionFR_Add.SelectedValue != "0" && ddlCenterTO_Add.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "Select Transfer To Center");
            ddlTransferFR_Add.Focus();
            Flag = false;
        }




         //----------------------------



        //else if (ddlGodownFR_Add.SelectedValue != "Select" && ddlGodownTO_Add.SelectedValue != "Select" && ddlGodownFR_Add.SelectedValue == ddlGodownTO_Add.SelectedValue)
        //{
        //    Show_Error_Success_Box("E", "Godown Transfer From and To can't be same. ");
        //    Flag = false;
        //}

        //else if (ddlFunctionFR_Add.SelectedValue != "Select" && ddlFunctionTO_Add.SelectedValue != "Select" && ddlFunctionTO_Add.SelectedValue == ddlFunctionFR_Add.SelectedValue)
        //{
        //    Show_Error_Success_Box("E", "Function Transfer From and To can't be same. ");
        //    Flag = false;
        //}

        //else if (ddlCenterFR_Add.SelectedValue != "Select" && ddlCenterTO_Add.SelectedValue != "Select" && ddlCenterFR_Add.SelectedValue == ddlCenterTO_Add.SelectedValue)
        //{
        //    Show_Error_Success_Box("E", "Center Transfer From and To can't be same. ");
        //    Flag = false;
        //}

        else if (txtContactPerson_Add.Text.Trim() == "")
        {
            Show_Error_Success_Box("E", "Enter Contact Person name");
            Flag = false;
            txtContactPerson_Add.Focus();

        }
        //else if (DataList2.Items.Count == 0)
        //{

        //    Show_Error_Success_Box("E", "Select atleast one material detail");
        //    Flag = false;
        //    ddlTransferFR_Add.Focus();
        //}

        else if (ddlLogisticType_Add.SelectedValue == "Select")
        {

            Show_Error_Success_Box("E", "Select Logistic Type ");
            Flag = false;
            ddlLogisticType_Add.Focus();
        }
        else if (txtLogisticDetails_Add.Text.Trim() == "")
        {

            Show_Error_Success_Box("E", "Enter Logistic Details");
            Flag = false;
            txtLogisticDetails_Add.Focus();
        }

        return Flag;

    }

    protected void txtItemQty_TextChanged(object sender, EventArgs e)
    {
        decimal Qty1 = 0, Rate1 = 0;
        double Qty, Rate;
        if (double.TryParse(txtItemQty.Text.Trim(), out Qty))
        {
            Qty1 = Convert.ToInt32(txtItemQty.Text.Trim());

        }
        else
        {
            Show_Error_Success_Box("E", "Enter Numeric only");
            txtItemQty.Focus();
            return;
        }

        if (double.TryParse(txtItemRate.Text.Trim(), out Rate))
        {
            Rate1 = Convert.ToDecimal(txtItemRate.Text.Trim());

        }
        else
        {
            Show_Error_Success_Box("E", "Enter Numeric only");
            txtItemQty.Focus();
            return;
        }

        decimal CalAns = Qty1 * Rate1;

        lblCalValue.Text = CalAns.ToString();

    }

    protected void chkAttendanceAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox s = sender as CheckBox;

        //Set checked status of hidden check box to items in grid
        foreach (DataListItem dtlItem in datalist_Student.Items)
        {
            CheckBox chkitemck = (CheckBox)dtlItem.FindControl("chkCheck");
            //System.Web.UI.HtmlControls.HtmlInputCheckBox chkitemck = (System.Web.UI.HtmlControls.HtmlInputCheckBox)dtlItem.FindControl("chkDL_Select_Center");
            chkitemck.Checked = s.Checked;
        }
    }
    protected void chkTeachereAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox s = sender as CheckBox;

        //Set checked status of hidden check box to items in grid
        foreach (DataListItem dtlItem in datalist_Teacher.Items)
        {
            CheckBox chkitemck = (CheckBox)dtlItem.FindControl("chkCheck");
            //System.Web.UI.HtmlControls.HtmlInputCheckBox chkitemck = (System.Web.UI.HtmlControls.HtmlInputCheckBox)dtlItem.FindControl("chkDL_Select_Center");
            chkitemck.Checked = s.Checked;
        }
    }

    protected void chkAttendance_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox s = sender as CheckBox;

        //Set checked status of hidden check box to items in grid
        foreach (DataListItem dtlItem in DTOP3.Items)
        {
            CheckBox chkitemck = (CheckBox)dtlItem.FindControl("chkCheck");
            //System.Web.UI.HtmlControls.HtmlInputCheckBox chkitemck = (System.Web.UI.HtmlControls.HtmlInputCheckBox)dtlItem.FindControl("chkDL_Select_Center");
            chkitemck.Checked = s.Checked;
        }
    }

    protected void chkItem_CheckedChanged(object sender, EventArgs e)
    {
        //Set checked status of hidden check box to items in grid

        CheckBox s = sender as CheckBox;
        foreach (DataListItem dtlItem in dladditem.Items)
        {
            CheckBox chkitemck = (CheckBox)dtlItem.FindControl("chkCheck");

            chkitemck.Checked = s.Checked;
        }
        UpdatePanel3.Update();
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalDivOverride1();", true);


    }

    protected void chkAuthorise_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox s = sender as CheckBox;

        //Set checked status of hidden check box to items in grid
        foreach (DataListItem dtlItem in dlItemListAuthorise.Items)
        {
            CheckBox chkitemck = (CheckBox)dtlItem.FindControl("chkCheck");
            //System.Web.UI.HtmlControls.HtmlInputCheckBox chkitemck = (System.Web.UI.HtmlControls.HtmlInputCheckBox)dtlItem.FindControl("chkDL_Select_Center");
            chkitemck.Checked = s.Checked;
        }
    }

    protected void btnCloseAuthorise_Click(object sender, EventArgs e)
    {

    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        //lblPkey.Text
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        string opt = null;

        opt = Request.QueryString["OptionCode"];
        if (opt == "2" || opt == "3" || opt == "4")
        {
            Server.Transfer("DispatchRequest_Print.aspx?DispatchCode=" + lblPkey.Text + "&UserID=" + UserID);
        }
        else
        {
            Server.Transfer("Dispatch_Print_For_Oldchallan.aspx?DispatchCode=" + lblPkey.Text + "&UserID=" + UserID);
        }


    }

    private void If(bool p)
    {
        throw new NotImplementedException();
    }
    protected void btnRequi_Search_Click(object sender, EventArgs e)
    {
        try
        {
            Clear_Error_Success_Box();
            string opt = null;
            opt = Request.QueryString["OptionCode"];

            if (opt == "2")
            {


                if (ddlTransferFR_Add.SelectedValue == "Select Transfer From")
                {
                    Show_Error_Success_Box("E", "Select Transfer From");
                    ddlTransferFR_Add.Focus();
                    return;

                }


                else if (ddlTransferTO_Add.SelectedValue == "Select Transfer To")
                {
                    Show_Error_Success_Box("E", "Select Transfer To");
                    ddlTransferTO_Add.Focus();
                    return;
                }

                else if (ddlTransferFR_Add.SelectedItem.Text == "Godown" && ddlGodownFR_Add.SelectedValue == "0")
                {
                    Show_Error_Success_Box("E", "Select Transfer From Godown");
                    ddlTransferFR_Add.Focus();
                    return;
                }

                else if (ddlTransferFR_Add.SelectedItem.Text == "Function" && ddlFunctionFR_Add.SelectedValue == "0")
                {
                    Show_Error_Success_Box("E", "Select Transfer From Function");
                    ddlTransferFR_Add.Focus();
                    return;

                }
                else if (ddlTransferFR_Add.SelectedItem.Text == "Center" && ddlDivisionFR_Add.SelectedValue == "0")
                {
                    Show_Error_Success_Box("E", "Select Transfer From Division");
                    ddlTransferFR_Add.Focus();
                    return;
                }
                else if (ddlTransferFR_Add.SelectedItem.Text == "Center" && ddlCenterFR_Add.SelectedValue == "0")
                {
                    Show_Error_Success_Box("E", "Select Transfer From Center");
                    ddlTransferFR_Add.Focus();
                    return;
                }
                else if (ddlDivisionFR_Add.SelectedValue != "0" && ddlCenterFR_Add.SelectedValue == "0")
                {
                    Show_Error_Success_Box("E", "Select Transfer From Center");
                    ddlTransferFR_Add.Focus();
                    return;
                }


                 //---------------
                else if (ddlTransferTO_Add.SelectedItem.Text == "Godown" && ddlGodownTO_Add.SelectedValue == "0")
                {
                    Show_Error_Success_Box("E", "Select Transfer To Godown");
                    ddlTransferFR_Add.Focus();
                    return;
                }

                else if (ddlTransferTO_Add.SelectedItem.Text == "Function" && ddlFunctionTO_Add.SelectedValue == "0")
                {
                    Show_Error_Success_Box("E", "Select Transfer To Function");
                    ddlTransferFR_Add.Focus();
                    return;
                }
                else if (ddlTransferTO_Add.SelectedItem.Text == "Center" && ddlDivisionTO_Add.SelectedValue == "0")
                {
                    Show_Error_Success_Box("E", "Select Transfer To Division");
                    ddlTransferFR_Add.Focus();
                    return;
                }
                else if (ddlTransferTO_Add.SelectedItem.Text == "Center" && ddlCenterTO_Add.SelectedValue == "0")
                {
                    Show_Error_Success_Box("E", "Select Transfer To Center");
                    ddlTransferFR_Add.Focus();
                    return;
                }
                else if (ddlDivisionFR_Add.SelectedValue != "0" && ddlCenterTO_Add.SelectedValue == "0")
                {
                    Show_Error_Success_Box("E", "Select Transfer To Center");
                    ddlTransferFR_Add.Focus();
                    return;
                }


                if (txtRequestCode.Text == "")
                {
                    Show_Error_Success_Box("E", "Enter Request Code");
                    txtRequestCode.Focus();
                    return;
                }

                DataSet dsGrid = ProductController.Get_Data_ByRequNo(txtRequestCode.Text.Trim(), "4", "");
                if (dsGrid != null)
                {
                    if (dsGrid.Tables[0].Rows.Count > 0)
                    {
                        lblusertypeCode.Text = dsGrid.Tables[0].Rows[0]["UserType_Code"].ToString();
                        lblreissue.Visible = true;
                        lblreissue.Text = dsGrid.Tables[0].Rows[0]["ReIssue_Request_Code"].ToString();
                        if (lblusertypeCode.Text.Trim() == "UT001")
                        {
                            lblUserType.Text = "Student";

                            ControlVisibility("Student");
                            FillGrid_Student(txtRequestCode.Text.Trim());
                        }
                        else if (lblusertypeCode.Text.Trim() == "UT003")
                        {
                            lblUserType.Text = "Teacher";
                            ControlVisibility("Teacher");
                            FillGrid_Teacher(txtRequestCode.Text.Trim());
                        }
                        else if (lblusertypeCode.Text.Trim() == "UT004")
                        {
                            lblUserType.Text = "Employee";
                            ControlVisibility("Employee");
                            FillGrid_Employee(txtRequestCode.Text.Trim());
                        }
                    }
                    else
                    {
                        datalist_Student.DataSource = null;
                        datalist_Student.DataBind();
                        datalist_Teacher.DataSource = null;
                        datalist_Teacher.DataBind();
                        Show_Error_Success_Box("E", "Records Not Found..");
                        return;
                    }

                }
                else
                {
                    datalist_Student.DataSource = null;
                    datalist_Student.DataBind();
                    datalist_Teacher.DataSource = null;
                    datalist_Teacher.DataBind();
                    Show_Error_Success_Box("E", "Records Not Found..");
                    return;
                }
            }


            if (opt == "3")
            {
                lblvoucher.Visible = true;
                if (ddlTransferFR_Add.SelectedValue == "Select Transfer From")
                {
                    Show_Error_Success_Box("E", "Select Transfer From");
                    ddlTransferFR_Add.Focus();
                    return;

                }


                else if (ddlTransferFR_Add.SelectedItem.Text == "Godown" && ddlGodownFR_Add.SelectedValue == "0")
                {
                    Show_Error_Success_Box("E", "Select Transfer From Godown");
                    ddlTransferFR_Add.Focus();
                    return;
                }

                else if (ddlTransferFR_Add.SelectedItem.Text == "Function" && ddlFunctionFR_Add.SelectedValue == "0")
                {
                    Show_Error_Success_Box("E", "Select Transfer From Function");
                    ddlTransferFR_Add.Focus();
                    return;

                }
                else if (ddlTransferFR_Add.SelectedItem.Text == "Center" && ddlDivisionFR_Add.SelectedValue == "0")
                {
                    Show_Error_Success_Box("E", "Select Transfer From Division");
                    ddlTransferFR_Add.Focus();
                    return;
                }
                else if (ddlTransferFR_Add.SelectedItem.Text == "Center" && ddlCenterFR_Add.SelectedValue == "0")
                {
                    Show_Error_Success_Box("E", "Select Transfer From Center");
                    ddlTransferFR_Add.Focus();
                    return;
                }
                else if (ddlDivisionFR_Add.SelectedValue != "0" && ddlCenterFR_Add.SelectedValue == "0")
                {
                    Show_Error_Success_Box("E", "Select Transfer From Center");
                    ddlTransferFR_Add.Focus();
                    return;
                }



                if (txtRequestCode.Text == "")
                {
                    Show_Error_Success_Box("E", "Enter Request Code");
                    txtRequestCode.Focus();
                    return;
                }

                string From_Location_Code = "";

                if (ddlTransferFR_Add.SelectedItem.Text == "Godown")
                {
                    From_Location_Code = ddlGodownFR_Add.SelectedValue;
                }
                else if (ddlTransferFR_Add.SelectedItem.Text == "Function")
                {
                    From_Location_Code = ddlFunctionFR_Add.SelectedValue;
                }
                else if (ddlTransferFR_Add.SelectedItem.Text == "Center")
                {
                    From_Location_Code = ddlCenterFR_Add.SelectedValue;
                }

                DataSet dsGrid = ProductController.Get_Data_ByRequNoforOptionCode3Dispatch(ddlTransferFR_Add.SelectedValue.ToString().Trim(), From_Location_Code, txtRequestCode.Text.Trim(), 6);
                if (dsGrid != null)
                {
                    if (dsGrid.Tables[0].Rows.Count > 0)
                    {
                        lblusertypeCode.Text = dsGrid.Tables[0].Rows[0]["UserTypeCode"].ToString();
                        lblUserType.Text = dsGrid.Tables[0].Rows[0]["type"].ToString();
                        lblvoucherno.Text = dsGrid.Tables[0].Rows[0]["Voucher_Code"].ToString();
                        lblvoucherno.Visible = true;

                        if (lblusertypeCode.Text.Trim() == "UT001")
                        {
                            ControlVisibility("Student");
                            lblHeadingOP3.Text = "Student Details";
                        }
                        else if (lblusertypeCode.Text.Trim() == "UT003")
                        {
                            ControlVisibility("Teacher");
                            lblHeadingOP3.Text = "Teacher Details";
                        }
                        else if (lblusertypeCode.Text.Trim() == "UT004")
                        {
                            ControlVisibility("Employee");
                            lblHeadingOP3.Text = "Employee Details";
                        }

                        if (dsGrid.Tables[1].Rows.Count != 0)
                        {
                            DTOP3.DataSource = dsGrid.Tables[2];
                            DTOP3.DataBind();

                        }
                        else
                        {
                            DTOP3.DataSource = null;
                            DTOP3.DataBind();
                        }


                    }
                    else
                    {
                        Show_Error_Success_Box("E", "Records Not Found..");
                        return;
                    }

                }
                else
                {
                    Show_Error_Success_Box("E", "Records Not Found..");
                    return;
                }
            }

            if (opt == "4")
            {
                lblvoucher.Visible = true;
                if (ddlTransferFR_Add.SelectedValue == "Select Transfer From")
                {
                    Show_Error_Success_Box("E", "Select Transfer From");
                    ddlTransferFR_Add.Focus();
                    return;

                }


                else if (ddlTransferFR_Add.SelectedItem.Text == "Godown" && ddlGodownFR_Add.SelectedValue == "0")
                {
                    Show_Error_Success_Box("E", "Select Transfer From Godown");
                    ddlTransferFR_Add.Focus();
                    return;
                }

                else if (ddlTransferFR_Add.SelectedItem.Text == "Function" && ddlFunctionFR_Add.SelectedValue == "0")
                {
                    Show_Error_Success_Box("E", "Select Transfer From Function");
                    ddlTransferFR_Add.Focus();
                    return;

                }
                else if (ddlTransferFR_Add.SelectedItem.Text == "Center" && ddlDivisionFR_Add.SelectedValue == "0")
                {
                    Show_Error_Success_Box("E", "Select Transfer From Division");
                    ddlTransferFR_Add.Focus();
                    return;
                }
                else if (ddlTransferFR_Add.SelectedItem.Text == "Center" && ddlCenterFR_Add.SelectedValue == "0")
                {
                    Show_Error_Success_Box("E", "Select Transfer From Center");
                    ddlTransferFR_Add.Focus();
                    return;
                }
                else if (ddlDivisionFR_Add.SelectedValue != "0" && ddlCenterFR_Add.SelectedValue == "0")
                {
                    Show_Error_Success_Box("E", "Select Transfer From Center");
                    ddlTransferFR_Add.Focus();
                    return;
                }



                if (txtRequestCode.Text == "")
                {
                    Show_Error_Success_Box("E", "Enter Request Code");
                    txtRequestCode.Focus();
                    return;
                }

                string From_Location_Code = "";

                if (ddlTransferFR_Add.SelectedItem.Text == "Godown")
                {
                    From_Location_Code = ddlGodownFR_Add.SelectedValue;
                }
                else if (ddlTransferFR_Add.SelectedItem.Text == "Function")
                {
                    From_Location_Code = ddlFunctionFR_Add.SelectedValue;
                }
                else if (ddlTransferFR_Add.SelectedItem.Text == "Center")
                {
                    From_Location_Code = ddlCenterFR_Add.SelectedValue;
                }

                DataSet dsGrid = ProductController.Get_Data_ByRequNoforOptionCode3Dispatch(ddlTransferFR_Add.SelectedValue.ToString().Trim(), From_Location_Code, txtRequestCode.Text.Trim(), 7);
                if (dsGrid != null)
                {
                    if (dsGrid.Tables[0].Rows.Count > 0)
                    {
                        lblusertypeCode.Text = dsGrid.Tables[0].Rows[0]["UserTypeCode"].ToString();
                        lblUserType.Text = dsGrid.Tables[0].Rows[0]["type"].ToString();
                        lblvoucherno.Text = dsGrid.Tables[0].Rows[0]["Voucher_Code"].ToString();
                        lblvoucherno.Visible = true;

                        if (lblusertypeCode.Text.Trim() == "UT001")
                        {
                            ControlVisibility("Student");
                            lblHeadingOP3.Text = "Student Details";
                        }
                        else if (lblusertypeCode.Text.Trim() == "UT003")
                        {
                            ControlVisibility("Teacher");
                            lblHeadingOP3.Text = "Teacher Details";
                        }
                        else if (lblusertypeCode.Text.Trim() == "UT004")
                        {
                            ControlVisibility("Employee");
                            lblHeadingOP3.Text = "Employee Details";
                        }

                        if (dsGrid.Tables[2] != null)
                        {
                            if (dsGrid.Tables[2].Rows.Count != 0)
                            {
                                DTOP3.DataSource = dsGrid.Tables[2];
                                DTOP3.DataBind();
                            }
                            else
                            {
                                DTOP3.DataSource = null;
                                DTOP3.DataBind();
                                Show_Error_Success_Box("E", "Records Not Found This Request has been Closed..");
                                return;
                            }

                        }
                        else
                        {
                            DTOP3.DataSource = null;
                            DTOP3.DataBind();
                            Show_Error_Success_Box("E", "Records Not Found This Request has been Closed..");
                            return;
                        }


                    }
                    else
                    {
                        Show_Error_Success_Box("E", "Records Not Found This Request has been Closed..");
                        return;
                    }

                }
                else
                {
                    Show_Error_Success_Box("E", "Records Not Found..");
                    return;
                }
            }
        }
        catch (Exception ex)
        {
            Msg_Error.Visible = true;
            Msg_Success.Visible = false;
            lblerror.Text = ex.ToString();
            UpdatePanelMsgBox.Update();
            return;
        }

    }

    private void FillGrid_Student(string Request_Code)
    {

        DataSet dsGrid = ProductController.Get_Data_ByRequNo(Request_Code, "1", "");


        if (dsGrid != null)
        {
            if (dsGrid.Tables.Count != 0)
            {
                if (dsGrid.Tables[0].Rows.Count != 0)
                {
                    datalist_Student.DataSource = dsGrid;
                    datalist_Student.DataBind();

                }
                else
                {
                    datalist_Student.DataSource = null;
                    datalist_Student.DataBind();
                    Show_Error_Success_Box("E", "Records Not Found..");
                    return;
                }
            }
            else
            {
                datalist_Student.DataSource = null;
                datalist_Student.DataBind();
                Show_Error_Success_Box("E", "Records Not Found..");
                return;
            }
        }
        else
        {
            datalist_Student.DataSource = null;
            datalist_Student.DataBind();
            Show_Error_Success_Box("E", "Records Not Found..");
            return;

        }

    }

    private void FillGrid_Student_Edit(string Request_Code, string Dispatch_code)
    {

        DataSet dsGrid = ProductController.Get_Data_ByRequNo(Request_Code, "5", Dispatch_code);


        if (dsGrid != null)
        {
            if (dsGrid.Tables.Count != 0)
            {
                if (dsGrid.Tables[0].Rows.Count != 0)
                {
                    datalist_Student.DataSource = dsGrid;
                    datalist_Student.DataBind();

                }
                else
                {
                    datalist_Student.DataSource = null;
                    datalist_Student.DataBind();
                    Show_Error_Success_Box("E", "Records Not Found..");
                    return;
                }
            }
            else
            {
                datalist_Student.DataSource = null;
                datalist_Student.DataBind();
                Show_Error_Success_Box("E", "Records Not Found..");
                return;
            }
        }
        else
        {
            datalist_Student.DataSource = null;
            datalist_Student.DataBind();
            Show_Error_Success_Box("E", "Records Not Found..");
            return;

        }

    }

    private void FillGrid_Teacher(string Request_Code)
    {

        DataSet dsGrid = ProductController.Get_Data_ByRequNo(Request_Code, "2", "");

        if (dsGrid != null)
        {
            if (dsGrid.Tables.Count != 0)
            {
                if (dsGrid.Tables[0].Rows.Count != 0)
                {
                    datalist_Teacher.DataSource = dsGrid;
                    datalist_Teacher.DataBind();
                }
                else
                {
                    datalist_Teacher.DataSource = null;
                    datalist_Teacher.DataBind();
                    Show_Error_Success_Box("E", "Records Not Found..");
                    return;
                }
            }
            else
            {
                datalist_Teacher.DataSource = null;
                datalist_Teacher.DataBind();
                Show_Error_Success_Box("E", "Records Not Found..");
                return;
            }
        }
        else
        {
            datalist_Teacher.DataSource = null;
            datalist_Teacher.DataBind();
            Show_Error_Success_Box("E", "Records Not Found..");
            return;

        }

    }

    private void FillGrid_Teacher_edit(string Request_Code, string Dispatch_code)
    {

        DataSet dsGrid = ProductController.Get_Data_ByRequNo(Request_Code, "6", Dispatch_code);

        if (dsGrid != null)
        {
            if (dsGrid.Tables.Count != 0)
            {
                if (dsGrid.Tables[0].Rows.Count != 0)
                {
                    datalist_Teacher.DataSource = dsGrid;
                    datalist_Teacher.DataBind();
                }
                else
                {
                    datalist_Teacher.DataSource = null;
                    datalist_Teacher.DataBind();
                    Show_Error_Success_Box("E", "Records Not Found..");
                    return;
                }
            }
            else
            {
                datalist_Teacher.DataSource = null;
                datalist_Teacher.DataBind();
                Show_Error_Success_Box("E", "Records Not Found..");
                return;
            }
        }
        else
        {
            datalist_Teacher.DataSource = null;
            datalist_Teacher.DataBind();
            Show_Error_Success_Box("E", "Records Not Found..");
            return;

        }

    }


    private void FillGrid_Employee(string Request_Code)
    {

        DataSet dsGrid = ProductController.Get_Data_ByRequNo(Request_Code, "3", "");
        if (dsGrid != null)
        {
            if (dsGrid.Tables.Count != 0)
            {
                if (dsGrid.Tables[0].Rows.Count != 0 || dsGrid.Tables[1].Rows.Count != 0)
                {

                    string User_Code = dsGrid.Tables[0].Rows[0]["UserCode"].ToString();

                    string User_Name = dsGrid.Tables[0].Rows[0]["UserName"].ToString();
                    string User_EmailId = dsGrid.Tables[0].Rows[0]["UserEmailId"].ToString();
                    string User_Status = dsGrid.Tables[0].Rows[0]["UserStatus"].ToString();
                    string Remarks = dsGrid.Tables[0].Rows[0]["Remark"].ToString();
                    lblRequ_CodeforEmp.Text = dsGrid.Tables[1].Rows[0]["Request_Code"].ToString();
                    lblRequ_EntryCodeforEMP.Text = dsGrid.Tables[1].Rows[0]["Request_EntryCode"].ToString();

                    lblEmployeenmforEMP.Text = User_Name;
                    lblemployeeCodeForEMP.Text = User_Code;
                    lblEmailidForEMP.Text = User_EmailId;
                    lblEmpstatusForEMP.Text = User_Status;
                    lbl_RemarksForEMP.Text = Remarks;
                }
                else
                {
                    Show_Error_Success_Box("E", "Record not found");
                }

            }
            else
            {
                Show_Error_Success_Box("E", "Record not found");
            }
        }
        if (dsGrid.Tables.Count == 0)
        {
            Show_Error_Success_Box("E", "Record not found");
        }
    }



    protected void btnClose_FotStudent_Click(object sender, EventArgs e)
    {
        //ddlrequi_No.SelectedIndex = 0;
        txtRequestCode.Text = "";
        div_student.Visible = false;
        lblUserType.Text = "";
    }
    protected void btncancel_forTeacher_Click(object sender, EventArgs e)
    {
        //ddlrequi_No.SelectedIndex = 0;
        txtRequestCode.Text = "";
        div_Teacher.Visible = false;
        lblUserType.Text = "";
    }
    protected void btnCancel_forEMP_Click(object sender, EventArgs e)
    {
        //ddlrequi_No.SelectedIndex = 0;
        txtRequestCode.Text = "";
        div_Employee.Visible = false;
        DivForOP3.Visible = false;
        lblUserType.Text = "";
    }


    protected void ddlFunctionFR_Add_SelectedIndexChanged(object sender, EventArgs e)
    {
        //string opt = null;
        //opt = Request.QueryString["OptionCode"];
        //if (opt == "3")
        //{
        //    FillDDL_Requisition_No(
        //}

        if (ddlFunctionFR_Add.SelectedIndex == 0 || ddlFunctionFR_Add.SelectedIndex == -1)
        {
            Show_Error_Success_Box("E", "Selec Function");
            ddlFunctionFR_Add.Focus();
            //ddlrequi_No.Items.Clear();
            return;

        }

        string opt = null;
        opt = Request.QueryString["OptionCode"];

        if (opt == "3")
        {
            //FillDDL_Requisition_No(ddlTransferFR_Add.SelectedValue.ToString().Trim(), ddlFunctionFR_Add.SelectedValue.ToString().Trim(), 5);
        }
    }
    protected void ddlCenterFR_Add_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlDivisionFR_Add.SelectedIndex == 0 || ddlDivisionFR_Add.SelectedIndex == -1)
        {
            Show_Error_Success_Box("E", "Select Division");
            ddlDivisionFR_Add.Focus();
            //ddlrequi_No.Items.Clear();
            return;
        }

        if (ddlCenterFR_Add.SelectedIndex == 0 || ddlCenterFR_Add.SelectedIndex == -1)
        {
            Show_Error_Success_Box("E", "Select Center");
            ddlCenterFR_Add.Focus();
            //ddlrequi_No.Items.Clear();
            return;
        }

        string opt = null;
        opt = Request.QueryString["OptionCode"];

        if (opt == "3")
        {
            //FillDDL_Requisition_No(ddlTransferFR_Add.SelectedValue.ToString().Trim(), ddlCenterFR_Add.SelectedValue.ToString().Trim(), 5);
        }
    }
    protected void ddlGodownFR_Add_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlGodownFR_Add.SelectedIndex == 0 || ddlGodownFR_Add.SelectedIndex == -1)
        {
            Show_Error_Success_Box("E", "Selec Godown");
            ddlGodownFR_Add.Focus();
            //ddlrequi_No.Items.Clear();
            return;

        }

        string opt = null;
        opt = Request.QueryString["OptionCode"];

        if (opt == "3")
        {
            //FillDDL_Requisition_No(ddlTransferFR_Add.SelectedValue.ToString().Trim(), ddlGodownFR_Add.SelectedValue.ToString().Trim(), 5);
        }
    }

    protected void btnprintopt2_Click(object sender, EventArgs e)
    {
        Clear_Error_Success_Box();

        if (ddlTransferFR_SR.SelectedValue == "Select Transfer From")
        {
            Show_Error_Success_Box("E", "Select Transfer From");
            ddlTransferFR_SR.Focus();
            return;

        }

        else if (ddlTransferTO_SR.SelectedValue == "Select Transfer To")
        {
            Show_Error_Success_Box("E", "Select Transfer To");
            ddlTransferTO_SR.Focus();
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


         //---------------
        else if (ddlTransferTO_SR.SelectedItem.Text == "Godown" && ddlgodownTO_SR.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "Select Transfer To Godown");
            ddlTransferTO_SR.Focus();
            return;
        }

        else if (ddlTransferTO_SR.SelectedItem.Text == "Function" && ddlFunctionTO_SR.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "Select Transfer To Function");
            ddlTransferTO_SR.Focus();
            return;
        }
        else if (ddlTransferTO_SR.SelectedItem.Text == "Center" && ddlDivisionTO_SR.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "Select Transfer To Division");
            ddlTransferTO_SR.Focus();
            return;
        }
        else if (ddlTransferTO_SR.SelectedItem.Text == "Center" && ddlCenterTO_SR.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "Select Transfer To Center");
            ddlTransferTO_SR.Focus();
            return;
        }
        else if (ddlDivisionFR_Add.SelectedIndex != 0 && ddlCenterTO_SR.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "Select Transfer To Center");
            ddlCenterTO_SR.Focus();
            return;
        }




         //----------------------------



        else if (ddlgodownFR_SR.SelectedIndex != 0 && ddlgodownTO_SR.SelectedIndex != 0 && ddlgodownFR_SR.SelectedValue == ddlgodownTO_SR.SelectedValue)
        {
            Show_Error_Success_Box("E", "Godown Transfer From and To can't be same. ");
            return;
        }

        else if (ddlFunctionFR_SR.SelectedIndex != 0 && ddlFunctionTO_SR.SelectedIndex != 0 && ddlFunctionTO_SR.SelectedValue == ddlFunctionFR_SR.SelectedValue)
        {
            Show_Error_Success_Box("E", "Function Transfer From and To can't be same. ");
            return;
        }

        else if (ddlCenterFR_SR.SelectedIndex != -1 && ddlCenterTO_SR.SelectedIndex != -1 && ddlCenterFR_SR.SelectedIndex != 0 && ddlCenterTO_SR.SelectedIndex != 0 && ddlCenterFR_SR.SelectedValue == ddlCenterTO_SR.SelectedValue)
        {
            Show_Error_Success_Box("E", "Center Transfer From and To can't be same. ");
            return;
        }

        else if (date_range_SR.Value == "")
        {
            Show_Error_Success_Box("E", "Select date range ");
            return;
        }



        string FromDate, ToDate;
        string From_Location_Type_Code = "";
        string From_Location_Code = "";
        string To_Location_Type_Code = "";
        string To_Location_Code = "";
        string Challan_No = "";
        if (date_range_SR.Value == "")
        {
            FromDate = "";
            ToDate = "";
        }
        else
        {
            string DateRange = "";
            DateRange = date_range_SR.Value;

            FromDate = DateRange.Substring(0, 10);
            ToDate = (DateRange.Length > 9) ? DateRange.Substring(DateRange.Length - 10, 10) : DateRange;
        }

        From_Location_Type_Code = ddlTransferFR_SR.SelectedValue;
        To_Location_Type_Code = ddlTransferTO_SR.SelectedValue;

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

        if (ddlTransferTO_SR.SelectedItem.Text == "Godown")
        {
            To_Location_Code = ddlgodownTO_SR.SelectedValue;
        }
        else if (ddlTransferTO_SR.SelectedItem.Text == "Function")
        {
            To_Location_Code = ddlFunctionTO_SR.SelectedValue;
        }
        else if (ddlTransferTO_SR.SelectedItem.Text == "Center")
        {
            To_Location_Code = ddlCenterTO_SR.SelectedValue;
        }

        Challan_No = txtChallan_SR.Text.Trim();

        DataSet ds = null;

        string opt = Request.QueryString["OptionCode"];
        if (opt == "2")
        {
            ds = ProductController.Get_Dispatch_Item(16, Challan_No, From_Location_Type_Code, From_Location_Code, To_Location_Code, To_Location_Type_Code, FromDate, ToDate);
        }




        if (ds.Tables[0].Rows.Count == 0)
        {
            Show_Error_Success_Box("E", "No Records Found");

        }
        else
        {
            ControlVisibility("Print Panel");
            datalistprintexcel.DataSource = ds;
            datalistprintexcel.DataBind();

            datalistprint.DataSource = ds;
            datalistprint.DataBind();
            lbltotalrecordsprint.Text = (ds.Tables[0].Rows.Count).ToString();
        }

    }

    public void AllChk_Selected(object sender, System.EventArgs e)
    {

        CheckBox s = sender as CheckBox;

        //Set checked status of hidden check box to items in grid
        foreach (DataListItem dtlItem in datalistprint.Items)
        {
            CheckBox chkitemck = (CheckBox)dtlItem.FindControl("chkItem");

            chkitemck.Checked = s.Checked;
        }



    }
    protected void Btprintgrid_Click(object sender, EventArgs e)
    {
        string Dispatch_Code = "";

        {

            foreach (DataListItem item in datalistprint.Items)
            {
                Label lbldispatchcode = (Label)item.FindControl("lbldispatchcode");
                CheckBox chkItem = (CheckBox)item.FindControl("chkItem");


                if (chkItem.Checked)
                {
                    if (lbldispatchcode.Text != "")
                    {
                        Dispatch_Code = Dispatch_Code + lbldispatchcode.Text + ",";
                    }

                }

            }

            if (Dispatch_Code.Length > 1)
            {
                Dispatch_Code = Dispatch_Code.Substring(0, Dispatch_Code.Length - 1);
            }
            //if (Dispatch_Code == "")
            //{
            //    Show_Error_Success_Box("E", "Asset No Blank");
            //    return;
            //}

            if (Dispatch_Code != "")
            {
                Label lblHeader_User_Code = default(Label);
                lblHeader_User_Code = (Label)Master.FindControl("lblHeader_User_Code");
                string CreatedBy = null;
                CreatedBy = lblHeader_User_Code.Text;
                DataSet ds = ProductController.Get_Print_Dispatch_Details(1, CreatedBy, Dispatch_Code);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        Response.Redirect("Print_Dispatch_Hidden.aspx?Job_Id=" + ds.Tables[0].Rows[0]["Job_Id"].ToString());
                    }
                }
            }
            else
            {

                lblerror.Visible = true;
                Show_Error_Success_Box("E", "Select Atleast One Record");
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        DivSearchPanel.Visible = false;
        DivAddPanel.Visible = false;
        BtnAdd.Visible = false;
        DivPrintPanel.Visible = false;
    }
    protected void btnadditem_Click(object sender, EventArgs e)
    {

        ClearItemAdd();
        Clear_Error_Success_Box();



        string From_Location_Type_Code = "";
        string From_Location_Code = "";

        From_Location_Type_Code = ddlTransferFR_Add.SelectedValue;


        if (ddlTransferFR_Add.SelectedItem.Text == "Godown")
        {
            From_Location_Code = ddlGodownFR_Add.SelectedValue;
        }
        else if (ddlTransferFR_Add.SelectedItem.Text == "Function")
        {
            From_Location_Code = ddlFunctionFR_Add.SelectedValue;
        }
        else if (ddlTransferFR_Add.SelectedItem.Text == "Center")
        {
            From_Location_Code = ddlCenterFR_Add.SelectedValue;
        }


        int TotalRecord1 = 0;
        string MaterialCode = "";
        foreach (DataListItem dtlItem in dladditem.Items)
        {
            CheckBox chkCheck = (CheckBox)dtlItem.FindControl("chkCheck");

            if (chkCheck.Checked == true)
            {
                TotalRecord1 = TotalRecord1 + 1;
            }
        }
        if (TotalRecord1 == 0)
        {
            Show_Error_Success_Box("E", "You have not Selected any Item");
            return;
        }
        else
        {
            foreach (DataListItem item in dladditem.Items)
            {
                if (item.ItemType == ListItemType.Item | item.ItemType == ListItemType.AlternatingItem)
                {
                    CheckBox chkCheck = (CheckBox)item.FindControl("chkCheck");

                    if (chkCheck.Checked == true)
                    {
                        //Label Request_Code = (Label)item.FindControl("lblrequCode");
                        Label lblitemcode = (Label)item.FindControl("lblitemcode");

                        string REBind = lblitemcode.Text.Trim();
                        MaterialCode = MaterialCode + REBind + ",";
                    }

                }

            }

            MaterialCode = Common.RemoveComma(MaterialCode);

        }



        //


        DataTable dtCorrectEntry = new DataTable();
        DataRow NewRow = null;


        var _with1 = dtCorrectEntry;
        _with1.Columns.Add("Dispatch_Code");
        _with1.Columns.Add("DispatchEntry_Code");
        _with1.Columns.Add("Item_Code");
        _with1.Columns.Add("Item_Name");
        _with1.Columns.Add("Purchase_Amount");
        _with1.Columns.Add("Purchase_Rate");
        _with1.Columns.Add("Barcode");
        _with1.Columns.Add("Dispatch_Qty");
        _with1.Columns.Add("Asset_No");
        _with1.Columns.Add("Pkey");
        _with1.Columns.Add("InwardEntry_Code");
        _with1.Columns.Add("Inward_Code");
        _with1.Columns.Add("Inward_Qty");
        _with1.Columns.Add("is_Acknowledged");
        _with1.Columns.Add("Request_EntryCode");




        int itemcount = 0;
        int Total_Item_Count = 0;
        int Total_Quantity = 0;
        decimal Total_Amount = 0;

        foreach (DataListItem item in dlQuestion.Items)
        {
            if (item.ItemType == ListItemType.Item | item.ItemType == ListItemType.AlternatingItem)
            {
                Label lblDispatch_Code = (Label)item.FindControl("lblDispatch_Code");
                Label lblDispatchEntry_Code = (Label)item.FindControl("lblDispatchEntry_Code");
                Label lblItem_Code_DT = (Label)item.FindControl("lblItem_Code_DT");
                Label lblItemName_DT = (Label)item.FindControl("lblItemName_DT");
                Label lblBarcode_DT = (Label)item.FindControl("lblBarcode_DT");
                Label lblAssetNo_DT = (Label)item.FindControl("lblAssetNo_DT");
                Label lblQty_DT = (Label)item.FindControl("lblQty_DT");
                Label lblUnitPrice_DT = (Label)item.FindControl("lblUnitPrice_DT");
                Label lblAmount_DT = (Label)item.FindControl("lblAmount_DT");
                Label lblPkey_Code = (Label)item.FindControl("lblPkey_Code");

                Label lblInward_Code = (Label)item.FindControl("lblInward_Code");
                Label lblInwardEntry_Code_DL = (Label)item.FindControl("lblInwardEntry_Code_DL");
                Label Inward_Qty = (Label)item.FindControl("Inward_Qty");
                Label lblis_Acknowledged = (Label)item.FindControl("lblis_Acknowledged");
                Label lblRequestEntry_Code_Grid = (Label)item.FindControl("lblRequestEntry_Code_Grid");

                NewRow = dtCorrectEntry.NewRow();
                NewRow["Dispatch_Code"] = lblDispatch_Code.Text.Trim();
                NewRow["DispatchEntry_Code"] = lblDispatchEntry_Code.Text.Trim();
                NewRow["Item_Code"] = lblItem_Code_DT.Text.Trim();
                NewRow["Item_Name"] = lblItemName_DT.Text.Trim();
                NewRow["Barcode"] = lblBarcode_DT.Text.Trim();
                NewRow["Asset_No"] = lblAssetNo_DT.Text.Trim();
                NewRow["Dispatch_Qty"] = lblQty_DT.Text.Trim();
                NewRow["Purchase_Rate"] = lblUnitPrice_DT.Text.Trim();
                NewRow["Purchase_Amount"] = lblAmount_DT.Text.Trim();

                NewRow["InwardEntry_Code"] = lblInwardEntry_Code_DL.Text.Trim();
                NewRow["Inward_Code"] = lblInward_Code.Text.Trim();
                NewRow["Inward_Qty"] = Inward_Qty.Text.Trim();
                NewRow["is_Acknowledged"] = lblis_Acknowledged.Text.Trim();
                NewRow["Request_EntryCode"] = lblRequestEntry_Code_Grid.Text.Trim();
                NewRow["Pkey"] = lblPkey_Code.Text.Trim();


                itemcount++;


                Total_Quantity = Total_Quantity + Convert.ToInt32(lblQty_DT.Text.Trim());
                Total_Amount = Total_Amount + Convert.ToDecimal(lblAmount_DT.Text.Trim());
                Total_Item_Count = Convert.ToInt32(lblTotalItem.Text);



                dtCorrectEntry.Rows.Add(NewRow);


            }
        }

        ////
        //temp data

        DataTable dtTempEntry = new DataTable();
        DataRow NewRow1 = null;


        var _with2 = dtTempEntry;
        _with2.Columns.Add("Dispatch_Code");
        _with2.Columns.Add("DispatchEntry_Code");
        _with2.Columns.Add("Item_Code");
        _with2.Columns.Add("Item_Name");
        _with2.Columns.Add("Purchase_Amount");
        _with2.Columns.Add("Purchase_Rate");
        _with2.Columns.Add("Barcode");
        _with2.Columns.Add("Dispatch_Qty");
        _with2.Columns.Add("Asset_No");
        _with2.Columns.Add("Pkey");
        _with2.Columns.Add("InwardEntry_Code");
        _with2.Columns.Add("Inward_Code");
        _with2.Columns.Add("Inward_Qty");
        _with2.Columns.Add("is_Acknowledged");
        _with2.Columns.Add("Request_EntryCode");


        int itemcount1 = 0;
        int Total_Item_Count1 = 0;
        int Total_Quantity1 = 0;
        decimal Total_Amount1 = 0;

        foreach (DataListItem item in DataList2.Items)
        {
            if (item.ItemType == ListItemType.Item | item.ItemType == ListItemType.AlternatingItem)
            {
                Label lblDispatch_Code = (Label)item.FindControl("lblDispatch_Code");
                Label lblDispatchEntry_Code = (Label)item.FindControl("lblDispatchEntry_Code");
                Label lblItem_Code_DT = (Label)item.FindControl("lblItem_Code_DT");
                Label lblItemName_DT = (Label)item.FindControl("lblItemName_DT");
                Label lblBarcode_DT = (Label)item.FindControl("lblBarcode_DT");
                Label lblAssetNo_DT = (Label)item.FindControl("lblAssetNo_DT");
                Label lblQty_DT = (Label)item.FindControl("lblQty_DT");
                Label lblUnitPrice_DT = (Label)item.FindControl("lblUnitPrice_DT");
                Label lblAmount_DT = (Label)item.FindControl("lblAmount_DT");
                Label lblPkey_Code = (Label)item.FindControl("lblPkey_Code");

                Label lblInward_Code = (Label)item.FindControl("lblInward_Code");
                Label lblInwardEntry_Code_DL = (Label)item.FindControl("lblInwardEntry_Code_DL");
                Label Inward_Qty = (Label)item.FindControl("Inward_Qty");
                Label lblis_Acknowledged = (Label)item.FindControl("lblis_Acknowledged");
                Label lblRequestEntry_Code_Grid = (Label)item.FindControl("lblRequestEntry_Code_Grid");

                NewRow1 = dtTempEntry.NewRow();
                NewRow1["Dispatch_Code"] = lblDispatch_Code.Text.Trim();
                NewRow1["DispatchEntry_Code"] = lblDispatchEntry_Code.Text.Trim();
                NewRow1["Item_Code"] = lblItem_Code_DT.Text.Trim();
                NewRow1["Item_Name"] = lblItemName_DT.Text.Trim();
                NewRow1["Barcode"] = lblBarcode_DT.Text.Trim();
                NewRow1["Asset_No"] = lblAssetNo_DT.Text.Trim();
                NewRow1["Dispatch_Qty"] = lblQty_DT.Text.Trim();
                NewRow1["Purchase_Rate"] = lblUnitPrice_DT.Text.Trim();
                NewRow1["Purchase_Amount"] = lblAmount_DT.Text.Trim();

                NewRow1["InwardEntry_Code"] = lblInwardEntry_Code_DL.Text.Trim();
                NewRow1["Inward_Code"] = lblInward_Code.Text.Trim();
                NewRow1["Inward_Qty"] = Inward_Qty.Text.Trim();
                NewRow1["is_Acknowledged"] = lblis_Acknowledged.Text.Trim();
                NewRow1["Request_EntryCode"] = lblRequestEntry_Code_Grid.Text.Trim();
                NewRow1["Pkey"] = lblPkey_Code.Text.Trim();

                itemcount1++;



                //Inward_Qty + Convert.ToInt32(lblQty_DT.Text.Trim());
                Total_Amount1 = Total_Amount1 + Convert.ToDecimal(lblAmount_DT.Text.Trim());
                Total_Item_Count = Convert.ToInt32(lblTotalItem.Text);
                lblTotal_Quantity.Text = Total_Quantity.ToString();
                lblTotal_Amount.Text = Total_Amount.ToString();


                // NewRow1["Pkey"] = itemcount1.ToString();

                dtTempEntry.Rows.Add(NewRow1);


            }
        }
        DataSet dsSupplier = null;


        dsSupplier = ProductController.GetItemForDispatch(MaterialCode, 10, From_Location_Type_Code, From_Location_Code, "", "", "");
        int itemcnt = 1;
        if (dsSupplier.Tables[0].Rows.Count > 0)
        {


            for (int cnt = 0; cnt < dsSupplier.Tables[0].Rows.Count; cnt++)
            {



                NewRow = dtCorrectEntry.NewRow();
                NewRow["Dispatch_Code"] = "";
                NewRow["DispatchEntry_Code"] = "";
                NewRow["Item_Code"] = dsSupplier.Tables[0].Rows[cnt]["Item_Code"].ToString();
                NewRow["Item_Name"] = dsSupplier.Tables[0].Rows[cnt]["Item_Name"].ToString();
                NewRow["Barcode"] = dsSupplier.Tables[0].Rows[cnt]["Item_EAN_No"].ToString();
                NewRow["Asset_No"] = dsSupplier.Tables[0].Rows[cnt]["Asset_No"].ToString();
                //NewRow["Dispatch_Qty"] = dsSupplier.Tables[0].Rows[cnt]["Dispatch_Qty"].ToString();
                NewRow["Dispatch_Qty"] = "1";
                NewRow["Purchase_Rate"] = dsSupplier.Tables[0].Rows[cnt]["Purchase_Rate"].ToString();
                NewRow["Purchase_Amount"] = dsSupplier.Tables[0].Rows[cnt]["Purchase_Rate"].ToString();
                // NewRow["Purchase_Amount"] = dsSupplier.Tables[0].Rows[cnt]["Purchase_Rate"].ToString();
                NewRow["Pkey"] = itemcount + itemcnt;


                NewRow["InwardEntry_Code"] = dsSupplier.Tables[0].Rows[cnt]["InwardEntry_Code"].ToString();
                NewRow["Inward_Code"] = dsSupplier.Tables[0].Rows[cnt]["Inward_Code"].ToString();
                NewRow["Inward_Qty"] = dsSupplier.Tables[0].Rows[cnt]["Inward_Qty"].ToString();
                NewRow["is_Acknowledged"] = "0";
                NewRow["Request_EntryCode"] = lblRequestEntry_Code_Item.Text.Trim();
                dtCorrectEntry.Rows.Add(NewRow);



                //
                string text = "";
                NewRow1 = dtTempEntry.NewRow();
                NewRow1["Dispatch_Code"] = "";
                NewRow1["DispatchEntry_Code"] = "";
                NewRow1["Item_Code"] = dsSupplier.Tables[0].Rows[cnt]["Item_Code"].ToString();
                NewRow1["Item_Name"] = dsSupplier.Tables[0].Rows[cnt]["Item_Name"].ToString();
                NewRow1["Barcode"] = dsSupplier.Tables[0].Rows[cnt]["Item_EAN_No"].ToString();
                NewRow1["Asset_No"] = dsSupplier.Tables[0].Rows[cnt]["Asset_No"].ToString();
                //NewRow1["Dispatch_Qty"] = dsSupplier.Tables[0].Rows[cnt]["Dispatch_Qty"].ToString();
                NewRow1["Dispatch_Qty"] = "1";
                NewRow1["Purchase_Rate"] = dsSupplier.Tables[0].Rows[cnt]["Purchase_Rate"].ToString();
                NewRow1["Purchase_Amount"] = dsSupplier.Tables[0].Rows[cnt]["Purchase_Rate"].ToString();
                //  NewRow1["Purchase_Amount"] = (dsSupplier.Tables[0].Rows[cnt]["Purchase_Rate"].ToString());
                //lblCalValue.Text;

                // NewRow1["Pkey"] = (itemcount + 1).ToString();


                NewRow1["InwardEntry_Code"] = dsSupplier.Tables[0].Rows[cnt]["InwardEntry_Code"].ToString();
                NewRow1["Inward_Code"] = dsSupplier.Tables[0].Rows[cnt]["Inward_Code"].ToString();
                NewRow1["Inward_Qty"] = dsSupplier.Tables[0].Rows[cnt]["Inward_Qty"].ToString();
                NewRow1["is_Acknowledged"] = "0";
                NewRow1["Request_EntryCode"] = lblRequestEntry_Code_Item.Text.Trim();
                NewRow1["Pkey"] = itemcount + itemcnt + 1;
                dtTempEntry.Rows.Add(NewRow1);
                itemcnt++;
                string QTY = lblqty.Text.Trim();
                Total_Item_Count = Total_Item_Count + Convert.ToInt32(lblqty.Text);
                string amount = dsSupplier.Tables[0].Rows[cnt]["Purchase_Rate"].ToString();
                Total_Quantity = Total_Quantity + Convert.ToInt32(QTY);

                Total_Amount = Total_Amount + Convert.ToDecimal(amount);
                lblTotalItem.Text = Total_Item_Count.ToString();

                lblTotal_Quantity.Text = Total_Quantity.ToString();
                //lblPkey.Text = Total_Quantity.ToString();
                lblTotal_Amount.Text = Total_Amount.ToString();
                //lblMateCode




                dlQuestion.DataSource = dtCorrectEntry;
                dlQuestion.DataBind();
                DataList2.DataSource = dtTempEntry;
                DataList2.DataBind();

                dlQuestion.Visible = true;




                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "openModalDivOverride2", "openModalDivOverride2();");



                UpdatePanel3.Update();









            }









        }
    }

    protected void dladditem_ItemCommand(object source, DataListCommandEventArgs e)
    {

        if (e.CommandName == "comSetItem")
        {
            ClearItemAdd();
            Clear_Error_Success_Box();

            string MaterialCode = e.CommandArgument.ToString();
            lblSearchAddItem.Text = MaterialCode;

            string From_Location_Type_Code = "";
            string From_Location_Code = "";

            From_Location_Type_Code = ddlTransferFR_Add.SelectedValue;


            if (ddlTransferFR_Add.SelectedItem.Text == "Godown")
            {
                From_Location_Code = ddlGodownFR_Add.SelectedValue;
            }
            else if (ddlTransferFR_Add.SelectedItem.Text == "Function")
            {
                From_Location_Code = ddlFunctionFR_Add.SelectedValue;
            }
            else if (ddlTransferFR_Add.SelectedItem.Text == "Center")
            {
                From_Location_Code = ddlCenterFR_Add.SelectedValue;
            }

            //
            DataSet dsSupplier = null;

            string opt = null;
            opt = Request.QueryString["OptionCode"];

            if (opt == "3")
            {

                string RequestEntry_Code = "";

                //For Student                
                if (lblusertypeCode.Text.Trim() == "UT001")
                {
                    int TotalRecord = 0;
                    foreach (DataListItem dtlItem in datalist_Student.Items)
                    {
                        CheckBox chkCheck = (CheckBox)dtlItem.FindControl("chkCheck");

                        if (chkCheck.Checked == true)
                        {
                            TotalRecord = TotalRecord + 1;
                        }
                    }
                    if (TotalRecord == 0)
                    {
                        Show_Error_Success_Box("E", "You have not Selected any Student");
                        return;
                    }
                    else
                    {
                        foreach (DataListItem item in datalist_Student.Items)
                        {
                            if (item.ItemType == ListItemType.Item | item.ItemType == ListItemType.AlternatingItem)
                            {
                                CheckBox chkCheck = (CheckBox)item.FindControl("chkCheck");

                                if (chkCheck.Checked == true)
                                {
                                    //Label Request_Code = (Label)item.FindControl("lblrequCode");
                                    Label Request_EntryCode = (Label)item.FindControl("Request_EntryCode");

                                    string REBind = Request_EntryCode.Text.Trim();
                                    RequestEntry_Code = RequestEntry_Code + REBind + ",";
                                }

                            }

                        }

                        RequestEntry_Code = Common.RemoveComma(RequestEntry_Code);

                    }
                }

                //For Teachers
                if (lblusertypeCode.Text.Trim() == "UT003")
                {
                    int TotalRecord = 0;
                    foreach (DataListItem dtlItem in datalist_Teacher.Items)
                    {
                        CheckBox chkCheck = (CheckBox)dtlItem.FindControl("chkCheck");

                        if (chkCheck.Checked == true)
                        {
                            TotalRecord = TotalRecord + 1;
                        }
                    }
                    if (TotalRecord == 0)
                    {
                        Show_Error_Success_Box("E", "You have not Selected any Teacher");
                        return;
                    }
                    else
                    {
                        foreach (DataListItem item in datalist_Teacher.Items)
                        {
                            if (item.ItemType == ListItemType.Item | item.ItemType == ListItemType.AlternatingItem)
                            {
                                CheckBox chkCheck = (CheckBox)item.FindControl("chkCheck");

                                if (chkCheck.Checked == true)
                                {
                                    //Label Request_Code = (Label)item.FindControl("lblrequCode_TH");
                                    Label Request_EntryCode = (Label)item.FindControl("Request_EntryCode_TH");

                                    string REBind = Request_EntryCode.Text.Trim();
                                    RequestEntry_Code = RequestEntry_Code + REBind + ",";
                                }

                            }

                        }

                        RequestEntry_Code = Common.RemoveComma(RequestEntry_Code);

                    }
                }

                else if (lblusertypeCode.Text.Trim() == "UT004")
                {
                    string REBind = lblRequ_EntryCodeforEMP.Text.Trim();

                    RequestEntry_Code = Common.RemoveComma(REBind);

                }

                dsSupplier = ProductController.GetItemForDispatch(MaterialCode, 5, From_Location_Type_Code, From_Location_Code, txtRequestCode.Text.Trim(), RequestEntry_Code, "");
            }
            else
            {
                dsSupplier = ProductController.GetItemForDispatch(MaterialCode, 2, From_Location_Type_Code, From_Location_Code, "", "", "");
            }

            //

            if (dsSupplier.Tables[0].Rows.Count > 0)
            {
                lblMateCode.Text = dsSupplier.Tables[0].Rows[0]["Item_Code"].ToString();
                lblItemName.Text = dsSupplier.Tables[0].Rows[0]["Item_Name"].ToString();
                lblUnit.Text = dsSupplier.Tables[0].Rows[0]["UOM_Name"].ToString();
                txtItemRate.Text = dsSupplier.Tables[0].Rows[0]["Purchase_Rate"].ToString();
                string itemtype = dsSupplier.Tables[0].Rows[0]["AssetsNo_Type_Id"].ToString();
                int Current_Qty = Convert.ToInt32(dsSupplier.Tables[0].Rows[0]["Current_Qty"].ToString());

                lblCurrentQty.Text = Current_Qty.ToString();
                txtItemQty.Text = "1";
                lblInwardEntry_Code.Text = dsSupplier.Tables[0].Rows[0]["InwardEntry_Code"].ToString();
                lblInward_Code.Text = dsSupplier.Tables[0].Rows[0]["Inward_Code"].ToString();
                lblInward_Qty.Text = dsSupplier.Tables[0].Rows[0]["Inward_Qty"].ToString();
                lblRequestEntry_Code_Item.Text = dsSupplier.Tables[0].Rows[0]["Request_EntryCode"].ToString();

                if (itemtype == "ATN00000001")
                {
                    if (opt == "2")
                    {
                        txtItemQty.Enabled = false;
                    }
                    else
                    {
                        txtItemQty.Enabled = true;
                    }
                }
                else if (itemtype == "ATN00000002")
                {
                    txtItemQty.Enabled = false;
                }
                else if (itemtype == "ATN00000003")
                {
                    txtItemQty.Enabled = false;
                }


                lblCalValue.Text = "";
                int itemQty = 0;
                decimal Rate1 = 0;
                if (txtItemQty.Text == "")
                {
                    itemQty = 1;
                }
                else
                {
                    itemQty = Convert.ToInt32(txtItemQty.Text);
                }
                if (txtItemRate.Text == "")
                {
                    Rate1 = 0;
                }
                else
                {

                    Rate1 = Convert.ToDecimal(string.Format("{0:F2}", txtItemRate.Text));

                }

                decimal CalAns = itemQty * Rate1;

                lblCalValue.Text = CalAns.ToString();


            }
        }

    }


}
