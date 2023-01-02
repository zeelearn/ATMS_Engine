<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Print_Dispatch_Hidden.aspx.cs" Inherits="Print_Dispatch_Hidden" %>


<%@ Register Assembly="BarcodeLib.Barcode.ASP.NET" Namespace="BarcodeLib.Barcode.ASP.NET"
    TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <style type="text/css">
        @media print
        {
            html, body
            {
                height: 99%;
                margin-top:0px;
                margin-left:3px;
            }
            table
            {
                height: 99%;
                margin-left:3px;
            }
            .row-fluid
            {
                padding-left: 100;
                page-break-after: right;
            }
            .Print
            {
                padding-left: 30px;
                page-break-after: avoid;
                margin-left: 1px;
                page-break-inside: auto;
            }
            .print:last-child
            {
                page-break-after: avoid;
            }
            .content
            {
                page-break-after: right;
                page-break-inside: avoid;
            }
            .dlstudentlabel
            {
                page-break-inside: auto;
                margin-left: 200px;
            }
        
            table
            {
                page-break-inside: inherit;
                page-break-before: avoid;
            }
            tr
            {
                page-break-inside: avoid;
                page-break-after: auto;
            }
            .abc
            {
                page-break-after: avoid;
                page-break-before: inherit;
            }
            page
            {
                table-layout: fixed;
            }
    </style>
    <script type="text/javascript">
        window.onload = function () { window.print(); }

    
    </script>
</head>
<body>
    <div id="Print" class="Print"  runat="server">
       <%-- <form id="form1" runat="server" style="page-break-before: avoid">--%>
        <!-- BEGIN  BARCODE PRINT-->
        <div class="row-fluid" id="DivReport" runat="server" style="page-break-inside: avoid">
            <%-- <asp:DataList ID="dlstudentlabel" runat="server">
                <AlternatingItemStyle Font-Size="Medium" />
                <ItemTemplate>
                    <div class="content" style="page-break-inside: avoid">--%>
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <b>SPID: </b>
                    </td>
                    <td align="left">
                        <asp:Label ID="lblstudentcode" runat="server" Text='  <%# Bind("Student_Code") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <b>SBEntrycode: </b>
                    </td>
                    <td align="left">
                        <asp:Label ID="lblSbentrycode" runat="server" Text='<%# Bind("User_Primary_Code") %>'></asp:Label>
                    </td>
                </tr>

                 <tr>
                    <td>
                        <b>Name: </b>
                    </td>
                    <td align="left">
                        <asp:Label ID="lblname" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                    </td>
                </tr>

                 <tr>
                    <td>
                        <b>Center: </b>
                    </td>
                    <td align="left">
                        <asp:Label ID="lblcenter" runat="server" Text='<%# Bind("Center") %>'></asp:Label>
                    </td>
                </tr>

                <tr>

                    <!--  PRINT BARCODE-->
                    <td colspan="2">
                        <cc1:LinearASPNET ID="LinearASPNET1" runat="server" BarHeight="15" BarWidth="2" Data='<%# Bind("Asset_No") %>'
                            ShowText="false" TextFontColor="black" />
                    </td>
                </tr>
            </table>
            <%-- </div>
                </ItemTemplate>
            </asp:DataList>--%>
        </div>
        <%--<div id="div_print">
            <div id="header" style="background-color: White;">
            </div>
            <div id="footer" style="background-color: White;">
            </div>
        </div>--%>
       <%-- </form>--%>
    </div>
</body>
</html>

