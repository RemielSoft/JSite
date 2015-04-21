<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="AgentEditUpdate.aspx.cs" Inherits="JSVisaTrackingWebApplication.AgentEditUpdate" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <!--[if lt IE 9]>
<script src="http://html5shim.googlecode.com/svn/trunk/html5.js"></script>
<![endif]-->


    <script type="text/javascript">


        function confirmationSave() {
            if (confirm('Are you sure you want to Delete ?')) {
                return true;
            } else {
                return false;
            }
        }
    </script>
    <script language="javascript" type="text/javascript">
        function UpdateListBox() {
            var updateListBox = document.getElementById('<%=lnksearch.ClientID %>');
            var filterText = document.getElementById('<%=txt_search.ClientID %>');
            updateListBox.click();
        }


        function Clear(flag) {
            var filterText = document.getElementById('<%=txt_search.ClientID %>');
        }



    </script>

    <script type="text/javascript">
        document.createElement('header');
        document.createElement('section');
        document.createElement('article');
        document.createElement('aside');
        document.createElement('nav');
        document.createElement('footer');


    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fulid page-heading">
        <div class="container">
            <div class="row">
                <div class="col-xs-12 col-sm-6">Find Agent Name</div>
                <div class="col-xs-12 col-sm-6 caption text-right">Agent / Find Agent Name</div>
            </div>
        </div>
    </div>
    <div class="container">
        <div class="row">
            <div class="col-xs-12 col-sm-12">
                <div class="form-inner-bg">
                    <div class="col-sm-12 col-xs-12">
                        <div class="row form-group">
                            <div class="col-sm-3 col-xs-12" id="agent" runat="server">
                                <label>Choose Agent Name</label>
                                <div class="input-group">
                                    <asp:TextBox ID="txt_search" runat="server" onkeyUp="UpdateListBox();" onfocus="Clear(true);"
                                        onblur="Clear(false);" CssClass="form-control">
                                    </asp:TextBox>
                                    <asp:LinkButton ID="lnksearch" runat="server" ValidationGroup="search" OnClick="lnksearch_Click" class="input-group-addon"><i class="glyphicon glyphicon-search"></i></asp:LinkButton>

                                </div>
                            </div>

                            <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                            </asp:ToolkitScriptManager>
                            <div class="col-sm-3 col-xs-12" id="divcity" runat="server">
                                <label>Agent City</label>
                                <div class="input-group">
                                    <asp:DropDownList ID="ddlCity" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                    <%--<asp:TextBox ID="txt_city" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txt_city"
                                        MinimumPrefixLength="1" EnableCaching="false" CompletionSetCount="1" CompletionInterval="100"
                                        ServiceMethod="GetCityName" FirstRowSelected="false">
                                    </asp:AutoCompleteExtender>--%>
                                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" CssClass="input-group-addon">
                            <i class="glyphicon glyphicon-search"></i>
                                    </asp:LinkButton>
                                </div>
                            </div>

                            <div class="col-sm-3 col-xs-12" id="status" runat="server">
                                <label>Agent Status</label>
                                <div class="input-group">
                                    <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged">
                                        <asp:ListItem>-Select-</asp:ListItem>
                                        <asp:ListItem>Y</asp:ListItem>
                                        <asp:ListItem>N</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click" CssClass="input-group-addon">
                            <i class="glyphicon glyphicon-search"></i>
                                    </asp:LinkButton>
                                </div>
                            </div>

                        </div>
                        <div class="row form-group">
                            <div class="col-sm-3 col-xs-12">
                                <asp:Label ID="lblagentname" runat="server" Text="Agent Name"></asp:Label>
                                <asp:TextBox ID="txtagentname" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-sm-3 col-xs-12">
                                <asp:Label ID="lblusername" runat="server" Text="Agent UserName"></asp:Label>
                                <asp:TextBox ID="txtusername" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-sm-3 col-xs-12">
                                <asp:Label ID="lblagentpwd" runat="server" Text="Agent Password"></asp:Label>
                                <asp:TextBox ID="txtagentpwd" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-sm-3 col-xs-12">
                                <asp:Label ID="lblagentcp" runat="server" Text="Agent Contact Person"></asp:Label>
                                <asp:TextBox ID="txtagentcp" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                        </div>

                        <%---------------------------------------------------------%>
                        <div class="row form-group">
                              <div class="col-sm-3 col-xs-12">
                                <asp:Label ID="lbladdress" runat="server" Text="Agent Address"></asp:Label>
                                <asp:TextBox ID="txtagentaddress" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-sm-3 col-xs-12">
                                <asp:Label ID="lblCountry" runat="server" Text="Country"></asp:Label>
                                <asp:DropDownList ID="ddlCountry" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged" CssClass="form-control">
                                   <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                     </asp:DropDownList>
                            </div>
                            <div class="col-sm-3 col-xs-12">
                                <asp:Label ID="lblState" runat="server" Text="State"></asp:Label>
                              <asp:DropDownList ID="ddlState" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlState_SelectedIndexChanged" CssClass="form-control">
                                  <asp:ListItem Value="0" Text="--Select--"></asp:ListItem> 
                                   </asp:DropDownList>
                            </div>
                            <div class="col-sm-3 col-xs-12">
                                <asp:Label ID="lblCity" runat="server" Text="City"></asp:Label>
                                <asp:DropDownList ID="ddlagentCity" runat="server" CssClass="form-control">
                                   <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                     </asp:DropDownList>
                            </div>
                        </div>
                        <%-----------------------------------------------------------------%>


                        <div class="row form-group">
                            <div class="col-sm-3 col-xs-12">
                                <asp:Label ID="lblpin" runat="server" Text="Agent Pin"></asp:Label>
                                <asp:TextBox ID="txtpin" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-sm-3 col-xs-12">
                                <asp:Label ID="lblemailid" runat="server" Text="Agent EmailId"></asp:Label>
                                <asp:TextBox ID="txtemailid" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                             <div class="col-sm-3 col-xs-12">
                                <asp:Label ID="lblph" runat="server" Text="Agent Phone"></asp:Label>
                                <asp:TextBox ID="txtph" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-sm-3 col-xs-12">
                                <asp:Label ID="lblfax" runat="server" Text="Agent Fax"></asp:Label>
                                <asp:TextBox ID="txtfax" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row form-group">                           
                            <div class="col-sm-3 col-xs-12">
                                <asp:Label ID="lblenable" runat="server" Text="Agent Enable"></asp:Label>
                                <asp:TextBox ID="txtenable" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-sm-3 col-xs-12">
                                <asp:Label ID="lblpriority" runat="server" Text="Agent Priority"></asp:Label>
                                <asp:TextBox ID="txtpriority" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                             <div class="col-sm-3 col-xs-12">
                                <asp:Label ID="lblscharge" runat="server" Text="Agent Service Charge"></asp:Label>
                                <asp:TextBox ID="txtscharge" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-sm-3 col-xs-12">
                                <asp:Label ID="lblccharge" runat="server" Text="Agent Courier Charge"></asp:Label>
                                <asp:TextBox ID="txtccharge" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row form-group">
                           
                            <div class="col-sm-3 col-xs-12">
                                <asp:Label ID="lbltallyaccnt" runat="server" Text="Tally Account Name"></asp:Label>
                                <asp:TextBox ID="txttallyaccnt" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-sm-3 col-xs-12">
                                <asp:Label ID="lbldcharge" runat="server" Text="Agent Draft Charge"></asp:Label>
                                <asp:TextBox ID="txtdcharge" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                             <div class="col-sm-3 col-xs-12">
                                <asp:Label ID="lblopenbal" runat="server" Text="Opening Balance"></asp:Label>
                                <asp:TextBox ID="txtob" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="text-right">
                            <asp:Button ID="btnExport" runat="server" Text="Download" OnClick="btnExport_Click" CssClass="button-1" />
                            <asp:Button ID="btnupdate" runat="server" Text="Update" OnClick="btnupdate_Click" CssClass="button-1" ValidationGroup="validgroup" />
                        </div>

                    </div>
                </div>
                <div class="table table-responsive" style="overflow-x: scroll;">
                    <asp:GridView ID="gvDetails" DataKeyNames="AgentId,AgentName" runat="server" AutoGenerateColumns="False"
                        AllowPaging="True" CssClass="gridview table table-bordered table-striped table-condensed" PageSize="50" CellPadding="5" OnRowCancelingEdit="gvDetails_RowCancelingEdit"
                        OnRowDeleting="gvDetails_RowDeleting" OnRowEditing="gvDetails_RowEditing" OnRowUpdating="gvDetails_RowUpdating"
                        OnPageIndexChanging="gvDetails_PageIndexChanging" OnRowDataBound="gvDetails_RowDataBound" OnRowCommand="gvDetails_RowCommand">
                        <HeaderStyle CssClass="gridViewHeader" />
                        <RowStyle CssClass="gridViewRow" />
                        <AlternatingRowStyle CssClass="gridViewAltRow" />
                        <SelectedRowStyle CssClass="gridViewSelectedRow" />
                        <PagerStyle CssClass="gridViewPager" />
                        <Columns>
                             <asp:TemplateField HeaderText="Action">
                                <%-- <EditItemTemplate>
                                    <asp:LinkButton ID="linbtn_edit" runat="server" CommandName="Update" ToolTip="Update" style="margin-bottom:10px; display: block;"><i class="glyphicon glyphicon-refresh"></i></asp:LinkButton>
                                    <asp:LinkButton ID="linbtn_delete" runat="server" CommandName="Cancel" ToolTip="Cancel"><i class="glyphicon glyphicon-remove"></i></asp:LinkButton>
                                </EditItemTemplate>--%>
                                <ItemTemplate>
                                    <asp:LinkButton ID="linbtn_edit" runat="server" CommandArgument='<%#Eval("AgentId") %>' CommandName="Edit" ToolTip="Edit" Style="margin-bottom: 10px; display: block;"><i class="glyphicon glyphicon-edit"></i></asp:LinkButton>
                                    <asp:LinkButton ID="linbtn_delete" runat="server" CommandArgument='<%#Eval("AgentId") %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Agent Id">
                                <EditItemTemplate>
                                    <asp:Label ID="lbleditusr" runat="server" Text='<%#Eval("AgentId") %>' />
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblitemUsr" runat="server" Text='<%#Eval("AgentId") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Agent Name">
                                <%-- <EditItemTemplate>
                                    <asp:TextBox ID="txtname" runat="server" Text='<%#Eval("AgentName") %>' />
                                </EditItemTemplate>--%>
                                <ItemTemplate>
                                    <asp:Label ID="lblname" runat="server" Text='<%#Eval("AgentName") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="AGENT USERNAME">
                                <%--<EditItemTemplate>
                        <asp:TextBox ID="txtusername" runat="server" Text='<%#Eval("AgentUserName") %>' />
                    </EditItemTemplate>--%>
                                <ItemTemplate>
                                    <asp:Label ID="lblusername" runat="server" Text='<%#Eval("AgentUserName") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="AGENT PASSWORD">
                                <%-- <EditItemTemplate>
                        <asp:TextBox ID="txtpass" runat="server" Text='<%#Eval("AgentPassword") %>' />
                    </EditItemTemplate>--%>
                                <ItemTemplate>
                                    <asp:Label ID="lblpass" runat="server" Text='<%#Eval("AgentPassword") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Agent Enable">

                                <%-- <EditItemTemplate>
                                    <asp:TextBox ID="txtenable" runat="server" Text='<%#Eval("AgentEnable") %>' />
                                </EditItemTemplate>--%>
                                <ItemTemplate>
                                    <%--<asp:Label ID="lblenable" runat="server" Text='<%#Eval("AgentEnable") %>' />--%>
                                    <asp:RadioButton ID="RBtnY" runat="server" GroupName="RB" value="1" OnCheckedChanged="RBtnY_CheckedChanged" AutoPostBack="true" Checked='<%# (((string)DataBinder.Eval(Container.DataItem,"AgentEnable")) == "Y") ? (true) : (false )%>' class="radioY" />Y
                        <asp:RadioButton ID="RBtnN" runat="server" GroupName="RB" value="0" OnCheckedChanged="RBtnY_CheckedChanged" AutoPostBack="true" Checked='<%# (((string)DataBinder.Eval(Container.DataItem,"AgentEnable")) == "N") ? (true) : (false )%>' class="radioN" />N
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Agent Contact Person">
                                <%--<EditItemTemplate>
                                    <asp:TextBox ID="txtcper" runat="server" Text='<%#Eval("AgentCPerson") %>' />
                                </EditItemTemplate>--%>
                                <ItemTemplate>
                                    <asp:Label ID="lblcper" runat="server" Text='<%#Eval("AgentCPerson") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Agent Address">
                                <%--<EditItemTemplate>
                                    <asp:TextBox ID="txtadd" runat="server" Text='<%#Eval("AgentAddress") %>' />
                                </EditItemTemplate>--%>
                                <ItemTemplate>
                                    <asp:Label ID="lbladd" runat="server" Text='<%#Eval("AgentAddress") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Agent City">
                                <%--<EditItemTemplate>
                                    <asp:TextBox ID="txtcity" runat="server" Text='<%#Eval("AgentCity") %>' />
                                </EditItemTemplate>--%>
                                <ItemTemplate>
                                    <asp:Label ID="lblcity" runat="server" Text='<%#Eval("AgentCity") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Agent Pin">
                                <%--<EditItemTemplate>
                                    <asp:TextBox ID="txtpin" runat="server" Text='<%#Eval("AgentPin") %>' />
                                </EditItemTemplate>--%>
                                <ItemTemplate>
                                    <asp:Label ID="lblpin" runat="server" Text='<%#Eval("AgentPin") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Agent EmailId">
                                <%-- <EditItemTemplate>
                                    <asp:TextBox ID="txtemail" runat="server" Text='<%#Eval("AgentEmail") %>' />
                                </EditItemTemplate>--%>
                                <ItemTemplate>
                                    <asp:Label ID="lblemail" runat="server" Text='<%#Eval("AgentEmail") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Agent Phone">
                                <%-- <EditItemTemplate>
                                    <asp:TextBox ID="txtphone" runat="server" Text='<%#Eval("AgentPhone") %>' />
                                </EditItemTemplate>--%>
                                <ItemTemplate>
                                    <asp:Label ID="lblphone" runat="server" Text='<%#Eval("AgentPhone") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Agent Fax">
                                <%-- <EditItemTemplate>
                                    <asp:TextBox ID="txtfax" runat="server" Text='<%#Eval("AgentFax") %>' />
                                </EditItemTemplate>--%>
                                <ItemTemplate>
                                    <asp:Label ID="lblfax" runat="server" Text='<%#Eval("AgentFax") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Agent Prority">
                                <%--<EditItemTemplate>
                                    <asp:TextBox ID="txtpro" runat="server" Text='<%#Eval("AgentPrority") %>' />
                                </EditItemTemplate>--%>
                                <ItemTemplate>
                                    <asp:Label ID="lblpro" runat="server" Text='<%#Eval("AgentPrority") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Agent Service Charge">
                                <%--<EditItemTemplate>
                                    <asp:TextBox ID="txtscharge" runat="server" Text='<%#Eval("AgentSCharge") %>' />
                                </EditItemTemplate>--%>
                                <ItemTemplate>
                                    <asp:Label ID="lblscharge" runat="server" Text='<%#Eval("AgentSCharge") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Agent Courier Charge">
                                <%--<EditItemTemplate>
                                    <asp:TextBox ID="txtccharge" runat="server" Text='<%#Eval("AgentCCharge") %>' />
                                </EditItemTemplate>--%>
                                <ItemTemplate>
                                    <asp:Label ID="lblccharge" runat="server" Text='<%#Eval("AgentCCharge") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Agent Draft Charge">
                                <%-- <EditItemTemplate>
                                    <asp:TextBox ID="txtdcharge" runat="server" Text='<%#Eval("AgentDDCharge") %>' />
                                </EditItemTemplate>--%>
                                <ItemTemplate>
                                    <asp:Label ID="lbldcharge" runat="server" Text='<%#Eval("AgentDDCharge") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Opening Balance">
                                <%--<EditItemTemplate>
                                    <asp:TextBox ID="txtopening" runat="server" Text='<%#Eval("OpeningBalance") %>' />
                                </EditItemTemplate>--%>
                                <ItemTemplate>
                                    <asp:Label ID="lblopening" runat="server" Text='<%#Eval("OpeningBalance") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="Tally Account Name">
                                <%-- <EditItemTemplate>
                                    <asp:TextBox ID="txttally" runat="server" Text='<%#Eval("TallyACName") %>' />
                                </EditItemTemplate>--%>
                                <ItemTemplate>
                                    <asp:Label ID="lbltally" runat="server" Text='<%#Eval("TallyACName") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <div>
                    <asp:Label ID="lblresult" runat="server"></asp:Label>
                </div>

                <div class="table table-responsive">
                    <asp:GridView ID="grid_search" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                        CssClass="gridview table table-bordered table-striped table-condensed" PageSize="15"
                        CellPadding="5" OnPageIndexChanging="grid_search_PageIndexChanging" OnRowCommand="grid_search_RowCommand">
                        <HeaderStyle CssClass="gridViewHeader" />
                        <RowStyle CssClass="gridViewRow" />
                        <AlternatingRowStyle CssClass="gridViewAltRow" />
                        <SelectedRowStyle CssClass="gridViewSelectedRow" />
                        <PagerStyle CssClass="gridViewPager" />
                        <Columns>
                            <asp:TemplateField HeaderText="Agent Id">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_agentname" runat="server" Text='<%# Eval("AgentId") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Agent Name">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_agentname" runat="server" Text='<%# Eval("AgentName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="AGENT CPERSON">
                                <ItemTemplate>
                                    <asp:Label ID="lblcper" runat="server" Text='<%#Eval("AgentCPerson") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="AGENT ADDRESS">
                                <ItemTemplate>
                                    <asp:Label ID="lbladd" runat="server" Text='<%#Eval("AgentAddress") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="AGENT CITY">
                                <ItemTemplate>
                                    <asp:Label ID="lblcity" runat="server" Text='<%#Eval("AgentCity") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="AGENT PIN">
                                <ItemTemplate>
                                    <asp:Label ID="lblpin" runat="server" Text='<%#Eval("AgentPin") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="AGENT EMAIL">
                                <ItemTemplate>
                                    <asp:Label ID="lblemail" runat="server" Text='<%#Eval("AgentEmail") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="AGENT PHONE">
                                <ItemTemplate>
                                    <asp:Label ID="lblphone" runat="server" Text='<%#Eval("AgentPhone") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="AGENT FAX">
                                <ItemTemplate>
                                    <asp:Label ID="lblfax" runat="server" Text='<%#Eval("AgentFax") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                    </asp:GridView>
                </div>

                <div class="text-right">
                    <asp:Button ID="btnupdateStatus" runat="server" Text="Update Status" CssClass="button-1" OnClick="btnupdateStatus_Click" />
                </div>

            </div>
        </div>
    </div>
</asp:Content>
