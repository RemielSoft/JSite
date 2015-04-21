using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Remielsoft.JetSave.DataAccessLayer;
using Remielsoft.JetSave.DomianObjectModel;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Remielsoft.JetSave.BusinessAccessLayer
{
   public class NewsLetterBAL:BaseBusinessAccess
    {
        private Database myDataBase;
        private NewsLetterDAL newsDAL;
        public NewsLetterBAL()
        {
            myDataBase = DatabaseFactory.CreateDatabase(C_ConnectionString);
            newsDAL = new NewsLetterDAL(myDataBase);
        }
        public int CreateNewsLetter(NewsLetterDom newsdom)
        {
            int topicId = newsDAL.CreateNewsLetter(newsdom);
            return topicId;
        }
        public List<NewsLetterDom> ReadNewsLetter()
        {
            List<NewsLetterDom> lstnewsdom = new List<NewsLetterDom>();
            lstnewsdom = newsDAL.ReadNewsLetter();
            //var lstDescription = lstnewsdom.Select(b => b.Description).ToList();
           
            return lstnewsdom;
        }
        public NewsLetterDom ReadNewsLetterById(int topicId)
        {
            NewsLetterDom newsdom = new NewsLetterDom();
            newsdom = newsDAL.ReadNewsLetterById(topicId);
            return newsdom;
        }
        public NewsLetterDom ReadNewsLetterByImage(int TopicId, string imageName)
        {
            NewsLetterDom newsdom = new NewsLetterDom();
            newsdom = newsDAL.ReadNewsLetterByImage(TopicId, imageName);
            return newsdom;
        }
        public int UpdateNewsLetter(NewsLetterDom newsdom)
        {
           int topicId = newsDAL.UpdateNewsletter(newsdom);
           return topicId;
        }
        public void DeleteNewsLetter(int topicId, string modifiedBy, DateTime modifiedDate)
        {
            newsDAL.DeleteNewsLetter(topicId, modifiedBy, modifiedDate);
        }
        public void DeleteNewsLetterImage(int topicId, string modifiedBy, DateTime modifiedDate)
        {
            newsDAL.DeleteNewsLetter(topicId, modifiedBy, modifiedDate);
        }
    }
}
