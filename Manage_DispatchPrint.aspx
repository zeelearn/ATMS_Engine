<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Manage_DispatchPrint.aspx.cs"
    Inherits="Manage_DispatchPrint" %>

<%@ Register Assembly="BarcodeLib.Barcode.ASP.NET" Namespace="BarcodeLib.Barcode.ASP.NET"
    TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">


        window.onload = function () { window.print(); }
       
        
    </script>
    <style>
        @media print
        {
        
            .print:last-child
            {
                page-break-after: auto;
            }
             html, body {
        height: 99%;    
    }
    * {margin:0;padding:0}
                @page {size: A4 ;padding-top:50px; margin-top:50px; height:100%;}
                html, body {height: 100%;  padding-left:15px}
               
               
        
        
        }
        
        
        .content
        {
            width: 384px;
            padding-top:20px;
            height: 96px;
            page-break-after:avoid;
            margin:None;
            empty-cells:hide;
            white-space: nowrap;
            width: 384px;
            height: 100px;
            margin: 100;
            padding: 100; 
            
         
        }
        
        
        .p1
        {
            background: white;
            -webkit-column-break-inside: avoid;
            page-break-inside: avoid;
            page-break-inside: avoid;
            page-break-after: always;
            padding: 1em;
            margin-bottom: 1.3em;
        }
    </style>
</head>
<body>
    <div id="Print" class="Print">
        <form id="form1" runat="server">
        <!-- BEGIN  BARCODE PRINT-->
        <div class="row-fluid" id="DivReport" runat="server">
            <asp:DataList ID="dlstudentlabel" runat="server" RepeatColumns="1" Font-Size="Large"
                EditItemStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" CellPadding="25"
                FooterStyle-Wrap="False" CaptionAlign="Top" ShowFooter="False" ShowHeader="False">
                <ItemTemplate>
                    <div style="width: 384px; display: block;">
                        <div class="content">
                            <table class="table" style="page-break-after: always; page-break-inside: avoid; display: block;"
                                cellpadding="0" cellspacing="0">
                                <tr>
                                    <td colspan="5" width="50" valign="baseline" style="font-weight: 200; font-size: 18px">
                                        <b>MT EDUCARE LTD </b>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-left: 0px;">
                                        <b>SBEntry Code : </b>
                                    </td>
                                    <td style="padding-left: 0px; left: 2px;">
                                        <asp:Label ID="lblSBEntrycode" runat="server" Text='  <%# Bind("User_Primary_Code") %>'></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>Name : </b>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>Asset No : </b>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblAssetNo" runat="server" Text='<%# Bind("Asset_No") %>'></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <!--  PRINT BARCODE-->
                                    <td colspan="2">
                                        <cc1:LinearASPNET ID="LinearASPNET1" runat="server" BarHeight="21" BarWidth="2" Data='<%# Bind("Asset_No") %>'
                                            ShowText="false" TextFontColor="black" />
                                    </td>
                            </table>
                        </div>
                        <p class="p1">
                        </p>
                    </div>
                </ItemTemplate>
                <%--    <SelectedItemStyle HorizontalAlign="Center" />--%>
            </asp:DataList>
        </div>
        <div id="div_print">
            <div id="header" style="background-color: White;">
            </div>
            <div id="footer" style="background-color: White;">
            </div>
        </div>
        </form>
    </div>
</body>
</html>
