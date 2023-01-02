﻿using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using ShoppingCart.BL;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web;


public partial class Master_Vendor : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
   {
        if (!IsPostBack)
        {
            ////Page_Validation();
            ControlVisibility("Search");
            ////txtDOJ.Value = System.DateTime.Now.ToString("dd MMM yyyy");
            ////txtDOB.Value = System.DateTime.Now.ToString("dd MMM yyyy");
            ////FillDDL_Company();
            FillDDL_Country();
            ////FillDDL_Title();
            ////FillDDL_Gender();
            FillDDL_Status();
            //FillDDL_Division();

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

    //private void FillDDL_Division()
    //{

    //    try
    //    {

    //        Clear_Error_Success_Box();
    //        string Company_Code = "MT";
    //        string DBname = "CDB";

    //        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
    //        string UserID = cookie.Values["UserID"];
    //        string UserName = cookie.Values["UserName"];

    //        DataSet dsDivision = ProductController.GetAllActiveUser_Company_Division_Zone_Center(UserID, Company_Code, "", "", "2", DBname);
    //        BindDDL(ddlDivision_Sr, dsDivision, "Division_Name", "Division_Code");
    //        ddlDivision_Sr.Items.Insert(0, "Select Division");
    //        ddlDivision_Sr.SelectedIndex = 0;


    //    }
    //    catch (Exception ex)
    //    {
    //        Msg_Error.Visible = true;
    //        Msg_Success.Visible = false;
    //        lblerror.Text = ex.ToString();
    //        UpdatePanelMsgBox.Update();
    //        return;
    //    }
    //}

    private void ControlVisibility(string Mode)
    {
        if (Mode == "Search")
        {
            DivResultPanel.Visible = false;
            DivSearchPanel.Visible = true;
            BtnShowSearchPanel.Visible = false;
            DivAddPanel.Visible = false;
            BtnAdd.Visible = true;
          
        }
        else if (Mode == "Result")
        {
            DivResultPanel.Visible = true;
            DivSearchPanel.Visible = false;
            BtnShowSearchPanel.Visible = true;
            DivAddPanel.Visible = false;
            BtnAdd.Visible = true;
        }
        else if (Mode == "Add")
        {
            DivAddPanel.Visible = true;
            DivResultPanel.Visible = false;
            DivSearchPanel.Visible = false;
            BtnShowSearchPanel.Visible = true;
            BtnAdd.Visible = false;
            //txtPartnerName.Text = "";
           // txtvendorid.Text = "";

        }
        Clear_Error_Success_Box();
    }

    protected void BtnAdd_Click(object sender, System.EventArgs e)
    {
        ControlVisibility("Add");
        Clear_AddPanel();

        lblHeader_Add.Text = "Create New Vendor";
        lblTestPKey_Hidden.Text = "";
        BtnSaveEdit.Visible = false;
        BtnSave.Visible = true;
        FillDL_Activity();
    }

    protected void BtnCloseAdd_Click(object sender, System.EventArgs e)
    {
        ControlVisibility("Result");
        Clear_AddPanel();
        DivSearchPanel.Visible = true;
        DivResultPanel.Visible = false;
    }


    protected void dlGridDisplay_ItemCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            lbldelCode.Text = e.CommandArgument.ToString();
            txtDeleteItemName.Text = (((Label)e.Item.FindControl("lblModeName")).Text);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalDelete();", true);
        }
        else if (e.CommandName == "Edit")
        {
            ControlVisibility("Add");
            BtnSave.Visible = false;
            BtnSaveEdit.Visible = true;

            lblPKey_Edit.Text = e.CommandArgument.ToString();
            lblHeader_Add.Text = "Edit Vendor Details";
            lblTestPKey_Hidden.Text = "";
            FillVendorMasterDetails(lblPKey_Edit.Text, e.CommandName);
        }
    }

    private void FillVendorMasterDetails(string PKey, string CommandName)
    {

        try
        {



            FillDL_Activity();

            ////Label lblHeader_User_Code = default(Label);
            ////lblHeader_User_Code = (Label)Master.FindControl("lblHeader_User_Code");

            DataSet dsCRoom = ProductController.GetVendorMaster_ByPKey(PKey);


            if (dsCRoom.Tables[0].Rows.Count > 0)
            {
                lblTestPKey_Hidden.Text = PKey;

                string Vendor_Id = null;
                Vendor_Id = Convert.ToString(dsCRoom.Tables[0].Rows[0]["Vendor_Id"]);


                string Country_Code = null;
                Country_Code = Convert.ToString(dsCRoom.Tables[0].Rows[0]["Country_Code"]);


                string State_Code = null;
                State_Code = Convert.ToString(dsCRoom.Tables[0].Rows[0]["State_Code"]);

                string City_Code = null;
                City_Code = Convert.ToString(dsCRoom.Tables[0].Rows[0]["City_Code"]);

                ddlCountry_Add.SelectedValue = Country_Code;
                FillDDL_State_Add();

                ddlState_Add.SelectedValue = State_Code;
                FillDDL_City_Add();

                ddlCity_Add.SelectedValue = City_Code;

                //int Cnt = 0;
                //for ( int cnt = 0; cnt <= ddlTitle_Add.Items.Count - 1; cnt++)
                //{
                //    if (ddlTitle_Add.Items[Cnt].Text == dsCRoom.Tables[0].Rows[0]["Title"])
                //    {
                //        ddlTitle_Add.SelectedIndex = Cnt;
                //    }
                //}

                ////ddlTitle_Add.SelectedIndex = -1;

                ////ddlTitle_Add.Items.FindByText(dsCRoom.Tables[0].Rows[0]["Title"].ToString()).Selected = true;


                txtFirstName_Add.Text = Convert.ToString(dsCRoom.Tables[0].Rows[0]["Vendor_Name"]);
                ////txtMiddleName_Add.Text = Convert.ToString(dsCRoom.Tables[0].Rows[0]["MiddleName"]);
                ////txtLastName_Add.Text = Convert.ToString(dsCRoom.Tables[0].Rows[0]["LastName"]);
                ////txtHandPhone1_Add.Text = Convert.ToString(dsCRoom.Tables[0].Rows[0]["HandPhone1"]);
                txtvendorcode.Text = Convert.ToString(dsCRoom.Tables[0].Rows[0]["Vendor_Id"]);
                txtvendorcode.Enabled = false;
                txtPhoneNo_Add.Text = Convert.ToString(dsCRoom.Tables[0].Rows[0]["Landline"]);
                ////ddlCompany_Add.SelectedValue = Convert.ToString(dsCRoom.Tables[0].Rows[0]["Company_Code"]);
                txtEmailId_Add.Text = Convert.ToString(dsCRoom.Tables[0].Rows[0]["Emailid"]);
                ////ddlGender_Add.SelectedValue = Convert.ToString(dsCRoom.Tables[0].Rows[0]["Gender"]);
                txtAreaName_Add.Text = Convert.ToString(dsCRoom.Tables[0].Rows[0]["Area_Name"]);
                txtRoadName_Add.Text = Convert.ToString(dsCRoom.Tables[0].Rows[0]["StreetName"]);
                txtBuilding_Add.Text = Convert.ToString(dsCRoom.Tables[0].Rows[0]["BuildingName"]);
                txtRoomNo_Add.Text = Convert.ToString(dsCRoom.Tables[0].Rows[0]["FlatNo"]);
                txtPincode_Add.Text = Convert.ToString(dsCRoom.Tables[0].Rows[0]["Pincode"]);
                txtBeneficiaryName.Text = Convert.ToString(dsCRoom.Tables[0].Rows[0]["Beneficiary_Name"]);
                txtBankaddress.Text = Convert.ToString(dsCRoom.Tables[0].Rows[0]["Bank_address"]);
                txtRemarks_Add.Text = Convert.ToString(dsCRoom.Tables[0].Rows[0]["Remarks"]);
                txtAccountNumber_Add.Text = Convert.ToString(dsCRoom.Tables[0].Rows[0]["BankACNo"]);
                txtIFSCCode_Add.Text = Convert.ToString(dsCRoom.Tables[0].Rows[0]["BankIFSECode"]);
                txtBranchName_Add.Text = Convert.ToString(dsCRoom.Tables[0].Rows[0]["BankBranch"]);
                txtcontactPerson.Text = Convert.ToString(dsCRoom.Tables[0].Rows[0]["ContactPerson"]);
                txtPanNumber_Add.Text = Convert.ToString(dsCRoom.Tables[0].Rows[0]["PANNo"]);
                txtmobContPerson.Text = Convert.ToString(dsCRoom.Tables[0].Rows[0]["ContactPerson_MobileNo"]);
                txtcontper_email.Text = Convert.ToString(dsCRoom.Tables[0].Rows[0]["ContactPerson_EmailId"]);
                txtptregno.Text = Convert.ToString(dsCRoom.Tables[0].Rows[0]["PTRegNo"]);

                ////if (dsCRoom.Tables[0].Rows[0]["DOB"].ToString() != "")
                ////{
                ////    txtDOB.Value = Convert.ToString(Convert.ToDateTime(dsCRoom.Tables[0].Rows[0]["DOB"]).ToString("dd MMM yyyy"));
                ////}
                ////if (dsCRoom.Tables[0].Rows[0]["DOJ"].ToString() != "")
                ////{
                ////    txtDOJ.Value = Convert.ToString(Convert.ToDateTime(dsCRoom.Tables[0].Rows[0]["DOJ"]).ToString("dd MMM yyyy"));

                ////}
                
                
                ////lblCompany_Add.Text = ddlCompany_Add.SelectedItem.ToString();
                ////ddlCompany_Add.Visible = false;
                ////lblCompany_Add.Visible = true;
                FillDDL_Centre();

                //ddlLocation_Add.SelectedValue = dsCRoom.Tables(0).Rows(0)("Location_Code")

                if (Convert.ToInt32(dsCRoom.Tables[0].Rows[0]["Is_Active"]) == 0)
                {
                    chkActiveFlag.Checked = false;
                }
                else
                {
                    chkActiveFlag.Checked = true;
                }

                ////for (int cnt = 0; cnt <= dsCRoom.Tables[1].Rows.Count - 1; cnt++)
                ////{

                ////    foreach (DataListItem dtlItem in dlCentre_Add.Items)
                ////    {
                ////        CheckBox chkDL_Select_Centre = (CheckBox)dtlItem.FindControl("chkDL_Select_Centre");
                ////        Label lblDivisionCode = (Label)dtlItem.FindControl("lblDivisionCode");
                ////        if (Convert.ToString(lblDivisionCode.Text).Trim() == Convert.ToString(dsCRoom.Tables[1].Rows[cnt]["Division_Code"]).Trim())
                ////        { 
                ////            chkDL_Select_Centre.Checked = true;
                ////            break; // TODO: might not be correct. Was : Exit For
                ////        }
                ////    }

                ////}

                ////for (int cnt = 0; cnt <= dsCRoom.Tables[2].Rows.Count - 1; cnt++)
                ////{
                ////    foreach (DataListItem dtlItem in dlCapacity_Add.Items)
                ////    {
                ////        CheckBox chkDL_Select_Activity = (CheckBox)dtlItem.FindControl("chkDL_Select_Activity");
                ////        Label lblDL_Activity_Id = (Label)dtlItem.FindControl("lblDL_Activity_Id");
                ////        if (lblDL_Activity_Id.Text.Trim() == dsCRoom.Tables[2].Rows[cnt]["Activity_Id"].ToString().Trim())
                ////        {
                ////            chkDL_Select_Activity.Checked = true;
                ////            break; // TODO: might not be correct. Was : Exit For
                ////        }
                ////    }

                ////}

                //'dlCentre_Add.DataSource = dsCRoom.Tables(3)
                //'dlCentre_Add.DataBind()

            }
        }
        catch (Exception ex)
        {
            Show_Error_Success_Box("E", ex.ToString());
            return;
        }
    }

    protected void BtnShowSearchPanel_Click(object sender, System.EventArgs e)
    {
        ControlVisibility("Search");
    }

    private void BindDDL(DropDownList ddl, DataSet ds, string txtField, string valField)
    {
        ddl.DataSource = ds;
        ddl.DataTextField = txtField;
        ddl.DataValueField = valField;
        ddl.DataBind();
    }

    ////private void FillDDL_Gender()
    ////{
    ////    ddlGender_Add.Items.Clear();
    ////    ddlGender_Add.Items.Add("Select");
    ////    ddlGender_Add.Items.Add("Male");
    ////    ddlGender_Add.Items.Add("Female");
    ////    ddlGender_Add.SelectedIndex = 0;
    ////}

    private void FillDDL_Country()
    {
        
        DataSet dsDivision = ProductController.GetAllActiveCountry();
        BindDDL(ddlCountry, dsDivision, "Country_Name", "Country_Code");
        ddlCountry.Items.Insert(0, "Select");
        ddlCountry.SelectedIndex = 0;

        BindDDL(ddlCountry_Add, dsDivision, "Country_Name", "Country_Code");
        ddlCountry_Add.Items.Insert(0, "Select");
        ddlCountry_Add.SelectedIndex = 0;

    }

    private void FillDDL_Centre()
    {
        ////dlCentre_Add.DataSource = null;
        ////dlCentre_Add.DataBind();

        
        string DBname = "CDB";

        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];


        //DataSet dsCentre = ProductController.GetAllActiveUser_Company_Division_Zone_Center(UserID, Company_Code, "", "", "2", DBname);
        DataSet dsCentre = ProductController.GetAllActiveUser_Company_Division_Zone_Center("","", "", "", "16", DBname);
        ////dlCentre_Add.DataSource = dsCentre;
        ////dlCentre_Add.DataBind();
    }

    ////private void FillDDL_Title()
    ////{
    ////    DataSet dsTitle = ProductController.GetAllActivePartnerTitle();
    ////    BindDDL(ddlTitle_Add, dsTitle, "Title_Name", "Title_Id");
    ////    ddlTitle_Add.Items.Insert(0, "Select");
    ////    ddlTitle_Add.SelectedIndex = 0;

    ////    BindDDL(ddlTitle_Gender, dsTitle, "Gender", "Title_Id");
    ////    ddlTitle_Gender.Items.Insert(0, "Select");
    ////    ddlTitle_Gender.SelectedIndex = 0;

    ////}


    private void FillDDL_Status()
    {
        ddlStatus.Items.Insert(0, "All");
        ddlStatus.Items.Insert(1, "Active");
        ddlStatus.Items.Insert(2, "In Active");
        ddlStatus.SelectedIndex = 0;

    }

    ////private void FillDDL_Company()
    ////{
    ////    string Company_Code = "MT";
    ////    string DBname = "CDB";

    ////    HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
    ////    string UserID = cookie.Values["UserID"];
    ////    string UserName = cookie.Values["UserName"];

    ////    DataSet dsCompany = ProductController.GetAllActiveUser_Company_Division_Zone_Center(UserID, Company_Code, "", "", "1", DBname);
    ////    BindDDL(ddlCompany_Add, dsCompany, "Company_Name", "Company_Code");
    ////    ddlCompany_Add.Items.Insert(0, "Select");
    ////    ddlCompany_Add.SelectedIndex = 0;
    ////}

    protected void ddlCountry_Add_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        FillDDL_State_Add();

        Clear_Error_Success_Box();
    }

    protected void ddlCountry_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        FillDDL_State();
        Clear_Error_Success_Box();
    }

    private void FillDDL_State()
    {
        string Country_Code = null;
        Country_Code = ddlCountry.SelectedValue;

        DataSet dsState = ProductController.GetAllActiveState(Country_Code);
        BindDDL(ddlState, dsState, "State_Name", "State_Code");
        ddlState.Items.Insert(0, "Select");
        ddlState.SelectedIndex = 0;
    }

    private void FillDDL_State_Add()
    {
        string Country_Code = null;
        Country_Code = ddlCountry_Add.SelectedValue;

        DataSet dsState = ProductController.GetAllActiveState(Country_Code);
        BindDDL(ddlState_Add, dsState, "State_Name", "State_Code");
        ddlState_Add.Items.Insert(0, "Select");
        ddlState_Add.SelectedIndex = 0;
    }

    private void FillDDL_City()
    {
        string State_Code = null;
        State_Code = ddlState.SelectedValue;

        DataSet dsCity = ProductController.GetAllActiveCity(State_Code);
        BindDDL(ddlCity, dsCity, "City_Name", "City_Code");
        ddlCity.Items.Insert(0, "Select");
        ddlCity.SelectedIndex = 0;
    }

    private void FillDDL_City_Add()
    {
        string State_Code = null;
        State_Code = ddlState_Add.SelectedValue;

        DataSet dsCity = ProductController.GetAllActiveCity(State_Code);
        BindDDL(ddlCity_Add, dsCity, "City_Name", "City_Code");
        ddlCity_Add.Items.Insert(0, "Select");
        ddlCity_Add.SelectedIndex = 0;
    }

    //Private Sub FillDDL_Location()
    //    Dim City_Code As String
    //    City_Code = ddlCity.SelectedValue

    //    Dim dsLocation As DataSet = ProductController.GetAllActiveLocation(City_Code)
    //    BindListBox(ddlLocation, dsLocation, "Location_Name", "Location_Code")
    //End Sub

    //Private Sub FillDDL_Location_Add()
    //    Dim City_Code As String
    //    City_Code = ddlCity_Add.SelectedValue

    //    Dim dsLocation As DataSet = ProductController.GetAllActiveLocation(City_Code)
    //    BindDDL(ddlLocation_Add, dsLocation, "Location_Name", "Location_Code")
    //    ddlLocation_Add.Items.Insert(0, "Select")
    //    ddlLocation_Add.SelectedIndex = 0
    //End Sub

    private void BindListBox(ListBox ddl, DataSet ds, string txtField, string valField)
    {
        ddl.DataSource = ds;
        ddl.DataTextField = txtField;
        ddl.DataValueField = valField;
        ddl.DataBind();
    }

    protected void ddlState_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        FillDDL_City();
        Clear_Error_Success_Box();
    }

    protected void ddlState_Add_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        FillDDL_City_Add();
        Clear_Error_Success_Box();
    }

    protected void ddlCity_Add_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        //FillDDL_Location_Add()
        //Clear_Error_Success_Box()
    }

    ////public void All_Centre_ChkBox_Selected(object sender, System.EventArgs e)//NFFFF
    ////{
    ////    //Change checked status of a hidden check box
    ////    chkCentreAllHidden_Sel.Checked = !(chkCentreAllHidden_Sel.Checked);

    ////    //Set checked status of hidden check box to items in grid
    ////    foreach (DataListItem dtlItem in dlCentre_Add.Items)
    ////    {
    ////        CheckBox chkitemck = (CheckBox)dtlItem.FindControl("chkCentre");

    ////        chkitemck.Checked = chkCentreAllHidden_Sel.Checked;
    ////    }

    ////}

    public void chkCentre_Checked(object sender, System.EventArgs e)//NFFFFF
    {
        CheckBox chkCentre = (CheckBox)sender;
        DataListItem row = (DataListItem)chkCentre.NamingContainer;

        HtmlInputCheckBox chkDL_PrimaryFlag = (HtmlInputCheckBox)row.FindControl("chkDL_PrimaryFlag");

        if (chkCentre.Checked == true)
        {
            chkDL_PrimaryFlag.Visible = true;
        }
        else
        {
            chkDL_PrimaryFlag.Checked = false;
            chkDL_PrimaryFlag.Visible = false;
        }
    }

    protected void BtnSave_Click(object sender, System.EventArgs e)
    {
        Clear_Error_Success_Box();

        //Validation
        //Validate if all information is entered correctly
        ////if (ddlTitle_Add.SelectedIndex == 0)
        ////{
        ////    Show_Error_Success_Box("E", "0053");
        ////    ddlTitle_Add.Focus();
        ////    return;
        ////}

        if (string.IsNullOrEmpty(txtFirstName_Add.Text.Trim()))
        {
            Show_Error_Success_Box("E", "0054");
            txtFirstName_Add.Focus();
            return;
        }

        if (string.IsNullOrEmpty(txtvendorcode.Text.Trim()))
        {
            Show_Error_Success_Box("E", "Enter Vendor Code");
            txtvendorcode.Focus();
            return;
        }

        //if (string.IsNullOrEmpty(txtIFSCCode_Add.Text.Trim()))
        //{
        //    Show_Error_Success_Box("E","Enter IFSC Code");
        //    txtIFSCCode_Add.Focus();
        //    return;
        //}

        //if (string.IsNullOrEmpty(txtBranchName_Add .Text .Trim ()))
        //{
        //    Show_Error_Success_Box("E","Enter Branch Name");
        //    txtBranchName_Add.Focus();
        //    return;
        //}

        
        ////if (string.IsNullOrEmpty(txtHandPhone1_Add.Text.Trim()))
        ////{
        ////    Show_Error_Success_Box("E", "0055");
        ////    txtHandPhone1_Add.Focus();
        ////    return;
        ////}

        ////if (string.IsNullOrEmpty(txtLastName_Add.Text.Trim()))
        ////{
        ////    Show_Error_Success_Box("E", "Enter Last Name");
        ////    txtLastName_Add.Focus();
        ////    return;
        ////}

        ////if ((txtHandPhone1_Add.Text.Trim().Length) < 10)
        ////{
        ////    Show_Error_Success_Box("E", "0059");
        ////    txtHandPhone1_Add.Focus();
        ////    return;
        ////}

        ////if (txtHandPhone2_Add.Text.Length > 0 && txtHandPhone2_Add.Text.Trim().Length < 10)
        ////{
        ////    Show_Error_Success_Box("E", "0060");
        ////    txtHandPhone1_Add.Focus();
        ////    return;
        ////}

        ////if (ddlGender_Add.SelectedIndex == 0)
        ////{
        ////    Show_Error_Success_Box("E", "0056");
        ////    ddlGender_Add.Focus();
        ////    return;
        ////}

        ////if (ddlCompany_Add.SelectedIndex == 0)
        ////{
        ////    Show_Error_Success_Box("E", "0043");
        ////    ddlCompany_Add.Focus();
        ////    return;
        ////}

        if (ddlCountry_Add.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "0040");
            ddlCountry_Add.Focus();
            return;
        }

        if (ddlState_Add.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "0041");
            ddlState_Add.Focus();
            return;
        }

        if (ddlCity_Add.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "0042");
            ddlCity_Add.Focus();
            return;
        }
        //if (txtcontper_email.Text.ToString().Trim() != "")
        //{
        //    if (ContPersonEmail.ErrorMessage == "Invalid Email Format")
        //    {
        //        Show_Error_Success_Box("E", "Invalid Email Format");
        //        txtcontper_email.Focus();
        //        return;
        //    }
        //}
        //if (txtEmailId_Add.Text.ToString().Trim() != "")
        //{
        //    if (regexEmailValid.ErrorMessage == "Invalid Email Format")
        //    {
        //        Show_Error_Success_Box("E", "Invalid Email Format");
        //        txtEmailId_Add.Focus();
        //        return;
        //    }
        //}
        if(txtPincode_Add.Text.ToString().Trim() != "")
        {
            if (txtPincode_Add.Text.Length != 6)
        {
            Show_Error_Success_Box("E", "Pin code must be 6 numeric digits");
            txtPincode_Add.Focus();
            return;
        }
        }
        if (txtmobContPerson.Text.ToString().Trim() != "")
        {
            if (txtmobContPerson.Text.Length > 0 && txtmobContPerson.Text.Length < 10)
            {
                Show_Error_Success_Box("E", "Mobile No must be 10 numeric digits");
                txtmobContPerson.Focus();
                return;
            }
        }

        if (txtPhoneNo_Add.Text.ToString().Trim() != "")
        {
            if (txtPhoneNo_Add.Text.Length > 0 && txtPhoneNo_Add.Text.Length < 10)
            {
                Show_Error_Success_Box("E", "Cont Person Mobile No Must Be Of 10 Digits");
                txtPhoneNo_Add.Focus();
                return;
            }

        }

        ////int SelCnt = 0;
        //////Check if unit of measurement is mentioned or not
        ////SelCnt = 0;
        ////string ActivityCode = "";
        ////foreach (DataListItem dtlItem in dlCapacity_Add.Items)
        ////{
        ////    CheckBox chkDL_Select_Activity = (CheckBox)dtlItem.FindControl("chkDL_Select_Activity");
        ////    Label lblDL_Activity_Id = (Label)dtlItem.FindControl("lblDL_Activity_Id");
        ////    if (chkDL_Select_Activity.Checked == true)
        ////    {
        ////        SelCnt = SelCnt + 1;
        ////        ActivityCode = ActivityCode + lblDL_Activity_Id.Text + ",";
        ////    }
        ////}
        ////ActivityCode = Common.RemoveComma(ActivityCode);
        //if (Strings.Right(ActivityCode, 1) == ",")
        //    ActivityCode = Strings.Left(ActivityCode, Strings.Len(ActivityCode) - 1);

        ////if (SelCnt == 0)
        ////{
        ////    Show_Error_Success_Box("E", "0057");
        ////    return;
        ////}

        ////SelCnt = 0;
        string DivisionCode = "";
        ////foreach (DataListItem dtlItem in dlCentre_Add.Items)
        ////{
        ////    CheckBox chkDL_Select_Centre = (CheckBox)dtlItem.FindControl("chkDL_Select_Centre");
        ////    Label lblDivisionCode = (Label)dtlItem.FindControl("lblDivisionCode");

        ////    if (chkDL_Select_Centre.Checked == true)
        ////    {
        ////        SelCnt = SelCnt + 1;
        ////        DivisionCode = DivisionCode + lblDivisionCode.Text + ",";

        ////    }
        ////}
        DivisionCode = Common.RemoveComma(DivisionCode);
        //if (Strings.Right(DivisionCode, 1) == ",")
        //    DivisionCode = Strings.Left(DivisionCode, Strings.Len(DivisionCode) - 1);

        ////if (SelCnt == 0)
        ////{
        ////    Show_Error_Success_Box("E", "0001");
        ////    ////dlCentre_Add.Focus();
        ////    return;
        ////}


        //Save
        string ResultId = null;
        string CountryCode = null;
        CountryCode = ddlCountry_Add.SelectedValue;

        ////string CompanyCode = null;
        ////CompanyCode = ddlCompany_Add.SelectedValue;

        string StateCode = null;
        StateCode = ddlState_Add.SelectedValue;

        string CityCode = null;
        CityCode = ddlCity_Add.SelectedValue;

        string LocationCode = null;
        LocationCode = "";

        Label lblHeader_User_Code = default(Label);
        lblHeader_User_Code = (Label)Master.FindControl("lblHeader_User_Code");

        string CreatedBy = null;
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        CreatedBy = UserID;

        int ActiveFlag = 0;
        if (chkActiveFlag.Checked == true)
        {
            ActiveFlag = 1;
        }
        else
        {
            ActiveFlag = 0;
        }

        string AreaName = null;
        AreaName = txtAreaName_Add.Text;

        string Remarks = null;
        Remarks = txtRemarks_Add.Text;
        string Vendor_Code;

        ResultId = ProductController.Insert_Vendor(lblPKey_Edit.Text, txtFirstName_Add.Text, txtPhoneNo_Add.Text, txtmobContPerson.Text, txtcontper_email.Text, txtRoomNo_Add.Text, txtBuilding_Add.Text, txtRoadName_Add.Text, CountryCode, StateCode, CityCode, LocationCode,
        txtPincode_Add.Text, ActiveFlag, CreatedBy,  AreaName, Remarks, txtAccountNumber_Add.Text, txtBranchName_Add.Text, txtPanNumber_Add.Text, txtIFSCCode_Add.Text, txtFirstName_Add.Text, txtEmailId_Add.Text, ddlCountry_Add.Text,
        txtcontactPerson.Text, txtptregno.Text, "", "", "", "", "", "", "", "",txtvendorcode.Text, txtBeneficiaryName.Text, txtBankaddress.Text);

        //Close the Add Panel and go to Search Grid
        if (ResultId == "-1")
        {
            Show_Error_Success_Box("E", "Vendor Code Already Exists");
            txtFirstName_Add.Focus();
            return;
        }
        else
        {
            ControlVisibility("Search");
            Clear_AddPanel();
            BtnSearch_Click(sender, e);
            Show_Error_Success_Box("S", "0000");
           

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
        }
        else
        {
            Msg_Success.Visible = true;
            Msg_Error.Visible = false;
            lblSuccess.Text = ProductController.Raise_Error(Error_Code);
            UpdatePanelMsgBox.Update();
        }
    }

    private void Clear_AddPanel()
    {
        ////ddlCompany_Add.SelectedIndex = 0;
        ddlCountry_Add.SelectedIndex = 0;
        ddlState_Add.Items.Clear();
        ddlCity_Add.Items.Clear();
        //ddlLocation_Add.Items.Clear()

        ////dlCapacity_Add.DataSource = null;
        ////dlCapacity_Add.DataBind();
        ////dlCentre_Add.DataSource = null;
        ////dlCentre_Add.DataBind();

        txtFirstName_Add.Text = "";
        txtBeneficiaryName.Text = "";
        txtBankaddress.Text = "";
        ////txtHandPhone1_Add.Text = "";
        ////txtHandPhone2_Add.Text = "";
        txtPhoneNo_Add.Text = "";
        txtEmailId_Add.Text = "";
        ////ddlTitle_Add.SelectedIndex = 0;
        txtBuilding_Add.Text = "";
        txtRoomNo_Add.Text = "";
        txtRoadName_Add.Text = "";
        txtPincode_Add.Text = "";
        txtvendorcode.Text = "";
        txtvendorcode.Enabled = true;
        txtRemarks_Add.Text = "";
        ////txtQualification_Add.Text = "";
        txtAreaName_Add.Text = "";
        txtAccountNumber_Add.Text = "";
        txtIFSCCode_Add.Text = "";
        txtBranchName_Add.Text = "";
        txtPanNumber_Add.Text = "";
        txtcontper_email.Text = "";
        txtmobContPerson.Text = "";
        txtptregno.Text = "";
        txtcontactPerson.Text = "";
        ////ddlCompany_Add.Visible = true;
        ////lblCompany_Add.Visible = false;

        BtnSaveEdit.Visible = false;
        BtnSave.Visible = true;
        ////txtDOJ.Value = System.DateTime.Now.ToString("dd MMM yyyy");
        ////txtDOB.Value = System.DateTime.Now.ToString("dd MMM yyyy");
    }

    //Protected Sub ddlLocation_Add_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlLocation_Add.SelectedIndexChanged
    //    Clear_Error_Success_Box()
    //End Sub

    protected void btnDelete_Yes_Click(object sender, System.EventArgs e)
    {
        //Clear_Error_Success_Box()
        //'Authorise the selected test
        //Dim PKey As String
        //PKey = lblPKey_Authorise.Text

        //Dim lblHeader_User_Code As Label
        //lblHeader_User_Code = CType(Master.FindControl("lblHeader_User_Code"), Label)

        //Dim AlteredBy As String
        //AlteredBy = lblHeader_User_Code.Text

        //Dim ResultId As Integer
        //ResultId = ProductController.UpdateTest_Authorise_Block(PKey, 2, AlteredBy)

        //'Close the Add Panel and go to Search Grid
        //If ResultId = 1 Then
        //    ControlVisibility("Result")
        //    BtnSearch_Click(sender, e)
        //    Show_Error_Success_Box("S", "0000")
        //    Clear_AddPanel()
        //End If
    }

    protected void ddlCity_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        //FillDDL_Location()
        //Clear_Error_Success_Box()
    }

    protected void ddlCompany_Add_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        FillDDL_Centre();
        Clear_Error_Success_Box();
    }

    private void FillDL_Activity()
    {
        DataSet dsGrid = ProductController.GetAllActiveActivity("", "2");
        ////dlCapacity_Add.DataSource = dsGrid;
        ////dlCapacity_Add.DataBind();
    }

    //protected void BtnSaveEdit_Click(object sender, System.EventArgs e)
    //{
    //    Clear_Error_Success_Box();

    //    //Validation
    //    //Validate if all information is entered correctly
    //    ////if (ddlTitle_Add.SelectedIndex == 0)
    //    ////{
    //    ////    Show_Error_Success_Box("E", "0053");
    //    ////    ddlTitle_Add.Focus();
    //    ////    return;
    //    ////}

    //    if (string.IsNullOrEmpty(txtFirstName_Add.Text.Trim()))
    //    {
    //        Show_Error_Success_Box("E", "0054");
    //        txtFirstName_Add.Focus();
    //        return;
    //    }

    //    if (string.IsNullOrEmpty(txtHandPhone1_Add.Text.Trim()))
    //    {
    //        Show_Error_Success_Box("E", "0055");
    //        txtHandPhone1_Add.Focus();
    //        return;
    //    }

    //    //if (string.IsNullOrEmpty(txtAccountNumber_Add.Text.Trim()))
    //    //{
    //    //    Show_Error_Success_Box("E", "Enter Account Number");
    //    //    txtAccountNumber_Add.Focus();
    //    //    return;
    //    //}

    //    //if (string.IsNullOrEmpty(txtIFSCCode_Add.Text.Trim()))
    //    //{
    //    //    Show_Error_Success_Box("E", "Enter IFSC Code");
    //    //    txtIFSCCode_Add.Focus();
    //    //    return;
    //    //}

    //    //if (string.IsNullOrEmpty(txtBranchName_Add.Text.Trim()))
    //    //{
    //    //    Show_Error_Success_Box("E", "Enter Branch Name");
    //    //    txtBranchName_Add.Focus();
    //    //    return;
    //    //}

    //    //if (string.IsNullOrEmpty(txtPanNumber_Add.Text.Trim()))
    //    //{
    //    //    Show_Error_Success_Box("E", "Enter Pan Number");
    //    //    txtPanNumber_Add.Focus();
    //    //    return;
    //    //}

    //    if ((txtHandPhone1_Add.Text.Trim().Length) < 10)
    //    {
    //        Show_Error_Success_Box("E", "0059");
    //        txtHandPhone1_Add.Focus();
    //        return;
    //    }

    //    if ((txtHandPhone2_Add.Text.Length) > 0 && txtHandPhone2_Add.Text.Trim().Length < 10)
    //    {
    //        Show_Error_Success_Box("E", "0060");
    //        txtHandPhone1_Add.Focus();
    //        return;
    //    }

    //    if (ddlGender_Add.SelectedIndex == 0)
    //    {
    //        Show_Error_Success_Box("E", "0056");
    //        ddlGender_Add.Focus();
    //        return;
    //    }

    //    if (ddlCompany_Add.SelectedIndex == 0)
    //    {
    //        Show_Error_Success_Box("E", "0043");
    //        ddlCompany_Add.Focus();
    //        return;
    //    }

    //    if (ddlCountry_Add.SelectedIndex == 0)
    //    {
    //        Show_Error_Success_Box("E", "0040");
    //        ddlCountry_Add.Focus();
    //        return;
    //    }

    //    if (ddlState_Add.SelectedIndex == 0)
    //    {
    //        Show_Error_Success_Box("E", "0041");
    //        ddlState_Add.Focus();
    //        return;
    //    }

    //    if (ddlCity_Add.SelectedIndex == 0)
    //    {
    //        Show_Error_Success_Box("E", "0042");
    //        ddlCity_Add.Focus();
    //        return;
    //    }

    //    ////if (string.IsNullOrEmpty(txtLastName_Add.Text.Trim()))
    //    ////{
    //    ////    Show_Error_Success_Box("E", "Enter Last Name");
    //    ////    txtLastName_Add.Focus();
    //    ////    return;
    //    ////}

    //    int SelCnt = 0;
    //    //Check if unit of measurement is mentioned or not
    //    SelCnt = 0;
    //    string ActivityCode = "";
    //    ////foreach (DataListItem dtlItem in dlCapacity_Add.Items)
    //    ////{
    //    ////    CheckBox chkDL_Select_Activity = (CheckBox)dtlItem.FindControl("chkDL_Select_Activity");
    //    ////    Label lblDL_Activity_Id = (Label)dtlItem.FindControl("lblDL_Activity_Id");
    //    ////    if (chkDL_Select_Activity.Checked == true)
    //    ////    {
    //    ////        SelCnt = SelCnt + 1;
    //    ////        ActivityCode = ActivityCode + lblDL_Activity_Id.Text + ",";
    //    ////    }
    //    ////}
    //    ActivityCode = Common.RemoveComma(ActivityCode);
    //    //if (Strings.Right(ActivityCode, 1) == ",")
    //    //    ActivityCode = Strings.Left(ActivityCode, Strings.Len(ActivityCode) - 1);

    //    if (SelCnt == 0)
    //    {
    //        Show_Error_Success_Box("E", "0057");
    //        return;
    //    }

    //    ////SelCnt = 0;
    //    string DivisionCode = "";
    //    ////foreach (DataListItem dtlItem in dlCentre_Add.Items)
    //    ////{
    //    ////    CheckBox chkDL_Select_Centre = (CheckBox)dtlItem.FindControl("chkDL_Select_Centre");
    //    ////    Label lblDivisionCode = (Label)dtlItem.FindControl("lblDivisionCode");

    //    ////    if (chkDL_Select_Centre.Checked == true)
    //    ////    {
    //    ////        SelCnt = SelCnt + 1;
    //    ////        DivisionCode = DivisionCode + lblDivisionCode.Text + ",";

    //    ////    }
    //    ////}
    //    ////DivisionCode = Common.RemoveComma(DivisionCode);
    //    //if (Strings.Right(DivisionCode, 1) == ",")
    //    //    DivisionCode = Strings.Left(DivisionCode, Strings.Len(DivisionCode) - 1);

    //    ////if (SelCnt == 0)
    //    ////{
    //    ////    Show_Error_Success_Box("E", "0001");
    //    ////    dlCentre_Add.Focus();
    //    ////    return;
    //    ////}


    //    //Save
    //    string ResultId = null;
    //    string CountryCode = null;
    //    CountryCode = ddlCountry_Add.SelectedValue;

    //    string CompanyCode = null;
    //    CompanyCode = ddlCompany_Add.SelectedValue;

    //    string StateCode = null;
    //    StateCode = ddlState_Add.SelectedValue;

    //    string CityCode = null;
    //    CityCode = ddlCity_Add.SelectedValue;

    //    string LocationCode = null;
    //    LocationCode = "";

    //    Label lblHeader_User_Code = default(Label);
    //    lblHeader_User_Code = (Label)Master.FindControl("lblHeader_User_Code");

    //    string CreatedBy = null;
    //    CreatedBy = lblHeader_User_Code.Text;

    //    int ActiveFlag = 0;
    //    if (chkActiveFlag.Checked == true)
    //    {
    //        ActiveFlag = 1;
    //    }
    //    else
    //    {
    //        ActiveFlag = 0;
    //    }

    //    string AreaName = null;
    //    AreaName = txtAreaName_Add.Text;

    //    string Remarks = null;
    //    Remarks = txtRemarks_Add.Text;

    //    ResultId = ProductController.Update_Partner(lblPKey_Edit.Text, CompanyCode, ddlTitle_Add.SelectedItem.Text, txtFirstName_Add.Text, "", "", ddlGender_Add.SelectedItem.Text,Convert.ToDateTime(txtDOB.Value),Convert.ToDateTime(txtDOJ.Value), txtQualification_Add.Text,
    //    txtHandPhone1_Add.Text, txtHandPhone2_Add.Text, txtPhoneNo_Add.Text, txtEmailId_Add.Text, txtRoomNo_Add.Text, txtBuilding_Add.Text, txtRoadName_Add.Text, CountryCode, StateCode, CityCode,
    //    LocationCode, txtPincode_Add.Text, ActiveFlag, CreatedBy, ActivityCode, DivisionCode, txtEmployeeNo_Add.Text, AreaName, Remarks, txtAccountNumber_Add.Text, txtIFSCCode_Add.Text, txtBranchName_Add.Text, txtPanNumber_Add.Text);

    //    //Close the Add Panel and go to Search Grid
    //    if (ResultId == "-1")
    //    {
    //        Show_Error_Success_Box("E", "0058");
    //        txtFirstName_Add.Focus();
    //        return;
    //    }
    //    else
    //    {
    //        ControlVisibility("Result");
    //        BtnSearch_Click(sender, e);
    //        Show_Error_Success_Box("S", "0000");
    //        Clear_AddPanel();
    //    }
    //}

    protected void btnExport_Click(object sender, System.EventArgs e)
    {
        //string div = "";
        //if (ddlDivision_Sr.SelectedIndex == 0)
        //{
        //    div = "All";
        //}
        //else
        //{
        //    div = ddlDivision_Sr.SelectedItem.ToString();
        //}


        string status = "";
        if (ddlStatus.SelectedIndex == 0)
        {
            status = "All";
        }
        else
        {
            status = ddlStatus.SelectedItem.ToString();
        }


        string Faculty_Name = "";
        if (string.IsNullOrEmpty(txtPartnerName.Text.Trim()))
        {
            Faculty_Name = "";
        }
        else
        {
            Faculty_Name = txtPartnerName.Text.Trim();
        }

        string Hand_Phone = "";
        if (string.IsNullOrEmpty(txtHandPhone.Text.Trim()))
        {
            Hand_Phone = "";
        }
        else
        {
            Hand_Phone = txtHandPhone.Text.Trim();
        }

        DataList1.Visible = true;

        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        string filenamexls1 = "Vendor" + DateTime.Now + ".xls";
        Response.AddHeader("Content-Disposition", "inline;filename=" + filenamexls1);
        HttpContext.Current.Response.Charset = "utf-8";
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");
        //sets font
        HttpContext.Current.Response.Write("<font style='font-size:10.0pt; font-family:Calibri;'>");
        HttpContext.Current.Response.Write("<BR><BR><BR>");
        HttpContext.Current.Response.Write("<Table border='1'  borderColor='#000000' cellSpacing='0' cellPadding='0' style='font-size:10.0pt; font-family:Calibri; text-align:center;'> <TR style='color: #fff; background: black;text-align:center;'><TD Colspan='8'>Partner</b></TD></TR><TR><TD><b>Country</b></TD><TD>" + ddlCountry.SelectedItem.ToString() + "</TD><TD><b>State</b></TD><TD>" + ddlState.SelectedItem.ToString() + "</TD><TD><b>City</b></TD><TD>" + ddlCity.SelectedItem.ToString() + "</TD><TD><b>Active Status</b></TD><TD>" + status + "</TD></TR>");
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

    ////protected void ddlTitle_Add_SelectedIndexChanged(object sender, System.EventArgs e)
    ////{
    ////    string Gender = null;
    ////    Gender = ddlTitle_Gender.Items[ddlTitle_Add.SelectedIndex].Text;
    ////    if (!string.IsNullOrEmpty(Gender))
    ////    {
    ////        ddlGender_Add.SelectedValue = Gender;
    ////        ddlGender_Add.Enabled = false;
    ////    }
    ////    else
    ////    {
    ////        ddlGender_Add.SelectedIndex = 0;
    ////        ddlGender_Add.Enabled = true;
    ////    }
    ////}

    protected void BtnSearch_Click(object sender, System.EventArgs e)
    {
        //Validate if all information is entered correctly
        if (ddlCountry.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "0040");
            ddlCountry.Focus();
            return;
        }

        if (ddlState.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "0041");
            ddlState.Focus();
            return;
        }

        if (ddlCity.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "0042");
            ddlCity.Focus();
            return;
        }

        
        string LocationCode = "";
        //Dim LocationCnt As Integer
        //Dim LocationSelCnt As Integer = 0
        //For LocationCnt = 0 To ddlLocation.Items.Count - 1
        //    If ddlLocation.Items(LocationCnt).Selected = True Then
        //        LocationSelCnt = LocationSelCnt + 1
        //    End If
        //Next

        //If LocationSelCnt = 0 Then
        //    'When all is selected
        //    For LocationCnt = 0 To ddlLocation.Items.Count - 1
        //        LocationCode = LocationCode & ddlLocation.Items(LocationCnt).Value & ","
        //    Next
        //    If Right(LocationCode, 1) = "," Then LocationCode = Left(LocationCode, Len(LocationCode) - 1)
        //Else
        //    For LocationCnt = 0 To ddlLocation.Items.Count - 1
        //        If ddlLocation.Items(LocationCnt).Selected = True Then
        //            LocationCode = LocationCode & ddlLocation.Items(LocationCnt).Value & ","
        //        End If
        //    Next
        //    If Right(LocationCode, 1) = "," Then LocationCode = Left(LocationCode, Len(LocationCode) - 1)
        //End If

        int ActiveStatus = 0;
        if (ddlStatus.SelectedIndex == 0)
        {
            ActiveStatus = -1;
        }
        else if (ddlStatus.SelectedIndex == 1)
        {
            ActiveStatus = 1;
        }
        else
        {
            ActiveStatus = 0;
        }

        ControlVisibility("Result");

        string CountryCode = null;
        CountryCode = ddlCountry.SelectedValue;

        string StateCode = null;
        StateCode = ddlState.SelectedValue;

        string CityCode = null;
        CityCode = ddlCity.SelectedValue;

        string VendorName = null;
        if (string.IsNullOrEmpty(txtPartnerName.Text.Trim()))
        {
            VendorName = "%%";
        }
        else
        {
            VendorName = "%" + txtPartnerName.Text.Trim() + "%";
        }

        string Vendorcode = null;
        if (string.IsNullOrEmpty(txtvendorid.Text.Trim()))
        {
            Vendorcode = "%";
        }
        else
        {
            Vendorcode = "%" + txtvendorid.Text.Trim()+"%";
        }

        string HandPhone = null;
        if (string.IsNullOrEmpty(txtHandPhone.Text.Trim()))
        {
            HandPhone = "%%";
        }
        else
        {
            HandPhone = "%" + txtHandPhone.Text.Trim() + "%";
        }

        //string div_code = "";
        //if (ddlDivision_Sr.SelectedIndex == 0)
        //{
        //    div_code = "%";
        //}
        //else
        //{
        //    div_code = ddlDivision_Sr.SelectedValue.ToString().Trim();
        //}

        DataSet dsGrid = ProductController.GetVendorMasterBy_Country_State_City_Division(CountryCode, StateCode, CityCode, VendorName, HandPhone, ActiveStatus, txtvendorid.Text.Trim());
        if (dsGrid != null)




        {
            if (dsGrid.Tables.Count != 0)
            {

                dlGridDisplay.DataSource = dsGrid;
                dlGridDisplay.DataBind();

                DataList1.DataSource = dsGrid;
                DataList1.DataBind();

                lbltotalcount.Text = Convert.ToString(dsGrid.Tables[0].Rows.Count);
            }
        }
        else
        {
            lbltotalcount.Text = "0";
            dlGridDisplay.DataSource = null;
            dlGridDisplay.DataBind();

            DataList1.DataSource = null;
            DataList1.DataBind();
        }
        
        
    }
    ////public Master_Partner()
    ////{
    ////    Load += Page_Load;
    ////}
    protected void BtnClearSearch_Click(object sender, EventArgs e)
    {
        txtPartnerName.Text = "";
        ddlCountry.SelectedIndex = 0;
        ddlState.Items.Clear();
        ddlCity.Items.Clear();
        txtHandPhone.Text = "";
        ddlStatus.SelectedIndex = 0;
    }
    protected void ddlCountry_SelectedIndexChanged1(object sender, EventArgs e)
    {
        FillDDL_State();
        Clear_Error_Success_Box();
    }

  
    protected void ddlState_SelectedIndexChanged1(object sender, EventArgs e)
    {
        FillDDL_City();
        Clear_Error_Success_Box();
    }


    protected void BtnClearSearch_Click1(object sender, EventArgs e)
    {
        txtPartnerName.Text = "";
        ddlCountry.SelectedIndex = 0;
        ddlState.Items.Clear();
        ddlCity.Items.Clear();
        txtvendorid.Text = "";
        txtHandPhone.Text = "";
        ddlStatus.SelectedIndex = 0;
    }
    //protected void dlGridDisplay_ItemCommand(object source, DataListCommandEventArgs e)
    //{
    //    if (e.CommandName == "Delete")
    //    {
    //        lbldelCode.Text = e.CommandArgument.ToString();
    //        txtDeleteItemName.Text = (((Label)e.Item.FindControl("lblModeName")).Text);
    //        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalDelete();", true);
    //    }
    //    else if (e.CommandName == "Edit")
    //    {
    //        ControlVisibility("Add");
    //        BtnSave.Visible = false;
    //        BtnSaveEdit.Visible = true;

    //        lblPKey_Edit.Text = e.CommandArgument.ToString();
    //        lblHeader_Add.Text = "Edit Partner Details";
    //        lblTestPKey_Hidden.Text = "";
    //        FillPartnerMasterDetails(lblPKey_Edit.Text, e.CommandName);
    //    }
    //}




    protected void BtnSaveEdit_Click(object sender, EventArgs e)
    {

        if (ddlCountry_Add.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "0040");
            ddlCountry_Add.Focus();
            return;
        }

        if (ddlState_Add.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "0041");
            ddlState_Add.Focus();
            return;
        }

        if (ddlCity_Add.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "0042");
            ddlCity_Add.Focus();
            return;
        }

               ////int SelCnt = 0;
        //Check if unit of measurement is mentioned or not
      
      

        ////if (SelCnt == 0)
        ////{
        ////    Show_Error_Success_Box("E", "0057");
        ////    return;
        ////}

        //if (txtcontper_email.Text.ToString().Trim() != "")
        //{
        //    if (ContPersonEmail.ErrorMessage == "Invalid Email Format")
        //    {
        //        Show_Error_Success_Box("E", "Invalid Email Format");
        //        txtcontper_email.Focus();
        //        return;
        //    }
        //}
        //if (txtEmailId_Add.Text.ToString().Trim() != "")
        //{
        //    if (regexEmailValid.ErrorMessage == "Invalid Email Format")
        //    {
        //        Show_Error_Success_Box("E", "Invalid Email Format");
        //        txtEmailId_Add.Focus();
        //        return;
        //    }
        //}
        if (txtPincode_Add.Text.ToString().Trim() != "")
        {
            if (txtPincode_Add.Text.Length != 6)
            {
                Show_Error_Success_Box("E", "Pin code must be 6 numeric digits");
                txtPincode_Add.Focus();
                return;
            }
        }
        if (txtmobContPerson.Text.ToString().Trim() != "")
        {
             if (txtmobContPerson.Text.Length > 0 && txtmobContPerson.Text.Length < 10)
            {
                Show_Error_Success_Box("E", "Mobile No must be 10 numeric digits");
                txtmobContPerson.Focus();
                return;
            }
        }
       
        if (txtPhoneNo_Add.Text.ToString().Trim() != "")
        {
            if (txtPhoneNo_Add.Text.Length > 0 && txtPhoneNo_Add.Text.Length < 10)
            {
                Show_Error_Success_Box("E", "Cont Person Mobile No Must Be Of 10 Digits");
                txtPhoneNo_Add.Focus();
                return;
            }

        }
        //if (txtEmailId_Add.Text != "")
        //{
        //    if (txtEmailId_Add.ValidationGroup == "UcValidate")
        //    {
        //    }
        //}


        


        //Save
        string ResultId = null;
        string CountryCode = null;
        CountryCode = ddlCountry_Add.SelectedValue;

        ////string CompanyCode = null;
        ////CompanyCode = ddlCompany_Add.SelectedValue;

        string StateCode = null;
        StateCode = ddlState_Add.SelectedValue;

        string CityCode = null;
        CityCode = ddlCity_Add.SelectedValue;

        string LocationCode = null;
        LocationCode = "";

        Label lblHeader_User_Code = default(Label);
        lblHeader_User_Code = (Label)Master.FindControl("lblHeader_User_Code");

        string CreatedBy = null;

        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        CreatedBy = UserID;

        int ActiveFlag = 0;
        if (chkActiveFlag.Checked == true)
        {
            ActiveFlag = 1;
        }
        else
        {
            ActiveFlag = 0;
        }

        string AreaName = null;
        AreaName = txtAreaName_Add.Text;

        string Remarks = null;
        Remarks = txtRemarks_Add.Text;

        ResultId = ProductController.Update_Vendor(lblPKey_Edit.Text, txtFirstName_Add.Text, txtEmailId_Add.Text, txtPhoneNo_Add.Text,txtRoomNo_Add.Text, txtBuilding_Add.Text, txtRoadName_Add.Text, CountryCode
       , StateCode, CityCode, LocationCode, txtPincode_Add.Text, ddlCountry_Add.SelectedItem.ToString(),ActiveFlag, txtmobContPerson.Text, txtcontper_email.Text, AreaName, Remarks, txtPanNumber_Add.Text, txtptregno.Text, txtAccountNumber_Add.Text,
       txtIFSCCode_Add.Text, txtBranchName_Add.Text, txtcontactPerson.Text, CreatedBy, "", CreatedBy, "", "", "", "", "", "", txtBeneficiaryName.Text, txtBankaddress.Text);

        //Close the Add Panel and go to Search Grid
        if (ResultId == "-1")
        {
            Show_Error_Success_Box("E", "0058");
            txtFirstName_Add.Focus();
            return;
        }
        else
        {
            ControlVisibility("Result");
            BtnSearch_Click(sender, e);
            Show_Error_Success_Box("S", "0000");
            Clear_AddPanel();
        }
    }
    
}

