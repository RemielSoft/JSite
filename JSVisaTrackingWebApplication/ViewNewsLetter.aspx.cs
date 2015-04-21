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
using System.Net;
using System.Data;
using System.Text;
using System.Web.UI.HtmlControls;

namespace JSVisaTrackingWebApplication
{
    public partial class ViewNewsLetter : System.Web.UI.Page
    {
        #region globals Variables..
        NewsLetterBAL newsbal = new NewsLetterBAL();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindNewsLetter();
            }
        }

        protected void grdViewNewsletter_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int topicId = 0;
            topicId = Convert.ToInt32(e.CommandArgument);
            this.TopicId = topicId;
           
            if (e.CommandName == "cmdDetails")
            {
                SetControlName(GetNewById(topicId));
                ModalPopupExtender1.Show();
               
            }
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
            literal3.Text = lit.Text;
            var description = newsdom.Description;
            lit.Text = HttpUtility.HtmlDecode(description);
            literal4.Text = lit.Text;

            var docName = Convert.ToString(newsdom.ImageName);
            
            lit.Text = HttpUtility.HtmlDecode(docName);
            VisaFormLink.Text = HttpUtility.HtmlDecode(docName);
            string atag = "/AddVisaForm/" + newsdom.ImageName;
            VisaFormLink.NavigateUrl = atag;
            //literal5.Text = lit.Text;

        }
        public NewsLetterDom GetNewById(int topicId)
        {
            return newsbal.ReadNewsLetterById(topicId);
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

        public List<NewsLetterDom> GetNewsLetterDetail()
        {
            List<NewsLetterDom> lstnewsdom = newsbal.ReadNewsLetter();
            //lstnewsdom = newsbal.ReadNewsLetter();
            return lstnewsdom;
        }

        public void BindNewsLetter()
        {
            grdViewNewsletter.DataSource = GetNewsLetterDetail();
            grdViewNewsletter.DataBind();
        }

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