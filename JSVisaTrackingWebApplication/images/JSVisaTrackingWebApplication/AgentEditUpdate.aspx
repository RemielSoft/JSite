<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="AgentEditUpdate.aspx.cs" Inherits="JSVisaTrackingWebApplication.AgentEditUpdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>
       <i class="icon-search  fg-color-blue"></i> Find Agent Name </h2>
    <table class="bordered">
        <tr>
            <td class="left">
                Choose Agent Name
            </td>
            <td class="left">
                <div class="input-control text">
                    <asp:TextBox ID="txt_search" runat="server"></asp:TextBox>
                    <button class="btn-clear" />
                </div>
            </td>
            <td>
                <asp:Button ID="btn_search" runat="server" Text="Search" OnClick="btn_search_Click1" />
               <%-- <asp:LinkButton ID="lnkbtn_search" runat="server" OnClick="lnkbtn_search_Click1">
                            <i class="btn-search"></i>
                    </asp:LinkButton>--%>
            </td>
        </tr>
    </table>
    <div style="width: 100%; height: auto; overflow: scroll;">
        <asp:GridView ID="gvDetails" DataKeyNames="AgentId,AgentName" runat="server"  
            AutoGenerateColumns="False" AllowPaging="True" 
            CssClass="gridview" PageSize="10"
            CellPadding="5" 
            OnRowCancelingEdit="gvDetails_RowCancelingEdit"
            OnRowDeleting="gvDetails_RowDeleting" OnRowEditing="gvDetails_RowEditing" OnRowUpdating="gvDetails_RowUpdating"
            onpageindexchanging="gvDetails_PageIndexChanging" 
            onrowdatabound="gvDetails_RowDataBound">  
            <HeaderStyle CssClass="gridViewHeader" />
            <RowStyle CssClass="gridViewRow" />
            <AlternatingRowStyle CssClass="gridViewAltRow" />
            <SelectedRowStyle CssClass="gridViewSelectedRow" />
           
            <PagerStyle CssClass="gridViewPager" /> 
            <Columns>
                <asp:TemplateField HeaderText="ACTION">
                    <EditItemTemplate>
                     <asp:LinkButton ID="linbtn_update" runat="server" CommandName="Update" ToolTip="Update"><i class=" icon-loading-2 fg-color-greenDark"></i></asp:LinkButton>
                   
                       <asp:LinkButton ID="linbtn_cancel" runat="server" CommandName="Cancel" ToolTip="Cancel"><i class="icon-cancel-2 red"></i></asp:LinkButton>
                       
                        <%--<asp:ImageButton ID="imgbtnUpdate" CommandName="Update" runat="server" ImageUrl="~/image/images (2).jpg"
                            ToolTip="Update" Height="30px" Width="30px" />
                        <asp:ImageButton ID="imgbtnCancel" runat="server" CommandName="Cancel" ImageUrl="~/image/images (3).jpg"
                            ToolTip="Cancel" Height="30px" Width="30px" />--%>
                    </EditItemTemplate>
                    <ItemTemplate>
                    <asp:LinkButton ID="linbtn_edit" runat="server" CommandName="Edit" ToolTip="Edit"><i class="icon-pencil black"></i></asp:LinkButton>
                     <asp:LinkButton ID="linbtn_delete" runat="server" CommandName="Delete" ToolTip="Delete"><i class=" icon-remove red"></i></asp:LinkButton>
                        <%--<asp:ImageButton ID="imgbtnEdit" CommandName="Edit" runat="server" ImageUrl="~/image/images.jpg"
                            ToolTip="Edit" Height="30px" Width="30px" />
                        <asp:ImageButton ID="imgbtnDelete" CommandName="Delete" Text="Edit" runat="server"
                            ImageUrl="~/image/images (1).jpg" ToolTip="Delete" Height="30px" Width="30px" />--%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="AGENT ID">
                    <EditItemTemplate>
                        <asp:Label ID="lbleditusr" runat="server" Text='<%#Eval("AgentId") %>' />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblitemUsr" runat="server" Text='<%#Eval("AgentId") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="AGENT USERNAME">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtusername" runat="server" Text='<%#Eval("AgentUserName") %>' />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblusername" runat="server" Text='<%#Eval("AgentUserName") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="AGENT PASSWORD">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtpass" runat="server" Text='<%#Eval("AgentPassword") %>' />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblpass" runat="server" Text='<%#Eval("AgentPassword") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="AGENT CPERSON">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtcper" runat="server" Text='<%#Eval("AgentCPerson") %>' />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblcper" runat="server" Text='<%#Eval("AgentCPerson") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="AGENT NAME">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtname" runat="server" Text='<%#Eval("AgentName") %>' />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblname" runat="server" Text='<%#Eval("AgentName") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="AGENT ADDRESS">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtadd" runat="server" Text='<%#Eval("AgentAddress") %>' />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbladd" runat="server" Text='<%#Eval("AgentAddress") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="AGENT CITY">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtcity" runat="server" Text='<%#Eval("AgentCity") %>' />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblcity" runat="server" Text='<%#Eval("AgentCity") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="AGENT PIN">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtpin" runat="server" Text='<%#Eval("AgentPin") %>' />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblpin" runat="server" Text='<%#Eval("AgentPin") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="AGENT EMAIL">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtemail" runat="server" Text='<%#Eval("AgentEmail") %>' />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblemail" runat="server" Text='<%#Eval("AgentEmail") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="AGENT PHONE">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtphone" runat="server" Text='<%#Eval("AgentPhone") %>' />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblphone" runat="server" Text='<%#Eval("AgentPhone") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="AGENT FAX">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtfax" runat="server" Text='<%#Eval("AgentFax") %>' />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblfax" runat="server" Text='<%#Eval("AgentFax") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="AGENT ENABLE">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtenable" runat="server" Text='<%#Eval("AgentEnable") %>' />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblenable" runat="server" Text='<%#Eval("AgentEnable") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="AGENT PRORITY">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtpro" runat="server" Text='<%#Eval("AgentPrority") %>' />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblpro" runat="server" Text='<%#Eval("AgentPrority") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="AGENT SCHARGE">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtscharge" runat="server" Text='<%#Eval("AgentSCharge") %>' />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblscharge" runat="server" Text='<%#Eval("AgentSCharge") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="AGENT CCHARGE">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtccharge" runat="server" Text='<%#Eval("AgentCCharge") %>' />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblccharge" runat="server" Text='<%#Eval("AgentCCharge") %>' />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="TALLY ACNAME">
                    <EditItemTemplate>
                        <asp:TextBox ID="txttally" runat="server" Text='<%#Eval("TallyACName") %>' />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbltally" runat="server" Text='<%#Eval("TallyACName") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                                <asp:TemplateField HeaderText="AGENT DDCHARGE">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtdcharge" runat="server" Text='<%#Eval("AgentDDCharge") %>' />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbldcharge" runat="server" Text='<%#Eval("AgentDDCharge") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="OPENING BALANCE">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtopening" runat="server" Text='<%#Eval("OpeningBalance") %>' />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblopening" runat="server" Text='<%#Eval("OpeningBalance") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <div>
        <asp:Label ID="lblresult" runat="server"></asp:Label>
    </div>
</asp:Content>
