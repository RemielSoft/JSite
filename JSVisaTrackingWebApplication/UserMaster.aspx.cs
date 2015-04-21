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
        List<LocationMaster> lstLocation = null;

        #endregion

        #region Protected Method(s)

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lstLocation = locationBAL.ReadLocation(null);
                if (lstLocation.Count > 0)
                {
                    //var lst = lstLocation.Where(p => p.City.Equals(0)).Distinct();
                    basePage.BindDropDown(ddllocation, "City", "LocationId", locationBAL.ReadLocation(null));
                }
                BindgvwUser();
                BindRadioButton();
                SetValidationExp();
                txtdob.Text = DateTime.Now.AddYears(-15).ToString("MM/dd/yyyy");
                String name = basePage.LoggedInUser.FullName;
                btnupdate.Visible = false;
                btnSave.Visible = true;
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
            user.Created_By = basePage.LoggedInUser.LoginId;
            out1 = ob.CreateUser(user);
            if (out1 > 0)
            {
                ScriptManager.RegisterClientScriptBlock(btnSave, GetType(), "test", "alert('User created successfully')", true);
                CancelUserDetails();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(btnSave, GetType(), "test", "alert('EmpCode already exist')", true);
            }
            BindgvwUser();
            btnupdate.Visible = false;
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
                btnupdate.Visible = true;
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
                lblname.Text = userdom.FullName;
                lblLid.Text = userdom.LoginId;
                lbladd.Text = userdom.Address;
                lblemail.Text = userdom.EmailId;
                lblEmpCode.Text = userdom.EmpCode;
                lblgender.Text = userdom.Gender;
                lblphone.Text = userdom.PhoneNo;
                lblDOB.Text = userdom.DateOfBirth.ToString();
                lbllocation.Text = userdom.UserLocation.City;
                lblMobNo.Text = userdom.MobileNo;
                lblOfficeExtNo.Text = userdom.OfficeExtentionNo;
                lblPwd.Text = userdom.Password;
                lblMarritalS.Text = userdom.MaritalStatus;
                ModalPopupExtender1.Show();
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
            user.Modified_By = basePage.LoggedInUser.LoginId;
            user.Modified_Date = DateTime.Now;
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
            btnupdate.Visible = false;
        }

        protected void gvw_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvw.PageIndex = e.NewPageIndex;
            BindgvwUser();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            CancelUserDetails();
        }

        #endregion

        #region Private Method(s)

        private void SetValidationExp()
        {
            revFName.ValidationExpression = RegularExpression.C_ALPHANUMERIC;
            revFName.ErrorMessage = "First Name Should Be Alphanumeric";
            revMName.ValidationExpression = RegularExpression.C_ALPHANUMERIC;
            revMName.ErrorMessage = "Middle Name Should Be Alphanumeric";
            revLName.ValidationExpression = RegularExpression.C_ALPHANUMERIC;
            revLName.ErrorMessage = "Last Name Should Be Alphanumeric";
            revLoginId.ValidationExpression = RegularExpression.C_USER_ID;
            revLoginId.ErrorMessage = "Login-Id Should Be Alphanumeric";
            revEmpCode.ValidationExpression = RegularExpression.C_ALPHANUMERIC;
            revEmpCode.ErrorMessage = "Emp Code Should Be Alphanumeric";
            revMobile.ValidationExpression = RegularExpression.C_MOBILE_PHONE_NUMBER;
            revMobile.ErrorMessage = "Mobile Number Should Be In Minimum 10 Digits";
            revPhone.ValidationExpression = RegularExpression.C_MOBILE_PHONE_NUMBER;
            revPhone.ErrorMessage = "Phone Number Should Be In Minimum 10 Digits";
            revOfficeExtNo.ValidationExpression = RegularExpression.C_NUMERIC;
            revOfficeExtNo.ErrorMessage = "Office Extension No. Should Be Numeric";
            revEmailId.ValidationExpression = RegularExpression.C_EMAIL_ID;
            revEmailId.ErrorMessage = "Invalid Email Entry";
            revPassword.ValidationExpression = RegularExpression.C_PASSWORD;
            revPassword.ErrorMessage = "Password Must Contain At Least 1 Alphabate, 1 Digit, No Special Characters And Length Must Be 5-20";
            //revAddress.ValidationExpression = ValidationExpression.C_ADDRESS;
            //revAddress.ErrorMessage = GlobalConstants.C_ERROR_MESSAGE_ADDRESS;
        }

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
            txtdob.Text = string.Empty;
            txtofficeextno.Text = string.Empty;
            txtphn.Text = string.Empty;
            ddllocation.SelectedValue = "0";
            rdbgender.SelectedValue = "false";
            rdbMaritalstatus.SelectedValue = "false";
            btnupdate.Visible = false;
            btnSave.Visible = true;
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