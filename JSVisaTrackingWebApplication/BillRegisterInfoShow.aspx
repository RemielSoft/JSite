<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" ValidateRequest="true" EnableEventValidation="true"
    CodeBehind="BillRegisterInfoShow.aspx.cs" Inherits="JSVisaTrackingWebApplication.BillRegisterInfoShow" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>   
    <h2>
        <i class="icon-keyboard fg-color-blue">&nbsp; </i>Bill Summary Information
    </h2>
    <asp:UpdatePanel ID="updatePanel1" runat="server">
        <ContentTemplate>      
    <div style="width: 100%; height: auto; overflow: scroll; overflow-y:hidden;">
        <asp:GridView ID="gv_billRegister" runat="server" AutoGenerateColumns="False" CssClass="gridview"
            PageSize="10" CellPadding="5" ShowFooter="true" OnRowDataBound="gv_billRegister_RowDataBound" OnRowCreated="gv_billRegister_RowCreated">
            <HeaderStyle CssClass="gridViewHeader" />
            <RowStyle CssClass="gridViewRow" />
            <AlternatingRowStyle CssClass="gridViewAltRow" />
            <SelectedRowStyle CssClass="gridViewSelectedRow" />
            <PagerStyle CssClass="gridViewPager" />
            <FooterStyle BackColor="#2D89EF" ForeColor="White" HorizontalAlign="Left" />
            <Columns>
                <asp:TemplateField HeaderText="Date">
                    <ItemTemplate>
                        <asp:Label ID="lbl_date" runat="server" Text='<%# Eval("Date") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblPageTotal" runat="server" Text="Total (INR)" /><%--<br />
                        <br />
                        <asp:Label ID="lblGrandTotal" runat="server" Text="Grand Total" />--%>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Bill No.">
                    <ItemTemplate>
                        <asp:Label ID="lbl_billno" runat="server" Text='<%# Eval("BillNo") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Pax Name">
                    <ItemTemplate>
                        <asp:Label ID="lbl_paxname" runat="server" Text='<%# Eval("PaxName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Party Name">
                    <ItemTemplate>
                        <asp:Label ID="lbl_partyname" runat="server" Text='<%# Eval("PartyName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Visa Country">
                    <ItemTemplate>
                        <asp:Label ID="lbl_visacountry" runat="server" Text='<%# Eval("VisaCountry") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField >
                <HeaderTemplate>
                <asp:label ID="Charge" runat="Server" Text="Visa Charge" />
                <asp:Image ID="Image1" runat="server" ImageUrl="~/image/Rupees-symbol.png" Height="16px"
                                    Width="16px" />
                </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbl_visacharge" runat="server" Text='<%# Eval("Visa") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblTotalvisa" runat="server" Font-Bold="True" /><%--<br />
                        <br />
                        <asp:Label ID="lblGrandvisa" runat="server" Font-Bold="True" />--%>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Attestation Charge (INR)">
                    <ItemTemplate>
                        <asp:Label ID="lbl_attestation" runat="server" Text='<%# Eval("Attestation") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblTotalAttestation" runat="server" Font-Bold="True" /><%--<br />
                        <br />
                        <asp:Label ID="lblGrandAttestation" runat="server" Font-Bold="True" />--%>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Token Charge (INR)">
                    <ItemTemplate>
                        <asp:Label ID="lbl_token" runat="server" Text='<%# Eval("Token") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblTotalToken" runat="server" Font-Bold="True" /><%--<br />
                        <br />
                        <asp:Label ID="lblGrandToken" runat="server" Font-Bold="True" />--%>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="VFS/BLS/TTS (INR)">
                    <ItemTemplate>
                        <asp:Label ID="lbl_vfs" runat="server" Text='<%# Eval("Vfs") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblTotalVFS" runat="server" Font-Bold="True" /><%--<br />
                        <br />
                        <asp:Label ID="lblGrandVFS" runat="server" Font-Bold="True" />--%>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Handling Charge (INR)">
                    <ItemTemplate>
                        <asp:Label ID="lbl_handling" runat="server" Text='<%# Eval("Handling") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblTotalHandling" runat="server" Font-Bold="True" /><%--<br />
                        <br />
                        <asp:Label ID="lblGrandHandling" runat="server" Font-Bold="True" />--%>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Courier Charge (INR)">
                    <ItemTemplate>
                        <asp:Label ID="lbl_courier" runat="server" Text='<%# Eval("Courior") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblTotalCourior" runat="server" Font-Bold="True" /><%--<br />
                        <br />
                        <asp:Label ID="lblGrandCourior" runat="server" Font-Bold="True" />--%>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Delivery Charge (INR)">
                    <ItemTemplate>
                        <asp:Label ID="lbl_Delivery" runat="server" Text='<%# Eval("Delivery") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblTotalDelivery" runat="server" Font-Bold="True" /><%--<br />
                        <br />
                        <asp:Label ID="lblGrandDelivery" runat="server" Font-Bold="True" />--%>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Convenience (INR)">
                    <ItemTemplate>
                        <asp:Label ID="lbl_Convenience" runat="server" Text='<%# Eval("Convenience") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblTotalConvenience" runat="server" Font-Bold="True" /><%--<br />
                        <br />
                        <asp:Label ID="lblGrandConvenience" runat="server" Font-Bold="True" />--%>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Urgent Charge (INR)">
                    <ItemTemplate>
                        <asp:Label ID="lbl_Urgent" runat="server" Text='<%# Eval("Urgent") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblTotalUrgent" runat="server" Font-Bold="True" /><%--<br />
                        <br />
                        <asp:Label ID="lblGrandUrgent" runat="server" Font-Bold="True" />--%>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Draft Charge (INR)">
                    <ItemTemplate>
                        <asp:Label ID="lbl_Draft" runat="server" Text='<%# Eval("Draft") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblTotalDraft" runat="server" Font-Bold="True" /><%--<br />
                        <br />
                        <asp:Label ID="lblGrandDraft" runat="server" Font-Bold="True" />--%>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Insurance Charge (INR)">
                    <ItemTemplate>
                        <asp:Label ID="lbl_Insurance" runat="server" Text='<%# Eval("Insurance") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblTotalInsurance" runat="server" Font-Bold="True" /><%--<br />
                        <br />
                        <asp:Label ID="lblGrandInsurance" runat="server" Font-Bold="True" />--%>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Other Charge (INR)">
                    <ItemTemplate>
                        <asp:Label ID="lbl_OtherCharges" runat="server" Text='<%# Eval("OtherCharge") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblTotalOther" runat="server" Font-Bold="True" /><%--<br />
                        <br />
                        <asp:Label ID="lblGrandOther" runat="server" Font-Bold="True" />--%>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Service Charge (INR)">
                    <ItemTemplate>
                        <asp:Label ID="lbl_ServiceCharge" runat="server" Text='<%# Eval("ServiceCharge") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblTotalService" runat="server" Font-Bold="True" /><%--<br />
                        <br />
                        <asp:Label ID="lblGrandService" runat="server" Font-Bold="True" />--%>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Service Tax (INR)">
                    <ItemTemplate>
                        <asp:Label ID="lbl_ServiceTax" runat="server" Text='<%# Eval("ServiceTax") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblTotalServiceTax" runat="server" Font-Bold="True" /><%--<br />
                        <br />
                        <asp:Label ID="lblGrandServiceTax" runat="server" Font-Bold="True" />--%>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Amount (INR)">
                    <ItemTemplate>
                        <asp:Label ID="lbl_Amount" runat="server" Text='<%# Eval("Amount") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblTotalAmount" runat="server" Font-Bold="True" /><%--<br />
                        <br />
                        <asp:Label ID="lblGrandAmount" runat="server" Font-Bold="True" />--%>
                    </FooterTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <br />
    <div align="right">
    <asp:Button ID="btnBack" runat="server" Text="Back" onclick="btnBack_Click"/>
        <asp:Button ID="btnExport" runat="server" Text="Export To Excel" OnClick="btnExport_Click" />
    </div>
    </ContentTemplate>  
        <Triggers>
            <asp:PostBackTrigger ControlID="btnExport" />
        </Triggers>        
    </asp:UpdatePanel>
</asp:Content>
