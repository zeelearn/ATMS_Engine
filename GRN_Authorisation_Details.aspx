<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="GRN_Authorisation_Details.aspx.cs" Inherits="GRN_Authorisation_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
   <script type="text/javascript">

       function openModalDivCOnfirmation() {
           $('#DivConfirmation').modal({
               backdrop: 'static'
           })

           $('#DivConfirmation').modal('show');
       }

       function NumberOnly() {
           var AsciiValue = event.keyCode
           if ((AsciiValue >= 48 && AsciiValue <= 57))
               event.returnValue = true;
           else
               event.returnValue = false;
       }

       function CharacterOnly() {
           var AsciiValue = event.keyCode
           if ((AsciiValue >= 33 && AsciiValue <= 64) || (AsciiValue == 8 || AsciiValue == 127) || (AsciiValue >= 91 && AsciiValue <= 96) || (AsciiValue >= 123 && AsciiValue <= 126))
               event.returnValue = false;
           else
               event.returnValue = true;
       }

       function openModalDivOverride() {
           $('#DivOverrid').modal({
               backdrop: 'static'
           })

           $('#DivOverrid').modal('show');
       }

       function ValidateEnterKey(evt) {
           if (evt.keyCode == 13) //detect Enter key
           {
               return false;
           }
           else {
               return true;
           }
       }

       function autoTab(input, len, e) {
           var keyCode = (isNN) ? e.which : e.keyCode;
           var filter = (isNN) ? [0, 8, 9] : [0, 8, 9, 16, 17, 18, 37, 38, 39, 40, 46];
           if (input.value.length >= len) {
               input.value = input.value.slice(0, len);
               input.form[(getIndex(input) + 1)].focus();
           }
       }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContainer" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="breadcrumbs" class="position-relative" style="height: 53px">
        <ul class="breadcrumb" style="height: 15px">
            <li><i class="icon-home"></i><a href="Homepage.aspx">Home</a><span class="divider"><i
                class="icon-angle-right"></i></span></li>
            <li>
                <h4 class="blue">
                    GRN Authorisation Details<span class="divider"></span></h4>
            </li>
        </ul>
        <div id="nav-search">
            <!-- /btn-group -->
       <%--     <asp:Button class="btn  btn-app btn-success btn-mini radius-4" runat="server" ID="BtnAdd"
                Text="Add" OnClick="BtnAdd_Click" />
            <asp:Button class="btn  btn-app btn-primary btn-mini radius-4  " Visible="true" runat="server"
                ID="BtnShowSearchPanel" Text="Search" OnClick="BtnShowSearchPanel_Click" />--%>
        </div>
        <!--#nav-search-->
    </div>
    <div id="page-content" class="clearfix">
        <!--/page-header-->
        <div class="row-fluid">
            <!-- -->
            <!-- PAGE CONTENT BEGINS HERE -->
            <asp:UpdatePanel ID="UpdatePanelMsgBox" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="alert alert-block alert-success" id="Msg_Success" visible="false" runat="server">
                        <button type="button" class="close" data-dismiss="alert">
                            <i class="icon-remove"></i>
                        </button>
                        <p>
                            <strong><i class="icon-ok"></i></strong>
                            <asp:Label ID="lblSuccess" runat="server" Text="Label"></asp:Label>
                        </p>
                    </div>
                    <div class="alert alert-error" id="Msg_Error" visible="false" runat="server">
                        <button type="button" class="close" data-dismiss="alert">
                            <i class="icon-remove"></i>
                        </button>
                        <p>
                            <strong><i class="icon-remove"></i>Error!</strong>
                            <asp:Label ID="lblerror" runat="server" Text="Label"></asp:Label>
                        </p>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div id="DivAuthorise" runat="server" visible="true">
                <div class="widget-box">
                    <div class="widget-header widget-header-small header-color-dark">
                        <h5 class="modal-title">
                            GRN Authorisation
                            <asp:Label runat="server" ID="Label33" Visible="false"></asp:Label>
                            <asp:Label runat="server" ID="lblAuthorised" Visible="false"></asp:Label>
                        </h5>
                    </div>
                    <div class="widget-body">
                        <div class="widget-body-inner">
                            <div class="widget-main">
                                <asp:UpdatePanel ID="UpdatePanelAdd" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <table cellpadding="3" class="table table-striped table-bordered table-condensed">
                                            <tr>
                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" class="table-hover" style="border-style: none; width: 100%;">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label34" runat="server">Entry Date</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:TextBox ID="txtEntryDate_Auth" runat="server" Text="" Width="205px" Enabled="False"></asp:TextBox>

                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" class="table-hover" style="border-style: none; width: 100%;">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label35" runat="server" CssClass="red">PO Status</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                               <asp:Label ID="lblPONo_Add" runat="server"></asp:Label>
                                                                <%--<asp:DropDownList ID="ddlpostatus_Auth" runat="server" CssClass="chzn-select" Width="215px"
                                                                    Enabled="False">
                                                                    <asp:ListItem>Select</asp:ListItem>
                                                                    <asp:ListItem>Yes</asp:ListItem>
                                                                    <asp:ListItem>No</asp:ListItem>
                                                                </asp:DropDownList>--%>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" class="table-hover" style="border-style: none; width: 100%;"
                                                        runat="server" id="PONOID_Auth">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label36" runat="server" CssClass="red">PO No.</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label ID="lblPono" runat="server" CssClass="red">PO No.</asp:Label>
                                                                <%--<asp:DropDownList ID="ddlpoNo_Auth" runat="server" CssClass="chzn-select" Width="215px"
                                                                    AutoPostBack="True" 
                                                                    Enabled="False">
                                                                </asp:DropDownList>--%>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table id="SuppID_Auth" runat="server" cellpadding="0" class="table-hover" style="border-style: none;
                                                        width: 100%;" visible="false">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label37" runat="server" CssClass="red">Supplier</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                               <asp:Label ID="lblSuppName11" runat="server"></asp:Label>
                                                                <%--<asp:DropDownList ID="ddlSupplier_Auth" runat="server" CssClass="chzn-select" Width="215px"
                                                                    Enabled="False">
                                                                </asp:DropDownList>--%>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                        <tr>
                                                            <td class="span2" style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label39" runat="server" CssClass="red">Challan No.</asp:Label>
                                                            </td>
                                                            <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                            <asp:Label ID="lblDCNO" runat="server"></asp:Label>
                                                                <%--<asp:TextBox ID="txtDCNO_Auth" runat="server" Text="" Width="205px" ReadOnly="True"></asp:TextBox>--%>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label40" runat="server" CssClass="red">DC Date</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                             <input class="span11 date-picker" id="txtDCDate" type="text" data-date-format="dd-mm-yyyy"
                                                                    runat="server" readonly="readonly" />
                                                               <%-- <asp:TextBox ID="txtDCDate_Auth" runat="server" Text="" Width="205px" ReadOnly="True"></asp:TextBox>--%>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="lblSup_Auth">Supplier</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label ID="lblSuppName" runat="server"></asp:Label>
                                                                <asp:Label ID="lblsuppliercode" runat="server" Visible="False"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                        <tr>
                                                            <td class="span2" style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label44" runat="server">Invoice No</asp:Label>
                                                            </td>
                                                            <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                            <asp:Label ID="lblInvoiceNo_Add" runat="server"></asp:Label>
                                                                <%--<asp:TextBox ID="txtInvoice_No_Auth" runat="server" Text="" Width="205px" ReadOnly="True"></asp:TextBox>--%>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label45" runat="server">Invoice Date</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <input class="span11 date-picker" id="txtInvoiceDT" type="text" data-date-format="dd-mm-yyyy"
                                                                    runat="server" readonly="readonly" />
                                                              <%--  <asp:TextBox ID="txtInvoiceDate_Auth" runat="server" ReadOnly="True" Text="" Width="205px"></asp:TextBox>--%>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label46">Invoice Value</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                               <%-- <asp:TextBox ID="txtInvoiceValue_Auth" runat="server" Text="" Width="205px" onkeypress="return NumberOnly(event);"
                                                                    ReadOnly="True"></asp:TextBox>--%>
                                                                    <asp:Label ID="lblInvoiceValue_Add" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                        <tr>
                                                            <td class="span2" style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label47" runat="server" CssClass="red">Location</asp:Label>
                                                            </td>
                                                            <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                               <%-- <asp:DropDownList ID="ddlLocation_Auth" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Location Type" Width="215px" 
                                                                    Enabled="False" />--%>
                                                                     <asp:Label ID="lblTransferFR_SR" runat="server"></asp:Label>
                                                                <asp:Label ID="ddlTransferFR_SR1" runat="server" Visible="False"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                        runat="server" id="tblFr_Godown" visible="false">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="lblGodownName" runat="server" CssClass="red">Godown Name</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <%--<asp:DropDownList ID="ddlGodown_Auth" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Godown" Width="215px" Enabled="False" />--%>
                                                                    <asp:Label ID="lblgodownFR_SR" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                        runat="server" id="tblFr_Division" visible="false">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="lblDivision" runat="server" CssClass="red">Division Name</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                             <%--   <asp:DropDownList ID="ddlDivision_Auth" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Division" Width="215px" 
                                                                    Enabled="False" />--%>
                                                                        <asp:Label ID="lblDivisionFR_SR" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                        runat="server" id="tblFr_Function" visible="false">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                               <asp:Label ID="lblfunction" runat="server" CssClass="red">Function Name</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                             <%--   <asp:DropDownList ID="ddlFunction_Auth" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Function" Width="215px" Enabled="False" />--%>
                                                                    <asp:Label ID="lblFunctionFR_SR" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%"
                                                        runat="server" id="tblFr_Center" visible="false">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                 <asp:Label ID="lblCenterName" runat="server" CssClass="red">Center Name</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                               <%-- <asp:DropDownList ID="ddlCenter_Auth" runat="server" CssClass="chzn-select" data-placeholder="Select Center"
                                                                    Width="215px" Enabled="False" />--%>
                                                                       <asp:Label ID="lblCenterFR_SR" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                        <asp:DataList ID="dlItemListAuthorise" CssClass="table table-striped table-bordered table-hover"
                                            runat="server" Width="100%" >
                                            <HeaderTemplate>
                                                <%--  <asp:CheckBox ID="chkAuthoriseAll" runat="server" AutoPostBack="True" OnCheckedChanged="chkAuthoriseAll_CheckedChanged" />
                                                   <span class="lbl"></span></th>--%>
                                              <%--  <b>
                                                    <asp:CheckBox ID="chkAuthoriseAll" runat="server" AutoPostBack="True"  />
                                                    <span class="lbl"></span></b></th>--%>
                                           <%--     <th style="width: 10%; text-align: center;">--%>
                                                   <b> Item Code </b>
                                                </th>
                                                <th style="width: 10%; text-align: center;">
                                                    Inward Entry Code
                                                </th>
                                                <th style="width: 30%; text-align: center;">
                                                    Item Name
                                                </th>
                                                <th style="width: 15%; text-align: center;">
                                                    Challan Qty
                                                </th>
                                                <th style="width: 20%; text-align: center;">
                                                    EAN No.
                                                </th>
                                              <%--  <th style="width: 10%; text-align: center;">--%>
                                            </HeaderTemplate>
                                            <ItemTemplate>

                                             <%--   <center>--%>
                                                    <%--<asp:CheckBox ID="chkCheck" runat="server" AutoPostBack="true" Checked="false" Visible='<%#(string)DataBinder.Eval(Container.DataItem,"Is_Authorised") == "1" ? false : true%>' />--%>
                                                   <%-- <span class="lbl"></span>--%>
                                          <%--      </center>--%>
                                             <%--   </td>
                                                <td>--%>
                                                    <asp:Label ID="lblMaterialCode_DT" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"lblMaterialCode_DT")%>' />
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblInwardEntry_Code" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"InwardEntry_Code")%>' />
                                                </td>
                                                <td style="width: 20%; text-align: left;">
                                                    <asp:Label ID="lblMaterialName_DT" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"lblMaterialName_DT")%>' />
                                                </td>
                                                <td style="width: 10%; text-align: left;">
                                                    <asp:TextBox ID="txtChallanQty_DT" runat="server" Text="" Width="85%" onkeypress="return NumberOnly()"
                                                        Visible="false" />
                                                    <asp:Label ID="lblChallanQty_DT" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"lblChallanQty_DT")%>' />
                                                </td>
                                                <td style="width: 15%; text-align: left;">
                                                    <asp:Label ID="lblBarcode_DT" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"lblBarcode_DT")%>' />
                                                    <%--<asp:Label ID="lblAssetType" runat="server" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem,"AssetType")%>' />--%>
                                                </td>
                                             <%--   <td style="width: 8%; text-align: center;">
                                                   <asp:Label ID="Label1" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"lblIs_Authorised")%>' />
                                                    <a id="lbl_DLError" runat="server" title="Error" data-rel="tooltip" href="#">
                                                        <asp:Panel ID="icon_Error" runat="server" class="badge badge-important" Visible="false">
                                                            <i class="icon-bolt"></i>
                                                        </asp:Panel>
                                                    </a>
                                                    </td>--%>
                                                    <asp:Label ID="lblSuccess" runat="server" Text='Success' CssClass='green' Visible="false" />
                                            </ItemTemplate>
                                        </asp:DataList>
                                        <br />
                                    </ContentTemplate>
                                
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="widget-main alert-block alert-success  alert- " style="text-align: center;">
                            <!--Button Area -->
                        <%--    <asp:Label runat="server" ID="Label38" Text="" ForeColor="Red" />--%>
                           <%-- <asp:Button class="btn btn-app btn-success btn-mini radius-4" ID="btnAuthorise" runat="server"
                                Text="Authorise" ValidationGroup="UcValidate" Width="80px" OnClick="btnAuthorise_Click" />--%>
                            <%-- <asp:Label ID="lblDLMaterial_Code" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"Item_Id")%>' />--%>
                             <button class="btn btn-app btn-primary btn-mini radius-4" id="Button3" runat="server"
                                onclick="javascript:window.close()">
                                Close</button>
                            <%--<asp:ValidationSummary ID="ValidationSummary3" ShowSummary="false" DisplayMode="List"
                                ShowMessageBox="true" ValidationGroup="UcValidate" runat="server" />--%>
                          <%--  <asp:Button class="btn btn-app btn-primary btn-mini radius-4" ID="BtnPrint" Visible="true"
                                runat="server" Text="Print" OnClick="BtnPrint_Click" />
                            <asp:ValidationSummary ID="ValidationSummary1" ShowSummary="false" DisplayMode="List"
                                ShowMessageBox="true" ValidationGroup="UcValidate" runat="server" />--%>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
