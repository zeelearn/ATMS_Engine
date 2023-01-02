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

public partial class Report_GRM : System.Web.UI.Page
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
    protected void ddldivision_Search_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillDDL_FRSearch_Centre_Search();
    }
    private void FillDDL_FRSearch_Centre_Search()
    {
        string Company_Code = "MT";
        string DBname = "CDB";

        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];

        string Div_Code = null;
        //Div_Code = ddlDivisionFR_SR.SelectedValue;

        DataSet dsCentre = ProductController.GetAllActiveUser_Company_Division_Zone_Center(UserID, Company_Code, Div_Code, "", "5", DBname);

        BindDDL(ddlCenter_Search, dsCentre, "Center_Name", "Center_Code");
        ddlCenter_Search.Items.Insert(0, "Select");
        ddlCenter_Search.SelectedIndex = 0;
    }
    private void BindDDL(DropDownList ddl, DataSet ds, string txtField, string valField)
    {
        ddl.DataSource = ds;
        ddl.DataTextField = txtField;
        ddl.DataValueField = valField;
        ddl.DataBind();
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

    private void FillDDL_Division()
    {
        string Company_Code = "MT";
        string DBname = "CDB";

        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];

        //Search DDL
        DataSet dsDivision = ProductController.GetAllActiveUser_Company_Division_Zone_Center(UserID, Company_Code, "", "", "2", DBname);
        //BindDDL(ddlDivisionFR_SR, dsDivision, "Division_Name", "Division_Code");
        //ddlDivisionFR_SR.Items.Insert(0, "Select Division");
        //ddlDivisionFR_SR.SelectedIndex = 0;

        BindDDL(ddldivision_Search, dsDivision, "Division_Name", "Division_Code");
        ddldivision_Search.Items.Insert(0, "Select Division");
        ddldivision_Search.SelectedIndex = 0;

        //BindDDL(ddlDivision_Auth, dsDivision, "Division_Name", "Division_Code");
        //ddlDivision_Auth.Items.Insert(0, "Select Division");
        //ddlDivision_Auth.SelectedIndex = 0;

        //BindDDL(ddlbudgetDivision, dsDivision, "Division_Name", "Division_Code");
        //ddlbudgetDivision.Items.Insert(0, "Select Division");
        //ddlbudgetDivision.SelectedIndex = 0;

    }
    private void FillDDL_Supplier()
    {
        DataSet dsSupplier = ProductController.GetAllSupplier();
        //BindDDL(ddlSupplier_Add, dsSupplier, "Vendor_Name", "Vendor_Id");
        //ddlSupplier_Add.Items.Insert(0, "Select");
        //ddlSupplier_Add.SelectedIndex = 0;

        BindDDL(ddlSupplier_SR, dsSupplier, "Vendor_Name", "Vendor_Id");
        ddlSupplier_SR.Items.Insert(0, "Select");
        ddlSupplier_SR.SelectedIndex = 0;

        //BindDDL(ddlSupplier_Auth, dsSupplier, "Vendor_Name", "Vendor_Id");
        //ddlSupplier_Auth.Items.Insert(0, "Select");
        //ddlSupplier_Auth.SelectedIndex = 0;

    }

     private void FillDDL_Godown_SR()
    {
        ddlGodown_Search.Items.Clear();
        DataSet dsTransfer_Tp = ProductController.GetGodown_Function_Logistic_Assests_Type(1);
        BindDDL(ddlGodown_Search, dsTransfer_Tp, "Godown_Name", "Godown_Id");
        ddlGodown_Search.Items.Insert(0, "Select Godown");
        ddlGodown_Search.SelectedIndex = 0;
    }
       private void FillDDL_Function_Search()
    {
        ddlFunction_Search.Items.Clear();
        DataSet dsTransfer_Tp = ProductController.GetGodown_Function_Logistic_Assests_Type(2);
        BindDDL(ddlFunction_Search, dsTransfer_Tp, "Function_Name", "Function_Id");
        ddlFunction_Search.Items.Insert(0, "Select Function");
        ddlFunction_Search.SelectedIndex = 0;
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
            DivSearchPanel.Visible = true;
            DivResultPanel.Visible = false;
            
        }
        else if (Mode == "Result")
        {
            DivSearchPanel.Visible = false;
            DivResultPanel.Visible = true;
            
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




   
    
    private void FillDDL_TransferType()
    {
        //Search DDL
        DataSet dsTransfer_Tp = ProductController.GetAllTransferType(1);
        //BindDDL(ddlTransferFR_SR, dsTransfer_Tp, "Transfer_Location_Type_Name", "Transfer_Location_Type_ID");
        //ddlTransferFR_SR.Items.Insert(0, "Select Location");
        //ddlTransferFR_SR.SelectedIndex = 0;

        BindDDL(ddllocation_Search, dsTransfer_Tp, "Transfer_Location_Type_Name", "Transfer_Location_Type_ID");
        ddllocation_Search.Items.Insert(0, "Select Location");
        ddllocation_Search.SelectedIndex = 0;

        //BindDDL(ddlLocation_Auth, dsTransfer_Tp, "Transfer_Location_Type_Name", "Transfer_Location_Type_ID");
        //ddlLocation_Auth.Items.Insert(0, "Select Location");
        //ddlLocation_Auth.SelectedIndex = 0;

    }





 





    #endregion
    protected void BtnClearSearch_Click(object sender, EventArgs e)
    {
        ClearSearchPanel();
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

            string From_Location_Type_Code = "";// 
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


            FillGrid(FromDate, ToDate, Supplier, txtChallan_SR.Text.Trim(), From_Location_Type_Code, From_Location_Code);
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

    private void FillGrid(string fromdate, string todate, string supplier, string challan, string From_Location_Type_Code, string From_Location_Code)
    {
        try
        {
            Clear_Error_Success_Box();

            ControlVisibility("Result");

            DataSet dsGrid = ProductController.Get_GRN_Report(fromdate, todate, supplier, challan, From_Location_Type_Code, From_Location_Code);
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

    protected void HLExport_Click(object sender, EventArgs e)
    {
        DataList1.Visible = true;

        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        string filenamexls1 = "GRN_Report" + DateTime.Now + ".xls";
        Response.AddHeader("Content-Disposition", "inline;filename=" + filenamexls1);
        HttpContext.Current.Response.Charset = "utf-8";
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");
        //sets font
        HttpContext.Current.Response.Write("<font style='font-size:10.0pt; font-family:Calibri;'>");
        HttpContext.Current.Response.Write("<BR><BR><BR>");
        HttpContext.Current.Response.Write("<Table border='1'  borderColor='#000000' cellSpacing='0' cellPadding='0' style='font-size:10.0pt; font-family:Calibri; text-align:center;'> <TR style='color: #fff; background: black;text-align:center;'><TD Colspan='15'>GRN Report</b></TD></TR>");
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
    protected void BtnShowSearchPanel_Click(object sender, EventArgs e)
    {
        ControlVisibility("Search");
        Clear_Error_Success_Box();
    }
}