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

public partial class Rpt_SupplierDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            try
            {
                FillListBX_Supplier();
                // FillDDL_LocationType();


            }
            catch (Exception ex)
            {

            }
        }
    }
    private void FillListBX_Supplier()
    {

        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];

        DataSet dsSupplier = ProductController.GetAllSupplier();
        BindListBox(listbxsupplier, dsSupplier, "Vendor_Name", "Vendor_Id");
        listbxsupplier.Items.Insert(0, "Select");
        listbxsupplier.Items.Insert(1, "All");




    }
    private void BindListBox(ListBox ddl, DataSet ds, string txtField, string valField)
    {
        ddl.DataSource = ds;
        ddl.DataTextField = txtField;
        ddl.DataValueField = valField;
        ddl.DataBind();
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

            if (listbxsupplier.SelectedIndex == 0 || listbxsupplier.SelectedIndex == -1)
            {
                Supplier = "";
            }
            else
            {
                Supplier = listbxsupplier.SelectedValue.ToString().Trim();
                List<string> list_1 = new List<string>();
                List<string> List_11 = new List<string>();
                List<string> List_22 = new List<string>();
                //string Supplier = "";
                foreach (ListItem li in listbxsupplier.Items)
                {
                    if (li.Selected == true)
                    {
                        list_1.Add(li.Value);
                        Supplier = string.Join(",", list_1.ToArray());
                        // lblsupplier.Text = listbxsupplier.SelectedItem.ToString().Trim();
                        if (Supplier == "All")
                        {
                            int remove = Math.Min(list_1.Count, 1);
                            list_1.RemoveRange(0, remove);
                        }
                    }
                }
            }
          
            FillGrid(FromDate, ToDate, Supplier, txtPo_no.Text.Trim());
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
    
    private void FillGrid(string fromdate, string todate, string supplier, string PO_NO )
    {
        try
        {
            Clear_Error_Success_Box();

           
           // lblsupplier.Text = listbxsupplier.SelectedItem.ToString().Trim();
           // lblperoid.Text = ddl.SelectedItem.ToString().Trim();
          


           

            DataSet dsGrid = ProductController.Get_SupplierDetails_Report(fromdate, todate, supplier, PO_NO);
         
            //if (dsGrid.Tables[0].Rows.Count == 0)
            //{
            //    Show_Error_Success_Box("E", " Record Not Found");
            //}
        

            if (dsGrid != null)
            {
                if (dsGrid.Tables.Count != 0)
                {
                    if (dsGrid.Tables[0].Rows.Count != 0)
                    {
                        lblperoid.Text = id_date_range_picker_2.Value;
                        lblPono.Text = txtPo_no.Text;
                        lbltotalcount.Text = (dsGrid.Tables[0].Rows.Count).ToString();
                        dlGridDisplay.DataSource = dsGrid;
                        dlGridDisplay.DataBind();

                        DataList1.DataSource = dsGrid;
                        DataList1.DataBind();
                        ControlVisibility("Result");

                    }
                    else
                    {
                        lbltotalcount.Text = "0";
                        dlGridDisplay.DataSource = null;
                        dlGridDisplay.DataBind();

                        DataList1.DataSource = null;
                        DataList1.DataBind();
                        Show_Error_Success_Box("E","Records Not found");
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

            string Supplier_Name = "";
            string SupplierCode = "";
            int BatchCnt = 0;
            int BatchSelCnt = 0;
            for (BatchCnt = 0; BatchCnt <= listbxsupplier.Items.Count - 1; BatchCnt++)
            {
                if (listbxsupplier.Items[BatchCnt].Selected == true)
                {
                    BatchSelCnt = BatchSelCnt + 1;
                }
            }

            if (BatchSelCnt == 0)
            {
                //When all is selected   
                //Show_Error_Success_Box("E", "0006");
                listbxsupplier.Focus();
                return;

            }
            else
            {
                for (BatchCnt = 0; BatchCnt <= listbxsupplier.Items.Count - 1; BatchCnt++)
                {
                    if (listbxsupplier.Items[BatchCnt].Selected == true)
                    {
                        SupplierCode = SupplierCode + listbxsupplier.Items[BatchCnt].Value + ",";
                        Supplier_Name = Supplier_Name + listbxsupplier.Items[BatchCnt].Text + ",";
                    }
                }
                SupplierCode = Common.RemoveComma(SupplierCode);
                Supplier_Name = Common.RemoveComma(Supplier_Name);

            }

            lblsupplier.Text = Supplier_Name;
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
            DivSearchPanel.Visible = true;
            DivResultPanel.Visible = false;

        }
        else if (Mode == "Result")
        {
            DivSearchPanel.Visible = false;
            DivResultPanel.Visible = true;

        }



    }
    protected void HLExport_Click(object sender, EventArgs e)
    {
        DataList1.Visible = true;

        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        string filenamexls1 = "SupplierDetails_Report" + DateTime.Now + ".xls";
        Response.AddHeader("Content-Disposition", "inline;filename=" + filenamexls1);
        HttpContext.Current.Response.Charset = "utf-8";
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");
        //sets font
        HttpContext.Current.Response.Write("<font style='font-size:10.0pt; font-family:Calibri;'>");
        HttpContext.Current.Response.Write("<BR><BR><BR>");
       //HttpContext.Current.Response.Write("<Table border='1'  borderColor='#000000' cellSpacing='0' cellPadding='0' style='font-size:10.0pt; font-family:Calibri; text-align:center;'> <TR style='color: #fff; background: black;text-align:center;'><TD Colspan='15'>SupplierDetails Report</b></TD></TR>");
        HttpContext.Current.Response.Write("<Table border='1'  borderColor='#000000' cellSpacing='0' cellPadding='0' style='font-size:10.0pt; font-family:Calibri; text-align:center;'> <TR style='color: #fff; background: black;text-align:center;'><TD Colspan='10'>PO Reprt Details</b></TD><TR><TD Colspan='3'><b>Supplier : " + lblsupplier.Text + "</b></TD><TD Colspan='3'><b>Peroid : " + lblperoid.Text + "</b></TD></tr><tr><TD Colspan='3'><b>PO NO : " + lblPono.Text + "</b></TD></TR></TR>");
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

    protected void BtnShowSearchPanel_Click(object sender, EventArgs e)
    {
        ControlVisibility("Search");
        Clear_Error_Success_Box();
    }
    protected void BtnClearSearch_Click(object sender, EventArgs e)
    {
        ClearSearchPanel();
    }

    private void ClearSearchPanel()
    {

        listbxsupplier.SelectedIndex = 0;
        id_date_range_picker_2.Value = "";
        txtPo_no.Text = "";
     

    }
}