using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;

public partial class _Default : System.Web.UI.Page
{
  
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    //type方式必须是post，方法必须是静态的，方法声明要加上特性[System.Web.Services.WebMethod()]，传递的参数个数也应该和方法的参数相同。
    [System.Web.Services.WebMethod()]
    public static string AjaxMethod(string param2)
    {
        
       // string videoURL = null;
        string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["hongruanConnectionString"].ConnectionString;
        int unitid = int.Parse(param2);
        SqlConnection con = new SqlConnection(connStr);
        con.Open();
        string sqlcout = "select video.VideoURL,ppt.SwfURL,ppt.PPTURL,Audio.AudioURL,Audio.AudioName from video,ppt,Audio where video.UnitID=" + unitid + " and ppt.unitid=" + unitid + " and Audio.UnitID=" + unitid;
        string strSqlVideo = "select top 1 LearnTimeLength  from LearnClass where studentid=1 and unitid=1 order by learndate";
        SqlCommand cmd = new SqlCommand(sqlcout, con);
        SqlDataReader myreader = cmd.ExecuteReader();
        
        DataTable tb = new DataTable("Data");
        if (myreader.Read())
        {
           
            tb.Columns.Add("videourl", Type.GetType("System.String"));
            tb.Columns.Add("SwfURL", Type.GetType("System.String"));
            tb.Columns.Add("AudioURL", Type.GetType("System.String"));
            tb.Columns.Add("PPTURL", Type.GetType("System.String"));
            tb.Columns.Add("AudioName", Type.GetType("System.String"));
            tb.Columns.Add("lasttime", Type.GetType("System.String"));
            string a1 = myreader["VideoURL"].ToString().Trim();
            string a2 = myreader["SwfURL"].ToString().Trim();
            string a3 = myreader["AudioURL"].ToString().Trim();
            string a4 = myreader["PPTURL"].ToString().Trim();
            string a5 = myreader["AudioName"].ToString().Trim();
            SqlDataAdapter sda = new SqlDataAdapter(strSqlVideo, con);
            DataSet dss = new DataSet();
            myreader.Close();
            sda.Fill(dss);
            string a6 = dss.Tables[0].Rows[0]["LearnTimeLength"].ToString();
            tb.Rows.Add(new object[]{a1,a2,a3,a4,a5,a6});
          

        }
        string JsonStr = JsonConvert.SerializeObject(tb);
      
       
        con.Close();
        return JsonStr;
    }
}