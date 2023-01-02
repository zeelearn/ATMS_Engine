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

public partial class Sim_Payment_Details : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            FillDDL_serviceprovider();
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

        string mobileno = null;
        if (string.IsNullOrEmpty(txtmobileno.Text.Trim()))
        {
            mobileno = "%";
        }
        else
        {
            mobileno = txtmobileno.Text.Trim();
        }
        Clear_Error_Success_Box();

        ControlVisibility("Result");

        DataSet dsGrid = new DataSet();
        dsGrid = ProductController.GetPayment_deatils(ddlServiceprovider.SelectedValue, mobileno, 10);
        if (dsGrid != null)
        {
            if (dsGrid.Tables[0].Rows.Count > 0)
            {

                //DataList1.DataSource = dsGrid;
                //DataList1.DataBind();
                ////Lblservicep.Text= dsGrid.Tables[0].Rows[0]["SERVICEPROVDERNAME"].ToString{};
                //lbltotalcount.Text = dsGrid.Tables[0].Rows.Count.ToString();

                DataList1.DataSource = dsGrid;
                DataList1.DataBind();

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
                Show_Error_Success_Box("E", " Record Not Found");
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

    protected void BtnAdd_Click(object sender, EventArgs e)
    {
        Clear_Addpanel();

        if (ddlServiceprovider.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "Select Service Provider");
            //ddlServiceprovider.Focus();
            return;
        }

        if (txtmobileno.Text.Trim() == "")
        {

            Show_Error_Success_Box("E", "Enter Mobile No");
            //ddlServiceprovider.Focus();
            return;
        }

        DataSet dsGrid = ProductController.GetSim_deatils(ddlServiceprovider.SelectedValue, txtmobileno.Text, "", 9);
        if (dsGrid != null)
        {
            if (dsGrid.Tables[0].Rows.Count > 0)
            {
                //    //if (dsGrid.Tables[1].Rows.Count > 0)
                //    {
                //        Show_Error_Success_Box("E", "SIM ALREADY ALLOTED");
                //        return;
                //    }

                ControlVisibility("Add");
                lblHeader_Add.Text = "ADD SIM DETAILS";
                FillDDL_serviceprovider1();
                FillDDL_simtype();
                //FillDDL_Division();
                FillDDL_paymode();
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
            else
            {
                Show_Error_Success_Box("E", "MOBILE NUMBER NOT FOUND IN RECEIVE SIM MASTER");
            }
        }


    }
    protected void Clear_Addpanel()
    {
        Txtcontactno.Text = ""; Txtamount.Text = "";
        TxtUser.Text = ""; Txtpayment.Text = "";
        Txtremarks.Text = ""; Txtpayment.Text = ""; txtBilldate.Value = ""; Txtpaydate.Value = "";
        //TxtRemarks.Text = "";
    }

    protected void BtnClearSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect("Sim_Payment_Details.aspx");
    }
    protected void btnClear_Add_Click(object sender, EventArgs e)
    {
        Response.Redirect("Sim_Payment_Details.aspx");
    }
    private void ControlVisibility(string Mode)
    {
        if (Mode == "Search")
        {
            DivPaymentHistory.Visible = false;
            DivAddPanel.Visible = false;
            DivSearchPanel.Visible = true;
            BtnShowSearchPanel.Visible = false;
            //BtnAdd.Visible = false;
            DivResultPanel.Visible = false;
            DivEditPanel.Visible = false;
        }
        else if (Mode == "Result")
        {
            DivAddPanel.Visible = false;
            DivEditPanel.Visible = false;
            DivSearchPanel.Visible = false;
            BtnShowSearchPanel.Visible = true;
            //BtnAdd.Visible = false;
            DivResultPanel.Visible = true;
            DivPaymentHistory.Visible = false;

        }
        else if (Mode == "Add")
        {
            DivPaymentHistory.Visible = true;
            DivAddPanel.Visible = true;
            DivEditPanel.Visible = false;
            DivSearchPanel.Visible = false;
            BtnShowSearchPanel.Visible = true;
            //BtnAdd.Visible = false;
            DivResultPanel.Visible = false;
            BtnSaveEdit.Visible = false;
            btnSave.Visible = true;

        }
        else if (Mode == "Edit")
        {
            DivPaymentHistory.Visible = false;
            DivAddPanel.Visible = false;
            DivResultPanel.Visible = false;
            DivSearchPanel.Visible = false;
            //BtnAdd.Visible = false;
            DivEditPanel.Visible = true;
            BtnSaveEdit.Visible = true;
            btnSave.Visible = false;
        }

        else if (Mode == "EditClose")
        {
            DivPaymentHistory.Visible = false;
            DivAddPanel.Visible = false;
            DivResultPanel.Visible = true;
            DivSearchPanel.Visible = false;
            //BtnAdd.Visible = false;
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

    private void FillDDL_Division()
    {
        {
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];

            string Flag = "8";

            //DataSet dsDivision = ProductController.Get_Division(Flag);
            //BindDDL(ddlDivision1, dsDivision, "Source_Division_ShortDesc", "Source_Division_Code");
            //ddlDivision1.Items.Insert(0, "Select");
            //ddlDivision1.SelectedIndex = 0;

        }
    }


    int ActiveFlag = 0;

    protected void btnSave_Click(object sender, EventArgs e)
    {


        if (string.IsNullOrEmpty(Txtpayment.Text.Trim()))
        {
            Show_Error_Success_Box("E", "Enter Payment Status");
            Txtpayment.Focus();
            return;
        }
        if (string.IsNullOrEmpty(Txtamount.Text.Trim()))
        {
            Show_Error_Success_Box("E", "Enter Bill Amount");
            Txtamount.Focus();
            return;
        }

        if (txtBilldate.Value == "")
        {
            Show_Error_Success_Box("E", "Enter Period ");
        }

        if (Txtpaydate.Value == "")
        {
            Show_Error_Success_Box("E", "Enter payment Date ");
        }



        string DateRange = "";
        DateRange = txtBilldate.Value;

        string FDate, ToDate;
        FDate = DateRange.Substring(0, 10);
        ToDate = (DateRange.Length > 9) ? DateRange.Substring(DateRange.Length - 10, 10) : DateRange;

        //FDate = DateRange.Substring(0, 10);
        //ToDate = DateRange.Substring(13, 10);

        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        int resultid = 0;
        string flag = "3";

        resultid = ProductController.Insert_Sim_payment_details(ddlServiceprovider1.SelectedValue,
            ddlsimtype.SelectedValue, txtMobilenumber.Text, txtSimnum.Text, TxtRelationshipnum.Text, TxtAccountNum.Text,
            TxtPlan.Text, TxtTariff.Text, TxtUser.Text, Txtcontactno.Text, Txtpayment.Text, ddlpaymode.SelectedValue, Txtamount.Text,
             FDate, ToDate, Txtpaydate.Value, Txtremarks.Text, UserID, 3);

        if (resultid == -1)
        {
            Show_Error_Success_Box("S", "Record Saved Succesfully");
            //ControlVisibility("Search");
            DataSet dsGrid_previous = new DataSet();
            dsGrid_previous = ProductController.GetPayment_deatils(ddlServiceprovider.SelectedValue, txtMobilenumber.Text, 11);
            if (dsGrid_previous != null)
            {
                if (dsGrid_previous.Tables[0].Rows.Count > 0)
                {
                    lbldlerror.Visible = false;
                    lbldlerror.Text = "";
                    DataList3.DataSource = dsGrid_previous;
                    DataList3.DataBind();
                    DataList3.Visible = true;
                    //datatlist.data = dsGrid;
                }
                else
                {
                    DataList3.DataSource = null;
                    DataList3.DataBind();
                    DataList3.Visible = false;
                    lbldlerror.Visible = true;
                    lbldlerror.Text = "No Previous Payment Records Found";
                }
            }

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
        BtnSearch_Click(this, e);
        //BtnAdd.Visible = true;
    }


    protected void BtnShowSearchPanel_Click(object sender, EventArgs e)
    {

        ControlVisibility("Search");
        Clear_Error_Success_Box();
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
        DataList2.RenderControl(oHtmlTextWriter1);
        Response.Write(oStringWriter1.ToString());
        Response.Flush();
        Response.End();
        DataList2.Visible = false;
    }

    protected void BtnSaveEdit_Click(object sender, System.EventArgs e)
    {
        Clear_Error_Success_Box();


        if (ddlpaymode.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "Select Paymode");
            //ddlpaymode.Focus();
            return;
        }
        if (txtBilldate.Value == "")
        {
            Show_Error_Success_Box("E", "Enter Period ");
            return;
        }

        if (Txtpaydate.Value == "")
        {
            Show_Error_Success_Box("E", "Enter payment Date ");
            return;
        }


        string DateRange = "";
        DateRange = txtBilldate.Value;

        string FDate, ToDate;

        FDate = DateRange.Substring(0, 10);
        ToDate = (DateRange.Length > 9) ? DateRange.Substring(DateRange.Length - 10, 10) : DateRange;


        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        int resultid = 0;
        string flag = "4";

        resultid = ProductController.Update_Sim_payement_details(ddlServiceprovider1.SelectedValue,
            ddlsimtype.SelectedValue, txtMobilenumber.Text, txtSimnum.Text, TxtRelationshipnum.Text, TxtAccountNum.Text,
            TxtPlan.Text, TxtTariff.Text, TxtUser.Text, Txtcontactno.Text, Txtpayment.Text, ddlpaymode.SelectedValue, Txtamount.Text,
             FDate, ToDate, Txtpaydate.Value, Txtremarks.Text, UserID, 4);


        if (resultid == -1)
        {
            Show_Error_Success_Box("S", "Record Saved Succesfully");
            ControlVisibility("Search");

        }

    }

    //edit

    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        Clear_Addpanel();

        if (e.CommandName == "Add")
        {
            
            DataSet dsGrid = ProductController.GetSim_deatils(ddlServiceprovider.SelectedValue, e.CommandArgument.ToString(), "", 9);
            DataSet dsGrid_previous = new DataSet();
            dsGrid_previous = ProductController.GetPayment_deatils(ddlServiceprovider.SelectedValue, e.CommandArgument.ToString(), 11);
            if (dsGrid_previous != null)
            {
                if (dsGrid_previous.Tables[0].Rows.Count > 0)
                {

                    lbldlerror.Visible = false;
                    lbldlerror.Text = "";
                    DataList3.DataSource = dsGrid_previous;
                    DataList3.DataBind();
                    DataList3.Visible = true;
                    //datatlist.data = dsGrid;
                }
                else
                {
                    DataList3.DataSource = null;
                    DataList3.DataBind();
                    DataList3.Visible = false;
                    lbldlerror.Visible = true;
                    lbldlerror.Text = "No Previous Payment Records Found";
                }
            }
            if (dsGrid != null)
            {
                if (dsGrid.Tables[0].Rows.Count > 0)
                {
                    //    //if (dsGrid.Tables[1].Rows.Count > 0)
                    //    {
                    //        Shdow_Error_Success_Box("E", "SIM ALREADY ALLOTED");
                    //        return;
                    //    }

                    ControlVisibility("Add");
                    lblHeader_Add.Text = "ADD SIM DETAILS";
                    FillDDL_serviceprovider1();
                    FillDDL_simtype();
                    //FillDDL_Division();
                    FillDDL_paymode();
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
            else
            {
                Show_Error_Success_Box("E", "MOBILE NUMBER NOT FOUND IN RECEIVE SIM MASTER");
            }
        }
        if (e.CommandName == "comEdit")
        {
            lblPkey.Text = e.CommandArgument.ToString();

            //string Flag = "3";
            DataSet DSGrid = ProductController.Get_sim_edit_details(ddlServiceprovider1.SelectedValue.ToString().Trim(),txtMobilenumber.Text, lblPkey.Text, 8);
            if (DSGrid != null)
            {
                if (DSGrid.Tables[0].Rows.Count > 0)
                {
                    FillDDL_serviceprovider1();
                    FillDDL_simtype();
                    FillDDL_paymode();



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
                    TxtUser.Enabled = true;
                    Txtcontactno.Text = DSGrid.Tables[0].Rows[0]["Mobile_No"].ToString();
                    Txtcontactno.Enabled = true;
                    Txtpayment.Text = DSGrid.Tables[0].Rows[0]["Payment_status"].ToString();
                    Txtpayment.Enabled = true;
                    ddlpaymode.SelectedValue = DSGrid.Tables[0].Rows[0]["Payment_mode"].ToString();
                    ddlpaymode.Enabled = true;
                    Txtamount.Text = DSGrid.Tables[0].Rows[0]["Amount"].ToString();
                    Txtamount.Enabled = true;
                    Txtpaydate.Value = DSGrid.Tables[0].Rows[0]["Paymentdate"].ToString();

                    //Txtpaydate.Value = DSGrid.Tables[0].Rows[0]["Paymentdate"].ToString();




                    DivResultPanel.Visible = false;
                    DivAddPanel.Visible = true;
                    BtnSaveEdit.Visible = true;
                    btnSave.Visible = false;
                }
                else
                {
                    Show_Error_Success_Box("E", " SIM IS NOT ACTIVE");
                }


            }
            else
            {
                Show_Error_Success_Box("E", " SIM IS NOT ACTIVE");
            }
        }
    }


    private void FillDDL_paymode()
    {
        {
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];

            string Flag = "4";
            DataSet dspaymode = ProductController.Get_paymode(Flag);
            BindDDL(ddlpaymode, dspaymode, "Description", "Pay_Mode_Code");
            ddlpaymode.Items.Insert(0, "Select");
            ddlpaymode.SelectedIndex = 0;

            //BindDDL(ddlpaymode, dspaymode, "Description", "Pay_Mode_Code");
            //ddlsimtype.Items.Insert(0, "Select");
            //ddlpaymode.SelectedIndex = 0;
        }

    }
}

