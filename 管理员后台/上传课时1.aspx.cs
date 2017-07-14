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


public partial class 上传课时1 : System.Web.UI.Page
{

    public string fileName;
    public int fileSize;
    public string swfName;   
    public string filextention;
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
            if (Session["UserID"] == null)
            {
                Response.Write("alert('您还未登陆！');</script>");
                Response.Write("<script>   top.window.location.href = 'Login.aspx' ;</script>");
            }
            else
            {
                if (!this.IsPostBack)
                {
                    this.Session["UploadInfo"] = new UploadInfo { IsReady = false };

                }
            }
        }
    }
    //http://59.110.235.44/video/ga.mp4  

    public void upload_Click(object sender, EventArgs e)
    {
        //存这一个页面的课时信息
        Session["UnitName"] = UnitName.Value;
        Session["UnitRank"] = UnitRank.Value;
       
        //Session["UnitID"] = UnitID;
        //拉取上Upload页面传过来的文件信息
        fileName = Application["filename"].ToString();
        fileSize = Int32.Parse(Application["filesize"].ToString()) / 1024;
        swfName = Application["swfname"].ToString();
        filextention = Application["fileExtention"].ToString();
        String Unitname = Request.Form["UnitName"].Trim();
        String Unitrank = UnitRank.Value;
        //存数据库的文件夹路径
        String pdffile = "http://59.110.235.44/Uploads/" + fileName;
        String swffile = "http://59.110.235.44/PPT/" + swfName;
        String vediofile = "http://59.110.235.44/Uploads/" + fileName;
        String audiofile = "http://59.110.235.44/Uploads/" + fileName;
        //string id = Session["ClassID"].ToString();
        int id = int.Parse(Session["ClassID"].ToString());
        //获取文件类型
        String fileCategory = "PPT.PDF.WORD";
        //fileName = Application["name"].ToString();
        if (Unitname != String.Empty && Unitrank != String.Empty)
        {
                //先查询数据库中是否有这个单元
                string sql = "select * from Unit where (UnitName ='" + Unitname + "'and ClassID='" + id + "')";
                SqlConnection con = new SqlConnection(connStr);
                con.Open();
                SqlDataAdapter sdr = new SqlDataAdapter(sql, con);
                DataSet ds = new DataSet();
                sdr.Fill(ds, "Class");
                //数据为0时，没有这个单元，可以添加，否则提示单元重复
                if (ds.Tables[0].Rows.Count == 0)
                {
                    con.Close();
                    //先将单元名称，ClassID插入数据库
                    string sqlStr = "insert into Unit(UnitName,ClassID,UnitRank) values ('" + Unitname + "','" + id  +"','"+ Unitrank + "')";
                    //SqlConnection conn = new SqlConnection(connStr);
                    con.Open();
                    SqlCommand cmdd = con.CreateCommand();
                    cmdd.CommandText = sqlStr;
                    cmdd.ExecuteNonQuery();
                    con.Close();

                    //查出上一条数据的UnitID
                    string sqlStr1 = "select UnitID from Unit where (UnitName ='" + Unitname + "'and ClassID='" + id + "')";
                    //SqlConnection conn1 = new SqlConnection(connStr);
                    con.Open();
                    SqlCommand cmd1 = con.CreateCommand();
                    cmd1.CommandText = sqlStr1;
                    SqlDataReader reader1 = cmd1.ExecuteReader();
                    reader1.Read(); 
                    int UnitID = reader1.GetInt32(reader1.GetOrdinal("UnitID"));
                    Session["UnitID"] = UnitID;
                    Console.Read();
                    con.Close();
                        if (filextention == ".pdf" || filextention == ".doc" || filextention == ".docx" || filextention == ".pptx" || filextention == ".ppt")
                        {
                            try
                            {
                                //根据UnitID将数据插入PPT表
                                string sqlStr4 = " insert into PPT (PPTName,PPTURL,PPTSize,SwfURL,UnitID) values ('" + fileName + "','" + pdffile + "','" + fileSize + "','" + swffile + "','" + UnitID + "')";
                                //SqlConnection conn4 = new SqlConnection(connStr);
                                con.Open();
                                SqlCommand cmd4 = con.CreateCommand();
                                cmd4.CommandText = sqlStr4;
                                cmd4.ExecuteNonQuery();
                                con.Close();
                                
                            }
                            catch
                            {
                                //异常情况，当插入PPT表失败时，要删掉刚加入的Unit
                                //string sqlD = "delete from Unit where UnitID = '" + UnitID + "'";
                                ////SqlConnection conD = new SqlConnection(connStr);
                                //SqlCommand cmdD = new SqlCommand(sqlD, con);
                                //con.Open();
                                //cmdD.ExecuteNonQuery();
                                //con.Close();
                            }
                            Response.Write("<script>alert('该单元和第一份资料添加成功！若还有其他资料，请您继续添加');</script>");
                            Server.Transfer("上传课时2.aspx");
                        }
                        else
                        {
                            Response.Write("<script>alert('请选择正确格式的课时学习资料！');</script>");
                        }
                    }                                                                                                                                         
                else
                {                  
                    Response.Write("<script>alert('已存在同名单元，请您更改单元名称！');</script>");
                }                
            }       
        else
        {
            Response.Write("<script>alert('单元名称和学习资料类型不可为空！');</script>");
        }       
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        //存这一个页面的课时信息
        Session["UnitName"] = UnitName.Value;
        Session["UnitRank"] = UnitRank.Value;

        String Unitname = Request.Form["UnitName"].Trim();
        String Unitrank = UnitRank.Value;

        int id = int.Parse(Session["ClassID"].ToString());
        //fileName = Application["name"].ToString();
        if (Unitname != String.Empty && Unitrank != String.Empty)
        {
            try
            {
                //先查询数据库中是否有这个单元
                string sql = "select * from Unit where (UnitName ='" + Unitname + "'and ClassID='" + id + "')";
                SqlConnection con = new SqlConnection(connStr);
                con.Open();
                SqlDataAdapter sdr = new SqlDataAdapter(sql, con);
                DataSet ds = new DataSet();
                sdr.Fill(ds, "Class");
                //数据为0时，没有这个单元，可以添加，否则提示单元重复
                if (ds.Tables[0].Rows.Count == 0)
                {
                    con.Close();
                    //将单元名称，ClassID插入数据库
                    string sqlStr = "insert into Unit(UnitName,ClassID,UnitRank) values ('" + Unitname + "','" + id + "','" + Unitrank + "')";
                    //SqlConnection conn = new SqlConnection(connStr);
                    con.Open();
                    SqlCommand cmdd = con.CreateCommand();
                    cmdd.CommandText = sqlStr;
                    cmdd.ExecuteNonQuery();
                    con.Close();

                    //查出上一条数据的UnitID
                    string sqlStr1 = "select UnitID from Unit where (UnitName ='" + Unitname + "'and ClassID='" + id + "')";
                    //SqlConnection conn1 = new SqlConnection(connStr);
                    con.Open();
                    SqlCommand cmd1 = con.CreateCommand();
                    cmd1.CommandText = sqlStr1;
                    SqlDataReader reader1 = cmd1.ExecuteReader();
                    reader1.Read();
                    int UnitID = reader1.GetInt32(reader1.GetOrdinal("UnitID"));
                    Session["UnitID"] = UnitID;
                    Console.Read();
                    con.Close();
                    Response.Write("<script>alert('课时添加成功，请您继续添加资料！');</script>");
                }
                else
                {
                    Response.Write("<script>alert('该课程下，已存在同名单元，请您更改单元名称！');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('添加失败！请您稍后再试');</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('单元名称和学习资料类型不可为空！');</script>");
        }
        Server.Transfer("上传课时2.aspx");
    }
}