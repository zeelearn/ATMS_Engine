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

public partial class Rpt_SIM_Issue_Details : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DivSearchPanel.Visible = true;
            DivResultPanel.Visible = false;
            FillDDL_Department();
            //FillDDL_simissue();
        }
    }

    private void FillDDL_Department()
    
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
    private void BindDDL(DropDownList ddl, DataSet ds, string txtField, string valField)
    {
        ddl.DataSource = ds;
        ddl.DataTextField = txtField;
        ddl.DataValueField = valField;
        ddl.DataBind();
    }
    protected void btnexporttoexcel_Click(object sender, EventArgs e)
    {

        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        string filenamexls1 = "SIM User Details" + DateTime.Now + ".xls";
        Response.AddHeader("Content-Disposition", "inline;filename=" + filenamexls1);
        HttpContext.Current.Response.Charset = "utf-8";
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");
        //sets font
        HttpContext.Current.Response.Write("<font style='font-size:10.0pt; font-family:Calibri;'>");
        HttpContext.Current.Response.Write("<BR><BR><BR>");
        HttpContext.Current.Response.Write("<Table border='1'  borderColor='#000000' cellSpacing='0' cellPadding='0' style='font-size:10.0pt; font-family:Calibri; text-align:center;'> <TR style='color: #fff; background: black;text-align:center;'><TD Colspan='8'>SIM User Details</TD></TR>");
        Response.Charset = "";
        this.EnableViewState = false;
        System.IO.StringWriter oStringWriter1 = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter oHtmlTextWriter1 = new System.Web.UI.HtmlTextWriter(oStringWriter1);
        //this.ClearControls(dladmissioncount);
        Repeater1.RenderControl(oHtmlTextWriter1);
        Response.Write(oStringWriter1.ToString());
        Response.Flush();
        Response.End();
    }
    protected void BtnSearch_Click(object sender, System.EventArgs e)
    {
        
        string DateRange = "";
        DateRange = txtdate.Value;

        if (DateRange.Length != 0)
        {

            DateTime fromdate, todate;
            fromdate = Convert.ToDateTime(DateRange.Substring(0, 10));
            todate = Convert.ToDateTime(DateRange.Substring(DateRange.Length - 10));

            string a1 = fromdate.ToString("dd MMM yyyy");
            string a2 = todate.ToString("dd MMM yyyy");

            DataSet ds1 = ProductController.Getissuesimdetaisl(ddlDepartment.SelectedValue, txtusername.Text, Txtmobile.Text, a1, a2);
            if (ds1.Tables[0].Rows.Count > 0 && ds1 != null)
            {
                Repeater1.DataSource = ds1;
                Repeater1.DataBind();
                //script1.RegisterAsyncPostBackControl(Repeater1);
                lbltotalcount.Text = ds1.Tables[0].Rows.Count.ToString();
                Msg_Error.Visible = false;
                DivSearchPanel.Visible = false;
                DivResultPanel.Visible = true;

            }
            else
            {
                Msg_Error.Visible = true;
                lblerror.Visible = true;
                lblerror.Text = "No Record Found. Kindly Re-Select your search criteria";
            }

        }
        else
        {
            string a1 = "";
            string a2 = "";
            DataSet ds1 = ProductController.Getissuesimdetaisl(ddlDepartment.SelectedValue, txtusername.Text, Txtmobile.Text, a1, a2);
            if (ds1.Tables[0].Rows.Count > 0 && ds1 != null)
            {
                Repeater1.DataSource = ds1;
                Repeater1.DataBind();
                //script1.RegisterAsyncPostBackControl(Repeater1);
                lbltotalcount.Text = ds1.Tables[0].Rows.Count.ToString();
                Msg_Error.Visible = false;
                DivSearchPanel.Visible = false;
                DivResultPanel.Visible = true;

            }
            else
            {
                Msg_Error.Visible = true;
                lblerror.Visible = true;
                lblerror.Text = "No Record Found. Kindly Re-Select your search criteria";
            }
        }

    }
    protected void Back_Click(object sender, EventArgs e)
    {
        //Response.Redirect("RptAdmissionCount.aspx");
        //DivSearchPanel.Visible = true;
        DivSearchPanel.Visible = true;
        DivResultPanel.Visible = false;
    }
    //private void FillDDL_simissue()
    //{

    //    HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
    //    string UserID = cookie.Values["UserID"];
    //    string UserName = cookie.Values["UserName"];

    //    string Flag = "13";
    //    DataSet dssimissue = ProductController.Get_Service_provider_list2(Flag);
    //    BindDDL(ddlissuestatus, dssimissue, "ID_Name", "Sim_IssueID");
    //    //ddlissuestatus.Items.Insert(0, "Select");
    //    ddlissuestatus.SelectedIndex = 0;

    //}
    protected void BtnClearSearch_Click(object sender, EventArgs e)
    {
        Txtmobile.Text = "";
        txtusername.Text = "";
        ddlDepartment.SelectedValue = null;
        txtdate.Value = "";
    }
}

       
    
   
