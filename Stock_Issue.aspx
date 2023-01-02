<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="Stock_Issue.aspx.cs" Inherits="Stock_Issue" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">

        function openModalDivOverride() {
            $('#DivOverrid').modal({
                backdrop: 'static'
            })

            $('#DivOverrid').modal('show');
        }

        function openModalDivUser() {
            $('#DivUserDetail').modal({
                backdrop: 'static'
            })

            $('#DivUserDetail').modal('show');
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
                <h5 class="blue">
                    Stock Issue<span class="divider"></span></h5>
            </li>
        </ul>
        <div id="nav-search">
            <!-- /btn-group -->  
            <asp:Button class="btn  btn-app btn-success btn-mini radius-4" runat="server" ID="BtnAdd"
                Text="Add" OnClick="BtnAdd_Click" />          
            <asp:Button class="btn  btn-app btn-primary btn-mini radius-4  " Visible="true" runat="server"
                ID="BtnShowSearchPanel" Text="Search" onclick="BtnShowSearchPanel_Click" />

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
                                                                <asp:Label ID="Label13" runat="server">Requisition No</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:TextBox ID="txtRequestCode" runat="server" Text="" Width="205px"></asp:TextBox>
                                                                <%--<input id="date_range_SR" runat="server" class="id_date_range_picker_1" data-original-title="Date Range"
                                                                    data-placement="bottom" name="date-range-picker" placeholder="Date Search" readonly="readonly"
                                                                    style="width: 205px" />--%>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                   <%-- <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                            </td>
                                                        </tr>
                                                    </table>--%>
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
                                    Text="Search" ToolTip="Search" ValidationGroup="UcValidateSearch" 
                                    onclick="BtnSearch_Click" />
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
                                        Height="25px" onclick="HLExport_Click" Visible="false" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
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
                                        <asp:Label runat="server" ID="Label11" Visible="false">Location</asp:Label>
                                    </td>
                                    <td style="border-style: none; text-align: left; width: 60%;">
                                        <asp:Label runat="server" ID="lblLocationResult" class="blue" Visible="false"></asp:Label>
                                        <asp:Label runat="server" ID="lblPeroidResult" Visible="false" Text="" CssClass="blue" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <%--<tr>
                        <td class="span6" style="text-align: left">
                            <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                <tr>
                                    <td style="border-style: none; text-align: left; width: 40%;">
                                        <asp:Label runat="server" ID="Label1" >Period</asp:Label>
                                    </td>
                                    <td style="border-style: none; text-align: left; width: 60%;">
                                        <asp:Label runat="server" ID="lblPeroidResult"  Text="" CssClass="blue" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="span6" style="text-align: left">                           
                        </td>
                    </tr>--%>
                </table>

                <asp:DataList ID="dlGridDisplay" CssClass="table table-striped table-bordered table-hover"
                    runat="server" Width="100%" OnItemCommand="dlGridDisplay_ItemCommand">
                    <HeaderTemplate>
                        <b>Location</b> </th>
                        <th align="left">
                            Voucher No
                        </th>
                        <th align="left">
                            Request Code
                        </th>
                        <th align="left">
                            User Type
                        </th>
                        <th align="left">
                           Action  
                    </HeaderTemplate>
                    <ItemTemplate>
                            <asp:Label ID="lblLocation" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Location")%>' />
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="lblVoucherNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Voucher_Code")%>' />
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="lblRequest_Code" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Request_Code")%>' />
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="lblUserType" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"UserType")%>' />
                        </td>
                        <td style="text-align: left;">
                            <asp:LinkButton ID="lnkEditInfo" ToolTip="Edit" class="btn-small btn-primary icon-info-sign"
                                CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Voucher_Code")%>' runat="server"
                                CommandName="Edit" />
                            <asp:LinkButton ID="lnkAuthorise" ToolTip="Authorise" class="btn-small btn-warning  icon-lock"
                                CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Voucher_Code")%>' runat="server"
                                CommandName="Authorise" Visible='<%#(int)DataBinder.Eval(Container.DataItem,"ShowAuthoriseButtonFlag") == 0 ? true : false%>'  /> 
                        </td>
                    </ItemTemplate>
                </asp:DataList>

                <%--<asp:DataList ID="dlGridDisplay" CssClass="table table-striped table-bordered table-hover"
                    runat="server" Width="100%">
                    <HeaderTemplate>
                        <b>Voucher No</b> </th>
                        <th align="left">
                            Issue Date
                        </th>
                        <th align="left">
                            Item Code
                        </th>
                        <th align="left">
                            Item Name
                        </th>
                        <th align="left">
                           Issued to Type
                        </th>
                        <th align="left">
                            User Name
                        </th>
                        <th align="left">
                            Status
                        </th>
                        <th align="left">
                            Expect Return Date
                         </th>
                        <th align="left">
                            Return Status
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblVoucherNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Voucher_No")%>' />
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="lblIssueDate" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Issue_Date")%>' />
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="lblItemCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Item_Code")%>' />
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="lblItemName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Item_Name")%>' />
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="lblIssuedToType" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"IssuedToType")%>' />
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="lblUserName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"UserName")%>' />
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="lblStatus" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Status")%>' />
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="lblExpectReturnDate" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Expect_Return_Date")%>' />
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="lblReturnStatus" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Return_Status")%>' />
                        </td>
                    </ItemTemplate>
                </asp:DataList>--%>


            </div>

            <div id="DivAddPanel" runat="server" visible="false">
                <div class="widget-box">
                    <div class="widget-header widget-header-small header-color-dark">
                        <h5 class="modal-title">
                            Stock Issue                            
                        </h5>
                    </div>
                    <div class="widget-body">
                        <div class="widget-body-inner">
                            <div class="widget-main">
                                <asp:UpdatePanel ID="UpdatePanelAdd" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                    <div class="row-fluid">
                                        <table cellpadding="3" class="table table-striped table-bordered table-condensed">
                                            <tr>
                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label19">Location Type</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label ID="lblAddPanelLocationTypeResult" runat="server" CssClass="blue"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label21">Location</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label ID="lblAddPanelLocationResult" runat="server" CssClass="blue"></asp:Label>
                                                                <asp:Label ID="lblAddPanelLocationCodeResult" runat="server" CssClass="blue" Visible="false"></asp:Label>
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
                                                                <asp:Label runat="server" ID="Label3">Requisition No</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlrequi_No" runat="server" CssClass="chzn-select" data-placeholder="Select Requi. No"
                                                                    Width="160px" AutoPostBack ="true" 
                                                                    onselectedindexchanged="ddlrequi_No_SelectedIndexChanged" />
                                                                <button runat="server" class="btn btn-info btn-small" style="height: 28px" id="btnRequi_Search"
                                                                    onserverclick="btnRequi_Search_Click" type="button" visible="false"> <!--onserverclick="btnRequi_Search_Click"-->
                                                                    <i class="icon-search icon-on-right"></i>
                                                                </button>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label8">User Type</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label runat="server" ID="lblUserType" CssClass="blue"></asp:Label>
                                                                <asp:Label runat="server" ID="lblUserTypeCode" Visible="false"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>   
                                   
                                        <div id="div_student" runat="server">
                                            <div class="widget-box">
                                                <div class="widget-header widget-header-small header-color-dark">
                                                    <h5>
                                                        Stock Issue Detail for Student
                                                    </h5>
                                                </div>
                                                <div class="widget-body">
                                                    <div class="widget-body-inner">
                                                        <div class="widget-main">
                                                            <asp:DataList ID="datalist_Student" CssClass="table table-striped table-bordered table-hover"
                                                                runat="server" Width="100%" Visible="True">
                                                                <HeaderTemplate>
                                                                    <b></b></th>
                                                                    <th style="width: 20%; text-align: center;">
                                                                        Student Name
                                                                    </th>
                                                                    <th style="width: 10%; text-align: center;">
                                                                        Net Fees
                                                                    </th>
                                                                    <th style="width: 10%; text-align: center;">
                                                                        Fees Received
                                                                    </th>
                                                                    <th style="width: 20%; text-align: center;">
                                                                        Cleared Amount
                                                                    </th>
                                                                    <th style="width: 20%; text-align: center;">
                                                                        Subject Group
                                                                    </th>
                                                                    <th style="width: 20%; text-align: center;">
                                                                        Material
                                                                    </th>
                                                                    
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="chkCheck" runat="server" />
                                                                    <span class="lbl"></span></td>
                                                                    <td style="width: 12%; text-align: left;">
                                                                        <asp:Label ID="lblstudnNm" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"StudentName")%>' />
                                                                        <asp:Label ID="lblrequCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Request_Code")%>' Visible="false"/>
                                                                        <asp:Label ID="lblRequest_EntryCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Request_EntryCode")%>' Visible="false"/>
                                                                        <asp:Label ID="lblUserCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"UserCode")%>' Visible="false"/>
                                                                        <asp:Label ID="lblInwardEntryCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"InwardEntry_Code")%>' Visible="false"/>                                                                        
                                                                        <asp:Label ID="lblItemCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Item_Code")%>' Visible="false" />
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
                                                                    <td style="text-align: left;">
                                                                        <asp:Label ID="Label12" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Item_Name")%>' />
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
                                                    <h5>
                                                        Stock Issue Detail for Teacher
                                                    </h5>
                                                </div>
                                                <div class="widget-body">
                                                    <div class="widget-body-inner">
                                                        <div class="widget-main">
                                                            <asp:DataList ID="datalist_Teacher" CssClass="table table-striped table-bordered table-hover"
                                                                runat="server" Width="100%" Visible="True">
                                                                <HeaderTemplate>
                                                                    <b></b></th>
                                                                    <th style="width: 12%; text-align: center;">
                                                                        Teacher Code
                                                                    </th>
                                                                    <th style="width: 22%; text-align: center;">
                                                                        Teacher Name
                                                                    </th>
                                                                    <th style="width: 25%; text-align: center;">
                                                                        Subject
                                                                    </th>
                                                                    <th style="width: 15%; text-align: center;">
                                                                        Short Name
                                                                    </th>
                                                                    <th style="width: 20%; text-align: center;">
                                                                        Material Name
                                                                    </th>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="chkCheck" runat="server" />
                                                                    <span class="lbl"></span></td>
                                                                    <td style="width: 12%; text-align: left;">
                                                                        <asp:Label ID="lblPartnerCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Partner_code")%>' />
                                                                        <asp:Label ID="lblrequCode_TH" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Request_Code")%>' Visible="false"/>
                                                                        <asp:Label ID="Request_EntryCode_TH" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Request_EntryCode")%>' Visible="false"/>
                                                                        <asp:Label ID="lblUserCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"UserCode")%>' Visible="false"/>
                                                                        <asp:Label ID="lblInwardEntryCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"InwardEntry_Code")%>' Visible="false"/>                                                                        
                                                                        <asp:Label ID="lblItemCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Item_Code")%>' Visible="false" />
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
                                                                    <td style="text-align: left;">
                                                                        <asp:Label ID="Label12" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Item_Name")%>' />
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
                                                    <h5>
                                                        Stock Issue Detail for Employee
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
                                                                                <td class="span2" style="border-style: none; text-align: left; width: 40%;">
                                                                                    <asp:Label runat="server" ID="Label10">Item</asp:Label>
                                                                                    <asp:Label ID="lblRequ_CodeforEmp" runat="server" Text="" Visible="false"></asp:Label>
                                                                                    <asp:Label ID="lblRequ_EntryCodeforEMP" runat="server" Text="" Visible="false"></asp:Label>
                                                                                    <asp:Label ID="lblEmp_ItemCode" runat="server" Text="" Visible="false"></asp:Label>
                                                                                    <asp:Label ID="lblEmp_InwardEntryCode" runat="server" Text="" Visible="false"></asp:Label>
                                                                                </td>
                                                                                <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                                                    <asp:Label runat="server" ID="lblRequ_EmpItmeName" Text="" CssClass="blue" />
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
                                        <asp:PostBackTrigger ControlID = "btnRequi_Search" />
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

            <div id="DivEditPanel" runat="server" visible="false">
                <div class="widget-box">
                    <div class="widget-header widget-header-small header-color-dark">
                        <h5 class="modal-title">
                            Edit Stock Issue
                            <asp:Label runat="server" ID="lblPkey" Visible="false"></asp:Label>
                            <asp:LinkButton ID="lnkAuthorise" ToolTip="Authorised" class="btn-small btn-warning  icon-lock" runat="server" /> 
                        </h5>
                    </div>
                    <div class="widget-body">
                        <div class="widget-body-inner">
                            <div class="widget-main">
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                    <div class="row-fluid">
                                        <table cellpadding="3" class="table table-striped table-bordered table-condensed">
                                            <tr>
                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label14">Location Type</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label ID="lblEditLocationType" runat="server" CssClass="blue"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label16">Location</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label ID="lblEditLocation" runat="server" CssClass="blue"></asp:Label>
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
                                                                <asp:Label runat="server" ID="Label23">Requisition No</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label ID="lblEditRequisitionNo" runat="server" CssClass="blue"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label24">User Type</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label runat="server" ID="lblEditUserType" CssClass="blue"></asp:Label>
                                                                <asp:Label runat="server" ID="lblEditUserTypeCode" Visible="false"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>   
                                   
                                        <div id="div_student_Edit" runat="server">
                                            <div class="widget-box">
                                                <div class="widget-header widget-header-small header-color-dark">
                                                    <h5>
                                                        Stock Issue Detail for Student
                                                    </h5>
                                                </div>
                                                <div class="widget-body">
                                                    <div class="widget-body-inner">
                                                        <div class="widget-main">
                                                            <asp:DataList ID="datalist_Student_Edit" CssClass="table table-striped table-bordered table-hover"
                                                                runat="server" Width="100%" Visible="True">
                                                                <HeaderTemplate>
                                                                    <b></b></th>
                                                                    <th style="width: 20%; text-align: center;">
                                                                        Student Name
                                                                    </th>
                                                                    <th style="width: 10%; text-align: center;">
                                                                        Net Fees
                                                                    </th>
                                                                    <th style="width: 10%; text-align: center;">
                                                                        Fees Received
                                                                    </th>
                                                                    <th style="width: 20%; text-align: center;">
                                                                        Cleared Amount
                                                                    </th>
                                                                    <th style="width: 20%; text-align: center;">
                                                                        Subject Group
                                                                    </th>
                                                                    <th style="width: 20%; text-align: center;">
                                                                        Material
                                                                    </th>
                                                                    
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="chkCheck" runat="server" Checked='<%#(int)DataBinder.Eval(Container.DataItem,"CheckedFlag") == 1 ? true : false%>' />
                                                                    <span class="lbl"></span></td>
                                                                    <td style="width: 12%; text-align: left;">
                                                                        <asp:Label ID="lblstudnNm" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"StudentName")%>' />
                                                                        <asp:Label ID="lblrequCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Request_Code")%>' Visible="false"/>
                                                                        <asp:Label ID="lblRequest_EntryCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Request_EntryCode")%>' Visible="false"/>
                                                                        <asp:Label ID="lblUserCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"UserCode")%>' Visible="false"/>
                                                                        <asp:Label ID="lblInwardEntryCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"InwardEntry_Code")%>' Visible="false"/>                                                                        
                                                                        <asp:Label ID="lblItemCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Item_Code")%>' Visible="false" />
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
                                                                    <td style="text-align: left;">
                                                                        <asp:Label ID="Label12" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Item_Name")%>' />
                                                                    </td>
                                                                   
                                                                </ItemTemplate>
                                                            </asp:DataList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div id="div_Teacher_Edit" runat="server">
                                            <div class="widget-box">
                                                <div class="widget-header widget-header-small header-color-dark">
                                                    <h5>
                                                        Stock Issue Detail for Teacher
                                                    </h5>
                                                </div>
                                                <div class="widget-body">
                                                    <div class="widget-body-inner">
                                                        <div class="widget-main">
                                                            <asp:DataList ID="datalist_Teacher_Edit" CssClass="table table-striped table-bordered table-hover"
                                                                runat="server" Width="100%" Visible="True">
                                                                <HeaderTemplate>
                                                                    <b></b></th>
                                                                    <th style="width: 12%; text-align: center;">
                                                                        Teacher Code
                                                                    </th>
                                                                    <th style="width: 22%; text-align: center;">
                                                                        Teacher Name
                                                                    </th>
                                                                    <th style="width: 25%; text-align: center;">
                                                                        Subject
                                                                    </th>
                                                                    <th style="width: 15%; text-align: center;">
                                                                        Short Name
                                                                    </th>
                                                                    <th style="width: 20%; text-align: center;">
                                                                        Material Name
                                                                    </th>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="chkCheck" runat="server" Checked='<%#(int)DataBinder.Eval(Container.DataItem,"CheckedFlag") == 1 ? true : false%>' />
                                                                    <span class="lbl"></span></td>
                                                                    <td style="width: 12%; text-align: left;">
                                                                        <asp:Label ID="lblPartnerCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Partner_code")%>' />
                                                                        <asp:Label ID="lblrequCode_TH" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Request_Code")%>' Visible="false"/>
                                                                        <asp:Label ID="Request_EntryCode_TH" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Request_EntryCode")%>' Visible="false"/>
                                                                        <asp:Label ID="lblUserCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"UserCode")%>' Visible="false"/>
                                                                        <asp:Label ID="lblInwardEntryCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"InwardEntry_Code")%>' Visible="false"/>                                                                        
                                                                        <asp:Label ID="lblItemCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Item_Code")%>' Visible="false" />
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
                                                                    <td style="text-align: left;">
                                                                        <asp:Label ID="Label12" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Item_Name")%>' />
                                                                    </td>
                                                                </ItemTemplate>
                                                            </asp:DataList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div id="div_Employee_Edit" runat="server">
                                            <div class="widget-box">
                                                <div class="widget-header widget-header-small header-color-dark">
                                                    <h5>
                                                        Stock Issue Detail for Employee
                                                    </h5>
                                                </div>
                                                <div class="widget-body">
                                                    <div class="widget-body-inner">
                                                        <div class="widget-main">
                                                            <table cellpadding="2" class="table table-striped table-bordered table-condensed">
                                                                <tr>
                                                                    <td class="span4" style="text-align: left">
                                                                        <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                                            runat="server" id="Table1">
                                                                            <tr>
                                                                                <td style="border-style: none; text-align: left; width: 40%;">
                                                                                    <asp:Label ID="Label27" runat="server">Employee Name</asp:Label>
                                                                                </td>
                                                                                <td style="border-style: none; text-align: left">
                                                                                    <asp:Label ID="lblEmployeeName_Edit" runat="server" Text=""></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                    <td class="span4" style="text-align: left" colspan="2">
                                                                        <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                                            <tr>
                                                                                <td class="span2" style="border-style: none; text-align: left; width: 40%;">
                                                                                    <asp:Label ID="Label29" runat="server">Employee Code</asp:Label>
                                                                                </td>
                                                                                <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                                                    <asp:Label ID="lblEmployeeCode_Edit" runat="server" Text=""></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="span4" style="text-align: left">
                                                                        <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                                            runat="server" id="Table2">
                                                                            <tr>
                                                                                <td style="border-style: none; text-align: left; width: 40%;">
                                                                                    <asp:Label ID="Label31" runat="server">Email Id</asp:Label>
                                                                                </td>
                                                                                <td style="border-style: none; text-align: left">
                                                                                    <asp:Label ID="lblEmployeeEmailId_Edit" runat="server" Text=""></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                    <td class="span4" style="text-align: left" colspan="2">
                                                                        <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                                            runat="server" id="Table3">
                                                                            <tr>
                                                                                <td style="border-style: none; text-align: left; width: 40%;">
                                                                                    <asp:Label ID="Label33" runat="server">Employee Status</asp:Label>
                                                                                </td>
                                                                                <td style="border-style: none; text-align: left">
                                                                                    <asp:Label ID="lblEmployeeStatus_Edit" runat="server" Text=""></asp:Label>
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
                                                                                    <asp:Label runat="server" ID="Label35">Remarks</asp:Label>
                                                                                </td>
                                                                                <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                                                    <asp:Label runat="server" ID="lblEmployeeRemark_Edit" Text="" CssClass="blue" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                    <td class="span4" style="text-align: left">
                                                                        <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                                            runat="server" id="Table4">
                                                                            <tr>
                                                                                <td class="span2" style="border-style: none; text-align: left; width: 40%;">
                                                                                    <asp:Label runat="server" ID="Label37">Item</asp:Label>
                                                                                    <asp:Label ID="lblRequ_CodeforEmp_Edit" runat="server" Text="" Visible="false"></asp:Label>
                                                                                    <asp:Label ID="lblRequ_EntryCodeforEMP_Edit" runat="server" Text="" Visible="false"></asp:Label>
                                                                                    <asp:Label ID="lblEmp_ItemCode_Edit" runat="server" Text="" Visible="false"></asp:Label>
                                                                                    <asp:Label ID="lblEmp_InwardEntryCode_Edit" runat="server" Text="" Visible="false"></asp:Label>
                                                                                </td>
                                                                                <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                                                    <asp:Label runat="server" ID="lblEmployeeItemName_Edit" Text="" CssClass="blue" />
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
                                 </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="widget-main alert-block alert-success  alert- " style="text-align: center;">
                            <!--Button Area -->
                            <asp:Button class="btn btn-app btn-success btn-mini radius-4" ID="btnEditStock" runat="server"
                                Text="Save" ValidationGroup="UcValidate" onclick="btnEditStock_Click"/>
                            <asp:Button class="btn btn-app btn-primary btn-mini radius-4" 
                                ID="btnEditStockClose" Visible="true"
                                runat="server" Text="Close" onclick="btnEditStockClose_Click" />
                            <asp:ValidationSummary ID="ValidationSummary1" ShowSummary="false" DisplayMode="List"
                                ShowMessageBox="true" ValidationGroup="UcValidate" runat="server" />
                        </div>
                    </div>
                </div>
            </div>

            
            <div id="DivAuthorisePanel" runat="server" visible="false">
                <div class="widget-box">
                    <div class="widget-header widget-header-small header-color-dark">
                        <h5 class="modal-title">
                            Authorise Stock Issue
                        </h5>
                    </div>
                    <div class="widget-body">
                        <div class="widget-body-inner">
                            <div class="widget-main">
                                <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                    <div class="row-fluid">
                                        <table cellpadding="3" class="table table-striped table-bordered table-condensed">
                                            <tr>
                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label15">Location Type</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label ID="lblAuthoriseLocationType" runat="server" CssClass="blue"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label20">Location</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label ID="lblAuthoriseLocation" runat="server" CssClass="blue"></asp:Label>
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
                                                                <asp:Label runat="server" ID="Label26">Requisition No</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label ID="lblAuthoriseRequisitionNo" runat="server" CssClass="blue"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label30">User Type</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label runat="server" ID="lblAuthoriseUserType" CssClass="blue"></asp:Label>
                                                                <asp:Label runat="server" ID="lblAuthoriseUserTypeCode" Visible="false"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>   
                                   
                                        <div id="div_Student_Authorise" runat="server">
                                            <div class="widget-box">
                                                <div class="widget-header widget-header-small header-color-dark">
                                                    <h5>
                                                        Stock Issue Detail for Student
                                                    </h5>
                                                </div>
                                                <div class="widget-body">
                                                    <div class="widget-body-inner">
                                                        <div class="widget-main">
                                                            <asp:DataList ID="datalist_Student_Authorise" CssClass="table table-striped table-bordered table-hover"
                                                                runat="server" Width="100%" Visible="True">
                                                                <HeaderTemplate>
                                                                    <b>Student Name</b>
                                                                    </th>
                                                                    <th style="width: 10%; text-align: center;">
                                                                        Net Fees
                                                                    </th>
                                                                    <th style="width: 10%; text-align: center;">
                                                                        Fees Received
                                                                    </th>
                                                                    <th style="width: 20%; text-align: center;">
                                                                        Cleared Amount
                                                                    </th>
                                                                    <th style="width: 20%; text-align: center;">
                                                                        Subject Group
                                                                    </th>
                                                                    <th style="width: 20%; text-align: center;">
                                                                        Material
                                                                    </th>
                                                                    
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                        <asp:Label ID="lblstudnNm" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"StudentName")%>' />
                                                                        <asp:Label ID="lblrequCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Request_Code")%>' Visible="false"/>
                                                                        <asp:Label ID="lblRequest_EntryCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Request_EntryCode")%>' Visible="false"/>
                                                                        <asp:Label ID="lblUserCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"UserCode")%>' Visible="false"/>
                                                                        <asp:Label ID="lblInwardEntryCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"InwardEntry_Code")%>' Visible="false"/>                                                                        
                                                                        <asp:Label ID="lblItemCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Item_Code")%>' Visible="false" />
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
                                                                    <td style="text-align: left;">
                                                                        <asp:Label ID="Label12" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Item_Name")%>' />
                                                                    </td>
                                                                   
                                                                </ItemTemplate>
                                                            </asp:DataList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div id="div_Teacher_Authorise" runat="server">
                                            <div class="widget-box">
                                                <div class="widget-header widget-header-small header-color-dark">
                                                    <h5>
                                                        Stock Issue Detail for Teacher
                                                    </h5>
                                                </div>
                                                <div class="widget-body">
                                                    <div class="widget-body-inner">
                                                        <div class="widget-main">
                                                            <asp:DataList ID="datalist_Teacher_Authorise" CssClass="table table-striped table-bordered table-hover"
                                                                runat="server" Width="100%" Visible="True">
                                                                <HeaderTemplate>
                                                                    <b>Teacher Code</b>
                                                                    </th>
                                                                    <th style="width: 22%; text-align: center;">
                                                                        Teacher Name
                                                                    </th>
                                                                    <th style="width: 25%; text-align: center;">
                                                                        Subject
                                                                    </th>
                                                                    <th style="width: 15%; text-align: center;">
                                                                        Short Name
                                                                    </th>
                                                                    <th style="width: 20%; text-align: center;">
                                                                        Material Name
                                                                    </th>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                        <asp:Label ID="lblPartnerCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Partner_code")%>' />
                                                                        <asp:Label ID="lblrequCode_TH" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Request_Code")%>' Visible="false"/>
                                                                        <asp:Label ID="Request_EntryCode_TH" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Request_EntryCode")%>' Visible="false"/>
                                                                        <asp:Label ID="lblUserCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"UserCode")%>' Visible="false"/>
                                                                        <asp:Label ID="lblInwardEntryCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"InwardEntry_Code")%>' Visible="false"/>                                                                        
                                                                        <asp:Label ID="lblItemCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Item_Code")%>' Visible="false" />
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
                                                                    <td style="text-align: left;">
                                                                        <asp:Label ID="Label12" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Item_Name")%>' />
                                                                    </td>
                                                                </ItemTemplate>
                                                            </asp:DataList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div id="div_Employee_Authorise" runat="server">
                                            <div class="widget-box">
                                                <div class="widget-header widget-header-small header-color-dark">
                                                    <h5>
                                                        Stock Issue Detail for Employee
                                                    </h5>
                                                </div>
                                                <div class="widget-body">
                                                    <div class="widget-body-inner">
                                                        <div class="widget-main">
                                                            <table cellpadding="2" class="table table-striped table-bordered table-condensed">
                                                                <tr>
                                                                    <td class="span4" style="text-align: left">
                                                                        <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                                            runat="server" id="Table5">
                                                                            <tr>
                                                                                <td style="border-style: none; text-align: left; width: 40%;">
                                                                                    <asp:Label ID="Label36" runat="server">Employee Name</asp:Label>
                                                                                </td>
                                                                                <td style="border-style: none; text-align: left">
                                                                                    <asp:Label ID="lblEmployeeName_Authorise" runat="server" Text=""></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                    <td class="span4" style="text-align: left" colspan="2">
                                                                        <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                                            <tr>
                                                                                <td class="span2" style="border-style: none; text-align: left; width: 40%;">
                                                                                    <asp:Label ID="Label39" runat="server">Employee Code</asp:Label>
                                                                                </td>
                                                                                <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                                                    <asp:Label ID="lblEmployeeCode_Authorise" runat="server" Text=""></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="span4" style="text-align: left">
                                                                        <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                                            runat="server" id="Table7">
                                                                            <tr>
                                                                                <td style="border-style: none; text-align: left; width: 40%;">
                                                                                    <asp:Label ID="Label41" runat="server">Email Id</asp:Label>
                                                                                </td>
                                                                                <td style="border-style: none; text-align: left">
                                                                                    <asp:Label ID="lblEmployeeEmailId_Authorise" runat="server" Text=""></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                    <td class="span4" style="text-align: left" colspan="2">
                                                                        <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                                            runat="server" id="Table8">
                                                                            <tr>
                                                                                <td style="border-style: none; text-align: left; width: 40%;">
                                                                                    <asp:Label ID="Label43" runat="server">Employee Status</asp:Label>
                                                                                </td>
                                                                                <td style="border-style: none; text-align: left">
                                                                                    <asp:Label ID="lblEmployeeStatus_Authorise" runat="server" Text=""></asp:Label>
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
                                                                                    <asp:Label runat="server" ID="Label45">Remarks</asp:Label>
                                                                                </td>
                                                                                <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                                                    <asp:Label runat="server" ID="lblEmployeeRemark_Authorise" Text="" CssClass="blue" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                    <td class="span4" style="text-align: left">
                                                                        <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                                            runat="server" id="Table9">
                                                                            <tr>
                                                                                <td class="span2" style="border-style: none; text-align: left; width: 40%;">
                                                                                    <asp:Label runat="server" ID="Label47">Material</asp:Label>
                                                                                </td>
                                                                                <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                                                    <asp:Label runat="server" ID="lblEmployeeItemName_Authorise" Text="" CssClass="blue" />
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
                                 </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="widget-main alert-block alert-success  alert- " style="text-align: center;">
                            <!--Button Area -->
                            <asp:Button class="btn btn-app btn-success btn-mini radius-4" ID="btnAuthorise" runat="server"
                                Text="Authorise" ValidationGroup="UcValidate" Width="80px" 
                                onclick="btnAuthorise_Click" />
                            <asp:Button class="btn btn-app btn-primary btn-mini radius-4" 
                                ID="btnAuthoriseClose" Visible="true"
                                runat="server" Text="Close" onclick="btnAuthoriseClose_Click" />
                            <asp:ValidationSummary ID="ValidationSummary4" ShowSummary="false" DisplayMode="List"
                                ShowMessageBox="true" ValidationGroup="UcValidate" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
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
                                                <th align="left" style="width: 25%">
                                                    Voucher No
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
                                                <td>
                                                    <asp:Label ID="lblDLVoucherNo" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"Asset_No")%>' />

                                                </td>
                                            </ItemTemplate>
                                        </asp:DataList>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="modal-footer">
                            <!--Button Area -->
                            <asp:Label runat="server" ID="Label2" Text="" Visible="false" />
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


    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
     <div class="modal fade" id="DivUserDetail" style="left: 50% !important; top: 20% !important;
                display: none;" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                &times;</button>
                            <h4 class="modal-title">
                                Select User
                            </h4>
                        </div>
                        <div class="modal-body">
                            <!--Controls Area -->
                            <table cellpadding="0" style="border-style: none;" width="100%">
                                <tr>
                                    <td style="border-style: none; text-align: left; width: 40%;">
                                        <asp:DataList ID="dlUserDetail" runat="server" CssClass="table table-striped table-bordered table-hover"
                                            Width="97%" OnItemCommand="dlUserDetail_ItemCommand">
                                            <HeaderTemplate>
                                                <b>User Code</b>
                                                <th align="left" style="width: 25%">
                                                    User Id
                                                </th>
                                                <th>
                                                    User Name
                                                </th>                                                
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <%-- <asp:Label ID="lblDLMaterial_Code" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"Item_Id")%>' />--%>
                                                <asp:LinkButton ID="lnkUser_Code" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"User_Code")%>'
                                                    runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"User_Code")%>' CommandName="comSetUser" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblDLUserID" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"User_Name")%>' />
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblDLUserName" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"User_Display_Name")%>' />

                                                </td>
                                            </ItemTemplate>
                                        </asp:DataList>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="modal-footer">
                            <!--Button Area -->
                            <asp:Label runat="server" ID="Label22" Text="" Visible="false" />
                            <asp:Button class="btn btn-app btn-primary btn-mini radius-4" data-dismiss="modal"
                                ID="btnUserCancel" ToolTip="Cancel" runat="server" Text="Cancel" />
                        </div>
                    </div>
                    <!-- /.modal-content -->
                </div>
                <!-- /.modal-dialog -->
            </div>
         </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="dlUserDetail" />
        </Triggers>
    </asp:UpdatePanel>

</asp:Content>
