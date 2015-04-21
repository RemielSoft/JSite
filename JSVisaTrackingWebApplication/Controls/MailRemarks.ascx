<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MailRemarks.ascx.cs" Inherits="JSVisaTrackingWebApplication.Controls.MailRemarks" %>
<table class="table table-bordered table-striped table-condensed">
                    <asp:Repeater ID="ReptrMailRemarks" runat="server">
                        <HeaderTemplate>
                            <tr>
                                <td>
                                    Consignment Id
                                </td>
                                <td>
                                    Country Name
                                </td>
                                <td>
                                    Submission Date
                                </td>
                                <td>
                                    Check-On Date
                                </td>
                                <td>
                                    Collection Date
                                </td>
                                <td>
                                    Collected
                                </td>
                                <td>
                                    Remarks
                                </td>
                            </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                              
                                <asp:Label ID="lblSubject" runat="server"  Text='<%#Eval("ConsignmentId") %>' Font-Bold="true" />
                            </td>
                            <td>
                            <%-- <asp:TextBox ID="txtCountryId" runat="Server" Text='<%#Eval("CountryId")%>'></asp:TextBox>--%>
                            <asp:Label ID="Label5" runat="server" Text='<%#Eval("CountryName") %>' Font-Bold="true" />
                            </td>
                            <td>
                             <%--<asp:TextBox ID="txtSubmissionDate" runat="Server" Text='<%#Eval("SubmissionDate")%>'></asp:TextBox>--%>
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("CgSubmissionDate") %>' Font-Bold="true" />
                            </td>
                            <td>
                             <%--<asp:TextBox ID="txtCheckOnDate" runat="Server" Text='<%#Eval("CheckOnDate")%>'></asp:TextBox>--%>
                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("CgCheckOnDate") %>' Font-Bold="true" />
                            </td>
                            <td>
                             <%--<asp:TextBox ID="txtCollectionDate" runat="Server" Text='<%#Eval("CollectionDate")%>'></asp:TextBox>--%>
                                <asp:Label ID="Label3" runat="server" Text='<%#Eval("CG_COLLECTION_DATE") %>' Font-Bold="true" />
                            </td>
                            <td>
                                <asp:CheckBox ID="CheckBox1" runat="server" />
                            </td>
                            <td>

                                <asp:TextBox ID="txtremarks" runat="server"  TextMode="MultiLine"></asp:TextBox>
                            </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                   
                   
                </table>
                <table>
                 <tr>
                    <td colspan="7" align="right"> 
                    <asp:Button ID="BtnMailremark" runat="server" OnClick="BtnMailremark_Click" Text="Save" /> </td>
                    </tr>
                </table>