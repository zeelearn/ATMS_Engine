<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="PO_Details.aspx.cs" Inherits="PO_Details" %>

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
    <div id="breadcrumbs" class="position-relative" style="height: 53px; top: 0px; left: 0px;">
        <ul class="breadcrumb" style="height: 15px">
            <li><i class="icon-home"></i><a href="Homepage.aspx">Home</a><span class="divider"><i
                class="icon-angle-right"></i></span></li>
            <li>
                <h4 class="blue">
                    GRN PO Report Details<span class="divider"></span></h4>
            </li>
        </ul>
        <div id="nav-search">
            <!-- /btn-group -->
        </div>
        <!--#nav-search-->
    </div>
    <div id="page-content" class="clearfix">
        <!--/page-header-->
        <div class="row-fluid">
            <div id="DivAddPanel" runat="server" visible="true">
                <div class="widget-box">
                    <div class="widget-header widget-header-small header-color-dark">
                        <h5 class="modal-title">
                            PO REport Details
                        </h5>
                    </div>
                    <div>
                        <div id="DivAuthorise" runat="server" visible="true">
                            <div class="widget-body">
                                <div class="widget-body-inner">
                                    <div class="widget-main">
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
                                                                                    <asp:Label ID="lblTransferFR_SR" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                    <td class="span6" style="text-align: left">
                                                                        <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                                            runat="server" id="tblFr_Godown" visible="false">
                                                                            <tr>
                                                                                <td class="span2" style="border-style: none; text-align: left; width: 40%;">
                                                                                    <asp:Label ID="lblGodownName" runat="server" CssClass="red">Godown Name</asp:Label>
                                                                                </td>
                                                                                <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                                                    <%--                 <asp:DropDownList ID="lblgodownFR_SR" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Godown" Width="215px" />--%>
                                                                                    <asp:Label ID="lblgodownFR_SR" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                        <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                                            runat="server" id="tblFr_Division" visible="false">
                                                                            <tr>
                                                                                <td class="span2" style="border-style: none; text-align: left; width: 40%;">
                                                                                    <asp:Label ID="lblDivision" runat="server" CssClass="red">Division Name</asp:Label>
                                                                                </td>
                                                                                <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                                                    <%--    <asp:DropDownList ID="ddlDivisionFR_SR" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Division" Width="215px" />--%>
                                                                                    <asp:Label ID="lblDivisionFR_SR" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                        <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                                            runat="server" id="tblFr_Function" visible="false">
                                                                            <tr>
                                                                                <td class="span2" style="border-style: none; text-align: left; width: 40%;">
                                                                                    <asp:Label ID="lblfunction" runat="server" CssClass="red">Function Name</asp:Label>
                                                                                </td>
                                                                                <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                                                    <%--    <asp:DropDownList ID="ddlFunctionFR_SR" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Function" Width="215px" />--%>
                                                                                    <asp:Label ID="lblFunctionFR_SR" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                    <td class="span6" style="text-align: left">
                                                                        <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%"
                                                                            runat="server" id="tblFr_Center" visible="false">
                                                                            <tr>
                                                                                <td class="span2" style="border-style: none; text-align: left; width: 40%;">
                                                                                    <asp:Label ID="lblCenterName" runat="server" CssClass="red">Center Name</asp:Label>
                                                                                </td>
                                                                                <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                                                    <%--<asp:DropDownList ID="ddlCenterFR_SR" runat="server" CssClass="chzn-select" data-placeholder="Select Center"
                                                                    Width="215px" />--%>
                                                                                    <asp:Label ID="lblCenterFR_SR" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="span6" style="text-align: left">
                                                                        <table cellpadding="0" class="table-hover" style="border-style: none; width: 100%;">
                                                                            <tr>
                                                                                <td style="border-style: none; text-align: left; width: 40%;">
                                                                                    <asp:Label ID="Label25" runat="server" CssClass="red">Budget Division</asp:Label>
                                                                                </td>
                                                                                <td style="border-style: none; text-align: left; width: 60%;">
                                                                                    <%--   <asp:DropDownList ID="ddlbudgetDivision" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Division" 
                                                                    Width="215px" />--%>
                                                                                    <asp:Label ID="lblbudgetDivision" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                    <td class="span6" style="text-align: left">
                                                                    </td>
                                                                    <td class="span6" style="text-align: left">
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
                                                                                    <asp:Label ID="lblPONo_Add" runat="server"></asp:Label>
                                                                                    <%--  <asp:ListItem>Select</asp:ListItem>
                                                                    <asp:ListItem>Yes</asp:ListItem>
                                                                    <asp:ListItem>No</asp:ListItem>
                                                                </asp:DropDownList>--%>
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
                                                                                    <asp:Label ID="lblPono" runat="server" CssClass="red">PO No.</asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                        <table id="SuppID" runat="server" cellpadding="0" class="table-hover" style="border-style: none;
                                                                            width: 100%;">
                                                                            <tr>
                                                                                <%--   <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label29" runat="server" CssClass="red">Supplier</asp:Label>
                                                            </td>--%>
                                                                                <%--  <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlSupplier_Add" runat="server" CssClass="chzn-select" Width="215px">
                                                                </asp:DropDownList>
                                                            </td>--%>
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
                                                                                    <asp:Label ID="lblDCNO" runat="server"></asp:Label>
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
                                                                                    <asp:Label ID="lblInvoiceNo_Add" runat="server"></asp:Label>
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
                                                                                    <asp:Label ID="lblInvoiceValue_Add" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <div class="row-fluid">
                                                                <div class="span4" runat="server" id="DivAddItem" visible="false">
                                                                    <div class="widget-box">
                                                                        <div class="widget-header">
                                                                            <h5 class="smaller">
                                                                                Item Details
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
                                                                                                    <td style="border-style: none; text-align: left; width: 35%;" class="span2">
                                                                                                        <asp:Label ID="Label12" runat="server" CssClass="red">Item Code</asp:Label>
                                                                                                        <span class="help-button ace-popover" data-trigger="hover" data-placement="right"
                                                                                                            data-content="Enter Material name/ Material Code/ Barcode/ Serial No." title="Help">
                                                                                                            ?</span>
                                                                                                    </td>
                                                                                                    <td style="border-style: none; text-align: left; width: 65%;" class="span4">
                                                                                                        <asp:TextBox ID="txtItemMatCode" runat="server" Text="" Width="150px"></asp:TextBox><%--<button class="btn btn-info btn-small" runat ="server" id="Button2" onserverclick ="btnSearchItem_Click"><i class="icon-search"></i></button>--%>
                                                                                                        <button class="btn btn-info btn-small" runat="server" id="Button2" style="height: 30px">
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
                                                                                                        <asp:Label ID="Label7" runat="server" CssClass="red">Select Item</asp:Label>
                                                                                                    </td>
                                                                                                    <td style="border-style: none; text-align: left; width: 65%;" class="span4">
                                                                                                        <asp:DropDownList ID="ddlPOItems_Add" runat="server" CssClass="chzn-select" Width="165px"
                                                                                                            AutoPostBack="True">
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
                                                                                                        <asp:Label ID="Label11" runat="server">Item Code</asp:Label>
                                                                                                    </td>
                                                                                                    <td style="border-style: none; text-align: left; width: 65%;">
                                                                                                        <asp:Label ID="lblMateCode" runat="server" Text=""></asp:Label>
                                                                                                        <asp:Label ID="lblAssetNoType" runat="server" Visible="False"></asp:Label>
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
                                                                                                        <asp:Label ID="Label14" runat="server">Item Name</asp:Label>
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
                                                                                                            Text="" Width="160px" AutoPostBack="True"></asp:TextBox>
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
                                                                                                            Width="160px"></asp:TextBox>
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
                                                                                                            Width="160px" ReadOnly="True">0</asp:TextBox>
                                                                                                        <button class="btn btn-info btn-small" runat="server" id="Button1" style="height: 30px"
                                                                                                            type="button">
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
                                                                <div class="span10" runat="server" id="GridMaterialList">
                                                                    <div class="widget-box">
                                                                        <div class="widget-header">
                                                                            <h5 class="smaller">
                                                                                Item List
                                                                            </h5>
                                                                        </div>
                                                                        <div class="widget-body">
                                                                            <div class="widget-main ">
                                                                                <asp:DataList ID="dlQuestion" CssClass="table table-striped table-bordered table-hover"
                                                                                    runat="server" Width="100%">
                                                                                    <HeaderTemplate>
                                                                                        <center>
                                                                                            <b>Item Code</b>
                                                                                        </center>
                                                                                        </th>
                                                                                        <th style="width: 20%; text-align: center;">
                                                                                            Item Name
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
                                                                                        <%-- <th style="width: 12%; text-align: center;">--%>
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
                                                                                            <%--   </td>--%>
                                                                                            <%--       <td style="width: 12%; text-align: center;">--%>
                                                                                            <%--       <asp:LinkButton ID="lnkDLDelete" ToolTip="Remove" class="btn-small btn-danger icon-trash"
                                                                            runat="server" CommandName="ItemRemove" Height="25px" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"InwardEntry_Code")%>'
                                                                            Visible='<%#(string)DataBinder.Eval(Container.DataItem,"lblIs_Authorised") =="0" ? true : false%>' />&nbsp;
                                                                        <asp:LinkButton ID="lnkDLDetails" ToolTip="Details" class="btn-small btn-primary icon-credit-card"
                                                                            runat="server" CommandName="Details" Height="25px" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"InwardEntry_Code")%>'
                                                                            Visible='<%#(string)DataBinder.Eval(Container.DataItem,"AssetNoTypeBtn") =="1" ? true : false%>' />--%>
                                                                                            <%--     <asp:Label ID="lblbtnvisible" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"AssetNoTypeBtn")%>'
                                                                            Visible="false"></asp:Label>
                                                                        <asp:Label ID="lblIs_Authorised" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"lblIs_Authorised")%>'
                                                                            Visible="false"></asp:Label>--%>
                                                                                    </ItemTemplate>
                                                                                </asp:DataList>
                                                                                <asp:DataList ID="DataList4" CssClass="table table-striped table-bordered table-hover"
                                                                                    runat="server" Width="100%" Visible="false">
                                                                                    <HeaderTemplate>
                                                                                        <center>
                                                                                            <b>Item Code</b>
                                                                                        </center>
                                                                                        </th>
                                                                                        <th style="width: 30%; text-align: center;">
                                                                                            Item Name
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
                                                                                                Visible="true" AutoPostBack="true" value='<%#DataBinder.Eval(Container.DataItem,"lblChallanQty_DT")%>' />
                                                                                            <asp:Label ID="lblChallanQty_DT" runat="server" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem,"lblChallanQty_DT")%>' />
                                                                                        </td>
                                                                                        <td style="width: 10%; text-align: left;">
                                                                                            <asp:TextBox ID="txtRatePO_DT" runat="server" Text="" Width="85%" onkeypress="return NumberOnly()"
                                                                                                Visible="false" AutoPostBack="true" value='<%#DataBinder.Eval(Container.DataItem,"lblRatePO_DT")%>' />
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
                                                                                            <b>Total Item : </b>
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
                                                                                                        <asp:Label ID="lblLogisticType_Add" runat="server">Logistic Type</asp:Label>
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
                                                                                                        <asp:Label ID="lblLogisticDetails_Add" runat="server"></asp:Label>
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
                                                                                                            Text="Upload" ToolTip="Upload" ValidationGroup="UcValidateSearch" />
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
                                                            </div>
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:PostBackTrigger ControlID="dlQuestion" />
                                                            <asp:PostBackTrigger ControlID="btnUpload" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </div>
                                            </div>
                                            <div class="widget-main alert-block alert-success  alert- " style="text-align: center;">
                                                <!--Button Area -->
                                                <button class="btn btn-app btn-primary btn-mini radius-4" id="Button3" runat="server"
                                                    onclick="javascript:window.close()">
                                                    Close</button>
                                                <asp:ValidationSummary ID="ValidationSummary3" ShowSummary="false" DisplayMode="List"
                                                    ShowMessageBox="true" ValidationGroup="UcValidate" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
