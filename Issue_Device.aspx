<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Issue_Device.aspx.cs" Inherits="Iussu_Device" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">

        function NumberOnly() {
            var AsciiValue = event.keyCode
            if ((AsciiValue >= 48 && AsciiValue <= 57) || (AsciiValue >= 65 && AsciiValue <= 90) || (AsciiValue >= 97 && AsciiValue <= 122))
                event.returnValue = true;
            else
                event.returnValue = false;
        }

        function NumberandCharOnly() {
            var AsciiValue = event.keyCode
            if ((AsciiValue >= 48 && AsciiValue <= 57) || (AsciiValue >= 65 && AsciiValue <= 90) || (AsciiValue >= 97 && AsciiValue <= 122) || AsciiValue == 40 || AsciiValue == 41 || AsciiValue == 45)
                event.returnValue = true;
            else
                event.returnValue = false;
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContainer" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="breadcrumbs" class="position-relative" style="height: 53px">
        <ul class="breadcrumb" style="height: 15px">
            <li><i class="icon-home"></i><a href="#">Home</a><span class="divider"><i class="icon-angle-right"></i></span></li>
            <li>
                <h4 class="blue">
                    Issue  Device<span class="divider"></span></h4>
            </li>
        </ul>
        <div id="nav-search">
            <!-- /btn-group -->
            <asp:Button class="btn  btn-app btn-success btn-mini radius-4  " runat="server" ID="BtnAdd"
                Text="Add" OnClick="BtnAdd_Click" />
            <asp:Button class="btn  btn-app btn-primary btn-mini radius-4  " Visible="false"
                runat="server" ID="BtnShowSearchPanel" Text="Search" OnClick="BtnShowSearchPanel_Click" />
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
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 28%;">
                                                                <asp:Label runat="server" ID="Label14" CssClass="red">Service Provider</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 100%;">
                                                                <asp:DropDownList runat="server" ID="ddlServiceprovider" Width="215px" data-placeholder="Select Service Provider Name"
                                                                    CssClass="chzn-select" AutoPostBack="True" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 28%;">
                                                                <asp:Label runat="server" ID="Label2">Device Type</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 100%;">
                                                                <asp:DropDownList runat="server" ID="ddlDevicetype1" Width="215px" data-placeholder="Select Device Type"
                                                                    CssClass="chzn-select" AutoPostBack="True" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
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
                                    Text="Search" ToolTip="Search"  ValidationGroup="UcValidateSearch" OnClick="BtnSearch_Click" />
                                <asp:Button class="btn btn-app btn-grey btn-mini radius-4" ID="BtnClearSearch" Visible="true"
                                    runat="server" Text="Clear" OnClick="BtnClearSearch_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div id="DivResultPanel" runat="server" visible="false">
                <div class="widget-box">
                    <div class="table-header">
                        <table width="100%">
                            <tr>
                                <td class="span10">
                                    Total No of Records:
                                    <asp:Label runat="server" ID="lbltotalcount" Text="0" />
                                </td>
                                 <td style="text-align: right" class="span2">
                                    <asp:LinkButton runat="server" ID="btnExport" ToolTip="Export" class="btn-small btn-danger icon-2x icon-download-alt"
                                        Height="25px" OnClick="btnExport_Click" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                </td>
                           
                            </tr>
                        </table>
                    </div>
                    <div id="center" runat="server" style="overflow-x: scroll; overflow-y: auto">
                    
                    <asp:DataList ID="dlcenter" CssClass="table table-striped table-bordered table-hover"
                        runat="server" Width="100%" >
                        
                        <HeaderTemplate>
                            <b>Service Provider Name</b> 
                            </th>
                            <%--<th style="width: 05%; text-align: center">
                                SIM Type
                            </th>--%>
                            <th style="width: 05%; text-align: center">
                                Device Type
                            </th>
                            <th style="width: 05%; text-align: center">
                                Device Name
                            </th>
                            <th style="width: 05%; text-align: center">
                                Model No
                            </th>
                            <th style="width: 05%; text-align: center">
                                IMEI No
                            </th>
                            <th style="width: 05%; text-align: center">
                                SSID
                            </th>
                            <th style="width: 05%; text-align: center">
                                Password
                            </th>
                            <th style="width: 05%; text-align: center">
                                Sr Number
                            </th>
                            <th style="width: 05%; text-align: center">
                                Cost Type
                            </th>
                             <th style="width: 05%; text-align: center">
                                Accessories
                            </th>
                              <th style="width: 05%; text-align: center">
                                Power Adapter
                            </th>
                             <th style="width: 05%; text-align: center">
                                Issued Date
                            </th>
                             <th style="width: 05%; text-align: center">
                                Purchased Date
                            </th>
                             <th style="width: 05%; text-align: center">
                                Color
                            </th>
                             <th style="width: 05%; text-align: center">
                                Returned Date
                            </th>
                             <th style="width: 05%; text-align: center">
                                 Remark
                            <%--</th>
                              <th style="width: 05%; text-align: center">
                                Remark
                            </th>
                              <th style="width: 05%; text-align: center">
                                Handover date
                            </th>
                              <th style="width: 05%; text-align: center">
                                ICT Coordinator
                            </th>
                             <th style="width: 05%; text-align: center">
                                Issued by
                            </th>
                              <th style="width: 05%; text-align: center">
                                Received by
                            </th>
                             <th style="width: 05%; text-align: center">
                                Delivered by
                            </th>
                            <th style="width: 10%; text-align: center">
                            Remarks--%>
                            </th>
                            <th style="width: 10%; text-align: center">
                           Action
                            
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblBoardCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"SERVICEPROVDERNAME")%>' />
                            </td>
                            <td style="width: 30%; text-align: left">
                                <asp:Label ID="lblBoardNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"DeviceType")%>' />
                            </td>
                            <td style="width: 20%; text-align: left">
                                <asp:Label ID="Label3" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Devicename")%>' />
                            </td>
                            <td style="width: 20%; text-align: left">
                                <asp:Label ID="Label4" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Modelno")%>' />
                            </td>
                            <td style="width: 20%; text-align: left">
                                <asp:Label ID="Label17" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"IMEIno")%>' />
                            </td>
                            <td style="width: 20%; text-align: left">
                                <asp:Label ID="Label23" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"SSID")%>' />
                            </td>
                            <td style="width: 20%; text-align: left">
                                <asp:Label ID="Label48" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"[Password]")%>' />
                            </td>
                            <td style="width: 20%; text-align: left">
                                <asp:Label ID="Label49" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"[SR_number]")%>' />
                            </td>
                             <td style="width: 20%; text-align: left">
                                <asp:Label ID="Label24" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"[Cost_type]")%>' />
                            </td>
                             <td style="width: 20%; text-align: left">
                                <asp:Label ID="Label25" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Accessories")%>' />
                            </td>
                             <td style="width: 20%; text-align: left">
                                <asp:Label ID="Label26" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Power_adapter")%>' />
                            </td>
                            <td style="width: 20%; text-align: left">
                                <asp:Label ID="Label27" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Issued_date")%>' />
                            </td>
                              <td style="width: 20%; text-align: left">
                                <asp:Label ID="Label28" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Purchased_date")%>' />
                            </td>
                             <td style="width: 20%; text-align: left">
                                <asp:Label ID="Label32" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Color")%>' />
                            </td>
                            <td style="width: 20%; text-align: left">
                                <asp:Label ID="Label33" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Returned_date")%>' />
                            </td>
                            <td style="width: 20%; text-align: left">
                                <asp:Label ID="Label34" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Remark")%>' />
                            </td>
                           <%-- <td style="width: 20%; text-align: left">
                                <asp:Label ID="Label35" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"[PaymentMode]")%>' />
                            </td>--%>
                            <%--<td style="width: 20%; text-align: left">
                                <asp:Label ID="Label46" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"[Description]")%>' />
                            </td>
                            <td style="width: 20%; text-align: left">
                                <asp:Label ID="Label47" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"REMARS")%>' />
                            </td>--%>
                            <td style="width: 10%; text-align: center">
                                <asp:LinkButton ID="lblEdit" runat="server" class="btn-small btn-primary icon-info-sign"
                                    data-rel="tooltip" CommandName='comEdit' CommandArgument='<%#DataBinder.Eval(Container.DataItem,"SERVICEPROVDERNAME")%>'
                                    ToolTip="Edit" data-placement="left"></asp:LinkButton>
                            </td>
                        </ItemTemplate>
                    </asp:DataList>
                    </div>
                    <asp:DataList ID="DataList1" CssClass="table table-striped table-bordered table-hover"
                        runat="server" Width="100%" Visible="false">
                        <HeaderTemplate>
                            <b>Service Provider Name</b> </th>
                            <th style="width: 05%; text-align: center">
                                Device Type
                            </th>
                            <th style="width: 05%; text-align: center">
                                Device Name
                            </th>
                            <th style="width: 05%; text-align: center">
                                Model No
                            </th>
                            <th style="width: 05%; text-align: center">
                                IMEI No
                            </th>
                            <th style="width: 05%; text-align: center">
                                SSID
                            </th>
                            <th style="width: 05%; text-align: center">
                                Password
                            </th>
                            <th style="width: 05%; text-align: center">
                                Sr Number
                            </th>
                            <th style="width: 05%; text-align: center">
                                Cost Type
                            </th>
                            <th style="width: 05%; text-align: center">
                                Accessories
                            </th>
                             <th style="width: 05%; text-align: center">
                                Power Adapter
                            </th>
                              <th style="width: 05%; text-align: center">
                                Issued Date
                            </th>
                             <th style="width: 05%; text-align: center">
                                Purchased Date
                            </th>
                             <th style="width: 05%; text-align: center">
                                Color
                            </th>
                             <th style="width: 05%; text-align: center">
                               Returned Date
                            </th>
                             <th style="width: 05%; text-align: center">
                                Remark
                            <%--</th>
                             <th style="width: 05%; text-align: center">
                                Payment Mode
                            </th>
                              <th style="width: 05%; text-align: center">
                                Bill Copy
                            </th>
                            <th style="width: 10%; text-align: center">
                            Remarks--%>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblBoardCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"SERVICEPROVDERNAME")%>' />
                            </td>
                            <td style="width: 30%; text-align: left">
                                <asp:Label ID="lblBoardNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"DeviceType")%>' />
                            </td>
                            <td style="width: 20%; text-align: left">
                                <asp:Label ID="Label3" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Devicename")%>' />
                            </td>
                            <td style="width: 20%; text-align: left">
                                <asp:Label ID="Label4" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Modelno")%>' />
                            </td>
                            <td style="width: 20%; text-align: left">
                                <asp:Label ID="Label17" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"IMEIno")%>' />
                            </td>
                            <td style="width: 20%; text-align: left">
                                <asp:Label ID="Label23" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"SSID")%>' />
                            </td>
                            <td style="width: 20%; text-align: left">
                                <asp:Label ID="Label48" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"[Password]")%>' />
                            </td>
                            <td style="width: 20%; text-align: left">
                                <asp:Label ID="Label49" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"[SR_number]")%>' />
                            </td>
                             <td style="width: 20%; text-align: left">
                                <asp:Label ID="Label24" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"[Cost_type]")%>' />
                            </td>
                             <td style="width: 20%; text-align: left">
                                <asp:Label ID="Label25" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Accessories")%>' />
                            </td>
                             <td style="width: 20%; text-align: left">
                                <asp:Label ID="Label26" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Power_adapter")%>' />
                            </td>
                            <td style="width: 20%; text-align: left">
                                <asp:Label ID="Label27" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Issued_date")%>' />
                            </td>
                              <td style="width: 20%; text-align: left">
                                <asp:Label ID="Label28" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Purchased_date")%>' />
                            </td>
                             <td style="width: 20%; text-align: left">
                                <asp:Label ID="Label32" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Color")%>' />
                            </td>
                            <td style="width: 20%; text-align: left">
                                <asp:Label ID="Label33" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Returned_date")%>' />
                            </td>
                            <td style="width: 20%; text-align: left">
                                <asp:Label ID="Label34" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Remark")%>' />
                            <%--</td>
                            <td style="width: 20%; text-align: left">
                                <asp:Label ID="Label35" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"[PaymentMode]")%>' />
                            </td>
                            <td style="width: 20%; text-align: left">
                                <asp:Label ID="Label46" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"[Description]")%>' />
                            </td>
                            <td style="width: 20%; text-align: left">
                                <asp:Label ID="Label47" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"REMARS")%>' />--%>
                            </td>
                        </ItemTemplate>
                    </asp:DataList>
                </div>
            </div>
            <div id="DivAddPanel" runat="server" visible="false">
                <div class="widget-box">
                    <div class="widget-header widget-header-small header-color-dark">
                        <h5 class="modal-title">
                            <asp:Label ID="lblHeader_Add" runat="server"></asp:Label>
                        </h5>
                    </div>
                    <div class="widget-body">
                        <div class="widget-body-inner">
                            <div class="widget-main">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <table cellpadding="3" class="table table-striped table-bordered table-condensed">
                                            <tr>
                                                
                                                            <td class="span4" style="text-align: left">
                                                                <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                                    <tr>
                                                                        <td style="border-style: none; text-align: left; width: 40%;">
                                                                            <asp:Label runat="server" ID="Label15" CssClass="red">Service Provider</asp:Label>
                                                                        </td>
                                                                        <td style="border-style: none; text-align: left; width: 60%;">
                                                                            <asp:DropDownList runat="server" ID="ddlServiceprovider1" Width="215px" ToolTip="Select"
                                                                                data-placeholder="Select" CssClass="chzn-select" AutoPostBack="True" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td class="span4" style="text-align: left">
                                                                <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                                    <tr>
                                                                        <td style="border-style: none; text-align: left; width: 40%;">
                                                                            <asp:Label runat="server" ID="Label16" CssClass="red">Device type</asp:Label>
                                                                        </td>
                                                                        <td style="border-style: none; text-align: left; width: 60%;">
                                                                            <asp:DropDownList runat="server" ID="ddlDevicetype" Width="215px" ToolTip="SIM TYPE" data-placeholder="Device Type"
                                                                                CssClass="chzn-select" AutoPostBack="True" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td class="span4" style="text-align: left">
                                                                <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                                    <tr>
                                                                        <td style="border-style: none; text-align: left; width: 40%;">
                                                                            <asp:Label runat="server" ID="Mobileno" CssClass="red">Device Name</asp:Label>
                                                                        </td>
                                                                        <td style="border-style: none; text-align: left; width: 60%;">
                                                                            <asp:TextBox ID="txtDeviceName" runat="server" Width="205px" data-placeholder="Device Name"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        
                                                        </tr>
                                                        <tr>
                                                        <td class="span4" style="text-align: left">
                                                            <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                                <tr>
                                                                    <td style="border-style: none; text-align: left; width: 40%;">
                                                                        <asp:Label runat="server" ID="Label1" CssClass="red">Device Model</asp:Label>
                                                                    </td>
                                                                    <td style="border-style: none; text-align: left; width: 60%;">
                                                                        <asp:TextBox ID="txtDeviceModel" runat="server" Width="205px" data-placeholder="DeviceModel"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td class="span4" style="text-align: left">
                                                            <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                                <tr>
                                                                    <td style="border-style: none; text-align: left; width: 40%;">
                                                                        <asp:Label runat="server" ID="Label12" CssClass="red">IMEI Number</asp:Label>
                                                                    </td>
                                                                    <td style="border-style: none; text-align: left; width: 60%;">
                                                                        <asp:TextBox ID="TxtIMEI" runat="server" Width="205px" data-placeholder="IMEI Number"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        
                                                        <td class="span4" style="text-align: left">
                                                            <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                                <tr>
                                                                    <td style="border-style: none; text-align: left; width: 40%;">
                                                                        <asp:Label ID="Label41" runat="server" CssClass="red">SSID</asp:Label>
                                                                    </td>
                                                                    <td style="border-style: none; text-align: left; width: 60%;">
                                                                        <asp:TextBox ID="TxtSSID" runat="server" Width="205px" data-placeholder="SSID Number"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="span4" style="text-align: left">
                                                                <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                                    <tr>
                                                                        <td style="border-style: none; text-align: left; width: 40%;">
                                                                            <asp:Label ID="Label40" runat="server" CssClass="red">Password</asp:Label>
                                                                        </td>
                                                                        <td style="border-style: none; text-align: left; width: 60%;">
                                                                            <asp:TextBox ID="TxtPassword" runat="server" Width="205px" data-placeholder="Password"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td class="span4" style="text-align: left">
                                                                <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                                    <tr>
                                                                        <td style="border-style: none; text-align: left; width: 40%;">
                                                                            <asp:Label ID="Label39" runat="server" >Serial No</asp:Label>
                                                                        </td>
                                                                        <td style="border-style: none; text-align: left; width: 60%;">
                                                                            <asp:TextBox ID="TxtSerialNo" runat="server" Width="205px" data-placeholder="Serial No"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td class="span4" style="text-align: left">
                                                                <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                                    <tr>
                                                                        <td style="border-style: none; text-align: left; width: 40%;">
                                                                            <asp:Label ID="Label20" runat="server"  CssClass="red" >Cost type </asp:Label>
                                                                        </td>
                                                                        <td style="border-style: none; text-align: left; width: 60%;">
                                                                        <asp:TextBox ID="TxtCosttype" runat="server" Width="205px" data-placeholder="Cost type"></asp:TextBox>
                                                                         
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        
                                                        <tr>
                                                            <td class="span4" style="text-align: left">
                                                                <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                                    <tr>
                                                                        <td style="border-style: none; text-align: left; width: 40%;">
                                                                            <asp:Label ID="Label19" runat="server" >Accessories</asp:Label>
                                                                        </td>
                                                                        <td style="border-style: none; text-align: left; width: 60%;">
                                                                        <asp:TextBox ID="TxtAccessories" runat="server" Width="205px" data-placeholder="Accessories"></asp:TextBox>
                                                                                                                                               
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td class="span4" style="text-align: left">
                                                                <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                                    <tr>
                                                                        <td style="border-style: none; text-align: left; width: 40%;">
                                                                            <asp:Label ID="Label18" runat="server"  CssClass="red" >Power Adapter</asp:Label>
                                                                        </td>
                                                                        <td style="border-style: none; text-align: left; width: 60%;">
                                                                        <asp:TextBox ID="TxtPoweradapter" runat="server" Width="205px" data-placeholder="Power adapter"></asp:TextBox>
                                                                                                                                                 
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td class="span4" style="text-align: left">
                                                                <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                                    <tr>
                                                                        <td style="border-style: none; text-align: left; width: 40%;">
                                                                            <asp:Label ID="Label11" runat="server"  CssClass="red" > Issued date </asp:Label>
                                                                        </td>
                                                                        <td style="border-style: none; text-align: left; width: 60%;">
                                                                            <input readonly="readonly" runat="server" class="span8 date-picker" style=" width:215px;" name="date-range-picker" id="Issuedate"
                                                                        placeholder="Date" data-placement="bottom" data-original-title="Date" data-date-format="dd M yyyy"/>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="span4" style="text-align: left">
                                                                <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                                    <tr>
                                                                        <td style="border-style: none; text-align: left; width: 40%;">
                                                                            <asp:Label ID="Label10" runat="server"  CssClass="red" >Purchased date</asp:Label>
                                                                        </td>
                                                                        <td style="border-style: none; text-align: left; width: 60%;">
                                                                        <input readonly="readonly" runat="server" class="span8 date-picker" style=" width:215px;" name="date-range-picker" id="Purchaseddate"
                                                                        placeholder="Date" data-placement="bottom" data-original-title="Date" data-date-format="dd M yyyy"/>
                                                                          
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td class="span4" style="text-align: left">
                                                                <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                                    <tr>
                                                                        <td style="border-style: none; text-align: left; width: 40%;">
                                                                            <asp:Label ID="Label9" runat="server"  CssClass="red" > Color</asp:Label>
                                                                        </td>
                                                                        <td style="border-style: none; text-align: left; width: 60%;">
                                                                        <asp:TextBox ID="TxtColor" runat="server" Width="205px" data-placeholder="Color"></asp:TextBox>
                                                                                                                                                
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td class="span4" style="text-align: left">
                                                                <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                                    <tr>
                                                                        <td style="border-style: none; text-align: left; width: 40%;">
                                                                            <asp:Label ID="Label8" runat="server" >Returned date </asp:Label>
                                                                        </td>
                                                                        <td style="border-style: none; text-align: left; width: 60%;">
                                                                            <input readonly="readonly" runat="server" class="span8 date-picker" style=" width:215px;" name="date-range-picker" id="Returneddate"
                                                                        placeholder="Date" data-placement="bottom" data-original-title="Date" data-date-format="dd M yyyy"/>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label7" runat="server" >Remark</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                              <asp:TextBox ID="TxtRemark" runat="server" Width="205px" data-placeholder="Remark"></asp:TextBox>
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
                                <asp:Button class="btn btn-app btn-success  btn-mini radius-4" Visible="false" runat="server"
                                    ID="btnSave" Text="Save" ToolTip="Save" onclick="btnSave_Click" />
                                <asp:Button class="btn btn-app btn-grey btn-mini radius-4" ID="btnClear_Add" Visible="true"
                                    runat="server" Text="Close" OnClick="BtnCloseAdd_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div id="DivEditPanel" runat="server" visible="false">
                <div class="widget-box">
                    <div class="widget-header widget-header-small header-color-dark">
                        <h5 class="modal-title">
                            <asp:Label ID="Label13" runat="server" Text="Edit Center Details"></asp:Label>
                        </h5>
                    </div>
                    <div class="widget-body">
                        <div class="widget-body-inner">
                            <div class="widget-main">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <table cellpadding="3" class="table table-striped table-bordered table-condensed">
                                            <tr>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label29" runat="server" CssClass="red">Country</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:TextBox ID="txtCountry_edit" runat="server" Enabled="false" onkeypress="return NumberOnly(event);"
                                                                    Width="205"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label30" runat="server" CssClass="red">State</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:TextBox ID="txtState_edit" runat="server" Enabled="false" onkeypress="return NumberOnly(event);"
                                                                    Width="205"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label31" runat="server" CssClass="red">City</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:TextBox ID="txtCity_edit" runat="server" Enabled="false" onkeypress="return NumberOnly(event);"
                                                                    Width="205"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label36" runat="server" CssClass="red">Location</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:TextBox ID="txtLocation_edit" runat="server" Enabled="false" onkeypress="return NumberOnly(event);"
                                                                    Width="205"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label37" runat="server" CssClass="red">Division</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:TextBox ID="txtDivision" runat="server" Enabled="false" onkeypress="return NumberOnly(event);"
                                                                    Width="205"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label45" runat="server" CssClass="red">Zone</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlZone_edit" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Zone" Width="215px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label44" runat="server" CssClass="red">Center Code</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:TextBox ID="txteditcentercode" runat="server" Enabled="false" onkeypress="return NumberOnly(event);"
                                                                    Width="205"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label43" runat="server" CssClass="red">Center Name</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:TextBox ID="txteditcentername" runat="server" onkeypress="return NumberandCharOnly(event);"
                                                                    Width="205px" data-placeholder="Center Name"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label6" runat="server">Center short Name</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:TextBox ID="txtcenshrtname_edit" runat="server" onkeypress="return NumberandCharOnly(event);"
                                                                    Width="205px" data-placeholder="Center Short Name"></asp:TextBox>
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
                                                                <asp:Label ID="Label42" runat="server">Is Active</asp:Label>
                                                            </td>
                                                            <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                                <label>
                                                                    <input runat="server" id="chactiveedit" name="switch-field-1" type="checkbox" class="ace-switch ace-switch-2"
                                                                        checked="checked" />
                                                                    <span class="lbl"></span>
                                                                </label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="widget-main alert-block alert-info" style="text-align: center;">
                                <!--Button Area -->
                                <asp:Button class="btn btn-app btn-success btn-mini radius-4" ID="BtnSaveEdit" runat="server"
                                    Text="Save" ValidationGroup="UcValidate" Visible="false" 
                                     />
                                <asp:Button class="btn btn-app btn-grey btn-mini radius-4" ID="btnClear_Edit" Visible="true"
                                    runat="server" Text="Close" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <asp:Label ID="lblslotid" runat="server" Visible="false"></asp:Label>
        <asp:Label ID="lbldelCode" runat="server" Visible="false"></asp:Label>
        <!--/row-->
    </div>
</asp:Content>


