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
    public partial class Test2 : System.Web.UI.Page
    {
        NewsLetterBAL newsbal = new NewsLetterBAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindNewsLetter();
                Cancel();
            }
            
        }
       
        protected void lbtnNews_Click(object sender, EventArgs e)
        {
            
        }

        protected void lbtnDetail_Click(object sender, EventArgs e)
        {
            
         
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            int out1 = 0;
            NewsLetterDom newsdom = new NewsLetterDom();
            newsdom.TopicName = txtTopic.Text;
            newsdom.Description = txtdes.Text;
            newsdom.CreatedBy = "Admin";
            out1 = newsbal.CreateNewsLetter(newsdom);
            if (out1 > 0)
            {
                ScriptManager.RegisterClientScriptBlock(btn, GetType(), "test", "alert('News Created Successfully')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(btn, GetType(), "test", "alert('News Not created ')", true);
            }
            BindNewsLetter();
            Cancel();
        }

        public List<NewsLetterDom> GetNewsLetterDetail()
        {
            List<NewsLetterDom> lstnewsdom = new List<NewsLetterDom>();
            lstnewsdom = newsbal.ReadNewsLetter();
            return lstnewsdom;
        }
        public void BindNewsLetter()
        {
            gvwNews.DataSource = GetNewsLetterDetail();
            gvwNews.DataBind();
        }

     
        public int TopicId
        {
            get
            {
                return Convert.ToInt32(ViewState["topicid"]);
            }
            set
            {
                ViewState["topicid"] = value;
            }
        }

        protected void gvwNews_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {

            int topicId = 0;
            topicId = Convert.ToInt32(e.CommandArgument);
             this.TopicId = topicId;

            if (e.CommandName == "cmdEdit")
            {
                 SetControlName(GetNewById(topicId));

               //  TabContainer1.ActiveTab = 0;
               
                //btn.Visible = false;
            }
            if (e.CommandName == "cmdelete")
            {
                newsbal.DeleteNewsLetter(topicId, "Admin", DateTime.Now);
                BindNewsLetter();
                Cancel();
            }
            if (e.CommandName == "cmdDetails")
            {
                //pnlDetails.Visible = true;
                ModalPopupExtender2.Show();
            }
        }
        public void SetControlName(NewsLetterDom newsdom)
        {
            txtTopic.Text = newsdom.TopicName;
            txtdes.Text = newsdom.Description;
            // pnlEditor.Visible = true;
        }
        public NewsLetterDom GetNewById(int topicId)
        {
            return newsbal.ReadNewsLetterById(topicId);
        }
        protected void btnupdate_Click(object sender, EventArgs e)
        {

          
        }

        public void Cancel()
        {
            txtTopic.Text = string.Empty;
            txtdes.Text = string.Empty;
        }

        protected void btnupdate_Click1(object sender, EventArgs e)
        {
            NewsLetterDom newdom = new NewsLetterDom();
            newdom.TopicId = this.TopicId;
            newdom.TopicName = txtTopic.Text;
            newdom.Description = txtdes.Text;
            newdom.ModifiedBy = "Admin";
            newdom.ModifiedDate = DateTime.Now;
            newsbal.UpdateNewsLetter(newdom);

            BindNewsLetter();
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if
             (File1.HasFile)
            {
                try
                {
                    if
                    (File1.PostedFile.ContentType ==
                    "image/jpeg")
                    {
                        if
                        (File1.PostedFile.ContentLength < 8512000)
                        {
                            string
                            filename = System.IO.Path.GetFileName(File1.FileName);
                            File1.SaveAs(Server.MapPath("~/FileUploads/" + filename));
                            Label1.Text =
                            "File uploaded successfully!";
                        }
                        else

                            Label1.Text =
                            "File maximum size is 500 Kb";
                    }
                    else

                        Label1.Text =
                        "Only JPEG files are accepted!";
                }
                catch
                (Exception
                exc)
                {
                    Label1.Text =
                    "The file could not be uploaded. The following error occured: "

                    + exc.Message;
                }
            }
        }
       
    }
}