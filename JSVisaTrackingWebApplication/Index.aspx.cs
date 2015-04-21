using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Remielsoft.JetSave.DomianObjectModel;
using Remielsoft.JetSave.BusinessAccessLayer;
using System.IO;
using System.Web.Services;

namespace JSVisaTrackingWebApplication
{
    public partial class Index : System.Web.UI.Page
    {
        NewsLetterBAL newsbal = new NewsLetterBAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            BindNewsLetter();
            if (Session["agentValidate"] != null)
            {
                bool b = (bool)Session["agentValidate"];
                if (b)
                {
                    newsevents.Visible = true;

                }
            }
            //else 
            //{
            //    newsevents.Visible = false;
            //}

            else if (Session["adminValidate"] != null)
            {
                bool b1 = (bool)Session["adminValidate"];
                if (b1)
                {
                    newsevents.Visible = true;

                }
            }
            else
            {
                newsevents.Visible = false;
            }


        }
        public List<NewsLetterDom> GetNewsLetterDetail()
        {
            var lstnewsdom1 = new List<NewsLetterDom>();
            List<NewsLetterDom> lstnewsdom = newsbal.ReadNewsLetter();
            foreach (var item in lstnewsdom)
            {
                if (item.Description!="")
                {
                    item.Description = Convert.ToString(item.Description.Substring(0, 3));
                    lstnewsdom1.Add(item);
                }
            }
            return lstnewsdom1;
        }

        public void BindNewsLetter()
        {

            rptNews.DataSource = GetNewsLetterDetail();
            rptNews.DataBind();
        }
        protected void grdViewNewsletter_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int topicId = 0;
            topicId = Convert.ToInt32(e.CommandArgument);
            this.TopicId = topicId;
            if (e.CommandName == "cmdDetails")
            {
                //change by Divaker
               // SetControlName(GetNewById(topicId));
               
              //  ModalPopupExtender1.Show();

            }
        }
        //Change by Divaker
        //public void SetControlName(NewsLetterDom newsdom)
        //{

        //    literal2.Text = newsdom.TopicName;
        //    literal1.Text = newsdom.Description;
        //    lnkbtn1.Text = newsdom.ImageName;

        //}
        public NewsLetterDom GetNewById(int topicId)
        {
            return newsbal.ReadNewsLetterById(topicId);
        }
        //Change by Divaker
        //protected void OpenDetails(object sender, EventArgs e)
        //{

        //    if (lnkbtn1.Text != string.Empty)
        //    {
        //        if (lnkbtn1.Text.EndsWith(".txt"))
        //        {
        //            Response.ContentType = "application/txt";
        //        }
        //        else if (lnkbtn1.Text.EndsWith(".pdf"))
        //        {
        //            Response.ContentType = "application/pdf";
        //        }
        //        else if (lnkbtn1.Text.EndsWith(".docx"))
        //        {
        //            Response.ContentType = "application/docx";
        //        }

        //        else if (lnkbtn1.Text.EndsWith(".xls"))
        //        {
        //            Response.ContentType = "application/xls";
        //        }
        //        else if (lnkbtn1.Text.EndsWith(".zip"))
        //        {
        //            Response.ContentType = "application/zip";
        //        }

        //        else
        //        {
        //            Response.ContentType = "image/jpg";
        //        }
        //        string filePath = lnkbtn1.Text;
        //        Response.AddHeader("Content-Disposition", "attachment;filename=\"" + filePath + "\"");
        //        string path = Server.MapPath("~/Form/" + filePath);
        //        if (File.Exists(path))
        //        {
        //            Response.TransmitFile(Server.MapPath("~/Form/" + filePath));
        //        }
        //        else
        //            Response.Write("<script LANGUAGE='JavaScript' >alert('File not exist. ')</script>");
        //    }
        //}
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
        [WebMethod]
        public static string ReadNews(int topicId)
        {


            Literal lit = new Literal();
            lit.Mode = LiteralMode.PassThrough;
            NewsLetterBAL newsbal = new NewsLetterBAL();
            List<NewsLetterDom> lstnewsdom = newsbal.ReadNewsLetter();
            var strin = lstnewsdom.FirstOrDefault(a => a.TopicId == topicId).Description;
            lit.Text = HttpUtility.HtmlDecode(strin);
           // literal1.Text = lit.Text;





            return lit.Text.ToString();
        }


        #endregion
    }
}