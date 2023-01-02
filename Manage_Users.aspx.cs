using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShoppingCart.BL;
using System.IO;
using System.Data;


public partial class Manage_Users : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    private void ControlVisibility(string Mode)
    {
        if (Mode == "Search")
        {
            DivAddPanel.Visible = false;
            DivSearchPanel.Visible = true;
            DivResultPanel.Visible = false;
            BtnShowSearchPanel.Visible = false;
            BtnAdd.Visible = true;
        }
        else if (Mode == "Result")
        {
            DivAddPanel.Visible = false;
            DivSearchPanel.Visible = false;
            DivResultPanel.Visible = true;
            BtnShowSearchPanel.Visible = true;
            BtnAdd.Visible = true;
        }
        else if (Mode == "Add")
        {
            DivAddPanel.Visible = true;
            DivSearchPanel.Visible = false;
            DivResultPanel.Visible = false;
            BtnAdd.Visible = false;
            BtnShowSearchPanel.Visible = true;
            BtnSaveAdd.Visible = true;
            BtnSaveEdit.Visible = false;

        }
        else if (Mode == "Edit")
        {
            DivAddPanel.Visible = true;
            DivSearchPanel.Visible = false;
            DivResultPanel.Visible = false;
            BtnAdd.Visible = false;
            BtnShowSearchPanel.Visible = true;
            BtnSaveEdit.Visible = true;
            BtnSaveAdd.Visible = false;
        }
        else if (Mode == "Save")
        {
            DivAddPanel.Visible = false;
            DivSearchPanel.Visible = false;
            DivResultPanel.Visible = true;

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
    private void Show_Error_Success_Box(string BoxType, string Error_Code)
    {
        if (BoxType == "E")
        {
            Msg_Error.Visible = true;
            Msg_Success.Visible = false;
            lblerror.Text = ProductController.Raise_Error(Error_Code);
            UpdatePanelMsgBox.Update();
            Msg_Error.Focus();
        }
        else
        {
            Msg_Success.Visible = true;
            Msg_Error.Visible = false;
            lblSuccess.Text = ProductController.Raise_Error(Error_Code);
            UpdatePanelMsgBox.Update();
        }
    }
    protected void BtnAdd_Click(object sender, EventArgs e)
    {

    }
    protected void BtnAdd_Click1(object sender, EventArgs e)
    {
        Clear_Error_Success_Box();
        txtFunctionadd.Text = "";
        ControlVisibility("Add");
    }
    protected void BtnShowSearchPanel_Click(object sender, EventArgs e)
    {
        Clear_Error_Success_Box();
        ControlVisibility("Search");
    }
    protected void BtnSearch_Click(object sender, EventArgs e)
    {

        DataSet ds = ProductController.User_details(2, txtfunction.Text, "");
        if (ds != null)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                dlGridDisplay.DataSource = ds;
                dlGridDisplay.DataBind();
                dlUserExport.DataSource = ds;
                dlUserExport.DataBind();
                lbltotalcount.Text = (ds.Tables[0].Rows.Count).ToString();


                ControlVisibility("Result");
            }
            else
            {
                dlGridDisplay.DataSource = null;
                dlGridDisplay.DataBind();
                dlUserExport.DataSource = null;
                dlUserExport.DataBind();
                Show_Error_Success_Box("E", "No Records Found");
                return;

            }
        }
        else
        {
            Show_Error_Success_Box("E", "No Records Found");
            return;
        }

    }


    protected void BtnSaveAdd_Click(object sender, EventArgs e)
    {
        Clear_Error_Success_Box();
        if (txtFunctionadd.Text == "")
        {
            Show_Error_Success_Box("E", "Enter User Name");
            txtFunctionadd.Focus();
            return;
        }
        int ActiveFlag = 0;
        if (chkActive.Checked == true)
            ActiveFlag = 1;
        else
            ActiveFlag = 0;

        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];


        String ResultID = ProductController.Insert_User_Details(1, "", txtFunctionadd.Text, ActiveFlag, UserID);
        if (ResultID == "-1")
        {

            Show_Error_Success_Box("E", "Duplicate Records");
        }
        else
        {
            BtnSearch_Click(this, e);

            Show_Error_Success_Box("S", "Records Save Successfully");

        }
    }
    protected void BtnClearSearch_Click(object sender, EventArgs e)
    {
        Clear_Error_Success_Box();
        txtfunction.Text = "";
    }
    protected void BtnCloseAdd_Click(object sender, EventArgs e)
    {
        Clear_Error_Success_Box();
        BtnSearch_Click(this, e);
    }
    protected void BtnSaveEdit_Click(object sender, EventArgs e)
    {

        Clear_Error_Success_Box();
        if (txtFunctionadd.Text == "")
        {
            Show_Error_Success_Box("E", "Enter User Name");
            txtFunctionadd.Focus();
            return;
        }
        int ActiveFlag = 0;
        if (chkActive.Checked == true)
            ActiveFlag = 1;
        else
            ActiveFlag = 0;

        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];


        String ResultID = ProductController.Insert_User_Details(3, lblPkey.Text, txtFunctionadd.Text, ActiveFlag, UserID);
        if (ResultID == "-1")
        {

            Show_Error_Success_Box("E", "Duplicate Records");
        }
        else
        {
            BtnSearch_Click(this, e);

            Show_Error_Success_Box("S", "Records Updated Successfully");

        }
    }
    protected void dlGridDisplay_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "comEdit")
        {
            Clear_Error_Success_Box();
            lblPkey.Text = "";
            lblPkey.Text = e.CommandArgument.ToString();
            DataSet ds = ProductController.User_details(2, "", lblPkey.Text.Trim());
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtFunctionadd.Text = ds.Tables[0].Rows[0]["User_Type_Name"].ToString();
                    if (Convert.ToInt32(ds.Tables[0].Rows[0]["Is_Active"]) == 0)
                    {
                        chkActive.Checked = false;
                    }
                    else
                    {
                        chkActive.Checked = true;
                    }
                    ControlVisibility("Edit");

                }
            }
        }
    }
    protected void HLExport_Click(object sender, EventArgs e)
    {
        dlUserExport.Visible = true;

        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        string filenamexls1 = "UserDetails" + DateTime.Now + ".xls";
        Response.AddHeader("Content-Disposition", "inline;filename=" + filenamexls1);
        HttpContext.Current.Response.Charset = "utf-8";
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");
        //sets font
        HttpContext.Current.Response.Write("<font style='font-size:10.0pt; font-family:Calibri;'>");
        HttpContext.Current.Response.Write("<BR><BR><BR>");
        HttpContext.Current.Response.Write("<Table border='1'  borderColor='#000000' cellSpacing='0' cellPadding='0' style='font-size:10.0pt; font-family:Calibri; text-align:center;'> <TR style='color: #fff; background: black;text-align:center;'><TD Colspan='4'>User Details</b></TD></TR>");
        Response.Charset = "";
        this.EnableViewState = false;
        System.IO.StringWriter oStringWriter1 = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter oHtmlTextWriter1 = new System.Web.UI.HtmlTextWriter(oStringWriter1);
        //this.ClearControls(dladmissioncount)
        dlUserExport.RenderControl(oHtmlTextWriter1);
        Response.Write(oStringWriter1.ToString());
        Response.Flush();
        Response.End();

        dlUserExport.Visible = false;
    }
}