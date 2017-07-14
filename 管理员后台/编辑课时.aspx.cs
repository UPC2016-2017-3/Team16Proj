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

public partial class 编辑课时 : System.Web.UI.Page
{
    public string UnitName;
    public string FileName1;
    public string FileName2;
    public string FileName3;
    public string fileName;
    public int URank=1;
    public int unitrank;
    public string unitname;
    public int classid;
    public int unitid;
    Boolean PPTTrue = false;
    Boolean VideooTrue = false;
    Boolean AudioTure = false;
    public string filextention;
    public int fileSize;
    public string swfName;
    int count=0;
    string IFhasfile = "2";
    string connStr = "Data Source=59.110.235.44;Initial Catalog=hongruan;User ID=hrdev;Password=123hrdev456";
    protected void Page_Load(object sender, EventArgs args)
    {
        if (Session["UserID"] == null)
        {
            Response.Write("alert('您还未登陆！');</script>");
            Response.Write("<script>   top.window.location.href = 'Login.aspx' ;</script>");
        }
        else
        {

            IFhasfile = IFhasFile.InnerText.ToString().Trim();
            if (Session["UnitID"] != null && Session["UnitRank"] != null)
            {

                //classid = int.Parse(Session["UnitID"].ToString());
                unitid = int.Parse(Session["UnitID"].ToString());
                unitrank = int.Parse(Session["UnitRank"].ToString());
                unitname = Session["UnitName"].ToString();
                //取ClassID,UnitID,UnitRank的Session
                this.Session["UploadInfo"] = new UploadInfo { IsReady = false };

                //查询数据库是否有PPT类型文件
                string sql = "select * from PPT where UnitID = '" + unitid + "'";
                SqlConnection con = new SqlConnection(connStr);
                con.Open();
                SqlDataAdapter sdr = new SqlDataAdapter(sql, con);
                DataSet ds = new DataSet();
                sdr.Fill(ds);
                if (ds.Tables[0].Rows.Count == 1)
                {
                    //有。则调出相关信息
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = sql;
                    SqlDataReader reader1 = cmd.ExecuteReader();
                    reader1.Read();
                    FileName1 = (string)reader1["PPTName"];
                    Console.Read();
                    con.Close();
                    count = count + 1;
                    PPTTrue = true;
                }
                else
                {
                    FileName1 = "暂无此类型文件";
                }

                //从Vedio表里查询是否有该类型文件
                string sqlV = "select * from Video where UnitID = '" + unitid + "'";
                SqlConnection conV = new SqlConnection(connStr);
                conV.Open();
                SqlDataAdapter sdrV = new SqlDataAdapter(sqlV, conV);
                DataSet dsV = new DataSet();
                sdrV.Fill(dsV, "Video");
                if (dsV.Tables[0].Rows.Count == 1)
                {
                    //有。则调出相关信息
                    SqlCommand cmdV = conV.CreateCommand();
                    cmdV.CommandText = sqlV;
                    SqlDataReader readerV = cmdV.ExecuteReader();
                    readerV.Read();
                    FileName2 = (string)readerV["VideoName"];
                    Console.Read();
                    conV.Close();
                    count = count + 1;
                    VideooTrue = true;
                }
                else
                {
                    FileName2 = "暂无此类型文件";
                }

                //从Audio表里查询是否有该类型文件
                string sqlA = "select * from Audio where UnitID = '" + unitid + "'";
                SqlConnection conA = new SqlConnection(connStr);
                conA.Open();
                SqlDataAdapter sdrA = new SqlDataAdapter(sqlA, con);
                DataSet dsA = new DataSet();
                sdrA.Fill(dsA, "Audio");
                if (dsA.Tables[0].Rows.Count == 1)
                {
                    //有。则调出相关信息
                    SqlCommand cmdA = conA.CreateCommand();
                    cmdA.CommandText = sqlA;
                    SqlDataReader readerA = cmdA.ExecuteReader();
                    readerA.Read();
                    FileName3 = (string)readerA["AudioName"];
                    Console.Read();
                    conA.Close();
                    count = count + 1;
                    AudioTure = true;
                }
                else
                {
                    FileName3 = "暂无此类型文件";
                }

                //
                if (count == 3)
                {
                    div1.Attributes["style"] = "display:none"; //隐藏
                }
                else
                {
                    div1.Attributes["style"] = "display:block"; //显示
                }
            }

        }
    }
    public void upload_Click(object sender, EventArgs e)
    {
        
        
        String pdffile = "http://59.110.235.44/Uploads/" + fileName;
        String swffile = "http://59.110.235.44/PPT/" + swfName;
        String vediofile = "http://59.110.235.44/Uploads/" + fileName;
        String audiofile = "http://59.110.235.44/Uploads/" + fileName;
        //int id = 26;
        //int id = int.Parse(Session["ClassID"].ToString());
        string NewUnitname = Request.Form["Name"].Trim();
        if (IFhasfile=="1")
        {            
            if (NewUnitname != string.Empty)
            {
                SqlConnection con = new SqlConnection(connStr);
                string sqlStr4 = "UPDATE Unit SET UnitName='" + NewUnitname + "' where (UnitID ='" + unitid + "')";
                //SqlConnection conn4 = new SqlConnection(connStr);          
                con.Open();
                SqlCommand cmd4 = con.CreateCommand();
                cmd4.CommandText = sqlStr4;
                cmd4.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('课时名称修改成功！');</script>");
            }
        }
        else
        {
            fileName = Application["filename"].ToString();
            fileSize = Int32.Parse(Application["filesize"].ToString()) / 1024;
            swfName = Application["swfname"].ToString();
            filextention = Application["fileExtention"].ToString();       
            if ((filextention == ".pdf" || filextention == ".doc" || filextention == ".docx" || filextention == ".pptx" || filextention == ".ppt"))        
            {           
                if (PPTTrue)            
                {                
                    Response.Write("<script>alert('已有PPT.WORD.PDF类型文件，不可重复添加！');</script>");           
                }            
                else            
                {               
                    SqlConnection con = new SqlConnection(connStr);                
                    string sqlStr4 = " insert into PPT (PPTName,PPTURL,PPTSize,SwfURL,UnitID) values ('" + fileName + "','" + pdffile + "','" + fileSize + "','" + swffile + "','" + unitid + "')";                
                    //SqlConnection conn4 = new SqlConnection(connStr);                
                    con.Open();                
                    SqlCommand cmd4 = con.CreateCommand();                
                    cmd4.CommandText = sqlStr4;                
                    cmd4.ExecuteNonQuery();                
                    con.Close();                
                    Response.Write("<script>alert('新文件添加成功！');</script>");            
                }
        }
        else if (filextention == ".mp4")
        {
            if (VideooTrue)
            {
                Response.Write("<script>alert('已有视频类型文件，不可重复添加！');</script>");

            }
            else
            {
                SqlConnection con = new SqlConnection(connStr);
                string sqlStr4 = " insert into Video (VideoName,VideoURL,VideoSize,UnitID) values ('" + fileName + "','" + vediofile + "','" + fileSize + "','" + unitid + "')";
                con.Open();
                SqlCommand cmd4 = con.CreateCommand();
                cmd4.CommandText = sqlStr4;
                cmd4.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('新文件添加成功！');</script>");
            }
        }
        else if (filextention == ".mp3" || filextention == ".ogg" || filextention == ".wav")
        {
            if (AudioTure)
            {
                Response.Write("<script>alert('已有音频类型文件，不可重复添加！');</script>");
            }
            else
            {
                SqlConnection con = new SqlConnection(connStr);
                string sqlStr4 = " insert into Audio (AudioName,AudioURL,AudioSize,UnitID) values ('" + fileName + "','" + audiofile + "','" + fileSize + "','" + unitid + "')";
                //SqlConnection conn4 = new SqlConnection(connStr);
                con.Open();
                SqlCommand cmd4 = con.CreateCommand();
                cmd4.CommandText = sqlStr4;
                cmd4.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('新文件添加成功！');</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('您选择的文件格式不符合要求！');</script>");
        }
        }
    }
    //protected void upload_Click1(object sender, EventArgs e)
    //{
    //    IFhasfile = "2";
    //}
}