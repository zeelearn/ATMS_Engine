<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeFile="Manage_ItemMaster.aspx.cs" Inherits="Manage_ItemMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContainer" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="breadcrumbs" class="position-relative" style="height: 53px">
        <ul class="breadcrumb" style="height: 15px">
            <li><i class="icon-home"></i><a href="Homepage.aspx">Home</a><span class="divider"><i
                class="icon-angle-right"></i></span></li>
            <li>
                <h4 class="blue">
                    Item Master<span class="divider"></span></h4>
            </li>
        </ul>
        <div id="nav-search">
            <!-- /btn-group -->
            <asp:Button class="btn  btn-app btn-success btn-mini radius-4" runat="server" ID="BtnAdd"
                Text="Add" OnClick="BtnAdd_Click" />
            <asp:Button class="btn  btn-app btn-primary btn-mini radius-4  " Visible="false" runat="server"
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
                                <asp:UpdatePanel ID="UpdatePanelSearch" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <table cellpadding="3" class="table table-striped table-bordered table-condensed">
                                            <tr>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none; width: 139%;" class="table-hover">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label13" runat="server" CssClass="red">Material Group</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlProductCat_SR" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Category" Width="215px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none; width: 118%;" class="table-hover">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label57" runat="server">Material Name</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:TextBox ID="txtItemName_SR" runat="server" Text="" Width="205px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                  <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label8" runat="server">Material Code</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:TextBox ID="txtMaterial_Code" runat="server" Text="" Width="205px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>  
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none; width: 139%;" class="table-hover">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label1" runat="server">Material EAN No</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:TextBox ID="txtBarcode_SR" runat="server" Text="" Width="200px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label58" runat="server">Material SKU</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:TextBox ID="txtItemSKU_SR" runat="server" Text="" Width="205px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    &nbsp;
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
                <asp:Repeater ID="dlGridDisplay" runat="server" OnItemCommand="dlGridDisplay_ItemCommand1">
                    <HeaderTemplate>
                        <table class="table table-striped table-bordered table-hover Table2">
                            <thead>
                                <tr>
                                    <th style="width: 10%; text-align: left;">
                                        Material Code
                                    </th>
                                    <th style="width: 30%; text-align: left;">
                                        Material Name
                                    </th>
                                    <th style="text-align: left; width: 20%;">
                                        Material EAN No.
                                    </th>
                                    <th style="text-align: left; width: 10%;">
                                        Material SKU
                                    </th>
                                    <th style="text-align: center; width: 10%;">
                                        Status
                                    </th>
                                    <th style="text-align: center; width: 10%;">
                                        Action
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr class="odd gradeX">
                            <td style="text-align: left; width: 10%;">
                                <asp:Label ID="lblCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Item_Code")%>' />
                            </td>
                            <td style="width: 30%; text-align: left;">
                                <asp:Label ID="lblItem_Name" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Item_Name")%>' />
                            </td>
                            <td style="text-align: left; width: 20%;">
                                <asp:Label ID="Label2" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Item_EAN_No")%>' />
                            </td>
                            <td style="text-align: left; width: 10%;">
                                <asp:Label ID="Label3" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Item_SKU")%>' />
                            </td>
                            <td style="text-align: center; width: 10%;">
                                <asp:Label CssClass='<%# Convert.ToInt32( Eval("Is_Active")) == 1 ? "label label-success":"label label-warning"  %>'
                                    runat="server" ID="linkActive">                                
                                <%#(int)DataBinder.Eval(Container.DataItem, "Is_Active") == 1 ? "Active" : "Inactive" %>  
                                </asp:Label>
                            </td>
                            <td style="width: 10%; text-align: center;">
                                <div class="inline position-relative">
                                    <asp:LinkButton ID="lnkEdit" ToolTip="Edit" class="btn-small btn-primary icon-info-sign"
                                        CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Item_Code")%>' runat="server"
                                        CommandName="comEdit" Height="25px" />
                                </div>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody> </table>
                    </FooterTemplate>
                </asp:Repeater>
                <%--<div id="DivUserMenu" runat="server" visible="false">
                <div class="widget-box">
                    <div class="widget-header widget-header-small header-color-dark">
                        <h5 class="modal-title">
                            Edit Menu      Edit Menu<asp:Label runat="server" ID="lblmenuPK" Visible="False"></asp:Label>
                        &nbsp;</h5>
                    </div>
                    <div class="widget-body">
                        <div class="widget-body-inner">
                            <div class="widget-main">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        
                                                

                                                <table cellpadding="3" class="table table-striped table-bordered table-condensed">
                                                          <tr>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none; width: 139%;" 
                                                        class="table-hover">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">                                                                
                                                              
                                                                <asp:Label ID="Label9" runat="server" CssClass="red">Menu Name</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">                               
                                                                
                                                                                <asp:Label ID="lblMenuName" runat="server" CssClass="blue"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" class="table-hover" style="border-style: none;" 
                                                        width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label56" runat="server" CssClass="red">Menu Link</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label ID="lblMenuLink" runat="server" CssClass="blue"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                              </td>
                                                <td class="span4" style="text-align: left">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="span4" style="text-align: left">
                                                    &nbsp;</td>
                                                <td class="span4" style="text-align: left">
                                                    &nbsp;</td>
                                                <td class="span4" style="text-align: left">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="span4" style="text-align: left" colspan="3">
                                                    <div class="span10">
                                                    <div class="widget-box">
                                                        <div class="widget-header">
                                                            <h5 class="smaller">
                                                                User
                                                            </h5>
                                                        </div>
                                                        <div class="widget-body">
                                                            <div class="widget-main ">
                                                            <div class="widget-main no-padding" style="height: 240px; overflow-y: scroll; overflow-x: none;">
                                                                <asp:DataList ID="DLUserMenu01" runat="server" 
                                                                    CssClass="table table-striped table-bordered table-hover" Width="97%">
                                                                    <HeaderTemplate>
                                                                        <b>Select</b>
                                                                        <th>
                                                                        Role Code
                                                                        </th>
                                                                        <th align="left" style="width: 25%">
                                                                            Role Name
                                                                        </th>
                                                                        
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                            <label>
						                                                       <input name="form-field-checkbox" type="checkbox" id="chkCheck" runat="server"/><span class="lbl"></span>
					                                                        </label>	
                                                                            </td>
                                                                    <td>
                                                                    <asp:Label ID="lblRoleID01" runat="server" 
                                                                                Text='<%#DataBinder.Eval(Container.DataItem,"Role_Code")%>' />
                                                                        <asp:Label ID="lblRoleCode" runat="server" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem,"Role_Code")%>' />
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblAppName" runat="server" 
                                                                                Text='<%#DataBinder.Eval(Container.DataItem,"Role_Name")%>' />
                                                                                
                                                                        </td>
                                                                        
                                                                    </ItemTemplate>
                                                                </asp:DataList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div></td>
                                            </tr>
                                                                                    
                                          </table>
                                          
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="widget-main alert-block alert-success  alert- " style="text-align: center;">
                            <!--Button Area -->
                            <asp:Button class="btn btn-app btn-success btn-mini radius-4" 
                                ID="btnUserMenuSave" runat="server"
                                Text="Save" ValidationGroup="UcValidate" onclick="btnUserMenuSave_Click" />
                            <asp:Button class="btn btn-app btn-primary btn-mini radius-4" ID="btnUserMenuClose"
                                Visible="true" runat="server" Text="Close" 
                                onclick="btnUserMenuClose_Click"  />
                            <asp:ValidationSummary ID="ValidationSummary1" ShowSummary="false" DisplayMode="List"
                                ShowMessageBox="true" ValidationGroup="UcValidate" runat="server" />
                        </div>
                    </div>
                </div>
            </div>--%>
                <asp:DataList ID="DataList1" CssClass="table table-striped table-bordered table-hover"
                    runat="server" Width="100%" Visible="false">
                    <HeaderTemplate>
                        Material Code </th>
                        <th style="width: 12%; text-align: center;">
                            Material Name
                        </th>
                        <th style="text-align: center;">
                            Material SKU
                        </th>
                        <th style="text-align: center;">
                        Status
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblMenuCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Item_Code")%>' />
                        </td>
                        <td style="width: 12%; text-align: left;">
                            <asp:Label ID="lblMenuName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Item_Name")%>' />
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="Label3" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Item_SKU")%>' />
                        </td>
                        <td style="text-align: center">
                            <asp:Label CssClass='<%# Convert.ToInt32( Eval("Is_Active")) == 1 ? "label label-success":"label label-warning"  %>'
                                runat="server" ID="linkActive">                                
                                <%#(int)DataBinder.Eval(Container.DataItem, "Is_Active") == 1 ? "Active" : "Inactive" %>  
                            </asp:Label>
                        </td>
                    </ItemTemplate>
                </asp:DataList>
            </div>
            <div id="DivAddPanel" runat="server" visible="false">
                <div class="widget-box">
                    <div class="widget-header widget-header-small header-color-dark">
                        <h5 class="modal-title">
                            Item Details
                            <asp:Label runat="server" ID="lblPkey" Visible="false"></asp:Label>
                        </h5>
                    </div>
                    <div class="widget-body">
                        <div class="widget-body-inner">
                            <div class="widget-main">
                                <asp:UpdatePanel ID="UpdatePanelAdd" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <table cellpadding="3" class="table table-striped table-bordered table-condensed">
                                            <tr>
                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" class="table-hover" style="border-style: none; width: 100%;">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label32" runat="server" CssClass="red">Material Group</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlProductCat_Add" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Product Category" Width="215px" OnSelectedIndexChanged="ddlProductCat_Add_SelectedIndexChanged" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                              <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" class="table-hover" style="border-style: none; width: 100%;">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label7" runat="server" CssClass="red">Material Code</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:TextBox ID="txtMaterils" runat="server" Text="" Width="200px "></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span6" style="text-align: left">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" class="table-hover" style="border-style: none; width: 100%;">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label62" runat="server" CssClass="red">Material Name</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:TextBox ID="txtItemName_Add" runat="server" Text="" Width="200px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span6" style="text-align: left">
                                                    <table id="PONOID0" runat="server" cellpadding="0" class="table-hover" style="border-style: none;
                                                        width: 100%;">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label64" runat="server">Description</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:TextBox ID="txtItemDesc_Add" runat="server" Text="" Width="200px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label60" runat="server" CssClass="red">Manufacturer</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlManufacture_Add" runat="server" CssClass="chzn-select" data-placeholder="Select Manufacturer"
                                                                    Width="215px">
                                                                </asp:DropDownList>
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
                                                                <asp:Label ID="Label66" runat="server" CssClass="red">UOM</asp:Label>
                                                            </td>
                                                            <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlUOM_Add" runat="server" AutoPostBack="True" CssClass="chzn-select"
                                                                    data-placeholder="Select Unit" Width="215px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                        <tr>
                                                            <td class="span2" style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label68" runat="server" CssClass="red">EAN No.</asp:Label>
                                                            </td>
                                                            <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:TextBox ID="txtBarcode_Add" runat="server" Text="" Width="200px" onkeypress="return NumberOnly(event);"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                        <tr>
                                                            <td class="span2" style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label38" runat="server">Is Active</asp:Label>
                                                            </td>
                                                            <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                                <label>
                                                                    <input runat="server" id="chkActive" name="switch-field-2" type="checkbox" class="ace-switch ace-switch-2"
                                                                        checked="checked" />
                                                                    <span class="lbl"></span>
                                                                </label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label67" runat="server" CssClass="red">Material SKU</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:TextBox ID="txtItemSKU_Add" runat="server" Text="" Width="200px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label63" runat="server" CssClass="red">Asset No Type</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlAssetNoType_Add" runat="server" CssClass="chzn-select" data-placeholder="Select AssetNoType"
                                                                    Width="215px">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                        <tr>
                                                            <td class="span2" style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label6" runat="server">FG Status</asp:Label>
                                                            </td>
                                                            <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                                <label>
                                                                    <input runat="server" id="ChkFGStatus"  name="switch-field-2" type="checkbox" class="ace-switch ace-switch-2"
                                                                        checked="checked" />
                                                                    <span class="lbl"></span>
                                                                </label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label4" runat="server" CssClass="red">Purchasing group</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlAssetType_Add" runat="server" CssClass="chzn-select" data-placeholder="Select Asset Type"
                                                                    Width="215px">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" class="table-hover" style="border-style: none;" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label5" runat="server" CssClass="red">Material Type</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList ID="ddlExpenceType_Add" runat="server" CssClass="chzn-select" data-placeholder="Select Expense Type"
                                                                    Width="215px">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span6" style="text-align: left">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                        </td> </tr> </tr> </table>
                                        <div class="row-fluid" id="specification" >
                                            <div class="span8" runat="server" visible="false">
                                                <div class="widget-box">
                                                    <div class="widget-header">
                                                        <h5 class="smaller">
                                                            Item Specification
                                                        </h5>
                                                    </div>
                                                    <div class="widget-body">
                                                        <div class="widget-main ">
                                                            <asp:DataList ID="dlItemSpecification" CssClass="table table-striped table-bordered table-hover"
                                                                runat="server" Width="99%" >
                                                                <HeaderTemplate>
                                                                    <left>
                                                                        <b>Specification</b>
                                                                    </left>
                                                                    </th>
                                                                    <th style="width: 50%; text-align: left;">
                                                                    Description
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblSpecification" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"SpecificationType_ID")%>' />
                                                                    <asp:Label ID="lblItem_Code" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Item_Code")%>'
                                                                        Visible="false" />
                                                                    </td>
                                                                    <td style="width: 50%; text-align: left;">
                                                                        <asp:TextBox ID="txtSpecDescription" runat="server" Width="60%" Text='<%#DataBinder.Eval(Container.DataItem,"Speficiation_Value")%>' />
                                                                </ItemTemplate>
                                                            </asp:DataList>
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
                            <asp:Label runat="server" ID="lblErrorBatch" Text="" ForeColor="Red" />
                            <asp:Button class="btn btn-app btn-success btn-mini radius-4" ID="BtnSaveAdd" runat="server"
                                Text="Save" ValidationGroup="UcValidate" OnClick="BtnSaveAdd_Click" />
                            <asp:Button class="btn btn-app btn-success btn-mini radius-4" ID="BtnSaveEdit" runat="server"
                                Text="Save" ValidationGroup="UcValidate" OnClick="BtnSaveEdit_Click" Visible="False" />
                            <asp:Button class="btn btn-app btn-primary btn-mini radius-4" ID="BtnCloseAdd" Visible="true"
                                runat="server" Text="Close" OnClick="BtnCloseAdd_Click" />
                            <asp:ValidationSummary ID="ValidationSummary3" ShowSummary="false" DisplayMode="List"
                                ShowMessageBox="true" ValidationGroup="UcValidate" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
            <%--<div id="DivUserMenu" runat="server" visible="false">
                <div class="widget-box">
                    <div class="widget-header widget-header-small header-color-dark">
                        <h5 class="modal-title">
                            Edit Menu      Edit Menu<asp:Label runat="server" ID="lblmenuPK" Visible="False"></asp:Label>
                        &nbsp;</h5>
                    </div>
                    <div class="widget-body">
                        <div class="widget-body-inner">
                            <div class="widget-main">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        
                                                

                                                <table cellpadding="3" class="table table-striped table-bordered table-condensed">
                                                          <tr>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none; width: 139%;" 
                                                        class="table-hover">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">                                                                
                                                              
                                                                <asp:Label ID="Label9" runat="server" CssClass="red">Menu Name</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">                               
                                                                
                                                                                <asp:Label ID="lblMenuName" runat="server" CssClass="blue"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" class="table-hover" style="border-style: none;" 
                                                        width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label56" runat="server" CssClass="red">Menu Link</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:Label ID="lblMenuLink" runat="server" CssClass="blue"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                              </td>
                                                <td class="span4" style="text-align: left">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="span4" style="text-align: left">
                                                    &nbsp;</td>
                                                <td class="span4" style="text-align: left">
                                                    &nbsp;</td>
                                                <td class="span4" style="text-align: left">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="span4" style="text-align: left" colspan="3">
                                                    <div class="span10">
                                                    <div class="widget-box">
                                                        <div class="widget-header">
                                                            <h5 class="smaller">
                                                                User
                                                            </h5>
                                                        </div>
                                                        <div class="widget-body">
                                                            <div class="widget-main ">
                                                            <div class="widget-main no-padding" style="height: 240px; overflow-y: scroll; overflow-x: none;">
                                                                <asp:DataList ID="DLUserMenu01" runat="server" 
                                                                    CssClass="table table-striped table-bordered table-hover" Width="97%">
                                                                    <HeaderTemplate>
                                                                        <b>Select</b>
                                                                        <th>
                                                                        Role Code
                                                                        </th>
                                                                        <th align="left" style="width: 25%">
                                                                            Role Name
                                                                        </th>
                                                                        
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                            <label>
						                                                       <input name="form-field-checkbox" type="checkbox" id="chkCheck" runat="server"/><span class="lbl"></span>
					                                                        </label>	
                                                                            </td>
                                                                    <td>
                                                                    <asp:Label ID="lblRoleID01" runat="server" 
                                                                                Text='<%#DataBinder.Eval(Container.DataItem,"Role_Code")%>' />
                                                                        <asp:Label ID="lblRoleCode" runat="server" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem,"Role_Code")%>' />
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblAppName" runat="server" 
                                                                                Text='<%#DataBinder.Eval(Container.DataItem,"Role_Name")%>' />
                                                                                
                                                                        </td>
                                                                        
                                                                    </ItemTemplate>
                                                                </asp:DataList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div></td>
                                            </tr>
                                                                                    
                                          </table>
                                          
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="widget-main alert-block alert-success  alert- " style="text-align: center;">
                            <!--Button Area -->
                            <asp:Button class="btn btn-app btn-success btn-mini radius-4" 
                                ID="btnUserMenuSave" runat="server"
                                Text="Save" ValidationGroup="UcValidate" onclick="btnUserMenuSave_Click" />
                            <asp:Button class="btn btn-app btn-primary btn-mini radius-4" ID="btnUserMenuClose"
                                Visible="true" runat="server" Text="Close" 
                                onclick="btnUserMenuClose_Click"  />
                            <asp:ValidationSummary ID="ValidationSummary1" ShowSummary="false" DisplayMode="List"
                                ShowMessageBox="true" ValidationGroup="UcValidate" runat="server" />
                        </div>
                    </div>
                </div>
            </div>--%>
        </div>
    </div>
    <!--/row-->
</asp:Content>
