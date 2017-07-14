using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Drawing;

public partial class VideoPage : System.Web.UI.Page
{
    public string Category;
    public string Class,Unit,strURL,ppturl,audiourl,audioname;
    public int lasttime,classid=1;
    public string unitid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Write("alert('您还未登陆！');</script>");
            Response.Redirect("Login.aspx", true);
        }
        else
        {
            int UserId = int.Parse(Session["UserID"].ToString());
            unitid = "1";
            classid = 1;
            string connStr = "Data Source=59.110.235.44;Initial Catalog=hongruan;User ID=hrdev;Password=123hrdev456";
            SqlConnection con = new SqlConnection(connStr);
            SqlCommand cmd = con.CreateCommand();
            string strSqlComment = "select * from DiscussUnit inner join Student on DiscussUnit.StudentID=Student.StudentID and DiscussUnit.UnitID=" + unitid + " order by DiscussUnit.DiscussTime desc";
            string strSqlVideo = "SElECT VideoURL FROM Video where UnitID=UnitID";
            string sqlQ = "select * from QandA left join Student on Student.StudentID=QandA.StudentID left join Manager on Manager.ManagerID=QandA.ManagerID where(QandA.UnitID=1 or QandA.UnitID=2) order by QuestionTime desc";

            con.Open();

            string sqltime = "select top 1 LearnID,learntimelength ,unitcomplete from learnclass where studentid="+ int.Parse(Session["UserID"].ToString()) + " and classid=1 and unitid=" + unitid + " order by learnid desc";
            SqlCommand cmdd = new SqlCommand(sqltime, con);
            SqlDataReader myreader = cmdd.ExecuteReader();

            if (myreader.Read())
            {
                string a = myreader["LearnTimeLength"].ToString().Trim();

                lasttime = int.Parse(a);

            }
            else
            {
                lasttime = 0;
            }
            myreader.Close();


            SqlDataAdapter dataadapter = new SqlDataAdapter(strSqlComment, con);
            SqlDataAdapter dataadapter2 = new SqlDataAdapter(strSqlVideo, con);
            SqlDataAdapter adpQ = new SqlDataAdapter(sqlQ, con);

            DataSet dataset = new DataSet();
            DataSet dataset2 = new DataSet();
            DataSet dsQ = new DataSet();

            dataadapter.Fill(dataset);
            dataadapter2.Fill(dataset2);
            adpQ.Fill(dsQ);

            string sss = dataset2.Tables[0].Rows[0]["VideoURL"].ToString();
            strURL = sss.Trim();

            DataList1.DataSource = dataset;
            DataList1.DataBind();

            datalistQ.DataSource = dsQ;
            datalistQ.DataBind();

            string sql = "SELECT Unit.UnitName,Unit.UnitID, Class.ClassID,Class.ClassName FROM class  JOIN unit ON unit.ClassID=class.ClassID where unit.classid="+classid;
            SqlDataAdapter adp = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            DataListM1.DataSource = ds;
            DataListM1.DataBind();
            DataListM2.DataSource = ds;
            DataListM2.DataBind();

            string Sqlppt = "select PPTURL from PPT where UnitID=" + unitid + "";
            SqlDataAdapter adpppt = new SqlDataAdapter(Sqlppt, con);
            DataSet dsppt = new DataSet();
            adpppt.Fill(dsppt);
            ppturl = dsppt.Tables[0].Rows[0]["PPTURL"].ToString();

            string Sqlaudio = "select AudioName,AudioURL from Audio where UnitID=" + unitid + "";
            SqlDataAdapter adpaudio = new SqlDataAdapter(Sqlaudio, con);
            DataSet dsaudio = new DataSet();
            adpaudio.Fill(dsaudio);
            audiourl = dsaudio.Tables[0].Rows[0]["AudioURL"].ToString();
            audioname = dsaudio.Tables[0].Rows[0]["AudioName"].ToString();
            
           
            string Sqliscollect = "select count(StudentID) as num from Collection where StudentID=5 and ClassID=5 ";
            SqlDataAdapter adpco = new SqlDataAdapter(Sqliscollect, con);
            DataSet dsco = new DataSet();
            adpco.Fill(dsco);
            string n = dsco.Tables[0].Rows[0]["num"].ToString();
            if (n == "1")
            {
                collect.BackColor = Color.FromArgb(165, 42, 42);
            }
            if (n == "0")
            {
                collect.BackColor = Color.FromArgb(105, 105, 105);
            }

            con.Close();
            getBread(1, connStr);



        }
    }
   
    private void getBread(int UnitID, string constr) {
        SqlConnection conn = new SqlConnection(constr);
        SqlCommand cmd = conn.CreateCommand();
        UnitID = 1;//页面间的通信完成后，本行删掉
        string sqlstr = "SELECT Unit.UnitName,Class.ClassID,Class.ClassName FROM Unit LEFT JOIN Class ON Unit.ClassID=Class.ClassID";
        
        conn.Open();
        SqlDataAdapter sda = new SqlDataAdapter(sqlstr, conn);
        DataSet ds = new DataSet();
        sda.Fill(ds);
        //this.Category = ds.Tables[0].Rows[0]["CategoryName"].ToString();
        this.Unit = ds.Tables[0].Rows[0]["UnitName"].ToString();
        this.Class = ds.Tables[0].Rows[0]["ClassName"].ToString();
        string ClassID = ds.Tables[0].Rows[0]["ClassID"].ToString();

        string sqlstr2 = "SELECT CategoryName FROM Class_Category  LEFT JOIN Category ON ClassID='" + ClassID+ "' and Category.CategoryID=Class_Category.CategoryID;";

        SqlDataAdapter sda2 = new SqlDataAdapter(sqlstr2,conn);
        DataSet ds2 = new DataSet();

        sda2.Fill(ds2);

        this.Category = ds2.Tables[0].Rows[0]["CategoryName"].ToString();

        conn.Close();
    }

    protected void btn_Comment_Click(object sender, EventArgs e)
    {
        if (CommentText.InnerText.ToString() != String.Empty)
        {
            try
            {
                string discussStr = CommentText.InnerText.ToString();
                string conStr = "Data Source=59.110.235.44;Initial Catalog=hongruan;User ID=hrdev;Password=123hrdev456";
                string dateStr = DateTime.Now.ToString();
                string YMD = DateTime.Now.Date.ToString();
                string sqlStr = "INSERT INTO DiscussUnit (StudentID,UnitID,DiscussTime,DiscussContent,DisscussDate) VALUES ("+int.Parse(Session["UserID"].ToString())+",1,'" + dateStr + "','" + discussStr + "','" + YMD + "')";
                SqlConnection conn = new SqlConnection(conStr);
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sqlStr;
                cmd.ExecuteNonQuery();
                conn.Close();
                this.CommentText.Value = "";
                Response.Write("<script>window.location='VideoPage.aspx';alert('发表成功！');</script>");
            }
            catch(Exception exx)
            {
                Response.Write("<script>alert('评论失败！');</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('评论内容不能为空！');</script>");
        }
        
    }



    //问答提交
    protected void btn_Question_Click(object sender, EventArgs e)
    {
        
        if (TextareaQT.InnerText.ToString() != String.Empty && TextareaQC.InnerText.ToString() != String.Empty)
        {
            try
            {
                string QuestionT = TextareaQT.InnerText.ToString();
                string QuestionC = TextareaQC.InnerText.ToString();
                string conStr = "Data Source=59.110.235.44;Initial Catalog=hongruan;User ID=hrdev;Password=123hrdev456";
                string dateStr = DateTime.Now.ToString();
                string YMD = DateTime.Now.Date.ToString();
                string sqlStr = "INSERT INTO QandA (UnitID,StudentID,QuestionTitle,QuestionContent,QuestionTime,QuestionDate) VALUES (1," + int.Parse(Session["UserID"].ToString()) + ",'" + QuestionT + "','" + QuestionC + "','" + dateStr + "','" + YMD + "')";
                SqlConnection conn = new SqlConnection(conStr);
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sqlStr;
                cmd.ExecuteNonQuery();
                conn.Close();
                // Response.Write("<script language=javascript>window.alert('" + ls_ts + "');</script>");
                this.TextareaQT.Value = "";
                this.TextareaQC.Value = "";
                Response.Write("<script>window.location='VideoPage.aspx';alert('发表成功！');</script>");
            }
            catch (Exception exx)
            {
                Response.Write("<script>alert('提问失败！');</script>");
            }
        }
        else if (TextareaQT.InnerText.ToString() == String.Empty)
        {
            Response.Write("<script>alert('标题不能为空！');</script>");
        }
        else
        {
            Response.Write("<script>alert('内容不能为空！');</script>");
        }
    }

    protected void btn_Collect_Click(object sender, EventArgs e)
    {
         if(collect.BackColor == Color.FromArgb(105, 105, 105)) {
            int studentid = 5;
            int classid = 5;
            string ymd = DateTime.Now.Date.ToString();
            string constr = "Data Source=59.110.235.44;Initial Catalog=hongruan;User ID=hrdev;Password=123hrdev456";
            string sqlstr = "insert into Collection (StudentID,ClassID,Compulsion,IsCompleted,CollectionDate) values (" + studentid + "," + classid + ",0,0,'" + ymd + "')";
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sqlstr;
            cmd.ExecuteNonQuery();
            collect.BackColor = Color.FromArgb(165, 42, 42);
        }
        else if(collect.BackColor == Color.FromArgb(165, 42, 42)){
            int studetid = 5;
            int classid = 5;
            string sqlstr = "delete from Collection where StudentID=" + studetid + " and ClassID=" + classid + "";
            string constr = "Data Source=59.110.235.44;Initial Catalog=hongruan;User ID=hrdev;Password=123hrdev456";
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sqlstr;
            cmd.ExecuteNonQuery();
            collect.BackColor = Color.FromArgb(105, 105, 105);
        }

    }
   
}