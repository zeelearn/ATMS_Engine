using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ShoppingCart.BL;
using System.IO;

public partial class Dispatch_Acknowledgment : System.Web.UI.Page
{

    #region PageLoad
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ControlVisibility("Search");
            FillDDL_TransferType();
            FillDDL_Division();
            FillDDL_Godown();
            FillDDL_Function();            
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            Label lblHeader_User_Code = default(Label);
            lblHeader_User_Code = (Label)Master.FindControl("lblHeader_User_Code");
            lblHeader_User_Code.Text = UserID;
        }
    }
    #endregion

    #region Methods

    private void BindDDL(DropDownList ddl, DataSet ds, string txtField, string valField)
    {
        ddl.DataSource = ds;
        ddl.DataTextField = txtField;
        ddl.DataValueField = valField;
        ddl.DataBind();
    }


    private void FillDDL_TransferType()
    {
        //Search DDL
        DataSet dsTransfer_Tp = ProductController.GetAllTransferType(1);
        BindDDL(ddlTransferFR_SR, dsTransfer_Tp, "Transfer_Location_Type_Name", "Transfer_Location_Type_ID");
        ddlTransferFR_SR.Items.Insert(0, "Select Transfer From");
        ddlTransferFR_SR.SelectedIndex = 0;

        BindDDL(ddlTransferTO_SR, dsTransfer_Tp, "Transfer_Location_Type_Name", "Transfer_Location_Type_ID");
        ddlTransferTO_SR.Items.Insert(0, "Select Transfer To");
        ddlTransferTO_SR.SelectedIndex = 0;

        //Add DDL
        BindDDL(ddlTransferFR_Add, dsTransfer_Tp, "Transfer_Location_Type_Name", "Transfer_Location_Type_ID");
        ddlTransferFR_Add.Items.Insert(0, "Select Transfer From");
        ddlTransferFR_Add.SelectedIndex = 0;

        BindDDL(ddlTransferTO_Add, dsTransfer_Tp, "Transfer_Location_Type_Name", "Transfer_Location_Type_ID");
        ddlTransferTO_Add.Items.Insert(0, "Select Transfer To");
        ddlTransferTO_Add.SelectedIndex = 0;

    }


    private void FillDDL_Godown()
    {

        DataSet dsGodown = ProductController.GetGodown_Function_Logistic_Assests_Type(1);

        BindDDL(ddlGodownFR_Add, dsGodown, "Godown_Name", "Godown_Id");
        ddlGodownFR_Add.Items.Insert(0, "Select");
        ddlGodownFR_Add.SelectedIndex = 0;

        BindDDL(ddlGodownTO_Add, dsGodown, "Godown_Name", "Godown_Id");
        ddlGodownTO_Add.Items.Insert(0, "Select");
        ddlGodownTO_Add.SelectedIndex = 0;


        BindDDL(ddlgodownTO_SR, dsGodown, "Godown_Name", "Godown_Id");
        ddlgodownTO_SR.Items.Insert(0, "Select");
        ddlgodownTO_SR.SelectedIndex = 0;


        BindDDL(ddlgodownFR_SR, dsGodown, "Godown_Name", "Godown_Id");
        ddlgodownFR_SR.Items.Insert(0, "Select");
        ddlgodownFR_SR.SelectedIndex = 0;


    }


    private void FillDDL_Function()
    {

        DataSet dsFunction = ProductController.GetGodown_Function_Logistic_Assests_Type(2);
        BindDDL(ddlFunctionFR_Add, dsFunction, "Function_Name", "Function_Id");
        ddlFunctionFR_Add.Items.Insert(0, "Select");
        ddlFunctionFR_Add.SelectedIndex = 0;

        BindDDL(ddlFunctionTO_Add, dsFunction, "Function_Name", "Function_Id");
        ddlFunctionTO_Add.Items.Insert(0, "Select");
        ddlFunctionTO_Add.SelectedIndex = 0;

        BindDDL(ddlFunctionTO_SR, dsFunction, "Function_Name", "Function_Id");
        ddlFunctionTO_SR.Items.Insert(0, "Select");
        ddlFunctionTO_SR.SelectedIndex = 0;


        BindDDL(ddlFunctionFR_SR, dsFunction, "Function_Name", "Function_Id");
        ddlFunctionFR_SR.Items.Insert(0, "Select");
        ddlFunctionFR_SR.SelectedIndex = 0;
    }

    private void Clear_TempChallan()
    {
        string ResultId;
        ResultId = ProductController.usp_ClearIncInward(13);
    }

    private void BindListBox(ListBox ddl, DataSet ds, string txtField, string valField)
    {
        ddl.DataSource = ds;
        ddl.DataTextField = txtField;
        ddl.DataValueField = valField;
        ddl.DataBind();
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


    private void ControlVisibility(string Mode)
    {
        if (Mode == "Search")
        {
            DivAddPanel.Visible = false;
            DivSearchPanel.Visible = true;
            
            
            DivResultPanel.Visible = false;
        }
        else if (Mode == "Result")
        {
            DivAddPanel.Visible = false;
            DivSearchPanel.Visible = false;
            
            DivResultPanel.Visible = true;
            lblPkey.Text = "";

        }
        else if (Mode == "Add")
        {
            DivAddPanel.Visible = true;
            DivSearchPanel.Visible = false;
            
            DivResultPanel.Visible = false;
            lblPkey.Text = "";
            
        }
        else if (Mode == "Edit")
        {
            DivAddPanel.Visible = false;
            DivSearchPanel.Visible = false;
            
            DivResultPanel.Visible = false;
        }
        else if (Mode == "Details")
        {
            DivAddPanel.Visible = false;
            DivSearchPanel.Visible = false;            
            DivResultPanel.Visible = false;
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


    /// <summary>
    /// Clear Add Panel 
    /// </summary>
    private void ClearAddPanel()
    {



        //From Content
        ddlTransferFR_Add.SelectedIndex = 0;
        ddlDivisionFR_Add.SelectedIndex = 0;
        ddlCenterFR_Add.Items.Clear();
        //To Content
        ddlTransferTO_Add.SelectedIndex = 0;
        ddlDivisionTO_Add.SelectedIndex = 0;

        ddlCenterTO_Add.Items.Clear();

        //

        txtChallanNo_Add.Text = "";

        //Visible False from Table
        tblFR_Godown_Add.Visible = false;
        tblFR_Function_Add.Visible = false;
        tblFR_Division_Add.Visible = false;
        tblFR_Center_Add.Visible = false;

        //Visible False TO Table
        tblTO_Godown_Add.Visible = false;
        tblTO_Function_Add.Visible = false;
        tblTO_Division_Add.Visible = false;
        tblTO_Center_Add.Visible = false;
        txtEmail_Add.Text = "";
        txtContactPerson_Add.Text = "";
        txtContact_Add.Text = "";
        txtChallanDate_Add.Text = DateTime.Now.ToString("dd-MMM-yyyy");

        dlQuestion.DataSource = null;
        dlQuestion.DataBind();

        lblTotal_Quantity.Text = "";
        lblTotal_Amount.Text = "";
        lblTotalItem.Text = "";
        lblPkey.Text = "";
        


    }



    private void ClearSearchPanel()
    {
        //From Content
        ddlTransferFR_SR.SelectedIndex = 0;
        ddlgodownFR_SR.Items.Clear();
        ddlDivisionFR_SR.SelectedIndex = 0;
        ddlFunctionFR_SR.Items.Clear();
        ddlCenterFR_SR.Items.Clear();

        //To Content
        ddlTransferTO_SR.SelectedIndex = 0;
        ddlgodownTO_SR.Items.Clear();
        ddlDivisionTO_SR.SelectedIndex = 0;
        ddlFunctionTO_SR.Items.Clear();
        ddlCenterTO_SR.Items.Clear();

        //
        date_range_SR.Value = "";
        txtChallan_SR.Text = "";

        //Visible False from Table
        tblFr_Godown.Visible = false;
        tblFr_Function.Visible = false;
        tblFr_Division.Visible = false;
        tblFr_Center.Visible = false;

        //Visible False TO Table
        tblTO_Godown.Visible = false;
        tblTO_Function.Visible = false;
        tblTO_Division.Visible = false;
        tblTO_Center.Visible = false;

    }

       

    #endregion

    #region Event's
    

    protected void BtnShowSearchPanel_Click(object sender, EventArgs e)
    {
        ControlVisibility("Search");
        Clear_Error_Success_Box();
    }

    protected void BtnCloseAdd_Click(object sender, EventArgs e)
    {
        Clear_Error_Success_Box();
        ControlVisibility("Search");
    }
       
    
    protected void BtnSearch_Click(object sender, EventArgs e)
    {


        Clear_Error_Success_Box();


        if (ddlTransferFR_SR.SelectedValue == "Select Transfer From")
        {
            Show_Error_Success_Box("E", "Select Transfer From");
            ddlTransferFR_SR.Focus();
            return;

        }

        else if (ddlTransferTO_SR.SelectedValue == "Select Transfer To")
        {
            Show_Error_Success_Box("E", "Select Transfer To");
            ddlTransferTO_SR.Focus();
            return;
        }

        else if (ddlTransferFR_SR.SelectedItem.Text == "Godown" && ddlgodownFR_SR.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "Select Transfer From Godown");
            ddlTransferFR_SR.Focus();
            return;
        }

        else if (ddlTransferFR_SR.SelectedItem.Text == "Function" && ddlFunctionFR_SR.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "Select Transfer From Function");
            ddlFunctionFR_SR.Focus();
            return;

        }
        else if (ddlTransferFR_SR.SelectedItem.Text == "Center" && ddlDivisionFR_SR.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "Select Transfer From Division");
            ddlDivisionFR_SR.Focus();
            return;
        }
        else if (ddlTransferFR_SR.SelectedItem.Text == "Center" && ddlCenterFR_SR.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "Select Transfer From Center");
            ddlCenterFR_SR.Focus();
            return;
        }
        else if (ddlDivisionFR_SR.SelectedIndex != 0 && ddlCenterFR_SR.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "Select Transfer From Center");
            ddlCenterFR_SR.Focus();
            return;
        }


         //---------------
        else if (ddlTransferTO_SR.SelectedItem.Text == "Godown" && ddlgodownTO_SR.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "Select Transfer To Godown");
            ddlTransferTO_SR.Focus();
            return;
        }

        else if (ddlTransferTO_SR.SelectedItem.Text == "Function" && ddlFunctionTO_SR.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "Select Transfer To Function");
            ddlTransferTO_SR.Focus();
            return;
        }
        else if (ddlTransferTO_SR.SelectedItem.Text == "Center" && ddlDivisionTO_SR.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "Select Transfer To Division");
            ddlTransferTO_SR.Focus();
            return;
        }
        else if (ddlTransferTO_SR.SelectedItem.Text == "Center" && ddlCenterTO_SR.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "Select Transfer To Center");
            ddlTransferTO_SR.Focus();
            return;
        }
        else if (ddlDivisionFR_Add.SelectedIndex != 0 && ddlCenterTO_SR.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "Select Transfer To Center");
            ddlCenterTO_SR.Focus();
            return;
        }




         //----------------------------



        else if (ddlgodownFR_SR.SelectedIndex != 0 && ddlgodownTO_SR.SelectedIndex != 0 && ddlgodownFR_SR.SelectedValue == ddlgodownTO_SR.SelectedValue)
        {
            Show_Error_Success_Box("E", "Godown Transfer From and To can't be same. ");
            return;
        }

        else if (ddlFunctionFR_SR.SelectedIndex != 0 && ddlFunctionTO_SR.SelectedIndex != 0 && ddlFunctionTO_SR.SelectedValue == ddlFunctionFR_SR.SelectedValue)
        {
            Show_Error_Success_Box("E", "Function Transfer From and To can't be same. ");
            return;
        }

        else if (ddlCenterFR_SR.SelectedIndex != -1 && ddlCenterTO_SR.SelectedIndex != -1 && ddlCenterFR_SR.SelectedIndex != 0 && ddlCenterTO_SR.SelectedIndex != 0 && ddlCenterFR_SR.SelectedValue == ddlCenterTO_SR.SelectedValue)
        {
            Show_Error_Success_Box("E", "Center Transfer From and To can't be same. ");
            return;
        }

        else if (date_range_SR.Value == "")
        {
            Show_Error_Success_Box("E", "Select date range ");
            return;
        }



        string FromDate, ToDate;
        string From_Location_Type_Code = "";
        string From_Location_Code = "";
        string To_Location_Type_Code = "";
        string To_Location_Code = "";
        string Challan_No = "";
        if (date_range_SR.Value == "")
        {
            FromDate = "";
            ToDate = "";
        }
        else
        {
            string DateRange = "";
            DateRange = date_range_SR.Value;

            FromDate = DateRange.Substring(0, 10);
            ToDate = (DateRange.Length > 9) ? DateRange.Substring(DateRange.Length - 10, 10) : DateRange;
        }

        From_Location_Type_Code = ddlTransferFR_SR.SelectedValue;
        To_Location_Type_Code = ddlTransferTO_SR.SelectedValue;

        if (ddlTransferFR_SR.SelectedItem.Text == "Godown")
        {
            From_Location_Code = ddlgodownFR_SR.SelectedValue;
        }
        else if (ddlTransferFR_SR.SelectedItem.Text == "Function")
        {
            From_Location_Code = ddlFunctionFR_SR.SelectedValue;
        }
        else if (ddlTransferFR_SR.SelectedItem.Text == "Center")
        {
            From_Location_Code = ddlCenterFR_SR.SelectedValue;
        }

        if (ddlTransferTO_SR.SelectedItem.Text == "Godown")
        {
            To_Location_Code = ddlgodownTO_SR.SelectedValue;
        }
        else if (ddlTransferTO_SR.SelectedItem.Text == "Function")
        {
            To_Location_Code = ddlFunctionTO_SR.SelectedValue;
        }
        else if (ddlTransferTO_SR.SelectedItem.Text == "Center")
        {
            To_Location_Code = ddlCenterTO_SR.SelectedValue;
        }

        Challan_No = txtChallan_SR.Text.Trim();

        DataSet ds = ProductController.Get_Dispatch_Item(9, Challan_No, From_Location_Type_Code, From_Location_Code, To_Location_Code, To_Location_Type_Code, FromDate, ToDate);

        ControlVisibility("Result");
        if (ds != null)
        {
            if (ds.Tables.Count != 0)
            {
                if (ds.Tables[0].Rows.Count != 0)
                {
                    dlGridDisplay.DataSource = ds;
                    dlGridDisplay.DataBind();

                    DataList1.DataSource = ds;
                    DataList1.DataBind();
                    BtnSaveAdd.Visible = true;
                }
                else
                {
                    dlGridDisplay.DataSource = null;
                    dlGridDisplay.DataBind();

                    DataList1.DataSource = null;
                    DataList1.DataBind();
                    BtnSaveAdd.Visible = false;
                }

            }
            else
            {
                dlGridDisplay.DataSource = null;
                dlGridDisplay.DataBind();

                DataList1.DataSource = null;
                DataList1.DataBind();
                BtnSaveAdd.Visible = false;

            }

        }
        else
        {
            dlGridDisplay.DataSource = ds;
            dlGridDisplay.DataBind();

            DataList1.DataSource = ds;
            DataList1.DataBind();
        }

        if (ds != null)
        {
            if (ds.Tables.Count != 0)
            {
                if (ds.Tables[0].Rows.Count != 0)
                {
                    lbltotalcount.Text = (ds.Tables[0].Rows.Count).ToString();
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

    protected void BtnClearSearch_Click(object sender, EventArgs e)
    {
        ClearSearchPanel();
    }

    public void AllChk_Selected(object sender, System.EventArgs e)
    {

        CheckBox s = sender as CheckBox;

        //Set checked status of hidden check box to items in grid
        foreach (DataListItem dtlItem in dlGridDisplay.Items)
        {
            CheckBox chkitemck = (CheckBox)dtlItem.FindControl("chkItem");

            chkitemck.Checked = s.Checked;
        }

    }
    #endregion

    
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

    protected void HLExport_Click(object sender, EventArgs e)
    {
        DataList1.Visible = true;

        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        string filenamexls1 = "Menu_" + DateTime.Now + ".xls";
        Response.AddHeader("Content-Disposition", "inline;filename=" + filenamexls1);
        HttpContext.Current.Response.Charset = "utf-8";
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");
        //sets font
        HttpContext.Current.Response.Write("<font style='font-size:10.0pt; font-family:Calibri;'>");
        HttpContext.Current.Response.Write("<BR><BR><BR>");
        HttpContext.Current.Response.Write("<Table border='1'  borderColor='#000000' cellSpacing='0' cellPadding='0' style='font-size:10.0pt; font-family:Calibri; text-align:center;'> <TR style='color: #fff; background: black;text-align:center;'><TD Colspan='9'>Menu</b></TD></TR>");
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

    protected void dlGridDisplay_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "comEdit")
        {
            lblPkey.Text = "";
            ControlVisibility("Add");
            
            ClearAddPanel();
            
            dlQuestion.DataSource = null;
            dlQuestion.DataBind();

            Clear_Error_Success_Box();

            lblPkey.Text = e.CommandArgument.ToString();
            DataSet ds = null;
            ds = ProductController.Get_Dispatch_ItemById(6, lblPkey.Text.Trim());

            if (ds.Tables[0].Rows.Count > 0)
            {
                txtChallanNo_Add.Text = ds.Tables[0].Rows[0]["Challan_No"].ToString();
                txtChallanDate_Add.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["Challan_Date"].ToString()).ToString("dd-MMM-yyyy");
                txtEmail_Add.Text = ds.Tables[0].Rows[0]["ContactPersonEmailId"].ToString();
                txtContactPerson_Add.Text = ds.Tables[0].Rows[0]["ContactPerson"].ToString();
                txtContact_Add.Text = ds.Tables[0].Rows[0]["ContactPersonNo"].ToString();                
                ddlTransferFR_Add.SelectedValue = ds.Tables[0].Rows[0]["From_Location_Type_Code"].ToString();
                ddlTransferTO_Add.SelectedValue = ds.Tables[0].Rows[0]["To_Location_Type_Code"].ToString();
               


                if (ddlTransferFR_Add.SelectedItem.ToString().Trim() == "Godown")
                {
                    tblFR_Godown_Add.Visible = true;
                    tblFR_Function_Add.Visible = false;
                    tblFR_Division_Add.Visible = false;
                    tblFR_Center_Add.Visible = false;
                    ddlGodownFR_Add.SelectedValue = ds.Tables[0].Rows[0]["From_Location_Code"].ToString();
                }
                else if (ddlTransferFR_Add.SelectedItem.ToString().Trim() == "Function")
                {
                    tblFR_Function_Add.Visible = true;
                    tblFR_Godown_Add.Visible = false;
                    tblFR_Division_Add.Visible = false;
                    tblFR_Center_Add.Visible = false;
                    ddlFunctionFR_Add.SelectedValue = ds.Tables[0].Rows[0]["From_Location_Code"].ToString();
                }
                else if (ddlTransferFR_Add.SelectedItem.ToString().Trim() == "Center")
                {
                    tblFR_Division_Add.Visible = true;
                    tblFR_Center_Add.Visible = true;
                    tblFR_Function_Add.Visible = false;
                    tblFR_Godown_Add.Visible = false;
                    ddlCenterFR_Add.SelectedValue = ds.Tables[0].Rows[0]["From_Location_Code"].ToString();
                }
                else if (ddlTransferFR_Add.SelectedIndex == 0 || ddlTransferFR_Add.SelectedIndex == -1)
                {
                    tblFR_Godown_Add.Visible = false;
                    tblFR_Function_Add.Visible = false;
                    tblFR_Division_Add.Visible = false;
                    tblFR_Center_Add.Visible = false;
                }


                if (ddlTransferTO_Add.SelectedItem.ToString().Trim() == "Godown")
                {
                    tblTO_Godown_Add.Visible = true;
                    tblTO_Function_Add.Visible = false;
                    tblTO_Division_Add.Visible = false;
                    tblTO_Center_Add.Visible = false;
                    ddlGodownTO_Add.SelectedValue = ds.Tables[0].Rows[0]["To_Location_Code"].ToString();
                }
                else if (ddlTransferTO_Add.SelectedItem.ToString().Trim() == "Function")
                {
                    tblTO_Function_Add.Visible = true;
                    tblTO_Godown_Add.Visible = false;
                    tblTO_Division_Add.Visible = false;
                    tblTO_Center_Add.Visible = false;
                    ddlFunctionTO_Add.SelectedValue = ds.Tables[0].Rows[0]["To_Location_Code"].ToString();
                }
                else if (ddlTransferTO_Add.SelectedItem.ToString().Trim() == "Center")
                {
                    tblTO_Division_Add.Visible = true;
                    tblTO_Center_Add.Visible = true;
                    tblTO_Function_Add.Visible = false;
                    tblTO_Godown_Add.Visible = false;
                    ddlCenterTO_Add.SelectedValue = ds.Tables[0].Rows[0]["To_Location_Code"].ToString();
                }
                else if (ddlTransferTO_Add.SelectedIndex == 0 || ddlTransferTO_SR.SelectedIndex == -1)
                {
                    tblTO_Godown_Add.Visible = false;
                    tblTO_Function_Add.Visible = false;
                    tblTO_Division_Add.Visible = false;
                    tblTO_Center_Add.Visible = false;
                }

               
                if (ds.Tables[2].Rows.Count > 0)
                {
                    lblTotal_Quantity.Text = ds.Tables[2].Rows[0]["TotalQuantity"].ToString();
                    lblTotal_Amount.Text = ds.Tables[2].Rows[0]["Purchase_Amount"].ToString();
                    lblTotalItem.Text = ds.Tables[2].Rows[0]["TotalItem"].ToString();
                }

                if (ds.Tables[1].Rows.Count > 0)
                {
                    dlQuestion.DataSource = ds.Tables[1];
                    dlQuestion.DataBind();
                }
                else
                {
                    dlQuestion.DataSource = null;
                    dlQuestion.DataBind();

                }
            }
        }
    }

    protected void dlQuestion_ItemCommand(object source, DataListCommandEventArgs e)
    {


        if (e.CommandName == "ItemRemove")
        {
            string pkeyMaterialCode_DT = "";
            DataTable dtCorrectEntry = new DataTable();
            DataRow NewRow = null;

            var _with1 = dtCorrectEntry;
            _with1.Columns.Add("Dispatch_Code");
            _with1.Columns.Add("DispatchEntry_Code");
            _with1.Columns.Add("Item_Code");
            _with1.Columns.Add("Item_Name");
            _with1.Columns.Add("Purchase_Amount");
            _with1.Columns.Add("Purchase_Rate");
            _with1.Columns.Add("Barcode");
            _with1.Columns.Add("Dispatch_Qty");
            _with1.Columns.Add("Asset_No");
            _with1.Columns.Add("Pkey");

            int Total_Item_Count = 0;
            int Total_Quantity = 0;
            decimal Total_Amount = 0;

            foreach (DataListItem item in dlQuestion.Items)
            {
                if (item.ItemType == ListItemType.Item | item.ItemType == ListItemType.AlternatingItem)
                {
                    Label lblDispatch_Code = (Label)item.FindControl("lblDispatch_Code");
                    Label lblDispatchEntry_Code = (Label)item.FindControl("lblDispatchEntry_Code");
                    Label lblItem_Code_DT = (Label)item.FindControl("lblItem_Code_DT");
                    Label lblItemName_DT = (Label)item.FindControl("lblItemName_DT");
                    Label lblBarcode_DT = (Label)item.FindControl("lblBarcode_DT");
                    Label lblAssetNo_DT = (Label)item.FindControl("lblAssetNo_DT");
                    Label lblQty_DT = (Label)item.FindControl("lblQty_DT");
                    Label lblUnitPrice_DT = (Label)item.FindControl("lblUnitPrice_DT");
                    Label lblAmount_DT = (Label)item.FindControl("lblAmount_DT");
                    Label lblPkey_Code = (Label)item.FindControl("lblPkey_Code");

                    NewRow = dtCorrectEntry.NewRow();
                    NewRow["Dispatch_Code"] = lblDispatch_Code.Text.Trim();
                    NewRow["DispatchEntry_Code"] = lblDispatchEntry_Code.Text.Trim();
                    NewRow["Item_Code"] = lblItem_Code_DT.Text.Trim();
                    NewRow["Item_Name"] = lblItemName_DT.Text.Trim();
                    NewRow["Barcode"] = lblBarcode_DT.Text.Trim();
                    NewRow["Asset_No"] = lblAssetNo_DT.Text.Trim();
                    NewRow["Dispatch_Qty"] = lblQty_DT.Text.Trim();
                    NewRow["Purchase_Rate"] = lblUnitPrice_DT.Text.Trim();
                    NewRow["Purchase_Amount"] = lblAmount_DT.Text.Trim();
                    NewRow["Pkey"] = lblPkey_Code.Text.Trim();

                    dtCorrectEntry.Rows.Add(NewRow);

                }
            }

            DataRow[] rows;
            rows = dtCorrectEntry.Select("Pkey = '" + e.CommandArgument.ToString() + "'");
            foreach (DataRow row in rows)
                dtCorrectEntry.Rows.Remove(row);

            int count = 0;
            foreach (DataRow dr in dtCorrectEntry.Rows) // search whole table
            {
                count++;
                dr["Pkey"] = count.ToString(); //change the name                  
                Total_Quantity = Total_Quantity + Convert.ToInt32(dr["Dispatch_Qty"]);
                Total_Amount = Total_Amount + Convert.ToDecimal(dr["Purchase_Amount"]);

            }
            lblTotalItem.Text = count.ToString();
            lblTotal_Quantity.Text = Total_Quantity.ToString();
            lblTotal_Amount.Text = Total_Amount.ToString();

            dlQuestion.DataSource = dtCorrectEntry;
            dlQuestion.DataBind();
        }




        //if (e.CommandName == "ItemRemove")
        //{
        //    ControlVisibility("Details");
        //    lblInwardEbtryCode_BR.Text = e.CommandArgument.ToString();
        //    int Qty = 0;

        //    DataSet ds = ProductController.Get_FillDetails_InwardItems(9, lblInwardEbtryCode_BR.Text.Trim());
        //    //Get_FillDetails_InwardItems
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        txtItemName_BR.Text = ds.Tables[0].Rows[0]["Item_Name"].ToString();
        //        Qty = Convert.ToInt32(ds.Tables[0].Rows[0]["Inward_Qty"].ToString());
        //        lblInwardCode_BR.Text = ds.Tables[0].Rows[0]["Inward_Code"].ToString();
        //    }



        //    DataTable dtEmptEntry = new DataTable();
        //    DataRow NewRow = null;

        //    var _with1 = dtEmptEntry;
        //    _with1.Columns.Add("lblSRNo");
        //    _with1.Columns.Add("txtItemSerialNo");
        //    _with1.Columns.Add("txtItemBarcodeNo");


        //    for (int i = 0; i < Qty; i++)
        //    {
        //        int rownum = i + 1;

        //        NewRow = dtEmptEntry.NewRow();
        //        NewRow["lblSRNo"] = rownum.ToString();
        //        NewRow["txtItemSerialNo"] = "";
        //        NewRow["txtItemBarcodeNo"] = "";

        //        dtEmptEntry.Rows.Add(NewRow);

        //    }

        //    DataList2.DataSource = dtEmptEntry;
        //    DataList2.DataBind();

        //    DataSet DSCHK = ProductController.Get_FillDetails_InwardItemsDetails(12, lblInwardCode_BR.Text.Trim(), lblInwardEbtryCode_BR.Text.Trim());

        //    foreach (DataListItem item in DataList2.Items)
        //    {
        //        if (item.ItemType == ListItemType.Item | item.ItemType == ListItemType.AlternatingItem)
        //        {
        //            Label lblSRNo = (Label)item.FindControl("lblSRNo");
        //            TextBox txtItemSerialNo = (TextBox)item.FindControl("txtItemSerialNo");
        //            TextBox txtItemBarcodeNo = (TextBox)item.FindControl("txtItemBarcodeNo");
        //            string srno="", serial="", barcode="";
        //            for (int k = 0; k < DSCHK.Tables[0].Rows.Count; k++)
        //            {
        //                srno = DSCHK.Tables[0].Rows[k]["lblSRNo"].ToString();
        //                serial = DSCHK.Tables[0].Rows[k]["txtItemSerialNo"].ToString();
        //                barcode = DSCHK.Tables[0].Rows[k]["txtItemBarcodeNo"].ToString();

        //                if (lblSRNo.Text.Trim() == srno)
        //                {
        //                    txtItemSerialNo.Text = serial;
        //                    txtItemBarcodeNo.Text = barcode;
        //                }
        //            }

        //        }
        //    }



        //}
    }

    protected void ddlTransferFR_SR_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTransferFR_SR.SelectedItem.ToString().Trim() == "Godown")
        {
            tblFr_Godown.Visible = true;
            tblFr_Function.Visible = false;
            tblFr_Division.Visible = false;
            tblFr_Center.Visible = false;
        }
        else if (ddlTransferFR_SR.SelectedItem.ToString().Trim() == "Function")
        {
            tblFr_Function.Visible = true;
            tblFr_Godown.Visible = false;
            tblFr_Division.Visible = false;
            tblFr_Center.Visible = false;
        }
        else if (ddlTransferFR_SR.SelectedItem.ToString().Trim() == "Center")
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
        else if (ddlTransferFR_SR.SelectedIndex == 0 || ddlTransferFR_SR.SelectedIndex == -1)
        {
            tblFr_Godown.Visible = false;
            tblFr_Function.Visible = false;
            tblFr_Division.Visible = false;
            tblFr_Center.Visible = false;
        }
    }

    protected void ddlTransferTO_SR_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTransferTO_SR.SelectedItem.ToString().Trim() == "Godown")
        {
            tblTO_Godown.Visible = true;
            tblTO_Function.Visible = false;
            tblTO_Division.Visible = false;
            tblTO_Center.Visible = false;
        }
        else if (ddlTransferTO_SR.SelectedItem.ToString().Trim() == "Function")
        {
            tblTO_Function.Visible = true;
            tblTO_Godown.Visible = false;
            tblTO_Division.Visible = false;
            tblTO_Center.Visible = false;
        }
        else if (ddlTransferTO_SR.SelectedItem.ToString().Trim() == "Center")
        {
            tblTO_Division.Visible = true;
            tblTO_Center.Visible = true;
            tblTO_Function.Visible = false;
            tblTO_Godown.Visible = false;
        }
        else if (ddlTransferTO_SR.SelectedIndex == 0 || ddlTransferTO_SR.SelectedIndex == -1)
        {
            tblTO_Godown.Visible = false;
            tblTO_Function.Visible = false;
            tblTO_Division.Visible = false;
            tblTO_Center.Visible = false;
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

        BindDDL(ddlDivisionTO_SR, dsDivision, "Division_Name", "Division_Code");
        ddlDivisionTO_SR.Items.Insert(0, "Select");
        ddlDivisionTO_SR.SelectedIndex = 0;

        //Add DDL
        BindDDL(ddlDivisionFR_Add, dsDivision, "Division_Name", "Division_Code");
        ddlDivisionFR_Add.Items.Insert(0, "Select");
        ddlDivisionFR_Add.SelectedIndex = 0;

        BindDDL(ddlDivisionTO_Add, dsDivision, "Division_Name", "Division_Code");
        ddlDivisionTO_Add.Items.Insert(0, "Select");
        ddlDivisionTO_Add.SelectedIndex = 0;

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

    private void FillDDL_TOSearch_Centre()
    {
        string Company_Code = "MT";
        string DBname = "CDB";

        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];

        string Div_Code = null;
        Div_Code = ddlDivisionTO_SR.SelectedValue;

        DataSet dsCentre = ProductController.GetAllActiveUser_Company_Division_Zone_Center(UserID, Company_Code, Div_Code, "", "5", DBname);

        BindDDL(ddlCenterTO_SR, dsCentre, "Center_Name", "Center_Code");
        ddlCenterTO_SR.Items.Insert(0, "Select");
        ddlCenterTO_SR.SelectedIndex = 0;
    }

    protected void ddlDivisionTO_SR_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlCenterTO_SR.Items.Clear();
        FillDDL_TOSearch_Centre();
    }

    protected void ddlTransferFR_Add_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTransferFR_Add.SelectedItem.ToString().Trim() == "Godown")
        {
            tblFR_Godown_Add.Visible = true;
            tblFR_Function_Add.Visible = false;
            tblFR_Division_Add.Visible = false;
            tblFR_Center_Add.Visible = false;
        }
        else if (ddlTransferFR_Add.SelectedItem.ToString().Trim() == "Function")
        {
            tblFR_Function_Add.Visible = true;
            tblFR_Godown_Add.Visible = false;
            tblFR_Division_Add.Visible = false;
            tblFR_Center_Add.Visible = false;
        }
        else if (ddlTransferFR_Add.SelectedItem.ToString().Trim() == "Center")
        {
            tblFR_Division_Add.Visible = true;
            tblFR_Center_Add.Visible = true;
            tblFR_Function_Add.Visible = false;
            tblFR_Godown_Add.Visible = false;
        }
        else if (ddlTransferFR_Add.SelectedIndex == 0 || ddlTransferFR_Add.SelectedIndex == -1)
        {
            tblFR_Godown_Add.Visible = false;
            tblFR_Function_Add.Visible = false;
            tblFR_Division_Add.Visible = false;
            tblFR_Center_Add.Visible = false;
        }
    }

    protected void ddlTransferTO_Add_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTransferTO_Add.SelectedItem.ToString().Trim() == "Godown")
        {
            tblTO_Godown_Add.Visible = true;
            tblTO_Function_Add.Visible = false;
            tblTO_Division_Add.Visible = false;
            tblTO_Center_Add.Visible = false;
        }
        else if (ddlTransferTO_Add.SelectedItem.ToString().Trim() == "Function")
        {
            tblTO_Function_Add.Visible = true;
            tblTO_Godown_Add.Visible = false;
            tblTO_Division_Add.Visible = false;
            tblTO_Center_Add.Visible = false;
        }
        else if (ddlTransferTO_Add.SelectedItem.ToString().Trim() == "Center")
        {
            tblTO_Division_Add.Visible = true;
            tblTO_Center_Add.Visible = true;
            tblTO_Function_Add.Visible = false;
            tblTO_Godown_Add.Visible = false;
        }
        else if (ddlTransferTO_Add.SelectedIndex == 0 || ddlTransferTO_SR.SelectedIndex == -1)
        {
            tblTO_Godown_Add.Visible = false;
            tblTO_Function_Add.Visible = false;
            tblTO_Division_Add.Visible = false;
            tblTO_Center_Add.Visible = false;
        }
    }

    protected void ddlDivisionFR_Add_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlCenterFR_Add.Items.Clear();
        FillDDL_FRAdd_Centre();

    }

    protected void ddlDivisionTO_Add_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlCenterTO_Add.Items.Clear();
        FillDDL_TOAdd_Centre();
    }
      

    private void FillDDL_FRAdd_Centre()
    {
        string Company_Code = "MT";
        string DBname = "CDB";

        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];

        string Div_Code = null;
        Div_Code = ddlDivisionFR_Add.SelectedValue;

        DataSet dsCentre = ProductController.GetAllActiveUser_Company_Division_Zone_Center(UserID, Company_Code, Div_Code, "", "5", DBname);

        BindDDL(ddlCenterFR_Add, dsCentre, "Center_Name", "Center_Code");
        ddlCenterFR_Add.Items.Insert(0, "Select");
        ddlCenterFR_Add.SelectedIndex = 0;
    }

    private void FillDDL_TOAdd_Centre()
    {
        string Company_Code = "MT";
        string DBname = "CDB";

        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];

        string Div_Code = null;
        Div_Code = ddlDivisionTO_Add.SelectedValue;

        DataSet dsCentre = ProductController.GetAllActiveUser_Company_Division_Zone_Center(UserID, Company_Code, Div_Code, "", "5", DBname);

        BindDDL(ddlCenterTO_Add, dsCentre, "Center_Name", "Center_Code");
        ddlCenterTO_Add.Items.Insert(0, "Select");
        ddlCenterTO_Add.SelectedIndex = 0;
    }
    
    protected void BtnSaveAdd_Click(object sender, EventArgs e)
    {

        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];

        foreach (DataListItem item in dlGridDisplay.Items)
        {
            Label lblDispatch_Code = (Label)item.FindControl("lblDispatch_Code");
            Label lblDispatchEntry_Code = (Label)item.FindControl("lblDispatchEntry_Code");
            Label lblItemCode_SR = (Label)item.FindControl("lblItemCode_SR");
            Label lblItemEANNo_SR = (Label)item.FindControl("lblItemEANNo_SR");
            Label lblItemAssetNo_SR = (Label)item.FindControl("lblItemAssetNo_SR");

            CheckBox chkItem = (CheckBox)item.FindControl("chkItem");

            if (chkItem.Checked)
            {
                ProductController.UpdateAcknowledgment(8, lblDispatch_Code.Text, UserID, lblDispatchEntry_Code.Text, lblItemCode_SR.Text.Trim(), lblItemEANNo_SR.Text.Trim(), lblItemAssetNo_SR.Text .Trim ());
            }


        }

        ControlVisibility("Search");
        Show_Error_Success_Box("S", "Acknowledgment done successfully");


    }
}