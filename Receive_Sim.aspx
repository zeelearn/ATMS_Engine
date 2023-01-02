<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="Receive_Sim.aspx.cs" Inherits="Receive_SIM" EnableEventValidation="false" %>

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
            <li><i class="icon-home"></i><a href="Homepage.aspx">Home</a><span class="divider"><i class="icon-angle-right"></i></span></li>
            <li>
                <h4 class="blue">
                   Sim Registration<span class="divider"></span></h4>
            </li>
        </ul>
        <div id="nav-search">
            <!-- /btn-group -->
            <asp:Button class="btn  btn-app btn-success btn-mini radius-4  " runat="server" ID="BtnAdd"
                Text="Register" OnClick="BtnAdd_Click" />
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
                                                                <asp:Label runat="server" ID="Label2">Mobile No</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 100%;">
                                                                <asp:TextBox ID="txtmobileno" runat="server" Width="205px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                       <tr>
                                                            <td style="border-style: none; text-align: left; width: 28%;">
                                                            <asp:Label runat="server" ID="Label5"> Sim Status</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 100%;">
                                                            <asp:DropDownList runat="server" ID="ddlstatus1" Width="205px" data-placeholder="Select Service Provider Name"
                                                             CssClass="chzn-select" AutoPostBack="True" />
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
                        runat="server" Width="100%" onitemcommand="DataList1_ItemCommand" 
                        >
                        <HeaderTemplate>
                            <b>SPN</b> </th>
                            <th style="width: 20%; text-align: center">
                                SIM Type
                            </th>
                            <th style="width: 20%; text-align: center">
                                Mobile No
                            </th>
                            <th style="width: 20%; text-align: center">
                                SIM No
                            </th>
                            <th style="width: 20%; text-align: center">
                                Relationship No
                            </th>
                          <%--  <th style="width: 05%; text-align: center">
                                Account NO
                            </th>--%>
                         <%--   <th style="width: 05%; text-align: center">
                                Plan
                            </th>--%>
                            <th style="width: 20%; text-align: center">
                                Tariff
                            </th>
                            <th style="width: 20%; text-align: center">
                               Card Status
                            </th>
                         <%--   <th style="width: 10%; text-align: center">
                                Operational-Date
                            </th>--%>
                            <%-- <th style="width: 10%; text-align: center">
                                Disconnection-Date
                            </th>--%>
                             <%-- <th style="width: 10%; text-align: center">
                                Billing-Cycle
                            </th>--%>
                           <%--  <th style="width: 05%; text-align: center">
                                Cost
                            </th>--%>
                            <%-- <th style="width: 10%; text-align: center">
                                Due Date
                            </th>--%>
                            <%-- <th style="width: 10%; text-align: center">
                                Bill-Date
                            </th>--%>
                             <%--<th style="width: 05%; text-align: center">
                                Payment Status
                            </th>
                             <th style="width: 05%; text-align: center">
                                Payment Mode
                            </th>
                              <th style="width: 05%; text-align: center">
                                Bill Copy
                            </th>--%>
                           <%-- <th style="width: 20%; text-align: center">
                            Remarks
                            </th>--%>
                            <th style="width: 20%; text-align: center">
                           Action
                            
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblBoardCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"SERVICEPROVDERNAME")%>' />
                            </td>
                            <td style="width: 20%; text-align: left">
                                <asp:Label ID="lblBoardNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"SIMTYPE")%>' />
                            </td>
                            <td style="width: 20%; text-align: left">
                                <asp:Label ID="Label3" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"MOBILENUMBER")%>' />
                            </td>
                            <td style="width: 20%; text-align: left">
                                <asp:Label ID="Label4" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"SIMNUMBER")%>' />
                            </td>
                            <td style="width: 20%; text-align: left">
                                <asp:Label ID="Label17" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"RelationshipNO")%>' />
                            </td>
                           <%-- <td style="width: 06%; text-align: left">
                                <asp:Label ID="Label23" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"ACCOUNTNO")%>' />
                            </td>--%>
                          <%--  <td style="width: 06%; text-align: left">
                                <asp:Label ID="Label48" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"[Plan]")%>' />
                            </td>--%>
                            <td style="width: 20%; text-align: left">
                                <asp:Label ID="Label49" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"[Tariff]")%>' />
                            </td>
                             <td style="width: 20%; text-align: left">
                                <asp:Label ID="Label24" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"[Description]")%>' />
                            </td>
                          <%--   <td style="width: 06%; text-align: left">
                                <asp:Label ID="Label25" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"OPERATIONALDATE")%>' />
                            </td>--%>
                           <%--  <td style="width: 06%; text-align: left">
                                <asp:Label ID="Label26" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Disconnectionsdate")%>' />
                            </td>--%>
                         <%--   <td style="width: 06%; text-align: left">
                                <asp:Label ID="Label27" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Monthly_Billing_Cycle")%>' />
                            </td>--%>
                            <%--  <td style="width: 06%; text-align: left">
                                <asp:Label ID="Label28" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"COST")%>' />
                            </td>--%>
                         <%--    <td style="width: 06%; text-align: left">
                                <asp:Label ID="Label32" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"duedate")%>' />
                            </td>--%>
                         <%--   <td style="width: 06%; text-align: left">
                                <asp:Label ID="Label33" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"billdate")%>' />
                            </td>--%>
                           <%-- <td style="width: 20%; text-align: left">
                                <asp:Label ID="Label34" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"paymentstatus")%>' />
                            </td>--%>
                            <%--<td style="width: 20%; text-align: left">
                                <asp:Label ID="Label35" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"[PaymentMode]")%>' />
                            </td>--%>
                           <%-- <td style="width: 20%; text-align: left">
                                <asp:Label ID="Label46" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"[Description]")%>' />
                            </td>--%>
                           <%-- <td style="width: 06%; text-align: left">
                                <asp:Label ID="Label47" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"REMARS")%>' />
                            </td>--%>
                            <td style="width: 20%; text-align: center">
                                <asp:LinkButton ID="lnkEditInfo" runat="server" class="btn-small btn-primary icon-edit"
                                    data-rel="tooltip" CommandName='comEdit' CommandArgument='<%#DataBinder.Eval(Container.DataItem,"MOBILENUMBER")%>'
                                    ToolTip="Edit" data-placement="left"></asp:LinkButton>
                            </td>
                        </ItemTemplate>
                    </asp:DataList>
                    </div>
                    <asp:DataList ID="DataList1" CssClass="table table-striped table-bordered table-hover"
                        runat="server" Width="100%" Visible="false">
                        <HeaderTemplate>
                            <b>Service Provider Name</b> </th>
                            <th style="width: 10%; text-align: center">
                                SIM Type
                            </th>
                            <th style="width: 10%; text-align: center">
                                Mobile NO
                            </th>
                            <th style="width: 10%; text-align: center">
                                SIM NO
                            </th>
                            <th style="width: 10%; text-align: center">
                                Relationship NO
                            </th>
                            <th style="width: 10%; text-align: center">
                                Account NO
                            </th>
                            <th style="width: 10%; text-align: center">
                                Plan
                            </th>
                            <th style="width: 10%; text-align: center">
                                Tariff
                            </th>
                            <th style="width: 10%; text-align: center">
                                SIM/DATA Card Status
                            </th>
                            <th style="width: 10%; text-align: center">
                                Operational Date
                            </th>
                             <th style="width: 10%; text-align: center">
                                Disconnection Date
                            </th>
                              <th style="width: 10%; text-align: center">
                                Monthly Billing Cycle
                            </th>
                             <th style="width: 10%; text-align: center">
                                Cost
                            </th>
                             <th style="width: 10%; text-align: center">
                                Due Date
                            </th>
                             <th style="width: 10%; text-align: center">
                                Bill Date
                            </th>
                            <%-- <th style="width: 05%; text-align: center">
                                Payment Status
                            </th>
                             <th style="width: 05%; text-align: center">
                                Payment Mode
                            </th>
                              <th style="width: 05%; text-align: center">
                                Bill Copy--%>
                            </th>
                            <th style="width: 10%; text-align: center">
                            Remarks
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblBoardCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"SERVICEPROVDERNAME")%>' />
                            </td>
                            <td style="width: 10%; text-align: left">
                                <asp:Label ID="lblBoardNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"SIMTYPE")%>' />
                            </td>
                            <td style="width: 10%; text-align: left">
                                <asp:Label ID="Label3" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"MOBILENUMBER")%>' />
                            </td>
                            <td style="width: 10%; text-align: left">
                                <asp:Label ID="Label4" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"SIMNUMBER")%>' />
                            </td>
                            <td style="width: 10%; text-align: left">
                                <asp:Label ID="Label17" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"RelationshipNO")%>' />
                            </td>
                            <td style="width: 10%; text-align: left">
                                <asp:Label ID="Label23" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"ACCOUNTNO")%>' />
                            </td>
                            <td style="width: 10%; text-align: left">
                                <asp:Label ID="Label48" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"[Plan]")%>' />
                            </td>
                            <td style="width: 10%; text-align: left">
                                <asp:Label ID="Label49" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"[Tariff]")%>' />
                            </td>
                             <td style="width: 10%; text-align: left">
                                <asp:Label ID="Label24" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"[Description]")%>' />
                            </td>
                             <td style="width: 10%; text-align: left">
                                <asp:Label ID="Label25" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"OPERATIONALDATE")%>' />
                            </td>
                             <td style="width: 10%; text-align: left">
                                <asp:Label ID="Label26" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Disconnectionsdate")%>' />
                            </td>
                            <td style="width: 10%; text-align: left">
                                <asp:Label ID="Label27" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Monthly_Billing_Cycle")%>' />
                            </td>
                              <td style="width: 10%; text-align: left">
                                <asp:Label ID="Label28" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"COST")%>' />
                            </td>
                             <td style="width: 10%; text-align: left">
                                <asp:Label ID="Label32" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"duedate")%>' />
                            </td>
                            <td style="width: 10%; text-align: left">
                                <asp:Label ID="Label33" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"billdate")%>' />
                            </td>
                            <%--<td style="width: 20%; text-align: left">
                                <asp:Label ID="Label34" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"paymentstatus")%>' />
                            </td>
                            <td style="width: 20%; text-align: left">
                                <asp:Label ID="Label35" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"[PaymentMode]")%>' />
                            </td>
                            <td style="width: 20%; text-align: left">
                                <asp:Label ID="Label46" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"[Description]")%>' />
                            </td>--%>
                            <td style="width: 10%; text-align: left">
                                <asp:Label ID="Label47" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"REMARS")%>' />
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
                                                                                data-placeholder="Select" CssClass="chzn-select" AutoPostBack="true" 
                                                                                onselectedindexchanged="ddlServiceprovider1_SelectedIndexChanged" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td class="span4" style="text-align: left">
                                                                <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                                    <tr>
                                                                        <td style="border-style: none; text-align: left; width: 40%;">
                                                                            <asp:Label runat="server" ID="Label16" CssClass="red">SIM Type</asp:Label>
                                                                        </td>
                                                                        <td style="border-style: none; text-align: left; width: 60%;">
                                                                            <asp:DropDownList runat="server" ID="ddlsimtype" Width="215px" ToolTip="SIM TYPE" data-placeholder="SIM Type"
                                                                                CssClass="chzn-select" AutoPostBack="false" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td class="span4" style="text-align: left">
                                                                <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                                    <tr>
                                                                        <td style="border-style: none; text-align: left; width: 40%;">
                                                                            <asp:Label runat="server" ID="Mobileno" CssClass="red">Mobile Number</asp:Label>
                                                                        </td>
                                                                        <td style="border-style: none; text-align: left; width: 60%;">
                                                                            <asp:TextBox ID="txtMobilenumber" runat="server" Width="205px" data-placeholder="Mobile Number" MaxLength="10" ></asp:TextBox>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtMobilenumber" ValidationExpression="^\d+"
                                                                            ErrorMessage="Please enter 10 degit mobile no!" />
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
                                                                        <asp:Label runat="server" ID="Label1" CssClass="red">SIM Number</asp:Label>
                                                                    </td>
                                                                    <td style="border-style: none; text-align: left; width: 60%;">
                                                                        <asp:TextBox ID="txtSimnum" runat="server" Width="205px" data-placeholder="SIM Number"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtSimnum" ValidationExpression="^\d+"
                                                                            ErrorMessage="Please enter number!" CssClass="red" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td class="span4" style="text-align: left">
                                                            <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                                <tr>
                                                                    <td style="border-style: none; text-align: left; width: 40%;">
                                                                        <asp:Label runat="server" ID="Label12" CssClass="red">Relationship Number</asp:Label>
                                                                    </td>
                                                                    <td style="border-style: none; text-align: left; width: 60%;">
                                                                        <asp:TextBox ID="TxtRelationshipnum" runat="server" Width="205px" data-placeholder="Relationship Number"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TxtRelationshipnum" ValidationExpression="^\d+"
                                                                            ErrorMessage="Please enter number!" CssClass="red" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        
                                                        <td class="span4" style="text-align: left">
                                                            <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                                <tr>
                                                                    <td style="border-style: none; text-align: left; width: 40%;">
                                                                        <asp:Label ID="Label41" runat="server" CssClass="red">Account Number</asp:Label>
                                                                    </td>
                                                                    <td style="border-style: none; text-align: left; width: 60%;">
                                                                        <asp:TextBox ID="TxtAccountNum" runat="server" Width="205px" data-placeholder="Account Number"></asp:TextBox>
                                                                         <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="TxtAccountNum" ValidationExpression="^\d+"
                                                                            ErrorMessage="Please enter number!" CssClass="red" />
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
                                                                            <asp:Label ID="Label40" runat="server" CssClass="red">Plan</asp:Label>
                                                                        </td>
                                                                        <td style="border-style: none; text-align: left; width: 60%;">
                                                                        <asp:DropDownList runat="server" ID="ddlplan" Width="215px" ToolTip="Select"
                                                                                data-placeholder="Select" CssClass="chzn-select" AutoPostBack="true" 
                                                                                onselectedindexchanged="ddlplan_SelectedIndexChanged" />
                                                                            
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td class="span4" style="text-align: left">
                                                                <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                                    <tr>
                                                                        <td style="border-style: none; text-align: left; width: 40%;">
                                                                            <asp:Label ID="Label39" runat="server" CssClass="red">Tariff</asp:Label>
                                                                        </td>
                                                                        <td style="border-style: none; text-align: left; width: 60%;">
                                                                            <asp:TextBox ID="TxtTariff" runat="server" Width="205px" data-placeholder="Tariff"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td class="span4" style="text-align: left">
                                                                <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                                    <tr>
                                                                        <td style="border-style: none; text-align: left; width: 40%;">
                                                                            <asp:Label ID="Label20" runat="server" >Operational date</asp:Label>
                                                                        </td>
                                                                        <td style="border-style: none; text-align: left; width: 60%;">
                                                                            <input readonly="readonly" runat="server" class="span8 date-picker" style=" width:215px;" name="date-range-picker" id="id_date_range_picker_2"
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
                                                                            <asp:Label ID="Label19" runat="server" >Disconnections date</asp:Label>
                                                                        </td>
                                                                        <td style="border-style: none; text-align: left; width: 60%;">
                                                                         <input readonly="readonly" runat="server" class="span8 date-picker" style=" width:215px;" name="date-range-picker" id="Txtdate1"
                                                                        placeholder="Date" data-placement="bottom" data-original-title="Date" data-date-format="dd M yyyy"/>
                                                                           
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td class="span4" style="text-align: left">
                                                                <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                                    <tr>
                                                                        <td style="border-style: none; text-align: left; width: 40%;">
                                                                            <asp:Label ID="Label18" runat="server" >Monthly Billing Cycle</asp:Label>
                                                                        </td>
                                                                        <td style="border-style: none; text-align: left; width: 60%;">
                                                                        <input readonly="readonly" runat="server" class="span8 date-picker" style=" width:215px;" name="date-range-picker" id="Txtdate2"
                                                                        placeholder="Date" data-placement="bottom" data-original-title="Date" data-date-format="dd M yyyy"/>
                                                                           
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td class="span4" style="text-align: left">
                                                                <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                                    <tr>
                                                                        <td style="border-style: none; text-align: left; width: 40%;">
                                                                            <asp:Label ID="Label11" runat="server" CssClass="red">Cost</asp:Label>
                                                                        </td>
                                                                        <td style="border-style: none; text-align: left; width: 60%;">
                                                                            <asp:TextBox ID="TxtCost" runat="server" Width="205px" data-placeholder="Cost"></asp:TextBox>
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
                                                                            <asp:Label ID="Label10" runat="server" >Due Date</asp:Label>
                                                                        </td>
                                                                        <td style="border-style: none; text-align: left; width: 60%;">
                                                                        <input readonly="readonly" runat="server" class="span8 date-picker" style=" width:215px;" name="date-range-picker" id="Txtdate3"
                                                                        placeholder="Date" data-placement="bottom" data-original-title="Date" data-date-format="dd M yyyy"/>
                                                                          
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td class="span4" style="text-align: left">
                                                                <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                                    <tr>
                                                                        <td style="border-style: none; text-align: left; width: 40%;">
                                                                            <asp:Label ID="Label9" runat="server" >Bill Date</asp:Label>
                                                                        </td>
                                                                        <td style="border-style: none; text-align: left; width: 60%;">
                                                                        <input readonly="readonly" runat="server" class="span8 date-picker" style=" width:215px;" name="date-range-picker" id="TxtDate4"
                                                                        placeholder="Date" data-placement="bottom" data-original-title="Date" data-date-format="dd M yyyy"/>
                                                                           
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td class="span4" style="text-align: left">
                                                                <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                                    <tr>
                                                                    <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label21" runat="server" CssClass="red">Status</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList runat="server" ID="ddlstatus" Width="215px" ToolTip="STATUS" data-placeholder="Select Status"
                                                                CssClass="chzn-select" AutoPostBack="false" />
                                                            </td>
                                                                       <%-- <td style="border-style: none; text-align: left; width: 40%;">
                                                                            <asp:Label ID="Label8" runat="server" >Payment Status</asp:Label>
                                                                        </td>
                                                                        <td style="border-style: none; text-align: left; width: 60%;">
                                                                            <asp:TextBox ID="TxtPayment" runat="server" Width="205px" data-placeholder="Payment status"></asp:TextBox>
                                                                        </td>--%>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                
                                                <%--<td class="span4" style="text-align: left">
                                                    <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label7" runat="server" CssClass="red" >Payment Mode</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList runat="server" ID="ddlpaymode" Width="215px" ToolTip="PAY MODE" data-placeholder="Select Pay Mode"
                                                                CssClass="chzn-select" AutoPostBack="True" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label5" runat="server" CssClass="red">Bill Copy</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList runat="server" ID="ddlBillcopy" Width="215px" ToolTip="Billcopy" data-placeholder="Select Bill Copy"
                                                                CssClass="chzn-select" AutoPostBack="True" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                    </table>
                                                </td>--%>
                                                </tr>
                                                   <tr>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                        <tr>
                                                            <td class="span2" style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label38" runat="server">Remarks</asp:Label>
                                                           </td>
                                                            <td style="border-style: none; text-align: left; width:100%;">
                                                                <asp:TextBox ID="TextBox8" runat="server"  Width="205px" data-placeholder="Remark"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                               </td>
                                             
                                                <%--<td class="span4" style="text-align: left">
                                                </td>
                                                <td>
                                                </td>--%>
                                            </tr>
                                            
                                        </table>
                                         <div class="widget-main alert-block alert-info" style="text-align: center;">
                                            <!--Button Area -->
                                            <asp:Button class="btn btn-app btn-success  btn-mini radius-4" Visible="false" runat="server"
                                                ID="btnSave" Text="Save" ToolTip="Save" onclick="btnSave_Click" />
                                                <asp:Button class="btn btn-app btn-success btn-mini radius-4" ID="BtnSaveEdit" runat="server"
                                                  Text="Save" ValidationGroup="UcValidate" Visible="false" OnClick="BtnSaveEdit_Click" />
                                            <asp:Button class="btn btn-app btn-grey btn-mini radius-4" ID="BtnCloseAdd" Visible="true"
                                                runat="server" Text="Close" OnClick="BtnCloseAdd_Click" />
                                               <%-- <asp:Button class="btn btn-app btn-grey btn-mini radius-4" ID="BtnCloseedit" Visible="true"
                                                runat="server" Text="Close" OnClick="BtnCloseAdd_Click" />--%>
                                        </div>
                                 </ContentTemplate>
                              <Triggers>
                             <asp:PostBackTrigger ControlID="BtnCloseAdd" />
                             <asp:PostBackTrigger ControlID="BtnSaveEdit" />
                             <asp:PostBackTrigger ControlID="btnSave" />
                              </Triggers>                                   
                                </asp:UpdatePanel>

                            </div>
                           
                        </div>
                    </div>
                </div>
            </div>
            <div id="DivEditPanel" runat="server" visible="false">
                <div class="widget-box">
                    <div class="widget-header widget-header-small header-color-dark">
                        <h5 class="modal-title">
                            <asp:Label ID="Label13" runat="server" Text="Edit Sim Details"></asp:Label>
                            <asp:Label ID="lblPkey" runat="server" visble ="false"></asp:Label>
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
                               <%-- <asp:Button class="btn btn-app btn-success btn-mini radius-4" ID="BtnSaveEdit" runat="server"
                                    Text="Save" ValidationGroup="UcValidate" Visible="false" 
                                     />--%>
                                <asp:Button class="btn btn-app btn-grey btn-mini radius-4" ID="btnClear_Edit" Visible="true"
                                    runat="server" Text="Close" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <asp:Label ID="lblslotid" runat="server" Visible="false"></asp:Label>
            <asp:Label ID="lbldelCode" runat="server" Visible="false"></asp:Label>
        </div>
        
        <!--/row-->
    </div>
</asp:Content>
