using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Remielsoft.JetSave.DomianObjectModel;
using Remielsoft.JetSave.BusinessAccessLayer;
using System.Data.Common;
using System.Data;
using System.Text;
using System.IO;
using System.Data.SqlClient;

namespace JSVisaTrackingWebApplication
{
    public partial class AgentEmailList : System.Web.UI.Page
    {
        AgentBAL agentBal = new AgentBAL();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btn_download.Visible = false;
            }
        }

        public List<Agent> BindGrid(string city)
        {
            List<Agent> lst = new List<Agent>();
            lst = agentBal.GridbindEmail(city);
            grid_search.DataSource = lst;
            grid_search.DataBind();
            return lst;            
        }       

        protected void LinkButton1_Click1(object sender, EventArgs e)
        {
            string city = txt_city.Text;            
            BindGrid(city);
            btn_download.Visible = true;
        }

        protected void grid_search_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            string city = txt_city.Text;
            grid_search.PageIndex = e.NewPageIndex;
            BindGrid(city);
        }


        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]

        public static List<string> GetCityName(string prefixText)
        {
            SqlConnection con = new SqlConnection("Data Source=VPCSERVER;Initial Catalog=jetsave;User ID=sa;Password=sql@123");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT(AGENT_CITY) FROM AGENT WHERE AGENT_CITY LIKE @city+'%'", con);
            cmd.Parameters.AddWithValue("@city", prefixText);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            List<string> CityName = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CityName.Add(dt.Rows[i]["AGENT_CITY"].ToString());
            }
            return CityName;
        }

        protected void btn_download_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.ClearHeaders();
            Response.AddHeader("content-disposition", "attachment;filename=AgentEmailReport.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.xls";

            StringBuilder sb = new StringBuilder();
            StringWriter stringWrite = new StringWriter(sb);
            HtmlTextWriter htm = new HtmlTextWriter(stringWrite);
            grid_search.AllowPaging = false;
            //grid_search.Columns.RemoveAt(8);
            grid_search.DataSource = agentBal.GridbindEmail(txt_city.Text);
            grid_search.DataBind();

            //gvSample is Gridview server control

            grid_search.RenderControl(htm);
            Response.Write(stringWrite);
            Response.End();

            btn_download.Visible = false;
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            // base.VerifyRenderingInServerForm(control);
        }
    }
}