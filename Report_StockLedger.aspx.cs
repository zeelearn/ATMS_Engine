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

public partial class Report_StockLedger : System.Web.UI.Page
{
    #region PageLoad
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                ControlVisibility("Search");

                FillDDL_Item();
                //Clear_TempChallan();
                FillDDL_Division();
                FillDDL_TransferType();
                //FillDDL_Logistic();
                FillDDL_Godown_SR();
                FillDDL_Function_Search();
                //FillDDL_FRSearch_Centre_Search();
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
        //ddlCenterFR_SRSearch.SelectedIndex = 0;

        FillDDL_FRSearch_Centre_Search();
    }
    private void FillDDL_FRSearch_Centre_Search()
    {
        //ddlCenterFR_SRSearch.SelectedIndex = 0;
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
        ddlCenterFR_SRSearch.SelectedIndex = 0;
         
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
        if (ddlLocationType.SelectedItem.ToString().Trim() == "Godown")
        {
            tblgodown.Visible = true;
            tblFunction.Visible = false;
            tblDivision.Visible = false;
            tblCenter.Visible = false;
            FillDDL_Godown_SR();
            //ddlDivisionFR_SRSearch.SelectedIndex = 0;
            //ddldivision_Search_SelectedIndexChanged(sender,e);
        }
        else if (ddlLocationType.SelectedItem.ToString().Trim() == "Function")
        {
            tblFunction.Visible = true;
            tblgodown.Visible = false;
            tblDivision.Visible = false;
            tblCenter.Visible = false;
            FillDDL_Function_Search();
        }
        else if (ddlLocationType.SelectedItem.ToString().Trim() == "Center")
        {
            ddlDivisionFR_SRSearch.SelectedIndex = 0;
            ddldivision_Search_SelectedIndexChanged(sender, e);
            //ddlCenterFR_SRSearch.SelectedIndex = 0;
            //ddlFunctionFR_SRSearch.Items.Clear();
            //ddlCenterFR_SRSearch.Items.Clear();

            tblDivision.Visible = true;
            tblCenter.Visible = true;
            tblFunction.Visible = false;
            tblgodown.Visible = false;

            //Fill Division
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];

        }
        else if (ddlLocationType.SelectedIndex == 0 || ddlLocationType.SelectedIndex == -1)
        {
            tblgodown.Visible = false;
            tblFunction.Visible = false;
            tblDivision.Visible = false;
            tblCenter.Visible = false;
        }
    }

    private void FillDDL_Division()
    {
        //ddlDivisionFR_SRSearch.SelectedIndex=0;
        ddlCenterFR_SRSearch.Items.Clear();
        ddlDivisionFR_SRSearch.Items.Clear();
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

        BindDDL(ddlDivisionFR_SRSearch, dsDivision, "Division_Name", "Division_Code");
        ddlDivisionFR_SRSearch.Items.Insert(0, "Select Division");
        ddlDivisionFR_SRSearch.SelectedIndex = 0;

        
        //BindDDL(ddlDivision_Auth, dsDivision, "Division_Name", "Division_Code");
        //ddlDivision_Auth.Items.Insert(0, "Select Division");
        //ddlDivision_Auth.SelectedIndex = 0;

        //BindDDL(ddlbudgetDivision, dsDivision, "Division_Name", "Division_Code");
        //ddlbudgetDivision.Items.Insert(0, "Select Division");
        //ddlbudgetDivision.SelectedIndex = 0;

    }
    private void FillDDL_Item()
    {
        DataSet dsItem = ProductController.GetAllItem();
        BindDDL(ddlItemNme_SR, dsItem, "Item_Name", "Item_Code");
        ddlItemNme_SR.Items.Insert(0, "Select");
        ddlItemNme_SR.SelectedIndex = 0;

    }

     private void FillDDL_Godown_SR()
    {
        ddlgodownFR_SRSearch.Items.Clear();
        DataSet dsTransfer_Tp = ProductController.GetGodown_Function_Logistic_Assests_Type(1);
        BindDDL(ddlgodownFR_SRSearch, dsTransfer_Tp, "Godown_Name", "Godown_Id");
        ddlgodownFR_SRSearch.Items.Insert(0, "Select Godown");
        ddlgodownFR_SRSearch.SelectedIndex = 0;
    }
       private void FillDDL_Function_Search()
    {
        ddlFunctionFR_SRSearch.Items.Clear();
        DataSet dsTransfer_Tp = ProductController.GetGodown_Function_Logistic_Assests_Type(2);
        BindDDL(ddlFunctionFR_SRSearch, dsTransfer_Tp, "Function_Name", "Function_Id");
        ddlFunctionFR_SRSearch.Items.Insert(0, "Select Function");
        ddlFunctionFR_SRSearch.SelectedIndex = 0;
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

        BindDDL(ddlLocationType, dsTransfer_Tp, "Transfer_Location_Type_Name", "Transfer_Location_Type_ID");
        ddlLocationType.Items.Insert(0, "Select Location");
        ddlLocationType.SelectedIndex = 0;

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
        ddlItemNme_SR.SelectedIndex = 0;
        id_date_range_picker_2.Value = "";
        
        ddlLocationType.SelectedIndex = 0;
        ddlgodownFR_SRSearch.Items.Clear();
        ddlDivisionFR_SRSearch.SelectedIndex = 0;
        ddlFunctionFR_SRSearch.Items.Clear();
        ddlCenterFR_SRSearch.Items.Clear();

    }

    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            Clear_Error_Success_Box();
            string From_Location_Type = "";
            string From_Location_Code = "";
            if (ddlLocationType.SelectedIndex == 0 || ddlLocationType.SelectedIndex == -1)
            {
                Show_Error_Success_Box("E", "Select Location Type");
                ddlLocationType.Focus();
                return;
            }
            else
            {
                From_Location_Type = ddlLocationType.SelectedValue.ToString().Trim();
            }

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
                    From_Location_Code = ddlgodownFR_SRSearch.SelectedValue.ToString();
                lblLocationResult.Text = ddlgodownFR_SRSearch.SelectedItem.ToString();

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
                    From_Location_Code = ddlFunctionFR_SRSearch.SelectedValue.ToString();
                lblLocationResult.Text = ddlFunctionFR_SRSearch.SelectedItem.ToString();
            }
            else if (ddlLocationType.SelectedItem.ToString() == "Center")
            {
               // ddlCenterFR_SRSearch.Items.Clear();
                // ddlCenterFR_SRSearch.SelectedIndex = 0;
                if (ddlDivisionFR_SRSearch.SelectedIndex == 0)
                {
                    tblCenter.Visible = false;
                    Show_Error_Success_Box("E", "Select Division");
                    ddlDivisionFR_SRSearch.Focus();
                    return;
                }
                else if (ddlCenterFR_SRSearch.SelectedIndex == 0)
                {
                    tblCenter.Visible = true;
                    Show_Error_Success_Box("E", "Select Center");
                    ddlCenterFR_SRSearch.Focus();
                    return;
                }
                else
                    From_Location_Code = ddlCenterFR_SRSearch.SelectedValue.ToString();
                lblLocationResult.Text = ddlCenterFR_SRSearch.SelectedItem.ToString();
            }

            string FromDate, ToDate, ItemCode;
            if (ddlItemNme_SR.SelectedIndex == 0 || ddlItemNme_SR.SelectedIndex == -1)
            {
                Show_Error_Success_Box("E", "Select Item");
                ddlItemNme_SR.Focus();
                return;
            }
            else
            {
                ItemCode = ddlItemNme_SR.SelectedValue.ToString().Trim();
            }

            
            if (id_date_range_picker_2.Value == "")
            {
                Show_Error_Success_Box("E", "Select Period");
                id_date_range_picker_2.Focus();
                return;
            }
            else
            {
                string DateRange = "";
                DateRange = id_date_range_picker_2.Value;

                FromDate = DateRange.Substring(0, 10);
                ToDate = (DateRange.Length > 9) ? DateRange.Substring(DateRange.Length - 10, 10) : DateRange;
            }

            


            FillGrid(From_Location_Type, From_Location_Code, FromDate, ToDate, ItemCode);
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

    private void FillGrid(string Location_Type, string Location_Code, string fromdate, string todate, string ItemCode)
    {
        try
        {
            Clear_Error_Success_Box();

            ControlVisibility("Result");
            lblLocationType_Result.Text = ddlLocationType.SelectedItem.ToString().Trim();
            lblItemName.Text = ddlItemNme_SR.SelectedItem.ToString().Trim();
            lblPeriod.Text = id_date_range_picker_2.Value;

            DataSet dsGrid = ProductController.Get_StockLedger_RPT(Location_Type, Location_Code, fromdate, todate, ItemCode);
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