<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="Pending_RequestAuthorisation.aspx.cs" Inherits="Pending_RequestAuthorisation" %>

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
                     Request Authorisation<span class="divider"></span></h4>
            </li>
        </ul>
        <div id="nav-search">
            <!-- /btn-group -->
            <asp:Button class="btn  btn-app btn-primary btn-mini radius-4  " Visible="true" runat="server"
                ID="BtnShowSearchPanel" Text="Search"  />
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
                
                
                <asp:Repeater ID="dlGridDisplay" runat="server" >
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
                                
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr class="odd gradeX">
                            <td>
                                <asp:Label ID="lblNo_Requisition" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Request_Code")%>' />
                                <span id="iconDL_Authorise" runat="server" visible='<%# Convert.ToString(DataBinder.Eval(Container.DataItem,"Authorise_Flag")) == "1" ? true : false%>'
                                    class="btn btn-danger btn-mini tooltip-error" data-rel="tooltip" data-placement="right"
                                    title="Request Authorised"><i class="icon-lock"></i></span>
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
                            
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody> </table>
                    </FooterTemplate>
                </asp:Repeater>
                <asp:DataList ID="dlGridExport" CssClass="table table-striped table-bordered table-hover"
                    runat="server" Width="100%" Visible="false">
                    <HeaderTemplate>
                        <b>Requisition No.</b> </th>
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
        </div>
    </div>
</asp:Content>
