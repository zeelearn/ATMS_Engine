<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="PendingAcknowledgement.aspx.cs" Inherits="PendingAcknowledgement" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
<asp:Content ID="Content2" ContentPlaceHolderID="MainContainer" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="breadcrumbs" class="position-relative" style="height: 53px">
        <ul class="breadcrumb" style="height: 15px">
            <li><i class="icon-home"></i><a href="Homepage.aspx">Home</a><span class="divider"><i
                class="icon-angle-right"></i></span></li>
            <li>
                <h4 class="blue">
                    Pending Acknowledgment<span class="divider"></span></h4>
            </li>
        </ul>
     
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
                <asp:DataList ID="dlGridDisplay" runat="server" visible="true"
                    CssClass="table table-striped table-bordered table-hover" Width="100%">
                    <HeaderTemplate>
                 
                       
                       <%-- <th style="width: 10%; text-align: center;">--%>
                          <b>   From Location Type</b>
                        </th>
                         <th style="width: 10%; text-align: center;">
                             From Division
                        </th>
                        <th style="width: 10%; text-align: center;">
                             From Location
                        </th>
                        <th style="width: 10%; text-align: center;">
                             To Location Type
                        </th>
                            <th style="width: 10%; text-align: center;">
                             To Division
                        </th>
                         <th style="width: 10%; text-align: center;">
                            To Location
                        </th>
                        <th style="width: 10%; text-align: center;">
                            Dispatch Date
                        </th>
                        <th style="width: 15%; text-align: center;">
                            Challan No
                        </th>
                       
                        <th style="width: 10%; text-align: center;">
                            Material Code
                        </th>

                        <th style="width: 20%; text-align: center;">
                            Material Name
                        </th>
                     <%--   <th style="text-align: center; width: 10%;">
                            Asset No
                        </th>--%>

                         <th style="text-align: center; width: 10%;">
                            Dispatch Qty
                        </th>

                     <%--   <th style="text-align: center; width: 10%;">
                            Unit price
                        </th>
                        <th style="width: 10%; text-align: center;">
                            Total Amount--%>
                        
                    </HeaderTemplate>
                    <ItemTemplate>
                    <%--    <asp:CheckBox ID="chkItem" runat="server" />
                        
                        <span class="lbl"></span></td>--%>
                        <%--<td style="width: 10%; text-align: center;">--%>
                            <asp:Label ID="Label1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"From_Location_Type")%>' />
                        </td>
                          <td style="width: 15%; text-align: center;">
                            <asp:Label ID="Label2" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"FromDivision")%>' />
                        </td>
                        <td style="width: 15%; text-align: center;">
                            <asp:Label ID="Label3" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"From_Location")%>' />
                        </td>
                        <td style="width: 15%; text-align: center;">
                            <asp:Label ID="Label4" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"To_Location_Type")%>' />
                        </td>
                         <td style="width: 15%; text-align: center;">
                            <asp:Label ID="Label6" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"ToDivision")%>' />
                        </td>
                        <td style="width: 10%; text-align: center;">
                            <asp:Label ID="Label5" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"To_Location")%>' />
                        </td>
                       <td style="width: 10%; text-align: center;">
                            <asp:Label ID="lblMenuCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Dispatch_Date" ,"{0:dd MMM yyyy}" )%>' />
                        </td>
                        <td style="width: 15%; text-align: center;">
                            <asp:Label ID="lblMenuParentcode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Challan_No")%>' />
                        </td>
                        <td style="width: 10%; text-align: center;">
                            <asp:Label ID="lblItemCode_SR" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Item_Code")%>' />
                        </td>
                        <td style="text-align: center;">
                            <asp:Label ID="lblmenutype" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Item_Name")%>' />
                        </td>
                      <%--  <td style="text-align: center;">
                            <asp:Label ID="lblItemAssetNo_SR" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Asset_No")%>' />
                        </td>--%>
                        <td style="width: 07%; text-align: center;">
                            <asp:Label ID="lblmenulink" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Dispatch_Qty")%>' />
                        </td>
                    <%--    <td style="text-align: center;">
                            <asp:Label ID="Label10" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Purchase_Rate")%>' />
                        </td>
                        <td style="text-align: center;">
                            <asp:Label ID="Label11" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Purchase_Amount")%>' />
                           --%> 
                    </ItemTemplate>
                </asp:DataList>
                <asp:DataList ID="dlGridExport" runat="server" Visible ="false"
                    CssClass="table table-striped table-bordered table-hover" Width="100%">
                    <HeaderTemplate >
                    
                        
                            <b> From Location Type</b>
                        </th>
                        <th style="width: 10%; text-align: center;">
                             From Location
                        </th>
                        <th style="width: 10%; text-align: center;">
                             To Location Type
                        </th>
                         <th style="width: 10%; text-align: center;">
                            To Location
                        </th>
                        <th style="width: 10%; text-align: center;">
                            Dispatch Date
                        </th>
                        <th style="width: 15%; text-align: center;">
                            Challan No
                        </th>
                       
                        <th style="width: 10%; text-align: center;">
                            Item Code
                        </th>

                        <th style="width: 20%; text-align: center;">
                            Item Name
                        </th>
                      <%--  <th style="text-align: center; width: 10%;">
                            Asset No
                        </th>--%>

                         <th style="text-align: center; width: 10%;">
                            Dispatch Qty
                        </th>
<%--
                        <th style="text-align: center; width: 10%;">
                            Unit price
                        </th>
                        <th style="width: 10%; text-align: center;">
                            Total Amount
                        --%>
                    </HeaderTemplate>
                    <ItemTemplate>
                 
                    
                            <asp:Label ID="Label1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"From_Location_Type")%>' />
                        </td>
                        <td style="width: 10%; text-align: center;">
                            <asp:Label ID="Label3" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"From_Location")%>' />
                        </td>
                        <td style="width: 10%; text-align: center;">
                            <asp:Label ID="Label4" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"To_Location_Type")%>' />
                        </td>
                        <td style="width: 10%; text-align: center;">
                            <asp:Label ID="Label5" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"To_Location")%>' />
                        </td>
                       <td style="width: 10%; text-align: center;">
                            <asp:Label ID="lblMenuCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Dispatch_Date" ,"{0:dd MMM yyyy}" )%>' />
                        </td>
                        <td style="width: 15%; text-align: center;">
                            <asp:Label ID="lblMenuParentcode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Challan_No")%>' />
                        </td>
                        <td style="width: 10%; text-align: center;">
                            <asp:Label ID="lblItemCode_SR" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Item_Code")%>' />
                        </td>
                        <td style="text-align: center;">
                            <asp:Label ID="lblmenutype" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Item_Name")%>' />
                        </td>
                       <%-- <td style="text-align: center;">
                            <asp:Label ID="lblItemAssetNo_SR" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Asset_No")%>' />
                        </td>--%>
                        <td style="text-align: center;">
                            <asp:Label ID="lblmenulink" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Dispatch_Qty")%>' />
                        </td>
                      <%--  <td style="text-align: center;">
                            <asp:Label ID="Label10" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Purchase_Rate")%>' />
                        </td>
                        <td style="text-align: center;">
                            <asp:Label ID="Label11" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Purchase_Amount")%>' />
                            --%>
                    </ItemTemplate>
                </asp:DataList>
  
            </div>
        </div>
    </div>
</asp:Content>
