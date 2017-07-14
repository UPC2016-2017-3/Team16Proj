using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Drawing;

public partial class community : System.Web.UI.Page
{
    static string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["hongruanConnectionString"].ConnectionString;
    public  int studentid, topicCount,reply,topic,topicPage;
    public string name;
    int userID=1;
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Write("alert('您还未登陆！');</script>");
            Response.Redirect("Login.aspx", true);
        }
        else
        {
            if (!IsPostBack)
            {
                ViewState["pageindex"] = "0";
            }
            string method = Request["method"];
            studentid = 1;
            SqlConnection con = new SqlConnection(connStr);
            con.Open();
            string sqltopic = "select max(CommunityTopic.TopicID)as topicid, max(communityTopic.TopicTime) as TopicTime,max(student.StudentName) as StudentName,max(communityTopic.TopicTitle) as TopicTitle ,max(communityTopic.TopicContent) as TopicContent,count(communityreply.replyid)as replycount from communityTopic inner join student on student.studentid=communityTopic.studentid full join communityreply on communityreply.topicid=communityTopic.TopicID group by communityTopic.TopicID order by max(communityTopic.TopicTime) desc;select top 10 LEFT(CommunityReply.ReplyContent,15)as replycontent,Student.studentname from CommunityReply join student on student.studentid=CommunityReply.StudentID order by ReplyTime;select count(case CommunityReply.Studentid when 1 then 1 else null end)as reply,COUNT(distinct(case CommunityTopic.Studentid when " + studentid + " then CommunityTopic.topicid else null end )) as topic,max(student.studentname) as studentname from CommunityReply  full join CommunityTopic on CommunityReply.TopicID=CommunityTopic.TopicID join student on student.studentid=CommunityTopic.studentid where CommunityTopic.StudentID = " + studentid;
            SqlDataAdapter dpt = new SqlDataAdapter(sqltopic, con);
            ds = new DataSet();
            dpt.Fill(ds);
            replylist.DataSource = ds.Tables[1];
            replylist.DataBind();
            reply = int.Parse(ds.Tables[2].Rows[0]["reply"].ToString());
            topic = int.Parse(ds.Tables[2].Rows[0]["topic"].ToString());
            name = ds.Tables[2].Rows[0]["studentname"].ToString();
            if (method == null)
            {
                topicCount = ds.Tables[0].Rows.Count;
                double count = topicCount / 6.0 + 0.5;
                topicPage = Convert.ToInt32(count);
                PagedDataSource pds = new PagedDataSource();
                pds = BindData(ds);
                TopicList.DataSource = pds;
                TopicList.DataBind();
                xsTopicList.DataSource = ds.Tables[0];
                xsTopicList.DataBind();
            }
            else if (method.Equals("DBind"))
            {

                DataBinder();
            }
            con.Close();
        }

    }

    protected void IndexChanging(object sender, CommandEventArgs e)
    {
        string strCommand = e.CommandArgument.ToString();

        int pageindex = int.Parse(ViewState["pageindex"].ToString());
        if (strCommand == "convert")
        {
            if (int.Parse(pg.Value.ToString()) > topicPage)
            {
                Response.Write("<script>alert('咿呀，超过最大页码了')</script>");
            }
            else
            {
                pageindex = int.Parse(pg.Value.ToString())-1;
            }
        }
        else if (strCommand == "pre")
        {
            pageindex = pageindex - 1;
        }
        else
        {
            pageindex = pageindex + 1;
        }

        ViewState["pageindex"] = pageindex;

        PagedDataSource pds = new PagedDataSource();
        pds = BindData(ds);
        TopicList.DataSource = pds;
        TopicList.DataBind();
    }

    protected PagedDataSource BindData(DataSet ds)
    {
       
        DataTable objTable = ds.Tables[0];
        PagedDataSource objPds = new PagedDataSource();
       
        if (objTable != null && objTable.Rows.Count > 0)
        {
            DataView objView = objTable.DefaultView;
           
            objPds.DataSource = objView;

            objPds.AllowPaging = true;

            objPds.PageSize = 6;

            objPds.CurrentPageIndex = int.Parse(ViewState["pageindex"].ToString());

            if (!objPds.IsFirstPage)
            {
                lkPre.Visible = true;
            }
            else
            {
                lkPre.Visible = false;
            }

            if (!objPds.IsLastPage)
            {
                lkNext.Visible = true;
            }
            else
            {
                lkNext.Visible = false;
            }
          }
        return objPds;
    }


    protected void DataBinder()
    {
        SqlConnection con = new SqlConnection(connStr);
        con.Open();
        DataSet dss=new DataSet();
        int methodid = int.Parse(Request["methodid"].ToString());
        DataTable listtable=null;
        
        if (methodid == 1)
        {
            string sqltopic = "select max(CommunityTopic.TopicID)as topicid,max(communityTopic.TopicTime) as TopicTime,max(student.StudentName) as StudentName,max(communityTopic.TopicTitle) as TopicTitle ,max(communityTopic.TopicContent) as TopicContent,count(communityreply.replyid)as replycount from communityTopic inner join student on student.studentid=communityTopic.studentid full join communityreply on communityreply.topicid=communityTopic.TopicID group by communityTopic.TopicID order by max(communityTopic.TopicTime) desc";
            SqlDataAdapter dpt = new SqlDataAdapter(sqltopic, con);

            dpt.Fill(dss);
            listtable = dss.Tables[0];
           
        }
        else if (methodid == 2)
        {
            string sqltopic = "select max(CommunityTopic.TopicID)as topicid,max(communityTopic.TopicTime) as TopicTime,max(student.StudentName) as StudentName,max(communityTopic.TopicTitle) as TopicTitle ,max(communityTopic.TopicContent) as TopicContent,count(communityreply.replyid)as replycount from communityTopic inner join student on student.studentid=communityTopic.studentid full join communityreply on communityreply.topicid=communityTopic.TopicID  group by communityTopic.TopicID having (count(communityreply.replyid))=0";
            SqlDataAdapter dpt = new SqlDataAdapter(sqltopic, con);

            dpt.Fill(dss);
            listtable = dss.Tables[0];
            string expression =  "replycount = '0'";
            listtable.DefaultView.RowFilter = expression;
        }
        else if (methodid == 3)
        {
            string sqltopic = "select max(CommunityTopic.TopicID)as topicid,max(communityTopic.TopicTime) as TopicTime,max(student.StudentName) as StudentName,max(communityTopic.TopicTitle) as TopicTitle ,max(communityTopic.TopicContent) as TopicContent,count(communityreply.replyid)as replycount from communityTopic inner join student on student.studentid=communityTopic.studentid full join communityreply on communityreply.topicid=communityTopic.TopicID group by communityTopic.TopicID ";
            SqlDataAdapter dpt = new SqlDataAdapter(sqltopic, con);

            dpt.Fill(dss);
            listtable = dss.Tables[0];
            listtable.DefaultView.RowFilter = "replycount <> '0'";
        }
        else if (methodid == 4)
        {
            string sqltopic = "select max(CommunityTopic.TopicID)as topicid,max(communityTopic.TopicTime) as TopicTime,max(student.StudentName) as StudentName,max(communityTopic.TopicTitle) as TopicTitle ,max(communityTopic.TopicContent) as TopicContent,count(communityreply.replyid)as replycount from communityTopic inner join student on student.studentid=communityTopic.studentid full join communityreply on communityreply.topicid=communityTopic.TopicID group by communityTopic.TopicID order by max(communityTopic.TopicTime) desc";
            SqlDataAdapter dpt = new SqlDataAdapter(sqltopic, con);

            dpt.Fill(dss);
            listtable = dss.Tables[0];
        }
        else if (methodid == 5)
        {
            string sqltopic = "select max(CommunityTopic.TopicID)as topicid,max(communityTopic.TopicTime) as TopicTime,max(student.StudentName) as StudentName,max(communityTopic.TopicTitle) as TopicTitle ,max(communityTopic.TopicContent) as TopicContent,count(communityreply.replyid)as replycount from communityTopic inner join student on student.studentid=communityTopic.studentid full join communityreply on communityreply.topicid=communityTopic.TopicID group by communityTopic.TopicID order by count(communityreply.replyid) desc";
            SqlDataAdapter dpt = new SqlDataAdapter(sqltopic, con);
            dpt.Fill(dss);
            listtable = dss.Tables[0];
        }
         else if (methodid == 6)
        {
            string sqltopic = "select max(CommunityTopic.TopicID)as topicid,max(communityTopic.TopicTime) as TopicTime,max(student.StudentName) as StudentName,max(communityTopic.TopicTitle) as TopicTitle ,max(communityTopic.TopicContent) as TopicContent,count(communityreply.replyid)as replycount from communityTopic inner join student on student.studentid=communityTopic.studentid full join communityreply on communityreply.topicid=communityTopic.TopicID where CommunityTopic.StudentID=" + userID + " group by communityTopic.TopicID ";
            SqlDataAdapter dpt = new SqlDataAdapter(sqltopic, con);
            dpt.Fill(dss);
            listtable = dss.Tables[0];
        }
        else if (methodid == 7)
        {
            string sqltopic = "select max(CommunityTopic.TopicID)as topicid,max(communityTopic.TopicTime) as TopicTime,max(student.StudentName) as StudentName,max(communityTopic.TopicTitle) as TopicTitle ,max(communityTopic.TopicContent) as TopicContent,count(communityreply.replyid)as replycount from communityTopic inner join student on student.studentid=communityTopic.studentid full join communityreply on communityreply.topicid=communityTopic.TopicID where CommunityReply.StudentID= " + userID;
            SqlDataAdapter dpt = new SqlDataAdapter(sqltopic, con);
            dpt.Fill(dss);
            listtable = dss.Tables[0];
        }
        ds = dss;
        topicCount = listtable.DefaultView.Count;
        this.TopicList.DataSource =null;
        double count = topicCount / 6.0 + 0.5;
        topicPage = Convert.ToInt32(count);
        PagedDataSource pds = new PagedDataSource();
        pds = BindData(dss);
        TopicList.DataSource = pds;
        TopicList.DataBind();
        xsTopicList.DataSource = listtable;
        xsTopicList.DataBind();
        con.Close();
    }


    protected void submit_Click(object sender, EventArgs e)
    {
        int studentid = 2;
        string QT = null, QC = null;

        if (TextareaQT.InnerText.ToString() != String.Empty && TextareaQC.InnerText.ToString() != String.Empty)
        {
            try
            {
                QT = TextareaQT.InnerText.ToString();
                QC = TextareaQC.InnerText.ToString();
                string conStr = "Data Source=59.110.235.44;Initial Catalog=hongruan;User ID=hrdev;Password=123hrdev456";
                string dateStr = DateTime.Now.ToString();
                string sqlStr = "INSERT INTO CommunityTopic (TopicTitle,TopicContent,StudentID,TopicTime) VALUES ('" + QT + "','" + QC + "','" + studentid + "','" + dateStr + "')";
                SqlConnection conn = new SqlConnection(conStr);
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sqlStr;
                cmd.ExecuteNonQuery();
                conn.Close();
                // Response.Write("<script language=javascript>window.alert('" + ls_ts + "');</script>");
                this.TextareaQT.Value = "";
                this.TextareaQC.Value = "";

                Response.Write("<script>alert('发表成功！');</script>");
                HttpContext.Current.Response.Redirect("community.aspx", true);
            }
            catch (Exception exx)
            {
                Response.Write("<script>alert('发表失败！');</script>");
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

protected void submitxs_Click(object sender, EventArgs e)
{
    int studentid = 2;
    string QT = null, QC = null;

    if (TextareaQTx.InnerText.ToString() != String.Empty && TextareaQCx.InnerText.ToString() != String.Empty)
    {
         QT = TextareaQTx.InnerText.ToString();
                QC = TextareaQCx.InnerText.ToString();
            
            string conStr = "Data Source=59.110.235.44;Initial Catalog=hongruan;User ID=hrdev;Password=123hrdev456";
            string dateStr = DateTime.Now.ToString();
            string sqlStr = "INSERT INTO CommunityTopic (TopicTitle,TopicContent,StudentID,TopicTime) VALUES ('" + QT + "','" + QC + "','" + studentid + "','" + dateStr + "')";
            SqlConnection conn = new SqlConnection(conStr);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sqlStr;
            cmd.ExecuteNonQuery();
            conn.Close();
            // Response.Write("<script language=javascript>window.alert('" + ls_ts + "');</script>");
            this.TextareaQT.Value = "";
            this.TextareaQC.Value = "";

            HttpContext.Current.Response.Redirect("community.aspx", true);
        }
       
}


}