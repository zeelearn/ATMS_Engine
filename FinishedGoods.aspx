<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="FinishedGoods.aspx.cs" Inherits="FinishedGoods" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">

        function SetTarget() {
            document.forms[0].target = "_blank";
        }

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
                <h5 class="blue">
                    Finished Goods Details<span class="divider"></span></h5>
            </li>
        </ul>
        <div id="nav-search">
            <!-- /btn-group -->
            <asp:Button class="btn  btn-app btn-success btn-mini radius-4" Visible="true" runat="server"
                ID="btnAdd" Text="Add" OnClick="btnAdd_Click" />
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
            <div id="DivSearchPanel1" runat="server">
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
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="lblLocType" runat="server" CssClass="red">Location Type</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlLocationType" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Location Type" Width="215px" OnSelectedIndexChanged="ddlLocationType_SelectedIndexChanged" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                        runat="server" id="tblFr_Godown" visible="false">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="lblGodownNm" runat="server" CssClass="red">Godown Name</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlgodownFR_SR" runat="server" CssClass="chzn-select" data-placeholder="Select Godown"
                                                                    Width="215px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                        runat="server" id="tblFr_Division" visible="false">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="lblDivNm" runat="server" CssClass="red">Division Name</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlDivisionFR_SR" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Division" Width="215px" OnSelectedIndexChanged="ddlDivisionFR_SR_SelectedIndexChanged" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                        runat="server" id="tblFr_Function" visible="false">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="lblFunctionNm" runat="server" CssClass="red">Function Name</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlFunctionFR_SR" runat="server" CssClass="chzn-select" data-placeholder="Select Function"
                                                                    Width="215px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%"
                                                        runat="server" id="tblFr_Center" visible="false">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="lblCenterNm" runat="server" CssClass="red">Center Name</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlCenterFR_SR" runat="server" CssClass="chzn-select" data-placeholder="Select Center"
                                                                    Width="215px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="lblPeriod" runat="server" CssClass="red">Period</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <input id="date_range_SR" runat="server" class="id_date_range_picker_1" data-original-title="Date Range"
                                                                    data-placement="bottom" name="date-range-picker" placeholder="Date Search" readonly="readonly"
                                                                    style="width: 205px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="lblVoucherNm" runat="server">Voucher No</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:TextBox ID="txtVoucherNm" runat="server" Width="215px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4">
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
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table cellpadding="3" class="table table-striped table-bordered table-condensed">
                            <tr>
                                <td class="span6" style="text-align: left">
                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                        <tr>
                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                <asp:Label runat="server" ID="lblsearchLocType">Location Type</asp:Label>
                                            </td>
                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                <asp:Label runat="server" ID="lblLocationType_Result" Text="" CssClass="blue" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td class="span6" style="text-align: left">
                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                        <tr>
                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                <asp:Label runat="server" ID="lblLocNm">Location Name</asp:Label>
                                            </td>
                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                <asp:Label runat="server" ID="lblLocationResult" class="blue"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td class="span6" style="text-align: left">
                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                        <tr>
                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                <asp:Label runat="server" ID="lblsearchPeriod">Period</asp:Label>
                                            </td>
                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                <asp:Label runat="server" ID="lblPeroidResult" Text="" CssClass="blue" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td class="span6" style="text-align: left">
                                </td>
                            </tr>
                        </table>
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
                        <%--<asp:DataList ID="dlGridDisplay" CssClass="table table-striped table-bordered table-hover"
                            runat="server" Width="100%" OnItemCommand="dlGridDisplay_ItemCommand1">
                            <HeaderTemplate>
                                <b>Voucher No</b> </th>
                                <th align="left">
                                    Voucher Date
                                </th>
                                <th align="left">
                                    Location
                                </th>
                                <th align="left">
                                    Item Count
                                </th>
                                <th align="left">
                                    Total Qty
                                </th>
                                <th style="width: 10%; text-align: center;">
                                    Action
                                </th>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblItem_Code" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Voucher_Code")%>' />
                                </td>
                                <td style="text-align: left;">
                                    <asp:Label ID="lblOpening_Qty" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Date")%>' />
                                </td>
                                <td style="text-align: left;">
                                    <asp:Label ID="lblInward_Qty" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"location")%>' />
                                </td>
                                <td style="text-align: left;">
                                    <asp:Label ID="lblOutward_Qty" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"ItemCount")%>' />
                                </td>
                                <td style="text-align: left;">
                                    <asp:Label ID="Label1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"itemQty")%>' />
                                </td>
                                <td style="text-align: left;">
                                    <div class="inline position-relative">
                                        <asp:LinkButton ID="lnkEdit" ToolTip="Edit" class="btn-small btn-primary icon-info-sign"
                                            CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Voucher_Code")%>' runat="server"
                                            CommandName="comEdit" Height="25px" />
                                </td>
                            </ItemTemplate>
                        </asp:DataList>--%>
                        <asp:Repeater ID="dlGridDisplay" runat="server" OnItemCommand="dlGridDisplay_ItemCommand">
                            <HeaderTemplate>
                                <table class="table table-striped table-bordered table-hover Table2">
                                    <thead>
                                        <tr>
                                            <th>
                                                Voucher No
                                            </th>
                                            <th style="width: 20%; text-align: center;">
                                                Voucher Date
                                            </th>
                                            <th style="width: 20%; text-align: center;">
                                                Location
                                            </th>
                                            <th style="width: 15%; text-align: center;">
                                                Material Count
                                            </th>
                                            <th style="text-align: center; width: 15%;">
                                                Total Qty
                                            </th>
                                            <th style="width: 12%; text-align: center;">
                                                Action
                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr class="odd gradeX">
                                    <td>
                                        <asp:Label ID="lblItem_Code" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Voucher_Code")%>' />
                                        <span id="iconDL_Authorise" runat="server" visible='<%# Convert.ToString(DataBinder.Eval(Container.DataItem,"Is_Authorised")) == "1" ? true : false%>'
                                            class="btn btn-danger btn-mini tooltip-error" data-rel="tooltip" data-placement="right"
                                            title="Voucher Authorised"><i class="icon-lock"></i></span>
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:Label ID="lblOpening_Qty" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Date")%>' />
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:Label ID="lblInward_Qty" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"location")%>' />
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:Label ID="lblOutward_Qty" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"ItemCount")%>' />
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:Label ID="Label1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"itemQty")%>' />
                                    </td>
                                    <td style="text-align: center;">
                                        <div class="inline position-relative">
                                            <asp:LinkButton ID="lnkEdit" ToolTip="Edit" class="btn-small btn-primary icon-info-sign"
                                                CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Voucher_Code")%>' runat="server"
                                               Visible='<%#Convert.ToInt32(DataBinder.Eval(Container.DataItem,"Is_Authorised")) == 0 ? false : false%>'
                                                CommandName="comEdit" Height="25px" />
                                            <asp:LinkButton ID="lnkAuthorise" ToolTip="Authorise" class="btn-small btn-warning  icon-lock"
                                                CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Voucher_Code")%>' runat="server"
                                                CommandName="comAuthorise" Height="25px" />
                                                 <%-- Visible='<%#Convert.ToInt32(DataBinder.Eval(Container.DataItem,"Is_Authorised")) == 0 ? true : false%>'--%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </tbody> </table>
                            </FooterTemplate>
                        </asp:Repeater>
                        <asp:Repeater ID="DataList1" runat="server" Visible="false">
                            <HeaderTemplate>
                                <table class="table table-striped table-bordered table-hover">
                                    <thead>
                                        <tr>
                                            <th>
                                                Voucher No
                                            </th>
                                            <th style="width: 20%; text-align: center;">
                                                Voucher Date
                                            </th>
                                            <th style="width: 20%; text-align: center;">
                                                Location
                                            </th>
                                            <th style="width: 15%; text-align: center;">
                                                Material Count
                                            </th>
                                            <th style="text-align: center; width: 15%;">
                                                Total Qty
                                            </th>
                                            <%-- <th style="width: 12%; text-align: center;">
                                                Action
                                            </th>--%>
                                        </tr>
                                    </thead>
                                    <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr class="odd gradeX">
                                    <td>
                                        <asp:Label ID="lblItem_Code" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Voucher_Code")%>' />
                                        <span id="iconDL_Authorise" runat="server" visible='<%# Convert.ToString(DataBinder.Eval(Container.DataItem,"Is_Authorised")) == "1" ? true : false%>'
                                            class="btn btn-danger btn-mini tooltip-error" data-rel="tooltip" data-placement="right"
                                            title="Voucher Authorised"><i class="icon-lock"></i></span>
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:Label ID="lblOpening_Qty" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Date")%>' />
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:Label ID="lblInward_Qty" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"location")%>' />
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:Label ID="lblOutward_Qty" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"ItemCount")%>' />
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:Label ID="Label1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"itemQty")%>' />
                                    </td>
                                    <%-- <td style="text-align: center;">
                                        <div class="inline position-relative">
                                            <asp:LinkButton ID="lnkEdit" ToolTip="Edit" class="btn-small btn-primary icon-info-sign"
                                                CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Voucher_Code")%>' runat="server"
                                                CommandName="comEdit" Height="25px" />
                                            <asp:LinkButton ID="lnkAuthorise" ToolTip="Authorise" class="btn-small btn-warning  icon-lock"
                                                CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Voucher_Code")%>' runat="server"
                                                CommandName="comAuthorise" Height="25px" />
                                    </td>--%>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </tbody> </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="dlGridDisplay" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
            <div id="DivAdd" runat="server">
                <div class="widget-box">
                    <div class="widget-header widget-header-small header-color-dark">
                        <h5>
                            Finished Goods Details
                            <asp:Label runat="server" ID="lblPkey" Visible="false"></asp:Label>
                            <asp:Label runat="server" ID="lblCodeRemove" Visible="false"></asp:Label>
                            <asp:Label runat="server" ID="lblSearchAddItem" Visible="false"></asp:Label>
                        </h5>
                    </div>
                    <div class="widget-body">
                        <div class="widget-body-inner">
                            <div class="widget-main">
                                <div class="row-fluid">
                                    <table cellpadding="3" class="table table-striped table-bordered table-condensed">
                                        <tr>
                                            <td class="span4" style="text-align: left">
                                                <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                    <tr>
                                                        <td style="border-style: none; text-align: left; width: 40%;">
                                                            <asp:Label runat="server" ID="lblAddLoctype" CssClass="red">Location Type</asp:Label>
                                                        </td>
                                                        <td style="border-style: none; text-align: left; width: 60%;">
                                                            <asp:DropDownList ID="ddlAddLocationType" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                data-placeholder="Select Location Type" Width="215px" OnSelectedIndexChanged="ddlAddLocationType_SelectedIndexChanged" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td class="span4" style="text-align: left">
                                                <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                    runat="server" id="tbladdFr_Godown" visible="false">
                                                    <tr>
                                                        <td style="border-style: none; text-align: left; width: 40%;">
                                                            <asp:Label ID="lbladdGNm" runat="server" CssClass="red">Godown Name</asp:Label>
                                                        </td>
                                                        <td style="border-style: none; text-align: left; width: 60%;">
                                                            <asp:DropDownList ID="ddladdGodown" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                data-placeholder="Select Godown" Width="215px" />
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                    runat="server" id="tbladdFr_Division" visible="false">
                                                    <tr>
                                                        <td style="border-style: none; text-align: left; width: 40%;">
                                                            <asp:Label ID="lbladdDivNm" runat="server" CssClass="red">Division Name</asp:Label>
                                                        </td>
                                                        <td style="border-style: none; text-align: left; width: 60%;">
                                                            <asp:DropDownList ID="ddladdDivision" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                data-placeholder="Select Division" Width="215px" OnSelectedIndexChanged="ddladdDivision_SelectedIndexChanged" />
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                    runat="server" id="tbladdFr_Function" visible="false">
                                                    <tr>
                                                        <td style="border-style: none; text-align: left; width: 40%;">
                                                            <asp:Label ID="Label19" runat="server" CssClass="red">Function Name</asp:Label>
                                                        </td>
                                                        <td style="border-style: none; text-align: left; width: 60%;">
                                                            <asp:DropDownList ID="ddladdFunction" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                data-placeholder="Select Function" Width="215px" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td class="span4" style="text-align: left">
                                                <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%"
                                                    runat="server" id="tbladdFr_Center" visible="false">
                                                    <tr>
                                                        <td style="border-style: none; text-align: left; width: 40%;">
                                                            <asp:Label ID="Label20" runat="server" CssClass="red">Center Name</asp:Label>
                                                        </td>
                                                        <td style="border-style: none; text-align: left; width: 60%;">
                                                            <asp:DropDownList ID="ddladdCenter" runat="server" CssClass="chzn-select" data-placeholder="Select Center"
                                                                Width="215px" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="span4" style="text-align: left">
                                                <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                    runat="server" id="TblRequestCode">
                                                    <tr>
                                                        <td style="border-style: none; text-align: left; width: 40%;">
                                                            <asp:Label ID="Label41" runat="server" CssClass="red">Requisition No</asp:Label>
                                                        </td>
                                                        <td style="border-style: none; text-align: left; width: 60%;">
                                                            <%--<asp:DropDownList ID="ddlRequestCode_Add" runat="server" CssClass="chzn-select" data-placeholder="Select Requi. No"
                                                                Width="160px" />--%>
                                                            <asp:TextBox ID="txtRequestCode" runat="server" Text="" Width="155px"></asp:TextBox>
                                                            <button runat="server" class="btn btn-info btn-small" style="height: 28px" id="btnRequi_Search"
                                                                type="button" onserverclick="btnRequi_Search_Click">
                                                                <i class="icon-search icon-on-right"></i>
                                                            </button>
                                                        </td>
                                                      
                                                    </tr>
                                                </table>
                                            </td>
                                            <td class="span4" style="text-align: left">
                                                <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                    <tr>
                                                        <td style="border-style: none; text-align: left; width: 40%;">
                                                            <asp:Label runat="server" ID="lbladdVoucher">Voucher Date</asp:Label>
                                                        </td>
                                                        <td style="border-style: none; text-align: left; width: 60%;">
                                                            <asp:Label runat="server" ID="lblAddVoucherDate" Text="" CssClass="blue" />
                                                        </td>
                                                        
                                                    </tr>
                                                </table>
                                            </td>
                                            <td class="span4" style="text-align: left">
                                                <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                    <tr>
                                                        <td style="border-style: none; text-align: left; width: 40%;">
                                                            <asp:Label runat="server" ID="lblvoucher" Visible="false">Voucher No</asp:Label>
                                                        </td>
                                                        <td style="border-style: none; text-align: left; width: 60%;">
                                                            <asp:Label runat="server" ID="lbladdVoucherNo" Text="" CssClass="blue" />
                                                            <asp:Label runat="server" ID="lblusertypeCode" Text="" Visible="false" />
                                                        </td>
                                                    </tr>
                                                    
                                                </table>
                                            </td>
                                        </tr>
                                        
                                        
                                        
                                    </table>
                                    <table cellpadding="2" class="table table-striped table-bordered table-condensed">
                                    <tr >
                                            <td class="span8" style="text-align: left">
                                                <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                    runat="server" id="Table1">
                                                    <tr>
                                                       <td style="border-style: none; text-align: left; width: 20%;">
                                                            <asp:Label runat="server" ID="Label6">Approve Remark</asp:Label>
                                                        </td>
                                                        <td style="border-style: none; text-align: left; width: 80%;">
                                                            <asp:Label runat="server" ID="lblapproveremark" Text="" Visible="true" CssClass="blue" />
                                                        </td>
                                                      
                                                       
                                                    </tr>
                                                </table>
                                            </td>
                                              <td class="span4" style="text-align: left">
                                                  
                                                        </td>
                                            
                                        </tr></table>
                                </div>
                                <div id="div_student" runat="server">
                                    <%--    <div class="widget-box">
                                        <div class="widget-header widget-header-small header-color-dark">
                                      
                                            <h5>
                                                Student Details
                                            </h5>--%>
                                    <div class="widget-box">
                                        <div class="table-header  header-color-dark">
                                            <table width="100%">
                                                <tr>
                                                    <td class="span10">
                                                        Student Details
                                                    </td>
                                                    <td style="text-align: right" class="span2">
                                                        <asp:LinkButton runat="server" ID="btnexportStudent_Details" ToolTip="Export" class="btn-small btn-danger icon-3x icon-download-alt"
                                                            Height="27px" OnClick="btnexportStudent_Details_Click" />
                                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div class="widget-body">
                                            <div class="widget-body-inner">
                                                <div class="widget-main">
                                                    <asp:DataList ID="datalist_Student" CssClass="table table-striped table-bordered table-hover"
                                                        runat="server" Width="100%" Visible="True" OnItemCommand="datalist_Student_ItemCommand">
                                                        <HeaderTemplate>
                                                            <asp:CheckBox ID="chkAttendanceAll" runat="server" AutoPostBack="True" OnCheckedChanged="chkAttendanceAll_CheckedChanged" />
                                                            <span class="lbl"></span></th>
                                                            <th style="width: 10%; text-align: center;">
                                                                ID
                                                            </th>
                                                            <th style="width: 22%; text-align: center;">
                                                                Student Name
                                                            </th>
                                                              <th style="width: 22%; text-align: center;">
                                                                Center
                                                            </th>
                                                            <th style="width: 10%; text-align: center;">
                                                                Material Code
                                                            </th>
                                                            <th style="width: 20%; text-align: center;">
                                                                Material Name
                                                            </th>
                                                            <th style="width: 10%; text-align: center;">
                                                                EAN No.
                                                            </th>
                                                            <th style="width: 10%; text-align: center;">
                                                                Asset No
                                                            </th>
                                                            <th style="width: 8%; text-align: center;">
                                                                Qty
                                                            </th>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkCheck" runat="server" />
                                                            <span class="lbl"></span></td>
                                                            <td style=" text-align: left;">
                                                                <asp:Label ID="lblrequCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Request_Code")%>'
                                                                    Visible="false" />
                                                                <asp:Label ID="Request_EntryCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Request_EntryCode")%>'
                                                                    Visible="false" />
                                                                <asp:Label ID="lblInward_Code" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Inward_Code")%>'
                                                                    Visible="false" />
                                                                <asp:Label ID="lblInwardEntry_Code_DL" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"InwardEntry_Code")%>'
                                                                    Visible="false" />
                                                                <asp:Label ID="lblAssetStatus" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"AssetStatus_Id")%>'
                                                                    Visible="false" />
                                                                <asp:Label ID="lblAssetFGStatus" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Asset_FG_Status")%>'
                                                                    Visible="false" />
                                                                <asp:Label ID="lblAssetCondition" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Asset_Condition_id")%>'
                                                                    Visible="false" />
                                                                <asp:Label ID="lblRequestEntry_Code_Grid" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Request_EntryCode")%>'
                                                                    Visible="false" />
                                                                <asp:Label ID="lblSBentryCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"SBEntrycode")%>' />
                                                            </td>
                                                            <td style=" text-align: left;">
                                                                <asp:Label ID="lblstudnNm" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"StudentName")%>' />
                                                            </td>
                                                            <td style=" text-align: center;">
                                                                <asp:Label ID="lblcenter" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Source_Center_Name")%>' />
                                                                <asp:Label ID="lblvoucherEntry" Visible="false" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"VoucherEntry_Code")%>' />
                                                            </td>
                                                            <td style=" text-align: left;">
                                                                <asp:Label ID="lblItem_Code_DT" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Item_Code")%>' />
                                                            </td>
                                                                <td style=" text-align: left;">
                                                                <asp:Label ID="lblitem_name" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Item_Name")%>' />
                                                            </td>
                                                            <td style="text-align: left;">
                                                                 <asp:Label ID="lblItem_EAN_No" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"Item_EAN_No")%>' />
                                                                    <%-- <asp:TextBox ID="txtEAN_No" runat="server" Width="120px" Visible="true" Text="" />--%>

                                                            </td>
                                                            <td style="  text-align: left;">
                                                               <asp:Label ID="lblAssetNo_DT1" runat="server" Visible="False" Text='<%#DataBinder.Eval(Container.DataItem,"Asset_No")%>' />
                                                                <asp:TextBox ID="txtAssetNo" runat="server" Width="120px" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"Asset_No")%>'/>
                                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"  ValidationGroup="UcValidateSearch"></asp:RequiredFieldValidator>--%>
                                                            </td>
                                                            <td style="width: 10%; text-align: left;">
                                                                <asp:Label ID="lblQty_DT" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Current_Qty")%>' />
                                                            </td>
                                                        </ItemTemplate>
                                                    </asp:DataList>
                                                    <asp:DataList ID="StudentDetsils" CssClass="table table-striped table-bordered table-hover"
                                                        runat="server" Width="100%" Visible="false">
                                                        <HeaderTemplate>
                                                            <b>ID </b></th>
                                                            <th style="width: 22%; text-align: center;">
                                                                Student Name
                                                            </th>
                                                            <th style="width: 10%; text-align: center;">
                                                                Material Code
                                                            </th>
                                                            <th style="width: 25%; text-align: center;">
                                                                Material Name
                                                            </th>
                                                            <th style="width: 10%; text-align: center;">
                                                                EAN No.
                                                            </th>
                                                            <th style="width: 10%; text-align: center;">
                                                                Asset No
                                                            </th>
                                                            <th style="width: 8%; text-align: center;">
                                                                Qty
                                                            </th>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblrequCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Request_Code")%>'
                                                                Visible="false" />
                                                            <asp:Label ID="Request_EntryCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Request_EntryCode")%>'
                                                                Visible="false" />
                                                            <asp:Label ID="lblInward_Code" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Inward_Code")%>'
                                                                Visible="false" />
                                                            <asp:Label ID="lblInwardEntry_Code_DL" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"InwardEntry_Code")%>'
                                                                Visible="false" />
                                                            <asp:Label ID="lblAssetStatus" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"AssetStatus_Id")%>'
                                                                Visible="false" />
                                                            <asp:Label ID="lblAssetFGStatus" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Asset_FG_Status")%>'
                                                                Visible="false" />
                                                            <asp:Label ID="lblAssetCondition" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Asset_Condition_id")%>'
                                                                Visible="false" />
                                                            <asp:Label ID="lblRequestEntry_Code_Grid" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Request_EntryCode")%>'
                                                                Visible="false" />
                                                            <asp:Label ID="lblSBentryCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"SBEntrycode")%>' />
                                                            </td>
                                                            <td style="width: 12%; text-align: left;">
                                                                <asp:Label ID="lblstudnNm" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"StudentName")%>' />
                                                            </td>
                                                            <td style="width: 10%; text-align: center;">
                                                                <asp:Label ID="lblItem_Code_DT" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Item_Code")%>' />
                                                            </td>
                                                            <td style="text-align: left;">
                                                                <asp:Label ID="lblclramt" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Item_Name")%>' />
                                                            </td>
                                                            <td style="text-align: left;">
                                                                <asp:Label ID="lblsubgrp" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Item_EAN_No")%>' />
                                                            </td>
                                                            <td style="text-align: left;">
                                                                <asp:Label ID="lblAssetNo_DT" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Asset_No")%>' />
                                                            </td>
                                                            <td style="text-align: left;">
                                                                <asp:Label ID="lblQty_DT" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Current_Qty")%>' />
                                                            </td>
                                                        </ItemTemplate>
                                                    </asp:DataList>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div id="div_Teacher" runat="server">
                                    <div class="widget-box">
                                        <div class="widget-box">
                                            <div class="table-header  header-color-dark">
                                                <table width="100%">
                                                    <tr>
                                                        <td class="span10">
                                                            Teacher Details
                                                        </td>
                                                        <td style="text-align: right" class="span2">
                                                            <asp:LinkButton runat="server" ID="btnexportTeacher_Details" ToolTip="Export" class="btn-small btn-danger icon-3x icon-download-alt"
                                                                Height="27px" OnClick="btnexportTeacher_Details_Click" />
                                                            &nbsp;&nbsp;&nbsp;&nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div class="widget-body">
                                                <div class="widget-body-inner">
                                                    <div class="widget-main">
                                                        <asp:DataList ID="datalist_Teacher" CssClass="table table-striped table-bordered table-hover"
                                                            runat="server" Width="100%" Visible="True">
                                                            <HeaderTemplate>
                                                                <asp:CheckBox ID="chkTeachereAll" runat="server" AutoPostBack="True" OnCheckedChanged="chkTeachereAll_CheckedChanged" />
                                                                <span class="lbl"></span></th>
                                                                <th style="width: 10%; text-align: center;">
                                                                    ID
                                                                </th>
                                                                <th style="width: 22%; text-align: center;">
                                                                    Teacher Name
                                                                </th>
                                                                <th style="width: 10%; text-align: center;">
                                                                    Material Code
                                                                </th>
                                                                <th style="width: 25%; text-align: center;">
                                                                    Material Name
                                                                </th>
                                                                <th style="width: 10%; text-align: center;">
                                                                    EAN No.
                                                                </th>
                                                                <th style="width: 10%; text-align: center;">
                                                                    Asset No.
                                                                </th>
                                                                <th style="width: 8%; text-align: center;">
                                                                    Qty
                                                                </th>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="chkCheck" runat="server" />
                                                                <span class="lbl"></span></td>
                                                                <td style="width: 12%; text-align: left;">
                                                                    <asp:Label ID="lblrequCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Request_Code")%>'
                                                                        Visible="false" />
                                                                    <asp:Label ID="Request_EntryCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Request_EntryCode")%>'
                                                                        Visible="false" />
                                                                    <asp:Label ID="lblInward_Code" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Inward_Code")%>'
                                                                        Visible="false" />
                                                                    <asp:Label ID="lblInwardEntry_Code_DL" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"InwardEntry_Code")%>'
                                                                        Visible="false" />
                                                                    <asp:Label ID="lblAssetStatus" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"AssetStatus_Id")%>'
                                                                        Visible="false" />
                                                                    <asp:Label ID="lblAssetFGStatus" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Asset_FG_Status")%>'
                                                                        Visible="false" />
                                                                    <asp:Label ID="lblAssetCondition" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Asset_Condition_id")%>'
                                                                        Visible="false" />
                                                                    <asp:Label ID="lblRequestEntry_Code_Grid" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Request_EntryCode")%>'
                                                                        Visible="false" />
                                                                    <asp:Label ID="lblSBentryCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Partner_code")%>' />
                                                                </td>
                                                                <td style="width: 12%; text-align: left;">
                                                                    <asp:Label ID="lblstudnNm" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"PartnerName")%>' />
                                                                    <asp:Label ID="lblvoucherEntry" Visible="false" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"VoucherEntry_Code")%>' />
                                                                </td>
                                                                <td style="width: 10%; text-align: center;">
                                                                    <asp:Label ID="lblItem_Code_DT" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Item_Code")%>' />
                                                                </td>
                                                                <td style="text-align: left;">
                                                                    <asp:Label ID="lblclramt" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Item_Name")%>' />
                                                                </td>
                                                                <td style="text-align: left;">
                                                                     <asp:Label ID="lblItem_EAN_No" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"Item_EAN_No")%>' />
                                                                     <%--<asp:TextBox ID="txtEAN_No" runat="server" Width="120px" Visible="true" Text="" />--%>
                                                                </td>
                                                                <td style="text-align: left;">
                                                                    <asp:Label ID="lblAssetNo_DT" runat="server"  Visible="false" Text='<%#DataBinder.Eval(Container.DataItem,"Asset_No")%>' />
                                                                     <asp:TextBox ID="txtAssetNo" runat="server" Width="120px" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"Asset_No")%>' />
                                                                     <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="UcValidateSearch"></asp:RequiredFieldValidator>--%>
                                                                </td>
                                                                <td style="text-align: left;">
                                                                    <asp:Label ID="lblQty_DT" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Current_Qty")%>' />
                                                                </td>
                                                            </ItemTemplate>
                                                        </asp:DataList>
                                                        <asp:DataList ID="Teacher_Details" CssClass="table table-striped table-bordered table-hover"
                                                            runat="server" Width="100%" Visible="false">
                                                            <HeaderTemplate>
                                                                ID </th>
                                                                <th style="width: 22%; text-align: center;">
                                                                    Teacher Name
                                                                </th>
                                                                <th style="width: 10%; text-align: center;">
                                                                    Material Code
                                                                </th>
                                                                <th style="width: 25%; text-align: center;">
                                                                    Material Name
                                                                </th>
                                                                <th style="width: 10%; text-align: center;">
                                                                    EAN No.
                                                                </th>
                                                                <th style="width: 10%; text-align: center;">
                                                                    Asset No.
                                                                </th>
                                                                <th style="width: 8%; text-align: center;">
                                                                    Qty
                                                                </th>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblrequCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Request_Code")%>'
                                                                    Visible="false" />
                                                                <asp:Label ID="Request_EntryCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Request_EntryCode")%>'
                                                                    Visible="false" />
                                                                <asp:Label ID="lblInward_Code" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Inward_Code")%>'
                                                                    Visible="false" />
                                                                <asp:Label ID="lblInwardEntry_Code_DL" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"InwardEntry_Code")%>'
                                                                    Visible="false" />
                                                                <asp:Label ID="lblAssetStatus" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"AssetStatus_Id")%>'
                                                                    Visible="false" />
                                                                <asp:Label ID="lblAssetFGStatus" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Asset_FG_Status")%>'
                                                                    Visible="false" />
                                                                <asp:Label ID="lblAssetCondition" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Asset_Condition_id")%>'
                                                                    Visible="false" />
                                                                <asp:Label ID="lblRequestEntry_Code_Grid" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Request_EntryCode")%>'
                                                                    Visible="false" />
                                                                <asp:Label ID="lblSBentryCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Partner_code")%>' />
                                                                </td>
                                                                <td style="width: 12%; text-align: left;">
                                                                    <asp:Label ID="lblstudnNm" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"PartnerName")%>' />
                                                                </td>
                                                                <td style="width: 10%; text-align: center;">
                                                                    <asp:Label ID="lblItem_Code_DT" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Item_Code")%>' />
                                                                </td>
                                                                <td style="text-align: left;">
                                                                    <asp:Label ID="lblclramt" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Item_Name")%>' />
                                                                </td>
                                                                <td style="text-align: left;">
                                                                    <asp:Label ID="lblsubgrp" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Item_EAN_No")%>' />
                                                                </td>
                                                                <td style="text-align: left;">
                                                                    <asp:Label ID="lblAssetNo_DT" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Asset_No")%>' />
                                                                </td>
                                                                <td style="text-align: left;">
                                                                    <asp:Label ID="lblQty_DT" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Current_Qty")%>' />
                                                                </td>
                                                            </ItemTemplate>
                                                        </asp:DataList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div id="div_Employee" runat="server">
                                    <div class="widget-box">
                                        <div class="widget-box">
                                            <div class="table-header  header-color-dark">
                                                <table width="100%">
                                                    <tr>
                                                        <td class="span10">
                                                            Employee Details
                                                        </td>
                                                        <td style="text-align: right" class="span2">
                                                            <asp:LinkButton runat="server" ID="btnexportEmployee" ToolTip="Export" class="btn-small btn-danger icon-3x icon-download-alt"
                                                                Height="27px" OnClick="btnexportEmployee_Details_Click" />
                                                            &nbsp;&nbsp;&nbsp;&nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div class="widget-body">
                                                <div class="widget-body-inner">
                                                    <div class="widget-main">
                                                        <%--<table cellpadding="2" class="table table-striped table-bordered table-condensed">
                                                        <tr>
                                                            <td class="span4" style="text-align: left">
                                                                <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                                    runat="server" id="Table17">
                                                                    <tr>
                                                                        <td style="border-style: none; text-align: left; width: 40%;">
                                                                            <asp:Label ID="Label78" runat="server">Employee Name</asp:Label>
                                                                        </td>
                                                                        <td style="border-style: none; text-align: left">
                                                                            <asp:Label ID="lblEmployeenmforEMP" runat="server" Text=""></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td class="span4" style="text-align: left" colspan="2">
                                                                <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                                    <tr>
                                                                        <td class="span2" style="border-style: none; text-align: left; width: 40%;">
                                                                            <asp:Label ID="Label79" runat="server">Employee Code</asp:Label>
                                                                        </td>
                                                                        <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                                            <asp:Label ID="lblemployeeCodeForEMP" runat="server" Text=""></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="span4" style="text-align: left">
                                                                <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                                    runat="server" id="Table18">
                                                                    <tr>
                                                                        <td style="border-style: none; text-align: left; width: 40%;">
                                                                            <asp:Label ID="Label80" runat="server">Email Id</asp:Label>
                                                                        </td>
                                                                        <td style="border-style: none; text-align: left">
                                                                            <asp:Label ID="lblEmailidForEMP" runat="server" Text=""></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td class="span4" style="text-align: left" colspan="2">
                                                                <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                                    runat="server" id="Table19">
                                                                    <tr>
                                                                        <td style="border-style: none; text-align: left; width: 40%;">
                                                                            <asp:Label ID="Label81" runat="server">Employee Status</asp:Label>
                                                                        </td>
                                                                        <td style="border-style: none; text-align: left">
                                                                            <asp:Label ID="lblEmpstatusForEMP" runat="server" Text=""></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="span4" style="text-align: left">
                                                                <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                                    <tr>
                                                                        <td class="span2" style="border-style: none; text-align: left; width: 40%;">
                                                                            <asp:Label runat="server" ID="Label84">Remarks</asp:Label>
                                                                        </td>
                                                                        <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                                            <asp:Label runat="server" ID="lbl_RemarksForEMP" Text="" CssClass="blue" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td class="span4" style="text-align: left">
                                                                <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                                    runat="server" id="Table6">
                                                                    <tr>
                                                                        <td style="border-style: none; text-align: left">
                                                                            <asp:Label ID="lblRequ_CodeforEmp" runat="server" Text="" Visible="false"></asp:Label>
                                                                            <asp:Label ID="lblRequ_EntryCodeforEMP" runat="server" Text="" Visible="false"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>--%>
                                                        <asp:DataList ID="datalist_Employee" CssClass="table table-striped table-bordered table-hover"
                                                            runat="server" Width="100%" Visible="True">
                                                            <HeaderTemplate>
                                                                <asp:CheckBox ID="chkEmployeeAll" runat="server" AutoPostBack="True" OnCheckedChanged="chkEmployeeAll_CheckedChanged" />
                                                                <span class="lbl"></span></th>
                                                                <th style="width: 10%; text-align: center;">
                                                                    ID
                                                                </th>
                                                                <th style="width: 22%; text-align: center;">
                                                                    Employee Name
                                                                </th>
                                                                <th style="width: 10%; text-align: center;">
                                                                    Material Code
                                                                </th>
                                                                <th style="width: 25%; text-align: center;">
                                                                    Material Name
                                                                </th>
                                                                <th style="width: 10%; text-align: center;">
                                                                    EAN No.
                                                                </th>
                                                                <th style="width: 10%; text-align: center;">
                                                                    Asset No.
                                                                </th>
                                                                <th style="width: 8%; text-align: center;">
                                                                    Qty
                                                                </th>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="chkCheck" runat="server" />
                                                                <span class="lbl"></span></td>
                                                                <td style="width: 12%; text-align: left;">
                                                                    <asp:Label ID="lblrequCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Request_Code")%>'
                                                                        Visible="false" />
                                                                    <asp:Label ID="Request_EntryCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Request_EntryCode")%>'
                                                                        Visible="false" />
                                                                    <asp:Label ID="lblInward_Code" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Inward_Code")%>'
                                                                        Visible="false" />
                                                                    <asp:Label ID="lblInwardEntry_Code_DL" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"InwardEntry_Code")%>'
                                                                        Visible="false" />
                                                                    <asp:Label ID="lblAssetStatus" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"AssetStatus_Id")%>'
                                                                        Visible="false" />
                                                                    <asp:Label ID="lblAssetFGStatus" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Asset_FG_Status")%>'
                                                                        Visible="false" />
                                                                    <asp:Label ID="lblAssetCondition" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Asset_Condition_id")%>'
                                                                        Visible="false" />
                                                                    <asp:Label ID="lblRequestEntry_Code_Grid" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Request_EntryCode")%>'
                                                                        Visible="false" />
                                                                    <asp:Label ID="lblSBentryCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"UserCode")%>' />
                                                                </td>
                                                                <td style="width: 12%; text-align: left;">
                                                                    <asp:Label ID="lblstudnNm" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"UserName")%>' />
                                                                </td>
                                                                <td style="width: 10%; text-align: center;">
                                                                    <asp:Label ID="lblItem_Code_DT" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Item_Code")%>' />
                                                                </td>
                                                                <td style="text-align: left;">
                                                                    <asp:Label ID="lblclramt" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Item_Name")%>' />
                                                                    <asp:Label ID="lblvoucherEntry" Visible="false" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"VoucherEntry_Code")%>' />
                                                                </td>
                                                                <td style="text-align: left;">
                                                                    <asp:Label ID="lblItem_EAN_No" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"Item_EAN_No")%>' />
                                                                     <%--<asp:TextBox ID="txtEAN_No" runat="server" Width="120px" Visible="true" Text="" />--%>
                                                                </td>
                                                                <td style="text-align: left;">
                                                                    <asp:Label ID="lblAssetNo_DT" runat="server" Visible="false"  Text='<%#DataBinder.Eval(Container.DataItem,"Asset_No")%>' />
                                                                     <asp:TextBox ID="txtAssetNo" runat="server" Width="120px" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"Asset_No")%>'  />
                                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"  ValidationGroup="UcValidateSearch"></asp:RequiredFieldValidator>--%>

                                                                </td>
                                                                <td style="text-align: left;">
                                                                    <asp:Label ID="lblQty_DT" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Current_Qty")%>' />
                                                                </td>
                                                            </ItemTemplate>
                                                        </asp:DataList>
                                                        <asp:DataList ID="datalist_EmployeeDetails" CssClass="table table-striped table-bordered table-hover"
                                                            runat="server" Width="100%" Visible="false">
                                                            <HeaderTemplate>
                                                                <b>ID </b></th>
                                                                <th style="width: 22%; text-align: center;">
                                                                    Employee Name
                                                                </th>
                                                                <th style="width: 10%; text-align: center;">
                                                                    Material Code
                                                                </th>
                                                                <th style="width: 25%; text-align: center;">
                                                                    Material Name
                                                                </th>
                                                                <th style="width: 10%; text-align: center;">
                                                                    EAN No.
                                                                </th>
                                                                <th style="width: 10%; text-align: center;">
                                                                    Asset No.
                                                                </th>
                                                                <th style="width: 8%; text-align: center;">
                                                                    Qty
                                                                </th>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblrequCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Request_Code")%>'
                                                                    Visible="false" />
                                                                <asp:Label ID="Request_EntryCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Request_EntryCode")%>'
                                                                    Visible="false" />
                                                                <asp:Label ID="lblInward_Code" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Inward_Code")%>'
                                                                    Visible="false" />
                                                                <asp:Label ID="lblInwardEntry_Code_DL" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"InwardEntry_Code")%>'
                                                                    Visible="false" />
                                                                <asp:Label ID="lblAssetStatus" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"AssetStatus_Id")%>'
                                                                    Visible="false" />
                                                                <asp:Label ID="lblAssetFGStatus" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Asset_FG_Status")%>'
                                                                    Visible="false" />
                                                                <asp:Label ID="lblAssetCondition" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Asset_Condition_id")%>'
                                                                    Visible="false" />
                                                                <asp:Label ID="lblRequestEntry_Code_Grid" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Request_EntryCode")%>'
                                                                    Visible="false" />
                                                                <asp:Label ID="lblSBentryCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"UserCode")%>' />
                                                                </td>
                                                                <td style="width: 12%; text-align: left;">
                                                                    <asp:Label ID="lblstudnNm" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"UserName")%>' />
                                                                </td>
                                                                <td style="width: 10%; text-align: center;">
                                                                    <asp:Label ID="lblItem_Code_DT" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Item_Code")%>' />
                                                                </td>
                                                                <td style="text-align: left;">
                                                                    <asp:Label ID="lblclramt" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Item_Name")%>' />
                                                                </td>
                                                                <td style="text-align: left;">
                                                                    <asp:Label ID="lblsubgrp" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Item_EAN_No")%>' />
                                                                </td>
                                                                <td style="text-align: left;">
                                                                    <asp:Label ID="lblAssetNo_DT1" runat="server"  Text ='<%#DataBinder.Eval(Container.DataItem,"Asset_No")%>' />
                                                                 <%--    <asp:TextBox ID="txtAssetNo" runat="server" Width="120px" Visible="true" Text="" />--%>
                                                                </td>
                                                                <td style="text-align: left;">
                                                                    <asp:Label ID="lblQty_DT" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Current_Qty")%>' />
                                                                </td>
                                                            </ItemTemplate>
                                                        </asp:DataList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row-fluid">
                                    <div class="span4" runat="server" id="DivItems">
                                        <div class="widget-box">
                                            <div class="widget-header">
                                                <h5 class="smaller">
                                                    Material Details
                                                    <%--<td style="width: 10%; text-align: center;">
                                                                <asp:Label ID="lblAmount_DT" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"Amount")%>' />
                                                            </td--%>
                                                </h5>
                                            </div>
                                            <div class="widget-body">
                                                <div class="widget-main">
                                                    <table cellpadding="0" style="width: 100%;" class="table table-striped table-bordered table-condensed">
                                                        <tr>
                                                            <td class="span4" style="text-align: left;" colspan="3">
                                                                <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover">
                                                                    <tr>
                                                                        <td style="border-style: none; text-align: left; width: 35%;">
                                                                            <asp:Label ID="lblIteamCd" runat="server" CssClass="red">Item Code</asp:Label>
                                                                            <span class="help-button ace-popover" data-trigger="hover" data-placement="right"
                                                                                data-content="Enter Item name/ Item Code/ Barcode/ Serial No." title="Help">?
                                                                            </span>&nbsp;
                                                                        </td>
                                                                        <td style="border-style: none; text-align: left; width: 65%;">
                                                                            <asp:TextBox ID="txtItemMatCode" runat="server" Text="" placeholder="Search Item....."
                                                                                Width="140px"></asp:TextBox>
                                                                            <button runat="server" class="btn btn-info btn-small" style="height: 28px" id="btnSearchItem"
                                                                                onserverclick="btnSearchItem_ServerClick" type="button">
                                                                                <i class="icon-search icon-on-right"></i>
                                                                            </button>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr runat="server" id="tr1">
                                                            <td class="span4" style="text-align: left" colspan="3">
                                                                <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover">
                                                                    <tr>
                                                                        <td style="border-style: none; text-align: left; width: 35%;">
                                                                            <asp:Label ID="Label2" runat="server">Material Code</asp:Label>
                                                                        </td>
                                                                        <td style="border-style: none; text-align: left; width: 65%;">
                                                                            <asp:Label ID="lblMateCode" runat="server" Text=""></asp:Label>
                                                                            <asp:Label ID="lblInwardEntry_Code" runat="server" Text="" Visible="false"></asp:Label>
                                                                            <asp:Label ID="lblCurrentQty" runat="server" Text="" Visible="false"></asp:Label>
                                                                            <asp:Label ID="lblInward_Code" runat="server" Text="" Visible="false" />
                                                                            <asp:Label ID="lblInward_Qty" runat="server" Text="" Visible="false" />
                                                                            <asp:Label ID="lblRequestEntry_Code_Item" runat="server" Text="" Visible="false" />
                                                                            <asp:Label ID="lblPkey2_Grid" runat="server" Text="" Visible="false" />
                                                                            <asp:Label ID="lblAssetStatus_Grid" runat="server" Text="" Visible="false" />
                                                                            <asp:Label ID="lblAssetFGStatus_Grid" runat="server" Text="" Visible="false" />
                                                                            <asp:Label ID="lblAssetCondition_Grid" runat="server" Text="" Visible="false" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="span4" style="text-align: left" colspan="3">
                                                                <table cellpadding="0" class="table-hover" style="border-style: none; width: 100%;">
                                                                    <tr>
                                                                        <td style="border-style: none; text-align: left; width: 35%;">
                                                                            <asp:Label ID="lbladdIteamNm" runat="server">Material Name</asp:Label>
                                                                        </td>
                                                                        <td style="border-style: none; text-align: left; width: 65%;">
                                                                            <asp:Label ID="lblItemName" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="span4" style="text-align: left" colspan="3">
                                                                <table cellpadding="0" class="table-hover" style="border-style: none; width: 100%;">
                                                                    <tr>
                                                                        <td style="border-style: none; text-align: left; width: 35%;">
                                                                            <asp:Label ID="lbladdUnit" runat="server">Unit</asp:Label>
                                                                        </td>
                                                                        <td style="border-style: none; text-align: left; width: 65%;">
                                                                            <asp:Label ID="lblUnit" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr runat="server" id="tr2">
                                                            <td class="span4" style="text-align: left" colspan="3">
                                                                <table cellpadding="0" class="table-hover" style="border-style: none; width: 100%;">
                                                                    <tr>
                                                                        <td style="border-style: none; text-align: left; width: 35%;">
                                                                            <asp:Label ID="Label60" runat="server" CssClass="red">Quantity</asp:Label>
                                                                        </td>
                                                                        <td style="border-style: none; text-align: left; width: 65%;">
                                                                            <asp:TextBox ID="txtItemQty" runat="server" Text="1" Width="150px" AutoPostBack="True"></asp:TextBox>
                                                                            &nbsp;
                                                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender19" runat="server" FilterType="Numbers,Custom"
                                                                                ValidChars="." TargetControlID="txtItemQty" />
                                                                            <asp:Label runat="server" ID="Label10" Text="" ForeColor="Red" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="span4" style="text-align: left" colspan="3">
                                                                <table cellpadding="0" class="table-hover" style="border-style: none; width: 100%;">
                                                                    <tr>
                                                                        <td style="border-style: none; text-align: left; width: 35%;">
                                                                            <asp:Label ID="Label64" runat="server">Rate</asp:Label>
                                                                        </td>
                                                                        <td style="border-style: none; text-align: left; width: 65%;">
                                                                            <asp:Label ID="txtItemRate" runat="server" Width="160px" Text="0"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="span4" style="text-align: left" colspan="3">
                                                                <table cellpadding="0" class="table-hover" style="border-style: none; width: 100%;">
                                                                    <tr>
                                                                        <td style="border-style: none; text-align: left; width: 35%;">
                                                                            <asp:Label ID="Label63" runat="server">Value</asp:Label>
                                                                        </td>
                                                                        <td style="border-style: none; text-align: left; width: 65%;">
                                                                            <%-- <th style="width: 10%; text-align: center;">
                                                            Amount--%>
                                                                            <asp:Label ID="lblCalValue" runat="server" onkeypress="return NumberOnly(event);"
                                                                                Width="160px">0</asp:Label>
                                                                            <button class="btn btn-info btn-mini radius-4" id="btnSaveItem" runat="server" style="height: 28px"
                                                                                validationgroup="UcValidate" title="Add Item Qty " type="button" onserverclick="btnSaveItem_ServerClick">
                                                                                <i class="icon-plus"></i>
                                                                            </button>
                                                                            <asp:ValidationSummary ID="ValidationSummary1" ShowSummary="false" DisplayMode="List"
                                                                                ShowMessageBox="true" ValidationGroup="UcValidate" runat="server" />
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
                                    <div class="span8" runat="server" id="DivItemsList">
                                        <div class="widget-box">
                                            <div class="widget-header">
                                                <h5 class="smaller">
                                                    Material List
                                                </h5>
                                            </div>
                                            <div class="widget-body">
                                                <div class="widget-main">
                                                    <asp:DataList ID="dlQuestion" CssClass="table table-striped table-bordered table-hover"
                                                        runat="server" Width="99%" OnItemCommand="dlQuestion_ItemCommand">
                                                        <HeaderTemplate>
                                                            <b>Sr.No </b></th>
                                                            <th style="width: 10%; text-align: center;">
                                                                Material Code
                                                            </th>
                                                            <th style="width: 20%; text-align: center;">
                                                                Material Name
                                                            </th>
                                                            <th style="width: 15%; text-align: center;">
                                                                EAN No.
                                                            </th>
                                                            <th style="width: 15%; text-align: center;">
                                                                Asset No.
                                                            </th>
                                                            <th style="width: 5%; text-align: center;">
                                                                Qty
                                                            </th>
                                                            <th style="width: 10%; text-align: center;">
                                                                Unit Price
                                                            </th>
                                                            <th style="width: 10%; text-align: center;">
                                                                Amount
                                                            </th>
                                                            <th style="width: 15%; text-align: center;">
                                                            Remove Material
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblPkey_Code" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Pkey")%>' />
                                                            <td style="width: 20%; text-align: center;">
                                                                <asp:Label ID="lblDispatch_Code" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Dispatch_Code")%>'
                                                                    Visible="false" />
                                                                <asp:Label ID="lblDispatchEntry_Code" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"DispatchEntry_Code")%>'
                                                                    Visible="false" />
                                                                <asp:Label ID="lblItem_Code_DT" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Item_Code")%>' />
                                                                <asp:Label ID="lblInward_Code" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Inward_Code")%>'
                                                                    Visible="false" />
                                                                <asp:Label ID="lblInwardEntry_Code_DL" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"InwardEntry_Code")%>'
                                                                    Visible="false" />
                                                                <asp:Label ID="Inward_Qty" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Inward_Qty")%>'
                                                                    Visible="false" />
                                                                <asp:Label ID="Is_Authorised" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Is_Authorised")%>'
                                                                    Visible="false" />
                                                                <asp:Label ID="lblRequestEntry_Code_Grid" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Request_EntryCode")%>'
                                                                    Visible="false" />
                                                                <asp:Label ID="lblPkey2" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Pkey2")%>'
                                                                    Visible="false" />
                                                                <asp:Label ID="lblAssetStatus" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"AssetStatusId")%>'
                                                                    Visible="false" />
                                                                <asp:Label ID="lblAssetFGStatus" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"AssetFGStatus")%>'
                                                                    Visible="false" />
                                                                <asp:Label ID="lblAssetCondition" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"AssetCondition")%>'
                                                                    Visible="false" />
                                                            </td>
                                                            <td style="width: 20%; text-align: center;">
                                                                <asp:Label ID="lblItemName_DT" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"Item_Name")%>' />
                                                            </td>
                                                            <td style="width: 15%; text-align: center;">
                                                                <asp:Label ID="lblBarcode_DT" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"Barcode")%>' />
                                                            </td>
                                                            <td style="width: 15%; text-align: center;">
                                                                <asp:Label ID="lblAssetNo_DT" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"Asset_No")%>' />
                                                            </td>
                                                            <td style="width: 10%; text-align: center;">
                                                                <asp:Label ID="lblQty_DT" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"Dispatch_Qty")%>' />
                                                            </td>
                                                            <td style="width: 10%; text-align: center;">
                                                                <asp:Label ID="lblUnitPrice_DT" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"Purchase_Rate")%>' />
                                                            </td>
                                                            <td style="width: 10%; text-align: center;">
                                                                <asp:Label ID="lblAmount_DT" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"Purchase_Amount")%>' />
                                                            </td>
                                                            <td style="width: 15%; text-align: center;">
                                                                <asp:LinkButton ID="lnkRemove" ToolTip="Remove" class="btn-small btn-danger icon-trash"
                                                                    runat="server" CommandName="ItemRemove" Height="25px" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Pkey")%>'
                                                                    Visible='<%#(string)DataBinder.Eval(Container.DataItem,"Is_Authorised") =="0" ? true : false%>' />
                                                        </ItemTemplate>
                                                    </asp:DataList>
                                                    <asp:DataList ID="DataList2" CssClass="table table-striped table-bordered table-hover"
                                                        runat="server" Width="99%" Visible="false">
                                                        <HeaderTemplate>
                                                            <b>Sr.No </b></th>
                                                            <th style="width: 10%; text-align: center;">
                                                                Material Code
                                                            </th>
                                                            <th style="width: 20%; text-align: center;">
                                                                Material Name
                                                            </th>
                                                            <th style="width: 15%; text-align: center;">
                                                                EAN No.
                                                            </th>
                                                            <th style="width: 15%; text-align: center;">
                                                                Asset No.
                                                            </th>
                                                            <th style="width: 5%; text-align: center;">
                                                                Qty
                                                            </th>
                                                            <th style="width: 10%; text-align: center;">
                                                                Unit Price
                                                            </th>
                                                            <th style="width: 10%; text-align: center;">
                                                            Amount
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblPkey_Code" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Pkey")%>' />
                                                            <td style="width: 20%; text-align: center;">
                                                                <asp:Label ID="lblDispatch_Code" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Dispatch_Code")%>'
                                                                    Visible="false" />
                                                                <asp:Label ID="lblDispatchEntry_Code" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"DispatchEntry_Code")%>'
                                                                    Visible="false" />
                                                                <asp:Label ID="lblItem_Code_DT" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Item_Code")%>' />
                                                                <asp:Label ID="lblInward_Code" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Inward_Code")%>'
                                                                    Visible="false" />
                                                                <asp:Label ID="lblInwardEntry_Code_DL" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"InwardEntry_Code")%>'
                                                                    Visible="false" />
                                                                <asp:Label ID="Inward_Qty" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Inward_Qty")%>'
                                                                    Visible="false" />
                                                                <asp:Label ID="Is_Authorised" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Is_Authorised")%>'
                                                                    Visible="false" />
                                                                <asp:Label ID="lblRequestEntry_Code_Grid" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Request_EntryCode")%>'
                                                                    Visible="false" />
                                                            </td>
                                                            <td style="width: 20%; text-align: center;">
                                                                <asp:Label ID="lblItemName_DT" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"Item_Name")%>' />
                                                            </td>
                                                            <td style="width: 15%; text-align: center;">
                                                                <asp:Label ID="lblBarcode_DT" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"Barcode")%>' />
                                                            </td>
                                                            <td style="width: 15%; text-align: center;">
                                                                <asp:Label ID="lblAssetNo_DT" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"Asset_No")%>' />
                                                            </td>
                                                            <td style="width: 10%; text-align: center;">
                                                                <asp:Label ID="lblQty_DT" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"Dispatch_Qty")%>' />
                                                            </td>
                                                            <td style="width: 10%; text-align: center;">
                                                                <asp:Label ID="lblUnitPrice_DT" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"Purchase_Rate")%>' />
                                                            </td>
                                                            <td style="width: 10%; text-align: center;">
                                                                <asp:Label ID="lblAmount_DT" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"Purchase_Amount")%>' />
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
                                                            <%--  <asp:Label ID="lblAmount" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Amount")%>'
                                                                    Visible="false" />--%>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="widget-main alert-block alert-info" style="text-align: center;">
                                <!--Button Area -->
                                <asp:Button class="btn  btn-app btn-success btn-mini radius-4" runat="server" ID="BtnSaveAdd"
                                    Text="Save" ToolTip="Save" ValidationGroup="UcValidateSearch" OnClick="BtnSaveAdd_Click" />
                                <asp:Button class="btn btn-app btn-success btn-mini radius-4" ID="BtnSaveEdit" runat="server"
                                    Text="Save" ValidationGroup="UcValidate" Visible="False" OnClick="BtnSaveEdit_Click" />
                                <asp:Button class="btn btn-app btn-primary btn-mini radius-4" ID="btnCancel" Visible="true"
                                    runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                                <asp:ValidationSummary ID="ValidationSummary3" ShowSummary="false" DisplayMode="List"
                                    ShowMessageBox="true" ValidationGroup="UcValidate" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div id="DivAuthorise" runat="server" visible="false">
            <div class="widget-box">
                <div class="widget-header widget-header-small header-color-dark">
                    <h5 class="modal-title">
                        Voucher Authorisation
                        <asp:Label runat="server" ID="lblAuthPkey" Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="lblAuthorised" Visible="false"></asp:Label>
                    </h5>
                </div>
                <div class="widget-body">
                    <div class="widget-body-inner">
                        <div class="widget-main">
                     <%--       <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>--%>
                                    <table cellpadding="3" class="table table-striped table-bordered table-condensed">
                                        <tr>
                                            <td class="span4" style="text-align: left">
                                                <table cellpadding="0" class="table-hover" style="border-style: none; width: 100%;">
                                                    <tr>
                                                        <td style="border-style: none; text-align: left; width: 40%;">
                                                            <asp:Label ID="Label34" runat="server">Location Type</asp:Label>
                                                        </td>
                                                        <td style="border-style: none; text-align: left; width: 60%;">
                                                            <asp:Label runat="server" ID="lblLocationType_Auth" Text="" CssClass="blue" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td class="span4" style="text-align: left">
                                                <table cellpadding="0" class="table-hover" style="border-style: none; width: 100%;">
                                                    <tr>
                                                        <td style="border-style: none; text-align: left; width: 40%;">
                                                            <asp:Label ID="Label35" runat="server">Location</asp:Label>
                                                        </td>
                                                        <td style="border-style: none; text-align: left; width: 60%;">
                                                            <asp:Label runat="server" ID="lbllocation_Auth" Text="" CssClass="blue" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td class="span4" style="text-align: left">
                                                <table cellpadding="0" class="table-hover" style="border-style: none; width: 100%;">
                                                    <tr>
                                                        <td style="border-style: none; text-align: left; width: 40%;">
                                                            <asp:Label ID="Label37" runat="server">Request Code</asp:Label>
                                                        </td>
                                                        <td style="border-style: none; text-align: left; width: 60%;">
                                                            <asp:Label runat="server" ID="lblRequestCode_Auth" Text="" CssClass="blue" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="span4" style="text-align: left">
                                                <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                    <tr>
                                                        <td class="span2" style="border-style: none; text-align: left; width: 40%;">
                                                            <asp:Label ID="Label3" runat="server">Voucher No.</asp:Label>
                                                        </td>
                                                        <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                            <asp:Label runat="server" ID="lblVoucherNo_Auth" Text="" CssClass="blue" />
                                                            <span id="Flag_Authorised" runat="server" visible="false" class="label label-important arrowed">
                                                                Authorised</span>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td class="span4" style="text-align: left">
                                                <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                    <tr>
                                                        <td style="border-style: none; text-align: left; width: 40%;">
                                                            <asp:Label ID="Label4" runat="server">Voucher Date</asp:Label>
                                                        </td>
                                                        <td style="border-style: none; text-align: left; width: 60%;">
                                                            <asp:Label runat="server" ID="lblVoucherdate_Auth" Text="" CssClass="blue" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td class="span4" style="text-align: left">
                                                <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                    <tr>
                                                        <td style="border-style: none; text-align: left; width: 40%;">
                                                            &nbsp;&nbsp;&nbsp;&nbsp;
                                                        </td>
                                                        <td style="border-style: none; text-align: left; width: 60%;">
                                                            &nbsp;&nbsp;&nbsp;&nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <table cellpadding="2" class="table table-striped table-bordered table-condensed">
                                    <tr >
                                            <td class="span8" style="text-align: left">
                                                <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                    runat="server" id="Table3">
                                                    <tr>
                                                       <td style="border-style: none; text-align: left; width: 20%;">
                                                            <asp:Label runat="server" ID="Label5">Approve Remark</asp:Label>
                                                        </td>
                                                        <td style="border-style: none; text-align: left; width: 80%;">
                                                            <asp:Label runat="server" ID="lblapprovedRemark" Text="" Visible="true" CssClass="blue" />
                                                        </td>
                                                        <td style="border-style: none; text-align: left; width: 60%;">
                                                            &nbsp;
                                                        </td>
                                                      
                                                       
                                                    </tr>
                                                </table>
                                            </td>
                                              <td class="span4" style="text-align: left">
                                                  
                                                        </td>
                                            
                                        </tr></table>
                                     <div id="divstudentDetails" runat="server">
                                    <div class="widget-box">
                                        <div class="table-header  header-color-dark">
                                            <table width="100%">
                                                <tr>
                                                    <td class="span10">
                                                        Student Details
                                                    </td>
                                                    <td style="text-align: right" class="span2">
                                                        <asp:LinkButton runat="server" ID="LinkButton1" ToolTip="Export" class="btn-small btn-danger icon-3x icon-download-alt"
                                                            Height="27px" onclick="LinkButton1_Click" />
                                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div class="widget-body">
                                           <div class="widget-body-inner">
                                              <div class="widget-main">
                                          <asp:DataList ID="dlItemListAuthorise" CssClass="table table-striped table-bordered table-hover"
                                        runat="server" Width="100%">
                                        <HeaderTemplate>
                                            <b>Material Code </b></th>
                                            <th style="width: 10%; text-align: center;">
                                                Voucher Entry Code
                                            </th>
                                             <th style="width: 25%; text-align: center;">
                                                Student Name
                                            </th>
                                            <th style="width: 25%; text-align: center;">
                                                Material Name
                                            </th>
                                            <th style="width: 8%; text-align: center;">
                                                Challan Qty
                                            </th>
                                            <th style="width: 13%; text-align: center;">
                                                EAN No.
                                            </th>
                                            <th style="width: 13%; text-align: center;">
                                                Asset No
                                            </th>
                                            <th style="width: 10%; text-align: center;">
                                                Asset Status
                                            </th>
                                            <th style="width: 10%; text-align: center;">
                                                FG Status
                                            </th>
                                            <th style="width: 10%; text-align: center;">
                                            Asset Condition
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblItem_Code" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Item_Code")%>' />
                                            </td>
                                            <td>
                                                <asp:Label ID="lblVoucherEntry_Code" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"VoucherEntry_Code")%>' />
                                            </td>
                                            <td>
                                                <asp:Label ID="Label7" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"UserName")%>' />
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:Label ID="lblItem_Name" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"Item_Name")%>' />
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:Label ID="lblQty" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"Qty")%>' />
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:Label ID="lblItem_EAN_No" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"Item_EAN_No")%>' />
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:Label ID="lblAsset_No" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"Asset_No")%>' />
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:Label ID="lblAssets_Status_Name" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"Assets_Status_Name")%>' />
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:Label ID="Label9" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"Asset_FG_Name")%>' />
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:Label ID="Label12" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"Assets_Condition_Name")%>' />
                                        </ItemTemplate>
                                    </asp:DataList>
                                    </div>
                                    </div>
                                    </div>
                                    <br />
                                    </div>
                                    </div>
                                    <div id="divteacherDetails" runat="server">
                                    <div class="widget-box">
                                        <div class="table-header  header-color-dark">
                                            <table width="100%">
                                                <tr>
                                                    <td class="span10">
                                                        Teacher Details
                                                    </td>
                                                    <td style="text-align: right" class="span2">
                                                        <asp:LinkButton runat="server" ID="teacherexoprt" ToolTip="Export" class="btn-small btn-danger icon-3x icon-download-alt"
                                                            Height="27px" onclick="teacherexoprt_Click" />
                                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div class="widget-body">
                                           <div class="widget-body-inner">
                                              <div class="widget-main">
                                          <asp:DataList ID="ddlteacher" CssClass="table table-striped table-bordered table-hover"
                                        runat="server" Width="100%">
                                        <HeaderTemplate>
                                            <b>Material Code </b></th>
                                            <th style="width: 10%; text-align: center;">
                                                Voucher Entry Code
                                            </th>
                                             <th style="width: 25%; text-align: center;">
                                                Teacher Name
                                            </th>
                                            <th style="width: 25%; text-align: center;">
                                                Material Name
                                            </th>
                                            <th style="width: 8%; text-align: center;">
                                                Challan Qty
                                            </th>
                                            <th style="width: 13%; text-align: center;">
                                                EAN No.
                                            </th>
                                            <th style="width: 13%; text-align: center;">
                                                Asset No
                                            </th>
                                            <th style="width: 10%; text-align: center;">
                                                Asset Status
                                            </th>
                                            <th style="width: 10%; text-align: center;">
                                                FG Status
                                            </th>
                                            <th style="width: 10%; text-align: center;">
                                            Asset Condition
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblItem_Code" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Item_Code")%>' />
                                            </td>
                                            <td>
                                                <asp:Label ID="lblVoucherEntry_Code" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"VoucherEntry_Code")%>' />
                                            </td>
                                            <td>
                                                <asp:Label ID="Label7" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"UserName")%>' />
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:Label ID="lblItem_Name" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"Item_Name")%>' />
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:Label ID="lblQty" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"Qty")%>' />
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:Label ID="lblItem_EAN_No" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"Item_EAN_No")%>' />
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:Label ID="lblAsset_No" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"Asset_No")%>' />
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:Label ID="lblAssets_Status_Name" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"Assets_Status_Name")%>' />
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:Label ID="Label9" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"Asset_FG_Name")%>' />
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:Label ID="Label12" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"Assets_Condition_Name")%>' />
                                        </ItemTemplate>
                                    </asp:DataList>
                                    </div>
                                    </div>
                                    </div>
                                    <br />
                                    </div>
                                    </div>
                                    <div id="divEmployeeDetails" runat="server">
                                    <div class="widget-box">
                                        <div class="table-header  header-color-dark">
                                            <table width="100%">
                                                <tr>
                                                    <td class="span10">
                                                        Employee Details
                                                    </td>
                                                    <td style="text-align: right" class="span2">
                                                        <asp:LinkButton runat="server" ID="EmployeeExoprt" ToolTip="Export" class="btn-small btn-danger icon-3x icon-download-alt"
                                                            Height="27px" onclick="EmployeeExoprt_Click" />
                                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div class="widget-body">
                                           <div class="widget-body-inner">
                                              <div class="widget-main">
                                          <asp:DataList ID="ddlEmployee" CssClass="table table-striped table-bordered table-hover"
                                        runat="server" Width="100%">
                                        <HeaderTemplate>
                                            <b>Material Code </b></th>
                                            <th style="width: 10%; text-align: center;">
                                                Voucher Entry Code
                                            </th>
                                             <th style="width: 25%; text-align: center;">
                                                Employee Name
                                            </th>
                                            <th style="width: 25%; text-align: center;">
                                                Material Name
                                            </th>
                                            <th style="width: 8%; text-align: center;">
                                                Challan Qty
                                            </th>
                                            <th style="width: 13%; text-align: center;">
                                                EAN No.
                                            </th>
                                            <th style="width: 13%; text-align: center;">
                                                Asset No
                                            </th>
                                            <th style="width: 10%; text-align: center;">
                                                Asset Status
                                            </th>
                                            <th style="width: 10%; text-align: center;">
                                                FG Status
                                            </th>
                                            <th style="width: 10%; text-align: center;">
                                            Asset Condition
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblItem_Code" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Item_Code")%>' />
                                            </td>
                                            <td>
                                                <asp:Label ID="lblVoucherEntry_Code" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"VoucherEntry_Code")%>' />
                                            </td>
                                            <td>
                                                <asp:Label ID="Label7" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"UserName")%>' />
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:Label ID="lblItem_Name" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"Item_Name")%>' />
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:Label ID="lblQty" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"Qty")%>' />
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:Label ID="lblItem_EAN_No" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"Item_EAN_No")%>' />
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:Label ID="lblAsset_No" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"Asset_No")%>' />
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:Label ID="lblAssets_Status_Name" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"Assets_Status_Name")%>' />
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:Label ID="Label9" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"Asset_FG_Name")%>' />
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:Label ID="Label12" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"Assets_Condition_Name")%>' />
                                        </ItemTemplate>
                                    </asp:DataList>
                                    </div>
                                    </div>
                                    </div>
                                    <br />
                                    </div>
                                    </div>
                            <%--    </ContentTemplate>
                            </asp:UpdatePanel>--%>
                        </div>
                    </div>
                    <div class="widget-main alert-block alert-success  alert- " style="text-align: center;">
                        <!--Button Area -->
                        <asp:Label runat="server" ID="Label38" Text="" ForeColor="Red" />
                        <asp:Button class="btn btn-app btn-success btn-mini radius-4" ID="btnAuthorise" runat="server"
                            Text="Authorise" ValidationGroup="UcValidate" Width="80px" OnClick="btnAuthorise_Click" />
                        <asp:Button class="btn btn-app btn-primary btn-mini radius-4" ID="btnCloseAuthorise"
                            Visible="true" Width="80px" runat="server" Text="Close" OnClick="btnCloseAuthorise_Click" />
                        <%--<asp:Button class="btn btn-app btn-primary btn-mini radius-4" ID="BtnPrint" Visible="false"
                                runat="server" Text="Print" OnClick="BtnPrint_Click" />--%>
                        <asp:ValidationSummary ID="ValidationSummary4" ShowSummary="false" DisplayMode="List"
                            ShowMessageBox="true" ValidationGroup="UcValidate" runat="server" />
                    </div>
                </div>
            </div>
        </div>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <div class="modal
    fade" id="DivOverrid" style="left: 40% !important; top: 10% !important; display: none; width: 65%"
                    role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                    &times;</button>
                                <h4 class="modal-title">
                                    Select Material
                                </h4>
                            </div>
                            <div class="modal-body">
                                <!--Controls
    Area -->
                                <table cellpadding="0" style="border-style: none;" width="100%">
                                    <tr>
                                        <td style="border-style: none; text-align: left; width: 90%;" colspan="3">
                                            <asp:DataList ID="DataList3" runat="server" CssClass="table table-striped table-bordered table-hover"
                                                Width="97%" OnItemCommand="DataList3_ItemCommand">
                                                <HeaderTemplate>
                                                    <b>Material Code</b>
                                                    <th>
                                                        Material Name
                                                    </th>
                                                    <th align="left" style="width: 10%">
                                                        Unit
                                                    </th>
                                                    <th align="left" style="width: 10%">
                                                        Asset No
                                                    </th>
                                                    <th align="left" style="width: 10%">
                                                        Qty
                                                    </th>
                                                    <th align="left" style="width: 10%">
                                                        Unit Price
                                                    </th>
                                                    <th align="left" style="width: 10%">
                                                        Total Amount
                                                    </th>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkMaterial_Code" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Pkey")%>'
                                                        runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Item_Code")%>' CommandName="comSetItem" />
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblDLInwardEntry_Code" runat="server" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem,"InwardEntry_Code")%>' />
                                                        <asp:Label ID="lblDLItemName" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"Item_Name")%>' />
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblDLItemUnit" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"UOM_Name")%>' />
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblAsset_No" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"Asset_No")%>' />
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblCurrent_Qty" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"Current_Qty")%>' />
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblPurchase_Rate" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"Purchase_Rate")%>' />
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblPurchase_Amount" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"Purchase_Amount")%>' />
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
                        <!--
    /.modal-content -->
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
                        <h4 class="modal-title" style="color: #FF0000">
                            Warning
                        </h4>
                    </div>
                    <div class="modal-body">
                        <!--Controls
    Area -->
                        <table cellpadding="0" style="border-style: none;" width="100%">
                            <tr>
                                <td style="border-style: none; text-align: left; width: 40%;">
                                    <asp:Label runat="server" ID="Label39">Are you sure want to remove Material ?</asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="modal-footer">
                        <!--Button Area -->
                        <asp:Label runat="server" ID="Label40" Text="" Visible="false" />
                        <asp:Button class="btn btn-app btn-success btn-mini radius-4" ID="Button3" ToolTip="Yes"
                            runat="server" Text="Yes" OnClick="btnDivConfirmYes_Click" />
                        <asp:Button class="btn btn-app btn-primary btn-mini radius-4" data-dismiss="modal"
                            ID="Button4" ToolTip="No" runat="server" Text="No" />
                    </div>
                </div>
                <!-- /.modal-content
    -->
            </div>
            <!-- /.modal-dialog -->
        </div>
</asp:Content>
