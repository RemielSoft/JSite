<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="AddVisaForm.aspx.cs" Inherits="JSVisaTrackingWebApplication.AddVisaForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
    function confirmation() {
        if (confirm('Are you sure you want to Save ?')) {
            return true;
        } else {
            return false;
        }
    }
    </script> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>
        Add Visa Form</h2>
        <asp:ValidationSummary ID="ValidationSummary1" ShowMessageBox="true" ShowSummary="false"
        runat="server" ValidationGroup="Summery1" />
    <table class="bordered">
        <tr>
            <td class="left">
                Visa Form City
            </td>
            <td class="left">
                <asp:CheckBoxList ID="CheckBoxcity" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem>Delhi</asp:ListItem>
                    <asp:ListItem>Mumbai</asp:ListItem>
                    <asp:ListItem>Channai</asp:ListItem>
                    <asp:ListItem>Bangalore</asp:ListItem>
                </asp:CheckBoxList>
                
            </td>
        </tr>
        <tr>
            <td class="left">
                Country Name For Visa<span class="red">*</span>
            </td>
            <td class="left">
                <div class="input-control select">
                    <asp:DropDownList ID="DropDownList_contry" runat="server">
                    </asp:DropDownList>
                </div>
                <asp:RequiredFieldValidator ID="rfv_Country" runat="server" ErrorMessage="Please Select Country Name"
            ControlToValidate="DropDownList_contry" InitialValue="" Display="None" SetFocusOnError="True" ValidationGroup="Summery1">
        </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="left">
                Visa Title<span class="red">*</span>
            </td>
            <td class="left">
                <div class="input-control text">
                    <asp:TextBox ID="txtvisatitle" runat="server"></asp:TextBox>
                    <button class="btn-clear" />
                </div>
                 <asp:RequiredFieldValidator ID="rfv_visatitle" runat="server" ControlToValidate="txtvisatitle"
                ValidationGroup="Summery1" SetFocusOnError="true" ErrorMessage="Please Enter Visa Title"
                Display="None">
            </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="left">
                Upload Visa Form
            </td>
            <td class="left">
                <asp:FileUpload ID="uploadform" runat="server" />
            </td>
        </tr>
       
       
      
    </table>
    <div align="right"><asp:Button ID="btnadd" runat="server" Text="ADD" OnClick="btnadd_Click" ValidationGroup="Summery1"/></div>
    <div>
    <asp:GridView runat="server" ID="Visa_gridview" AutoGenerateColumns="False"
                    OnRowCommand="Visa_gridview_RowCommand" CellPadding="5"
            CssClass="gridview" PageSize="10">
             <HeaderStyle CssClass="gridViewHeader" />
            <RowStyle CssClass="gridViewRow" />
            <AlternatingRowStyle CssClass="gridViewAltRow" />
            <SelectedRowStyle CssClass="gridViewSelectedRow" />
            <PagerStyle CssClass="gridViewPager" />
                    <Columns>
                        <asp:TemplateField HeaderText="Visa City">
                            <ItemTemplate>
                                <asp:Label ID="lbl_Visa_City" runat="server" Text='<%#Eval("VisaCity") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Country Name For Visa">
                            <ItemTemplate>
                                <asp:Label ID="lbl_country" runat="server" Text='<%#Eval("CountryForVisa") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Visa Title">
                            <ItemTemplate>
                                <asp:Label ID="lbl_title" runat="server" Text='<%#Eval("VisaTitle") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Form">
                            <ItemTemplate>
                                <asp:Label ID="lbl_Form" runat="server" Text='<%#Eval("Form") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ACTION">
                            <ItemTemplate>
                                <asp:ImageButton ID="btnDelete" runat="server" CommandName="cmdDelete" CommandArgument='<%#Container.DataItemIndex %>' ImageUrl="~/image/button_cancel.png"  ToolTip="delete" Width="14" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle Font-Size="10pt" />
                </asp:GridView>
                
    </div>
    <div align="right"><asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click"  OnClientClick="return confirmation();"/></div>
</asp:Content>
