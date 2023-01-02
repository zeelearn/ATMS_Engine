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
using Microsoft.VisualBasic;
using System.Collections;
using System.Diagnostics;
using System.Data.OleDb;
using System.Data.Odbc;
using System.Globalization;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;

public partial class Manage_GRN : System.Web.UI.Page
{

    #region PageLoad
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                ControlVisibility("Search");
                visFalse();
                FillDDL_Supplier();
                //Clear_TempChallan();
                FillDDL_Division();
                FillDDL_TransferType();
                FillDDL_Logistic();
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

    private void BindDDL(DropDownList ddl, DataSet ds, string txtField, string valField)
    {
        ddl.DataSource = ds;
        ddl.DataTextField = txtField;
        ddl.DataValueField = valField;
        ddl.DataBind();
    }

    public void visFalse()
    {
        PONOID.Visible = false;
        SuppID.Visible = false;
        //DivAddItem.Visible = false;
        lblsup.Visible = false;
        lblSuppName.Visible = false;
        //
        //tr1.Visible = false;
        //tr2.Visible = false;

    }

    private void FillDDL_Supplier()
    {
        DataSet dsSupplier = ProductController.GetAllSupplier();
        BindDDL(ddlSupplier_Add, dsSupplier, "Vendor_Name", "Vendor_Id");
        ddlSupplier_Add.Items.Insert(0, "Select");
        ddlSupplier_Add.SelectedIndex = 0;

        BindDDL(ddlSupplier_SR, dsSupplier, "Vendor_Name", "Vendor_Id");
        ddlSupplier_SR.Items.Insert(0, "Select");
        ddlSupplier_SR.SelectedIndex = 0;

        BindDDL(ddlSupplier_Auth, dsSupplier, "Vendor_Name", "Vendor_Id");
        ddlSupplier_Auth.Items.Insert(0, "Select");
        ddlSupplier_Auth.SelectedIndex = 0;

    }
    private void FillDDL_PONumber()
    {
        ddlPONo_Add.Items.Clear();
        DataSet dsPONumber = ProductController.GetAllPONumber(14);
        BindDDL(ddlPONo_Add, dsPONumber, "PurchaseOrder_Code", "PurchaseOrder_Code");
        ddlPONo_Add.Items.Insert(0, "Select");
        ddlPONo_Add.SelectedIndex = 0;

        BindDDL(ddlpoNo_Auth, dsPONumber, "PurchaseOrder_Code", "PurchaseOrder_Code");
        ddlpoNo_Auth.Items.Insert(0, "Select");
        ddlpoNo_Auth.SelectedIndex = 0;

    }

    private void FillDDL_POItems()
    {
        ddlPOItems_Add.Items.Clear();
        //DataSet dsPONumberItems = ProductController.GetItemsPONumber(16, ddlPONo_Add.SelectedValue.ToString().Trim());
        DataSet dsPONumberItems = ProductController.GetItemsDetailsPONumber(16, ddlPONo_Add.SelectedValue.ToString().Trim(), lblPkey.Text);
        BindDDL(ddlPOItems_Add, dsPONumberItems, "Item_Name", "PurchaseOrderEntry_Code");
        ddlPOItems_Add.Items.Insert(0, "Select");
        ddlPOItems_Add.SelectedIndex = 0;

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
            DivAuthorise.Visible = false;
            DivSearchPanel.Visible = true;
            BtnAdd.Visible = true;
            BtnSaveAdd.Visible = true;
            // BtnSaveEdit.Visible = false;
            DivResultPanel.Visible = false;
            DivAddBarcode.Visible = false;
            //RadioButton1.Checked = false;
            //RadioButton2.Checked = false;

        }
        else if (Mode == "Result")
        {
            DivAddBarcode.Visible = false;
            DivAddPanel.Visible = false;
            DivSearchPanel.Visible = false;
            BtnAdd.Visible = true;
            DivResultPanel.Visible = true;
            lblPkey.Text = "";
            DivAuthorise.Visible = false;

        }
        else if (Mode == "Add")
        {
            DivAddPanel.Visible = true;
            DivSearchPanel.Visible = false;
            DivAuthorise.Visible = false;
            BtnAdd.Visible = false;
            DivResultPanel.Visible = false;
            DivAddBarcode.Visible = false;

            ddlTransferFR_SR.Enabled = true;
            // ddllocation_Search.Enabled = true;
            //ddlTransferFR_SR.SelectedIndex = 0;
            ddlgodownFR_SR.Enabled = true;

            //BtnSaveEdit.Visible = false;
            BtnSaveAdd.Visible = true;
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
            BtnAdd.Visible = true;
            DivResultPanel.Visible = false;
            DivAddBarcode.Visible = true;
            // lblInwardCode_BR.Text = "";
            // lblInwardEbtryCode_BR.Text = "";
            DivAuthorise.Visible = false;
            btnUserMenuSave.Visible = true;

        }

