<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Report_Detailed_Dispatch.aspx.cs" Inherits="Dispatch_Report_Mohit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
                   Detailed Dispatch Report <span class="divider"></span></h5>
            </li>
        </ul>
        <div id="nav-search">
            <!-- /btn-group -->
            <asp:Button class="btn  btn-app btn-primary btn-mini radius-4  " Visible="false" runat="server"
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
                            <a href="GRN_Authorisation_Details.aspx">GRN_Authorisation_Details.aspx</a>
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
                                                                <asp:Label ID="Label4" runat="server" CssClass="red">Location Type</asp:Label>
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
                                            <tr>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label13" runat="server">Period</asp:Label>
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
                                                    
                                                    <table cellpadding="0" style="border-style: none; width: 139%;" class="table-hover">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label19" runat="server">Material Group</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlProductCat_SR" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Category" Width="215px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                               
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <%-- &nbsp;--%>
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
                <table cellpadding="3" class="table table-striped table-bordered table-condensed">
                    <tr>
                        <td class="span6" style="text-align: left">
                            <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                <tr>
                                    <td style="border-style: none; text-align: left; width: 40%;">
                                        <asp:Label runat="server" ID="Label9">Location Type</asp:Label>
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
                                        <asp:Label runat="server" ID="Label11">Location</asp:Label>
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
                                        <asp:Label runat="server" ID="Label1">Period</asp:Label>
                                    </td>
                                    <td style="border-style: none; text-align: left; width: 60%;">
                                        <asp:Label runat="server" ID="lblPeroidResult" Text="" CssClass="blue" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="span6" style="text-align: left">
                           
                                                    <table cellpadding="0" style="border-style: none; width: 139%;" class="table-hover">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label20" runat="server">Material Group</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                           <asp:Label runat="server" ID="lblMaterilaGroup" class="blue"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
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
                 <div class="prefix" style="overflow-x:scroll !important; height:1000px;">
                <asp:DataList ID="dlGridDisplay" CssClass="table table-striped table-bordered table-hover"
                    runat="server" Width="100%">
                    <HeaderTemplate>
                        <b>
                            Material Code
                        </b> 
                        </th>
                        <th align="left">
                            Material Name
                        </th>
                        <th align="left">
                            Material Group
                        </th>
                        <th align="left">
                            From Location Type
                        </th>
                         <th align="left">
                            From Division 
                        </th>
                        <th align="left">
                            From Location 
                        </th>
                        <th align="left">
                            To Location Type
                        </th>
                          <th align="left">
                            To Division 
                        </th>
                        <th align="left">
                            To Location 
                        </th>
                        <th align="left">
                            Vendor
                        </th>
                        <th align="left">
                            Challan No
                        </th>
                        <th align="left">
                            Challan Date
                        </th>
                        <th align="left">
                            PO Number 
                        </th>
                        <th align="left">
                            PO Date
                        </th>
                        <th align="left">
                            Asset Number
                        </th>
                         <th align="left">
                            Qty 
                             </th>
                         <th align="left">
                            User Name
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblItem_Code" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Item_Code")%>' />
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="lblOpening_Qty" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Item_Name")%>' />
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="lblValue" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Category_Name")%>' />
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="Label2" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"From_Location_Type")%>' />
                        </td>
                         <td style="text-align: left;">
                            <asp:Label ID="Label21" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"From_Division")%>' />
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="Label3" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"From_Location")%>' />
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="Label8" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"To_Location_Type")%>' />
                        </td>
                         <td style="text-align: left;">
                            <asp:Label ID="Label22" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"To_Division")%>' />
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="lblInward_Qty" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"To_Location")%>' />
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="lblOutward_Qty" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Supplier_Name")%>' />
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="lblClosing_Qty" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Challan_No")%>' />
                        </td>
                          <td style="text-align: left;">
                            <asp:Label ID="Label10" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Challan_Date")%>' />
                        </td>
                         <td style="text-align: left;">
                            <asp:Label ID="Label12" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"PoNo")%>' />
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="Label14" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"PurchaseOrder_Date")%>' />
                        </td>
                          <td style="text-align: left;">
                            <asp:Label ID="Label16" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Asset_No")%>' />
                        </td>
                         <td style="text-align: left;">
                            <asp:Label ID="Label17" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Current_Qty")%>' />
                        </td>
                          <td style="text-align: left;">
                            <asp:Label ID="Label15" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"ContactPerson")%>' />
                        </td>
                    </ItemTemplate>
                </asp:DataList>
                </div>
                <asp:DataList ID="DataList1" CssClass="table table-striped table-bordered table-hover" Visible="false"
                    runat="server" Width="100%">
                    <HeaderTemplate>
                        <b>
                            Material Code
                        </b> 
                        </th>
                        <th align="left">
                            Material Name
                        </th>
                        <th align="left">
                            Material Group
                        </th>
                        <th align="left">
                            From Location Type
                        </th>
                        <th align="left">
                            From Location 
                        </th>
                        <th align="left">
                            To Location Type
                        </th>
                        <th align="left">
                            To Location 
                        </th>
                        <th align="left">
                            Vendor
                        </th>
                        <th align="left">
                            Challan No
                        </th>
                        <th align="left">
                            Challan Date
                        </th>
                        <th align="left">
                            PO Number 
                        </th>
                        <th align="left">
                            PO Date
                        </th>
                        <th align="left">
                            Asset Number
                        </th>
                         <th align="left">
                            Qty 
                              </th>
                         <th align="left">
                            User Name
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblItem_Code" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Item_Code")%>' />
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="lblOpening_Qty" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Item_Name")%>' />
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="lblValue" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Category_Name")%>' />
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="Label2" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"From_Location_Type")%>' />
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="Label3" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"From_Location")%>' />
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="Label8" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"To_Location_Type")%>' />
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="lblInward_Qty" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"To_Location")%>' />
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="lblOutward_Qty" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Supplier_Name")%>' />
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="lblClosing_Qty" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Challan_No")%>' />
                        </td>
                          <td style="text-align: left;">
                            <asp:Label ID="Label10" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Challan_Date")%>' />
                        </td>
                         <td style="text-align: left;">
                            <asp:Label ID="Label12" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"PoNo")%>' />
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="Label14" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"PurchaseOrder_Date")%>' />
                        </td>
                          <td style="text-align: left;">
                            <asp:Label ID="Label16" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Asset_No")%>' />
                        </td>
                         <td style="text-align: left;">
                            <asp:Label ID="Label17" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Current_Qty")%>' />
                        </td>
                          <td style="text-align: left;">
                            <asp:Label ID="Label15" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"ContactPerson")%>' />
                        </td>
                    </ItemTemplate>
                </asp:DataList>
            </div>
        </div>
    </div>
</asp:Content>

