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

public partial class Issue_Sim_new : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            FillDDL_serviceprovider();
            FillDDL_simissue();
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
            //ddlServiceprovider.Items.Insert(0, "Select");
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
        //{
        //    Show_Error_Success_Box("E", "Select Service Provider");
        //    //ddlServiceprovider.Focus();
        //    return;
        //}
        if (ddlissuestatus.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "Select status");
            return;
        }
        Clear_Error_Success_Box();

        //new changes-- on sreach
        if (ddlissuestatus.SelectedValue == "1")     //Report
        {
            DataSet dsGrid = ProductController.Getissue_Sim_deatils_new(ddlServiceprovider.SelectedValue, txtmobileno.Text, ddlissuestatus.SelectedValue, 1);
            if (dsGrid != null)
            {
                if (dsGrid.Tables[0].Rows.Count > 0)
                //if (dsGrid.Tables.Count > 0)
                {

                    //DataList1.DataSource = dsGrid;
                    //DataList1.DataBind();
                    //Lblservicep.Text= dsGrid.Tables[0].Rows[0]["SERVICEPROVDERNAME"].ToString{};
                    lbltotalcount.Text = dsGrid.Tables[0].Rows.Count.ToString();

                    DataList1.DataSource = dsGrid;
                    DataList1.DataBind();
                    ControlVisibility("Result");
                    DataList2.DataSource = dsGrid;
                    DataList2.DataBind();
                }
                else
                {
                    Show_Error_Success_Box("E", "No records found");
                }
            }
        }

        if (ddlissuestatus.SelectedValue == "2")     //Report 
        {
            DataSet dsGrid = ProductController.Getissue_Sim_deatils_new(ddlServiceprovider.SelectedValue, txtmobileno.Text, ddlissuestatus.SelectedValue, 2);
            if (dsGrid != null)
            {
                if (dsGrid.Tables[0].Rows.Count > 0)
                //if (dsGrid.Tables.Count > 0)
                {

                    //DataList1.DataSource = dsGrid;
                    //DataList1.DataBind();
                    //Lblservicep.Text= dsGrid.Tables[0].Rows[0]["SERVICEPROVDERNAME"].ToString{};
                    lbltotalcount.Text = dsGrid.Tables[0].Rows.Count.ToString();

                    DataList1.DataSource = dsGrid;
                    DataList1.DataBind();
                    ControlVisibility("Result");
                    DataList2.DataSource = dsGrid;
                    DataList2.DataBind();
                }
                else
                {
                    Show_Error_Success_Box("E", "No records found");
                }
            }
        }

        if (ddlissuestatus.SelectedValue == "3")     //Report 
        {
            DataSet dsGrid = ProductController.Getissue_Sim_deatils_new(ddlServiceprovider.SelectedValue, txtmobileno.Text, ddlissuestatus.SelectedValue, 3);
            if (dsGrid != null)
            {
                if (dsGrid.Tables[0].Rows.Count > 0)
                //if (dsGrid.Tables.Count > 0)
                {

                    //DataList1.DataSource = dsGrid;
                    //DataList1.DataBind();
                    //Lblservicep.Text= dsGrid.Tables[0].Rows[0]["SERVICEPROVDERNAME"].ToString{};
                    lbltotalcount.Text = dsGrid.Tables[0].Rows.Count.ToString();

                    DataList1.DataSource = dsGrid;
                    DataList1.DataBind();
                    ControlVisibility("Result");
                    DataList2.DataSource = dsGrid;
                    DataList2.DataBind();
                }


                else
                {
                    //DataList1.DataSource = null;
                    //DataList1.DataBind();
                    //lbltotalcount.Text = "0";

                    //DataList2.DataSource = null;
                    //DataList2.DataBind();
                    Show_Error_Success_Box("E", "SIM allotted to user");
                    DivSearchPanel.Visible = true;
                    DivResultPanel.Visible = false;
                }
            }
            else
            {
                DataList1.DataSource = null;
                DataList1.DataBind();
                lbltotalcount.Text = "0";

                DataList2.DataSource = null;
                DataList2.DataBind();
            }
            
        }
        //else
        //{
        //    Show_Error_Success_Box("E", "No records found");
        //}

    }



    protected void BtnAdd_Click(object sender, EventArgs e)
    {
        Clear_Addpanel();
      

        DataSet dsGrid = ProductController.GetSim_deatils(ddlServiceprovider.SelectedValue, txtmobileno.Text, "", 5);
        if (dsGrid != null)
        {
            Clear_Error_Success_Box();

            if (dsGrid.Tables[0].Rows[0]["Status"].ToString() == "Sim already allotted to user")
            {
                Show_Error_Success_Box("E", "Mobile number is already allotted to user");
            }

            else
            {

                ControlVisibility("Add");
                //Clear_Addpanel();
                lblHeader_Add.Text = "Issue SIM";
                FillDDL_serviceprovider1();
                FillDDL_simtype();
                FillDDL_Division();
                FillDDL_Department();
                FillDDL_Costcenter();
                BtnSaveEdit.Visible = false;
                btnSave.Visible = true;

                ddlServiceprovider1.SelectedValue = dsGrid.Tables[0].Rows[0]["Service_Provider_Name"].ToString();
                ddlServiceprovider1.Enabled = false;
                ddlsimtype.SelectedValue = dsGrid.Tables[0].Rows[0]["SIM_Type"].ToString();
                ddlsimtype.Enabled = false;
                txtMobilenumber.Text = dsGrid.Tables[0].Rows[0]["Mobile_No"].ToString();
                txtMobilenumber.Enabled = false;
                txtSimnum.Text = dsGrid.Tables[0].Rows[0]["SIM_No"].ToString();
                txtSimnum.Enabled = false;
                TxtRelationshipnum.Text = dsGrid.Tables[0].Rows[0]["Relationship_Number"].ToString();
                TxtRelationshipnum.Enabled = false;
                TxtAccountNum.Text = dsGrid.Tables[0].Rows[0]["Account_Number"].ToString();
                TxtAccountNum.Enabled = false;
                TxtPlan.Text = dsGrid.Tables[0].Rows[0]["Plan"].ToString();
                TxtPlan.Enabled = false;
                TxtTariff.Text = dsGrid.Tables[0].Rows[0]["Tariff"].ToString();
                TxtTariff.Enabled = false;
            }


        }

    }



    protected void Clear_Addpanel()
    {
        TxtUser.Text = ""; TxtLocation.Text = ""; TxtApproval.Text = "";
        TxtEmail.Text = ""; TxtContact.Text = ""; TxtEmployeeid.Text = ""; TxtCoordinator.Text = ""; TxtHandoverdate.Value = ""; Txtperiod.Value = "";
        TexReceivedby.Text = ""; TxtDeliveredby.Text = ""; TxtIssueby.Text = ""; TxtIssuedDate.Value = ""; TxtRemarks.Text = "";
    }

    protected void Clear_Addpaneledite()
    {

        TxtHandoverdate.Value = "";

    }



    protected void BtnClearSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect("Issue_Sim_new.aspx");
    }
    protected void btnClear_Add_Click(object sender, EventArgs e)
    {
        Response.Redirect("Issue_Sim_new.aspx");
    }
    private void ControlVisibility(string Mode)
    {
        if (Mode == "Search")
        {
            DivAddPanel.Visible = false;
            DivAddPanel_issue.Visible = false;
            DivAddPaneldelivery.Visible = false;
            DivSearchPanel.Visible = true;
            BtnShowSearchPanel.Visible = false;
            BtnAdd.Visible = false;
            DivResultPanel.Visible = false;
            DivEditPanel.Visible = false;

        }
        else if (Mode == "Result")
        {
            DivAddPanel.Visible = false;
            DivEditPanel.Visible = false;
            DivSearchPanel.Visible = false;
            DivAddPanel_issue.Visible = false;
            DivAddPaneldelivery.Visible = false;
            
            BtnShowSearchPanel.Visible = true;
            BtnAdd.Visible = false;
            DivResultPanel.Visible = true;
           


        }
        else if (Mode == "Add")
        {
            DivAddPanel.Visible = true;
            DivAddPanel_issue.Visible = true;
            DivAddPaneldelivery.Visible = true;
            DivEditPanel.Visible = false;
            DivSearchPanel.Visible = false;
            BtnShowSearchPanel.Visible = true;
            BtnAdd.Visible = false;
            DivResultPanel.Visible = false;
           


        }
        else if (Mode == "Edit")
        {
            DivAddPanel.Visible = false;
            DivAddPaneldelivery.Visible = true;
            DivResultPanel.Visible = false;
            DivSearchPanel.Visible = false;
            BtnAdd.Visible = false;
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
    private void FillDDL_Department()
    {
        {

            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];

            string Flag = "7";
            DataSet dsDepartment = ProductController.Get_Department(Flag);
            BindDDL(ddlDepartment, dsDepartment, "DeptName", "DeptID");
            ddlDepartment.Items.Insert(0, "Select");
            ddlDepartment.SelectedIndex = 0;


        }
    }

    private void FillDDL_Division()
    {
        {
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];

            string Flag = "8";

            DataSet dsDivision = ProductController.Get_Division(Flag);
            BindDDL(ddlDivision1, dsDivision, "Source_Division_ShortDesc", "Source_Division_Code");
            ddlDivision1.Items.Insert(0, "Select");
            ddlDivision1.SelectedIndex = 0;

        }
    }
    private void FillDDL_Costcenter()
    {
        {
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];

            string Flag = "9";
            DataSet dsCostcenter = ProductController.Get_Costcenter2(Flag, ddlDivision1.SelectedValue);
            BindDDL(ddlCostcenter, dsCostcenter, "Centername", "Source_Center_Code");
            ddlCostcenter.Items.Insert(0, "Select");
            ddlCostcenter.SelectedIndex = 0;
        }
    }

    int ActiveFlag = 0;

    protected void btnSave_Click(object sender, EventArgs e)
    {



        if (ddlServiceprovider1.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "Select Service Provider");
            //ddlServiceprovider1.Focus();
            return;
        }
        if (ddlsimtype.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "Select SIMType");
            //ddlsimtype.Focus();
            return;
        }

        if (string.IsNullOrEmpty(txtMobilenumber.Text.Trim()))
        {
            Show_Error_Success_Box("E", "Enter Mobile Number");
            txtMobilenumber.Focus();
            return;
        }
        if (string.IsNullOrEmpty(txtSimnum.Text.Trim()))
        {
            Show_Error_Success_Box("E", "Enter SIM Number");
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
        if (string.IsNullOrEmpty(TxtPlan.Text.Trim()))
        {
            Show_Error_Success_Box("E", "Enter Plan ");
            TxtPlan.Focus();
            return;
        }
        if (string.IsNullOrEmpty(TxtTariff.Text.Trim()))
        {
            Show_Error_Success_Box("E", "Enter Tariff ");
            TxtTariff.Focus();
            return;
        }
        if (string.IsNullOrEmpty(TxtUser.Text.Trim()))
        {
            Show_Error_Success_Box("E", "Enter User Name");
            TxtUser.Focus();
            return;
        }
        if (string.IsNullOrEmpty(TxtApproval.Text.Trim()))
        {
            Show_Error_Success_Box("E", "Enter Approval Details");
            TxtApproval.Focus();
            return;
        }
        if (string.IsNullOrEmpty(TxtEmail.Text.Trim()))
        {
            Show_Error_Success_Box("E", "Enter Emailid ");
            TxtEmail.Focus();
            return;
        }
        if (string.IsNullOrEmpty(TxtContact.Text.Trim()))
        {
            Show_Error_Success_Box("E", "Enter Conact Number ");
            TxtContact.Focus();
            return;
        }
        if (string.IsNullOrEmpty(TxtEmployeeid.Text.Trim()))
        {
            Show_Error_Success_Box("E", "Enter Employee ID ");
            TxtEmployeeid.Focus();
            return;
        }
        if (Txtperiod.Value == "")
        {
            Show_Error_Success_Box("E", "Enter Period ");
            return;
        }

        if (string.IsNullOrEmpty(TxtIssueby.Text.Trim()))
        {
            Show_Error_Success_Box("E", "Enter issued By  ");
            TxtIssueby.Focus();
            return;
        }
        if (TxtIssuedDate.Value == "")
        {
            Show_Error_Success_Box("E", "Enter issue date ");
            return;
        }

        if (chkActiveFlag.Checked == true)
        {
            ActiveFlag = 1;
        }
        else
        {
            ActiveFlag = 0;
        }

       

        string DateRange = "";
        DateRange = Txtperiod.Value;

        string FDate, ToDate;
        FDate = DateRange.Substring(0, 10);
        ToDate = (DateRange.Length > 9) ? DateRange.Substring(DateRange.Length - 10, 10) : DateRange;


        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        int resultid = 0;
        string flag = "1";

        resultid = ProductController.Insert_Update_Sim_user_details(ddlServiceprovider1.SelectedValue, ddlsimtype.SelectedValue, txtMobilenumber.Text, txtSimnum.Text, TxtRelationshipnum.Text, TxtAccountNum.Text,
            TxtPlan.Text, TxtTariff.Text, TxtUser.Text, TxtLocation.Text, TxtApproval.Text, TxtEmail.Text, TxtContact.Text, TxtEmployeeid.Text, ddlDivision1.SelectedValue, ddlDepartment.SelectedValue, ddlCostcenter.SelectedValue,
            TxtCoordinator.Text, FDate, ToDate, TxtHandoverdate.Value, TexReceivedby.Text, TxtDeliveredby.Text, TxtIssueby.Text, TxtIssuedDate.Value, TxtRemarks.Text, UserID, ActiveFlag, 1);

        if (resultid == 1)
        {
            Show_Error_Success_Box("S", "Record Saved Succesfully");
            ControlVisibility("Search");
            Clear_Error_Success_Box();

        }
        else
        {
            Show_Error_Success_Box("E", "Mobile Details are not Registered");
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
        //ControlVisibility("Search");
        ControlVisibility("Result");
        BtnAdd.Visible = false;
        Clear_Error_Success_Box();
    }


    protected void BtnShowSearchPanel_Click(object sender, EventArgs e)
    {
        ControlVisibility("Search");
        Clear_Error_Success_Box();
        BtnAdd.Visible = false;
    }
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
        DataList2.Visible = true;
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        string filenamexls1 = "Issued Card Details" + DateTime.Now + ".xls";
        Response.AddHeader("Content-Disposition", "inline;filename=" + filenamexls1);
        HttpContext.Current.Response.Charset = "utf-8";
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");
        //sets font
        HttpContext.Current.Response.Write("<font style='font-size:10.0pt; font-family:Calibri;'>");
        HttpContext.Current.Response.Write("<BR><BR><BR>");
        HttpContext.Current.Response.Write("<Table border='1'  borderColor='#000000' cellSpacing='0' cellPadding='0' style='font-size:10.0pt; font-family:Calibri; text-align:center;'> <TR style='color: #fff; background: black;text-align:center;'><TD Colspan='28'>Issued Card Details</TD></TR>");
        Response.Charset = "";
        this.EnableViewState = false;
        System.IO.StringWriter oStringWriter1 = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter oHtmlTextWriter1 = new System.Web.UI.HtmlTextWriter(oStringWriter1);
        //this.ClearControls(dladmissioncount);
        DataList2.RenderControl(oHtmlTextWriter1);
        Response.Write(oStringWriter1.ToString());
        Response.Flush();
        Response.End();
        DataList2.Visible = false;
    }
    protected void BtnSaveEdit_Click(object sender, System.EventArgs e)
    {
        Clear_Error_Success_Box();

        //if (TxtHandoverdate.Value == "")
        //{
        //    Show_Error_Success_Box("E", "Select Handover Date ");
        //    return;
        //}


        if (chkActiveFlag.Checked == true)
        {
            ActiveFlag = 1;
        }
        else
        {
            ActiveFlag = 0;
        }


        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        int resultid = 0;
        string flag = "2";

        resultid = ProductController.Update_Sim_user_details(ddlServiceprovider.SelectedValue, ddlsimtype.SelectedValue, txtMobilenumber.Text, txtSimnum.Text, TxtRelationshipnum.Text, TxtAccountNum.Text,
             TxtPlan.Text, TxtTariff.Text, TxtUser.Text, TxtLocation.Text, TxtApproval.Text, TxtEmail.Text, TxtContact.Text, TxtEmployeeid.Text, ddlDivision1.SelectedValue, ddlDepartment.SelectedValue, ddlCostcenter.SelectedValue,
             TxtCoordinator.Text, TxtHandoverdate.Value, TexReceivedby.Text, TxtDeliveredby.Text, TxtIssueby.Text, TxtIssuedDate.Value, TxtRemarks.Text, UserID, ActiveFlag,lblPkey.Text, 2);

        if (resultid == 1)
        {
            Show_Error_Success_Box("S", "Record Updated Succesfully");
            ControlVisibility("Search");

            //Clear_Error_Success_Box();

        }

    }

    //edit

    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        Clear_Error_Success_Box();
        Clear_Addpanel();
        if (e.CommandName == "comEdit")
        {
            lblPkey.Text = e.CommandArgument.ToString();

            //string Flag = "3";
            DataSet DSGrid = ProductController.Get_sim_edit_details(ddlServiceprovider1.SelectedValue.ToString().Trim(),txtMobilenumber.Text, lblPkey.Text, 3);
            if (DSGrid != null)
            {
                if (DSGrid.Tables[0].Rows.Count > 0)
                {

                    FillDDL_serviceprovider1();
                    FillDDL_Division();
                    FillDDL_Department();
                    ddlServiceprovider1.SelectedValue = DSGrid.Tables[0].Rows[0]["Service_Provider_Name"].ToString();
                    ddlServiceprovider1.Enabled = false;
                    ddlsimtype.SelectedValue = DSGrid.Tables[0].Rows[0]["SIM_Type"].ToString();
                    ddlsimtype.Enabled = false;
                    txtMobilenumber.Text = DSGrid.Tables[0].Rows[0]["Mobile_No"].ToString();
                    txtMobilenumber.Enabled = false;
                    txtSimnum.Text = DSGrid.Tables[0].Rows[0]["SIM_No"].ToString();
                    txtSimnum.Enabled = false;
                    TxtRelationshipnum.Text = DSGrid.Tables[0].Rows[0]["Relationship_Number"].ToString();
                    TxtRelationshipnum.Enabled = false;
                    TxtAccountNum.Text = DSGrid.Tables[0].Rows[0]["Account_Number"].ToString();
                    TxtAccountNum.Enabled = false;
                    TxtPlan.Text = DSGrid.Tables[0].Rows[0]["Plan"].ToString();
                    TxtPlan.Enabled = false;
                    TxtTariff.Text = DSGrid.Tables[0].Rows[0]["Tariff"].ToString();
                    TxtTariff.Enabled = false;
                    TxtUser.Text = DSGrid.Tables[0].Rows[0]["User_name"].ToString();
                    TxtUser.Enabled = false;
                    TxtLocation.Text = DSGrid.Tables[0].Rows[0]["Location"].ToString();
                    TxtLocation.Enabled = false;
                    TxtApproval.Text = DSGrid.Tables[0].Rows[0]["Approval"].ToString();
                    TxtApproval.Enabled = false;
                    TxtEmail.Text = DSGrid.Tables[0].Rows[0]["Email_id"].ToString();
                    TxtEmail.Enabled = false;
                    TxtContact.Text = DSGrid.Tables[0].Rows[0]["Contact_No"].ToString();
                    TxtContact.Enabled = false;
                    TxtEmployeeid.Text = DSGrid.Tables[0].Rows[0]["Employeeid"].ToString();
                    TxtEmployeeid.Enabled = false;
                    ddlDivision1.SelectedValue = DSGrid.Tables[0].Rows[0]["Division"].ToString();
                    ddlDivision1.Enabled = true;
                    ddlDepartment.SelectedValue = DSGrid.Tables[0].Rows[0]["Dept"].ToString();
                    ddlDepartment.Enabled = true;
                    FillDDL_Costcenter();
                    ddlCostcenter.SelectedValue = DSGrid.Tables[0].Rows[0]["Center"].ToString();
                    ddlCostcenter.Enabled = true;
                    TxtCoordinator.Text = DSGrid.Tables[0].Rows[0]["Coordinater"].ToString();
                    TxtCoordinator.Enabled = false;
                    TxtDeliveredby.Text = DSGrid.Tables[0].Rows[0]["Deliveredby "].ToString();
                    TxtDeliveredby.Enabled = false;
                    TxtIssueby.Text = DSGrid.Tables[0].Rows[0]["issuedby"].ToString();
                    TxtIssueby.Enabled = false;
                    Txtperiod.Value = DSGrid.Tables[0].Rows[0]["Fdate"].ToString();
                   //Txtperiod.Value = false;
                    Txtperiod.Value = DSGrid.Tables[0].Rows[0]["TDate"].ToString();

                    TxtIssuedDate.Value = DSGrid.Tables[0].Rows[0]["issueddate"].ToString();
                    
                  

                    if (Convert.ToInt32(DSGrid.Tables[0].Rows[0]["isactive"]) == 0)
                    {
                        chkActiveFlag.Checked = false;
                    }
                    else
                    {
                        chkActiveFlag.Checked = true;
                    }
                    DivResultPanel.Visible = false;
                    DivAddPanel.Visible = false;
                    DivAddPanel_issue.Visible = true;
                    DivAddPaneldelivery.Visible = true;
                    BtnSaveEdit.Visible = true;
                    btnSave.Visible = false;
                }
                else
                {
                    Show_Error_Success_Box("E", " Details are not editable as SIM is not active");
                }


            }
            else
            {
                //Show_Error_Success_Box("E", " SIM IS NOT ACTIVE");
            }
        }
        if (e.CommandName == "comissue")
        {
            Clear_Addpanel();
           
            //ControlVisibility("Add");
           
            lblPkey.Text = e.CommandArgument.ToString();
            DataSet dsGrid = ProductController.GetSim_deatils(ddlServiceprovider.SelectedValue, lblPkey.Text, "", 5);
            if (dsGrid != null)
            {
                Clear_Error_Success_Box();

                if (dsGrid.Tables[0].Rows[0]["Status"].ToString() == "Sim already allotted to user")
                {
                    Show_Error_Success_Box("E", "Mobile number is already allotted to user");
                }

                else
                {

                    ControlVisibility("Add");

                    lblHeader_Add.Text = "SIM Details";
                    lblIssued_to.Text = "User Basic Details";
                    LblDelivery.Text = "Delivery Details";
                    FillDDL_serviceprovider1();
                    FillDDL_simtype();
                    FillDDL_Division();
                    FillDDL_Department();
                    FillDDL_Costcenter();
                    BtnSaveEdit.Visible = false;
                    btnSave.Visible = true;

                    ddlServiceprovider1.SelectedValue = dsGrid.Tables[0].Rows[0]["Service_Provider_Name"].ToString();
                    ddlServiceprovider1.Enabled = false;
                    ddlsimtype.SelectedValue = dsGrid.Tables[0].Rows[0]["SIM_Type"].ToString();
                    ddlsimtype.Enabled = false;
                    txtMobilenumber.Text = dsGrid.Tables[0].Rows[0]["Mobile_No"].ToString();
                    txtMobilenumber.Enabled = false;
                    txtSimnum.Text = dsGrid.Tables[0].Rows[0]["SIM_No"].ToString();
                    txtSimnum.Enabled = false;
                    TxtRelationshipnum.Text = dsGrid.Tables[0].Rows[0]["Relationship_Number"].ToString();
                    TxtRelationshipnum.Enabled = false;
                    TxtAccountNum.Text = dsGrid.Tables[0].Rows[0]["Account_Number"].ToString();
                    TxtAccountNum.Enabled = false;
                    TxtPlan.Text = dsGrid.Tables[0].Rows[0]["Plan"].ToString();
                    TxtPlan.Enabled = false;
                    TxtTariff.Text = dsGrid.Tables[0].Rows[0]["Tariff"].ToString();
                    TxtTariff.Enabled = false;
                    TxtUser.Enabled = true;
                    TxtLocation.Enabled = true;
                    TxtApproval.Enabled = true;
                    TxtEmail.Enabled = true;
                    TxtContact.Enabled = true;
                    TxtEmployeeid.Enabled = true;
                    ddlDivision1.Enabled = true;
                    ddlDepartment.Enabled = true;
                    ddlCostcenter.Enabled = true;
                    TxtCoordinator.Enabled = true;
                    TxtDeliveredby.Enabled = true;
                    TxtIssueby.Enabled = true;
                }


            }
            //BtnAdd_Click(this, e);

        }
    }

    private void FillDDL_simissue()
    {

        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];

        string Flag = "13";
        DataSet dssimissue = ProductController.Get_Service_provider_list2(Flag);
        BindDDL(ddlissuestatus, dssimissue, "ID_Name", "Sim_IssueID");
        ddlissuestatus.Items.Insert(0, "Select");
        ddlissuestatus.SelectedIndex = 1;

    }
    protected void ddlDivision1_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillDDL_Costcenter();
    }

}

