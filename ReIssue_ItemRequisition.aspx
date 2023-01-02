<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="ReIssue_ItemRequisition.aspx.cs" Inherits="ReIssue_ItemRequisition" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
<script type="text/javascript">
    function table() {

        $(".Table2").dataTable({
            sPaginationType: "bootstrap",
            aLengthMenu: [
                    [10, 20, 50, -1],
                    [10, 20, 50, "All"] // change per page values here
                ],
            iDisplayLength: 10,
            oLanguage: {
                sProcessing: '<i class="fa fa-coffee"></i>&nbsp;Please wait...',
                sLengthMenu: "_MENU_ records",
                oPaginate: {
                    "sPrevious": "Prev",
                    "sNext": "Next"
                }
            },
            //sLoadingRecords: "Please wait - loading...",
            //                oLanguage: { sProcessing: "DataTables is currently busy" },
            aoColumnDefs: [{
                bSortable: false,
                aTargets: [6]
            }
                ]

        });
    }
    function table1() {

        $(".Table4").dataTable({
            sPaginationType: "bootstrap",
            aLengthMenu: [
                    [10, 20, 50, -1],
                    [10, 20, 50, "All"] // change per page values here
                ],
            iDisplayLength: 10,
            oLanguage: {
                sProcessing: '<i class="fa fa-coffee"></i>&nbsp;Please wait...',
                sLengthMenu: "_MENU_ records",
                oPaginate: {
                    "sPrevious": "Prev",
                    "sNext": "Next"
                }
            },
            //sLoadingRecords: "Please wait - loading...",
            //                oLanguage: { sProcessing: "DataTables is currently busy" },
            aoColumnDefs: [{
                bSortable: false,
                aTargets: [0]
            }
                ]

        });
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
                <h4 class="blue">
                   ReIssue Item Requisition<span class="divider"></span></h4>
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
                                <asp:UpdatePanel ID="UpdatePanelSearch" runat="server">
                                    <ContentTemplate>
                                        <table cellpadding="2" class="table table-striped table-bordered table-condensed">
                                            <tr>
                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                        <tr>
                                                            <td class="span2" style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label1" runat="server" CssClass="red">User Type</asp:Label>
                                                            </td>
                                                            <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlUserType" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select User Type" Width="215px" OnSelectedIndexChanged="ddlUserType_SelectedIndexChanged" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span6" style="text-align: left">
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
                                            </tr>
                                            <tr>
                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                        runat="server" id="tblgodown">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label3" runat="server">Period</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left">
                                                                <input id="id_date_range_picker_2" runat="server" class="id_date_range_picker_1"
                                                                    data-original-title="Date Range" data-placement="bottom" name="date-range-picker"
                                                                    placeholder="Date Search" readonly="readonly" style="width: 205px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                        runat="server" id="Table1">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label5" runat="server">Order No.</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left">
                                                                <asp:TextBox ID="txtOrderNo" runat="server" Text="" Width="205px"></asp:TextBox>
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
                <table cellpadding="3" class="table table-striped table-bordered table-condensed">
                    <tr>
                        <td class="span4" style="text-align: left">
                            <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                <tr>
                                    <td style="border-style: none; text-align: left; width: 40%;">
                                        <asp:Label runat="server" ID="Label18">User Type</asp:Label>
                                    </td>
                                    <td style="border-style: none; text-align: left; width: 60%;">
                                        <asp:Label runat="server" ID="lblUserType_SR" CssClass="blue" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="span4" style="text-align: left">
                            <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                <tr>
                                    <td style="border-style: none; text-align: left; width: 40%;">
                                        <asp:Label runat="server" ID="Label28">Division</asp:Label>
                                    </td>
                                    <td style="border-style: none; text-align: left; width: 60%;">
                                        <asp:Label runat="server" ID="lblDivision_SR" CssClass="blue" />
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
                                        <asp:Label runat="server" ID="Label35">Period</asp:Label>
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
                                        <asp:Label runat="server" ID="Label45">Order No</asp:Label>
                                    </td>
                                    <td style="border-style: none; text-align: left; width: 60%;">
                                        <asp:Label runat="server" ID="lblOrderNo" class="blue"></asp:Label>
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
                                    <th style="width: 16%; text-align: center;">
                                        Division / Function
                                    </th>
                                    <th style="width: 11%; text-align: center;">
                                        Requisition Date
                                    </th>
                                    <th style="width: 25%; text-align: center;">
                                        Requisition Raised By
                                    </th>
                                    <th style="width: 12%; text-align: center;">
                                        Quantity
                                    </th>
                                    <th style="width: 12%; text-align: center;">
                                        Status
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
                                <asp:Label ID="lblMenuCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Request_code")%>' />
                            </td>
                            <td style="text-align: center;">
                                <asp:Label ID="Label34" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"DIV")%>' />
                            </td>
                            <td style="text-align: center;">
                                <asp:Label ID="lblMenuName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Request_Date")%>' />
                            </td>
                            <td style="text-align: center;">
                                <asp:Label ID="lblMenuCss" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"User_Display_Name")%>' />
                            </td>
                            <td style="text-align: center;">
                                <asp:Label ID="lblMenuParentcode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"quantity")%>' />
                            </td>
                            <td style="text-align: center;">
                                <asp:Label ID="lblmenutype" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Request_Status")%>' />
                            </td>
                            <td style="text-align: center;">
                                <div class="inline position-relative">
                                    <asp:LinkButton ID="lnkEdit" ToolTip="Edit" class="btn-small btn-primary icon-info-sign"
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
                        <th style="width: 25%; text-align: center;">
                            Requisition Raised By
                        </th>
                        <th style="width: 15%; text-align: center;">
                            Quantity
                        </th>
                        <th style="width: 15%; text-align: center;">
                        Status
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblMenuCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Request_code")%>' />
                        </td>
                        <td style="width: 12%; text-align: left;">
                            <asp:Label ID="Label36" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"DIV")%>' />
                        </td>
                        <td style="width: 12%; text-align: left;">
                            <asp:Label ID="lblMenuName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Request_Date")%>' />
                        </td>
                        <td style="width: 12%; text-align: left;">
                            <asp:Label ID="lblMenuCss" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"User_Display_Name")%>' />
                        </td>
                        <td style="width: 10%; text-align: left;">
                            <asp:Label ID="lblMenuParentcode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"quantity")%>' />
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="lblmenutype" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Request_Status")%>' />
                        </td>
                    </ItemTemplate>
                </asp:DataList>
            </div>
            <div id="div_student" visible="false" runat="server">
                <div class="widget-box">
                    <div class="widget-header widget-header-small header-color-dark">
                        <h5>
                            New Requisition for Student
                            <asp:Label ID="lblPkey" runat="server" Text="" Visible="false"></asp:Label>
                            <asp:Label ID="lblUserType" runat="server" Text="" Visible="false"></asp:Label>
                        </h5>
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
                                                                <asp:Label ID="Label6" runat="server" ForeColor="Red">Division</asp:Label>
                                                            </td>
                                                            <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlDivisionforStudent" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Division" Width="215px" OnSelectedIndexChanged="ddlDivisionforStudent_SelectedIndexChanged" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                        runat="server" id="Table4">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label10" runat="server" ForeColor="Red">Acad Year</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left">
                                                                <asp:DropDownList ID="ddlacadyr_frStud" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Acad Year" Width="215px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                        runat="server" id="Table2">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label7" runat="server" ForeColor="Red">Center</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left">
                                                                <asp:DropDownList ID="ddlcenter_forStudent" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Center" Width="215px" OnSelectedIndexChanged="ddlcenter_forStudent_SelectedIndexChanged" />
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
                                                                <asp:Label ID="Label8" runat="server" ForeColor="Red">Classroom Product</asp:Label>
                                                            </td>
                                                            <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlClassrmProd_frStud" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select ClassRoom Product" Width="215px" 
                                                                    onselectedindexchanged="ddlClassrmProd_frStud_SelectedIndexChanged" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                        runat="server" id="Table3">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label9" runat="server" ForeColor="Red">Material Name</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left">
                                                               <asp:DropDownList ID="ddlIteamName_ForStudent" runat="server" AutoPostBack="True"
                                                                    CssClass="chzn-select" data-placeholder="Select Item Name" Width="215px"  
                                                                     />
                                                                   <%-- <asp:ListBox runat="server" ID="ddlIteamName_ForStudent" Width="215px" ToolTip="Standard" data-placeholder="Select Item Name"
                                                                    SelectionMode="Multiple" CssClass="chzn-select" AutoPostBack="true" />--%>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                        runat="server" id="Table5">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Button class="btn  btn-app btn-primary btn-mini radius-4" Visible="true" runat="server"
                                                                    ID="btnshow" Text="Show" OnClick="btnshow_Click" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            
                                            </table>
                                               <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                             <table cellpadding="2"  class="table table-striped table-bordered table-condensed">
                                   <tr id="student" runat="server" visible="false">
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                        <tr>
                                                            <td class="span2" style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label37" runat="server" >Student Name</asp:Label>
                                                            </td>
                                                            <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                        <asp:TextBox ID="txtstudentName" runat="server" Text="" Width="205px" AutoPostBack="true" 
                                                                    ontextchanged="txtstudentName_TextChanged"></asp:TextBox>
                                                        
                                                    </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                        runat="server" id="Table6">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label38" runat="server">Sbentry Code</asp:Label>
                                                            </td>
                                                          <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                        <asp:TextBox ID="txtsbentrycode" runat="server" Text="" Width="205px"  AutoPostBack="true"
                                                                  ontextchanged="txtsbentrycode_TextChanged"></asp:TextBox>
                                                        &nbsp;
                                                    </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                        runat="server" id="Table11">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Button class="btn  btn-app btn-primary btn-mini radius-4" Visible="false" runat="server"
                                                                    ID="searchstudent" Text="Search" onclick="searchstudent_Click"  />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            
                                        </table>
                                         
                                        
                                       <div class="widget-box">
                                         <div class="table-header" id="total" runat="server" visible="false">
                                           <table width="100%" >
                                            <tr>
                                                <td class="span10">
                                                    Total No of Records:
                                                    <asp:Label runat="server" ID="lbltotalrecords" Text="0" />
                                                </td>
                                                <td style="text-align: right" class="span2">
                                    
                                                </td>
                                            </tr>
                                        </table>
                                        </div>
                                        </div>
                                       <asp:Repeater ID="datalist_Student" runat="server" OnItemCommand="dlGridDisplay_ItemCommand">
                                        <HeaderTemplate>
                                            <table class="table table-striped table-bordered table-hover Table2">
                                                <thead>
                                                    <tr>
                                                    <th>
                                                    <asp:CheckBox ID="chkAttendanceAll" runat="server" AutoPostBack="True" OnCheckedChanged="chkAttendanceAll_CheckedChanged" />
                                                                    <span class="lbl"></span></th>
                                                        <th>
                                                                SBEntrycode
                                                        </th>
                                                        <th style="width: 16%; text-align: center;">
                                                            Student Name
                                                        </th>
                                                
                                                        <th style="width: 15%; text-align: center;">
                                                            Center Name
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
                                                            <th style="width: 07%; text-align: center;">
                                                            Status
                                                        </th>
                                                        <th style="width: 25%; text-align: center;">
                                                            Subject Group
                                                        </th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                        <tr>
                                        <td>
                                            <asp:CheckBox ID="chkCheck" runat="server"     />
                                                    <span class="lbl"></span></td>
                                                <td>
                                                        <asp:Label ID="lblStudentCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"SBEntrycode")%>' />
                                                </td>
                                                    <td style="text-align: left;">
                                                    <asp:Label ID="lblMenuName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"StudentName")%>' />
                                                </td>
                                                    <td style="text-align: left;">
                                                    <asp:Label ID="Label39" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Source_Center_Name")%>' />
                                                </td>
                                                <td style="text-align: left;">
                                                    <asp:Label ID="lblMenuCss" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"netFees")%>' />
                                                </td>
                                                <td style="text-align: left;">
                                                    <asp:Label ID="lblMenuParentcode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"feesRecd")%>' />
                                                </td>
                                                <td style="text-align: left;">
                                                    <asp:Label ID="lblmenutype" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"ClearAmt")%>' />
                                                </td>
                                                    <td style="text-align: left;">
                                                    <asp:Label ID="Label40" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"status")%>' />
                                                </td>
                                                <td style="text-align: left;">
                                                    <asp:Label ID="Label2" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"SubjectGrp")%>' />
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </tbody> </table>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                         </ContentTemplate>
                                </asp:UpdatePanel>
                                        <table cellpadding="3" class="table table-striped table-bordered table-condensed">
                                            <tr>
                                                
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label12">Request By</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label runat="server" ID="lblRequestByforStud" class="blue"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td class="span2" style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label11">Date Requisition</asp:Label>
                                                            </td>
                                                            <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label runat="server" ID="lblDate" Text="" CssClass="blue" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label13">Requisition No.</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label runat="server" ID="lblRequisitionNo" Text="" CssClass="blue" />
                                                                <span id="Flag_Student" runat="server" visible="false" class="label label-important arrowed">
                                                                    <asp:Label ID="lbl_FlagStudent" runat="server" Text=""></asp:Label></span>
                                                                
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
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
                                            <tr id="TR1" runat ="server" visible ="false">
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td class="span2" style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="lblHeaderStud1">Authorised By</asp:Label>
                                                            </td>
                                                            <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label runat="server" ID="lblStudAuthorise" CssClass="blue" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="lblHeaderStud2">Authorised On</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label runat="server" ID="lblStudAuthorisedOn" class="blue"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="lblHeaderStud3">Remarks</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label runat="server" ID="lblStudAuthoriseRemark" CssClass="blue" />
                                                                
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
                                <asp:Button class="btn btn-app btn-primary  btn-mini radius-4" runat="server" ID="btnSaveEDit_ForStudent"
                                    Text="Save" ToolTip="Save" ValidationGroup="UcValidateSearch" OnClick="btnSaveEDit_ForStudent_Click" />
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
                            New Requisition for Teacher
                             </h5>
                    </div>
                    <div class="widget-body">
                        <div class="widget-body-inner">
                            <div class="widget-main">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <table cellpadding="2" class="table table-striped table-bordered table-condensed">
                                            <tr>
                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                        <tr>
                                                            <td class="span2" style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label14" runat="server" CssClass="red">Division</asp:Label>
                                                            </td>
                                                            <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlDivision_ForTeacher" runat="server" AutoPostBack="True"
                                                                    CssClass="chzn-select" data-placeholder="Select Division" Width="215px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                        runat="server" id="Table7">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label16" runat="server" CssClass="red">Acad Year</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left">
                                                                <asp:DropDownList ID="ddlacadyear_ForTeacher" runat="server" AutoPostBack="True"
                                                                    CssClass="chzn-select" data-placeholder="Select Acad Year" Width="215px" />
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
                                                                <asp:Label ID="Label17" runat="server">Teacher Name</asp:Label>
                                                            </td>
                                                            <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:TextBox ID="txtteacherName" runat="server" Width="200px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                        runat="server" id="Table9">
                                                        <tr>
                                                            <td class="span2" style="border-style: none; text-align: left;">
                                                                <asp:Button class="btn  btn-app btn-primary btn-mini radius-4" Visible="true" runat="server"
                                                                    ID="btnshow_ForTeacher" Text="Show" OnClick="btnshow_ForTeacher_Click" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                        <%--<asp:DataList ID="datalist_Teacher" CssClass="table table-striped table-bordered table-hover"
                                            runat="server" Width="100%" Visible="True">
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="ChkTeacherAll" runat="server" AutoPostBack="True" OnCheckedChanged="ChkTeacherAll_CheckedChanged" />
                                                <span class="lbl"></span></th>
                                                <th style="width: 15%; text-align: center;">
                                                    Teacher Code
                                                </th>
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
                                                <asp:CheckBox ID="chkCheck" runat="server" />
                                                <span class="lbl"></span></td>
                                                <td style="width: 12%; text-align: Center;">
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
                                        </asp:DataList>--%>
                                         <div class="widget-box">
                                         <div class="table-header" id="teacher" runat="server" visible="false">
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
                                       <asp:Repeater ID="datalist_Teacher" runat="server" OnItemCommand="dlGridDisplay_ItemCommand">
                                        <HeaderTemplate>
                                            <table class="table table-striped table-bordered table-hover Table2">
                                                <thead>
                                                    <tr>
                                                    <th>
                                               <asp:CheckBox ID="ChkTeacherAll" runat="server" AutoPostBack="True" OnCheckedChanged="ChkTeacherAll_CheckedChanged" />
                                                <span class="lbl"></span></th>
                                                <th style="width: 15%; text-align: center;">
                                                    Teacher Code
                                                </th>
                                                <th style="width: 25%; text-align: center;">
                                                    Teacher Name
                                                </th>
                                                <th style="width: 30%; text-align: center;">
                                                    Subject
                                                </th>
                                                <th style="width: 25%; text-align: center;">
                                                    Short Name
                                                </th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                        <tr>
                                        <td>
                                             <asp:CheckBox ID="chkCheck" runat="server" />
                                                <span class="lbl"></span></td>
                                                <td style="width: 12%; text-align: Center;">
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
                                            </tr>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </tbody> </table>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                        <table cellpadding="3" class="table table-striped table-bordered table-condensed">
                                            <tr>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 20%;">
                                                                <asp:Label runat="server" ID="Label15" CssClass="red">Remarks</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 80%;">
                                                                <asp:TextBox ID="TxtRemarks_ForTeacher" runat="server" TextMode="MultiLine" Width="250px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                        <table cellpadding="3" class="table table-striped table-bordered table-condensed">
                                            <tr>

                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label21">Requisition By</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label runat="server" ID="lblRequest_ByforTech" class="blue"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label19">Requisition Date</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label runat="server" ID="lblRequisition_DateforTech" Text="" CssClass="blue" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label23">Requisition No.</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label runat="server" ID="lblRequisition_No" Text="" CssClass="blue" />
                                                                <span id="Flag_Teacher" runat="server" visible="false" class="label label-important arrowed">
                                                                    <asp:Label ID="lbl_FlagTeacher" runat="server" Text=""></asp:Label></span>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                               <tr id="TRTeacher" runat ="server" visible ="false">
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td class="span2" style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="lblHeaderTeacher1">Approved By</asp:Label>
                                                            </td>
                                                            <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label runat="server" ID="lblApprovedBy" CssClass="blue" />
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
                                                                <asp:Label runat="server" ID="lblApprovedOn" class="blue"></asp:Label>
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
                                                                <asp:Label runat="server" ID="lblApprovedremark" CssClass="blue" />
                                                                
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr id="TRTeacher1" runat ="server" visible ="false">
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td class="span2" style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="lblHeaderTeach1">Authorised By</asp:Label>
                                                            </td>
                                                            <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label runat="server" ID="lblAuthorisedBy" CssClass="blue" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="lblHeaderTeach2">Authorised On</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label runat="server" ID="lblAuthorisedOn" class="blue"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="lblHeaderTeach3">Remarks</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label runat="server" ID="lblRemark" CssClass="blue" />
                                                                
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
                                <asp:Button class="btn btn-app btn-primary  btn-mini radius-4" runat="server" ID="btnSaveEdit_forTeacher"
                                    Text="Save" ToolTip="Save" ValidationGroup="UcValidateSearch" OnClick="btnSaveEdit_forTeacher_Click" />
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
                        New Requisition for Employee
                    </div>
                    <div class="widget-body">
                        <div class="widget-body-inner">
                            <div class="widget-main">
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <table cellpadding="3" class="table table-striped table-bordered table-condensed">
                                            <tr>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover">
                                                        <tr>
                                                            <td class="span2" style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label26" runat="server" CssClass="red">Location Type</asp:Label>
                                                            </td>
                                                            <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlLocationType" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Location Type" Width="215px" OnSelectedIndexChanged="ddlLocationType_SelectedIndexChanged" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                        runat="server" id="tblFr_Division" visible="false">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label31" runat="server" CssClass="red">Division Name</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlDiv_Function_ForEmp" runat="server" AutoPostBack="True"
                                                                    CssClass="chzn-select" data-placeholder="Select Division" Width="215px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                        runat="server" id="tblFr_Function" visible="false">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label33" runat="server" CssClass="red">Function Name</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlFunctionFR_SR" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Function" Width="215px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                        <table cellpadding="2" class="table table-striped table-bordered table-condensed">
                                            <tr>
                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                        <tr>
                                                            <td class="span2" style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label22" runat="server" CssClass="red">Employee Name</asp:Label>
                                                            </td>
                                                            <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:TextBox ID="txtEmployeeNM" runat="server" Text="" Width="205px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                        runat="server" id="Table8">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label24" runat="server" CssClass="red">Employee Code</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left">
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
                                                                <asp:Label ID="Label32" runat="server">Email Id</asp:Label>
                                                            </td>
                                                            <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:TextBox ID="txtEmailid" runat="server" Text="" Width="205px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                        runat="server" id="Table10">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label20" runat="server" CssClass="red">Status</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left">
                                                                <asp:DropDownList ID="ddlstatus" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Status" Width="215px">
                                                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                                                    <asp:ListItem Value="1">Permanant</asp:ListItem>
                                                                    <asp:ListItem Value="2">Visiting</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                        <table cellpadding="3" class="table table-striped table-bordered table-condensed">
                                            <tr>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 20%;">
                                                                <asp:Label runat="server" ID="Label30" CssClass="red">Remarks</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 80%;">
                                                                <asp:TextBox ID="txtremarks_ForEmployee" runat="server" TextMode="MultiLine" Width="250px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                            </tr>
                                        </table>
                                        <table cellpadding="3" class="table table-striped table-bordered table-condensed">
                                            <tr>
                                              
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td class="span2" style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label27">Requisition By</asp:Label>
                                                            </td>
                                                            <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label runat="server" ID="lbl_Requisition_ByforTech" class="blue"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                  <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td class="span2" style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label25">Requisition Date</asp:Label>
                                                            </td>
                                                            <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label runat="server" ID="lbl_Requisition_DateforEmpl" Text="" CssClass="blue" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td class="span2" style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label29">Requisition No.</asp:Label>
                                                            </td>
                                                            <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label runat="server" ID="lbl_Requisition_No" Text="" CssClass="blue" />
                                                                <span id="Flag_Employee" runat="server" visible="false" class="label label-important arrowed">
                                                                    <asp:Label ID="lbl_FlagEmployee" runat="server" Text=""></asp:Label></span>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr id="TREmployee" runat ="server" visible ="false">
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td class="span2" style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="lblHeaderEmployee1">Approved By</asp:Label>
                                                            </td>
                                                            <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label runat="server" ID="lblEmployeeApprovedBy" CssClass="blue" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="lblHeaderEmployee2">Approved On</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label runat="server" ID="lblEmployeeApprovedOn" class="blue"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="lblHeaderEmployee3">Remarks</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label runat="server" ID="lblEmployeeRemark" CssClass="blue" />
                                                                
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr id="TREmployee1" runat ="server" visible ="false">
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td class="span2" style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="lblHeaderEmp1">Authorised By</asp:Label>
                                                            </td>
                                                            <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label runat="server" ID="lblEmpApprovedBy" CssClass="blue" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="lblHeaderEmp2">Authorised On</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label runat="server" ID="lblEmpApprovedOn" class="blue"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="lblHeaderEmp3">Remarks</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label runat="server" ID="lblEmpRemark" CssClass="blue" />
                                                                
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
                                        <asp:PostBackTrigger ControlID="btnshow" />
                                        <asp:PostBackTrigger ControlID="searchstudent" />
                                        <asp:PostBackTrigger ControlID="txtstudentName" />
                                        <asp:PostBackTrigger ControlID="txtsbentrycode" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                            <div class="widget-main alert-block alert-info" style="text-align: center;">
                                <asp:Button class="btn btn-app btn-primary  btn-mini radius-4" runat="server" ID="btnSave_ForEmp"
                                    Text="Save" ToolTip="Save" ValidationGroup="UcValidateSearch" OnClick="btnSave_ForEmp_Click" />
                                <asp:Button class="btn btn-app btn-primary  btn-mini radius-4" runat="server" ID="btnSaveEdit_ForEmp"
                                    Text="Save" ToolTip="Save" ValidationGroup="UcValidateSearch" OnClick="btnSaveEdit_ForEmp_Click" />
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
    <!--/row-->
</asp:Content>
