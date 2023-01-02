<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeFile="Manage_GRN.aspx.cs" Inherits="Manage_GRN" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        function openModalDivCOnfirmation() {
            $('#DivConfirmation').modal({
                backdrop: 'static'
            })

            $('#DivConfirmation').modal('show');
        }
        function openModalDivCOnfirmationAset() {
            $('#DivCOnfirmationAsset').modal({
                backdrop: 'static'
            })

            $('#DivCOnfirmationAsset').modal('show');
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
<asp:Content ID="Content2" ContentPlaceHolderID="MainContainer" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="breadcrumbs" class="position-relative" style="height: 53px">
        <ul class="breadcrumb" style="height: 15px">
            <li><i class="icon-home"></i><a href="Homepage.aspx">Home</a><span class="divider"><i
                class="icon-angle-right"></i></span></li>
            <li>
                <h4 class="blue">
                    GRN Entry<span class="divider"></span></h4>
            </li>
        </ul>
        <div id="nav-search">
            <!-- /btn-group -->
            <asp:Button class="btn  btn-app btn-success btn-mini radius-4" runat="server" ID="BtnAdd"
                Text="Add" OnClick="BtnAdd_Click" />
            <asp:Button class="btn  btn-app btn-primary btn-mini radius-4  " Visible="true" runat="server"
                ID="BtnShowSearchPanel" Text="Search" OnClick="BtnShowSearchPanel_Click" />
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
            <div id="DivSearchPanel" runat="server">
                <div class="widget-box">
                    <div class="widget-header widget-header-small header-color-dark">
                        <h5>
                            Search Options
                        </h5>
                    </div>
                    <div class="widget-body">
                        <div class="widget-body-inner">
                            <div class="widget-main">
                                <asp:UpdatePanel ID="UpdatePanelSearch" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <table cellpadding="3" class="table table-striped table-bordered table-condensed">
                                            <tr>
                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                        <tr>
                                                            <td class="span2" style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label1" runat="server">Location</asp:Label>
                                                            </td>
                                                            <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddllocation_Search" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Location Type" Width="215px" OnSelectedIndexChanged="ddllocation_Search_SelectedIndexChanged" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                        runat="server" id="tblgodown" visible="false">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label3" runat="server">Godown</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlGodown_Search" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Godown" Width="215px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                        runat="server" id="tblDivision" visible="false">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label22" runat="server">Division</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddldivision_Search" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Division" Width="215px" OnSelectedIndexChanged="ddldivision_Search_SelectedIndexChanged" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                        runat="server" id="tblFunction" visible="false">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label26" runat="server">Function</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlFunction_Search" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Function" Width="215px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%"
                                                        runat="server" id="tblCenter" visible="false">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label28" runat="server">Center</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlCenter_Search" runat="server" CssClass="chzn-select" data-placeholder="Select Center"
                                                                    Width="215px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none; width: 139%;" class="table-hover">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label13" runat="server">Period</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <input id="id_date_range_picker_2" runat="server" class="id_date_range_picker_1"
                                                                    data-original-title="Date Range" data-placement="bottom" name="date-range-picker"
                                                                    placeholder="Date Search" readonly="readonly" style="width: 205px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none; width: 118%;" class="table-hover">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label57" runat="server">Supplier</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlSupplier_SR" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select supplier" Width="215px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label58" runat="server">Challan No.</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:TextBox ID="txtChallan_SR" runat="server" Text="" Width="205px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="widget-main alert-block alert-info" style="text-align: center;">
                                <!--Button Area -->
                                <asp:Button class="btn btn-app btn-primary  btn-mini radius-4" runat="server" ID="BtnSearch"
                                    Text="Search" ToolTip="Search" ValidationGroup="UcValidateSearch" OnClick="BtnSearch_Click" />
                                <asp:Button class="btn btn-app btn-grey btn-mini radius-4" ID="BtnClearSearch" Visible="true"
                                    runat="server" Text="Clear" OnClick="BtnClearSearch_Click" />
                                <asp:ValidationSummary ID="ValidationSummary2" ShowSummary="false" DisplayMode="List"
                                    ShowMessageBox="true" ValidationGroup="UcValidateSearch" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div id="DivResultPanel" runat="server" class="dataTables_wrapper" visible="false">
                <div class="widget-box">
                    <div class="table-header">
                        <table width="100%">
                            <tr>
                                <td class="span10">
                                    Total No of Records:
                                    <asp:Label runat="server" ID="lbltotalcount" Text="0" />
                                </td>
                                <td style="text-align: right" class="span2">
                                    <asp:LinkButton runat="server" ID="HLExport" ToolTip="Export" class="btn-small btn-danger icon-2x icon-download-alt"
                                        Height="25px" OnClick="HLExport_Click" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <asp:Repeater ID="dlGridDisplay" runat="server" OnItemCommand="dlGridDisplay_ItemCommand">
                    <HeaderTemplate>
                        <table class="table table-striped table-bordered table-hover Table2">
                            <thead>
                                <tr>
                                    <th>
                                        Inward Code
                                    </th>
                                    <th style="width: 10%; text-align: center;">
                                        Inward Date
                                    </th>
                                    <th style="width: 25%; text-align: center;">
                                        Supplier
                                    </th>
                                    <th style="width: 12%; text-align: center;">
                                        Challan No
                                    </th>
                                    <th style="width: 10%; text-align: center;">
                                        Challan Date
                                    </th>
                                    <th style="text-align: center;">
                                        Material
                                    </th>
                                    <th style="width: 13%; text-align: center;">
                                        Purchase Amount
                                    </th>
                                    <th style="width: 10%; text-align: center;">
                                        Is Authorised
                                    </th>
                                    <th style="width: 10%; text-align: center;">
                                        Action
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr class="odd gradeX">
                            <td>
                                <asp:Label ID="lblMenuCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Inward_Code")%>' />
                            </td>
                            <td style="width: 10%; text-align: left;">
                                <asp:Label ID="lblMenuName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Inward_date")%>' />
                            </td>
                            <td style="width: 25%; text-align: left;">
                                <asp:Label ID="lblMenuCss" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Vendor_Name")%>' />
                            </td>
                            <td style="width: 12%; text-align: left;">
                                <asp:Label ID="lblMenuParentcode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Challan_No")%>' />
                            </td>
                            <td style="width: 10%; text-align: left;">
                                <asp:Label ID="lblmenutype" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Challan_Date")%>' />
                            </td>
                            <td style="text-align: left;">
                                <asp:Label ID="Label2" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Total_Item_Count")%>' />
                            </td>
                            <td style="width: 13%; text-align: left;">
                                <asp:Label ID="lblmenulink" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Total_Purchase_Amount")%>' />
                            </td>
                            <td style="width: 13%; text-align: left;">
                                <asp:Label ID="lblAuthorised" runat="server" Visible="True" Text='<%# Convert.ToInt32( Eval("Is_Authorised")) == 1 ? "Yes":"No"  %>'
                                    CssClass='<%# Convert.ToInt32( Eval("Is_Authorised")) == 1 ? "label label-success":"label label-warning"  %>' />
                            </td>
                            <td style="width: 10%; text-align: center;">
                                <div class="inline position-relative">
                                    <asp:LinkButton ID="lnkEdit" ToolTip="Edit" class="btn-small btn-primary icon-info-sign"
                                        CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Inward_Code")%>' runat="server"
                                        CommandName="comEdit" Height="25px" />
                                    <asp:LinkButton ID="lnkAuthorise" ToolTip="Authorise" class="btn-small btn-warning  icon-lock"
                                        CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Inward_Code")%>' runat="server"
                                        CommandName="comAuthorise" Height="25px" />
                                    <asp:LinkButton ID="lnkUpdate" ToolTip="Uptade" class="btn-small btn-primary icon-info-sign"
                                        CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Inward_Code")%>' runat="server"
                                        CommandName="comUpdate" Height="25px" Visible="false" />
                                </div>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody> </table>
                    </FooterTemplate>
                </asp:Repeater>
                <asp:DataList ID="DataList1" CssClass="table table-striped table-bordered table-hover"
                    runat="server" Width="100%" Visible="false">
                    <HeaderTemplate>
                        <b>Inward Code</b> </th>
                        <th style="width: 12%; text-align: center;">
                            Inward Date
                        </th>
                        <th style="width: 12%; text-align: center;">
                            Supplier
                        </th>
                        <th style="width: 10%; text-align: center;">
                            Challan No
                        </th>
                        <th style="text-align: center;">
                            Challan Date
                        </th>
                        <th style="text-align: center;">
                            Material
                        </th>
                        <th style="text-align: center;">
                            Purchase Amount
                        </th>
                        <th style="text-align: center;">
                        Is Authorised
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblMenuCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Inward_Code")%>' />
                        </td>
                        <td style="width: 12%; text-align: left;">
                            <asp:Label ID="lblMenuName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Inward_date")%>' />
                        </td>
                        <td style="width: 12%; text-align: left;">
                            <asp:Label ID="lblMenuCss" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Vendor_Name")%>' />
                        </td>
                        <td style="width: 10%; text-align: left;">
                            <asp:Label ID="lblMenuParentcode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Challan_No")%>' />
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="lblmenutype" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Challan_Date")%>' />
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="Label2" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Total_Item_Count")%>' />
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="lblmenulink" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Total_Purchase_Amount")%>' />
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="lblActive" runat="server" Visible="True" Text='<%# Convert.ToInt32( Eval("Is_Authorised")) == 1 ? "Yes":"No"  %>' />
                        </td>
                    </ItemTemplate>
                </asp:DataList>
            </div>
            <div id="DivAddPanel" runat="server" visible="false">
                <div class="widget-box">
                    <div class="widget-header widget-header-small header-color-dark">
                        <h5 class="modal-title">
                            GRN Details
                            <asp:Label runat="server" ID="lblPkey" Visible="false"></asp:Label>
                            <asp:Label runat="server" ID="lblInwardEntryCodeRemove" Visible="false"></asp:Label>
                            <asp:Label runat="server" ID="lblInwardIsAuthorised" Visible="false"></asp:Label>
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
                                                    <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                        <tr>
                                                            <td class="span2" style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label8" runat="server" CssClass="red">Location</asp:Label>
                                                            </td>
                                                            <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlTransferFR_SR" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Location Type" Width="215px" OnSelectedIndexChanged="ddlTransferFR_SR_SelectedIndexChanged" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                        runat="server" id="tblFr_Godown" visible="false">
                                                        <tr>
                                                            <td class="span2" style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label9" runat="server" CssClass="red">Godown Name</asp:Label>
                                                            </td>
                                                            <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlgodownFR_SR" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Godown" Width="215px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                        runat="server" id="tblFr_Division" visible="false">
                                                        <tr>
                                                            <td class="span2" style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label10" runat="server" CssClass="red">Division Name</asp:Label>
                                                            </td>
                                                            <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlDivisionFR_SR" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Division" Width="215px" OnSelectedIndexChanged="ddlDivisionFR_SR_SelectedIndexChanged" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                        runat="server" id="tblFr_Function" visible="false">
                                                        <tr>
                                                            <td class="span2" style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label18" runat="server" CssClass="red">Function Name</asp:Label>
                                                            </td>
                                                            <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlFunctionFR_SR" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Function" Width="215px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%"
                                                        runat="server" id="tblFr_Center" visible="false">
                                                        <tr>
                                                            <td class="span2" style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label16" runat="server" CssClass="red">Center Name</asp:Label>
                                                            </td>
                                                            <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlCenterFR_SR" runat="server" CssClass="chzn-select" data-placeholder="Select Center"
                                                                    Width="215px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="span6" style="text-align: left; height: 38px;">
                                                    <table cellpadding="0" class="table-hover" style="border-style: none; width: 100%;">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label25" runat="server" CssClass="red">Budget Division</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlbudgetDivision" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Division" OnSelectedIndexChanged="ddlDivisionFR_SR_SelectedIndexChanged"
                                                                    Width="215px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span6" style="text-align: left; height: 38px;">
                                                </td>
                                                <td class="span6" style="text-align: left; height: 38px;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" class="table-hover" style="border-style: none; width: 100%;">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label32" runat="server">Entry Date</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:TextBox ID="txtEntryDate_Add" runat="server" Text="" Width="205px" Enabled="False"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" class="table-hover" style="border-style: none; width: 100%;">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label31" runat="server" CssClass="red">PO Status</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlPOStatus_Add" runat="server" CssClass="chzn-select" Width="215px"
                                                                    AutoPostBack="True" OnSelectedIndexChanged="ddlPOStatus_Add_SelectedIndexChanged">
                                                                    <asp:ListItem>Select</asp:ListItem>
                                                                    <asp:ListItem>Yes</asp:ListItem>
                                                                    <asp:ListItem>No</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span6" style="text-align: left">
                                                <table cellpadding="0" class="table-hover" style="border-style: none; width: 100%;"
                                                        runat="server" id="PONOID">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label30" runat="server" CssClass="red">PO No.</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlPONo_Add" runat="server" CssClass="chzn-select" Width="215px"
                                                                    AutoPostBack="True" OnSelectedIndexChanged="ddlPONo_Add_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table id="SuppID" runat="server" cellpadding="0" class="table-hover" style="border-style: none;
                                                        width: 100%;">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label29" runat="server" CssClass="red">Supplier</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlSupplier_Add" runat="server" CssClass="chzn-select" Width="215px">
                                                                </asp:DropDownList>
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
                                                                <asp:Label ID="Label59" runat="server" CssClass="red">Challan No.</asp:Label>
                                                            </td>
                                                            <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:TextBox ID="txtDCNO" runat="server" Text="" Width="205px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                        <tr>
                                                            <td class="span2" style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label27" runat="server" CssClass="red">DC Date</asp:Label>
                                                            </td>
                                                            <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                                <%--<div class="row-fluid input-append date">--%>
                                                                <input class="span11 date-picker" id="txtDCDate" type="text" data-date-format="dd-mm-yyyy"
                                                                    runat="server" readonly="readonly" />
                                                                <%-- </div>--%>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                        <tr>
                                                            <td class="span2" style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="lblsup">Supplier</asp:Label>
                                                            </td>
                                                            <td class="span4" style="border-style: none; text-align: left; width: 60%;">
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
                                                                <asp:Label ID="Label4" runat="server">Invoice No</asp:Label>
                                                            </td>
                                                            <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:TextBox ID="txtInvoiceNo_Add" runat="server" Text="" Width="205px"></asp:TextBox>
                                                                 
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                        <tr>
                                                            <td class="span2" style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label5" runat="server">Invoice Date</asp:Label>
                                                            </td>
                                                            <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                                <%-- <div class="row-fluid input-append date">--%>
                                                                <input class="span11 date-picker" id="txtInvoiceDT" type="text" data-date-format="dd-mm-yyyy"
                                                                    runat="server" readonly="readonly" />
                                                                <%-- </div>--%>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                        <tr>
                                                            <td class="span2" style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label6">Invoice Value</asp:Label>
                                                            </td>
                                                            <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:TextBox ID="txtInvoiceValue_Add" runat="server" Text="" Width="205px" onkeypress="return NumberOnly(event);"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                        <div class="row-fluid">
                                            <div class="span4" runat="server" id="DivAddItem">
                                                <div class="widget-box">
                                                    <div class="widget-header">
                                                        <h5 class="smaller">
                                                            Material Details
                                                        </h5>
                                                    </div>
                                                    <div class="widget-body">
                                                        <div class="widget-main ">
                                                            <table cellpadding="3" class="table table-striped table-bordered table-condensed">
                                                                <tr>
                                                                    <td class="span6" style="text-align: left">
                                                                        <table cellpadding="0" class="table-hover" style="border-style: none; width: 100%;"
                                                                            runat="server" id="tbl_poNo" visible="false">
                                                                            <tr>
                                                                                <td style="border-style: none; text-align: left; width: 25%;" class="span2">
                                                                                    <asp:Label ID="Label12" runat="server" CssClass="red">Material Code</asp:Label>
                                                                                    <span class="help-button ace-popover" data-trigger="hover" data-placement="right"
                                                                                        data-content="Enter Material name/ Material Code/ Barcode/ Serial No." title="Help">
                                                                                        ?</span>
                                                                                </td>
                                                                                <td style="border-style: none; text-align: left; width: 65%;" class="span4">
                                                                                    <asp:TextBox ID="txtItemMatCode" runat="server" Text="" Width="140px"></asp:TextBox><%--<button class="btn btn-info btn-small" runat ="server" id="Button2" onserverclick ="btnSearchItem_Click"><i class="icon-search"></i></button>--%>
                                                                                    <button class="btn btn-info btn-small" runat="server" id="Button2" onserverclick="btnSearchItem_Click"
                                                                                        style="height: 30px">
                                                                                        <i class="icon-search icon-on-right"></i>
                                                                                    </button>
                                                                                    <%--<asp:Button ID="Button2" runat="server" class="btn btn-purple btn-small icon-search"
                                                                                            OnClick="btnSearchItem_Click" Text="Search" />--%>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                        <table cellpadding="0" class="table-hover" style="border-style: none; width: 100%;"
                                                                            runat="server" id="tbl_poYes" visible="false">
                                                                            <tr>
                                                                                <td style="border-style: none; text-align: left; width: 35%;" class="span2">
                                                                                    <asp:Label ID="Label7" runat="server" CssClass="red">Select Material</asp:Label>
                                                                                </td>
                                                                                <td style="border-style: none; text-align: left; width: 65%;" class="span4">
                                                                                    <asp:DropDownList ID="ddlPOItems_Add" runat="server" CssClass="chzn-select" Width="165px"
                                                                                        AutoPostBack="True" OnSelectedIndexChanged="ddlPOItems_Add_SelectedIndexChanged">
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="span6" style="text-align: left">
                                                                        <table cellpadding="0" class="table-hover" style="border-style: none; width: 100%;">
                                                                            <tr>
                                                                                <td style="border-style: none; text-align: left; width: 35%;">
                                                                                    <asp:Label ID="Label11" runat="server">Material Code</asp:Label>
                                                                                </td>
                                                                                <td style="border-style: none; text-align: left; width: 65%;">
                                                                                    <asp:Label ID="lblMateCode" runat="server" Text=""></asp:Label>
                                                                                    <asp:Label ID="lblAssetNoType" runat="server" Visible="False"></asp:Label>
                                                                                    <asp:Label ID="lblcenter" runat="server" Visible="False"></asp:Label>
                                                                                    <asp:Label ID="lbldivision" runat="server" Visible="False"></asp:Label>
                                                                                    <asp:Label ID="lblpo_OrderEntry" runat="server" Visible="False"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="span6" style="text-align: left">
                                                                        <table cellpadding="0" class="table-hover" style="border-style: none; width: 100%;">
                                                                            <tr>
                                                                                <td style="border-style: none; text-align: left; width: 35%;">
                                                                                    <asp:Label ID="Label14" runat="server">Material Name</asp:Label>
                                                                                </td>
                                                                                <td style="border-style: none; text-align: left; width: 65%;">
                                                                                    <asp:Label ID="lblItemName" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="span6" style="text-align: left">
                                                                        <table cellpadding="0" class="table-hover" style="border-style: none; width: 100%;">
                                                                            <tr>
                                                                                <td style="border-style: none; text-align: left; width: 35%;">
                                                                                    <asp:Label ID="Label65" runat="server">Unit</asp:Label>
                                                                                </td>
                                                                                <td style="border-style: none; text-align: left; width: 65%;">
                                                                                    <asp:Label ID="lblUnit" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="span6" style="text-align: left">
                                                                        <table cellpadding="0" class="table-hover" style="border-style: none; width: 100%;">
                                                                            <tr>
                                                                                <td style="border-style: none; text-align: left; width: 35%;">
                                                                                    <asp:Label ID="Label60" runat="server" CssClass="red">Quantity</asp:Label>
                                                                                </td>
                                                                                <td style="border-style: none; text-align: left; width: 65%;">
                                                                                    <asp:TextBox ID="txtItemQty" runat="server" onkeypress="return NumberOnly(event);"
                                                                                        Text="" Width="160px" AutoPostBack="True" OnTextChanged="txtItemQty_TextChanged"></asp:TextBox>
                                                                                    <br />
                                                                                    <asp:Label ID="lblItemPOQty" runat="server" Visible="False" Text="0"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="span6" style="text-align: left">
                                                                        <table cellpadding="0" class="table-hover" style="border-style: none; width: 100%;">
                                                                            <tr>
                                                                                <td style="border-style: none; text-align: left; width: 35%;">
                                                                                    <asp:Label ID="Label64" runat="server" CssClass="red">Rate</asp:Label>
                                                                                </td>
                                                                                <td style="border-style: none; text-align: left; width: 65%;">
                                                                                    <asp:TextBox ID="txtItemRate" runat="server" AutoPostBack="True" onkeypress="return NumberOnly(event);"
                                                                                        OnTextChanged="txtItemRate_TextChanged" Width="160px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="span6" style="text-align: left">
                                                                        <table cellpadding="0" class="table-hover" style="border-style: none; width: 100%;">
                                                                            <tr>
                                                                                <td style="border-style: none; text-align: left; width: 35%;">
                                                                                    <asp:Label ID="Label63" runat="server">Value</asp:Label>
                                                                                </td>
                                                                                <td style="border-style: none; text-align: left; width: 65%;">
                                                                                    <%--<asp:Label ID="lblCalValue" runat="server">0</asp:Label>--%>
                                                                                    <asp:TextBox ID="lblCalValue" runat="server" onkeypress="return NumberOnly(event);"
                                                                                        Width="140px" ReadOnly="True">0</asp:TextBox>
                                                                                    <button class="btn btn-info btn-small" runat="server" id="Button1" onserverclick="btnSaveItem_ServerClick"
                                                                                        style="height: 30px" type="button">
                                                                                        <i class="icon-plus"></i>
                                                                                    </button>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="span8" runat="server" id="GridMaterialList">
                                                <div class="widget-box">
                                                    <div class="widget-header">
                                                        <h5 class="smaller">
                                                            Material List
                                                        </h5>
                                                    </div>
                                                    <div class="widget-body">
                                                        <div class="widget-main ">
                                                            <asp:DataList ID="dlQuestion" CssClass="table table-striped table-bordered table-hover"
                                                                runat="server" Width="100%" OnItemCommand="dlQuestion_ItemCommand">
                                                                <HeaderTemplate>
                                                                    <center>
                                                                        <b>Material Code</b>
                                                                    </center>
                                                                    </th>
                                                                    <th style="width: 20%; text-align: center;">
                                                                        Material Name
                                                                    </th>
                                                                    <th style="width: 10%; text-align: center;">
                                                                        PO Qty
                                                                    </th>
                                                                    <th style="width: 10%; text-align: center;">
                                                                        Challan Qty
                                                                    </th>
                                                                    <th style="width: 10%; text-align: center;">
                                                                        Rate as per PO
                                                                    </th>
                                                                    <th style="width: 10%; text-align: center;">
                                                                        Value
                                                                    </th>
                                                                    <th style="width: 15%; text-align: center;">
                                                                        EAN No.
                                                                    </th>
                                                                    <th style="width: 12%; text-align: center;">
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblMaterialCode_DT" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"lblMaterialCode_DT")%>' />
                                                                    <asp:Label ID="InwardEntry_Code" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"InwardEntry_Code")%>'
                                                                        Visible="false" />
                                                                    </td>
                                                                    <td style="width: 20%; text-align: left;">
                                                                        <asp:Label ID="lblMaterialName_DT" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"lblMaterialName_DT")%>' />
                                                                    </td>
                                                                    <td style="width: 120px; text-align: left;">
                                                                        <asp:TextBox ID="txtPoQty_DT" runat="server" Text="" Width="85%" onkeypress="return NumberOnly()"
                                                                            Visible="false" />
                                                                        <asp:Label ID="lblPoQty_DT" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"lblPoQty_DT")%>' />
                                                                    </td>
                                                                    <td style="width: 10%; text-align: left;">
                                                                        <asp:TextBox ID="txtChallanQty_DT" runat="server" Text="" Width="85%" onkeypress="return NumberOnly()"
                                                                            Visible="false" />
                                                                        <asp:Label ID="lblChallanQty_DT" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"lblChallanQty_DT")%>' />
                                                                    </td>
                                                                    <td style="width: 10%; text-align: left;">
                                                                        <asp:TextBox ID="txtRatePO_DT" runat="server" Text="" Width="85%" onkeypress="return NumberOnly()"
                                                                            Visible="false" />
                                                                        <asp:Label ID="lblRatePO_DT" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"lblRatePO_DT")%>' />
                                                                    </td>
                                                                    <td style="width: 13%; text-align: left;">
                                                                        <asp:Label ID="lblValue_DT" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"lblValue_DT")%>' />
                                                                    </td>
                                                                    <td style="width: 15%; text-align: left;">
                                                                        <asp:Label ID="lblBarcode_DT" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"lblBarcode_DT")%>' />
                                                                        <asp:Label ID="lblpoentry" runat="server" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem,"lblpoentry")%>' />
                                                                          
                                                                    </td>
                                                                    <td style="width: 12%; text-align: center;">
                                                                        <asp:LinkButton ID="lnkDLDelete" ToolTip="Remove" class="btn-small btn-danger icon-trash"
                                                                            runat="server" CommandName="ItemRemove" Height="25px" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"InwardEntry_Code")%>'
                                                                            Visible='<%#(string)DataBinder.Eval(Container.DataItem,"lblIs_Authorised") =="0" ? true : false%>' />&nbsp;
                                                                        <asp:LinkButton ID="lnkDLDetails" ToolTip="Details" class="btn-small btn-primary icon-credit-card"
                                                                            runat="server" CommandName="Details" Height="25px" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"InwardEntry_Code")%>'
                                                                            Visible='<%#(string)DataBinder.Eval(Container.DataItem,"AssetNoTypeBtn") =="1" ? true : false%>' />
                                                                        <asp:Label ID="lblbtnvisible" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"AssetNoTypeBtn")%>'
                                                                            Visible="false"></asp:Label>
                                                                        <asp:Label ID="lblIs_Authorised" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"lblIs_Authorised")%>'
                                                                            Visible="false"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:DataList>
                                                            <asp:DataList ID="DataList4" CssClass="table table-striped table-bordered table-hover"
                                                                runat="server" Width="100%" OnItemCommand="DataList4_ItemCommand" Visible="false">
                                                                <HeaderTemplate>
                                                                    <center>
                                                                        <b>Material Code</b>
                                                                    </center>
                                                                    </th>
                                                                    <th style="width: 30%; text-align: center;">
                                                                        Material Name
                                                                    </th>
                                                                    <th style="width: 13%; text-align: center;">
                                                                        PO Qty
                                                                    </th>
                                                                    <th style="width: 13%; text-align: center;">
                                                                        Challan Qty
                                                                    </th>
                                                                    <th style="width: 13%; text-align: center;">
                                                                        Rate as per PO
                                                                    </th>
                                                                    <th style="width: 13%; text-align: center;">
                                                                        Value
                                                                    </th>
                                                                    <th style="width: 13%; text-align: center;">
                                                                        EAN No.
                                                                    </th>
                                                                    <%--<th style="width: 12%; text-align: center;">
                                                                    --%></HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblMaterialCode_DT" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"lblMaterialCode_DT")%>' />
                                                                    <asp:Label ID="InwardEntry_Code" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"InwardEntry_Code")%>'
                                                                        Visible="false" />
                                                                    </td>
                                                                    <td style="width: 20%; text-align: left;">
                                                                        <asp:Label ID="lblMaterialName_DT" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"lblMaterialName_DT")%>' />
                                                                    </td>
                                                                    <td style="width: 120px; text-align: left;">
                                                                        <asp:TextBox ID="txtPoQty_DT" runat="server" Text="" Width="85%" onkeypress="return NumberOnly()"
                                                                            Visible="false" />
                                                                        <asp:Label ID="lblPoQty_DT" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"lblPoQty_DT")%>' />
                                                                    </td>
                                                                    <td style="width: 10%; text-align: left;">
                                                                        <asp:TextBox ID="txtChallanQty_DT" runat="server" Text="" Width="85%" onkeypress="return NumberOnly()"
                                                                            Visible="true" AutoPostBack="true" OnTextChanged="txtRatePO_DT_TextChanged" value='<%#DataBinder.Eval(Container.DataItem,"lblChallanQty_DT")%>' />
                                                                        <asp:Label ID="lblChallanQty_DT" runat="server" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem,"lblChallanQty_DT")%>' />
                                                                         <asp:Label ID="lblpurchaseorder" runat="server" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem,"POOrder")%>' />
                                                                    </td>
                                                                    <td style="width: 10%; text-align: left;">
                                                                        <asp:TextBox ID="txtRatePO_DT" runat="server" Text="" Width="85%" onkeypress="return NumberOnly()"
                                                                            Visible="false" AutoPostBack="true" OnTextChanged="txtRatePO_DT_TextChanged"
                                                                            value='<%#DataBinder.Eval(Container.DataItem,"lblRatePO_DT")%>' />
                                                                        <asp:Label ID="lblRatePO_DT" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"lblRatePO_DT")%>' />
                                                                    </td>
                                                                    <td style="width: 13%; text-align: left;">
                                                                        <asp:TextBox ID="txtValue_DT" runat="server" Text="" Width="85%" onkeypress="return NumberOnly()"
                                                                            Visible="false" value='<%#DataBinder.Eval(Container.DataItem,"lblValue_DT")%>' />
                                                                        <asp:Label ID="lblValue_DT" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"lblValue_DT")%>' />
                                                                    </td>
                                                                    <td style="width: 15%; text-align: left;">
                                                                        <asp:Label ID="lblBarcode_DT" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"lblBarcode_DT")%>' />
                                                                    </td>
                                                                    <%--<<td style="width: 12%; text-align: center;">--%>
                                                                    <%-- <asp:LinkButton ID="lnkDLDelete" ToolTip="Remove" class="btn-small btn-danger icon-trash"
                                                                            runat="server" CommandName="ItemRemove" Height="25px" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"InwardEntry_Code")%>'
                                                                            Visible='<%#(string)DataBinder.Eval(Container.DataItem,"lblIs_Authorised") =="0" ? true : false%>'  />&nbsp;
                                                                        <asp:LinkButton ID="lnkDLDetails" ToolTip="Details" class="btn-small btn-primary icon-credit-card"
                                                                            runat="server" CommandName="Details" Height="25px" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"InwardEntry_Code")%>'
                                                                            Visible='<%#(string)DataBinder.Eval(Container.DataItem,"AssetNoTypeBtn") =="1" ? true : false%>' />--%>
                                                                    <%--  <asp:Label ID="lblbtnvisible" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"AssetNoTypeBtn")%>'
                                                                            Visible="false"></asp:Label>--%>
                                                                    <asp:Label ID="lblIs_Authorised" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"lblIs_Authorised")%>'
                                                                        Visible="false"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:DataList>
                                                            <table class="table table-striped table-bordered table-hover">
                                                                <tr>
                                                                    <td>
                                                                        <b>Total Material : </b>
                                                                        <asp:Label runat="server" ID="txtTotalItems" Text="0"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <b>Total Qty : </b>
                                                                        <asp:Label runat="server" ID="txtTotalQuantity" Text="0"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <b>Total Amount :</b>
                                                                        <asp:Label runat="server" ID="txtTotalValue" Text="0"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row-fluid">
                                            <div class="span12" runat="server" id="Div2">
                                                <div class="widget-box">
                                                    <div class="widget-header">
                                                        <h5 class="smaller">
                                                            Logistic Details
                                                        </h5>
                                                    </div>
                                                    <div class="widget-body">
                                                        <div class="widget-main ">
                                                            <table cellpadding="3" class="table table-striped table-bordered table-condensed">
                                                                <tr>
                                                                    <td class="span6" style="text-align: left">
                                                                        <table cellpadding="0" class="table-hover" style="border-style: none; width: 100%;">
                                                                            <tr>
                                                                                <td style="border-style: none; text-align: left; width: 40%;">
                                                                                    <asp:Label ID="Label17" runat="server">Logistic Type</asp:Label>
                                                                                </td>
                                                                                <td style="border-style: none; text-align: left; width: 60%;">
                                                                                    <asp:DropDownList ID="ddlLogisticType_Add" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                                        data-placeholder="Select Godown" Width="215px" OnSelectedIndexChanged="ddlLogisticType_Add_SelectedIndexChanged" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                    <td class="span6" style="text-align: left">
                                                                        <table cellpadding="0" class="table-hover" style="border-style: none; width: 100%;">
                                                                            <tr>
                                                                                <td style="border-style: none; text-align: left; width: 40%;">
                                                                                    <asp:Label ID="Label19" runat="server">Logistic Details</asp:Label>
                                                                                </td>
                                                                                <td style="border-style: none; text-align: left; width: 60%;">
                                                                                    <asp:TextBox ID="txtLogisticDetails_Add" runat="server" Text="" Width="205px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                    <td class="span6" style="text-align: left">
                                                                        <table cellpadding="0" class="table-hover" style="border-style: none; width: 100%;"
                                                                            runat="server" id="tblPODNo" visible="false">
                                                                            <tr>
                                                                                <td style="border-style: none; text-align: left; width: 40%;">
                                                                                    <asp:Label ID="Label20" runat="server">POD No.</asp:Label>
                                                                                </td>
                                                                                <td style="border-style: none; text-align: left; width: 60%;">
                                                                                    <asp:TextBox ID="txtPODNo_Add0" runat="server" Text="" Width="205px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                        <table id="tblVehNo" runat="server" cellpadding="0" class="table-hover" style="border-style: none;
                                                                            width: 100%;" visible="false">
                                                                            <tr>
                                                                                <td style="border-style: none; text-align: left; width: 40%;">
                                                                                    <asp:Label ID="Label21" runat="server">Vehicle No.</asp:Label>
                                                                                </td>
                                                                                <td style="border-style: none; text-align: left; width: 60%;">
                                                                                    <asp:TextBox ID="txtVechicleNo_Add" runat="server" Text="" Width="205px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row-fluid">
                                                <div class="span12" runat="server" id="UploadPO">
                                                    <div class="widget-box">
                                                        <div class="widget-header">
                                                            <h5 class="smaller">
                                                                Upload GRN
                                                            </h5>
                                                        </div>
                                                        <div class="widget-body">
                                                            <div class="widget-main ">
                                                                <table cellpadding="2" class="table table-striped table-bordered table-condensed">
                                                                    <tr>
                                                                        <td class="span4" style="text-align: left">
                                                                            <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                                                <tr>
                                                                                    <td class="span2" style="border-style: none; text-align: left; width: 40%;">
                                                                                        <asp:Label ID="Label41" runat="server" ForeColor="Red">Current File</asp:Label>
                                                                                    </td>
                                                                                    <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                                                        <asp:Label ID="UploadStatusLabel1" runat="server"> </asp:Label>
                                                                                        <asp:Label ID="uploadfilename" runat="server" Visible="false"> </asp:Label>
                                                                                        <asp:Label ID="lblGRN_No" runat="server" Visible="false">
                                                                                        </asp:Label>
                                                                                        <asp:Label ID="path" runat="server" Visible="false">
                                                                                        </asp:Label>
                                                                                        <asp:Label ID="lblfilename" runat="server" Visible="false">
                                                                                        </asp:Label>
                                                                                        <asp:Label ID="lblextension" runat="server" Visible="false">
                                                                                        </asp:Label>
                                                                                        &nbsp;
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                        <td class="span4" style="text-align: left">
                                                                            <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                                                runat="server" id="Table4">
                                                                                <tr>
                                                                                    <td style="border-style: none; text-align: left; width: 40%;">
                                                                                        <asp:Label ID="Label42" runat="server" ForeColor="Red">Browse</asp:Label>
                                                                                    </td>
                                                                                    <td style="border-style: none; text-align: left">
                                                                                        <asp:FileUpload ID="FileUpload1" runat="server" />
                                                                                        <asp:Label ID="UploadStatusLabel" runat="server">   </asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                        <td class="span4" style="text-align: left">
                                                                            <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                                                runat="server" id="Table2">
                                                                                <tr>
                                                                                    <td id="Td1" runat="server" visible="false">
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Button class="btn btn-app btn-primary  btn-mini radius-4" runat="server" ID="btnUpload"
                                                                                            Text="Upload" ToolTip="Upload" ValidationGroup="UcValidateSearch" OnClick="btnUpload_Click" />
                                                                                        &nbsp;
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <%--<div class="span12" runat="server" id="UploadPO">
                                                <div class="widget-box">
                                                    <div class="widget-header">
                                                        <h5>
                                                            Upload GRN
                                                        </h5>
                                                    </div>
                                                    <table cellpadding="2" class="table table-striped table-bordered table-condensed">
                                                        <tr>
                                                            <td class="span4" style="text-align: left">
                                                                <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                                    <tr>
                                                                        <td class="span2" style="border-style: none; text-align: left; width: 40%;">
                                                                            <asp:Label ID="Label41" runat="server" ForeColor="Red">Current File</asp:Label>
                                                                        </td>
                                                                        <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                                            <asp:TextBox ID="txtuploadName" runat="server" Text="" Width="205px"></asp:TextBox>
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td class="span4" style="text-align: left">
                                                                <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                                    runat="server" id="Table4">
                                                                    <tr>
                                                                        <td style="border-style: none; text-align: left; width: 40%;">
                                                                            <asp:Label ID="Label42" runat="server" ForeColor="Red">Browse</asp:Label>
                                                                        </td>
                                                                        <td style="border-style: none; text-align: left">
                                                                            <asp:FileUpload ID="uploadfile" runat="server" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td class="span4" style="text-align: left">
                                                                <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                                    runat="server" id="Table2">
                                                                    <tr>
                                                                        <td id="Td1" runat="server" visible="false">
                                                                        </td>
                                                                        <td>
                                                                            <asp:Button class="btn btn-app btn-primary  btn-mini radius-4" runat="server" ID="btnUpload"
                                                                                Text="Upload" ToolTip="Upload" ValidationGroup="UcValidateSearch" />
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </div>--%>
                                            </div>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="dlQuestion" />
                                        <asp:PostBackTrigger ControlID="btnUpload" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                    <div class="widget-main alert-block alert-success  alert- " style="text-align: center;">
                        <!--Button Area -->
                        <asp:Label runat="server" ID="lblErrorBatch" Text="" ForeColor="Red" />
                        <asp:Button class="btn btn-app btn-success btn-mini radius-4" ID="BtnSaveAdd" runat="server"
                            Text="Save" ValidationGroup="UcValidate" OnClick="BtnSaveAdd_Click" />
                        <asp:Button class="btn btn-app btn-success btn-mini radius-4" ID="BtnSaveUpdate"
                            runat="server" Text="Save" ValidationGroup="UcValidate" OnClick="BtnSaveUpdate_Click"
                            Style="width: 42px" />
                        <%--<div class="row-fluid">
                                                        <div class="span12" runat="server" id="DivAddBarcode" visible ="false">
                                                            <div class="widget-box">
                                                                <div class="widget-header">
                                                                    <h5 class="smaller">
                                                                        Item Details
                                                                    </h5>
                                                                </div>
                                                                <div class="widget-body">
                                                                    <div class="widget-main ">
                                                                       
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>--%>
                        <asp:Button class="btn btn-app btn-primary btn-mini radius-4" ID="BtnCloseAdd" Visible="true"
                            runat="server" Text="Close" OnClick="BtnCloseAdd_Click" />
                        <asp:ValidationSummary ID="ValidationSummary3" ShowSummary="false" DisplayMode="List"
                            ShowMessageBox="true" ValidationGroup="UcValidate" runat="server" />
                    </div>
                </div>
            </div>
        </div>
        <div id="DivAddBarcode" runat="server" visible="false">
            <div class="widget-box">
                <div class="widget-header widget-header-small header-color-dark">
                    <h5 class="modal-title">
                        Material Details
                        <asp:Label runat="server" ID="lblInwardCode_BR" Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="lblInwardEbtryCode_BR" Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="lblAssetesNoTypeID" Visible="false"></asp:Label>
                    </h5>
                </div>
                <div class="widget-body">
                    <div class="widget-body-inner">
                        <div class="widget-main">
                            <%--<asp:UpdatePanel ID="UpdatePanel12" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>--%>
                            <table cellpadding="3" class="table table-striped table-bordered table-condensed">
                                <tr>
                                    <td class="span4">
                                        <table cellpadding="0" class="table-hover" style="border-style: none; width: 80%;">
                                            <tr>
                                                <td style="border-style: none; text-align: left; width: 40%;">
                                                    <asp:Label ID="Label66" runat="server">Material Name</asp:Label>
                                                </td>
                                                <td style="border-style: none; text-align: left; width: 60%;">
                                                    <asp:TextBox ID="txtItemName_BR" runat="server" Text="" Width="205px"></asp:TextBox>
                                                    <%--<button runat ="server" id="btnSearchItem" class="btn btn-purple btn-small" onclick ="btnSearchItem_Click" >
                                                                                                        Search <i class="icon-search icon-on-right"></i>
                                                                                                    </button>--%>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td class="span4">
                                        <asp:Label ID="lblIs_Authorised" runat="server" Text="" Visible="false"></asp:Label>
                                        <asp:DropDownList runat="server" ID="ddlDiffLevel_Hidden" Width="72px" Visible="false" />
                                        <asp:DropDownList runat="server" ID="ddlSubject_Hidden" Width="72px" Visible="false" />
                                        <asp:UpdateProgress ID="updProgress" DynamicLayout="false" runat="server">
                                            <ProgressTemplate>
                                                <img alt="progress" src="Images/loading.gif" />
                                                Processing...
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                        <asp:Label runat="server" ID="Label2">Select File :</asp:Label>
                                        <asp:Label ID="lbluploadfileName" runat="server" Text="" Visible="false"></asp:Label>
                                        <%--</ContentTemplate>
                                                </asp:UpdatePanel>--%>
                                        <span class="help-button ace-popover" runat="server" id="SMSHelpFlag" data-trigger="hover"
                                            data-placement="left" data-content="Select a CSV file that contain Asset No using browse button."
                                            title="Help">?</span>
                                           
                                        <asp:FileUpload ID="FFLExcel" runat="server" Width="172px" />
                                      <%--  <button id="BtnUploadExcel" class="btn btn-info btn-purple" data-rel="tooltip" data-placement="left"
                                            title="Upload" runat="server" onserverclick="BtnUploadExcel_ServerClick">
                                            <i class="icon-cloud-upload"></i>
                                        </button>--%>
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        <asp:Button class="btn btn-app btn-success btn-mini radius-4" runat="server" ID="BtnUploadExcel"
                                                         Width="70px"     Text="Upload" ToolTip="Upload" 
                                            ValidationGroup="UcValidateSearch" OnClick="BtnUploadExcel_ServerClick" 
                                            Font-Size="Medium" />
                                        
                                        <asp:Label runat="server" ID="lblqty" Visible="false"></asp:Label>
                                       <%-- <button id="BtnDownloadExcel" class="btn btn-info btn-pink" data-rel="tooltip" runat="server"
                                            data-placement="right" title="Download" onserverclick="BtnDownloadExcel_ServerClick">
                                            <i class="icon-cloud-download"></i>
                                        </button>--%>
                                        <asp:Button class="btn btn-app btn-primary  btn-mini radius-4" runat="server" ID="BtnDownloadExcel"
                                                            Width="75px"  Text="Download" ToolTip="Download" ValidationGroup="UcValidateSearch" OnClick="BtnDownloadExcel_ServerClick" />
                                        <asp:Label ID="lblfilepath" runat="server" Visible="False"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <asp:DataList ID="DataList2" CssClass="table table-striped table-bordered table-hover"
                                runat="server" Width="100%" OnItemDataBound="DataList2_ItemDataBound">
                                <HeaderTemplate>
                                    <center>
                                        <b>SR.No</b>
                                    </center>
                                    </th>
                                    <th style="width: 30%; text-align: center;">
                                        Material Serial No
                                    </th>
                                      <th style="width: 30%; text-align: center;">
                                        SAP Asset No
                                    </th>
                                    <th style="width: 30%; text-align: center;">
                                        Material Asset No
                                    </th>
                                    <th style="width: 10%; text-align: Center;">
                                    Remark
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <center>
                                        <asp:Label ID="lblSRNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"lblSRNo")%>'></asp:Label>
                                    </center>
                                    </td>
                                    <td style=" text-align: center;">
                                        <asp:TextBox ID="txtItemSerialNo" runat="server" Visible="TRUE" Text='<%#DataBinder.Eval(Container.DataItem,"txtItemSerialNo")%>'
                                            Width="200px"></asp:TextBox>
                                        <asp:Label ID="txtItemSerialNo1" runat="server" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem,"txtItemSerialNo")%>'></asp:Label>
                                    </td>
                                    <td style=" text-align: center;">
                                        <asp:TextBox ID="txtSAPAsset" runat="server" Visible="TRUE" Text='<%#DataBinder.Eval(Container.DataItem,"txtSAPAsset")%>'
                                            Width="200px" onkeypress="return ValidateEnterKey(event);"></asp:TextBox>
                                        <asp:Label ID="Label54" runat="server" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem,"txtSAPAsset")%>'></asp:Label>
                                    </td>
                                    <td style="text-align: center;">
                                        <asp:TextBox ID="txtItemBarcodeNo" runat="server" Visible="TRUE" Text='<%#DataBinder.Eval(Container.DataItem,"txtItemBarcodeNo")%>'
                                            Width="200px" onkeypress="return ValidateEnterKey(event);"></asp:TextBox>
                                        <asp:Label ID="txtItemBarcodeNo1" runat="server" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem,"txtItemBarcodeNo")%>'></asp:Label>
                                    </td>
                                    <td style=" text-align: center;">
                                        <asp:Label ID="lblResult" runat="server" Text="" />
                                </ItemTemplate>
                            </asp:DataList>
                            <%-- </ContentTemplate>
                            </asp:UpdatePanel>--%>
                        </div>
                    </div>
                    <div class="widget-main alert-block alert-success  alert- " style="text-align: center;">
                        <!--Button Area -->
                        <asp:Button class="btn btn-app btn-success btn-mini radius-4" ID="btnUserMenuSave"
                            runat="server" Text="Save" ValidationGroup="UcValidate" OnClick="btnUserMenuSave_Click" />
                        <asp:Button class="btn btn-app btn-primary btn-mini radius-4" ID="btnUserMenuClose"
                            Visible="true" runat="server" Text="Close" OnClick="btnUserMenuClose_Click" />
                        <asp:ValidationSummary ID="ValidationSummary12" ShowSummary="false" DisplayMode="List"
                            ShowMessageBox="true" ValidationGroup="UcValidate" runat="server" />
                    </div>
                </div>
            </div>
        </div>
        <div id="DivAuthorise" runat="server" visible="false">
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
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
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
                                                            <asp:DropDownList ID="ddlpostatus_Auth" runat="server" CssClass="chzn-select" Width="215px"
                                                                Enabled="False">
                                                                <asp:ListItem>Select</asp:ListItem>
                                                                <asp:ListItem>Yes</asp:ListItem>
                                                                <asp:ListItem>No</asp:ListItem>
                                                            </asp:DropDownList>
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
                                                            <asp:DropDownList ID="ddlpoNo_Auth" runat="server" CssClass="chzn-select" Width="215px"
                                                                AutoPostBack="True" OnSelectedIndexChanged="ddlPONo_Add_SelectedIndexChanged"
                                                                Enabled="False">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table id="SuppID_Auth" runat="server" cellpadding="0" class="table-hover" style="border-style: none;
                                                    width: 100%;">
                                                    <tr>
                                                        <td style="border-style: none; text-align: left; width: 40%;">
                                                            <asp:Label ID="Label37" runat="server" CssClass="red">Supplier</asp:Label>
                                                        </td>
                                                        <td style="border-style: none; text-align: left; width: 60%;">
                                                            <asp:DropDownList ID="ddlSupplier_Auth" runat="server" CssClass="chzn-select" Width="215px"
                                                                Enabled="False">
                                                            </asp:DropDownList>
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
                                                            <asp:Label ID="Label39" runat="server" CssClass="red">DC No.</asp:Label>
                                                        </td>
                                                        <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                            <asp:TextBox ID="txtDCNO_Auth" runat="server" Text="" Width="205px" ReadOnly="True"></asp:TextBox>
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
                                                            <asp:TextBox ID="txtDCDate_Auth" runat="server" Text="" Width="205px" ReadOnly="True"></asp:TextBox>
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
                                                            <asp:Label ID="lblSupplier_Auth" runat="server"></asp:Label>
                                                            <asp:Label ID="Label43" runat="server" Visible="False"></asp:Label>
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
                                                            <asp:TextBox ID="txtInvoice_No_Auth" runat="server" Text="" Width="205px" ReadOnly="True"></asp:TextBox>
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
                                                            <asp:TextBox ID="txtInvoiceDate_Auth" runat="server" ReadOnly="True" Text="" Width="205px"></asp:TextBox>
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
                                                            <asp:TextBox ID="txtInvoiceValue_Auth" runat="server" Text="" Width="205px" onkeypress="return NumberOnly(event);"
                                                                ReadOnly="True"></asp:TextBox>
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
                                                            <asp:DropDownList ID="ddlLocation_Auth" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                data-placeholder="Select Location Type" Width="215px" OnSelectedIndexChanged="ddlTransferFR_SR_SelectedIndexChanged"
                                                                Enabled="False" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td class="span6" style="text-align: left">
                                                <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                    runat="server" id="tblFr_Godown_Auth" visible="false">
                                                    <tr>
                                                        <td style="border-style: none; text-align: left; width: 40%;">
                                                            <asp:Label ID="Label48" runat="server" CssClass="red">Godown</asp:Label>
                                                        </td>
                                                        <td style="border-style: none; text-align: left; width: 60%;">
                                                            <asp:DropDownList ID="ddlGodown_Auth" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                data-placeholder="Select Godown" Width="215px" Enabled="False" />
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                    runat="server" id="tblFr_Division_Auth" visible="false">
                                                    <tr>
                                                        <td style="border-style: none; text-align: left; width: 40%;">
                                                            <asp:Label ID="Label49" runat="server" CssClass="red">Division</asp:Label>
                                                        </td>
                                                        <td style="border-style: none; text-align: left; width: 60%;">
                                                            <asp:DropDownList ID="ddlDivision_Auth" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                data-placeholder="Select Division" Width="215px" OnSelectedIndexChanged="ddlDivisionFR_SR_SelectedIndexChanged"
                                                                Enabled="False" />
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                    runat="server" id="tblFr_Function_Auth" visible="false">
                                                    <tr>
                                                        <td style="border-style: none; text-align: left; width: 40%;">
                                                            <asp:Label ID="Label50" runat="server" CssClass="red">Function</asp:Label>
                                                        </td>
                                                        <td style="border-style: none; text-align: left; width: 60%;">
                                                            <asp:DropDownList ID="ddlFunction_Auth" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                data-placeholder="Select Function" Width="215px" Enabled="False" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td class="span6" style="text-align: left">
                                                <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%"
                                                    runat="server" id="tblFr_Center_Auth" visible="false">
                                                    <tr>
                                                        <td style="border-style: none; text-align: left; width: 40%;">
                                                            <asp:Label ID="Label51" runat="server" CssClass="red">Center</asp:Label>
                                                        </td>
                                                        <td style="border-style: none; text-align: left; width: 60%;">
                                                            <asp:DropDownList ID="ddlCenter_Auth" runat="server" CssClass="chzn-select" data-placeholder="Select Center"
                                                                Width="215px" Enabled="False" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:DataList ID="dlItemListAuthorise" CssClass="table table-striped table-bordered table-hover"
                                        runat="server" Width="100%" OnItemCommand="dlQuestion_ItemCommand">
                                        <HeaderTemplate>
                                            <%--  <asp:CheckBox ID="chkAuthoriseAll" runat="server" AutoPostBack="True" OnCheckedChanged="chkAuthoriseAll_CheckedChanged" />
                                                   <span class="lbl"></span></th>--%>
                                            <b>
                                                <asp:CheckBox ID="chkAuthoriseAll" runat="server" AutoPostBack="True" OnCheckedChanged="chkAuthoriseAll_CheckedChanged" />
                                                <span class="lbl"></span></b></th>
                                            <th style="width: 10%; text-align: center;">
                                                Material Code
                                            </th>
                                            <th style="width: 10%; text-align: center;">
                                                Inward Entry Code
                                            </th>
                                            <th style="width: 30%; text-align: center;">
                                                Material Name
                                            </th>
                                            <th style="width: 15%; text-align: center;">
                                                Challan Qty
                                            </th>
                                            <th style="width: 10%; text-align: center;">
                                                EAN No.
                                            </th>
                                            <th style="width: 10%; text-align: center;">
                                                Sttaus
                                            </th>
                                            <th style="width: 10%; text-align: center;">
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%--   <center>--%>
                                            <asp:CheckBox ID="chkCheck" runat="server" AutoPostBack="true" Checked="false" Visible='<%#(string)DataBinder.Eval(Container.DataItem,"Is_Authorised") == "1" ? false : true%>' />
                                            <span class="lbl"></span>
                                            <%--      </center>--%>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblMaterialCode_DT" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"lblMaterialCode_DT")%>' />
                                                <%-- <asp:Label ID="lblpoentry" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"poentry")%>' />--%>
                                            </td>
                                            <td>
                                                <asp:Label ID="InwardEntry_Code" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"InwardEntry_Code")%>' />
                                            </td>
                                            <td style="width: 20%; text-align: left;">
                                                <asp:Label ID="lblMaterialName_DT" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"lblMaterialName_DT")%>' />
                                            </td>
                                            <td style="width: 10%; text-align: left;">
                                                <asp:TextBox ID="txtChallanQty_DT" runat="server" Text="" Width="85%" onkeypress="return NumberOnly()"
                                                    Visible="false" />
                                                <asp:Label ID="lblChallanQty_DT" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"lblChallanQty_DT")%>' />
                                            </td>
                                            <td style="width: 10%; text-align: left;">
                                                <asp:Label ID="lblBarcode_DT" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"lblBarcode_DT")%>' />
                                                <asp:Label ID="lblAssetType" runat="server" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem,"AssetType")%>' />
                                            </td>
                                            <td style="width: 10%; text-align: left;">
                                                <asp:Label ID="lblstatus" runat="server" Visible="true"  />
                                                
                                            </td>
                                            <td style="width: 8%; text-align: center;">
                                                <asp:LinkButton ID="lnkDLAuthorise" ToolTip="Authorise" class="btn-small btn-warning  icon-lock"
                                                    runat="server" CommandName="Details" Height="25px" Visible='<%#(string)DataBinder.Eval(Container.DataItem,"Is_Authorised") == "1" ? true : false%>' />
                                                <a id="lbl_DLError" runat="server" title="Error" data-rel="tooltip" href="#">
                                                    <asp:Panel ID="icon_Error" runat="server" class="badge badge-important" Visible="false">
                                                        <i class="icon-bolt"></i>
                                                    </asp:Panel>
                                                </a>
                                                <asp:Label ID="lblSuccess" runat="server" Text='Success' CssClass='green' Visible="false" />
                                        </ItemTemplate>
                                    </asp:DataList>
                                    <br />
                                </ContentTemplate>
                                <Triggers>
                                    <asp:PostBackTrigger ControlID="dlQuestion" />
                                    <asp:PostBackTrigger ControlID="Button1" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div class="widget-main alert-block alert-success  alert- " style="text-align: center;">
                        <!--Button Area -->
                        <asp:Label runat="server" ID="Label38" Text="" ForeColor="Red" />
                        <asp:Button class="btn btn-app btn-success btn-mini radius-4" ID="btnAuthorise" runat="server"
                            Text="Authorise" ValidationGroup="UcValidate" Width="80px" OnClick="btnAuthorise_Click" />
                        <%-- <asp:Label ID="lblDLMaterial_Code" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"Item_Id")%>' />--%>
                        <asp:Button class="btn btn-app btn-primary btn-mini radius-4" ID="btnCloseAuthorise"
                            Visible="true" Width="80px" runat="server" Text="Close" OnClick="btnCloseAuthorise_Click" />
                        <asp:Button class="btn btn-app btn-primary btn-mini radius-4" ID="BtnPrint" Visible="true"
                            runat="server" Text="Print" OnClick="BtnPrint_Click" />
                        <asp:ValidationSummary ID="ValidationSummary1" ShowSummary="false" DisplayMode="List"
                            ShowMessageBox="true" ValidationGroup="UcValidate" runat="server" />
                    </div>
                </div>
            </div>
        </div>
        <%--<div class="row-fluid">
                                                        <div class="span12" runat="server" id="DivAddBarcode" visible ="false">
                                                            <div class="widget-box">
                                                                <div class="widget-header">
                                                                    <h5 class="smaller">
                                                                        Item Details
                                                                    </h5>
                                                                </div>
                                                                <div class="widget-body">
                                                                    <div class="widget-main ">
                                                                       
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>--%>
    </div>
    </div>
    <!--/row-->
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="modal fade" id="DivOverrid" style="left: 50% !important; top: 20% !important;
                display: none;" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                &times;</button>
                            <h4 class="modal-title">
                                Select Item
                            </h4>
                        </div>
                        <div class="modal-body">
                            <!--Controls Area -->
                            <table cellpadding="0" style="border-style: none;" width="100%">
                                <tr>
                                    <td style="border-style: none; text-align: left; width: 40%;">
                                        <asp:DataList ID="DataList3" runat="server" CssClass="table table-striped table-bordered table-hover"
                                            Width="97%" OnItemCommand="DataList3_ItemCommand">
                                            <HeaderTemplate>
                                                <b>Material Code</b>
                                                <th>
                                                    Material Name
                                                </th>
                                                <th align="left" style="width: 25%">
                                                    Unit
                                                </th>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <%-- <asp:Label ID="lblDLMaterial_Code" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"Item_Id")%>' />--%>
                                                <asp:LinkButton ID="lnkMaterial_Code" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Item_Code")%>'
                                                    runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Item_Code")%>' CommandName="comSetItem" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblDLItemName" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"Item_Name")%>' />
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblDLItemUnit" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"UOM_Name")%>' />
                                                </td>
                                            </ItemTemplate>
                                        </asp:DataList>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="modal-footer">
                            <!--Button Area -->
                            <asp:Label runat="server" ID="Label15" Text="" Visible="false" />
                            <asp:Button class="btn btn-app btn-primary btn-mini radius-4" data-dismiss="modal"
                                ID="Button123" ToolTip="Cancel" runat="server" Text="Cancel" />
                        </div>
                    </div>
                    <!-- /.modal-content -->
                </div>
                <!-- /.modal-dialog -->
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="Datalist3" />
            
        </Triggers>
    </asp:UpdatePanel>
    <div class="modal fade" id="DivConfirmation" style="left: 50% !important; top: 20% !important;
        display: none;" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        &times;</button>
                    <h4 class="modal-title">
                        Warning
                    </h4>
                </div>
                <div class="modal-body">
                    <!--Controls Area -->
                    <table cellpadding="0" style="border-style: none;" width="100%">
                        <tr>
                            <td style="border-style: none; text-align: left; width: 40%;">
                                <asp:Label runat="server" ID="Label23">Are you sure want to remove Item</asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="modal-footer">
                    <!--Button Area -->
                    <asp:Label runat="server" ID="Label24" Text="" Visible="false" />
                    <asp:Button class="btn btn-app  btn-success btn-mini radius-4" ID="Button3" ToolTip="Yes"
                        runat="server" Text="Yes" OnClick="btnDivConfirmYes_Click" />
                    <asp:Button class="btn btn-app btn-primary btn-mini radius-4" data-dismiss="modal"
                        ID="Button4" ToolTip="No" runat="server" Text="No" />
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <div class="modal fade" id="DivCOnfirmationAsset" style="left: 50% !important; top: 20% !important;
        display: none;" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        &times;</button>
                    <h4 class="modal-title">
                        Alert!!!
                    </h4>
                </div>
                <div class="modal-body">
                    <!--Controls Area -->
                    <table cellpadding="0" style="border-style: none;" width="100%">
                        <tr>
                            <td style="border-style: none; text-align: left; width: 40%;">
                                <asp:Label runat="server" ID="Label52">This Material  is of Asset condition type , </asp:Label>
                                <asp:Label runat="server" ID="lblasset_type" ForeColor="red"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="modal-footer">
                    <!--Button Area -->
                    <asp:Label runat="server" ID="Label53" Text="" Visible="false" />
                    <asp:Button class="btn btn-app  btn-success btn-mini radius-4" ID="Button5" ToolTip="Yes"
                        runat="server" Text="Yes" OnClick="btnDivAssetConfirmYes_Click" />
                    <asp:Button class="btn btn-app btn-primary btn-mini radius-4" data-dismiss="modal"
                        ID="Button6" ToolTip="No" runat="server" Text="No" />
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
</asp:Content>
