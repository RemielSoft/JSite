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
    public partial class NewsLetter : System.Web.UI.Page
    {
        #region globals Variables..

        NewsLetterBAL newsbal = new NewsLetterBAL();

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                BindNewsLetter();
                TabContainer1.ActiveTabIndex = 0;
                btnSave.Visible = true;
                btnUpdate.Visible = false;
                lblfile.Visible = false;
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            int out1 = 0;
            if (Session["ImageName"] != null)
            {
                NewsLetterDom newsdom = new NewsLetterDom();
                newsdom.TopicName = txtTopic.Text;
                newsdom.Description = txtdes.Text;
                newsdom.Created_By = "Admin";
                newsdom.ImageName = Session["ImageName"].ToString();
                out1 = newsbal.CreateNewsLetter(newsdom);
            }
            else
            {
                NewsLetterDom newsdom = new NewsLetterDom();
                newsdom.TopicName = txtTopic.Text;
                newsdom.Description = txtdes.Text;
                newsdom.Created_By = "Admin";
                out1 = newsbal.CreateNewsLetter(newsdom);

            }


            if (out1 > 0)
            {

                ScriptManager.RegisterClientScriptBlock(btnSave, GetType(), "test", "alert('NewsLetter Created Successfully')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(btnSave, GetType(), "test", "alert('NewsLetter Not Created ')", true);
            }

            BindNewsLetter();
            Cancel();
            // grvw_image.Visible = false;
            Session.Remove("ImageName");
        }

        protected void gvwNews_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {

            int topicId = 0;
            topicId = Convert.ToInt32(e.CommandArgument);
            var id = topicId;

            this.TopicId = id;
            List<NewsLetterDom> lstNews = new List<NewsLetterDom>();
            if (e.CommandName == "cmdEdit")
            {
                NewsLetterDom newsDom = new NewsLetterDom();
                SetControlName(GetNewById(topicId));
                string imageName = newsDom.ImageName;
                newsDom = newsbal.ReadNewsLetterByImage(topicId, imageName);
                lstNews.Add(newsDom);
                string Name = lstNews[0].ImageName;
                if (lstNews.Count > 0 && Name != null)
                {
                    grvw_image.DataSource = lstNews;
                    grvw_image.DataBind();
                }
                else
                {
                    grvw_image.DataSource = null;
                    grvw_image.DataBind();
                }
                // grvw_image.Visible = true;
                TabContainer1.ActiveTabIndex = 0;
                btnUpdate.Visible = true;
                btnSave.Visible = false;
                Session["f"] = lstNews;
            }
            if (e.CommandName == "cmdelete")
            {

                newsbal.DeleteNewsLetter(topicId, "Admin", DateTime.Now);
                BindNewsLetter();
                Cancel();
            }
            if (e.CommandName == "cmdDetails")
            {
                SetControlName(GetNewById(topicId));
                ModalPopupExtender2.Show();
                Cancel();
            }
        }

        protected void OpenDetails(object sender, EventArgs e)
        {

            if (lnkbtn1.Text != string.Empty)
            {
                if (lnkbtn1.Text.EndsWith(".txt"))
                {
                    Response.ContentType = "application/txt";
                }
                else if (lnkbtn1.Text.EndsWith(".pdf"))
                {
                    Response.ContentType = "application/pdf";
                }
                else if (lnkbtn1.Text.EndsWith(".docx"))
                {
                    Response.ContentType = "application/docx";
                }

                else if (lnkbtn1.Text.EndsWith(".xls"))
                {
                    Response.ContentType = "application/xls";
                }
                else if (lnkbtn1.Text.EndsWith(".zip"))
                {
                    Response.ContentType = "application/zip";
                }

                else
                {
                    Response.ContentType = "image/jpg";
                }
                string filePath = lnkbtn1.Text;

                Response.AddHeader("Content-Disposition", "attachment;filename=\"" + filePath + "\"");
                string path = Server.MapPath("~/AddVisaForm/" + filePath);
                if (File.Exists(path))
                {
                    Response.TransmitFile(Server.MapPath("~/AddVisaForm/" + filePath));
                }
                else
                    Response.Write("<script LANGUAGE='JavaScript' >alert('File not exist. ')</script>");
            }
        }

        protected void btnUpdate_Click1(object sender, EventArgs e)
        {
            List<NewsLetterDom> lstdom = new List<NewsLetterDom>();
            lstdom = (List<NewsLetterDom>)Session["f"];
            int out1 = 0;

            if (Session["ImageName"] != null)
            {

                NewsLetterDom newdom = new NewsLetterDom();
                newdom.TopicId = this.TopicId;
                newdom.TopicName = txtTopic.Text;
                newdom.Description = txtdes.Text;
                newdom.ImageName = Session["ImageName"].ToString();
                newdom.Modified_By = "Admin";
                newdom.Modified_Date = DateTime.Now;
                out1 = newsbal.UpdateNewsLetter(newdom);
            }
            else
            {
                if (lstdom != null)
                {
                    List<NewsLetterDom> lstdomNew = new List<NewsLetterDom>();
                    NewsLetterDom newdom = new NewsLetterDom();
                    newdom.TopicId = this.TopicId;
                    newdom.TopicName = txtTopic.Text;
                    newdom.Description = txtdes.Text;
                    newdom.ImageName = lstdom[0].ImageName;
                    newdom.Modified_By = "Admin";
                    newdom.Modified_Date = DateTime.Now;
                    out1 = newsbal.UpdateNewsLetter(newdom);
                }
                else
                {
                    NewsLetterDom newdom = new NewsLetterDom();
                    newdom.TopicId = this.TopicId;
                    newdom.TopicName = txtTopic.Text;
                    newdom.Description = txtdes.Text;
                    newdom.Modified_By = "Admin";
                    newdom.Modified_Date = DateTime.Now;
                    out1 = newsbal.UpdateNewsLetter(newdom);
                }
            }
            if (out1 > 0)
            {
                ScriptManager.RegisterClientScriptBlock(btnSave, GetType(), "test", "alert('NewsLetter Updated Successfully')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(btnSave, GetType(), "test", "alert('NewsLetter Not Updated')", true);
            }
            BindNewsLetter();
            Cancel();
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            // Session.Remove("FileName");
        }

        protected void btnUpload_Click1(object sender, EventArgs e)
        {
        }

        protected void grvw_image_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int topicId = 0;
            topicId = Convert.ToInt32(e.CommandArgument);
            this.TopicId = topicId;
            if (e.CommandName == "cmddelete")
            {
                newsbal.DeleteNewsLetterImage(topicId, "Admin", DateTime.Now);
                grvw_image.DataSource = new List<object>();
                grvw_image.DataBind();
                Session.Remove("f");
            }
        }

        protected void OpenImage(object sender, EventArgs e)
        {
            if (lnkbtn1.Text != string.Empty)
            {
                if (lnkbtn1.Text.EndsWith(".txt"))
                {
                    Response.ContentType = "application/txt";
                }
                else if (lnkbtn1.Text.EndsWith(".pdf"))
                {
                    Response.ContentType = "application/pdf";
                }
                else if (lnkbtn1.Text.EndsWith(".docx"))
                {
                    Response.ContentType = "application/docx";
                }

                else if (lnkbtn1.Text.EndsWith(".xls"))
                {
                    Response.ContentType = "application/xls";
                }
                else if (lnkbtn1.Text.EndsWith(".zip"))
                {
                    Response.ContentType = "application/zip";
                }

                else if (lnkbtn1.Text.EndsWith(".jpeg"))
                {
                    Response.ContentType = "application/jpeg";
                }
                else
                {
                    Response.ContentType = "image/jpg";
                }
                //lnkbtn1.Text = Session["FileName"].ToString();
                string filePath = lnkbtn1.Text;
                Response.AddHeader("Content-Disposition", "attachment;filename=\"" + filePath + "\"");
                Response.TransmitFile(Server.MapPath("~/AddVisaForm/" + filePath));


            }
        }

        protected void uploadimage_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpload1_Click(object sender, EventArgs e)
        {

            Int64 fileSize = uploadimage.PostedFile.ContentLength;
            if (!string.IsNullOrEmpty(uploadimage.FileName))
            {

                if ((uploadimage.HasFile) && (fileSize < 2097151000000))
                {
                    string fileExtension = Path.GetExtension(uploadimage.FileName);
                    fileExtension = fileExtension.ToLower();
                    string[] acceptedFileTypes = new string[8];
                    acceptedFileTypes[0] = ".pdf";
                    acceptedFileTypes[1] = ".doc";
                    acceptedFileTypes[2] = ".docx";
                    acceptedFileTypes[3] = ".jpg";
                    acceptedFileTypes[5] = ".xls";
                    acceptedFileTypes[6] = ".zip";
                    acceptedFileTypes[7] = ".txt";
                    bool acceptFile = false;

                    for (int i = 0; i <= 7; i++)
                    {
                        if (fileExtension == acceptedFileTypes[i])
                        {

                            acceptFile = true;
                        }
                    }

                    if (!acceptFile)
                    {

                        lblfile.Visible = true;
                        lblfile.Text = "only .pdf, .doc, .docx, .jpg, .xls, .zip types are allowed";
                        return;
                    }
                    NewsLetterDom newsdom = new NewsLetterDom();
                    newsdom.ImageName = uploadimage.FileName;
                    string filename1 = Path.GetFileName(uploadimage.PostedFile.FileName);
                    uploadimage.SaveAs(Server.MapPath("~/AddVisaForm/" + filename1));
                    lnkbtn1.Text = filename1;
                    Session["ImageName"] = filename1;
                    List<NewsLetterDom> lstnews = new List<NewsLetterDom>();
                    lstnews.Add(newsdom);
                    grvw_image.DataSource = lstnews;
                    grvw_image.DataBind();
                    grvw_image.Visible = true;
                    ScriptManager.RegisterClientScriptBlock(btnSave, GetType(), "test", "alert('File uploaded successfully')", true);

                    txtTopic.Text = "";
                    txtdes.Text = "";

                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(btnSave, GetType(), "test", "alert('File Size is too large')", true);
                    txtTopic.Text = "";
                    txtdes.Text = "";
                }

            }


            else
            {
                //Response.Write("notDone");

                //Response.Write("<script LANGUAGE='JavaScript' >alert('Please Choose The File Name ')</script>");
                ScriptManager.RegisterClientScriptBlock(btnSave, GetType(), "test", "alert('Please Choose The File Name ')", true);
                txtTopic.Text = "";
                txtdes.Text = "";
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtTopic.Text = string.Empty;
            txtdes.Text = string.Empty;
        }

        protected void grvw_image_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }



        #region public_methods..

        public List<NewsLetterDom> GetNewsLetterDetail()
        {
            List<NewsLetterDom> lstnewsdom = newsbal.ReadNewsLetter();
            //lstnewsdom = newsbal.ReadNewsLetter();
            return lstnewsdom;
        }

        public void BindNewsLetter()
        {
            gvwNews.DataSource = GetNewsLetterDetail();
            gvwNews.DataBind();
        }

        public void BindImage()
        {
            grvw_image.DataSource = GetNewsLetterDetail();
            grvw_image.DataBind();
        }

        public void SetControlName(NewsLetterDom newsdom)
        {
            Literal lit = new Literal();
            lit.Mode = LiteralMode.PassThrough;
            string TopicName = newsdom.TopicName.ToString();
            lit.Text = HttpUtility.HtmlDecode(TopicName);
            literal2.Text = lit.Text;
            // added by divaker..


            var date = newsdom.NewsDate;
            lit.Text = HttpUtility.HtmlDecode(date);
            literal4.Text = lit.Text;
            var description = newsdom.Description;
            lit.Text = HttpUtility.HtmlDecode(description);
            literal1.Text = lit.Text;

            var docName = newsdom.ImageName;
            lit.Text = HttpUtility.HtmlDecode(docName);
            string atag = "/AddVisaForm/" + newsdom.ImageName;
            VisaFormLink.NavigateUrl = "<b>" + atag + "</b>";
            // literal3.Text = lit.Text;


        }

        public NewsLetterDom GetNewById(int topicId)
        {
            return newsbal.ReadNewsLetterById(topicId);
        }

        public void Cancel()
        {
            txtTopic.Text = string.Empty;
            txtdes.Text = string.Empty;
            grvw_image.DataSource = null;
            grvw_image.DataBind();
        }

        #endregion

        #region properties..

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

        #endregion



    }
}