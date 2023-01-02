using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
//using System.Data.SqlClient.SqlDataReader;
//using Exportxls.BL;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using ShoppingCart.BL;
//using Exportxls.BL;
using Encryption.BL;

public partial class Receive_SIM : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            FillDDL_serviceprovider();
            FillDDL_status1();
        }
    }

    private void BindDDL(DropDownList ddl, DataSet ds, string txtField, string valField)
    {
        ddl.DataSource = ds;
        ddl.DataTextField = txtField;
        ddl.DataValueField = valField;
        ddl.DataBind();
    }




    private void FillDDL_serviceprovider()
    {

        try
        {

            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];

            string Flag = "1";
            DataSet dsServiceProvider = ProductController.Get_Service_provider_list2(Flag);
            BindDDL(ddlServiceprovider, dsServiceProvider, "Service_Provider_ShortDesc", "Service_Provider_Code");
            ddlServiceprovider.Items.Insert(0, "Select");
            ddlServiceprovider.SelectedIndex = 0;



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
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        if (ddlServiceprovider.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "Select Service Provider");
            //ddlServiceprovider.Focus();
            return;
        }
        Clear_Error_Success_Box();

        

        DataSet dsGrid = new DataSet();
        dsGrid = ProductController.GetSim_deatils0(ddlServiceprovider.SelectedValue, txtmobileno.Text, ddlstatus1.SelectedValue, 1);
        if (dsGrid != null)
        {
            if (dsGrid.Tables[0].Rows.Count >0)
            {

                dlcenter.DataSource = dsGrid;
                dlcenter.DataBind();
                lbltotalcount.Text = dsGrid.Tables[0].Rows.Count.ToString();
                ControlVisibility("Result");

                DataList1.DataSource = dsGrid;
                DataList1.DataBind();
            }
            else
            {
                //dlcenter.DataSource = null;
                //dlcenter.DataBind();
                //lbltotalcount.Text = "0";

                //DataList1.DataSource = null;
                //DataList1.DataBind();
                Show_Error_Success_Box("E", " Record Not Found");
                DivSearchPanel.Visible = true;
                DivResultPanel.Visible = false;
            }
        }
        else
        {
            dlcenter.DataSource = null;
            dlcenter.DataBind();
            lbltotalcount.Text = "0";

            DataList1.DataSource = null;
            DataList1.DataBind();
        }

    }

    protected void BtnAdd_Click(object sender, EventArgs e)
    {
        DataSet dsGrid = new DataSet();
        dsGrid = ProductController.GetSim_deatils(ddlServiceprovider.SelectedValue, txtmobileno.Text, "", 12);
        if (dsGrid != null)
        {
            if (dsGrid.Tables[0].Rows.Count > 0)
            {
                Show_Error_Success_Box("E", " SIM details already exist");
            }
            else
            {
                ControlVisibility("Add");

                Clear_Addpanel();
                Clear_Error_Success_Box();
                lblHeader_Add.Text = "Register SIM Details";
                FillDDL_serviceprovider1();
                FillDDL_simtype();
                //FillDDL_paymode();
                FillDDL_status();
                //FillDDL_Billcopy();
            }
        }
              
            
        
    }
    protected void Clear_Addpanel()
    {
        txtMobilenumber.Text = "";
        txtSimnum.Text = "";
        TxtRelationshipnum.Text = "";
        TxtAccountNum.Text = "";
        //ddlplan.Text = ""; 
        TxtTariff.Text = ""; id_date_range_picker_2.Value = ""; Txtdate1.Value = "";
        Txtdate2.Value=""; TxtCost.Text=""; Txtdate3.Value=""; TxtDate4.Value=""; 
        //TxtPayment.Text="";
         TextBox8.Text="";
    }
  
    protected void BtnClearSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect("Receive_SIM.aspx");
    }
    protected void btnClear_Add_Click(object sender, EventArgs e)
    {
        Response.Redirect("Receive_SIM.aspx");
    }
    private void ControlVisibility(string Mode)
    {
        if (Mode == "Search")
        {
            DivAddPanel.Visible = false;
            DivSearchPanel.Visible = true;
            BtnShowSearchPanel.Visible = false;
            BtnAdd.Visible = true;
            DivResultPanel.Visible = false;
            DivEditPanel.Visible = false;
        }
        else if (Mode == "Result")
        {
            DivAddPanel.Visible = false;
            DivEditPanel.Visible = false;
            DivSearchPanel.Visible = false;
            BtnShowSearchPanel.Visible = true;
            BtnAdd.Visible = false;
            DivResultPanel.Visible = true;

        }
        else if (Mode == "Add")
        {
            DivAddPanel.Visible = true;
            DivEditPanel.Visible = false;
            DivSearchPanel.Visible = false;
            BtnShowSearchPanel.Visible = true;
            BtnAdd.Visible = false;
            DivResultPanel.Visible = false;
            BtnSaveEdit.Visible = false;
            btnSave.Visible = true;

        }
        else if (Mode == "Edit")
        {
            DivAddPanel.Visible = false;
            DivResultPanel.Visible = false;
            DivSearchPanel.Visible = false;
            BtnAdd.Visible = true;
            DivEditPanel.Visible = true;
            BtnSaveEdit.Visible = true;
            btnSave.Visible = false;
        }

        else if (Mode == "EditClose")
        {
            DivAddPanel.Visible = false;
            DivResultPanel.Visible = true;
            DivSearchPanel.Visible = false;
            BtnAdd.Visible = false;
            DivEditPanel.Visible = false;

        }
    }
    private void FillDDL_serviceprovider1()
    {
        {
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];

            string Flag = "2";
            DataSet dsServiceProvider1 = ProductController.Get_Service_provider_list2(Flag);
            BindDDL(ddlServiceprovider1, dsServiceProvider1, "Service_Provider_ShortDesc", "Service_Provider_Code");
            ddlServiceprovider1.Items.Insert(0, "Select");
            ddlServiceprovider1.SelectedIndex = 0;

            //BindDDL(ddlServiceprovider1, dsServiceProvider1, "Service_Provider_ShortDesc", "Service_Provider_Code");
            //ddlServiceprovider1.Items.Insert(0, "Select");
            //ddlServiceprovider1.SelectedIndex = 0;
        }
    }
   

    private void BindPlan()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        string flag = "12";
        DataSet ds = ProductController.Get_Plan(flag, ddlServiceprovider1.SelectedValue);
        //BindListBox(ddlplan, ds, "Zone_name", "plan_code");
        BindDDL(ddlplan, ds, "plan_name", "plan_code");
        TxtTariff.Text = ds.Tables[0].Rows[0]["plan_name"].ToString();
        TxtTariff.Enabled = true;
        ddlplan.Items.Insert(0, "Select");
        ddlplan.SelectedIndex = 0;
        if (ddlplan.SelectedIndex == 0)
        {
            TxtTariff.Text = "";
            
        }
    }


    private void FillDDL_simtype()
    {
        {
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];

            string Flag = "3";
            DataSet dssimtype = ProductController.Get_simtype(Flag);
            BindDDL(ddlsimtype, dssimtype, "Sim_type_ShortDesc", "Sim_type_Code");
            ddlsimtype.Items.Insert(0, "Select");
            ddlsimtype.SelectedIndex = 0;

            
        }
    }
    //private void FillDDL_paymode()
    //{
    //    {
    //        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
    //        string UserID = cookie.Values["UserID"];
    //        string UserName = cookie.Values["UserName"];

    //        string Flag = "4";
    //        DataSet dspaymode = ProductController.Get_paymode(Flag);
    //        BindDDL(ddlpaymode, dspaymode, "Description", "Pay_Mode_Code");
    //        ddlpaymode.Items.Insert(0, "Select");
    //        ddlpaymode.SelectedIndex = 0;

    //        //BindDDL(ddlpaymode, dspaymode, "Description", "Pay_Mode_Code");
    //        //ddlsimtype.Items.Insert(0, "Select");
    //        //ddlpaymode.SelectedIndex = 0;
    //    }
    //}

    private void FillDDL_status()
    {
        {
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];

            string Flag = "5";

            DataSet dsstatus = ProductController.Get_status(Flag);
            BindDDL(ddlstatus, dsstatus, "Description", "Sim_Datacard_status_Code");
            ddlstatus.Items.Insert(0, "Select");
            ddlstatus.SelectedIndex = 0;

        }
    }

    private void FillDDL_status1()
    {
        {
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];

            string Flag = "5";

            DataSet dsstatus1 = ProductController.Get_status(Flag);
            BindDDL(ddlstatus1, dsstatus1, "Description", "Sim_Datacard_status_Code");
            ddlstatus1.Items.Insert(0, "Select");
            ddlstatus1.SelectedIndex = 0;

        }
    }

    //private void FillDDL_Billcopy()
    //{
    //    {

    //        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
    //        string UserID = cookie.Values["UserID"];
    //        string UserName = cookie.Values["UserName"];

    //        string Flag = "6";
    //        DataSet dsBillcopy = ProductController.Get_Billcopy(Flag);
    //        BindDDL(ddlBillcopy, dsBillcopy, "Description", "Sim_Datacard_copy_Code");
    //        ddlBillcopy.Items.Insert(0, "Select");
    //        ddlBillcopy.SelectedIndex = 0;
    //    }
    //}
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Clear_Error_Success_Box();
        if (ddlServiceprovider1.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "Select Service Provider");
            //ddlServiceprovider1.Focus();
            return;
        }
        if (ddlsimtype.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "Select Sim Type");
            //ddlsimtype.Focus();
            return;
        }

        if (string.IsNullOrEmpty(txtMobilenumber.Text.Trim()))
        {
            Show_Error_Success_Box("E", "Enter Mobile number");
            txtMobilenumber.Focus();
            return;
        }
        if (string.IsNullOrEmpty(txtSimnum.Text.Trim()))
        {
            Show_Error_Success_Box("E", "Enter SIM Card Number");
            txtSimnum.Focus();
            return;
        }
        if (string.IsNullOrEmpty(TxtRelationshipnum.Text.Trim()))
        {
            Show_Error_Success_Box("E", "Enter Relationship Number");
            TxtRelationshipnum.Focus();
            return;
        }
        if (string.IsNullOrEmpty(TxtAccountNum.Text.Trim()))
        {
            Show_Error_Success_Box("E", "Enter Account Number");
            TxtAccountNum.Focus();
            return;
        }
        if (ddlplan.SelectedValue == "")
        {
            Show_Error_Success_Box("E", "Select Plan");
            //ddlServiceprovider1.Focus();
            return;
        }
        //if (string.IsNullOrEmpty(TxtPlan.Text.Trim()))
        //{
        //    Show_Error_Success_Box("E", "Enter Plan ");
        //    TxtPlan.Focus();
        //    return;
        //}
        if (string.IsNullOrEmpty(TxtTariff.Text.Trim()))
        {
            Show_Error_Success_Box("E", "Enter Tariff ");
            TxtTariff.Focus();
            return;
        }

        if (string.IsNullOrEmpty(TxtCost.Text.Trim()))
        {
            Show_Error_Success_Box("E", "Enter cost");
            TxtCost.Focus();
            return;
        }
        //if (ddlpaymode.SelectedIndex == 0)
        //{
        //    Show_Error_Success_Box("E", "Select Payment Mode");
        //    //ddlpaymode.Focus();
        //    return;
        //}
        if (ddlstatus.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "Select Status");
            //ddlstatus.Focus();
            return;
        }
        //if (ddlBillcopy.SelectedIndex == 0)
        //{
        //    Show_Error_Success_Box("E", "Select Bill Copy");
        //    //ddlstatus.Focus();
        //    return;
        //}

        //string DateRange = "";
        //DateRange = id_date_range_picker_2.Value;

        //string id_date_range_picker_2 ;
        //id_date_range_picker_2 = DateRange.Substring(0, 10);
        //ToDate = DateRange.Substring(13, 10);


        //         if (TxtDate.Value == "")
        //    //{
        //    //    Show_Error_Success_Box("E", "Select Bill Date");
        //    //    TxtDate.Focus();
        //    //    return;
        //    //}
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        int resultid = 0;
        string flag = "1";

        resultid = ProductController.Insert_Update_Sim_datacrad_details(ddlServiceprovider1.SelectedValue, ddlsimtype.SelectedValue, txtMobilenumber.Text, txtSimnum.Text, TxtRelationshipnum.Text, TxtAccountNum.Text,
            ddlplan.SelectedValue, TxtTariff.Text, id_date_range_picker_2.Value, Txtdate1.Value, Txtdate2.Value, TxtCost.Text, Txtdate3.Value, TxtDate4.Value, 
            //TxtPayment.Text, ddlpaymode.Text, ddlBillcopy.SelectedValue, 
            ddlstatus.SelectedValue, TextBox8.Text, UserID, 1);

        if (resultid == 1)
        {
            Show_Error_Success_Box("S", "Record Saved Succesfully");
            ControlVisibility("Search");

        }
        else
        {
            Show_Error_Success_Box("E", "Mobile Number Alredy Exist");
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


    protected void BtnCloseAdd_Click(object sender, EventArgs e)
    {
        //BtnSearch_Click(this, e);
        //BtnSearch_Click(this, e);
        UpdatePanel1.Update();
        ControlVisibility("Result");
        //ControlVisibility("Search");
        Clear_Error_Success_Box();

        //BtnAdd.Visible = true;
        //Msg_Success.Visible= false;
        //Msg_Error.Visible = false;
    }
    protected void BtnCloseedit_Click(object sender, EventArgs e)
    {
        BtnSearch_Click(this, e);
        //BtnSearch_Click(this, e);
        UpdatePanel1.Update();
        //ControlVisibility("Search");

        //BtnAdd.Visible = true;
        //Msg_Success.Visible= false;
        //Msg_Error.Visible = false;
        Clear_Error_Success_Box();
    }



    protected void BtnShowSearchPanel_Click(object sender, EventArgs e)
    {
        ControlVisibility("Search");
        Clear_Error_Success_Box();
    }
    //protected void BtnShowSearchPanel_Click(object sender, EventArgs e)
    //{
    //    ControlVisibility("Search");
    //    Clear_Error_Success_Box();
    //}
    private void Clear_Error_Success_Box()
    {
        Msg_Error.Visible = false;
        Msg_Success.Visible = false;
        lblSuccess.Text = "";
        lblerror.Text = "";
        UpdatePanelMsgBox.Update();
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {

        Response.Clear();
        DataList1.Visible = true;
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        string filenamexls1 = "SIM/DATA Card Details" + DateTime.Now + ".xls";
        Response.AddHeader("Content-Disposition", "inline;filename=" + filenamexls1);
        HttpContext.Current.Response.Charset = "utf-8";
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");
        //sets font
        HttpContext.Current.Response.Write("<font style='font-size:10.0pt; font-family:Calibri;'>");
        HttpContext.Current.Response.Write("<BR><BR><BR>");
        HttpContext.Current.Response.Write("<Table border='1'  borderColor='#000000' cellSpacing='0' cellPadding='0' style='font-size:10.0pt; font-family:Calibri; text-align:center;'> <TR style='color: #fff; background: black;text-align:center;'><TD Colspan='19'>SIM/DATA Card Details</TD></TR>");
        Response.Charset = "";
        this.EnableViewState = false;
        System.IO.StringWriter oStringWriter1 = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter oHtmlTextWriter1 = new System.Web.UI.HtmlTextWriter(oStringWriter1);
        //this.ClearControls(dladmissioncount);
        DataList1.RenderControl(oHtmlTextWriter1);
        Response.Write(oStringWriter1.ToString());
        Response.Flush();
        Response.End();
        DataList1.Visible = false;
    }

    protected void BtnSaveEdit_Click(object sender, System.EventArgs e)
    {
        Clear_Error_Success_Box();


        if (ddlServiceprovider1.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "Select Service Provider");
            ddlServiceprovider1.Focus();
            return;
        }
        if (ddlsimtype.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "Select Sim Type");
            ddlsimtype.Focus();
            return;
        }

        //if (string.IsNullOrEmpty(txtMobilenumber.Text.Trim()))
        //{
        //    Show_Error_Success_Box("E", "Enter Mobile number");
        //    txtMobilenumber.Focus();
        //    return;
        //}
        //if (string.IsNullOrEmpty(txtSimnum.Text.Trim()))
        //{
        //    Show_Error_Success_Box("E", "Enter SIM Deatails");
        //    txtSimnum.Focus();
        //    return;
        //}
        //if (string.IsNullOrEmpty(TxtRelationshipnum.Text.Trim()))
        //{
        //    Show_Error_Success_Box("E", "Enter Relationship Number");
        //    TxtRelationshipnum.Focus();
        //    return;
        //}
        //if (string.IsNullOrEmpty(TxtAccountNum.Text.Trim()))
        //{
        //    Show_Error_Success_Box("E", "Enter Account Number");
        //    TxtAccountNum.Focus();
        //    return;
        //}
        //if (string.IsNullOrEmpty(TxtPlan.Text.Trim()))
        //{
        //    Show_Error_Success_Box("E", "Enter Plan Details");
        //    TxtPlan.Focus();
        //    return;
        //}
        //if (string.IsNullOrEmpty(TxtTariff.Text.Trim()))
        //{
        //    Show_Error_Success_Box("E", "Enter Tariff Details");
        //    TxtTariff.Focus();
        //    return;
        //}
        //if (string.IsNullOrEmpty(TxtUser.Text.Trim()))
        //{
        //    Show_Error_Success_Box("E", "Enter User Details");
        //    TxtUser.Focus();
        //    return;
        //}
        //if (string.IsNullOrEmpty(TxtApproval.Text.Trim()))
        //{
        //    Show_Error_Success_Box("E", "Enter Approval Details");
        //    TxtApproval.Focus();
        //    return;
        //}
        //if (string.IsNullOrEmpty(TxtEmail.Text.Trim()))
        //{
        //    Show_Error_Success_Box("E", "Enter Emailid ");
        //    TxtEmail.Focus();
        //    return;
        //}
        //if (string.IsNullOrEmpty(TxtContact.Text.Trim()))
        //{
        //    Show_Error_Success_Box("E", "Enter Conact Details ");
        //    TxtContact.Focus();
        //    return;
        //}
        //if (string.IsNullOrEmpty(TxtEmployeeid.Text.Trim()))
        //{
        //    Show_Error_Success_Box("E", "Enter Employee ID ");
        //    TxtEmployeeid.Focus();
        //    return;
        //}
        //if (string.IsNullOrEmpty(TxtIssueby.Text.Trim()))
        //{
        //    Show_Error_Success_Box("E", "Enter issued by Deatils ");
        //    TxtIssueby.Focus();
        //    return;
        //}

        //if (chkActiveFlag.Checked == true)
        //{
        //    ActiveFlag = 1;
        //}
        //else
        //{
        //    ActiveFlag = 0;
        //}

        //string DateRange = "";
        //DateRange = id_date_range_picker_1.Value;

        //string FDate, ToDate;
        //FDate = DateRange.Substring(0, 10);
        //ToDate = DateRange.Substring(13, 10);

        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        int resultid = 0;
        string flag = "2";

        resultid = ProductController.Update_Sim_details(ddlServiceprovider.SelectedValue, ddlsimtype.SelectedValue, txtMobilenumber.Text, txtSimnum.Text, TxtRelationshipnum.Text, TxtAccountNum.Text,
             ddlplan.SelectedValue, TxtTariff.Text, id_date_range_picker_2.Value, Txtdate1.Value, Txtdate2.Value, TxtCost.Text, Txtdate3.Value, TxtDate4.Value,
             ddlstatus.SelectedValue, TextBox8.Text, UserID, 2);

        if (resultid == 1)
        {
            Show_Error_Success_Box("S", "Record Saved Succesfully");
            DivSearchPanel.Visible = true;
            DivAddPanel.Visible = false;
            Msg_Success.Visible = false;
            Msg_Error.Visible = false;

        }

    }
     protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "comEdit")
        {
            lblPkey.Text = e.CommandArgument.ToString();
            
            //string Flag = "3";
            DataSet DSGrid = ProductController.Get_sim_edit_details1(ddlServiceprovider1.SelectedValue.ToString().Trim(), lblPkey.Text, 6);
            if (DSGrid != null)
            {
                if (DSGrid.Tables[0].Rows.Count > 0)
                {
                    //           , , txtMobilenumber.Text, txtSimnum.Text, TxtRelationshipnum.Text, TxtAccountNum.Text,
                    //TxtPlan.Text, TxtTariff.Text, , , , , , , ddlDivision1.SelectedValue, , ,
                    //, FDate, ToDate, TxtHandoverdate.Value, TexReceivedby.Text, TxtDeliveredby.Text, TxtIssueby.Text, TxtIssuedDate.Value, TxtRemarks.Text, UserID, ActiveFlag,

                    //           ddlProposalType_Add.SelectedValue = DSGrid.Tables[0].Rows[0]["Proposal_Type_Code"].ToString();
                    FillDDL_serviceprovider1();
                    FillDDL_simtype();
                    FillDDL_status();
                   
                    ddlServiceprovider1.SelectedValue = DSGrid.Tables[0].Rows[0]["Service_Provider_Name"].ToString();
                    ddlServiceprovider1.Enabled = false;
                    ddlsimtype.SelectedValue = DSGrid.Tables[0].Rows[0]["SIM_Type"].ToString();
                    ddlsimtype.Enabled = false;
                    txtMobilenumber.Text = DSGrid.Tables[0].Rows[0]["Mobile_No"].ToString();
                    txtMobilenumber.Enabled = false;
                    txtSimnum.Text = DSGrid.Tables[0].Rows[0]["SIM_No"].ToString();
                    txtSimnum.Enabled = true;
                    TxtRelationshipnum.Text = DSGrid.Tables[0].Rows[0]["Relationship_Number"].ToString();
                    TxtRelationshipnum.Enabled = true;
                    TxtAccountNum.Text = DSGrid.Tables[0].Rows[0]["Account_Number"].ToString();
                    TxtAccountNum.Enabled = true;
                    BindPlan();
                    ddlplan.SelectedValue = DSGrid.Tables[0].Rows[0]["Plan"].ToString();
                    ddlplan.Enabled = true;
                    TxtTariff.Text = DSGrid.Tables[0].Rows[0]["Tariff"].ToString();
                    TxtTariff.Enabled = true;
                    ddlstatus.SelectedValue = DSGrid.Tables[0].Rows[0]["Status_ID"].ToString();
                    ddlstatus.Enabled = true;
                    TxtCost.Text = DSGrid.Tables[0].Rows[0]["Cost"].ToString();
                    TxtCost.Enabled = true;
                    if (DSGrid.Tables[0].Rows[0]["Operational_date"].ToString() == "01 Jan 1900")
                    {
                        id_date_range_picker_2.Value = "";
                    }
                    else
                    {
                        id_date_range_picker_2.Value = DSGrid.Tables[0].Rows[0]["Operational_date"].ToString();
                    }
                    //id_date_range_picker_2.Enabled = true;
                    if (DSGrid.Tables[0].Rows[0]["Disconnections_date"].ToString() == "01 Jan 1900")
                    {
                        Txtdate1.Value = "";
                    }
                    else
                    {
                        Txtdate1.Value = DSGrid.Tables[0].Rows[0]["Disconnections_date"].ToString();
                    }
                    if (DSGrid.Tables[0].Rows[0]["Monthly_Billing_Cycle"].ToString() == "01 Jan 1900")
                    {
                        Txtdate2.Value = "";
                    }
                    else
                    {
                        Txtdate2.Value = DSGrid.Tables[0].Rows[0]["Monthly_Billing_Cycle"].ToString();
                    }
                    if (DSGrid.Tables[0].Rows[0]["Due_Date"].ToString() == "01 Jan 1900")
                    {
                        Txtdate3.Value = "";
                    }
                    else
                    {
                        Txtdate3.Value = DSGrid.Tables[0].Rows[0]["Due_Date"].ToString();
                    }
                    
                    }
                    

                    DivResultPanel.Visible = false;
                    DivAddPanel.Visible = true;
                    BtnSaveEdit.Visible = true;
                    btnSave.Visible = false;
                    BtnAdd.Visible = false;
                }
                else
                { 
                    Show_Error_Success_Box ("E"," SIM is not active");
                }


            }
             else
                {
                    Show_Error_Success_Box("E", " SIM is not active");
                }
        }
     protected void ddlServiceprovider1_SelectedIndexChanged(object sender, EventArgs e)
     {
         BindPlan();
     }
     protected void ddlplan_SelectedIndexChanged(object sender, EventArgs e)
     {
         TxtTariff.Text =ddlplan.SelectedItem.ToString();
     }
}
  