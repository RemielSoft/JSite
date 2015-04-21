using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Data.Common;
using Remielsoft.JetSave.DomianObjectModel;
using Remielsoft.JetSave.BusinessAccessLayer;
using System.IO;
using JSVisaTrackingWebApplication.Shared;

namespace JSVisaTrackingWebApplication
{
    public partial class TallyExport : System.Web.UI.Page
    {
        #region Global Variable(s)

        String MyTextString = null;
        String MyFirstTextLine;
        String MySecondTextLine;
        string nl = System.Environment.NewLine;
        BasePage basePage = new BasePage();
        DataExportTallyBusinessAccess dataExportTallyBAL = new DataExportTallyBusinessAccess();

        #endregion

        #region Protected Function(s)

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Reset();
            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            DateTime FromDate = Convert.ToDateTime(txtFromDate.Text);
            DateTime ToDate = Convert.ToDateTime(txtToDate.Text);
            List<DataExportTally> lst = new List<DataExportTally>();
            int LocId = basePage.LoggedInUser.UserLocation.LocationId;
            int userId = basePage.LoggedInUser.UserTypeId;
            if (FromDate > ToDate)
            {
                ScriptManager.RegisterClientScriptBlock(btnExport, GetType(), "a", "alert('FromDate Must Be Less Or Equal To ToDate')", true);
                txtFromDate.Focus();
            }
            else
            {
                System.Threading.Thread.Sleep(1000);

                if (userId == Convert.ToInt32(UserType.Admin))
                {
                    LocId = 0;
                    lst = dataExportTallyBAL.ReadExportDataTally(FromDate, ToDate, LocId);
                }
                else
                {
                    lst = dataExportTallyBAL.ReadExportDataTally(FromDate, ToDate, LocId);
                }
                for (int i = 0; i < lst.Count; i++)
                {
                    MyFirstTextLine = lst[i].FirstBlock + lst[i].SecondBlock + lst[i].PartyName + lst[i].CrAmt + lst[i].Ref + lst[i].Inv + lst[i].CrAmt2 + lst[i].Narr + nl;
                    MySecondTextLine = lst[i].FirstBlock + lst[i].SecBlankBlock + lst[i].PartyName2 + lst[i].DrAmt + lst[i].BlankRef + lst[i].Inv + lst[i].BlankNarr + nl;
                    MyTextString = MyTextString + MyFirstTextLine + MySecondTextLine;
                }

                MyTextString = MyTextString + (Char)26;
                
                String MyPath;
                MyPath = Server.MapPath("TallyExportData");
                
                if (CreateFile(MyTextString, MyPath + "\\TallyExport.txt") == true)
                {
                    FileInfo MyFlInfo = new FileInfo(MyPath + "\\TallyExport.txt");
                    long Filesize = 0;
                    Filesize = MyFlInfo.Length;

                    Response.ContentType = "application/binary";
                    Response.AddHeader("content-disposition", "attachment; filename= TallyExport.txt");
                    Response.AddHeader("Content-Type", "application/binary");
                    Response.AddHeader("Content-Length", Filesize.ToString());

                    Response.ClearContent();
                    Response.Clear();
                    Response.Flush();
                    Response.WriteFile(MyPath + "\\TallyExport.txt");
                    ScriptManager.RegisterClientScriptBlock(btnExport, GetType(), "a", "alert('File Exported Succesfully')", true);
                    Response.End();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ScriptKey", "alert('File Exported Fail...');window.location='DataExportTally.aspx'; ", true);
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Reset();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }

        #endregion

        #region Public Function(s)

        public bool CreateFile(string strData, string FullPath)
        {
            bool bAns = false;
            StreamWriter objReader = default(StreamWriter);

            try
            {
                objReader = new StreamWriter(FullPath);
                objReader.Write(strData);
                objReader.Close();
                bAns = true;
            }
            catch (Exception Ex)
            {
                Response.Write(Ex.Message);

            }
            return bAns;
        }

        public void Reset()
        {
            txtFromDate.Text = System.DateTime.Today.ToShortDateString();
            txtToDate.Text = System.DateTime.Today.ToShortDateString();
        }

        #endregion
    }

    #region Commentd Code

    //public partial class TallyExport : System.Web.UI.Page
    //{
    //    String MyTextString = null;
    //    String MyFirstTextLine;
    //    String mySeconTextLine;

    //    string nl = System.Environment.NewLine;
    //    DataExportTallyBusinessAccess dataExportTallyBAL = new DataExportTallyBusinessAccess();
    //    protected void Page_Load(object sender, EventArgs e)
    //    {
    //        if (!IsPostBack)
    //        {

    //        }
    //    }

    //    protected void btnExport_Click(object sender, EventArgs e)
    //    {
    //        DataExportTally dataExportTally = new DataExportTally();

    //        DateTime FromDate = Convert.ToDateTime(txtFromDate.Text);
    //        DateTime ToDate = Convert.ToDateTime(txtToDate.Text);

    //        List<DataExportTally> lst = dataExportTallyBAL.ReadDataExportTally(FromDate, ToDate);
    //        for (int i = 0; i < lst.Count; i++)
    //        {
    //            MyFirstTextLine = lst[i].MyFirstBlock + lst[i].MySecondBlock + lst[i].MyPartyName + lst[i].MyCreditAmt + lst[i].Ref + lst[i].Inv + lst[i].MyCreditAmt2 + lst[i].Narration + nl;
    //            mySeconTextLine = lst[i].MyFirstBlock + lst[i].MySecBlankBlock + lst[i].MySecPartyName + lst[i].MyDebitAmt + lst[i].BlankRef + lst[i].Inv + lst[i].BlankNarration + nl;
    //            MyTextString = MyTextString + MyFirstTextLine + mySeconTextLine;
    //        }

    //        MyTextString = MyTextString + (Char)26;

    //        String MyPath;
    //        MyPath = Server.MapPath("TallyExportData");


    //        if (CreateFile(MyTextString, MyPath + "\\TallyExport.txt") == true)
    //        {
    //            FileInfo MyFlInfo = new FileInfo(MyPath + "\\TallyExport.txt");

    //            long Filesize = 0;
    //            Filesize = MyFlInfo.Length;

    //            Response.ContentType = "application/binary";
    //            Response.AddHeader("content-disposition", "attachment; filename= TallyExport.txt");
    //            Response.AddHeader("Content-Type", "application/binary");
    //            Response.AddHeader("Content-Length", Filesize.ToString());

    //            Response.ClearContent();
    //            Response.Clear();
    //            Response.Flush();
    //            Response.WriteFile(MyPath + "\\TallyExport.txt");
    //            ScriptManager.RegisterClientScriptBlock(btnExport, GetType(), "a", "alert('File Exported Succesfully')", true);
    //            Response.End();
    //        }
    //        else
    //        {
    //            ScriptManager.RegisterClientScriptBlock(btnExport, GetType(), "a", "alert('File Export Failed')", true);
    //        }
    //    }

    //    //public override void VerifyRenderingInServerForm(Control control)
    //    //{
    //    //    //base.VerifyRenderingInServerForm(control);
    //    //}       

    //    public bool CreateFile(string strData, string FullPath)
    //    {
    //        bool bAns = false;
    //        StreamWriter objReader = default(StreamWriter);

    //        try
    //        {
    //            objReader = new StreamWriter(FullPath);
    //            objReader.Write(strData);
    //            objReader.Close();
    //            bAns = true;

    //        }
    //        catch (Exception Ex)
    //        {
    //            Response.Write(Ex.Message);

    //        }
    //        return bAns;
    //    }
    //}

    #endregion
}