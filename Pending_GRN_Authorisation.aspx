<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="Pending_GRN_Authorisation.aspx.cs" Inherits="Pending_GRN_Authorisation" %>

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
                     GRN Authorisation<span class="divider"></span></h4>
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
                <asp:DataList ID="dlItemListAuthorise" CssClass="table table-striped table-bordered table-hover"
                    runat="server" Width="100%" >
                    <HeaderTemplate>
                        <%--  <asp:CheckBox ID="chkAuthoriseAll" runat="server" AutoPostBack="True" OnCheckedChanged="chkAuthoriseAll_CheckedChanged" />
                                                <span class="lbl"></span></th>
                                                                    <th style="width: 10%; text-align: center;">--%>
                        <b>From Location </b></th>
                        <th>
                            location
                        </th>
                        <th>
                          Inward  Code
                        </th>
                        <th>
                           Inward/Challan Date
                        </th>
                        <th>
                            Challan No
                        </th>
                      
                        <th>
                            Total Material count
                        </th>
                           <th>
                            Purchase Amount
                        </th>
                      
                    </HeaderTemplate>
                    <ItemTemplate>
                      
                        <asp:Label ID="lblLocation_Type" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Transfer_Location_Type_Code")%>' />
                        </td>
                        <td  style="width: 20%; text-align: left;">
                            <asp:Label ID="lblLocation" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Transfer_Location_Code")%>' />
                        </td>
                       <td style="text-align: left;">
                            
                            <a href='<%#DataBinder.Eval(Container.DataItem,"Inward_Code","GRN_Authorisation_Details.aspx?&Inward_Code={0}") %>'
                                                                    id="btnGRNAuthorisationDetail" runat="server" target="_blank" 
                                                                    data-rel="tooltip" data-placement="top" title="GRNAuthorisationDetails"><asp:Label ID="lblOpening_Qty" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Inward_Code")%>' /></a> 
                        </td>
                        <td  style="width: 15%; text-align: left;">
                            <asp:Label ID="lblInwardEntry_Code" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Inward_Date","{0:dd MMM yyyy}")%>' />
                        </td>
                        <td style="width: 15%; text-align: left;">
                            <asp:Label ID="lblMaterialName_DT" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"Challan_No")%>' />
                        </td>
                      
                        <td style="width: 10%; text-align: left;">
                            <asp:Label ID="lblBarcode_DT" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"Total_Item_Count")%>' />
                           
                        </td>
                        <td style="width: 10%; text-align: left;">
                         <asp:Label ID="lblAssetType" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"Total_Purchase_Amount")%>' />
                         </td>
                    
                    </ItemTemplate>
                </asp:DataList>
                <asp:DataList ID="dlGridExport" CssClass="table table-striped table-bordered table-hover"
                    runat="server" Width="100%" Visible="false">
                    <HeaderTemplate>
                      
                       <b>From Location </b></th>
                        <th style="width: 30%; text-align: center;">
                            location
                        </th>
                        <th style="width: 30%; text-align: center;">
                          Inward  Code
                        </th>
                        <th style="width: 10%; text-align: center;">
                           Inward/challan Date
                        </th>
                        <th style="width: 30%; text-align: center;">
                            Challan No
                        </th>
                        <th style="width: 20%; text-align: center;">
                            Total Item count
                        </th>
                           <th style="width: 20%; text-align: center;">
                            Purchase Amount
                        </th>
                    
                    </HeaderTemplate>
                    <ItemTemplate>
                            <asp:Label ID="lblLocation_Type" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Transfer_Location_Type_Code")%>' />
                        </td>
                        <td  style="width: 20%; text-align: left;">
                            <asp:Label ID="lblLocation" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Transfer_Location_Code")%>' />
                        </td>
                        <td  style="width: 15%; text-align: left;">
                            <asp:Label ID="lblMaterialCode_DT" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Inward_Code")%>' />
                        </td>
                        <td  style="width: 15%; text-align: left;">
                            <asp:Label ID="lblInwardEntry_Code" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Inward_Date","{0:dd MMM yyyy}")%>' />
                        </td>
                        <td style="width: 15%; text-align: left;">
                            <asp:Label ID="lblMaterialName_DT" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"Challan_No")%>' />
                        </td>
                      
                        <td style="width: 10%; text-align: left;">
                            <asp:Label ID="lblBarcode_DT" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"Total_Item_Count")%>' />
                           
                        </td>
                        <td style="width: 10%; text-align: left;">
                         <asp:Label ID="lblAssetType" runat="server" Visible="true" Text='<%#DataBinder.Eval(Container.DataItem,"Total_Purchase_Amount")%>' />
                         </td>
                       
                    </ItemTemplate>
                </asp:DataList>
            </div>
        </div>
    </div>
</asp:Content>
