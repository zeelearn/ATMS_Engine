<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="Sim_Payment_Details.aspx.cs" Inherits="Sim_Payment_Details" %>

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
    <%-- </div>--%>
    <div id="breadcrumbs" class="position-relative" style="height: 53px">
        <ul class="breadcrumb" style="height: 15px">
            <li><i class="icon-home"></i><a href="#">Home</a><span class="divider"><i class="icon-angle-right"></i></span></li>
            <li>
                <h4 class="blue">
                    SIM Payment<span class="divider"></span></h4>
            </li>
        </ul>
        <div id="nav-search">
            <!-- /btn-group -->
            <%--<asp:Button class="btn  btn-app btn-success btn-mini radius-4  " runat="server" ID="BtnAdd"
                Text="Add Payment" OnClick="BtnAdd_Click"  style="width:100px;"/>--%>
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
                                    Text="Search" ToolTip="Search" ValidationGroup="UcValidateSearch" OnClick="BtnSearch_Click" />
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
                                <%--   <td style="text-align: right" class="span2">
                                    <asp:LinkButton runat="server" ID="btnexporttoexcel" ToolTip="Export" class="btn-small btn-danger icon-2x icon-download-alt"
                                        Height="25px"> 
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                </td>--%>
                            </tr>
                        </table>
                    </div>
                    <div id="center" runat="server" style="overflow-x: scroll;">
                        <asp:DataList ID="DataList1" CssClass="table table-striped table-bordered table-hover"
                            runat="server" Width="100%" OnItemCommand="DataList1_ItemCommand">
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
                                <%--<th style="width: 05%; text-align: center">
                             User Name
                            </th>--%>
                                <%--  <th style="width: 05%; text-align: center">
                             Mobile No
                            </th>--%>
                                <%--  <th style="width: 05%; text-align: center">
                             Payment Status
                            </th>--%>
                                <%--  <th style="width: 05%; text-align: center">
                             Payment Mode
                            </th>--%>
                                <%-- <th style="width: 05%; text-align: center">
                             Amount
                           </th>--%>
                                <%--  <th style="width: 05%; text-align: center">
                             From Date
                            </th>--%>
                                <%--  <th style="width: 05%; text-align: center">
                             To Date
                             </th>--%>
                                <%-- <th style="width: 10%; text-align: center">
                            Payment Date
                            </th>--%>
                                <th style="width: 30%; text-align: center">
                                    Relationship No
                                </th>
                                <th style="width: 10%; text-align: center">
                                Action
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="ddlServiceprovider" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Service_Provider_ShortDesc")%>' />
                                </td>
                                <td style="width: 8%; text-align: left">
                                    <asp:Label ID="Laabel3" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Sim_Type_ShortDesc")%>' />
                                </td>
                                <td style="width: 02%; text-align: left">
                                    <asp:Label ID="Label3" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Mobile_No")%>' />
                                </td>
                                <td style="width: 10%; text-align: left">
                                    <asp:Label ID="Label4" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"SIM_No")%>' />
                                </td>
                                <%-- <td style="width: 10%; text-align: left">
                                <asp:Label ID="Label17" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"[User_name]")%>' />
                            </td>--%>
                                <%--<td style="width: 10%; text-align: left">
                                <asp:Label ID="Label23" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Mobile_No")%>' />
                            </td>--%>
                                <%-- <td style="width:8%; text-align: left">
                                <asp:Label ID="Label48" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"[Payment_status]")%>' />
                            </td>--%>
                                <%-- <td style="width: 10%; text-align: left">
                                <asp:Label ID="Label49" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"[Payment_mode]")%>' />
                         </td>--%>
                                <%-- <td style="width:8%; text-align: left">
                                <asp:Label ID="Label8" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"[Amount]")%>' />
                         </td>--%>
                                <%--<td style="width:10%; text-align: left">
                          <asp:Label ID="Label35" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"[Fdate]")%>' />
                          </td>--%>
                                <%--   <td style="width: 10%; text-align: left">
                                <asp:Label ID="Label46" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"[Tdate]")%>' />
                            </td>--%>
                                <%-- <td style="width: 10%; text-align: left">
                                <asp:Label ID="Label47" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Paymentdate")%>' />
                            </td>--%>
                                <td style="width: 20%; text-align: left">
                                    <asp:Label ID="Label59" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Relationship_Number")%>' />
                                </td>
                                <%-- <td style="width: 20%; text-align: left">
                                <asp:Label ID="Label9" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"pk")%>' />
                                </td>--%>
                                <td style="width: 10%; text-align: center">
                                    <asp:LinkButton ID="lnkEditInfo" runat="server" class="btn-small btn-primary icon-info-sign"
                                        data-rel="tooltip" CommandName='Add' CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Mobile_No")%>'
                                        ToolTip="Add" data-placement="left"></asp:LinkButton>
                                    <%--                   <asp:Button class="btn  btn-app btn-success btn-mini radius-4  " runat="server" ID="BtnAdd"
                Text="Add Payment" OnClick="BtnAdd_Click"  style="width:100px;"/>--%>
                                </td>
                            </ItemTemplate>
                        </asp:DataList>
                    </div>
                    <asp:DataList ID="DataList2" CssClass="table table-striped table-bordered table-hover"
                        Visible="false" runat="server" Width="100%">
                        <HeaderTemplate>
                            <b>Service Provider Name</b> </th>
                            <th style="width: 05%; text-align: center">
                                SIM Type
                            </th>
                            <th style="width: 05%; text-align: center">
                                Mobile NO
                            </th>
                            <th style="width: 05%; text-align: center">
                                SIM NO
                            </th>
                            <th style="width: 05%; text-align: center">
                                Relationship NO
                            </th>
                            <th style="width: 05%; text-align: center">
                                Account NO
                            </th>
                            <th style="width: 05%; text-align: center">
                                Plan
                            </th>
                            <th style="width: 05%; text-align: center">
                                Tariff
                            </th>
                            <th style="width: 05%; text-align: center">
                                User Name
                            </th>
                            <th style="width: 05%; text-align: center">
                                Location Area
                            </th>
                            <th style="width: 05%; text-align: center">
                                Approval
                            </th>
                            <th style="width: 05%; text-align: center">
                                Email
                            </th>
                            <th style="width: 05%; text-align: center">
                                Contact number
                            </th>
                            <th style="width: 05%; text-align: center">
                                Employee ID
                            </th>
                            <th style="width: 05%; text-align: center">
                                Division
                            </th>
                            <th style="width: 05%; text-align: center">
                                Department
                            </th>
                            <th style="width: 05%; text-align: center">
                                Center Name
                            </th>
                            <th style="width: 05%; text-align: center">
                                ICT Co-ordinator
                            </th>
                            <th style="width: 05%; text-align: center">
                                From Date
                            </th>
                            <th style="width: 05%; text-align: center">
                                To Date
                            </th>
                            <th style="width: 05%; text-align: center">
                                Handover date
                            </th>
                            <th style="width: 05%; text-align: center">
                                Received by
                            </th>
                            <th style="width: 05%; text-align: center">
                                Delivered by
                            </th>
                            <th style="width: 05%; text-align: center">
                                Issued by
                            </th>
                            <th style="width: 05%; text-align: center">
                                Issued Date
                            </th>
                            <th style="width: 10%; text-align: center">
                                Remarks
                            </th>
                            <th style="width: 10%; text-align: center">
                            Action
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="ddlServiceprovider" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Service_Provider_ShortDesc")%>' />
                            </td>
                            <td style="width: 30%; text-align: left">
                                <asp:Label ID="Laabel3" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Sim_Type_ShortDesc")%>' />
                            </td>
                            <td style="width: 10%; text-align: left">
                                <asp:Label ID="Label3" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Mobile_No")%>' />
                            </td>
                            <td style="width: 10%; text-align: left">
                                <asp:Label ID="Label4" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"SIM_No")%>' />
                            </td>
                            <%--  <td style="width: 10%; text-align: left">
                                <asp:Label ID="Label17" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"[User_name]")%>' />
                            </td>--%>
                            <%-- <td style="width: 10%; text-align: left">
                                <asp:Label ID="Label23" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Mobile_No")%>' />
                            </td>--%>
                            <%--    <td style="width: 10%; text-align: left">
                                <asp:Label ID="Label48" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"[Payment_status]")%>' />
                            </td>--%>
                            <%--<td style="width: 10%; text-align: left">
                                <asp:Label ID="Label49" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"[Payment_mode]")%>' />
                            </td>--%>
                            <%--<td style="width: 20%; text-align: left">
                                <asp:Label ID="Label24" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"[Amount]")%>' />
                            </td>--%>
                            <%--  <td style="width: 20%; text-align: left">
                                <asp:Label ID="Label25" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Fdate")%>' />
                            </td>--%>
                            <%-- <td style="width: 20%; text-align: left">
                                <asp:Label ID="Label26" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Tdate")%>' />
                            </td>--%>
                            <%--   <td style="width: 20%; text-align: left">
                                <asp:Label ID="Label27" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Paymentdate")%>' />
                            </td>--%>
                            <%-- <td style="width: 20%; text-align: left">
                                <asp:Label ID="Label61" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Remarks")%>' />
                            --%>
                            </td>
                            <td style="width: 10%; text-align: center">
                                <asp:Label ID="Label62" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Service_Provider_ShortDesc")%>' />
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
                                                                <asp:Label runat="server" ID="Label16" CssClass="red">SIM Type</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList runat="server" ID="ddlsimtype" Width="215px" ToolTip="SIM TYPE"
                                                                    data-placeholder="SIM Type" CssClass="chzn-select" AutoPostBack="True" />
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
                                                                <asp:TextBox ID="txtMobilenumber" runat="server" Width="205px" data-placeholder="Mobile Number"></asp:TextBox>
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
                                                                <asp:TextBox ID="TxtPlan" runat="server" Width="205px" data-placeholder="Plan"></asp:TextBox>
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
                                                                <asp:Label ID="Label20" runat="server">User Name</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:TextBox ID="TxtUser" runat="server" Width="205px" data-placeholder="Tariff"></asp:TextBox>
                                                                <%--   <input readonly="readonly" runat="server" class="span8 date-picker" style=" width:215px;" name="date-range-picker" id="id_date_range_picker_2"
                                                                        placeholder="Date" data-placement="bottom" data-original-title="Date" data-date-format="dd M yyyy"/>--%>
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
                                                                <asp:Label ID="Label18" runat="server">Contact number</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:TextBox ID="Txtcontactno" runat="server" Width="205px" data-placeholder="Contact"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label19" runat="server" CssClass="red">Payment Status</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:TextBox ID="Txtpayment" runat="server" Width="205px" data-placeholder="Contact"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label11" runat="server" CssClass="red">Pay Mode</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList runat="server" ID="ddlpaymode" Width="215px" ToolTip="PAY MODE"
                                                                    data-placeholder="Select Pay Mode" CssClass="chzn-select" AutoPostBack="True" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <%--   <tr>
                                                           <td class="span4" style="text-align: left">
                                                                <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                                    <tr>
                                                                        <td style="border-style: none; text-align: left; width: 40%;">
                                                                            <asp:Label ID="Label10" runat="server"  CssClass="red" >Contact number</asp:Label>
                                                                        </td>
                                                                        <td style="border-style: none; text-align: left; width: 60%;">
                                                                          <asp:TextBox ID="TxtContact" runat="server" Width="205px" data-placeholder="Contact"></asp:TextBox>
                                                                      
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td class="span4" style="text-align: left">
                                                                <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                                    <tr>
                                                                        <td style="border-style: none; text-align: left; width: 40%;">
                                                                            <asp:Label ID="Label9" runat="server"  CssClass="red" >Employee ID</asp:Label>
                                                                        </td>
                                                                        <td style="border-style: none; text-align: left; width: 60%;">
                                                                        <asp:TextBox ID="TxtEmployeeid" runat="server" Width="205px" data-placeholder="Employee"></asp:TextBox>
                                                                    
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td class="span4" style="text-align: left">
                                                                <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                                    <tr>
                                                                        <td style="border-style: none; text-align: left; width: 40%;">
                                                                            <asp:Label ID="Label8" runat="server" >Division </asp:Label>
                                                                        </td>
                                                                        <td style="border-style: none; text-align: left; width: 60%;">
                                                                            <asp:DropDownList runat="server" ID="ddlDivision1" Width="215px" ToolTip="Division" data-placeholder="Select Division"
                                                                CssClass="chzn-select" AutoPostBack="True" />
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
                                                                <asp:Label ID="Label7" runat="server" >Department</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                             <asp:DropDownList runat="server" ID="ddlDepartment" Width="215px" ToolTip="Department" data-placeholder="Select Department"
                                                                CssClass="chzn-select" AutoPostBack="True" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label5" runat="server">Cost Center</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList runat="server" ID="ddlCostcenter" Width="215px" ToolTip="CostCenter" data-placeholder="Select Cost Center"
                                                                CssClass="chzn-select" AutoPostBack="True" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label21" runat="server">ICT Coordinator</asp:Label>
                                                             </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                             <asp:TextBox ID="TxtCoordinator" runat="server" Width="205px" data-placeholder="Coordinator"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                </tr>--%>
                                            <tr>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                        <tr>
                                                            <td class="span2" style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label51" runat="server" CssClass="red"> Bill Amount</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:TextBox ID="Txtamount" runat="server" Width="205px" data-placeholder="Txtbillamount"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                        <tr>
                                                            <td class="span2" style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label5" runat="server" CssClass="red">Bill Date</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <input readonly="readonly" runat="server" class="id_date_range_picker_1 span8" style="width: 215px;"
                                                                    name="date-range-picker" id="txtBilldate" placeholder="Date Search" data-placement="bottom"
                                                                    data-original-title="Date" data-date-format="dd M yyyy" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                        <tr>
                                                            <td class="span2" style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label50" runat="server">Payment Date</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <input readonly="readonly" runat="server" class="span8 date-picker" style="width: 215px;"
                                                                    name="date-range-picker" id="Txtpaydate" placeholder="Date" data-placement="bottom"
                                                                    data-original-title="Date" data-date-format="dd M yyyy" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <%--         <td class="span4" style="text-align: left">
                                                <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                        <tr>
                                                            <td class="span2" style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label38" runat="server" CssClass="red" >Period</asp:Label>
                                                           </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">

                                                                         <input readonly="readonly" runat="server" class="id_date_range_picker_1 span11" name="date-range-picker"
                                                                            id="id_date_range_picker_1" placeholder="Date Search" data-placement="bottom"
                                                                            data-original-title="Date Range" onclick="return id_date_range_picker_1_onclick()" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    
                                               </td>--%>
                                                <%--   <td class="span4" style="text-align: left">
                                               <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                        <tr>
                                                            <td class="span2" style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label54" runat="server">Remarks</asp:Label>
                                                           </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:TextBox ID="TxtRemarks" runat="server" Width="205px" data-placeholder="TxtRemarks"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>--%>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                        <tr>
                                                            <td class="span2" style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label7" runat="server">Remarks</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:TextBox ID="Txtremarks" runat="server" Width="205px" data-placeholder="Txtremark"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                </td>
                                            </tr>
                                            <tr>
                                                <%--                <td class="span4" style="text-align: left">
                                                
                                                <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                        <tr>
                                                            <td class="span2" style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label22" runat="server">Handover date</asp:Label>
                                                           </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                              <input readonly="readonly" runat="server" class="span8 date-picker" style=" width:215px;" name="date-range-picker" id="TxtHandoverdate"
                                                                        placeholder="Date" data-placement="bottom" data-original-title="Date" data-date-format="dd M yyyy" onclick="return TxtHandoverdate_onclick()" />   
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    
                                               </td>
                                             
                                                <td class="span4" style="text-align: left">
                                                
                                                <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                        <tr>
                                                            <td class="span2" style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label53" runat="server"  CssClass="red" >Issued Date </asp:Label>
                                                           </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                              <input readonly="readonly" runat="server" class="span8 date-picker" style=" width:215px;" name="date-range-picker" id="TxtIssuedDate"
                                                                        placeholder="Date" data-placement="bottom" data-original-title="Date" data-date-format="dd M yyyy"/>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                
                                                    <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                        <tr>
                                                            <td class="span2" style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label28" >Status</asp:Label>
                                                           </td>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                            <label>
                                                               <input runat="server" id="chkActiveFlag" name="switch-field-1" type="checkbox" class="ace-switch ace-switch-2"
                                                                    checked="checked" />
                                                                    <span class="lbl"></span>
                                                            </label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                
                                                </td>--%>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="widget-main alert-block alert-info" style="text-align: center;">
                                <!--Button Area -->
                                <asp:Button class="btn btn-app btn-success  btn-mini radius-4" Visible="false" runat="server"
                                    ID="btnSave" Text="Save" ToolTip="Save" OnClick="btnSave_Click" />
                                <asp:Button class="btn btn-app btn-success btn-mini radius-4" ID="BtnSaveEdit" runat="server"
                                    Text="Save" ValidationGroup="UcValidate" Visible="false" OnClick="BtnSaveEdit_Click" />
                                <asp:Button class="btn btn-app btn-grey btn-mini radius-4" ID="btnClear_Add" Visible="true"
                                    runat="server" Text="Close" OnClick="BtnCloseAdd_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div id="DivPaymentHistory" runat="server" visible="false">
                <div class="widget-box">
                    <div class="widget-header widget-header-small header-color-dark">
                        <h5 class="modal-title">
                            <asp:Label ID="lblpaymenthistory_header" runat="server" Text="Payment History"></asp:Label>
                        </h5>
                    </div>
                    <div class="widget-body">
                        <div class="widget-body-inner">
                            <div class="widget-main">
                                <p>
                                    &nbsp;&nbsp;
                                    <asp:Label ID="lbldlerror" runat="server" Text="" Visible="false" CssClass="red"></asp:Label>
                                </p>
                                <asp:DataList ID="DataList3" CssClass="table table-striped table-bordered table-hover"
                                    Visible="false" runat="server" Width="100%">
                                    <HeaderTemplate>
                                        <b>SPN</b> </th>
                                        <th style="width: 10%; text-align: center">
                                            SIM Type
                                        </th>
                                        <th style="width: 10%; text-align: center">
                                            Mobile No
                                        </th>
                                        <th style="width: 10%; text-align: center">
                                            SIM NO
                                        </th>
                                        <%-- <th style="width: 05%; text-align: center">
                             Relationship No
                            </th>--%>
                                        <%--<th style="width: 05%; text-align: center">
                             Account NO
                            </th>--%>
                                        <%--<th style="width: 05%; text-align: center">
                             Plan
                            </th>--%>
                                        <%-- <th style="width: 05%; text-align: center">
                                Tariff
                            </th>--%>
                                        <%--<th style="width: 05%; text-align: center">
                                User Name
                            </th>--%>
                                        <th style="width: 10%; text-align: center">
                                            Payment Status
                                        </th>
                                        <th style="width: 10%; text-align: center">
                                            Pay Mode
                                        </th>
                                        <th style="width: 10%; text-align: center">
                                            Amount
                                        </th>
                                        <th style="width: 10%; text-align: center">
                                            Payment Date
                                        </th>
                                        <%--<th style="width: 05%; text-align: center">
                                Employee ID
                            </th>--%>
                                        <%-- <th style="width: 05%; text-align: center">
                                Division
                            </th>--%>
                                        <%--  <th style="width: 05%; text-align: center">
                                Department
                            </th>--%>
                                        <%--   <th style="width: 05%; text-align: center">
                                Center Name
                            </th>--%>
                                        <%--    <th style="width: 05%; text-align: center">
                                ICT Co-ordinator
                            </th>--%>
                                        <%--<th style="width: 05%; text-align: center">
                                From Date
                            </th>--%>
                                        <%--<th style="width: 05%; text-align: center">
                                To Date
                            </th>--%>
                                        <%--   <th style="width: 05%; text-align: center">
                                Handover date
                            </th>--%>
                                        <%-- <th style="width: 05%; text-align: center">
                              Received by
                            </th>--%>
                                        <%--  <th style="width: 05%; text-align: center">
                               Delivered by 
                            </th>--%>
                                        <%--  <th style="width: 05%; text-align: center">
                                Issued by
                            </th>--%>
                                        <%--  <th style="width: 05%; text-align: center">
                                Issued Date
                            </th>--%>
                                        <th style="width: 10%; text-align: center">
                                            Remarks
                                        </th>
                                        <%-- <th style="width: 10%; text-align: center">
                           Action--%>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="ddlServiceprovider" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Service_Provider_ShortDesc")%>' />
                                        </td>
                                        <td style="width: 30%; text-align: left">
                                            <asp:Label ID="Laabel3" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Sim_Type_ShortDesc")%>' />
                                        </td>
                                        <td style="width: 10%; text-align: left">
                                            <asp:Label ID="Label3" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Mobile_No")%>' />
                                        </td>
                                        <td style="width: 10%; text-align: left">
                                            <asp:Label ID="Label4" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"SIM_No")%>' />
                                        </td>
                                        <%-- <td style="width: 10%; text-align: left">
                                <asp:Label ID="Label17" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"[User_name]")%>' />
                            </td>--%>
                                        <%-- <td style="width: 10%; text-align: left">
                                <asp:Label ID="Label23" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Mobile_No")%>' />
                            </td>--%>
                                        <td style="width: 10%; text-align: left">
                                            <asp:Label ID="Label48" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"[Payment_status]")%>' />
                                        </td>
                                        <td style="width: 10%; text-align: left">
                                            <asp:Label ID="Label49" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"[Payment_mode]")%>' />
                                        </td>
                                        <td style="width: 20%; text-align: left">
                                            <asp:Label ID="Label24" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"[Amount]")%>' />
                                        </td>
                                        <%--  <td style="width: 20%; text-align: left">
                                <asp:Label ID="Label25" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Fdate")%>' />
                            </td>--%>
                                        <%--<td style="width: 20%; text-align: left">
                                <asp:Label ID="Label26" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Tdate")%>' />
                            </td>--%>
                                        <td style="width: 20%; text-align: left">
                                            <asp:Label ID="Label27" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Paymentdate")%>' />
                                        </td>
                                        <td style="width: 20%; text-align: left">
                                            <asp:Label ID="Label61" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Remarks")%>' />
                                            <%-- </td>
                            <td style="width: 10%; text-align: center">
                            <asp:Label ID="Label62" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Service_Provider_ShortDesc")%>' />
                                            --%>
                                        </td>
                                    </ItemTemplate>
                                </asp:DataList>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div id="DivEditPanel" runat="server" visible="false">
                <div class="widget-box">
                    <div class="widget-header widget-header-small header-color-dark">
                        <h5 class="modal-title">
                            <asp:Label ID="Label13" runat="server" Text="SIM Payment"></asp:Label>
                            <asp:Label ID="lblPkey" runat="server" visble="false"></asp:Label>
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
                            <%--<div class="widget-main alert-block alert-info" style="text-align: center;">
                                <!--Button Area -->
                                <%--<asp:Button class="btn btn-app btn-success btn-mini radius-4" ID="<%--BtnSaveEdit--%>"
                            runat="server" Text="Save" ValidationGroup="UcValidate" Visible="false" onclick="BtnSaveEdit_Click"
                            />--%>
                            <asp:Button class="btn btn-app btn-grey btn-mini radius-4" ID="btnClear_Edit" Visible="true"
                                runat="server" Text="Close" />
                        </div>
                        --%>
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
<%--<asp:Content ID="Content2" ContentPlaceHolderID="MainContainer" Runat="Server">
</asp:Content>--%>
