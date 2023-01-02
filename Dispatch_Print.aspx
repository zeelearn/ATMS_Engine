<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Dispatch_Print.aspx.cs" Inherits="Dispatch_Print" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta content="width=device-width, initial-scale=1.0" name="viewport"/>
    <meta content="" name="description"/>
    <meta content="" name="author"/>
  
    <script type="text/javascript">
        window.onload = function () { window.print(); }
    </script>
<style>

/* RESET */
html,body,div,span,applet,object,iframe,h1,h2,h3,h4,h5,h6,p,blockquote,pre,a,abbr,acronym,address,big,cite,code,del,dfn,em,img,ins,kbd,q,s,samp,small,strike,strong,sub,sup,tt,var,b,u,i,center,dl,dt,dd,ol,ul,li,fieldset,form,label,legend,table,caption,tbody,tfoot,thead,tr,th,td,article,aside,canvas,details,embed,figure,figcaption,footer,header,hgroup,menu,nav,output,ruby,section,summary,time,mark,audio,video{border:0;font-size:100%;font:inherit;vertical-align:baseline;margin:0;padding:0}article,aside,details,figcaption,figure,footer,header,hgroup,menu,nav,section{display:block}body{line-height:1}ol,ul{list-style:none}blockquote,q{quotes:none}blockquote:before,blockquote:after,q:before,q:after{content:none}table{border-collapse:collapse;border-spacing:0}
/* RESET END */


@media print {


}

.wrapper{
width: 1000px;
border: 1px solid black;
margin: 0 auto;

}

.header{
width: 100%;
height: 175px;
border-bottom: 1px solid black;
}

.logo{
float: left;
width: 17%;
padding-top: 34px;
padding-left: 20px;
}

.header_info{
float: right;
width: 80%;
height: 176px;
}

.header_info h1{
font-size: 26px;
padding-left: 135px;
padding-top: 15px;

}

.header_info p{
font-size: 16px;
padding: 10px 10px 15px 10px;

}

.header_info h2{
font-size: 20px;
font-weight: bold;
text-decoration: underline;
padding-left: 135px;
}

.bottom_header{
border-bottom: 1px solid black;
padding-bottom: 10px;
}

.date{
float: left;
padding: 10px;
}

.serial_no{
float: right;
padding: 10px;
}

.user_info{
padding: 10px;
}

.user_info h2{
font-size: 18px;
padding-bottom: 10px;
}

.user_info p{
font-size: 16px;
border-bottom: 1px solid rgb(186, 186, 186);
margin-bottom: 5px;
padding-bottom: 2px;
}

.table{
height: 720px;
border-bottom: 1px solid black;
}

.left_table{
width: 580px;
height: 700px;
border-right: 1px solid black;
float: left;
padding: 10px;

}

.left_table tr{
border-bottom: 1px solid rgb(205, 205, 205);
}

.left_table td{
padding: 1px;
}



.right_table{
width: 372px;
height: 700px;
border-left: 1px solid black;
float: right;
padding: 10px;
font-weight: bold;
}

.right_table tr{
border-bottom: 1px solid rgb(205, 205, 205);
}

.right_table td{
padding: 18px 10px;
}

.footnote{
padding: 10px;

}

.footnote h1{
font-size: 20px;
padding-bottom: 5px;
}

.footnote p{
font-size: 16px;
line-height: 19px;
}

.footnote h2{
font-size: 20px;
padding-top: 10px;
}


