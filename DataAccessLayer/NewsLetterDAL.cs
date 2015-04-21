using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Remielsoft.JetSave.DomianObjectModel;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;

namespace Remielsoft.JetSave.DataAccessLayer
{
    public class NewsLetterDAL : BaseDataAccess
    {

        private Database myDataBase;
        public NewsLetterDAL(Database m_database)
        {
            myDataBase = m_database;
        }
        public int CreateNewsLetter(NewsLetterDom newsdom)
        {
            int topicId;
            DbCommand dbcommand = myDataBase.GetStoredProcCommand(DBConstant.CREATE_NEWSLETTER);
            dbcommand.CommandType = CommandType.StoredProcedure;
            myDataBase.AddInParameter(dbcommand, "@TopicName", DbType.String, newsdom.TopicName);
            myDataBase.AddInParameter(dbcommand, "@Description", DbType.String, newsdom.Description);
            myDataBase.AddInParameter(dbcommand, "@CreatedBy", DbType.String, newsdom.Created_By);
            myDataBase.AddInParameter(dbcommand, "@ImageName", DbType.String, newsdom.ImageName);
            myDataBase.AddOutParameter(dbcommand, "@out_TopicId", DbType.Int32, 10);

            myDataBase.ExecuteNonQuery(dbcommand);
            int.TryParse(myDataBase.GetParameterValue(dbcommand, "@out_TopicId").ToString(), out topicId);

            return topicId;
        }

        public List<NewsLetterDom> ReadNewsLetter()
        {
            List<NewsLetterDom> lstnewsdom = new List<NewsLetterDom>();
            NewsLetterDom newsdom = null;
            DbCommand dbcommand = myDataBase.GetStoredProcCommand(DBConstant.READ_NEWSLETTER);
            dbcommand.CommandType = CommandType.StoredProcedure;
            using (IDataReader reader = myDataBase.ExecuteReader(dbcommand))
            {
                while (reader.Read())
                {
                    newsdom = GetNewsDetailFromDataReader(reader);
                    lstnewsdom.Add(newsdom);
                }
            }
            return lstnewsdom;
        }
        public NewsLetterDom ReadNewsLetterById(int TopicId)
        {
            NewsLetterDom newsdom = new NewsLetterDom();
            DbCommand dbcommnd = myDataBase.GetStoredProcCommand(DBConstant.READ_NEWSLETTER);
            dbcommnd.CommandType = CommandType.StoredProcedure;
            myDataBase.AddInParameter(dbcommnd, "@TopicId", DbType.Int32, TopicId);
            using (IDataReader reader = myDataBase.ExecuteReader(dbcommnd))
            {
                while (reader.Read())
                {

                    newsdom = GetNewsDetailFromDataReader(reader);

                }
                return newsdom;
            }
        }
        public NewsLetterDom ReadNewsLetterByImage(int TopicId,string imageName)
        {
            NewsLetterDom newsdom = new NewsLetterDom();
            DbCommand dbcommnd = myDataBase.GetStoredProcCommand(DBConstant.Read_NewsLetter_Image);
            dbcommnd.CommandType = CommandType.StoredProcedure;
            myDataBase.AddInParameter(dbcommnd, "@TopicId", DbType.Int32, TopicId);
            myDataBase.AddInParameter(dbcommnd, "@imageName", DbType.String, imageName);
            using (IDataReader reader = myDataBase.ExecuteReader(dbcommnd))
            {
                while (reader.Read())
                {

                    newsdom = GetNewsDetailFromDataReader(reader);

                }
                return newsdom;
            }
        }
        public NewsLetterDom GetNewsDetailFromDataReader(IDataReader reader)
        {
            NewsLetterDom newsdom = new NewsLetterDom();
            newsdom.TopicId = GetIntegerFromDataReader(reader, "TopicId");
            newsdom.NewsDate = GetStringFromDataReader(reader, "NewsLetterDate");
            newsdom.TopicName = GetStringFromDataReader(reader, "TopicName");
            newsdom.Description = GetStringFromDataReader(reader, "Description");
            //newsdom.Created_By = GetStringFromDataReader(reader, "Created_By");
            //newsdom.Created_Date = GetDateFromReader(reader, "Created_Date");
            //newsdom.Modified_By = GetStringFromDataReader(reader, "Modified_By");
            //newsdom.Modified_Date = GetDateFromReader(reader, "Modified_Date");
            newsdom.ImageName = GetStringFromDataReader(reader, "ImageName");
            return newsdom;
        }
        public int UpdateNewsletter(NewsLetterDom newsdom)
        {
            int topicId = 0;
            DbCommand dbcommand = myDataBase.GetStoredProcCommand(DBConstant.EDIT_NEWSLETTER);
            myDataBase.AddInParameter(dbcommand, "@TopicId", DbType.Int32, newsdom.TopicId);
            myDataBase.AddInParameter(dbcommand, "@TopicName", DbType.String, newsdom.TopicName);
            myDataBase.AddInParameter(dbcommand, "@ImageName", DbType.String, newsdom.ImageName);
            myDataBase.AddInParameter(dbcommand, "@Description", DbType.String, newsdom.Description);
            myDataBase.AddInParameter(dbcommand, "@ModifiedBy", DbType.String, newsdom.Modified_By);
            myDataBase.AddInParameter(dbcommand, "@ModifiedDate", DbType.DateTime, newsdom.Modified_Date);
            myDataBase.AddOutParameter(dbcommand, "@out_TopicId", DbType.Int32, 10);

            myDataBase.ExecuteNonQuery(dbcommand);
            int.TryParse(myDataBase.GetParameterValue(dbcommand, "@out_TopicId").ToString(), out topicId);

            return topicId;
        }
        public void DeleteNewsLetter(int topicId, string modifiedBy, DateTime modifiedDate)
        {
            DbCommand dbcommand = myDataBase.GetStoredProcCommand(DBConstant.DELETE_NEWSLETTER);
            dbcommand.CommandType = CommandType.StoredProcedure;
            myDataBase.AddInParameter(dbcommand, "@TopicId", DbType.Int32, topicId);
            myDataBase.AddInParameter(dbcommand, "@ModifiedBy", DbType.String, modifiedBy);
            myDataBase.AddInParameter(dbcommand, "@ModifiedDate", DbType.DateTime, modifiedDate);
            myDataBase.ExecuteNonQuery(dbcommand);
        }
        public void DeleteNewsLetterImage(int topicId, string modifiedBy, DateTime modifiedDate)
        {
            DbCommand dbcommand = myDataBase.GetStoredProcCommand(DBConstant.DELETE_NEWSLETTER_IMAGE);
            dbcommand.CommandType = CommandType.StoredProcedure;
            myDataBase.AddInParameter(dbcommand, "@TopicId", DbType.Int32, topicId);
            myDataBase.AddInParameter(dbcommand, "@ModifiedBy", DbType.String, modifiedBy);
            myDataBase.AddInParameter(dbcommand, "@ModifiedDate", DbType.DateTime, modifiedDate);
            myDataBase.ExecuteNonQuery(dbcommand);
        }
    }
}
