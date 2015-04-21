using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Remielsoft.JetSave.DomianObjectModel;
using Remielsoft.JetSave.BusinessAccessLayer;
using System.Web.Configuration;
using JSVisaTrackingWebApplication.Shared;
using System.IO;

namespace JSVisaTrackingWebApplication
{
    public partial class UserMaster : System.Web.UI.Page
    {
        #region Global Variable(s)

        Location obj1 = new Location();
        BasePage basePage = new BasePage();
        UserBAL ob = new UserBAL();
        MetaDataBal metabal = new MetaDataBal();
        LocationBusinessAccess locationBAL = new LocationBusinessAccess();
        #endregion

        #region Protected Method(s)

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                basePage.BindDropDown(ddllocation, "City", "LocationId", locationBAL.ReadLocation(null));
                BindgvwUser();
                BindRadioButton();
                txtdob.Text = DateTime.Now.AddYears(-15).ToString();
                String name = basePage.LoggedInUser.FullName;
            }
        }
        
        protected void btnSave_Click1(object sender, EventArgs e)
        {
            int out1 = 0;
            UserDom user = new UserDom();
            user.FirstName = txtFName.Text;
            user.MiddleName = txtMiddleName.Text;
            user.LastName = txtlname.Text;
            user.Password = txtpassword.Text;
            user.EmpCode = txtEmpCode.Text;
            user.UserLocation = new LocationMaster();
            user.UserLocation.LocationId = (Convert.ToInt32(ddllocation.SelectedItem.Value));
            user.LoginId = txtLoginId.Text;
            user.EmailId = txtemail.Text;
            user.PhoneNo = txtphn.Text;
            user.MobileNo = txtmobile.Text;
            user.OfficeExtentionNo = txtofficeextno.Text;
            user.Gender = rdbgender.SelectedItem.Text;
            user.Address = txtaddress.Text;
            user.UserTypeId = Convert.ToInt32(rbtnUserType.SelectedValue);
            user.MaritalStatus = rdbMaritalstatus.SelectedItem.Text;
            user.DateOfBirth = Convert.ToDateTime(txtdob.Text);
            out1 = ob.CreateUser(user);
            if (out1 > 0)
            {
                ScriptManager.RegisterClientScriptBlock(btnSave, GetType(), "test", "alert('User created successfully')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(btnSave, GetType(), "test", "alert('EmpCode already exist')", true);
            }
            BindgvwUser();
            CancelUserDetails();
        }

        protected void gvw_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int userId = 0;
            userId = Convert.ToInt32(e.CommandArgument);
            this.UserId = userId;
            if (e.CommandName == "cmdEditt")
            {
                SetControlsName(GetUserById(userId));
                btnSave.Visible = false;
            }
            if (e.CommandName == "cmdDelete")
            {
                ob.DeleteUserMaster(userId, "Admin", DateTime.Now);
                BindgvwUser();
            }
            if (e.CommandName == "cmdDetails")
            {
                UserDom userdom = new UserDom();
                userdom = ob.ReadUserById(userId);
                lblname.Text = userdom.FirstName;
                lblLid.Text = userdom.LoginId;
                ddllocation.SelectedValue = (userdom.UserLocation.LocationName).ToString();
                lbladd.Text = userdom.Address;
                lblemail.Text = userdom.EmailId;
                lblEmpCode.Text = userdom.EmpCode;
                lblgender.Text = userdom.Gender;
                lblphone.Text = userdom.PhoneNo;
                //this.modalpopupExt.Show();
                BindgvwUser();
            }
            if (e.CommandName == "cmdUserTaskMapping")
            {
                Response.Redirect("UserTaskMapping.aspx?UserId=" + userId);
            }
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            int out1 = 0;
            UserDom user = new UserDom();
            user.UserId = this.UserId;
            user.FirstName = txtFName.Text;
            user.MiddleName = txtMiddleName.Text;
            user.LastName = txtlname.Text;
            user.Password = txtpassword.Text;
            user.EmpCode = txtEmpCode.Text;
            user.UserLocation = new LocationMaster();
            user.UserLocation.LocationId = (Convert.ToInt32(ddllocation.SelectedItem.Value));
            user.LoginId = txtLoginId.Text;
            user.EmailId = txtemail.Text;
            user.PhoneNo = txtphn.Text;
            user.MobileNo = txtmobile.Text;
            user.OfficeExtentionNo = txtofficeextno.Text;
            user.Gender = rdbgender.SelectedItem.Text;
            user.Address = txtaddress.Text;
            user.MaritalStatus = rdbMaritalstatus.SelectedItem.Text;
            user.UserTypeId = Convert.ToInt32(rbtnUserType.SelectedValue);
            user.DateOfBirth = Convert.ToDateTime(txtdob.Text);
            user.ModifiedBy = "Admin";
            user.ModifiedDate = DateTime.Now;
            out1 = ob.UpdateUserMaster(user);
            if (out1 > 0)
            {
                ScriptManager.RegisterClientScriptBlock(btnupdate, GetType(), "a", "alert('User Updated successfully')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(btnupdate, GetType(), "a", "alert('Can't Enter duplicate Emp Code')", true);
            }
            BindgvwUser();
            CancelUserDetails();
        }

        #endregion

        #region Private Method(s)

        public List<MetaData> GetData()
        {
            List<MetaData> lstmeta = new List<MetaData>();
            MetaData metadata = new MetaData();
            lstmeta = metabal.ReadMetaDataUserType();
            return lstmeta;
        }

        public void BindRadioButton()
        {
            rbtnUserType.DataSource = GetData();
            rbtnUserType.DataTextField = "Name";
            rbtnUserType.DataValueField = "Id";
            rbtnUserType.DataBind();
        }

        public List<UserDom> GetUserDetails()
        {
            List<UserDom> lstdom = new List<UserDom>();
            UserDom userdom = new UserDom();
            lstdom = ob.ReadUserMaster();
            return lstdom;
        }

        public UserDom GetUserById(int userId)
        {
            return ob.ReadUserById(userId);
        }

        public void BindgvwUser()
        {
            gvw.DataSource = GetUserDetails();
            gvw.DataBind();
        }

        public void SetControlsName(UserDom userdom)
        {
            //UserDom userdom = new UserDom();
            txtFName.Text = userdom.FirstName;
            txtMiddleName.Text = userdom.MiddleName;
            txtlname.Text = userdom.LastName;

            if (userdom.DateOfBirth != DateTime.MinValue)
            {
                txtdob.Text = Convert.ToString(userdom.DateOfBirth);
            }
            else
            {
                
            }
            txtemail.Text = userdom.EmailId;
            txtEmpCode.Text = userdom.EmpCode;
            txtaddress.Text = userdom.Address;
            rdbgender.SelectedValue = userdom.Gender;
            rdbMaritalstatus.SelectedValue = userdom.MaritalStatus;
            txtLoginId.Text = userdom.LoginId;
            txtmobile.Text = userdom.MobileNo;
            txtofficeextno.Text = userdom.OfficeExtentionNo;
            txtpassword.Text = userdom.Password;
            //txtConfirmPassword.Text = userdom.Password;
            txtphn.Text = userdom.PhoneNo;
            ddllocation.SelectedValue = userdom.UserLocation.LocationId.ToString();
            rdbgender.SelectedValue = userdom.Gender;
            rdbMaritalstatus.SelectedValue = userdom.MaritalStatus;
            rbtnUserType.SelectedValue = userdom.UserTypeId.ToString();
        }

        private void CancelUserDetails()
        {
            txtLoginId.Text = string.Empty;
            txtFName.Text = string.Empty;
            txtMiddleName.Text = string.Empty;
            txtlname.Text = string.Empty;
            txtpassword.Text = string.Empty;
            txtConPass.Text = string.Empty;
            txtaddress.Text = string.Empty;
            txtemail.Text = string.Empty;
            txtEmpCode.Text = string.Empty;
            txtemail.Text = string.Empty;
            txtmobile.Text = string.Empty;
            txtofficeextno.Text = string.Empty;
            txtphn.Text = string.Empty;
            ddllocation.SelectedValue = "0";
            rdbgender.SelectedValue = "false";
            rdbMaritalstatus.SelectedValue = "false";
        }

        #endregion

        #region Public Properties

        public int UserId
        {
            get
            {
                return Convert.ToInt32(ViewState["userid"]);
            }
            set
            {
                ViewState["userid"] = value;
            }
        }

        #endregion
    }
}