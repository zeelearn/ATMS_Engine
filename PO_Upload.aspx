<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="PO_Upload.aspx.cs" Inherits="PO_Upload" %>

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
                    PO Upload <span class="divider"></span>
                </h4>
            </li>
        </ul>
        <div id="nav-search">
            <!-- /btn-group -->
            <asp:Button class="btn  btn-app btn-success btn-mini radius-4" runat="server" ID="BtndwnldTemplate"
                Width="150px" Text="Download Template" OnClick="BtndwnldTemplate_Click" />
            <asp:Button class="btn  btn-app btn-primary btn-mini radius-4  " Visible="true" runat="server"
                ID="btnnew" Text="New" onclick="btnnew_Click"  />
                <asp:Button class="btn btn-app btn-primary  btn-mini radius-4" 
                runat="server" ID="Search" Visible="false"
                    Text="Search" ToolTip="Search" ValidationGroup="UcValidateSearch" 
                onclick="Search_Click" />
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
                            Search Upload History
                        </h5>
                    </div>
                    <div class="widget-body">
                        <div class="widget-body-inner">
                            <div class="widget-main">
                                <asp:UpdatePanel ID="UpdatePanelSearch" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <table cellpadding="2" class="table table-striped table-bordered table-condensed">
                                            <tr>
                                                <td class="span6" style="text-align: left; width: 444px;">
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                        runat="server" id="tblgodown">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label3" runat="server" CssClass="red">Period</asp:Label>
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
                                                                <asp:Label ID="Label5" runat="server">Upload Name</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left">
                                                                <asp:TextBox ID="txtuploadnameSearch" runat="server" Text="" Width="205px"></asp:TextBox>
                                                                <asp:Label ID="lbluploadfileName" runat="server" Text="" Visible="false"></asp:Label>
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
            <div runat="server" id="divdlGridDisplay">
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
              
                    <asp:Repeater ID="dlGridDisplay" runat="server">
                        <HeaderTemplate>
                            <table class="table table-striped table-bordered table-hover Table2">
                                <thead>
                                    <tr>
                                        <th>
                                            Upload No.
                                        </th>
                                        <th style="width: 25%; text-align: center;">
                                            Upload Date
                                        </th>
                                        <th style="width: 25%; text-align: center;">
                                            File Name
                                        </th>
                                        <th style="width: 25%; text-align: center;">
                                            Upload Name
                                        </th>
                                        <th style="width: 25%; text-align: center;">
                                            Record Count
                                        </th>
                                    </tr>
                                </thead>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr class="odd gradeX">
                                <td>
                                    <asp:Label ID="lbluploadNO" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"PO_ImportCode")%>' />
                                </td>
                                <td style="text-align: center;">
                                    <asp:Label ID="lbluploadDate" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"PO_ImportDate")%>' />
                                </td>
                                <td style="text-align: center;">
                                    <asp:Label ID="lblMenuCss" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"PO_ImportDescription")%>' />
                                </td>
                                <td style="text-align: center;">
                                    <asp:Label ID="lbluploadNm" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Upload_Name")%>' />
                                </td>
                                <td style="text-align: center;">
                                    <asp:Label ID="lblRecCount" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"PO_ImportRecordCount")%>' />
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </tbody> </table>
                        </FooterTemplate>
                    </asp:Repeater>









                     <div class="widget-main alert-block alert-info" style="text-align: center;">
                 
                                    <asp:Button class="btn btn-app btn-primary  btn-mini radius-4" runat="server" ID="btnclosedlGridDisplay"
                                        Text="Close" ToolTip="Close" ValidationGroup="UcValidateSearch" 
                                        onclick="btnclosedlGridDisplay_Click" />
                         
                    </div>
                </div>
            </div>
            <div id="DivNew_Upload" visible="false" runat="server">
                <div class="widget-box">
                    <div class="widget-header widget-header-small header-color-dark">
                        <h5>
                            New Upload
                            <%-- <asp:Label ID="lblPkey" runat="server" Text="" Visible="false"></asp:Label>
                            <asp:Label ID="lblUserType" runat="server" Text="" Visible="false"></asp:Label>--%>
                        </h5>
                    </div>
                    <div class="widget-body">
                        <div class="widget-body-inner">
                            <div class="widget-main">
                                <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>--%>
                                <table cellpadding="2" class="table table-striped table-bordered table-condensed">
                                    <tr>
                                        <td class="span4" style="text-align: left">
                                            <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                <tr>
                                                    <td class="span2" style="border-style: none; text-align: left; width: 40%;">
                                                        <asp:Label ID="Label6" runat="server" ForeColor="Red">Upload Name</asp:Label>
                                                    </td>
                                                    <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                        <asp:TextBox ID="txtuploadName" runat="server" Text="" Width="205px"></asp:TextBox>
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
                                                        <asp:Label ID="Label10" runat="server" ForeColor="Red">Select File</asp:Label>
                                                    </td>
                                                    <td style="border-style: none; text-align: left">
                                                        <%--  <div class="widget-header">
                                                                        
                                                                        <span class="widget-toolbar"><a href="#" data-action="collapse"><i class="icon-chevron-up">
                                                                        </i></a><a href="#" data-action="close"><i class="icon-remove"></i></a></span>
                                                                    </div>--%>
                                                        <%--   <input type="file" id="id-input-file-1" />--%>
                                                        <asp:FileUpload ID="uploadfile" runat="server" />
                                                        <asp:Label ID="Label1" runat="server" Visible="false"></asp:Label>
                                                          <asp:Label ID="lblfilepath" runat="server" Visible="False"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td class="span4" style="text-align: left">
                                            <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                runat="server" id="Table2">
                                                <tr>
                                                    <td runat="server" visible="false">
                                                    </td>
                                                    <td>
                                                        <asp:Button class="btn btn-app btn-primary  btn-mini radius-4" runat="server" ID="btnUpload"
                                                            Text="Upload" ToolTip="Upload" ValidationGroup="UcValidateSearch" OnClick="btnUpload_Click" />
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                                <div id="New_UploadGrid" runat="server">
                                    <asp:DataList ID="datalist_NewUploads1" CssClass="table table-striped table-bordered table-hover"
                                        runat="server" Width="100%" Visible="True">
                                        <HeaderTemplate>
                                          <%--  <th style="width: 14%; text-align: center;">--%>
                                               <b> P.O. No</b>
                                            </th>
                                            <th style="width: 14%; text-align: center;">
                                                P.O. Date
                                            </th>
                                            <th style="width: 14%; text-align: center;">
                                                Vendor Code
                                            </th>
                                            <th style="width: 14%; text-align: center;">
                                                Material Code
                                            </th>
                                            <th style="width: 10%; text-align: center;">
                                                Order Qty
                                            </th>
                                            <th style="width: 14%; text-align: center;">
                                                Rate
                                         
                                           </th>
                                                <th style="width: 14%; text-align: center;">
                                                Cost Center
                                            </th>
                                            <th style="width: 20%; text-align: center;">
                                                Status
                                            </th>
                                             
                                            <th runat="server" visible="false" style="width: 14%; text-align: center;">
                                                Vendor Name
                                            </th>
                                            <th runat="server" visible="false" style="width: 14%; text-align: center;">
                                                Material Description
                                            </th>
                                            <th id="Th1" runat="server" visible="false" style="width: 14%; text-align: center;">
                                                Order By
                                            </th>
                                           
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                       <%--     <td style="text-align: left;">--%>
                                                <asp:Label ID="lblPOnumber" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"P_O_Number")%>' />
                                            </td>
                                            <td style="text-align: Center;">
                                                <asp:Label ID="lblP_O_Date" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"P_O_Date")%>' />
                                            </td>
                                            <td style="text-align: Center;">
                                                <asp:Label ID="lblVendor_Code" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Vendor_Code")%>' />
                                            </td>
                                            <td style="text-align: Center;">
                                                <asp:Label ID="lblMaterial_Code" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Material_Code")%>' />
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:Label ID="lblOrder_Qty" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Order_Qty")%>' />
                                            </td>
                                            <td style="text-align: Center;">
                                                <asp:Label ID="lblRate" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Rate")%>' />
                                            </td>
                                              <td id="Td1" style="text-align: Center;" runat="server" visible="false">
                                                <asp:Label ID="Label2" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Order_By")%>' />
                                            </td>
                                                  <td style="text-align: Center;">
                                                <asp:Label ID="Cost_Center" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Cost_Center")%>' />
                                            </td>
                                            <td style="text-align: left;">
                                               <%-- <asp:Label ID="lblStatus" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Status")%>' />--%>
                                                <asp:Label ID="labelSTATUS" runat="server" Text=""></asp:Label>
                                            </td>
                                       
                                            <td style="text-align: Center;" runat="server" visible="false">
                                                <asp:Label ID="lblvendorName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Vendor_Name")%>' />
                                            </td>
                                            <td style="text-align: Center;" runat="server" visible="false">
                                                <asp:Label ID="lblmaterialDescr" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Material_Description")%>' />
                                            </td>
                                            <td style="text-align: Center;" runat="server" visible="false">
                                                <asp:Label ID="lblOrderBY" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Order_By")%>' />
                                            </td>
                                          
                                        </ItemTemplate>
                                    </asp:DataList>
                                    <div runat="server" class="widget-main alert-block alert-info" id="Divbtnimport"  style="text-align: center;">
                                        <asp:Button class="btn btn-app btn-primary  btn-mini radius-4" runat="server" ID="btnImport"
                                            Text="Import" ToolTip="Import" ValidationGroup="UcValidateSearch" OnClick="btnImport_Click" />
                                        <asp:Button class="btn btn-app btn-primary  btn-mini radius-4" runat="server" ID="btnClose"
                                            Text="Close" ToolTip="Close" ValidationGroup="UcValidateSearch" OnClick="btnClose_Click" />
                                        <asp:ValidationSummary ID="ValidationSummary1" ShowSummary="false" DisplayMode="List"
                                            ShowMessageBox="true" ValidationGroup="UcValidateSearch" runat="server" />
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
