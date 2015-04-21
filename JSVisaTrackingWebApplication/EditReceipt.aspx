<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="EditReceipt.aspx.cs" Inherits="JSVisaTrackingWebApplication.EditReceipt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ValidationSummary ID="EditRcptSummary" runat="server" ShowMessageBox="true"
        ValidationGroup="a" ShowSummary="false" DisplayMode="List" />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <h2>
        <i class="fg-color-blue icon-file"></i>Edit Receipt
    </h2>
    
    <script type="text/javascript" language="javascript">
        function validateEdit() 
        {
            if (Page_ClientValidate())
                return confirm('Are You Sure To Edit This Receipt?');                  
        }

        function validateDelete() {
            if (Page_ClientValidate())
                return confirm('Are You Sure To Delete This Receipt?');            
        }
    </script>

    <asp:UpdatePanel ID="updatePanel1" runat="server">
        <ContentTemplate>
            <table class="table table-bordered table-striped table-condensed">
                <tr>
                    <td class="left">
                        Receipt No. <span class="red">*</span>
                    </td>
                    <td class="left">
                        <div class="input-control text">
                            <asp:RequiredFieldValidator ID="RFV1" runat="server" ControlToValidate="txtRcptNo"
                                ErrorMessage="Please Fill Receipt No." ValidationGroup="a" Display="None" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CV1" runat="server" ControlToValidate="txtRcptNo" Display="None"
                                ErrorMessage="Please Fill Receipt No. With Only Numeric Value." ForeColor="Red"
                                Operator="DataTypeCheck" Type="Integer" ValidationGroup="a"></asp:CompareValidator>
                            <asp:TextBox ID="txtRcptNo" runat="server"></asp:TextBox>
                            <button class="btn-clear" />
                        </div>
                    </td>
                    
                </tr>
            </table>
            <br />
            <div align="right">
            <asp:Button ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" ValidationGroup="a"
                            CausesValidation="true" OnClientClick="return validateEdit();" />
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click"
                            ValidationGroup="a" CausesValidation="true" OnClientClick="return validateDelete();" />  
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnEdit" />
        </Triggers>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnDelete" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
