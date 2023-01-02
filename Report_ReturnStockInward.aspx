<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Report_ReturnStockInward.aspx.cs" Inherits="Report_ReturnStockInward" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
<asp:Content ID="Content2" ContentPlaceHolderID="MainContainer" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="breadcrumbs" class="position-relative" style="height: 53px">
        <ul class="breadcrumb" style="height: 15px">
            <li><i class="icon-home"></i><a href="Homepage.aspx">Home</a><span class="divider"><i
                class="icon-angle-right"></i></span></li>
            <li>
                <h4 class="blue">
                    Return Stock Inward<span class="divider"></span></h4>
            </li>
        </ul>
        <div id="nav-search">
            <!-- /btn-group -->
            <%--<asp:Button class="btn  btn-app btn-success btn-mini radius-4" runat="server" ID="BtnAdd"
                Text="Add" OnClick="BtnAdd_Click" />--%>
            <asp:Button class="btn  btn-app btn-primary btn-mini radius-4  " Visible="true" runat="server"
                ID="BtnShowSearchPanel" Text="Search" 
                onclick="BtnShowSearchPanel_Click"  />
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
                                                                <asp:Label ID="Label1" runat="server" CssClass="red">Location</asp:Label>
                                                            </td>
                                                            <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlLocationType" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Location Type" Width="215px" OnSelectedIndexChanged="ddllocation_Search_SelectedIndexChanged" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span6" style="text-align: left">
                                                  <%--  <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                        runat="server" id="tblgodown" visible="false">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="lblGodownFR_SR" runat="server" CssClass="red">Godown</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlgodownFR_SRSearch" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Godown" Width="215px" />
                                                            </td>
                                                        </tr>
                                                    </table>--%>
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                        runat="server" id="tblDivision" visible="false">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="lblDivisiobFR_SR" runat="server" CssClass="red">Division</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlDivisionFR_SRSearch" runat="server" AutoPostBack="True"
                                                                    CssClass="chzn-select" data-placeholder="Select Division" Width="215px" OnSelectedIndexChanged="ddldivision_Search_SelectedIndexChanged" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                        runat="server" id="tblFunction" visible="false">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="lblFunctionFR_SR" runat="server" CssClass="red">Function</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlFunctionFR_SRSearch" runat="server" AutoPostBack="True"
                                                                    CssClass="chzn-select" data-placeholder="Select Function" Width="215px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%"
                                                        runat="server" id="tblCenter" visible="false">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="lblCenterFR_SR" runat="server" CssClass="red">Center</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlCenterFR_SRSearch" runat="server" CssClass="chzn-select"
                                                                    data-placeholder="Select Center" Width="215px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" class="table-hover" style="border-style: none; width: 118%;">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="lblItem" runat="server" CssClass="red">Item Name</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlItemNme_SR" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select supplier" Width="215px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" class="table-hover" style="border-style: none; width: 139%;">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="lbl_Period" runat="server" CssClass="red">Period</asp:Label>
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
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="widget-main alert-block alert-info" style="text-align: center;">
                                <!--Button Area -->
                                <asp:Button class="btn btn-app btn-primary  btn-mini radius-4" runat="server" ID="BtnSearch"
                                    Text="Search" ToolTip="Search" ValidationGroup="UcValidateSearch" 
                                    onclick="BtnSearch_Click" />
                                <asp:Button class="btn btn-app btn-grey btn-mini radius-4" ID="BtnClearSearch" Visible="true"
                                    runat="server" Text="Clear" onclick="BtnClearSearch_Click" />
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
                                        Height="25px"/>
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div class="row-fluid">
                    <table cellpadding="3" class="table table-striped table-bordered table-condensed">
                        <tr>
                            <td class="span6" style="text-align: left">
                                <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                    <tr>
                                        <td style="border-style: none; text-align: left; width: 40%;">
                                            <asp:Label runat="server" ID="Label7">Location Type</asp:Label>
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
                                            <asp:Label runat="server" ID="Label17">Location</asp:Label>
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
                                            <asp:Label runat="server" ID="Label2">Item Name</asp:Label>
                                        </td>
                                        <td style="border-style: none; text-align: left; width: 60%;">
                                            <asp:Label runat="server" ID="lblItemName" CssClass="blue" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td class="span6" style="text-align: left">
                                <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                    <tr>
                                        <td style="border-style: none; text-align: left; width: 40%;">
                                            <asp:Label runat="server" ID="Label5">Period</asp:Label>
                                        </td>
                                        <td style="border-style: none; text-align: left; width: 60%;">
                                            <asp:Label runat="server" ID="lblPeriod" class="blue"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
                <asp:DataList ID="dlGridDisplay" CssClass="table table-striped table-bordered table-hover"
                    runat="server" Width="100%" Visible="True">
                    <HeaderTemplate>
                        <b>Date</b> </th>
                        <th style="width: 20%; text-align: center;">
                            GRN No
                        </th>
                        <th style="width: 20%; text-align: center;">
                            Division
                        </th>
                        <th style="width: 20%; text-align: center;">
                            Item Return Center
                        </th>
                        <th style="width: 20%; text-align: center;">
                            Material code
                        </th>
                        <th style="width: 20%; text-align: center;">
                            Material Name
                        </th>
                          <th style="width: 20%; text-align: center;">
                            Vendor name
                        </th>
                        <th style="width: 10%; text-align: center;">
                             Qty
                        </th>
                        
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblMenuCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Date")%>' />
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="lblMenuName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"GRN_No")%>' />
                        </td>
                          <td style="text-align: left;">
                            <asp:Label ID="Label4" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Division")%>' />
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="Label8" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Item_ReturnCenter")%>' />
                        </td>
                          <td style="text-align: left;">
                            <asp:Label ID="Label6" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Item_Code")%>' />
                        </td>
                           <td style="text-align: left;">
                            <asp:Label ID="Label10" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Item_Name")%>' />
                        </td>
                          <td style="text-align: left;">
                            <asp:Label ID="Label9" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Vendor_Name")%>' />
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="lblmenutype" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Inward_Qty")%>' />
                        </td>
                    </ItemTemplate>
                </asp:DataList>
                <asp:DataList ID="DataList1" CssClass="table table-striped table-bordered table-hover"
                    runat="server" Width="100%" Visible="False">
                    <HeaderTemplate>
                        <b>Date</b> </th>
                        <th style="width: 40%; text-align: center;">
                            GRN No
                        </th>
                        <th style="width: 40%; text-align: center;">
                            Division
                        </th>
                        <th style="width: 70%; text-align: center;">
                            Item Return Center
                        </th>
                        <th style="width: 60%; text-align: center;">
                            Material code
                        </th>
                        <th style="width: 60%; text-align: center;">
                            Item Name
                        </th>
                          <th style="width: 60%; text-align: center;">
                            Vendor name
                        </th>
                        <th style="width: 10%; text-align: center;">
                             Qty
                        </th>
                       
                    </HeaderTemplate>
                    <ItemTemplate>
                               <asp:Label ID="lblMenuCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Date")%>' />
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="lblMenuName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"GRN_No")%>' />
                        </td>
                          <td style="text-align: left;">
                            <asp:Label ID="Label4" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Division")%>' />
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="Label8" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Item_ReturnCenter")%>' />
                        </td>
                          <td style="text-align: left;">
                            <asp:Label ID="Label6" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Item_Code")%>' />
                        </td>S
                           <td style="text-align: left;">
                            <asp:Label ID="Label10" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Item_Name")%>' />
                        </td>
                          <td style="text-align: left;">
                            <asp:Label ID="Label9" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Vendor_Name")%>' />
                        </td>
                         
                        <td style="text-align: left;">
                            <asp:Label ID="lblMenuCss" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Inward_Qty")%>' />
                        </td>
                     
                    </ItemTemplate>
                </asp:DataList>
                
            </div>
        </div>
    </div>
</asp:Content>

