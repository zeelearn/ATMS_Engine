using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ShoppingCart.BL;
using System.IO;



public partial class Manage_ItemMaster : System.Web.UI.Page
    {

        #region PageLoad
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ControlVisibility("Search");
                //visFalse();
                FillDDL_ProductCategory();
                FillDDL_UOM();
                FillDDL_Manufacture();
                FillDDL_AssetNoType();
                FillDDL_AssetType();
                FillDDL_ExpenceType();
               
                
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

        
        private void FillDDL_ProductCategory()
        {
            DataSet dsPrdouctCat = ProductController.GetAllProductCategory(2);
            BindDDL(ddlProductCat_SR, dsPrdouctCat, "Category_name", "Category_Code");
            ddlProductCat_SR.Items.Insert(0, "Select");
            ddlProductCat_SR.SelectedIndex = 0;

            BindDDL(ddlProductCat_Add, dsPrdouctCat, "Category_name", "Category_Code");
            ddlProductCat_Add.Items.Insert(0, "Select");
            ddlProductCat_Add.SelectedIndex = 0;

        }

        private void FillDDL_UOM()
        {
            DataSet dsUOM = ProductController.GetGodown_Function_Logistic_Assests_Type(10);
            BindDDL(ddlUOM_Add, dsUOM, "UOM_Name", "UOM_ID");
            ddlUOM_Add.Items.Insert(0, "Select");
            ddlUOM_Add.SelectedIndex = 0;

        }

        private void FillDDL_ItemSpecification()
        {
            DataSet dsSpecification = new DataSet();

            if (lblPkey.Text=="")
            {
                dsSpecification = ProductController.GetAllSpecification(9, ddlProductCat_Add.SelectedValue.ToString(), lblPkey.Text);
            }
            else
            {
                dsSpecification = ProductController.GetAllSpecification(8, ddlProductCat_Add.SelectedValue.ToString(), lblPkey.Text);
                if (dsSpecification.Tables.Count != 0)
                {
                    if (dsSpecification.Tables[0].Rows.Count == 0)
                    {
                        dsSpecification = ProductController.GetAllSpecification(9, ddlProductCat_Add.SelectedValue.ToString(), "");
                    }
                    
                }
            }
             
            dlItemSpecification.DataSource = null;
            dlItemSpecification.DataBind();
            
            if (dsSpecification.Tables[0].Rows.Count > 0)
            {  dlItemSpecification.DataSource = dsSpecification;
                dlItemSpecification.DataBind();
            }        
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
                BtnAdd.Visible = true;
                BtnSaveAdd.Visible = true;
                BtnSaveEdit.Visible  = false;
                DivResultPanel.Visible = false;
                //DivUserMenu.Visible = false;
                lblPkey.Text = "";      
            }
            else if (Mode == "Result")
            {
                BtnShowSearchPanel.Visible = true;
                DivAddPanel.Visible = false;
                DivSearchPanel.Visible = false;
                BtnAdd.Visible = true;
                DivResultPanel.Visible = true;
                lblPkey.Text = "";
                
            }
            else if (Mode == "Add")
            {
                DivAddPanel.Visible = true;
                DivSearchPanel.Visible = false;
                BtnAdd.Visible = false;
                DivResultPanel.Visible = false;
                BtnShowSearchPanel.Visible = true;
                lblPkey.Text = "";
                txtMaterils.Text = "";
                txtMaterils.Enabled = true;
                BtnSaveEdit.Visible = false;
                BtnSaveAdd.Visible = true;
            }
            else if (Mode == "Edit")
            {
                DivAddPanel.Visible = false;
                DivSearchPanel.Visible = false;
                BtnAdd.Visible = false;
                DivResultPanel.Visible = false;
                //DivUserMenu.Visible = false; 
            }
            else if (Mode == "UserRole")
            {
                DivAddPanel.Visible = false;
                DivSearchPanel.Visible = false;
                BtnAdd.Visible = true;
                DivResultPanel.Visible = false;
                //DivUserMenu.Visible = true;
                //lblmenuPK.Text = "";
            }
         
        }


        private void FillDDL_Manufacture()
        {
            ddlManufacture_Add.Items.Clear();
            DataSet dsTransfer_Tp = ProductController.GetGodown_Function_Logistic_Assests_Type(6);
            BindDDL(ddlManufacture_Add, dsTransfer_Tp, "Manufacturer_Name", "Manufacturer_Id");
            ddlManufacture_Add.Items.Insert(0, "Select");
            ddlManufacture_Add.SelectedIndex = 0;
        }


        private void FillDDL_AssetNoType()
        {
            ddlAssetNoType_Add.Items.Clear();
            DataSet dsTransfer_Tp = ProductController.GetGodown_Function_Logistic_Assests_Type(7);
            BindDDL(ddlAssetNoType_Add, dsTransfer_Tp, "AssetsNo_Type_Name", "AssetsNo_Type_Id");
            ddlAssetNoType_Add.Items.Insert(0, "Select");
            ddlAssetNoType_Add.SelectedIndex = 0;
        }


        private void FillDDL_AssetType()
        {
            ddlAssetType_Add.Items.Clear();
            DataSet dsTransfer_Tp = ProductController.GetGodown_Function_Logistic_Assests_Type(8);
            BindDDL(ddlAssetType_Add, dsTransfer_Tp, "Asset_Type_Name", "Asset_Type_Id");
            ddlAssetType_Add.Items.Insert(0, "Select");
            ddlAssetType_Add.SelectedIndex = 0;
        }


        private void FillDDL_ExpenceType()
        {
            ddlExpenceType_Add.Items.Clear();
            DataSet dsTransfer_Tp = ProductController.GetGodown_Function_Logistic_Assests_Type(9);
            BindDDL(ddlExpenceType_Add, dsTransfer_Tp, "Expense_Type_Name", "Expense_Type_Id");
            ddlExpenceType_Add.Items.Insert(0, "Select");
            ddlExpenceType_Add.SelectedIndex = 0;
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
        private void ClearAddPanel()
        {
            ddlProductCat_Add.SelectedIndex = 0;
            txtItemName_Add.Text = "";
            txtItemDesc_Add.Text = "";        
            txtBarcode_Add.Text = "";
            txtItemSKU_Add.Text = "";
            ddlManufacture_Add.SelectedIndex = 0;
            ddlExpenceType_Add.SelectedIndex = 0;
            ddlAssetNoType_Add.SelectedIndex = 0;
            ddlAssetType_Add.SelectedIndex = 0;
            ddlUOM_Add.SelectedIndex = 0;
            txtMaterils.Text = "";
            dlItemSpecification.DataSource = null;
            dlItemSpecification.DataBind();
        }

                
        private void ClearSearchPanel()
        {
            ddlProductCat_SR.SelectedIndex = 0;
            txtItemName_SR.Text = "";
            txtItemSKU_SR.Text = "";
            txtBarcode_SR.Text = "";
            txtMaterial_Code.Text = "";
        }


        private void FillGrid(string categoryname, string Item_Name, string Item_SKU, string Item_Barcode,string Material_Code)
        {
            try
            {
                Clear_Error_Success_Box();
                               
            

                DataSet dsGrid = ProductController.Get_Fill_Item(5, categoryname, Item_Name, Item_SKU, Item_Barcode, Material_Code);

               

                if (dsGrid != null)
                {
                    if (dsGrid.Tables.Count != 0)
                    {
                        if (dsGrid.Tables[0].Rows.Count != 0)
                        {
                            dlGridDisplay.DataSource = dsGrid;
                            dlGridDisplay.DataBind();

                            DataList1.DataSource = dsGrid;
                            DataList1.DataBind();
                            lbltotalcount.Text = (dsGrid.Tables[0].Rows.Count).ToString();
                            ControlVisibility("Result");
                        }
                        else
                        {
                            lbltotalcount.Text = "0";
                            dlGridDisplay.DataSource = null;
                            dlGridDisplay.DataBind();

                            DataList1.DataSource = null;
                            DataList1.DataBind();
                            Show_Error_Success_Box("E", "No Records Found");
                        }
                    }
                    else
                    {
                        lbltotalcount.Text = "0";
                        dlGridDisplay.DataSource = null;
                        dlGridDisplay.DataBind();

                        DataList1.DataSource = null;
                        DataList1.DataBind();
                        Show_Error_Success_Box("E", "No Records Found");
                    }
                }
                else
                {
                    lbltotalcount.Text = "0";
                    dlGridDisplay.DataSource = null;
                    dlGridDisplay.DataBind();

                    DataList1.DataSource = null;
                    DataList1.DataBind();
                    Show_Error_Success_Box("E", "No Records Found");
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



        private void SaveData()
        {
            try
            {
                Clear_Error_Success_Box();

                if (ddlProductCat_Add.SelectedIndex == 0 || ddlProductCat_Add.SelectedIndex == -1)
                {
                    Show_Error_Success_Box("E", "Select Category");
                    ddlProductCat_Add.Focus();
                    return;
                }

                if (txtItemName_Add.Text.Trim() == "")
                {
                    Show_Error_Success_Box("E", "Enter Item Name");
                    txtItemName_Add.Focus();
                    return;
                }


                if (ddlUOM_Add.SelectedIndex == 0 || ddlUOM_Add.SelectedIndex == -1)
                {
                    Show_Error_Success_Box("E", "Select UOM");
                    ddlUOM_Add.Focus();
                    return;
                }


                if (txtBarcode_Add.Text.Trim() == "")
                {
                    Show_Error_Success_Box("E", "Enter EAN No");
                    txtBarcode_Add.Focus();
                    return;
                }
                if (txtMaterils.Text.Trim() == "")
                {
                    Show_Error_Success_Box("E", "Enter Material Code ");
                    txtMaterils.Focus();
                    return;
                }

                if (txtItemSKU_Add.Text.Trim() == "")
                {
                    Show_Error_Success_Box("E", "Enter Item SKU");
                    txtItemSKU_Add.Focus();
                    return;
                }
                if (ddlManufacture_Add.SelectedIndex == 0 || ddlManufacture_Add.SelectedIndex == -1)
                {
                    Show_Error_Success_Box("E", "Select Manufacture");
                    ddlManufacture_Add.Focus();
                    return;
                }

                if (ddlAssetNoType_Add.SelectedIndex == 0 || ddlAssetNoType_Add.SelectedIndex == -1)
                {
                    Show_Error_Success_Box("E", "Select Asset No Type");
                    ddlAssetNoType_Add.Focus();
                    return;
                }

                if (ddlAssetType_Add.SelectedIndex == 0 || ddlAssetType_Add.SelectedIndex == -1)
                {
                    Show_Error_Success_Box("E", "Select Asset Type");
                    ddlAssetType_Add.Focus();
                    return;
                }


                if (ddlExpenceType_Add.SelectedIndex == 0 || ddlExpenceType_Add.SelectedIndex == -1)
                {
                    Show_Error_Success_Box("E", "Select Expence Type");
                    ddlExpenceType_Add.Focus();
                    return;
                }


                Label lblHeader_User_Code = default(Label);
                lblHeader_User_Code = (Label)Master.FindControl("lblHeader_User_Code");

                HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                string UserID = cookie.Values["UserID"];
                string CreatedBy = null;
                CreatedBy = UserID;

                int ActiveFlag = 0;
                if (chkActive.Checked == true)
                    ActiveFlag = 1;
                else
                    ActiveFlag = 0;

                int FGStatus = 0;
                if (ChkFGStatus.Checked == true)
                    FGStatus = 1;
                else
                    FGStatus = 0;

                string ResultId = "";
                


                ResultId = ProductController.Insert_ItemMaster(1, txtMaterils.Text, ddlProductCat_Add.SelectedValue.ToString().Trim(), txtItemName_Add.Text.Trim(),
                txtItemDesc_Add.Text.Trim(), ddlManufacture_Add.SelectedValue, txtBarcode_Add.Text.Trim(), txtItemSKU_Add.Text.Trim(),
                ddlUOM_Add.SelectedValue, ddlAssetNoType_Add.SelectedValue, ddlAssetType_Add.SelectedValue, ddlExpenceType_Add.SelectedValue,
                ActiveFlag, CreatedBy, FGStatus);

                if (ResultId == "-3")
                {
                    Clear_Error_Success_Box();
                    Msg_Error.Visible = true;
                    Msg_Success.Visible = false;
                    Show_Error_Success_Box("E", "Material already Exist");
                    return;
                }

                else if (ResultId == "-2")
                {
                    Clear_Error_Success_Box();
                    Msg_Error.Visible = true;
                    Msg_Success.Visible = false;
                    Show_Error_Success_Box("E", "Item SKU already Exist");
                    return;
                }


                else if (ResultId == "-4")
                {
                    Clear_Error_Success_Box();
                    Msg_Error.Visible = true;
                    Msg_Success.Visible = false;
                    Show_Error_Success_Box("E", "Item EAN No already Exist");
                    return;
                }
                else
                {


                    string childResult = "";
                    childResult = ProductController.Insert_ProductItemSpecification(ResultId, "", "", 0, "", 2);
                    if (childResult == "1")
                    {
                        childResult = "";
                        foreach (DataListItem item in dlItemSpecification.Items)
                        {
                            Label lblSpecification = (Label)item.FindControl("lblSpecification");
                            Label lblItem_Code = (Label)item.FindControl("lblItem_Code");
                            TextBox txtSpecDescription = (TextBox)item.FindControl("txtSpecDescription");
                            childResult = ProductController.Insert_ProductItemSpecification(ResultId, lblSpecification.Text, txtSpecDescription.Text.Trim(), 1, CreatedBy, 1);
                        }
                    }
                    ControlVisibility("Search");
                    Show_Error_Success_Box("S", "Record saved Successfully.");
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

       
        private void UpdateData()
        {
            //try
            //{
            //    Clear_Error_Success_Box();

            //    if (ddlDivisionEdit.SelectedIndex == 0)
            //    {
            //        Show_Error_Success_Box("E", "0001");
            //        ddlDivisionEdit.Focus();
            //        return;
            //    }
            //    if (ddlCCEdit.SelectedIndex == 0)
            //    {
            //        Show_Error_Success_Box("E", "Select Course Category");
            //        ddlCCEdit.Focus();
            //        return;
            //    }
            //    if (ddlBoardEdit.SelectedIndex == 0)
            //    {
            //        Show_Error_Success_Box("E", "Select Board");
            //        ddlBoardEdit.Focus();
            //        return;
            //    }
            //    if (ddlMediumEdit.SelectedIndex == 0)
            //    {
            //        Show_Error_Success_Box("E", "Select Medium");
            //        ddlMediumEdit.Focus();
            //        return;
            //    }
            //    if (txtEditCourseName.Text.Trim() == "")
            //    {
            //        Show_Error_Success_Box("E", "Enter Course Name");
            //        txtEditCourseName.Focus();
            //        return;
            //    }
            //    HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            //    string UserID = cookie.Values["UserID"];

            //    int ActiveFlag = 0;
            //    if (chkEditActiveFlag.Checked == true)
            //        ActiveFlag = 1;
            //    else
            //        ActiveFlag = 0;
                
            //    int ResultId = 0;
            //    ResultId = ProductController.InsertUpdateCourseDetail(lblPkey.Text,ddlCCEdit.SelectedValue, ddlBoardEdit.SelectedValue,ddlMediumEdit.SelectedValue,ddlDivisionEdit.SelectedValue, txtEditCourseName.Text, txtEditCourseDisplayName.Text, txtEditCourseShortName.Text, txtEditCourseDesc.Text, txtEditCourseSequenceNo.Text, ActiveFlag, UserID, "2");
                                
            //    if (ResultId == -1)
            //    {
            //        Show_Error_Success_Box("E", "Duplicate Course Name");
            //        return;
            //    }
            //    else
            //    {
            //        Show_Error_Success_Box("S", "Record Update Successfully.");
            //        FillGrid("%%", ddlDivisionEdit.SelectedValue);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Msg_Error.Visible = true;
            //    Msg_Success.Visible = false;
            //    lblerror.Text = ex.ToString();
            //    UpdatePanelMsgBox.Update();
            //    return;
            //}

        }

        #endregion
           
        #region Event's
        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            Clear_Error_Success_Box();   
            ControlVisibility("Add");
            ClearAddPanel();         
        }

        protected void BtnShowSearchPanel_Click(object sender, EventArgs e)
        {
            ControlVisibility("Search");
            BtnShowSearchPanel.Visible = false;
            Clear_Error_Success_Box();
        }

        protected void BtnCloseAdd_Click(object sender, EventArgs e)
        {
            ControlVisibility("Result");
            ClearAddPanel();     
            Clear_Error_Success_Box();
        }

        
        protected void BtnSaveAdd_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            Clear_Error_Success_Box();

            if (ddlProductCat_SR.SelectedIndex == 0 || ddlProductCat_SR.SelectedIndex == -1)
            {
                Show_Error_Success_Box("E", "Select Item Category");
                ddlProductCat_Add.Focus();
                return;
            }
            
            FillGrid(ddlProductCat_SR .SelectedValue .ToString (),txtItemName_SR .Text .Trim (),txtItemSKU_SR .Text .Trim (),txtBarcode_SR .Text .Trim (),txtMaterial_Code.Text.Trim());
        }

        protected void BtnClearSearch_Click(object sender, EventArgs e)
        {
            Clear_Error_Success_Box();
            ClearSearchPanel();
            
        }


        protected void btnEditSave_Click(object sender, EventArgs e)
        {
            UpdateData();
        }
        #endregion            

               
        
        protected void BtnSaveEdit_Click(object sender, EventArgs e)
        {
            try
            {
                Clear_Error_Success_Box();

                if (ddlProductCat_Add.SelectedIndex == 0 || ddlProductCat_Add.SelectedIndex == -1)
                {
                    Show_Error_Success_Box("E", "Select Item Category");
                    ddlProductCat_Add.Focus();
                    return;
                }

                if (txtItemName_Add.Text.Trim() == "")
                {
                    Show_Error_Success_Box("E", "Enter Item Name");
                    txtItemName_Add.Focus();
                    return;
                }


                if (ddlUOM_Add.SelectedIndex == 0 || ddlUOM_Add.SelectedIndex == -1)
                {
                    Show_Error_Success_Box("E", "Select UOM");
                    ddlUOM_Add.Focus();
                    return;
                }


                if (txtBarcode_Add.Text.Trim() == "")
                {
                    Show_Error_Success_Box("E", "Enter EAN No");
                    txtBarcode_Add.Focus();
                    return;
                }

                if (txtItemSKU_Add.Text.Trim() == "")
                {
                    Show_Error_Success_Box("E", "Enter Item SKU");
                    txtItemSKU_Add.Focus();
                    return;
                }
                if (ddlManufacture_Add.SelectedIndex == 0 || ddlManufacture_Add.SelectedIndex == -1)
                {
                    Show_Error_Success_Box("E", "Select Manufacture");
                    ddlManufacture_Add.Focus();
                    return;
                }

                if (ddlAssetNoType_Add.SelectedIndex == 0 || ddlAssetNoType_Add.SelectedIndex == -1)
                {
                    Show_Error_Success_Box("E", "Select Asset No Type");
                    ddlAssetNoType_Add.Focus();
                    return;
                }

                if (ddlAssetType_Add.SelectedIndex == 0 || ddlAssetType_Add.SelectedIndex == -1)
                {
                    Show_Error_Success_Box("E", "Select Asset Type");
                    ddlAssetType_Add.Focus();
                    return;
                }


                if (ddlExpenceType_Add.SelectedIndex == 0 || ddlExpenceType_Add.SelectedIndex == -1)
                {
                    Show_Error_Success_Box("E", "Select Expence Type");
                    ddlExpenceType_Add.Focus();
                    return;
                }





                Label lblHeader_User_Code = default(Label);
                lblHeader_User_Code = (Label)Master.FindControl("lblHeader_User_Code");

                string CreatedBy = null;
                HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                string UserID = cookie.Values["UserID"];
                CreatedBy = UserID;

                int ActiveFlag = 0;
                if (chkActive.Checked == true)
                    ActiveFlag = 1;
                else
                    ActiveFlag = 0;


                int FGStatus = 0;
                if (ChkFGStatus.Checked == true)
                    FGStatus = 1;
                else
                    FGStatus = 0;

                string ResultId = "";


                ResultId = ProductController.Insert_ItemMaster(4, lblPkey.Text, ddlProductCat_Add.SelectedValue.ToString().Trim(), txtItemName_Add.Text.Trim(),
                txtItemDesc_Add.Text.Trim(), ddlManufacture_Add.SelectedValue, txtBarcode_Add.Text.Trim(), txtItemSKU_Add.Text.Trim(),
                ddlUOM_Add.SelectedValue, ddlAssetNoType_Add.SelectedValue, ddlAssetType_Add.SelectedValue, ddlExpenceType_Add.SelectedValue,
                ActiveFlag, CreatedBy, FGStatus);

                if (ResultId == "-3")
                {
                    Clear_Error_Success_Box();
                    Msg_Error.Visible = true;
                    Msg_Success.Visible = false;
                    Show_Error_Success_Box("E", "Item Name not Exist");
                    return;
                }

                else if (ResultId == "-2")
                {
                    Clear_Error_Success_Box();
                    Msg_Error.Visible = true;
                    Msg_Success.Visible = false;
                    Show_Error_Success_Box("E", "Item SKU already Exist");
                    return;
                }


                else if (ResultId == "-4")
                {
                    Clear_Error_Success_Box();
                    Msg_Error.Visible = true;
                    Msg_Success.Visible = false;
                    Show_Error_Success_Box("E", "Item EAN No already Exist");
                    return;
                }
                else if (ResultId == "1")
                {

                    //

                    //FillGrid(ddlProductCat_SR.SelectedValue.ToString(), txtItemName_SR.Text.Trim(), txtItemSKU_SR.Text.Trim(), txtBarcode_SR.Text.Trim());
                    string childResult = "";
                    childResult = ProductController.Insert_ProductItemSpecification(lblPkey.Text, "", "", 0, "", 2);
                    if (childResult == "1")
                    {
                        childResult = "";
                        foreach (DataListItem item in dlItemSpecification.Items)
                        {
                            Label lblSpecification = (Label)item.FindControl("lblSpecification");
                            Label lblItem_Code = (Label)item.FindControl("lblItem_Code");
                            TextBox txtSpecDescription = (TextBox)item.FindControl("txtSpecDescription");
                            childResult = ProductController.Insert_ProductItemSpecification(lblPkey.Text, lblSpecification.Text, txtSpecDescription.Text.Trim(), 1, CreatedBy, 1);
                        }
                    }
                   ControlVisibility("Search");
                    BtnSearch_Click(this, e);
                    Show_Error_Success_Box("S", "Record updated successfully.");
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

        protected void btnUserMenuSave_Click(object sender, EventArgs e)
        {
            //string Menucode = lblmenuPK.Text.Trim();
            //string resid = null;

            
            //foreach (DataListItem dtlItem in DLUserMenu01.Items)
            //{
            //    System.Web.UI.HtmlControls.HtmlInputCheckBox chkCheck = (System.Web.UI.HtmlControls.HtmlInputCheckBox)dtlItem.FindControl("chkCheck");
            //    if (chkCheck.Checked == true)
            //    {

            //        Label lblRoleCode = (Label)dtlItem.FindControl("lblRoleCode");

            //        resid = ProductController.Usp_DelUpdate_RoleMenuCode(Menucode, lblRoleCode.Text.Trim(), 8);

            //    }

            //}


            //if (resid == "1")
            //{
            //    ControlVisibility("Result");
            //    BtnSearch_Click(sender, e);
            //    Show_Error_Success_Box("S", "Record Save Successfully");

            //}
            //else
            //{
            //    ControlVisibility("Result");
            //}
        


        }

        protected void btnUserMenuClose_Click(object sender, EventArgs e)
        {
            //FillGrid(ddlSupplier_SR.SelectedValue.ToString().Trim());
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
       
        

        protected void btnSearchItem_Click(object sender, EventArgs e)
        {
            //Clear_Error_Success_Box();

            //if (txtItemMatCode.Text.Trim() == "")
            //{
            //    Show_Error_Success_Box("E", "Enter Material Code");
            //    txtItemMatCode.Focus();
            //    return;
            //}

            //DataSet dsSupplier = ProductController.GetItem_ByAll(txtItemMatCode.Text.Trim(), 1);
            //ClearItemAdd();

            //if (dsSupplier.Tables[0].Rows.Count > 0)
            //{
            //    if (dsSupplier.Tables[0].Rows.Count == 1)
            //    {
            //        lblMateCode.Text = dsSupplier.Tables[0].Rows[0]["Item_Id"].ToString();
            //        lblItemName.Text = dsSupplier.Tables[0].Rows[0]["Item_Name"].ToString();
            //        lblUnit.Text = dsSupplier.Tables[0].Rows[0]["UOM_Name"].ToString();
            //    }
            //    else if (dsSupplier.Tables[0].Rows.Count >= 1)
            //    {
            //        DataList3.DataSource = dsSupplier;
            //        DataList3.DataBind();
            //        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalDivOverride();", true);
            //        //UpdatePanel1.Update();
            //    }
                
            //}

            //tr1.Visible = true;
            //tr2.Visible = true;
            
        }
        protected void btnClearItem_Click(object sender, EventArgs e)
        {
            //ClearItemAdd();
            //tr1.Visible = false;
            //tr2.Visible = false;
        }
        protected void txtItemRate_TextChanged(object sender, EventArgs e)
        {
            //Clear_Error_Success_Box();

            //if (txtItemQty.Text.Trim() == "")
            //{
            //    Show_Error_Success_Box("E", "Enter Item Quantity");
            //    txtItemQty.Focus();
            //    return;
            //}
            //int Qty1=0, Rate1=0;
            //double Qty,Rate;
            //if (double.TryParse(txtItemQty.Text.Trim(), out Qty))
            //{
            //    Qty1 = Convert.ToInt32(txtItemQty.Text.Trim());

            //}
            //else
            //{
            //    Show_Error_Success_Box("E", "Enter Numeric only");
            //    txtItemQty.Focus();
            //    return;
            //}

            //if (double.TryParse(txtItemRate.Text.Trim(), out Rate))
            //{
            //    Rate1 = Convert.ToInt32(txtItemRate.Text.Trim());

            //}
            //else
            //{
            //    Show_Error_Success_Box("E", "Enter Numeric only");
            //    txtItemQty.Focus();
            //    return;
            //}

            //int CalAns = Qty1 * Rate1;

            //lblCalValue.Text = CalAns.ToString();

        }

        protected void dlGridDisplay_ItemCommand1(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "comEdit")
            {
                lblPkey.Text = "";
                ControlVisibility("Add");
                BtnSaveEdit.Visible = true;
                BtnSaveAdd.Visible = false;
                ClearAddPanel();
                
                FillDDL_UOM();
                FillDDL_AssetNoType();
                FillDDL_AssetType();
                FillDDL_ExpenceType();
                FillDDL_Manufacture();


                Clear_Error_Success_Box();
                lblPkey.Text = e.CommandArgument.ToString();
                DataSet ds = ProductController.Get_Edit_ItemDetails(6, lblPkey.Text.Trim());

                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlProductCat_Add.SelectedValue = ds.Tables[0].Rows[0]["Category_Code"].ToString();
                    txtItemName_Add.Text = ds.Tables[0].Rows[0]["Item_Name"].ToString();
                    txtMaterils.Text = ds.Tables[0].Rows[0]["Item_code"].ToString();
                    txtMaterils.Enabled = false;
                    txtItemDesc_Add.Text = ds.Tables[0].Rows[0]["Item_Description"].ToString();                    
                    ddlUOM_Add.SelectedValue = ds.Tables[0].Rows[0]["Unit_Code"].ToString();                    
                    txtBarcode_Add.Text = ds.Tables[0].Rows[0]["Item_EAN_No"].ToString();
                    txtItemSKU_Add.Text = ds.Tables[0].Rows[0]["Item_SKU"].ToString();

                    if (ddlExpenceType_Add.Items.FindByValue(ds.Tables[0].Rows[0]["Expense_Type_Id"].ToString()) != null)
                    {
                        ddlExpenceType_Add.SelectedValue = ds.Tables[0].Rows[0]["Expense_Type_Id"].ToString();
                    }

                    if (ddlAssetType_Add.Items.FindByValue(ds.Tables[0].Rows[0]["Asset_Type_Id"].ToString()) != null)
                    {
                        ddlAssetType_Add.SelectedValue = ds.Tables[0].Rows[0]["Asset_Type_Id"].ToString();
                    }

                    if (ddlAssetNoType_Add.Items.FindByValue(ds.Tables[0].Rows[0]["AssetsNo_Type_Id"].ToString()) != null)
                    {
                        ddlAssetNoType_Add.SelectedValue = ds.Tables[0].Rows[0]["AssetsNo_Type_Id"].ToString();
                    }
                    string Result = ProductController.Asset_Type_enable(11, lblPkey.Text.Trim());
                    if (Result == "1")// material entry not in transaction tables
                    {
                        ddlAssetNoType_Add.Enabled = true;
                       // ChkFGStatus.Disabled = false;
                    }
                    else if (Result == "-1")
                    {
                        ddlAssetNoType_Add.Enabled = false;
                        //ChkFGStatus.Disabled = true;
                    }

                    if (ddlManufacture_Add.Items.FindByValue(ds.Tables[0].Rows[0]["Manufacturer_Code"].ToString()) != null)
                    {
                        ddlManufacture_Add.SelectedValue = ds.Tables[0].Rows[0]["Manufacturer_Code"].ToString();
                    }
                   
                    if (Convert.ToInt32(ds.Tables[0].Rows[0]["Is_Active"]) == 0)
                    {
                        chkActive.Checked = false;
                    }
                    else
                    {
                        chkActive.Checked = true;
                    }


                    //
                    if (Convert.ToInt32(ds.Tables[0].Rows[0]["FG_Status_id"]) == 0)
                    {
                        ChkFGStatus.Checked = false;
                    }
                    else
                    {
                        ChkFGStatus.Checked = true;
                    }

                    //

                   
                    if (ds.Tables[1] != null)
                    {
                        if (ds.Tables[1].Rows.Count != 0)
                        {
                            dlItemSpecification.DataSource = null;
                            dlItemSpecification.DataBind();
                            dlItemSpecification.DataSource = ds.Tables[1];
                            dlItemSpecification.DataBind();
                        }
                        else
                        {
                            FillDDL_ItemSpecification();
                        }
                    }
                    else
                    {
                        FillDDL_ItemSpecification();
                    }


                   
                }
            }
        }
        protected void ddlProductCat_Add_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillDDL_ItemSpecification();
        }
}


