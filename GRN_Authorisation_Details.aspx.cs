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

public partial class GRN_Authorisation_Details : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];


        // lblPkey.Text = e.CommandArgument.ToString();
        string ErrorFlag = "";
        string Inward_Code = null;
        Inward_Code = Request.QueryString["Inward_Code"];

        ErrorFlag = ProductController.Get_Edit_GRNDetails_UserAuth(4, Inward_Code, UserID);
        DataSet ds = ProductController.Get_GRNNO_Details(Inward_Code);

        lblTransferFR_SR.Text = ds.Tables[0].Rows[0]["Transfer_Location_Type"].ToString();
        if (ds.Tables[0].Rows[0]["Transfer_Location_Type_Code"].ToString() == "TL0000001")
        {
            lblGodownName.Text = "Godown Name";
            lblgodownFR_SR.Text = ds.Tables[0].Rows[0]["Transfer_Location"].ToString();
            tblFr_Godown.Visible = true;
        }
        if (ds.Tables[0].Rows[0]["Transfer_Location_Type_Code"].ToString() == "TL0000002")
        {
            lblFunctionFR_SR.Text = ds.Tables[0].Rows[0]["Transfer_Location"].ToString();
            tblFr_Function.Visible = true;
        }
        if (ds.Tables[0].Rows[0]["Transfer_Location_Type_Code"].ToString() == "TL0000003")
        {
            lblfunction.Text = "Center";

            lblDivision.Text = "Division ";
            lblCenterName.Text = "Center";
            lblDivisionFR_SR.Text = ds.Tables[0].Rows[0]["Transfer_Location"].ToString();
            lblCenterFR_SR.Text = ds.Tables[0].Rows[0]["Center"].ToString();
            tblFr_Division.Visible = true;
            tblFr_Center.Visible = true;

        }
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtEntryDate_Auth.Text = ds.Tables[0].Rows[0]["Inward_date"].ToString();
                  //  poflag = ds.Tables[0].Rows[0]["PoFlag"].ToString();

                     lblPONo_Add.Text = ds.Tables[0].Rows[0]["PoFlag"].ToString();
                        // FillDDL_POItems();
                     lblSuppName.Text = ds.Tables[0].Rows[0]["Vendor_Name"].ToString();
                     lblsuppliercode.Text = ds.Tables[0].Rows[0]["Vendor_Code"].ToString();
                     lblTransferFR_SR.Text = ds.Tables[0].Rows[0]["Transfer_Location_Type"].ToString();
               
                   // lblbudgetDivision.Text = ds.Tables[0].Rows[0]["Budget_Division"].ToString();
                    lblDCNO.Text = ds.Tables[0].Rows[0]["Challan_No"].ToString();
                    txtDCDate.Value = ds.Tables[0].Rows[0]["Challan_Date"].ToString();
                    lblInvoiceNo_Add.Text = ds.Tables[0].Rows[0]["Invoice_No"].ToString();
                    txtInvoiceDT.Value = ds.Tables[0].Rows[0]["invoice_date"].ToString();
                    lblInvoiceValue_Add.Text = ds.Tables[0].Rows[0]["invoice_value"].ToString();

                   // txtTotalItems.Text = ds.Tables[0].Rows[0]["total_item_count"].ToString();
                   // txtTotalQuantity.Text = ds.Tables[0].Rows[0]["total_quantity"].ToString();
                   // txtTotalValue.Text = ds.Tables[0].Rows[0]["total_purchase_Amount"].ToString();

                 //   lblLogisticType_Add.Text = ds.Tables[0].Rows[0]["Logistic_Type_Name"].ToString();
                   // lblLogisticDetails_Add.Text = ds.Tables[0].Rows[0]["LogisticDetails1"].ToString();
                    lblPono.Text = ds.Tables[0].Rows[0]["PoNo"].ToString();
                    
                   // txtPODNo_Add0.Text = ds.Tables[0].Rows[0]["LogisticDetails2"].ToString();
                   // txtVechicleNo_Add.Text = ds.Tables[0].Rows[0]["LogisticDetails2"].ToString();

                    string Inward_Code1 = null;
                    Inward_Code1 = Request.QueryString["Inward_Code"];


                    DataSet dsItems = ProductController.Get_Edit_GRNDetails(19, Inward_Code1);
                    if (dsItems.Tables[0].Rows.Count > 0)
                    {
                        dlItemListAuthorise.DataSource = dsItems;
                        dlItemListAuthorise.DataBind();
                    }
                }

            }
        }

    
