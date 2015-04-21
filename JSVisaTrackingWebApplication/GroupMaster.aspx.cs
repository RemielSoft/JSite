using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Remielsoft.JetSave.BusinessAccessLayer;
using Remielsoft.JetSave.DomianObjectModel;
using System.Data;
using System.Data.SqlClient;
using JSVisaTrackingWebApplication.Shared;
namespace JSVisaTrackingWebApplication
{
    public partial class GroupMaster : System.Web.UI.Page
    {
        GroupMasterBusinessAccess GroupmasterBusiness = new GroupMasterBusinessAccess();
        VisaRequirementBusinessAccess visareq = new VisaRequirementBusinessAccess();
        GroupMember groupmember = new GroupMember();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                dropbind();
                dropbind1();
                UserReg.Visible = false;
                Panel2.Visible = false;
                BindCountry();
            }


        }
        #region addgroup

        public void BindCountry()
        {
            Chklistcountry.DataSource = visareq.ReadCountry();
            Chklistcountry.DataTextField = "CountryName";
            Chklistcountry.DataValueField = "COUNTRY_ID";
            Chklistcountry.DataBind();
        }

        protected void btnaddgroup_Click(object sender, EventArgs e)
        {
            int Id;
            int check = 0;
            List<GroupMasterData> lstcountry = new List<GroupMasterData>();
            //Id = Convert.ToInt32(Chklistcountry.SelectedItem.Value);
            foreach (ListItem item in Chklistcountry.Items)
            {
                if (item.Selected == true)
                {
                    Id = Convert.ToInt32(item.Value);
                    lstcountry = GroupmasterBusiness.country(Id);
                    if (lstcountry.Count != 0)
                    {
                        if (lstcountry[0].CountryId == Convert.ToInt32(item.Value))
                        {
                            check = 1;
                            Response.Write("<Script Language=javascript>alert('" + lstcountry[0].CountryName + " is already exist in " + lstcountry[0].GroupName + " Group.  ');</Script>");
                            break;
                        }
                    }
                }

            }

            if (check == 0)
            {
                {
                    int success;
                    int groupId;
                    GroupMasterData groupmasterdata = new GroupMasterData();

                    groupmasterdata.GroupName = txtGroupName.Text;
                    groupmasterdata.GroupArea = txtGroupArea.Text;

                    List<GroupMasterData> lst = new List<GroupMasterData>();
                    lst = GroupmasterBusiness.insertgroup(groupmasterdata);

                    success = lst[0].Success;
                    groupId = lst[0].GroupId;
                    if (success == 1)
                    {
                        foreach (ListItem item in Chklistcountry.Items)
                        {
                            if (item.Selected == true)
                            {
                                GroupMasterData groupmaster = new GroupMasterData();
                                groupmaster.CountryId = Convert.ToInt32(item.Value);
                                groupmaster.GroupId = groupId;
                                GroupmasterBusiness.InsertGroupCountry(groupmaster);

                            }
                        }
                        
                        Response.Write("<Script Language=javascript>alert('Group Added Successfullly.  ');</Script>");
                    }
                    else
                    {
                        Response.Write("<Script Language=javascript>alert('Group Name is already exist.  ');</Script>");
                    }

                }
                empty();
                dropbind();
                dropbind1();
            }
        }
        #endregion

        #region dropdown
        public void dropbind()
        {
            List<GroupMasterData> lstGroup = new List<GroupMasterData>();
            lstGroup = GroupmasterBusiness.BindGroupName();
            ddlgroupname.DataSource = lstGroup;
            ddlgroupname.DataTextField = "GroupName";
            ddlgroupname.DataValueField = "GroupId";
            ddlgroupname.DataBind();
            ddlgroupname.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        public void dropbind1()
        {
            List<GroupMasterData> lstGroup = new List<GroupMasterData>();
            lstGroup = GroupmasterBusiness.BindGroupName();
            DrpdnGroupName.DataSource = lstGroup;
            DrpdnGroupName.DataTextField = "GroupName";
            DrpdnGroupName.DataValueField = "GroupId";
            DrpdnGroupName.DataBind();
            DrpdnGroupName.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        #endregion

        #region addMember
        protected void btnmember_Click(object sender, System.EventArgs e)
        {


            string Name;
            List<GroupMember> lst = new List<GroupMember>();

            Name = txtmember.Text;
            lst = (GroupmasterBusiness.memberName(Name));

            if (lst.Count > 0)
            {
                Response.Write("<Script Language=javascript>alert('Name is already exist in " + lst[0].groupMasterData.GroupName + "  ');</Script>");

            }
            else
            {
               
                groupmember.groupName = Convert.ToInt32(ddlgroupname.SelectedItem.Value);
                groupmember.MemberName = txtmember.Text;
                GroupmasterBusiness.insertMember(groupmember);
                Response.Write("<Script Language=javascript>alert('Group Member Added Successfullly.  ');</Script>");
            }
            empty();

        }
        #endregion

        #region empty
        public void empty()
        {
            txtGroupArea.Text = "";
            txtGroupName.Text = "";
            txtmember.Text = "";
            ddlgroupname.ClearSelection();
            DrpdnGroupName.ClearSelection();
            Chklistcountry.ClearSelection();
            //DropDownList1.ClearSelection();
            DropDownList1.Items.Clear();
        }
        #endregion

        protected void DrpdnGroupName_SelectedIndexChanged(object sender, System.EventArgs e)
        {

            int Id;
            Id = Convert.ToInt32(DrpdnGroupName.SelectedItem.Value);
            BindgrpName(Id);
            //DropDownList1.DataSource = GroupmasterBusiness.bindmember(Id);
            //DropDownList1.DataTextField = "GroupMember";
            //DropDownList1.DataValueField = "GroupName";
            //DropDownList1.DataBind();
            
        }
        public void BindgrpName(int Id)
        {
            DropDownList1.DataSource = GroupmasterBusiness.bindmember(Id);
            DropDownList1.DataTextField = "groupmember";
            DropDownList1.DataValueField = "groupName";
            DropDownList1.DataBind();
            //DropDownList1.Items.Insert(0, new ListItem("--Select--", "0"));

        }
        protected void addGroup_Click(object sender, System.EventArgs e)
        {
            UserReg.Visible = true;
            Panel2.Visible = false;
            btnGroupupdate.Visible = false;
            btnaddgroup.Visible = true;
            panel1.Visible = false;
            ContolDiv.Visible = false;
        }

        protected void adMember_Click(object sender, System.EventArgs e)
        {
            Panel2.Visible = true;
            UserReg.Visible = false;
            btnMemberUpdate.Visible = false;
            btnmember.Visible = true;
            panel1.Visible = false;
            ContolDiv.Visible = false;
        }

        protected void btnExit_Click(object sender, System.EventArgs e)
        {
            UserReg.Visible = false;
            Panel2.Visible = false;
            panel1.Visible = true;
            ContolDiv.Visible = true;
            empty();
        }

        protected void btnExit1_Click(object sender, System.EventArgs e)
        {
            UserReg.Visible = false;
            Panel2.Visible = false;
            panel1.Visible = true;
            ContolDiv.Visible = true; 
            
            empty();
        }

        protected void editGroup_Click(object sender, System.EventArgs e)
        {
            UserReg.Visible = true;
            Panel2.Visible = false;
            panel1.Visible = false;
            ContolDiv.Visible = false;
            btnGroupupdate.Visible = true;
            btnaddgroup.Visible = false;
            int id;
            List<GroupMasterData> lstedit = new List<GroupMasterData>();
            List<GroupMasterData> lstedit1 = new List<GroupMasterData>();
            id = Convert.ToInt32(DrpdnGroupName.SelectedItem.Value);
            ViewState["id"] = id;

            lstedit = GroupmasterBusiness.editGroup1(id);

            txtGroupName.Text = lstedit[0].GroupName;
            txtGroupArea.Text = lstedit[0].GroupArea;
            lstedit1 = GroupmasterBusiness.ReadCounryIdByID(id);
            for (int i = 0; i < lstedit1.Count; i++)
            {
                int value = lstedit1[i].CountryId;               
                foreach (ListItem item in Chklistcountry.Items)
                {
                    if (item.Value == Convert.ToString(value))
                    {
                        item.Selected = true;
                    }
                }

            }

        }

        protected void editMembwer_Click(object sender, System.EventArgs e)
         {
             //if (DropDownList1.Items.Count==0)
             //{
             //    Response.Write("<script Language=javascript> alert('Select Group Member');</script>");
             //}
             //else
             //{
                 txtmember.Text = DropDownList1.SelectedItem.Text;
                 Panel2.Visible = true;
                 UserReg.Visible = false;
                 panel1.Visible = false;
                 ContolDiv.Visible = false;
                 btnmember.Visible = false;
                 btnMemberUpdate.Visible = true;
                 int IdMember;
                 List<GroupMasterData> lst = new List<GroupMasterData>();
                 IdMember = Convert.ToInt32(DrpdnGroupName.SelectedItem.Value);
                 lst = GroupmasterBusiness.editGroup1(IdMember);
                 int groupIdd = lst[0].GroupId;
                 string name = lst[0].GroupName;
                 ddlgroupname.SelectedItem.Text = name;
                 ddlgroupname.SelectedItem.Value = Convert.ToString(groupIdd);
            // }

        }

        protected void btnGroupupdate_Click(object sender, System.EventArgs e)
        {
            int id = Convert.ToInt32(ViewState["id"]);
            int Id;
            int checkcountry = 0;
            //int c=Chklistcountry.Items.Count;
            List<GroupMasterData> lstcountry = new List<GroupMasterData>();
            //Id = Convert.ToInt32(Chklistcountry.SelectedItem.Value);
            foreach (ListItem item in Chklistcountry.Items)
            {
                if (item.Selected == true)
                {
                    Id = Convert.ToInt32(item.Value);
                    lstcountry = GroupmasterBusiness.country(Id);
                        if (lstcountry.Count != 0)
                        {
                            if (lstcountry[0].CountryId == Convert.ToInt32(item.Value))
                            {
                                if (lstcountry[0].GroupId == id)
                                {
                                }
                                else
                                {
                                    checkcountry = 1;
                                    Response.Write("<Script Language=javascript>alert('" + lstcountry[0].CountryName + " is already exist in " + lstcountry[0].GroupName + " Group.  ');</Script>");
                                    break;
                                }
                                
                            }
                        }
                    
                }

            }
            if (checkcountry == 0)
            {
                GroupMasterData updatemastergroup = new GroupMasterData();

                updatemastergroup.GroupName = txtGroupName.Text;
                updatemastergroup.GroupArea = txtGroupArea.Text;
                GroupmasterBusiness.updategroup1(id, updatemastergroup);                
                GroupmasterBusiness.deletegroup1(id);
                foreach (ListItem item in Chklistcountry.Items)
                {
                    if (item.Selected == true)
                    {
                        GroupMasterData groupmaster = new GroupMasterData();
                        groupmaster.CountryId = Convert.ToInt32(item.Value);
                        groupmaster.GroupId = id;
                       // GroupmasterBusiness.UpdateGroupCountry(groupmaster, id);
                        GroupmasterBusiness.InsertGroupCountry(groupmaster);                       
                       

                    }
                                    
                   
                }


                empty();
                Response.Write("<Script Language=javascript>alert('Group Updated Successfullly.  ');</Script>");
                panel1.Visible = true;
                ContolDiv.Visible = true;
                UserReg.Visible = false;
                dropbind();
            }
            
            
         }

        protected void btnMemberUpdate_Click(object sender, System.EventArgs e)
        {
            List<GroupMember> lst = new List<GroupMember>();
            
            int Id = Convert.ToInt32(DropDownList1.SelectedItem.Value);
            //lst = GroupmasterBusiness.bindmember(Id);
            //int IdMem = lst[0].groupName;

            groupmember.MemberName = txtmember.Text;
            groupmember.groupName = Convert.ToInt32( ddlgroupname.SelectedItem.Value);

            GroupmasterBusiness.UpdateGroupmember1(Id, groupmember);
            empty();
            panel1.Visible = true;
            ContolDiv.Visible = true;
            Panel2.Visible = false;
            Response.Write("<Script Language=javascript>alert('Group Member Updated Successfullly.  ');</Script>");
        }

    }
}