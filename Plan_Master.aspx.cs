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

public partial class Plan_Master : System.Web.UI.Page
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

            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];

            string Flag = "1";
            DataSet dsServiceProvider = ProductController.Get_Service_provider_list2(Flag);
            BindDDL(ddlServiceprovider, dsServiceProvider, "Service_Provider_ShortDesc", "Service_Provider_Code");
            //ddlServiceprovider.Items.Insert(0, "Select");
            ddlServiceprovider.SelectedIndex = 0;
        }

    protected void BtnClearSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect("Plan_Master.aspx");
    }
    protected void btnClear_Add_Click(object sender, EventArgs e)
    {
        Response.Redirect("Plan_Master.aspx");
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
            //DivEditPanel.Visible = false;

        }
        else if (Mode == "Result")
        {
            DivAddPanel.Visible = false;
            //DivEditPanel.Visible = false;
            DivSearchPanel.Visible = false;
            BtnShowSearchPanel.Visible = true;
            BtnAdd.Visible = false;
            DivResultPanel.Visible = true;



        }
        else if (Mode == "Add")
        {
            DivAddPanel.Visible = true;
            //DivEditPanel.Visible = false;
            DivSearchPanel.Visible = false;
            BtnShowSearchPanel.Visible = true;
            BtnAdd.Visible = false;
            DivResultPanel.Visible = false;



        }
        else if (Mode == "Edit")
        {
            DivAddPanel.Visible = false;
            DivResultPanel.Visible = false;
            DivSearchPanel.Visible = false;
            BtnAdd.Visible = false;
            //DivEditPanel.Visible = true;
            //BtnSaveEdit.Visible = true;
            btnSave.Visible = false;
        }

        else if (Mode == "EditClose")
        {
            DivAddPanel.Visible = false;
            DivResultPanel.Visible = true;
            DivSearchPanel.Visible = false;
            BtnAdd.Visible = false;
           // DivEditPanel.Visible = false;

        }
    }
    protected void BtnShowSearchPanel_Click(object sender, EventArgs e)
    {
        ControlVisibility("Search");
        Clear_Error_Success_Box();
        BtnAdd.Visible = true;
    }
    private void Clear_Error_Success_Box()
    {
        Msg_Error.Visible = false;
        Msg_Success.Visible = false;
        lblSuccess.Text = "";
        lblerror.Text = "";
        UpdatePanelMsgBox.Update();
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



          
    protected void BtnAdd_Click(object sender, EventArgs e)
    {
        Clear_Addpanel();
      
        {
            Clear_Error_Success_Box();

            {

                ControlVisibility("Add");
                Clear_Addpanel();
                lblHeader_Add.Text = "Add Plan";
                FillDDL_serviceprovider1();
                //BtnSaveEdit.Visible = false;
                btnSave.Visible = true;

                //ddlServiceprovider1.SelectedValue = dsGrid.Tables[0].Rows[0]["Service_Provider_Name"].ToString();
                //ddlServiceprovider1.Enabled = false;
                
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

    protected void Clear_Addpanel()
    {
        Txtplan.Text = "";
    }
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        //if (ddlServiceprovider.SelectedIndex == 0)
        //{
        //    Show_Error_Success_Box("E", "Select Service Provider");
        //    //ddlServiceprovider.Focus();
        //    return;
        //}
           
        Clear_Error_Success_Box();

        {
            DataSet dsGrid = ProductController.Getplanmaster(ddlServiceprovider.SelectedValue, Txtplan.Text, 1);
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

    }
    int ActiveFlag = 0;
    protected void btnSave_Click(object sender, EventArgs e)
    {
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
        string UserName = cookie.Values["UserName"];
        string resultid = "";
        resultid = ProductController.insert_planmaster(ddlServiceprovider1.SelectedValue, Txtplan.Text,ActiveFlag, UserID, 2);
       
          if (resultid == "1")
            {
                Show_Error_Success_Box("S", "Record Saved Succesfully");
                ControlVisibility("Search");
                //Clear_Error_Success_Box();

            }
            else
            {
                //Show_Error_Success_Box("E", "Mobile Details are not Registered");
            }

    }
    protected void BtnCloseAdd_Click(object sender, EventArgs e)
    {
        ControlVisibility("Search");
        //ControlVisibility("Result");
        BtnAdd.Visible = true;
        Clear_Error_Success_Box();
    }
}




