 <%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="Location.aspx.cs" Inherits="JSVisaTrackingWebApplication.Location" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="bordered">
        <tr>
            <td class="left">
                CompanyId<span class="red">*</span>
            </td>
            <td class="left">
                <div class="input-control select">
                    <asp:DropDownList ID="ddlCompany" runat="server">
                    </asp:DropDownList>
                </div>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please Select The Company" Display="None" InitialValue="0" ForeColor="Red" ValidationGroup ="validgroup" ControlToValidate= "ddlCompany">
                </asp:RequiredFieldValidator>
            </td>
            <td class="left">
                Location Title<span class="red">*</span>
            </td>
            <td class="left">
                <div class="input-control text">
                    <asp:TextBox ID="txtlocation" runat="server" TextMode="MultiLine"></asp:TextBox>
                </div>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ErrorMessage="Please Enter The  Location Title"  ValidationGroup ="validgroup" 
                    ControlToValidate= "txtlocation" ForeColor="Red" Display="None"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="left">
                City<span class="red">*</span>
            </td>
            <td class="left">
                <div class="input-control text">
                    <asp:TextBox ID="txtcity" runat="server"></asp:TextBox>
                </div>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Enter The City"  Display="None" ValidationGroup ="validgroup" ControlToValidate= "txtcity" ForeColor="Red">
                </asp:RequiredFieldValidator>
            </td>
            <td class="left">
                Location Address<span class="red">*</span>
            </td>
            <td class="left">
                <div class="input-control text">
                    <asp:TextBox ID="txtlocationaddress" runat="server"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please Enter The Address"  ValidationGroup ="validgroup" ControlToValidate= "txtlocationaddress" ForeColor="Red" Display="None">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <asp:ValidationSummary ID="ValidationSummary1" ShowMessageBox="true" ShowSummary="false"
        runat="server" ValidationGroup="validgroup" />
         
        <tr>
        <td colspan="4" class="right"><asp:Button ID="BtnAdd" runat="server" Text="ADD" 
                ValidationGroup = "validgroup" onclick="BtnAdd_Click" />
                <asp:Button ID="btnupdate" runat="server" Text="UPDATE" 
                onclick="btnupdate_Click" ValidationGroup = "validgroup" />
                <asp:Button ID="btncancle" runat="server" Text="CANCLE" 
                onclick="btncancle_Click" /></td>
        </tr>
    </table>
     <div>
     <asp:GridView ID="Grdlocation" runat="server" AutoGenerateColumns="False" 
                    AllowPaging="True" 
                    CellPadding="5"  
            CssClass="gridview" PageSize="10" 
             onpageindexchanging="Grdlocation_PageIndexChanging" 
             onrowcommand="Grdlocation_RowCommand">
                    <HeaderStyle CssClass="gridViewHeader" />
            <RowStyle CssClass="gridViewRow" />
            <AlternatingRowStyle CssClass="gridViewAltRow" />
            <SelectedRowStyle CssClass="gridViewSelectedRow" />
            <PagerStyle CssClass="gridViewPager" />
                    <Columns>
                        <asp:TemplateField HeaderText="Location Id">
                            <ItemTemplate>
                                <asp:Label ID="lblId" runat="server" Text='<%# Eval("LocationId") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Company Name">
                            <ItemTemplate>
                                <asp:Label ID="lblcompanyId" runat="server" Text='<%# Eval("CompanyName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Location Title">
                            <ItemTemplate>
                                <asp:Label ID="lblLocationTitle" runat="server" Text='<%# Eval("LocationTitle") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="City">
                            <ItemTemplate>
                                <asp:Label ID="lblCity" runat="server" Text='<%# Eval("City") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Location Address">
                            <ItemTemplate>
                                <asp:Label ID="lblLocationAddress" runat="server" Text='<%# Eval("LocationAddress") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--<asp:TemplateField HeaderText="Created By">
                            <ItemTemplate>
                                <asp:Label ID="lblCreatedBy" runat="server" Text='<%# Eval("CreatedBy") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Created Date ">
                            <ItemTemplate>
                                <asp:Label ID="lblCreatedDate" runat="server" Text='<%# Eval("CreatedDate") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Modified By">
                            <ItemTemplate>
                                <asp:Label ID="lblModifiedBy" runat="server" Text='<%# Eval("ModifiedBy") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ModifieDate">
                            <ItemTemplate>
                                <asp:Label ID="lblModifieDate" runat="server" Text='<%# Eval("ModifieDate") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton3" runat="server" ToolTip="Edit" CommandName="cmdedit" CommandArgument='<%#Eval("LocationId") %>' ><i class="icon-pencil black" ></i></asp:LinkButton>
                                     <asp:LinkButton ID="LinkButton5" runat="server" ToolTip="Delete" CommandName="cmddelete" CommandArgument='<%#Eval("LocationId") %>' OnClientClick="return confirm ('Are you Sure to Delete?')"><i class=" icon-remove red"></i></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                   
                </asp:GridView>
    </div>
</asp:Content>