</style>
</head>
<body>
    <form id="form1" runat="server">
    
        <asp:ScriptManager ID="script1" runat="server">
                </asp:ScriptManager>
        
            <asp:UpdatePanel ID="UpnlprintDispatch" runat="server">
                <ContentTemplate>
                     <!-- BEGIN Dispatch PRINT-->
                     <asp:Panel ID="pnlPerson" runat="server">
                        <div class="wrapper">
                            <div class="header">
                             <div class="logo">
                               <img id="imglogo" runat ="server"  style="width:100%" src="Images/logo.jpg"/>
                          </div>
                          <div class="header_info">
                                <br />
                              <asp:Label ID="Label8" runat="server" CssClass="red" Font-Bold="False" Font-Size="X-Large">MT Educare Ltd., Office No. 220, 2nd Floor,</asp:Label><br />
                              <asp:Label ID="Label6" runat="server" CssClass="red" Font-Bold="False" Font-Size="X-Large">Neptune's Flying Colors,Near Check Naka Bus Depot,</asp:Label><br />
                                    <asp:Label ID="Label7" runat="server" CssClass="red" Font-Bold="False" Font-Size="X-Large">L.B.S Cross Road, Mulund(W), Mumbai 400080, India</asp:Label><br />
                                    <br />
                                    <br />
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;<asp:Label 
                                        ID="Label9" runat="server" CssClass="red" Font-Bold="True" 
                                    Font-Size="Large" Font-Underline="True">Delivery Challan</asp:Label><br />
                                     <br />
                                      <br />
                                     <asp:Label ID="Labe1l9" runat="server" CssClass="red" Font-Bold="True" 
                                    Font-Size="Large" Font-Underline="True">ORIGINAL For Consignee/ DUPLICATE For Transporter/ TRIPLICATE For Consignor</asp:Label><br />
                                   
                          </div>
                             
                         </div>
	
	                        <div class="bottom_header">
	                            <div class="date">Transfer From: <asp:label ID="lblTransferFrom" runat ="server"></asp:label></div>
	                            <div class="serial_no">Challan No: <asp:label ID="lblChallanNo" runat ="server"></asp:label></div>                                
                                <div style="clear:both;"></div>
	                             <div class="date">Transfer To: <asp:label ID="lblTransferTo" runat ="server"></asp:label></div>
                                 <div class="serial_no">Challan Date: <asp:label ID="lblChallanDate" runat ="server"></asp:label></div>
	                            <div style="clear:both;"></div>
	
	                            
	                            </div>
                                <br />
	
	                        <%--<div class="table">--%>
                                          
                                    <asp:DataList ID="DLItemList" CssClass="gridFont"  Visible="false" ItemStyle-CssClass="gridFont" HeaderStyle-CssClass="gridFont"
                                                runat="server" Width="98%" >
                                                <HeaderTemplate>
                                              <th align="center" style="width: 20%;border-collapse: collapse; border: 1px solid black;font-family:Arial;font-size:12">
                                                 Name
                                            </th>
                                            <th align="center" style="width: 15%;border-collapse: collapse; border: 1px solid black;font-family:Arial;font-size:12">
                                                Material Code
                                            </th>
                                            <th align="center" style="width: 38%;border-collapse: collapse; border: 1px solid black;font-family:Arial;font-size:12">
                                                Material Name & Description
                                            </th>
                                            <th align="center" style="width: 15%;border-collapse: collapse; border: 1px solid black;font-family:Arial;font-size:12">
                                                Material Asset No
                                            </th>
                                            <th align="center" style="width: 10%;border-collapse: collapse; border: 1px solid black;font-family:Arial;font-size:12">
                                                Units
                                            </th>
                                            
                                            <th align="center" style="width: 15%;border-collapse: collapse; border: 1px solid black;font-family:Arial;font-size:12">
                                               Quantity Delivered
                                            </th>                                    
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                         <td align="left" style="border-collapse: collapse; border: 1px solid black;font-family:Arial;font-size:12">
                                                &nbsp;<asp:Label ID="Label12" Text='<%#DataBinder.Eval(Container.DataItem, "UOM_Name")%>'
                                                 runat="server"></asp:Label>                                                
                                            </td>
                                            <td align="left" style="border-collapse: collapse; border: 1px solid black;font-family:Arial;font-size:12">
                                                &nbsp;<asp:Label ID="Label1" Text='<%#DataBinder.Eval(Container.DataItem, "Item_Code")%>'
                                                 runat="server"></asp:Label>                                                
                                            </td>
                                            <td align="left" style="border-collapse: collapse; border: 1px solid black;font-family:Arial;font-size:12">
                                                &nbsp;<asp:Label ID="Label2" Text='<%#DataBinder.Eval(Container.DataItem, "Item_Name")%>'
                                                    runat="server"></asp:Label>
                                            </td>
                                            <td align="left" style="border-collapse: collapse; border: 1px solid black;font-family:Arial;font-size:12">
                                                &nbsp;<asp:Label ID="Label11" Text='<%#DataBinder.Eval(Container.DataItem, "Asset_No")%>'
                                                    runat="server"></asp:Label>
                                            </td>
                                            <td align="left" style="border-collapse: collapse; border: 1px solid black;font-family:Arial;font-size:12">
                                                &nbsp;<asp:Label ID="Label3" Text='<%#DataBinder.Eval(Container.DataItem, "UOM_Name")%>'
                                                    runat="server"></asp:Label>
                                            </td>                                            
                                            <td align="right" style="border-collapse: collapse; border: 1px solid black;font-family:Arial;font-size:12">
                                                <asp:Label ID="Label4" Text='<%#DataBinder.Eval(Container.DataItem, "Dispatch_Qty")%>'
                                                 runat="server"></asp:Label>&nbsp;
                                            </td>                                            
                                        </ItemTemplate>
                                    </asp:DataList>
                                    <asp:DataList ID="dldispatch"   Visible="false" runat="server" Width="92%" >
                                           <HeaderTemplate>
                                            <th align="center" style="width: 15%;border-collapse: collapse; border: 1px solid black;font-family:Arial;font-size:12">
                                                Material Code
                                            </th>
                                            <th align="center" style="width: 38%;border-collapse: collapse; border: 1px solid black;font-family:Arial;font-size:12">
                                                Material Name & Description
                                            </th>
                                            <th align="center" style="width: 15%;border-collapse: collapse; border: 1px solid black;font-family:Arial;font-size:12">
                                                Material Asset No
                                            </th>
                                            <th align="center" style="width: 10%;border-collapse: collapse; border: 1px solid black;font-family:Arial;font-size:12">
                                                Units
                                            </th>
                                            
                                            <th align="center" style="width: 15%;border-collapse: collapse; border: 1px solid black;font-family:Arial;font-size:12">
                                               Quantity Delivered
                                            </th>                                    
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <td align="left" style="border-collapse: collapse; border: 1px solid black;font-family:Arial;font-size:12">
                                                &nbsp;<asp:Label ID="Label1" Text='<%#DataBinder.Eval(Container.DataItem, "Item_Code")%>'
                                                 runat="server"></asp:Label>                                                
                                            </td>
                                            <td align="left" style="border-collapse: collapse; border: 1px solid black;font-family:Arial;font-size:12">
                                                &nbsp;<asp:Label ID="Label2" Text='<%#DataBinder.Eval(Container.DataItem, "Item_Name")%>'
                                                    runat="server"></asp:Label>
                                            </td>
                                            <td align="left" style="border-collapse: collapse; border: 1px solid black;font-family:Arial;font-size:12">
                                                &nbsp;<asp:Label ID="Label11" Text='<%#DataBinder.Eval(Container.DataItem, "Asset_No")%>'
                                                    runat="server"></asp:Label>
                                            </td>
                                            <td align="left" style="border-collapse: collapse; border: 1px solid black;font-family:Arial;font-size:12">
                                                &nbsp;<asp:Label ID="Label3" Text='<%#DataBinder.Eval(Container.DataItem, "UOM_Name")%>'
                                                    runat="server"></asp:Label>
                                            </td>                                            
                                            <td align="right" style="border-collapse: collapse; border: 1px solid black;font-family:Arial;font-size:12">
                                                <asp:Label ID="Label4" Text='<%#DataBinder.Eval(Container.DataItem, "Dispatch_Qty")%>'
                                                 runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
                                            </td>                                            
                                        </ItemTemplate>
                                    </asp:DataList>
                                     <br />
                                    <br />                                    
                                    <br />
                                    <br />
                              
                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover">
                                        <tr>
                                            <td style="border-style: none; text-align: left; width: 27%;">
                                                &nbsp;&nbsp;&nbsp;<asp:Label ID="Label4" Text="Prepared By -" runat="server"></asp:Label>&nbsp;<asp:Label ID="lblPreparedBy" Text="Prepared By" runat="server"></asp:Label>
                                            </td>
                                            <td style="border-style: none; text-align: left; width: 25%;">
                                                <asp:Label ID="Label5" Text="Approved By" runat="server"></asp:Label>
                                            </td>
                                            <td style="border-style: none; text-align: left; width: 25%;">
                                                <asp:Label ID="Label10" Text="Authorised By" runat="server"></asp:Label>
                                            </td>
                                             <td style="border-style: none; text-align: left; width: 25%;">
                                                <asp:Label ID="Label14" Text="Received By" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                       <%-- <tr>
                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                
                                            </td>
                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                <asp:Label ID="Label11" Text="Authorised By" runat="server"></asp:Label>
                                            </td>
                                        </tr>--%>
                                    </table>

                                    <br />
                                    <br />

                                             <table cellpadding="3" class="table table-striped table-bordered table-condensed" runat="server" visible="false" id="tlLocation">
                                            <tr>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label13" runat="server" CssClass="red">Location Type</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlLocationType" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Location Type" Width="215px"  />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                        runat="server" id="tblFr_GodownSearch" visible="false">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label22" runat="server" CssClass="red">Godown Name</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlgodownFR_SRSearch" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Godown" Width="215px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                        runat="server" id="tblFr_DivisionSearch" visible="false">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label23" runat="server" CssClass="red">Division Name</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table cellpadding="0" style="border-style: none; width: 100%;" class="table-hover"
                                                        runat="server" id="tblFr_FunctionSearch" visible="false">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label24" runat="server" CssClass="red">Function Name</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlFunctionFR_SRSearch" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Function" Width="215px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%"
                                                        runat="server" id="tblFr_CenterSearch" visible="false">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label25" runat="server" CssClass="red">Center Name</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>                                           
                                        </table>
			                        
	                      <%--</div>--%>

	                        <%--<div class="footnote">
                                   
	                        </div>--%>
                            
                            
                        </div>
                  
                    
                    </asp:Panel>
                     <asp:Button ID="btnprint" runat ="server" OnClick ="btnprint_Click" Text="Print" Visible ="false"  />
                </ContentTemplate>
            </asp:UpdatePanel>
    </form>
</body>
</html>
