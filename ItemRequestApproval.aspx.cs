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
using System.Data.SqlClient;

public partial class ItemRequestApproval : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                ControlVisibility("Search");
                FillDDL_Division();
            }
            catch (Exception ex)
            {
                Msg_Error.Visible = true;
                Msg_Success.Visible = false;
                lblerror.Text = ex.ToString();
                UpdatePanelMsgBox.Update();
                return;
            }
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];

           // lblStudApproved.Text = UserName;
           
           
        }

    }
    private void FillDDL_Division()
    {
        string Company_Code = "MT";
        string DBname = "CDB";

        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];

        //Search DDL
        DataSet dsDivision = ProductController.GetDivision_RequestApprovalProcess(10, UserID);
        BindDDL(ddlDivision, dsDivision, "Division_Name", "Division_Code");
        ddlDivision.Items.Insert(0, "Select");
        ddlDivision.SelectedIndex = 0;

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
        ddlDivision.SelectedIndex = 0;
        ddlsattusforSearch.SelectedIndex = 0;
        id_date_range_picker_1.Value = "";
    }

    protected void dlGridDisplay_ItemCommand(object source, DataListCommandEventArgs e)
    {
        
    }
    protected void btnClose_FotStudent_Click(object sender, EventArgs e)
    {
        //DivResultPanel.Visible = true;
        //DivSearchPanel.Visible = true;
        //div_student.Visible = false;
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
    protected void btncancel_forTeacher_Click(object sender, EventArgs e)
    {
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

    private void Clear_Error_Success_Box()
    {
        Msg_Error.Visible = false;
        Msg_Success.Visible = false;
        lblSuccess.Text = "";
        lblerror.Text = "";
        UpdatePanelMsgBox.Update();
    }

    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            Clear_Error_Success_Box();

            string Status, Division, OrderNO;

            string FromDate, ToDate;

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

            if (id_date_range_picker_1.Value == "")
            {
                FromDate = "";
                ToDate = "";
            }
            else
            {
                string DateRange = "";
                DateRange = id_date_range_picker_1.Value;

                FromDate = DateRange.Substring(0, 10);
                ToDate = (DateRange.Length > 9) ? DateRange.Substring(DateRange.Length - 10, 10) : DateRange;
            }


            if (ddlsattusforSearch.SelectedIndex == 0 || ddlsattusforSearch.SelectedIndex == -1)
            {
                Status = "";
                lblStatus.Text = "";
            }
            else
            {
                Status = ddlsattusforSearch.SelectedItem.ToString().Trim();
                lblStatus.Text = ddlsattusforSearch.SelectedItem.ToString().Trim(); 
            }

            lblPeriod.Text = id_date_range_picker_1.Value;

            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];

            ControlVisibility("Result");
            DataSet Ds = ProductController.GetSearchApprovalRequisition(Division, FromDate, ToDate, Status, 5, UserID);

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
            BtnShowSearchPanel.Visible = false;
            DivResultPanel.Visible = false;

        }
        else if (Mode == "Result")
        {
            div_student.Visible = false;
            div_Employee.Visible = false;
            div_Teacher.Visible = false;
            DivSearchPanel.Visible = false;
            DivResultPanel.Visible = true;
            lblPkey.Text = "";
            BtnShowSearchPanel.Visible = true;

        }
        else if (Mode == "AddStudent")
        {
            DivResultPanel.Visible = false;
            DivSearchPanel.Visible = false;
            div_student.Visible = true;
           // datalist_Student.Visible = true;
            div_Teacher.Visible = false;
            div_Employee.Visible = false;
            ClearFields();
        }
        else if (Mode == "AddTeacher")
        {
            DivResultPanel.Visible = false;
            DivSearchPanel.Visible = false;
            div_student.Visible = false;
            div_Teacher.Visible = true;
            div_Employee.Visible = false;
            ClearFields();
        }
        else if (Mode == "AddEmployee")
        {
            DivResultPanel.Visible = false;
            DivSearchPanel.Visible = false;
            div_student.Visible = false;
            div_Teacher.Visible = false;
            div_Employee.Visible = true;
            ClearFields();

        }


    }

    protected void BtnShowSearchPanel_Click(object sender, EventArgs e)
    {
        ControlVisibility("Search");
        Clear_Error_Success_Box();
    }

    private void ClearFields()
    {
        //For Student
        lblRequ_No.Text = "";
        lblRequisitiondate.Text = "";
        lblRequstby.Text = "";
        lbldivision.Text = "";
        lblCenter.Text = "";
        lblAcadYear.Text = "";
        lblClassroom.Text = "";
        lblItemName.Text = "";
        lblOpenDays.Text = "";
        datalist_Student.DataSource = null;
        datalist_Student.DataBind();
        ddlstatusforStudent.SelectedIndex = 0;
        lblDateforTech.Text = "";
        txtremarksforTech.Text = "";




        //lblDate.Text = "";
       // lblRequestByforStud.Text = "";
       // lblRequisitionNo1.Text = "";
        //For Teacher
       // lblRequisitionNo1.Text = "";
        lblrequisitionDateforTech.Text = "";
        lblRequstbyforTech.Text = "";
        lbldivisionforTech.Text = "";
        lblacadyearforTech.Text = "";
        lblOpendaysforTech.Text = "";
        datalist_Teacher.DataSource = null;
        datalist_Teacher.DataBind();
        TxtRemarks_ForTeacher.Text = "";
        ddlstatusfortech.SelectedIndex = 0;
        lbldate2fortech.Text = "";
        TextBox1.Text = "";

        //For Employee
        lblrequsitionforEMP.Text = "";
        lblrequisitonDateforEMP.Text = "";
        lblrequstbtForEMP.Text = "";
        lbldivisionforEMP.Text = "";
        lblOpendaysForEMP.Text = "";
        lblEmployeenmforEMP.Text = "";
        lblemployeeCodeForEMP.Text = "";
        lblEmailidForEMP.Text = "";
        lblEmpstatusForEMP.Text = "";
        ddlstatusForEMP.SelectedIndex = 0;
        lbl_DateForEMP.Text = "";
        lbl_RemarksForEMP.Text = "";


    }


    protected void dlGridDisplay_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "comEdit")
            {
                Clear_Error_Success_Box();
                lblPkey.Text = "";
                lblUserType.Text = "";
                string Pkey = e.CommandArgument.ToString();
                string[] s1 = Pkey.Split('%');
                lblPkey.Text = s1[0].ToString();
                lblUserType.Text = s1[1].ToString();

                if (lblUserType.Text == "UT001")
                {
                    ControlVisibility("AddStudent");


                    DataSet ds = ProductController.Get_FillDetails_ItemRequisition(6, lblPkey.Text.Trim());
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lblRequ_No.Text = ds.Tables[0].Rows[0]["Request_Code"].ToString();
                        lblRequisitiondate.Text = ds.Tables[0].Rows[0]["Request_Date"].ToString();
                        lblRequstby.Text = ds.Tables[0].Rows[0]["User_Display_Name"].ToString();
                        lbldivision.Text = ds.Tables[0].Rows[0]["Source_Division_ShortDesc"].ToString();
                        lblCenter.Text = ds.Tables[0].Rows[0]["Source_Center_Name"].ToString();
                        lblAcadYear.Text = ds.Tables[0].Rows[0]["Acad_Year"].ToString();
                        lblClassroom.Text = ds.Tables[0].Rows[0]["Stream_Name"].ToString();
                        lblItemName.Text = ds.Tables[0].Rows[0]["item_Name"].ToString();
                        lblOpenDays.Text = ds.Tables[0].Rows[0]["OpenDays"].ToString();
                       

                        string Re_Status = ds.Tables[0].Rows[0]["Request_Status"].ToString();


              



                        if (Re_Status == "Approved" || Re_Status == "Rejected At Approval")
                        {
                            Flag_StudApproved.Visible = true;
                            btnSave_ForStudent.Visible = false;
                            if (Re_Status == "Approved")
                            {
                                ddlstatusforStudent.SelectedValue = "2";
                            }
                            else if (Re_Status == "Rejected At Approval")
                            {
                                ddlstatusforStudent.SelectedValue = "3";
                            }
                            
                            txtremarksforTech.Text = ds.Tables[0].Rows[0]["Approved_Remark"].ToString();
                        }
                        else
                        {
                            Flag_StudApproved.Visible = false;
                            btnSave_ForStudent.Visible = true;
                            ddlstatusforStudent.SelectedIndex = 0;
                            txtremarksforTech.Text = ds.Tables[0].Rows[0]["Approved_Remark"].ToString();
                        }


                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            datalist_Student.DataSource = ds.Tables[1];
                            datalist_Student.DataBind();
                            UpdatePanel1.Update();
                            lbltotalrecords1.Text = (ds.Tables[1].Rows.Count).ToString();
                        }
                        else
                        {
                            datalist_Student.DataSource = null;
                            datalist_Student.DataBind();
                            UpdatePanel1.Update();
                        }


                    }

                    lblDateforTech.Text = DateTime.Now.ToString("dd-MM-yyyy");
                }
                else if (lblUserType.Text == "UT003")
                {
                    ControlVisibility("AddTeacher");

                    DataSet ds = ProductController.Get_FillDetails_ItemRequisition(7, lblPkey.Text.Trim());
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lblrequisitionNo.Text = ds.Tables[0].Rows[0]["Request_Code"].ToString();
                        lblrequisitionDateforTech.Text = ds.Tables[0].Rows[0]["Request_Date"].ToString();
                        lblRequstbyforTech.Text = ds.Tables[0].Rows[0]["User_Display_Name"].ToString();
                        lbldivisionforTech.Text = ds.Tables[0].Rows[0]["Source_Division_ShortDesc"].ToString();
                        lblacadyearforTech.Text = ds.Tables[0].Rows[0]["Acad_Year"].ToString();
                        lblOpendaysforTech.Text = ds.Tables[0].Rows[0]["OpenDays"].ToString();
                        TxtRemarks_ForTeacher.Text = ds.Tables[0].Rows[0]["Remark"].ToString();
                      

                        //string Re_Status = ds.Tables[0].Rows[0]["Request_Status"].ToString();
                        //if (Re_Status == "Approved")
                        //{
                        //    Flag_TCHApproved.Visible = true;
                        //    btnSave_forTeacher.Visible = false;
                        //    ddlstatusfortech.SelectedValue = "2";
                        //    TextBox1.Text = ds.Tables[0].Rows[0]["Approved_Remark"].ToString();
                        //}
                        string Re_Status = ds.Tables[0].Rows[0]["Request_Status"].ToString();




                        if (Re_Status == "Approved" || Re_Status == "Rejected At Approval")
                        {
                            Flag_TCHApproved.Visible = true;
                            btnSave_forTeacher.Visible = false;
                            if (Re_Status == "Approved")
                            {
                                ddlstatusfortech.SelectedValue = "2";
                            }
                            else if (Re_Status == "Rejected At Approval")
                            {
                                ddlstatusfortech.SelectedValue = "3";
                            }

                            txtremarksforTech.Text = ds.Tables[0].Rows[0]["Approved_Remark"].ToString();
                        }
                        else
                        {
                            Flag_TCHApproved.Visible = false;
                            btnSave_forTeacher.Visible = true;
                            ddlstatusfortech.SelectedIndex = 0;
                            TextBox1.Text = ds.Tables[0].Rows[0]["Approved_Remark"].ToString();
                        }

                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            datalist_Teacher.DataSource = ds.Tables[1];
                            datalist_Teacher.DataBind();
                            lblteachertotaalrecords.Text = (ds.Tables[1].Rows.Count).ToString();
                        }
                        else
                        {
                            datalist_Teacher.DataSource = null;
                            datalist_Teacher.DataBind();
                        }


                    }

                    lbldate2fortech.Text = DateTime.Now.ToString("dd-MM-yyyy");

                }

                else if (lblUserType.Text == "UT004")
                {
                    ControlVisibility("AddEmployee");

                    DataSet ds = ProductController.Get_FillDetails_ItemRequisition(8, lblPkey.Text.Trim());
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lblrequsitionforEMP.Text = ds.Tables[0].Rows[0]["Request_Code"].ToString();
                        lblrequisitonDateforEMP.Text = ds.Tables[0].Rows[0]["Request_Date"].ToString();
                        lblrequstbtForEMP.Text = ds.Tables[0].Rows[0]["User_Display_Name"].ToString();
                        lbldivisionforEMP.Text = ds.Tables[0].Rows[0]["DIV"].ToString();
                        lblOpendaysForEMP.Text = ds.Tables[0].Rows[0]["OpenDays"].ToString();
                        lbl_RemarksForEMP.Text = ds.Tables[0].Rows[0]["Remark"].ToString();

                        //string Re_Status = ds.Tables[0].Rows[0]["Request_Status"].ToString();
                        //if (Re_Status == "Approved")
                        //{
                        //    Flag_EMPApproved.Visible = true;
                        //    btnSave_ForEmp.Visible = false;
                        //    ddlstatusForEMP.SelectedValue = "2";
                            
                        //}
                        string Re_Status = ds.Tables[0].Rows[0]["Request_Status"].ToString();
                        if (Re_Status == "Approved" || Re_Status == "Rejected At Approval")
                        {
                            Flag_EMPApproved.Visible = true;
                            btnSave_ForEmp.Visible = false;
                            if (Re_Status == "Approved")
                            {
                                ddlstatusForEMP.SelectedValue = "2";
                            }
                            else if (Re_Status == "Rejected At Approval")
                            {
                                ddlstatusForEMP.SelectedValue = "3";
                            }

                            txtremarksforTech.Text = ds.Tables[0].Rows[0]["Approved_Remark"].ToString();
                        }
                        else
                        {
                            Flag_EMPApproved.Visible = false;
                            btnSave_ForEmp.Visible = true;
                            ddlstatusForEMP.SelectedIndex = 0;
                        }

                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            lblEmployeenmforEMP.Text = ds.Tables[1].Rows[0]["UserName"].ToString();
                            lblemployeeCodeForEMP.Text = ds.Tables[1].Rows[0]["UserCode"].ToString();
                            lblEmailidForEMP.Text = ds.Tables[1].Rows[0]["UserEmailId"].ToString();
                            lblEmailidForEMP.Text = ds.Tables[1].Rows[0]["UserEmailId"].ToString();
                            lblEmpstatusForEMP.Text = ds.Tables[1].Rows[0]["UserStatus"].ToString();
                        }

                    }
                    lbl_DateForEMP.Text = DateTime.Now.ToString("dd-MM-yyyy");

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

    protected void btnSave_ForStudent_Click(object sender, EventArgs e)
    {
        try
        {
            Clear_Error_Success_Box();

            if (ddlstatusforStudent.SelectedIndex == 0 || ddlstatusforStudent.SelectedIndex == -1)
            {
                Show_Error_Success_Box("E", "Select Status");
                ddlstatusforStudent.Focus();
                return;
            }
            
            string Status="",Remark="";

            Status = ddlstatusforStudent.SelectedItem.ToString().Trim();
            Remark = txtremarksforTech.Text.Trim();

            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];
            string ResultId = "";

            ResultId = ProductController.InsertUpdate_ItemApproveRequsition(5, lblPkey.Text.Trim(), Status, Remark, UserID);

            if (ResultId == "1")
            {
                Clear_Error_Success_Box();
                BtnSearch_Click(this, e);
                Show_Error_Success_Box("S", "Record saved Successfully.");
                //
            }
            else
            {
                if (ResultId == "0")
                {
                    Clear_Error_Success_Box();
                    BtnSearch_Click(this, e);
                    Show_Error_Success_Box("E", "Error");
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
    protected void btnSave_forTeacher_Click(object sender, EventArgs e)
    {
        try
        {
            Clear_Error_Success_Box();

            if (ddlstatusfortech.SelectedIndex == 0 || ddlstatusfortech.SelectedIndex == -1)
            {
                Show_Error_Success_Box("E", "Select Status");
                ddlstatusfortech.Focus();
                return;
            }

            string Status = "", Remark = "";

            Status = ddlstatusfortech.SelectedItem.ToString().Trim();
            Remark = TextBox1.Text.Trim();

            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];
            string ResultId = "";

            ResultId = ProductController.InsertUpdate_ItemApproveRequsition(5, lblPkey.Text.Trim(), Status, Remark, UserID);

            if (ResultId == "1")
            {
                Clear_Error_Success_Box();
                BtnSearch_Click(this, e);
                Show_Error_Success_Box("S", "Record saved Successfully.");
                //
            }
            else
            {
                if (ResultId == "0")
                {
                    Clear_Error_Success_Box();
                    BtnSearch_Click(this, e);
                    Show_Error_Success_Box("E", "Error");
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

            if (ddlstatusForEMP.SelectedIndex == 0 || ddlstatusForEMP.SelectedIndex == -1)
            {
                Show_Error_Success_Box("E", "Select Status");
                ddlstatusForEMP.Focus();
                return;
            }

            string Status = "", Remark = "";

            Status = ddlstatusForEMP.SelectedItem.ToString().Trim();
            

            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];
            string ResultId = "";

            ResultId = ProductController.InsertUpdate_ItemApproveRequsition(5, lblPkey.Text.Trim(), Status, Remark, UserID);

            if (ResultId == "1")
            {
                Clear_Error_Success_Box();
                BtnSearch_Click(this, e);
                Show_Error_Success_Box("S", "Record saved Successfully.");
                //
            }
            else
            {
                if (ResultId == "0")
                {
                    Clear_Error_Success_Box();
                    BtnSearch_Click(this, e);
                    Show_Error_Success_Box("E", "Error");
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
    protected void HLExport_Click(object sender, EventArgs e)
    {
        DataList1.Visible = true;

        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        string filenamexls1 = "Item_Request_Approval_" + DateTime.Now + ".xls";
        Response.AddHeader("Content-Disposition", "inline;filename=" + filenamexls1);
        HttpContext.Current.Response.Charset = "utf-8";
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");
        //sets font
        HttpContext.Current.Response.Write("<font style='font-size:10.0pt; font-family:Calibri;'>");
        HttpContext.Current.Response.Write("<BR><BR><BR>");
        HttpContext.Current.Response.Write("<Table border='1'  borderColor='#000000' cellSpacing='0' cellPadding='0' style='font-size:10.0pt; font-family:Calibri; text-align:center;'> <TR style='color: #fff; background: black;text-align:center;'><TD Colspan='6'>Item Request Approval</b></TD></TR>");
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
}