        else if (Mode == "Authorise")
        {
            DivAddPanel.Visible = false;
            DivSearchPanel.Visible = false;
            BtnAdd.Visible = false;
            BtnSaveUpdate.Visible = false;
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
    private void ClearAddPanel()
    {
        txtEntryDate_Add.Text = "";
        ddlPOStatus_Add.SelectedIndex = 0;
        ddlPONo_Add.Items.Clear();
        ddlSupplier_Add.Items.Clear();
        txtDCNO.Text = "";
        lblSuppName.Text = "";
        lblsuppliercode.Text = "";
        txtDCDate.Value = "";
        txtInvoiceNo_Add.Text = "";
        txtInvoiceDT.Value = "";
        txtInvoiceValue_Add.Text = "";

        //
        ddlLogisticType_Add.SelectedIndex = 0;
        txtLogisticDetails_Add.Text = "";
        txtPODNo_Add0.Text = "";
        txtVechicleNo_Add.Text = "";

        txtTotalItems.Text = "";
        txtTotalQuantity.Text = "";
        txtTotalValue.Text = "";

        //ddlTransferFR_SR.SelectedIndex = 0;
        //ddlDivisionFR_SR.SelectedIndex = 0;
        //ddlgodownFR_SR.SelectedIndex = 0;
        //ddlFunctionFR_SR.SelectedIndex = 0;
        //ddlCenterFR_SR.SelectedIndex = 0;


        txtEntryDate_Add.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
    }
    private void ClearUpdatePanel()
    {
        ddlTransferFR_SR.SelectedIndex = 0;
        ddlDivisionFR_SR.SelectedIndex = 0;
        ddlgodownFR_SR.Items.Clear();
        ddlFunctionFR_SR.Items.Clear();
        ddlCenterFR_SR.Items.Clear();
        ddlbudgetDivision.SelectedIndex = 0;
        //ddlPOStatus_Add.SelectedIndex = 0;
        //ddlPONo_Add.SelectedIndex = 0;
        txtDCNO.Text = "";
        txtDCDate.Value = "";
        txtInvoiceNo_Add.Text = "";
        txtInvoiceDT.Value = "";
        txtInvoiceValue_Add.Text = "";


    }

    private void ClearAuthPanel()
    {
        txtEntryDate_Auth.Text = "";
        ddlpostatus_Auth.SelectedIndex = 0;
        ddlpoNo_Auth.Items.Clear();
        ddlSupplier_Auth.Items.Clear();
        txtDCNO_Auth.Text = "";
        lblSupplier_Auth.Text = "";
        txtDCDate_Auth.Text = "";
        txtInvoice_No_Auth.Text = "";
        txtInvoiceDate_Auth.Text = "";
        txtInvoiceValue_Auth.Text = "";

        //

        ddlLocation_Auth.SelectedIndex = 0;
        ddlDivision_Auth.SelectedIndex = 0;
        ddlGodown_Auth.SelectedIndex = 0;
        ddlFunction_Auth.SelectedIndex = 0;
        ddlCenter_Auth.SelectedIndex = 0;
        txtEntryDate_Auth.Text = "";

    }

    public void ClearItemAdd()
    {
        txtItemMatCode.Text = "";
        txtItemQty.Text = "";
        txtItemRate.Text = "0";
        lblCalValue.Text = "0";
        lblMateCode.Text = "";
        lblUnit.Text = "";
        lblItemName.Text = "";
        lblpo_OrderEntry.Text = "";

    }


    public void FillTotalDetails_Temp()
    {
        int Total_Item_Count = 0;
        double Total_Purchase_Amount = 0, Total_Quantity = 0;

        foreach (DataListItem item in dlQuestion.Items)
        {
            if (item.ItemType == ListItemType.Item | item.ItemType == ListItemType.AlternatingItem)
            {
                Label lblValue_DT = (Label)item.FindControl("lblValue_DT");
                Label lblChallanQty_DT = (Label)item.FindControl("lblChallanQty_DT");

                Total_Item_Count = Total_Item_Count + 1;

                Total_Purchase_Amount = Total_Purchase_Amount + Convert.ToDouble(lblValue_DT.Text.Trim());
                Total_Quantity = Total_Quantity + Convert.ToDouble(lblChallanQty_DT.Text.Trim());
            }
        }

        txtTotalItems.Text = Total_Item_Count.ToString();
        txtTotalQuantity.Text = Total_Quantity.ToString();
        txtTotalValue.Text = Total_Purchase_Amount.ToString();
    }


    private void ClearSearchPanel()
    {
        ddlSupplier_SR.SelectedIndex = 0;
        id_date_range_picker_2.Value = "";
        txtChallan_SR.Text = "";
        ddllocation_Search.SelectedIndex = 0;
        ddlGodown_Search.Items.Clear();
        ddldivision_Search.SelectedIndex = 0;
        ddlFunction_Search.Items.Clear();
        ddlCenter_Search.Items.Clear();

        txtChallan_SR.Text = "";


        tblgodown.Visible = false;
        tblFunction.Visible = false;
        tblDivision.Visible = false;
        tblCenter.Visible = false;
    }


    private void FillGrid(string fromdate, string todate, string supplier, string challan)
    {
        try
        {
            Clear_Error_Success_Box();

            ControlVisibility("Result");

            DataSet dsGrid = ProductController.Get_Fill_GRNDetails(3, fromdate, todate, supplier, challan);
            dlGridDisplay.DataSource = dsGrid;
            dlGridDisplay.DataBind();

            DataList1.DataSource = dsGrid;
            DataList1.DataBind();

            if (dsGrid != null)
            {
                if (dsGrid.Tables.Count != 0)
                {
                    if (dsGrid.Tables[0].Rows.Count != 0)
                    {
                        lbltotalcount.Text = (dsGrid.Tables[0].Rows.Count).ToString();
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
            BtnSaveUpdate.Visible = false;

            if (ddlPOStatus_Add.SelectedIndex == 0)
            {
                Show_Error_Success_Box("E", "Select Po Status");
                ddlPOStatus_Add.Focus();
                return;
            }

            if (ddlPOStatus_Add.SelectedValue == "Yes")
            {
                if (ddlPONo_Add.SelectedIndex == 0)
                {
                    Show_Error_Success_Box("E", "Select PO Number");
                    ddlPONo_Add.Focus();
                    return;
                }
                else if (ddlPONo_Add.SelectedIndex == -1)
                {
                    Show_Error_Success_Box("E", "Select PO Number");
                    ddlPONo_Add.Focus();
                    return;
                }

                if (lblSuppName.Text == "")
                {
                    Show_Error_Success_Box("E", "Supplier not found for this PO...!");
                    return;
                }
            }
            else if (ddlPOStatus_Add.SelectedValue == "No")
            {
                if (ddlSupplier_Add.SelectedIndex == 0)
                {
                    Show_Error_Success_Box("E", "Select Supplier");
                    ddlSupplier_Add.Focus();
                    return;
                }
            }



            if (txtDCNO.Text.Trim() == "")
            {
                Show_Error_Success_Box("E", "Enter Challan Number");
                txtDCNO.Focus();
                return;
            }

            if (txtDCDate.Value.Trim() == "")
            {
                Show_Error_Success_Box("E", "Enter DC Date");
                txtDCDate.Focus();
                return;
            }

            if (Convert.ToDateTime(ClsCommon.FormatDate(txtDCDate.Value)) > DateTime.Today)
            {
                Show_Error_Success_Box("E", "Challan date cannot be a future date");
                txtDCDate.Focus();
                return;
            }

            if (ddlbudgetDivision.SelectedIndex == 0 || ddlbudgetDivision.SelectedIndex == -1)
            {
                Show_Error_Success_Box("E", "Select Budget Division");
                ddlbudgetDivision.Focus();
                return;
            }

            string CreatedBy = null;
            Label lblHeader_User_Code = default(Label);
            lblHeader_User_Code = (Label)Master.FindControl("lblHeader_User_Code");
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

            if (ddlPOStatus_Add.SelectedValue == "Yes")
            {
                Supplier_Code = lblsuppliercode.Text.Trim();
                PONo = ddlPONo_Add.SelectedValue.ToString();
                PoFlag = 1;
            }
            else if (ddlPOStatus_Add.SelectedValue == "No")
            {
                Supplier_Code = ddlSupplier_Add.SelectedValue.ToString().Trim();
                PONo = "";
                PoFlag = 0;
            }

            int Total_Item_Count = 0;
            double Total_Purchase_Amount = 0, Total_Quantity = 0;

            foreach (DataListItem item in dlQuestion.Items)
            {
                if (item.ItemType == ListItemType.Item | item.ItemType == ListItemType.AlternatingItem)
                {
                    Label lblValue_DT = (Label)item.FindControl("lblValue_DT");
                    Label lblChallanQty_DT = (Label)item.FindControl("lblChallanQty_DT");

                    Total_Item_Count = Total_Item_Count + 1;

                    Total_Purchase_Amount = Total_Purchase_Amount + Convert.ToDouble(lblValue_DT.Text.Trim());
                    Total_Quantity = Total_Quantity + Convert.ToDouble(lblChallanQty_DT.Text.Trim());
                }
            }


            double invoiceval = 0;
            if (txtInvoiceValue_Add.Text == "")
            {
                invoiceval = 0;
            }
            else
            {
                invoiceval = Convert.ToDouble(txtInvoiceValue_Add.Text.Trim());
            }

            string Transfer_LocationCode = "";
            //

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

            string logistic1 = "", logistic2 = "";

            if (ddlLogisticType_Add.SelectedItem.ToString() == "Courier")
            {
                logistic1 = txtLogisticDetails_Add.Text.Trim();
                logistic2 = txtPODNo_Add0.Text.Trim();
            }

            if (ddlLogisticType_Add.SelectedItem.ToString() == "Transport")
            {
                logistic1 = txtLogisticDetails_Add.Text.Trim();
                logistic2 = txtVechicleNo_Add.Text.Trim();
            }

            if (ddlLogisticType_Add.SelectedItem.ToString() == "In Person")
            {
                logistic1 = txtLogisticDetails_Add.Text.Trim();
                logistic2 = "";
            }

            //
            string Error_Code = "";
            if (lblPkey.Text == "")
            {

                ResultId = ProductController.Insert_ChkGRNInward(7, Supplier_Code, txtDCNO.Text.Trim(), txtDCDate.Value.ToString().Trim());
                if (ResultId == "1")
                {
                    ResultId = ProductController.Insert_GRNInward(1, Supplier_Code, txtDCNO.Text.Trim(), txtDCDate.Value.ToString().Trim(), txtInvoiceNo_Add.Text.Trim(), Total_Item_Count, Total_Purchase_Amount, 1, PONo, PoFlag, CreatedBy, 0, txtInvoiceDT.Value.ToString().Trim(), invoiceval, ddlTransferFR_SR.SelectedValue.ToString().Trim(), Transfer_LocationCode, Total_Quantity, ddlLogisticType_Add.SelectedValue.ToString().Trim(), logistic1, logistic2, 0, ddlbudgetDivision.SelectedValue.ToString().Trim());
                }

                else
                {
                    lblPkey.Text = ResultId;

                    ResultId = ProductController.Update_GRNInward(6, Supplier_Code, txtDCNO.Text.Trim(), txtDCDate.Value.ToString().Trim(), txtInvoiceNo_Add.Text.Trim(), Total_Item_Count, Total_Purchase_Amount, 1, PONo, PoFlag, CreatedBy, lblPkey.Text.Trim(), txtDCDate.Value.ToString().Trim(), 1, txtInvoiceDT.Value.ToString().Trim(), invoiceval, ddlTransferFR_SR.SelectedValue.ToString().Trim(), Transfer_LocationCode, Total_Quantity, ddlLogisticType_Add.SelectedValue.ToString().Trim(), logistic1, logistic2, 0, ddlbudgetDivision.SelectedValue.ToString().Trim());

                    try
                    {
                        Error_Code = ResultId.Substring(0, 5);
                    }
                    catch { }
                }

            }
            else//Check update time
            {
                ResultId = ProductController.Insert_ChkGRNInward_Updatetime(30, lblPkey.Text, Supplier_Code, txtDCNO.Text.Trim(), txtDCDate.Value.ToString().Trim());
                if (ResultId == "1")
                {
                    ResultId = ProductController.Update_GRNInward(6, Supplier_Code, txtDCNO.Text.Trim(), txtDCDate.Value.ToString().Trim(), txtInvoiceNo_Add.Text.Trim(), Total_Item_Count, Total_Purchase_Amount, 1, PONo, PoFlag, CreatedBy, lblPkey.Text.Trim(), txtDCDate.Value.ToString().Trim(), 1, txtInvoiceDT.Value.ToString().Trim(), invoiceval, ddlTransferFR_SR.SelectedValue.ToString().Trim(), Transfer_LocationCode, Total_Quantity, ddlLogisticType_Add.SelectedValue.ToString().Trim(), logistic1, logistic2, 0, ddlbudgetDivision.SelectedValue.ToString().Trim());
                    try
                    {
                        Error_Code = ResultId.Substring(0, 5);
                    }
                    catch { }
                }
                else
                {
                    Clear_Error_Success_Box();
                    Msg_Error.Visible = true;
                    Msg_Success.Visible = false;
                    Show_Error_Success_Box("E", "Duplicate Challan Number");
                    return;
                }
            }
            if (ResultId == "-1")
            {
                Clear_Error_Success_Box();
                Msg_Error.Visible = true;
                Msg_Success.Visible = false;
                Show_Error_Success_Box("E", "Duplicate Challan Number");
                return;
            }
            else if (Error_Code == "Error")
            {
                Clear_Error_Success_Box();
                Msg_Error.Visible = true;
                Msg_Success.Visible = false;
                Show_Error_Success_Box("E", ResultId.Substring(5, ResultId.Length - 5));
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
                        Label lblbtnvisible = (Label)item.FindControl("lblbtnvisible");
                        Label lblIs_Authorised = (Label)item.FindControl("lblIs_Authorised");
                        Label lblpoentry = (Label)item.FindControl("lblpoentry");

                        icoun = icoun + 1;
                        string InwardEntry_Code = lblPkey.Text.Trim() + icoun.ToString();

                        ResultId1 = ProductController.Insert_GRNInward_Items(2, lblPkey.Text.Trim(), InwardEntry_Code, lblMaterialCode_DT.Text.Trim(), Convert.ToDouble(lblChallanQty_DT.Text.Trim()), Convert.ToDouble(lblRatePO_DT.Text.Trim()), Convert.ToDouble(lblValue_DT.Text.Trim()), 1, Convert.ToInt32(lblIs_Authorised.Text.Trim()), ddlbudgetDivision.SelectedValue.ToString(), lblpoentry.Text, CreatedBy);

                        if (lblbtnvisible.Text == "0")
                        {
                            ResultId1 = ProductController.Usp_Insert_InwardItemDetails(10, lblPkey.Text.Trim(), InwardEntry_Code, lblBarcode_DT.Text.Trim(), lblBarcode_DT.Text.Trim(), 1, "AS00000002", "AC00000001", ddlbudgetDivision.SelectedValue.ToString().Trim(), CreatedBy);
                        }

                    }
                }
                if (icoun == 0)
                {
                    ResultId1 = "1";
                }

            }

            if ((ResultId1 == "1") || ResultId1 == "-1")
            {
                Show_Error_Success_Box("S", "Record saved Successfully.");

                //

                string FromDate, ToDate, Supplier;
                if (id_date_range_picker_2.Value == "")
                {
                    FromDate = "";
                    ToDate = "";
                }
                else
                {
                    string DateRange = "";
                    DateRange = id_date_range_picker_2.Value;

                    FromDate = DateRange.Substring(0, 10);
                    ToDate = (DateRange.Length > 9) ? DateRange.Substring(DateRange.Length - 10, 10) : DateRange;
                }

                if (ddlSupplier_SR.SelectedIndex == 0 || ddlSupplier_SR.SelectedIndex == -1)
                {
                    Supplier = "";
                }
                else
                {
                    Supplier = ddlSupplier_SR.SelectedValue.ToString().Trim();
                }


                FillGrid(FromDate, ToDate, Supplier, txtChallan_SR.Text.Trim());
                Show_Error_Success_Box("S", "Record saved Successfully.");
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
            lblPkey.Text = "";
            ControlVisibility("Add");
            ClearAddPanel();
            ClearUpdatePanel();
            ClearItemAdd();
            ddlTransferFR_SR.Visible = true;

            ddlDivisionFR_SR.Enabled = true;
            tblFr_Godown.Visible = false;
            tblFr_Function.Visible = false;
            tblFr_Division.Visible = false;
            tblFr_Center.Visible = false;
            ddlCenterFR_SR.Enabled = true;
            ddlFunctionFR_SR.Enabled = true;
            ddlPOStatus_Add.Enabled = true;
            ddlgodownFR_SR.Enabled = true;
            txtLogisticDetails_Add.Enabled = true;
            ddlLogisticType_Add.Enabled = true;
            ddlSupplier_Add.Enabled = true;
            ddlbudgetDivision.Enabled = true;
            //txtEntryDate_Add.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
            BtnSaveUpdate.Visible = false;
            // ClearItemAdd();
            DataList4.DataSource = null;
            DataList4.DataBind();
            //ddlTransferFR_SR.Enabled = true;
            //ddlTransferFR_SR.SelectedIndex = 0;
            dlQuestion.DataSource = null;
            dlQuestion.DataBind();
            txtEntryDate_Add.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
            Clear_Error_Success_Box();
            visFalse();

            DivAddItem.Visible = true;

            GridMaterialList.Attributes.Remove("Class");
            GridMaterialList.Attributes.Add("Class", "span8");


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



    protected void chkAuthoriseAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox s = sender as CheckBox;

        //Set checked status of hidden check box to items in grid
        foreach (DataListItem dtlItem in dlItemListAuthorise.Items)
        {
            CheckBox chkitemck = (CheckBox)dtlItem.FindControl("chkCheck");
            //System.Web.UI.HtmlControls.HtmlInputCheckBox chkitemck = (System.Web.UI.HtmlControls.HtmlInputCheckBox)dtlItem.FindControl("chkDL_Select_Center");

            if (chkitemck.Visible == true)
            {
                chkitemck.Checked = s.Checked;
            }
        }




    }
    protected void BtnShowSearchPanel_Click(object sender, EventArgs e)
    {
        ControlVisibility("Search");
        Clear_Error_Success_Box();
    }

    protected void BtnCloseAdd_Click(object sender, EventArgs e)
    {
        BtnSearch_Click(this, e);
    }


    protected void BtnSaveAdd_Click(object sender, EventArgs e)
    {
        BtnSaveUpdate.Visible = false;
        SaveData();


    }

    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            Clear_Error_Success_Box();

            string FromDate, ToDate, Supplier;
            if (id_date_range_picker_2.Value == "")
            {
                FromDate = "";
                ToDate = "";
            }
            else
            {
                string DateRange = "";
                DateRange = id_date_range_picker_2.Value;

                FromDate = DateRange.Substring(0, 10);
                ToDate = (DateRange.Length > 9) ? DateRange.Substring(DateRange.Length - 10, 10) : DateRange;
            }

            if (ddlSupplier_SR.SelectedIndex == 0 || ddlSupplier_SR.SelectedIndex == -1)
            {
                Supplier = "";
            }
            else
            {
                Supplier = ddlSupplier_SR.SelectedValue.ToString().Trim();
            }

            string From_Location_Type_Code = "";
            if (ddllocation_Search.SelectedIndex == 0 || ddllocation_Search.SelectedIndex == -1)
            {
                From_Location_Type_Code = "";
            }
            else
            {
                From_Location_Type_Code = ddllocation_Search.SelectedValue.ToString().Trim();
            }

            string From_Location_Code = "";

            if (ddllocation_Search.SelectedItem.Text == "Godown")
            {
                From_Location_Code = ddlGodown_Search.SelectedValue;
            }
            else if (ddllocation_Search.SelectedItem.Text == "Function")
            {
                From_Location_Code = ddlFunction_Search.SelectedValue;
            }
            else if (ddllocation_Search.SelectedItem.Text == "Center")
            {
                From_Location_Code = ddlCenter_Search.SelectedValue;
            }


            FillGrid(FromDate, ToDate, Supplier, txtChallan_SR.Text.Trim());
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


    #endregion



    //protected void BtnSaveEdit_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        Clear_Error_Success_Box();

    //        if (ddlPOStatus_Add.SelectedIndex == 0)
    //        {
    //            Show_Error_Success_Box("E", "Select Po Status");
    //            ddlPOStatus_Add.Focus();
    //            return;
    //        }

    //        if (ddlPOStatus_Add.SelectedValue == "Yes")
    //        {
    //            if (ddlPONo_Add.SelectedIndex == 0)
    //            {
    //                Show_Error_Success_Box("E", "Select PO Number");
    //                ddlPONo_Add.Focus();
    //                return;
    //            }
    //            else if (ddlPONo_Add.SelectedIndex == -1)
    //            {
    //                Show_Error_Success_Box("E", "Select PO Number");
    //                ddlPONo_Add.Focus();
    //                return;
    //            }
    //        }
    //        else if (ddlPOStatus_Add.SelectedValue == "No")
    //        {
    //            if (ddlSupplier_Add.SelectedIndex == 0)
    //            {
    //                Show_Error_Success_Box("E", "Select Supplier");
    //                ddlSupplier_Add.Focus();
    //                return;
    //            }
    //        }



    //        if (txtDCNO.Text.Trim() == "")
    //        {
    //            Show_Error_Success_Box("E", "Enter DC Number");
    //            txtDCNO.Focus();
    //            return;
    //        }

    //        if (txtDCDate.Value.Trim() == "")
    //        {
    //            Show_Error_Success_Box("E", "Enter DC Date");
    //            txtDCDate.Focus();
    //            return;
    //        }

    //        if (Convert.ToDateTime(ClsCommon.FormatDate(txtDCDate.Value)) > DateTime.Today)
    //        {
    //            Show_Error_Success_Box("E", "Challan date cannot be a future date");
    //            txtDCDate.Focus();
    //            return;
    //        }


    //        Label lblHeader_User_Code = default(Label);
    //        lblHeader_User_Code = (Label)Master.FindControl("lblHeader_User_Code");

    //        string CreatedBy = null;
    //        CreatedBy = lblHeader_User_Code.Text;

    //        //int ActiveFlag = 0;
    //        //if (chkActiveFlag.Checked == true)
    //        //    ActiveFlag = 1;
    //        //else
    //        //    ActiveFlag = 0;

    //        string ResultId = "", ResultId1 = "";
    //        string Supplier_Code = "", PONo = "";
    //        int PoFlag = 0;

    //        if (ddlPOStatus_Add.SelectedValue == "Yes")
    //        {
    //            Supplier_Code = lblsuppliercode.Text.Trim();
    //            PONo = ddlPONo_Add.SelectedValue.ToString();
    //            PoFlag = 1;
    //        }
    //        else if (ddlPOStatus_Add.SelectedValue == "No")
    //        {
    //            Supplier_Code = ddlSupplier_Add.SelectedValue.ToString().Trim();
    //            PONo = "";
    //            PoFlag = 0;
    //        }

    //        int Total_Item_Count = 0;
    //        double Total_Purchase_Amount = 0;

    //        foreach (DataListItem item in dlQuestion.Items)
    //        {
    //            if (item.ItemType == ListItemType.Item | item.ItemType == ListItemType.AlternatingItem)
    //            {
    //                Label lblValue_DT = (Label)item.FindControl("lblValue_DT");

    //                Total_Item_Count = Total_Item_Count + 1;

    //                Total_Purchase_Amount = Total_Purchase_Amount + Convert.ToDouble(lblValue_DT.Text.Trim());

    //            }
    //        }

    //        double invoiceval = 0;
    //        if (txtInvoiceValue_Add.Text == "")
    //        {
    //            invoiceval = 0;
    //        }
    //        else
    //        {
    //            invoiceval = Convert.ToDouble(txtInvoiceValue_Add.Text.Trim());
    //        }

    //        ResultId = ProductController.Update_GRNInward(6, Supplier_Code, txtDCNO.Text.Trim(), txtDCDate.Value.ToString().Trim(), txtInvoiceNo_Add.Text.Trim(), Total_Item_Count, Total_Purchase_Amount, 1, PONo, PoFlag, CreatedBy, lblPkey.Text.Trim(), txtDCDate.Value.ToString().Trim(), 1, txtInvoiceDT.Value.ToString().Trim(), invoiceval, ddlTransferFR_SR.SelectedValue.ToString().Trim(), Transfer_LocationCode, Total_Quantity, ddlLogisticType_Add.SelectedValue.ToString().Trim(), logistic1, logistic2, 0);

    //        if (ResultId == "-1")
    //        {
    //            Clear_Error_Success_Box();
    //            Msg_Error.Visible = true;
    //            Msg_Success.Visible = false;
    //            Show_Error_Success_Box("E", "Duplicate Challan Number");
    //            return;
    //        }
    //        else
    //        {
    //            int icoun = 0;
    //            foreach (DataListItem item in dlQuestion.Items)
    //            {
    //                if (item.ItemType == ListItemType.Item | item.ItemType == ListItemType.AlternatingItem)
    //                {
    //                    Label lblMaterialCode_DT = (Label)item.FindControl("lblMaterialCode_DT");
    //                    Label lblMaterialName_DT = (Label)item.FindControl("lblMaterialName_DT");
    //                    Label lblPoQty_DT = (Label)item.FindControl("lblPoQty_DT");
    //                    Label lblChallanQty_DT = (Label)item.FindControl("lblChallanQty_DT");
    //                    Label lblRatePO_DT = (Label)item.FindControl("lblRatePO_DT");
    //                    Label lblValue_DT = (Label)item.FindControl("lblValue_DT");
    //                    Label lblBarcode_DT = (Label)item.FindControl("lblBarcode_DT");
    //                    Label lblSuppSerial = (Label)item.FindControl("lblSuppSerial");

    //                    icoun = icoun + 1;
    //                    string InwardEntry_Code = lblPkey.Text.Trim() + icoun.ToString();

    //                    ResultId1 = ProductController.Insert_GRNInward_Items(2, lblPkey.Text.Trim(), InwardEntry_Code, lblMaterialCode_DT.Text.Trim(), Convert.ToDouble(lblChallanQty_DT.Text.Trim()), Convert.ToDouble(lblRatePO_DT.Text.Trim()), Convert.ToDouble(lblValue_DT.Text.Trim()), 1);

    //                }
    //            }

    //        }

    //        if (ResultId1 == "1")
    //        {
    //            Show_Error_Success_Box("S", "Record Updated Successfully.");
    //            BtnSearch_Click(this, e);
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

    protected void btnUserMenuSave_Click(object sender, EventArgs e)
    {
        if (lblAssetesNoTypeID.Text == "ATN00000002")
        {
            lblasset_type.Text = "Manual Asset Number";
        }
        else if (lblAssetesNoTypeID.Text == "ATN00000003")
        {
            lblasset_type.Text = "System Asset Number";
        }

        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalDivCOnfirmationAset();", true);




    }
    protected void btnUserMenuClose_Click(object sender, EventArgs e)
    {
        ControlVisibility("Add");
        Clear_Error_Success_Box();
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
    protected void HLExport_Click(object sender, EventArgs e)
    {
        DataList1.Visible = true;

        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        string filenamexls1 = "GRN_" + DateTime.Now + ".xls";
        Response.AddHeader("Content-Disposition", "inline;filename=" + filenamexls1);
        HttpContext.Current.Response.Charset = "utf-8";
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");
        //sets font
        HttpContext.Current.Response.Write("<font style='font-size:10.0pt; font-family:Calibri;'>");
        HttpContext.Current.Response.Write("<BR><BR><BR>");
        HttpContext.Current.Response.Write("<Table border='1'  borderColor='#000000' cellSpacing='0' cellPadding='0' style='font-size:10.0pt; font-family:Calibri; text-align:center;'> <TR style='color: #fff; background: black;text-align:center;'><TD Colspan='8'>GRN Details</b></TD></TR>");
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
        try
        {
            if (ddlPOStatus_Add.SelectedValue == "Yes")
            {
                FillDDL_PONumber();
                PONOID.Visible = true;
                SuppID.Visible = false;
                //DivAddItem.Visible = true;
                tbl_poNo.Visible = false;
                tbl_poYes.Visible = true;

                lblsup.Visible = true;
                lblSuppName.Visible = true;
                //txtItemRate.Enabled = false;
                txtItemRate.ReadOnly = true;
                ClearItemAdd();
            }
            else if (ddlPOStatus_Add.SelectedValue == "No")
            {
                PONOID.Visible = false;
                SuppID.Visible = true;
                //DivAddItem.Visible = true;
                tbl_poNo.Visible = true;
                tbl_poYes.Visible = false;
                //txtItemRate.Enabled = true;
                txtItemRate.ReadOnly = false;
                lblsup.Visible = false;
                lblSuppName.Visible = false;
                FillDDL_Supplier();
                ddlSupplier_Add.Visible = true;
                ClearItemAdd();
            }
            else if (ddlPOStatus_Add.SelectedValue == "Select")
            {
                PONOID.Visible = false;
                SuppID.Visible = false;
                //DivAddItem.Visible = false;
                lblsup.Visible = false;
                lblSuppName.Visible = false;
                ClearItemAdd();
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

    protected void btnSaveItem_ServerClick(object sender, EventArgs e)
    {
        try
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

            if (txtItemRate.Text.Trim() == "")
            {
                Show_Error_Success_Box("E", "Enter Item Rate");
                txtItemRate.Focus();
                return;
            }

            if (ddlPOStatus_Add.SelectedValue == "Yes")
            {
                if (ddlPONo_Add.SelectedIndex == 0)
                {
                    Show_Error_Success_Box("E", "Select PO Number");
                    ddlPONo_Add.Focus();
                    dlQuestion.DataSource = null;
                    dlQuestion.DataBind();
                    return;
                }
                else if (ddlPONo_Add.SelectedIndex == -1)
                {
                    Show_Error_Success_Box("E", "Select PO Number");
                    ddlPONo_Add.Focus();
                    dlQuestion.DataSource = null;
                    dlQuestion.DataBind();
                    return;
                }
            }
            else if (ddlPOStatus_Add.SelectedValue == "No")
            {
                if (ddlSupplier_Add.SelectedIndex == 0)
                {
                    Show_Error_Success_Box("E", "Select Supplier");
                    ddlSupplier_Add.Focus();
                    dlQuestion.DataSource = null;
                    dlQuestion.DataBind();
                    return;
                }
            }

            if (txtDCNO.Text.Trim() == "")
            {
                Show_Error_Success_Box("E", "Enter DC Number");
                txtDCNO.Focus();
                return;
            }

            if (txtDCDate.Value.Trim() == "")
            {
                Show_Error_Success_Box("E", "Enter DC Date");
                txtDCDate.Focus();
                return;
            }

            if (Convert.ToDateTime(ClsCommon.FormatDate(txtDCDate.Value)) > DateTime.Today)
            {
                Show_Error_Success_Box("E", "Challan date cannot be a future date");
                txtDCDate.Focus();
                return;
            }

            if (ddlTransferFR_SR.SelectedIndex == 0 || ddlTransferFR_SR.SelectedIndex == -1)
            {
                Show_Error_Success_Box("E", "Select Location Type");
                ddlTransferFR_SR.Focus();
                return;
            }


            if (ddlTransferFR_SR.SelectedItem.ToString() == "Godown")
            {
                if (ddlgodownFR_SR.SelectedIndex == 0 || ddlgodownFR_SR.SelectedIndex == -1)
                {
                    Show_Error_Success_Box("E", "Select Godown");
                    ddlgodownFR_SR.Focus();
                    return;
                }
            }
            else if (ddlTransferFR_SR.SelectedItem.ToString() == "Function")
            {
                if (ddlFunctionFR_SR.SelectedIndex == 0 || ddlFunctionFR_SR.SelectedIndex == -1)
                {
                    Show_Error_Success_Box("E", "Select Function");
                    ddlFunctionFR_SR.Focus();
                    return;
                }
            }
            else if (ddlTransferFR_SR.SelectedItem.ToString() == "Center")
            {
                if (ddlDivisionFR_SR.SelectedIndex == 0 || ddlDivisionFR_SR.SelectedIndex == -1)
                {
                    Show_Error_Success_Box("E", "Select Division");
                    ddlDivisionFR_SR.Focus();
                    return;
                }

                else if (ddlCenterFR_SR.SelectedIndex == 0 || ddlCenterFR_SR.SelectedIndex == -1)
                {
                    Show_Error_Success_Box("E", "Select Center");
                    ddlCenterFR_SR.Focus();
                    return;
                }

            }

            if (ddlbudgetDivision.SelectedIndex == 0 || ddlbudgetDivision.SelectedIndex == -1)
            {
                Show_Error_Success_Box("E", "Select Budget Division");
                ddlbudgetDivision.Focus();
                return;
            }
            DataTable dtCorrectEntry = new DataTable();
            DataRow NewRow = null;

            var _with1 = dtCorrectEntry;
            _with1.Columns.Add("lblMaterialCode_DT");
            _with1.Columns.Add("lblMaterialName_DT");
            _with1.Columns.Add("lblPoQty_DT");
            _with1.Columns.Add("lblChallanQty_DT");
            _with1.Columns.Add("lblRatePO_DT");
            _with1.Columns.Add("lblValue_DT");
            _with1.Columns.Add("lblBarcode_DT");
            _with1.Columns.Add("InwardEntry_Code");
            _with1.Columns.Add("AssetNoTypeBtn");
            _with1.Columns.Add("lblIs_Authorised");
            _with1.Columns.Add("lblpoentry");


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
                    Label InwardEntry_Code = (Label)item.FindControl("InwardEntry_Code");
                    Label lblpoentry = (Label)item.FindControl("lblpoentry");
                    Label lblbtnvisible = (Label)item.FindControl("lblbtnvisible");
                    Label lblIs_Authorised = (Label)item.FindControl("lblIs_Authorised");

                    NewRow = dtCorrectEntry.NewRow();
                    NewRow["lblMaterialCode_DT"] = lblMaterialCode_DT.Text.Trim();
                    NewRow["lblMaterialName_DT"] = lblMaterialName_DT.Text.Trim();
                    NewRow["lblPoQty_DT"] = lblPoQty_DT.Text.Trim();
                    NewRow["lblChallanQty_DT"] = lblChallanQty_DT.Text.Trim();
                    NewRow["lblRatePO_DT"] = lblRatePO_DT.Text.Trim();
                    NewRow["lblValue_DT"] = lblValue_DT.Text.Trim();
                    NewRow["lblBarcode_DT"] = lblBarcode_DT.Text.Trim();
                    NewRow["InwardEntry_Code"] = InwardEntry_Code.Text.Trim();
                    NewRow["AssetNoTypeBtn"] = lblbtnvisible.Text.Trim();
                    NewRow["lblIs_Authorised"] = lblIs_Authorised.Text.Trim();
                    NewRow["lblpoentry"] = lblpoentry.Text.Trim();
                    dtCorrectEntry.Rows.Add(NewRow);
                    lblInwardEbtryCode_BR.Text = InwardEntry_Code.Text;

                }
            }

            DataSet dsSupplier = ProductController.GetItem_ByAll(lblMateCode.Text.Trim(), 2);

            if (dsSupplier.Tables[0].Rows.Count > 0)
            {
                if (dsSupplier.Tables[0].Rows.Count == 1)
                {
                    // check duplicate material 
                    DataRow[] DupliRollNoRow = null;
                    DupliRollNoRow = dtCorrectEntry.Select("lblMaterialCode_DT ='" + lblMateCode.Text.Trim() + "'");
                    //if (DupliRollNoRow.Length > 0)
                    //{
                    //    Show_Error_Success_Box("E", "Material Code Already Exist");
                    //    ClearItemAdd();
                    //    return;

                    //}
                    //else
                    {
                        NewRow = dtCorrectEntry.NewRow();
                        NewRow["lblMaterialCode_DT"] = lblMateCode.Text.Trim();
                        NewRow["lblMaterialName_DT"] = lblItemName.Text.Trim();
                        NewRow["lblPoQty_DT"] = lblItemPOQty.Text;
                        NewRow["lblChallanQty_DT"] = txtItemQty.Text.Trim();
                        NewRow["lblRatePO_DT"] = txtItemRate.Text.Trim();
                        NewRow["lblValue_DT"] = lblCalValue.Text.Trim();
                        NewRow["lblpoentry"] = lblpo_OrderEntry.Text.Trim();
                        NewRow["lblBarcode_DT"] = dsSupplier.Tables[0].Rows[0]["Item_EAN_No"].ToString();
                        NewRow["lblIs_Authorised"] = "0";

                        if (lblAssetNoType.Text == "ATN00000001")
                        {
                            NewRow["AssetNoTypeBtn"] = "0";
                        }
                        else if (lblAssetNoType.Text == "ATN00000002" || lblAssetNoType.Text == "ATN00000003")
                        {
                            NewRow["AssetNoTypeBtn"] = "1";
                        }

                        dtCorrectEntry.Rows.Add(NewRow);


                    }
                 
                }
            }

            string ResultId = "";

            if (ddlPOStatus_Add.SelectedValue == "Yes")
            {
                ResultId = ProductController.Check_POQty_GRN(26, ddlPONo_Add.SelectedValue.ToString().Trim(), lblMateCode.Text.Trim(), lblcenter.Text, lbldivision.Text, lblpo_OrderEntry.Text.Trim());

                if (Convert.ToInt32(ResultId) < Convert.ToInt32(txtItemQty.Text.Trim()))
                {
                    Msg_Error.Visible = true;
                    Msg_Success.Visible = false;
                    lblerror.Text = "Quantity doesn't match with PO Quantity.";
                    UpdatePanelMsgBox.Update();
                    return;
                }
                else
                {

                    dlQuestion.DataSource = dtCorrectEntry;
                    dlQuestion.DataBind();

                    TempSaveData();
                    ClearItemAdd();
                    FillTotalDetails_Temp();
                    FillDDL_POItems();
                  

                }


            }
            else if (ddlPOStatus_Add.SelectedValue == "No")
            {
                dlQuestion.DataSource = dtCorrectEntry;
                dlQuestion.DataBind();
                TempSaveData();
                ClearItemAdd();
                FillTotalDetails_Temp();
                FillDDL_POItems();

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
                    lblAssetNoType.Text = dsSupplier.Tables[0].Rows[0]["AssetsNo_Type_Id"].ToString();
                }
                else if (dsSupplier.Tables[0].Rows.Count >= 1)
                {
                    DataList3.DataSource = dsSupplier;
                    DataList3.DataBind();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalDivOverride();", true);
                    //UpdatePanel1.Update();
                }

            }
            else
            {
                Show_Error_Success_Box("E", "Item Not Found");
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

        if (double.TryParse(txtItemRate.Text.Trim(), out Rate))
        {
            Rate1 = Convert.ToInt32(txtItemRate.Text.Trim());

        }
        else
        {
            Show_Error_Success_Box("E", "Enter Numeric only");
            txtItemQty.Focus();
            return;
        }

        int CalAns = Qty1 * Rate1;

        lblCalValue.Text = CalAns.ToString();

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
                lblAssetNoType.Text = dsSupplier.Tables[0].Rows[0]["AssetsNo_Type_Id"].ToString();
            }

            //tr1.Visible = true;
            //tr2.Visible = true;
        }

    }
    protected void dlGridDisplay_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "comEdit")
            {

                lblPkey.Text = "";
                lblInwardIsAuthorised.Text = "";
                ControlVisibility("Add");
                //BtnSaveEdit.Visible = true;
                dlQuestion.Visible = true;
                BtnSaveAdd.Visible = true;
                BtnSaveUpdate.Visible = false;
                DataList4.Visible = false;
                ClearAddPanel();
                ClearItemAdd();
                dlQuestion.DataSource = null;
                dlQuestion.DataBind();
                FillDDL_Supplier();
                Clear_Error_Success_Box();
                string poflag;
                UploadStatusLabel1.Visible = false;

                HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                string UserID = cookie.Values["UserID"];
                string UserName = cookie.Values["UserName"];


                lblPkey.Text = e.CommandArgument.ToString();
                string ErrorFlag = "";

                ErrorFlag = ProductController.Get_Edit_GRNDetails_UserAuth(4, lblPkey.Text.Trim(), UserID);

                if (ErrorFlag == "0")
                {
                    BtnSearch_Click(this, e);
                    Show_Error_Success_Box("E", "You are not Authorised to view this GRN (Division is not assigned to you)");
                    return;
                }
                else if (ErrorFlag == "1")
                {
                    DataSet ds = ProductController.Get_Edit_GRNDetails(28, lblPkey.Text.Trim());
                    lblGRN_No.Text = ds.Tables[0].Rows[0]["Inward_Code"].ToString();
                    lblGRN_No.Visible = false;
                    lblInwardIsAuthorised.Text = ds.Tables[0].Rows[0]["Is_Authorised"].ToString();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtEntryDate_Add.Text = ds.Tables[0].Rows[0]["Inward_date"].ToString();
                        poflag = ds.Tables[0].Rows[0]["PoFlag"].ToString();
                        if (poflag == "0")
                        {
                            ddlPOStatus_Add.SelectedIndex = 2;
                            PONOID.Visible = false;
                            tbl_poNo.Visible = true;
                            tbl_poYes.Visible = false;
                            SuppID.Visible = true;
                            //DivAddItem.Visible = true;
                            lblsup.Visible = false;
                            lblSuppName.Visible = false;
                            //FillDDL_Supplier();
                            ClearItemAdd();
                            ddlSupplier_Add.SelectedValue = ds.Tables[0].Rows[0]["Vendor_Code"].ToString();
                            ddlSupplier_Add.Visible = true;
                        }
                        else if (poflag == "1")
                        {
                            PONOID.Visible = true;
                            SuppID.Visible = false;
                            tbl_poNo.Visible = false;
                            tbl_poYes.Visible = true;

                            ddlPOStatus_Add.SelectedIndex = 1;
                            ddlSupplier_Add.Visible = false;
                            //DivAddItem.Visible = true;
                            FillDDL_PONumber();
                            ddlPONo_Add.SelectedValue = ds.Tables[0].Rows[0]["PoNo"].ToString();
                            FillDDL_POItems();
                            lblSuppName.Text = ds.Tables[0].Rows[0]["Vendor_Name"].ToString();
                            lblsuppliercode.Text = ds.Tables[0].Rows[0]["Vendor_Code"].ToString();

                            lblsup.Visible = true;
                            lblSuppName.Visible = true;
                        }

                        ddlbudgetDivision.SelectedValue = ds.Tables[0].Rows[0]["Budget_Division"].ToString();
                        txtDCNO.Text = ds.Tables[0].Rows[0]["Challan_No"].ToString();
                        txtDCDate.Value = ds.Tables[0].Rows[0]["Challan_Date"].ToString();
                        txtInvoiceNo_Add.Text = ds.Tables[0].Rows[0]["Invoice_No"].ToString();
                        txtInvoiceDT.Value = ds.Tables[0].Rows[0]["invoice_date"].ToString();
                        txtInvoiceValue_Add.Text = ds.Tables[0].Rows[0]["invoice_value"].ToString();

                        txtTotalItems.Text = ds.Tables[0].Rows[0]["total_item_count"].ToString();
                        txtTotalQuantity.Text = ds.Tables[0].Rows[0]["total_quantity"].ToString();
                        txtTotalValue.Text = ds.Tables[0].Rows[0]["total_purchase_Amount"].ToString();

                        ddlLogisticType_Add.SelectedValue = ds.Tables[0].Rows[0]["LogisticType_Code"].ToString();
                        txtLogisticDetails_Add.Text = ds.Tables[0].Rows[0]["LogisticDetails1"].ToString();

                        txtPODNo_Add0.Text = ds.Tables[0].Rows[0]["LogisticDetails2"].ToString();
                        txtVechicleNo_Add.Text = ds.Tables[0].Rows[0]["LogisticDetails2"].ToString();

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

                        ddlTransferFR_SR.SelectedValue = ds.Tables[0].Rows[0]["Transfer_Location_Type_Code"].ToString();

                        if (ddlTransferFR_SR.SelectedItem.ToString().Trim() == "Godown")
                        {
                            tblFr_Godown.Visible = true;
                            tblFr_Function.Visible = false;
                            tblFr_Division.Visible = false;
                            tblFr_Center.Visible = false;
                            FillDDL_Godown();
                            ddlgodownFR_SR.SelectedValue = ds.Tables[0].Rows[0]["Transfer_Location_Code"].ToString();
                        }
                        else if (ddlTransferFR_SR.SelectedItem.ToString().Trim() == "Function")
                        {
                            tblFr_Function.Visible = true;
                            tblFr_Godown.Visible = false;
                            tblFr_Division.Visible = false;
                            tblFr_Center.Visible = false;
                            FillDDL_Function();
                            ddlFunctionFR_SR.SelectedValue = ds.Tables[0].Rows[0]["Transfer_Location_Code"].ToString();
                        }
                        else if (ddlTransferFR_SR.SelectedItem.ToString().Trim() == "Center")
                        {
                            tblFr_Division.Visible = true;
                            tblFr_Center.Visible = true;
                            tblFr_Function.Visible = false;
                            tblFr_Godown.Visible = false;

                            ddlDivisionFR_SR.SelectedValue = ds.Tables[0].Rows[0]["Source_Division_Code"].ToString();
                            ddlCenterFR_SR.Items.Clear();
                            FillDDL_FRSearch_Centre();

                            ddlCenterFR_SR.SelectedValue = ds.Tables[0].Rows[0]["Transfer_Location_Code"].ToString();

                        }
                        else if (ddlTransferFR_SR.SelectedIndex == 0 || ddlTransferFR_SR.SelectedIndex == -1)
                        {
                            tblFr_Godown.Visible = false;
                            tblFr_Function.Visible = false;
                            tblFr_Division.Visible = false;
                            tblFr_Center.Visible = false;
                        }



                        DataSet dsItems = ProductController.Get_Edit_GRNDetails(19, lblPkey.Text.Trim());
                        if (dsItems.Tables[0].Rows.Count > 0)
                        {
                            dlQuestion.DataSource = dsItems;
                            dlQuestion.DataBind();
                        }
                    }


                    if (lblInwardIsAuthorised.Text == "0")
                    {
                        BtnSaveAdd.Visible = true;
                        DivAddItem.Visible = true;

                        GridMaterialList.Attributes.Remove("Class");
                        GridMaterialList.Attributes.Add("Class", "span8");
                        //DivAddItem.Attributes.Remove("Class");
                        //DivAddItem.Attributes.Add("Class", "span4");
                    }
                    else if (lblInwardIsAuthorised.Text == "1")
                    {
                        BtnSaveAdd.Visible = false;
                        DivAddItem.Visible = false;
                        GridMaterialList.Attributes.Remove("Class");
                        GridMaterialList.Attributes.Add("Class", "span8");

                    }
                }
                string[] Files = Directory.GetFiles(Server.MapPath("~/Uploads/"));
                string GetThis = lblGRN_No.Text;


                // string fileExtension = Path.GetExtension(FileUpload1.PostedFile.FileName);

                foreach (string file in Files)
                {
                    if (file.ToUpper().Contains(GetThis.ToUpper()))
                    {
                        File.OpenText(file);
                        string file1 = file;

                        // Split string on spaces.
                        // ... This will separate all the words.
                        string[] words = file1.Split('\\');
                        foreach (string word in words)
                        {
                            Console.WriteLine(word);

                        }
                        //get only grn_no with extension
                        string inwardno = words[3];
                        lblfilename.Visible = true;
                        lblfilename.Text = inwardno;

                        return;
                    }

                }



            }
            else if (e.CommandName == "comAuthorise")
            {
                lblPkey.Text = "";
                ControlVisibility("Authorise");
                Clear_Error_Success_Box();
                //ClearAuthPanel();

                dlItemListAuthorise.DataSource = null;
                dlItemListAuthorise.DataBind();

                FillDDL_Supplier();
                Clear_Error_Success_Box();
                string poflag;
                lblPkey.Text = e.CommandArgument.ToString();
                string pky = e.CommandArgument.ToString();
                DataSet ds = ProductController.Get_Edit_GRNDetails(28, e.CommandArgument.ToString());

                lblAuthorised.Text = ds.Tables[0].Rows[0]["Is_Authorised"].ToString();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtEntryDate_Auth.Text = ds.Tables[0].Rows[0]["Inward_date"].ToString();
                    poflag = ds.Tables[0].Rows[0]["PoFlag"].ToString();
                    if (poflag == "0")
                    {
                        ddlpostatus_Auth.SelectedIndex = 2;
                        PONOID_Auth.Visible = false;

                        SuppID_Auth.Visible = true;
                        lblSup_Auth.Visible = false;
                        lblSupplier_Auth.Visible = false;

                        ddlSupplier_Auth.SelectedValue = ds.Tables[0].Rows[0]["Vendor_Code"].ToString();
                        ddlSupplier_Auth.Visible = true;
                    }
                    else if (poflag == "1")
                    {
                        PONOID_Auth.Visible = true;
                        SuppID_Auth.Visible = false;

                        ddlpostatus_Auth.SelectedIndex = 1;
                        ddlSupplier_Auth.Visible = false;
                        //DivAddItem.Visible = true;
                        FillDDL_PONumber();
                        ddlpoNo_Auth.SelectedValue = ds.Tables[0].Rows[0]["PoNo"].ToString();

                        lblSupplier_Auth.Text = ds.Tables[0].Rows[0]["Vendor_Name"].ToString();
                        Label43.Text = ds.Tables[0].Rows[0]["Vendor_Code"].ToString();
                        lblSup_Auth.Visible = true;
                        lblSupplier_Auth.Visible = true;
                    }

                    txtDCNO_Auth.Text = ds.Tables[0].Rows[0]["Challan_No"].ToString();
                    txtDCDate_Auth.Text = ds.Tables[0].Rows[0]["Challan_Date"].ToString();
                    txtInvoice_No_Auth.Text = ds.Tables[0].Rows[0]["Invoice_No"].ToString();
                    txtInvoiceDate_Auth.Text = ds.Tables[0].Rows[0]["invoice_date"].ToString();
                    txtInvoiceValue_Auth.Text = ds.Tables[0].Rows[0]["invoice_value"].ToString();

                    ddlLocation_Auth.SelectedValue = ds.Tables[0].Rows[0]["Transfer_Location_Type_Code"].ToString();

                    if (ddlLocation_Auth.SelectedItem.ToString().Trim() == "Godown")
                    {
                        tblFr_Godown_Auth.Visible = true;
                        tblFr_Function_Auth.Visible = false;
                        tblFr_Division_Auth.Visible = false;
                        tblFr_Center_Auth.Visible = false;
                        FillDDL_Godown();
                        ddlGodown_Auth.SelectedValue = ds.Tables[0].Rows[0]["Transfer_Location_Code"].ToString();
                    }
                    else if (ddlLocation_Auth.SelectedItem.ToString().Trim() == "Function")
                    {
                        tblFr_Function_Auth.Visible = true;
                        tblFr_Godown_Auth.Visible = false;
                        tblFr_Division_Auth.Visible = false;
                        tblFr_Center_Auth.Visible = false;
                        FillDDL_Function();
                        ddlFunction_Auth.SelectedValue = ds.Tables[0].Rows[0]["Transfer_Location_Code"].ToString();
                    }
                    else if (ddlLocation_Auth.SelectedItem.ToString().Trim() == "Center")
                    {
                        tblFr_Division_Auth.Visible = true;
                        tblFr_Center_Auth.Visible = true;
                        tblFr_Function_Auth.Visible = false;
                        tblFr_Godown_Auth.Visible = false;

                        ddlDivision_Auth.SelectedValue = ds.Tables[0].Rows[0]["Source_Division_Code"].ToString();
                        ddlCenter_Auth.Items.Clear();
                        FillDDL_FRAuth_Centre();

                        ddlCenter_Auth.SelectedValue = ds.Tables[0].Rows[0]["Transfer_Location_Code"].ToString();

                    }
                    else if (ddlLocation_Auth.SelectedIndex == 0 || ddlLocation_Auth.SelectedIndex == -1)
                    {
                        tblFr_Godown_Auth.Visible = false;
                        tblFr_Function_Auth.Visible = false;
                        tblFr_Division_Auth.Visible = false;
                        tblFr_Center_Auth.Visible = false;
                    }


                    DataSet dsItems = ProductController.Get_Edit_GRNDetails(5, pky);
                    if (dsItems.Tables[0].Rows.Count > 0)
                    {
                        dlItemListAuthorise.DataSource = dsItems;
                        dlItemListAuthorise.DataBind();
                    }
                }

            }

            else if (e.CommandName == "comUpdate")
            {

                lblPkey.Text = "";
                lblInwardIsAuthorised.Text = "";
                ControlVisibility("Add");
                BtnSaveAdd.Visible = false;
                BtnSaveUpdate.Visible = true;
                DataList4.Visible = true;

                ddlbudgetDivision.Enabled = false;
                ddlCenterFR_SR.Enabled = false;
                ddlFunctionFR_SR.Enabled = false;
                ddlDivisionFR_SR.Enabled = false;
                ddlgodownFR_SR.Enabled = false;
                ddlTransferFR_SR.Enabled = false;
                ddlSupplier_Add.Enabled = false;
                ddlLogisticType_Add.Enabled = false;
                txtLogisticDetails_Add.Enabled = false;
                ddlPOStatus_Add.Enabled = false;
                dlQuestion.Visible = false;
                DivAddItem.Visible = false;
                ClearAddPanel();
                ClearItemAdd();
                DataList4.DataSource = null;
                DataList4.DataBind();
                FillDDL_Supplier();
                Clear_Error_Success_Box();
                string poflag;

                HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                string UserID = cookie.Values["UserID"];
                string UserName = cookie.Values["UserName"];


                lblPkey.Text = e.CommandArgument.ToString();
                string ErrorFlag = "";

                ErrorFlag = ProductController.Get_Edit_GRNDetails_UserAuth(4, lblPkey.Text.Trim(), UserID);

                if (ErrorFlag == "0")
                {
                    BtnSearch_Click(this, e);
                    Show_Error_Success_Box("E", "You are not Authorised to view this GRN (Division is not assigned to you)");
                    return;
                }
                else if (ErrorFlag == "1")
                {
                    DataSet ds = ProductController.Get_Edit_GRNDetails(28, lblPkey.Text.Trim());

                    lblInwardIsAuthorised.Text = ds.Tables[0].Rows[0]["Is_Authorised"].ToString();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtEntryDate_Add.Text = ds.Tables[0].Rows[0]["Inward_date"].ToString();
                        poflag = ds.Tables[0].Rows[0]["PoFlag"].ToString();
                        if (poflag == "0")
                        {
                            ddlPOStatus_Add.SelectedIndex = 2;
                            PONOID.Visible = false;
                            tbl_poNo.Visible = true;
                            tbl_poYes.Visible = false;
                            BtnSaveUpdate.Visible = false;
                            SuppID.Visible = true;
                            //DivAddItem.Visible = true;
                            lblsup.Visible = false;
                            lblSuppName.Visible = false;
                            //FillDDL_Supplier();
                            ClearItemAdd();
                            ddlSupplier_Add.SelectedValue = ds.Tables[0].Rows[0]["Vendor_Code"].ToString();
                            ddlSupplier_Add.Visible = true;
                        }
                        else if (poflag == "1")
                        {
                            PONOID.Visible = true;
                            SuppID.Visible = false;
                            tbl_poNo.Visible = false;
                            tbl_poYes.Visible = true;

                            ddlPOStatus_Add.SelectedIndex = 1;
                            ddlSupplier_Add.Visible = false;
                            //DivAddItem.Visible = true;
                            FillDDL_PONumber();
                            ddlPONo_Add.SelectedValue = ds.Tables[0].Rows[0]["PoNo"].ToString();
                            FillDDL_POItems();
                            lblSuppName.Text = ds.Tables[0].Rows[0]["Vendor_Name"].ToString();
                            lblsuppliercode.Text = ds.Tables[0].Rows[0]["Vendor_Code"].ToString();
                            lblsup.Visible = true;
                            lblSuppName.Visible = true;
                        }


                        ddlbudgetDivision.SelectedValue = ds.Tables[0].Rows[0]["Budget_Division"].ToString();
                        txtDCNO.Text = ds.Tables[0].Rows[0]["Challan_No"].ToString();
                        txtDCDate.Value = ds.Tables[0].Rows[0]["Challan_Date"].ToString();
                        txtInvoiceNo_Add.Text = ds.Tables[0].Rows[0]["Invoice_No"].ToString();
                        txtInvoiceDT.Value = ds.Tables[0].Rows[0]["invoice_date"].ToString();
                        txtInvoiceValue_Add.Text = ds.Tables[0].Rows[0]["invoice_value"].ToString();

                        txtTotalItems.Text = ds.Tables[0].Rows[0]["total_item_count"].ToString();
                        txtTotalQuantity.Text = ds.Tables[0].Rows[0]["total_quantity"].ToString();
                        txtTotalValue.Text = ds.Tables[0].Rows[0]["total_purchase_Amount"].ToString();

                        ddlLogisticType_Add.SelectedValue = ds.Tables[0].Rows[0]["LogisticType_Code"].ToString();
                        txtLogisticDetails_Add.Text = ds.Tables[0].Rows[0]["LogisticDetails1"].ToString();

                        txtPODNo_Add0.Text = ds.Tables[0].Rows[0]["LogisticDetails2"].ToString();
                        txtVechicleNo_Add.Text = ds.Tables[0].Rows[0]["LogisticDetails2"].ToString();

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

                        ddlTransferFR_SR.SelectedValue = ds.Tables[0].Rows[0]["Transfer_Location_Type_Code"].ToString();

                        if (ddlTransferFR_SR.SelectedItem.ToString().Trim() == "Godown")
                        {
                            tblFr_Godown.Visible = true;
                            tblFr_Function.Visible = false;
                            tblFr_Division.Visible = false;
                            tblFr_Center.Visible = false;
                            FillDDL_Godown();
                            ddlgodownFR_SR.SelectedValue = ds.Tables[0].Rows[0]["Transfer_Location_Code"].ToString();
                        }
                        else if (ddlTransferFR_SR.SelectedItem.ToString().Trim() == "Function")
                        {
                            tblFr_Function.Visible = true;
                            tblFr_Godown.Visible = false;
                            tblFr_Division.Visible = false;
                            tblFr_Center.Visible = false;
                            FillDDL_Function();
                            ddlFunctionFR_SR.SelectedValue = ds.Tables[0].Rows[0]["Transfer_Location_Code"].ToString();
                        }
                        else if (ddlTransferFR_SR.SelectedItem.ToString().Trim() == "Center")
                        {
                            tblFr_Division.Visible = true;
                            tblFr_Center.Visible = true;
                            tblFr_Function.Visible = false;
                            tblFr_Godown.Visible = false;

                            ddlDivisionFR_SR.SelectedValue = ds.Tables[0].Rows[0]["Source_Division_Code"].ToString();
                            ddlCenterFR_SR.Items.Clear();
                            FillDDL_FRSearch_Centre();

                            ddlCenterFR_SR.SelectedValue = ds.Tables[0].Rows[0]["Transfer_Location_Code"].ToString();

                        }
                        else if (ddlTransferFR_SR.SelectedIndex == 0 || ddlTransferFR_SR.SelectedIndex == -1)
                        {
                            tblFr_Godown.Visible = false;
                            tblFr_Function.Visible = false;
                            tblFr_Division.Visible = false;
                            tblFr_Center.Visible = false;
                        }



                        DataSet dsItems = ProductController.Get_Edit_GRNDetails(19, lblPkey.Text.Trim());
                        if (dsItems.Tables[0].Rows.Count > 0)
                        {
                            DataList4.DataSource = dsItems;
                            DataList4.DataBind();
                        }
                    }


                    if (lblInwardIsAuthorised.Text == "0")
                    {
                        BtnSaveUpdate.Visible = true;
                        DivAddItem.Visible = false;

                        GridMaterialList.Attributes.Remove("Class");
                        GridMaterialList.Attributes.Add("Class", "span8");
                        //DivAddItem.Attributes.Remove("Class");
                        //DivAddItem.Attributes.Add("Class", "span4");
                    }
                    else if (lblInwardIsAuthorised.Text == "1")
                    {
                        BtnSaveAdd.Visible = false;
                        BtnSaveUpdate.Visible = false;
                        DivAddItem.Visible = false;
                        GridMaterialList.Attributes.Remove("Class");
                        GridMaterialList.Attributes.Add("Class", "span8");

                    }

                }



            }
            else if (e.CommandName == "comAuthorise")
            {
                lblPkey.Text = "";
                ControlVisibility("Authorise");
                Clear_Error_Success_Box();
                //ClearAuthPanel();

                dlItemListAuthorise.DataSource = null;
                dlItemListAuthorise.DataBind();

                FillDDL_Supplier();
                Clear_Error_Success_Box();
                string poflag;
                lblPkey.Text = e.CommandArgument.ToString();
                string pky = e.CommandArgument.ToString();
                DataSet ds = ProductController.Get_Edit_GRNDetails(28, e.CommandArgument.ToString());

                lblAuthorised.Text = ds.Tables[0].Rows[0]["Is_Authorised"].ToString();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtEntryDate_Auth.Text = ds.Tables[0].Rows[0]["Inward_date"].ToString();
                    poflag = ds.Tables[0].Rows[0]["PoFlag"].ToString();
                    if (poflag == "0")
                    {
                        ddlpostatus_Auth.SelectedIndex = 2;
                        PONOID_Auth.Visible = false;

                        SuppID_Auth.Visible = true;
                        lblSup_Auth.Visible = false;
                        lblSupplier_Auth.Visible = false;

                        ddlSupplier_Auth.SelectedValue = ds.Tables[0].Rows[0]["Vendor_Code"].ToString();
                        ddlSupplier_Auth.Visible = true;
                    }
                    else if (poflag == "1")
                    {
                        PONOID_Auth.Visible = true;
                        SuppID_Auth.Visible = false;

                        ddlpostatus_Auth.SelectedIndex = 1;
                        ddlSupplier_Auth.Visible = false;
                        //DivAddItem.Visible = true;
                        FillDDL_PONumber();
                        ddlpoNo_Auth.SelectedValue = ds.Tables[0].Rows[0]["PoNo"].ToString();

                        lblSupplier_Auth.Text = ds.Tables[0].Rows[0]["Vendor_Name"].ToString();
                        Label43.Text = ds.Tables[0].Rows[0]["Vendor_Code"].ToString();
                        lblSup_Auth.Visible = true;
                        lblSupplier_Auth.Visible = true;
                    }

                    txtDCNO_Auth.Text = ds.Tables[0].Rows[0]["Challan_No"].ToString();
                    txtDCDate_Auth.Text = ds.Tables[0].Rows[0]["Challan_Date"].ToString();
                    txtInvoice_No_Auth.Text = ds.Tables[0].Rows[0]["Invoice_No"].ToString();
                    txtInvoiceDate_Auth.Text = ds.Tables[0].Rows[0]["invoice_date"].ToString();
                    txtInvoiceValue_Auth.Text = ds.Tables[0].Rows[0]["invoice_value"].ToString();

                    ddlLocation_Auth.SelectedValue = ds.Tables[0].Rows[0]["Transfer_Location_Type_Code"].ToString();

                    if (ddlLocation_Auth.SelectedItem.ToString().Trim() == "Godown")
                    {
                        tblFr_Godown_Auth.Visible = true;
                        tblFr_Function_Auth.Visible = false;
                        tblFr_Division_Auth.Visible = false;
                        tblFr_Center_Auth.Visible = false;
                        FillDDL_Godown();
                        ddlGodown_Auth.SelectedValue = ds.Tables[0].Rows[0]["Transfer_Location_Code"].ToString();
                    }
                    else if (ddlLocation_Auth.SelectedItem.ToString().Trim() == "Function")
                    {
                        tblFr_Function_Auth.Visible = true;
                        tblFr_Godown_Auth.Visible = false;
                        tblFr_Division_Auth.Visible = false;
                        tblFr_Center_Auth.Visible = false;
                        FillDDL_Function();
                        ddlFunction_Auth.SelectedValue = ds.Tables[0].Rows[0]["Transfer_Location_Code"].ToString();
                    }
                    else if (ddlLocation_Auth.SelectedItem.ToString().Trim() == "Center")
                    {
                        tblFr_Division_Auth.Visible = true;
                        tblFr_Center_Auth.Visible = true;
                        tblFr_Function_Auth.Visible = false;
                        tblFr_Godown_Auth.Visible = false;

                        ddlDivision_Auth.SelectedValue = ds.Tables[0].Rows[0]["Source_Division_Code"].ToString();
                        ddlCenter_Auth.Items.Clear();
                        FillDDL_FRAuth_Centre();

                        ddlCenter_Auth.SelectedValue = ds.Tables[0].Rows[0]["Transfer_Location_Code"].ToString();

                    }
                    else if (ddlLocation_Auth.SelectedIndex == 0 || ddlLocation_Auth.SelectedIndex == -1)
                    {
                        tblFr_Godown_Auth.Visible = false;
                        tblFr_Function_Auth.Visible = false;
                        tblFr_Division_Auth.Visible = false;
                        tblFr_Center_Auth.Visible = false;
                    }


                    DataSet dsItems = ProductController.Get_Edit_GRNDetails(5, pky);
                    if (dsItems.Tables[0].Rows.Count > 0)
                    {
                        dlItemListAuthorise.DataSource = dsItems;
                        dlItemListAuthorise.DataBind();
                    }
                }

            }

        }

        catch (Exception ex)
        {
        }

    }
    protected void dlQuestion_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "Details")
        {
            ControlVisibility("Details");
            lblInwardEbtryCode_BR.Text = e.CommandArgument.ToString();
            int Qty = 0;

            DataSet ds = ProductController.Get_FillDetails_InwardItems(9, lblInwardEbtryCode_BR.Text.Trim());
            //Get_FillDetails_InwardItems
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtItemName_BR.Text = ds.Tables[0].Rows[0]["Item_Name"].ToString();
                Qty = Convert.ToInt32(ds.Tables[0].Rows[0]["Inward_Qty"].ToString());
                lblInwardCode_BR.Text = ds.Tables[0].Rows[0]["Inward_Code"].ToString();
                lblAssetesNoTypeID.Text = ds.Tables[0].Rows[0]["AssetsNo_Type_Id"].ToString();
                lblIs_Authorised.Text = ds.Tables[0].Rows[0]["lblIs_Authorised"].ToString();
                lblqty.Text = ds.Tables[0].Rows[0]["Inward_Qty"].ToString();
                // lblqty.Text = Qty;
                if (lblIs_Authorised.Text == "0")
                {
                    btnUserMenuSave.Visible = true;
                }
                else if (lblIs_Authorised.Text == "1")
                {
                    btnUserMenuSave.Visible = false;
                }
            }

            DataTable dtEmptEntry = new DataTable();
            DataRow NewRow = null;

            var _with1 = dtEmptEntry;
            _with1.Columns.Add("lblSRNo");
            _with1.Columns.Add("txtItemSerialNo");
            _with1.Columns.Add("txtSAPAsset");
            _with1.Columns.Add("txtItemBarcodeNo");


            for (int i = 0; i < Qty; i++)
            {
                int rownum = i + 1;

                NewRow = dtEmptEntry.NewRow();
                NewRow["lblSRNo"] = rownum.ToString();
                NewRow["txtItemSerialNo"] = "";
                NewRow["txtSAPAsset"] = "";
                NewRow["txtItemBarcodeNo"] = "";

                dtEmptEntry.Rows.Add(NewRow);

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
                    TextBox txtItemBarcodeNo = (TextBox)item.FindControl("txtItemBarcodeNo");
                    TextBox txtSAPAsset = (TextBox)item.FindControl("txtSAPAsset");

                    if (lblAssetesNoTypeID.Text == "ATN00000002")
                    {
                        txtItemSerialNo.Enabled = true;
                        txtItemBarcodeNo.Enabled = true;
                    }
                    else if (lblAssetesNoTypeID.Text == "ATN00000003")
                    {
                        txtItemSerialNo.Enabled = true;
                        txtItemBarcodeNo.Enabled = false;
                    }

                    string srno = "", serial = "", barcode = "", SAP_Asset = "";
                    for (int k = 0; k < DSCHK.Tables[0].Rows.Count; k++)
                    {
                        srno = DSCHK.Tables[0].Rows[k]["lblSRNo"].ToString();
                        serial = DSCHK.Tables[0].Rows[k]["txtItemSerialNo"].ToString();
                        SAP_Asset = DSCHK.Tables[0].Rows[k]["txtSAPAsset"].ToString();
                        barcode = DSCHK.Tables[0].Rows[k]["txtItemBarcodeNo"].ToString();

                        if (lblSRNo.Text.Trim() == srno)
                        {
                            txtItemSerialNo.Text = serial;
                            txtSAPAsset.Text = SAP_Asset;
                            txtItemBarcodeNo.Text = barcode;
                        }
                    }

                }
            }
        }
        else if (e.CommandName == "ItemRemove")
        {
            //Remove_andFill_Items

            lblInwardEntryCodeRemove.Text = e.CommandArgument.ToString().Trim();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalDivCOnfirmation();", true);



        }

    }

    private void Fill_data()
    {
        int Qty = 0;

        DataSet ds = ProductController.Get_FillDetails_InwardItems(9, lblInwardEbtryCode_BR.Text.Trim());
        //Get_FillDetails_InwardItems
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtItemName_BR.Text = ds.Tables[0].Rows[0]["Item_Name"].ToString();
            Qty = Convert.ToInt32(ds.Tables[0].Rows[0]["Inward_Qty"].ToString());
            lblInwardCode_BR.Text = ds.Tables[0].Rows[0]["Inward_Code"].ToString();
            lblAssetesNoTypeID.Text = ds.Tables[0].Rows[0]["AssetsNo_Type_Id"].ToString();
        }

        DataTable dtEmptEntry = new DataTable();
        DataRow NewRow = null;

        var _with1 = dtEmptEntry;
        _with1.Columns.Add("lblSRNo");
        _with1.Columns.Add("txtItemSerialNo");
        _with1.Columns.Add("txtSAPAsset");
        _with1.Columns.Add("txtItemBarcodeNo");


        for (int i = 0; i < Qty; i++)
        {
            int rownum = i + 1;

            NewRow = dtEmptEntry.NewRow();
            NewRow["lblSRNo"] = rownum.ToString();
            NewRow["txtItemSerialNo"] = "";
            NewRow["txtSAPAsset"] = "";
            NewRow["txtItemBarcodeNo"] = "";

            dtEmptEntry.Rows.Add(NewRow);

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
                TextBox txtSAPAsset = (TextBox)item.FindControl("txtSAPAsset");
                TextBox txtItemBarcodeNo = (TextBox)item.FindControl("txtItemBarcodeNo");

                if (lblAssetesNoTypeID.Text == "ATN00000002")
                {
                    txtItemSerialNo.Enabled = true;
                    txtItemBarcodeNo.Enabled = true;
                }
                else if (lblAssetesNoTypeID.Text == "ATN00000003")
                {
                    txtItemSerialNo.Enabled = true;
                    txtItemBarcodeNo.Enabled = false;
                }

                string srno = "", serial = "", barcode = "", SAP_Asset = "";
                for (int k = 0; k < DSCHK.Tables[0].Rows.Count; k++)
                {
                    srno = DSCHK.Tables[0].Rows[k]["lblSRNo"].ToString();
                    serial = DSCHK.Tables[0].Rows[k]["txtItemSerialNo"].ToString();
                    SAP_Asset = DSCHK.Tables[0].Rows[k]["txtSAPAsset"].ToString();
                    barcode = DSCHK.Tables[0].Rows[k]["txtItemBarcodeNo"].ToString();

                    if (lblSRNo.Text.Trim() == srno)
                    {
                        txtItemSerialNo.Text = serial;
                        txtItemBarcodeNo.Text = barcode;
                        txtSAPAsset.Text = SAP_Asset;
                    }
                }

            }
        }



    }

    private void TempSaveData()
    {
        try
        {
            Clear_Error_Success_Box();

            if (ddlPOStatus_Add.SelectedIndex == 0)
            {
                Show_Error_Success_Box("E", "Select Po Status");
                ddlPOStatus_Add.Focus();

                dlQuestion.DataSource = null;
                dlQuestion.DataBind();

                return;
            }

            if (ddlPOStatus_Add.SelectedValue == "Yes")
            {
                if (ddlPONo_Add.SelectedIndex == 0)
                {
                    Show_Error_Success_Box("E", "Select PO Number");
                    ddlPONo_Add.Focus();
                    dlQuestion.DataSource = null;
                    dlQuestion.DataBind();
                    return;
                }
                else if (ddlPONo_Add.SelectedIndex == -1)
                {
                    Show_Error_Success_Box("E", "Select PO Number");
                    ddlPONo_Add.Focus();
                    dlQuestion.DataSource = null;
                    dlQuestion.DataBind();
                    return;
                }

                if (lblSuppName.Text == "")
                {
                    Show_Error_Success_Box("E", "Supplier not found for this PO...!");
                    return;
                }
            }
            else if (ddlPOStatus_Add.SelectedValue == "No")
            {
                if (ddlSupplier_Add.SelectedIndex == 0)
                {
                    Show_Error_Success_Box("E", "Select Supplier");
                    ddlSupplier_Add.Focus();
                    dlQuestion.DataSource = null;
                    dlQuestion.DataBind();
                    return;
                }
            }


            if (txtDCNO.Text.Trim() == "")
            {
                Show_Error_Success_Box("E", "Enter DC Number");
                txtDCNO.Focus();
                dlQuestion.DataSource = null;
                dlQuestion.DataBind();
                return;
            }

            if (txtDCDate.Value.Trim() == "")
            {
                Show_Error_Success_Box("E", "Enter DC Date");
                txtDCDate.Focus();
                dlQuestion.DataSource = null;
                dlQuestion.DataBind();
                return;
            }

            if (ddlTransferFR_SR.SelectedIndex == 0 || ddlTransferFR_SR.SelectedIndex == -1)
            {
                Show_Error_Success_Box("E", "Select Location Type");
                ddlTransferFR_SR.Focus();
                return;
            }


            if (ddlTransferFR_SR.SelectedItem.ToString() == "Godown")
            {
                if (ddlgodownFR_SR.SelectedIndex == 0 || ddlgodownFR_SR.SelectedIndex == -1)
                {
                    Show_Error_Success_Box("E", "Select Godown");
                    ddlgodownFR_SR.Focus();
                    return;
                }
            }
            else if (ddlTransferFR_SR.SelectedItem.ToString() == "Function")
            {
                if (ddlFunctionFR_SR.SelectedIndex == 0 || ddlFunctionFR_SR.SelectedIndex == -1)
                {
                    Show_Error_Success_Box("E", "Select Function");
                    ddlFunctionFR_SR.Focus();
                    return;
                }
            }
            else if (ddlTransferFR_SR.SelectedItem.ToString() == "Center")
            {
                if (ddlDivisionFR_SR.SelectedIndex == 0 || ddlDivisionFR_SR.SelectedIndex == -1)
                {
                    Show_Error_Success_Box("E", "Select Division");
                    ddlDivisionFR_SR.Focus();
                    return;
                }

                else if (ddlCenterFR_SR.SelectedIndex == 0 || ddlCenterFR_SR.SelectedIndex == -1)
                {
                    Show_Error_Success_Box("E", "Select Center");
                    ddlCenterFR_SR.Focus();
                    return;
                }

            }

            if (ddlbudgetDivision.SelectedIndex == 0 || ddlbudgetDivision.SelectedIndex == -1)
            {
                Show_Error_Success_Box("E", "Select Budget Division");
                ddlbudgetDivision.Focus();
                return;
            }

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
            string Supplier_Code = "", PONo = "";
            int PoFlag = 0;

            if (ddlPOStatus_Add.SelectedValue == "Yes")
            {
                Supplier_Code = lblsuppliercode.Text.Trim();
                PONo = ddlPONo_Add.SelectedValue.ToString();
                PoFlag = 1;
            }
            else if (ddlPOStatus_Add.SelectedValue == "No")
            {
                Supplier_Code = ddlSupplier_Add.SelectedValue.ToString().Trim();
                PONo = "";
                PoFlag = 0;
            }

            int Total_Item_Count = 0;
            double Total_Purchase_Amount = 0;
            double total_Quantity = 0;

            double invoiceval = 0;
            if (txtInvoiceValue_Add.Text == "")
            {
                invoiceval = 0;
            }
            else
            {
                invoiceval = Convert.ToDouble(txtInvoiceValue_Add.Text.Trim());
            }

            string Transfer_LocationCode = "";
            //

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

            string logistic1 = "", logistic2 = "";

            if (ddlLogisticType_Add.SelectedItem.ToString() == "Courier")
            {
                logistic1 = txtLogisticDetails_Add.Text.Trim();
                logistic2 = txtPODNo_Add0.Text.Trim();
            }

            if (ddlLogisticType_Add.SelectedItem.ToString() == "Transport")
            {
                logistic1 = txtLogisticDetails_Add.Text.Trim();
                logistic2 = txtVechicleNo_Add.Text.Trim();
            }

            if (ddlLogisticType_Add.SelectedItem.ToString() == "In Person")
            {
                logistic1 = txtLogisticDetails_Add.Text.Trim();
                logistic2 = "";
            }

            //


            if (lblPkey.Text == "")
            {
                ResultId = ProductController.Insert_ChkGRNInward(7, Supplier_Code, txtDCNO.Text.Trim(), txtDCDate.Value.ToString().Trim());
                if (ResultId == "1")
                {
                    ResultId = ProductController.Insert_GRNInward(1, Supplier_Code, txtDCNO.Text.Trim(), txtDCDate.Value.ToString().Trim(), txtInvoiceNo_Add.Text.Trim(), Total_Item_Count, Total_Purchase_Amount, 1, PONo, PoFlag, CreatedBy, 0, txtInvoiceDT.Value.ToString().Trim(), invoiceval, ddlTransferFR_SR.SelectedValue.ToString().Trim(), Transfer_LocationCode, total_Quantity, ddlLogisticType_Add.SelectedValue.ToString().Trim(), logistic1, logistic2, 0, ddlbudgetDivision.SelectedValue.ToString().Trim());
                    if (ResultId == "-1")
                    {
                        Msg_Error.Visible = true;
                        Msg_Success.Visible = false;
                        lblerror.Text = "Duplicate Chalan No ...!";
                        UpdatePanelMsgBox.Update();
                        return;
                    }
                    else
                    {
                        lblPkey.Text = ResultId;
                    }
                }
                else
                {
                    Msg_Error.Visible = true;
                    Msg_Success.Visible = false;
                    lblerror.Text = "Duplicate Chalan No...!";
                    UpdatePanelMsgBox.Update();
                    return;
                }

            }
            else//Check the update time
            {
                string Error_Code = "";
                ResultId = ProductController.Insert_ChkGRNInward_Updatetime(30, lblPkey.Text, Supplier_Code, txtDCNO.Text.Trim(), txtDCDate.Value.ToString().Trim());
                if (ResultId == "1")
                {
                    double Total_Quantity = 0;

                    foreach (DataListItem item in dlQuestion.Items)
                    {
                        if (item.ItemType == ListItemType.Item | item.ItemType == ListItemType.AlternatingItem)
                        {
                            Label lblValue_DT = (Label)item.FindControl("lblValue_DT");
                            Label lblChallanQty_DT = (Label)item.FindControl("lblChallanQty_DT");

                            Total_Item_Count = Total_Item_Count + 1;

                            Total_Purchase_Amount = Total_Purchase_Amount + Convert.ToDouble(lblValue_DT.Text.Trim());
                            Total_Quantity = Total_Quantity + Convert.ToDouble(lblChallanQty_DT.Text.Trim());
                        }
                    }
                    ResultId = ProductController.Update_GRNInward(6, Supplier_Code, txtDCNO.Text.Trim(), txtDCDate.Value.ToString().Trim(), txtInvoiceNo_Add.Text.Trim(), Total_Item_Count, Total_Purchase_Amount, 1, PONo, PoFlag, CreatedBy, lblPkey.Text.Trim(), txtDCDate.Value.ToString().Trim(), 0, txtInvoiceDT.Value.ToString().Trim(), invoiceval, ddlTransferFR_SR.SelectedValue.ToString().Trim(), Transfer_LocationCode, Total_Quantity, ddlLogisticType_Add.SelectedValue.ToString().Trim(), logistic1, logistic2, 0, ddlbudgetDivision.SelectedValue.ToString().Trim());

                    try
                    {
                        Error_Code = ResultId.Substring(0, 5);
                    }
                    catch { }

                    if (ResultId == "-1")
                    {
                        Clear_Error_Success_Box();
                        Msg_Error.Visible = true;
                        Msg_Success.Visible = false;
                        Show_Error_Success_Box("E", "Duplicate Challan Number");
                        return;
                    }
                    else if (Error_Code == "Error")
                    {
                        Clear_Error_Success_Box();
                        Msg_Error.Visible = true;
                        Msg_Success.Visible = false;
                        Show_Error_Success_Box("E", ResultId.Substring(5, ResultId.Length - 5));
                        return;
                    }
                }
                else
                {
                    Msg_Error.Visible = true;
                    Msg_Success.Visible = false;
                    lblerror.Text = "Duplicate Chalan No...!";
                    UpdatePanelMsgBox.Update();
                    dlQuestion.DataSource = null;
                    dlQuestion.DataBind();
                    return;
                }
            }

            ResultID2 = ProductController.delete_InwardItems(8, lblPkey.Text.Trim());

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
                    Label lblIs_Authorised = (Label)item.FindControl("lblIs_Authorised");
                    Label lblpoentry = (Label)item.FindControl("lblpoentry");

                    icoun = icoun + 1;
                    string InwardEntry_Code = lblPkey.Text + icoun.ToString();

                    ResultId1 = ProductController.Insert_GRNInward_Items(2, lblPkey.Text, InwardEntry_Code, lblMaterialCode_DT.Text.Trim(), Convert.ToDouble(lblChallanQty_DT.Text.Trim()), Convert.ToDouble(lblRatePO_DT.Text.Trim()), Convert.ToDouble(lblValue_DT.Text.Trim()), 1, Convert.ToInt32(lblIs_Authorised.Text.Trim()), ddlbudgetDivision.SelectedValue.ToString().Trim(), lblpoentry.Text, CreatedBy);

                }
            }


            DataSet dsItems = ProductController.Get_Edit_GRNDetails1(19, lblPkey.Text.Trim(), lblcenter.Text, lbldivision.Text);
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
    protected void DataList2_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        int tabIndex = 0;

        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            //Label txtItemBarcodeNo = (Label)e.Item.FindControl("txtItemBarcodeNo");
            //Label txtItemSerialNo = (Label)e.Item.FindControl("txtItemSerialNo");
            //txtItemBarcodeNo.TabIndex = (short)++tabIndex;
            TextBox txtItemBarcodeNo = (TextBox)e.Item.FindControl("txtItemBarcodeNo");
            TextBox txtItemSerialNo = (TextBox)e.Item.FindControl("txtItemSerialNo");
            txtItemBarcodeNo.TabIndex = (short)++tabIndex;


        }
    }

    //protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    //{
    //    foreach (DataListItem item in DataList2.Items)
    //    {
    //        if (item.ItemType == ListItemType.Item | item.ItemType == ListItemType.AlternatingItem)
    //        {
    //            Label lblSRNo = (Label)item.FindControl("lblSRNo");
    //            TextBox txtItemSerialNo = (TextBox)item.FindControl("txtItemSerialNo");
    //            TextBox txtItemBarcodeNo = (TextBox)item.FindControl("txtItemBarcodeNo");


    //            txtItemSerialNo.Enabled = false;
    //            txtItemSerialNo.Text = "";
    //            txtItemBarcodeNo.Text = "";

    //        }
    //    }

    //    DataSet DSCHK = ProductController.Get_FillDetails_InwardItemsDetails(12, lblInwardCode_BR.Text.Trim(), lblInwardEbtryCode_BR.Text.Trim());

    //    foreach (DataListItem item in DataList2.Items)
    //    {
    //        if (item.ItemType == ListItemType.Item | item.ItemType == ListItemType.AlternatingItem)
    //        {
    //            Label lblSRNo = (Label)item.FindControl("lblSRNo");
    //            TextBox txtItemSerialNo = (TextBox)item.FindControl("txtItemSerialNo");
    //            TextBox txtItemBarcodeNo = (TextBox)item.FindControl("txtItemBarcodeNo");
    //            string srno = "", serial = "", barcode = "";
    //            for (int k = 0; k < DSCHK.Tables[0].Rows.Count; k++)
    //            {
    //                srno = DSCHK.Tables[0].Rows[k]["lblSRNo"].ToString();
    //                serial = DSCHK.Tables[0].Rows[k]["txtItemSerialNo"].ToString();
    //                barcode = DSCHK.Tables[0].Rows[k]["txtItemBarcodeNo"].ToString();

    //                if (lblSRNo.Text.Trim() == srno)
    //                {
    //                    txtItemSerialNo.Text = serial;
    //                    txtItemBarcodeNo.Text = barcode;
    //                }
    //            }

    //        }
    //    }
    //}
    //protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
    //{
    //    foreach (DataListItem item in DataList2.Items)
    //    {
    //        if (item.ItemType == ListItemType.Item | item.ItemType == ListItemType.AlternatingItem)
    //        {
    //            Label lblSRNo = (Label)item.FindControl("lblSRNo");
    //            TextBox txtItemSerialNo = (TextBox)item.FindControl("txtItemSerialNo");
    //            TextBox txtItemBarcodeNo = (TextBox)item.FindControl("txtItemBarcodeNo");

    //            if (lblSRNo.Text.Trim() == "1")
    //            {
    //                txtItemSerialNo.Enabled = true;
    //            }
    //            else
    //            {
    //                txtItemSerialNo.Enabled = false;
    //            }

    //            txtItemSerialNo.Text = "";
    //            txtItemBarcodeNo.Text = "";
    //        }
    //    }

    //    DataSet DSCHK = ProductController.Get_FillDetails_InwardItemsDetails(12, lblInwardCode_BR.Text.Trim(), lblInwardEbtryCode_BR.Text.Trim());

    //    foreach (DataListItem item in DataList2.Items)
    //    {
    //        if (item.ItemType == ListItemType.Item | item.ItemType == ListItemType.AlternatingItem)
    //        {
    //            Label lblSRNo = (Label)item.FindControl("lblSRNo");
    //            TextBox txtItemSerialNo = (TextBox)item.FindControl("txtItemSerialNo");
    //            TextBox txtItemBarcodeNo = (TextBox)item.FindControl("txtItemBarcodeNo");
    //            string srno = "", serial = "", barcode = "";
    //            for (int k = 0; k < DSCHK.Tables[0].Rows.Count; k++)
    //            {
    //                srno = DSCHK.Tables[0].Rows[k]["lblSRNo"].ToString();
    //                serial = DSCHK.Tables[0].Rows[k]["txtItemSerialNo"].ToString();
    //                barcode = DSCHK.Tables[0].Rows[k]["txtItemBarcodeNo"].ToString();

    //                if (lblSRNo.Text.Trim() == srno)
    //                {
    //                    txtItemSerialNo.Text = serial;
    //                    txtItemBarcodeNo.Text = barcode;
    //                }
    //            }

    //        }
    //    }
    //}


    protected void txtItemSerialNo_TextChanged(object sender, EventArgs e)
    {
        //if (RadioButton1.Checked == true)
        //{
        //    string Copy = "";
        //    foreach (DataListItem item in DataList2.Items)
        //    {
        //        if (item.ItemType == ListItemType.Item | item.ItemType == ListItemType.AlternatingItem)
        //        {
        //            Label lblSRNo = (Label)item.FindControl("lblSRNo");
        //            TextBox txtItemSerialNo = (TextBox)item.FindControl("txtItemSerialNo");
        //            TextBox txtItemBarcodeNo = (TextBox)item.FindControl("txtItemBarcodeNo");

        //            if (lblSRNo.Text.Trim() == "1")
        //            {
        //                Copy = txtItemSerialNo.Text.Trim();
        //            }
        //            else
        //            {
        //                txtItemSerialNo.Text = "";
        //                txtItemSerialNo.Text = Copy;
        //            }

        //        }
        //    }
        //}

    }

    protected void txtItemBarcodeNo_TextChanged(object sender, EventArgs e)
    {
        //if (RadioButton2.Checked == true)
        //{
        //    string Copy = "";
        //    foreach (DataListItem item in DataList2.Items)
        //    {
        //        if (item.ItemType == ListItemType.Item | item.ItemType == ListItemType.AlternatingItem)
        //        {
        //            Label lblSRNo = (Label)item.FindControl("lblSRNo");
        //            TextBox txtItemSerialNo = (TextBox)item.FindControl("txtItemSerialNo");
        //            TextBox txtItemBarcodeNo = (TextBox)item.FindControl("txtItemBarcodeNo");

        //            Copy = txtItemBarcodeNo.Text.Trim();
        //            txtItemSerialNo.Text = "";
        //            txtItemSerialNo.Text = Copy;

        //        }
        //    }
        //}
        //else
        //{
        //}

    }

    protected void ddlPONo_Add_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlPONo_Add.SelectedIndex == 0 || ddlPONo_Add.SelectedIndex == -1)
            {
                ddlPOItems_Add.Items.Clear();
                lblSuppName.Text = "";
                lblsuppliercode.Text = "";
            }
            else
            {
                DataSet dsSupplier = ProductController.GetSupplierPONumber(15, ddlPONo_Add.SelectedValue.ToString().Trim());

                if (dsSupplier.Tables[0].Rows.Count > 0)
                {
                    lblSuppName.Text = dsSupplier.Tables[0].Rows[0]["Vendor_Name"].ToString();
                    lblsuppliercode.Text = dsSupplier.Tables[0].Rows[0]["Supplier_Code"].ToString();
                }
                else
                {
                    lblSuppName.Text = "";
                    lblsuppliercode.Text = "";
                }

                FillDDL_POItems();
                lblMateCode.Text = "";
                lblItemName.Text = "";
                lblUnit.Text = "";
                lblItemPOQty.Text = "0";
                txtItemRate.Text = "";
                lblAssetNoType.Text = "";

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
    protected void ddlPOItems_Add_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlPOItems_Add.SelectedIndex == 0 || ddlPOItems_Add.SelectedIndex == -1)
            {
                lblMateCode.Text = "";
                lblItemName.Text = "";
                lblUnit.Text = "";
                lblItemPOQty.Text = "0";
                txtItemRate.Text = "";
                lblAssetNoType.Text = "";
            }
            else
            {
                DataSet dsItemDetails = ProductController.GetItemsDetailsPONumber(17, ddlPONo_Add.SelectedValue.ToString().Trim(), ddlPOItems_Add.SelectedValue.ToString().Trim());
                // DataSet dsItemDetails = ProductController.GetItemsDetailsPONumber(17, ddlPONo_Add.SelectedValue.ToString().Trim(), lblPkey.Text);

                if (dsItemDetails.Tables[0].Rows.Count > 0)
                {
                    lblMateCode.Text = dsItemDetails.Tables[0].Rows[0]["Item_Code"].ToString();
                    lblItemName.Text = dsItemDetails.Tables[0].Rows[0]["Item_Name"].ToString();
                    lblUnit.Text = dsItemDetails.Tables[0].Rows[0]["UOM_Name"].ToString();
                    lblItemPOQty.Text = dsItemDetails.Tables[0].Rows[0]["PurchaseOrder_Qty"].ToString();
                    txtItemRate.Text = dsItemDetails.Tables[0].Rows[0]["PurchaseOrder_Rate"].ToString();
                    lblAssetNoType.Text = dsItemDetails.Tables[0].Rows[0]["AssetsNo_Type_Id"].ToString();
                    lblcenter.Text = dsItemDetails.Tables[0].Rows[0]["Center_Code"].ToString();
                    lbldivision.Text = dsItemDetails.Tables[0].Rows[0]["Division_Code"].ToString();
                    lblpo_OrderEntry.Text = dsItemDetails.Tables[0].Rows[0]["PurchaseOrderEntry_Code"].ToString();
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
    protected void txtItemQty_TextChanged(object sender, EventArgs e)
    {
        decimal Qty1 = 0;
        decimal Rate1 = 0;
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


    //protected void txtRatePO_DT_TextChanged(object sender, EventArgs e)
    //{
    //    //int Qty1 = 0, Rate1 = 0;
    //    //double Qty, Rate;
    //    DataListItem DataList4 = (DataListItem)((Label)sender).Parent;
    //    Label abc = (Label)DataList4.FindControl("lblChallanQty_DT");
    //    TextBox xyz = (TextBox)DataList4.FindControl("txtRatePO_DT");
    //    TextBox result = (TextBox)DataList4.FindControl("txtValue_DT");

    //    Double Qty = Convert.ToDouble(abc.Text);
    //    Double Rate = Convert.ToDouble(xyz.Text);
    //    Double Value = Convert.ToDouble(result.Text);
    //    Value = (Qty * Rate);



    //    result.Text = Value.ToString();
    //}



    protected void ddlTransferFR_SR_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTransferFR_SR.SelectedItem.ToString().Trim() == "Godown")
        {
            tblFr_Godown.Visible = true;
            tblFr_Function.Visible = false;
            tblFr_Division.Visible = false;
            tblFr_Center.Visible = false;
            FillDDL_Godown();
        }
        else if (ddlTransferFR_SR.SelectedItem.ToString().Trim() == "Function")
        {
            tblFr_Function.Visible = true;
            tblFr_Godown.Visible = false;
            tblFr_Division.Visible = false;
            tblFr_Center.Visible = false;
            FillDDL_Function();
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
        ddlDivisionFR_SR.Items.Insert(0, "Select Division");
        ddlDivisionFR_SR.SelectedIndex = 0;

        BindDDL(ddldivision_Search, dsDivision, "Division_Name", "Division_Code");
        ddldivision_Search.Items.Insert(0, "Select Division");
        ddldivision_Search.SelectedIndex = 0;

        BindDDL(ddlDivision_Auth, dsDivision, "Division_Name", "Division_Code");
        ddlDivision_Auth.Items.Insert(0, "Select Division");
        ddlDivision_Auth.SelectedIndex = 0;

        BindDDL(ddlbudgetDivision, dsDivision, "Division_Name", "Division_Code");
        ddlbudgetDivision.Items.Insert(0, "Select Division");
        ddlbudgetDivision.SelectedIndex = 0;

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

        BindDDL(ddlCenter_Auth, dsCentre, "Center_Name", "Center_Code");
        ddlCenter_Auth.Items.Insert(0, "Select");
        ddlCenter_Auth.SelectedIndex = 0;
    }


    private void FillDDL_FRAuth_Centre()
    {
        string Company_Code = "MT";
        string DBname = "CDB";

        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];

        string Div_Code = null;
        Div_Code = ddlDivision_Auth.SelectedValue;

        DataSet dsCentre = ProductController.GetAllActiveUser_Company_Division_Zone_Center(UserID, Company_Code, Div_Code, "", "5", DBname);

        BindDDL(ddlCenter_Auth, dsCentre, "Center_Name", "Center_Code");
        ddlCenter_Auth.Items.Insert(0, "Select");
        ddlCenter_Auth.SelectedIndex = 0;
    }


    private void FillDDL_FRSearch_Centre_Search()
    {
        string Company_Code = "MT";
        string DBname = "CDB";

        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];

        string Div_Code = null;
        Div_Code = ddldivision_Search.SelectedValue;

        DataSet dsCentre = ProductController.GetAllActiveUser_Company_Division_Zone_Center(UserID, Company_Code, Div_Code, "", "5", DBname);

        BindDDL(ddlCenter_Search, dsCentre, "Center_Name", "Center_Code");
        ddlCenter_Search.Items.Insert(0, "Select");
        ddlCenter_Search.SelectedIndex = 0;
    }

    private void FillDDL_TransferType()
    {
        //Search DDL
        DataSet dsTransfer_Tp = ProductController.GetAllTransferType(1);
        BindDDL(ddlTransferFR_SR, dsTransfer_Tp, "Transfer_Location_Type_Name", "Transfer_Location_Type_ID");
        ddlTransferFR_SR.Items.Insert(0, "Select Location");
        ddlTransferFR_SR.SelectedIndex = 0;

        BindDDL(ddllocation_Search, dsTransfer_Tp, "Transfer_Location_Type_Name", "Transfer_Location_Type_ID");
        ddllocation_Search.Items.Insert(0, "Select Location");
        ddllocation_Search.SelectedIndex = 0;

        BindDDL(ddlLocation_Auth, dsTransfer_Tp, "Transfer_Location_Type_Name", "Transfer_Location_Type_ID");
        ddlLocation_Auth.Items.Insert(0, "Select Location");
        ddlLocation_Auth.SelectedIndex = 0;

    }


    private void FillDDL_Godown()
    {
        ddlgodownFR_SR.Items.Clear();
        DataSet dsTransfer_Tp = ProductController.GetGodown_Function_Logistic_Assests_Type(1);
        BindDDL(ddlgodownFR_SR, dsTransfer_Tp, "Godown_Name", "Godown_Id");
        ddlgodownFR_SR.Items.Insert(0, "Select Godown");
        ddlgodownFR_SR.SelectedIndex = 0;

        BindDDL(ddlGodown_Auth, dsTransfer_Tp, "Godown_Name", "Godown_Id");
        ddlGodown_Auth.Items.Insert(0, "Select Godown");
        ddlGodown_Auth.SelectedIndex = 0;
    }

    private void FillDDL_Godown_SR()
    {
        ddlGodown_Search.Items.Clear();
        DataSet dsTransfer_Tp = ProductController.GetGodown_Function_Logistic_Assests_Type(1);
        BindDDL(ddlGodown_Search, dsTransfer_Tp, "Godown_Name", "Godown_Id");
        ddlGodown_Search.Items.Insert(0, "Select Godown");
        ddlGodown_Search.SelectedIndex = 0;
    }

    private void FillDDL_Function()
    {
        ddlgodownFR_SR.Items.Clear();
        DataSet dsTransfer_Tp = ProductController.GetGodown_Function_Logistic_Assests_Type(2);
        BindDDL(ddlFunctionFR_SR, dsTransfer_Tp, "Function_Name", "Function_Id");
        ddlFunctionFR_SR.Items.Insert(0, "Select Function");
        ddlFunctionFR_SR.SelectedIndex = 0;

        //ddlFunction_Auth
        BindDDL(ddlFunction_Auth, dsTransfer_Tp, "Function_Name", "Function_Id");
        ddlFunction_Auth.Items.Insert(0, "Select Function");
        ddlFunction_Auth.SelectedIndex = 0;
    }

    private void FillDDL_Function_Search()
    {
        ddlFunction_Search.Items.Clear();
        DataSet dsTransfer_Tp = ProductController.GetGodown_Function_Logistic_Assests_Type(2);
        BindDDL(ddlFunction_Search, dsTransfer_Tp, "Function_Name", "Function_Id");
        ddlFunction_Search.Items.Insert(0, "Select Function");
        ddlFunction_Search.SelectedIndex = 0;
    }

    private void FillDDL_Logistic()
    {
        ddlLogisticType_Add.Items.Clear();
        DataSet dsTransfer_Tp = ProductController.GetGodown_Function_Logistic_Assests_Type(5);
        BindDDL(ddlLogisticType_Add, dsTransfer_Tp, "Logistic_Type_Name", "Logistic_Type_Id");
        ddlLogisticType_Add.Items.Insert(0, "Select Logistic");
        ddlLogisticType_Add.SelectedIndex = 0;
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
    protected void ddllocation_Search_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddllocation_Search.SelectedItem.ToString().Trim() == "Godown")
        {
            tblgodown.Visible = true;
            tblFunction.Visible = false;
            tblDivision.Visible = false;
            tblCenter.Visible = false;
            FillDDL_Godown_SR();
        }
        else if (ddllocation_Search.SelectedItem.ToString().Trim() == "Function")
        {
            tblFunction.Visible = true;
            tblgodown.Visible = false;
            tblDivision.Visible = false;
            tblCenter.Visible = false;
            FillDDL_Function_Search();
        }
        else if (ddllocation_Search.SelectedItem.ToString().Trim() == "Center")
        {
            tblDivision.Visible = true;
            tblCenter.Visible = true;
            tblFunction.Visible = false;
            tblgodown.Visible = false;

            //Fill Division
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];

        }
        else if (ddllocation_Search.SelectedIndex == 0 || ddllocation_Search.SelectedIndex == -1)
        {
            tblgodown.Visible = false;
            tblFunction.Visible = false;
            tblDivision.Visible = false;
            tblCenter.Visible = false;
        }
    }
    protected void ddldivision_Search_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillDDL_FRSearch_Centre_Search();
    }
    protected void btnCloseAuthorise_Click(object sender, EventArgs e)
    {
        try
        {
            BtnSearch_Click(this, e);
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

    protected void btnAuthorise_Click(object sender, EventArgs e)
    {
        try
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
            string CreatedBy = null;
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            CreatedBy = cookie.Values["UserID"];
            string ResultId = "0";

            foreach (DataListItem dtlItem in dlItemListAuthorise.Items)
            {
                CheckBox chkCheck = (CheckBox)dtlItem.FindControl("chkCheck");

                if (chkCheck.Checked == true)
                {
                    Label InwardEntry_Code = (Label)dtlItem.FindControl("InwardEntry_Code");
                    Label lblMaterialCode_DT = (Label)dtlItem.FindControl("lblMaterialCode_DT");
                    Label lblAssetType = (Label)dtlItem.FindControl("lblAssetType");
                    Label lblstatus = (Label)dtlItem.FindControl("lblstatus");

                    Label lblHeader_User_Code = default(Label);
                    lblHeader_User_Code = (Label)Master.FindControl("lblHeader_User_Code");

                    HtmlAnchor lbl_DLError = (HtmlAnchor)dtlItem.FindControl("lbl_DLError");
                    Panel icon_Error = (Panel)dtlItem.FindControl("icon_Error");

                    ResultId = ProductController.Update_Authorisation_GRN(1, lblPkey.Text, InwardEntry_Code.Text, lblMaterialCode_DT.Text, "1", lblAssetType.Text, CreatedBy);
                    if (ResultId == "1")
                    {
                        //ControlVisibility("Search");
                        Show_Error_Success_Box("S", "Authorisation Done Successfully.");
                        //lbl_DLError.Title = "Teacher not allocated";
                        icon_Error.Visible = false;
                        chkCheck.Visible = false;
                        chkCheck.Checked = false;

                        LinkButton lnkDLAuthorise = (LinkButton)dtlItem.FindControl("lnkDLAuthorise");
                        lnkDLAuthorise.Visible = true;
                        string ResultId1 = ProductController.Update_Authorisation_GRNFlat(1, lblPkey.Text, CreatedBy);
                        // BtnSearch_Click(this, e);
                       // Show_Error_Success_Box("S", "Authorisation Done Successfully.");
                        lblstatus.Text = "Authorisation Done Successfully";
                       // lblstatus.ForeColor = "green";

                    }
                    else if (ResultId == "-1")
                    {
                        //lbl_DLError.Title = "Please Enter the barcode for the item.";
                        //icon_Error.Visible = true;
                        lblstatus.Text = "Please Enter the barcode for the item.";

                    }
                    //if (ResultId == "1")
                    //{
                    //    //string ResultId1 = ProductController.Update_Authorisation_GRNFlat(1, lblPkey.Text, CreatedBy);
                    //    //BtnSearch_Click(this, e);
                    //    //Show_Error_Success_Box("S", "Authorisation Done Successfully.");

                    //    if (ResultId1 == "-1")
                    //    {

                    //    }
                    //}
                    //@AssetType
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

    protected void btnDivConfirmYes_Click(object sender, System.EventArgs e)
    {
        Clear_Error_Success_Box();
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
                    FillTotalDetails_Temp();
                }
                else
                {
                    dlQuestion.DataSource = null;
                    dlQuestion.DataBind();
                    FillTotalDetails_Temp();
                }
            }
            else
            {
                dlQuestion.DataSource = null;
                dlQuestion.DataBind();
                FillTotalDetails_Temp();
            }
        }
        else
        {
            dlQuestion.DataSource = null;
            dlQuestion.DataBind();
            FillTotalDetails_Temp();
        }

        //UpdatePanel1.Update();
    }


    protected void BtnPrint_Click(object sender, EventArgs e)
    {
        if (lblAuthorised.Text == "0")
        {
            Msg_Error.Visible = true;
            Msg_Success.Visible = false;
            lblerror.Text = "Authorisation of all Items to be completed for taking print of GRN.";
            UpdatePanelMsgBox.Update();
            return;
        }
        else if (lblAuthorised.Text == "1")
        {
            Response.Redirect("GRN_Print.aspx?InwardCode=" + lblPkey.Text.Trim());
        }

    }
    protected void BtnSaveUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            Clear_Error_Success_Box();

            if (ddlPOStatus_Add.SelectedIndex == 0)
            {
                Show_Error_Success_Box("E", "Select Po Status");
                ddlPOStatus_Add.Focus();
                return;
            }

            if (ddlPOStatus_Add.SelectedValue == "Yes")
            {
                if (ddlPONo_Add.SelectedIndex == 0)
                {
                    Show_Error_Success_Box("E", "Select PO Number");
                    ddlPONo_Add.Focus();
                    return;
                }
                else if (ddlPONo_Add.SelectedIndex == -1)
                {
                    Show_Error_Success_Box("E", "Select PO Number");
                    ddlPONo_Add.Focus();
                    return;
                }
            }
            else if (ddlPOStatus_Add.SelectedValue == "No")
            {
                if (ddlSupplier_Add.SelectedIndex == 0)
                {
                    Show_Error_Success_Box("E", "Select Supplier");
                    ddlSupplier_Add.Focus();
                    return;
                }
            }



            if (txtDCNO.Text.Trim() == "")
            {
                Show_Error_Success_Box("E", "Enter DC Number");
                txtDCNO.Focus();
                return;
            }

            if (txtDCDate.Value.Trim() == "")
            {
                Show_Error_Success_Box("E", "Enter DC Date");
                txtDCDate.Focus();
                return;
            }

            if (Convert.ToDateTime(ClsCommon.FormatDate(txtDCDate.Value)) > DateTime.Today)
            {
                Show_Error_Success_Box("E", "Challan date cannot be a future date");
                txtDCDate.Focus();
                return;
            }

            if (ddlbudgetDivision.SelectedIndex == 0 || ddlbudgetDivision.SelectedIndex == -1)
            {
                Show_Error_Success_Box("E", "Select Budget Division");
                ddlbudgetDivision.Focus();
                return;
            }

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

            if (ddlPOStatus_Add.SelectedValue == "Yes")
            {
                Supplier_Code = lblsuppliercode.Text.Trim();
                PONo = ddlPONo_Add.SelectedValue.ToString();
                PoFlag = 1;
            }
            else if (ddlPOStatus_Add.SelectedValue == "No")
            {
                Supplier_Code = ddlSupplier_Add.SelectedValue.ToString().Trim();
                PONo = "";
                PoFlag = 0;
            }

            int Total_Item_Count = 0;
            double Total_Purchase_Amount = 0, Total_Quantity = 0;

            foreach (DataListItem item in DataList4.Items)
            {
                if (item.ItemType == ListItemType.Item | item.ItemType == ListItemType.AlternatingItem)
                {
                    //Label lblValue_DT = (Label)item.FindControl("lblValue_DT");
                    //Label lblChallanQty_DT = (Label)item.FindControl("lblChallanQty_DT");



                    Label lblValue_DT = (Label)item.FindControl("lblValue_DT");
                    TextBox txtChallanQty_DT = (TextBox)item.FindControl("txtChallanQty_DT");
                    Label lblRatePO_DT = (Label)item.FindControl("lblRatePO_DT");
                    Double Total = 0;
                    Total = Convert.ToDouble(lblRatePO_DT.Text) * Convert.ToDouble(txtChallanQty_DT.Text);
                    lblValue_DT.Text = Convert.ToString(Total);

                    Total_Item_Count = Total_Item_Count + 1;

                    Total_Purchase_Amount = Total_Purchase_Amount + Convert.ToDouble(lblValue_DT.Text.Trim());
                    Total_Quantity = Total_Quantity + Convert.ToDouble(txtChallanQty_DT.Text.Trim());
                }
            }


            double invoiceval = 0;
            if (txtInvoiceValue_Add.Text == "")
            {
                invoiceval = 0;
            }
            else
            {
                invoiceval = Convert.ToDouble(txtInvoiceValue_Add.Text.Trim());
            }

            string Transfer_LocationCode = "";
            //

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

            string logistic1 = "", logistic2 = "";

            if (ddlLogisticType_Add.SelectedItem.ToString() == "Courier")
            {
                logistic1 = txtLogisticDetails_Add.Text.Trim();
                logistic2 = txtPODNo_Add0.Text.Trim();
            }

            if (ddlLogisticType_Add.SelectedItem.ToString() == "Transport")
            {
                logistic1 = txtLogisticDetails_Add.Text.Trim();
                logistic2 = txtVechicleNo_Add.Text.Trim();
            }

            if (ddlLogisticType_Add.SelectedItem.ToString() == "In Person")
            {
                logistic1 = txtLogisticDetails_Add.Text.Trim();
                logistic2 = "";
            }

            //


            ResultId = ProductController.Insert_ChkGRNInward(7, Supplier_Code, txtDCNO.Text.Trim(), txtDCDate.Value.ToString().Trim());
            if (ResultId == "1")
            {
                ResultId = ProductController.Insert_GRNInward(1, Supplier_Code, txtDCNO.Text.Trim(), txtDCDate.Value.ToString().Trim(), txtInvoiceNo_Add.Text.Trim(), Total_Item_Count, Total_Purchase_Amount, 1, PONo, PoFlag, CreatedBy, 0, txtInvoiceDT.Value.ToString().Trim(), invoiceval, ddlTransferFR_SR.SelectedValue.ToString().Trim(), Transfer_LocationCode, Total_Quantity, ddlLogisticType_Add.SelectedValue.ToString().Trim(), logistic1, logistic2, 0, ddlbudgetDivision.SelectedValue.ToString().Trim());

            }

            else
            {
                lblPkey.Text = ResultId;

                ResultId = ProductController.Update_GRNInward(6, Supplier_Code, txtDCNO.Text.Trim(), txtDCDate.Value.ToString().Trim(), txtInvoiceNo_Add.Text.Trim(), Total_Item_Count, Total_Purchase_Amount, 1, PONo, PoFlag, CreatedBy, lblPkey.Text.Trim(), txtDCDate.Value.ToString().Trim(), 1, txtInvoiceDT.Value.ToString().Trim(), invoiceval, ddlTransferFR_SR.SelectedValue.ToString().Trim(), Transfer_LocationCode, Total_Quantity, ddlLogisticType_Add.SelectedValue.ToString().Trim(), logistic1, logistic2, 0, ddlbudgetDivision.SelectedValue.ToString().Trim());

            }



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
                foreach (DataListItem item in DataList4.Items)
                {

                    if (item.ItemType == ListItemType.Item | item.ItemType == ListItemType.AlternatingItem)
                    {

                        Label lblMaterialCode_DT = (Label)item.FindControl("lblMaterialCode_DT");
                        Label lblMaterialName_DT = (Label)item.FindControl("lblMaterialName_DT");
                        Label lblPoQty_DT = (Label)item.FindControl("lblPoQty_DT");
                        TextBox txtChallanQty_DT = (TextBox)item.FindControl("txtChallanQty_DT");
                        Label lblRatePO_DT = (Label)item.FindControl("lblRatePO_DT");
                        Label lblValue_DT = (Label)item.FindControl("lblValue_DT");
                        Label lblBarcode_DT = (Label)item.FindControl("lblBarcode_DT");
                        //  Label lblSuppSerial = (Label)item.FindControl("lblSuppSerial");
                        Label lblpurchaseorder = (Label)item.FindControl("lblpurchaseorder");
                        Label lblIs_Authorised = (Label)item.FindControl("lblIs_Authorised");

                        icoun = icoun + 1;
                        string InwardEntry_Code = lblPkey.Text.Trim() + icoun.ToString();

                        ResultId1 = ProductController.Insert_GRNInward_Items(2, lblPkey.Text.Trim(), InwardEntry_Code, lblMaterialCode_DT.Text.Trim(), Convert.ToDouble(txtChallanQty_DT.Text.Trim()), Convert.ToDouble(lblRatePO_DT.Text.Trim()), Convert.ToDouble(lblValue_DT.Text.Trim()), 1, Convert.ToInt32(lblIs_Authorised.Text.Trim()), lblpurchaseorder.Text);

                        //if (lblbtnvisible.Text == "0")
                        //{
                        //    ResultId1 = ProductController.Usp_Insert_InwardItemDetails(10, lblPkey.Text.Trim(), InwardEntry_Code, lblBarcode_DT.Text.Trim(), lblBarcode_DT.Text.Trim(), 1, "AS00000002", "AC00000001", ddlbudgetDivision.SelectedValue.ToString().Trim());
                        //}

                    }
                }

            }

            if (ResultId1 == "1")
            {
                Show_Error_Success_Box("S", "Record Updated Successfully.");

                //

                string FromDate, ToDate, Supplier;
                if (id_date_range_picker_2.Value == "")
                {
                    FromDate = "";
                    ToDate = "";
                }
                else
                {
                    string DateRange = "";
                    DateRange = id_date_range_picker_2.Value;

                    FromDate = DateRange.Substring(0, 10);
                    ToDate = (DateRange.Length > 9) ? DateRange.Substring(DateRange.Length - 10, 10) : DateRange;
                }

                if (ddlSupplier_SR.SelectedIndex == 0 || ddlSupplier_SR.SelectedIndex == -1)
                {
                    Supplier = "";
                }
                else
                {
                    Supplier = ddlSupplier_SR.SelectedValue.ToString().Trim();
                }


                FillGrid(FromDate, ToDate, Supplier, txtChallan_SR.Text.Trim());
                Show_Error_Success_Box("S", "Record Updated Successfully.");
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

    private void RemoveDirectories(string strpath)
    {
        //This condition is used to delete all files from the Directory
        File.Delete(strpath);

    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {

        try
        {


            string grnno = lblPkey.Text;
            string DeleteThis = grnno;
            string[] Files = Directory.GetFiles(Server.MapPath("~") + "\\Uploads\\");

            foreach (string file in Files)
            {
                if (file.ToUpper().Contains(DeleteThis.ToUpper()))
                {
                    File.Delete(file);
                }
            }
            string fileName1 = Path.GetFileName(FileUpload1.PostedFile.FileName);
            string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
            string fileExtension = Path.GetExtension(FileUpload1.PostedFile.FileName);
            string path = Server.MapPath("~") + "\\Uploads\\";
            string strpath = path + grnno + fileExtension;







            if (fileExtension == ".xlsx" && grnno == grnno)
            {
                RemoveDirectories(strpath);
                //    //lblResult.Text = filename + " file deleted successfully";
                //    //lblResult.ForeColor = Color.Green;




            }
            if (fileExtension == ".csv" && grnno == grnno)
            {
                RemoveDirectories(strpath);

            }
            if (fileExtension == ".png" && grnno == grnno)
            {
                RemoveDirectories(strpath);

            }
            if (fileExtension == ".jpeg" && grnno == grnno)
            {
                RemoveDirectories(strpath);

            }

            if (fileExtension == ".jpg" && grnno == grnno)
            {
                RemoveDirectories(strpath);

            }
            if (fileExtension == ".zip" && grnno == grnno)
            {
                RemoveDirectories(strpath);

            }
            if (fileExtension == ".xls" && grnno == grnno)
            {
                RemoveDirectories(strpath);

            }
            if (fileExtension == ".xlsx" && grnno == grnno)
            {
                RemoveDirectories(strpath);

            }
            if (fileExtension == ".gif" && grnno == grnno)
            {
                RemoveDirectories(strpath);

            }






            //uploadfilename.Text = fileName1;

            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Uploads/") + fileName);
            string path1 = Server.MapPath("~") + "\\Uploads\\";
            string Fromfile = path1 + fileName;
            string Tofile = path1 + lblPkey.Text + fileExtension;
            File.Move(Fromfile, Tofile);
            string label = lblPkey.Text + fileExtension;
            lblGRN_No.Visible = true;
            lblGRN_No.Text = label;
            // string[] filePaths = Directory.GetFiles( Server.MapPath("~") + "\\Uploads\\"+grnno);



            //  string fileExtension = lblextension.Text;
            // string fileExtension = Path.GetExtension(FileUpload1.PostedFile.FileName);
            //// abc = UploadStatusLabel1.Text;
            // lblGRN_No.Visible = false;

            // string fileName1 = Path.GetFileName(FileUpload1.PostedFile.FileName);











            //   string strpath = (Server.MapPath("~/Uploads/") + lblGRN_No.Text + fileExtension);

            ////  string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);



            //  if (fileExtension == ".xlsx" || fileExtension == ".csv" || fileExtension == ".png" || fileExtension == ".jpeg" || fileExtension == ".zip" || fileExtension == ".xlsx" || fileExtension == ".xls")
            //  {
            //      RemoveDirectories(strpath);
            //      //    //lblResult.Text = filename + " file deleted successfully";
            //      //    //lblResult.ForeColor = Color.Green;
            //      //}



            //  }
            //  //if (fileExtension == ".csv")
            //  //{
            //  //    RemoveDirectories(strpath);

            //  //}
            //  //if (fileExtension == ".png")
            //  //{
            //  //    RemoveDirectories(strpath);

            //  //}
            //  //if (fileExtension == ".jpeg")
            //  //{
            //  //    RemoveDirectories(strpath);

            //  //}

            //  //if (fileExtension == ".jpeg")
            //  //{
            //  //    RemoveDirectories(strpath);

            //  //}
            //  //if (fileExtension == ".zip")
            //  //{
            //  //    RemoveDirectories(strpath);

            //  //}
            //  //if (fileExtension == ".xls")
            //  //{
            //  //    RemoveDirectories(strpath);

            //  //}
            //  //if (fileExtension == ".xlsx")
            //  //{
            //  //    RemoveDirectories(strpath);

            //  //}
            //  FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Uploads/") + fileName);
            //  string path = Server.MapPath("~") + "\\Uploads\\";
            //  string Fromfile = path + fileName;
            //  string Tofile = path + lblGRN_No.Text + fileExtension;
            //  File.Move(Fromfile, Tofile);





            lblfilename.Text = fileName;
            lblextension.Text = fileExtension;

            UploadStatusLabel1.Text = fileName;
            UploadStatusLabel1.Visible = false;
            // lblGRN_No.Visible = true;



        }
        catch (Exception ex)
        {

        }


    }
    protected void BtnDownloadExcel_ServerClick(object sender, System.EventArgs e)
    {
        try
        {
            //DataList2.Visible = true;
            //Response.Clear();
            //Response.Buffer = true;
            //Response.ContentType = "application/vnd.csv";
            //string filenamexls1 = "Serial_No.csv";
            //Response.AddHeader("Content-Disposition", "inline;filename=" + filenamexls1);
            //HttpContext.Current.Response.Charset = "utf-8";
            //HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");
            ////sets font
            //HttpContext.Current.Response.Write("<font style='font-size:10.0pt; font-family:Calibri;'>");
            //HttpContext.Current.Response.Write("<BR><BR><BR>");
            //HttpContext.Current.Response.Write("<Table border='1'  borderColor='#000000' cellSpacing='0' cellPadding='0' style='font-size:14.0pt; font-family:Calibri; text-align:center;'><TR><TD>lblSRNo</TD><TD>txtItemSerialNo</TD><TD>txtItemBarcodeNo</TD></TR>");
            //Response.Charset = "";
            //this.EnableViewState = false;
            //System.IO.StringWriter oStringWriter1 = new System.IO.StringWriter();
            //System.Web.UI.HtmlTextWriter oHtmlTextWriter1 = new System.Web.UI.HtmlTextWriter(oStringWriter1);
            ////this.ClearControls(dladmissioncount)
            //DataList2.RenderControl(oHtmlTextWriter1);
            //Response.Write(oStringWriter1.ToString());
            //Response.Flush();
            //Response.End();
            //DataList2.Visible = false;

            DivAddBarcode.Visible = true;
            //To Get the physical Path of the file(me2.doc)
            string filepath = Server.MapPath("~/Template/Asset_Template.csv");



            // Create New instance of FileInfo class to get the properties of the file being downloaded
            FileInfo myfile = new FileInfo(filepath);

            // Checking if file exists
            if (myfile.Exists)
            {
                // Clear the content of the response
                Response.ClearContent();

                // Add the file name and attachment, which will force the open/cancel/save dialog box to show, to the header
                Response.AddHeader("Content-Disposition", "attachment; filename=" + myfile.Name);

                // Add the file size into the response header
                Response.AddHeader("Content-Length", myfile.Length.ToString());

                // Set the ContentType
                //Response.ContentType = ReturnExtension(myfile.Extension.ToLower());

                // Write the file into the response (TransmitFile is for ASP.NET 2.0. In ASP.NET 1.1 you have to use WriteFile instead)
                Response.TransmitFile(myfile.FullName);

                // End the response
                Response.End();
            }

        }
        catch (Exception ex)
        {
        }

    }


    protected void DataList4_ItemCommand(object source, DataListCommandEventArgs e)
    {


    }

    protected void txtRatePO_DT_TextChanged(object sender, EventArgs e)
    {
        //Label lblChallanQty_DT = (Label)(DataList4.FindControl("lblChallanQty_DT"));
        //TextBox txtRatePO_DT = (TextBox)(DataList4.FindControl("lblRatePO_DT"));
        //Label lblValue_DT = (Label)item.FindControl("lblValue_DT");
        //TextBox txtValue_DT = (TextBox)(DataList4.FindControl("lblValue_DT"));


        //txtValue_DT.Text = txtRatePO_DT.Text + ", " + lblChallanQty_DT.text; 

        //txtValue_DT.Text = (Int32.Parse(txtRatePO_DT.Text) * (Int32.Parse(lblChallanQty_DT.Text))).ToString();

        //TextBox txtRatePO_DT = (TextBox)DataList4.FindControl("lblRatePO_DT");
        //TextBox percentage = (TextBox)gVAppraisal.Rows[((sender as TextBox).NamingContainer as GridViewRow).RowIndex].Cells[2].FindControl("txtPercentage");
        //TextBox score = (TextBox)gVAppraisal.Rows[((sender as TextBox).NamingContainer as GridViewRow).RowIndex].Cells[2].FindControl("txtScore");
        //score.Text = (Int32.Parse(percentage.Text) * (Int32.Parse(txtWeightage.Text))).ToString();


        foreach (DataListItem item in DataList4.Items)
        //{
        //    if (item.ItemType == ListItemType.Item | item.ItemType == ListItemType.AlternatingItem)
        {
            Label lblValue_DT = (Label)item.FindControl("lblValue_DT");
            TextBox txtChallanQty_DT = (TextBox)item.FindControl("txtChallanQty_DT");
            Label lblRatePO_DT = (Label)item.FindControl("lblRatePO_DT");
            Double Total = 0;
            Total = Convert.ToDouble(lblRatePO_DT.Text) * Convert.ToDouble(txtChallanQty_DT.Text);
            lblValue_DT.Text = Convert.ToString(Total);

        }


    }

    protected void BtnUploadExcel_ServerClick(object sender, System.EventArgs e)
    {
        try
        {
            if (!string.IsNullOrEmpty(FFLExcel.FileName))
            {
                lbluploadfileName.Text = Path.GetFileName(FFLExcel.FileName);
                string FullName = Server.MapPath("~/Uploads") + "\\" + Path.GetFileName(FFLExcel.FileName);
                lblfilepath.Text = FullName;
                string strFileType = Path.GetExtension(FFLExcel.FileName).ToLower();
                if (strFileType != ".csv")
                {

                }

                else
                {
                    FFLExcel.SaveAs(FullName);

                    DataTable dtRaw = new DataTable();

                    FileStream fileStream = new FileStream(FullName, FileMode.Open);
                    CSVReader reader = new CSVReader(fileStream);
                    //get the header
                    string[] headers = reader.GetCSVLine();

                    //add headers
                    foreach (string strHeader in headers)
                    {
                        dtRaw.Columns.Add(strHeader);

                    }
                    DataRow NewRow = null;
                    int CurRowNo = 0;


                    //  DateTime.ParseExact(lblP_O_Date.Text.Trim(), "MM/dd/yyyy", null).ToString("dd/MM/yyyy");

                    string[] data = null;


                    data = reader.GetCSVLine();
                    //Read first line
                    CurRowNo = 1;
                    while (data != null)
                    {
                        dtRaw.Rows.Add(data);


                    NextCSVLine:


                        data = reader.GetCSVLine();
                        //Read next line
                        CurRowNo = CurRowNo + 1;
                    }

                    DataList2.DataSource = dtRaw;
                    string aa;
                    aa = Convert.ToString(dtRaw.Rows.Count);
                    //{
                    if (aa != lblqty.Text)
                    {
                        Show_Error_Success_Box("E", "Qty not match with challan qty");
                        return;
                    }
                    //if(aa=Convert.ToInt32(lblqty.Text))
                    //{

                    DataList2.DataBind();
                    DataList2.Visible = true;
                    // Divbtnimport.Visible = true;
                    Msg_Error.Visible = false;


                }


            }
            else
            {
                Msg_Error.Visible = true;
                Msg_Success.Visible = false;
                lblerror.Text = "Please Select File...!";
                // Divbtnimport.Visible = false;
                return;
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void btnDivAssetConfirmYes_Click(object sender, System.EventArgs e)
    {

        try
        {
            string Result = "", ResultId = "", CreatedBy;
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            CreatedBy = cookie.Values["UserID"];

            if (txtItemName_BR.Text.Trim() == "")
            {
                Show_Error_Success_Box("E", "Select Item");
                txtItemName_BR.Focus();
                return;
            }
            if (lblAssetesNoTypeID.Text == "ATN00000002")
            {

                Result = ProductController.Usp_Delete_InwardItemDetails(11, lblInwardCode_BR.Text.Trim(), lblInwardEbtryCode_BR.Text.Trim());
            }

            // Result = ProductController.Usp_Delete_InwardItemDetails(11, lblInwardCode_BR.Text.Trim(), lblInwardEbtryCode_BR.Text.Trim());

            foreach (DataListItem item in DataList2.Items)
            {
                if (item.ItemType == ListItemType.Item | item.ItemType == ListItemType.AlternatingItem)
                {
                    Label lblSRNo = (Label)item.FindControl("lblSRNo");
                    TextBox txtItemSerialNo = (TextBox)item.FindControl("txtItemSerialNo");
                    TextBox txtSAPAsset = (TextBox)item.FindControl("txtSAPAsset");
                    TextBox txtItemBarcodeNo = (TextBox)item.FindControl("txtItemBarcodeNo");
                    Label lblResult = (Label)item.FindControl("lblResult");
                    //Check if Serial No, Barcode No is Blank

                    if (lblAssetesNoTypeID.Text == "ATN00000002")
                    {

                        ResultId = ProductController.Usp_Insert_InwardItemDetails(10, lblInwardCode_BR.Text.Trim(), lblInwardEbtryCode_BR.Text.Trim(), txtItemSerialNo.Text.Trim(), txtItemBarcodeNo.Text.Trim(), 1, "AS00000002", "AC00000001", ddlbudgetDivision.SelectedValue.ToString().Trim(), txtSAPAsset.Text.Trim(), CreatedBy);
                    }
                    else if (lblAssetesNoTypeID.Text == "ATN00000003")
                    {
                        ResultId = ProductController.Usp_Insert_InwardItemDetails(20, lblInwardCode_BR.Text.Trim(), lblInwardEbtryCode_BR.Text.Trim(), txtItemSerialNo.Text.Trim(), txtItemBarcodeNo.Text.Trim(), 1, "AS00000002", "AC00000001", ddlbudgetDivision.SelectedValue.ToString().Trim(), txtSAPAsset.Text.Trim(), CreatedBy);
                    }


                    if (ResultId == "1")
                    {
                        lblResult.ForeColor = System.Drawing.Color.Green;
                        lblResult.Text = "Success";
                        Show_Error_Success_Box("S", "Record saved Successfully.");
                    }
                    else
                    {
                        lblResult.ForeColor = System.Drawing.Color.Red;
                        lblResult.Text = "Error";
                    }

                    //}
                    //else
                    //{
                    //    lblResult.ForeColor = System.Drawing.Color.Red;
                    //    lblResult.Text = "Error : Invalid Entry";
                    //    cnttrue = cnttrue + 1;
                    //}
                }
            }
            if (lblAssetesNoTypeID.Text == "ATN00000003")
            {
                Fill_data();
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
}