using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ShoppingCart.BL;
using System.IO;
public partial class Rpt_ScrappedDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ControlVisibility("Search");
                FillDDL_LocationType();
                FillDDL_Division();
                FillDDL_Godown();
                FillDDL_Function();
                //FillDDL_Item();

            }
        }
        catch (Exception ex)
        {
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
        ddlDivisionFR_SR.Items.Insert(1, "All");
        ddlDivisionFR_SR.SelectedIndex = 0;

       

    }
    private void FillDDL_LocationType()
    {
        //Search DDL
        DataSet dsTransfer_Tp = ProductController.GetAllTransferType(1);
        BindDDL(ddlLocationType, dsTransfer_Tp, "Transfer_Location_Type_Name", "Transfer_Location_Type_ID");
        ddlLocationType.Items.Insert(0, "Select Location Type");
        ddlLocationType.Items.Insert(1, "All");
        ddlLocationType.SelectedIndex = 0;

    }

    private void FillDDL_Function()
    {
        ddlFunctionFR_SR.Items.Clear();
        DataSet dsTransfer_Tp = ProductController.GetGodown_Function_Logistic_Assests_Type(2);
        BindDDL(ddlFunctionFR_SR, dsTransfer_Tp, "Function_Name", "Function_Id");
        ddlFunctionFR_SR.Items.Insert(0, "Select Function");
        ddlFunctionFR_SR.Items.Insert(1, "All");
        ddlFunctionFR_SR.SelectedIndex = 0;
    }
    private void BindDDL(DropDownList ddl, DataSet ds, string txtField, string valField)
    {
        ddl.DataSource = ds;
        ddl.DataTextField = txtField;
        ddl.DataValueField = valField;
        ddl.DataBind();
    }
    protected void ddlLocationType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlLocationType.SelectedItem.ToString().Trim() == "Godown")
        {
            tblFr_Godown.Visible = true;
            tblFr_Function.Visible = false;
            tblFr_Division.Visible = false;
            tblFr_Center.Visible = false;
        }
        else if (ddlLocationType.SelectedItem.ToString().Trim() == "Function")
        {
            tblFr_Function.Visible = true;
            tblFr_Godown.Visible = false;
            tblFr_Division.Visible = false;
            tblFr_Center.Visible = false;
        }
        else if (ddlLocationType.SelectedItem.ToString().Trim() == "Center")
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
        else if (ddlLocationType.SelectedIndex == 0 || ddlLocationType.SelectedIndex == -1)
        {
            tblFr_Godown.Visible = false;
            tblFr_Function.Visible = false;
            tblFr_Division.Visible = false;
            tblFr_Center.Visible = false;
        }
        else if (ddlLocationType.SelectedItem.ToString().Trim() == "All")
        {
            tblFr_Division.Visible = false;
            tblFr_Center.Visible = false;
            tblFr_Function.Visible = false;
            tblFr_Godown.Visible = false;
        }
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
        ddlCenterFR_SR.Items.Insert(1, "All");
        ddlCenterFR_SR.SelectedIndex = 0;
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
        else if (Mode == "Add")
        {
            DivSearchPanel.Visible = false;
            DivResultPanel.Visible = false;
           
        }
        else if (Mode == "Edit")
        {
            DivSearchPanel.Visible = false;
            DivResultPanel.Visible = false;
        }
        else if (Mode == "Details")
        {
            DivSearchPanel.Visible = false;
            DivResultPanel.Visible = false;
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
    private void Clear_Error_Success_Box()
    {
        Msg_Error.Visible = false;
        Msg_Success.Visible = false;
        lblSuccess.Text = "";
        lblerror.Text = "";
        UpdatePanelMsgBox.Update();
    }
    private void FillDDL_Godown()
    {
        ddlgodownFR_SR.Items.Clear();

        DataSet dsTransfer_Tp = ProductController.GetGodown_Function_Logistic_Assests_Type(1);
        BindDDL(ddlgodownFR_SR, dsTransfer_Tp, "Godown_Name", "Godown_Id");
        ddlgodownFR_SR.Items.Insert(0, "Select Godown");
        ddlgodownFR_SR.Items.Insert(1, "All");
        ddlgodownFR_SR.SelectedIndex = 0;
    }
    private void ClearSearchPanel()
    {
        //From Content
        ddlLocationType.SelectedIndex = 0;
        ddlgodownFR_SR.SelectedIndex = 0;
        ddlDivisionFR_SR.SelectedIndex = 0;
        ddlFunctionFR_SR.SelectedIndex = 0;
        ddlCenterFR_SR.Items.Clear();

        //To Content

        date_range_SR.Value = "";
        tblFr_Godown.Visible = false;
        tblFr_Function.Visible = false;
        tblFr_Division.Visible = false;
        tblFr_Center.Visible = false;

       

    }
    protected void BtnClearSearch_Click(object sender, EventArgs e)
    {
        Clear_Error_Success_Box();
        ClearSearchPanel();
    }
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        string Location = "";
        Clear_Error_Success_Box();
        if (ddlLocationType.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "Select Location Type");
            ddlLocationType.Focus();
            return;
        }


        if (ddlLocationType.SelectedItem.ToString() == "Godown")
        {
            if (ddlgodownFR_SR.SelectedIndex == 0)
            {
                //Transfer_LocationCode = "%%";
                Show_Error_Success_Box("E", "Select Godown");
                ddlgodownFR_SR.Focus();
                return;
            }
            else
                Location = ddlgodownFR_SR.SelectedItem.ToString();

        }
        else if (ddlLocationType.SelectedItem.ToString() == "Function")
        {
            if (ddlFunctionFR_SR.SelectedIndex == 0)
            {
                //Transfer_LocationCode = "%%";
                Show_Error_Success_Box("E", "Select Function");
                ddlFunctionFR_SR.Focus();
                return;
            }
            else
                Location = ddlFunctionFR_SR.SelectedItem.ToString();
        }
        else if (ddlLocationType.SelectedItem.ToString() == "Center")
        {
            if (ddlDivisionFR_SR.SelectedIndex == 0)
            {
                Show_Error_Success_Box("E", "Select Division");
                ddlDivisionFR_SR.Focus();
                return;
            }
            else if (ddlCenterFR_SR.SelectedIndex == 0)
            {
                Show_Error_Success_Box("E", "Select Center");
                ddlCenterFR_SR.Focus();
                return;
            }
            else
                Location = ddlCenterFR_SR.SelectedItem.ToString();
        }


        ControlVisibility("Result");
        string Transfer_LocationCode = "";
        if (ddlLocationType.SelectedItem.ToString() == "Godown")
        {
            if ((ddlgodownFR_SR.SelectedIndex == 0) || (ddlgodownFR_SR.SelectedIndex == -1))
            {
                Transfer_LocationCode = "%%";
            }
            else
                Transfer_LocationCode = ddlgodownFR_SR.SelectedValue.ToString().Trim();
        }
        else if (ddlLocationType.SelectedItem.ToString() == "Function")
        {
            if (ddlFunctionFR_SR.SelectedIndex == 0)
            {
                Transfer_LocationCode = "%%";
            }
            else
                Transfer_LocationCode = ddlFunctionFR_SR.SelectedValue.ToString().Trim();
        }
        else if (ddlLocationType.SelectedItem.ToString() == "Center")
        {
            if (ddlDivisionFR_SR.SelectedIndex == 0)
            {
                Transfer_LocationCode = "%%";
            }
            else if (ddlCenterFR_SR.SelectedIndex == 0)
            {
                Transfer_LocationCode = "%%";
            }
            else
                Transfer_LocationCode = ddlCenterFR_SR.SelectedValue.ToString().Trim();
        }

        string DateRange = "";
        DateRange = date_range_SR.Value;
        string FromDate, ToDate;
        if (DateRange != "")
        {
            FromDate = DateRange.Substring(0, 10);
            ToDate = (DateRange.Length > 9) ? DateRange.Substring(DateRange.Length - 10, 10) : DateRange;
        }
        else
        {
             FromDate = "";
             ToDate = "";
        }

        try
        {
            lbltotalcount.Text = "0";
            DataSet dsGrid = ProductController.Get_Report_itemscrappedDetails(ddlLocationType.SelectedValue.ToString(), Transfer_LocationCode, FromDate, ToDate);
            dlGridDisplay.DataSource = dsGrid;
            dlGridDisplay.DataBind();


          //  DateTime dt = Convert.ToDateTime(FromDate);
            lblLocationType_Result.Text = ddlLocationType.SelectedItem.ToString();
            //lblPeroidResult.Text = dt.Day + "-" + dt.Month + "-" + dt.Year;
            //dt = Convert.ToDateTime(ToDate);
            lblPeroidResult.Text = date_range_SR.Value;
            lblLocationResult.Text = Location;
           // lblitem.Text = ddlitem_Name.SelectedItem.ToString();



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
            Show_Error_Success_Box("E", ex.ToString());
        }

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
    protected void BtnShowSearchPanel_Click(object sender, EventArgs e)
    {
        ControlVisibility("Search");
    }
    protected void HLExport_Click(object sender, EventArgs e)
    {

        //DataList1.Visible = true;

        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        string filenamexls1 = "Rpt_itemscrapped_details_" + DateTime.Now + ".xls";
        Response.AddHeader("Content-Disposition", "inline;filename=" + filenamexls1);
        HttpContext.Current.Response.Charset = "utf-8";
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");
        //sets font
        HttpContext.Current.Response.Write("<font style='font-size:10.0pt; font-family:Calibri;'>");
        HttpContext.Current.Response.Write("<BR><BR><BR>");
        // HttpContext.Current.Response.Write("<Table border='1'  borderColor='#000000' cellSpacing='0' cellPadding='0' style='font-size:10.0pt; font-family:Calibri; text-align:center;'> <TR style='color: #fff; background: black;text-align:center;'><TD Colspan='8'>PO Reprt Details</b></TD></TR><TR><TD Colspan='2'><b>Location Type : " + lblLocationType_Result.Text + "</b></TD><TD Colspan='2'><b>Location : " + lblLocationResult.Text + "</b></TD></tr><tr><TD Colspan='3'><b>Period : " + lblPeriod.Text + "</b></TD><TD Colspan='3'><b>Supplier : " + lblsupplierName.Text + "</b></TD><TD Colspan='3'><b>GRN_NO : " + lblGRN_NO.Text + "</b></TD></TR><TR>");
        HttpContext.Current.Response.Write("<Table border='1'  borderColor='#000000' cellSpacing='0' cellPadding='0' style='font-size:10.0pt; font-family:Calibri; text-align:center;'> <TR style='color: #fff; background: black;text-align:center;'><TD Colspan='12'>Reoprt Scrapped Details</b></TD><TR><TD Colspan='6'><b>Location Type : " + lblLocationType_Result.Text + "</b></TD><TD Colspan='6'><b>Location : " + lblLocationResult.Text + "</b></TD></tr><tr><TD Colspan='6'><b>Period : " + lblPeroidResult.Text + "</b></TD></TR></TR>");
        Response.Charset = "";
        this.EnableViewState = false;
        System.IO.StringWriter oStringWriter1 = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter oHtmlTextWriter1 = new System.Web.UI.HtmlTextWriter(oStringWriter1);
        //this.ClearControls(dladmissioncount)
        dlGridDisplay.RenderControl(oHtmlTextWriter1);
        Response.Write(oStringWriter1.ToString());
        Response.Flush();
        Response.End();

        //DataList1.Visible = false;
    }
}