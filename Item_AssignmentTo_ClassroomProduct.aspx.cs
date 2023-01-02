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

public partial class Item_AssignmentTo_ClassroomProduct : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //FillDDL_UserType();
            //FillDDL_LocationType();
            FillDDL_Division();


            /////////
            //FillDDL_DivisionForStud();
            FillDDL_AcadYear();
            ////FillDDL_Centre();
            //FillDDL_AcadYearForTeacher();
            //FillDDL_DivisionForTeacher();
            //FillDDL_DivisionForEmployee();

            //FillItemName();
            //HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            //string UserID = cookie.Values["UserID"];
            //string UserName = cookie.Values["UserName"];
            //lblDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            //lblRequestByforStud.Text = UserName;
            //lblStudApproved.Text = UserName;
            //lblRequisition_DateforTech.Text = DateTime.Now.ToString("dd-MM-yyyy");
            //lblRequest_ByforTech.Text = UserName;
            //lbl_Requisition_DateforEmpl.Text = DateTime.Now.ToString("dd-MM-yyyy");
            //lbl_Requisition_ByforTech.Text = UserName;

        }
    }
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
            //ddlDiv_Function_ForEmp.Items.Clear();
            DataSet dsDivision = ProductController.GetAllActiveUser_Company_Division_Zone_Center(UserID, Company_Code, "", "", "2", DBname);
            BindDDL(ddlDivision, dsDivision, "Division_Name", "Division_Code");
            ddlDivision.Items.Insert(0, "Select Division");
            ddlDivision.SelectedIndex = 0;

            BindDDL(ddlDivisionNew, dsDivision, "Division_Name", "Division_Code");
            ddlDivisionNew.Items.Insert(0, "Select Division");
            ddlDivisionNew.SelectedIndex = 0;

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
    private void FillDDL_AcadYear()
    {
        try
        {
            DataSet dsAcadYear = ProductController.GetAllActiveUser_AcadYear();
            BindDDL(ddlacadyr, dsAcadYear, "Description", "Id");
            ddlacadyr.Items.Insert(0, "Select");
            ddlacadyr.SelectedIndex = 0;
            DataSet dsAcadYear1 = ProductController.GetAllActiveUser_AcadYear();
            BindDDL(ddlacad_year1, dsAcadYear, "Description", "Id");
            ddlacad_year1.Items.Insert(0, "Select");
            ddlacad_year1.SelectedIndex = 0;
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
    //private void Fill_ClassRoomProductForItemRequisition()
    //{
    //    try
    //    {
    //        string Division_Code;
    //        Division_Code = ddlDivision.SelectedValue.ToString();
    //        string CenterCode;
    //        CenterCode = ddlacadyr.SelectedValue.ToString();
    //        string AcadYear;
    //        AcadYear = ddlacadyr.SelectedValue.ToString();


    //        DataSet dsClassRoomProduct = ProductController.GetClassroomProducts_ForItemRequisition(Division_Code, CenterCode, AcadYear, "1");
    //        BindDDL(ddlclassroomproduct, dsClassRoomProduct, "Stream_Name", "Stream_Code");
    //        ddlclassroomproduct.Items.Insert(0, "Select");

    //        //ddlCenters.Items.Insert(0, "Select");
    //        //ddlClassrmProd_frStud.SelectedIndex = 0;

    //    }
    //    catch (Exception ex)
    //    {

    //    }

    //}
    private void FillDDL_Divisifornew()
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
            BindDDL(ddlDivision, dsDivision, "Division_Name", "Division_Code");
            ddlDivision.Items.Insert(0, "Select Division");
            ddlDivision.SelectedIndex = 0;


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

    private void ControlVisibility(string Mode)
    {
        if (Mode == "Search")
        {
            // div_student.Visible = false;
            // div_Employee.Visible = false;
            // div_Teacher.Visible = false;
            DivSearchPanel.Visible = true;
            BtnAdd.Visible = true;
            div_Newassignment.Visible = false;
            BtnShowSearchPanel.Visible = false;

            DivResultPanel.Visible = false;

        }
        else if (Mode == "Result")
        {
            //div_student.Visible = false;
            // div_Employee.Visible = false;
             BtnAdd.Visible = true;
            DivSearchPanel.Visible = false;
            BtnAdd.Visible = false;
            BtnShowSearchPanel.Visible = true;
            DivResultPanel.Visible = true;
           // lblPkey.Text = "";
            div_Newassignment.Visible = false;
            BtnShowSearchPanel.Visible = true;

        }
        else if (Mode == "edit")
        {
            //div_student.Visible = false;
            // div_Employee.Visible = false;
            // div_Teacher.Visible = false;
            DivSearchPanel.Visible = false;
            div_Newassignment.Visible = false;
           // BtnAdd.Visible = true;
            DivResultPanel.Visible = true;
          //  lblPkey.Text = "";
            BtnShowSearchPanel.Visible = true;

        }
        else if (Mode == "Student")
        {
            DivSearchPanel.Visible = false;
            div_Newassignment.Visible = true;
            BtnAdd.Visible = false;
            BtnShowSearchPanel.Visible = true;
            ddlDivisionNew.Enabled = true;
            BtnSaveEdit.Visible = false;

            ddlclassroomProduct1.Enabled = true;
            ddlacad_year1.Enabled = true;
            //  txtItem_Name.Enabled = true;
            ClearFields();
            // div_student.Visible = true;
            // div_Teacher.Visible = false;
            //  div_Employee.Visible = false;
            BtnShowSearchPanel.Visible = true;

        }

        else if (Mode == "AddClassRoomStudent")
        {
            DivSearchPanel.Visible = false;
            div_Newassignment.Visible = true;

            //div_Employee.Visible = false;
            // div_Teacher.Visible = false;
            BtnShowSearchPanel.Visible = true;
            ddlDivisionNew.Enabled = false;
             ddlacad_year1.Enabled = false;
             ddlclassroomProduct1.Enabled = false;
            // ddlClassrmProd_frStud.Enabled = true;
            ClearFields();
            DivResultPanel.Visible = false;
            // btnshow.Visible = true;
            // btnSaveEDit_ForStudent.Visible = false;
            btnSave_ForStudent.Visible = true;
            BtnAdd.Visible = false;

        }
        else if (Mode == "AddECommerceStudent")
        {
            DivSearchPanel.Visible = false;
            ddlDivisionNew.Enabled = false;
            // div_student.Visible = true;
            // div_Teacher.Visible = false;
            //  div_Employee.Visible = false;
            BtnShowSearchPanel.Visible = true;
        }


    }
    private void ClearFields()
    {
        //For Student
       //ddlDivisionNew.SelectedIndex = 0;
        //ddlacad_year1.SelectedIndex = 0;
        txtItem_Name.Text = "";
       // if (ddlclassroomProduct1.SelectedValue == "0")
       // {
       //     ddlclassroomProduct1.Enabled = false;
       // }
       // else
       //// ddlclassroomProduct1.SelectedIndex = 0;
       // if (ddlclassroomProduct1.SelectedIndex == 0)
       // {
       //     ddlclassroomProduct1.Enabled = false;
       // }
        //ddlclassroomProduct1.SelectedValue = 0;
       
       

    }
    private void Fill_ClassRoomProductForItemRequisition()
    {
        try
        {
            string Division_Code;
            Division_Code = ddlDivision.SelectedValue.ToString();

            string AcadYear;
            AcadYear = ddlacadyr.SelectedValue.ToString();


            DataSet dsClassRoomProduct = ProductController.GetClassroomProducts_ForItemassignment(Division_Code, AcadYear, "1");
            BindDDL(ddlclassroomproduct, dsClassRoomProduct, "Stream_Name", "Stream_Code");
            ddlclassroomproduct.Items.Insert(0, "Select");



        }
        catch (Exception ex)
        {

        }

    }
    protected void BtnAdd_Click1(object sender, EventArgs e)
    {


        try
        {
            Clear_Error_Success_Box();

          

            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];
           string Location;

            if (ddlDivision.SelectedIndex == 0 || ddlDivision.SelectedIndex == -1)
            {
                Show_Error_Success_Box("E", "Select Division");
                ddlDivision.Focus();
                return;
            }
            ddlDivisionNew.SelectedValue = ddlDivision.SelectedValue;
           // Location = ddlDivisionNew.SelectedValue;
           // Location = ddlDivisionNew.SelectedItem.ToString().Trim();
           // Location = ddlDivision.SelectedItem.ToString().Trim();

            if (ddlacadyr.SelectedIndex == 0 || ddlacad_year1.SelectedIndex == -1)
            {
                Show_Error_Success_Box("E", "Select Acad Year");
                ddlacadyr.Focus();
                return;
            }
            ddlacad_year1.SelectedValue = ddlacadyr.SelectedValue;
            if (ddlclassroomproduct.SelectedIndex == 0 || ddlclassroomproduct.SelectedIndex == -1)
            {
                Show_Error_Success_Box("E", "Select ClassroomProduct");
                ddlclassroomproduct.Focus();
                return;
            }
            Fill_ClassRoomProduct();
            ddlclassroomProduct1.SelectedValue = ddlclassroomproduct.SelectedValue;
            ddlclassroomProduct1.Enabled = true;
            //Fill_ClassRoomProductForItemRequisition();
            Fill_ClassRoomProduct();
           // ddlclassroomProduct1.SelectedValue = ddlclassroomproduct.SelectedValue;
           // ddlclassroomProduct1.Enabled = true;
            
            //}
                ControlVisibility("Student");
           // ddlclassroomProduct1.SelectedIndex = 0;
            DivResultPanel.Visible = false;
            btnSave_ForStudent.Visible = true; ;


          


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
    protected void ddlDivision_SelectedIndexChanged(object sender, EventArgs e)
    {
         Fill_ClassRoomProductForItemRequisition();
    }

    private void Fill_ClassRoomProduct()
    {
        try
        {
            string Division_Code;
            Division_Code = ddlDivisionNew.SelectedValue.ToString();
            // string CenterCode;
            // CenterCode = ddlcenter_forStudent.SelectedValue.ToString();
            string AcadYear;
            AcadYear = ddlacad_year1.SelectedValue.ToString();


            DataSet dsClassRoomProduct = ProductController.GetClassroomProducts_ForItemassignment(Division_Code, AcadYear, "1");
            BindDDL(ddlclassroomProduct1, dsClassRoomProduct, "Stream_Name", "Stream_Code");
            ddlclassroomProduct1.Items.Insert(0, "Select");
            ddlclassroomProduct1.SelectedValue = ddlclassroomproduct.SelectedValue;

            //ddlCenters.Items.Insert(0, "Select");
            //ddlClassrmProd_frStud.SelectedIndex = 0;

        }
        catch (Exception ex)
        {

        }

    }

    protected void ddlacad_year1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Fill_ClassRoomProduct();
    }
    protected void btnSave_ForStudent_Click(object sender, EventArgs e)
    {
        try
        {
            Clear_Error_Success_Box();

            if (ddlDivisionNew.SelectedIndex == 0 || ddlDivisionNew.SelectedIndex == -1)
            {
                Show_Error_Success_Box("E", "Select Division");
                ddlDivisionNew.Focus();
                return;
            }

            if (ddlacad_year1.SelectedIndex == 0 || ddlacad_year1.SelectedIndex == -1)
            {
                Show_Error_Success_Box("E", "Select Acad Year");
                ddlacad_year1.Focus();
                return;
            }



            if (ddlclassroomProduct1.SelectedIndex == 0 || ddlclassroomProduct1.SelectedIndex == -1)
            {
                Show_Error_Success_Box("E", "Select Classroom Product");
                ddlclassroomProduct1.Focus();
                return;
            }
            //if (ddlclassroomproduct.SelectedIndex == 0 || ddlclassroomproduct.SelectedIndex == -1)
            //{
            //    Show_Error_Success_Box("E", "Select Classroom Product");
            //    ddlclassroomProduct1.Focus();
            //    return;
            //}

            if (txtItem_Name.Text == "")
            {
                Show_Error_Success_Box("E", "Enter Item Name");
                txtItem_Name.Focus();
                return;
            }
            string Division = "", Acad = "", center = "", CP = "", Item = "", Item1 = "", ResultId = "";

            Division = ddlDivisionNew.SelectedValue.ToString().Trim();
            Acad = ddlacad_year1.SelectedValue.ToString().Trim();
            //center = ddlcenter_forStudent.SelectedValue.ToString().Trim();
            CP = ddlclassroomProduct1.SelectedValue.ToString().Trim();
            // Item = Item + ddlIteamName_ForStudent.SelectedValue + ",";



            Item1 = txtItem_Name.Text;



            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];

            int ActiveFlag = 0;
            if (chkActive.Checked == true)
                ActiveFlag = 1;
            else
                ActiveFlag = 0;

            ResultId = ProductController.Insert_ItemRecord(1, Division, Acad, CP, Item1, UserID, "", ActiveFlag);

            if (ResultId == "")
            {
                Show_Error_Success_Box("E", "Record Not Saved");
            }
            else if (ResultId == "1")
            {
                Clear_Error_Success_Box();
                 BtnSearch_Click(this, e);
                Show_Error_Success_Box("S", "Record saved Successfully.");
                //fillGrid(); 
            }
        }
        catch (Exception ex)
        {
            Clear_Error_Success_Box();
            Show_Error_Success_Box("E", "Record Not Saved");
        }
    }

    private void fillGrid()
    {
        try
        {
            Clear_Error_Success_Box();

            if (ddlDivision.SelectedIndex == 0 || ddlDivision.SelectedIndex == -1)
            {
                Show_Error_Success_Box("E", "Select Division");
                ddlDivision.Focus();
                return;
            }

            if (ddlacadyr.SelectedIndex == 0 || ddlacad_year1.SelectedIndex == -1)
            {
                Show_Error_Success_Box("E", "Select Acad Year");
                ddlacadyr.Focus();
                return;
            }
            if (ddlclassroomproduct.SelectedIndex == 0 || ddlclassroomproduct.SelectedIndex == -1)
            {
                Show_Error_Success_Box("E", "Select ClassroomProduct");
                ddlclassroomproduct.Focus();
                return;
            }

            string Division, AcadYear, Stream;


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

            if (ddlclassroomproduct.SelectedIndex == 0 || ddlclassroomproduct.SelectedIndex == -1)
            {
                Stream = "";
                lblProduct.Text = Stream;
            }
            else
            {
                Stream = ddlclassroomproduct.SelectedValue.ToString().Trim();
                lblProduct.Text = ddlclassroomproduct.SelectedItem.ToString().Trim();
            }

            Division = ddlDivision.SelectedValue.ToString().Trim();
            AcadYear = ddlacadyr.SelectedValue.ToString();
            Stream = ddlclassroomproduct.SelectedValue.ToString().Trim();
            // lblProduct.Text = Stream;
            lblAcadyear.Text = AcadYear;

            ControlVisibility("Result");
            BtnAdd.Visible = false;
            DataSet Ds = ProductController.GetSearchItem(Division, AcadYear, Stream, 2);

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
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        fillGrid();   
    }

    protected void ddlacadyr_SelectedIndexChanged(object sender, EventArgs e)
    {
        Fill_ClassRoomProductForItemRequisition();
    }
    protected void BtnShowSearchPanel_Click(object sender, EventArgs e)
    {

        Clear_Error_Success_Box();
        ControlVisibility("Search");
    }
    protected void btnClose_FotStudent_Click(object sender, EventArgs e)
    {

        Clear_Error_Success_Box();
        DivResultPanel.Visible = true;
        
        BtnAdd.Visible = false;
        div_Newassignment.Visible = false;
        fillGrid(); 
    }
    protected void BtnClearSearch_Click(object sender, EventArgs e)
    {

        Clear_Error_Success_Box();
        ddlDivision.SelectedIndex = 0;
        ddlacadyr.SelectedIndex = 0;
        ddlclassroomproduct.SelectedIndex = 0;
    }
    protected void dlGridDisplay_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

        try
        {
            if (e.CommandName == "comEdit")
            {

                // lblPkey.Text = "";
                string CPItemCode = e.CommandArgument.ToString();
                lblPkey.Text = CPItemCode.ToString();
                //ControlVisibility("AddClassRoomStudent");
                Clear_Error_Success_Box();
                BtnSaveEdit.Visible = true;
                btnSave_ForStudent.Visible = false;
                DivResultPanel.Visible = false;
                div_Newassignment.Visible = true;
               
                HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                string UserID = cookie.Values["UserID"];
                string UserName = cookie.Values["UserName"];


                lblPkey.Text = e.CommandArgument.ToString();
                // string ErrorFlag = "";
                DataSet ds = ProductController.Get_Edit_ItemAssignment(3, lblPkey.Text.Trim());
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlDivisionNew.SelectedValue = ds.Tables[0].Rows[0]["DivisionCode"].ToString();
                    // FillDDL_Centre();
                    ddlacad_year1.SelectedValue = ds.Tables[0].Rows[0]["Acad_Year"].ToString();
                    ddlclassroomProduct1.SelectedValue = ds.Tables[0].Rows[0]["ClassroomProductCode"].ToString();
                    Fill_ClassRoomProduct();
                    txtItem_Name.Text = ds.Tables[0].Rows[0]["CPItem_Name"].ToString();
                    if (Convert.ToInt32(ds.Tables[0].Rows[0]["Is_Active"]) == 0)
                    {
                        chkActive.Checked = false;
                    }
                    else
                    {
                        chkActive.Checked = true;
                    }
                    ddlDivisionNew.Enabled = false;
                    ddlacad_year1.Enabled = false;
                    ddlclassroomProduct1.Enabled = false;
                }
               
            }
            else if (e.CommandName == "ItemRemove")
            {
                //Remove_andFill_Items

                lblPkey.Text = e.CommandArgument.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalDivCOnfirmation();", true);
                BtnSearch_Click(this, e);



            }
        }
        catch (Exception ex)
        {

        }
        
    
    }
    protected void btnDivConfirmYes_Click(object sender, System.EventArgs e)
    {
       // lblPkey.Text = e.CommandArgument.ToString().Trim();
        string CPItemCode = lblPkey.Text.Trim();
        // string CPItemCode
        DataSet dsGrid = ProductController.Get_Delete_ItemAssignmentDetails(5, CPItemCode);

       // DataSet dsGrid = ProductController.Remove_andFill_Items(25, lblInwardEntryCodeRemove.Text.Trim());

        if (dsGrid != null)
        {
            if (dsGrid.Tables.Count != 0)
            {
                if (dsGrid.Tables[0].Rows.Count != 0)
                {
                    //lbltotalcount.Text = (dsGrid.Tables[0].Rows.Count).ToString();
                    dlGridDisplay.DataSource = dsGrid;
                    dlGridDisplay.DataBind();
                   // dlGridDisplay();
                }
                else
                {
                    dlGridDisplay.DataSource = null;
                    dlGridDisplay.DataBind();
                  //  FillTotalDetails_Temp();
                }
            }
            else
            {
                dlGridDisplay.DataSource = null;
                dlGridDisplay.DataBind();
               // FillTotalDetails_Temp();
            }
        }
        else
        {
            dlGridDisplay.DataSource = null;
            dlGridDisplay.DataBind();
            //FillTotalDetails_Temp();
        }

        //UpdatePanel1.Update();
        Clear_Error_Success_Box();
        BtnSearch_Click(this, e);
    }
    protected void BtnSaveEdit_Click(object sender, EventArgs e)
    {
        try
        {
            Clear_Error_Success_Box();

            if (ddlDivisionNew.SelectedIndex == 0 || ddlDivisionNew.SelectedIndex == -1)
            {
                Show_Error_Success_Box("E", "Select Division");
                ddlDivisionNew.Focus();
                return;
            }

            if (ddlacad_year1.SelectedIndex == 0 || ddlacad_year1.SelectedIndex == -1)
            {
                Show_Error_Success_Box("E", "Select Acad Year");
                ddlacad_year1.Focus();
                return;
            }

            if (ddlclassroomProduct1.SelectedIndex == 0 || ddlclassroomProduct1.SelectedIndex == -1)
            {
                Show_Error_Success_Box("E", "Select Center");
                ddlclassroomProduct1.Focus();
                return;
            }

            if (txtItem_Name.Text == "")
            {
                Show_Error_Success_Box("E", "Enter Item Name");
                txtItem_Name.Focus();
                return;
            }
            int ActiveFlag = 0;
            if (chkActive.Checked == true)
                ActiveFlag = 1;
            else
                ActiveFlag = 0;



            ControlVisibility("edit");
            BtnSaveEdit.Visible = true;
            btnSave_ForStudent.Visible = false;
            //  dlQuestion.Visible = true;
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];
            string CPItemCode = lblPkey.Text.Trim();
            string  Item = txtItem_Name.Text.Trim();
           
            DataSet ds = ProductController.Get_Edit_ItemAssignmentDetails(4, CPItemCode, Item, ActiveFlag);
          
                Clear_Error_Success_Box();
                BtnSearch_Click(this, e);
                Show_Error_Success_Box("S", "Record Update Successfully.");
                UpdatePanel1.Update();
                
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
    protected void HLExport_Click(object sender, EventArgs e)
    {
         
        DataList1.Visible = true;

        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        string filenamexls1 = "Item_Assignment" + DateTime.Now + ".xls";
        Response.AddHeader("Content-Disposition", "inline;filename=" + filenamexls1);
        HttpContext.Current.Response.Charset = "utf-8";
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");
        //sets font
        HttpContext.Current.Response.Write("<font style='font-size:10.0pt; font-family:Calibri;'>");
        HttpContext.Current.Response.Write("<BR><BR><BR>");
        HttpContext.Current.Response.Write("<Table border='1'  borderColor='#000000' cellSpacing='0' cellPadding='0' style='font-size:10.0pt; font-family:Calibri; text-align:center;'> <TR style='color: #fff; background: black;text-align:center;'><TD Colspan='7'>Item Assignment To Classroom Product</b></TD></TR>");
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

    protected void ddlDivisionNew_SelectedIndexChanged(object sender, EventArgs e)
    {
          Fill_ClassRoomProduct();
    }
}
    
