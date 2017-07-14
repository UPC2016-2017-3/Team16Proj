using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;

public partial class 上传课时3 : System.Web.UI.Page
{
    public string fileName;
    public int fileSize;
    public string swfName;
    public int UnitID = 0;
    public string UName;
    public string URank;
    //public string ifhasfile;
    public string filextention;
    string connStr = "Data Source=59.110.235.44;Initial Catalog=hongruan;User ID=hrdev;Password=123hrdev456";
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["UserID"] == null)
        {
            Response.Write("alert('您还未登陆！');</script>");
            Response.Write("<script>   top.window.location.href = 'Login.aspx' ;</script>");
        }
        else
        {
            UName = Session["UnitName"].ToString();
            URank = Session["UnitRank"].ToString();
            UnitID = Int32.Parse(Session["UnitID"].ToString());
            if (!this.IsPostBack)
            {

                //UnitID = 1017;
                //URank = "4";
                //UName = "1235";
                this.Session["UploadInfo"] = new UploadInfo { IsReady = false };

            }
        }
    }
 

    public void upload_Click(object sender, EventArgs e)
    {

        fileName = Application["filename"].ToString();
        fileSize = Int32.Parse(Application["filesize"].ToString()) / 1024;
        swfName = Application["swfname"].ToString();
        //ifhasfile = Session["Ifhasfile"].ToString().Trim();
        filextention = Application["fileExtention"].ToString();
        //存数据库的文件夹路径
        String pdffile = "http://59.110.235.44/Uploads/" + fileName;
        String swffile = "http://59.110.235.44/PPT/" + swfName;
        String vediofile = "http://59.110.235.44/Uploads/" + fileName;
        String audiofile = "http://59.110.235.44/Uploads/" + fileName;
        //string id = Session["ClassID"].ToString();
        int id = int.Parse(Session["ClassID"].ToString());
        //获取文件类型
        //String fileCategory = "音频";
        //fileName = Application["name"].ToString();
        if (filextention == ".mp3" || filextention == ".ogg" || filextention==".wav")
        {
            SqlConnection con = new SqlConnection(connStr);
            try
            {
                //if (fileCategory == "PPT.PDF.WORD")
                //{
                //    //根据UnitID将数据插入PPT表
                //    string sqlStr4 = " insert into PPT (PPTName,PPTURL,PPTSize,SwfURL,UnitID) values ('" + fileName + "','" + pdffile + "','" + fileSize + "','" + swffile + "','" + UnitID + "')";
                //    //SqlConnection conn4 = new SqlConnection(connStr);
                //    con.Open();
                //    SqlCommand cmd4 = con.CreateCommand();
                //    cmd4.CommandText = sqlStr4;
                //    cmd4.ExecuteNonQuery();
                //    con.Close();
                //}
                //else if (fileCategory == "视频")
                //{
                //    //根据UnitID将数据插入Vedio表
                //    string sqlStr4 = " insert into Video (VideoName,VideoURL,VideoSize,UnitID) values ('" + fileName + "','" + vediofile + "','" + fileSize + "','" + UnitID + "')";
                //    //SqlConnection conn4 = new SqlConnection(connStr);
                //    con.Open();
                //    SqlCommand cmd4 = con.CreateCommand();
                //    cmd4.CommandText = sqlStr4;
                //    cmd4.ExecuteNonQuery();
                //    con.Close();
                //}
                //else if (fileCategory == "音频")
                //{
                    //根据UnitID将数据插入Audio表
                    string sqlStr4 = " insert into Audio (AudioName,AudioURL,AudioSize,UnitID) values ('" + fileName + "','" + audiofile + "','" + fileSize + "','" + UnitID + "')";
                    //SqlConnection conn4 = new SqlConnection(connStr);
                    con.Open();
                    SqlCommand cmd4 = con.CreateCommand();
                    cmd4.CommandText = sqlStr4;
                    cmd4.ExecuteNonQuery();
                    con.Close();
                //}
                Response.Write("<script>alert('该单元第三份资料添加成功！');</script>");
            }
            catch
            {

                Response.Write("<script>alert('添加资料失败！');</script>");
                //异常情况，当插入PPT表，Vedio表，Audio表任何一张表失败时，要删掉刚加入的Unit
                //string sqlD = "delete from Unit where UnitID = '" + UnitID + "'";
                ////SqlConnection conD = new SqlConnection(connStr);
                //SqlCommand cmdD = new SqlCommand(sqlD, con);
                //con.Open();
                //cmdD.ExecuteNonQuery();
                //con.Close();
            }
        }
        else
        {
            Response.Write("<script>alert('请选择正确格式的课时学习资料！');</script>");
        } 
    Server.Transfer("UnitLit.aspx");
    }
}