<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeFile="Opening_Stock.aspx.cs" Inherits="Opening_Stock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

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

        function openModalDivConfirmation() {
            $('#DivConfirmation').modal({
                backdrop: 'static'
            })

            $('#DivConfirmation').modal('show');
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
                    Opening Stock<span class="divider"></span></h4>
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
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label13" runat="server" CssClass="red">Location Type</asp:Label>
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
                                                        runat="server" id="tblFr_GodownSearch" visible="false">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label22" runat="server" CssClass="red">Godown Name</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlgodownFR_SRSearch" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Godown" Width="215px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                        runat="server" id="tblFr_DivisionSearch" visible="false">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label23" runat="server" CssClass="red">Division Name</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlDivisionFR_SRSearch" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Division" Width="215px" OnSelectedIndexChanged="ddlDivisionFR_SRSearch_SelectedIndexChanged" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                        runat="server" id="tblFr_FunctionSearch" visible="false">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label24" runat="server" CssClass="red">Function Name</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlFunctionFR_SRSearch" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Function" Width="215px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%"
                                                        runat="server" id="tblFr_CenterSearch" visible="false">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label25" runat="server" CssClass="red">Center Name</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlCenterFR_SRSearch" runat="server" CssClass="chzn-select" data-placeholder="Select Center"
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
                                                                <asp:Label ID="Label8" runat="server">Transfer To</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlTransferTO_SR" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Transfer To" Width="215px" 
                                                                    onselectedindexchanged="ddlTransferTO_SR_SelectedIndexChanged" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover" runat="server" id="tblTO_Godown" visible ="false">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label9" runat="server">Godown</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlgodownTO_SR" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Godown" Width="215px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover" runat="server" id="tblTO_Division" visible ="false">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label16" runat="server">Division</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlDivisionTO_SR" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Division" Width="215px" 
                                                                    onselectedindexchanged="ddlDivisionTO_SR_SelectedIndexChanged" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                     <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                        runat="server" id="tblTO_Function" visible ="false">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label19" runat="server">Function</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlFunctionTO_SR" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Function" Width="215px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%" runat="server" id="tblTO_Center" visible ="false">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label17" runat="server">Center</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlCenterTO_SR" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Center" Width="215px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>--%>
                                            
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
                </table>
                </div>
<%--
                <asp:Repeater ID="dlGridDisplay" runat="server" OnItemCommand="dlGridDisplay_ItemCommand">
                    <HeaderTemplate>
                        <table class="table table-striped table-bordered table-hover Table2">
                            <thead>
                                <tr>
                                    <th>
                                        
                                    </th>
                                    <th style="width: 10%; text-align: center;">
                                        Inward Entry Code
                                    </th>                                    
                                    <th style="width: 10%; text-align: center;">
                                        Item Code
                                    </th>
                                    <th style="width: 30%; text-align: center;">
                                        Item Name
                                    </th>
                                    <th style="width: 15%; text-align: center;">
                                        Chalan Quantity
                                    </th>
                                    <th style="width: 20%; text-align: center;">
                                        EAN Number
                                    </th>
                                    <th style="width: 10%; text-align: center;">
                                        
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr class="odd gradeX">
                            <td>
                                <asp:CheckBox ID="chkCheck" runat="server" 
                                    AutoPostBack="true" Checked="false" Visible='<%#(string)DataBinder.Eval(Container.DataItem,"Is_Authorised") == "1" ? false : true%>' />
                                <span class="lbl"></span> 
                            </td>
                            <td>
                                <asp:Label ID="lblInwardEntryCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"InwardEntry_Code")%>' />
                            </td>
                            <td style="text-align: left;">
                                <asp:Label ID="lblItemCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"lblMaterialCode_DT")%>' />
                            </td>
                            <td style="text-align: left;">
                                <asp:Label ID="lblItemName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"lblMaterialName_DT")%>' />
                            </td>
                            <td style="text-align: left;">
                                <asp:Label ID="lblChalanQty" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"lblChallanQty_DT")%>' />
                            </td>
                            <td style="text-align: left;">
                                <asp:Label ID="lblBarcode_DT" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"lblBarcode_DT")%>' />
                                <asp:Label ID="lblAssetType" runat="server" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem,"AssetType")%>' />
                            </td>
                            <td style="text-align: center;">
                                <div class="inline position-relative">
                                    <asp:LinkButton ID="lnkEdit" ToolTip="Edit" class="btn-small btn-primary icon-info-sign"
                                        CommandArgument='<%#DataBinder.Eval(Container.DataItem,"InwardEntry_Code")%>' runat="server"
                                        CommandName="comEdit" Height="25px" />
                                    <asp:LinkButton ID="lnkAuthorise" ToolTip="Authorise" class="btn-small btn-warning  icon-lock"
                                        CommandArgument='<%#DataBinder.Eval(Container.DataItem,"InwardEntry_Code")%>' runat="server"
                                        CommandName="comAuthorise12" Height="25px" Visible='<%#(string)DataBinder.Eval(Container.DataItem,"Is_Authorised") == "1" ? true : false%>' />
                                </div>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody> </table>
                    </FooterTemplate>
                </asp:Repeater>--%>

                <asp:DataList ID="dlGridDisplay" CssClass="table table-striped table-bordered table-hover"
                    runat="server" Width="100%" >
                    <HeaderTemplate>
                        <b></b> </th>                                                            
                        <th style="width: 12%; text-align: center;">
                            Inward Entry Code
                        </th>                                    
                        <th style="width: 12%; text-align: center;">
                            Material Code
                        </th>
                        <th style="width: 30%; text-align: center;">
                            Material Name
                        </th>
                        <th style="width: 10%; text-align: center;">
                            Chalan Quantity
                        </th>
                        <th style="width: 20%; text-align: center;">
                            EAN Number
                        </th>
                        <th style="width: 10%; text-align: center;">

                    </HeaderTemplate>
                    <ItemTemplate>
                                <asp:CheckBox ID="chkCheck" runat="server"  Checked="false" 
                                    Visible='<%#(string)DataBinder.Eval(Container.DataItem,"Is_Authorised") == "1" ? false : true%>' />
                                <span class="lbl"></span> 
                            </td>
                            <td>
                                <asp:Label ID="lblInwardEntryCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"InwardEntry_Code")%>' />
                            </td>
                            <td style="text-align: left;">
                                <asp:Label ID="lblItemCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"lblMaterialCode_DT")%>' />
                            </td>
                            <td style="text-align: left;">
                                <asp:Label ID="lblItemName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"lblMaterialName_DT")%>' />
                            </td>
                            <td style="text-align: left;">
                                <asp:Label ID="lblChalanQty" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"lblChallanQty_DT")%>' />
                            </td>
                            <td style="text-align: left;">
                                <asp:Label ID="lblBarcode_DT" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"lblBarcode_DT")%>' />
                                <asp:Label ID="lblAssetType" runat="server" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem,"AssetType")%>' />
                            </td>
                            <td style="text-align: center;">
                                <div class="inline position-relative">
                                    <%--<asp:LinkButton ID="lnkEdit" ToolTip="Edit" class="btn-small btn-primary icon-info-sign"
                                        CommandArgument='<%#DataBinder.Eval(Container.DataItem,"InwardEntry_Code")%>' runat="server"
                                        CommandName="comEdit" Height="25px" />--%>
                                    <asp:LinkButton ID="lnkAuthorise" ToolTip="Authorise" class="btn-small btn-warning  icon-lock"
                                        CommandArgument='<%#DataBinder.Eval(Container.DataItem,"InwardEntry_Code")%>' runat="server"
                                        CommandName="comAuthorise12" Height="25px" Visible='<%#(string)DataBinder.Eval(Container.DataItem,"Is_Authorised") == "1" ? true : false%>' />
                                    <a id="lbl_DLError" runat="server" title="Error" data-rel="tooltip" href="#">
                                        <asp:Panel ID="icon_Error" runat="server" class="badge badge-important" Visible="false">
                                            <i class="icon-bolt"></i>
                                        </asp:Panel>
                                    </a>
                                        <asp:Label ID="lblSuccess" runat="server" Text='Success' CssClass='green'
                                        Visible="false" />
                                </div>
                            </td>
                    </ItemTemplate>
                </asp:DataList>

                <asp:DataList ID="DataList1" CssClass="table table-striped table-bordered table-hover"
                    runat="server" Width="100%" Visible="false">
                    <HeaderTemplate>
                        <b>Inward Entry Code</b> </th>                                                            
                        <th style="width: 10%; text-align: center;">
                            Material Code
                        </th>
                        <th style="width: 30%; text-align: center;">
                            Material Name
                        </th>
                        <th style="width: 15%; text-align: center;">
                            Chalan Quantity
                        </th>
                        <th style="width: 20%; text-align: center;">
                            EAN Number
                    </HeaderTemplate>
                    <ItemTemplate>
                                <asp:Label ID="lblInwardEntryCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"InwardEntry_Code")%>' />
                            </td>
                            <td style="text-align: left;">
                                <asp:Label ID="lblItemCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"lblMaterialCode_DT")%>' />
                            </td>
                            <td style="text-align: left;">
                                <asp:Label ID="lblItemName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"lblMaterialName_DT")%>' />
                            </td>
                            <td style="text-align: left;">
                                <asp:Label ID="lblChalanQty" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"lblChallanQty_DT")%>' />
                            </td>
                            <td style="text-align: left;">
                                <asp:Label ID="lblBarcode_DT" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"lblBarcode_DT")%>' />
                                <asp:Label ID="lblAssetType" runat="server" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem,"AssetType")%>' />
                            </td>
                    </ItemTemplate>
                </asp:DataList>

                <div class="widget-main alert-block alert-success  alert- " style="text-align: center;">
                    <!--Button Area -->
                    <asp:Label runat="server" ID="Label19" Text="" ForeColor="Red" />
                    <asp:Button class="btn btn-app btn-success btn-mini radius-4" 
                        ID="btnAllAuthorise" runat="server"
                        Text="Authorise" ValidationGroup="UcValidate" width="80px" 
                        onclick="btnAllAuthorise_Click"  />                    
                    <asp:ValidationSummary ID="ValidationSummary4" ShowSummary="false" DisplayMode="List"
                        ShowMessageBox="true" ValidationGroup="UcValidate" runat="server" />
                </div>
            </div>
            <div id="DivAddPanel" runat="server" visible="false">
                <div class="widget-box">
                    <div class="widget-header widget-header-small header-color-dark">
                        <h5 class="modal-title">
                            Opening Stock Details
                            <asp:Label runat="server" ID="lblPkey" Visible="false"></asp:Label>
                            <asp:Label runat="server" ID="lblInwardEntryCodeRemove" Visible="false"></asp:Label>
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
                                                                <asp:Label ID="Label8" runat="server">Location</asp:Label>
                                                            </td>
                                                            <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlTransferFR_SR" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Location Type" Width="215px" 
                                                                    onselectedindexchanged="ddlTransferFR_SR_SelectedIndexChanged" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                        runat="server" id="tblFr_Godown" visible="false">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label9" runat="server">Godown Name</asp:Label>
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
                                                                <asp:Label ID="Label10" runat="server">Division Name</asp:Label>
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
                                                                <asp:Label ID="Label18" runat="server">Function Name</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlFunctionFR_SR" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Function" Width="215px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span6" style="text-align: left">
                                                   <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%"
                                                        runat="server" id="tblFr_Center" visible ="false">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label16" runat="server">Center Name</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlCenterFR_SR" runat="server" CssClass="chzn-select"
                                                                    data-placeholder="Select Center" Width="215px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            </tr>
                                        </table>
                                        <div class="row-fluid">
                                            <div class="span4" runat="server" id="DivAddItem">
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
                                                                            runat="server" id="tbl_poNo">
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
                                                                                        style="height: 28px">
                                                                                        <i class="icon-search icon-on-right"></i>
                                                                                    </button>
                                                                                    <%--<asp:Button ID="Button2" runat="server" class="btn btn-purple btn-small icon-search"
                                                                                            OnClick="btnSearchItem_Click" Text="Search" />--%>
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
                                                                                    <asp:Label ID="Label26" runat="server">Budget Division</asp:Label>
                                                                                </td>
                                                                                <td style="border-style: none; text-align: left; width: 65%;">
                                                                                    <asp:DropDownList ID="ddlDivision" runat="server" CssClass="chzn-select"
                                                                                            data-placeholder="Select Division" Width="215px" />
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
                                                                                    <button class="btn btn-info btn-small" runat="server" id="Button1" onserverclick="btnSaveItem_ServerClick"
                                                                                        style="height: 30px; top: 1px; left: 0px;" type="button">
                                                                                        <i class="icon-plus"></i>
                                                                                    </button>
                                                                                    <br />
                                                                                    <asp:Label ID="lblItemPOQty" runat="server" Visible="False" Text="0"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <%--<tr>
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
                                                                </tr>--%>
                                                                <%--<tr>
                                                                    <td class="span6" style="text-align: left">
                                                                        <table cellpadding="0" class="table-hover" style="border-style: none; width: 100%;">
                                                                            <tr>
                                                                                <td style="border-style: none; text-align: left; width: 35%;">
                                                                                    <asp:Label ID="Label63" runat="server">Value</asp:Label>
                                                                                </td>
                                                                                <td style="border-style: none; text-align: left; width: 65%;">
                                                                                    
                                                                                    <asp:TextBox ID="lblCalValue" runat="server" onkeypress="return NumberOnly(event);"
                                                                                        Width="160px" ReadOnly="True">0</asp:TextBox>
                                                                                    
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>--%>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                        <%-- <div class="widget-main alert-block alert-success  alert- " style="text-align: center;">
                                                            <!--Button Area -->
                                                            <asp:Label runat="server" ID="Label10" Text="" ForeColor="Red" />
                                                            <asp:Button class="btn btn-app btn-success btn-mini radius-4" ID="btnSaveItem" runat="server"
                                                                Text="Add" ValidationGroup="UcValidate" OnClick="btnSaveItem_Click" />
                                                            <asp:Button class="btn btn-app btn-primary btn-mini radius-4" ID="btnClearItem" Visible="true"
                                                                runat="server" Text="Clear" OnClick="btnClearItem_Click" />
                                                            <asp:ValidationSummary ID="ValidationSummary1" ShowSummary="false" DisplayMode="List"
                                                                ShowMessageBox="true" ValidationGroup="UcValidate" runat="server" />
                                                        </div>--%>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="span8" runat="server" id="GridMaterialList">
                                                <div class="widget-box">
                                                    <div class="widget-header">
                                                        <h5 class="smaller">
                                                            Item List
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
                                                                    <th style="width: 40%; text-align: center;">
                                                                        Material Name
                                                                    </th>
                                                                    <%--<th style="width: 10%; text-align: center;">
                                                                        PO Qty
                                                                    </th>--%>
                                                                    <th style="width: 10%; text-align: center;">
                                                                        Challan Qty
                                                                    </th>
                                                                    <%--<th style="width: 10%; text-align: center;">
                                                                        Rate as per PO
                                                                    </th>
                                                                    <th style="width: 10%; text-align: center;">
                                                                        Value
                                                                    </th>--%>
                                                                    <th style="width: 15%; text-align: center;">
                                                                        EAN No.
                                                                    </th>
                                                                    <th style="width: 8%; text-align: center;">
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblMaterialCode_DT" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"lblMaterialCode_DT")%>' />
                                                                    <asp:Label ID="InwardEntry_Code" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"InwardEntry_Code")%>'
                                                                        Visible="false" />
                                                                    </td>
                                                                    <td style="width: 20%; text-align: left;">
                                                                        <asp:Label ID="lblMaterialName_DT" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"lblMaterialName_DT")%>' />
                                                                    </td>
                                                                    <%--<td style="width: 120px; text-align: left;">
                                                                        <asp:TextBox ID="txtPoQty_DT" runat="server" Text="" Width="85%" onkeypress="return NumberOnly()"
                                                                            Visible="false" />
                                                                        <asp:Label ID="lblPoQty_DT" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"lblPoQty_DT")%>' />
                                                                    </td>--%>
                                                                    <td style="width: 10%; text-align: left;">
                                                                        <asp:TextBox ID="txtChallanQty_DT" runat="server" Text="" Width="85%" onkeypress="return NumberOnly()"
                                                                            Visible="false" />
                                                                        <asp:Label ID="lblChallanQty_DT" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"lblChallanQty_DT")%>' />
                                                                    </td>
                                                                    <%--<td style="width: 10%; text-align: left;">
                                                                        <asp:TextBox ID="txtRatePO_DT" runat="server" Text="" Width="85%" onkeypress="return NumberOnly()"
                                                                            Visible="false" />
                                                                        <asp:Label ID="lblRatePO_DT" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"lblRatePO_DT")%>' />
                                                                    </td>
                                                                    <td style="width: 13%; text-align: left;">
                                                                        <asp:Label ID="lblValue_DT" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"lblValue_DT")%>' />
                                                                    </td>--%>
                                                                    <td style="width: 15%; text-align: left;">
                                                                        <asp:Label ID="lblBarcode_DT" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"lblBarcode_DT")%>' />
                                                                        <asp:Label ID="lblAssetType" runat="server" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem,"AssetType")%>' />
                                                                        <asp:Label ID="lblAuthoriseFlag" runat="server" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem,"Is_Authorised")%>' />
                                                                    </td>
                                                                    <td style="width: 12%; text-align: center;">
                                                                        <asp:LinkButton ID="lnkDLSave" ToolTip="Save" class="btn-small btn-success icon-save"
                                                                            runat="server" CommandName="Save" Height="25px" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"lblMaterialCode_DT")%>'
                                                                            Visible="False" />&nbsp;
                                                                        <asp:LinkButton ID="lnkDLDetails" ToolTip="Details" class="btn-small btn-primary icon-credit-card"
                                                                            runat="server" CommandName="Details" Height="25px" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"InwardEntry_Code")%>'
                                                                            Visible='<%#(string)DataBinder.Eval(Container.DataItem,"Is_Authorised") == "1" ? false : true%>' />
                                                                        <asp:LinkButton ID="lnkDLAuthorise" ToolTip="Details" class="btn-small btn-warning  icon-lock"
                                                                            runat="server" CommandName="Authorise" Height="25px" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"InwardEntry_Code")%>'
                                                                            Visible='<%#(string)DataBinder.Eval(Container.DataItem,"Is_Authorised") == "1" ? true : false%>' />
                                                                        <asp:LinkButton ID="lnkDLDelete" ToolTip="Remove" class="btn-small btn-danger icon-trash"
                                                                            runat="server" CommandName="ItemRemove" Height="25px" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"InwardEntry_Code")%>'
                                                                           Visible='<%#(string)DataBinder.Eval(Container.DataItem,"Is_Authorised") == "1" ? false : true%>' />&nbsp;
                                                                </ItemTemplate>
                                                            </asp:DataList>

                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <%--<div class="row-fluid">
                                            
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
                                                                <asp:Label ID="Label17" runat="server" CssClass="red">Logistic Type</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlLogisticType_Add" runat="server" AutoPostBack="True" 
                                                                    CssClass="chzn-select" data-placeholder="Select Godown" Width="215px" 
                                                                    onselectedindexchanged="ddlLogisticType_Add_SelectedIndexChanged" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" class="table-hover" style="border-style: none; width: 100%;">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label19" runat="server" CssClass="red">Logistic Details</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:TextBox ID="txtLogisticDetails_Add" runat="server" Text="" Width="205px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" class="table-hover" style="border-style: none; width: 100%;"
                                                        runat="server" id="tblPODNo" visible ="false">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label20" runat="server" CssClass="red">POD No.</asp:Label>
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
                                                                <asp:Label ID="Label21" runat="server" CssClass="red">Vehicle No.</asp:Label>
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
                                        </div>--%>
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
                            <asp:Label runat="server" ID="lblErrorBatch" Text="" ForeColor="Red" />
                            <asp:Button class="btn btn-app btn-success btn-mini radius-4" ID="BtnSaveAdd" runat="server"
                                Text="Save" ValidationGroup="UcValidate" OnClick="BtnSaveAdd_Click" />
                            <%-- <asp:Label ID="lblDLMaterial_Code" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"Item_Id")%>' />--%>
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
                            Item Details
                                      <asp:Label runat="server" ID="lblInwardCode_BR" Visible="false"></asp:Label>
                                      <asp:Label runat="server" ID="lblBudget_Division" Visible="false"></asp:Label>
                            <asp:Label runat="server" ID="lblInwardEbtryCode_BR" Visible="false"></asp:Label>
                        </h5>
                    </div>
                    <div class="widget-body">
                        <div class="widget-body-inner">
                            <div class="widget-main">
                                <asp:UpdatePanel ID="UpdatePanel12" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <table cellpadding="3" class="table table-striped table-bordered table-condensed">
                                            <tr>
                                                <td class="span4">
                                                    <table cellpadding="0" class="table-hover" style="border-style: none; width: 80%;">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label66" runat="server">Item Name</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:TextBox ID="txtItemName_BR" runat="server" Text="" Width="205px" Enabled="false"></asp:TextBox>
                                                                <%--<button runat ="server" id="btnSearchItem" class="btn btn-purple btn-small" onclick ="btnSearchItem_Click" >
                                                                                                        Search <i class="icon-search icon-on-right"></i>
                                                                                                    </button>--%>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4">
                                                    <table cellpadding="0" class="table-hover" style="border-style: none; width: 100%;">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <%--<asp:Label ID="Label67" runat="server">Serial Type</asp:Label>--%>
                                                                <asp:Label ID="lblItemType" runat="server" Visible="false"></asp:Label>
                                                                <asp:Label ID="lblEANNo" runat="server" Visible="false"></asp:Label>
                                                                <asp:Label ID="lblChalanQty" runat="server" Visible="false"></asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <%--<asp:RadioButton ID="RadioButton1" runat="server" GroupName="SerialType" AutoPostBack="True"
                                                                    OnCheckedChanged="RadioButton1_CheckedChanged" />
                                                                <span class="lbl">
                                                                    <asp:Label ID="Label3" runat="server" Text=" Common Serial No"></asp:Label></span>
                                                                <br />
                                                                <asp:RadioButton ID="RadioButton2" runat="server" GroupName="SerialType" OnCheckedChanged="RadioButton2_CheckedChanged"
                                                                    AutoPostBack="True" />
                                                                <span class="lbl">
                                                                    <asp:Label ID="Label1" runat="server" Text=" Same Serial No & Barcode No"></asp:Label></span>--%>
                                                            </td>
                                                        </tr>
                                                    </table>
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
                                                <th style="width: 10%; text-align: center;">
                                                    Material Serial No
                                                </th>
                                                <th style="width: 10%; text-align: center;">
                                                     SAP Asset No   
                                                </th>
                                                   <th style="width: 10%; text-align: center;">
                                                     Material Barcode No
                                                </th>
                                                <th style="width: 10%; text-align: center;">
                                                    Purchase Rate
                                                </th>
                                                <th style="width: 10%; text-align: center;">
                                                    Purchase Date
                                                </th>
                                                <th style="width: 10%; text-align: center;">
                                                    PO Number
                                                </th>
                                                <th style="width: 10%; text-align: center;">
                                                    Current Value
                                                </th>
                                                <th style="width: 10%; text-align: center;">
                                                    Status
                                                </th>
                                                <th style="width: 10%; text-align: center;">
                                                    Condition
                                                </th>
                                                <th style="width: 10%; text-align: left;">
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <center>
                                                    <asp:Label ID="lblSRNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"lblSRNo")%>'></asp:Label>
                                                </center>
                                                </td>
                                                <td style="width: 10%; text-align: center;">
                                                    <asp:TextBox ID="txtItemSerialNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"txtItemSerialNo")%>'
                                                        Width="90%"></asp:TextBox>
                                                </td>
                                                  <td style="width: 10%; text-align: center;">
                                                    <asp:TextBox ID="txtAssetNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"txtAssetNo")%>'
                                                        Width="90%"></asp:TextBox>
                                                </td>
                                                <td style="width: 10%; text-align: center;">
                                                    <asp:TextBox ID="txtItemBarcodeNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"txtItemBarcodeNo")%>'
                                                        Width="90%" onkeypress="return ValidateEnterKey(event);"></asp:TextBox>
                                                </td>
                                                <td style="width: 10%; text-align: center;">
                                                    <asp:TextBox ID="txtPurchaseRate" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Purchase_Rate")%>'
                                                        Width="90%" onkeypress="return ValidateEnterKey(event);" 
                                                        AutoPostBack="True"></asp:TextBox>
                                                </td>
                                                <td style="width: 10%; text-align: center;">
                                                    <%--<asp:TextBox ID="txtPurchaseDate" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"txtItemBarcodeNo")%>'
                                                        Width="95%"></asp:TextBox>--%>
                                                         <input   type="text" readonly="readonly" class="span8 date-picker" id="txtPurchaseDate" runat="server" 
                                                                 data-date-format="dd M yyyy" style="width:90%" value='<%#DataBinder.Eval(Container.DataItem,"PurchaseDate")%>' />
                                                </td>
                                                <td style="width: 10%; text-align: center;">
                                                    <asp:TextBox ID="txtPONumber" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"PONumber")%>'
                                                        Width="90%"></asp:TextBox>
                                                </td>
                                                <td style="width: 10%; text-align: center;">
                                                    <asp:TextBox ID="txtCurrentValue" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Current_Value")%>'
                                                        Width="90%"></asp:TextBox>
                                                </td>
                                                <td style="width: 10%;">
                                                    <asp:DropDownList ID="ddlStatus" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Status" Width="10%" />
                                                    <asp:Label ID="lblStatusId"  Visible="false" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Asset_Status_Id")%>' />
                                                </td>
                                                <td style="width: 10%;">
                                                    <asp:DropDownList ID="ddlCondition" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Condition" Width="10%"  />
                                                    <asp:Label ID="lblConditionId" runat="server"  Visible="false" Text='<%#DataBinder.Eval(Container.DataItem,"ConditionId")%>' />
                                                </td>
                                                <td style="width: 10%; text-align: center;">
                                                    <asp:Label ID="lblResult" runat="server" Text="" />
                                            </ItemTemplate>
                                        </asp:DataList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
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
                            Opening Stock Authorisation
                            <asp:Label runat="server" ID="Label1" Visible="false"></asp:Label>
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
                                                    <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                        <tr>
                                                            <td class="span2" style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label2" runat="server">Location</asp:Label>
                                                            </td>
                                                            <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlTransferFR_SRAuthorise" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Location Type" Width="215px" Enabled="false"
                                                                    onselectedindexchanged="ddlTransferFR_SRAuthorise_SelectedIndexChanged" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                        runat="server" id="tblFr_GodownAuthorise" visible="false">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label3" runat="server">Godown</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlgodownFR_SRAuthorise" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Godown" Width="215px" Enabled="false"/>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                        runat="server" id="tblFr_DivisionAuthorise" visible="false">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label4" runat="server">Division</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlDivisionFR_SRAuthorise" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Division" Width="215px" Enabled="false" OnSelectedIndexChanged="ddlDivisionFR_SRAuthorise_SelectedIndexChanged" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                        runat="server" id="tblFr_FunctionAuthorise" visible="false">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label5" runat="server">Function</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlFunctionFR_SRAuthorise" Enabled="false" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Function" Width="215px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span6" style="text-align: left">
                                                   <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%"
                                                        runat="server" id="tblFr_CenterAuthorise" visible ="false">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label6" runat="server">Center</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlCenterFR_SRAuthorise" runat="server" CssClass="chzn-select"
                                                                    data-placeholder="Select Center" Width="215px" Enabled="false"/>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            </tr>
                                        </table>
                                        <div class="row-fluid">
                                            <div class="span12" runat="server" id="DivAuthoriseItemList">
                                                <div class="widget-box">
                                                    <div class="widget-header">
                                                        <h5 class="smaller">
                                                            Item List
                                                        </h5>
                                                    </div>
                                                    <div class="widget-body">
                                                        <div class="widget-main ">
                                                            <asp:DataList ID="dlItemListAuthorise" CssClass="table table-striped table-bordered table-hover"
                                                                runat="server" Width="100%" OnItemCommand="dlQuestion_ItemCommand" 
                                                                onselectedindexchanged="dlItemListAuthorise_SelectedIndexChanged">
                                                                <HeaderTemplate>                                                                        
                                                                    </th>
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
                                                                    <th style="width: 20%; text-align: center;">
                                                                        EAN No.
                                                                    </th>
                                                                    <th style="width: 10%; text-align: center;">
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                        <center>
                                                                            <asp:CheckBox ID="chkCheck" runat="server" 
                                                                                AutoPostBack="true" Checked="false" Visible='<%#(string)DataBinder.Eval(Container.DataItem,"Is_Authorised") == "1" ? false : true%>' />
                                                                            <span class="lbl"></span>  
                                                                        </center>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblMaterialCode_DT" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"lblMaterialCode_DT")%>' />
                                                                        
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblInwardEntry_Code" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"InwardEntry_Code")%>'/>
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
                                                                        <asp:Label ID="lblAssetType" runat="server" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem,"AssetType")%>' />
                                                                    </td>
                                                                    <td style="width: 8%; text-align: center;">
                                                                        <asp:LinkButton ID="lnkDLAuthorise" ToolTip="Authorise" class="btn-small btn-warning  icon-lock"
                                                                            runat="server" CommandName="Details" Height="25px" 
                                                                            Visible='<%#(string)DataBinder.Eval(Container.DataItem,"Is_Authorised") == "1" ? true : false%>' />

                                                                        <a id="lbl_DLError" runat="server" title="Error" data-rel="tooltip" href="#">
                                                                            <asp:Panel ID="icon_Error" runat="server" class="badge badge-important" Visible="false">
                                                                                <i class="icon-bolt"></i>
                                                                            </asp:Panel>
                                                                        </a>
                                                                         <asp:Label ID="lblSuccess" runat="server" Text='Success' CssClass='green'
                                                                            Visible="false" />
                                                                </ItemTemplate>
                                                            </asp:DataList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
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
                            <asp:Label runat="server" ID="Label30" Text="" ForeColor="Red" />
                            <asp:Button class="btn btn-app btn-success btn-mini radius-4" ID="btnAuthorise" runat="server"
                                Text="Authorise" ValidationGroup="UcValidate" width="80px" 
                                onclick="btnAuthorise_Click" />
                            <%-- <asp:Label ID="lblDLMaterial_Code" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"Item_Id")%>' />--%>
                            <asp:Button class="btn btn-app btn-primary btn-mini radius-4" 
                                ID="btnCloseAuthorise" Visible="true" width="80px"
                                runat="server" Text="Close" onclick="btnCloseAuthorise_Click" />
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
                                                <b>Item Code</b>
                                                <th>
                                                    Item Name
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
                    <h4 class="modal-title" style="color: #FF0000">
                       Warning                        
                    </h4>
                </div>
                <div class="modal-body">
                    <!--Controls Area -->
                    <table cellpadding="0" style="border-style: none;" width="100%">
                        <tr>
                            <td style="border-style: none; text-align: left; width: 40%;">
                                <asp:Label runat="server" ID="Label20">Are you sure want to remove Material?</asp:Label>
                            
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="modal-footer">
                    <!--Button Area -->
                    <asp:Label runat="server" ID="Label21" Text="" Visible="false" />
                    <asp:Button class="btn btn-app  btn-success btn-mini radius-4" ID="Button3" ToolTip="Yes"
                        runat="server" Text="Yes"  OnClick="btnDivConfirmYes_Click"/>
                    <asp:Button class="btn btn-app btn-primary btn-mini radius-4" data-dismiss="modal"
                        ID="Button4" ToolTip="No" runat="server" Text="No" />
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
</asp:Content>
