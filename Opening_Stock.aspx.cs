using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ShoppingCart.BL;
using System.IO;
using System.Web.UI.HtmlControls;



public partial class Opening_Stock : System.Web.UI.Page
{

    #region PageLoad
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                ControlVisibility("Search");
                
                FillDDL_Supplier();
                //Clear_TempChallan();
                FillDDL_Division();
                FillDDL_TransferType();
                //FillDDL_Logistic();
                FillDDL_Godown();
                FillDDL_Function();
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
    }
    #endregion

    #region Methods
    private void TempSaveData()
    {
        try
        {
            Clear_Error_Success_Box();
            //if (ddlTransferFR_SR.SelectedIndex == 0)
            //{
            //    Show_Error_Success_Box("E", "Select Location Type");
            //    ddlTransferFR_SR.Focus();
            //    return;
            //}
            //if (ddlTransferFR_SR.SelectedItem.ToString() == "Godown")
            //{
            //   // Transfer_LocationCode = ddlgodownFR_SR.SelectedValue.ToString().Trim();
            //    if (ddlgodownFR_SR.SelectedIndex == 0)
            //    {
            //        Show_Error_Success_Box("E", "Select Godown");
            //        ddlgodownFR_SR.Focus();
            //        return;
            //    }
            //}
            //else if (ddlTransferFR_SR.SelectedItem.ToString() == "Function")
            //{
            //   // Transfer_LocationCode = ddlFunctionFR_SR.SelectedValue.ToString().Trim();
            //    if (ddlFunctionFR_SR.SelectedIndex == 0)
            //    {
            //        Show_Error_Success_Box("E", "Select Function");
            //        ddlFunctionFR_SR.Focus();
            //        return;
            //    }
            //}
            //else if (ddlTransferFR_SR.SelectedItem.ToString() == "Center")
            //{
            //    //Transfer_LocationCode = ddlCenterFR_SR.SelectedValue.ToString().Trim();
            //    if (ddlCenterFR_SR.SelectedIndex == 0)
            //    {
            //        Show_Error_Success_Box("E", "Select Center");
            //        ddlCenterFR_SR.Focus();
            //        return;
            //    }

            //}

            //if (ddlPOStatus_Add.SelectedIndex == 0)
            //{
            //    Show_Error_Success_Box("E", "Select Po Status");
            //    ddlPOStatus_Add.Focus();

            //    dlQuestion.DataSource = null;
            //    dlQuestion.DataBind();

            //    return;
            //}

            //if (ddlPOStatus_Add.SelectedValue == "Yes")
            //{
            //    if (ddlPONo_Add.SelectedIndex == 0)
            //    {
            //        Show_Error_Success_Box("E", "Select PO Number");
            //        ddlPONo_Add.Focus();
            //        dlQuestion.DataSource = null;
            //        dlQuestion.DataBind();
            //        return;
            //    }
            //    else if (ddlPONo_Add.SelectedIndex == -1)
            //    {
            //        Show_Error_Success_Box("E", "Select PO Number");
            //        ddlPONo_Add.Focus();
            //        dlQuestion.DataSource = null;
            //        dlQuestion.DataBind();
            //        return;
            //    }
            //}
            //else if (ddlPOStatus_Add.SelectedValue == "No")
            //{
            //    if (ddlSupplier_Add.SelectedIndex == 0)
            //    {
            //        Show_Error_Success_Box("E", "Select Supplier");
            //        ddlSupplier_Add.Focus();
            //        dlQuestion.DataSource = null;
            //        dlQuestion.DataBind();
            //        return;
            //    }
            //}


            //if (txtDCNO.Text.Trim() == "")
            //{
            //    Show_Error_Success_Box("E", "Enter DC Number");
            //    txtDCNO.Focus();
            //    dlQuestion.DataSource = null;
            //    dlQuestion.DataBind();
            //    return;
            //}

            //if (txtDCDate.Value.Trim() == "")
            //{
            //    Show_Error_Success_Box("E", "Enter DC Date");
            //    txtDCDate.Focus();
            //    dlQuestion.DataSource = null;
            //    dlQuestion.DataBind();
            //    return;
            //}


            Label lblHeader_User_Code = default(Label);
            lblHeader_User_Code = (Label)Master.FindControl("lblHeader_User_Code");

            string CreatedBy = null;
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            CreatedBy = cookie.Values["UserID"];

            //int ActiveFlag = 0;
            //if (chkActiveFlag.Checked == true)
            //    ActiveFlag = 1;
            //else
            //    ActiveFlag = 0;

            string ResultId = "", ResultId1 = "", ResultID2 = "";
            //string Supplier_Code = "", PONo = "";
            //int PoFlag = 0;

            //if (ddlPOStatus_Add.SelectedValue == "Yes")
            //{
            //    Supplier_Code = lblsuppliercode.Text.Trim();
            //    PONo = ddlPONo_Add.SelectedValue.ToString();
            //    PoFlag = 1;
            //}
            //else if (ddlPOStatus_Add.SelectedValue == "No")
            //{
            //    Supplier_Code = ddlSupplier_Add.SelectedValue.ToString().Trim();
            //    PONo = "";
            //    PoFlag = 0;
            //}

            //int Total_Item_Count = 0;
            //double Total_Purchase_Amount = 0;

            //double invoiceval = 0;
            //if (txtInvoiceValue_Add.Text == "")
            //{
            //    invoiceval = 0;
            //}
            //else
            //{
            //    invoiceval = Convert.ToDouble(txtInvoiceValue_Add.Text.Trim());
            //}
            string Transfer_LocationCode = "";
            if (ddlTransferFR_SR.SelectedItem.ToString() == "Godown")
            {
                Transfer_LocationCode = ddlgodownFR_SR.SelectedValue.ToString().Trim();
            }
            else if (ddlTransferFR_SR.SelectedItem.ToString() == "Function")
            {
                Transfer_LocationCode = ddlFunctionFR_SR.SelectedValue.ToString().Trim();
            }
            else if (ddlTransferFR_SR.SelectedItem.ToString() == "Center")
            {
                Transfer_LocationCode = ddlCenterFR_SR.SelectedValue.ToString().Trim();
            }

            
            if (lblPkey.Text == "")
            {
                if (ddlTransferFR_SR.SelectedItem.ToString() == "Godown")
                {
                    Transfer_LocationCode=ddlgodownFR_SR.SelectedValue .ToString ().Trim ();
                }
                else if (ddlTransferFR_SR.SelectedItem.ToString() == "Function")
                {
                    Transfer_LocationCode=ddlFunctionFR_SR.SelectedValue .ToString ().Trim ();
                }
                else if (ddlTransferFR_SR.SelectedItem.ToString() == "Center")
                {
                    Transfer_LocationCode=ddlCenterFR_SR.SelectedValue .ToString ().Trim ();
                }

                ResultId = ProductController.Insert_OpeningStockDetail(21, ddlTransferFR_SR.SelectedValue, Transfer_LocationCode, "1", CreatedBy, "1", "0");
                lblPkey.Text = ResultId;
            }
            ResultId = lblPkey.Text;
            

           // ResultID2 = ProductController.delete_InwardItems(8, lblPkey.Text.Trim());

            //int icoun = 0;
            //foreach (DataListItem item in dlQuestion.Items)
            //{
            //    if (item.ItemType == ListItemType.Item | item.ItemType == ListItemType.AlternatingItem)
            //    {
            //        Label lblMaterialCode_DT = (Label)item.FindControl("lblMaterialCode_DT");
            //        Label lblMaterialName_DT = (Label)item.FindControl("lblMaterialName_DT");
            //        //Label lblPoQty_DT = (Label)item.FindControl("lblPoQty_DT");
            //        Label lblChallanQty_DT = (Label)item.FindControl("lblChallanQty_DT");
            //        //Label lblRatePO_DT = (Label)item.FindControl("lblRatePO_DT");
            //        //Label lblValue_DT = (Label)item.FindControl("lblValue_DT");
            //        Label lblBarcode_DT = (Label)item.FindControl("lblBarcode_DT");
            //        Label lblSuppSerial = (Label)item.FindControl("lblSuppSerial");
            //        Label lblAuthoriseFlag = (Label)item.FindControl("lblAuthoriseFlag");

            //        if (lblAuthoriseFlag.Text == "")
            //        {
            //            lblAuthoriseFlag.Text = "0";
            //        }

            //        icoun = icoun + 1;
            //        string InwardEntry_Code = ResultId + icoun.ToString();

            //        ResultId1 = ProductController.Insert_OpeningStockInward_ItemsDetail(2, ResultId, InwardEntry_Code, lblMaterialCode_DT.Text.Trim(), Convert.ToDouble(lblChallanQty_DT.Text.Trim()), 0, 0, 1, lblAuthoriseFlag.Text);

            //    }
            //}





            DataSet dsItems = ProductController.Get_Edit_GRNDetails(5, lblPkey.Text.Trim());
            if (dsItems.Tables[0].Rows.Count > 0)
            {
                dlQuestion.DataSource = dsItems;
                dlQuestion.DataBind();
            }

            ddlTransferFR_SR.Enabled = false;
            ddlgodownFR_SR.Enabled = false;
            ddlDivisionFR_SR.Enabled = false;
            ddlFunctionFR_SR.Enabled = false;
            ddlCenterFR_SR.Enabled = false;
            //BtnSaveAdd.Visible = true;
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

    private void FillDDL_FRSearch_Centre_Search()
    {
        string Company_Code = "MT";
        string DBname = "CDB";

        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];

        string Div_Code = null;
        Div_Code = ddlDivisionFR_SRSearch.SelectedValue;

        DataSet dsCentre = ProductController.GetAllActiveUser_Company_Division_Zone_Center(UserID, Company_Code, Div_Code, "", "5", DBname);

        BindDDL(ddlCenterFR_SRSearch, dsCentre, "Center_Name", "Center_Code");
        ddlCenterFR_SRSearch.Items.Insert(0, "Select");
        ddlCenterFR_SRSearch.Items.Insert(1, "All");
        //ddlCenterFR_SRSearch.SelectedIndex = 0;

    }

    private void FillDDL_FRSearch_CentreAuthorise()
    {
        string Company_Code = "MT";
        string DBname = "CDB";

        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];

        string Div_Code = null;
        Div_Code = ddlDivisionFR_SRAuthorise.SelectedValue;

        DataSet dsCentre = ProductController.GetAllActiveUser_Company_Division_Zone_Center(UserID, Company_Code, Div_Code, "", "5", DBname);

        BindDDL(ddlCenterFR_SRAuthorise, dsCentre, "Center_Name", "Center_Code");
        ddlCenterFR_SRAuthorise.Items.Insert(0, "Select");
        ddlCenterFR_SRAuthorise.SelectedIndex = 0;
    }

    private void FillDDL_TransferType()
    {
        //Search DDL
        DataSet dsTransfer_Tp = ProductController.GetAllTransferType(1);
        BindDDL(ddlLocationType, dsTransfer_Tp, "Transfer_Location_Type_Name", "Transfer_Location_Type_ID");
        ddlLocationType.Items.Insert(0, "Select Location");
        ddlLocationType.SelectedIndex = 0;

        BindDDL(ddlTransferFR_SR, dsTransfer_Tp, "Transfer_Location_Type_Name", "Transfer_Location_Type_ID");
        ddlTransferFR_SR.Items.Insert(0, "Select Location");
        ddlTransferFR_SR.SelectedIndex = 0;

        BindDDL(ddlTransferFR_SRAuthorise, dsTransfer_Tp, "Transfer_Location_Type_Name", "Transfer_Location_Type_ID");
        ddlTransferFR_SRAuthorise.Items.Insert(0, "Select Location");
        ddlTransferFR_SRAuthorise.SelectedIndex = 0;
        
    }


    private void FillDDL_Godown()
    {
        ddlgodownFR_SR.Items.Clear();
        ddlgodownFR_SRSearch.Items.Clear();
        DataSet dsTransfer_Tp = ProductController.GetGodown_Function_Logistic_Assests(1, ddlgodownFR_SRSearch.Text);
        BindDDL(ddlgodownFR_SRSearch, dsTransfer_Tp, "Godown_Name", "Godown_Id");
        ddlgodownFR_SRSearch.Items.Insert(0, "Select Godown");
       // ddlgodownFR_SRSearch.SelectedIndex = 0;
        ddlgodownFR_SRSearch.Items.Insert(1, "All");
        

        BindDDL(ddlgodownFR_SR, dsTransfer_Tp, "Godown_Name", "Godown_Id");
        ddlgodownFR_SR.Items.Insert(0, "Select Godown");
        ddlgodownFR_SR.SelectedIndex = 0;

        BindDDL(ddlgodownFR_SRAuthorise, dsTransfer_Tp, "Godown_Name", "Godown_Id");
        ddlgodownFR_SRAuthorise.Items.Insert(0, "Select Godown");
        ddlgodownFR_SRAuthorise.SelectedIndex = 0;
        
    }

    private void FillDDL_Function()
    {
        ddlFunctionFR_SR.Items.Clear();
        ddlFunctionFR_SRSearch.Items.Clear();
        DataSet dsTransfer_Tp = ProductController.GetGodown_Function_Logistic_Assests_Type(2);
        BindDDL(ddlFunctionFR_SRSearch, dsTransfer_Tp, "Function_Name", "Function_Id");
        ddlFunctionFR_SRSearch.Items.Insert(0, "Select Function");
        ddlFunctionFR_SRSearch.SelectedIndex = 0;

        BindDDL(ddlFunctionFR_SR, dsTransfer_Tp, "Function_Name", "Function_Id");
        ddlFunctionFR_SR.Items.Insert(0, "Select Function");
        ddlFunctionFR_SR.SelectedIndex = 0;

        BindDDL(ddlFunctionFR_SRAuthorise, dsTransfer_Tp, "Function_Name", "Function_Id");
        ddlFunctionFR_SRAuthorise.Items.Insert(0, "Select Function");
        ddlFunctionFR_SRAuthorise.SelectedIndex = 0;
    }

    //private void FillDDL_Logistic()
    //{
    //    ddlLogisticType_Add.Items.Clear();
    //    DataSet dsTransfer_Tp = ProductController.GetGodown_Function_Logistic_Assests_Type(5);
    //    BindDDL(ddlLogisticType_Add, dsTransfer_Tp, "Logistic_Type_Name", "Logistic_Type_Id");
    //    ddlLogisticType_Add.Items.Insert(0, "Select Logistic");
    //    ddlLogisticType_Add.SelectedIndex = 0;
    //}

    private void FillDDL_Division()
    {
        string Company_Code = "MT";
        string DBname = "CDB";

        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];

        //Search DDL
        DataSet dsDivision = ProductController.GetAllActiveUser_Company_Division_Zone_Center(UserID, Company_Code, "", "", "2", DBname);
        BindDDL(ddlDivisionFR_SRSearch, dsDivision, "Division_Name", "Division_Code");
        ddlDivisionFR_SRSearch.Items.Insert(0, "Select");
        ddlDivisionFR_SRSearch.SelectedIndex = 0;

        BindDDL(ddlDivisionFR_SR, dsDivision, "Division_Name", "Division_Code");
        ddlDivisionFR_SR.Items.Insert(0, "Select");
        ddlDivisionFR_SR.SelectedIndex = 0;

        BindDDL(ddlDivisionFR_SRAuthorise, dsDivision, "Division_Name", "Division_Code");
        ddlDivisionFR_SRAuthorise.Items.Insert(0, "Select");
        ddlDivisionFR_SRAuthorise.SelectedIndex = 0;

        BindDDL(ddlDivision, dsDivision, "Division_Name", "Division_Code");
        ddlDivision.Items.Insert(0, "Select");
        ddlDivision.SelectedIndex = 0;
        

    }


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

    private void BindDDL(DropDownList ddl, DataSet ds, string txtField, string valField)
    {
        ddl.DataSource = ds;
        ddl.DataTextField = txtField;
        ddl.DataValueField = valField;
        ddl.DataBind();
    }

    

    private void FillDDL_Supplier()
    {
        //DataSet dsSupplier = ProductController.GetAllSupplier();
        //BindDDL(ddlSupplier_Add, dsSupplier, "Vendor_Name", "Vendor_Id");
        //ddlSupplier_Add.Items.Insert(0, "Select");
        //ddlSupplier_Add.SelectedIndex = 0;

        //BindDDL(ddlSupplier_SR, dsSupplier, "Vendor_Name", "Vendor_Id");
        //ddlSupplier_SR.Items.Insert(0, "Select");
        //ddlSupplier_SR.SelectedIndex = 0;

    }
    private void FillDDL_PONumber()
    {
        //ddlPONo_Add.Items.Clear();
        //DataSet dsPONumber = ProductController.GetAllPONumber(14);
        //BindDDL(ddlPONo_Add, dsPONumber, "PurchaseOrder_Code", "PurchaseOrder_Code");
        //ddlPONo_Add.Items.Insert(0, "Select");
        //ddlPONo_Add.SelectedIndex = 0;

    }

    private void FillDDL_POItems()
    {
       // ddlPOItems_Add.Items.Clear();
        //DataSet dsPONumberItems = ProductController.GetItemsPONumber(16,ddlPONo_Add .SelectedValue .ToString ().Trim ());
        //BindDDL(ddlPOItems_Add, dsPONumberItems, "Item_Name", "PurchaseOrderEntry_Code");
        //ddlPOItems_Add.Items.Insert(0, "Select");
        //ddlPOItems_Add.SelectedIndex = 0;

    }

    

    private void Clear_TempChallan()
    {
        string ResultId;
        ResultId = ProductController.usp_ClearIncInward(13);
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
            DivAddPanel.Visible = false;
            DivSearchPanel.Visible = true;
            BtnAdd.Visible = true;
            //BtnSaveAdd.Visible = true;
           // BtnSaveEdit.Visible = false;
            DivResultPanel.Visible = false;
            DivAddBarcode.Visible = false;
            DivAuthorise.Visible = false;
            //RadioButton1.Checked = false;
            //RadioButton2.Checked = false;

        }
        else if (Mode == "Result")
        {
            DivAddBarcode.Visible = false;
            DivAddPanel.Visible = false;
            DivSearchPanel.Visible = false;
            BtnAdd.Visible = false;
            DivResultPanel.Visible = true;
            DivAuthorise.Visible = false;
            //lblPkey.Text = "";

        }
        else if (Mode == "Add")
        {
            DivAddPanel.Visible = true;
            DivSearchPanel.Visible = false;
            BtnAdd.Visible = false;
            DivResultPanel.Visible = false;
            DivAddBarcode.Visible = false;
            //lblPkey.Text = "";
            //BtnSaveEdit.Visible = false;
            //BtnSaveAdd.Visible = true;
            DivAuthorise.Visible = false;
        }
        else if (Mode == "Edit")
        {
            DivAddPanel.Visible = false;
            DivSearchPanel.Visible = false;
            BtnAdd.Visible = false;
            DivResultPanel.Visible = false;
            DivAddBarcode.Visible = false;
            DivAuthorise.Visible = false;
        }
        else if (Mode == "Details")
        {
            DivAddPanel.Visible = false;
            DivSearchPanel.Visible = false;
            BtnAdd.Visible = false;
            DivResultPanel.Visible = false;
            DivAddBarcode.Visible = true;
            lblInwardCode_BR.Text = "";
            lblInwardEbtryCode_BR.Text = "";
            DivAuthorise.Visible = false;
        }
        else if (Mode == "Authorise")
        {
            DivAddPanel.Visible = false;
            DivSearchPanel.Visible = false;
            BtnAdd.Visible = false;
            DivResultPanel.Visible = false;
            DivAddBarcode.Visible = false;           
            DivAuthorise.Visible = true;
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
    //private void ClearAddPanel()
    //{
        //txtEntryDate_Add.Text = "";
        //ddlPOStatus_Add.SelectedIndex = 0;
        //ddlPONo_Add.Items.Clear();
        //ddlSupplier_Add.Items.Clear();
        //txtDCNO.Text = "";
        //lblSuppName.Text = "";
        //lblsuppliercode.Text = "";
        //txtDCDate.Value = "";
        //txtInvoiceNo_Add.Text = "";
        //txtInvoiceDT.Value = "";
        //txtInvoiceValue_Add.Text = "";

        ////

        //txtEntryDate_Add.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
        
    //}

    public void ClearItemAdd()
    {
        txtItemMatCode.Text = "";
        txtItemQty.Text = "";
        //txtItemRate.Text = "";
        //lblCalValue.Text = "0";
        lblMateCode.Text = "";
        lblUnit.Text = "";
        lblItemName.Text = "";
        ddlDivision.SelectedIndex = 0;
    }


    private void ClearSearchPanel()
    {
        //From Content
        ddlLocationType.SelectedIndex = 0;
        ddlgodownFR_SRSearch.SelectedIndex = 0;
        ddlDivisionFR_SRSearch.SelectedIndex = 0;
        ddlFunctionFR_SRSearch.SelectedIndex = 0;
        ddlCenterFR_SRSearch.Items.Clear();

        //To Content

        //date_range_SR.Value = "";
        //txtChallan_SR.Text = "";

        //Visible False from Table
        tblFr_GodownSearch.Visible = false;
        tblFr_FunctionSearch.Visible = false;
        tblFr_DivisionSearch.Visible = false;
        tblFr_CenterSearch.Visible = false;
    }


    private void FillGrid()
    {
        try
        {
            Clear_Error_Success_Box();

            ControlVisibility("Result");

             string Transfer_LocationCode = "";
            if (ddlLocationType.SelectedItem.ToString() == "Godown")
            {
                if (ddlgodownFR_SRSearch.SelectedIndex == 0)
                {
                    Transfer_LocationCode = "%%";
                }
                else
                {
                    Transfer_LocationCode = ddlgodownFR_SRSearch.SelectedValue.ToString().Trim();
                    lblLocationResult.Text = ddlgodownFR_SRSearch.SelectedItem.ToString();
                }

                lblLocationType_Result.Text = "Godown";
            }
            else if (ddlLocationType.SelectedItem.ToString() == "Function")
            {
                if (ddlFunctionFR_SRSearch.SelectedIndex == 0)
                {
                    Transfer_LocationCode = "%%";
                }
                else
                {
                    Transfer_LocationCode = ddlFunctionFR_SRSearch.SelectedValue.ToString().Trim();
                    lblLocationResult.Text = ddlFunctionFR_SRSearch.SelectedItem.ToString();
                }

                lblLocationType_Result.Text = "Function";
            }
            else if (ddlLocationType.SelectedItem.ToString() == "Center")
            {
                if (ddlDivisionFR_SRSearch.SelectedIndex == 0)
                {
                    Transfer_LocationCode = "%%";
                }
                else if (ddlCenterFR_SRSearch.SelectedIndex == 0)
                {
                    Transfer_LocationCode = "%%";
                }
                else
                {
                    Transfer_LocationCode = ddlCenterFR_SRSearch.SelectedValue.ToString().Trim();
                    lblLocationResult.Text = ddlCenterFR_SRSearch.SelectedItem.ToString();
                }

                lblLocationType_Result.Text = ddlDivisionFR_SRSearch.SelectedItem.ToString().Trim();
            }


            Label lblHeader_User_Code = default(Label);
            lblHeader_User_Code = (Label)Master.FindControl("lblHeader_User_Code");

            string CreatedBy = null;
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            CreatedBy = cookie.Values["UserID"];

            string ResultId = ProductController.Insert_OpeningStock_Inward(1, ddlLocationType.SelectedValue, Transfer_LocationCode, CreatedBy);
            lblPkey.Text = ResultId;

            //DataSet dsGrid = ProductController.Get_Fill_OpeninfStockDetails(1, ddlLocationType.SelectedValue.ToString(), Transfer_LocationCode,"");
            //dlGridDisplay.DataSource = dsGrid;
            //dlGridDisplay.DataBind();

            //DataList1.DataSource = dsGrid;
            //DataList1.DataBind();

            DataSet dsItems = ProductController.Get_Edit_GRNDetails(5, lblPkey.Text.Trim());
            if (dsItems.Tables[0].Rows.Count > 0)
            {
                dlGridDisplay.DataSource = dsItems;
                dlGridDisplay.DataBind();

                DataList1.DataSource = dsItems;
                DataList1.DataBind();
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
                        dlGridDisplay.DataSource = null;
                        dlGridDisplay.DataBind();

                        DataList1.DataSource = null;
                        DataList1.DataBind();
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
        catch (Exception ex)
        {

            Msg_Error.Visible = true;
            Msg_Success.Visible = false;
            lblerror.Text = ex.ToString();
            UpdatePanelMsgBox.Update();
            return;
        }
    }



    private void SaveData()
    {
        try
        {
            Clear_Error_Success_Box();

            if (ddlTransferFR_SR.SelectedIndex == 0)
            {
                Show_Error_Success_Box("E", "Select Location Type");
                ddlTransferFR_SR.Focus();
                return;
            }
            if (ddlTransferFR_SR.SelectedItem.ToString() == "Godown")
            {
                // Transfer_LocationCode = ddlgodownFR_SR.SelectedValue.ToString().Trim();
                if (ddlgodownFR_SR.SelectedIndex == 0)
                {
                    Show_Error_Success_Box("E", "Select Godown");
                    ddlgodownFR_SR.Focus();
                    return;
                }
            }
            else if (ddlTransferFR_SR.SelectedItem.ToString() == "Function")
            {
                // Transfer_LocationCode = ddlFunctionFR_SR.SelectedValue.ToString().Trim();
                if (ddlFunctionFR_SR.SelectedIndex == 0)
                {
                    Show_Error_Success_Box("E", "Select Function");
                    ddlFunctionFR_SR.Focus();
                    return;
                }
            }
            else if (ddlTransferFR_SR.SelectedItem.ToString() == "Center")
            {
                //Transfer_LocationCode = ddlCenterFR_SR.SelectedValue.ToString().Trim();
                if (ddlDivisionFR_SR.SelectedIndex == 0)
                {
                    Show_Error_Success_Box("E", "Select Division");
                    ddlCenterFR_SR.Focus();
                    return;
                }
                if (ddlCenterFR_SR.SelectedIndex == 0)
                {
                    Show_Error_Success_Box("E", "Select Center");
                    ddlCenterFR_SR.Focus();
                    return;
                }

            }
            Label lblHeader_User_Code = default(Label);
            lblHeader_User_Code = (Label)Master.FindControl("lblHeader_User_Code");

            string CreatedBy = null;
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            CreatedBy = cookie.Values["UserID"];


            string ResultId = "";
            string Transfer_LocationCode="";
            if (ddlTransferFR_SR.SelectedItem.ToString() == "Godown")
            {
                Transfer_LocationCode = ddlgodownFR_SR.SelectedValue.ToString().Trim();
            }
            else if (ddlTransferFR_SR.SelectedItem.ToString() == "Function")
            {
                Transfer_LocationCode = ddlFunctionFR_SR.SelectedValue.ToString().Trim();
            }
            else if (ddlTransferFR_SR.SelectedItem.ToString() == "Center")
            {
                Transfer_LocationCode = ddlCenterFR_SR.SelectedValue.ToString().Trim();
            }


            ResultId = ProductController.Update_OpeningStockDetail(23, ddlTransferFR_SR.SelectedValue, Transfer_LocationCode, "1", CreatedBy, "1", "0",lblPkey.Text);

            if (ResultId == "1")
            {                
                ControlVisibility("Search");
                Show_Error_Success_Box("S", "Record saved Successfully.");


                //

              //  string FromDate, ToDate, Supplier;
              //  //if (id_date_range_picker_2.Value == "")
              //  //{
              //  //    FromDate = "";
              //  //    ToDate = "";
              //  //}
              //  //else
              //  //{
              //      string DateRange = "";
              //     // DateRange = id_date_range_picker_2.Value;

              //      FromDate = DateRange.Substring(0, 10);
              //      ToDate = (DateRange.Length > 9) ? DateRange.Substring(DateRange.Length - 10, 10) : DateRange;
              //  //}

              //  //if (ddlSupplier_SR.SelectedIndex == 0 || ddlSupplier_SR.SelectedIndex == -1)
              //  //{
              //  //    Supplier = "";
              //  //}
              //  //else
              //  //{
              //  //    Supplier = ddlSupplier_SR.SelectedValue.ToString().Trim();
              //  //}


              ////  FillGrid(FromDate, ToDate, Supplier, txtChallan_SR.Text.Trim());
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


    
    #endregion

    #region Event's
    protected void BtnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            Clear_Error_Success_Box();
            string Location = "";
            if (ddlLocationType.SelectedIndex == 0)
            {
                Show_Error_Success_Box("E", "Select Location Type");
                ddlLocationType.Focus();
                return;
            }

            ddlTransferFR_SR.SelectedValue = ddlLocationType.SelectedValue;
            ddlTransferFR_SR_SelectedIndexChanged(sender, e);
            if (ddlLocationType.SelectedItem.ToString() == "Godown")
            {
                if (ddlgodownFR_SRSearch.SelectedIndex == 0)
                {
                    //Transfer_LocationCode = "%%";
                    Show_Error_Success_Box("E", "Select Godown");
                    ddlgodownFR_SRSearch.Focus();
                    return;
                }
                else
                {
                    ddlgodownFR_SR.SelectedValue = ddlgodownFR_SRSearch.SelectedValue;
                    Location = ddlgodownFR_SRSearch.SelectedValue;
                }
            }
            else if (ddlLocationType.SelectedItem.ToString() == "Function")
            {
                if (ddlFunctionFR_SRSearch.SelectedIndex == 0)
                {
                    //Transfer_LocationCode = "%%";
                    Show_Error_Success_Box("E", "Select Function");
                    ddlFunctionFR_SRSearch.Focus();
                    return;
                }
                else
                {
                    ddlFunctionFR_SR.SelectedValue = ddlFunctionFR_SRSearch.SelectedValue;
                    Location = ddlFunctionFR_SRSearch.SelectedValue;
                }
            }
            else if (ddlLocationType.SelectedItem.ToString() == "Center")
            {
                if (ddlDivisionFR_SRSearch.SelectedIndex == 0)
                {
                    Show_Error_Success_Box("E", "Select Division");
                    ddlDivisionFR_SRSearch.Focus();
                    return;
                }
                else if (ddlCenterFR_SRSearch.SelectedIndex == 0)
                {
                    Show_Error_Success_Box("E", "Select Center");
                    ddlCenterFR_SRSearch.Focus();
                    return;
                }
                else
                {
                    ddlDivisionFR_SR.SelectedValue = ddlDivisionFR_SRSearch.SelectedValue.ToString();
                    ddlDivisionFR_SR_SelectedIndexChanged(sender, e);
                    ddlCenterFR_SR.SelectedValue = ddlCenterFR_SRSearch.SelectedValue;
                    Location = ddlCenterFR_SRSearch.SelectedValue;
                }
            }

            
            ControlVisibility("Add");
            ClearItemAdd();
            //ClearAddPanel();
            
            dlQuestion.DataSource = null;
            dlQuestion.DataBind();          
            
            
            lblPkey.Text = "";
            ddlTransferFR_SR.Enabled = false;
            ddlgodownFR_SR.Enabled = false;
            ddlDivisionFR_SR.Enabled = false;
            ddlFunctionFR_SR.Enabled = false;
            ddlCenterFR_SR.Enabled = false;
            //BtnSaveAdd.Visible = false;

            //ddlTransferFR_SR.SelectedIndex = 0;
            //ddlTransferFR_SR_SelectedIndexChanged(sender, e);

            Label lblHeader_User_Code = default(Label);
            lblHeader_User_Code = (Label)Master.FindControl("lblHeader_User_Code");

            string CreatedBy = null;
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            CreatedBy = cookie.Values["UserID"];

            string ResultId = ProductController.Insert_OpeningStock_Inward(1, ddlTransferFR_SR.SelectedValue, Location, CreatedBy);
            lblPkey.Text = ResultId;

            DataSet dsItems = ProductController.Get_Edit_GRNDetails(5, lblPkey.Text.Trim());
            if (dsItems.Tables[0].Rows.Count > 0)
            {
                dlQuestion.DataSource = dsItems;
                dlQuestion.DataBind();
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

    protected void BtnShowSearchPanel_Click(object sender, EventArgs e)
    {
        ControlVisibility("Search");
        Clear_Error_Success_Box();
    }

    protected void BtnCloseAdd_Click(object sender, EventArgs e)
    {
        ControlVisibility("Search");
        Clear_Error_Success_Box();
    }


    protected void BtnSaveAdd_Click(object sender, EventArgs e)
    {
        SaveData();
    }

    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            Clear_Error_Success_Box();

            string FromDate, ToDate, Supplier, Location;
  

            if (ddlLocationType.SelectedIndex == 0)
            {
                Show_Error_Success_Box("E", "Select Location Type");
                ddlLocationType.Focus();
                return;
            }

            if (ddlLocationType.SelectedItem.ToString() == "Godown")
            {
                if (ddlgodownFR_SRSearch.SelectedIndex == 0)
                {
                    //ddlgodownFR_SRSearch = "%%";
                    Show_Error_Success_Box("E", "Select Godown");
                    ddlgodownFR_SRSearch.Focus();
                    return;
                }
                else
                    Location = ddlgodownFR_SRSearch.SelectedItem.ToString();

            }
            else if (ddlLocationType.SelectedItem.ToString() == "Function")
            {
                if (ddlFunctionFR_SRSearch.SelectedIndex == 0)
                {
                    //Transfer_LocationCode = "%%";
                    Show_Error_Success_Box("E", "Select Function");
                    ddlFunctionFR_SRSearch.Focus();
                    return;
                }
                else
                    Location = ddlFunctionFR_SRSearch.SelectedItem.ToString();
            }
            else if (ddlLocationType.SelectedItem.ToString() == "Center")
            {
                if (ddlDivisionFR_SRSearch.SelectedIndex == 0)
                {
                    Show_Error_Success_Box("E", "Select Division");
                    ddlDivisionFR_SRSearch.Focus();
                    return;
                }
                else if (ddlCenterFR_SRSearch.SelectedIndex == 0)
                {
                    Show_Error_Success_Box("E", "Select Center");
                    ddlCenterFR_SRSearch.Focus();
                    return;
                }
                else
                    Location = ddlCenterFR_SRSearch.SelectedItem.ToString();
            }
            FillGrid();
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

    protected void BtnClearSearch_Click(object sender, EventArgs e)
    {
        ClearSearchPanel();
    }





    protected void BtnSaveEdit_Click(object sender, EventArgs e)
    {
        try
        {
            Clear_Error_Success_Box();

            //if (ddlPOStatus_Add.SelectedIndex == 0)
            //{
            //    Show_Error_Success_Box("E", "Select Po Status");
            //    ddlPOStatus_Add.Focus();
            //    return;
            //}

            //if (ddlPOStatus_Add.SelectedValue == "Yes")
            //{
            //    if (ddlPONo_Add.SelectedIndex == 0)
            //    {
            //        Show_Error_Success_Box("E", "Select PO Number");
            //        ddlPONo_Add.Focus();
            //        return;
            //    }
            //    else if (ddlPONo_Add.SelectedIndex == -1)
            //    {
            //        Show_Error_Success_Box("E", "Select PO Number");
            //        ddlPONo_Add.Focus();
            //        return;
            //    }
            //}
            //else if (ddlPOStatus_Add.SelectedValue == "No")
            //{
            //    if (ddlSupplier_Add.SelectedIndex == 0)
            //    {
            //        Show_Error_Success_Box("E", "Select Supplier");
            //        ddlSupplier_Add.Focus();
            //        return;
            //    }
            //}



            //if (txtDCNO.Text.Trim() == "")
            //{
            //    Show_Error_Success_Box("E", "Enter DC Number");
            //    txtDCNO.Focus();
            //    return;
            //}

            //if (txtDCDate.Value.Trim() == "")
            //{
            //    Show_Error_Success_Box("E", "Enter DC Date");
            //    txtDCDate.Focus();
            //    return;
            //}

            //if (Convert.ToDateTime(ClsCommon.FormatDate(txtDCDate.Value)) > DateTime.Today)
            //{
            //    Show_Error_Success_Box("E", "Challan date cannot be a future date");
            //    txtDCDate.Focus();
            //    return;
            //}


            Label lblHeader_User_Code = default(Label);
            lblHeader_User_Code = (Label)Master.FindControl("lblHeader_User_Code");

            string CreatedBy = null;
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            CreatedBy = cookie.Values["UserID"];

            //int ActiveFlag = 0;
            //if (chkActiveFlag.Checked == true)
            //    ActiveFlag = 1;
            //else
            //    ActiveFlag = 0;

            string ResultId = "", ResultId1 = "";
            string Supplier_Code = "", PONo = "";
            int PoFlag = 0;

            //if (ddlPOStatus_Add.SelectedValue == "Yes")
            //{
            //    Supplier_Code = lblsuppliercode.Text.Trim();
            //    PONo = ddlPONo_Add.SelectedValue.ToString();
            //    PoFlag = 1;
            //}
            //else if (ddlPOStatus_Add.SelectedValue == "No")
            //{
            //    Supplier_Code = ddlSupplier_Add.SelectedValue.ToString().Trim();
            //    PONo = "";
            //    PoFlag = 0;
            //}

            int Total_Item_Count = 0;
            double Total_Purchase_Amount = 0;

            foreach (DataListItem item in dlQuestion.Items)
            {
                if (item.ItemType == ListItemType.Item | item.ItemType == ListItemType.AlternatingItem)
                {
                    Label lblValue_DT = (Label)item.FindControl("lblValue_DT");

                    Total_Item_Count = Total_Item_Count + 1;

                    Total_Purchase_Amount = Total_Purchase_Amount + Convert.ToDouble(lblValue_DT.Text.Trim());

                }
            }

            double invoiceval = 0;
            //if (txtInvoiceValue_Add.Text == "")
            //{
            //    invoiceval = 0;
            //}
            //else
            //{
            //    invoiceval = Convert.ToDouble(txtInvoiceValue_Add.Text.Trim());
            //}

            //ResultId = ProductController.Update_GRNInward(6, Supplier_Code, txtDCNO.Text.Trim(), txtDCDate.Value.ToString().Trim(), txtInvoiceNo_Add.Text.Trim(), Total_Item_Count, Total_Purchase_Amount, 1, PONo, PoFlag, CreatedBy, lblPkey.Text.Trim(), txtDCDate.Value.ToString().Trim(), 1, txtInvoiceDT.Value.ToString().Trim(), invoiceval);

            if (ResultId == "-1")
            {
                Clear_Error_Success_Box();
                Msg_Error.Visible = true;
                Msg_Success.Visible = false;
                Show_Error_Success_Box("E", "Duplicate Challan Number");
                return;
            }
            else
            {
                int icoun = 0;
                foreach (DataListItem item in dlQuestion.Items)
                {
                    if (item.ItemType == ListItemType.Item | item.ItemType == ListItemType.AlternatingItem)
                    {
                        Label lblMaterialCode_DT = (Label)item.FindControl("lblMaterialCode_DT");
                        Label lblMaterialName_DT = (Label)item.FindControl("lblMaterialName_DT");
                        Label lblPoQty_DT = (Label)item.FindControl("lblPoQty_DT");
                        Label lblChallanQty_DT = (Label)item.FindControl("lblChallanQty_DT");
                        Label lblRatePO_DT = (Label)item.FindControl("lblRatePO_DT");
                        Label lblValue_DT = (Label)item.FindControl("lblValue_DT");
                        Label lblBarcode_DT = (Label)item.FindControl("lblBarcode_DT");
                        Label lblSuppSerial = (Label)item.FindControl("lblSuppSerial");
                        Label lblAuthoriseFlag = (Label)item.FindControl("lblAuthoriseFlag");

                        if (lblAuthoriseFlag.Text == "")
                        {
                            lblAuthoriseFlag.Text = "0";
                        }

                        icoun = icoun + 1;
                        string InwardEntry_Code = lblPkey.Text.Trim() + icoun.ToString();

                        ResultId1 = ProductController.Insert_OpeningStockInward_ItemsDetail(2, lblPkey.Text.Trim(), InwardEntry_Code, lblMaterialCode_DT.Text.Trim(), Convert.ToDouble(lblChallanQty_DT.Text.Trim()), Convert.ToDouble(lblRatePO_DT.Text.Trim()), Convert.ToDouble(lblValue_DT.Text.Trim()), 1, lblAuthoriseFlag.Text);

                    }
                }

            }

            if (ResultId1 == "1")
            {
                Show_Error_Success_Box("S", "Record Updated Successfully.");
                BtnSearch_Click(this, e);
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
    protected void btnUserMenuSave_Click(object sender, EventArgs e)
    {
        try
        {
            Clear_Error_Success_Box();
            int cnttrue = 0;
            string Result = "", ResultId = "";

            if (txtItemName_BR.Text.Trim() == "")
            {
                Show_Error_Success_Box("E", "Select Item");
                txtItemName_BR.Focus();
                return;
            }
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
          string   CreatedBy = cookie.Values["UserID"];

            Result = ProductController.Usp_Delete_InwardItemDetails(11, lblInwardCode_BR.Text.Trim(), lblInwardEbtryCode_BR.Text.Trim());

            foreach (DataListItem item in DataList2.Items)
            {
                if (item.ItemType == ListItemType.Item | item.ItemType == ListItemType.AlternatingItem)
                {
                    Label lblSRNo = (Label)item.FindControl("lblSRNo");
                    TextBox txtItemSerialNo = (TextBox)item.FindControl("txtItemSerialNo");
                    TextBox txtItemBarcodeNo = (TextBox)item.FindControl("txtItemBarcodeNo");
                    TextBox txtAssetNo = (TextBox)item.FindControl("txtAssetNo");
                    TextBox txtPurchaseRate = (TextBox)item.FindControl("txtPurchaseRate");  
                    System.Web.UI.HtmlControls.HtmlInputText txtPurchaseDate = (System.Web.UI.HtmlControls.HtmlInputText)item.FindControl("txtPurchaseDate");
                    TextBox txtPONumber = (TextBox)item.FindControl("txtPONumber");
                    TextBox txtCurrentValue = (TextBox)item.FindControl("txtCurrentValue");
                    DropDownList ddlStatus = (DropDownList)item.FindControl("ddlStatus");
                    DropDownList ddlCondition = (DropDownList)item.FindControl("ddlCondition");
                    
                    

                    Label lblResult = (Label)item.FindControl("lblResult");

                    //Check if Serial No, Barcode No is Blank

                    if (!string.IsNullOrEmpty(txtItemSerialNo.Text) & !string.IsNullOrEmpty(txtItemBarcodeNo.Text))
                    {
                        if (txtCurrentValue.Text.Trim() == "")
                        {
                            lblResult.ForeColor = System.Drawing.Color.Red;
                            lblResult.Text = "Error : Enter Current Value";
                            cnttrue = cnttrue + 1;                           
                        }
                        else if (ddlStatus.SelectedIndex == 0)
                        {
                            lblResult.ForeColor = System.Drawing.Color.Red;
                            lblResult.Text = "Error : Select Status";
                            cnttrue = cnttrue + 1;
                        }
                        else if (ddlCondition.SelectedIndex == 0)
                        {
                            lblResult.ForeColor = System.Drawing.Color.Red;
                            lblResult.Text = "Error : Select Condition";
                            cnttrue = cnttrue + 1;
                        }
                        else
                        {
                            string OpeningStock_Purchase_Amount="0";
                            if(txtPurchaseRate.Text.Trim()!="")
                            {
                               if (lblItemType.Text == "ATN00000001")
                               {
                                    OpeningStock_Purchase_Amount=(Convert.ToInt32(txtPurchaseRate.Text.Trim()) * Convert.ToInt32(lblChalanQty.Text)).ToString();
                               } 
                            }
                            ResultId = ProductController.Usp_Insert_OpeningStockItemDetails(18, lblInwardCode_BR.Text.Trim(), lblInwardEbtryCode_BR.Text.Trim(), txtItemSerialNo.Text.Trim(), txtItemBarcodeNo.Text.Trim(), 1, txtPurchaseRate.Text.Trim(), OpeningStock_Purchase_Amount, txtCurrentValue.Text.Trim(), ddlStatus.SelectedValue, ddlCondition.SelectedValue, txtPurchaseDate.Value, txtPONumber.Text.Trim(), lblBudget_Division.Text, txtAssetNo.Text, CreatedBy);

                            if (ResultId == "1")
                            {
                                lblResult.ForeColor = System.Drawing.Color.Green;
                                lblResult.Text = "Success";
                            }
                            else
                            {
                                lblResult.ForeColor = System.Drawing.Color.Red;
                                lblResult.Text = "Error";
                            }

                        } 
                    }
                    else if (lblItemType.Text == "ATN00000003")//if item type is 3
                    {
                        if (txtCurrentValue.Text.Trim() == "")
                        {
                            lblResult.ForeColor = System.Drawing.Color.Red;
                            lblResult.Text = "Error : Enter Current Value";
                            cnttrue = cnttrue + 1;
                        }
                        else if (ddlStatus.SelectedIndex == 0)
                        {
                            lblResult.ForeColor = System.Drawing.Color.Red;
                            lblResult.Text = "Error : Select Status";
                            cnttrue = cnttrue + 1;
                        }
                        else if (ddlCondition.SelectedIndex == 0)
                        {
                            lblResult.ForeColor = System.Drawing.Color.Red;
                            lblResult.Text = "Error : Select Condition";
                            cnttrue = cnttrue + 1;
                        }
                        else
                        {
                            string OpeningStock_Purchase_Amount = "0";

                            ResultId = ProductController.Usp_Insert_OpeningStockItemDetails(24, lblInwardCode_BR.Text.Trim(), lblInwardEbtryCode_BR.Text.Trim(), txtItemSerialNo.Text.Trim(), txtItemBarcodeNo.Text.Trim(), 1, txtPurchaseRate.Text.Trim(), OpeningStock_Purchase_Amount, txtCurrentValue.Text.Trim(), ddlStatus.SelectedValue, ddlCondition.SelectedValue, txtPurchaseDate.Value, txtPONumber.Text.Trim(), lblBudget_Division.Text, txtAssetNo.Text, CreatedBy);

                            if (ResultId == "1")
                            {
                                lblResult.ForeColor = System.Drawing.Color.Green;
                                lblResult.Text = "Success";
                            }
                            else
                            {
                                lblResult.ForeColor = System.Drawing.Color.Red;
                                lblResult.Text = "Error";
                            }

                        } 
                    }
                    else
                    {
                        lblResult.ForeColor = System.Drawing.Color.Red;
                        lblResult.Text = "Error : Serial number Or Barcode Number Is Empty...!";
                        cnttrue = cnttrue + 1;
                    }
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
    protected void btnUserMenuClose_Click(object sender, EventArgs e)
    {
        Clear_Error_Success_Box();
        ControlVisibility("Add");
    }


    protected void HLExport_Click(object sender, EventArgs e)
    {
        DataList1.Visible = true;

        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        string filenamexls1 = "Opening Stock_" + DateTime.Now + ".xls";
        Response.AddHeader("Content-Disposition", "inline;filename=" + filenamexls1);
        HttpContext.Current.Response.Charset = "utf-8";
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");
        //sets font
        HttpContext.Current.Response.Write("<font style='font-size:10.0pt; font-family:Calibri;'>");
        HttpContext.Current.Response.Write("<BR><BR><BR>");
        HttpContext.Current.Response.Write("<Table border='1'  borderColor='#000000' cellSpacing='0' cellPadding='0' style='font-size:10.0pt; font-family:Calibri; text-align:center;'> <TR style='color: #fff; background: black;text-align:center;'><TD Colspan='9'>Opening Stock</b></TD></TR>");
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
    protected void ddlPOStatus_Add_SelectedIndexChanged(object sender, EventArgs e)
    {
        //try
        //{
    //        if (ddlPOStatus_Add.SelectedValue == "Yes")
    //        {
    //            FillDDL_PONumber();
    //            PONOID.Visible = true;
    //            SuppID.Visible = false;
    //            //DivAddItem.Visible = true;
    //            tbl_poNo.Visible = false;
    //            tbl_poYes.Visible = true;

    //            lblsup.Visible = true;
    //            lblSuppName.Visible = true;
    //            //txtItemRate.Enabled = false;
    //            txtItemRate.ReadOnly = true;
    //            ClearItemAdd();
    //        }
    //        else if (ddlPOStatus_Add.SelectedValue == "No")
    //        {
    //            PONOID.Visible = false;
    //            SuppID.Visible = true;
    //            //DivAddItem.Visible = true;
    //            tbl_poNo.Visible = true;
    //            tbl_poYes.Visible = false;
    //            //txtItemRate.Enabled = true;
    //            txtItemRate.ReadOnly = false;
    //            lblsup.Visible = false;
    //            lblSuppName.Visible = false;
    //            FillDDL_Supplier();
    //            ClearItemAdd();
    //        }
    //        else if (ddlPOStatus_Add.SelectedValue == "Select")
    //        {
    //            PONOID.Visible = false;
    //            SuppID.Visible = false;
    //            //DivAddItem.Visible = false;
    //            lblsup.Visible = false;
    //            lblSuppName.Visible = false;
    //            ClearItemAdd();
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
        
    }

    protected void btnSaveItem_ServerClick(object sender, EventArgs e)
    {
        try
        {

            Clear_Error_Success_Box();


            if (ddlTransferFR_SR.SelectedIndex == 0)
            {
                Show_Error_Success_Box("E", "Select Location Type");
                ddlTransferFR_SR.Focus();
                return;
            }
            if (ddlTransferFR_SR.SelectedItem.ToString() == "Godown")
            {
                // Transfer_LocationCode = ddlgodownFR_SR.SelectedValue.ToString().Trim();
                if (ddlgodownFR_SR.SelectedIndex == 0)
                {
                    Show_Error_Success_Box("E", "Select Godown");
                    ddlgodownFR_SR.Focus();
                    return;
                }
            }
            else if (ddlTransferFR_SR.SelectedItem.ToString() == "Function")
            {
                // Transfer_LocationCode = ddlFunctionFR_SR.SelectedValue.ToString().Trim();
                if (ddlFunctionFR_SR.SelectedIndex == 0)
                {
                    Show_Error_Success_Box("E", "Select Function");
                    ddlFunctionFR_SR.Focus();
                    return;
                }
            }
            else if (ddlTransferFR_SR.SelectedItem.ToString() == "Center")
            {
                //Transfer_LocationCode = ddlCenterFR_SR.SelectedValue.ToString().Trim();
                if (ddlDivisionFR_SR.SelectedIndex == 0)
                {
                    Show_Error_Success_Box("E", "Select Division");
                    ddlCenterFR_SR.Focus();
                    return;
                }
                if (ddlCenterFR_SR.SelectedIndex == 0)
                {
                    Show_Error_Success_Box("E", "Select Center");
                    ddlCenterFR_SR.Focus();
                    return;
                }

            }

            if (lblMateCode.Text.Trim() == "")
            {
                Show_Error_Success_Box("E", "Select Item");
                return;
            }

            if (ddlDivision.SelectedIndex == 0)
            {
                Show_Error_Success_Box("E", "Select Budget Division");
                ddlDivision.Focus();
                return;
            }

            if (txtItemQty.Text.Trim() == "")
            {
                Show_Error_Success_Box("E", "Enter Item Quantity");
                txtItemQty.Focus();
                return;
            }

            string Transfer_LocationCode = "";
            if (ddlTransferFR_SR.SelectedItem.ToString() == "Godown")
            {
                Transfer_LocationCode = ddlgodownFR_SR.SelectedValue.ToString().Trim();
            }
            else if (ddlTransferFR_SR.SelectedItem.ToString() == "Function")
            {
                Transfer_LocationCode = ddlFunctionFR_SR.SelectedValue.ToString().Trim();
            }
            else if (ddlTransferFR_SR.SelectedItem.ToString() == "Center")
            {
                Transfer_LocationCode = ddlCenterFR_SR.SelectedValue.ToString().Trim();
            }
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
           string  CreatedBy = cookie.Values["UserID"];

            if (lblPkey.Text == "")
            {
                string ResultId = ProductController.Insert_ChkOpeningStock(22, ddlTransferFR_SR.SelectedValue.ToString(), Transfer_LocationCode);
                if ((ResultId != ""))
                {
                    Show_Error_Success_Box("E", "This Location is Aleready Exist");
                    return;
                }
            }
            
            DataSet dsSupplier = ProductController.GetItem_ByAll(lblMateCode.Text.Trim(), 2);

            if (dsSupplier.Tables[0].Rows.Count > 0)
            {
                if (dsSupplier.Tables[0].Rows.Count == 1)
                {
                    string ResultId123 = ProductController.Insert_OpeningStockInward_Items(1, lblPkey.Text, "", lblMateCode.Text, Convert.ToDouble(txtItemQty.Text.Trim()), 0, 0, 1, "0", ddlDivision.SelectedValue.ToString(), CreatedBy);
                }
            }


            DataSet dsItems = ProductController.Get_Edit_GRNDetails(5, lblPkey.Text.Trim());
            if (dsItems.Tables[0].Rows.Count > 0)
            {
                dlQuestion.DataSource = dsItems;
                dlQuestion.DataBind();
            }
            //TempSaveData();
            ClearItemAdd();
            //tr1.Visible = false;
            //tr2.Visible = false;
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

    protected void btnSearchItem_Click(object sender, EventArgs e)
    {
        try
        {
            Clear_Error_Success_Box();

            if (txtItemMatCode.Text.Trim() == "")
            {
                Show_Error_Success_Box("E", "Enter Material Code");
                txtItemMatCode.Focus();
                return;
            }

            DataSet dsSupplier = ProductController.GetItem_ByAll(txtItemMatCode.Text.Trim(), 1);
            ClearItemAdd();

            if (dsSupplier.Tables[0].Rows.Count > 0)
            {
                if (dsSupplier.Tables[0].Rows.Count == 1)
                {
                    lblMateCode.Text = dsSupplier.Tables[0].Rows[0]["Item_Code"].ToString();
                    lblItemName.Text = dsSupplier.Tables[0].Rows[0]["Item_Name"].ToString();
                    lblUnit.Text = dsSupplier.Tables[0].Rows[0]["UOM_Name"].ToString();
                }
                else if (dsSupplier.Tables[0].Rows.Count >= 1)
                {
                    DataList3.DataSource = dsSupplier;
                    DataList3.DataBind();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalDivOverride();", true);
                    //UpdatePanel1.Update();
                }

            }

            //tr1.Visible = true;
            //tr2.Visible = true;

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

    protected void btnClearItem_Click(object sender, EventArgs e)
    {
        ClearItemAdd();
        //tr1.Visible = false;
        //tr2.Visible = false;
    }

    protected void txtItemRate_TextChanged(object sender, EventArgs e)
    {
        Clear_Error_Success_Box();

        if (txtItemQty.Text.Trim() == "")
        {
            Show_Error_Success_Box("E", "Enter Item Quantity");
            txtItemQty.Focus();
            return;
        }
        int Qty1 = 0, Rate1 = 0;
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

        int CalAns = Qty1 * Rate1;

        //lblCalValue.Text = CalAns.ToString();

    }

    protected void DataList3_ItemCommand(object source, DataListCommandEventArgs e)
    {

        if (e.CommandName == "comSetItem")
        {
            ClearItemAdd();
            Clear_Error_Success_Box();

            string MaterialCode = e.CommandArgument.ToString();

            DataSet dsSupplier = ProductController.GetItem_ByAll(MaterialCode, 2);
            ClearItemAdd();

            if (dsSupplier.Tables[0].Rows.Count > 0)
            {
                lblMateCode.Text = dsSupplier.Tables[0].Rows[0]["Item_Code"].ToString();
                lblItemName.Text = dsSupplier.Tables[0].Rows[0]["Item_Name"].ToString();
                lblUnit.Text = dsSupplier.Tables[0].Rows[0]["UOM_Name"].ToString();

            }

            //tr1.Visible = true;
            //tr2.Visible = true;
        }

    }
    protected void dlGridDisplay_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "comEdit")
        {
            
            lblPkey.Text = "";
            ControlVisibility("Add");
            //BtnSaveEdit.Visible = true;
            ddlTransferFR_SR.Enabled = false;
            ddlgodownFR_SR.Enabled = false;
            ddlDivisionFR_SR.Enabled = false;
            ddlFunctionFR_SR.Enabled = false;
            ddlCenterFR_SR.Enabled = false;
            //BtnSaveAdd.Visible = true;
            //ClearAddPanel();
            ClearItemAdd();
            dlQuestion.DataSource = null;
            dlQuestion.DataBind();
            FillDDL_Supplier();
            Clear_Error_Success_Box();
            string poflag;
            lblPkey.Text = e.CommandArgument.ToString();
            DataSet ds = ProductController.Get_Fill_OpeninfStockDetails(2, "", "", lblPkey.Text);

            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlTransferFR_SR.SelectedValue = ds.Tables[0].Rows[0]["Location_Type"].ToString();
                ddlTransferFR_SR_SelectedIndexChanged(source, e);

                if (ds.Tables[0].Rows[0]["Location_Type"].ToString() == "TL0000001")//Godown
                {
                    ddlgodownFR_SR.SelectedValue = ds.Tables[0].Rows[0]["Location"].ToString();
                }
                else if (ds.Tables[0].Rows[0]["Location_Type"].ToString() == "TL0000002")//Function
                {
                    ddlFunctionFR_SR.SelectedValue = ds.Tables[0].Rows[0]["Location"].ToString();
                }
                else if (ds.Tables[0].Rows[0]["Location_Type"].ToString() == "TL0000003")//Center
                {
                    ddlDivisionFR_SR.SelectedValue = ds.Tables[0].Rows[0]["Division"].ToString();
                    ddlDivisionFR_SR_SelectedIndexChanged(source, e);
                    ddlCenterFR_SR.SelectedValue = ds.Tables[0].Rows[0]["Location"].ToString();
                }

                DataSet dsItems = ProductController.Get_Edit_GRNDetails(5, lblPkey.Text.Trim());
                if (dsItems.Tables[0].Rows.Count > 0)
                {
                    dlQuestion.DataSource = dsItems;
                    dlQuestion.DataBind();
                }
            }
        }
        else if (e.CommandName == "comAuthorise")
        {
            lblPkey.Text = "";
            ControlVisibility("Authorise");
            Clear_Error_Success_Box();
            dlItemListAuthorise.DataSource = null;
            dlItemListAuthorise.DataBind();
            lblPkey.Text = e.CommandArgument.ToString();
            DataSet ds = ProductController.Get_Fill_OpeninfStockDetails(2, "", "", lblPkey.Text);

            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlTransferFR_SRAuthorise.SelectedValue = ds.Tables[0].Rows[0]["Location_Type"].ToString();
                ddlTransferFR_SRAuthorise_SelectedIndexChanged(source, e);

                if (ds.Tables[0].Rows[0]["Location_Type"].ToString() == "TL0000001")//Godown
                {
                    ddlgodownFR_SRAuthorise.SelectedValue = ds.Tables[0].Rows[0]["Location"].ToString();
                }
                else if (ds.Tables[0].Rows[0]["Location_Type"].ToString() == "TL0000002")//Function
                {
                    ddlFunctionFR_SRAuthorise.SelectedValue = ds.Tables[0].Rows[0]["Location"].ToString();
                }
                else if (ds.Tables[0].Rows[0]["Location_Type"].ToString() == "TL0000003")//Center
                {
                    ddlDivisionFR_SRAuthorise.SelectedValue = ds.Tables[0].Rows[0]["Division"].ToString();
                    ddlDivisionFR_SRAuthorise_SelectedIndexChanged(source, e);
                    ddlCenterFR_SRAuthorise.SelectedValue = ds.Tables[0].Rows[0]["Location"].ToString();
                }

                DataSet dsItems = ProductController.Get_Edit_GRNDetails(5, lblPkey.Text.Trim());
                if (dsItems.Tables[0].Rows.Count > 0)
                {
                    dlItemListAuthorise.DataSource = dsItems;
                    dlItemListAuthorise.DataBind();
                }
            }
        }
    }
    protected void dlQuestion_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "Details")
        {
            btnUserMenuSave.Visible = true;
            ControlVisibility("Details");
            lblInwardEbtryCode_BR.Text = e.CommandArgument.ToString();
            int Qty = 0;

            Label lblAssetType = (Label)e.Item.FindControl("lblAssetType");
            lblItemType.Text = lblAssetType.Text;
            Label lblBarcode_DT = (Label)e.Item.FindControl("lblBarcode_DT");
            lblEANNo.Text = lblBarcode_DT.Text;
            Label lblChallanQty_DT = (Label)e.Item.FindControl("lblChallanQty_DT");
            lblChalanQty.Text = lblChallanQty_DT.Text;

            //Label lblSRNo = (Label)e.FindControl("lblSRNo");

            DataSet ds = ProductController.Get_FillDetails_InwardItems(9, lblInwardEbtryCode_BR.Text.Trim());
            //Get_FillDetails_InwardItems
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtItemName_BR.Text = ds.Tables[0].Rows[0]["Item_Name"].ToString();
                Qty = Convert.ToInt32(ds.Tables[0].Rows[0]["Inward_Qty"].ToString());
                lblInwardCode_BR.Text = ds.Tables[0].Rows[0]["Inward_Code"].ToString();
                lblBudget_Division.Text = ds.Tables[0].Rows[0]["Budget_Division"].ToString();
            }

            

            DataTable dtEmptEntry = new DataTable();
            DataRow NewRow = null;

            var _with1 = dtEmptEntry;
            _with1.Columns.Add("lblSRNo");
            _with1.Columns.Add("txtItemSerialNo");
            _with1.Columns.Add("txtAssetNo");
            _with1.Columns.Add("txtItemBarcodeNo");
            _with1.Columns.Add("Purchase_Rate");
            _with1.Columns.Add("PurchaseDate");
            _with1.Columns.Add("PONumber");
            _with1.Columns.Add("Current_Value");
            _with1.Columns.Add("Asset_Status_Id");
            _with1.Columns.Add("ConditionId");


            if (lblAssetType.Text == "ATN00000001")
            {
                NewRow = dtEmptEntry.NewRow();
                NewRow["lblSRNo"] = "1";
                NewRow["txtItemSerialNo"] = lblEANNo.Text;
                NewRow["txtAssetNo"] = "";
                NewRow["txtItemBarcodeNo"] = lblEANNo.Text;
                NewRow["Purchase_Rate"] = "";
                NewRow["PurchaseDate"] = "";
                NewRow["PONumber"] = "";
                NewRow["Current_Value"] = "";
                NewRow["Asset_Status_Id"] = "";
                NewRow["ConditionId"] = "";

                dtEmptEntry.Rows.Add(NewRow);
            }
            else
            {
                for (int i = 0; i < Qty; i++)
                {
                    int rownum = i + 1;

                    NewRow = dtEmptEntry.NewRow();
                    NewRow["lblSRNo"] = rownum.ToString();
                    NewRow["txtItemSerialNo"] = "";
                    NewRow["txtItemBarcodeNo"] = "";
                    NewRow["txtAssetNo"] = "";
                    NewRow["Purchase_Rate"] = "";
                    NewRow["PurchaseDate"] = "";
                    NewRow["PONumber"] = "";
                    NewRow["Current_Value"] = "";
                    NewRow["Asset_Status_Id"] = "";
                    NewRow["ConditionId"] = "";

                    dtEmptEntry.Rows.Add(NewRow);

                }
            }

            DataList2.DataSource = dtEmptEntry;
            DataList2.DataBind();

            DataSet DSCHK = ProductController.Get_FillDetails_InwardItemsDetails(12, lblInwardCode_BR.Text.Trim(), lblInwardEbtryCode_BR.Text.Trim());
            
            foreach (DataListItem item in DataList2.Items)
            {
                if (item.ItemType == ListItemType.Item | item.ItemType == ListItemType.AlternatingItem)
                {
                    Label lblSRNo = (Label)item.FindControl("lblSRNo");
                    TextBox txtItemSerialNo = (TextBox)item.FindControl("txtItemSerialNo");
                    TextBox txtAssetNo = (TextBox)item.FindControl("txtAssetNo");
                    TextBox txtItemBarcodeNo = (TextBox)item.FindControl("txtItemBarcodeNo");
                    TextBox txtPurchaseRate = (TextBox)item.FindControl("txtPurchaseRate");
                    System.Web.UI.HtmlControls.HtmlInputText txtPurchaseDate = (System.Web.UI.HtmlControls.HtmlInputText)item.FindControl("txtPurchaseDate");
                    TextBox txtPONumber = (TextBox)item.FindControl("txtPONumber");
                    TextBox txtCurrentValue = (TextBox)item.FindControl("txtCurrentValue");
                    DropDownList ddlStatus = (DropDownList)item.FindControl("ddlStatus");
                    DropDownList ddlCondition = (DropDownList)item.FindControl("ddlCondition");

                    if (lblItemType.Text == "ATN00000001")
                    {
                        txtItemSerialNo.Enabled = false;
                        txtItemBarcodeNo.Enabled = false;
                       // txtAssetNo.Visible = true;
                        //txtAssetNo.Enabled = false;
                    }
                    else if (lblItemType.Text == "ATN00000002")
                    {
                        txtItemSerialNo.Visible = true;
                        txtItemBarcodeNo.Visible = true;
                        txtAssetNo.Visible = true;
                        txtItemSerialNo.Enabled = true;
                        txtItemBarcodeNo.Enabled = true;

                    }
                    else if (lblItemType.Text == "ATN00000003")
                    {
                        txtItemSerialNo.Visible = true;
                        txtAssetNo.Visible = true;
                        txtItemBarcodeNo.Visible = true;
                        txtItemSerialNo.Enabled = true;
                        txtItemBarcodeNo.Enabled = false;

                    }


                    string srno = "", serial = "", barcode = "", Sap_Asset_No = "";
                    for (int k = 0; k < DSCHK.Tables[0].Rows.Count; k++)
                    {
                        srno = DSCHK.Tables[0].Rows[k]["lblSRNo"].ToString();
                        serial = DSCHK.Tables[0].Rows[k]["txtItemSerialNo"].ToString();
                        barcode = DSCHK.Tables[0].Rows[k]["txtItemBarcodeNo"].ToString();
                        Sap_Asset_No = DSCHK.Tables[0].Rows[k]["txtAssetNo"].ToString();

                        if (lblSRNo.Text.Trim() == srno)
                        {
                            txtItemSerialNo.Text = serial;
                            txtAssetNo.Text = Sap_Asset_No;
                            txtItemBarcodeNo.Text = barcode;
                            txtPurchaseRate.Text = DSCHK.Tables[0].Rows[k]["Purchase_Rate"].ToString();
                            
                            txtPONumber.Text = DSCHK.Tables[0].Rows[k]["PONumber"].ToString();
                            txtCurrentValue.Text = DSCHK.Tables[0].Rows[k]["Current_Value"].ToString();
                            if (DSCHK.Tables[0].Rows[k]["PurchaseDate"].ToString() == "01 Jan 1900")
                            {
                                txtPurchaseDate.Value = "";
                            }
                            else
                                txtPurchaseDate.Value = DSCHK.Tables[0].Rows[k]["PurchaseDate"].ToString();
                            
                            ddlStatus.SelectedValue = DSCHK.Tables[0].Rows[k]["Asset_Status_Id"].ToString();
                            ddlCondition.SelectedValue = DSCHK.Tables[0].Rows[k]["ConditionId"].ToString();
                        }
                    }

                }
            }
        }
        else if (e.CommandName == "ItemRemove")
        {
            //Remove Confirmation
            lblInwardEntryCodeRemove.Text = e.CommandArgument.ToString().Trim();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalDivConfirmation();", true);

        }
        else if (e.CommandName == "Authorise")
        {
            btnUserMenuSave.Visible = false;
            ControlVisibility("Details");
            lblInwardEbtryCode_BR.Text = e.CommandArgument.ToString();
            int Qty = 0;

            Label lblAssetType = (Label)e.Item.FindControl("lblAssetType");
            lblItemType.Text = lblAssetType.Text;
            Label lblBarcode_DT = (Label)e.Item.FindControl("lblBarcode_DT");
            lblEANNo.Text = lblBarcode_DT.Text;
            Label lblChallanQty_DT = (Label)e.Item.FindControl("lblChallanQty_DT");
            lblChalanQty.Text = lblChallanQty_DT.Text;

            //Label lblSRNo = (Label)e.FindControl("lblSRNo");

            DataSet ds = ProductController.Get_FillDetails_InwardItems(9, lblInwardEbtryCode_BR.Text.Trim());
            //Get_FillDetails_InwardItems
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtItemName_BR.Text = ds.Tables[0].Rows[0]["Item_Name"].ToString();
                Qty = Convert.ToInt32(ds.Tables[0].Rows[0]["Inward_Qty"].ToString());
                lblInwardCode_BR.Text = ds.Tables[0].Rows[0]["Inward_Code"].ToString();
            }



            DataTable dtEmptEntry = new DataTable();
            DataRow NewRow = null;

            var _with1 = dtEmptEntry;
            _with1.Columns.Add("lblSRNo");
            _with1.Columns.Add("txtItemSerialNo");
            _with1.Columns.Add("txtItemBarcodeNo");
            _with1.Columns.Add("txtAssetNo");
            _with1.Columns.Add("Purchase_Rate");
            _with1.Columns.Add("PurchaseDate");
            _with1.Columns.Add("PONumber");
            _with1.Columns.Add("Current_Value");
            _with1.Columns.Add("Asset_Status_Id");
            _with1.Columns.Add("ConditionId");


            if (lblAssetType.Text == "ATN00000001")
            {
                NewRow = dtEmptEntry.NewRow();
                NewRow["lblSRNo"] = "1";
                NewRow["txtItemSerialNo"] = lblEANNo.Text;
                NewRow["txtItemBarcodeNo"] = lblEANNo.Text;
                NewRow["txtAssetNo"] = "";
                NewRow["Purchase_Rate"] = "";
                NewRow["PurchaseDate"] = "";
                NewRow["PONumber"] = "";
                NewRow["Current_Value"] = "";
                NewRow["Asset_Status_Id"] = "";
                NewRow["ConditionId"] = "";

                dtEmptEntry.Rows.Add(NewRow);
            }
            else
            {
                for (int i = 0; i < Qty; i++)
                {
                    int rownum = i + 1;

                    NewRow = dtEmptEntry.NewRow();
                    NewRow["lblSRNo"] = rownum.ToString();
                    NewRow["txtItemSerialNo"] = "";
                    NewRow["txtItemBarcodeNo"] = "";
                    NewRow["txtAssetNo"] = "";
                    NewRow["Purchase_Rate"] = "";
                    NewRow["PurchaseDate"] = "";
                    NewRow["PONumber"] = "";
                    NewRow["Current_Value"] = "";
                    NewRow["Asset_Status_Id"] = "";
                    NewRow["ConditionId"] = "";

                    dtEmptEntry.Rows.Add(NewRow);

                }
            }

            DataList2.DataSource = dtEmptEntry;
            DataList2.DataBind();

            DataSet DSCHK = ProductController.Get_FillDetails_InwardItemsDetails(12, lblInwardCode_BR.Text.Trim(), lblInwardEbtryCode_BR.Text.Trim());
            DataList2.DataSource = DSCHK;
            DataList2.DataBind();
            

            foreach (DataListItem item in DataList2.Items)
            {
                if (item.ItemType == ListItemType.Item | item.ItemType == ListItemType.AlternatingItem)
                {
                    Label lblSRNo = (Label)item.FindControl("lblSRNo");
                    TextBox txtItemSerialNo = (TextBox)item.FindControl("txtItemSerialNo");
                    TextBox txtItemBarcodeNo = (TextBox)item.FindControl("txtItemBarcodeNo");
                    TextBox txtAssetNo = (TextBox)item.FindControl("txtAssetNo");
                    TextBox txtPurchaseRate = (TextBox)item.FindControl("txtPurchaseRate");
                    System.Web.UI.HtmlControls.HtmlInputText txtPurchaseDate = (System.Web.UI.HtmlControls.HtmlInputText)item.FindControl("txtPurchaseDate");
                    TextBox txtPONumber = (TextBox)item.FindControl("txtPONumber");
                    TextBox txtCurrentValue = (TextBox)item.FindControl("txtCurrentValue");
                    DropDownList ddlStatus = (DropDownList)item.FindControl("ddlStatus");
                    DropDownList ddlCondition = (DropDownList)item.FindControl("ddlCondition");
                    

                    if (lblItemType.Text == "ATN00000001")
                    {
                        txtItemSerialNo.Enabled = false;
                        txtItemBarcodeNo.Enabled = false;
                        txtAssetNo.Enabled = true;
                        txtAssetNo.Visible = true;
                    }
                    else if (lblItemType.Text == "ATN00000002")
                    {
                        txtItemSerialNo.Visible = true;
                        txtItemBarcodeNo.Visible = true;
                        txtItemSerialNo.Enabled = true;
                        txtItemBarcodeNo.Enabled = true;
                        txtAssetNo.Enabled = true;
                        txtAssetNo.Visible = true;

                    }
                    else if (lblItemType.Text == "ATN00000003")
                    {
                        txtItemSerialNo.Visible = true;
                        txtItemBarcodeNo.Visible = true;
                        txtItemSerialNo.Enabled = true;
                        txtItemBarcodeNo.Enabled = false;
                         txtAssetNo.Enabled = true;
                         txtAssetNo.Visible = true;

                    }


                    string srno = "", serial = "", barcode = "";
                    for (int k = 0; k < DSCHK.Tables[0].Rows.Count; k++)
                    {
                        srno = DSCHK.Tables[0].Rows[k]["lblSRNo"].ToString();
                        serial = DSCHK.Tables[0].Rows[k]["txtItemSerialNo"].ToString();
                        barcode = DSCHK.Tables[0].Rows[k]["txtItemBarcodeNo"].ToString();

                        if (lblSRNo.Text.Trim() == srno)
                        {
                            txtItemSerialNo.Text = serial;
                            txtItemBarcodeNo.Text = barcode;
                            txtPurchaseRate.Text = DSCHK.Tables[0].Rows[k]["Purchase_Rate"].ToString();

                            txtPONumber.Text = DSCHK.Tables[0].Rows[k]["PONumber"].ToString();
                            txtCurrentValue.Text = DSCHK.Tables[0].Rows[k]["Current_Value"].ToString();
                            if (DSCHK.Tables[0].Rows[k]["PurchaseDate"].ToString() == "01 Jan 1900")
                            {
                                txtPurchaseDate.Value = "";
                            }
                            else
                                txtPurchaseDate.Value = DSCHK.Tables[0].Rows[k]["PurchaseDate"].ToString();

                            ddlStatus.SelectedValue = DSCHK.Tables[0].Rows[k]["Asset_Status_Id"].ToString();
                            ddlCondition.SelectedValue = DSCHK.Tables[0].Rows[k]["ConditionId"].ToString();
                        }
                    }
                }
            }
        }
    }

    
    protected void DataList2_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        int tabIndex = 0;

        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            TextBox tbName = (TextBox)e.Item.FindControl("txtItemBarcodeNo");
            tbName.TabIndex = (short)++tabIndex;

            DropDownList ddlStatus = (DropDownList)e.Item.FindControl("ddlStatus");
            DataSet dsStatus = ProductController.GetGodown_Function_Logistic_Assests_Type(11);
            BindDDL(ddlStatus, dsStatus, "Assets_Status_Name", "Assets_Status_Id");
            ddlStatus.Items.Insert(0, "Select Status");
            ddlStatus.SelectedIndex = 0;

            DropDownList ddlCondition = (DropDownList)e.Item.FindControl("ddlCondition");
            DataSet dsCondition = ProductController.GetGodown_Function_Logistic_Assests_Type(4);
            BindDDL(ddlCondition, dsCondition, "Assets_Condition_Name", "Assets_Condition_Id");
            ddlCondition.Items.Insert(0, "Select Condition");
            ddlCondition.SelectedIndex = 0;            
        }
    }
    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
        foreach (DataListItem item in DataList2.Items)
        {
            if (item.ItemType == ListItemType.Item | item.ItemType == ListItemType.AlternatingItem)
            {
                Label lblSRNo = (Label)item.FindControl("lblSRNo");
                TextBox txtItemSerialNo = (TextBox)item.FindControl("txtItemSerialNo");
                TextBox txtItemBarcodeNo = (TextBox)item.FindControl("txtItemBarcodeNo");


                txtItemSerialNo.Enabled = false;
                txtItemSerialNo.Text = "";
                txtItemBarcodeNo.Text = "";

            }
        }

        DataSet DSCHK = ProductController.Get_FillDetails_InwardItemsDetails(12, lblInwardCode_BR.Text.Trim(), lblInwardEbtryCode_BR.Text.Trim());

        foreach (DataListItem item in DataList2.Items)
        {
            if (item.ItemType == ListItemType.Item | item.ItemType == ListItemType.AlternatingItem)
            {
                Label lblSRNo = (Label)item.FindControl("lblSRNo");
                TextBox txtItemSerialNo = (TextBox)item.FindControl("txtItemSerialNo");
                TextBox txtItemBarcodeNo = (TextBox)item.FindControl("txtItemBarcodeNo");
                string srno = "", serial = "", barcode = "";
                for (int k = 0; k < DSCHK.Tables[0].Rows.Count; k++)
                {
                    srno = DSCHK.Tables[0].Rows[k]["lblSRNo"].ToString();
                    serial = DSCHK.Tables[0].Rows[k]["txtItemSerialNo"].ToString();
                    barcode = DSCHK.Tables[0].Rows[k]["txtItemBarcodeNo"].ToString();

                    if (lblSRNo.Text.Trim() == srno)
                    {
                        txtItemSerialNo.Text = serial;
                        txtItemBarcodeNo.Text = barcode;
                    }
                }

            }
        }
    }
    protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
    {
        foreach (DataListItem item in DataList2.Items)
        {
            if (item.ItemType == ListItemType.Item | item.ItemType == ListItemType.AlternatingItem)
            {
                Label lblSRNo = (Label)item.FindControl("lblSRNo");
                TextBox txtItemSerialNo = (TextBox)item.FindControl("txtItemSerialNo");
                TextBox txtItemBarcodeNo = (TextBox)item.FindControl("txtItemBarcodeNo");

                if (lblSRNo.Text.Trim() == "1")
                {
                    txtItemSerialNo.Enabled = true;
                }
                else
                {
                    txtItemSerialNo.Enabled = false;
                }

                txtItemSerialNo.Text = "";
                txtItemBarcodeNo.Text = "";
            }
        }

        DataSet DSCHK = ProductController.Get_FillDetails_InwardItemsDetails(12, lblInwardCode_BR.Text.Trim(), lblInwardEbtryCode_BR.Text.Trim());

        foreach (DataListItem item in DataList2.Items)
        {
            if (item.ItemType == ListItemType.Item | item.ItemType == ListItemType.AlternatingItem)
            {
                Label lblSRNo = (Label)item.FindControl("lblSRNo");
                TextBox txtItemSerialNo = (TextBox)item.FindControl("txtItemSerialNo");
                TextBox txtItemBarcodeNo = (TextBox)item.FindControl("txtItemBarcodeNo");
                string srno = "", serial = "", barcode = "";
                for (int k = 0; k < DSCHK.Tables[0].Rows.Count; k++)
                {
                    srno = DSCHK.Tables[0].Rows[k]["lblSRNo"].ToString();
                    serial = DSCHK.Tables[0].Rows[k]["txtItemSerialNo"].ToString();
                    barcode = DSCHK.Tables[0].Rows[k]["txtItemBarcodeNo"].ToString();

                    if (lblSRNo.Text.Trim() == srno)
                    {
                        txtItemSerialNo.Text = serial;
                        txtItemBarcodeNo.Text = barcode;
                    }
                }

            }
        }
    }
    protected void txtItemSerialNo_TextChanged(object sender, EventArgs e)
    {
        //if (RadioButton1.Checked == true)
        //{
            string Copy = "";
            foreach (DataListItem item in DataList2.Items)
            {
                if (item.ItemType == ListItemType.Item | item.ItemType == ListItemType.AlternatingItem)
                {
                    Label lblSRNo = (Label)item.FindControl("lblSRNo");
                    TextBox txtItemSerialNo = (TextBox)item.FindControl("txtItemSerialNo");
                    TextBox txtItemBarcodeNo = (TextBox)item.FindControl("txtItemBarcodeNo");

                    if (lblSRNo.Text.Trim() == "1")
                    {
                        Copy = txtItemSerialNo.Text.Trim();
                    }
                    else
                    {
                        txtItemSerialNo.Text = "";
                        txtItemSerialNo.Text = Copy;
                    }

                }
            }
       // }

    }

    protected void txtItemBarcodeNo_TextChanged(object sender, EventArgs e)
    {
        //if (RadioButton2.Checked == true)
        //{
            string Copy = "";
            foreach (DataListItem item in DataList2.Items)
            {
                if (item.ItemType == ListItemType.Item | item.ItemType == ListItemType.AlternatingItem)
                {
                    Label lblSRNo = (Label)item.FindControl("lblSRNo");
                    TextBox txtItemSerialNo = (TextBox)item.FindControl("txtItemSerialNo");
                    TextBox txtItemBarcodeNo = (TextBox)item.FindControl("txtItemBarcodeNo");

                    Copy = txtItemBarcodeNo.Text.Trim();
                    txtItemSerialNo.Text = "";
                    txtItemSerialNo.Text = Copy;

                }
            }
        //}
        //else
        //{
        //}

    }
    protected void ddlPONo_Add_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //if (ddlPONo_Add.SelectedIndex == 0 || ddlPONo_Add.SelectedIndex == -1)
            //{
            //    ddlPOItems_Add.Items.Clear();
            //    lblSuppName.Text = "";
            //    lblsuppliercode.Text = "";
            //}
            //else
            //{
            //    DataSet dsSupplier = ProductController.GetSupplierPONumber(15, ddlPONo_Add.SelectedValue .ToString ().Trim ());

            //    if (dsSupplier.Tables[0].Rows.Count > 0)
            //    {
            //        lblSuppName.Text = dsSupplier.Tables[0].Rows[0]["Vendor_Name"].ToString();
            //        lblsuppliercode.Text = dsSupplier.Tables[0].Rows[0]["Supplier_Code"].ToString();                    
            //    }

            //    FillDDL_POItems();
            //}
        }
        catch(Exception ex)
        {
            Msg_Error.Visible = true;
            Msg_Success.Visible = false;
            lblerror.Text = ex.ToString();
            UpdatePanelMsgBox.Update();
            return;
        }
    }
    protected void ddlPOItems_Add_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //if (ddlPOItems_Add.SelectedIndex == 0 || ddlPOItems_Add.SelectedIndex == -1)
            //{
            //    lblMateCode.Text = "";
            //    lblItemName.Text = "";
            //    lblUnit.Text = "";
            //    lblItemPOQty.Text = "0";
            //    txtItemRate.Text = "";
            //}
            //else
            //{
                //DataSet dsItemDetails = ProductController.GetItemsDetailsPONumber(17, ddlPONo_Add.SelectedValue.ToString().Trim(), ddlPOItems_Add.SelectedValue .ToString ().Trim ());

                //if (dsItemDetails.Tables[0].Rows.Count > 0)
                //{
                //    lblMateCode.Text = dsItemDetails.Tables[0].Rows[0]["Item_Code"].ToString();
                //    lblItemName.Text = dsItemDetails.Tables[0].Rows[0]["Item_Name"].ToString();
                //    lblUnit.Text = dsItemDetails.Tables[0].Rows[0]["UOM_Name"].ToString();
                //    lblItemPOQty.Text = dsItemDetails.Tables[0].Rows[0]["PurchaseOrder_Qty"].ToString();
                //    txtItemRate.Text = dsItemDetails.Tables[0].Rows[0]["PurchaseOrder_Rate"].ToString();
                //}
            //}
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
    protected void txtItemQty_TextChanged(object sender, EventArgs e)
    {
        int Qty1 = 0, Rate1 = 0;
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

        int CalAns = Qty1 * Rate1;

        //lblCalValue.Text = CalAns.ToString();
    }
    protected void ddlTransferFR_SR_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTransferFR_SR.SelectedItem.ToString().Trim() == "Godown")
        {
            tblFr_Godown.Visible = true;
            tblFr_Function.Visible = false;
            tblFr_Division.Visible = false;
            tblFr_Center.Visible = false;
          //  FillDDL_Godown();
        }
        else if (ddlTransferFR_SR.SelectedItem.ToString().Trim() == "Function")
        {
            tblFr_Function.Visible = true;
            tblFr_Godown.Visible = false;
            tblFr_Division.Visible = false;
            tblFr_Center.Visible = false;
          //  FillDDL_Function();
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

   
    protected void ddlDivisionFR_SR_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlCenterFR_SR.Items.Clear();
        FillDDL_FRSearch_Centre();
    }

    protected void ddlLogisticType_Add_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (ddlLogisticType_Add.SelectedIndex == 0 || ddlLogisticType_Add.SelectedIndex == -1)
        //{
        //    tblPODNo.Visible = false;
        //    tblVehNo.Visible = false;
        //}
        //else if (ddlLogisticType_Add.SelectedItem.ToString().Trim() == "Courier")
        //{
        //    tblPODNo.Visible = true;
        //    tblVehNo.Visible = false;
        //}
        //else if (ddlLogisticType_Add.SelectedItem.ToString().Trim() == "In Person")
        //{
        //    tblPODNo.Visible = false;
        //    tblVehNo.Visible = false;
        //}
        //else if (ddlLogisticType_Add.SelectedItem.ToString().Trim() == "Transport")
        //{
        //    tblPODNo.Visible = false;
        //    tblVehNo.Visible = true;
        //}
    }

    protected void ddlLocationType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlLocationType.SelectedItem.ToString().Trim() == "Godown")
        {
            tblFr_GodownSearch.Visible = true;
            tblFr_FunctionSearch.Visible = false;
            tblFr_DivisionSearch.Visible = false;
            tblFr_CenterSearch.Visible = false;
        }
        else if (ddlLocationType.SelectedItem.ToString().Trim() == "Function")
        {
            tblFr_FunctionSearch.Visible = true;
            tblFr_GodownSearch.Visible = false;
            tblFr_DivisionSearch.Visible = false;
            tblFr_CenterSearch.Visible = false;
        }
        else if (ddlLocationType.SelectedItem.ToString().Trim() == "Center")
        {
            tblFr_DivisionSearch.Visible = true;
            tblFr_CenterSearch.Visible = true;
            tblFr_FunctionSearch.Visible = false;
            tblFr_GodownSearch.Visible = false;

            //Fill Division
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];

        }
        else if (ddlLocationType.SelectedIndex == 0 || ddlLocationType.SelectedIndex == -1)
        {
            tblFr_GodownSearch.Visible = false;
            tblFr_FunctionSearch.Visible = false;
            tblFr_DivisionSearch.Visible = false;
            tblFr_CenterSearch.Visible = false;
        }
    }

    protected void ddlDivisionFR_SRSearch_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlCenterFR_SRSearch.Items.Clear();
        FillDDL_FRSearch_Centre_Search();
    }

    protected void ddlTransferFR_SRAuthorise_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTransferFR_SRAuthorise.SelectedItem.ToString().Trim() == "Godown")
        {
            tblFr_GodownAuthorise.Visible = true;
            tblFr_FunctionAuthorise.Visible = false;
            tblFr_DivisionAuthorise.Visible = false;
            tblFr_CenterAuthorise.Visible = false;
            //  FillDDL_Godown();
        }
        else if (ddlTransferFR_SRAuthorise.SelectedItem.ToString().Trim() == "Function")
        {
            tblFr_FunctionAuthorise.Visible = true;
            tblFr_GodownAuthorise.Visible = false;
            tblFr_DivisionAuthorise.Visible = false;
            tblFr_CenterAuthorise.Visible = false;
            //  FillDDL_Function();
        }
        else if (ddlTransferFR_SRAuthorise.SelectedItem.ToString().Trim() == "Center")
        {
            tblFr_DivisionAuthorise.Visible = true;
            tblFr_CenterAuthorise.Visible = true;
            tblFr_FunctionAuthorise.Visible = false;
            tblFr_GodownAuthorise.Visible = false;

            //Fill Division
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];

        }
        else if (ddlTransferFR_SRAuthorise.SelectedIndex == 0 || ddlTransferFR_SRAuthorise.SelectedIndex == -1)
        {
            tblFr_GodownAuthorise.Visible = false;
            tblFr_FunctionAuthorise.Visible = false;
            tblFr_DivisionAuthorise.Visible = false;
            tblFr_CenterAuthorise.Visible = false;
        }
    }

    protected void ddlDivisionFR_SRAuthorise_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlCenterFR_SRAuthorise.Items.Clear();
        FillDDL_FRSearch_CentreAuthorise();
    }


    protected void btnCloseAuthorise_Click(object sender, EventArgs e)
    {
        BtnSearch_Click(this, e);
    }

    protected void btnAuthorise_Click(object sender, EventArgs e)
    {
        Clear_Error_Success_Box();
        int TotalRecord = 0;
        foreach (DataListItem dtlItem in dlItemListAuthorise.Items)
        {
            CheckBox chkCheck = (CheckBox)dtlItem.FindControl("chkCheck");

            if (chkCheck.Checked == true)
            {
                TotalRecord = TotalRecord + 1;
            }
        }
        if (TotalRecord == 0)
        {
            Show_Error_Success_Box("E", "You have not Selected any Record");
            return;
        }
        foreach (DataListItem dtlItem in dlItemListAuthorise.Items)
        {
            CheckBox chkCheck = (CheckBox)dtlItem.FindControl("chkCheck");

            if (chkCheck.Checked == true)
            {
                Label lblInwardEntry_Code = (Label)dtlItem.FindControl("lblInwardEntry_Code");
                Label lblMaterialCode_DT = (Label)dtlItem.FindControl("lblMaterialCode_DT");
                Label lblAssetType = (Label)dtlItem.FindControl("lblAssetType");
                Label lblBarcode_DT = (Label)dtlItem.FindControl("lblBarcode_DT");                

                Label lblHeader_User_Code = default(Label);
                lblHeader_User_Code = (Label)Master.FindControl("lblHeader_User_Code");

                string CreatedBy = null;
                HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                CreatedBy = cookie.Values["UserID"];               

                

                HtmlAnchor lbl_DLError = (HtmlAnchor)dtlItem.FindControl("lbl_DLError");
                Panel icon_Error = (Panel)dtlItem.FindControl("icon_Error");

                string ResultId = ProductController.Update_Authorisation_OpeningStock(1, lblPkey.Text, lblInwardEntry_Code.Text, lblMaterialCode_DT.Text, "1", lblAssetType.Text, CreatedBy, lblBarcode_DT.Text);
                if (ResultId == "1")
                {
                    icon_Error.Visible = false;                    
                    chkCheck.Visible = false;
                    chkCheck.Checked = false;

                    LinkButton lnkDLAuthorise = (LinkButton)dtlItem.FindControl("lnkDLAuthorise");
                    lnkDLAuthorise.Visible = true;
                }
                else if (ResultId == "-1")//if the Barcode Entry not insert into T803
                {
                    lbl_DLError.Title = "Please Enter the barcode for the item.";
                    icon_Error.Visible = true;
                }
            }
        }
    }

    protected void btnAllAuthorise_Click(object sender, EventArgs e)
    {

        Clear_Error_Success_Box();
        int TotalRecord = 0;
        foreach (DataListItem dtlItem in dlGridDisplay.Items)
        {
            CheckBox chkCheck = (CheckBox)dtlItem.FindControl("chkCheck");

            if (chkCheck.Checked == true)
            {
                TotalRecord = TotalRecord + 1;
            }
        }
        if (TotalRecord == 0)
        {
            Show_Error_Success_Box("E", "You have not Selected any Record");
            return;
        }
        foreach (DataListItem dtlItem in dlGridDisplay.Items)
        {
            CheckBox chkCheck = (CheckBox)dtlItem.FindControl("chkCheck");

            if (chkCheck.Checked == true)
            {
                Label lblInwardEntry_Code = (Label)dtlItem.FindControl("lblInwardEntryCode");
                Label lblMaterialCode_DT = (Label)dtlItem.FindControl("lblItemCode");
                Label lblAssetType = (Label)dtlItem.FindControl("lblAssetType");
                Label lblBarcode_DT = (Label)dtlItem.FindControl("lblBarcode_DT");

                Label lblHeader_User_Code = default(Label);
                lblHeader_User_Code = (Label)Master.FindControl("lblHeader_User_Code");

                string CreatedBy = null;
                HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                CreatedBy = cookie.Values["UserID"];



                HtmlAnchor lbl_DLError = (HtmlAnchor)dtlItem.FindControl("lbl_DLError");
                Panel icon_Error = (Panel)dtlItem.FindControl("icon_Error");

                string ResultId = ProductController.Update_Authorisation_OpeningStock(1, lblPkey.Text, lblInwardEntry_Code.Text, lblMaterialCode_DT.Text, "1", lblAssetType.Text, CreatedBy, lblBarcode_DT.Text);
                if (ResultId == "1")
                {
                    icon_Error.Visible = false;
                    chkCheck.Visible = false;
                    chkCheck.Checked = false;

                    LinkButton lnkDLAuthorise = (LinkButton)dtlItem.FindControl("lnkAuthorise");
                    lnkDLAuthorise.Visible = true;
                    Show_Error_Success_Box("S", "Authorisation Done Successfully.");
                }
                else if (ResultId == "-1")//if the Barcode Entry not insert into T803
                {
                    lbl_DLError.Title = "Please Enter the barcode for the item.";
                    icon_Error.Visible = true;
                }
            }
            //else
            //{
            //    Show_Error_Success_Box("E","Please select atleast one record");
            //    return;
            //}
        }
    }

    protected void btnDivConfirmYes_Click(object sender, System.EventArgs e)
    {
        DataSet dsGrid = ProductController.Remove_andFill_Items(25, lblInwardEntryCodeRemove.Text.Trim());

        if (dsGrid != null)
        {
            if (dsGrid.Tables.Count != 0)
            {
                if (dsGrid.Tables[0].Rows.Count != 0)
                {
                    //lbltotalcount.Text = (dsGrid.Tables[0].Rows.Count).ToString();
                    dlQuestion.DataSource = dsGrid;
                    dlQuestion.DataBind();
                }
                else
                {
                    dlQuestion.DataSource = null;
                    dlQuestion.DataBind();
                }
            }
            else
            {
                dlQuestion.DataSource = null;
                dlQuestion.DataBind();
                
            }
        }
        else
        {
            dlQuestion.DataSource = null;
            dlQuestion.DataBind();
        }

        //UpdatePanel1.Update();
    }
    #endregion



    protected void dlItemListAuthorise_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}


