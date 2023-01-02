<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GRN_Print.aspx.cs" Inherits="GRN_Print"
    EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta content="width=device-width, initial-scale=1.0" name="viewport" />
    <meta content="" name="description" />
    <meta content="" name="author" />
    <script type="text/javascript">
        window.onload = function () { window.print(); }
    </script>
    <style>
        /* RESET */
        html, body, div, span, applet, object, iframe, h1, h2, h3, h4, h5, h6, p, blockquote, pre, a, abbr, acronym, address, big, cite, code, del, dfn, em, img, ins, kbd, q, s, samp, small, strike, strong, sub, sup, tt, var, b, u, i, center, dl, dt, dd, ol, ul, li, fieldset, form, label, legend, table, caption, tbody, tfoot, thead, tr, th, td, article, aside, canvas, details, embed, figure, figcaption, footer, header, hgroup, menu, nav, output, ruby, section, summary, time, mark, audio, video
        {
            border: 0;
            font-size: 100%;
            font: inherit;
            vertical-align: baseline;
            margin: 0;
            padding: 0;
        }
        article, aside, details, figcaption, figure, footer, header, hgroup, menu, nav, section
        {
            display: block;
        }
        body
        {
            line-height: 1;
        }
        ol, ul
        {
            list-style: none;
        }
        blockquote, q
        {
            quotes: none;
        }
        blockquote:before, blockquote:after, q:before, q:after
        {
            content: none;
        }
        table
        {
            border-collapse: collapse;
            border-spacing: 0;
        }
        /* RESET END */
        
        
        @media print
        {
        
        
        }
        
        .wrapper
        {
            width: 1000px;
            border: 1px solid black;
            margin: 0 auto;
        }
        
        .header
        {
            width: 100%;
            height: 175px;
            border-bottom: 1px solid black;
        }
        
        .logo
        {
            float: left;
            width: 17%;
            padding-top: 34px;
            padding-left: 20px;
        }
        
        .header_info
        {
            float: right;
            width: 80%;
            height: 176px;
        }
        
        .header_info h1
        {
            font-size: 26px;
            padding-left: 135px;
            padding-top: 15px;
        }
        
        .header_info p
        {
            font-size: 16px;
            padding: 10px 10px 15px 10px;
        }
        
        .header_info h2
        {
            font-size: 20px;
            font-weight: bold;
            text-decoration: underline;
            padding-left: 135px;
        }
        
        .bottom_header
        {
            border-bottom: 1px solid black;
            padding-bottom: 10px;
        }
        
        .date
        {
            float: left;
            padding: 10px;
        }
        
        .serial_no
        {
            float: right;
            padding: 10px;
        }
        
        .user_info
        {
            padding: 10px;
        }
        
        .user_info h2
        {
            font-size: 18px;
            padding-bottom: 10px;
        }
        
        .user_info p
        {
            font-size: 16px;
            border-bottom: 1px solid rgb(186, 186, 186);
            margin-bottom: 5px;
            padding-bottom: 2px;
        }
        
        .table
        {
            height: 720px;
            border-bottom: 1px solid black;
        }
        
        .left_table
        {
            width: 580px;
            height: 700px;
            border-right: 1px solid black;
            float: left;
            padding: 10px;
        }
        
        .left_table tr
        {
            border-bottom: 1px solid rgb(205, 205, 205);
        }
        
        .left_table td
        {
            padding: 1px;
        }
        
        
        
        .right_table
        {
            width: 372px;
            height: 700px;
            border-left: 1px solid black;
            float: right;
            padding: 10px;
            font-weight: bold;
        }
        
        .right_table tr
        {
            border-bottom: 1px solid rgb(205, 205, 205);
        }
        
        .right_table td
        {
            padding: 18px 10px;
        }
        
        .footnote
        {
            padding: 10px;
        }
        
        .footnote h1
        {
            font-size: 20px;
            padding-bottom: 5px;
        }
        
        .footnote p
        {
            font-size: 16px;
            line-height: 19px;
        }
        
        .footnote h2
        {
            font-size: 20px;
            padding-top: 10px;
        }
        .style1
        {
            width: 109px;
        }
        .style2
        {
            width: 139px;
        }
        .style3
        {
            width: 217px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="script1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="Upnlprintreceipt" runat="server">
        <ContentTemplate>
            <!-- BEGIN RECEIPT I PRINT-->
            <asp:Panel ID="pnlPerson" runat="server">
                <div class="wrapper">
                    <%--<div class="header">
                        <table style="width: 100%;">
                            <tr>
                                <td class="style1">
                                    <img alt="MT Educare Ltd" class="msg-photo" src="Images/logo.jpg" />
                                </td>
                                <td class="style2" valign ="top">
                                    <table cellpadding="0" class="table-hover" style="border-style: none; height: 81px;"
                                        width="100%">
                                        <tr>
                                            <td class="span2" style="border-style: none; text-align: left; width: 40%;" colspan="2">
                                                <asp:Label ID="Label8" runat="server" CssClass="red" Font-Bold="False" Font-Size="X-Large">MT Educare Ltd., Office No. 220, 2nd Floor,</asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:Label ID="Label6" runat="server" CssClass="red" Font-Bold="False" Font-Size="X-Large">Neptune's Flying Colors,Near Check Naka Bus Depot,</asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:Label ID="Label7" runat="server" CssClass="red" Font-Bold="False" Font-Size="X-Large">L.B.S Cross Road, Mulund(W), Mumbai 400080, India</asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td align="right">
                                    <h3 style="font-family: Arial">
                                        <asp:Label ID="lblDivisionPrint" runat="server" Text="GOODS RECEIPT NOTE   "></asp:Label></h3>
                                </td>
                            </tr>
                        </table>
                    </div>--%>
                    <div class="header">
                        <div class="logo">
                            <img id="imglogo" runat="server" style="width: 100%" src="Images/logo.jpg" />
                        </div>
                        <div class="header_info">
                            <br />
                            <asp:Label ID="Label8" runat="server" Font-Bold="False" Font-Size="X-Large">MT Educare Ltd., Office No. 220, 2nd Floor,</asp:Label><br />
                            <asp:Label ID="Label6" runat="server" Font-Bold="False" Font-Size="X-Large">Neptune's Flying Colors,Near Check Naka Bus Depot,</asp:Label><br />
                            <asp:Label ID="Label7" runat="server" Font-Bold="False" Font-Size="X-Large">L.B.S Cross Road, Mulund(W), Mumbai 400080, India</asp:Label>
                            <br />
                            <br />
                            <br />
                            <br />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            &nbsp;&nbsp;<asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Size="Large">GOODS RECEIPT NOTE</asp:Label>
                        </div>
                    </div>
                    <div class="bottom_header">
                        <div style="clear: both;">
                        </div>
                        <div class="user_info">
                            <table style="width: 98%; height: 129px;">
                                <tr>
                                    <td class="style1" style="width: 10%">
                                    </td>
                                    <td style="width: 22%">
                                    </td>
                                    <td class="style2">
                                    </td>
                                    <td style="width: 18%">
                                    </td>
                                    <td style="width: 12%">
                                        GRN No :
                                    </td>
                                    <td style="width: 22%">
                                        <asp:Label ID="lblGRNNo" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1" style="width: 10%">
                                        Supplier Name :
                                    </td>
                                    <td style="width: 22%">
                                        <asp:Label ID="lblSuppName" runat="server"></asp:Label>
                                    </td>
                                    <td class="style2">
                                    </td>
                                    <td style="width: 18%">
                                    </td>
                                    <td style="width: 12%">
                                        GRN Date :
                                    </td>
                                    <td style="width: 22%">
                                        <asp:Label ID="lblGrnDate" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1" style="width: 10%">
                                        PO NO :
                                    </td>
                                    <td style="width: 22%">
                                        <asp:Label ID="lblPONO" runat="server"></asp:Label>
                                    </td>
                                    <td class="style2" style="width: 8%">
                                    </td>
                                    <td style="width: 18%">
                                    </td>
                                    <td style="width: 12%">
                                        DEL.CH.No :
                                    </td>
                                    <td style="width: 22%">
                                        <asp:Label ID="lblDelChalNO" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1" style="width: 10%">
                                        PO Date :
                                    </td>
                                    <td style="width: 22%">
                                        <asp:Label ID="lblPoDate" runat="server"></asp:Label>
                                    </td>
                                    <td class="style2">
                                    </td>
                                    <td style="width: 18%">
                                    </td>
                                    <td style="width: 12%">
                                        DEL.CH.Date :
                                    </td>
                                    <td style="width: 22%">
                                        <asp:Label ID="lblChalaDate" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1" style="width: 14%">
                                        Invoice Value :
                                    </td>
                                    <td style="width: 24%">
                                        <asp:Label ID="lblInvoiceValue" runat="server"></asp:Label>
                                    </td>
                                    <td class="style2">
                                    </td>
                                    <td style="width: 18%">
                                    </td>
                                    <td style="width: 12%">
                                        Sup.Invoice.No :
                                    </td>
                                    <td style="width: 22%">
                                        <asp:Label ID="lblInvoiceNo" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1" style="width: 12%">
                                    </td>
                                    <td style="width: 22%">
                                    </td>
                                    <td class="style2">
                                    </td>
                                    <td style="width: 18%">
                                    </td>
                                    <td style="width: 14%">
                                        Sup Invoice Date :
                                    </td>
                                    <td style="width: 24%">
                                        <asp:Label ID="lblInvoiceDate" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <%--<div class="table">--%>
                        <br />
                        <asp:DataList ID="DLItemList" CssClass="gridFont" ItemStyle-CssClass="gridFont" HeaderStyle-CssClass="gridFont"
                            runat="server" Width="98%">
                            <HeaderTemplate>
                                <th align="center" style="width: 15%; border-collapse: collapse; border: 1px solid black;
                                    font-family: Arial; font-size: 12">
                                    Item Code
                                </th>
                                <th align="center" style="width: 34%; border-collapse: collapse; border: 1px solid black;
                                    font-family: Arial; font-size: 12">
                                    Item Name & Description
                                </th>
                                <th align="center" style="width: 10%; border-collapse: collapse; border: 1px solid black;
                                    font-family: Arial; font-size: 12">
                                    Units
                                </th>
                                <th align="center" style="width: 15%; border-collapse: collapse; border: 1px solid black;
                                    font-family: Arial; font-size: 12">
                                    Quantity Received
                                </th>
                                <th align="center" style="width: 10%; border-collapse: collapse; border: 1px solid black;
                                    font-family: Arial; font-size: 12">
                                    Rate
                                </th>
                                <th align="center" style="width: 15%; border-collapse: collapse; border: 1px solid black;
                                    font-family: Arial; font-size: 12">
                                    Value
                                </th>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <td align="left" style="border-collapse: collapse; border: 1px solid black; font-family: Arial;
                                    font-size: 12">
                                    &nbsp;<asp:Label ID="Label1" Text='<%#DataBinder.Eval(Container.DataItem, "Item_Code")%>'
                                        runat="server"></asp:Label>
                                </td>
                                <td align="left" style="border-collapse: collapse; border: 1px solid black; font-family: Arial;
                                    font-size: 12">
                                    &nbsp;<asp:Label ID="Label2" Text='<%#DataBinder.Eval(Container.DataItem, "Item_Name")%>'
                                        runat="server"></asp:Label>
                                </td>
                                <td align="left" style="border-collapse: collapse; border: 1px solid black; font-family: Arial;
                                    font-size: 12">
                                    &nbsp;<asp:Label ID="Label3" Text='<%#DataBinder.Eval(Container.DataItem, "UOM_Name")%>'
                                        runat="server"></asp:Label>
                                </td>
                                <td align="right" style="border-collapse: collapse; border: 1px solid black; font-family: Arial;
                                    font-size: 12">
                                    <asp:Label ID="Label4" Text='<%#DataBinder.Eval(Container.DataItem, "Inward_Qty")%>'
                                        runat="server"></asp:Label>&nbsp;
                                </td>
                                <td align="right" style="border-collapse: collapse; border: 1px solid black; font-family: Arial;
                                    font-size: 12">
                                    <asp:Label ID="Label5" Text='<%#DataBinder.Eval(Container.DataItem, "Purchase_Rate")%>'
                                        runat="server"></asp:Label>&nbsp;
                                </td>
                                <td align="right" style="border-collapse: collapse; border: 1px solid black; font-family: Arial;
                                    font-size: 12">
                                    <asp:Label ID="Label10" Text='<%#DataBinder.Eval(Container.DataItem, "Purchase_Amount")%>'
                                        runat="server"></asp:Label>&nbsp;
                                </td>
                            </ItemTemplate>
                        </asp:DataList>
                        <br />
                        <br />
                        <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;Received By :
                        <br />
                        <br />
                        <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;Accepted By :
                        <br />
                        <br />
                        <br />
                    <%--</div>--%>
                    
                </div>
            </asp:Panel>
            <asp:Button ID="btnprint" runat="server" Text="Print" Visible="false" />
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
