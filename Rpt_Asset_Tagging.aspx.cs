
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ShoppingCart.BL;
using System.IO;
using System.Web.UI.HtmlControls;


public partial class Rpt_Asset_Tagging : System.Web.UI.Page
{
     #region PageLoad
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                ControlVisibility("Search");

                FillDDL_Division();
                FillDDL_TransferType();
                FillDDL_Godown();
                FillDDL_Function();
                //FillDDL_Asset();
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
    }
    #endregion

    #region Methods


    private void FillDDL_FRSearch_Centre()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];

        //string Div_Code = null;
        //Div_Code = ddlDivisionFR_SR.SelectedValue;

        //DataSet dsCentre = ProductController.GetAllActiveUser_Company_Division_Zone_Center(UserID, Company_Code, Div_Code, "", "5", DBname);

        //BindDDL(ddlCenterFR_SR, dsCentre, "Center_Name", "Center_Code");
        //ddlCenterFR_SR.Items.Insert(0, "Select");
        //ddlCenterFR_SR.SelectedIndex = 0;
    }

    private void FillDDL_FRSearch_Centre_Search()
    {
        string Company_Code = "MT";
        string DBname = "CDB";

        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];

        string Div_Code = null;
        Div_Code = ddlDivisionFR_SRSearch.SelectedValue;

        DataSet dsCentre = ProductController.GetAllActiveUser_Company_Division_Zone_Center(UserID, Company_Code, Div_Code, "", "5", DBname);

        BindDDL(ddlCenterFR_SRSearch, dsCentre, "Center_Name", "Center_Code");
        ddlCenterFR_SRSearch.Items.Insert(0, "Select");
        ddlCenterFR_SRSearch.Items.Insert(1, "All");
        //ddlCenterFR_SRSearch.SelectedIndex = 0;

    }

    private void FillDDL_FRSearch_CentreAuthorise()
    {


        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];

    }

    private void FillDDL_TransferType()
    {
        //Search DDL
        DataSet dsTransfer_Tp = ProductController.GetAllTransferType(1);
        BindDDL(ddlLocationType, dsTransfer_Tp, "Transfer_Location_Type_Name", "Transfer_Location_Type_ID");
        ddlLocationType.Items.Insert(0, "Select Location");
        ddlLocationType.Items.Insert(1, "All");
        ddlLocationType.SelectedIndex = 0;

        //BindDDL(ddlTransferFR_SR, dsTransfer_Tp, "Transfer_Location_Type_Name", "Transfer_Location_Type_ID");
        //ddlTransferFR_SR.Items.Insert(0, "Select Location");
        //ddlTransferFR_SR.SelectedIndex = 0;

        //BindDDL(ddlTransferFR_SRAuthorise, dsTransfer_Tp, "Transfer_Location_Type_Name", "Transfer_Location_Type_ID");
        //ddlTransferFR_SRAuthorise.Items.Insert(0, "Select Location");
        //ddlTransferFR_SRAuthorise.SelectedIndex = 0;
        
    }


    private void FillDDL_Godown()
    {
       // ddlgodownFR_SR.Items.Clear();
        ddlgodownFR_SRSearch.Items.Clear();
        DataSet dsTransfer_Tp = ProductController.GetGodown_Function_Logistic_Assests(1, ddlgodownFR_SRSearch.Text);
        BindDDL(ddlgodownFR_SRSearch, dsTransfer_Tp, "Godown_Name", "Godown_Id");
        ddlgodownFR_SRSearch.Items.Insert(0, "Select Godown");
       // ddlgodownFR_SRSearch.SelectedIndex = 0;
        ddlgodownFR_SRSearch.Items.Insert(1, "All");
        

        //BindDDL(ddlgodownFR_SR, dsTransfer_Tp, "Godown_Name", "Godown_Id");
        //ddlgodownFR_SR.Items.Insert(0, "Select Godown");
        //ddlgodownFR_SR.SelectedIndex = 0;

        //BindDDL(ddlgodownFR_SRAuthorise, dsTransfer_Tp, "Godown_Name", "Godown_Id");
        //ddlgodownFR_SRAuthorise.Items.Insert(0, "Select Godown");
        //ddlgodownFR_SRAuthorise.SelectedIndex = 0;
        
    }



    //private void FillDDL_Asset()
    //{
    //    // ddlgodownFR_SR.Items.Clear();
    //    ddlasset.Items.Clear();
    //   DataSet dsTransfer_Tp = ProductController.Get_Assests(12);
    //    BindListBox(ddlasset, dsTransfer_Tp, "ASSET_NO","");
    //    //ddlasset.Items.Insert(0, "Select Godown");
      

    //}





    private void FillDDL_Function()
    {
        //ddlFunctionFR_SR.Items.Clear();
        ddlFunctionFR_SRSearch.Items.Clear();
        DataSet dsTransfer_Tp = ProductController.GetGodown_Function_Logistic_Assests_Type(2);
        BindDDL(ddlFunctionFR_SRSearch, dsTransfer_Tp, "Function_Name", "Function_Id");
        ddlFunctionFR_SRSearch.Items.Insert(0, "Select Function");
        ddlFunctionFR_SRSearch.Items.Insert(1, "All");
        ddlFunctionFR_SRSearch.SelectedIndex = 0;

        //BindDDL(ddlFunctionFR_SR, dsTransfer_Tp, "Function_Name", "Function_Id");
        //ddlFunctionFR_SR.Items.Insert(0, "Select Function");
        //ddlFunctionFR_SR.SelectedIndex = 0;

        //BindDDL(ddlFunctionFR_SRAuthorise, dsTransfer_Tp, "Function_Name", "Function_Id");
        //ddlFunctionFR_SRAuthorise.Items.Insert(0, "Select Function");
        //ddlFunctionFR_SRAuthorise.SelectedIndex = 0;
    }

    //private void FillDDL_Logistic()
    //{
    //    ddlLogisticType_Add.Items.Clear();
    //    DataSet dsTransfer_Tp = ProductController.GetGodown_Function_Logistic_Assests_Type(5);
    //    BindDDL(ddlLogisticType_Add, dsTransfer_Tp, "Logistic_Type_Name", "Logistic_Type_Id");
    //    ddlLogisticType_Add.Items.Insert(0, "Select Logistic");
    //    ddlLogisticType_Add.SelectedIndex = 0;
    //}

    private void FillDDL_Division()
    {
        string Company_Code = "MT";
        string DBname = "CDB";

        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];

        //Search DDL
        DataSet dsDivision = ProductController.GetAllActiveUser_Company_Division_Zone_Center(UserID, Company_Code, "", "", "2", DBname);
        BindDDL(ddlDivisionFR_SRSearch, dsDivision, "Division_Name", "Division_Code");
        ddlDivisionFR_SRSearch.Items.Insert(0, "Select");
        ddlDivisionFR_SRSearch.Items.Insert(1, "All");

        //ddlDivisionFR_SRSearch.SelectedIndex = 0;

    }


    private void Page_Validation()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];

        string Path = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
        System.IO.FileInfo Info = new System.IO.FileInfo(Path);
        string pageName = Info.Name;
    }

    private void BindDDL(DropDownList ddl, DataSet ds, string txtField, string valField)
    {
        ddl.DataSource = ds;
        ddl.DataTextField = txtField;
        ddl.DataValueField = valField;
        ddl.DataBind();
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

            DivSearchPanel.Visible = true;
            DivResultPanel.Visible = false;


        }
        else if (Mode == "Result")
        {

            DivSearchPanel.Visible = false;
            DivResultPanel.Visible = true;

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


    /// <summary>
    /// Clear Add Panel 
    /// </summary>
   


    private void ClearSearchPanel()
    {
        //From Content
        ddlLocationType.SelectedIndex = 0;
        ddlgodownFR_SRSearch.SelectedIndex = 0;
        ddlDivisionFR_SRSearch.SelectedIndex = 0;
        ddlFunctionFR_SRSearch.SelectedIndex = 0;
        ddlCenterFR_SRSearch.Items.Clear();
       // ddlasset.Text = "";

        //To Content

        tblFr_GodownSearch.Visible = false;
        tblFr_FunctionSearch.Visible = false;
        tblFr_DivisionSearch.Visible = false;
        tblFr_CenterSearch.Visible = false;
    }


    private void FillGrid()
    {
        //string asseet = "";
        try
        {
            Clear_Error_Success_Box();

            string Transfer_LocationCode = "", Div_Code = "" ;
            if (ddlLocationType.SelectedItem.ToString() == "Godown")
            {
                if (ddlgodownFR_SRSearch.SelectedIndex == 0)
                {
                    Transfer_LocationCode = "%%";
                }
                else
                {
                    Transfer_LocationCode = ddlgodownFR_SRSearch.SelectedValue.ToString().Trim();
                    lblLocationResult.Text = ddlgodownFR_SRSearch.SelectedItem.ToString();
                }

                lblLocationType_Result.Text = "Godown";
            }
            else if (ddlLocationType.SelectedItem.ToString() == "Function")
            {
                if (ddlFunctionFR_SRSearch.SelectedIndex == 0)
                {
                    Transfer_LocationCode = "%%";
                }
                else
                {
                    Transfer_LocationCode = ddlFunctionFR_SRSearch.SelectedValue.ToString().Trim();
                    lblLocationResult.Text = ddlFunctionFR_SRSearch.SelectedItem.ToString();
                }

                lblLocationType_Result.Text = "Function";
            }
            else if (ddlLocationType.SelectedItem.ToString() == "Center")
            {
                if (ddlDivisionFR_SRSearch.SelectedIndex == 0)
                {
                    Transfer_LocationCode = "%%";
                }
                else if (ddlCenterFR_SRSearch.SelectedIndex == 0)
                {
                    Transfer_LocationCode = "%%";
                }
                else
                {
                    Transfer_LocationCode = ddlCenterFR_SRSearch.SelectedValue.ToString().Trim();
                    lblLocationResult.Text = ddlCenterFR_SRSearch.SelectedItem.ToString();
                    Div_Code = ddlDivisionFR_SRSearch.SelectedValue;
                }

                lblLocationType_Result.Text = ddlDivisionFR_SRSearch.SelectedItem.ToString().Trim();
            }


          

            string CreatedBy = null;
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            CreatedBy = cookie.Values["UserID"];
            DataSet dsItems = null;
            try
            {

                dsItems = Report.Get_Report_OpeningStock(2, "", ddlLocationType.SelectedValue, Div_Code, Transfer_LocationCode, "", CreatedBy);
                if (dsItems.Tables[0].Rows.Count > 0)
                {
                    dlGridDisplay.DataSource = dsItems;
                    dlGridDisplay.DataBind();
                    ControlVisibility("Result");

                   // Response.ClearContent();
                   // Response.Buffer = true;
                   // Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "Asset_Report.xls"));
                   // Response.ContentType = "application/ms-excel";
                   // DataTable dt = dsItems.Tables[0];
                   // string str = string.Empty;
                   // int count = 0;
                   // foreach (DataColumn dtcol in dt.Columns)
                   // {
                   //     if (dtcol.ColumnName == "StudentName")
                   //     {

                   //         Response.Write("Asset Report");
                   //     }
                   //     else
                   //     {
                   //         string str11 = "\t";
                   //         Response.Write(str11);
                   //     }

                   // }
                   // string str1 = "\n";
                   // Response.Write(str1);
                   // foreach (DataColumn dtcol in dt.Columns)
                   // {
                   //     Response.Write(str + dtcol.ColumnName);
                   //     str = "\t";
                   // }
                   // Response.Write("\n");
                   // foreach (DataRow dr in dt.Rows)
                   // {
                   //     str = "";
                   //     for (int j = 0; j < dt.Columns.Count; j++)
                   //     {
                   //         Response.Write(str + Convert.ToString(dr[j]).Trim());
                   //         str = "\t";
                   //     }
                   //     Response.Write("\n");
                   // }
                   //Response.End();
                    

                   }
                else
                {
                    Msg_Error.Visible = true;
                    Msg_Success.Visible = false;
                    lblSuccess.Text = "";
                    lblerror.Text = "Records not found...!";
                    UpdatePanelMsgBox.Update();
                }
               
            }
            catch (Exception ex)
            {
                Msg_Error.Visible = true;
                Msg_Success.Visible = false;
                lblSuccess.Text = "";
                lblerror.Text = ex.ToString();
                UpdatePanelMsgBox.Update();
            }
            if (dsItems != null)
                   
            {
                
                if (dsItems.Tables.Count != 0)
                {
                    if (dsItems.Tables[0].Rows.Count != 0)
                    {
                        lbltotalcount.Text = (dsItems.Tables[0].Rows.Count).ToString();
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

            Msg_Error.Visible = true;
            Msg_Success.Visible = false;
            lblerror.Text = ex.ToString();
            UpdatePanelMsgBox.Update();
            return;
        }
    }



    
    #endregion

    #region Event's

    protected void ddlDivisionFR_SRSearch_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlCenterFR_SRSearch.Items.Clear();
        FillDDL_FRSearch_Centre_Search();
    }

    protected void ddlLocationType_SelectedIndexChanged(object sender, EventArgs e)
    {
        


        if (ddlLocationType.SelectedItem.ToString().Trim() == "Godown")
        {
            //Txtmat.Text = "";
            tblFr_GodownSearch.Visible = true;
            tblFr_FunctionSearch.Visible = false;
            tblFr_DivisionSearch.Visible = false;
            tblFr_CenterSearch.Visible = false;
            //Txtmaterial.Visible = false;
            
        }
        if (ddlLocationType.SelectedItem.ToString().Trim() == "All")
        {
            tblFr_GodownSearch.Visible = false;
            tblFr_FunctionSearch.Visible = false;
            tblFr_DivisionSearch.Visible = false;
            tblFr_CenterSearch.Visible = false;
            //Txtmaterial.Visible = true;
            
        }
        else if (ddlLocationType.SelectedItem.ToString().Trim() == "Function")
        {
            //Txtmat.Text = "";
            tblFr_FunctionSearch.Visible = true;
            tblFr_GodownSearch.Visible = false;
            tblFr_DivisionSearch.Visible = false;
            tblFr_CenterSearch.Visible = false;
            //ddlasset.Visible = false;
            //Txtmaterial.Visible = false;
        }
        else if (ddlLocationType.SelectedItem.ToString().Trim() == "Center")
        {

            //Txtmat.Text = ""; 
            tblFr_DivisionSearch.Visible = true;
            tblFr_CenterSearch.Visible = true;
            tblFr_FunctionSearch.Visible = false;
            tblFr_GodownSearch.Visible = false;
            //Txtmaterial.Visible = false;

            //Fill Division
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];

        }
        else if (ddlLocationType.SelectedIndex == 0 || ddlLocationType.SelectedIndex == -1)
        {
            tblFr_GodownSearch.Visible = false;
            tblFr_FunctionSearch.Visible = false;
            tblFr_DivisionSearch.Visible = false;
            tblFr_CenterSearch.Visible = false;
            //Txtmaterial.Visible = true;

        }
    }


    protected void BtnShowSearchPanel_Click(object sender, EventArgs e)
    {
        ControlVisibility("Search");
        Clear_Error_Success_Box();
    }

    protected void BtnCloseAdd_Click(object sender, EventArgs e)
    {
        ControlVisibility("Search");
        Clear_Error_Success_Box();
    }


   

    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            Clear_Error_Success_Box();

            string FromDate, ToDate, Supplier, Location;
            

            if (ddlLocationType.SelectedIndex == 0)
            {
                Show_Error_Success_Box("E", "Select Location Type");
                ddlLocationType.Focus();
                return;
            }

            if (ddlLocationType.SelectedItem.ToString() == "Godown")
            {
                if (ddlgodownFR_SRSearch.SelectedIndex == 0)
                {
                    //ddlgodownFR_SRSearch = "%%";
                    Show_Error_Success_Box("E", "Select Godown");
                    ddlgodownFR_SRSearch.Focus();
                    return;
                }
                else
                    Location = ddlgodownFR_SRSearch.SelectedItem.ToString();

            }
            else if (ddlLocationType.SelectedItem.ToString() == "Function")
            {
                if (ddlFunctionFR_SRSearch.SelectedIndex == 0)
                {
                    //Transfer_LocationCode = "%%";
                    Show_Error_Success_Box("E", "Select Function");
                    ddlFunctionFR_SRSearch.Focus();
                    return;
                }
                else
                    Location = ddlFunctionFR_SRSearch.SelectedItem.ToString();
            }
            else if (ddlLocationType.SelectedItem.ToString() == "Center")
            {
                if (ddlDivisionFR_SRSearch.SelectedIndex == 0)
                {
                    Show_Error_Success_Box("E", "Select Division");
                    ddlDivisionFR_SRSearch.Focus();
                    return;
                }
                else if (ddlCenterFR_SRSearch.SelectedIndex == 0)
                {
                    Show_Error_Success_Box("E", "Select Center");
                    ddlCenterFR_SRSearch.Focus();
                    return;
                }
                else
                    Location = ddlCenterFR_SRSearch.SelectedItem.ToString();
            }
            FillGrid();
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

    protected void BtnClearSearch_Click(object sender, EventArgs e)
    {
        ClearSearchPanel();
        Clear_Error_Success_Box();
    }



    public void ExportToExcel(DataSet ds)
    {
        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "Payment_Details.xls"));
        Response.ContentType = "application/ms-excel";
        DataTable dt = ds.Tables[0];
        string str = string.Empty;
        int count = 0;
        foreach (DataColumn dtcol in dt.Columns)
        {
            if (dtcol.ColumnName == "StudentName")
            {

                Response.Write("PO Report");
            }
            else
            {
                string str11 = "\t";
                Response.Write(str11);
            }

        }
        string str1 = "\n";
        Response.Write(str1);
        foreach (DataColumn dtcol in dt.Columns)
        {
            Response.Write(str + dtcol.ColumnName);
            str = "\t";
        }
        Response.Write("\n");
        foreach (DataRow dr in dt.Rows)
        {
            str = "";
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                Response.Write(str + Convert.ToString(dr[j]).Trim());
                str = "\t";
            }
            Response.Write("\n");
        }
        Response.End();

    }
    protected void HLExport_Click(object sender, EventArgs e)
    {
        //string asseet = "";
        try
        {
            Clear_Error_Success_Box();

            string Transfer_LocationCode = "", Div_Code = "";
            if (ddlLocationType.SelectedItem.ToString() == "Godown")
            {
                if (ddlgodownFR_SRSearch.SelectedIndex == 0)
                {
                    Transfer_LocationCode = "%%";
                }
                else
                {
                    Transfer_LocationCode = ddlgodownFR_SRSearch.SelectedValue.ToString().Trim();
                    lblLocationResult.Text = ddlgodownFR_SRSearch.SelectedItem.ToString();
                }

                lblLocationType_Result.Text = "Godown";
            }
            else if (ddlLocationType.SelectedItem.ToString() == "Function")
            {
                if (ddlFunctionFR_SRSearch.SelectedIndex == 0)
                {
                    Transfer_LocationCode = "%%";
                }
                else
                {
                    Transfer_LocationCode = ddlFunctionFR_SRSearch.SelectedValue.ToString().Trim();
                    lblLocationResult.Text = ddlFunctionFR_SRSearch.SelectedItem.ToString();
                }

                lblLocationType_Result.Text = "Function";
            }
            else if (ddlLocationType.SelectedItem.ToString() == "Center")
            {
                if (ddlDivisionFR_SRSearch.SelectedIndex == 0)
                {
                    Transfer_LocationCode = "%%";
                }
                else if (ddlCenterFR_SRSearch.SelectedIndex == 0)
                {
                    Transfer_LocationCode = "%%";
                }
                else
                {
                    Transfer_LocationCode = ddlCenterFR_SRSearch.SelectedValue.ToString().Trim();
                    lblLocationResult.Text = ddlCenterFR_SRSearch.SelectedItem.ToString();
                    Div_Code = ddlDivisionFR_SRSearch.SelectedValue;
                }

                lblLocationType_Result.Text = ddlDivisionFR_SRSearch.SelectedItem.ToString().Trim();
            }




            string CreatedBy = null;
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            CreatedBy = cookie.Values["UserID"];
            DataSet dsItems = null;
            try
            {

                DataSet ds1 = Report.Get_Report_OpeningStock1(2, "", ddlLocationType.SelectedValue, Div_Code, Transfer_LocationCode, "", CreatedBy);
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    GridView GridView1 = new GridView();
                    GridView1.DataSource = ds1.Tables[0];
                    GridView1.DataBind();

                    Response.ClearContent();
                    Response.AddHeader("content-disposition", "attachment; filename=Asset_Tagging" + DateTime.Now + ".xls");
                    Response.ContentType = "application/excel";
                    StringWriter sw = new StringWriter();
                    HtmlTextWriter htw = new HtmlTextWriter(sw);
                    GridView1.RenderControl(htw);
                    string style = @"<style> td { mso-number-format:\@;} </style>";
                    Response.Write(style);
                    Response.Write(sw.ToString());
                    Response.End();
                }
                else
                {
                    Msg_Error.Visible = true;
                    Msg_Success.Visible = false;
                    lblSuccess.Text = "";
                    lblerror.Text = "Records not found...!";
                    UpdatePanelMsgBox.Update();
                }

            }
            catch (Exception ex)
            {
                Msg_Error.Visible = true;
                Msg_Success.Visible = false;
                lblSuccess.Text = "";
                lblerror.Text = ex.ToString();
                UpdatePanelMsgBox.Update();
            }
            if (dsItems != null)
            {

                if (dsItems.Tables.Count != 0)
                {
                    if (dsItems.Tables[0].Rows.Count != 0)
                    {
                        lbltotalcount.Text = (dsItems.Tables[0].Rows.Count).ToString();
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

            Msg_Error.Visible = true;
            Msg_Success.Visible = false;
            lblerror.Text = ex.ToString();
            UpdatePanelMsgBox.Update();
            return;
        }
    }

    

   
 #endregion 

}


