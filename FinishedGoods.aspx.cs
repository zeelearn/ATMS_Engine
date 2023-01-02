using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ShoppingCart.BL;
using System.IO;
using System.Data.SqlClient;


public partial class FinishedGoods : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillDDL_TransferType();
            FillDDL_Division();
            FillDDL_Godown();
            FillDDL_Function();
            FillDDL_FRSearch_Centre();
            DivResultPanel.Visible = false;
            DivAdd.Visible = false;
            //FillDDL_Logistic();

        }

    }
    private void FillDDL_TransferType()
    {
        //Search DDL
        DataSet dsTransfer_Tp = ProductController.GetAllTransferType(1);
        BindDDL(ddlLocationType, dsTransfer_Tp, "Transfer_Location_Type_Name", "Transfer_Location_Type_ID");
        ddlLocationType.Items.Insert(0, "Select Location");
        ddlLocationType.SelectedIndex = 0;

        BindDDL(ddlAddLocationType, dsTransfer_Tp, "Transfer_Location_Type_Name", "Transfer_Location_Type_ID");
        ddlAddLocationType.Items.Insert(0, "Select Location");
        ddlAddLocationType.SelectedIndex = 0;


    }

    private void FillDDL_Godown()
    {

        DataSet dsGodown = ProductController.GetGodown_Function_Logistic_Assests_Type(1);


        BindDDL(ddlgodownFR_SR, dsGodown, "Godown_Name", "Godown_Id");
        ddlgodownFR_SR.Items.Insert(0, "Select");
        ddlgodownFR_SR.SelectedIndex = 0;


        BindDDL(ddladdGodown, dsGodown, "Godown_Name", "Godown_Id");
        ddladdGodown.Items.Insert(0, "Select");
        ddladdGodown.SelectedIndex = 0;


    }
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
            //tbladdFr_Godown.Visible = true;

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
        else if (ddlLocationType.SelectedIndex == 0)
        {
            tblFr_Godown.Visible = false;
            tblFr_Function.Visible = false;
            tblFr_Division.Visible = false;
            tblFr_Center.Visible = false;
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

        BindDDL(ddladdDivision, dsDivision, "Division_Name", "Division_Code");
        ddladdDivision.Items.Insert(0, "Select");
        ddladdDivision.SelectedIndex = 0;



    }


    private void FillDDL_Function()
    {

        DataSet dsFunction = ProductController.GetGodown_Function_Logistic_Assests_Type(2);



        BindDDL(ddlFunctionFR_SR, dsFunction, "Function_Name", "Function_Id");
        ddlFunctionFR_SR.Items.Insert(0, "Select");
        ddlFunctionFR_SR.SelectedIndex = 0;


        BindDDL(ddladdFunction, dsFunction, "Function_Name", "Function_Id");
        ddladdFunction.Items.Insert(0, "Select");
        ddladdFunction.SelectedIndex = 0;
    }
    //protected void ddlgodownFR_SR_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddlgodownFR_SR.SelectedIndex == 0 || ddlgodownFR_SR.SelectedIndex == -1)
    //    {
    //        Show_Error_Success_Box("E", "Selec Godown");
    //        ddlgodownFR_SR.Focus();
    //        ddlRequestCode_Add.Items.Clear();
    //        return;

    //    }

    //    FillDDL_Requisition_No(ddlLocationType.SelectedValue.ToString().Trim(), ddlgodownFR_SR.SelectedValue.ToString().Trim(), 5);

    //}


    private void FillDDL_FRADDSearch_Centre()
    {
        string Company_Code = "MT";
        string DBname = "CDB";

        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];

        string Div_Code = null;
        Div_Code = ddladdDivision.SelectedValue;


        DataSet dsCentre = ProductController.GetAllActiveUser_Company_Division_Zone_Center(UserID, Company_Code, Div_Code, "", "5", DBname);

        BindDDL(ddlCenterFR_SR, dsCentre, "Center_Name", "Center_Code");
        ddlCenterFR_SR.Items.Insert(0, "Select");
        ddlCenterFR_SR.SelectedIndex = 0;

        BindDDL(ddladdCenter, dsCentre, "Center_Name", "Center_Code");
        ddladdCenter.Items.Insert(0, "Select");
        ddladdCenter.SelectedIndex = 0;
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

        BindDDL(ddladdCenter, dsCentre, "Center_Name", "Center_Code");
        ddladdCenter.Items.Insert(0, "Select");
        ddladdCenter.SelectedIndex = 0;
    }


    protected void ddlAddLocationType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlAddLocationType.SelectedItem.ToString().Trim() == "Godown")
        {

            tbladdFr_Godown.Visible = true;

            tbladdFr_Function.Visible = false;
            tbladdFr_Division.Visible = false;
            tbladdFr_Center.Visible = false;

        }
        else if (ddlAddLocationType.SelectedItem.ToString().Trim() == "Function")
        {
            tbladdFr_Function.Visible = true;
            tbladdFr_Godown.Visible = false;
            tbladdFr_Division.Visible = false;
            tbladdFr_Center.Visible = false;
        }
        else if (ddlAddLocationType.SelectedItem.ToString().Trim() == "Center")
        {
            tbladdFr_Division.Visible = true;
            tbladdFr_Center.Visible = true;
            tbladdFr_Function.Visible = false;
            tbladdFr_Godown.Visible = false;

            //Fill Division
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];

        }
        else if (ddlAddLocationType.SelectedIndex == 0)
        {
            tbladdFr_Godown.Visible = false;
            tbladdFr_Function.Visible = false;
            tbladdFr_Division.Visible = false;
            tbladdFr_Center.Visible = false;
        }
    }

    protected void ddlDivisionFR_SR_SelectedIndexChanged(object sender, EventArgs e)
    {
        //ddlCenterFR_SR.Items.Clear();
        FillDDL_FRSearch_Centre();
    }
    protected void ddladdDivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        //ddladdCenter.Items.Clear();
        FillDDL_FRADDSearch_Centre();
    }
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        btnAdd.Visible = false;

        try
        {
            Clear_Error_Success_Box();
            if (ddlLocationType.SelectedIndex == 0 || ddlLocationType.SelectedIndex == -1)
            {
                Show_Error_Success_Box("E", "Select Location Type");
                ddlLocationType.Focus();
                return;

            }

            if (ddlLocationType.SelectedItem.Text == "Godown" && ddlgodownFR_SR.SelectedIndex == 0)
            {
                Show_Error_Success_Box("E", "Select Godown Name");
                ddlgodownFR_SR.Focus();
                return;
            }
            if (ddlLocationType.SelectedItem.Text == "Center" && ddlDivisionFR_SR.SelectedIndex == 0)
            {
                Show_Error_Success_Box("E", "Select Division Name");
                ddlDivisionFR_SR.Focus();
                return;

            }
            if (ddlLocationType.SelectedItem.Text == "Function" && ddlFunctionFR_SR.SelectedIndex == 0)
            {
                Show_Error_Success_Box("E", "Select  Function");
                ddlFunctionFR_SR.Focus();
                return;

            }

            if (ddlLocationType.SelectedItem.Text == "Center" && ddlCenterFR_SR.SelectedIndex == 0)
            {
                Show_Error_Success_Box("E", "Select  Center");
                ddladdCenter.Focus();
                return;
            }
            if (ddlDivisionFR_SR.SelectedIndex != 0 && ddlCenterFR_SR.SelectedIndex == 0)
            {
                Show_Error_Success_Box("E", "Select Center");
                ddlCenterFR_SR.Focus();
                return;
            }

            FillGrid();

        }

        catch (Exception ex)
        {
            Msg_Error.Visible = true;
            Msg_Success.Visible = false;
            lblerror.Text = ex.ToString();
            UpdatePanelMsgBox.Update();
            DivResultPanel.Visible = true;
            DivSearchPanel1.Visible = false;
            DivAdd.Visible = false;



            return;
        }
    }




    protected void dlQuestion_ItemCommand(object source, DataListCommandEventArgs e)
    {


        if (e.CommandName == "ItemRemove")
        {
            lblCodeRemove.Text = e.CommandArgument.ToString().Trim();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalDivCOnfirmation();", true);

        }

    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {

        try
        {

            Clear_Error_Success_Box();
            string Location = "";
            if (ddlLocationType.SelectedIndex == 0)
            {
                Show_Error_Success_Box("E", "Select Location Type");
                ddlLocationType.Focus();
                return;

            }
            ddlAddLocationType.SelectedValue = ddlLocationType.SelectedValue;
            ddlAddLocationType_SelectedIndexChanged(sender, e);

            if (ddlLocationType.SelectedItem.ToString() == "Godown")
            {


                if (ddlgodownFR_SR.SelectedIndex == 0)
                {

                    Show_Error_Success_Box("E", "Select Godown");
                    ddlgodownFR_SR.Focus();
                    return;
                }
                else
                {
                    ddladdGodown.SelectedValue = ddlgodownFR_SR.SelectedValue;
                    Location = ddlgodownFR_SR.SelectedValue;
                }
            }

            else if (ddlLocationType.SelectedItem.ToString() == "Function")
            {


                if (ddlFunctionFR_SR.SelectedIndex == 0)
                {

                    Show_Error_Success_Box("E", "Select Function");
                    ddlFunctionFR_SR.Focus();
                    return;
                }
                else
                {
                    ddladdFunction.SelectedValue = ddlFunctionFR_SR.SelectedValue;
                    Location = ddlFunctionFR_SR.SelectedValue;
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
                    ddladdDivision.SelectedValue = ddlDivisionFR_SR.SelectedValue.ToString();
                    ddladdDivision_SelectedIndexChanged(sender, e);
                    ddladdCenter.SelectedValue = ddlCenterFR_SR.SelectedValue;
                    Location = ddlCenterFR_SR.SelectedValue;
                }

            }


            ControlVisibility("Add");


        }


        catch (Exception ex)
        {
            Msg_Error.Visible = true;
            Msg_Success.Visible = false;
            lblerror.Text = ex.ToString();
            UpdatePanelMsgBox.Update();
            DivResultPanel.Visible = true;
            DivSearchPanel1.Visible = false;
            DivAdd.Visible = false;



            return;
        }



    }

    protected void BtnClearSearch_Click(object sender, EventArgs e)
    {
        ClearSearchPanel();

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Clear_Error_Success_Box();
        DivAdd.Visible = false;
        DivSearchPanel1.Visible = false;
        DivResultPanel.Visible = true;
        btnAdd.Visible = true;
    }
    private void Clear_Error_Success_Box()
    {
        Msg_Error.Visible = false;
        Msg_Success.Visible = false;
        lblSuccess.Text = "";
        lblerror.Text = "";
        UpdatePanelMsgBox.Update();
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
    private void ClearItemAdd()
    {
        lblMateCode.Text = "";
        lblItemName.Text = "";
        lblUnit.Text = "";
        txtItemRate.Text = "";
        txtItemMatCode.Text = "";
        txtItemQty.Text = "";
        lblapproveremark.Text = "";

    }

    protected void btnSearchItem_ServerClick(object sender, EventArgs e)
    {
        Clear_Error_Success_Box();

        if (txtItemMatCode.Text.Trim() == "")
        {
            Show_Error_Success_Box("E", "Enter Item");
            txtItemMatCode.Focus();
            return;
        }


        string From_Location_Type_Code = "";
        string From_Location_Code = "";

        From_Location_Type_Code = ddlAddLocationType.SelectedValue;


        if (ddlAddLocationType.SelectedItem.Text == "Godown")
        {
            From_Location_Code = ddladdGodown.SelectedValue;
        }
        else if (ddlAddLocationType.SelectedItem.Text == "Function")
        {
            From_Location_Code = ddladdFunction.SelectedValue;
        }
        else if (ddlAddLocationType.SelectedItem.Text == "Center")
        {
            From_Location_Code = ddladdCenter.SelectedValue;
        }


        string Pkey2 = "", TempPkey = "";
        foreach (DataListItem item in dlQuestion.Items)
        {
            if (item.ItemType == ListItemType.Item | item.ItemType == ListItemType.AlternatingItem)
            {
                Label lblItem_Code_DT = (Label)item.FindControl("lblItem_Code_DT");
                Label lblAssetNo_DT = (Label)item.FindControl("lblAssetNo_DT");
                Label lblInward_Code = (Label)item.FindControl("lblInward_Code");
                Label lblInwardEntry_Code_DL = (Label)item.FindControl("lblInwardEntry_Code_DL");
                Label lblQty_DT = (Label)item.FindControl("lblQty_DT");

                TempPkey = lblItem_Code_DT.Text.Trim() + "%" + lblAssetNo_DT.Text.Trim() + "%" + lblInward_Code.Text.Trim() + "%" + lblInwardEntry_Code_DL.Text.Trim() + "%" + lblQty_DT.Text.Trim();

                Pkey2 = Pkey2 + TempPkey + ",";
            }

        }

        Pkey2 = Common.RemoveComma(Pkey2);

        int OptionCode = 0;
        OptionCode = Convert.ToInt32(Request.QueryString["OptionCode"]);

        //DataSet dsSupplier = ProductController.GetItemForFinishedGoods(txtItemMatCode.Text.Trim(), 2, From_Location_Type_Code, From_Location_Code, ddlRequestCode_Add.SelectedValue.ToString().Trim(), RequestEntry_Code, Pkey2, OptionCode);
        DataSet dsSupplier = ProductController.GetItemForFinishedGoods(txtItemMatCode.Text.Trim(), 2, From_Location_Type_Code, From_Location_Code, "", "", Pkey2, OptionCode);


        ClearItemAdd();
        if (dsSupplier.Tables[0].Rows.Count > 0)
        {
            if (dsSupplier.Tables[0].Rows.Count == 1)
            {
                lblMateCode.Text = dsSupplier.Tables[0].Rows[0]["Item_Code"].ToString();
                lblItemName.Text = dsSupplier.Tables[0].Rows[0]["Item_Name"].ToString();
                lblUnit.Text = dsSupplier.Tables[0].Rows[0]["UOM_Name"].ToString();
                txtItemRate.Text = dsSupplier.Tables[0].Rows[0]["Purchase_Rate"].ToString();
                string itemtype = dsSupplier.Tables[0].Rows[0]["AssetsNo_Type_Id"].ToString();
                int Current_Qty = Convert.ToInt32(dsSupplier.Tables[0].Rows[0]["Current_Qty"].ToString());
                lblCurrentQty.Text = Current_Qty.ToString();

                lblInwardEntry_Code.Text = dsSupplier.Tables[0].Rows[0]["InwardEntry_Code"].ToString();
                lblInward_Code.Text = dsSupplier.Tables[0].Rows[0]["Inward_Code"].ToString();
                lblInward_Qty.Text = dsSupplier.Tables[0].Rows[0]["Inward_Qty"].ToString();
                lblRequestEntry_Code_Item.Text = dsSupplier.Tables[0].Rows[0]["Request_EntryCode"].ToString();
                lblPkey2_Grid.Text = dsSupplier.Tables[0].Rows[0]["Pkey2"].ToString();

                lblAssetStatus_Grid.Text = dsSupplier.Tables[0].Rows[0]["AssetStatus_Id"].ToString();
                lblAssetFGStatus_Grid.Text = dsSupplier.Tables[0].Rows[0]["Asset_FG_Status"].ToString();
                lblAssetCondition_Grid.Text = dsSupplier.Tables[0].Rows[0]["Asset_Condition_id"].ToString();

                lblSearchAddItem.Text = dsSupplier.Tables[0].Rows[0]["Pkey"].ToString();
                if (itemtype == "ATN00000001")
                {
                    txtItemQty.Enabled = true;
                }
                else if (itemtype == "ATN00000002")
                {
                    txtItemQty.Enabled = false;
                }
                else if (itemtype == "ATN00000003")
                {
                    txtItemQty.Enabled = false;
                }


                txtItemQty.Text = "1";

                lblCalValue.Text = "";
                int itemQty = 0;
                decimal Rate1 = 0;
                if (txtItemQty.Text == "")
                {
                    itemQty = 1;
                }
                else
                {
                    itemQty = Convert.ToInt32(txtItemQty.Text);
                }
                if (txtItemRate.Text == "")
                {
                    Rate1 = 0;
                }
                else
                {

                    Rate1 = Convert.ToDecimal(string.Format("{0:F2}", txtItemRate.Text));

                }

                decimal CalAns = itemQty * Rate1;

                lblCalValue.Text = CalAns.ToString();
            }
            else if (dsSupplier.Tables[0].Rows.Count >= 1)
            {
                DataList3.DataSource = dsSupplier;
                DataList3.DataBind();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalDivOverride();", true);

            }

        }
        else
        {
            Show_Error_Success_Box("E", "Record not found");
            return;
        }

        tr1.Visible = true;
        tr2.Visible = true;


    }

    protected void DataList3_ItemCommand(object source, DataListCommandEventArgs e)
    {

        if (e.CommandName == "comSetItem")
        {
            ClearItemAdd();
            Clear_Error_Success_Box();

            string MaterialCode = e.CommandArgument.ToString();
            lblSearchAddItem.Text = MaterialCode;

            string From_Location_Type_Code = "";
            string From_Location_Code = "";

            From_Location_Type_Code = ddlAddLocationType.SelectedValue;


            if (ddlAddLocationType.SelectedItem.Text == "Godown")
            {
                From_Location_Code = ddladdGodown.SelectedValue;
            }
            else if (ddlAddLocationType.SelectedItem.Text == "Function")
            {
                From_Location_Code = ddladdFunction.SelectedValue;
            }
            else if (ddlAddLocationType.SelectedItem.Text == "Center")
            {
                From_Location_Code = ddladdCenter.SelectedValue;
            }

            //
            DataSet dsSupplier = null;

            string Pkey2 = "", TempPkey = "";
            foreach (DataListItem item in dlQuestion.Items)
            {
                if (item.ItemType == ListItemType.Item | item.ItemType == ListItemType.AlternatingItem)
                {
                    Label lblItem_Code_DT = (Label)item.FindControl("lblItem_Code_DT");
                    Label lblAssetNo_DT = (Label)item.FindControl("lblAssetNo_DT");
                    Label lblInward_Code = (Label)item.FindControl("lblInward_Code");
                    Label lblInwardEntry_Code_DL = (Label)item.FindControl("lblInwardEntry_Code_DL");
                    Label lblQty_DT = (Label)item.FindControl("lblQty_DT");

                    TempPkey = lblItem_Code_DT.Text.Trim() + "%" + lblAssetNo_DT.Text.Trim() + "%" + lblInward_Code.Text.Trim() + "%" + lblInwardEntry_Code_DL.Text.Trim() + "%" + lblQty_DT.Text.Trim();

                    Pkey2 = Pkey2 + TempPkey + ",";
                }

            }

            Pkey2 = Common.RemoveComma(Pkey2);

            int OptionCode = 0;
            OptionCode = Convert.ToInt32(Request.QueryString["OptionCode"]);


            dsSupplier = ProductController.GetItemForFinishedGoods(MaterialCode, 3, From_Location_Type_Code, From_Location_Code, txtRequestCode.Text.Trim(), "", Pkey2, OptionCode);

            //

            if (dsSupplier.Tables[0].Rows.Count > 0)
            {
                lblMateCode.Text = dsSupplier.Tables[0].Rows[0]["Item_Code"].ToString();
                lblItemName.Text = dsSupplier.Tables[0].Rows[0]["Item_Name"].ToString();
                lblUnit.Text = dsSupplier.Tables[0].Rows[0]["UOM_Name"].ToString();
                txtItemRate.Text = dsSupplier.Tables[0].Rows[0]["Purchase_Rate"].ToString();
                string itemtype = dsSupplier.Tables[0].Rows[0]["AssetsNo_Type_Id"].ToString();
                int Current_Qty = Convert.ToInt32(dsSupplier.Tables[0].Rows[0]["Current_Qty"].ToString());

                lblCurrentQty.Text = Current_Qty.ToString();
                txtItemQty.Text = "1";
                lblInwardEntry_Code.Text = dsSupplier.Tables[0].Rows[0]["InwardEntry_Code"].ToString();
                lblInward_Code.Text = dsSupplier.Tables[0].Rows[0]["Inward_Code"].ToString();
                lblInward_Qty.Text = dsSupplier.Tables[0].Rows[0]["Inward_Qty"].ToString();
                lblRequestEntry_Code_Item.Text = dsSupplier.Tables[0].Rows[0]["Request_EntryCode"].ToString();
                lblPkey2_Grid.Text = dsSupplier.Tables[0].Rows[0]["Pkey2"].ToString();

                lblAssetStatus_Grid.Text = dsSupplier.Tables[0].Rows[0]["AssetStatus_Id"].ToString();
                lblAssetFGStatus_Grid.Text = dsSupplier.Tables[0].Rows[0]["Asset_FG_Status"].ToString();
                lblAssetCondition_Grid.Text = dsSupplier.Tables[0].Rows[0]["Asset_Condition_id"].ToString();

                if (itemtype == "ATN00000001")
                {
                    txtItemQty.Enabled = true;
                }
                else if (itemtype == "ATN00000002")
                {
                    txtItemQty.Enabled = false;
                }
                else if (itemtype == "ATN00000003")
                {
                    txtItemQty.Enabled = false;
                }


                lblCalValue.Text = "";
                int itemQty = 0;
                decimal Rate1 = 0;
                if (txtItemQty.Text == "")
                {
                    itemQty = 1;
                }
                else
                {
                    itemQty = Convert.ToInt32(txtItemQty.Text);
                }
                if (txtItemRate.Text == "")
                {
                    Rate1 = 0;
                }
                else
                {

                    Rate1 = Convert.ToDecimal(string.Format("{0:F2}", txtItemRate.Text));

                }

                decimal CalAns = itemQty * Rate1;

                lblCalValue.Text = CalAns.ToString();


            }
        }


    }



    public void FillTotalDetails_Temp()
    {
        int Total_Item_Count = 0;
        int Total_Quantity = 0;

        foreach (DataListItem item in dlQuestion.Items)
        {
            if (item.ItemType == ListItemType.Item | item.ItemType == ListItemType.AlternatingItem)
            {
                Label lblValue_DT = (Label)item.FindControl("lblValue_DT");
                Label lblQty_DT = (Label)item.FindControl("lblQty_DT");

                Total_Item_Count = Total_Item_Count + 1;


                Total_Quantity = Total_Quantity + Convert.ToInt32(lblQty_DT.Text.Trim());
            }
        }

        txtTotalItems.Text = Total_Item_Count.ToString();
        txtTotalQuantity.Text = Total_Quantity.ToString();

    }

    protected void btnSaveItem_ServerClick(object sender, EventArgs e)
    {
        Clear_Error_Success_Box();
        if (lblMateCode.Text.Trim() == "")
        {
            Show_Error_Success_Box("E", "Select Item");
            return;
        }

        if (txtItemQty.Text.Trim() == "")
        {
            Show_Error_Success_Box("E", "Enter Item Quantity");
            txtItemQty.Focus();
            return;
        }

        if (Convert.ToInt32(txtItemQty.Text.Trim()) > Convert.ToInt32(lblCurrentQty.Text))
        {
            Show_Error_Success_Box("E", "Item Quantity can't be greater than stock Quantity");
            txtItemQty.Focus();
            return;
        }


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
        _with1.Columns.Add("InwardEntry_Code");
        _with1.Columns.Add("Inward_Code");
        _with1.Columns.Add("Inward_Qty");
        _with1.Columns.Add("Is_Authorised");
        _with1.Columns.Add("Request_EntryCode");
        _with1.Columns.Add("Pkey2");

        _with1.Columns.Add("AssetStatusId");
        _with1.Columns.Add("AssetFGStatus");
        _with1.Columns.Add("AssetCondition");



        int itemcount = 0;
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

                Label lblInward_Code = (Label)item.FindControl("lblInward_Code");
                Label lblInwardEntry_Code_DL = (Label)item.FindControl("lblInwardEntry_Code_DL");
                Label Inward_Qty = (Label)item.FindControl("Inward_Qty");
                Label Is_Authorised = (Label)item.FindControl("Is_Authorised");
                Label lblRequestEntry_Code_Grid = (Label)item.FindControl("lblRequestEntry_Code_Grid");
                Label lblPkey2 = (Label)item.FindControl("lblPkey2");

                Label lblAssetStatus = (Label)item.FindControl("lblAssetStatus");
                Label lblAssetFGStatus = (Label)item.FindControl("lblAssetFGStatus");
                Label lblAssetCondition = (Label)item.FindControl("lblAssetCondition");

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

                NewRow["InwardEntry_Code"] = lblInwardEntry_Code_DL.Text.Trim();
                NewRow["Inward_Code"] = lblInward_Code.Text.Trim();
                NewRow["Inward_Qty"] = Inward_Qty.Text.Trim();
                NewRow["Is_Authorised"] = Is_Authorised.Text.Trim();
                NewRow["Request_EntryCode"] = lblRequestEntry_Code_Grid.Text.Trim();
                NewRow["Pkey2"] = lblPkey2.Text.Trim();

                NewRow["AssetStatusId"] = lblAssetStatus.Text.Trim();
                NewRow["AssetFGStatus"] = lblAssetFGStatus.Text.Trim();
                NewRow["AssetCondition"] = lblAssetCondition.Text.Trim();
                itemcount++;


                Total_Quantity = Total_Quantity + Convert.ToInt32(lblQty_DT.Text.Trim());
                Total_Amount = Total_Amount + Convert.ToDecimal(lblAmount_DT.Text.Trim());


                NewRow["Pkey"] = itemcount.ToString();

                dtCorrectEntry.Rows.Add(NewRow);


            }
        }

        ////
        //temp data

        DataTable dtTempEntry = new DataTable();
        DataRow NewRow1 = null;


        var _with2 = dtTempEntry;
        _with2.Columns.Add("Dispatch_Code");
        _with2.Columns.Add("DispatchEntry_Code");
        _with2.Columns.Add("Item_Code");
        _with2.Columns.Add("Item_Name");
        _with2.Columns.Add("Purchase_Amount");
        _with2.Columns.Add("Purchase_Rate");
        _with2.Columns.Add("Barcode");
        _with2.Columns.Add("Dispatch_Qty");
        _with2.Columns.Add("Asset_No");
        _with2.Columns.Add("Pkey");
        _with2.Columns.Add("InwardEntry_Code");
        _with2.Columns.Add("Inward_Code");
        _with2.Columns.Add("Inward_Qty");
        _with2.Columns.Add("Is_Authorised");
        _with2.Columns.Add("Request_EntryCode");

        int itemcount1 = 0;
        int Total_Item_Count1 = 0;
        int Total_Quantity1 = 0;
        decimal Total_Amount1 = 0;

        foreach (DataListItem item in DataList2.Items)
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

                Label lblInward_Code = (Label)item.FindControl("lblInward_Code");
                Label lblInwardEntry_Code_DL = (Label)item.FindControl("lblInwardEntry_Code_DL");
                Label Inward_Qty = (Label)item.FindControl("Inward_Qty");
                Label Is_Authorised = (Label)item.FindControl("Is_Authorised");
                Label lblRequestEntry_Code_Grid = (Label)item.FindControl("lblRequestEntry_Code_Grid");

                NewRow1 = dtTempEntry.NewRow();
                NewRow1["Dispatch_Code"] = lblDispatch_Code.Text.Trim();
                NewRow1["DispatchEntry_Code"] = lblDispatchEntry_Code.Text.Trim();
                NewRow1["Item_Code"] = lblItem_Code_DT.Text.Trim();
                NewRow1["Item_Name"] = lblItemName_DT.Text.Trim();
                NewRow1["Barcode"] = lblBarcode_DT.Text.Trim();
                NewRow1["Asset_No"] = lblAssetNo_DT.Text.Trim();
                NewRow1["Dispatch_Qty"] = lblQty_DT.Text.Trim();
                NewRow1["Purchase_Rate"] = lblUnitPrice_DT.Text.Trim();
                NewRow1["Purchase_Amount"] = lblAmount_DT.Text.Trim();

                NewRow1["InwardEntry_Code"] = lblInwardEntry_Code_DL.Text.Trim();
                NewRow1["Inward_Code"] = lblInward_Code.Text.Trim();
                NewRow1["Inward_Qty"] = Inward_Qty.Text.Trim();
                NewRow1["Is_Authorised"] = Is_Authorised.Text.Trim();
                NewRow1["Request_EntryCode"] = lblRequestEntry_Code_Grid.Text.Trim();

                itemcount1++;


                Total_Quantity1 = Total_Quantity1 + Convert.ToInt32(lblQty_DT.Text.Trim());
                Total_Amount1 = Total_Amount1 + Convert.ToDecimal(lblAmount_DT.Text.Trim());


                NewRow1["Pkey"] = itemcount1.ToString();

                dtTempEntry.Rows.Add(NewRow1);


            }
        }


        ////



        string From_Location_Type_Code = "";
        string From_Location_Code = "";

        From_Location_Type_Code = ddlAddLocationType.SelectedValue;


        if (ddlAddLocationType.SelectedItem.Text == "Godown")
        {
            From_Location_Code = ddladdGodown.SelectedValue;
        }
        else if (ddlAddLocationType.SelectedItem.Text == "Function")
        {
            From_Location_Code = ddladdFunction.SelectedValue;
        }
        else if (ddlAddLocationType.SelectedItem.Text == "Center")
        {
            From_Location_Code = ddladdCenter.SelectedValue;
        }




        DataSet dsSupplier = ProductController.GetItemForDispatch(lblSearchAddItem.Text, 3, From_Location_Type_Code, From_Location_Code, "", "", "");

        if (dsSupplier.Tables[0].Rows.Count > 0)
        {
            if (dsSupplier.Tables[0].Rows.Count == 1)
            {
                NewRow = dtCorrectEntry.NewRow();
                NewRow["Dispatch_Code"] = "";
                NewRow["DispatchEntry_Code"] = "";
                NewRow["Item_Code"] = lblMateCode.Text.Trim();
                NewRow["Item_Name"] = lblItemName.Text.Trim();
                NewRow["Barcode"] = dsSupplier.Tables[0].Rows[0]["Item_EAN_No"].ToString();
                NewRow["Asset_No"] = dsSupplier.Tables[0].Rows[0]["Asset_No"].ToString();
                NewRow["Dispatch_Qty"] = txtItemQty.Text.Trim();
                NewRow["Purchase_Rate"] = txtItemRate.Text;
                NewRow["Purchase_Amount"] = lblCalValue.Text;
                NewRow["Pkey"] = (itemcount + 1).ToString();


                NewRow["InwardEntry_Code"] = dsSupplier.Tables[0].Rows[0]["InwardEntry_Code"].ToString();
                NewRow["Inward_Code"] = dsSupplier.Tables[0].Rows[0]["Inward_Code"].ToString();
                NewRow["Inward_Qty"] = dsSupplier.Tables[0].Rows[0]["Inward_Qty"].ToString();
                NewRow["Is_Authorised"] = "0";
                NewRow["Request_EntryCode"] = lblRequestEntry_Code_Item.Text.Trim();
                NewRow["Pkey2"] = lblPkey2_Grid.Text.Trim();

                NewRow["AssetStatusId"] = lblAssetStatus_Grid.Text.Trim();
                NewRow["AssetFGStatus"] = lblAssetFGStatus_Grid.Text.Trim();
                NewRow["AssetCondition"] = lblAssetCondition_Grid.Text.Trim();

                dtCorrectEntry.Rows.Add(NewRow);


                //

                NewRow1 = dtTempEntry.NewRow();
                NewRow1["Dispatch_Code"] = "";
                NewRow1["DispatchEntry_Code"] = "";
                NewRow1["Item_Code"] = lblMateCode.Text.Trim();
                NewRow1["Item_Name"] = lblItemName.Text.Trim();
                NewRow1["Barcode"] = dsSupplier.Tables[0].Rows[0]["Item_EAN_No"].ToString();
                NewRow1["Asset_No"] = dsSupplier.Tables[0].Rows[0]["Asset_No"].ToString();
                NewRow1["Dispatch_Qty"] = txtItemQty.Text.Trim();
                NewRow1["Purchase_Rate"] = txtItemRate.Text;
                NewRow1["Purchase_Amount"] = lblCalValue.Text;
                NewRow1["Pkey"] = (itemcount + 1).ToString();


                NewRow1["InwardEntry_Code"] = dsSupplier.Tables[0].Rows[0]["InwardEntry_Code"].ToString();
                NewRow1["Inward_Code"] = dsSupplier.Tables[0].Rows[0]["Inward_Code"].ToString();
                NewRow1["Inward_Qty"] = dsSupplier.Tables[0].Rows[0]["Inward_Qty"].ToString();
                NewRow1["Is_Authorised"] = "0";
                NewRow1["Request_EntryCode"] = lblRequestEntry_Code_Item.Text.Trim();

                dtTempEntry.Rows.Add(NewRow1);

                Total_Quantity = Total_Quantity + Convert.ToInt32(txtItemQty.Text.Trim());
                Total_Amount = Total_Amount + Convert.ToDecimal(lblCalValue.Text);
            }
        }




        dlQuestion.DataSource = dtCorrectEntry;
        dlQuestion.DataBind();
        DataList2.DataSource = dtTempEntry;
        DataList2.DataBind();
        //lblTotal_Amount.Text = Total_Amount.ToString();
        txtTotalQuantity.Text = Total_Quantity.ToString();
        txtTotalItems.Text = (itemcount + 1).ToString();

        lblMateCode.Text = "";
        lblItemName.Text = "";
        lblUnit.Text = "";
        lblCalValue.Text = "";
        txtItemQty.Text = "";
        txtItemRate.Text = "";
        lblRequestEntry_Code_Item.Text = "";
        lblPkey2_Grid.Text = "";
        lblAssetStatus_Grid.Text = "";
        lblAssetFGStatus_Grid.Text = "";
        lblAssetCondition_Grid.Text = "";

    }



    protected void btnDivConfirmYes_Click(object sender, System.EventArgs e)
    {


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
        _with1.Columns.Add("InwardEntry_Code");
        _with1.Columns.Add("Inward_Code");
        _with1.Columns.Add("Inward_Qty");
        _with1.Columns.Add("Is_Authorised");
        _with1.Columns.Add("Request_EntryCode");
        _with1.Columns.Add("Pkey2");

        _with1.Columns.Add("AssetStatusId");
        _with1.Columns.Add("AssetFGStatus");
        _with1.Columns.Add("AssetCondition");

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

                Label lblInward_Code = (Label)item.FindControl("lblInward_Code");
                Label lblInwardEntry_Code_DL = (Label)item.FindControl("lblInwardEntry_Code_DL");
                Label Inward_Qty = (Label)item.FindControl("Inward_Qty");
                Label Is_Authorised = (Label)item.FindControl("Is_Authorised");
                Label lblRequestEntry_Code_Grid = (Label)item.FindControl("lblRequestEntry_Code_Grid");
                Label lblPkey2 = (Label)item.FindControl("lblPkey2");

                Label lblAssetStatus = (Label)item.FindControl("lblAssetStatus");
                Label lblAssetFGStatus = (Label)item.FindControl("lblAssetFGStatus");
                Label lblAssetCondition = (Label)item.FindControl("lblAssetCondition");

                //if (lblPkey_Code.Text == lblCodeRemove.Text)
                //{
                NewRow = dtCorrectEntry.NewRow();
                NewRow["Dispatch_Code"] = lblDispatch_Code.Text.ToString().Trim();
                NewRow["DispatchEntry_Code"] = lblDispatchEntry_Code.Text.ToString().Trim();
                NewRow["Item_Code"] = lblItem_Code_DT.Text.ToString().Trim();
                NewRow["Item_Name"] = lblItemName_DT.Text.ToString().Trim();
                NewRow["Barcode"] = lblBarcode_DT.Text.ToString().Trim();
                NewRow["Asset_No"] = lblAssetNo_DT.Text.ToString().Trim();
                NewRow["Dispatch_Qty"] = lblQty_DT.Text.ToString().Trim();
                NewRow["Purchase_Rate"] = lblUnitPrice_DT.Text.ToString().Trim();
                NewRow["Purchase_Amount"] = lblAmount_DT.Text.ToString().Trim();

                NewRow["InwardEntry_Code"] = lblInwardEntry_Code_DL.Text.ToString().Trim();
                NewRow["Inward_Code"] = lblInward_Code.Text.ToString().Trim();
                NewRow["Inward_Qty"] = Inward_Qty.Text.ToString().Trim();
                NewRow["Is_Authorised"] = Is_Authorised.Text.ToString().Trim();
                NewRow["Request_EntryCode"] = lblRequestEntry_Code_Grid.Text.ToString().Trim();
                NewRow["Pkey2"] = lblPkey2.Text.ToString().Trim();

                NewRow["AssetStatusId"] = lblAssetStatus.Text.ToString().Trim();
                NewRow["AssetFGStatus"] = lblAssetFGStatus.Text.ToString().Trim();
                NewRow["AssetCondition"] = lblAssetCondition.Text.ToString().Trim();
                NewRow["Pkey"] = lblPkey_Code.Text.ToString().Trim();

                dtCorrectEntry.Rows.Add(NewRow);
                //}

            }
        }


        DataRow[] rows;
        rows = dtCorrectEntry.Select("Pkey = '" + lblCodeRemove.Text + "'");
        foreach (DataRow row in rows)
            dtCorrectEntry.Rows.Remove(row);



        int count = 0;
        foreach (DataRow dr in dtCorrectEntry.Rows) // search whole table
        {
            count++;
            dr["Pkey"] = count.ToString(); //change the name                  


        }

        dlQuestion.DataSource = dtCorrectEntry;
        dlQuestion.DataBind();
        FillTotalDetails_Temp();
    }

    private void FillGrid()
    {
        try
        {
            Clear_Error_Success_Box();

            ControlVisibility("Result");

            string Transfer_LocationCode = "";
            if (ddlLocationType.SelectedItem.ToString() == "Godown")
            {
                if (ddlgodownFR_SR.SelectedIndex == 0)
                {
                    Transfer_LocationCode = "%%";
                }
                else
                {
                    Transfer_LocationCode = ddlgodownFR_SR.SelectedValue.ToString().Trim();
                    lblLocationResult.Text = ddlgodownFR_SR.SelectedItem.ToString();
                }

                lblLocationType_Result.Text = "Godown";
            }
            else if (ddlLocationType.SelectedItem.ToString() == "Function")
            {
                if (ddlFunctionFR_SR.SelectedIndex == 0)
                {
                    Transfer_LocationCode = "%%";
                }
                else
                {
                    Transfer_LocationCode = ddlFunctionFR_SR.SelectedValue.ToString().Trim();
                    lblLocationResult.Text = ddlFunctionFR_SR.SelectedItem.ToString();
                }

                lblLocationType_Result.Text = "Function";
            }
            else if (ddlLocationType.SelectedItem.ToString() == "Center")
            {
                if (ddlDivisionFR_SR.SelectedIndex == 0)
                {
                    Transfer_LocationCode = "%%";
                }
                else if (ddlCenterFR_SR.SelectedIndex == 0)
                {
                    Transfer_LocationCode = "%%";
                }
                else
                {
                    Transfer_LocationCode = ddlCenterFR_SR.SelectedValue.ToString().Trim();
                    lblLocationResult.Text = ddlCenterFR_SR.SelectedItem.ToString();
                }

                lblLocationType_Result.Text = ddlDivisionFR_SR.SelectedItem.ToString().Trim();
            }



            Label lblHeader_User_Code = default(Label);
            lblHeader_User_Code = (Label)Master.FindControl("lblHeader_User_Code");

            //string CreatedBy = null;
            //CreatedBy = lblHeader_User_Code.Text;
            string Location_Type_Code = ddlLocationType.SelectedValue;
            string Voucher_Code = txtVoucherNm.Text;
            string FromDate;
            string ToDate;
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

            lblPeroidResult.Text = FromDate + " - " + ToDate;

            string OptionCode = "";
            OptionCode = Request.QueryString["OptionCode"].ToString().Trim();

            DataSet ds;
            ds = ProductController.Get_FinishedGood(2, Location_Type_Code, FromDate, ToDate, Voucher_Code, OptionCode);


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
                        FillTotalDetails_Temp();

                        DataList1.DataSource = null;
                        DataList1.DataBind();
                        BtnSaveAdd.Visible = true;
                    }

                }
                else
                {
                    dlGridDisplay.DataSource = null;
                    dlGridDisplay.DataBind();
                    FillTotalDetails_Temp();

                    DataList1.DataSource = null;
                    DataList1.DataBind();
                    BtnSaveAdd.Visible = true;

                }

            }
            else
            {
                dlGridDisplay.DataSource = ds;
                dlGridDisplay.DataBind();

                DataList1.DataSource = ds;
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
        catch (Exception ex)
        {

            Msg_Error.Visible = true;
            Msg_Success.Visible = false;
            lblerror.Text = ex.ToString();
            UpdatePanelMsgBox.Update();
            return;
        }

    }


    private void ClearSearchPanel()
    {
        //From Content
        ddlAddLocationType.SelectedIndex = 0;
        ddlLocationType.SelectedIndex = 0;
        ddladdGodown.SelectedIndex = 0;
        ddladdDivision.SelectedIndex = 0;
        ddladdFunction.SelectedIndex = 0;
        lblMateCode.Text = "";
        lblInwardEntry_Code.Text = "";
        lblCurrentQty.Text = "";
        lblInward_Code.Text = "";
        lblInward_Qty.Text = "";
        lblItemName.Text = "";
        lblUnit.Text = "";
        txtItemQty.Text = "";
        txtItemRate.Text = "";
        lblCalValue.Text = "";
        ddladdCenter.Items.Clear();
        Clear_Error_Success_Box();


        //ddlFunctionFR_SR.Items.Clear();

        txtVoucherNm.Text = "";

        //To Content


        //
        date_range_SR.Value = "";

        //Visible False from Table
        tblFr_Godown.Visible = false;
        tblFr_Function.Visible = false;
        tblFr_Division.Visible = false;
        tblFr_Center.Visible = false;
        tbladdFr_Godown.Visible = false;
        tbladdFr_Division.Visible = false;
        tbladdFr_Function.Visible = false;
        tbladdFr_Center.Visible = false;
        txtTotalItems.Text = "0";
        txtTotalQuantity.Text = "0";
        //lblTotal_Amount.Text = "0";




        //Visible False TO Table

    }

    private void ClearAddPanel()
    {
        ddlAddLocationType.SelectedIndex = 0;
        ddladdGodown.SelectedIndex = 0; ;
        ddladdDivision.SelectedIndex = 0;
        ddladdFunction.SelectedIndex = 0;
        lbladdVoucherNo.Text = "";
        lblAddVoucherDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");

    }
    private void ControlVisibility(string Mode)
    {
        if (Mode == "Search")
        {
            DivAdd.Visible = false;
            DivSearchPanel1.Visible = false;
            BtnSaveAdd.Visible = true;
            BtnSaveEdit.Visible = false;
            BtnSaveAdd.Visible = true;
            DivResultPanel.Visible = true;
            lbladdVoucherNo.Text = "";
            lblAddVoucherDate.Text = "";
            DivAuthorise.Visible = false;

            div_student.Visible = false;
            div_Teacher.Visible = false;
            div_Employee.Visible = false;

        }
        else if (Mode == "Result")
        {
            DivAdd.Visible = false;
            DivSearchPanel1.Visible = false;
            btnAdd.Visible = false;
            DivResultPanel.Visible = true;
            lblPkey.Text = "";
            DivAuthorise.Visible = false;

            div_student.Visible = false;
            div_Teacher.Visible = false;
            div_Employee.Visible = false;
        }
        else if (Mode == "Add")
        {
            DivAdd.Visible = true;

            DivSearchPanel1.Visible = false;
            BtnSaveEdit.Visible = false;
            DivAdd.Visible = true;
            DivSearchPanel1.Visible = false;
            btnAdd.Visible = true;
            DivResultPanel.Visible = false;
            lblPkey.Text = "";
            btnAdd.Visible = false;
            lblAddVoucherDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
            BtnSaveAdd.Visible = true;
            txtRequestCode.Enabled = true;
            btnRequi_Search.Visible = true;
            DivAuthorise.Visible = false;

            ddlAddLocationType.Enabled = false;
            ddladdGodown.Enabled = false;
            ddladdDivision.Enabled = false;
            ddladdFunction.Enabled = false;
            ddladdCenter.Enabled = true;
            ClearAddpanel();

            div_student.Visible = false;
            div_Teacher.Visible = false;
            div_Employee.Visible = false;

            string OptionCode = "";
            OptionCode = Request.QueryString["OptionCode"].ToString().Trim();

            if (OptionCode == "1")
            {
                DivItems.Visible = false;
                DivItemsList.Visible = false;
                TblRequestCode.Visible = true;
            }
            else
            {
                DivItems.Visible = true;
                DivItemsList.Visible = true;
                TblRequestCode.Visible = false;
            }
        }
        else if (Mode == "Edit")
        {
            DivAdd.Visible = false;
            DivSearchPanel1.Visible = false;
            btnAdd.Visible = false;
            DivResultPanel.Visible = false;
            DivAuthorise.Visible = false;

            div_student.Visible = false;
            div_Teacher.Visible = false;
            div_Employee.Visible = false;
        }
        else if (Mode == "Details")
        {
            DivAdd.Visible = false;
            DivSearchPanel1.Visible = false;
            btnAdd.Visible = true;
            DivResultPanel.Visible = false;
            DivAuthorise.Visible = false;

            div_student.Visible = false;
            div_Teacher.Visible = false;
            div_Employee.Visible = false;
        }
        else if (Mode == "Student")
        {
            div_student.Visible = true;
            div_Teacher.Visible = false;
            div_Employee.Visible = false;

          /////// auth
            divstudentDetails.Visible = true;
            divteacherDetails.Visible = false;
            divEmployeeDetails.Visible = false;

        }
        else if (Mode == "Teacher")
        {
            div_Teacher.Visible = true;
            div_student.Visible = false;
            div_Employee.Visible = false;

            /////// auth
            divstudentDetails.Visible = false;
            divteacherDetails.Visible = true;
            divEmployeeDetails.Visible = false;
        }
        else if (Mode == "Employee")
        {
            div_Employee.Visible = true;
            div_student.Visible = false;
            div_Teacher.Visible = false;
            /////// auth
            divstudentDetails.Visible = false;
            divteacherDetails.Visible = false;
            divEmployeeDetails.Visible = true;
        }
        else if (Mode == "Authorise")
        {
            DivAdd.Visible = false;
            DivSearchPanel1.Visible = false;
            btnAdd.Visible = false;
            DivResultPanel.Visible = false;
            DivAuthorise.Visible = true;
        }

    }



    private void SaveData()
    {
        try
        {
            Clear_Error_Success_Box();

            Label lblHeader_User_Code = default(Label);
            lblHeader_User_Code = (Label)Master.FindControl("lblHeader_User_Code");

            string CreatedBy = null;
            CreatedBy = lblHeader_User_Code.Text;

            string Voucher_Code = "";
            string Location_Type_Code = "";
            string Location_Code = "";
            //string Transaction_Type = "";

            string Voucher_No = "";
            DateTime Date;

            string LogisticType_Code = string.Empty;
            string LogisticDetails1 = string.Empty;
            string LogisticDetails2 = string.Empty;

            string ResultId = "";

            int Total_Item_Count = 0;
            int Total_Quantity = 0;

            Location_Type_Code = ddlAddLocationType.SelectedValue;


            if (ddlAddLocationType.SelectedItem.Text == "Godown")
            {
                Location_Code = ddladdGodown.SelectedValue;
            }
            else if (ddlAddLocationType.SelectedItem.Text == "Function")
            {
                Location_Code = ddladdFunction.SelectedValue;
            }
            else if (ddlAddLocationType.SelectedItem.Text == "Center")
            {
                Location_Code = ddladdCenter.SelectedValue;
            }


            Voucher_No = lbladdVoucherNo.Text.Trim();
            Date = Convert.ToDateTime(lblAddVoucherDate.Text.Trim());


            if (txtTotalQuantity.Text != "")
            {
                Total_Quantity = Convert.ToInt32(txtTotalQuantity.Text);
            }

            if (txtTotalItems.Text != "")
            {
                Total_Item_Count = Convert.ToInt32(txtTotalItems.Text);
            }

            int TotalRecord = 0;
            int checked_flag = 0;
            int count = 0;
            string OptionCode = "";
            OptionCode = Request.QueryString["OptionCode"].ToString().Trim();
            string Request1 = txtRequestCode.Text;
            DataSet Asset_Nos = ProductController.GetAssetNo_ByRequestNo(Request1, 7);

            if (OptionCode == "1")
            {
                if (lblusertypeCode.Text.Trim() == "UT001")
                {

                    for (count = 0; count < Asset_Nos.Tables[0].Rows.Count; count++)
                    {

                        foreach (DataListItem dtlItem in datalist_Student.Items)
                        {

                            TextBox txtAssetNo = (TextBox)dtlItem.FindControl("txtAssetNo");

                            CheckBox chkCheck = (CheckBox)dtlItem.FindControl("chkCheck");

                            checked_flag = 0;
                            if (chkCheck.Checked == true)
                            {
                                


                                if (txtAssetNo.Text.Trim() == Asset_Nos.Tables[0].Rows[count]["Asset_No"].ToString())
                                {
                                    TotalRecord = TotalRecord + 1;
                                    checked_flag = 1;
                                    break;
                                }


                            }
                        }

                    }
                    if (checked_flag == 0)
                    {
                        Show_Error_Success_Box("E", "Asset No Not Match");
                        return;
                    }

                    Total_Item_Count = TotalRecord;
                    Total_Quantity = TotalRecord;

                }
                else if (lblusertypeCode.Text.Trim() == "UT003")
                {
                    for (count = 0; count < Asset_Nos.Tables[0].Rows.Count; count++)
                    {
                        foreach (DataListItem dtlItem in datalist_Teacher.Items)
                        {

                            CheckBox chkCheck = (CheckBox)dtlItem.FindControl("chkCheck");
                            //TextBox txtEAN_No = (TextBox)dtlItem.FindControl("txtEAN_No");
                            TextBox txtAssetNo = (TextBox)dtlItem.FindControl("txtAssetNo");
                            checked_flag = 0;
                            if (chkCheck.Checked == true)
                            {
                                
                                if (txtAssetNo.Text.Trim() == Asset_Nos.Tables[0].Rows[count]["Asset_No"].ToString())
                                {
                                    TotalRecord = TotalRecord + 1;
                                    checked_flag = 1;
                                    break;
                                }


                            }

                        }
                    }
                    if (checked_flag == 0)
                    {
                        Show_Error_Success_Box("E", "Asset Number Not Match");
                        return;
                    }

                    Total_Item_Count = TotalRecord;
                    Total_Quantity = TotalRecord;

                }
                else if (lblusertypeCode.Text.Trim() == "UT004")
                {
                    for (count = 0; count < Asset_Nos.Tables[0].Rows.Count; count++)
                    {

                        foreach (DataListItem dtlItem in datalist_Employee.Items)
                        {

                            CheckBox chkCheck = (CheckBox)dtlItem.FindControl("chkCheck");
                            TextBox txtAssetNo = (TextBox)dtlItem.FindControl("txtAssetNo");
                            checked_flag = 0;
                            if (chkCheck.Checked == true)
                            {
                               

                                if (txtAssetNo.Text.Trim() == Asset_Nos.Tables[0].Rows[count]["Asset_No"].ToString())
                                {
                                    TotalRecord = TotalRecord + 1;
                                    checked_flag = 1;
                                    break;
                                }

                            }

                        }
                    }
                    if (checked_flag == 0)
                    {
                        Show_Error_Success_Box("E", "Asset Number Not Match");
                        return;
                    }

                    Total_Item_Count = TotalRecord;
                    Total_Quantity = TotalRecord;
                }
            }


            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];


            ResultId = ProductController.GetItemForFinishedgood(1, Voucher_Code, Location_Type_Code, Location_Code, UserID, Total_Quantity, Total_Item_Count, OptionCode, txtRequestCode.Text.Trim());


            if (ResultId == "")
            {

            }
            else if (ResultId == "-1")
            {
                Show_Error_Success_Box("E", "Record already exist");
            }
            else
            {
                string deleteItem = ProductController.Delete_FinishedGood_Item(2, ResultId);
                int checked_flag1 = 0;

                if (OptionCode == "1")
                {
                    if (lblusertypeCode.Text.Trim() == "UT001")
                    {
                        foreach (DataListItem item in datalist_Student.Items)
                        {
                            for (int count1 = 0; count1 < Asset_Nos.Tables[0].Rows.Count; count1++)
                            {
                                if (item.ItemType == ListItemType.Item | item.ItemType == ListItemType.AlternatingItem)
                                {
                                    CheckBox chkCheck = (CheckBox)item.FindControl("chkCheck");

                                    if (chkCheck.Checked == true)
                                    {

                                        Label lblItem_Code_DT = (Label)item.FindControl("lblItem_Code_DT");
                                        Label lblQty_DT = (Label)item.FindControl("lblQty_DT");
                                        TextBox txtAssetNo = (TextBox)item.FindControl("txtAssetNo");
                                        Label lblInward_Code = (Label)item.FindControl("lblInward_Code");
                                        Label lblInwardEntry_Code_DL = (Label)item.FindControl("lblInwardEntry_Code_DL");
                                        Label lblAssetStatus = (Label)item.FindControl("lblAssetStatus");
                                        Label lblAssetFGStatus = (Label)item.FindControl("lblAssetFGStatus");
                                        Label lblAssetCondition = (Label)item.FindControl("lblAssetCondition");

                                        Label lblRequestEntry_Code_Grid = (Label)item.FindControl("lblRequestEntry_Code_Grid");
                                        checked_flag1 = 0;
                                        if (txtAssetNo.Text == Asset_Nos.Tables[0].Rows[count1]["Asset_No"].ToString())
                                        {

                                            string a = ProductController.Insert_Update_FinishedGoodItem(1, ResultId, lblItem_Code_DT.Text.Trim(), lblAssetFGStatus.Text.Trim(), lblQty_DT.Text.Trim(), lblAssetStatus.Text.Trim(), lblAssetCondition.Text.Trim(), txtAssetNo.Text.Trim(), lblRequestEntry_Code_Grid.Text.Trim(), lblInward_Code.Text.Trim(), lblInwardEntry_Code_DL.Text.Trim(), UserID);
                                            checked_flag1 = 1;
                                            break;

                                        }


                                    }


                                }
                            }
                            if (checked_flag1 == 0)
                            {
                                Show_Error_Success_Box("E", "Asset Number Not Match");
                                return;
                            }

                        }
                    }
                    else if (lblusertypeCode.Text.Trim() == "UT003")
                    {
                        foreach (DataListItem item in datalist_Teacher.Items)
                        {
                            for (int count1 = 0; count1 < Asset_Nos.Tables[0].Rows.Count; count1++)
                            {
                                if (item.ItemType == ListItemType.Item | item.ItemType == ListItemType.AlternatingItem)
                                {
                                    CheckBox chkCheck = (CheckBox)item.FindControl("chkCheck");

                                    if (chkCheck.Checked == true)
                                    {
                                        Label lblItem_Code_DT = (Label)item.FindControl("lblItem_Code_DT");
                                        Label lblQty_DT = (Label)item.FindControl("lblQty_DT");
                                        // Label lblAssetNo_DT = (Label)item.FindControl("lblAssetNo_DT");
                                        TextBox txtAssetNo = (TextBox)item.FindControl("txtAssetNo");

                                        Label lblInward_Code = (Label)item.FindControl("lblInward_Code");
                                        Label lblInwardEntry_Code_DL = (Label)item.FindControl("lblInwardEntry_Code_DL");

                                        Label lblAssetStatus = (Label)item.FindControl("lblAssetStatus");
                                        Label lblAssetFGStatus = (Label)item.FindControl("lblAssetFGStatus");
                                        Label lblAssetCondition = (Label)item.FindControl("lblAssetCondition");

                                        Label lblRequestEntry_Code_Grid = (Label)item.FindControl("lblRequestEntry_Code_Grid");
                                        checked_flag1 = 0;
                                        if (txtAssetNo.Text == Asset_Nos.Tables[0].Rows[count1]["Asset_No"].ToString())
                                        {

                                            string a = ProductController.Insert_Update_FinishedGoodItem(1, ResultId, lblItem_Code_DT.Text.Trim(), lblAssetFGStatus.Text.Trim(), lblQty_DT.Text.Trim(), lblAssetStatus.Text.Trim(), lblAssetCondition.Text.Trim(), txtAssetNo.Text.Trim(), lblRequestEntry_Code_Grid.Text.Trim(), lblInward_Code.Text.Trim(), lblInwardEntry_Code_DL.Text.Trim(), UserID);
                                            checked_flag1 = 1;
                                            break;
                                        }
                                    }

                                }

                            }
                            if (checked_flag1 == 0)
                            {
                                Show_Error_Success_Box("E", "Asset Number Not Match");
                                return;
                            }
                        }
                    }
                    else if (lblusertypeCode.Text.Trim() == "UT004")
                    {
                        foreach (DataListItem item in datalist_Employee.Items)
                        {
                            for (int count1 = 0; count1 < Asset_Nos.Tables[0].Rows.Count; count1++)
                            {

                                if (item.ItemType == ListItemType.Item | item.ItemType == ListItemType.AlternatingItem)
                                {
                                    CheckBox chkCheck = (CheckBox)item.FindControl("chkCheck");

                                    if (chkCheck.Checked == true)
                                    {
                                        Label lblItem_Code_DT = (Label)item.FindControl("lblItem_Code_DT");
                                        Label lblQty_DT = (Label)item.FindControl("lblQty_DT");
                                        //Label lblAssetNo_DT = (Label)item.FindControl("lblAssetNo_DT");
                                        TextBox txtAssetNo = (TextBox)item.FindControl("txtAssetNo");
                                        Label lblInward_Code = (Label)item.FindControl("lblInward_Code");
                                        Label lblInwardEntry_Code_DL = (Label)item.FindControl("lblInwardEntry_Code_DL");

                                        Label lblAssetStatus = (Label)item.FindControl("lblAssetStatus");
                                        Label lblAssetFGStatus = (Label)item.FindControl("lblAssetFGStatus");
                                        Label lblAssetCondition = (Label)item.FindControl("lblAssetCondition");

                                        Label lblRequestEntry_Code_Grid = (Label)item.FindControl("lblRequestEntry_Code_Grid");
                                        checked_flag1 = 0;
                                        if (txtAssetNo.Text == Asset_Nos.Tables[0].Rows[count1]["Asset_No"].ToString())
                                        {

                                            string a = ProductController.Insert_Update_FinishedGoodItem(1, ResultId, lblItem_Code_DT.Text.Trim(), lblAssetFGStatus.Text.Trim(), lblQty_DT.Text.Trim(), lblAssetStatus.Text.Trim(), lblAssetCondition.Text.Trim(), txtAssetNo.Text.Trim(), lblRequestEntry_Code_Grid.Text.Trim(), lblInward_Code.Text.Trim(), lblInwardEntry_Code_DL.Text.Trim(), UserID);

                                            checked_flag1 = 1;
                                            break;
                                        }

                                    }

                                }

                            }
                            if (checked_flag1 == 0)
                            {
                                Show_Error_Success_Box("E", "Asset Number Not Match");
                                return;
                            }
                        }
                    }
                }
                else
                {
                    foreach (DataListItem item in dlQuestion.Items)
                    {
                        for (int count1 = 0; count1 < Asset_Nos.Tables[0].Rows.Count; count1++)
                        {

                            if (item.ItemType == ListItemType.Item | item.ItemType == ListItemType.AlternatingItem)
                            {
                                Label lblItem_Code_DT = (Label)item.FindControl("lblItem_Code_DT");
                                Label lblQty_DT = (Label)item.FindControl("lblQty_DT");
                                // Label lblAssetNo_DT = (Label)item.FindControl("lblAssetNo_DT");
                                TextBox txtAssetNo = (TextBox)item.FindControl("txtAssetNo");
                                Label lblInward_Code = (Label)item.FindControl("lblInward_Code");
                                Label lblInwardEntry_Code_DL = (Label)item.FindControl("lblInwardEntry_Code_DL");

                                Label lblAssetStatus = (Label)item.FindControl("lblAssetStatus");
                                Label lblAssetFGStatus = (Label)item.FindControl("lblAssetFGStatus");
                                Label lblAssetCondition = (Label)item.FindControl("lblAssetCondition");

                                Label lblRequestEntry_Code_Grid = (Label)item.FindControl("lblRequestEntry_Code_Grid");
                                checked_flag1 = 0;
                                if (txtAssetNo.Text == Asset_Nos.Tables[0].Rows[count1]["Asset_No"].ToString())
                                {

                                    string a = ProductController.Insert_Update_FinishedGoodItem(1, ResultId, lblItem_Code_DT.Text.Trim(), lblAssetFGStatus.Text.Trim(), lblQty_DT.Text.Trim(), lblAssetStatus.Text.Trim(), lblAssetCondition.Text.Trim(), txtAssetNo.Text.Trim(), lblRequestEntry_Code_Grid.Text.Trim(), lblInward_Code.Text.Trim(), lblInwardEntry_Code_DL.Text.Trim(), UserID);
                                    checked_flag1 = 1;
                                    break;
                                }
                            }

                        }
                        if (checked_flag1 == 0)
                        {
                            Show_Error_Success_Box("E", "Asset Number Not Match");
                            return;
                        }
                    }
                }



                ControlVisibility("Search");
                FillGrid();
                ClearAddpanel();
                Show_Error_Success_Box("S", "Record save successfully");
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

    public void ClearAddpanel()
    {
        //ddlAddLocationType.SelectedIndex = 0;
        //ddladdGodown.SelectedIndex = 0;
        //ddladdFunction.SelectedIndex = 0;
        //ddladdDivision.SelectedIndex = 0;
        //ddladdCenter.Items.Clear();
        lbladdVoucherNo.Text = "";
        lblAddVoucherDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
        txtRequestCode.Text = "";

        txtItemMatCode.Text = "";
        lblMateCode.Text = "";
        lblInwardEntry_Code.Text = "";
        lblCurrentQty.Text = "";
        lblInward_Code.Text = "";
        lblInward_Qty.Text = "";
        lblItemName.Text = "";
        lblUnit.Text = "";

        dlQuestion.DataSource = null;
        dlQuestion.DataBind();

        DataList2.DataSource = null;
        DataList2.DataBind();

        txtTotalItems.Text = "0";
        txtTotalQuantity.Text = "0";
    }

    protected void BtnShowSearchPanel_Click(object sender, EventArgs e)
    {
        ControlVisibility("Search");
        DivSearchPanel1.Visible = true;
        DivResultPanel.Visible = false;
        DivAdd.Visible = false;
        Clear_Error_Success_Box();
        btnAdd.Visible = true;
        ClearSearchPanel();

    }


    protected void BtnSaveAdd_Click(object sender, EventArgs e)
    {
        Clear_Error_Success_Box();

        if (ddlAddLocationType.SelectedIndex == 0 || ddlAddLocationType.SelectedIndex == -1)
        {
            Show_Error_Success_Box("E", "Select Location Type");
            ddlAddLocationType.Focus();
            return;

        }

        if (ddlAddLocationType.SelectedItem.Text == "Godown" && ddladdGodown.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "Select Godown Name");
            ddladdGodown.Focus();
            return;
        }
        if (ddlAddLocationType.SelectedItem.Text == "Center" && ddladdDivision.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "Select Division Name");
            ddladdDivision.Focus();
            return;

        }
        if (ddlAddLocationType.SelectedItem.Text == "Function" && ddladdFunction.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "Select  Function");
            ddladdFunction.Focus();
            return;

        }

        if (ddlAddLocationType.SelectedItem.Text == "Center" && ddladdCenter.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "Select  Center");
            ddladdCenter.Focus();
            return;
        }
        if (ddladdDivision.SelectedIndex != 0 && ddladdCenter.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "Select Center");
            ddladdCenter.Focus();
            return;
        }


        int TotalRecord = 0;

        string OptionCode = "";
        OptionCode = Request.QueryString["OptionCode"].ToString().Trim();

        if (OptionCode == "1")
        {
            if (txtRequestCode.Text.Trim() == "")
            {
                Show_Error_Success_Box("E", "Enter Request Code");
                txtRequestCode.Focus();
                return;
            }


            if (lblusertypeCode.Text.Trim() == "UT001")
            {
                foreach (DataListItem dtlItem in datalist_Student.Items)
                {

                    CheckBox chkCheck = (CheckBox)dtlItem.FindControl("chkCheck");

                    if (chkCheck.Checked == true)
                    {
                        TotalRecord = TotalRecord + 1;
                    }

                }
                if (TotalRecord == 0)
                {
                    Show_Error_Success_Box("E", "Please Select atleast one item");
                    return;
                }
            }
            else if (lblusertypeCode.Text.Trim() == "UT003")
            {
                foreach (DataListItem dtlItem in datalist_Teacher.Items)
                {

                    CheckBox chkCheck = (CheckBox)dtlItem.FindControl("chkCheck");

                    if (chkCheck.Checked == true)
                    {
                        TotalRecord = TotalRecord + 1;
                    }

                }
                if (TotalRecord == 0)
                {
                    Show_Error_Success_Box("E", "Please Select atleast one item");
                    return;
                }
            }
            else if (lblusertypeCode.Text.Trim() == "UT004")
            {
                foreach (DataListItem dtlItem in datalist_Employee.Items)
                {

                    CheckBox chkCheck = (CheckBox)dtlItem.FindControl("chkCheck");

                    if (chkCheck.Checked == true)
                    {
                        TotalRecord = TotalRecord + 1;
                    }

                }
                if (TotalRecord == 0)
                {
                    Show_Error_Success_Box("E", "Please Select atleast one item");
                    return;
                }
            }
        }
        else
        {
            foreach (DataListItem dtlItem in dlQuestion.Items)
            {

                TotalRecord = TotalRecord + 1;

            }
            if (TotalRecord == 0)
            {
                Show_Error_Success_Box("E", "Please Select atleast one item");
                return;
            }
        }


        SaveData();

    }


    protected void BtnSaveEdit_Click(object sender, EventArgs e)
    {
        Clear_Error_Success_Box();
        //ControlVisibility("Search");
        if (ddlAddLocationType.SelectedIndex == 0 || ddlAddLocationType.SelectedIndex == -1)
        {
            Show_Error_Success_Box("E", "Select Location Type");
            ddlAddLocationType.Focus();
            return;

        }

        if (ddlAddLocationType.SelectedItem.Text == "Godown" && ddladdGodown.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "Select Godown Name");
            ddladdGodown.Focus();
            return;
        }
        if (ddlAddLocationType.SelectedItem.Text == "Center" && ddladdDivision.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "Select Division Name");
            ddladdDivision.Focus();
            return;

        }
        if (ddlAddLocationType.SelectedItem.Text == "Function" && ddladdFunction.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "Select  Function");
            ddladdFunction.Focus();
            return;

        }

        if (ddlAddLocationType.SelectedItem.Text == "Center" && ddladdCenter.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "Select  Center");
            ddladdCenter.Focus();
            return;
        }
        if (ddladdDivision.SelectedIndex != 0 && ddladdCenter.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "Select Center");
            ddladdCenter.Focus();
            return;
        }

        int TotalRecord = 0;

        string OptionCode = "";
        OptionCode = Request.QueryString["OptionCode"].ToString().Trim();

        if (OptionCode == "1")
        {
            if (lblusertypeCode.Text.Trim() == "UT001")
            {
                foreach (DataListItem dtlItem in datalist_Student.Items)
                {

                    CheckBox chkCheck = (CheckBox)dtlItem.FindControl("chkCheck");

                    if (chkCheck.Checked == true)
                    {
                        TotalRecord = TotalRecord + 1;
                    }

                }
                if (TotalRecord == 0)
                {
                    Show_Error_Success_Box("E", "Please Select atleast one item");
                    return;
                }
            }
            else if (lblusertypeCode.Text.Trim() == "UT003")
            {
                foreach (DataListItem dtlItem in datalist_Teacher.Items)
                {

                    CheckBox chkCheck = (CheckBox)dtlItem.FindControl("chkCheck");

                    if (chkCheck.Checked == true)
                    {
                        TotalRecord = TotalRecord + 1;
                    }

                }
                if (TotalRecord == 0)
                {
                    Show_Error_Success_Box("E", "Please Select atleast one item");
                    return;
                }
            }
            else if (lblusertypeCode.Text.Trim() == "UT004")
            {
                foreach (DataListItem dtlItem in datalist_Employee.Items)
                {

                    CheckBox chkCheck = (CheckBox)dtlItem.FindControl("chkCheck");

                    if (chkCheck.Checked == true)
                    {
                        TotalRecord = TotalRecord + 1;
                    }

                }
                if (TotalRecord == 0)
                {
                    Show_Error_Success_Box("E", "Please Select atleast one item");
                    return;
                }
            }
        }
        else
        {
            foreach (DataListItem dtlItem in dlQuestion.Items)
            {

                TotalRecord = TotalRecord + 1;

            }
            if (TotalRecord == 0)
            {
                Show_Error_Success_Box("E", "Please Select atleast one item");
                return;
            }
        }

        if (ControlValidation())
        {
            UpdateData();
        }

    }
    private void UpdateData()
    {
        try
        {
            Clear_Error_Success_Box();

            

            string Location_Type_Code = "";
            string Location_Code = "";
            string Voucher_Code = "";


            DateTime Date = DateTime.Now;
            DateTime Created_on = DateTime.Now;

            string ResultId = "";

            int Total_Item_Count = 0;
            int Total_Quantity = 0;

            Location_Type_Code = ddlAddLocationType.SelectedValue;

            if (ddlAddLocationType.SelectedItem.Text == "Godown")
            {
                Location_Code = ddladdGodown.SelectedValue;
            }
            else if (ddlAddLocationType.SelectedItem.Text == "Function")
            {
                Location_Code = ddladdFunction.SelectedValue;
            }
            else if (ddlAddLocationType.SelectedItem.Text == "Center")
            {
                Location_Code = ddladdCenter.SelectedValue;
            }

            if (txtTotalQuantity.Text != "")
            {
                Total_Quantity = Convert.ToInt32(txtTotalQuantity.Text);
            }

            //if (lblTotal_Amount.Text != "")
            //{
            //    Total_Amount = Convert.ToDecimal(lblTotal_Amount.Text);
            //}

            if (txtTotalItems.Text != "")
            {
                Total_Item_Count = Convert.ToInt32(txtTotalItems.Text);
            }

            int TotalRecord = 0;
            int count = 0;
            int checked_flag = 0;
            string OptionCode = "";
            OptionCode = Request.QueryString["OptionCode"].ToString().Trim();
            DataSet Asset_Nos = ProductController.GetAssetNo_ByRequestNo(txtRequestCode.Text.Trim(), 7);
            if (OptionCode == "1")
            {
                if (lblusertypeCode.Text.Trim() == "UT001")
                {
                    for (count = 0; count < Asset_Nos.Tables[0].Rows.Count; count++)
                    {

                        foreach (DataListItem dtlItem in datalist_Student.Items)
                        {

                            TextBox txtAssetNo = (TextBox)dtlItem.FindControl("txtAssetNo");

                            CheckBox chkCheck = (CheckBox)dtlItem.FindControl("chkCheck");

                            checked_flag = 0;
                            if (chkCheck.Checked == true)
                            {
                                


                                if (txtAssetNo.Text == Asset_Nos.Tables[0].Rows[count]["Asset_No"].ToString())
                                {
                                    TotalRecord = TotalRecord + 1;
                                    checked_flag = 1;
                                    break;
                                }


                            }
                        }

                    }
                    if (checked_flag == 0)
                    {
                        Show_Error_Success_Box("E", "Asset No Not Match");
                        return;
                    }

                    Total_Item_Count = TotalRecord;
                    Total_Quantity = TotalRecord;

                }




                else if (lblusertypeCode.Text.Trim() == "UT004")
                {
                    for (count = 0; count < Asset_Nos.Tables[0].Rows.Count; count++)
                    {

                        foreach (DataListItem dtlItem in datalist_Employee.Items)
                        {

                            CheckBox chkCheck = (CheckBox)dtlItem.FindControl("chkCheck");

                            TextBox txtAssetNo = (TextBox)dtlItem.FindControl("txtAssetNo");

                            if (chkCheck.Checked == true)
                            {
                                
                                if (txtAssetNo.Text == Asset_Nos.Tables[0].Rows[count]["Asset_No"].ToString())
                                {
                                    TotalRecord = TotalRecord + 1;
                                    checked_flag = 1;
                                    break;
                                }

                            }

                        }
                    }
                    if (checked_flag == 0)
                    {
                        Show_Error_Success_Box("E", "Asset No Not Match");
                        return;
                    }


                    Total_Item_Count = TotalRecord;
                    Total_Quantity = TotalRecord;
                }
            }

            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];

            ResultId = ProductController.Insert_Update_FinishedGood(8, lblPkey.Text, Total_Item_Count, Total_Quantity, UserID);


            if (ResultId == "")
            {

            }
            else if (ResultId == "-1")
            {

            }
            else if (ResultId == "1")
            {

                //string deleteItem = ProductController.Delete_FinishedGood_Item(2, lblPkey.Text);

                if (OptionCode == "1")
                {
                    if (lblusertypeCode.Text.Trim() == "UT001")
                    {
                        foreach (DataListItem item in datalist_Student.Items)
                        {
                            for (int count1 = 0; count1 < Asset_Nos.Tables[0].Rows.Count; count1++)
                            {


                                if (item.ItemType == ListItemType.Item | item.ItemType == ListItemType.AlternatingItem)
                                {
                                    CheckBox chkCheck = (CheckBox)item.FindControl("chkCheck");

                                    if (chkCheck.Checked == true)
                                    {
                                        Label lblItem_Code_DT = (Label)item.FindControl("lblItem_Code_DT");
                                        Label lblQty_DT = (Label)item.FindControl("lblQty_DT");
                                        Label lblvoucherEntry = (Label)item.FindControl("lblvoucherEntry");
                                        TextBox txtAssetNo = (TextBox)item.FindControl("txtAssetNo");

                                        Label lblInward_Code = (Label)item.FindControl("lblInward_Code");
                                        Label lblInwardEntry_Code_DL = (Label)item.FindControl("lblInwardEntry_Code_DL");

                                        Label lblAssetStatus = (Label)item.FindControl("lblAssetStatus");
                                        Label lblAssetFGStatus = (Label)item.FindControl("lblAssetFGStatus");
                                        Label lblAssetCondition = (Label)item.FindControl("lblAssetCondition");

                                        Label lblRequestEntry_Code_Grid = (Label)item.FindControl("lblRequestEntry_Code_Grid");
                                        checked_flag = 0;
                                        if (txtAssetNo.Text == Asset_Nos.Tables[0].Rows[count1]["Asset_No"].ToString())
                                        {
                                           //string a = ProductController.Insert_Update_FinishedGoodItem(1, lblPkey.Text.Trim(), lblItem_Code_DT.Text.Trim(), lblAssetFGStatus.Text.Trim(), lblQty_DT.Text.Trim(), lblAssetStatus.Text.Trim(), lblAssetCondition.Text.Trim(), txtAssetNo.Text.Trim(), lblRequestEntry_Code_Grid.Text.Trim(), lblInward_Code.Text.Trim(), lblInwardEntry_Code_DL.Text.Trim());
                                            string a = ProductController.Update_FinishedGood_asset(3, lblPkey.Text.Trim(), lblvoucherEntry.Text.Trim(), txtAssetNo.Text, lblAssetStatus.Text, lblAssetFGStatus.Text, lblAssetCondition.Text, lblInward_Code.Text, lblInwardEntry_Code_DL.Text, lblRequestEntry_Code_Grid.Text, lblQty_DT.Text, lblItem_Code_DT.Text, UserID);
                                            
                                            
                                            checked_flag = 1;
                                            break;
                                        }

                                    }

                                }

                            }

                            if (checked_flag == 0)
                            {
                                Show_Error_Success_Box("E", "Asset No Not Match");
                                return;
                            }
                        }
                    }
                    else if (lblusertypeCode.Text.Trim() == "UT003")
                    {

                        foreach (DataListItem item in datalist_Teacher.Items)
                        {
                            for (int count1 = 0; count1 < Asset_Nos.Tables[0].Rows.Count; count1++)
                            {


                                if (item.ItemType == ListItemType.Item | item.ItemType == ListItemType.AlternatingItem)
                                {
                                    CheckBox chkCheck = (CheckBox)item.FindControl("chkCheck");

                                    if (chkCheck.Checked == true)
                                    {
                                        Label lblItem_Code_DT = (Label)item.FindControl("lblItem_Code_DT");
                                        Label lblQty_DT = (Label)item.FindControl("lblQty_DT");
                                        Label lblAssetNo_DT = (Label)item.FindControl("lblAssetNo_DT");
                                        TextBox txtAssetNo = (TextBox)item.FindControl("txtAssetNo");
                                        Label lblInward_Code = (Label)item.FindControl("lblInward_Code");
                                        Label lblInwardEntry_Code_DL = (Label)item.FindControl("lblInwardEntry_Code_DL");
                                        Label lblvoucherEntry = (Label)item.FindControl("lblvoucherEntry");
                                        Label lblAssetStatus = (Label)item.FindControl("lblAssetStatus");
                                        Label lblAssetFGStatus = (Label)item.FindControl("lblAssetFGStatus");
                                        Label lblAssetCondition = (Label)item.FindControl("lblAssetCondition");

                                        Label lblRequestEntry_Code_Grid = (Label)item.FindControl("lblRequestEntry_Code_Grid");
                                        checked_flag = 0;
                                        if (txtAssetNo.Text == Asset_Nos.Tables[0].Rows[count1]["Asset_No"].ToString())
                                        {
                                            //string a = ProductController.Insert_Update_FinishedGoodItem(1, lblPkey.Text.Trim(), lblItem_Code_DT.Text.Trim(), lblAssetFGStatus.Text.Trim(), lblQty_DT.Text.Trim(), lblAssetStatus.Text.Trim(), lblAssetCondition.Text.Trim(), txtAssetNo.Text.Trim(), lblRequestEntry_Code_Grid.Text.Trim(), lblInward_Code.Text.Trim(), lblInwardEntry_Code_DL.Text.Trim());
                                            string a = ProductController.Update_FinishedGood_asset(3, lblPkey.Text.Trim(), lblvoucherEntry.Text.Trim(), txtAssetNo.Text, lblAssetStatus.Text, lblAssetFGStatus.Text, lblAssetCondition.Text, lblInward_Code.Text, lblInwardEntry_Code_DL.Text, lblRequestEntry_Code_Grid.Text, lblQty_DT.Text, lblItem_Code_DT.Text,UserID);
                                            
                                            checked_flag = 1;
                                            break;
                                        }
                                    }

                                }
                            }

                            if (checked_flag == 0)
                            {
                                Show_Error_Success_Box("E", "Asset No Not Match");
                            }
                        }
                    }
                    else if (lblusertypeCode.Text.Trim() == "UT004")
                    {
                        foreach (DataListItem item in datalist_Employee.Items)
                        {
                            for (int count1 = 0; count1 < Asset_Nos.Tables[0].Rows.Count; count1++)
                            {
                                if (item.ItemType == ListItemType.Item | item.ItemType == ListItemType.AlternatingItem)
                                {
                                    CheckBox chkCheck = (CheckBox)item.FindControl("chkCheck");

                                    if (chkCheck.Checked == true)
                                    {
                                        Label lblItem_Code_DT = (Label)item.FindControl("lblItem_Code_DT");
                                        Label lblQty_DT = (Label)item.FindControl("lblQty_DT");
                                        Label lblAssetNo_DT = (Label)item.FindControl("lblAssetNo_DT");
                                        TextBox txtAssetNo = (TextBox)item.FindControl("txtAssetNo");
                                        Label lblInward_Code = (Label)item.FindControl("lblInward_Code");
                                        Label lblInwardEntry_Code_DL = (Label)item.FindControl("lblInwardEntry_Code_DL");
                                        Label lblvoucherEntry = (Label)item.FindControl("lblvoucherEntry");
                                        Label lblAssetStatus = (Label)item.FindControl("lblAssetStatus");
                                        Label lblAssetFGStatus = (Label)item.FindControl("lblAssetFGStatus");
                                        Label lblAssetCondition = (Label)item.FindControl("lblAssetCondition");

                                        Label lblRequestEntry_Code_Grid = (Label)item.FindControl("lblRequestEntry_Code_Grid");
                                        checked_flag = 0;
                                        if (txtAssetNo.Text == Asset_Nos.Tables[0].Rows[count1]["Asset_No"].ToString())
                                        {
                                            //string a = ProductController.Insert_Update_FinishedGoodItem(1, lblPkey.Text.Trim(), lblItem_Code_DT.Text.Trim(), lblAssetFGStatus.Text.Trim(), lblQty_DT.Text.Trim(), lblAssetStatus.Text.Trim(), lblAssetCondition.Text.Trim(), txtAssetNo.Text.Trim(), lblRequestEntry_Code_Grid.Text.Trim(), lblInward_Code.Text.Trim(), lblInwardEntry_Code_DL.Text.Trim());
                                            string a = ProductController.Update_FinishedGood_asset(3, lblPkey.Text.Trim(), lblvoucherEntry.Text.Trim(), txtAssetNo.Text, lblAssetStatus.Text, lblAssetFGStatus.Text, lblAssetCondition.Text, lblInward_Code.Text, lblInwardEntry_Code_DL.Text, lblRequestEntry_Code_Grid.Text, lblQty_DT.Text, lblItem_Code_DT.Text, UserID);
                                            
                                            checked_flag = 1;
                                            break;
                                        }

                                    }

                                }

                            }

                            if (checked_flag == 0)
                            {
                                Show_Error_Success_Box("E", "Asset No Not Match");
                                return;
                            }
                        }
                    }
                    else
                    {
                        foreach (DataListItem item in dlQuestion.Items)
                        {
                            for (int count1 = 0; count1 < Asset_Nos.Tables[0].Rows.Count; count1++)
                            {
                                if (item.ItemType == ListItemType.Item | item.ItemType == ListItemType.AlternatingItem)
                                {
                                    Label lblItem_Code_DT = (Label)item.FindControl("lblItem_Code_DT");
                                    Label lblQty_DT = (Label)item.FindControl("lblQty_DT");
                                    Label lblAssetNo_DT = (Label)item.FindControl("lblAssetNo_DT");
                                    TextBox txtAssetNo = (TextBox)item.FindControl("txtAssetNo");
                                    Label lblInward_Code = (Label)item.FindControl("lblInward_Code");
                                    Label lblInwardEntry_Code_DL = (Label)item.FindControl("lblInwardEntry_Code_DL");
                                    Label lblvoucherEntry = (Label)item.FindControl("lblvoucherEntry");
                                    Label lblAssetStatus = (Label)item.FindControl("lblAssetStatus");
                                    Label lblAssetFGStatus = (Label)item.FindControl("lblAssetFGStatus");
                                    Label lblAssetCondition = (Label)item.FindControl("lblAssetCondition");

                                    Label lblRequestEntry_Code_Grid = (Label)item.FindControl("lblRequestEntry_Code_Grid");

                                    checked_flag = 0;
                                    if (txtAssetNo.Text == Asset_Nos.Tables[0].Rows[count1]["Asset_No"].ToString())
                                    {
                                        string a = ProductController.Insert_Update_FinishedGoodItem(1, lblPkey.Text.Trim(), lblItem_Code_DT.Text.Trim(), lblAssetFGStatus.Text.Trim(), lblQty_DT.Text.Trim(), lblAssetStatus.Text.Trim(), lblAssetCondition.Text.Trim(), lblAssetNo_DT.Text.Trim(), lblRequestEntry_Code_Grid.Text.Trim(), lblInward_Code.Text.Trim(), lblInwardEntry_Code_DL.Text.Trim(), UserID);
                                        checked_flag = 1;
                                        break;
                                    }
                                }

                            }
                            if (checked_flag == 0)
                            {
                                Show_Error_Success_Box("E", "Asset No Not Match");
                                return;
                            }
                        }
                    }

                    ControlVisibility("Search");
                    FillGrid();
                    ClearAddpanel();
                    Show_Error_Success_Box("S", "Record Updated successfully");
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

    private bool ControlValidation()
    {
        Clear_Error_Success_Box();
        bool Flag = true;

        if (ddlAddLocationType.SelectedValue == "Select Location")
        {
            Show_Error_Success_Box("E", "Select Location");
            ddlAddLocationType.Focus();
            Flag = false;

        }


        else if (ddlAddLocationType.SelectedItem.Text == "Godown" && ddladdGodown.SelectedValue == "0")
        {
            Show_Error_Success_Box("E", "Select Location From Godown");
            ddlAddLocationType.Focus();
            Flag = false;
        }

        else if (ddlAddLocationType.SelectedItem.Text == "Function" && ddladdFunction.SelectedValue == "0")
        {
            Show_Error_Success_Box("E", "Select Transfer From Function");
            ddlAddLocationType.Focus();
            Flag = false;

        }
        else if (ddlAddLocationType.SelectedItem.Text == "Center" && ddladdDivision.SelectedValue == "0")
        {
            Show_Error_Success_Box("E", "Select Transfer From Division");
            ddlAddLocationType.Focus();
            Flag = false;
        }
        else if (ddlAddLocationType.SelectedItem.Text == "Center" && ddladdCenter.SelectedValue == "0")
        {
            Show_Error_Success_Box("E", "Select Transfer From Center");
            ddlAddLocationType.Focus();
            Flag = false;
        }
        else if (ddladdDivision.SelectedValue != "0" && ddladdCenter.SelectedValue == "0")
        {
            Show_Error_Success_Box("E", "Select Transfer From Center");
            ddlAddLocationType.Focus();
            Flag = false;
        }


        return Flag;

    }

    protected void btnRequi_Search_Click(object sender, EventArgs e)
    {
        try
        {
            Clear_Error_Success_Box();

            if (txtRequestCode.Text.Trim() == "")
            {
                Show_Error_Success_Box("E", "Enter Request Code");
                txtRequestCode.Focus();
                return;
            }

            string From_Location_Code = "";

            if (ddlAddLocationType.SelectedItem.Text == "Godown")
            {
                From_Location_Code = ddladdGodown.SelectedValue;
            }
            else if (ddlAddLocationType.SelectedItem.Text == "Function")
            {
                From_Location_Code = ddladdFunction.SelectedValue;
            }
            else if (ddlAddLocationType.SelectedItem.Text == "Center")
            {
                From_Location_Code = ddladdCenter.SelectedValue;
            }

            int OptionCode = 0;
            OptionCode = Convert.ToInt32(Request.QueryString["OptionCode"]);


            DataSet dsGrid = ProductController.Get_Data_ByRequNoforFinished(ddlAddLocationType.SelectedValue.ToString().Trim(), From_Location_Code, txtRequestCode.Text.Trim(), 6, OptionCode);
            if (dsGrid != null)
            {
                if (dsGrid.Tables[0].Rows.Count > 0)
                {
                    lblusertypeCode.Text = dsGrid.Tables[0].Rows[0]["UserTypeCode"].ToString();

                    if (lblusertypeCode.Text.Trim() == "UT001")
                    {
                        ControlVisibility("Student");
                        if (dsGrid.Tables[1].Rows.Count != 0)
                        {
                            datalist_Student.DataSource = dsGrid.Tables[2];
                            datalist_Student.DataBind();

                            StudentDetsils.DataSource = dsGrid.Tables[2];
                            StudentDetsils.DataBind();
                            lblapproveremark.Text = dsGrid.Tables[3].Rows[0]["Approved_Remark"].ToString();
                            lblapprovedRemark.Text = dsGrid.Tables[3].Rows[0]["Approved_Remark"].ToString();


                        }
                        else
                        {
                            datalist_Student.DataSource = null;
                            datalist_Student.DataBind();

                            StudentDetsils.DataSource = null;
                            StudentDetsils.DataBind();
                            Show_Error_Success_Box("E", "Records Not Found..");
                            return;
                        }
                    }
                    else if (lblusertypeCode.Text.Trim() == "UT003")
                    {
                        ControlVisibility("Teacher");
                        if (dsGrid.Tables[0].Rows.Count != 0)
                        {
                            datalist_Teacher.DataSource = dsGrid.Tables[2];
                            datalist_Teacher.DataBind();

                            Teacher_Details.DataSource = dsGrid.Tables[2];
                            Teacher_Details.DataBind();
                            lblapproveremark.Text = dsGrid.Tables[3].Rows[0]["Approved_Remark"].ToString();
                            lblapprovedRemark.Text = dsGrid.Tables[3].Rows[0]["Approved_Remark"].ToString();

                        }
                        else
                        {
                            datalist_Teacher.DataSource = null;
                            datalist_Teacher.DataBind();

                            Teacher_Details.DataSource = null;
                            Teacher_Details.DataBind();
                            Show_Error_Success_Box("E", "Records Not Found..");
                            return;
                        }
                    }
                    else if (lblusertypeCode.Text.Trim() == "UT004")
                    {
                        ControlVisibility("Employee");
                        if (dsGrid.Tables[0].Rows.Count != 0)
                        {
                            datalist_Employee.DataSource = dsGrid.Tables[2];
                            datalist_Employee.DataBind();

                            datalist_EmployeeDetails.DataSource = dsGrid.Tables[2];
                            datalist_EmployeeDetails.DataBind();
                        }
                        else
                        {
                            datalist_Employee.DataSource = null;
                            datalist_Employee.DataBind();

                            datalist_EmployeeDetails.DataSource = null;
                            datalist_EmployeeDetails.DataBind();
                            lblapproveremark.Text = dsGrid.Tables[3].Rows[0]["Approved_Remark"].ToString();
                            lblapprovedRemark.Text = dsGrid.Tables[3].Rows[0]["Approved_Remark"].ToString();
                            Show_Error_Success_Box("E", "Records Not Found..");
                            return;

                        }
                    }
                }
                else
                {
                    Show_Error_Success_Box("E", "Records Not Found..");
                    return;
                }


            }
            else
            {
                Show_Error_Success_Box("E", "Records Not Found..");
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
    protected void datalist_Student_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "RemoveRequest")
        {
            string RequestEntry_Code = e.CommandArgument.ToString();

            foreach (DataListItem dtlItem in datalist_Student.Items)
            {
                CheckBox chkCheck = (CheckBox)dtlItem.FindControl("chkCheck");
                Label Request_EntryCode = (Label)dtlItem.FindControl("Request_EntryCode");

                if (Request_EntryCode.Text.Trim() == RequestEntry_Code)
                {
                    if (chkCheck.Checked == false)
                    {

                    }
                }
            }
        }
    }
    protected void dlGridDisplay_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "comEdit")
            {
                Clear_Error_Success_Box();
                lblPkey.Text = "";
                lblapproveremark.Text = "";
                ControlVisibility("Add");
                BtnSaveEdit.Visible = true;
                BtnSaveAdd.Visible = false;
                lblvoucher.Visible = true;
                ClearAddpanel();

                lblPkey.Text = e.CommandArgument.ToString();
                DataSet ds1 = null;
                ds1 = ProductController.Get_FinishedGood_ItemById(3, lblPkey.Text.Trim());

                if (ds1.Tables[0].Rows.Count > 0)
                {

                    ddlAddLocationType.SelectedValue = ds1.Tables[0].Rows[0]["Location_Type_code"].ToString();
                    lblAddVoucherDate.Text = ds1.Tables[0].Rows[0]["Date"].ToString();
                    lbladdVoucherNo.Text = ds1.Tables[0].Rows[0]["Voucher_Code"].ToString();

                    if (ddlAddLocationType.SelectedItem.ToString().Trim() == "Godown")
                    {
                       
                        tbladdFr_Godown.Visible = true;
                        tbladdFr_Function.Visible = false;
                        tbladdFr_Division.Visible = false;
                        tbladdFr_Center.Visible = false;
                        ddladdGodown.SelectedValue = ds1.Tables[0].Rows[0]["Location_code"].ToString();
                    }
                    else if (ddlAddLocationType.SelectedItem.ToString().Trim() == "Function")
                    {
                        tbladdFr_Function.Visible = true;
                        tbladdFr_Godown.Visible = false;
                        tbladdFr_Division.Visible = false;
                        tbladdFr_Center.Visible = false;
                        ddladdFunction.SelectedValue = ds1.Tables[0].Rows[0]["Location_Code"].ToString();

                      
                    }
                    else if (ddlAddLocationType.SelectedItem.ToString().Trim() == "Center")
                    {
                        tbladdFr_Division.Visible = true;
                        tbladdFr_Center.Visible = true;
                        tbladdFr_Function.Visible = false;
                        tbladdFr_Godown.Visible = false;
                        ddladdDivision.SelectedValue = ds1.Tables[0].Rows[0]["FromDivision"].ToString();

                        FillDDL_FRADDSearch_Centre();
                        ddladdCenter.SelectedValue = ds1.Tables[0].Rows[0]["Location_code"].ToString();

                        
                    }
                    else if (ddlAddLocationType.SelectedIndex == 0 || ddlAddLocationType.SelectedIndex == -1)
                    {
                        tbladdFr_Godown.Visible = false;
                        tbladdFr_Function.Visible = false;
                        tbladdFr_Division.Visible = false;
                        tbladdFr_Center.Visible = false;
                    }


                    txtTotalItems.Text = ds1.Tables[0].Rows[0]["total_item_count"].ToString();
                    txtTotalQuantity.Text = ds1.Tables[0].Rows[0]["total_quantity"].ToString();
                    //ddlRequestCode_Add.SelectedValue = ds1.Tables[0].Rows[0]["Request_Code"].ToString();
                    txtRequestCode.Text = ds1.Tables[0].Rows[0]["Request_Code"].ToString();

                    if (ds1.Tables[0].Rows[0]["Is_Authorised"].ToString() == "1")
                    {
                        BtnSaveEdit.Visible = false;
                    }
                    else if (ds1.Tables[0].Rows[0]["Is_Authorised"].ToString() == "0")
                    {
                        BtnSaveEdit.Visible = true;
                    }

                    txtRequestCode.Enabled = false;
                    btnRequi_Search.Visible = false;


                    string From_Location_Code = "";

                    if (ddlAddLocationType.SelectedItem.Text == "Godown")
                    {
                        From_Location_Code = ddladdGodown.SelectedValue;
                    }
                    else if (ddlAddLocationType.SelectedItem.Text == "Function")
                    {
                        From_Location_Code = ddladdFunction.SelectedValue;
                    }
                    else if (ddlAddLocationType.SelectedItem.Text == "Center")
                    {
                        From_Location_Code = ddladdCenter.SelectedValue;
                    }

                    string OptionCode = "";
                    OptionCode = Request.QueryString["OptionCode"].ToString().Trim();

                    if (OptionCode == "1")
                    {
                        DataSet dsGrid = ProductController.Get_Data_ByRequNoforFinishedForEdit(ddlAddLocationType.SelectedValue.ToString().Trim(), From_Location_Code, txtRequestCode.Text.Trim(), 6, Convert.ToInt32(OptionCode), lblPkey.Text.Trim());
                        if (dsGrid != null)
                        {
                            if (dsGrid.Tables[0].Rows.Count > 0)
                            {
                                lblusertypeCode.Text = dsGrid.Tables[0].Rows[0]["UserTypeCode"].ToString();

                                if (lblusertypeCode.Text.Trim() == "UT001")
                                {
                                    ControlVisibility("Student");
                                    //FillGrid_Student(ddlrequi_No.SelectedValue.ToString().Trim());
                                    if (dsGrid.Tables[1].Rows.Count != 0)
                                    {
                                        datalist_Student.DataSource = dsGrid.Tables[2];
                                        datalist_Student.DataBind();
                                        StudentDetsils.DataSource = dsGrid.Tables[2];
                                        StudentDetsils.DataBind();

                                        lblapproveremark.Text = dsGrid.Tables[3].Rows[0]["Approved_Remark"].ToString();

                                        UpdatePanel1.Update();

                                        for (int cnt = 0; cnt <= ds1.Tables[1].Rows.Count - 1; cnt++)
                                        {

                                            foreach (DataListItem dtlItem in datalist_Student.Items)
                                            {
                                                CheckBox chkDL_Select_Centre = (CheckBox)dtlItem.FindControl("chkCheck");
                                                Label Request_EntryCode = (Label)dtlItem.FindControl("Request_EntryCode");
                                                Label lblItem_Code_DT = (Label)dtlItem.FindControl("lblItem_Code_DT");
                                                TextBox txtAssetNo = (TextBox)dtlItem.FindControl("txtassetNo");
                                                Label lblAssetNo_DT1 = (Label)dtlItem.FindControl("lblAssetNo_DT1");
                                                Label lblItem_EAN_No = (Label)dtlItem.FindControl("lblItem_EAN_No");
                                                TextBox txtEAN_No = (TextBox)dtlItem.FindControl("txtEAN_No");

                                                if (Convert.ToString(Request_EntryCode.Text).Trim() == Convert.ToString(ds1.Tables[1].Rows[cnt]["Request_EntryCode"]).Trim() && Convert.ToString(lblItem_Code_DT.Text).Trim() == Convert.ToString(ds1.Tables[1].Rows[cnt]["Item_Code"]).Trim())
                                                {
                                                    chkDL_Select_Centre.Checked = true;
                                                    break; // TODO: might not be correct. Was : Exit For
                                                }
                                            }

                                        }
                                    }
                                    else
                                    {
                                        datalist_Student.DataSource = null;
                                        datalist_Student.DataBind();

                                    }
                                }
                                else if (lblusertypeCode.Text.Trim() == "UT003")
                                {
                                    ControlVisibility("Teacher");
                                 
                                    if (dsGrid.Tables[0].Rows.Count != 0)
                                    {
                                        datalist_Teacher.DataSource = dsGrid.Tables[2];
                                        datalist_Teacher.DataBind();
                                        Teacher_Details.DataSource = dsGrid.Tables[2];
                                        Teacher_Details.DataBind();
                                        lblapproveremark.Text = dsGrid.Tables[3].Rows[0]["Approved_Remark"].ToString();

                                        ////

                                        for (int cnt = 0; cnt <= ds1.Tables[1].Rows.Count - 1; cnt++)
                                        {

                                            foreach (DataListItem dtlItem in datalist_Teacher.Items)
                                            {
                                                CheckBox chkDL_Select_Centre = (CheckBox)dtlItem.FindControl("chkCheck");
                                                Label Request_EntryCode = (Label)dtlItem.FindControl("Request_EntryCode");
                                                Label lblItem_Code_DT = (Label)dtlItem.FindControl("lblItem_Code_DT");

                                                Label lblAssetNo_DT = (Label)dtlItem.FindControl("lblAssetNo_DT");
                                                TextBox txtAssetNo = (TextBox)dtlItem.FindControl("txtAssetNo");
                                                Label lblItem_EAN_No = (Label)dtlItem.FindControl("lblItem_EAN_No");
                                                TextBox txtEAN_No = (TextBox)dtlItem.FindControl("txtEAN_No");

                                                if (Convert.ToString(Request_EntryCode.Text).Trim() == Convert.ToString(ds1.Tables[1].Rows[cnt]["Request_EntryCode"]).Trim() && Convert.ToString(lblItem_Code_DT.Text).Trim() == Convert.ToString(ds1.Tables[1].Rows[cnt]["Item_Code"]).Trim())
                                                {
                                                    chkDL_Select_Centre.Checked = true;
                                                    //count = count + 1;
                                                    break; // TODO: might not be correct. Was : Exit For
                                                }
                                            }

                                        }

                                        /////
                                    }
                                    else
                                    {
                                        datalist_Teacher.DataSource = null;
                                        datalist_Teacher.DataBind();
                                    }
                                }
                                else if (lblusertypeCode.Text.Trim() == "UT004")
                                {
                                    ControlVisibility("Employee");
                                    //FillGrid_Teacher(ddlrequi_No.SelectedValue.ToString().Trim());
                                    if (dsGrid.Tables[0].Rows.Count != 0)
                                    {
                                        datalist_Employee.DataSource = dsGrid.Tables[2];
                                        datalist_Employee.DataBind();
                                        datalist_EmployeeDetails.DataSource = dsGrid.Tables[2];
                                        datalist_EmployeeDetails.DataBind();
                                        lblapproveremark.Text = dsGrid.Tables[3].Rows[0]["Approved_Remark"].ToString();
                                        ////

                                        for (int cnt = 0; cnt <= ds1.Tables[1].Rows.Count - 1; cnt++)
                                        {

                                            foreach (DataListItem dtlItem in datalist_Employee.Items)
                                            {
                                                CheckBox chkDL_Select_Centre = (CheckBox)dtlItem.FindControl("chkCheck");
                                                Label Request_EntryCode = (Label)dtlItem.FindControl("Request_EntryCode");
                                                Label lblItem_Code_DT = (Label)dtlItem.FindControl("lblItem_Code_DT");
                                                Label lblAssetNo_DT = (Label)dtlItem.FindControl("lblAssetNo_DT");
                                                TextBox txtAssetNo = (TextBox)dtlItem.FindControl("txtAssetNo");
                                                Label lblItem_EAN_No = (Label)dtlItem.FindControl("lblItem_EAN_No");
                                                TextBox txtEAN_No = (TextBox)dtlItem.FindControl("txtEAN_No");
                                                //txtAssetNo.Visible = false;
                                                //lblAssetNo_DT.Visible = true;

                                                if (Convert.ToString(Request_EntryCode.Text).Trim() == Convert.ToString(ds1.Tables[1].Rows[cnt]["Request_EntryCode"]).Trim() && Convert.ToString(lblItem_Code_DT.Text).Trim() == Convert.ToString(ds1.Tables[1].Rows[cnt]["Item_Code"]).Trim())
                                                {
                                                    chkDL_Select_Centre.Checked = true;
                                                    //count = count + 1;
                                                    break; // TODO: might not be correct. Was : Exit For
                                                }
                                            }

                                        }

                                        /////
                                    }
                                    else
                                    {
                                        datalist_Employee.DataSource = null;
                                        datalist_Employee.DataBind();


                                    }
                                }
                            }

                        }
                        else
                        {
                            Show_Error_Success_Box("E", "Records Not Found..");
                            return;
                        }
                    }
                    else
                    {
                    }


                    if (OptionCode == "1")
                    {
                    }
                    else
                    {
                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            txtTotalQuantity.Text = ds1.Tables[0].Rows[0]["Total_Quantity"].ToString();
                            txtTotalItems.Text = ds1.Tables[0].Rows[0]["Total_Item_Count"].ToString();
                        }

                        if (ds1.Tables[1].Rows.Count > 0)
                        {
                            DataList2.DataSource = ds1.Tables[1];
                            DataList2.DataBind();


                            dlQuestion.DataSource = ds1.Tables[1];
                            dlQuestion.DataBind();
                        }
                        else
                        {
                            DataList2.DataSource = null;
                            DataList2.DataBind();

                            dlQuestion.DataSource = null;
                            dlQuestion.DataBind();
                        }
                    }


                }
            }
            else if (e.CommandName == "comAuthorise")
            {
                Clear_Error_Success_Box();
                lblAuthPkey.Text = "";
                ControlVisibility("Authorise");
                lblapprovedRemark.Text = "";
                dlItemListAuthorise.DataSource = null;
                dlItemListAuthorise.DataBind();

                lblAuthPkey.Text = e.CommandArgument.ToString();
                string pky = e.CommandArgument.ToString();
                string From_Location_Code = "";

                DataSet ds1 = ProductController.Get_FinishedGood_ItemById(3, pky);

                 if (ds1.Tables[0].Rows.Count > 0)
                 {

                     ddlAddLocationType.SelectedValue = ds1.Tables[0].Rows[0]["Location_Type_code"].ToString();
                     lblAddVoucherDate.Text = ds1.Tables[0].Rows[0]["Date"].ToString();
                     lbladdVoucherNo.Text = ds1.Tables[0].Rows[0]["Voucher_Code"].ToString();
                     txtRequestCode.Text = ds1.Tables[0].Rows[0]["Request_Code"].ToString();

                 }
                 if (ddlAddLocationType.SelectedItem.ToString().Trim() == "Godown")
                 {

                     tbladdFr_Godown.Visible = true;
                     tbladdFr_Function.Visible = false;
                     tbladdFr_Division.Visible = false;
                     tbladdFr_Center.Visible = false;
                     ddladdGodown.SelectedValue = ds1.Tables[0].Rows[0]["Location_code"].ToString();
                 }
                 else if (ddlAddLocationType.SelectedItem.ToString().Trim() == "Function")
                 {
                     tbladdFr_Function.Visible = true;
                     tbladdFr_Godown.Visible = false;
                     tbladdFr_Division.Visible = false;
                     tbladdFr_Center.Visible = false;
                     ddladdFunction.SelectedValue = ds1.Tables[0].Rows[0]["Location_Code"].ToString();


                 }
                 else if (ddlAddLocationType.SelectedItem.ToString().Trim() == "Center")
                 {
                     tbladdFr_Division.Visible = true;
                     tbladdFr_Center.Visible = true;
                     tbladdFr_Function.Visible = false;
                     tbladdFr_Godown.Visible = false;
                     ddladdDivision.SelectedValue = ds1.Tables[0].Rows[0]["FromDivision"].ToString();

                     FillDDL_FRADDSearch_Centre();
                     ddladdCenter.SelectedValue = ds1.Tables[0].Rows[0]["Location_code"].ToString();


                 }


                if (ddlAddLocationType.SelectedItem.Text == "Godown")
                {
                    From_Location_Code = ddladdGodown.SelectedValue;
                }
                else if (ddlAddLocationType.SelectedItem.Text == "Function")
                {
                    From_Location_Code = ddladdFunction.SelectedValue;
                }
                else if (ddlAddLocationType.SelectedItem.Text == "Center")
                {
                    From_Location_Code = ddladdCenter.SelectedValue;
                }

               // DataSet ds = ProductController.GetVoucherDetailsForAuthorization(5, e.CommandArgument.ToString());
                DataSet ds = ProductController.GetVoucherDetailsForAuthorization( 5, e.CommandArgument.ToString(),ddlAddLocationType.SelectedValue.ToString().Trim(), From_Location_Code, txtRequestCode.Text.Trim());



                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblAuthorised.Text = ds.Tables[0].Rows[0]["Is_Authorised"].ToString();
                    lblLocationType_Auth.Text = ds.Tables[0].Rows[0]["Location_type"].ToString();
                    lbllocation_Auth.Text = ds.Tables[0].Rows[0]["Location"].ToString();
                    lblRequestCode_Auth.Text = ds.Tables[0].Rows[0]["Request_Code"].ToString();
                    lblVoucherNo_Auth.Text = ds.Tables[0].Rows[0]["Voucher_code"].ToString();
                    lblVoucherdate_Auth.Text = ds.Tables[0].Rows[0]["Date"].ToString();

                    if (ds.Tables[0].Rows[0]["Is_Authorised"].ToString() == "1")
                    {
                        btnAuthorise.Visible = false;
                        Flag_Authorised.Visible = true;
                    }
                    else if (ds.Tables[0].Rows[0]["Is_Authorised"].ToString() == "0")
                    {
                        btnAuthorise.Visible = true;
                        Flag_Authorised.Visible = false;
                    }

                  
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        if (ds.Tables[1].Rows[0]["User_Code"].ToString() == "UT001")
                        {
                            ControlVisibility("Student");
                            dlItemListAuthorise.DataSource = ds.Tables[1];
                            dlItemListAuthorise.DataBind();
                        }
                        if (ds.Tables[1].Rows[0]["User_Code"].ToString() == "UT003")
                        {
                            ControlVisibility("Teacher");
                            ddlteacher.DataSource = ds.Tables[1];
                            ddlteacher.DataBind();
                        }
                        if (ds.Tables[1].Rows[0]["User_Code"].ToString() == "UT004")
                        {
                            ControlVisibility("Employee");
                            ddlEmployee.DataSource = ds.Tables[1];
                            ddlEmployee.DataBind();
                        }
                       
                        lblapprovedRemark.Text = ds.Tables[2].Rows[0]["Approved_Remark"].ToString();
                      //  UpdatePanel3.Update();

                    }
                    else
                    {
                        dlItemListAuthorise.DataSource = null;
                        dlItemListAuthorise.DataBind();

                        ddlteacher.DataSource = null;
                        ddlteacher.DataBind();

                        ddlEmployee.DataSource = null;
                        ddlEmployee.DataBind();
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

    protected void btnCloseAuthorise_Click(object sender, EventArgs e)
    {
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
    protected void chkAttendanceAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox s = sender as CheckBox;

        //Set checked status of hidden check box to items in grid
        foreach (DataListItem dtlItem in datalist_Student.Items)
        {
            CheckBox chkitemck = (CheckBox)dtlItem.FindControl("chkCheck");
            //System.Web.UI.HtmlControls.HtmlInputCheckBox chkitemck = (System.Web.UI.HtmlControls.HtmlInputCheckBox)dtlItem.FindControl("chkDL_Select_Center");
            chkitemck.Checked = s.Checked;
        }
    }
    protected void chkTeachereAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox s = sender as CheckBox;

        //Set checked status of hidden check box to items in grid
        foreach (DataListItem dtlItem in datalist_Teacher.Items)
        {
            CheckBox chkitemck = (CheckBox)dtlItem.FindControl("chkCheck");
            //System.Web.UI.HtmlControls.HtmlInputCheckBox chkitemck = (System.Web.UI.HtmlControls.HtmlInputCheckBox)dtlItem.FindControl("chkDL_Select_Center");
            chkitemck.Checked = s.Checked;
        }
    }

    protected void chkEmployeeAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox s = sender as CheckBox;

        //Set checked status of hidden check box to items in grid
        foreach (DataListItem dtlItem in datalist_Employee.Items)
        {
            CheckBox chkitemck = (CheckBox)dtlItem.FindControl("chkCheck");
            //System.Web.UI.HtmlControls.HtmlInputCheckBox chkitemck = (System.Web.UI.HtmlControls.HtmlInputCheckBox)dtlItem.FindControl("chkDL_Select_Center");
            chkitemck.Checked = s.Checked;
        }
    }


    protected void btnAuthorise_Click(object sender, EventArgs e)
    {
        try
        {
            Clear_Error_Success_Box();

            if (lblAuthPkey.Text == "")
            {
                Show_Error_Success_Box("E", "Select Voucher");
                //ddlAddLocationType.Focus();
                return;

            }

            string ResultId = "";

            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];

            ResultId = ProductController.Update_FinishedGoodForAuthFlat(6, lblAuthPkey.Text.Trim(), UserID);

            if (ResultId == "1")
            {
                ControlVisibility("Search");
                FillGrid();
                Show_Error_Success_Box("S", "Authorisation Done Successfully");

            }
            else if (ResultId == "-1")
            {
                Show_Error_Success_Box("S", "Error Occured During Authorisation.....");
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
        string filenamexls1 = "Finished Goods_" + DateTime.Now + ".xls";
        Response.AddHeader("Content-Disposition", "inline;filename=" + filenamexls1);
        HttpContext.Current.Response.Charset = "utf-8";
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");
        //sets font
        HttpContext.Current.Response.Write("<font style='font-size:10.0pt; font-family:Calibri;'>");
        HttpContext.Current.Response.Write("<BR><BR><BR>");
        HttpContext.Current.Response.Write("<Table border='1'  borderColor='#000000' cellSpacing='0' cellPadding='0' style='font-size:10.0pt; font-family:Calibri; text-align:center;'> <TR style='color: #fff; background: black;text-align:center;'><TD Colspan='9'>Finished Goods</b></TD></TR>");
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
    protected void btnexportStudent_Details_Click(object sender, EventArgs e)
    {

        StudentDetsils.Visible = true;

        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        string filenamexls1 = "Student Details_" + DateTime.Now + ".xls";
        Response.AddHeader("Content-Disposition", "inline;filename=" + filenamexls1);
        HttpContext.Current.Response.Charset = "utf-8";
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");
        //sets font
        HttpContext.Current.Response.Write("<font style='font-size:10.0pt; font-family:Calibri;'>");
        HttpContext.Current.Response.Write("<BR><BR><BR>");
        HttpContext.Current.Response.Write("<Table border='1'  borderColor='#000000' cellSpacing='0' cellPadding='0' style='font-size:10.0pt; font-family:Calibri; text-align:center;'> <TR style='color: #fff; background: black;text-align:center;'><TD Colspan='9'>Student Details</b></TD></TR>");
        Response.Charset = "";
        this.EnableViewState = false;
        System.IO.StringWriter oStringWriter1 = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter oHtmlTextWriter1 = new System.Web.UI.HtmlTextWriter(oStringWriter1);
        //this.ClearControls(dladmissioncount)
        StudentDetsils.RenderControl(oHtmlTextWriter1);
        Response.Write(oStringWriter1.ToString());
        Response.Flush();
        Response.End();

        StudentDetsils.Visible = false;
    }
    protected void btnexportTeacher_Details_Click(object sender, EventArgs e)
    {

        Teacher_Details.Visible = true;

        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        string filenamexls1 = "Student Details_" + DateTime.Now + ".xls";
        Response.AddHeader("Content-Disposition", "inline;filename=" + filenamexls1);
        HttpContext.Current.Response.Charset = "utf-8";
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");
        //sets font
        HttpContext.Current.Response.Write("<font style='font-size:10.0pt; font-family:Calibri;'>");
        HttpContext.Current.Response.Write("<BR><BR><BR>");
        HttpContext.Current.Response.Write("<Table border='1'  borderColor='#000000' cellSpacing='0' cellPadding='0' style='font-size:10.0pt; font-family:Calibri; text-align:center;'> <TR style='color: #fff; background: black;text-align:center;'><TD Colspan='9'>Teacher Details</b></TD></TR>");
        Response.Charset = "";
        this.EnableViewState = false;
        System.IO.StringWriter oStringWriter1 = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter oHtmlTextWriter1 = new System.Web.UI.HtmlTextWriter(oStringWriter1);
        //this.ClearControls(dladmissioncount)
        Teacher_Details.RenderControl(oHtmlTextWriter1);
        Response.Write(oStringWriter1.ToString());
        Response.Flush();
        Response.End();

        Teacher_Details.Visible = false;
    }
    protected void btnexportEmployee_Details_Click(object sender, EventArgs e)
    {

        datalist_EmployeeDetails.Visible = true;

        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        string filenamexls1 = "Student Details_" + DateTime.Now + ".xls";
        Response.AddHeader("Content-Disposition", "inline;filename=" + filenamexls1);
        HttpContext.Current.Response.Charset = "utf-8";
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");
        //sets font
        HttpContext.Current.Response.Write("<font style='font-size:10.0pt; font-family:Calibri;'>");
        HttpContext.Current.Response.Write("<BR><BR><BR>");
        HttpContext.Current.Response.Write("<Table border='1'  borderColor='#000000' cellSpacing='0' cellPadding='0' style='font-size:10.0pt; font-family:Calibri; text-align:center;'> <TR style='color: #fff; background: black;text-align:center;'><TD Colspan='9'>Employee Details</b></TD></TR>");
        Response.Charset = "";
        this.EnableViewState = false;
        System.IO.StringWriter oStringWriter1 = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter oHtmlTextWriter1 = new System.Web.UI.HtmlTextWriter(oStringWriter1);
        //this.ClearControls(dladmissioncount)
        datalist_EmployeeDetails.RenderControl(oHtmlTextWriter1);
        Response.Write(oStringWriter1.ToString());
        Response.Flush();
        Response.End();

        datalist_EmployeeDetails.Visible = false;
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        dlItemListAuthorise.Visible = true;

        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        string filenamexls1 = "Student_" + DateTime.Now + ".xls";
        Response.AddHeader("Content-Disposition", "inline;filename=" + filenamexls1);
        HttpContext.Current.Response.Charset = "utf-8";
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");
        //sets font
        HttpContext.Current.Response.Write("<font style='font-size:10.0pt; font-family:Calibri;'>");
        HttpContext.Current.Response.Write("<BR><BR><BR>");
        HttpContext.Current.Response.Write("<Table border='1'  borderColor='#000000' cellSpacing='0' cellPadding='0' style='font-size:10.0pt; font-family:Calibri; text-align:center;'> <TR style='color: #fff; background: black;text-align:center;'><TD Colspan='10'>Student Details</b></TD></TR>");
        Response.Charset = "";
        this.EnableViewState = false;
        System.IO.StringWriter oStringWriter1 = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter oHtmlTextWriter1 = new System.Web.UI.HtmlTextWriter(oStringWriter1);
        //this.ClearControls(dladmissioncount)
        dlItemListAuthorise.RenderControl(oHtmlTextWriter1);
        Response.Write(oStringWriter1.ToString());
        Response.Flush();
        Response.End();

        dlItemListAuthorise.Visible = false;
    }
    protected void teacherexoprt_Click(object sender, EventArgs e)
    {
        ddlteacher.Visible = true;

        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        string filenamexls1 = "Teacher_" + DateTime.Now + ".xls";
        Response.AddHeader("Content-Disposition", "inline;filename=" + filenamexls1);
        HttpContext.Current.Response.Charset = "utf-8";
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");
        //sets font
        HttpContext.Current.Response.Write("<font style='font-size:10.0pt; font-family:Calibri;'>");
        HttpContext.Current.Response.Write("<BR><BR><BR>");
        HttpContext.Current.Response.Write("<Table border='1'  borderColor='#000000' cellSpacing='0' cellPadding='0' style='font-size:10.0pt; font-family:Calibri; text-align:center;'> <TR style='color: #fff; background: black;text-align:center;'><TD Colspan='9'>Teacher Details</b></TD></TR>");
        Response.Charset = "";
        this.EnableViewState = false;
        System.IO.StringWriter oStringWriter1 = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter oHtmlTextWriter1 = new System.Web.UI.HtmlTextWriter(oStringWriter1);
        //this.ClearControls(dladmissioncount)
        ddlteacher.RenderControl(oHtmlTextWriter1);
        Response.Write(oStringWriter1.ToString());
        Response.Flush();
        Response.End();

        ddlteacher.Visible = false;
    }
    protected void EmployeeExoprt_Click(object sender, EventArgs e)
    {
        ddlEmployee.Visible = true;

        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        string filenamexls1 = "Employee_" + DateTime.Now + ".xls";
        Response.AddHeader("Content-Disposition", "inline;filename=" + filenamexls1);
        HttpContext.Current.Response.Charset = "utf-8";
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");
        //sets font
        HttpContext.Current.Response.Write("<font style='font-size:10.0pt; font-family:Calibri;'>");
        HttpContext.Current.Response.Write("<BR><BR><BR>");
        HttpContext.Current.Response.Write("<Table border='1'  borderColor='#000000' cellSpacing='0' cellPadding='0' style='font-size:10.0pt; font-family:Calibri; text-align:center;'> <TR style='color: #fff; background: black;text-align:center;'><TD Colspan='9'>Employee Details</b></TD></TR>");
        Response.Charset = "";
        this.EnableViewState = false;
        System.IO.StringWriter oStringWriter1 = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter oHtmlTextWriter1 = new System.Web.UI.HtmlTextWriter(oStringWriter1);
        //this.ClearControls(dladmissioncount)
        ddlEmployee.RenderControl(oHtmlTextWriter1);
        Response.Write(oStringWriter1.ToString());
        Response.Flush();
        Response.End();

        ddlEmployee.Visible = false;
    }
}
