<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeFile="ScrapDetail.aspx.cs" Inherits="ScrapDetail" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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

        function print() {
            window.onload = function () { window.print(); }
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
                    <asp:Label ID="lblHeader" runat="server" Text=""></asp:Label><span class="divider"></span></h4>
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
                        <h5>Search Options
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
                                                                <asp:Label ID="Label4" runat="server" CssClass="red">Location Type</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlTransferFR_SR" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Location Type" Width="215px" OnSelectedIndexChanged="ddlTransferFR_SR_SelectedIndexChanged" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                        runat="server" id="tblFr_Godown" visible="false">
                                                        <tr>
                                                            <td style="border-style: none; text-align: lef t; width: 40%;">
                                                                <asp:Label ID="Label5" runat="server" CssClass="red">Godown Name</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlgodownFR_SR" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Godown" Width="215px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                        runat="server" id="tblFr_Division" visible="false">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label7" runat="server" CssClass="red">Division Name</asp:Label>
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
                                                                <asp:Label ID="Label18" runat="server" CssClass="red">Function Name</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlFunctionFR_SR" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Function" Width="215px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%"
                                                        runat="server" id="tblFr_Center" visible="false">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label6" runat="server" CssClass="red">Center Name</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlCenterFR_SR" runat="server" CssClass="chzn-select" data-placeholder="Select Center"
                                                                    Width="215px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <%--<tr>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label8" runat="server" CssClass="red">Transfer To</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlTransferTO_SR" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Transfer To" Width="215px" OnSelectedIndexChanged="ddlTransferTO_SR_SelectedIndexChanged" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                        runat="server" id="tblTO_Godown" visible="false">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label9" runat="server" CssClass="red">Godown Name</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlgodownTO_SR" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Godown" Width="215px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                        runat="server" id="tblTO_Division" visible="false">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label16" runat="server" CssClass="red">Division Name</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlDivisionTO_SR" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Division" Width="215px" OnSelectedIndexChanged="ddlDivisionTO_SR_SelectedIndexChanged" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                        runat="server" id="tblTO_Function" visible="false">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label19" runat="server" CssClass="red">Function Name</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlFunctionTO_SR" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Function" Width="215px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%"
                                                        runat="server" id="tblTO_Center" visible="false">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label17" runat="server" CssClass="red">Center Name</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlCenterTO_SR" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Center" Width="215px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>--%>
                                            <tr>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label13" runat="server" CssClass="red">Period</asp:Label>
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
                                                    <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label58" runat="server">Challan No</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:TextBox ID="txtChallan_SR" runat="server" Text="" Width="205px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">&nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="widget-main alert-block alert-info" style="text-align: center;">
                                <!--Button Area -->
                                <asp:Button class="btn btn-app btn-warning  btn-mini radius-4" runat="server" Visible="false" ID="btnprintopt2"
                                    Text="Print" ToolTip="Print" ValidationGroup="UcValidateSearch" OnClick="btnprintopt2_Click" />
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
                                <td class="span10">Total No of Records:
                                    <asp:Label runat="server" ID="lbltotalcount" Text="0" />
                                </td>
                                <td style="text-align: right" class="span2">
                                    <asp:LinkButton runat="server" ID="HLExport" ToolTip="Export" class="btn-small btn-danger icon-2x icon-download-alt"
                                        Height="25px" OnClick="HLExport_Click" Visible="true" />
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
                                        Dispatch Code
                                    </th>
                                    <th>Dispatch Date
                                    </th>
                                    <th style="width: 35%; text-align: center;">Challan No
                                    </th>
                                    <th style="width: 35%; text-align: center;">Contact Person
                                    </th>
                                    <th style="width: 5%; text-align: center;">Material Count
                                    </th>
                                    <th style="text-align: center; width: 5%;">Total Qty
                                    </th>
                                    <th style="width: 5%; text-align: center;">Total Amount
                                    </th>
                                    <%-- <th runat="server" visible="false">
                                    
                                    </th>--%>
                                    <th style="width: 5%; text-align: center;">Action
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr class="odd gradeX">
                         <td>
                                <asp:Label ID="Label16" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Dispatch_Code")%>' />
                                 <span id="iconDL_Authorise" runat="server" visible='<%# Convert.ToString(DataBinder.Eval(Container.DataItem,"Is_Authorised")) == "1" ? true : false%>'
                                            class="btn btn-danger btn-mini tooltip-error" data-rel="tooltip" data-placement="right"
                                            title="Voucher Authorised"><i class="icon-lock"></i></span>
                            </td>
                            <td>
                                <asp:Label ID="lblMenuCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Dispatch_Date" ,"{0:dd MMM yyyy}" )%>' />
                            </td>
                            <td style="width: 20%; text-align: center;">
                                <asp:Label ID="lblMenuParentcode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Challan_No")%>' />
                            </td>
                            <td style="width: 22%; text-align: center;">
                                <asp:Label ID="Label37" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"ContactPerson")%>' />
                            </td>
                            <td style="width: 11%; text-align: center;">
                                <asp:Label ID="lblmenutype" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Total_Item_Count")%>' />
                            </td>
                            <td style="width: 11%; text-align: center;">
                                <asp:Label ID="Label2" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Total_Quantity")%>' />
                            </td>
                            <td style="width: 11%; text-align: center;">
                                <asp:Label ID="lblmenulink" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Total_Amount")%>' />
                                <%--   </td>
                                  <td style="text-align: center; " runat="server" visible="false">
                                <asp:Label ID="lbldispacthCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Dispatch_Code")%>' />
                            </td>--%>
                                <td style="width: 11%; text-align: center;">
                                    <div class="inline position-relative">
                                        <asp:LinkButton ID="lnkEdit" ToolTip="Edit" class="btn-small btn-primary icon-info-sign"
                                            CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Dispatch_Code")%>' runat="server"
                                            CommandName="comEdit" Height="25px" />
                                        <asp:LinkButton runat="server" ID="btnPrint" ToolTip="Print" class="btn-small btn-warning icon-2x icon-print"
                                            CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Dispatch_Code")%>' Height="25px"
                                            CommandName="print"
                                            Visible='<%#(string)DataBinder.Eval(Container.DataItem,"Is_visible") =="1" ? true : false%>' />
                                        <%--    <div class="btn-group" id="Div20" runat="server">
                                                        <a id="aprint" runat="server" target="_blank" class="btn btn-small btn-primary tooltip-info">
                                                            <i class="icon-print"></i></a>
                                                    </div>--%>
                                       <asp:LinkButton ID="lnkAuthorise" ToolTip="Authorise" class="btn-small btn-warning  icon-lock"
                                            CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Dispatch_Code")%>' runat="server"
                                            CommandName="comAuthorise" Height="25px" />
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
                        <b>Dispatch Date</b> </th>
                        <th style="width: 20%; text-align: center;">Challan No
                        </th>
                        <th style="width: 20%; text-align: center;">Contact Person
                        </th>
                        <th style="width: 20%; text-align: center;">Material Count
                        </th>
                        <th style="text-align: center; width: 20%;">Total Qty
                        </th>
                        <th style="width: 20%; text-align: center;">
                        Total Amount
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblMenuCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Dispatch_Date")%>' />
                        </td>
                        <td style="width: 10%; text-align: center;">
                            <asp:Label ID="lblMenuParentcode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Challan_No")%>' />
                        </td>
                        <td style="width: 10%; text-align: center;">
                            <asp:Label ID="Label37" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"ContactPerson")%>' />
                        </td>
                        <td style="text-align: center;">
                            <asp:Label ID="lblmenutype" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Total_Item_Count")%>' />
                        </td>
                        <td style="text-align: center;">
                            <asp:Label ID="Label2" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Total_Quantity")%>' />
                        </td>
                        <td style="text-align: center;">
                            <asp:Label ID="lblmenulink" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Total_Amount")%>' />
                        </td>
                    </ItemTemplate>
                </asp:DataList>
            </div>

            <div id="DivAuthorise" runat="server" visible="false">
                <div class="widget-box">
                    <div class="widget-header widget-header-small header-color-dark">
                        <h5 class="modal-title">
                            Item Faulty Authorisation
                            <asp:Label runat="server" ID="lblAuthPkey" Visible="false"></asp:Label>
                             <asp:Label runat="server" ID="lblAuthorised" Visible="false"></asp:Label>
                             <asp:Label runat="server" ID="lblResultId" Visible="false"></asp:Label>
                              <asp:Label runat="server" ID="lbla" Visible="false"></asp:Label>
                        </h5>
                    </div>
                    <div class="widget-body">
                        <div class="widget-body-inner">
                            <div class="widget-main">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                      
                                        <div class="widget-main ">
                                            <table cellpadding="3" class="table table-striped table-bordered table-condensed">
                                                <tr>
                                                    <td class="span4" style="text-align: left">
                                                        <table cellpadding="0" class="table-hover" style="border-style: none; width: 100%;">
                                                            <tr>
                                                                <td style="border-style: none; text-align: left; width: 40%;">
                                                                    <asp:Label ID="Label16" runat="server">Location Type</asp:Label>
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
                                                                    <asp:Label ID="Label17" runat="server">Location</asp:Label>
                                                                </td>
                                                                <td style="border-style: none; text-align: left; width: 60%;">
                                                                    <asp:Label runat="server" ID="lbllocation_Auth" Text="" CssClass="blue" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    
                                                </tr>
                                                
                                            </table>
                                            <asp:DataList ID="dlItemListAuthorise" CssClass="table table-striped table-bordered table-hover"
                                                runat="server" Width="100%" 
                   >
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="chkAttendanceAll" runat="server" AutoPostBack="True" OnCheckedChanged="chkAttendanceAll_CheckedChanged" />
                                                    <span class="lbl"></span></th>
                                                    <th style="width: 10%; text-align: center;">
                                                        Material Code
                                                    </th>
                                                    <th style="width: 10%; text-align: center;">
                                                        Dispatch Entry Code
                                                    </th>
                                                    <th style="width: 30%; text-align: center;">
                                                        Material Name
                                                    </th>
                                                    <th style="width: 15%; text-align: center;">
                                                        Qty
                                                    </th>
                                                    <th style="width: 20%; text-align: center;">
                                                        Asset No
                                                    </th>
                                                    <th style="width: 10%; text-align: center;">
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkCheck" runat="server" AutoPostBack="true" Visible='<%#(string)DataBinder.Eval(Container.DataItem,"Is_Authorised") == "1" ? false : true%>' />
                                                    <span class="lbl"></span></td>
                                                    <td style="width: 20%; text-align: center;">
                                                        <asp:Label ID="lblItem_Code_DT" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Item_Code")%>' />
                                                        
                                                    </td>
                                                    <td style="width: 20%; text-align: center;">
                                                        <asp:Label ID="lblDispatchEntry_Code" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"DispatchEntry_Code")%>' />
                                                         <asp:Label ID="lblDispatch_code" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Dispatch_code" )%>' Visible="false" />
                                                    </td>
                                                    <td style="width: 20%; text-align: center;">
                                                        <asp:Label ID="lblMaterialName_DT" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"Item_Name")%>' />
                                                    </td>
                                                    <td style="width: 10%; text-align: center;">
                                                        <asp:Label ID="lblChallanQty_DT" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"Dispatch_Qty")%>' />
                                                    </td>
                                                    <td style="width: 15%; text-align: center;">
                                                        <asp:Label ID="lblBarcode_DT" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"Asset_No")%>' />
                                                         <asp:Label ID="lblitem_EAN_NO" runat="server" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem,"Barcode")%>' />
                                                    </td>
                                                    <td style="width: 10%; text-align: center;">
                                                        <asp:LinkButton ID="lnkDLAuthorise" ToolTip="Authorise" class="btn-small btn-warning  icon-lock"
                                                            runat="server" CommandName="Details" Height="25px" Visible='<%#(string)DataBinder.Eval(Container.DataItem,"Is_Acknowledged") == "1" ? true : false%>' />
                                                        <a id="lbl_DLError" runat="server" title="Error" data-rel="tooltip" href="#">
                                                            <asp:Panel ID="icon_Error" runat="server" class="badge badge-important" Visible="false">
                                                                <i class="icon-bolt"></i>
                                                            </asp:Panel>
                                                        </a>
                                                        <asp:Label ID="lblSuccess" runat="server" Text='Success' CssClass='green' Visible="false" />
                                                </ItemTemplate>
                                            </asp:DataList>
                                        </div>
                                        </div> </div> </div> </div>
                                        <br />
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="dlQuestion" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="widget-main alert-block alert-success  alert- " style="text-align: center;">
                            <!--Button Area -->
                            <asp:Label runat="server" ID="Label53" Text="" ForeColor="Red" />
                            <asp:Button class="btn btn-app btn-success btn-mini radius-4" ID="btnAuthorise" runat="server"
                                Text="Authorise" ValidationGroup="UcValidate" Width="80px" 
                                onclick="btnAuthorise_Click" />
                            <asp:Button class="btn btn-app btn-primary btn-mini radius-4" ID="btnCloseAuthorise"
                                Visible="true" Width="80px" runat="server" Text="Close" 
                                onclick="btnCloseAuthorise_Click" />
                            <asp:ValidationSummary ID="ValidationSummary4" ShowSummary="false" DisplayMode="List"
                                ShowMessageBox="true" ValidationGroup="UcValidate" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
            <div id="DivAddPanel" runat="server" visible="false">
                <div class="widget-box">
                    <div class="widget-header widget-header-small header-color-dark">
                        <h5 class="modal-title">Scrap Details
                            <asp:Label runat="server" ID="lblPkey" Visible="false"></asp:Label>
                            <asp:Label runat="server" ID="lblCodeRemove" Visible="false"></asp:Label>
                            <asp:Label runat="server" ID="lblSearchAddItem" Visible="false"></asp:Label>
                        </h5>
                    </div>
                    <div class="widget-body">
                        <div class="widget-body-inner">
                            <div class="widget-main">
                                <asp:UpdatePanel ID="UpdatePanelAdd" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <table cellpadding="3" class="table table-striped table-bordered table-condensed">
                                            <tr>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label1" runat="server" CssClass="red">Location Type</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlTransferFR_Add" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Location Type" Width="215px" OnSelectedIndexChanged="ddlTransferFR_Add_SelectedIndexChanged" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                        runat="server" id="tblFR_Godown_Add" visible="false">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label3" runat="server" CssClass="red">Godown Name</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlGodownFR_Add" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Godown" Width="215px" OnSelectedIndexChanged="ddlGodownFR_Add_SelectedIndexChanged" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                        runat="server" id="tblFR_Division_Add" visible="false">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label20" runat="server" CssClass="red">Division Name</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlDivisionFR_Add" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Division" Width="215px" OnSelectedIndexChanged="ddlDivisionFR_Add_SelectedIndexChanged" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                        runat="server" id="tblFR_Function_Add" visible="false">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label21" runat="server" CssClass="red">Function Name</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlFunctionFR_Add" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Function" Width="215px" OnSelectedIndexChanged="ddlFunctionFR_Add_SelectedIndexChanged" />
                                                            </td>
                                                        </tr>
                                                    </table>                                                    
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%"
                                                        runat="server" id="tblFR_Center_Add" visible="false">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label22" runat="server" CssClass="red">Center Name</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlCenterFR_Add" runat="server" CssClass="chzn-select" data-placeholder="Select Center"
                                                                    Width="215px" OnSelectedIndexChanged="ddlCenterFR_Add_SelectedIndexChanged" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    
                                                </td>
                                            </tr>
                                            <%--<tr>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label23" runat="server" CssClass="red">Transfer To</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlTransferTO_Add" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Transfer To" Width="215px" OnSelectedIndexChanged="ddlTransferTO_Add_SelectedIndexChanged" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                        runat="server" id="tblTO_Godown_Add" visible="false">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label24" runat="server" CssClass="red">Godown Name</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlGodownTO_Add" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Godown" Width="215px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                        runat="server" id="tblTO_Division_Add" visible="false">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label25" runat="server" CssClass="red">Division Name</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlDivisionTO_Add" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Division" Width="215px" OnSelectedIndexChanged="ddlDivisionTO_Add_SelectedIndexChanged" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                        runat="server" id="tblTO_Function_Add" visible="false">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label26" runat="server" CssClass="red">Function Name</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlFunctionTO_Add" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Function" Width="215px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                        runat="server" id="tblFr_Vendor_Add" visible="false">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label44" runat="server" CssClass="red">Vendor</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlVendorAdd" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Vendor" Width="215px" OnSelectedIndexChanged="ddlVendorAdd_SelectedIndexChanged"/>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%"
                                                        runat="server" id="tblTO_Center_Add" visible="false">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label27" runat="server" CssClass="red">Center Name</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlCenterTO_Add" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Center" Width="215px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%"
                                                        runat="server" id="tblVendor_Other_Add" visible="false">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label45" runat="server" CssClass="red">Vendor Name</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:TextBox ID="txtVendorNameAdd" runat="server" Text="" Width="205px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>--%>
                                            
                                            <tr>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label28" runat="server" CssClass="red">Challan No</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:TextBox ID="txtChallanNo_Add" runat="server" Enabled="False" Text="" Width="205px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label29" runat="server">Challan Date</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:TextBox ID="txtChallanDate_Add" runat="server" Enabled="False" Text="" Width="205px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label32" runat="server" CssClass="red">Contact Person</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:TextBox ID="txtContactPerson_Add" runat="server" Text="" Width="205px"></asp:TextBox>
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
                                                                <asp:Label ID="Label8" runat="server" >Vendor Name</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:TextBox ID="txtVendor" runat="server" Text="" Width="205px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label30" runat="server">Contact No.</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:TextBox ID="txtContact_Add" runat="server" Text="" Width="205px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label31" runat="server">Narration</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:TextBox ID="txtNarration" runat="server" Text="" Width="205px"></asp:TextBox>
                                                                 <asp:Label ID="Label9" runat="server" Text="" Visible="false"></asp:Label>
                                                            </td>
                                                              
                                                    <asp:Label ID="lblusertypeCode" runat="server" Text="" Visible="false"></asp:Label>
                                                
                                                        </tr>
                                                    </table>
                                                </td>
                                              
                                            </tr>
                                        </table>
                                        <div id="div_student" runat="server">
                                            <div class="widget-box">
                                                <div class="widget-header widget-header-small header-color-dark">
                                                    <h5>Manage Dispatch for Student
                                                    </h5>
                                                </div>
                                                <div class="widget-body">
                                                    <div class="widget-body-inner">
                                                        <div class="widget-main">
                                                            <asp:DataList ID="datalist_Student" CssClass="table table-striped table-bordered table-hover"
                                                                runat="server" Width="100%" Visible="True">
                                                                <HeaderTemplate>
                                                                    <asp:CheckBox ID="chkAttendanceAll" runat="server" AutoPostBack="True" OnCheckedChanged="chkAttendanceAll_CheckedChanged" />
                                                                    <span class="lbl"></span></th>
                                                                    <th style="width: 20%; text-align: center;">Student Name
                                                                    </th>
                                                                    <th style="width: 20%; text-align: center;">Net Fees
                                                                    </th>
                                                                    <th style="width: 20%; text-align: center;">Fees Received
                                                                    </th>
                                                                    <th style="width: 20%; text-align: center;">Cleared Amount
                                                                    </th>
                                                                    <th style="width: 20%; text-align: center;">Subject Group
                                                                    </th>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="chkCheck" runat="server" />
                                                                    <span class="lbl"></span></td>
                                                                    <td style="width: 12%; text-align: left;">
                                                                        <asp:Label ID="lblstudnNm" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"StudentName")%>' />
                                                                        <asp:Label ID="lblrequCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Request_Code")%>'
                                                                            Visible="false" />
                                                                        <asp:Label ID="Request_EntryCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Request_EntryCode")%>'
                                                                            Visible="false" />
                                                                    </td>
                                                                    <td style="width: 12%; text-align: center;">
                                                                        <asp:Label ID="lblnetfees" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"netFees")%>' />
                                                                    </td>
                                                                    <td style="width: 10%; text-align: center;">
                                                                        <asp:Label ID="lblfees" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"feesRecd")%>' />
                                                                    </td>
                                                                    <td style="text-align: center;">
                                                                        <asp:Label ID="lblclramt" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"ClearAmt")%>' />
                                                                    </td>
                                                                    <td style="text-align: left;">
                                                                        <asp:Label ID="lblsubgrp" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"SubjectGrp")%>' />
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
                                                <div class="widget-header widget-header-small header-color-dark">
                                                    <h5>Manage Dispatch for Teacher
                                                    </h5>
                                                </div>
                                                <div class="widget-body">
                                                    <div class="widget-body-inner">
                                                        <div class="widget-main">
                                                            <asp:DataList ID="datalist_Teacher" CssClass="table table-striped table-bordered table-hover"
                                                                runat="server" Width="100%" Visible="True">
                                                                <HeaderTemplate>
                                                                    <asp:CheckBox ID="chkTeachereAll" runat="server" AutoPostBack="True" OnCheckedChanged="chkTeachereAll_CheckedChanged" />
                                                                    <span class="lbl"></span></th>
                                                                    <th style="width: 22%; text-align: center;">Teacher Code
                                                                    </th>
                                                                    <th style="width: 22%; text-align: center;">Teacher Name
                                                                    </th>
                                                                    <th style="width: 25%; text-align: center;">Subject
                                                                    </th>
                                                                    <th style="width: 25%; text-align: center;">Short Name
                                                                    </th>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="chkCheck" runat="server" />
                                                                    <span class="lbl"></span></td>
                                                                    <td style="width: 12%; text-align: left;">
                                                                        <asp:Label ID="lblPartnerCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Partner_code")%>' />
                                                                        <asp:Label ID="lblrequCode_TH" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Request_Code")%>'
                                                                            Visible="false" />
                                                                        <asp:Label ID="Request_EntryCode_TH" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Request_EntryCode")%>'
                                                                            Visible="false" />
                                                                    </td>
                                                                    <td style="width: 12%; text-align: left;">
                                                                        <asp:Label ID="lblTeachername" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"PartnerName")%>' />
                                                                    </td>
                                                                    <td style="width: 10%; text-align: left;">
                                                                        <asp:Label ID="lblSubjName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"SubjectName")%>' />
                                                                    </td>
                                                                    <td style="text-align: left;">
                                                                        <asp:Label ID="lblShorNm" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"ShortName")%>' />
                                                                    </td>
                                                                </ItemTemplate>
                                                            </asp:DataList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div id="div_Employee" runat="server">
                                            <div class="widget-box">
                                                <div class="widget-header widget-header-small header-color-dark">
                                                    <h5>Manage Dispatch for Employee
                                                    </h5>
                                                </div>
                                                <div class="widget-body">
                                                    <div class="widget-body-inner">
                                                        <div class="widget-main">
                                                            <table cellpadding="2" class="table table-striped table-bordered table-condensed">
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
                                                            </table>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div id="DivForOP3" runat="server">
                                            <div class="widget-box">
                                                <div class="widget-header widget-header-small header-color-dark">
                                                    <h5>
                                                        <asp:Label ID="lblHeadingOP3" runat="server" Text=""></asp:Label>
                                                    </h5>
                                                </div>
                                                <div class="widget-body">
                                                    <div class="widget-body-inner">
                                                        <div class="widget-main">
                                                            <asp:DataList ID="DTOP3" CssClass="table table-striped table-bordered table-hover"
                                                                runat="server" Width="100%" Visible="True">
                                                                <HeaderTemplate>
                                                                    <asp:CheckBox ID="chkAttendanceAll" runat="server" AutoPostBack="True" OnCheckedChanged="chkAttendance_CheckedChanged" />
                                                                    <span class="lbl"></span></th>
                                                                    <th style="width: 10%; text-align: center;">ID
                                                                    </th>
                                                                    <th style="width: 22%; text-align: center;">Name
                                                                    </th>
                                                                    <th style="width: 10%; text-align: center;">Item Code
                                                                    </th>
                                                                    <th style="width: 25%; text-align: center;">Item Name
                                                                    </th>
                                                                    <th style="width: 10%; text-align: center;">EAN No.
                                                                    </th>
                                                                    <th style="width: 10%; text-align: center;">Asset No.
                                                                    </th>
                                                                    <th style="width: 8%; text-align: center;">Qty
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
                                                                        <asp:Label ID="lblDispatchEntry_Code_Grid" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"DispatchEntry_Code")%>'
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
                                                                        <asp:Label ID="lblEANNo_DT" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Item_EAN_No")%>' />
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
                                        <div class="row-fluid" runat="server" id="ItemDivs">
                                            <div class="span4">
                                                <div class="widget-box">
                                                    <div class="widget-header">
                                                        <h5 class="smaller">Item Details
                                                        </h5>
                                                    </div>
                                                    <div class="widget-body">
                                                        <div class="widget-main">
                                                            <table cellpadding="0" style="width: 100%;" class="table table-striped table-bordered table-condensed">
                                                                <tr>
                                                                    <td class="span4" style="text-align: left;" colspan="3">
                                                                        <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover">
                                                                            <tr>
                                                                                <td style="border-style: none; text-align: left; width: 25%;">
                                                                                    <asp:Label ID="Label33" runat="server" CssClass="red">Material Code</asp:Label>
                                                                                    <span class="help-button ace-popover" data-trigger="hover" data-placement="right"
                                                                                        data-content="Enter Material name/ Material Code/ Barcode/ Serial No." title="Help">?</span>
                                                                                </td>
                                                                                <td style="border-style: none; text-align: left; width: 65%;">
                                                                                    <asp:TextBox ID="txtItemMatCode" runat="server" Text="" placeholder="Search Material....."
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
                                                                                    <asp:Label ID="Label11" runat="server">Material Code</asp:Label>
                                                                                </td>
                                                                                <td style="border-style: none; text-align: left; width: 65%;">
                                                                                    <asp:Label ID="lblMateCode" runat="server" Text=""></asp:Label>
                                                                                    <asp:Label ID="lblInwardEntry_Code" runat="server" Text="" Visible="false"></asp:Label>
                                                                                    <asp:Label ID="lblCurrentQty" runat="server" Text="" Visible="false"></asp:Label>
                                                                                    <asp:Label ID="lblInward_Code" runat="server" Text="" Visible="false" />
                                                                                    <asp:Label ID="lblInward_Qty" runat="server" Text="" Visible="false" />
                                                                                    <asp:Label ID="lblRequestEntry_Code_Item" runat="server" Text="" Visible="false" />
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
                                                                    <td class="span4" style="text-align: left" colspan="3">
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
                                                                <tr runat="server" id="tr2">
                                                                    <td class="span4" style="text-align: left" colspan="3">
                                                                        <table cellpadding="0" class="table-hover" style="border-style: none; width: 100%;">
                                                                            <tr>
                                                                                <td style="border-style: none; text-align: left; width: 35%;">
                                                                                    <asp:Label ID="Label60" runat="server" CssClass="red">Quantity</asp:Label>
                                                                                </td>
                                                                                <td style="border-style: none; text-align: left; width: 65%;">
                                                                                    <asp:TextBox ID="txtItemQty" runat="server" Text="" Width="150px" OnTextChanged="txtItemQty_TextChanged"
                                                                                        AutoPostBack="True"></asp:TextBox>
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
                                                                                    <%--<asp:Label ID="lblCalValue" runat="server">0</asp:Label>--%>
                                                                                    <asp:Label ID="lblCalValue" runat="server" onkeypress="return NumberOnly(event);"
                                                                                        Width="160px">0</asp:Label>
                                                                                    <button class="btn btn-info btn-mini radius-4" id="btnSaveItem" runat="server" style="height: 28px"
                                                                                        validationgroup="UcValidate" title="Add Item Qty " onserverclick="btnSaveItem_ServerClick"
                                                                                        type="button">
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
                                            <div class="span8">
                                                <div class="widget-box">
                                                    <div class="widget-header">
                                                        <h5 class="smaller">Material List
                                                        </h5>
                                                    </div>
                                                    <div class="widget-body">
                                                        <div class="widget-main">
                                                            <asp:DataList ID="dlQuestion" CssClass="table table-striped table-bordered table-hover"
                                                                runat="server" Width="99%" OnItemCommand="dlQuestion_ItemCommand">
                                                                <HeaderTemplate>
                                                                    <b>Sr.No </b></th>
                                                                    <th style="width: 10%; text-align: center;">Material Code
                                                                    </th>
                                                                    <th style="width: 20%; text-align: center;">Material Name
                                                                    </th>
                                                                    <th style="width: 15%; text-align: center;">EAN No.
                                                                    </th>
                                                                    <th style="width: 15%; text-align: center;">Asset No.
                                                                    </th>
                                                                    <th style="width: 5%; text-align: center;">Qty
                                                                    </th>
                                                                    <th style="width: 10%; text-align: center;">Unit Price
                                                                    </th>
                                                                    <th style="width: 10%; text-align: center;">Amount
                                                                    </th>
                                                                    <th style="width: 15%; text-align: center;">
                                                                    Remove Item
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
                                                                        <asp:Label ID="lblis_Acknowledged" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"is_Authorised")%>'
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
                                                                    <th style="width: 10%; text-align: center;">Material Code
                                                                    </th>
                                                                    <th style="width: 20%; text-align: center;">Material Name
                                                                    </th>
                                                                    <th style="width: 15%; text-align: center;">EAN No.
                                                                    </th>
                                                                    <th style="width: 15%; text-align: center;">Asset No.
                                                                    </th>
                                                                    <th style="width: 5%; text-align: center;">Qty
                                                                    </th>
                                                                    <th style="width: 10%; text-align: center;">Unit Price
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
                                                                        <asp:Label ID="lblis_Acknowledged" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"is_Authorised")%>'
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
                                                                        <asp:Label runat="server" ID="lblTotalItem" Text="0"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <b>Total Qty : </b>
                                                                        <asp:Label runat="server" ID="lblTotal_Quantity" Text="0"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <b>Total Amount :</b>
                                                                        <asp:Label runat="server" ID="lblTotal_Amount" Text="0"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row-fluid">
                                            <div class="span12">
                                                <div class="widget-box">
                                                    <div class="widget-header">
                                                        <h5 class="smaller">Logistic Details
                                                        </h5>
                                                    </div>
                                                    <div class="widget-body">
                                                        <div class="widget-body-inner">
                                                            <div class="widget-main">
                                                                <table cellpadding="3" class="table table-striped table-bordered table-condensed">
                                                                    <tr>
                                                                        <td class="span6" style="text-align: left">
                                                                            <table cellpadding="0" class="table-hover" style="border-style: none; width: 100%;">
                                                                                <tr>
                                                                                    <td style="border-style: none; text-align: left; width: 40%;">
                                                                                        <asp:Label ID="Label12" runat="server" CssClass="red">Logistic Type</asp:Label>
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
                                                                                        <asp:Label ID="Label34" runat="server" CssClass="red">Logistic Details</asp:Label>
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
                                                                                        <asp:Label ID="Label35" runat="server">POD No.</asp:Label>
                                                                                    </td>
                                                                                    <td style="border-style: none; text-align: left; width: 60%;">
                                                                                        <asp:TextBox ID="txtPODNo_Add0" runat="server" Text="" Width="205px"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                            <table id="tblVehNo" runat="server" cellpadding="0" class="table-hover" style="border-style: none; width: 100%;"
                                                                                visible="false">
                                                                                <tr>
                                                                                    <td style="border-style: none; text-align: left; width: 40%;">
                                                                                        <asp:Label ID="Label36" runat="server">Vehicle No.</asp:Label>
                                                                                    </td>
                                                                                    <td style="border-style: none; text-align: left; width: 60%;">
                                                                                        <asp:TextBox ID="txtVechicleNo_Add" runat="server" Text="" Width="205px"></asp:TextBox>
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
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="dlQuestion" />
                                        <asp:PostBackTrigger ControlID="btnSaveItem" />
                                        <asp:PostBackTrigger ControlID="btnSearchItem" />
                                    </Triggers>
                                </asp:UpdatePanel>
                                <div class="widget-main alert-block alert-success  alert- " style="text-align: center;">
                                    <!--Button Area -->
                                    <asp:Label runat="server" ID="lblErrorBatch" Text="" ForeColor="Red" />
                                    <asp:Button class="btn btn-app btn-success btn-mini radius-4" ID="btnPrint" runat="server"
                                        Text="Print" Visible="False" OnClick="btnPrint_Click" OnClientClick="SetTarget();" />
                                    <asp:Button class="btn btn-app btn-success btn-mini radius-4" ID="BtnSaveAdd" runat="server"
                                        Text="Save" ValidationGroup="UcValidate" OnClick="BtnSaveAdd_Click" />
                                    <asp:Button class="btn btn-app btn-success btn-mini radius-4" ID="BtnSaveEdit" runat="server"
                                        Text="Save" ValidationGroup="UcValidate" OnClick="BtnSaveEdit_Click" Visible="False" />
                                    <asp:Button class="btn btn-app btn-primary btn-mini radius-4" ID="BtnCloseAdd" Visible="true"
                                        runat="server" Text="Close" OnClick="BtnCloseAdd_Click" />
                                    <asp:ValidationSummary ID="ValidationSummary3" ShowSummary="false" DisplayMode="List"
                                        ShowMessageBox="true" ValidationGroup="UcValidate" runat="server" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <asp:UpdatePanel ID="updatepaneel_UserType" UpdateMode="Conditional" runat="server">
                <ContentTemplate>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <!--/row-->
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="modal fade" id="DivOverrid" style="left: 40% !important; top: 10% !important; display: none; width: 65%"
                role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                &times;</button>
                            <h4 class="modal-title">Select Item
                            </h4>
                        </div>
                        <div class="modal-body">
                            <!--Controls Area -->
                            <table cellpadding="0" style="border-style: none;" width="100%">
                                <tr>
                                    <td style="border-style: none; text-align: left; width: 90%;" colspan="3">
                                        <asp:DataList ID="DataList3" runat="server" CssClass="table table-striped table-bordered table-hover"
                                            Width="97%" OnItemCommand="DataList3_ItemCommand">
                                            <HeaderTemplate>
                                                <b>Item Code</b>
                                                <th>Item Name
                                                </th>
                                                <th align="left" style="width: 10%">Unit
                                                </th>
                                                <th align="left" style="width: 10%">Asset No
                                                </th>
                                                <th align="left" style="width: 10%">Qty
                                                </th>
                                                <th align="left" style="width: 10%">Unit Price
                                                </th>
                                                <th align="left" style="width: 10%">Total Amount
                                                </th>
                                                <th align="left" style="width: 10%">Status
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
                                                <td>
                                                    <asp:Label ID="Label38" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"Stringa")%>' />
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
    <div class="modal fade" id="DivConfirmation" style="left: 50% !important; top: 20% !important; display: none;"
        role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        &times;</button>
                    <h4 class="modal-title" style="color: #FF0000">Warning
                    </h4>
                </div>
                <div class="modal-body">
                    <!--Controls Area -->
                    <table cellpadding="0" style="border-style: none;" width="100%">
                        <tr>
                            <td style="border-style: none; text-align: left; width: 40%;">
                                <asp:Label runat="server" ID="Label39">Are you sure want to remove Material?</asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="modal-footer">
                    <!--Button Area -->
                    <asp:Label runat="server" ID="Label40" Text="" Visible="false" />
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
</asp:Content>
