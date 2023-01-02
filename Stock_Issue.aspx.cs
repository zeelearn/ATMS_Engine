using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ShoppingCart.BL;
using System.IO;

public partial class Stock_Issue : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ControlVisibility("Search");
            FillDDL_LocationType();
            FillDDL_Division();
            FillDDL_Godown();
            FillDDL_Function();
            //FillDDL_IssuedToType();
            //FillDDL_ItemReturnStatus();
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
        DataSet dsDivision = ProductController.GetAllActiveUser_Company_Division_Zone_Center(UserID, Company_Code, "", "", "2", DBname);
        BindDDL(ddlDivisionFR_SR, dsDivision, "Division_Name", "Division_Code");
        ddlDivisionFR_SR.Items.Insert(0, "Select");
        ddlDivisionFR_SR.SelectedIndex = 0;

        BindDDL(ddlDivisionFR_SR, dsDivision, "Division_Name", "Division_Code");
        ddlDivisionFR_SR.Items.Insert(0, "Select");
        ddlDivisionFR_SR.SelectedIndex = 0;

        //Add DDL
        BindDDL(ddlDivisionFR_SR, dsDivision, "Division_Name", "Division_Code");
        ddlDivisionFR_SR.Items.Insert(0, "Select");
        ddlDivisionFR_SR.SelectedIndex = 0;

        BindDDL(ddlDivisionFR_SR, dsDivision, "Division_Name", "Division_Code");
        ddlDivisionFR_SR.Items.Insert(0, "Select");
        ddlDivisionFR_SR.SelectedIndex = 0;

    }
    private void FillDDL_LocationType()
    {
        //Search DDL
        DataSet dsTransfer_Tp = ProductController.GetAllTransferType(1);
        BindDDL(ddlLocationType, dsTransfer_Tp, "Transfer_Location_Type_Name", "Transfer_Location_Type_ID");
        ddlLocationType.Items.Insert(0, "Select Location Type");
        ddlLocationType.SelectedIndex = 0;

    }

    private void FillDDL_Function()
    {
        ddlFunctionFR_SR.Items.Clear();
        DataSet dsTransfer_Tp = ProductController.GetGodown_Function_Logistic_Assests_Type(2);
        BindDDL(ddlFunctionFR_SR, dsTransfer_Tp, "Function_Name", "Function_Id");
        ddlFunctionFR_SR.Items.Insert(0, "Select Function");
        ddlFunctionFR_SR.SelectedIndex = 0;
    }

    //private void FillDDL_IssuedToType()
    //{
    //    //Search DDL
    //    DataSet dsStockIssued= ProductController.GetStockIssuedDDL(1);
    //    BindDDL(ddlIssuedToType, dsStockIssued, "Issued_Type_Name", "Issued_Type_Id");
    //    ddlIssuedToType.Items.Insert(0, "Select");
    //    ddlIssuedToType.SelectedIndex = 0;

    //}

    //private void FillDDL_ItemReturnStatus()
    //{
    //    //Search DDL
    //    DataSet dsStockIssued = ProductController.GetStockIssuedDDL(2);
    //    BindDDL(ddlReturnStatus, dsStockIssued, "Return_Status_Name", "Return_Status_Id");
    //    ddlReturnStatus.Items.Insert(0, "Select");
    //    ddlReturnStatus.SelectedIndex = 0;

    //}
    private void BindDDL(DropDownList ddl, DataSet ds, string txtField, string valField)
    {
        ddl.DataSource = ds;
        ddl.DataTextField = txtField;
        ddl.DataValueField = valField;
        ddl.DataBind();
    }
    protected void ddlLocationType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlLocationType.SelectedItem.ToString().Trim() == "Godown")
        {
            tblFr_Godown.Visible = true;
            tblFr_Function.Visible = false;
            tblFr_Division.Visible = false;
            tblFr_Center.Visible = false;
        }
        else if (ddlLocationType.SelectedItem.ToString().Trim() == "Function")
        {
            tblFr_Function.Visible = true;
            tblFr_Godown.Visible = false;
            tblFr_Division.Visible = false;
            tblFr_Center.Visible = false;
        }
        else if (ddlLocationType.SelectedItem.ToString().Trim() == "Center")
        {
            tblFr_Division.Visible = true;
            tblFr_Center.Visible = true;
            tblFr_Function.Visible = false;
            tblFr_Godown.Visible = false;

            //Fill Division
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];

        }
        else if (ddlLocationType.SelectedIndex == 0 || ddlLocationType.SelectedIndex == -1)
        {
            tblFr_Godown.Visible = false;
            tblFr_Function.Visible = false;
            tblFr_Division.Visible = false;
            tblFr_Center.Visible = false;
        }
    }
    protected void ddlDivisionFR_SR_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlCenterFR_SR.Items.Clear();
        FillDDL_FRSearch_Centre();
    }
    private void FillDDL_FRSearch_Centre()
    {
        string Company_Code = "MT";
        string DBname = "CDB";

        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];

        string Div_Code = null;
        Div_Code = ddlDivisionFR_SR.SelectedValue;

        DataSet dsCentre = ProductController.GetAllActiveUser_Company_Division_Zone_Center(UserID, Company_Code, Div_Code, "", "5", DBname);

        BindDDL(ddlCenterFR_SR, dsCentre, "Center_Name", "Center_Code");
        ddlCenterFR_SR.Items.Insert(0, "Select");
        ddlCenterFR_SR.SelectedIndex = 0;
    }
    private void ControlVisibility(string Mode)
    {
        if (Mode == "Search")
        {
            DivAddPanel.Visible = false;
            DivSearchPanel.Visible = true;
            //BtnAdd.Visible = true;
            //BtnSaveAdd.Visible = true;
            //BtnSaveEdit.Visible = false;
            DivResultPanel.Visible = false;
            DivEditPanel.Visible = false;
            BtnAdd.Visible = true;
            BtnShowSearchPanel.Visible = false;
            DivAuthorisePanel.Visible = false;
        }
        else if (Mode == "Result")
        {
            DivAddPanel.Visible = false;
            DivSearchPanel.Visible = false;
            //BtnAdd.Visible = true;
            DivResultPanel.Visible = true;
            BtnAdd.Visible = true;
            DivEditPanel.Visible = false;
            //lblPkey.Text = "";
            DivAuthorisePanel.Visible = false;
            BtnShowSearchPanel.Visible = true;
        }
        else if (Mode == "Add")
        {
            DivAddPanel.Visible = true;
            DivSearchPanel.Visible = false;
            BtnShowSearchPanel.Visible = true;
            DivResultPanel.Visible = false;
            //lblPkey.Text = "";
            //BtnSaveEdit.Visible = false;
            //BtnSaveAdd.Visible = true;
            BtnAdd.Visible = false;
            div_student.Visible = false;
            div_Employee.Visible = false;
            div_Teacher.Visible = false;
            DivEditPanel.Visible = false;
            DivAuthorisePanel.Visible = false;
        }
        else if (Mode == "Edit")
        {
            DivAddPanel.Visible = false;
            DivSearchPanel.Visible = false;
            BtnShowSearchPanel.Visible = true;
            DivResultPanel.Visible = false;
            BtnAdd.Visible = false;
            DivEditPanel.Visible = true;
            div_student_Edit.Visible = false;
            div_Teacher_Edit.Visible = false;
            div_Employee_Edit.Visible = false;
            DivAuthorisePanel.Visible = false;
        }
        else if (Mode == "Authorise")
        {
            DivAddPanel.Visible = false;
            DivSearchPanel.Visible = false;
            BtnShowSearchPanel.Visible = true;
            DivResultPanel.Visible = false;
            BtnAdd.Visible = false;
            DivEditPanel.Visible = false;
            DivAuthorisePanel.Visible = true;
            div_Student_Authorise.Visible = false;
            div_Teacher_Authorise.Visible = false;
            div_Employee_Authorise.Visible = false;
        }
        else if (Mode == "Student")
        {
            div_student.Visible = true;

            div_Teacher.Visible = false;
            div_Employee.Visible = false;
        }
        else if (Mode == "Teacher")
        {

            div_Teacher.Visible = true;

            div_student.Visible = false;
            div_Employee.Visible = false;
        }
        else if (Mode == "Employee")
        {
            div_Employee.Visible = true;

            div_student.Visible = false;
            div_Teacher.Visible = false;
        }
        else if (Mode == "Student_Edit")
        {
            div_student_Edit.Visible = true;
            div_Teacher_Edit.Visible = false;
            div_Employee_Edit.Visible = false;
        }
        else if (Mode == "Teacher_Edit")
        {
            div_student_Edit.Visible = false;
            div_Teacher_Edit.Visible = true;
            div_Employee_Edit.Visible = false;
        }
        else if (Mode == "Employee_Edit")
        {
            div_student_Edit.Visible = false;
            div_Teacher_Edit.Visible = false;
            div_Employee_Edit.Visible = true;
        }
        else if (Mode == "Student_Authorise")
        {
            div_Student_Authorise.Visible = true;
            div_Teacher_Authorise.Visible = false;
            div_Employee_Authorise.Visible = false;
        }
        else if (Mode == "Teacher_Authorise")
        {
            div_Student_Authorise.Visible = false;
            div_Teacher_Authorise.Visible = true;
            div_Employee_Authorise.Visible = false;
        }
        else if (Mode == "Employee_Authorise")
        {
            div_Student_Authorise.Visible = false;
            div_Teacher_Authorise.Visible = false;
            div_Employee_Authorise.Visible = true;
        }

    }


    private void FillDDL_Requisition_No(string Loc_Type_Code, string Loc_Code, int Flag)
    {

        ddlrequi_No.Items.Clear();
        DataSet dsReuisition = ProductController.GetRequisition_No_StockIssue(Loc_Type_Code, Loc_Code, "", Flag);
        BindDDL(ddlrequi_No, dsReuisition, "Request_Code", "Request_Code");
        ddlrequi_No.Items.Insert(0, "Select Requi. No");
        ddlrequi_No.SelectedIndex = 0;
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

    /// <summary>
    /// Clear Error Success Box
    /// </summary>
    private void Clear_Error_Success_Box()
    {
        Msg_Error.Visible = false;
        Msg_Success.Visible = false;
        lblSuccess.Text = "";
        lblerror.Text = "";
        UpdatePanelMsgBox.Update();
    }


    private void FillDDL_Godown()
    {
        ddlgodownFR_SR.Items.Clear();
       
        DataSet dsTransfer_Tp = ProductController.GetGodown_Function_Logistic_Assests_Type(1);
        BindDDL(ddlgodownFR_SR, dsTransfer_Tp, "Godown_Name", "Godown_Id");
        ddlgodownFR_SR.Items.Insert(0, "Select Godown");
        ddlgodownFR_SR.SelectedIndex = 0;
    }

    private void ClearSearchPanel()
    {
        //From Content
        ddlLocationType.SelectedIndex = 0;
        ddlgodownFR_SR.SelectedIndex = 0;
        ddlDivisionFR_SR.SelectedIndex = 0;
        ddlFunctionFR_SR.SelectedIndex = 0;
        ddlCenterFR_SR.Items.Clear();

        //To Content
      
        //date_range_SR.Value = "";
        //txtChallan_SR.Text = "";

        //Visible False from Table
        tblFr_Godown.Visible = false;
        tblFr_Function.Visible = false;
        tblFr_Division.Visible = false;
        tblFr_Center.Visible = false;

        //Visible False TO Table
        //tblTO_Godown.Visible = false;
        //tblTO_Function.Visible = false;
        //tblTO_Division.Visible = false;
        //tblTO_Center.Visible = false;

    }

    protected void BtnClearSearch_Click(object sender, EventArgs e)
    {
        ClearSearchPanel();
    }
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        string Location = "",Transfer_LocationCode = "";
        Clear_Error_Success_Box();
        if (ddlLocationType.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "Select Location Type");
            ddlLocationType.Focus();
            return;
        }


        if (ddlLocationType.SelectedItem.ToString() == "Godown")
        {
            if (ddlgodownFR_SR.SelectedIndex == 0)
            {
                Transfer_LocationCode = "%%";
                //Show_Error_Success_Box("E", "Select Godown");
                //ddlgodownFR_SR.Focus();
                //return;
            }
            else
            {
                Location = ddlgodownFR_SR.SelectedItem.ToString();
                Transfer_LocationCode = ddlgodownFR_SR.SelectedValue.ToString().Trim();
            }

        }
        else if (ddlLocationType.SelectedItem.ToString() == "Function")
        {
            if (ddlFunctionFR_SR.SelectedIndex == 0)
            {
                Transfer_LocationCode = "%%";
                //Show_Error_Success_Box("E", "Select Function");
                //ddlFunctionFR_SR.Focus();
                //return;
            }
            else
            {
                Location = ddlFunctionFR_SR.SelectedItem.ToString();
                Transfer_LocationCode = ddlFunctionFR_SR.SelectedValue.ToString().Trim();
            }
        }
        else if (ddlLocationType.SelectedItem.ToString() == "Center")
        {
            if (ddlDivisionFR_SR.SelectedIndex == 0)
            {
                Transfer_LocationCode = "%%";
                //Show_Error_Success_Box("E", "Select Division");
                //ddlDivisionFR_SR.Focus();
                //return;
            }
            else if (ddlCenterFR_SR.SelectedIndex == 0)
            {
                Transfer_LocationCode = "%%";
                //Show_Error_Success_Box("E", "Select Center");
                //ddlCenterFR_SR.Focus();
                //return;
            }
            else
            {
                Location = ddlCenterFR_SR.SelectedItem.ToString();
                Transfer_LocationCode = ddlCenterFR_SR.SelectedValue.ToString().Trim();
            }
        }


        //if (date_range_SR.Value == "")
        //{
        //    Show_Error_Success_Box("E", "Select Period");
        //    return;
        //}


        ControlVisibility("Result");
        
       
        //string DateRange = "";
        //DateRange = date_range_SR.Value;

        //string FromDate, ToDate;
        //FromDate = DateRange.Substring(0, 10);
        //ToDate = (DateRange.Length > 9) ? DateRange.Substring(DateRange.Length - 10, 10) : DateRange;

        try
        {
            string Request_Code="";
            if(txtRequestCode.Text.Trim()=="")
                Request_Code="%%";
            lbltotalcount.Text = "0";
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            DataSet dsGrid = ProductController.Get_StockIssueDetails(1, ddlLocationType.SelectedValue.ToString(), Transfer_LocationCode, "", "", Request_Code, UserID,"");
            dlGridDisplay.DataSource = dsGrid;
            dlGridDisplay.DataBind();
            
           // DateTime dt = Convert.ToDateTime(FromDate);            
            lblLocationType_Result.Text = ddlLocationType.SelectedItem.ToString();
            //lblPeroidResult.Text = dt.Day + "-" + dt.Month + "-" + dt.Year;
            //dt = Convert.ToDateTime(ToDate);
            //lblPeroidResult.Text = lblPeroidResult.Text + " To " + dt.Day + "-" + dt.Month + "-" + dt.Year;
            //lblLocationResult.Text = Location;



            if (dsGrid != null)
            {
                if (dsGrid.Tables.Count != 0)
                {
                    if (dsGrid.Tables[0].Rows.Count != 0)
                    {
                        lbltotalcount.Text = (dsGrid.Tables[0].Rows.Count).ToString();
                    }
                    else
                    {
                        lbltotalcount.Text = "0";
                    }
                }
                else
                {
                    lbltotalcount.Text = "0";
                }
            }
            else
            {
                lbltotalcount.Text = "0";
            }
        }
        catch (Exception ex)
        {
            Show_Error_Success_Box("E", ex.ToString());
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
    protected void BtnShowSearchPanel_Click(object sender, EventArgs e)
    {
        Clear_Error_Success_Box();
        ControlVisibility("Search");
    }
    protected void HLExport_Click(object sender, EventArgs e)
    {
        //Response.Clear();
        //Response.Buffer = true;
        //Response.ContentType = "application/vnd.ms-excel";
        //string filenamexls1 = "Stock_Report_" + DateTime.Now + ".xls";
        //Response.AddHeader("Content-Disposition", "inline;filename=" + filenamexls1);
        //HttpContext.Current.Response.Charset = "utf-8";
        //HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");
        ////sets font
        //HttpContext.Current.Response.Write("<font style='font-size:10.0pt; font-family:Calibri;'>");
        //HttpContext.Current.Response.Write("<BR><BR><BR>");
        //HttpContext.Current.Response.Write("<Table border='1'  borderColor='#000000' cellSpacing='0' cellPadding='0' style='font-size:10.0pt; font-family:Calibri; text-align:center;'> <TR style='color: #fff; background: black;text-align:center;'><TD Colspan='7'>Stock Report</b></TD></TR><TR><TD Colspan='2'><b>Location Type : " + lblLocationType_Result.Text + "</b></TD><TD Colspan='2'><b>Location : " + lblLocationResult.Text + "</b></TD><TD Colspan='3'><b>Period : " + lblPeroidResult.Text + "</b></TD></TR><TR></TR>");
        //Response.Charset = "";
        //this.EnableViewState = false;
        //System.IO.StringWriter oStringWriter1 = new System.IO.StringWriter();
        //System.Web.UI.HtmlTextWriter oHtmlTextWriter1 = new System.Web.UI.HtmlTextWriter(oStringWriter1);
        ////this.ClearControls(dladmissioncount)
        //dlGridDisplay.RenderControl(oHtmlTextWriter1);
        //Response.Write(oStringWriter1.ToString());
        //Response.Flush();
        //Response.End();
    }


    protected void BtnAdd_Click(object sender, EventArgs e)
    {
        string Location = "",LocationCode="";
        Clear_Error_Success_Box();
        if (ddlLocationType.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "Select Location Type");
            ddlLocationType.Focus();
            return;
        }


        if (ddlLocationType.SelectedItem.ToString() == "Godown")
        {
            if (ddlgodownFR_SR.SelectedIndex == 0)
            {
                //Transfer_LocationCode = "%%";
                Show_Error_Success_Box("E", "Select Godown");
                ddlgodownFR_SR.Focus();
                return;
            }
            else
            {
                Location = ddlgodownFR_SR.SelectedItem.ToString();
                LocationCode = ddlgodownFR_SR.SelectedValue.ToString();
            }

        }
        else if (ddlLocationType.SelectedItem.ToString() == "Function")
        {
            if (ddlFunctionFR_SR.SelectedIndex == 0)
            {
                //Transfer_LocationCode = "%%";
                Show_Error_Success_Box("E", "Select Function");
                ddlFunctionFR_SR.Focus();
                return;
            }
            else
            {
                Location = ddlFunctionFR_SR.SelectedItem.ToString();
                LocationCode = ddlFunctionFR_SR.SelectedValue.ToString();
            }
        }
        else if (ddlLocationType.SelectedItem.ToString() == "Center")
        {
            if (ddlDivisionFR_SR.SelectedIndex == 0)
            {
                Show_Error_Success_Box("E", "Select Division");
                ddlDivisionFR_SR.Focus();
                return;
            }
            else if (ddlCenterFR_SR.SelectedIndex == 0)
            {
                Show_Error_Success_Box("E", "Select Center");
                ddlCenterFR_SR.Focus();
                return;
            }
            else
            {
                Location = ddlCenterFR_SR.SelectedItem.ToString();
                LocationCode = ddlCenterFR_SR.SelectedValue.ToString();
            }            
        }

        lblAddPanelLocationTypeResult.Text = ddlLocationType.SelectedItem.ToString();
        lblAddPanelLocationResult.Text = Location;
        lblAddPanelLocationCodeResult.Text = LocationCode;
        ControlVisibility("Add");
        ClearItemAdd();
        FillDDL_Requisition_No(ddlLocationType.SelectedValue, LocationCode, 1);
        lblPkey.Text = "";
        //ddlIssuedToType.SelectedIndex = 0;
        //lblUser.Text = "";
        //ddlReturnStatus.SelectedIndex = 0;
        //txtReturnDT.Value = "";


    }

    protected void BtnCloseAdd_Click(object sender, EventArgs e)
    {
        ControlVisibility("Search");
    }


    protected void btnSearchItem_Click(object sender, EventArgs e)
    {
        try
        {
            Clear_Error_Success_Box();

            //if (txtItemMatCode.Text.Trim() == "")
            //{
            //    Show_Error_Success_Box("E", "Enter Material Code");
            //    txtItemMatCode.Focus();
            //    return;
            //}

           // DataSet dsSupplier = ProductController.GetIssuedItemDetails(txtItemMatCode.Text.Trim(), ddlLocationType.SelectedValue.ToString(), lblAddPanelLocationCodeResult.Text, 1);
            ClearItemAdd();

            //if (dsSupplier.Tables[0].Rows.Count > 0)
            //{
            //    if (dsSupplier.Tables[0].Rows.Count == 1)
            //    {
            //        lblMateCode.Text = dsSupplier.Tables[0].Rows[0]["Item_Code"].ToString();
            //        lblItemName.Text = dsSupplier.Tables[0].Rows[0]["Item_Name"].ToString();
            //        lblUnit.Text = dsSupplier.Tables[0].Rows[0]["UOM_Name"].ToString();
            //        lblVoucherNo.Text = dsSupplier.Tables[0].Rows[0]["Asset_No"].ToString();

            //    }
            //    else if (dsSupplier.Tables[0].Rows.Count >= 1)
            //    {
            //        DataList3.DataSource = dsSupplier;
            //        DataList3.DataBind();
            //        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalDivOverride();", true);
            //        //UpdatePanel1.Update();
            //    }

            //}
            //else 
            //{
            //    Show_Error_Success_Box("E", "Item are not in stock for this Location");    
            //}
            ////tr1.Visible = true;
            ////tr2.Visible = true;

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


    protected void DataList3_ItemCommand(object source, DataListCommandEventArgs e)
    {

        if (e.CommandName == "comSetItem")
        {
            ClearItemAdd();
            Clear_Error_Success_Box();

           

           // DataSet dsSupplier = ProductController.GetItem_ByAll(MaterialCode, 2);
            //ClearItemAdd();

            //if (dsSupplier.Tables[0].Rows.Count > 0)
            //{
            //    lblMateCode.Text = dsSupplier.Tables[0].Rows[0]["Item_Code"].ToString();
            //    lblItemName.Text = dsSupplier.Tables[0].Rows[0]["Item_Name"].ToString();
            //    lblUnit.Text = dsSupplier.Tables[0].Rows[0]["UOM_Name"].ToString();

            //}

            //tr1.Visible = true;
            //tr2.Visible = true;

            //Label lblDLItemName = (Label)e.Item.FindControl("lblDLItemName");
            //Label lblDLItemUnit = (Label)e.Item.FindControl("lblDLItemUnit");
            //Label lblDLVoucherNo = (Label)e.Item.FindControl("lblDLVoucherNo");

            //lblMateCode.Text = e.CommandArgument.ToString();
            //lblItemName.Text = lblDLItemName.Text;
            //lblUnit.Text = lblDLItemUnit.Text;
            //lblVoucherNo.Text = lblDLVoucherNo.Text;
        }

    }
    public void ClearItemAdd()
    {
        lblUserType.Text = "";
       // txtItemMatCode.Text = "";
       //// txtItemQty.Text = "";
       // //txtItemRate.Text = "";
       // //lblCalValue.Text = "0";
       // lblMateCode.Text = "";
       // lblUnit.Text = "";
       // lblItemName.Text = "";
       // lblVoucherNo.Text = "";
    }

    public void ClearUserAdd()
    {
        //lblUserId.Text = "";
        //lblUser.Text = "";
    }

    protected void BtnSaveAdd_Click(object sender, EventArgs e)
    {
        Clear_Error_Success_Box();
        string Request_EntryCode = "", UserName = "", UserCode = "", Item_Code = "", InwardEntry_Code="";
        if (lblPkey.Text == "")//Insert New Record
        {
            if (ddlrequi_No.SelectedIndex == 0)
            {
                Show_Error_Success_Box("E", "Select Requisition Number");
                return;
            }

            int SelectedRow = 0;

            if (lblUserTypeCode.Text == "UT001")//if User Type is Student
            {
                foreach (DataListItem dtlItem in datalist_Student.Items)
                {
                    CheckBox chkCheck = (CheckBox)dtlItem.FindControl("chkCheck");
                    if (chkCheck.Checked == true)
                    {
                        SelectedRow ++;
                    }
                }
                if (SelectedRow == 0)
                {
                    Show_Error_Success_Box("E", "Select Atleast one Student");
                    return;
                }
                foreach (DataListItem dtlItem in datalist_Student.Items)
                {
                    CheckBox chkCheck = (CheckBox)dtlItem.FindControl("chkCheck");
                    if (chkCheck.Checked == true)
                    {
                        Label lblRequest_EntryCode = (Label)dtlItem.FindControl("lblRequest_EntryCode");
                        Label lblstudnNm = (Label)dtlItem.FindControl("lblstudnNm");
                        Label lblUserCode = (Label)dtlItem.FindControl("lblUserCode");
                        Label lblItemCode = (Label)dtlItem.FindControl("lblItemCode");
                        Label lblInwardEntryCode = (Label)dtlItem.FindControl("lblInwardEntryCode");
                       
                        Request_EntryCode = Request_EntryCode + lblRequest_EntryCode.Text + ",";
                        UserName = UserName + lblstudnNm.Text + ",";
                        UserCode = UserCode + lblUserCode.Text + ",";
                        Item_Code = Item_Code + lblItemCode.Text + ",";
                        InwardEntry_Code = InwardEntry_Code + lblInwardEntryCode.Text + ",";
                    }
                }
            }//End if User Type Student
            else if (lblUserTypeCode.Text == "UT003")//if User Type is Teacher
            {
                foreach (DataListItem dtlItem in datalist_Teacher.Items)
                {
                    CheckBox chkCheck = (CheckBox)dtlItem.FindControl("chkCheck");
                    if (chkCheck.Checked == true)
                    {
                        SelectedRow++;
                    }
                }
                if (SelectedRow == 0)
                {
                    Show_Error_Success_Box("E", "Select Atleast one Teacher");
                    return;
                }
                foreach (DataListItem dtlItem in datalist_Teacher.Items)
                {
                    CheckBox chkCheck = (CheckBox)dtlItem.FindControl("chkCheck");
                    if (chkCheck.Checked == true)
                    {
                        Label lblRequest_EntryCode = (Label)dtlItem.FindControl("Request_EntryCode_TH");
                        Label lblTeachername = (Label)dtlItem.FindControl("lblTeachername");
                        Label lblUserCode = (Label)dtlItem.FindControl("lblUserCode");
                        Label lblItemCode = (Label)dtlItem.FindControl("lblItemCode");
                        Label lblInwardEntryCode = (Label)dtlItem.FindControl("lblInwardEntryCode");

                        Request_EntryCode = Request_EntryCode + lblRequest_EntryCode.Text + ",";
                        UserName = UserName + lblTeachername.Text + ",";
                        UserCode = UserCode + lblUserCode.Text + ",";
                        Item_Code = Item_Code + lblItemCode.Text + ",";
                        InwardEntry_Code = InwardEntry_Code + lblInwardEntryCode.Text + ",";
                    }
                }
            }//End if User Type Teacher
            else if (lblUserTypeCode.Text == "UT004")//if User Type is Employee
            {
                Request_EntryCode = lblRequ_EntryCodeforEMP.Text;
                UserName = lblEmployeenmforEMP.Text;
                UserCode = lblemployeeCodeForEMP.Text;
                Item_Code = lblEmp_ItemCode.Text;
                InwardEntry_Code = lblEmp_InwardEntryCode.Text;                   
            }//End if User Type Employee

            if (lblUserTypeCode.Text != "")
            {

                HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                string CreatedBy = cookie.Values["UserID"];
                DataSet ds = ProductController.Insert_Update_StockIssue_Header("", ddlLocationType.SelectedValue, lblAddPanelLocationCodeResult.Text, lblUserTypeCode.Text, ddlrequi_No.SelectedValue, Request_EntryCode, UserName, UserCode, Item_Code, InwardEntry_Code, CreatedBy, 1);
                if (ds != null)
                {
                    if (ds.Tables[0].Rows[0]["Result"].ToString() == "1")//If 1 is Return then save record successfully
                    {
                        ControlVisibility("Search");
                        Show_Error_Success_Box("S", "Record Saved Successfully...!");
                    }
                }
            }
        }
        else   //Update Existing Reocrd
        {

        }
        
    }



    protected void btnSearchUser_Click(object sender, EventArgs e)
    {
        try
        {
            Clear_Error_Success_Box();

            //if (txtUID_UName.Text.Trim() == "")
            //{
            //    Show_Error_Success_Box("E", "Enter User Id Or User Name");
            //    txtUID_UName.Focus();
            //    return;
            //}

            //DataSet dsUser = ProductController.GetUserDetails(txtUID_UName.Text.Trim(), 1);
            ClearUserAdd();

            //if (dsUser.Tables[0].Rows.Count > 0)
            //{
            //    if (dsUser.Tables[0].Rows.Count == 1)
            //    {
            //        lblUserId.Text = dsUser.Tables[0].Rows[0]["User_Code"].ToString();
            //        lblUser.Text = dsUser.Tables[0].Rows[0]["User_Display_Name"].ToString();
            //    }
            //    else if (dsUser.Tables[0].Rows.Count >= 1)
            //    {
            //        dlUserDetail.DataSource = dsUser;
            //        dlUserDetail.DataBind();
            //        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalDivUser();", true);
            //        //UpdatePanel1.Update();
            //    }

            //}
            //else
            //{
            //    Show_Error_Success_Box("E", "Item are not in stock for this Location");
            //}
            ////tr1.Visible = true;
            ////tr2.Visible = true;

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


    protected void dlUserDetail_ItemCommand(object source, DataListCommandEventArgs e)
    {

        if (e.CommandName == "comSetUser")
        {
            ClearUserAdd();
            Clear_Error_Success_Box();

            //Label lblDLUserName = (Label)e.Item.FindControl("lblDLUserName");
            //lblUserId.Text = e.CommandArgument.ToString();
            //lblUser.Text = lblDLUserName.Text;
        }

    }

    protected void btnRequi_Search_Click(object sender, EventArgs e)
    {
        try
        {
            Clear_Error_Success_Box();
            ControlVisibility("Add");
            lblUserType.Text = "";
            lblUserTypeCode.Text = "";
            if (ddlrequi_No.SelectedIndex == 0 || ddlrequi_No.SelectedIndex == -1)
            {
                Show_Error_Success_Box("E", "Select Request Code");
                ddlrequi_No.Focus();
                return;
            }

            DataSet dsGrid = ProductController.GetRequisition_No_StockIssue(ddlLocationType.SelectedValue, lblAddPanelLocationCodeResult.Text, ddlrequi_No.SelectedValue, 2);
            if (dsGrid != null)
            {

                if (dsGrid.Tables[0].Rows[0]["UserTypeCode"].ToString() == "UT001")
                {
                    lblUserType.Text = "Student";
                    lblUserTypeCode.Text = "UT001";
                    ControlVisibility("Student");
                    datalist_Student.DataSource = dsGrid.Tables[1];
                    datalist_Student.DataBind();
                }
                else if (dsGrid.Tables[0].Rows[0]["UserTypeCode"].ToString() == "UT003")
                {
                    lblUserType.Text = "Teacher";
                    lblUserTypeCode.Text = "UT003";
                    ControlVisibility("Teacher");
                    datalist_Teacher.DataSource = dsGrid.Tables[1];
                    datalist_Teacher.DataBind();
                }
                else if (dsGrid.Tables[0].Rows[0]["UserTypeCode"].ToString() == "UT004")
                {
                    lblUserType.Text = "Employee";
                    lblUserTypeCode.Text = "UT004";
                    ControlVisibility("Employee");
                    lblRequ_CodeforEmp.Text = dsGrid.Tables[1].Rows[0]["Request_Code"].ToString();
                    lblRequ_EntryCodeforEMP.Text = dsGrid.Tables[1].Rows[0]["Request_EntryCode"].ToString();

                    lblEmployeenmforEMP.Text = dsGrid.Tables[1].Rows[0]["UserName"].ToString(); ;
                    lblemployeeCodeForEMP.Text = dsGrid.Tables[1].Rows[0]["UserCode"].ToString();
                    lblEmailidForEMP.Text = dsGrid.Tables[1].Rows[0]["UserEmailId"].ToString();
                    lblEmpstatusForEMP.Text = dsGrid.Tables[1].Rows[0]["UserStatus"].ToString();
                    lbl_RemarksForEMP.Text = dsGrid.Tables[1].Rows[0]["Remark"].ToString();
                    lblRequ_EmpItmeName.Text = dsGrid.Tables[1].Rows[0]["Item_Name"].ToString();
                    lblEmp_ItemCode.Text = dsGrid.Tables[1].Rows[0]["Item_Code"].ToString();
                    lblEmp_InwardEntryCode.Text = dsGrid.Tables[1].Rows[0]["InwardEntry_Code"].ToString();
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

    protected void ddlrequi_No_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnRequi_Search_Click(sender, e);
    }


    protected void dlGridDisplay_ItemCommand(object source, DataListCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Edit")
            {
                lblPkey.Text = e.CommandArgument.ToString();

                DataSet dsGrid = ProductController.Get_StockIssueDetails(2,"","","","","","",e.CommandArgument.ToString());
                if (dsGrid != null)
                {
                    ControlVisibility("Edit");
                    lblEditLocationType.Text = dsGrid.Tables[0].Rows[0]["LocationType"].ToString();
                    lblEditLocation.Text = dsGrid.Tables[0].Rows[0]["Location"].ToString();
                    lblEditRequisitionNo.Text = dsGrid.Tables[0].Rows[0]["Request_Code"].ToString();

                    if (dsGrid.Tables[0].Rows[0]["ShowAuthoriseButtonFlag"].ToString() == "0")
                    {
                        btnEditStock.Visible = true;
                        lnkAuthorise.Visible = false;

                    }
                    else
                    {
                        btnEditStock.Visible = false;
                        lnkAuthorise.Visible = true;
                    }

                    if (dsGrid.Tables[0].Rows[0]["UserTypeCode"].ToString() == "UT001")
                    {
                        lblEditUserType.Text = "Student";
                        lblUserTypeCode.Text = "UT001";
                        ControlVisibility("Student_Edit");
                        datalist_Student_Edit.DataSource = dsGrid.Tables[1];
                        datalist_Student_Edit.DataBind();
                    }
                    else if (dsGrid.Tables[0].Rows[0]["UserTypeCode"].ToString() == "UT003")
                    {
                        lblEditUserType.Text = "Teacher";
                        lblUserTypeCode.Text = "UT003";
                        ControlVisibility("Teacher_Edit");
                        datalist_Teacher_Edit.DataSource = dsGrid.Tables[1];
                        datalist_Teacher_Edit.DataBind();
                    }
                    else if (dsGrid.Tables[0].Rows[0]["UserTypeCode"].ToString() == "UT004")
                    {
                        lblEditUserType.Text = "Employee";
                        lblUserTypeCode.Text = "UT004";
                        ControlVisibility("Employee_Edit");
                        lblRequ_CodeforEmp_Edit.Text = dsGrid.Tables[1].Rows[0]["Request_Code"].ToString();
                        lblRequ_EntryCodeforEMP_Edit.Text = dsGrid.Tables[1].Rows[0]["Request_EntryCode"].ToString();

                        lblEmployeeName_Edit.Text = dsGrid.Tables[1].Rows[0]["UserName"].ToString(); ;
                        lblEmployeeCode_Edit.Text = dsGrid.Tables[1].Rows[0]["UserCode"].ToString();
                        lblEmployeeEmailId_Edit.Text = dsGrid.Tables[1].Rows[0]["UserEmailId"].ToString();
                        lblEmployeeStatus_Edit.Text = dsGrid.Tables[1].Rows[0]["UserStatus"].ToString();
                        lblEmployeeRemark_Edit.Text = dsGrid.Tables[1].Rows[0]["Remark"].ToString();
                        lblEmployeeItemName_Edit.Text = dsGrid.Tables[1].Rows[0]["Item_Name"].ToString();
                        lblEmp_ItemCode_Edit.Text = dsGrid.Tables[1].Rows[0]["Item_Code"].ToString();
                        lblEmp_InwardEntryCode_Edit.Text = dsGrid.Tables[1].Rows[0]["InwardEntry_Code"].ToString();
                    }
                }
            }//End Edit Command
            else if (e.CommandName == "Authorise")
            {
                lblPkey.Text = e.CommandArgument.ToString();

                DataSet dsGrid = ProductController.Get_StockIssueDetails(3, "", "", "", "", "", "", e.CommandArgument.ToString());
                if (dsGrid != null)
                {
                    ControlVisibility("Authorise");
                    lblAuthoriseLocationType.Text = dsGrid.Tables[0].Rows[0]["LocationType"].ToString();
                    lblAuthoriseLocation.Text = dsGrid.Tables[0].Rows[0]["Location"].ToString();
                    lblAuthoriseRequisitionNo.Text = dsGrid.Tables[0].Rows[0]["Request_Code"].ToString();

                    if (dsGrid.Tables[0].Rows[0]["UserTypeCode"].ToString() == "UT001")
                    {
                        lblAuthoriseUserType.Text = "Student";
                        lblAuthoriseUserTypeCode.Text = "UT001";
                        ControlVisibility("Student_Authorise");
                        datalist_Student_Authorise.DataSource = dsGrid.Tables[1];
                        datalist_Student_Authorise.DataBind();
                    }
                    else if (dsGrid.Tables[0].Rows[0]["UserTypeCode"].ToString() == "UT003")
                    {
                        lblAuthoriseUserType.Text = "Teacher";
                        lblAuthoriseUserTypeCode.Text = "UT003";
                        ControlVisibility("Teacher_Authorise");
                        datalist_Teacher_Authorise.DataSource = dsGrid.Tables[1];
                        datalist_Teacher_Authorise.DataBind();
                    }
                    else if (dsGrid.Tables[0].Rows[0]["UserTypeCode"].ToString() == "UT004")
                    {
                        lblAuthoriseUserType.Text = "Employee";
                        lblAuthoriseUserTypeCode.Text = "UT004";
                        ControlVisibility("Employee_Authorise");
                        lblRequ_CodeforEmp_Edit.Text = dsGrid.Tables[1].Rows[0]["Request_Code"].ToString();
                        lblRequ_EntryCodeforEMP_Edit.Text = dsGrid.Tables[1].Rows[0]["Request_EntryCode"].ToString();

                        lblEmployeeName_Authorise.Text = dsGrid.Tables[1].Rows[0]["UserName"].ToString(); ;
                        lblEmployeeCode_Authorise.Text = dsGrid.Tables[1].Rows[0]["UserCode"].ToString();
                        lblEmployeeEmailId_Authorise.Text = dsGrid.Tables[1].Rows[0]["UserEmailId"].ToString();
                        lblEmployeeStatus_Authorise.Text = dsGrid.Tables[1].Rows[0]["UserStatus"].ToString();
                        lblEmployeeRemark_Authorise.Text = dsGrid.Tables[1].Rows[0]["Remark"].ToString();
                        lblEmployeeItemName_Authorise.Text = dsGrid.Tables[1].Rows[0]["Item_Name"].ToString();
                        lblEmp_ItemCode_Edit.Text = dsGrid.Tables[1].Rows[0]["Item_Code"].ToString();
                        lblEmp_InwardEntryCode_Edit.Text = dsGrid.Tables[1].Rows[0]["InwardEntry_Code"].ToString();
                    }
                }
            }//End Authorise Command
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

    protected void btnEditStockClose_Click(object sender, EventArgs e)
    {
        ControlVisibility("Result");
    }

    protected void btnEditStock_Click(object sender, EventArgs e)
    {
       string Request_EntryCode ="",UserName = "", UserCode = "", Item_Code = "", InwardEntry_Code = "";

       if (lblUserTypeCode.Text == "UT001")//if User Type is Student
        {            
            foreach (DataListItem dtlItem in datalist_Student_Edit.Items)
            {
                CheckBox chkCheck = (CheckBox)dtlItem.FindControl("chkCheck");
                if (chkCheck.Checked == true)
                {
                    Label lblRequest_EntryCode = (Label)dtlItem.FindControl("lblRequest_EntryCode");
                    Label lblstudnNm = (Label)dtlItem.FindControl("lblstudnNm");
                    Label lblUserCode = (Label)dtlItem.FindControl("lblUserCode");
                    Label lblItemCode = (Label)dtlItem.FindControl("lblItemCode");
                    Label lblInwardEntryCode = (Label)dtlItem.FindControl("lblInwardEntryCode");

                    Request_EntryCode = Request_EntryCode + lblRequest_EntryCode.Text + ",";
                    UserName = UserName + lblstudnNm.Text + ",";
                    UserCode = UserCode + lblUserCode.Text + ",";
                    Item_Code = Item_Code + lblItemCode.Text + ",";
                    InwardEntry_Code = InwardEntry_Code + lblInwardEntryCode.Text + ",";
                }
            }
        }//End if User Type Student
        else if (lblUserTypeCode.Text == "UT003")//if User Type is Teacher
        {
            foreach (DataListItem dtlItem in datalist_Teacher_Edit.Items)
            {
                CheckBox chkCheck = (CheckBox)dtlItem.FindControl("chkCheck");
                if (chkCheck.Checked == true)
                {
                    Label lblRequest_EntryCode = (Label)dtlItem.FindControl("Request_EntryCode_TH");
                    Label lblTeachername = (Label)dtlItem.FindControl("lblTeachername");
                    Label lblUserCode = (Label)dtlItem.FindControl("lblUserCode");
                    Label lblItemCode = (Label)dtlItem.FindControl("lblItemCode");
                    Label lblInwardEntryCode = (Label)dtlItem.FindControl("lblInwardEntryCode");

                    Request_EntryCode = Request_EntryCode + lblRequest_EntryCode.Text + ",";
                    UserName = UserName + lblTeachername.Text + ",";
                    UserCode = UserCode + lblUserCode.Text + ",";
                    Item_Code = Item_Code + lblItemCode.Text + ",";
                    InwardEntry_Code = InwardEntry_Code + lblInwardEntryCode.Text + ",";
                }
            }
        }//End if User Type Teacher
        else if (lblUserTypeCode.Text == "UT004")//if User Type is Employee
        {
            Request_EntryCode = lblRequ_EntryCodeforEMP.Text;
            UserName = lblEmployeenmforEMP.Text;
            UserCode = lblemployeeCodeForEMP.Text;
            Item_Code = lblEmp_ItemCode.Text;
            InwardEntry_Code = lblEmp_InwardEntryCode.Text;
        }//End if User Type Employee

        if (lblUserTypeCode.Text != "")
        {
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string CreatedBy = cookie.Values["UserID"];
            DataSet ds = ProductController.Insert_Update_StockIssue_Header(lblPkey.Text, ddlLocationType.SelectedValue, "", lblUserTypeCode.Text, lblEditRequisitionNo.Text, Request_EntryCode, UserName, UserCode, Item_Code, InwardEntry_Code, CreatedBy, 2);
            if (ds != null)
            {
                if (ds.Tables[0].Rows[0]["Result"].ToString() == "1")//If 1 is Return then save record successfully
                {
                    ControlVisibility("Search");
                    Show_Error_Success_Box("S", "Record Updated Successfully...!");
                }
            }
        }
    }

    protected void btnAuthoriseClose_Click(object sender, EventArgs e)
    {
        ControlVisibility("Result");
    }


    protected void btnAuthorise_Click(object sender, EventArgs e)
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string CreatedBy = cookie.Values["UserID"];
        DataSet ds = ProductController.Insert_Update_StockIssue_Header(lblPkey.Text, ddlLocationType.SelectedValue, "", lblAuthoriseUserTypeCode.Text, lblAuthoriseRequisitionNo.Text, "", "", "", "", "", CreatedBy, 3);
        if (ds != null)
        {
            if (ds.Tables[0].Rows[0]["Result"].ToString() == "1")//If 1 is Return then  record Authorised successfully
            {
                ControlVisibility("Search");
                Show_Error_Success_Box("S", "Record Authorised Successfully...!");
            }
        }
    }
}