using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Luntan : System.Web.UI.Page
{
    public string topictitle, topiccontent, topictime, studentname;
    int TopicID;
    public int studentid, reply, topic;
    public string name;
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
                if (Request["topicid"] != null)
                {
                    TopicID = int.Parse(Request["topicid"].ToString());
                    Session["TopicID"] = TopicID;
                }
                studentid = 1;
                string connStr = "Data Source=59.110.235.44;Initial Catalog=hongruan;User ID=hrdev;Password=123hrdev456";
                string sqlStr = "select CommunityTopic.TopicTiTle,CommunityTopic.TopicContent,CommunityTopic.TopicTime,Student.StudentName from CommunityTopic left join Student on CommunityTopic.StudentID=Student.StudentID where TopicID=" + TopicID + "";
                SqlConnection conn = new SqlConnection(connStr);
                SqlDataAdapter sda = new SqlDataAdapter(sqlStr, conn);

                DataSet ds = new DataSet();
                sda.Fill(ds);
                topictitle = ds.Tables[0].Rows[0]["TopicTiTle"].ToString();
                topiccontent = ds.Tables[0].Rows[0]["TopicContent"].ToString();
                topictime = ds.Tables[0].Rows[0]["TopicTime"].ToString();
                studentname = ds.Tables[0].Rows[0]["StudentName"].ToString();

                string sql = "select CommunityReply.ReplyContent,CommunityReply.ReplyTime,Student.StudentName from CommunityReply left join Student on CommunityReply.StudentID=Student.StudentID where TopicID=" + TopicID + ";select top 10 LEFT(CommunityReply.ReplyContent,15)as replycontent,Student.studentname from CommunityReply join student on student.studentid=CommunityReply.StudentID order by ReplyTime desc;select count(case CommunityReply.Studentid when 1 then 1 else null end)as reply,COUNT(distinct(case CommunityTopic.Studentid when " + studentid + " then CommunityTopic.topicid else null end )) as topic,max(student.studentname) as studentname from CommunityReply  full join CommunityTopic on CommunityReply.TopicID=CommunityTopic.TopicID join student on student.studentid=CommunityTopic.studentid where CommunityTopic.StudentID = " + studentid;
                SqlConnection conn1 = new SqlConnection(connStr);
                SqlDataAdapter adp = new SqlDataAdapter(sql, conn1);
                DataSet dsR = new DataSet();
                adp.Fill(dsR);
                datalistR.DataSource = dsR;
                datalistR.DataBind();
                datalistRx.DataSource = dsR;
                datalistRx.DataBind();
                if (dsR.Tables[0].Rows.Count == 0)
                {
                    NONa.Visible = true; ;
                }
                replylist.DataSource = dsR.Tables[1];
                replylist.DataBind();

                reply = int.Parse(dsR.Tables[2].Rows[0]["reply"].ToString());
                topic = int.Parse(dsR.Tables[2].Rows[0]["topic"].ToString());
                name = dsR.Tables[2].Rows[0]["studentname"].ToString();
            }
        }
    }
    protected void submit_Click(object sender, EventArgs e)
    {
        int studentid = 2;
        string hd = null;
        if (textareaHD.InnerText.ToString() != String.Empty)
        {
            try
            {
                hd = textareaHD.InnerText.ToString();
                string conStr = "Data Source=59.110.235.44;Initial Catalog=hongruan;User ID=hrdev;Password=123hrdev456";
                string dateStr = DateTime.Now.ToString();
                string YMD = DateTime.Now.Date.ToString();
                string sqlStr = "INSERT INTO CommunityReply (TopicID,StudentID,ReplyContent,ReplyTime) VALUES ('" + int.Parse(Session["TopicID"].ToString()) + "','" + studentid + "','" + hd + "','" + YMD + "')";
                SqlConnection conn = new SqlConnection(conStr);
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sqlStr;
                cmd.ExecuteNonQuery();
                conn.Close();
                // Response.Write("<script language=javascript>window.alert('" + ls_ts + "');</script>");
                this.textareaHD.Value = "";
                Response.Write("<script>alert('回答成功！');</script>");
                NONa.Visible = false;
                string sqlstr = "select CommunityTopic.TopicTiTle,CommunityTopic.TopicContent,CommunityTopic.TopicTime,Student.StudentName from CommunityTopic left join Student on CommunityTopic.StudentID=Student.StudentID where TopicID=" + int.Parse(Session["TopicID"].ToString()) + "";
                SqlConnection con = new SqlConnection(conStr);
                SqlDataAdapter sda = new SqlDataAdapter(sqlstr, con);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                topictitle = ds.Tables[0].Rows[0]["TopicTiTle"].ToString();
                topiccontent = ds.Tables[0].Rows[0]["TopicContent"].ToString();
                topictime = ds.Tables[0].Rows[0]["TopicTime"].ToString();
                studentname = ds.Tables[0].Rows[0]["StudentName"].ToString();

                string sql = "select CommunityReply.ReplyContent,CommunityReply.ReplyTime,Student.StudentName from CommunityReply left join Student on CommunityReply.StudentID=Student.StudentID where TopicID=" + int.Parse(Session["TopicID"].ToString()) + "";
                SqlConnection conn1 = new SqlConnection(conStr);
                SqlDataAdapter adp = new SqlDataAdapter(sql, conn1);
                DataSet dsR = new DataSet();
                adp.Fill(dsR);
                datalistR.DataSource = dsR;
                datalistR.DataBind();

                datalistRx.DataSource = dsR;
                datalistRx.DataBind();
            }
            catch (Exception exx)
            {
                Response.Write("<script>alert('回答失败！');</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('内容不能为空！');</script>");
        }


    }

    protected void submitxs_Click(object sender, EventArgs e)
    {
        int studentid = 2;
        string hd = null;
        if (textareaHDx.InnerText.ToString() != null)
        {
            hd = textareaHDx.InnerText.ToString();
            string conStr = "Data Source=59.110.235.44;Initial Catalog=hongruan;User ID=hrdev;Password=123hrdev456";
            string dateStr = DateTime.Now.ToString();
            string YMD = DateTime.Now.Date.ToString();
            string sqlStr = "INSERT INTO CommunityReply (TopicID,StudentID,ReplyContent,ReplyTime) VALUES ('" + int.Parse(Session["TopicID"].ToString()) + "','" + studentid + "','" + hd + "','" + YMD + "')";
            SqlConnection conn = new SqlConnection(conStr);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sqlStr;
            cmd.ExecuteNonQuery();
            conn.Close();
            // Response.Write("<script language=javascript>window.alert('" + ls_ts + "');</script>");
            this.textareaHD.Value = "";
            NONa.Visible = false;
            string sqlstr = "select CommunityTopic.TopicTiTle,CommunityTopic.TopicContent,CommunityTopic.TopicTime,Student.StudentName from CommunityTopic left join Student on CommunityTopic.StudentID=Student.StudentID where TopicID=" + int.Parse(Session["TopicID"].ToString()) + "";
            SqlConnection con = new SqlConnection(conStr);
            SqlDataAdapter sda = new SqlDataAdapter(sqlstr, con);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            topictitle = ds.Tables[0].Rows[0]["TopicTiTle"].ToString();
            topiccontent = ds.Tables[0].Rows[0]["TopicContent"].ToString();
            topictime = ds.Tables[0].Rows[0]["TopicTime"].ToString();
            studentname = ds.Tables[0].Rows[0]["StudentName"].ToString();

            string sql = "select CommunityReply.ReplyContent,CommunityReply.ReplyTime,Student.StudentName from CommunityReply left join Student on CommunityReply.StudentID=Student.StudentID where TopicID=" + int.Parse(Session["TopicID"].ToString()) + "";
            SqlConnection conn1 = new SqlConnection(conStr);
            SqlDataAdapter adp = new SqlDataAdapter(sql, conn1);
            DataSet dsR = new DataSet();
            adp.Fill(dsR);
            datalistR.DataSource = dsR;
            datalistR.DataBind();
            datalistRx.DataSource = dsR;
            datalistRx.DataBind();
        }

    }
}