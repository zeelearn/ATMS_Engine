using Microsoft.VisualBasic;
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

public partial class ReIssue_ItemRequisition : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillDDL_UserType();
            FillDDL_LocationType();
            FillDDL_Division();
            ddlcenter_forStudent.SelectedIndex = 0;
            ddlcenter_forStudent.SelectedIndex = 0;

            ///////
            FillDDL_DivisionForStud();
            FillDDL_AcadYear();
            //FillDDL_Centre();
            FillDDL_AcadYearForTeacher();
            FillDDL_DivisionForTeacher();
            FillDDL_DivisionForEmployee();

            FillItemName();
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];
            lblDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            lblRequestByforStud.Text = UserName;
            lblStudApproved.Text = UserName;
            lblRequisition_DateforTech.Text = DateTime.Now.ToString("dd-MM-yyyy");
            lblRequest_ByforTech.Text = UserName;
            lbl_Requisition_DateforEmpl.Text = DateTime.Now.ToString("dd-MM-yyyy");
            lbl_Requisition_ByforTech.Text = UserName;

        }
    }
    protected void BtnAdd_Click(object sender, EventArgs e)
    {

        try
        {
            Clear_Error_Success_Box();

            if (ddlUserType.SelectedIndex == 0 || ddlUserType.SelectedIndex == -1)
            {
                Show_Error_Success_Box("E", "Select User Type");
                ddlUserType.Focus();
                return;
            }

            if (ddlUserType.SelectedItem.ToString() == "Classroom Student")
            {
                lblPkey.Text = "";
                lblUserType.Text = "";
                ControlVisibility("AddClassRoomStudent");

            }
            else if (ddlUserType.SelectedItem.ToString() == "E-Commerce Student")
            {
                ControlVisibility("AddECommerceStudent");
            }
            else if (ddlUserType.SelectedItem.ToString() == "Teacher")
            {
                ControlVisibility("AddTeacher");
            }
            else if (ddlUserType.SelectedItem.ToString() == "Employee")
            {
                ControlVisibility("AddEmployee");
            }
            else
            {
                DivSearchPanel.Visible = true;
            }
            //div_student.Visible = true;
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];
            lblDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            lblRequestByforStud.Text = UserName;
            lblStudApproved.Text = UserName;
            lblRequisition_DateforTech.Text = DateTime.Now.ToString("dd-MM-yyyy");
            lblRequest_ByforTech.Text = UserName;
            lbl_Requisition_DateforEmpl.Text = DateTime.Now.ToString("dd-MM-yyyy");
            lbl_Requisition_ByforTech.Text = UserName;
            txtstudentName.Text = "";
            txtsbentrycode.Text = "";

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

    private void FillDDL_LocationType()
    {
        //Search DDL
        DataSet dsTransfer_Tp = ProductController.GetAllTransferTypeForItemRequisition(10);
        BindDDL(ddlLocationType, dsTransfer_Tp, "Transfer_Location_Type_Name", "Transfer_Location_Type_ID");
        ddlLocationType.Items.Insert(0, "Select Location Type");
        ddlLocationType.SelectedIndex = 0;

    }
    private void FillDDL_Centre()
    {
        try
        {
            //ddlcenter_forStudent.Items.Clear();
            //Label lblHeader_Company_Code = default(Label);
            //lblHeader_Company_Code = (Label)Master.FindControl("lblHeader_Company_Code");

            ////Label lblHeader_User_Code = default(Label);
            ////lblHeader_User_Code = (Label)Master.FindControl("lblHeader_User_Code");

            //Label lblHeader_DBName = default(Label);
            //lblHeader_DBName = (Label)Master.FindControl("lblHeader_DBName");

            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];


            string Company_Code = "MT";
            string DBname = "CDB";
            string Div_Code = null;
            Div_Code = ddlDivisionforStudent.SelectedValue.ToString();

            DataSet dsCentre = ProductController.GetAllActiveUser_Company_Division_Zone_Center(UserID, Company_Code, Div_Code, "", "5", DBname);

            BindListBox(ddlcenter_forStudent, dsCentre, "Center_Name", "Center_Code");
            ddlcenter_forStudent.Items.Insert(0, "Select");
            ddlcenter_forStudent.Items.Insert(1, "All");
            ddlClassrmProd_frStud.Items.Clear();

            //ddlCenters.Items.Insert(0, "Select");
            //ddlcenter_forStudent.SelectedIndex = 0;

        }
        catch (Exception ex)
        {

        }



    }

    private void Fill_ClassRoomProductForItemRequisition()
    {
        try
        {
            string Division_Code;
            Division_Code = ddlDivisionforStudent.SelectedValue.ToString();
            string CenterCode;
            CenterCode = ddlcenter_forStudent.SelectedValue.ToString();
            string AcadYear;
            AcadYear = ddlacadyr_frStud.SelectedValue.ToString();


            DataSet dsClassRoomProduct = ProductController.GetClassroomProducts_ForItemRequisition(Division_Code, CenterCode, AcadYear, "1");
            BindListBox(ddlClassrmProd_frStud, dsClassRoomProduct, "Stream_Name", "Stream_Code");
            ddlClassrmProd_frStud.Items.Insert(0, "Select");

            //ddlCenters.Items.Insert(0, "Select");
            //ddlClassrmProd_frStud.SelectedIndex = 0;

        }
        catch (Exception ex)
        {

        }

    }
    protected void ddlLocationType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlLocationType.SelectedItem.ToString().Trim() == "Function")
        {
            tblFr_Function.Visible = true;
            //tblFr_Godown.Visible = false;
            tblFr_Division.Visible = false;
            //tblFr_Center.Visible = false;
            FillDDL_Function();
        }
        else if (ddlLocationType.SelectedItem.ToString().Trim() == "Center")
        {
            tblFr_Division.Visible = true;

            tblFr_Function.Visible = false;

            FillDDL_Division();


        }
        else if (ddlLocationType.SelectedIndex == 0 || ddlLocationType.SelectedIndex == -1)
        {
            //tblFr_Godown.Visible = false;
            tblFr_Function.Visible = false;
            tblFr_Division.Visible = false;
            //tblFr_Center.Visible = false;
        }
    }
    private void FillDDL_Function()
    {
        ddlFunctionFR_SR.Items.Clear();
        DataSet dsTransfer_Tp = ProductController.GetGodown_Function_Logistic_Assests_Type(2);
        BindDDL(ddlFunctionFR_SR, dsTransfer_Tp, "Function_Name", "Function_Id");
        ddlFunctionFR_SR.Items.Insert(0, "Select Function");
        ddlFunctionFR_SR.SelectedIndex = 0;
    }
    //private void FillDDL_CentreForStudent()
    //{
    //    try
    //    {
    //        ddlcenter_forStudent.Items.Clear();
    //        Label lblHeader_Company_Code = default(Label);
    //        lblHeader_Company_Code = (Label)Master.FindControl("lblHeader_Company_Code");

    //        Label lblHeader_User_Code = default(Label);
    //        lblHeader_User_Code = (Label)Master.FindControl("lblHeader_User_Code");

    //        Label lblHeader_DBName = default(Label);
    //        lblHeader_DBName = (Label)Master.FindControl("lblHeader_DBName");


    //        string Div_Code = null;
    //        Div_Code = ddlcenter_forStudent.SelectedValue;

    //        DataSet dsCentre = ProductController.GetAllActiveUser_Company_Division_Zone_Center(lblHeader_User_Code.Text, lblHeader_Company_Code.Text, Div_Code, "", "5", lblHeader_DBName.Text);

    //        BindListBox(ddlcenter_forStudent, dsCentre, "Center_Name", "Center_Code");
    //        ddlcenter_forStudent.Items.Insert(0, "Select");

    //        //ddlCenters.Items.Insert(0, "Select");
    //        ddlcenter_forStudent.SelectedIndex = 0;

    //    }
    //    catch (Exception ex)
    //    {
    //    }



    //}

    private void BindListBox(DropDownList ddl, DataSet ds, string txtField, string valField)
    {
        ddl.DataSource = ds;
        ddl.DataTextField = txtField;
        ddl.DataValueField = valField;
        ddl.DataBind();
    }


    private void FillDDL_AcadYear()
    {
        try
        {
            DataSet dsAcadYear = ProductController.GetAllActiveUser_AcadYear();
            BindDDL(ddlacadyr_frStud, dsAcadYear, "Description", "Id");
            ddlacadyr_frStud.Items.Insert(0, "Select");
            ddlacadyr_frStud.SelectedIndex = 0;
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


    private void FillDDL_AcadYearForTeacher()
    {
        try
        {
            DataSet dsAcadYear = ProductController.GetAllActiveUser_AcadYear();
            BindDDL(ddlacadyear_ForTeacher, dsAcadYear, "Description", "Id");
            ddlacadyear_ForTeacher.Items.Insert(0, "Select");
            ddlacadyear_ForTeacher.SelectedIndex = 0;
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

    protected void btnClose_FotStudent_Click(object sender, EventArgs e)
    {
        //div_student.Visible = false;
        //DivSearchPanel.Visible = true;
        ClearFields();

        try
        {
            BtnSearch_Click(this, e);
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

    private void ClearFields()
    {
        //For Student
        ddlDivisionforStudent.SelectedIndex = 0;
        ddlacadyr_frStud.SelectedIndex = 0;
        ddlcenter_forStudent.Items.Clear();
        ddlClassrmProd_frStud.Items.Clear();
        ddlIteamName_ForStudent.SelectedIndex = 0;
        datalist_Student.DataSource = null;
        datalist_Student.DataBind();
        lblDate.Text = "";
        lblRequestByforStud.Text = "";
        lblRequisitionNo.Text = "";
        txtstudentName.Text = "";
        txtsbentrycode.Text = "";


        //For Teacher
        ddlDivision_ForTeacher.SelectedIndex = 0;
        ddlacadyear_ForTeacher.SelectedIndex = 0;
        txtteacherName.Text = "";
        datalist_Teacher.DataSource = null;
        datalist_Teacher.DataBind();
        TxtRemarks_ForTeacher.Text = "";
        lblRequisition_DateforTech.Text = "";
        lblRequest_ByforTech.Text = "";
        lblRequisition_No.Text = "";

        //For Employee
        ddlLocationType.SelectedIndex = 0;
        ddlDiv_Function_ForEmp.Items.Clear();
        ddlFunctionFR_SR.Items.Clear();
        txtEmployeeNM.Text = "";
        txtEmployeeCode.Text = "";
        txtEmailid.Text = "";
        ddlstatus.SelectedIndex = 0;
        txtremarks_ForEmployee.Text = "";
        lbl_Requisition_DateforEmpl.Text = "";
        lbl_Requisition_ByforTech.Text = "";
        lbl_Requisition_No.Text = "";


    }

    private void FillDDL_UserType()
    {
        try
        {
            DataSet dsUserType = ProductController.GetAllActiveUser_UsertType();
            BindDDL(ddlUserType, dsUserType, "User_Type_Name", "User_Type_Id");
            ddlUserType.Items.Insert(0, "Select");
            ddlUserType.SelectedIndex = 0;
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

    private void FillItemName()
    {
        try
        {

            string Division_Code;
            Division_Code = ddlDivisionforStudent.SelectedValue.ToString();
            string CenterCode;
            CenterCode = ddlcenter_forStudent.SelectedValue.ToString();
            string AcadYear;
            AcadYear = ddlacadyr_frStud.SelectedValue.ToString();
            string Stream;
            Stream = ddlClassrmProd_frStud.SelectedValue.ToString();
            string Is_Active = "1";

            DataSet dsItemName = ProductController.GetItem_Name(Division_Code, AcadYear, Stream, Is_Active);
            BindDDL(ddlIteamName_ForStudent, dsItemName, "CPItem_Name", "CPItemCode");
            ddlIteamName_ForStudent.Items.Insert(0, "Select");
            ddlIteamName_ForStudent.SelectedIndex = 0;
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
    //private void BindListBox(ListBox ddl, DataSet ds, string txtField, string valField)
    //{
    //    ddl.DataSource = ds;
    //    ddl.DataTextField = txtField;
    //    ddl.DataValueField = valField;
    //    ddl.DataBind();
    //}

    private void FillDDL_Division()
    {
        try
        {

            Clear_Error_Success_Box();
            string Company_Code = "MT";
            string DBname = "CDB";

            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];
            ddlDivision.Items.Clear();
            ddlDiv_Function_ForEmp.Items.Clear();
            DataSet dsDivision = ProductController.GetAllActiveUser_Company_Division_Zone_Center(UserID, Company_Code, "", "", "2", DBname);
            BindDDL(ddlDivision, dsDivision, "Division_Name", "Division_Code");
            ddlDivision.Items.Insert(0, "Select Division");
            ddlDivision.SelectedIndex = 0;

            BindDDL(ddlDiv_Function_ForEmp, dsDivision, "Division_Name", "Division_Code");
            ddlDiv_Function_ForEmp.Items.Insert(0, "Select Division");
            ddlDiv_Function_ForEmp.SelectedIndex = 0;

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
    private void FillDDL_DivisionForStud()
    {
        try
        {

            Clear_Error_Success_Box();
            string Company_Code = "MT";
            string DBname = "CDB";

            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];

            DataSet dsDivision = ProductController.GetAllActiveUser_Company_Division_Zone_Center(UserID, Company_Code, "", "", "2", DBname);
            BindDDL(ddlDivisionforStudent, dsDivision, "Division_Name", "Division_Code");
            ddlDivisionforStudent.Items.Insert(0, "Select Division");
            ddlDivisionforStudent.SelectedIndex = 0;


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



    private void FillDDL_DivisionForTeacher()
    {
        try
        {

            Clear_Error_Success_Box();
            string Company_Code = "MT";
            string DBname = "CDB";

            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];

            DataSet dsDivision = ProductController.GetAllActiveUser_Company_Division_Zone_Center(UserID, Company_Code, "", "", "2", DBname);
            BindDDL(ddlDivision_ForTeacher, dsDivision, "Division_Name", "Division_Code");
            ddlDivision_ForTeacher.Items.Insert(0, "Select Division");
            ddlDivision_ForTeacher.SelectedIndex = 0;


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

    private void FillDDL_DivisionForEmployee()
    {
        try
        {

            Clear_Error_Success_Box();
            string Company_Code = "MT";
            string DBname = "CDB";

            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];

            DataSet dsDivision = ProductController.GetAllActiveUser_Company_Division_Zone_Center(UserID, Company_Code, "", "", "2", DBname);
            BindDDL(ddlDiv_Function_ForEmp, dsDivision, "Division_Name", "Division_Code");
            ddlDiv_Function_ForEmp.Items.Insert(0, "Select Division");
            ddlDiv_Function_ForEmp.SelectedIndex = 0;


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

    private void Clear_Error_Success_Box()
    {
        Msg_Error.Visible = false;
        Msg_Success.Visible = false;
        lblSuccess.Text = "";
        lblerror.Text = "";
        UpdatePanelMsgBox.Update();
    }
    private void BindDDL(DropDownList ddl, DataSet ds, string txtField, string valField)
    {
        ddl.DataSource = ds;
        ddl.DataTextField = txtField;
        ddl.DataValueField = valField;
        ddl.DataBind();
    }
    protected void BtnClearSearch_Click(object sender, EventArgs e)
    {
        ddlUserType.SelectedIndex = 0;
        ddlDivision.SelectedIndex = 0;
        txtOrderNo.Text = "";
        id_date_range_picker_2.Value = "";

    }
    protected void ddlUserType_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btncancel_forTeacher_Click(object sender, EventArgs e)
    {
        //div_Teacher.Visible = false;
        //DivSearchPanel.Visible = true;


        try
        {
            ClearFields();
            BtnSearch_Click(this, e);
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
    protected void btnCancel_forEMP_Click(object sender, EventArgs e)
    {
        //div_Employee.Visible = false;
        //DivSearchPanel.Visible = true;
        try
        {
            ClearFields();
            BtnSearch_Click(this, e);
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
    protected void ddlDivisionforStudent_SelectedIndexChanged(object sender, EventArgs e)
    {

        FillDDL_Centre();
        ddlcenter_forStudent.SelectedIndex = 0;
    }
    protected void ddlcenter_forStudent_SelectedIndexChanged(object sender, EventArgs e)
    {
        Fill_ClassRoomProductForItemRequisition();
        ddlClassrmProd_frStud.SelectedIndex = 0;
    }

    protected void btnshow_Click(object sender, EventArgs e)
    {
        try
        {
            Clear_Error_Success_Box();


            if (ddlDivisionforStudent.SelectedIndex == 0 || ddlDivisionforStudent.SelectedIndex == -1)
            {
                Show_Error_Success_Box("E", "Select Division");
                ddlDivisionforStudent.Focus();
                return;
            }

            if (ddlacadyr_frStud.SelectedIndex == 0 || ddlacadyr_frStud.SelectedIndex == -1)
            {
                Show_Error_Success_Box("E", "Select Acad Year");
                ddlacadyr_frStud.Focus();
                return;
            }

            if (ddlcenter_forStudent.SelectedIndex == 0 || ddlcenter_forStudent.SelectedIndex == -1)
            {
                Show_Error_Success_Box("E", "Select Center");
                ddlcenter_forStudent.Focus();
                return;
            }

            if (ddlClassrmProd_frStud.SelectedIndex == 0 || ddlClassrmProd_frStud.SelectedIndex == -1)
            {
                Show_Error_Success_Box("E", "Select Classroom Product");
                ddlClassrmProd_frStud.Focus();
                return;
            }

            if (ddlIteamName_ForStudent.SelectedIndex == 0 || ddlIteamName_ForStudent.SelectedIndex == -1)
            {
                Show_Error_Success_Box("E", "Select Item");
                ddlIteamName_ForStudent.Focus();
                return;
            }

            string Division = "", Acad = "", center = "", CP = "", Item = "";

            Division = ddlDivisionforStudent.SelectedValue.ToString().Trim();
            Acad = ddlacadyr_frStud.SelectedValue.ToString().Trim();
            center = ddlcenter_forStudent.SelectedValue.ToString().Trim();
            CP = ddlClassrmProd_frStud.SelectedValue.ToString().Trim();
            Item = ddlIteamName_ForStudent.SelectedValue.ToString().Trim();
           // student.Visible = true;


            DataSet Ds = ProductController.GetStudentDetails(Division, center, CP, Acad, 1, "", "", "");

            if (Ds != null)
            {
                if (Ds.Tables.Count != 0)
                {
                    if (Ds.Tables[0].Rows.Count != 0)
                    {
                        datalist_Student.DataSource = Ds;
                        datalist_Student.DataBind();
                        UpdatePanel1.Update();
                        total.Visible = true;
                        lbltotalrecords.Text = (Ds.Tables[0].Rows.Count).ToString();
                        foreach (RepeaterItem dtlItem in datalist_Student.Items)
                        {
                            Label lblSbentryCode = (Label)dtlItem.FindControl("lblStudentCode");
                            Label lblMenuName = (Label)dtlItem.FindControl("lblMenuName");


                        }

                    }
                    else
                    {

                        datalist_Student.DataSource = null;
                        datalist_Student.DataBind();


                        //
                        Clear_Error_Success_Box();
                        Msg_Error.Visible = true;
                        Msg_Success.Visible = false;
                        lblerror.Text = "Students Not Found";
                        UpdatePanelMsgBox.Update();
                        return;
                    }
                }
                else
                {
                    datalist_Student.DataSource = null;
                    datalist_Student.DataBind();

                    //
                    Clear_Error_Success_Box();
                    Msg_Error.Visible = true;
                    Msg_Success.Visible = false;
                    lblerror.Text = "Students Not Found";
                    UpdatePanelMsgBox.Update();
                    return;
                }
            }
            else
            {
                datalist_Student.DataSource = null;
                datalist_Student.DataBind();
                //
                Clear_Error_Success_Box();
                Msg_Error.Visible = true;
                Msg_Success.Visible = false;
                lblerror.Text = "Students Not Found";
                UpdatePanelMsgBox.Update();
                return;
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


    protected void btnSave_ForStudent_Click(object sender, EventArgs e)
    {
        try
        {
            Clear_Error_Success_Box();

            if (ddlDivisionforStudent.SelectedIndex == 0 || ddlDivisionforStudent.SelectedIndex == -1)
            {
                Show_Error_Success_Box("E", "Select Division");
                ddlDivisionforStudent.Focus();
                return;
            }

            if (ddlacadyr_frStud.SelectedIndex == 0 || ddlacadyr_frStud.SelectedIndex == -1)
            {
                Show_Error_Success_Box("E", "Select Acad Year");
                ddlacadyr_frStud.Focus();
                return;
            }

            if (ddlcenter_forStudent.SelectedIndex == 0 || ddlcenter_forStudent.SelectedIndex == -1)
            {
                Show_Error_Success_Box("E", "Select Center");
                ddlcenter_forStudent.Focus();
                return;
            }

            if (ddlClassrmProd_frStud.SelectedIndex == 0 || ddlClassrmProd_frStud.SelectedIndex == -1)
            {
                Show_Error_Success_Box("E", "Select Classroom Product");
                ddlClassrmProd_frStud.Focus();
                return;
            }

            if (ddlIteamName_ForStudent.SelectedIndex == 0 || ddlIteamName_ForStudent.SelectedIndex == -1)
            {
                Show_Error_Success_Box("E", "Select Item");
                ddlIteamName_ForStudent.Focus();
                return;
            }

            int TotalRecord = 0;
            foreach (RepeaterItem dtlItem in datalist_Student.Items)
            {
                CheckBox chkCheck = (CheckBox)dtlItem.FindControl("chkCheck");

                if (chkCheck.Checked == true)
                {
                    TotalRecord = TotalRecord + 1;
                }
            }
            if (TotalRecord == 0)
            {
                Show_Error_Success_Box("E", "You have not Selected any Student");
                return;
            }

            string Item_Name = "";
            string ItemCode = "";
            int BatchCnt = 0;
            int BatchSelCnt = 0;
            for (BatchCnt = 0; BatchCnt <= ddlIteamName_ForStudent.Items.Count - 1; BatchCnt++)
            {
                if (ddlIteamName_ForStudent.Items[BatchCnt].Selected == true)
                {
                    BatchSelCnt = BatchSelCnt + 1;
                }
            }

            if (BatchSelCnt == 0)
            {
                ddlIteamName_ForStudent.Focus();
                return;
            }
            else
            {
                for (BatchCnt = 0; BatchCnt <= ddlIteamName_ForStudent.Items.Count - 1; BatchCnt++)
                {
                    if (ddlIteamName_ForStudent.Items[BatchCnt].Selected == true)
                    {
                        ItemCode = ItemCode + ddlIteamName_ForStudent.Items[BatchCnt].Value + ",";
                        Item_Name = Item_Name + ddlIteamName_ForStudent.Items[BatchCnt].Text + ",";
                    }
                }
                ItemCode = Common.RemoveComma(ItemCode);
                Item_Name = Common.RemoveComma(Item_Name);

            }



            string Division = "", Acad = "", center = "", CP = "", Item = "", Item1 = "", ResultId = "";

            Division = ddlDivisionforStudent.SelectedValue.ToString().Trim();
            Acad = ddlacadyr_frStud.SelectedValue.ToString().Trim();
            center = ddlcenter_forStudent.SelectedValue.ToString().Trim();
            CP = ddlClassrmProd_frStud.SelectedValue.ToString().Trim();
            // Item = Item + ddlIteamName_ForStudent.SelectedValue + ",";
            Item1 = ddlIteamName_ForStudent.SelectedValue;
            Item = Item + Item1 + ",";


            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];

            ResultId = ProductController.Insert_ItemRequsition(7, UserID, ddlUserType.SelectedValue.ToString().Trim(), Division, center, Acad, CP, ItemCode, UserID, "");

            if (ResultId == "")
            {
                //Show_Error_Success_Box("S", "Record saved Successfully.");
            }
            else
            {
                Clear_Error_Success_Box();
                int TotalRecord1 = 0;
                foreach (RepeaterItem dtlItem in datalist_Student.Items)
                {
                    CheckBox chkCheck = (CheckBox)dtlItem.FindControl("chkCheck");

                    if (chkCheck.Checked == true)
                    {
                        TotalRecord1 = TotalRecord1 + 1;
                    }
                }
                if (TotalRecord1 == 0)
                {
                    Show_Error_Success_Box("E", "You have not Selected any Student");
                    return;
                }
                string ResultId1 = "";
                foreach (RepeaterItem dtlItem in datalist_Student.Items)
                {
                    CheckBox chkCheck = (CheckBox)dtlItem.FindControl("chkCheck");

                    if (chkCheck.Checked == true)
                    {
                        Label lblSbentryCode = (Label)dtlItem.FindControl("lblStudentCode");

                        ResultId1 = ProductController.Insert_ItemRequsition_items(8, ResultId, lblSbentryCode.Text.Trim(), "", "", "", "");
                        if (ResultId1 == "1")
                        {

                        }

                    }
                }

                if (ResultId1 == "1")
                {
                    Clear_Error_Success_Box();
                    BtnSearch_Click(this, e);
                    Show_Error_Success_Box("S", "Record saved Successfully.");
                    //
                }
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
    protected void btnshow_ForTeacher_Click(object sender, EventArgs e)
    {
        try
        {
            Clear_Error_Success_Box();

            if (ddlDivision_ForTeacher.SelectedIndex == 0 || ddlDivision_ForTeacher.SelectedIndex == -1)
            {
                Show_Error_Success_Box("E", "Select Division");
                ddlDivisionforStudent.Focus();
                return;
            }

            if (ddlacadyear_ForTeacher.SelectedIndex == 0 || ddlacadyear_ForTeacher.SelectedIndex == -1)
            {
                Show_Error_Success_Box("E", "Select Acad Year");
                ddlacadyr_frStud.Focus();
                return;
            }


            string Division = "", Acad = "", TeacherName = "";

            Division = ddlDivision_ForTeacher.SelectedValue.ToString().Trim();
            Acad = ddlacadyear_ForTeacher.SelectedValue.ToString().Trim();
            TeacherName = txtteacherName.Text.Trim();

            DataSet Ds = ProductController.GetTeacherDetails(Division, Acad, TeacherName, 4);

            if (Ds != null)
            {
                if (Ds.Tables.Count != 0)
                {
                    if (Ds.Tables[0].Rows.Count != 0)
                    {
                        datalist_Teacher.DataSource = Ds;
                        datalist_Teacher.DataBind();
                        teacher.Visible = true;
                        lblteachertotaalrecords.Text = (Ds.Tables[0].Rows.Count).ToString();
                    }
                    else
                    {
                        datalist_Teacher.DataSource = null;
                        datalist_Teacher.DataBind();
                        //
                        Clear_Error_Success_Box();
                        Msg_Error.Visible = true;
                        Msg_Success.Visible = false;
                        lblerror.Text = "Teachers Not Found";
                        UpdatePanelMsgBox.Update();
                        return;
                    }
                }
                else
                {
                    datalist_Teacher.DataSource = null;
                    datalist_Teacher.DataBind();
                    //
                    Clear_Error_Success_Box();
                    Msg_Error.Visible = true;
                    Msg_Success.Visible = false;
                    lblerror.Text = "Teachers Not Found";
                    UpdatePanelMsgBox.Update();
                    return;
                }
            }
            else
            {
                datalist_Teacher.DataSource = null;
                datalist_Teacher.DataBind();
                //
                Clear_Error_Success_Box();
                Msg_Error.Visible = true;
                Msg_Success.Visible = false;
                lblerror.Text = "Teachers Not Found";
                UpdatePanelMsgBox.Update();
                return;
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
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            Clear_Error_Success_Box();

            if (ddlUserType.SelectedIndex == 0 || ddlUserType.SelectedIndex == -1)
            {
                Show_Error_Success_Box("E", "Select User Type");
                ddlUserType.Focus();
                return;
            }

            string UserType, Division, OrderNO;

            string FromDate, ToDate, Supplier;
            if (id_date_range_picker_2.Value == "")
            {
                FromDate = "";
                ToDate = "";
            }
            else
            {
                string DateRange = "";
                DateRange = id_date_range_picker_2.Value;

                FromDate = DateRange.Substring(0, 10);
                ToDate = (DateRange.Length > 9) ? DateRange.Substring(DateRange.Length - 10, 10) : DateRange;
            }


            if (ddlUserType.SelectedIndex == 0 || ddlUserType.SelectedIndex == -1)
            {
                UserType = "";
            }
            else
            {
                UserType = ddlUserType.SelectedValue.ToString().Trim();
            }

            if (ddlDivision.SelectedIndex == 0 || ddlDivision.SelectedIndex == -1)
            {
                Division = "";
                lblDivision_SR.Text = Division;
            }
            else
            {
                Division = ddlDivision.SelectedValue.ToString().Trim();
                lblDivision_SR.Text = ddlDivision.SelectedItem.ToString().Trim();
            }

            //Division = ddlDivision.SelectedValue.ToString().Trim();
            OrderNO = txtOrderNo.Text.Trim();

            lblUserType_SR.Text = "";
            lblUserType_SR.Text = ddlUserType.SelectedItem.ToString().Trim();

            lblPeriod.Text = id_date_range_picker_2.Value;
            lblOrderNo.Text = "";
            lblOrderNo.Text = txtOrderNo.Text;

            ControlVisibility("Result");
            DataSet Ds = ProductController.GetSearchRequisition(UserType, Division, FromDate, ToDate, OrderNO, 15);

            if (Ds != null)
            {
                if (Ds.Tables.Count != 0)
                {
                    if (Ds.Tables[0].Rows.Count != 0)
                    {
                        dlGridDisplay.DataSource = Ds;
                        dlGridDisplay.DataBind();

                        DataList1.DataSource = Ds;
                        DataList1.DataBind();

                        lbltotalcount.Text = (Ds.Tables[0].Rows.Count).ToString();
                    }
                    else
                    {
                        dlGridDisplay.DataSource = null;
                        dlGridDisplay.DataBind();

                        DataList1.DataSource = null;
                        DataList1.DataBind();
                        lbltotalcount.Text = "0";
                    }
                }
                else
                {
                    dlGridDisplay.DataSource = null;
                    dlGridDisplay.DataBind();

                    DataList1.DataSource = null;
                    DataList1.DataBind();
                    lbltotalcount.Text = "0";
                }
            }
            else
            {
                dlGridDisplay.DataSource = null;
                dlGridDisplay.DataBind();

                DataList1.DataSource = null;
                DataList1.DataBind();
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

    private void ControlVisibility(string Mode)
    {
        if (Mode == "Search")
        {
            div_student.Visible = false;
            div_Employee.Visible = false;
            div_Teacher.Visible = false;
            DivSearchPanel.Visible = true;
            BtnAdd.Visible = true;
            BtnShowSearchPanel.Visible = false;
            student.Visible = false;

            DivResultPanel.Visible = false;

        }
        else if (Mode == "Result")
        {
            div_student.Visible = false;
            div_Employee.Visible = false;
            div_Teacher.Visible = false;
            DivSearchPanel.Visible = false;
            BtnAdd.Visible = true;
            DivResultPanel.Visible = true;
            lblPkey.Text = "";
            BtnShowSearchPanel.Visible = true;

        }
        else if (Mode == "AddClassRoomStudent")
        {
            DivSearchPanel.Visible = false;
            div_student.Visible = true;
            div_Employee.Visible = false;
            div_Teacher.Visible = false;
            BtnShowSearchPanel.Visible = true;
            ddlDivisionforStudent.Enabled = true;
            ddlacadyr_frStud.Enabled = true;
            ddlcenter_forStudent.Enabled = true;
            ddlClassrmProd_frStud.Enabled = true;
            ClearFields();
            DivResultPanel.Visible = false;
            btnshow.Visible = true;
            btnSaveEDit_ForStudent.Visible = false;
            btnSave_ForStudent.Visible = true;
            BtnAdd.Visible = false;

        }
        else if (Mode == "AddECommerceStudent")
        {
            DivSearchPanel.Visible = false;
            div_student.Visible = true;
            div_Teacher.Visible = false;
            div_Employee.Visible = false;
            BtnShowSearchPanel.Visible = true;
        }
        else if (Mode == "AddTeacher")
        {
            DivSearchPanel.Visible = false;
            div_Teacher.Visible = true;
            div_student.Visible = false;
            div_Employee.Visible = false;
            BtnShowSearchPanel.Visible = true;
            DivResultPanel.Visible = false;
            ClearFields();
            //
            ddlDivision_ForTeacher.Enabled = true;
            ddlacadyear_ForTeacher.Enabled = true;
            btnshow_ForTeacher.Visible = true;
            btnSaveEdit_forTeacher.Visible = false;
            btnSave_forTeacher.Visible = true;
            BtnAdd.Visible = false;
        }
        else if (Mode == "AddEmployee")
        {
            DivSearchPanel.Visible = false;
            div_Employee.Visible = true;
            div_student.Visible = false;
            div_Teacher.Visible = false;
            BtnShowSearchPanel.Visible = true;
            ClearFields();
            //
            btnSave_ForEmp.Visible = true;
            btnSaveEdit_ForEmp.Visible = false;
            DivResultPanel.Visible = false;
            BtnAdd.Visible = false;
        }

    }
    protected void BtnShowSearchPanel_Click(object sender, EventArgs e)
    {
        ControlVisibility("Search");
        Clear_Error_Success_Box();
    }
    protected void dlGridDisplay_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            Clear_Error_Success_Box();
            if (e.CommandName == "comEdit")
            {
                string Pkey = e.CommandArgument.ToString();
                string[] s1 = Pkey.Split('%');
                lblPkey.Text = s1[0].ToString();
                lblUserType.Text = s1[1].ToString();

                if (lblUserType.Text == "UT001")
                {
                    ControlVisibility("AddClassRoomStudent");
                    ddlDivisionforStudent.Enabled = false;
                    ddlacadyr_frStud.Enabled = false;
                    ddlcenter_forStudent.Enabled = false;
                    ddlClassrmProd_frStud.Enabled = false;
                    btnshow.Visible = false;
                    //student.Visible = true;
                    ddlIteamName_ForStudent.Enabled = false;
                    btnSaveEDit_ForStudent.Visible = true;
                    btnSave_ForStudent.Visible = false;

                    DataSet ds = ProductController.Get_FillDetails_ItemRequisition(3, lblPkey.Text.Trim());
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ddlDivisionforStudent.SelectedValue = ds.Tables[0].Rows[0]["Division_Code"].ToString();
                        FillDDL_Centre();
                        ddlacadyr_frStud.SelectedValue = ds.Tables[0].Rows[0]["Acad_Year"].ToString();
                        ddlcenter_forStudent.SelectedValue = ds.Tables[0].Rows[0]["center_code"].ToString();
                        Fill_ClassRoomProductForItemRequisition();

                        ddlClassrmProd_frStud.SelectedValue = ds.Tables[0].Rows[0]["CLassroomproduct_code"].ToString();
                        FillItemName();
                        ddlIteamName_ForStudent.SelectedValue = ds.Tables[0].Rows[0]["Item_Code"].ToString();
                        lblDate.Text = ds.Tables[0].Rows[0]["Request_Date"].ToString();
                        lblstudApprovedOn.Text = ds.Tables[0].Rows[0]["Approved_On"].ToString();
                        lblStudentLevelRemark.Text = ds.Tables[0].Rows[0]["Approved_Remark"].ToString();
                        lblRequestByforStud.Text = ds.Tables[0].Rows[0]["User_Display_Name"].ToString();
                        lblRequisitionNo.Text = ds.Tables[0].Rows[0]["Request_Code"].ToString();
                        lblStudApproved.Text = ds.Tables[0].Rows[0]["Approved_By"].ToString();
                        lblStudAuthorise.Text = ds.Tables[0].Rows[0]["Authorised_By"].ToString();
                        lblStudAuthorisedOn.Text = ds.Tables[0].Rows[0]["Authorised_On"].ToString();
                        lblStudAuthoriseRemark.Text = ds.Tables[0].Rows[0]["Authorised_Remark"].ToString();

                        //


                        //

                        string Re_Status = ds.Tables[0].Rows[0]["Request_Status"].ToString();
                        if (Re_Status == "Pending")
                        {
                            btnSaveEDit_ForStudent.Visible = true;
                            btnSave_ForStudent.Visible = false;
                            Flag_Student.Visible = true;
                            lbl_FlagStudent.Visible = true;
                            lbl_FlagStudent.Text = Re_Status;
                            TRStudent.Visible = false;
                            TR1.Visible = false;
                        }
                        else if (Re_Status == "Approved")
                        {
                            btnSaveEDit_ForStudent.Visible = false;
                            btnSave_ForStudent.Visible = false;
                            Flag_Student.Visible = true;
                            lbl_FlagStudent.Visible = true;
                            lbl_FlagStudent.Text = Re_Status;
                            TRStudent.Visible = true;
                            TR1.Visible = false;
                        }
                        else
                        {
                            btnSaveEDit_ForStudent.Visible = false;
                            btnSave_ForStudent.Visible = false;
                            Flag_Student.Visible = true;
                            lbl_FlagStudent.Visible = true;
                            lbl_FlagStudent.Text = Re_Status;
                            TRStudent.Visible = true;
                            TR1.Visible = false;
                            if (ds.Tables[0].Rows[0]["Level"].ToString() == "Level1" || ds.Tables[0].Rows[0]["Level"].ToString() == "Level2")
                            {
                                lblHeaderStudent1.Text = "Approved By";
                                lblHeaderStudent2.Text = "Approved On";
                                lblHeaderStudent3.Text = "Remarks";

                                lblStudApproved.Text = ds.Tables[0].Rows[0]["Approved_By"].ToString();
                                lblstudApprovedOn.Text = ds.Tables[0].Rows[0]["Approved_On"].ToString();
                                lblStudentLevelRemark.Text = ds.Tables[0].Rows[0]["Approved_Remark"].ToString();
                            }
                            else
                                if (ds.Tables[0].Rows[0]["Level"].ToString() == "Level1" || ds.Tables[0].Rows[0]["Level"].ToString() == "Level2")
                                {
                                    lblHeaderStud1.Text = "Authorised By";
                                    lblHeaderStud2.Text = "Authorised On";
                                    lblHeaderStud3.Text = "Remarks";

                                    lblStudAuthorise.Text = ds.Tables[0].Rows[0]["Authorised_By"].ToString();
                                    lblStudAuthorisedOn.Text = ds.Tables[0].Rows[0]["Authorised_On"].ToString();
                                    lblStudAuthoriseRemark.Text = ds.Tables[0].Rows[0]["Authorised_Remark"].ToString();
                                }

                                else if (Re_Status == "Authorised")
                                {
                                    TR1.Visible = true;
                                }

                        }


                        //

                        DataSet DsGrid = ProductController.GetStudentDetails(ddlDivisionforStudent.SelectedValue.ToString().Trim(), ddlcenter_forStudent.SelectedValue.ToString().Trim(), ddlClassrmProd_frStud.SelectedValue.ToString().Trim(), ddlacadyr_frStud.SelectedValue.ToString().Trim(), 1, "", "", "");
                        if (DsGrid.Tables[0].Rows.Count > 0)
                        {
                            datalist_Student.DataSource = DsGrid;
                            datalist_Student.DataBind();
                            total.Visible = true;
                            lbltotalrecords.Text = (DsGrid.Tables[0].Rows.Count).ToString();
                        }
                        else
                        {
                            datalist_Student.DataSource = null;
                            datalist_Student.DataBind();
                        }

                        for (int cnt = 0; cnt <= ds.Tables[1].Rows.Count - 1; cnt++)
                        {

                            foreach (RepeaterItem dtlItem in datalist_Student.Items)
                            {
                                CheckBox chkDL_Select_Centre = (CheckBox)dtlItem.FindControl("chkCheck");
                                Label lblStudentCode = (Label)dtlItem.FindControl("lblStudentCode");
                                if (Convert.ToString(lblStudentCode.Text).Trim() == Convert.ToString(ds.Tables[1].Rows[cnt]["User_PrimaryCode"]).Trim())
                                {
                                    chkDL_Select_Centre.Checked = true;
                                    //count = count + 1;
                                    break; // TODO: might not be correct. Was : Exit For
                                }
                            }

                        }

                    }

                }
                else if (lblUserType.Text == "UT002")
                {

                }
                else if (lblUserType.Text == "UT003")
                {
                    ControlVisibility("AddTeacher");
                    ddlDivision_ForTeacher.Enabled = false;
                    ddlacadyear_ForTeacher.Enabled = false;
                    btnshow_ForTeacher.Visible = false;
                    //
                    btnSaveEdit_forTeacher.Visible = true;
                    btnSave_forTeacher.Visible = false;

                    DataSet ds = ProductController.Get_FillDetails_ItemRequisition(3, lblPkey.Text.Trim());
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ddlDivision_ForTeacher.SelectedValue = ds.Tables[0].Rows[0]["Division_Code"].ToString();
                        ddlacadyear_ForTeacher.SelectedValue = ds.Tables[0].Rows[0]["Acad_Year"].ToString();
                        TxtRemarks_ForTeacher.Text = ds.Tables[0].Rows[0]["Remark"].ToString();

                        lblRequisition_DateforTech.Text = ds.Tables[0].Rows[0]["Request_Date"].ToString();
                        lblRequest_ByforTech.Text = ds.Tables[0].Rows[0]["User_Display_Name"].ToString();
                        lblRequisition_No.Text = ds.Tables[0].Rows[0]["Request_Code"].ToString();
                        lblApprovedBy.Text = ds.Tables[0].Rows[0]["Approved_By"].ToString();
                        lblApprovedOn.Text = ds.Tables[0].Rows[0]["Approved_On"].ToString();
                        lblApprovedremark.Text = ds.Tables[0].Rows[0]["Approved_Remark"].ToString();
                        lblAuthorisedBy.Text = ds.Tables[0].Rows[0]["Authorised_By"].ToString();
                        lblAuthorisedOn.Text = ds.Tables[0].Rows[0]["Authorised_On"].ToString();
                        lblRemark.Text = ds.Tables[0].Rows[0]["Authorised_Remark"].ToString();

                        //

                        string Re_Status = ds.Tables[0].Rows[0]["Request_Status"].ToString();
                        if (Re_Status == "Pending")
                        {
                            btnSaveEdit_forTeacher.Visible = true;
                            btnSave_forTeacher.Visible = false;
                            Flag_Teacher.Visible = true;
                            lbl_FlagTeacher.Visible = true;
                            lbl_FlagTeacher.Text = Re_Status;
                            TRTeacher.Visible = false;
                            TRTeacher1.Visible = false;
                        }
                        else
                            if (Re_Status == "Approved")
                            {
                                btnSaveEdit_forTeacher.Visible = false;
                                btnSave_forTeacher.Visible = false;
                                Flag_Teacher.Visible = true;
                                lbl_FlagTeacher.Visible = true;
                                lbl_FlagTeacher.Text = Re_Status;
                                TRTeacher1.Visible = false;
                                TRTeacher.Visible = true;
                            }
                            else
                            {
                                btnSaveEdit_forTeacher.Visible = true;
                                btnSave_forTeacher.Visible = false;
                                Flag_Teacher.Visible = true;
                                lbl_FlagTeacher.Visible = true;
                                lbl_FlagTeacher.Text = Re_Status;
                                TRTeacher.Visible = true;
                                TRTeacher1.Visible = false;
                                if (ds.Tables[0].Rows[0]["Level"].ToString() == "Level1" || ds.Tables[0].Rows[0]["Level"].ToString() == "Level2")
                                {
                                    lblHeaderTeacher1.Text = "Approved By";
                                    lblHeaderTeacher2.Text = "Approved On";
                                    lblHeaderTeacher3.Text = "Remarks";

                                    lblApprovedBy.Text = ds.Tables[0].Rows[0]["Approved_By"].ToString();
                                    lblApprovedOn.Text = ds.Tables[0].Rows[0]["Approved_On"].ToString();
                                    lblApprovedremark.Text = ds.Tables[0].Rows[0]["Approved_Remark"].ToString();
                                }
                                else

                                    if (ds.Tables[0].Rows[0]["Level"].ToString() == "Level1" || ds.Tables[0].Rows[0]["Level"].ToString() == "Level2")
                                    {
                                        lblHeaderTeach1.Text = "Authorised By";
                                        lblHeaderTeach2.Text = "Authorised On";
                                        lblHeaderTeach3.Text = "Remarks";

                                        lblAuthorisedBy.Text = ds.Tables[0].Rows[0]["Authorised_By"].ToString();
                                        lblAuthorisedOn.Text = ds.Tables[0].Rows[0]["Authorised_On"].ToString();
                                        lblRemark.Text = ds.Tables[0].Rows[0]["Authorised_Remark"].ToString();
                                    }


                                if (Re_Status == "Authorised")
                                {
                                    btnSaveEdit_forTeacher.Visible = false;
                                    TRTeacher1.Visible = true;
                                }
                            }
                        //

                        DataSet DsGrid = ProductController.GetTeacherDetails(ddlDivision_ForTeacher.SelectedValue.ToString().Trim(), ddlacadyear_ForTeacher.SelectedValue.ToString().Trim(), "", 4);
                        if (DsGrid.Tables[0].Rows.Count > 0)
                        {
                            datalist_Teacher.DataSource = DsGrid;
                            datalist_Teacher.DataBind();
                            teacher.Visible = true;
                            lblteachertotaalrecords.Text = (DsGrid.Tables[0].Rows.Count).ToString();
                        }
                        else
                        {
                            datalist_Teacher.DataSource = null;
                            datalist_Teacher.DataBind();
                        }

                        for (int cnt = 0; cnt <= ds.Tables[1].Rows.Count - 1; cnt++)
                        {

                            foreach (RepeaterItem dtlItem in datalist_Teacher.Items)
                            {
                                CheckBox chkDL_Select_Centre = (CheckBox)dtlItem.FindControl("chkCheck");
                                Label lblPartnerCodeDL = (Label)dtlItem.FindControl("lblPartnerCodeDL");
                                if (Convert.ToString(lblPartnerCodeDL.Text).Trim() == Convert.ToString(ds.Tables[1].Rows[cnt]["User_PrimaryCode"]).Trim())
                                {
                                    chkDL_Select_Centre.Checked = true;
                                    //count = count + 1;
                                    break; // TODO: might not be correct. Was : Exit For
                                }
                            }

                        }

                    }
                }
                else if (lblUserType.Text == "UT004")
                {
                    ControlVisibility("AddEmployee");

                    btnSave_ForEmp.Visible = false;
                    btnSaveEdit_ForEmp.Visible = true;

                    DataSet ds = ProductController.Get_FillDetails_ItemRequisition(3, lblPkey.Text.Trim());
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ddlLocationType.SelectedValue = ds.Tables[0].Rows[0]["Division_Code"].ToString();
                        if (ddlLocationType.SelectedItem.ToString() == "Function")
                        {
                            tblFr_Function.Visible = true;
                            tblFr_Division.Visible = false;
                            FillDDL_Function();
                            ddlFunctionFR_SR.SelectedValue = ds.Tables[0].Rows[0]["Center_Code"].ToString();

                        }
                        else if (ddlLocationType.SelectedItem.ToString() == "Center")
                        {
                            tblFr_Division.Visible = true;
                            tblFr_Function.Visible = false;

                            FillDDL_Division();
                            ddlDiv_Function_ForEmp.SelectedValue = ds.Tables[0].Rows[0]["Center_Code"].ToString();

                        }

                        txtremarks_ForEmployee.Text = ds.Tables[0].Rows[0]["Remark"].ToString();

                        lbl_Requisition_DateforEmpl.Text = ds.Tables[0].Rows[0]["Request_Date"].ToString();
                        lbl_Requisition_ByforTech.Text = ds.Tables[0].Rows[0]["User_Display_Name"].ToString();
                        lbl_Requisition_No.Text = ds.Tables[0].Rows[0]["Request_Code"].ToString();
                        lblEmployeeApprovedBy.Text = ds.Tables[0].Rows[0]["Approved_By"].ToString();
                        lblEmployeeApprovedOn.Text = ds.Tables[0].Rows[0]["Approved_On"].ToString();
                        lblEmployeeRemark.Text = ds.Tables[0].Rows[0]["Approved_Remark"].ToString();
                        lblEmpApprovedBy.Text = ds.Tables[0].Rows[0]["Authorised_By"].ToString();
                        lblEmpApprovedOn.Text = ds.Tables[0].Rows[0]["Authorised_On"].ToString();
                        lblEmpRemark.Text = ds.Tables[0].Rows[0]["Authorised_Remark"].ToString();

                        //

                        string Re_Status = ds.Tables[0].Rows[0]["Request_Status"].ToString();
                        if (Re_Status == "Pending")
                        {
                            btnSave_ForEmp.Visible = false;

                            btnSaveEdit_ForEmp.Visible = true;
                            Flag_Employee.Visible = true;
                            lbl_FlagEmployee.Visible = true;
                            lbl_FlagEmployee.Text = Re_Status;
                            TREmployee.Visible = false;
                            TREmployee1.Visible = false;
                        }
                        else
                            if (Re_Status == "Approved")
                            {
                                btnSaveEdit_ForEmp.Visible = false;
                                btnSave_ForEmp.Visible = false;
                                Flag_Employee.Visible = true;
                                lbl_FlagEmployee.Visible = true;
                                lbl_FlagEmployee.Text = Re_Status;
                                TREmployee.Visible = true;
                                TREmployee1.Visible = false;

                            }
                            else
                            {
                                btnSave_ForEmp.Visible = false;
                                btnSaveEdit_ForEmp.Visible = false;
                                Flag_Employee.Visible = true;
                                lbl_FlagEmployee.Visible = true;
                                lbl_FlagEmployee.Text = Re_Status;
                                TREmployee.Visible = true;
                                TREmployee1.Visible = false;

                                if (ds.Tables[0].Rows[0]["Level"].ToString() == "Level1" || ds.Tables[0].Rows[0]["Level"].ToString() == "Level2")
                                {
                                    lblHeaderEmployee1.Text = "Approved By";
                                    lblHeaderEmployee2.Text = "Approved On";
                                    lblHeaderEmployee3.Text = "Remarks";

                                    lblEmployeeApprovedBy.Text = ds.Tables[0].Rows[0]["Approved_By"].ToString();
                                    lblEmployeeApprovedOn.Text = ds.Tables[0].Rows[0]["Approved_On"].ToString();
                                    lblEmployeeRemark.Text = ds.Tables[0].Rows[0]["Approved_Remark"].ToString();
                                }
                                else


                                    if (ds.Tables[0].Rows[0]["Level"].ToString() == "Level1" || ds.Tables[0].Rows[0]["Level"].ToString() == "Level2")
                                    {
                                        lblHeaderEmp1.Text = "Authorised By";
                                        lblHeaderEmp2.Text = "Authorised On";
                                        lblHeaderEmp3.Text = "Remarks";

                                        lblEmpApprovedBy.Text = ds.Tables[0].Rows[0]["Authorised_By"].ToString();
                                        lblEmpApprovedOn.Text = ds.Tables[0].Rows[0]["Authorised_On"].ToString();
                                        lblEmpRemark.Text = ds.Tables[0].Rows[0]["Authorised_Remark"].ToString();
                                    }

                            }

                        if (Re_Status == "Authorised")
                        {
                            TREmployee1.Visible = true;
                        }



                        txtEmployeeNM.Text = ds.Tables[1].Rows[0]["UserName"].ToString();
                        txtEmployeeCode.Text = ds.Tables[1].Rows[0]["UserCode"].ToString();
                        txtEmailid.Text = ds.Tables[1].Rows[0]["UserEmailId"].ToString();
                        ddlstatus.SelectedValue = ds.Tables[1].Rows[0]["UserStatus"].ToString();

                    }
                }
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
    protected void btnSaveEDit_ForStudent_Click(object sender, EventArgs e)
    {
        try
        {
            Clear_Error_Success_Box();

            if (ddlDivisionforStudent.SelectedIndex == 0 || ddlDivisionforStudent.SelectedIndex == -1)
            {
                Show_Error_Success_Box("E", "Select Division");
                ddlDivisionforStudent.Focus();
                return;
            }

            if (ddlacadyr_frStud.SelectedIndex == 0 || ddlacadyr_frStud.SelectedIndex == -1)
            {
                Show_Error_Success_Box("E", "Select Acad Year");
                ddlacadyr_frStud.Focus();
                return;
            }

            if (ddlcenter_forStudent.SelectedIndex == 0 || ddlcenter_forStudent.SelectedIndex == -1)
            {
                Show_Error_Success_Box("E", "Select Center");
                ddlcenter_forStudent.Focus();
                return;
            }

            if (ddlClassrmProd_frStud.SelectedIndex == 0 || ddlClassrmProd_frStud.SelectedIndex == -1)
            {
                Show_Error_Success_Box("E", "Select Classroom Product");
                ddlClassrmProd_frStud.Focus();
                return;
            }

            if (ddlIteamName_ForStudent.SelectedIndex == 0 || ddlIteamName_ForStudent.SelectedIndex == -1)
            {
                Show_Error_Success_Box("E", "Select Item");
                ddlIteamName_ForStudent.Focus();
                return;
            }

            int TotalRecord = 0;
            foreach (RepeaterItem dtlItem in datalist_Student.Items)
            {
                CheckBox chkCheck = (CheckBox)dtlItem.FindControl("chkCheck");

                if (chkCheck.Checked == true)
                {
                    TotalRecord = TotalRecord + 1;
                }
            }
            if (TotalRecord == 0)
            {
                Show_Error_Success_Box("E", "You have not Selected any Student");
                return;
            }



            string Division = "", Acad = "", center = "", CP = "", Item = "", ResultId = "";

            Division = ddlDivisionforStudent.SelectedValue.ToString().Trim();
            Acad = ddlacadyr_frStud.SelectedValue.ToString().Trim();
            center = ddlcenter_forStudent.SelectedValue.ToString().Trim();
            CP = ddlClassrmProd_frStud.SelectedValue.ToString().Trim();
            Item = ddlIteamName_ForStudent.SelectedValue.ToString().Trim();

            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];
            string RequestCode = lblPkey.Text.Trim();

            ResultId = ProductController.InsertUpdate_ItemRequsition(3, RequestCode, Item, "");

            if (ResultId == "")
            {
                //Show_Error_Success_Box("S", "Record saved Successfully.");
            }
            else if (ResultId == "1")
            {
                Clear_Error_Success_Box();
                int TotalRecord1 = 0;
                foreach (RepeaterItem dtlItem in datalist_Student.Items)
                {
                    CheckBox chkCheck = (CheckBox)dtlItem.FindControl("chkCheck");

                    if (chkCheck.Checked == true)
                    {
                        TotalRecord1 = TotalRecord1 + 1;
                    }
                }
                if (TotalRecord1 == 0)
                {
                    Show_Error_Success_Box("E", "You have not Selected any Student");
                    return;
                }
                string ResultId1 = "";
                foreach (RepeaterItem dtlItem in datalist_Student.Items)
                {
                    CheckBox chkCheck = (CheckBox)dtlItem.FindControl("chkCheck");

                    if (chkCheck.Checked == true)
                    {
                        Label lblSbentryCode = (Label)dtlItem.FindControl("lblStudentCode");

                        ResultId1 = ProductController.Insert_ItemRequsition_items(8, RequestCode, lblSbentryCode.Text.Trim(), "", "", "", "");
                        if (ResultId1 == "1")
                        {

                        }

                    }
                }

                if (ResultId1 == "1")
                {
                    Clear_Error_Success_Box();
                    BtnSearch_Click(this, e);
                    Show_Error_Success_Box("S", "Record Update Successfully.");
                    //
                }
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
    protected void btnSave_forTeacher_Click(object sender, EventArgs e)
    {
        try
        {
            Clear_Error_Success_Box();

            if (ddlDivision_ForTeacher.SelectedIndex == 0 || ddlDivision_ForTeacher.SelectedIndex == -1)
            {
                Show_Error_Success_Box("E", "Select Division");
                ddlDivisionforStudent.Focus();
                return;
            }

            if (ddlacadyear_ForTeacher.SelectedIndex == 0 || ddlacadyear_ForTeacher.SelectedIndex == -1)
            {
                Show_Error_Success_Box("E", "Select Acad Year");
                ddlacadyr_frStud.Focus();
                return;
            }

            int TotalRecord = 0;
            foreach (RepeaterItem dtlItem in datalist_Teacher.Items)
            {
                CheckBox chkCheck = (CheckBox)dtlItem.FindControl("chkCheck");

                if (chkCheck.Checked == true)
                {
                    TotalRecord = TotalRecord + 1;
                }
            }
            if (TotalRecord == 0)
            {
                Show_Error_Success_Box("E", "You have not Selected any Teacher");
                return;
            }

            if (TxtRemarks_ForTeacher.Text.Length == 0)
            {
                Show_Error_Success_Box("E", "Enter Remark");
                TxtRemarks_ForTeacher.Focus();
                return;
            }



            string Division = "", Acad = "", TeacherName = "", Remark = "";

            Division = ddlDivision_ForTeacher.SelectedValue.ToString().Trim();
            Acad = ddlacadyear_ForTeacher.SelectedValue.ToString().Trim();
            TeacherName = txtteacherName.Text.Trim();
            Remark = TxtRemarks_ForTeacher.Text.Trim();

            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];
            string ResultId = "";

            ResultId = ProductController.Insert_ItemRequsition(7, UserID, ddlUserType.SelectedValue.ToString().Trim(), Division, "", Acad, "", "", UserID, Remark);

            if (ResultId == "")
            {
                //Show_Error_Success_Box("S", "Record saved Successfully.");
            }
            else
            {
                Clear_Error_Success_Box();
                int TotalRecord1 = 0;
                foreach (RepeaterItem dtlItem in datalist_Teacher.Items)
                {
                    CheckBox chkCheck = (CheckBox)dtlItem.FindControl("chkCheck");

                    if (chkCheck.Checked == true)
                    {
                        TotalRecord1 = TotalRecord1 + 1;
                    }
                }
                if (TotalRecord1 == 0)
                {
                    Show_Error_Success_Box("E", "You have not Selected any Teacher");
                    return;
                }
                string ResultId1 = "";
                foreach (RepeaterItem dtlItem in datalist_Teacher.Items)
                {
                    CheckBox chkCheck = (CheckBox)dtlItem.FindControl("chkCheck");

                    if (chkCheck.Checked == true)
                    {
                        Label lblPartnerCodeDL = (Label)dtlItem.FindControl("lblPartnerCodeDL");

                        ResultId1 = ProductController.Insert_ItemRequsition_items(8, ResultId, lblPartnerCodeDL.Text.Trim(), "", "", "", "");
                        if (ResultId1 == "1")
                        {

                        }

                    }
                }

                if (ResultId1 == "1")
                {
                    Clear_Error_Success_Box();
                    BtnSearch_Click(this, e);
                    Show_Error_Success_Box("S", "Record saved Successfully.");
                    //
                }
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
    protected void btnSaveEdit_forTeacher_Click(object sender, EventArgs e)
    {
        try
        {
            Clear_Error_Success_Box();

            if (ddlDivision_ForTeacher.SelectedIndex == 0 || ddlDivision_ForTeacher.SelectedIndex == -1)
            {
                Show_Error_Success_Box("E", "Select Division");
                ddlDivisionforStudent.Focus();
                return;
            }

            if (ddlacadyear_ForTeacher.SelectedIndex == 0 || ddlacadyear_ForTeacher.SelectedIndex == -1)
            {
                Show_Error_Success_Box("E", "Select Acad Year");
                ddlacadyr_frStud.Focus();
                return;
            }

            int TotalRecord = 0;
            foreach (RepeaterItem dtlItem in datalist_Teacher.Items)
            {
                CheckBox chkCheck = (CheckBox)dtlItem.FindControl("chkCheck");

                if (chkCheck.Checked == true)
                {
                    TotalRecord = TotalRecord + 1;
                }
            }
            if (TotalRecord == 0)
            {
                Show_Error_Success_Box("E", "You have not Selected any Teacher");
                return;
            }

            if (TxtRemarks_ForTeacher.Text.Length == 0)
            {
                Show_Error_Success_Box("E", "Enter Remark");
                TxtRemarks_ForTeacher.Focus();
                return;
            }




            string Division = "", Acad = "", TeacherName = "", Remark = "";

            Division = ddlDivision_ForTeacher.SelectedValue.ToString().Trim();
            Acad = ddlacadyear_ForTeacher.SelectedValue.ToString().Trim();
            TeacherName = txtteacherName.Text.Trim();
            Remark = TxtRemarks_ForTeacher.Text.Trim();

            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];
            string ResultId = "";

            string RequestCode = lblPkey.Text.Trim();

            ResultId = ProductController.InsertUpdate_ItemRequsition(3, RequestCode, "", Remark);

            if (ResultId == "")
            {
                //Show_Error_Success_Box("S", "Record saved Successfully.");
            }
            else if (ResultId == "1")
            {
                Clear_Error_Success_Box();
                //int TotalRecord = 0;
                foreach (RepeaterItem dtlItem in datalist_Teacher.Items)
                {
                    CheckBox chkCheck = (CheckBox)dtlItem.FindControl("chkCheck");

                    if (chkCheck.Checked == true)
                    {
                        TotalRecord = TotalRecord + 1;
                    }
                }
                if (TotalRecord == 0)
                {
                    Show_Error_Success_Box("E", "You have not Selected any Teacher");
                    return;
                }
                string ResultId1 = "";
                foreach (RepeaterItem dtlItem in datalist_Teacher.Items)
                {
                    CheckBox chkCheck = (CheckBox)dtlItem.FindControl("chkCheck");

                    if (chkCheck.Checked == true)
                    {
                        Label lblPartnerCodeDL = (Label)dtlItem.FindControl("lblPartnerCodeDL");

                        ResultId1 = ProductController.Insert_ItemRequsition_items(8, RequestCode, lblPartnerCodeDL.Text.Trim(), "", "", "", "");
                        if (ResultId1 == "1")
                        {

                        }

                    }
                }

                if (ResultId1 == "1")
                {
                    Clear_Error_Success_Box();
                    BtnSearch_Click(this, e);
                    Show_Error_Success_Box("S", "Record saved Successfully.");
                    //
                }
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
    protected void btnSave_ForEmp_Click(object sender, EventArgs e)
    {
        try
        {
            Clear_Error_Success_Box();

            if (ddlLocationType.SelectedIndex == 0 || ddlLocationType.SelectedIndex == -1)
            {
                Show_Error_Success_Box("E", "Select Location");
                ddlLocationType.Focus();
                return;
            }

            if (ddlLocationType.SelectedItem.ToString() == "Function")
            {
                if (ddlFunctionFR_SR.SelectedIndex == 0 || ddlFunctionFR_SR.SelectedIndex == -1)
                {
                    Show_Error_Success_Box("E", "Select Function");
                    ddlFunctionFR_SR.Focus();
                    return;
                }
            }

            if (ddlLocationType.SelectedItem.ToString() == "Center")
            {
                if (ddlDiv_Function_ForEmp.SelectedIndex == 0 || ddlDiv_Function_ForEmp.SelectedIndex == -1)
                {
                    Show_Error_Success_Box("E", "Select Division");
                    ddlDiv_Function_ForEmp.Focus();
                    return;
                }
            }

            if (txtEmployeeNM.Text.Trim() == "")
            {
                Show_Error_Success_Box("E", "Enter Employee Name");
                txtEmployeeNM.Focus();
                return;
            }

            if (txtEmployeeCode.Text.Trim() == "")
            {
                Show_Error_Success_Box("E", "Enter Employee Code");
                txtEmployeeCode.Focus();
                return;
            }

            if (ddlstatus.SelectedIndex == 0 || ddlstatus.SelectedIndex == -1)
            {
                Show_Error_Success_Box("E", "Select Status");
                ddlstatus.Focus();
                return;
            }

            if (txtremarks_ForEmployee.Text.Trim() == "")
            {
                Show_Error_Success_Box("E", "Enter Remark");
                txtremarks_ForEmployee.Focus();
                return;
            }


            string Remark = "";

            string Transfer_LocationCode = "";
            //

            if (ddlLocationType.SelectedItem.ToString() == "Function")
            {
                Transfer_LocationCode = ddlFunctionFR_SR.SelectedValue.ToString().Trim();
            }
            else if (ddlLocationType.SelectedItem.ToString() == "Center")
            {
                Transfer_LocationCode = ddlDiv_Function_ForEmp.SelectedValue.ToString().Trim();
            }

            Remark = txtremarks_ForEmployee.Text.Trim();

            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];
            string ResultId = "";

            ResultId = ProductController.Insert_ItemRequsition(7, UserID, ddlUserType.SelectedValue.ToString().Trim(), ddlLocationType.SelectedValue.ToString().Trim(), Transfer_LocationCode, "", "", "", UserID, Remark);

            if (ResultId == "")
            {
                //Show_Error_Success_Box("S", "Record saved Successfully.");
            }
            else
            {
                Clear_Error_Success_Box();

                string ResultId1 = "";
                string EMpName = "", EMPCode = "", EmailId = "", Status = "";
                EMpName = txtEmployeeNM.Text.Trim();
                EMPCode = txtEmployeeCode.Text.Trim();
                EmailId = txtEmailid.Text.Trim();
                Status = ddlstatus.SelectedValue.ToString().Trim();


                ResultId1 = ProductController.Insert_ItemRequsition_items(8, ResultId, ddlUserType.SelectedValue.ToString().Trim(), EMpName, EMPCode, EmailId, Status);
                if (ResultId1 == "1")
                {
                    Clear_Error_Success_Box();
                    BtnSearch_Click(this, e);
                    Show_Error_Success_Box("S", "Record saved Successfully.");
                    //
                }
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
    protected void btnSaveEdit_ForEmp_Click(object sender, EventArgs e)
    {
        try
        {
            Clear_Error_Success_Box();

            if (ddlLocationType.SelectedIndex == 0 || ddlLocationType.SelectedIndex == -1)
            {
                Show_Error_Success_Box("E", "Select Location");
                ddlLocationType.Focus();
                return;
            }

            if (ddlLocationType.SelectedItem.ToString() == "Function")
            {
                if (ddlFunctionFR_SR.SelectedIndex == 0 || ddlFunctionFR_SR.SelectedIndex == -1)
                {
                    Show_Error_Success_Box("E", "Select Function");
                    ddlFunctionFR_SR.Focus();
                    return;
                }
            }

            if (ddlLocationType.SelectedItem.ToString() == "Center")
            {
                if (ddlDiv_Function_ForEmp.SelectedIndex == 0 || ddlDiv_Function_ForEmp.SelectedIndex == -1)
                {
                    Show_Error_Success_Box("E", "Select Division");
                    ddlDiv_Function_ForEmp.Focus();
                    return;
                }
            }

            if (txtEmployeeNM.Text.Trim() == "")
            {
                Show_Error_Success_Box("E", "Enter Employee Name");
                txtEmployeeNM.Focus();
                return;
            }

            if (txtEmployeeCode.Text.Trim() == "")
            {
                Show_Error_Success_Box("E", "Enter Employee Code");
                txtEmployeeCode.Focus();
                return;
            }

            if (ddlstatus.SelectedIndex == 0 || ddlstatus.SelectedIndex == -1)
            {
                Show_Error_Success_Box("E", "Select Status");
                ddlstatus.Focus();
                return;
            }

            if (txtremarks_ForEmployee.Text.Trim() == "")
            {
                Show_Error_Success_Box("E", "Enter Remark");
                txtremarks_ForEmployee.Focus();
                return;
            }


            string Remark = "";

            string Transfer_LocationCode = "";
            //

            if (ddlLocationType.SelectedItem.ToString() == "Function")
            {
                Transfer_LocationCode = ddlFunctionFR_SR.SelectedValue.ToString().Trim();
            }
            else if (ddlLocationType.SelectedItem.ToString() == "Center")
            {
                Transfer_LocationCode = ddlDiv_Function_ForEmp.SelectedValue.ToString().Trim();
            }

            Remark = txtremarks_ForEmployee.Text.Trim();

            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];
            string ResultId = "";


            string RequestCode = lblPkey.Text.Trim();

            ResultId = ProductController.InsertUpdate_ItemRequsition_ForEMP(4, RequestCode, ddlLocationType.SelectedValue.ToString().Trim(), Transfer_LocationCode, Remark);

            if (ResultId == "")
            {
                //Show_Error_Success_Box("S", "Error");
                //return;
            }
            else if (ResultId == "1")
            {
                Clear_Error_Success_Box();

                string ResultId1 = "";
                string EMpName = "", EMPCode = "", EmailId = "", Status = "";
                EMpName = txtEmployeeNM.Text.Trim();
                EMPCode = txtEmployeeCode.Text.Trim();
                EmailId = txtEmailid.Text.Trim();
                Status = ddlstatus.SelectedValue.ToString().Trim();


                ResultId1 = ProductController.Insert_ItemRequsition_items(8, RequestCode, ddlUserType.SelectedValue.ToString().Trim(), EMpName, EMPCode, EmailId, Status);
                if (ResultId1 == "1")
                {
                    Clear_Error_Success_Box();
                    BtnSearch_Click(this, e);
                    Show_Error_Success_Box("S", "Record saved Successfully.");
                    //
                }
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

    protected void chkAttendanceAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox s = sender as CheckBox;

        //Set checked status of hidden check box to items in grid
        foreach (RepeaterItem dtlItem in datalist_Student.Items)
        {
            CheckBox chkitemck = (CheckBox)dtlItem.FindControl("chkCheck");
            //System.Web.UI.HtmlControls.HtmlInputCheckBox chkitemck = (System.Web.UI.HtmlControls.HtmlInputCheckBox)dtlItem.FindControl("chkDL_Select_Center");
            chkitemck.Checked = s.Checked;
        }
        if (s.Checked == false)
        {


            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "table();", true);


        }



    }

    protected void ChkTeacherAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox s = sender as CheckBox;

        //Set checked status of hidden check box to items in grid
        foreach (RepeaterItem dtlItem in datalist_Teacher.Items)
        {
            CheckBox chkitemck = (CheckBox)dtlItem.FindControl("chkCheck");
            //System.Web.UI.HtmlControls.HtmlInputCheckBox chkitemck = (System.Web.UI.HtmlControls.HtmlInputCheckBox)dtlItem.FindControl("chkDL_Select_Center");
            chkitemck.Checked = s.Checked;
        }
        if (s.Checked == false)
        {


            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "table1();", true);


        }



    }
    protected void HLExport_Click(object sender, EventArgs e)
    {
        DataList1.Visible = true;

        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        string filenamexls1 = "Item_Requisition_" + DateTime.Now + ".xls";
        Response.AddHeader("Content-Disposition", "inline;filename=" + filenamexls1);
        HttpContext.Current.Response.Charset = "utf-8";
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");
        //sets font
        HttpContext.Current.Response.Write("<font style='font-size:10.0pt; font-family:Calibri;'>");
        HttpContext.Current.Response.Write("<BR><BR><BR>");
        HttpContext.Current.Response.Write("<Table border='1'  borderColor='#000000' cellSpacing='0' cellPadding='0' style='font-size:10.0pt; font-family:Calibri; text-align:center;'> <TR style='color: #fff; background: black;text-align:center;'><TD Colspan='6'>Item Requisition</b></TD></TR>");
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



    protected void ddlClassrmProd_frStud_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillItemName();
        ddlIteamName_ForStudent.SelectedIndex = 0;
    }


    protected void searchstudent_Click(object sender, EventArgs e)
    {
        Clear_Error_Success_Box();
        string Division = "", Acad = "", center = "", CP = "", Item = "";

        Division = ddlDivisionforStudent.SelectedValue.ToString().Trim();
        Acad = ddlacadyr_frStud.SelectedValue.ToString().Trim();
        center = ddlcenter_forStudent.SelectedValue.ToString().Trim();
        CP = ddlClassrmProd_frStud.SelectedValue.ToString().Trim();
        Item = ddlIteamName_ForStudent.SelectedValue.ToString().Trim();
        datalist_Student.DataSource = null;
        datalist_Student.DataBind();
        string studentname = txtstudentName.Text;
        string sbentrycode = txtsbentrycode.Text;



        DataSet Ds = ProductController.GetStudent_fornewrequest(Division, center, CP, Acad, 12, studentname, sbentrycode);

        if (Ds != null)
        {
            if (Ds.Tables.Count != 0)
            {
                if (Ds.Tables[0].Rows.Count != 0)
                {
                    datalist_Student.DataSource = Ds;
                    datalist_Student.DataBind();
                    UpdatePanel1.Update();
                }
                else
                {

                    datalist_Student.DataSource = null;
                    datalist_Student.DataBind();


                    //
                    Clear_Error_Success_Box();
                    Msg_Error.Visible = true;
                    Msg_Success.Visible = false;
                    lblerror.Text = "Students Not Found";
                    UpdatePanelMsgBox.Update();
                    return;
                }
            }
            else
            {
                datalist_Student.DataSource = null;
                datalist_Student.DataBind();

                //
                Clear_Error_Success_Box();
                Msg_Error.Visible = true;
                Msg_Success.Visible = false;
                lblerror.Text = "Students Not Found";
                UpdatePanelMsgBox.Update();
                return;
            }
        }
        else
        {
            datalist_Student.DataSource = null;
            datalist_Student.DataBind();
            //
            Clear_Error_Success_Box();
            Msg_Error.Visible = true;
            Msg_Success.Visible = false;
            lblerror.Text = "Students Not Found";
            UpdatePanelMsgBox.Update();
            return;
        }
    }

    protected void txtsbentrycode_TextChanged(object sender, EventArgs e)
    {
        string student_Name = "";
        string sbentrycode = "";
        string student_code = "";
        UpdatePanel4.Update();
        if (txtsbentrycode.Text != "" || txtstudentName.Text != "")
        {
          

                int TotalRecord = 0;
                foreach (RepeaterItem dtlItem in datalist_Student.Items)
                {
                    CheckBox chkCheck = (CheckBox)dtlItem.FindControl("chkCheck");
                    Label lblStudentCode = (Label)dtlItem.FindControl("lblStudentCode");
                    // Label lblStudentCode = (Label)dtlItem.FindControl("lblStudentCode");

                    if (chkCheck.Checked == true)
                    {
                        TotalRecord = TotalRecord + 1;

                        sbentrycode = sbentrycode + lblStudentCode.Text + ",";

                    }
                }
           
            if (txtstudentName.Text != "")
            {
                student_Name = txtstudentName.Text;
            }
            if (txtsbentrycode.Text != "")
            {
                student_code = txtsbentrycode.Text;
            }
            string Division = "", Acad = "", center = "", CP = "", Item = "";

            Division = ddlDivisionforStudent.SelectedValue.ToString().Trim();
            Acad = ddlacadyr_frStud.SelectedValue.ToString().Trim();
            center = ddlcenter_forStudent.SelectedValue.ToString().Trim();
            CP = ddlClassrmProd_frStud.SelectedValue.ToString().Trim();
            Item = ddlIteamName_ForStudent.SelectedValue.ToString().Trim();
            sbentrycode = Common.RemoveComma(sbentrycode);
            int Flag = 14;
            if (student_Name == "")
            {
                Flag = 13;
            }
            DataSet Ds = ProductController.GetStudentDetails(Division, center, CP, Acad, 13, sbentrycode, student_Name, student_code);
            if (Ds != null)
            {
                if (Ds.Tables.Count != 0)
                {
                    if (Ds.Tables[0].Rows.Count != 0)
                    {
                        datalist_Student.DataSource = Ds.Tables[0];
                        datalist_Student.DataBind();
                        UpdatePanel1.Update();
                        foreach (RepeaterItem dtlItem in datalist_Student.Items)
                        {
                            Label lblSbentryCode = (Label)dtlItem.FindControl("lblStudentCode");
                            Label lblMenuName = (Label)dtlItem.FindControl("lblMenuName");


                        }

                    }
                    else
                    {

                        datalist_Student.DataSource = null;
                        datalist_Student.DataBind();


                        //
                        Clear_Error_Success_Box();
                        Msg_Error.Visible = true;
                        Msg_Success.Visible = false;
                        lblerror.Text = "Students Not Found";
                        UpdatePanelMsgBox.Update();
                        return;
                    }
                }
            }
            // btnshow_Click(this ,e);
        }

        if (txtsbentrycode.Text == "" && txtstudentName.Text == "")
        {
            

                int TotalRecord = 0;
                foreach (RepeaterItem dtlItem in datalist_Student.Items)
                {
                    CheckBox chkCheck = (CheckBox)dtlItem.FindControl("chkCheck");
                    Label lblStudentCode = (Label)dtlItem.FindControl("lblStudentCode");
                    // Label lblStudentCode = (Label)dtlItem.FindControl("lblStudentCode");

                    if (chkCheck.Checked == true)
                    {
                        TotalRecord = TotalRecord + 1;

                        sbentrycode = sbentrycode + lblStudentCode.Text + ",";

                    }
                }
            
            if (txtstudentName.Text != "")
            {
                student_Name = txtstudentName.Text;
            }
            if (txtsbentrycode.Text != "")
            {
                student_code = txtsbentrycode.Text;
            }
            string Division = "", Acad = "", center = "", CP = "", Item = "";

            Division = ddlDivisionforStudent.SelectedValue.ToString().Trim();
            Acad = ddlacadyr_frStud.SelectedValue.ToString().Trim();
            center = ddlcenter_forStudent.SelectedValue.ToString().Trim();
            CP = ddlClassrmProd_frStud.SelectedValue.ToString().Trim();
            Item = ddlIteamName_ForStudent.SelectedValue.ToString().Trim();
            sbentrycode = Common.RemoveComma(sbentrycode);
            int Flag = 14;
            if (student_Name == "")
            {
                Flag = 13;
            }
            DataSet Ds = ProductController.GetStudentDetails(Division, center, CP, Acad, 13, sbentrycode, student_Name, student_code);
            if (Ds != null)
            {
                if (Ds.Tables.Count != 0)
                {
                    if (Ds.Tables[0].Rows.Count != 0)
                    {
                        datalist_Student.DataSource = Ds.Tables[0];
                        datalist_Student.DataBind();
                        UpdatePanel1.Update();
                        foreach (RepeaterItem dtlItem in datalist_Student.Items)
                        {
                            Label lblSbentryCode = (Label)dtlItem.FindControl("lblStudentCode");
                            Label lblMenuName = (Label)dtlItem.FindControl("lblMenuName");


                        }

                    }
                    else
                    {

                        datalist_Student.DataSource = null;
                        datalist_Student.DataBind();


                        //
                        Clear_Error_Success_Box();
                        Msg_Error.Visible = true;
                        Msg_Success.Visible = false;
                        lblerror.Text = "Students Not Found";
                        UpdatePanelMsgBox.Update();
                        return;
                    }
                }
            }
            // btnshow_Click(this ,e);
        }


        //if (txtsbentrycode.Text != "" || txtstudentName.Text!="")
        //{

        //    int TotalRecord = 0;
        //    foreach (DataListItem dtlItem in datalist_Student.Items)
        //    {
        //        CheckBox chkCheck = (CheckBox)dtlItem.FindControl("chkCheck");
        //        Label lblStudentCode = (Label)dtlItem.FindControl("lblStudentCode");
        //        // Label lblStudentCode = (Label)dtlItem.FindControl("lblStudentCode");

        //        if (chkCheck.Checked == true)
        //        {
        //            TotalRecord = TotalRecord + 1;

        //            sbentrycode = sbentrycode + lblStudentCode.Text + ",";

        //        }
        //    }
        //    if (txtstudentName.Text != "")
        //    {
        //        student_Name = txtstudentName.Text;
        //    }
        //    if (txtsbentrycode.Text != "")
        //    {
        //        student_code = txtsbentrycode.Text;
        //    }
        //    string Division = "", Acad = "", center = "", CP = "", Item = "";

        //    Division = ddlDivisionforStudent.SelectedValue.ToString().Trim();
        //    Acad = ddlacadyr_frStud.SelectedValue.ToString().Trim();
        //    center = ddlcenter_forStudent.SelectedValue.ToString().Trim();
        //    CP = ddlClassrmProd_frStud.SelectedValue.ToString().Trim();
        //    Item = ddlIteamName_ForStudent.SelectedValue.ToString().Trim();
        //    sbentrycode = Common.RemoveComma(sbentrycode);
        //    int Flag = 14;
        //    if (student_Name == "")
        //    {
        //        Flag = 13;
        //    }
        //    DataSet Ds = ProductController.GetStudentDetails(Division, center, CP, Acad, 13, sbentrycode, student_Name, student_code);
        //    if (Ds != null)
        //    {
        //        if (Ds.Tables.Count != 0)
        //        {
        //            if (Ds.Tables[0].Rows.Count != 0)
        //            {
        //                datalist_Student.DataSource = Ds.Tables[0];
        //                datalist_Student.DataBind();
        //                UpdatePanel1.Update();
        //                foreach (DataListItem dtlItem in datalist_Student.Items)
        //                {
        //                    Label lblSbentryCode = (Label)dtlItem.FindControl("lblStudentCode");
        //                    Label lblMenuName = (Label)dtlItem.FindControl("lblMenuName");


        //                }

        //            }
        //            else
        //            {

        //                datalist_Student.DataSource = null;
        //                datalist_Student.DataBind();


        //                //
        //                Clear_Error_Success_Box();
        //                Msg_Error.Visible = true;
        //                Msg_Success.Visible = false;
        //                lblerror.Text = "Students Not Found";
        //                UpdatePanelMsgBox.Update();
        //                return;
        //            }
        //        }
        //    }
        //    // btnshow_Click(this ,e);
        //}

    }

    protected void txtstudentName_TextChanged(object sender, EventArgs e)
    {
        string student_Code = "";
        string student_Name = "";
        string sbentrycode = "";
        UpdatePanel4.Update();
        if (txtstudentName.Text != "" || txtsbentrycode.Text != "")
        {
           
                int TotalRecord = 0;

                foreach (RepeaterItem dtlItem in datalist_Student.Items)
                {
                    CheckBox chkCheck = (CheckBox)dtlItem.FindControl("chkCheck");
                    Label lblStudentCode = (Label)dtlItem.FindControl("lblStudentCode");

                    if (chkCheck.Checked == true)
                    {
                        TotalRecord = TotalRecord + 1;

                        sbentrycode = sbentrycode + lblStudentCode.Text + ",";

                    }
                }
           
            if (txtsbentrycode.Text != "")
            {
                student_Code = txtsbentrycode.Text;
            }
            if (txtstudentName.Text != "")
            {
                student_Name = txtstudentName.Text;
            }
            sbentrycode = Common.RemoveComma(sbentrycode);
            string Division = "", Acad = "", center = "", CP = "", Item = "";

            Division = ddlDivisionforStudent.SelectedValue.ToString().Trim();
            Acad = ddlacadyr_frStud.SelectedValue.ToString().Trim();
            center = ddlcenter_forStudent.SelectedValue.ToString().Trim();
            CP = ddlClassrmProd_frStud.SelectedValue.ToString().Trim();
            Item = ddlIteamName_ForStudent.SelectedValue.ToString().Trim();
            DataSet Ds = ProductController.GetStudentDetails(Division, center, CP, Acad, 13, sbentrycode, student_Name, student_Code);
            if (Ds != null)
            {
                if (Ds.Tables.Count != 0)
                {
                    if (Ds.Tables[0].Rows.Count != 0)
                    {
                        datalist_Student.DataSource = Ds.Tables[0];
                        datalist_Student.DataBind();
                        UpdatePanel1.Update();
                        foreach (RepeaterItem dtlItem in datalist_Student.Items)
                        {
                            Label lblSbentryCode = (Label)dtlItem.FindControl("lblStudentCode");
                            Label lblMenuName = (Label)dtlItem.FindControl("lblMenuName");


                        }

                    }
                    else
                    {

                        datalist_Student.DataSource = null;
                        datalist_Student.DataBind();


                        //
                        Clear_Error_Success_Box();
                        Msg_Error.Visible = true;
                        Msg_Success.Visible = false;
                        lblerror.Text = "Students Not Found";
                        UpdatePanelMsgBox.Update();
                        return;
                    }
                }
            }
        }

        if (txtstudentName.Text == "" && txtsbentrycode.Text == "")
        {
           
                int TotalRecord = 0;

                foreach (RepeaterItem dtlItem in datalist_Student.Items)
                {
                    CheckBox chkCheck = (CheckBox)dtlItem.FindControl("chkCheck");
                    Label lblStudentCode = (Label)dtlItem.FindControl("lblStudentCode");

                    if (chkCheck.Checked == true)
                    {
                        TotalRecord = TotalRecord + 1;

                        sbentrycode = sbentrycode + lblStudentCode.Text + ",";

                    }
                }
            
            if (txtsbentrycode.Text != "")
            {
                student_Code = txtsbentrycode.Text;
            }
            if (txtstudentName.Text != "")
            {
                student_Name = txtstudentName.Text;
            }
            sbentrycode = Common.RemoveComma(sbentrycode);
            string Division = "", Acad = "", center = "", CP = "", Item = "";

            Division = ddlDivisionforStudent.SelectedValue.ToString().Trim();
            Acad = ddlacadyr_frStud.SelectedValue.ToString().Trim();
            center = ddlcenter_forStudent.SelectedValue.ToString().Trim();
            CP = ddlClassrmProd_frStud.SelectedValue.ToString().Trim();
            Item = ddlIteamName_ForStudent.SelectedValue.ToString().Trim();
            DataSet Ds = ProductController.GetStudentDetails(Division, center, CP, Acad, 13, sbentrycode, student_Name, student_Code);
            if (Ds != null)
            {
                if (Ds.Tables.Count != 0)
                {
                    if (Ds.Tables[0].Rows.Count != 0)
                    {
                        datalist_Student.DataSource = Ds.Tables[0];
                        datalist_Student.DataBind();
                        UpdatePanel1.Update();
                        foreach (RepeaterItem dtlItem in datalist_Student.Items)
                        {
                            Label lblSbentryCode = (Label)dtlItem.FindControl("lblStudentCode");
                            Label lblMenuName = (Label)dtlItem.FindControl("lblMenuName");


                        }

                    }
                    else
                    {

                        datalist_Student.DataSource = null;
                        datalist_Student.DataBind();


                        //
                        Clear_Error_Success_Box();
                        Msg_Error.Visible = true;
                        Msg_Success.Visible = false;
                        lblerror.Text = "Students Not Found";
                        UpdatePanelMsgBox.Update();
                        return;
                    }
                }
            }
        }

    }
    protected void ddlIteamName_ForStudent_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}