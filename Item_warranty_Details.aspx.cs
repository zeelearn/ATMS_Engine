using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ShoppingCart.BL;
using System.IO;
using Microsoft.VisualBasic;
using System.Collections;
using System.Diagnostics;
using System.Web.UI.HtmlControls;

public partial class Item_warranty_Details : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                // ControlVisibility("Search");
                //visFalse();
                FillDDL_ProductCategory();
                HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                string UserID = cookie.Values["UserID"];
                Label lblHeader_User_Code = default(Label);
                lblHeader_User_Code = (Label)Master.FindControl("lblHeader_User_Code");
                lblHeader_User_Code.Text = UserID;




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




    private void BindDDL(DropDownList ddl, DataSet ds, string txtField, string valField)
    {
        ddl.DataSource = ds;
        ddl.DataTextField = txtField;
        ddl.DataValueField = valField;
        ddl.DataBind();
    }
    private void FillDDL_ProductCategory()
    {
        DataSet dsPrdouctCat = ProductController.GetAllProductCategory(2);
        BindDDL(ddlProductCat_SR, dsPrdouctCat, "Category_name", "Category_Code");
        ddlProductCat_SR.Items.Insert(0, "Select");
        // ddlProductCat_SR.SelectedIndex = 0;

        //BindDDL(ddlProductCat_Add, dsPrdouctCat, "Category_name", "Category_Code");
        //ddlProductCat_Add.Items.Insert(0, "Select");
        //ddlProductCat_Add.SelectedIndex = 0;

    }
    private void FillDDL_Item()
    {
        string Category;
        Category = ddlProductCat_SR.SelectedValue.ToString();
        DataSet dsPrdouctCat = ProductController.GetAllItem_byProductCategory(10, Category);
        BindDDL(ddlItemName_SR, dsPrdouctCat, "Item_Name", "Item_Code");
        ddlItemName_SR.Items.Insert(0, "Select");
        ddlItemName_SR.SelectedIndex = 0;



        //BindDDL(ddlProductCat_Add, dsPrdouctCat, "Category_name", "Category_Code");
        //ddlProductCat_Add.Items.Insert(0, "Select");
        //ddlProductCat_Add.SelectedIndex = 0;

    }

    protected void ddlProductCat_SR_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillDDL_Item();

    }
    private void ControlVisibility(string Mode)
    {
        if (Mode == "Search")
        {

            DivAddPanel.Visible = false;
            DivSearchPanel.Visible = true;
            BtnAdd.Visible = true;
            BtnSaveEdit.Visible = true;
            // DivAddPanel.Visible = false;
            DivResultPanel.Visible = false;
            //DivUserMenu.Visible = false;
            //lblPkey.Text = "";
        }
        else if (Mode == "Result")
        {
            //DivUserMenu.Visible = false;
            DivAddPanel.Visible = false;
            DivSearchPanel.Visible = false;
            BtnAdd.Visible = true;
            DivResultPanel.Visible = true;
            lblPkey.Text = "";

        }
        else if (Mode == "Add")
        {
            DivAddPanel.Visible = true;
            dlGridDisplay.Visible = true;
            DivSearchPanel.Visible = false;
            BtnAdd.Visible = false;
            DivResultPanel.Visible = false;
            DivAddpart.Visible = false;
            BtnSaveEdit.Visible = true;
            //txtVendor_Add.Text = "";
            //txtremark.Text = "";
            //txtcontact.Text = "";
            //id_date_range_picker_2.Value = "";

            //DivResultPanel.Visible = true;
            //BtnSaveEdit.Visible = true;
        }
        else if (Mode == "Edit")
        {
            DivAddPanel.Visible = false;
            DivAddpart.Visible = true;
            BtnSave_Part.Visible = true;
            //DivSearchPanel.Visible = false;
            // BtnAdd.Visible = false;
            // DivResultPanel.Visible = false;
            //DivUserMenu.Visible = false; 
        }
        else if (Mode == "ADDPart")
        {
            DivResultPanel.Visible = false;
            dlGridDisplay.Visible = false;
            DivAddpart.Visible = true;
            DivAddPanel.Visible = false;
            Btnedit_Part.Visible = false;
            BtnSave_Part.Visible = true;
            txtpartname.Text = "";
            txtVendor.Text = "";
            txtcontactNo.Text = "";
            txt_Remark.Text = "";
            date.Value = "";
            //lblmenuPK.Text = "";
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
    protected void BtnAdd_Click(object sender, EventArgs e)
    {
        try
        {

            //    if (id_date_range_picker_2.Value.Trim() == "")
            //    {

            Clear_Error_Success_Box();
            AddPart.Visible = true;


            if (ddlProductCat_SR.SelectedIndex == 0)
            {
                Show_Error_Success_Box("E", "Select Category");
                ddlProductCat_SR.Focus();
                return;

            }

            if (ddlItemName_SR.SelectedIndex == 0)
            {
                Show_Error_Success_Box("E", "Select Item");
                ddlItemName_SR.Focus();
                return;

            }
            string Category = ddlProductCat_SR.SelectedItem.ToString();
            lblcategory.Text = Category;

            string Item = ddlItemName_SR.SelectedItem.ToString();
            lblitemname.Text = Item;
            //BtnSaveEdit.Visible = true;
            string itemcode = ddlItemName_SR.SelectedValue;
            //lblpkey_master.Text.Trim();
            //Pkey.Text.Trim();
            //if (lblpkey_master.Text.Trim() != "")
            //{


            //DataSet ds;
            DataSet ds1;
            ds1 = ProductController.Get_ItemDetails(8, itemcode);

            //lblpkey_master.Text = ds1.Tables[1].Rows[0]["Pkey"].ToString();
            Clear_Error_Success_Box();
            ControlVisibility("Add");
            //}
            //    }
            //catch (Exception ex)
            //{
            //}
            if (ds1.Tables[1].Rows.Count > 0)
            {

                ShowItemDetails();
            }
            else
            {
                DivAddPanel.Visible = true;
                BtnSaveEdit.Visible = false;
                BtnSaveAdd.Visible = true;
                lblpkey_master.Text = "";
                DivSearchPanel.Visible = false;
                BtnAdd.Visible = false;
                DivResultPanel.Visible = false;
                DivAddpart.Visible = false;
                // BtnSaveEdit.Visible = true;
                txtVendor_Add.Text = "";
                txtremark.Text = "";
                txtcontact.Text = "";
                id_date_range_picker_2.Value = "";
                dlGridDisplay.Visible = false;
                // DivResultPanel.Visible = true;
                //BtnSaveEdit.Visible = true;
            }

        }

        catch (Exception ex)
        {
        }
    }
    private void ShowItemDetails()
    {
        try
        {
            {
                string itemcode = ddlItemName_SR.SelectedValue;
                //lblpkey_master.Text.Trim();
                //Pkey.Text.Trim();
                //if (lblpkey_master.Text.Trim() != "")
                //{


                DataSet ds;
                DataSet ds1;
                ds1 = ProductController.Get_ItemDetails(8, itemcode);


                if (ds1.Tables[1].Rows.Count > 0)
                {
                    lblpkey_master.Text = ds1.Tables[1].Rows[0]["Pkey"].ToString();
                    ds = ProductController.Get_ItemDetails1(8, itemcode, lblpkey_master.Text);


                    // if (lblpkey_master.Text.Trim() == itemcode + '%' + 0)
                    //if (ds1.Tables[1] != null)
                    //{
                    id_date_range_picker_2.Value = ds.Tables[1].Rows[0]["Warranty_EndDate"].ToString();
                    txtVendor_Add.Text = ds.Tables[1].Rows[0]["Vendor_Name"].ToString();
                    txtcontact.Text = ds.Tables[1].Rows[0]["Vendor_Contact_No"].ToString();
                    txtremark.Text = ds.Tables[1].Rows[0]["Remark"].ToString();
                   

                    if (ds != null)
                    {

                        if (ds.Tables.Count != 0)
                        {
                            if (ds.Tables[0].Rows.Count != 0)
                            {
                                dlGridDisplay.DataSource = ds;
                                dlGridDisplay.DataBind();
                                BtnSaveAdd.Visible = false;
                            
                                DataList1.DataSource = ds;
                                DataList1.DataBind();
                                BtnSaveAdd.Visible = false;
                                DivResultPanel.Visible = true;

                            }
                            if (ds.Tables[1].Rows.Count != 0)
                            {
                                dlGridDisplay.DataSource = ds;
                                dlGridDisplay.DataBind();
                                BtnSaveAdd.Visible = false;
                         
                                DataList1.DataSource = ds;
                                DataList1.DataBind();
                                BtnSaveAdd.Visible = false;
                                DivResultPanel.Visible = true;

                            }
                        }
                        else
                        {
                            dlGridDisplay.DataSource = null;
                            dlGridDisplay.DataBind();

                            DataList1.DataSource = ds;
                            DataList1.DataBind();
                            BtnSaveAdd.Visible = true;
                        }

                    }
                    else
                    {
                        dlGridDisplay.DataSource = null;
                        dlGridDisplay.DataBind();

                        DataList1.DataSource = null;
                        DataList1.DataBind();
                        BtnSaveAdd.Visible = true;

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

               // }
                else
                {
                    DivAddPanel.Visible = false;
                    BtnSaveEdit.Visible = false;
                    DivSearchPanel.Visible = true;
                    Show_Error_Success_Box("E", "No Record  Found");
                }

            }
          
        }
           
        catch (Exception ex)
        {
        }
       
    }


    private void ClearAddPanel()
    {

        txtVendor_Add.Text = "";
        id_date_range_picker_2.Value = "";
        txtcontact.Text = "";
        txtremark.Text = "";

    }
    private void Clear_Error_Success_Box()
    {
        Msg_Error.Visible = false;
        Msg_Success.Visible = false;
        lblSuccess.Text = "";
        lblerror.Text = "";
        UpdatePanelMsgBox.Update();
    }
    protected void AddPart_Click(object sender, EventArgs e)
    {

        ControlVisibility("ADDPart");
        Clear_Error_Success_Box();
    }
    protected void BtnCloseAdd_Click(object sender, EventArgs e)
    {
        ControlVisibility("Search");
        Clear_Error_Success_Box();
    }
    protected void BtnClearSearch_Click(object sender, EventArgs e)
    {
        Clear_Error_Success_Box();
        ddlProductCat_SR.SelectedIndex = 0;
        ddlItemName_SR.SelectedIndex = 0;
        txtItem_Code.Text = "";

    }
    protected void BtnShowSearchPanel_Click(object sender, EventArgs e)
    {
        Clear_Error_Success_Box();
        ControlVisibility("Search");
    }
    protected void BtnSaveAdd_Click(object sender, EventArgs e)
    {
       // Clear_Error_Success_Box();
        if (lblpkey_master.Text == "")
        {
            Label lblHeader_User_Code = default(Label);
            lblHeader_User_Code = (Label)Master.FindControl("lblHeader_User_Code");

            string CreatedBy = null;
            CreatedBy = lblHeader_User_Code.Text;
            if (id_date_range_picker_2.Value.Trim() == "")
            {
                Show_Error_Success_Box("E", " Select Date ");
                id_date_range_picker_2.Focus();
                return;
            }
            if (txtVendor_Add.Text == "")
            {
                Show_Error_Success_Box("E", " Vendor Name Blank ");
                txtVendor_Add.Focus();
                return;
            }
            if (txtcontact.Text == "")
            {
                Show_Error_Success_Box("E", " Contact NO Blank ");
                txtcontact.Focus();
                return;
            }
            if (txtremark.Text == "")
            {
                Show_Error_Success_Box("E", " Remark is Blank ");
                txtremark.Focus();
                return;
            }



            int WarrantyFlag = 0;
            if (chkActive.Checked == true)
                WarrantyFlag = 1;
            else
                WarrantyFlag = 0;
            string FromDate, ToDate;

            string DateRange = "";
            DateRange = id_date_range_picker_2.Value;

            FromDate = DateRange.Substring(0, 10);
            ToDate = (DateRange.Length > 9) ? DateRange.Substring(DateRange.Length - 10, 10) : DateRange;

            //string Vendor = txtVendor_Add.Text;
            // string Contact = txtcontact.Text;
            // string Remark = txtremark.Text;
            string ItemCode = ddlItemName_SR.SelectedValue;
            string ItemName = ddlItemName_SR.SelectedItem.ToString();
            int Part_No = 0;

            string ResultId = "";
            ResultId = ProductController.Insert_Itemwarranty_Details(1, ItemCode, ItemName, Part_No, WarrantyFlag, FromDate, ToDate, txtVendor_Add.Text.Trim(),
            txtcontact.Text.Trim(), txtremark.Text.Trim(), CreatedBy);
           // lblpkey_master.Text = ResultId;
            if (ResultId == "1")
            {
                //Show_Error_Success_Box("S", "Record Saved Successfully");
                BtnSearch_Click(this,e );
                Show_Error_Success_Box("S", "Record Saved Successfully");
               // lblpkey_master.Text = "";
               // BtnSave_Part.Visible = false;
               // Btnedit_Part.Visible = true;
            }
        }
        else{
            Show_Error_Success_Box("E", "Item not saved");
        }

    }
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        ControlVisibility("Search");
        AddPart.Visible = false;
        if (txtVendor_Add.Text != "")
        {
           // txtVendor_Add.Enabled = false;
        }
        Clear_Error_Success_Box();


        if (ddlProductCat_SR.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "Select Category");
            ddlProductCat_SR.Focus();
            return;

        }

        if (ddlItemName_SR.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "Select Item");
            ddlItemName_SR.Focus();
            return;

        }
        string Category = ddlProductCat_SR.SelectedItem.ToString();
        lblcategory.Text = Category;

        string Item = ddlItemName_SR.SelectedItem.ToString();
        lblitemname.Text = Item;


        Clear_Error_Success_Box();
        ControlVisibility("Add");
        ShowItemDetails();
    }
    protected void BtnPart_ItemClose_Click(object sender, EventArgs e)
    {
        Clear_Error_Success_Box();

        ControlVisibility("Add");

        ShowItemDetails();
        dlGridDisplay.Visible = true;
        DivResultPanel.Visible = true;
    }
    protected void BtnSave_Part_Click(object sender, EventArgs e)
    {
        Clear_Error_Success_Box();
        Label lblHeader_User_Code = default(Label);
        lblHeader_User_Code = (Label)Master.FindControl("lblHeader_User_Code");


        if (txtpartname.Text == "")
        {
            Show_Error_Success_Box("E", " Part Name Blank ");
            txtpartname.Focus();
            return;
        }
        if (date.Value.Trim() == "")
        {
            Show_Error_Success_Box("E", " Select Date ");
            date.Focus();
            return;
        }
        if (txtVendor.Text == "")
        {
            Show_Error_Success_Box("E", " Vendor Name Blank ");
            txtVendor.Focus();
            return;
        }
        if (txtcontact.Text == "")
        {
            Show_Error_Success_Box("E", " Contact NO Blank ");
            txtcontact.Focus();
            return;
        }
        if (txtcontactNo.Text == "")
        {
            Show_Error_Success_Box("E", " Remark is Blank ");
            txtcontactNo.Focus();
            return;
        }


        string CreatedBy = null;
        CreatedBy = lblHeader_User_Code.Text;

        int WarrantyFlag = 0;
        if (chkstatus.Checked == true)
            WarrantyFlag = 1;
        else
            WarrantyFlag = 0;
        string FromDate, ToDate;
        if (date.Value == "")
        {
            FromDate = "";
            ToDate = "";
        }
        else
        {
            string DateRange = "";
            DateRange = date.Value;

            FromDate = DateRange.Substring(0, 10);
            ToDate = (DateRange.Length > 9) ? DateRange.Substring(DateRange.Length - 10, 10) : DateRange;
        }

        //string Vendor = txtVendor_Add.Text;
        // string Contact = txtcontact.Text;
        // string Remark = txtremark.Text;
        string ItemCode = ddlItemName_SR.SelectedValue;
        string ItemName = txtpartname.Text;
      //  int Part_No = 1;

        string ResultId = "";
        ResultId = ProductController.Insert_Itemwarranty_Details(2, ItemCode, ItemName, ' ', WarrantyFlag, FromDate, ToDate, txtVendor.Text.Trim(),
        txtcontactNo.Text.Trim(), txt_Remark.Text.Trim(), CreatedBy);
        if (ResultId == "1")
        {
            Show_Error_Success_Box("S", "Record Saved Successfully");
           // Clear_Error_Success_Box();

            ControlVisibility("Add");

            ShowItemDetails();
            dlGridDisplay.Visible = true;
            DivResultPanel.Visible = true;


        }
        
         //BtnSearch_Click(sender, e);
    }
    protected void dlGridDisplay_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "comEdit")
            {

                Clear_Error_Success_Box();
                // ControlVisibility("Edit");
                //BtnSaveEdit.Visible = true;
                // dlGridDisplay.Visible = true;
                DivAddpart.Visible = true;
                Btnedit_Part.Visible = true;
                BtnSave_Part.Visible = false;
                DivAddPanel.Visible = false;
                BtnSaveEdit.Visible = true;
                UpdatePanelAdd.Update();
                
                // BtnSaveUpdate.Visible = false;
                // DataList4.Visible = false;
                //  ClearAddPanel();
                // ClearItemAdd();
                //dlGridDisplay.DataSource = null;
                //dlGridDisplay.DataBind();
                //FillDDL_Supplier();
                //Clear_Error_Success_Box();
                string poflag;
                // UploadStatusLabel1.Visible = false;

                HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                string UserID = cookie.Values["UserID"];
                string UserName = cookie.Values["UserName"];


                lblPkey.Text = e.CommandArgument.ToString();
                //string ErrorFlag = "";
                DataSet ds;
                ds = ProductController.Get_ItempartDetails(4, lblPkey.Text);

                //  DataSet ds = ProductController.Get_Edit_GRNDetails(28, lblPkey.Text.Trim());
                txtpartname.Text = ds.Tables[0].Rows[0]["Part_Name"].ToString();
                date.Value = ds.Tables[0].Rows[0]["Warranty_EndDate"].ToString();
                txtVendor.Text = ds.Tables[0].Rows[0]["Vendor_Name"].ToString();
                txtcontactNo.Text = ds.Tables[0].Rows[0]["Vendor_Contact_No"].ToString();
                txt_Remark.Text = ds.Tables[0].Rows[0]["Remark"].ToString();


            }
            else if (e.CommandName == "ItemRemove")
            {
                lblPkey.Text = e.CommandArgument.ToString().Trim();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalDivCOnfirmation();", true);
                UpdatePanelAdd.Update();
                dlGridDisplay.Visible = true;
            }

        }



        catch (Exception ex)
        {

        }
    }
    protected void btnDivConfirmYes_Click(object sender, System.EventArgs e)
    {
        Clear_Error_Success_Box();
        string ItemCode = ddlItemName_SR.SelectedValue;
        DataSet dsGrid = ProductController.delete_Itempart(5, lblPkey.Text.Trim(), ItemCode);

        if (dsGrid != null)
        {
            if (dsGrid.Tables.Count != 0)
            {
                if (dsGrid.Tables[0].Rows.Count != 0)
                {
                    //lbltotalcount.Text = (dsGrid.Tables[0].Rows.Count).ToString();
                    dlGridDisplay.DataSource = dsGrid;
                    dlGridDisplay.DataBind();
                    dlGridDisplay.Visible = true;
                    UpdatePanelAdd.Update();
                    //UpdatePanel2.Update();
                    ShowItemDetails();
                    dlGridDisplay.Visible = true;
                    DivResultPanel.Visible = true;
                    Show_Error_Success_Box("S", "Part Deleted Successfully");

                }
                else
                {
                    dlGridDisplay.DataSource = null;
                    dlGridDisplay.DataBind();
                    dlGridDisplay.Visible = true;
                    UpdatePanelAdd.Update();
                    // UpdatePanel2.Update();
                    ShowItemDetails();
                    Show_Error_Success_Box("S", "Part Deleted Successfully");

                    //  FillTotalDetails_Temp();
                }
            }
            else
            {
                dlGridDisplay.DataSource = null;
                dlGridDisplay.DataBind();
                dlGridDisplay.Visible = true;
                UpdatePanelAdd.Update();
                dlGridDisplay.Visible = true;
                // UpdatePanel2.Update();
                DivResultPanel.Visible = true;
                DivAddPanel.Visible = true;
                dlGridDisplay.Visible = true;
                ShowItemDetails();
                Show_Error_Success_Box("S", "Part Deleted Successfully");
            }
        }
        else
        {
            dlGridDisplay.DataSource = null;
            dlGridDisplay.DataBind();
            UpdatePanelAdd.Update();
            // UpdatePanel2.Update();
            ShowItemDetails();
            Show_Error_Success_Box("S", "Part Deleted Successfully");


        }    

        //UpdatePanel1.Update();
        Show_Error_Success_Box("S", "Record Deleted Successfully");
    }
    public void FillTotalDetails_Temp()
    {
        int Total_Item_Count = 0;
        int Total_Quantity = 0;

        foreach (DataListItem item in dlGridDisplay.Items)
        {
            if (item.ItemType == ListItemType.Item | item.ItemType == ListItemType.AlternatingItem)
            {
                Label lblValue_DT = (Label)item.FindControl("lblValue_DT");
                Label lblQty_DT = (Label)item.FindControl("lblQty_DT");

                Total_Item_Count = Total_Item_Count + 1;


                Total_Quantity = Total_Quantity + Convert.ToInt32(lblQty_DT.Text.Trim());
            }
        }

        // txtTotalItems.Text = Total_Item_Count.ToString();
        //txtTotalQuantity.Text = Total_Quantity.ToString();

    }
    protected void Btnedit_Part_Click(object sender, EventArgs e)
    {
        Clear_Error_Success_Box();
        try
        {
            Label lblHeader_User_Code = default(Label);
            lblHeader_User_Code = (Label)Master.FindControl("lblHeader_User_Code");


            if (txtpartname.Text == "")
            {
                Show_Error_Success_Box("E", " Part Name Blank ");
                txtpartname.Focus();
                return;
            }
            if (date.Value.Trim() == "")
            {
                Show_Error_Success_Box("E", " Select Date ");
                date.Focus();
                return;
            }
            if (txtVendor.Text == "")
            {
                Show_Error_Success_Box("E", " Vendor Name Blank ");
                txtVendor.Focus();
                return;
            }
            if (txt_Remark.Text == "")
            {
                Show_Error_Success_Box("E", "   Remark is  Blank ");
                txt_Remark.Focus();
                return;
            }
            if (txtcontactNo.Text == "")
            {
                Show_Error_Success_Box("E", "Contact NO  is Blank ");
                txtcontactNo.Focus();
                return;
            }

            //if (txt_Remark.Text>)
            //{
            //}

            string CreatedBy = null;
            CreatedBy = lblHeader_User_Code.Text;

            int WarrantyFlag = 0;
            if (chkstatus.Checked == true)
                WarrantyFlag = 1;
            else
                WarrantyFlag = 0;
            string FromDate, ToDate;
            if (date.Value == "")
            {
                FromDate = "";
                ToDate = "";
            }
            else
            {
                string DateRange = "";
                DateRange = date.Value;

                FromDate = DateRange.Substring(0, 10);
                ToDate = (DateRange.Length > 9) ? DateRange.Substring(DateRange.Length - 10, 10) : DateRange;
            }

            //string Vendor = txtVendor_Add.Text;
            // string Contact = txtcontact.Text;
            // string Remark = txtremark.Text;
            string ItemCode = ddlItemName_SR.SelectedValue;
            string ItemName = txtpartname.Text;
            string ItemCode1 = ItemCode + '%' + 0;

            // lblPkey.Text = e.CommandArgument.ToString();
            string ResultId = "";
            DataSet ds;
            ds = ProductController.Update_ItempartDetails(6, txtpartname.Text.Trim(), WarrantyFlag, FromDate, ToDate, txtVendor.Text.Trim(), txtcontactNo.Text.Trim(), txt_Remark.Text.Trim(), lblPkey.Text);


            txtpartname.Text = ds.Tables[0].Rows[0]["Part_Name"].ToString();
            date.Value = ds.Tables[0].Rows[0]["Warranty_EndDate"].ToString();
            txtVendor.Text = ds.Tables[0].Rows[0]["Vendor_Name"].ToString();
            txtcontactNo.Text = ds.Tables[0].Rows[0]["Vendor_Contact_No"].ToString();
            txt_Remark.Text = ds.Tables[0].Rows[0]["Remark"].ToString();


            if (ds != null)
            {
                Show_Error_Success_Box("S", "Record updated Successfully");
                ShowItemDetails();
                dlGridDisplay.Visible = true;
                DivResultPanel.Visible = true;
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void BtnSaveEdit_Click(object sender, EventArgs e)
    {
        try
        {
            Label lblHeader_User_Code = default(Label);
            lblHeader_User_Code = (Label)Master.FindControl("lblHeader_User_Code");

            string CreatedBy = null;
            CreatedBy = lblHeader_User_Code.Text;
            if (id_date_range_picker_2.Value.Trim() == "")
            {
                Show_Error_Success_Box("E", " Select Date ");
                id_date_range_picker_2.Focus();
                return;
            }
            if (txtVendor_Add.Text == "")
            {
                Show_Error_Success_Box("E", " Vendor Name Blank ");
                txtVendor_Add.Focus();
                return;
            }
            if (txtcontact.Text == "")
            {
                Show_Error_Success_Box("E", " Contact NO Blank ");
                txtcontact.Focus();
                return;
            }
            if (txtremark.Text == "")
            {
                Show_Error_Success_Box("E", " Remark is Blank ");
                txtremark.Focus();
                return;
            }



            int WarrantyFlag = 0;
            if (chkActive.Checked == true)
                WarrantyFlag = 1;
            else
                WarrantyFlag = 0;
            string FromDate, ToDate;

            string DateRange = "";
            DateRange = id_date_range_picker_2.Value;

            FromDate = DateRange.Substring(0, 10);
            ToDate = (DateRange.Length > 9) ? DateRange.Substring(DateRange.Length - 10, 10) : DateRange;
            string itemcode = ddlItemName_SR.SelectedValue;
            // lblpkey_master.Text.Trim();
            //string Vendor = txtVendor_Add.Text;
            // string Contact = txtcontact.Text;
            // string Remark = txtremark.Text;
            string ItemCode = ddlItemName_SR.SelectedValue;
            string itemcod = ItemCode + '%' + 0;
            // string itemcod = lblpkey_master.Text.Trim();
            string ItemName = ddlItemName_SR.SelectedItem.ToString();
            //int Part_No = 0;

            DataSet ds;
            ds = ProductController.Update_ItemDetails(7, WarrantyFlag, FromDate, ToDate, txtVendor_Add.Text.Trim(), txtcontact.Text.Trim(), txtremark.Text.Trim(), itemcod, ItemCode);
            //ResultId = ProductController.Insert_Itemwarranty_Details(1, ItemCode, ItemName, Part_No, WarrantyFlag, FromDate, ToDate, txtVendor_Add.Text.Trim(),
            // txtcontact.Text.Trim(), txtremark.Text.Trim(), CreatedBy);
            //if (ds == "1")
            //{


            if (ds != null)
            {
                //lblpkey_master.Text = ds.Tables[0].Rows[0]["Pkey"].ToString();
                // ds = ProductController.Get_ItemDetails1(8, itemcode, lblpkey_master.Text);


                //if (lblpkey_master.Text.Trim() == itemcoddlItemName_SRde + '%' + 0)
                //{
                id_date_range_picker_2.Value = ds.Tables[0].Rows[0]["Warranty_EndDate"].ToString();
                txtVendor_Add.Text = ds.Tables[0].Rows[0]["Vendor_Name"].ToString();
                txtcontact.Text = ds.Tables[0].Rows[0]["Vendor_Contact_No"].ToString();
                txtremark.Text = ds.Tables[0].Rows[0]["Remark"].ToString();
            }
            Show_Error_Success_Box("S", "Record Updated Successfully");

            AddPart.Visible = false;
          //  lblpkey_master.Text = "";
            // Clear_Error_Success_Box();

        }
        catch (Exception ex)
        {
        }
    }
   
}