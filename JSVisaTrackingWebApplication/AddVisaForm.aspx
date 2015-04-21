<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="AddVisaForm.aspx.cs" Inherits="JSVisaTrackingWebApplication.AddVisaForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        function confirmation() {
            if (confirm('Are you sure you want to Save ?')) {
                return true;
            } else {
                return false;
            }
        }
        function confirmation1() {
            if (confirm('Are you sure you want to Delete ?')) {
                return true;
            } else {
                return false;
            }
        }
    </script>
    <script type="text/javascript">
        function ValidateModuleList(source, args) {
            var chkListModules = document.getElementById('<%= CheckBoxcity.ClientID %>');
            var chkListinputs = chkListModules.getElementsByTagName("input");
            for (var i = 0; i < chkListinputs.length; i++) {
                if (chkListinputs[i].checked) {
                    args.IsValid = true;
                    return;
                }
            }
            args.IsValid = false;
        }
    </script>
    <!--[if lt IE 9]>
<script src="http://html5shim.googlecode.com/svn/trunk/html5.js"></script>
<![endif]-->
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
                <div class="col-xs-12 col-sm-6">Add Visa Form</div>
                <div class="col-xs-12 col-sm-6 caption text-right">Visa /  Add Visa Form</div>
            </div>
        </div>
    </div>
      <div class="container">
        <div class="row">
            <div class="col-xs-12 col-sm-12">
                 <div class="form-inner-bg">

    <div class="col-sm-12 col-xs-12">
         <asp:ValidationSummary ID="ValidationSummary1" ShowMessageBox="true" ShowSummary="false"
        runat="server" ValidationGroup="Summery1" />
        
     <div class="row form-group">
        <div class="col-sm-4 col-xs-12">
            <label>Visa Form City</label>
            
       <div style="height:80px; padding:2px; overflow:auto; border: 1px solid #ccc;">
            <asp:CheckBoxList ID="CheckBoxcity" runat="server">
            </asp:CheckBoxList></div>
                                







            <%--<asp:CheckBoxList ID="CheckBoxcity" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem>Delhi</asp:ListItem>
                    <asp:ListItem>Mumbai</asp:ListItem>
                    <asp:ListItem>Chennai</asp:ListItem>
                    <asp:ListItem>Bangalore</asp:ListItem>
                </asp:CheckBoxList>--%>
                <asp:CustomValidator runat="server" ID="cvmodulelist" ClientValidationFunction="ValidateModuleList"
                    ErrorMessage="Please Select At Least one City" ValidationGroup="Summery1" Display="None"></asp:CustomValidator>
        </div>

         <div class="col-sm-3 col-xs-12">
              <label>Country Name For Visa<span class="red">*</span></label>
              <asp:DropDownList ID="DropDownList_contry" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                
                <asp:RequiredFieldValidator ID="rfv_Country" runat="server" ErrorMessage="Please Select Country Name"
                    ControlToValidate="DropDownList_contry" InitialValue="0" Display="None" SetFocusOnError="True"
                    ValidationGroup="Summery1">
                </asp:RequiredFieldValidator>
         </div>
         <div class="col-sm-2 col-xs-12">
                <label>Visa Title<span class="red">*</span></label>
               <asp:TextBox ID="txtvisatitle" runat="server"  CssClass="form-control"></asp:TextBox>
                 
           
                <asp:RequiredFieldValidator ID="rfv_visatitle" runat="server" ControlToValidate="txtvisatitle"
                    ValidationGroup="Summery1" SetFocusOnError="true" ErrorMessage="Please Enter Visa Title"
                    Display="None">
                </asp:RequiredFieldValidator>
         </div>
          <div class="col-sm-3 col-xs-12">
                  <label>Upload Visa Form<span class="red">*</span></label>
                <asp:FileUpload ID="uploadform" runat="server"  CssClass="form-control"/>
                <asp:RequiredFieldValidator ID="rfvUpload" runat="server" ControlToValidate="uploadform"
                    ErrorMessage="File Required!" Display="None" ValidationGroup="Summery1">
                </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator id="RValidator" runat="server" 
      ControlToValidate="uploadform" 
      ValidationGroup="Summery1" 
      ErrorMessage="Upload PDF files only" 
      Display="None" 
      CssClass="validationMsg" 
      ValidationExpression="^(([0-9])|([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))(.pdf|.PDF|.doc|.DOC|.docx|.DOCX)$"/>
          </div>
     </div>
         <div class="text-right">
              <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" CssClass="button-1"/>
        <asp:Button ID="btnadd" runat="server" Text="Add" OnClick="btnadd_Click" ValidationGroup="Summery1"  CssClass="button-1"/></div>
   

                 </div>
                      </div>
           
   <div class="table-responsive">
        <asp:GridView runat="server" ID="Visa_gridview" AutoGenerateColumns="False" OnRowCommand="Visa_gridview_RowCommand"
            CellPadding="5" CssClass="gridview table table-bordered table-striped table-condensed" PageSize="10">
            <HeaderStyle CssClass="gridViewHeader" />
            <RowStyle CssClass="gridViewRow" />
            <AlternatingRowStyle CssClass="gridViewAltRow" />
            <SelectedRowStyle CssClass="gridViewSelectedRow" />
            <PagerStyle CssClass="gridViewPager" />
            <Columns>
                <asp:TemplateField HeaderText="ID">
                    <ItemTemplate>
                        <asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
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
                        
                            <asp:LinkButton ID="LinkButton5" runat="server" CommandName="cmdDelete" CommandArgument='<%#Eval("Id") %>'
                                    ToolTip="Delete" OnClientClick="return confirmation1();" ><i class="glyphicon glyphicon-trash"></i></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <HeaderStyle Font-Size="10pt" />
        </asp:GridView>
          <div class="text-right form-group">
        <asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click" OnClientClick="return confirmation();"  CssClass="button-1"/></div>
    </div>
 
                </div>
            </div>
              </div>
       
   
</asp:Content>
