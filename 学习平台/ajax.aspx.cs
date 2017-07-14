using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class ajax : System.Web.UI.Page
{
    string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["hongruanConnectionString"].ConnectionString;
  
    protected void Page_Load(object sender, EventArgs e)
    {
        string method = Request["method"].ToString();
        if (method.Equals("record")){
        string played = string.Empty;
        string duration = string.Empty;
        int state;
        if (Request["cid"] != "" && Request["length"].ToString().Equals("0") == false)
        {

            played = Request["played"].ToString();
            duration = Request["length"].ToString();
            state = int.Parse(Request["readyState"]);
            SqlConnection con = new SqlConnection(connStr);
            con.Open();
            string[] sArray = played.ToString().Split('.');
            int a = int.Parse(sArray[0]);
            if (a != 0)
            {
                string[] sArray2 = duration.ToString().Split('.');
                int b = int.Parse(sArray2[0]);
                double ratio = a / (b + 0.0);
                int completed = 0;
                int IsCompleted = 0;
                int x = 0, y = 0;
                if (ratio > 0.9 & state > 0)
                {
                    completed = 1;
                }
                string sqlcout = "select (count(distinct unit.UnitID))as total , (count(distinct (case LearnClass.UnitComplete when 1 then unit.UnitID else null end)))as record from LearnClass join Unit on LearnClass.ClassID=unit.ClassID  where unit.classid=1and StudentID=2";
                SqlCommand cmd = new SqlCommand(sqlcout, con);
                SqlDataReader myreader = cmd.ExecuteReader();
                if (myreader.Read())
                {
                    x = int.Parse(myreader["total"].ToString().Trim());
                    y = int.Parse(myreader["record"].ToString().Trim());
                }
                myreader.Close();
                if (((x - y == 1) & completed == 1) || x == y)
                {
                    IsCompleted = 1;
                }
                string sqlin = "insert LearnClass(StudentID,ClassID,LearnDate,LearnTimeLength,UnitID,UnitComplete,IsCompleted) VALUES("+ int.Parse(Session["UserID"].ToString()) + ",1,CONVERT (nvarchar(12),GETDATE(),112)," + a + ",1," + completed + "," + IsCompleted + ")";
                SqlCommand cmdd = new SqlCommand(sqlin, con);
                cmdd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
        else if(method.Equals("convert"))
        {
            string videoURL = null ;
            string id = Request["unitid"].ToString();
            int unitid = int.Parse(id);
            SqlConnection con = new SqlConnection(connStr);
            con.Open();
            string sqlcout = "SELECT VideoURL  FROM Video where unitid=" + unitid;
            SqlCommand cmd = new SqlCommand(sqlcout, con);
            SqlDataReader myreader = cmd.ExecuteReader();
            if (myreader.Read())
            {
                //videoURL = @""""+ myreader["VideoURL"].ToString().Trim() + @"""";
               
            }
            myreader.Close();
            con.Close();
            videoURL = "video/aaa.mp4";
         //  Response.Write(videoURL);
            Response.Write("<span id='myVideo' src=" + videoURL + "></span>");
        }
    }
     

}