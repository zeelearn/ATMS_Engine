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

public partial class Issue_device_new : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            FillDDL_serviceprovider();
            FillDDL_Devicetype1();


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

        if (ddlDevicetype1.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "Select Device Type");
            //ddlDevicetype1.Focus();
            return;
        }
        Clear_Error_Success_Box();

        ControlVisibility("Result");

        DataSet dsGrid = new DataSet();
        dsGrid = ProductController.GetSim_deatils(ddlServiceprovider.SelectedValue, "", ddlDevicetype1.SelectedValue, 4);
        if (dsGrid != null)
        {
            if (dsGrid.Tables.Count != 0)
            {

                dlcenter.DataSource = dsGrid;
                dlcenter.DataBind();
                lbltotalcount.Text = dsGrid.Tables[0].Rows.Count.ToString();

                DataList1.DataSource = dsGrid;
                DataList1.DataBind();
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
        ControlVisibility("Add");
        lblHeader_Add.Text = "ADD SIM DETAILS";
        FillDDL_serviceprovider1();
        FillDDL_Devicetype();
        BtnSaveEdit.Visible = false;
        btnSave.Visible = true;
    }

    protected void BtnClearSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect("Iussu_Device.aspx");
    }
    protected void btnClear_Add_Click(object sender, EventArgs e)
    {
        Response.Redirect("Iussu_Device.aspx");
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
            BtnAdd.Visible = true;
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

            //BindDDL(ddlServiceprovider1, dsServiceProvider1, "Service_Provider_ShortDesc", "Service_Provider_Code");
            //ddlServiceprovider1.Items.Insert(0, "Select");
            //ddlServiceprovider1.SelectedIndex = 0;
        }
    }
    private void FillDDL_Devicetype()
    {
        {

            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];

            string Flag = "10";
            DataSet dsDevicetype = ProductController.Get_Devicetype(Flag);
            BindDDL(ddlDevicetype, dsDevicetype, "Device_type_ShortDesc", "Device_type_Code");
            ddlDevicetype.Items.Insert(0, "Select");
            ddlDevicetype.SelectedIndex = 0;

            //BindDDL(ddlsimtype, dssimtype, "Sim_type_ShortDesc", "Sim_type_Code");
            //ddlsimtype.Items.Insert(0, "Select");
            //ddlsimtype.SelectedIndex = 0;
        }
    }

    private void FillDDL_Devicetype1()
    {
        {

            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];

            string Flag = "11";
            DataSet dsDevicetype1 = ProductController.Get_Devicetype2(Flag);
            BindDDL(ddlDevicetype1, dsDevicetype1, "Device_type_ShortDesc", "Device_type_Code");
            ddlDevicetype1.Items.Insert(0, "Select");
            ddlDevicetype1.SelectedIndex = 0;

            //BindDDL(ddlsimtype, dssimtype, "Sim_type_ShortDesc", "Sim_type_Code");
            //ddlsimtype.Items.Insert(0, "Select");
            //ddlsimtype.SelectedIndex = 0;
        }
    }

    int ActiveFlag = 0;
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //Clear_Error_Success_Box();

        //Validation
        //Validate if all information is entered correctly
        if (ddlServiceprovider1.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "Select Service Provider");
            ddlServiceprovider1.Focus();
            return;
        }
        if (ddlDevicetype.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "Select Device Type");
            ddlDevicetype.Focus();
            return;
        }

        if (string.IsNullOrEmpty(txtDeviceName.Text.Trim()))
        {
            Show_Error_Success_Box("E", "Enter Device Name ");
            txtDeviceName.Focus();
            return;
        }
        if (string.IsNullOrEmpty(txtDeviceModel.Text.Trim()))
        {
            Show_Error_Success_Box("E", "Enter Device Model Number");
            txtDeviceModel.Focus();
            return;
        }
        if (string.IsNullOrEmpty(TxtIMEI.Text.Trim()))
        {
            Show_Error_Success_Box("E", "Enter IMEI Number");
            TxtIMEI.Focus();
            return;
        }
        if (string.IsNullOrEmpty(TxtSSID.Text.Trim()))
        {
            Show_Error_Success_Box("E", "Enter SSID Number");
            TxtSSID.Focus();
            return;
        }
        if (string.IsNullOrEmpty(TxtPassword.Text.Trim()))
        {
            Show_Error_Success_Box("E", "Enter Password Details");
            TxtPassword.Focus();
            return;
        }
        if (string.IsNullOrEmpty(TxtSerialNo.Text.Trim()))
        {
            Show_Error_Success_Box("E", "Enter Serial Number");
            TxtSerialNo.Focus();
            return;
        }
        if (string.IsNullOrEmpty(TxtPoweradapter.Text.Trim()))
        {
            Show_Error_Success_Box("E", "Enter Power adapter Details");
            TxtPoweradapter.Focus();
            return;
        }
        //if (Issuedate.Value == "")
        //{
        //    Show_Error_Success_Box("E", "Select Issue Date");
        //     return;
        //}
        if (Txtissuedate.Value == "")
        {
            Show_Error_Success_Box("E", "Select Purchase Date");
            
            return;
        }
        //if (Returneddate.Value == "")
        //{
        //    Show_Error_Success_Box("E", "Select Returned Date");
        //    Returneddate.Focus();
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
        string flag = "1";

        //resultid = ProductController.Insert_Update_device_user_details(ddlServiceprovider1.SelectedValue, ddlDevicetype.SelectedValue, txtDeviceName.Text, txtDeviceModel.Text, TxtIMEI.Text, TxtSSID.Text,
        //    TxtPassword.Text, TxtSerialNo.Text,TxtColor.Text,TxtAccessories.Text,TxtPoweradapter.Text, TxtUser.Text, Txtcontact.Text, Txtmployeid.Text, Txtlocation.Text, TxtApproval.Text, TxtDepartment.Text, ddlDivision1.SelectedValue, ddlCostcenter.SelectedValue, TxtAccessories.Text, TxtPoweradapter.Text, Txtissuedate.Value, TxtReturned.Value,  ActiveFlag, TxtRemark.Text,
        //     UserID, 1);

        if (resultid == 1)
        {
            Show_Error_Success_Box("S", "Record Saved Succesfully");
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
        ControlVisibility("Search");
        BtnAdd.Visible = true;
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


}
