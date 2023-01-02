<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="ItemRequestApproval.aspx.cs" Inherits="ItemRequestApproval" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContainer" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="breadcrumbs" class="position-relative" style="height: 53px">
        <ul class="breadcrumb" style="height: 15px">
            <li><i class="icon-home"></i><a href="Homepage.aspx">Home</a><span class="divider"><i
                class="icon-angle-right"></i></span></li>
            <li>
                <h4 class="blue">
                    Item Request Approval <span class="divider"></span>
                </h4>
            </li>
        </ul>
        <div id="nav-search">
            <!-- /btn-group -->
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
                                        <table cellpadding="2" class="table table-striped table-bordered table-condensed">
                                            <tr>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                        <tr>
                                                            <td class="span2" style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label4" runat="server">Division</asp:Label>
                                                            </td>
                                                            <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlDivision" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Division" Width="215px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                        runat="server" id="tblgodown">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label3" runat="server">Period</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left">
                                                                <input readonly="readonly" runat="server" class="id_date_range_picker_1 span10" name="date-range-picker"
                                                                    id="id_date_range_picker_1" placeholder="Date Search" data-placement="bottom"
                                                                    data-original-title="Date Range" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                        runat="server" id="Table6">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label18" runat="server">Status</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left">
                                                                <asp:DropDownList ID="ddlsattusforSearch" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Status" Width="215px">
                                                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                                                    <asp:ListItem Value="1">Pending</asp:ListItem>
                                                                    <asp:ListItem Value="2">Approved</asp:ListItem>
                                                                    <asp:ListItem Value="3">Rejected At Approval</asp:ListItem>
                                                                </asp:DropDownList>
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
            <%--<asp:GridView ID="GridView1" runat="server">
            </asp:GridView>--%>
            <div id="DivResultPanel" runat="server" class="dataTables_wrapper" visible="true">
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
                    runat="server" Width="100%" Visible="True" 
                    onitemcommand="dlGridDisplay_ItemCommand">
                    <HeaderTemplate>
                        <b>No. Requisition</b> </th>
                        <th style="width: 10%; text-align: center;">
                            Requisition Date
                        </th>
                        <th style="width: 20%; text-align: center;">
                          User Type
                        </th>
                        <th style="width: 14%; text-align: center;">
                            Quantity
                        </th>
                        <th style="width: 14%; text-align: center;">
                            Status
                        </th>
                        <th style="width: 14%; text-align: center;">
                            Open Days
                        </th>
                        <th style="width: 14%; text-align: center;">
                            Action
                        </th>

                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblNo_Requisition" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"No_Requisition")%>' />
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="lblDate_Requisition" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Date_Requisition")%>' />
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="lblUser_Type" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"User_Type")%>' />
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="lblQuintity" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Quintity")%>' />
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="lblStatus" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Status")%>' />
                        </td>
                             <td style="text-align: left;">
                            <asp:Label ID="lblOpen_Days" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Open_Days")%>' />
                        </td>
                        <td style="text-align: left;">
                            <asp:LinkButton ID="lnkopen" runat="server" class="btn btn-minier btn-primary icon-edit tooltip-info"
                                data-rel="tooltip" data-placement="top" title="Open" CommandName="Open" CommandArgument=''
                                ToolTip="Open"></asp:LinkButton>
                           
                        </td>
                    </ItemTemplate>
                </asp:DataList>--%>
                <table cellpadding="3" class="table table-striped table-bordered table-condensed">
                    <tr>
                        <td class="span4" style="text-align: left">
                            <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                <tr>
                                    <td style="border-style: none; text-align: left; width: 40%;">
                                        <asp:Label runat="server" ID="Label21">Division</asp:Label>
                                    </td>
                                    <td style="border-style: none; text-align: left; width: 60%;">
                                        <asp:Label runat="server" ID="lblDivision_SR" CssClass="blue" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="span4" style="text-align: left">
                            <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                <tr>
                                    <td style="border-style: none; text-align: left; width: 40%;">
                                        <asp:Label runat="server" ID="Label22">Period</asp:Label>
                                    </td>
                                    <td style="border-style: none; text-align: left; width: 60%;">
                                        <asp:Label runat="server" ID="lblPeriod" CssClass="blue"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="span4" style="text-align: left">
                            <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                <tr>
                                    <td style="border-style: none; text-align: left; width: 40%;">
                                        <asp:Label runat="server" ID="Label1">Status</asp:Label>
                                    </td>
                                    <td style="border-style: none; text-align: left; width: 60%;">
                                        <asp:Label runat="server" ID="lblStatus" CssClass="blue" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    
                </table>
                <asp:Repeater ID="dlGridDisplay" runat="server" OnItemCommand="dlGridDisplay_ItemCommand">
                    <HeaderTemplate>
                        <table class="table table-striped table-bordered table-hover Table2">
                            <thead>
                                <tr>
                                    <th>
                                        Requisition No.
                                    </th>
                                    <th style="width: 15%; text-align: center;">
                                        Division / Function
                                    </th>
                                    <th style="width: 14%; text-align: center;">
                                        Requisition Date
                                    </th>
                                    <th style="width: 20%; text-align: center;">
                                        User Type
                                    </th>
                                    <th style="width: 10%; text-align: center;">
                                        Quantity
                                    </th>
                                    <th style="width: 10%; text-align: center;">
                                        Status
                                    </th>
                                    <th style="width: 10%; text-align: center;">
                                        Open Days
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
                                <asp:Label ID="lblNo_Requisition" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Request_Code")%>' />
                                <span id="iconDL_Authorise" runat="server" visible='<%# Convert.ToString(DataBinder.Eval(Container.DataItem,"Approved_Flag")) == "1" ? true : false%>'
                                    class="btn btn-danger btn-mini tooltip-error" data-rel="tooltip" data-placement="right"
                                    title="Request Approved"><i class="icon-lock"></i></span>
                            </td>
                            <td style="text-align: center;">
                                <asp:Label ID="Label34" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"DIV")%>' />
                            </td>
                            <td style="text-align: center;">
                                <asp:Label ID="lblDate_Requisition" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Request_date")%>' />
                            </td>
                            <td style="text-align: center;">
                                <asp:Label ID="lblUser_Type" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"User_Type_Name")%>' />
                            </td>
                            <td style="text-align: center;">
                                <asp:Label ID="lblQuintity" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Quantity")%>' />
                            </td>
                            <td style="text-align: center;">
                                <asp:Label ID="lblStatus" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Request_Status")%>' />
                            </td>
                            <td style="text-align: center;">
                                <asp:Label ID="lblOpen_Days" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"OpenDays")%>' />
                            </td>
                            <td style="text-align: center;">
                                <div class="inline position-relative">
                                    <asp:LinkButton ID="lnkEdit" ToolTip="Open" class="btn-small btn-primary icon-info-sign"
                                        CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Pkey")%>' runat="server"
                                        CommandName="comEdit" Height="25px" />&nbsp;
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
                        <b>Requisition No.</b> </th>
                        <th style="width: 16%; text-align: center;">
                            Division / Function
                        </th>
                        <th style="width: 10%; text-align: center;">
                            Requisition Date
                        </th>
                        <th style="width: 20%; text-align: center;">
                            User Type
                        </th>
                        <th style="width: 14%; text-align: center;">
                            Quantity
                        </th>
                        <th style="width: 14%; text-align: center;">
                            Status
                        </th>
                        <th style="width: 14%; text-align: center;">
                        Open Days
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblNo_Requisition" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Request_Code")%>' />
                        </td>
                        <td>
                            <asp:Label ID="Label34" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"DIV")%>' />
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="lblDate_Requisition" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Request_date")%>' />
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="lblUser_Type" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"User_Type_Name")%>' />
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="lblQuintity" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Quantity")%>' />
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="lblStatus" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Request_Status")%>' />
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="lblOpen_Days" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"OpenDays")%>' />
                        </td>
                    </ItemTemplate>
                </asp:DataList>
            </div>
            <div id="div_student" visible="false" runat="server">
                <div class="widget-box">
                    <div class="widget-header widget-header-small header-color-dark">
                        <h5>
                            Item Request Approval for Student
                        </h5>
                        <asp:Label ID="lblPkey" runat="server" Text="" Visible="false"></asp:Label>
                        <asp:Label ID="lblUserType" runat="server" Text="" Visible="false"></asp:Label>
                    </div>
                    <div class="widget-body">
                        <div class="widget-body-inner">
                            <div class="widget-main">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <table cellpadding="2" class="table table-striped table-bordered table-condensed">
                                            
                                            <tr>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                        <tr>
                                                            <td class="span2" style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label8" runat="server">Division</asp:Label>
                                                            </td>
                                                            <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label ID="lbldivision" runat="server" Text=""></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                        runat="server" id="Table3">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label9" runat="server">Center</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left">
                                                                <asp:Label ID="lblCenter" runat="server" Text=""></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                        runat="server" id="Table1">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label5" runat="server">Acad Year</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left">
                                                                <asp:Label ID="lblAcadYear" runat="server" Text=""></asp:Label>
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
                                                                <asp:Label ID="Label28" runat="server">Classroom Product</asp:Label>
                                                            </td>
                                                            <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label ID="lblClassroom" runat="server" Text=""></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                        runat="server" id="Table5">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label35" runat="server">Material Name</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left">
                                                                <asp:Label ID="lblItemName" runat="server" Text=""></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                        runat="server" id="Table11">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label37" runat="server">Open Days</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left">
                                                                <asp:Label ID="lblOpenDays" runat="server" Text=""></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                          <div class="widget-box">
                                         <div class="table-header" id="total" runat="server">
                                           <table width="100%" >
                                            <tr>
                                                <td class="span10">
                                                    Total No of Records:
                                                    <asp:Label runat="server" ID="lbltotalrecords1" Text="0" />
                                                </td>
                                                <td style="text-align: right" class="span2">
                                    
                                                </td>
                                            </tr>
                                        </table>
                                        </div>
                                        </div>
                                        <asp:DataList ID="datalist_Student" CssClass="table table-striped table-bordered table-hover"
                                            runat="server" Width="100%" Visible="True">
                                            <HeaderTemplate>
                                                <b>Student Name</b> </th>
                                                <th style="width: 15%; text-align: center;">
                                                    Center
                                                </th>
                                                <th style="width: 10%; text-align: center;">
                                                    Net Fees
                                                </th>
                                                <th style="width: 10%; text-align: center;">
                                                    Fees Received
                                                </th>
                                                <th style="width: 10%; text-align: center;">
                                                    Cleared Amount
                                                </th>
                                                  <th style="width: 10%; text-align: center;">
                                                    Status
                                                </th>
                                                <th style="width: 22%; text-align: center;">
                                                    Subject Group
                                                </th>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblMenuName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"StudentName")%>' />
                                                <asp:Label ID="lblStudentCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"SBEntrycode")%>'
                                                    Visible="false" />
                                                </td>
                                                 <td style="text-align: center;">
                                                    <asp:Label ID="Label26" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Source_Center_Name")%>' />
                                                </td>
                                                <td style="text-align: center;">
                                                    <asp:Label ID="lblMenuCss" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"netFees")%>' />
                                                </td>
                                                <td style="text-align: center;">
                                                    <asp:Label ID="lblMenuParentcode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"feesRecd")%>' />
                                                </td>
                                                <td style="text-align: center;">
                                                    <asp:Label ID="lblmenutype" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"ClearAmt")%>' />
                                                </td>
                                                 <td style="text-align: center;">
                                                    <asp:Label ID="Label31" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"status")%>' />
                                                </td>
                                                <td style="text-align: left;">
                                                    <asp:Label ID="Label2" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"SubjectGrp")%>' />
                                                </td>
                                            </ItemTemplate>
                                        </asp:DataList>
                                     <%--   <table cellpadding="3" class="table table-striped table-bordered table-condensed">
                                            <tr id="TRStudent" runat ="server" visible ="false">
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td class="span2" style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="lblHeaderStudent1">Approved By</asp:Label>
                                                            </td>
                                                            <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label runat="server" ID="lblStudApproved" CssClass="blue" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="lblHeaderStudent2">Approved On</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label runat="server" ID="lblstudApprovedOn" class="blue"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="lblHeaderStudent3">Remarks</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label runat="server" ID="lblStudentLevelRemark" CssClass="blue" />
                                                                
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                           
                                      </table>--%>
                                        <table cellpadding="3" class="table table-striped table-bordered table-condensed">
                                        <tr>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                        <tr>
                                                            <td class="span2" style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label6" runat="server">Requisition No.</asp:Label>
                                                            </td>
                                                            <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label ID="lblRequ_No" runat="server" Text=""></asp:Label>
                                                                <span id="Flag_StudApproved" runat="server" visible="false" class="label label-important arrowed">
                                                                    Approved</span>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                        runat="server" id="Table4">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label10" runat="server">Requisition Date</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left">
                                                                <asp:Label ID="lblRequisitiondate" runat="server" Text=""></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                        runat="server" id="Table2">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label7" runat="server">Request By</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left">
                                                                <asp:Label ID="lblRequstby" runat="server" Text=""></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                        runat="server" id="Table12">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label11" runat="server" CssClass="red">Status</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left">
                                                                <asp:DropDownList ID="ddlstatusforStudent" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Status" Width="215px">
                                                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                                                    <asp:ListItem Value="1">Pending</asp:ListItem>
                                                                    <asp:ListItem Value="2">Approved</asp:ListItem>
                                                                    <asp:ListItem Value="3">Rejected At Approval</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label12">Date</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label runat="server" ID="lblDateforTech" class="blue"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label13">Remarks</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:TextBox ID="txtremarksforTech" runat="server" Width="200px"></asp:TextBox>
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
                                <asp:Button class="btn btn-app btn-primary  btn-mini radius-4" runat="server" ID="btnSave_ForStudent"
                                    Text="Save" ToolTip="Save" ValidationGroup="UcValidateSearch" OnClick="btnSave_ForStudent_Click" />
                                <asp:Button class="btn btn-app btn-grey btn-mini radius-4" ID="btnClose_FotStudent"
                                    Visible="true" runat="server" Text="Close" OnClick="btnClose_FotStudent_Click" />
                                <asp:ValidationSummary ID="ValidationSummary1" ShowSummary="false" DisplayMode="List"
                                    ShowMessageBox="true" ValidationGroup="UcValidateSearch" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div id="div_Teacher" visible="false" runat="server">
                <div class="widget-box">
                    <div class="widget-header widget-header-small header-color-dark">
                        <h5>
                            Item Request Approval for Teacher
                        </h5>
                    </div>
                    <div class="widget-body">
                        <div class="widget-body-inner">
                            <div class="widget-main">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <table cellpadding="2" class="table table-striped table-bordered table-condensed">
                                            
                                            <tr>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                        <tr>
                                                            <td class="span2" style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label39" runat="server">Division</asp:Label>
                                                            </td>
                                                            <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label ID="lbldivisionforTech" runat="server" Text=""></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                        runat="server" id="Table13">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label41" runat="server">Acad Year</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left">
                                                                <asp:Label ID="lblacadyearforTech" runat="server" Text=""></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                        runat="server" id="Table14">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label43" runat="server">Open Days</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left">
                                                                <asp:Label ID="lblOpendaysforTech" runat="server" Text=""></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                          <div class="widget-box">
                                         <div class="table-header" id="teacher" runat="server" >
                                           <table width="100%" >
                                            <tr>
                                                <td class="span10">
                                                    Total No of Records:
                                                    <asp:Label runat="server" ID="lblteachertotaalrecords" Text="0" />
                                                </td>
                                                <td style="text-align: right" class="span2">
                                    
                                                </td>
                                            </tr>
                                        </table>
                                        </div>
                                        </div>
                                        <asp:DataList ID="datalist_Teacher" CssClass="table table-striped table-bordered table-hover"
                                            runat="server" Width="100%" Visible="True">
                                            <HeaderTemplate>
                                                <b>Teacher Code</b> </th>
                                                <th style="width: 25%; text-align: center;">
                                                    Teacher Name
                                                </th>
                                                <th style="width: 30%; text-align: center;">
                                                    Subject
                                                </th>
                                                <th style="width: 25%; text-align: center;">
                                                    Short Name
                                                </th>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblPartnerCodeDL" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Partner_code")%>' />
                                                </td>
                                                <td style="width: 12%; text-align: left;">
                                                    <asp:Label ID="lblMenuCss" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"PartnerName")%>' />
                                                </td>
                                                <td style="width: 10%; text-align: left;">
                                                    <asp:Label ID="lblMenuParentcode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"SubjectName")%>' />
                                                </td>
                                                <td style="text-align: left;">
                                                    <asp:Label ID="lblmenutype" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"ShortName")%>' />
                                                </td>
                                            </ItemTemplate>
                                        </asp:DataList>
                                        <table cellpadding="3" class="table table-striped table-bordered table-condensed">
                                            <tr>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 15%;">
                                                                <asp:Label runat="server" ID="Label15">Remarks</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 80%;">
                                                                <asp:TextBox ID="TxtRemarks_ForTeacher" runat="server" TextMode="MultiLine" Width="300px"
                                                                    ReadOnly="True"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                        <table cellpadding="3" class="table table-striped table-bordered table-condensed">
                                        <%--<tr id="TRTeacher" runat ="server" visible ="false">
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td class="span2" style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="lblHeaderTeacher1">Approved By</asp:Label>
                                                            </td>
                                                            <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label runat="server" ID="lblTeachApproved" CssClass="blue" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="lblHeaderTeacher2">Approved On</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label runat="server" ID="lblTeachApprovedOn" class="blue"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="lblHeaderTeacher3">Remarks</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label runat="server" ID="lblTeachLevelRemark" CssClass="blue" />
                                                                
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
                                                                <asp:Label ID="Label14" runat="server">Requisition No.</asp:Label>
                                                            </td>
                                                            <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label ID="lblrequisitionNo" runat="server" Text=""></asp:Label>
                                                                <span id="Flag_TCHApproved" runat="server" visible="false" class="label label-important arrowed">
                                                                    Approved</span>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                        runat="server" id="Table7">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label17" runat="server">Requisition Date</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left">
                                                                <asp:Label ID="lblrequisitionDateforTech" runat="server" Text=""></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                        runat="server" id="Table9">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label36" runat="server">Request By</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left">
                                                                <asp:Label ID="lblRequstbyforTech" runat="server" Text=""></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                        runat="server" id="Table15">

                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label16" runat="server" CssClass="red">Status</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left">
                                                                <asp:DropDownList ID="ddlstatusfortech" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Status" Width="215px">
                                                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                                                    <asp:ListItem Value="1">Pending</asp:ListItem>
                                                                    <asp:ListItem Value="2">Approved</asp:ListItem>
                                                                    <asp:ListItem Value="3">Rejected At Approval</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label19">Date</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label runat="server" ID="lbldate2fortech" class="blue"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label23">Remarks</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:TextBox ID="TextBox1" runat="server" Width="200px"></asp:TextBox>
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
                                <asp:Button class="btn btn-app btn-primary  btn-mini radius-4" runat="server" ID="btnSave_forTeacher"
                                    Text="Save" ToolTip="Save" ValidationGroup="UcValidateSearch" OnClick="btnSave_forTeacher_Click" />
                                <asp:Button class="btn btn-app btn-grey btn-mini radius-4" ID="btncancel_forTeacher"
                                    Visible="true" runat="server" Text="Close" OnClick="btncancel_forTeacher_Click" />
                                <asp:ValidationSummary ID="ValidationSummary3" ShowSummary="false" DisplayMode="List"
                                    ShowMessageBox="true" ValidationGroup="UcValidateSearch" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div id="div_Employee" visible="false" runat="server">
                <div class="widget-box">
                    <div class="widget-header widget-header-small header-color-dark">
                        <h5>
                            Item Request Approval for Employee
                        </h5>
                    </div>
                    <div class="widget-body">
                        <div class="widget-body-inner">
                            <div class="widget-main">
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <%--<table cellpadding="2" class="table table-striped table-bordered table-condensed">
                                            <tr>
                                                <td class="span6" style="text-align: left" >
                                                    <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                        <tr>
                                                            <td class="span2" style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label18" runat="server">Division/Function</asp:Label>
                                                            </td>
                                                            <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlDiv_Function_ForEmp" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Division" Width="215px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span6" style="text-align: left" >
                                                    <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                        <tr>
                                                            <td class="span2" style="border-style: none; text-align: left; width: 40%;">
                                                               
                                                            </td>
                                                            <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                              
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
                                                                <asp:Label ID="Label22" runat="server">Employee Name</asp:Label>
                                                            </td>
                                                            <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                                     <asp:TextBox ID="txtEmployeeNM" runat="server" Text="" Width="205px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span6" style="text-align: left">
                                               <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                        <tr>
                                                            <td class="span2" style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label20" runat="server">Employee Code</asp:Label>
                                                            </td>
                                                            <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                                 <asp:TextBox ID="txtEmployeeCode" runat="server" Text="" Width="205px"></asp:TextBox>
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
                                                                <asp:Label ID="Label31" runat="server">Email-Id</asp:Label>
                                                            </td>
                                                            <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                                     <asp:TextBox ID="txtEmailid" runat="server" Text="" Width="205px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span6" style="text-align: left">
                                                 <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                        <tr>
                                                            <td class="span2" style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label32" runat="server">Status</asp:Label>
                                                            </td>
                                                            <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                               <asp:DropDownList ID="ddlstatus" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Status" Width="215px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                              
                                            </tr>
                                              <tr>
                                  
                                                 <td style="border-style: none; text-align: left; width: 20%;">
                                                                <asp:Label runat="server" ID="Label33">Remarks</asp:Label>
                                                            </td>
                                                 <td style="border-style: none; text-align: left; width: 80%;">
                                                                <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                            </td>
                                       
                                                </tr>
                                        </table>--%>
                                        <table cellpadding="2" class="table table-striped table-bordered table-condensed">
                                            
                                            <tr>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                        <tr>
                                                            <td class="span2" style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label32" runat="server">Division or Function</asp:Label>
                                                            </td>
                                                            <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label ID="lbldivisionforEMP" runat="server" Text=""></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                        runat="server" id="Table16">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label34" runat="server">Open days</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left">
                                                                <asp:Label ID="lblOpendaysForEMP" runat="server" Text=""></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                        runat="server" id="Table17">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label40" runat="server">Employee Name</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left">
                                                                <asp:Label ID="lblEmployeenmforEMP" runat="server" Text=""></asp:Label>
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
                                                                <asp:Label ID="Label38" runat="server">Employee Code</asp:Label>
                                                            </td>
                                                            <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label ID="lblemployeeCodeForEMP" runat="server" Text=""></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                        runat="server" id="Table18">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label44" runat="server">Email Id</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left">
                                                                <asp:Label ID="lblEmailidForEMP" runat="server" Text=""></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                        runat="server" id="Table19">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label46" runat="server">Employee Status</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left">
                                                                <asp:Label ID="lblEmpstatusForEMP" runat="server" Text=""></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                        <table cellpadding="3" class="table table-striped table-bordered table-condensed">
                                          <tr>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                        <tr>
                                                            <td class="span2" style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label20" runat="server">Requisition No.</asp:Label>
                                                            </td>
                                                            <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label ID="lblrequsitionforEMP" runat="server" Text=""></asp:Label>
                                                                <span id="Flag_EMPApproved" runat="server" visible="false" class="label label-important arrowed">
                                                                    Approved</span>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                        runat="server" id="Table8">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label24" runat="server">Requisition Date</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left">
                                                                <asp:Label ID="lblrequisitonDateforEMP" runat="server" Text=""></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                        runat="server" id="Table10">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label30" runat="server">Request By</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left">
                                                                <asp:Label ID="lblrequstbtForEMP" runat="server" Text=""></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                          
                                            <tr>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                        runat="server" id="Table20">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label25" runat="server" CssClass="red">Status</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left">
                                                                <asp:DropDownList ID="ddlstatusForEMP" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Status" Width="215px">
                                                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                                                    <asp:ListItem Value="1">Pending</asp:ListItem>
                                                                    <asp:ListItem Value="2">Approved</asp:ListItem>
                                                                    <asp:ListItem Value="3">Rejected At Approval</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td class="span2" style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label27">Date</asp:Label>
                                                            </td>
                                                            <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label runat="server" ID="lbl_DateForEMP" class="blue"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td class="span2" style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label29">Remarks</asp:Label>
                                                            </td>
                                                            <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label runat="server" ID="lbl_RemarksForEMP" Text="" CssClass="blue" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="btncancel_forTeacher" />
                                        <asp:PostBackTrigger ControlID="btnCancel_forEMP" />
                                        <asp:PostBackTrigger ControlID="btnClose_FotStudent" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                            <div class="widget-main alert-block alert-info" style="text-align: center;">
                                <asp:Button class="btn btn-app btn-primary  btn-mini radius-4" runat="server" ID="btnSave_ForEmp"
                                    Text="Save" ToolTip="Save" ValidationGroup="UcValidateSearch" OnClick="btnSave_ForEmp_Click" />
                                <asp:Button class="btn btn-app btn-grey btn-mini radius-4" ID="btnCancel_forEMP"
                                    Visible="true" runat="server" Text="Close" OnClick="btnCancel_forEMP_Click" />
                                <asp:ValidationSummary ID="ValidationSummary4" ShowSummary="false" DisplayMode="List"
                                    ShowMessageBox="true" ValidationGroup="UcValidateSearch" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
