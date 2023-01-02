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



public partial class Opening_Stock_Report : System.Web.UI.Page
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


    private void FillDDL_FRSearch_Centre()
    {
        string Company_Code = "MT";
        string DBname = "CDB";

        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];

        //string Div_Code = null;
        //Div_Code = ddlDivisionFR_SR.SelectedValue;

        //DataSet dsCentre = ProductController.GetAllActiveUser_Company_Division_Zone_Center(UserID, Company_Code, Div_Code, "", "5", DBname);

        //BindDDL(ddlCenterFR_SR, dsCentre, "Center_Name", "Center_Code");
        //ddlCenterFR_SR.Items.Insert(0, "Select");
        //ddlCenterFR_SR.SelectedIndex = 0;
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
        //Div_Code = ddlDivisionFR_SRAuthorise.SelectedValue;

        //DataSet dsCentre = ProductController.GetAllActiveUser_Company_Division_Zone_Center(UserID, Company_Code, Div_Code, "", "5", DBname);

        //BindDDL(ddlCenterFR_SRAuthorise, dsCentre, "Center_Name", "Center_Code");
        //ddlCenterFR_SRAuthorise.Items.Insert(0, "Select");
        //ddlCenterFR_SRAuthorise.SelectedIndex = 0;
    }

    private void FillDDL_TransferType()
    {
        //Search DDL
        DataSet dsTransfer_Tp = ProductController.GetAllTransferType(1);
        BindDDL(ddlLocationType, dsTransfer_Tp, "Transfer_Location_Type_Name", "Transfer_Location_Type_ID");
        ddlLocationType.Items.Insert(0, "Select Location");
        ddlLocationType.SelectedIndex = 0;

        //BindDDL(ddlTransferFR_SR, dsTransfer_Tp, "Transfer_Location_Type_Name", "Transfer_Location_Type_ID");
        //ddlTransferFR_SR.Items.Insert(0, "Select Location");
        //ddlTransferFR_SR.SelectedIndex = 0;

        //BindDDL(ddlTransferFR_SRAuthorise, dsTransfer_Tp, "Transfer_Location_Type_Name", "Transfer_Location_Type_ID");
        //ddlTransferFR_SRAuthorise.Items.Insert(0, "Select Location");
        //ddlTransferFR_SRAuthorise.SelectedIndex = 0;
        
    }


    private void FillDDL_Godown()
    {
       // ddlgodownFR_SR.Items.Clear();
        ddlgodownFR_SRSearch.Items.Clear();
        DataSet dsTransfer_Tp = ProductController.GetGodown_Function_Logistic_Assests(1, ddlgodownFR_SRSearch.Text);
        BindDDL(ddlgodownFR_SRSearch, dsTransfer_Tp, "Godown_Name", "Godown_Id");
        ddlgodownFR_SRSearch.Items.Insert(0, "Select Godown");
       // ddlgodownFR_SRSearch.SelectedIndex = 0;
        //ddlgodownFR_SRSearch.Items.Insert(1, "All");
        

        //BindDDL(ddlgodownFR_SR, dsTransfer_Tp, "Godown_Name", "Godown_Id");
        //ddlgodownFR_SR.Items.Insert(0, "Select Godown");
        //ddlgodownFR_SR.SelectedIndex = 0;

        //BindDDL(ddlgodownFR_SRAuthorise, dsTransfer_Tp, "Godown_Name", "Godown_Id");
        //ddlgodownFR_SRAuthorise.Items.Insert(0, "Select Godown");
        //ddlgodownFR_SRAuthorise.SelectedIndex = 0;
        
    }

    private void FillDDL_Function()
    {
        //ddlFunctionFR_SR.Items.Clear();
        ddlFunctionFR_SRSearch.Items.Clear();
        DataSet dsTransfer_Tp = ProductController.GetGodown_Function_Logistic_Assests_Type(2);
        BindDDL(ddlFunctionFR_SRSearch, dsTransfer_Tp, "Function_Name", "Function_Id");
        ddlFunctionFR_SRSearch.Items.Insert(0, "Select Function");
        ddlFunctionFR_SRSearch.SelectedIndex = 0;

        //BindDDL(ddlFunctionFR_SR, dsTransfer_Tp, "Function_Name", "Function_Id");
        //ddlFunctionFR_SR.Items.Insert(0, "Select Function");
        //ddlFunctionFR_SR.SelectedIndex = 0;

        //BindDDL(ddlFunctionFR_SRAuthorise, dsTransfer_Tp, "Function_Name", "Function_Id");
        //ddlFunctionFR_SRAuthorise.Items.Insert(0, "Select Function");
        //ddlFunctionFR_SRAuthorise.SelectedIndex = 0;
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

        //BindDDL(ddlDivisionFR_SR, dsDivision, "Division_Name", "Division_Code");
        //ddlDivisionFR_SR.Items.Insert(0, "Select");
        //ddlDivisionFR_SR.SelectedIndex = 0;

        //BindDDL(ddlDivisionFR_SRAuthorise, dsDivision, "Division_Name", "Division_Code");
        //ddlDivisionFR_SRAuthorise.Items.Insert(0, "Select");
        //ddlDivisionFR_SRAuthorise.SelectedIndex = 0;

        //BindDDL(ddlDivision, dsDivision, "Division_Name", "Division_Code");
        //ddlDivision.Items.Insert(0, "Select");
        //ddlDivision.SelectedIndex = 0;
        

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
            //DivAddPanel.Visible = false;
            DivSearchPanel.Visible = true;
            //BtnAdd.Visible = true;
            //BtnSaveAdd.Visible = true;
           // BtnSaveEdit.Visible = false;
            DivResultPanel.Visible = false;
            //DivAddBarcode.Visible = false;
            //DivAuthorise.Visible = false;
            //RadioButton1.Checked = false;
            //RadioButton2.Checked = false;

        }
        else if (Mode == "Result")
        {
            //DivAddBarcode.Visible = false;
            //DivAddPanel.Visible = false;
            DivSearchPanel.Visible = false;
            //BtnAdd.Visible = false;
            DivResultPanel.Visible = true;
            //DivAuthorise.Visible = false;
            //lblPkey.Text = "";

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
            
             string Transfer_LocationCode = "",Div_Code="";
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
                    Div_Code = ddlDivisionFR_SRSearch.SelectedValue;
                }

                lblLocationType_Result.Text = ddlDivisionFR_SRSearch.SelectedItem.ToString().Trim();
            }

            Label lblHeader_User_Code = default(Label);
            lblHeader_User_Code = (Label)Master.FindControl("lblHeader_User_Code");

            string CreatedBy = null;
           // CreatedBy = lblHeader_User_Code.Text;
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            CreatedBy = cookie.Values["UserID"];

            string ResultId = ProductController.Insert_OpeningStock_Inward(1, ddlLocationType.SelectedValue, Transfer_LocationCode, CreatedBy);
            //lblPkey.Text = ResultId;

            //DataSet dsGrid = ProductController.Get_Fill_OpeninfStockDetails(1, ddlLocationType.SelectedValue.ToString(), Transfer_LocationCode,"");
            //dlGridDisplay.DataSource = dsGrid;
            //dlGridDisplay.DataBind();

            //DataList1.DataSource = dsGrid;
            //DataList1.DataBind();

            DataSet dsItems = null;
            try
            {

                dsItems = Report.Get_Report_OpeningStock(2, "", ddlLocationType.SelectedValue, Div_Code, Transfer_LocationCode,"", CreatedBy);
                if (dsItems.Tables[0].Rows.Count > 0)
                {
                    dlGridDisplay.DataSource = dsItems;
                    dlGridDisplay.DataBind();
                    ControlVisibility("Result");
                }
                else
                {
                    Msg_Error.Visible = true;
                    Msg_Success.Visible = false;
                    lblSuccess.Text = "";
                    lblerror.Text = "Records not found...!";
                    UpdatePanelMsgBox.Update();
                }
            }
            catch (Exception ex)
            {
                Msg_Error.Visible = true;
                Msg_Success.Visible = false;
                lblSuccess.Text = "";
                lblerror.Text = ex.ToString();
                UpdatePanelMsgBox.Update();
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

    protected void ddlDivisionFR_SRSearch_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlCenterFR_SRSearch.Items.Clear();
        FillDDL_FRSearch_Centre_Search();
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




    protected void HLExport_Click(object sender, EventArgs e)
    {
      
        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        string filenamexls1 = "Opening Stock_Report_" + DateTime.Now + ".xls";
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
        dlGridDisplay.RenderControl(oHtmlTextWriter1);
        Response.Write(oStringWriter1.ToString());
        Response.Flush();
        Response.End();
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





    

    #endregion



    protected void dlItemListAuthorise_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}


