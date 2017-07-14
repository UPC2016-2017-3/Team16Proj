using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;

public partial class 上传课程 : System.Web.UI.Page
{
    public int ClassOpen = 0;
    public int ClassID;
    public int course_companyid;
    public int course_managerid;
    public string FName;
    string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["hongruanConnectionString"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Write("alert('您还未登陆！');</script>");
            Response.Write("<script>   top.window.location.href = 'Login.aspx' ;</script>");
        }
        else
        {
            course_companyid = int.Parse(Session["CompanyID"].ToString());
            course_managerid = int.Parse(Session["ManagerID"].ToString());
        }
    }
    protected void SubmitClick(object sender, EventArgs e)
    {
        if (Request.Form["ClassName"].Trim() != String.Empty && Category.InnerText.ToString().Trim() != String.Empty && Department.InnerText.ToString().Trim() != String.Empty && Class_info.InnerText.ToString().Trim() != String.Empty && text1.InnerText.ToString().Trim() != String.Empty)
        {
            try
            {
                String ClassName =Request.Form["ClassName"].Trim();
                String ClassCategory = Category.InnerText.ToString().Trim();
                String ClassDepartment = Department.InnerText.ToString().Trim();
                String ClassInfo = Class_info.InnerText.ToString().Trim();
                int ClassOpen = IfOpen();
                //int ManagerID=1;
                int CategoryID;
                int DepartmentID;
                string CoverURL;
                int ClassPrice = Int32.Parse(Request.Form["Price"].Trim());
                if (filename.InnerText.ToString().Trim() != string.Empty)
                {
                    //string Covername = filename.InnerText.ToString().Trim();
                    CoverURL = "/ClassCoverImg/" + filename.InnerText.ToString().Trim();
                }
                else
                {
                    CoverURL = "/ClassCoverImg/CLASSCOVER.jpg";
                }
                //先查询数据库中是否有这门课
                string sql = "select * from Class where (ClassName = '" + ClassName + "'and CompanyID='"+course_companyid+"')";
                SqlConnection con = new SqlConnection(connStr);
                con.Open();  
                SqlDataAdapter sdr = new SqlDataAdapter(sql, con);
                DataSet ds = new DataSet();
                sdr.Fill(ds,"Class");
                try
                {
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        con.Close();
                        //先将课程名称，简介，是否开放，价钱插入数据库
                        string sqlStr = "insert into Class(ClassName,ClassOpenness,ClassInfo,ClassPrice,CompanyID,ClassClickNum,ClassCollectionNum,ClassDiscussNum,ClassCoverURL) values ('" + ClassName + "','" + ClassOpen + "','" + ClassInfo + "','" + ClassPrice + "','" + course_companyid + "',0,0,0,'" + CoverURL + "')";
                        SqlConnection conn = new SqlConnection(connStr);
                        conn.Open();
                        SqlCommand cmdd = conn.CreateCommand();
                        cmdd.CommandText = sqlStr;
                        cmdd.ExecuteNonQuery();
                        conn.Close();

                        //查出上一条数据的ClassID
                        string sqlStr1 = "select ClassID from Class where (ClassName ='" + ClassName + "' and CompanyID='" + course_companyid + "') ";
                        SqlConnection conn1 = new SqlConnection(connStr);
                        conn1.Open();
                        SqlCommand cmd1 = conn1.CreateCommand();
                        cmd1.CommandText = sqlStr1;
                        SqlDataReader reader1 = cmd1.ExecuteReader();
                        reader1.Read();
                        ClassID = reader1.GetInt32(reader1.GetOrdinal("ClassID"));
                        Console.Read();
                        conn1.Close();

                        //查出课程类别ID
                        string sqlStr2 = "select CategoryID from Category where CategoryName ='" + ClassCategory + "'";
                        SqlConnection conn2 = new SqlConnection(connStr);
                        conn2.Open();
                        SqlDataAdapter reader2 = new SqlDataAdapter(sqlStr2, conn2);
                        DataSet ds2 = new DataSet();
                        reader2.Fill(ds2, "Category");
                        string category = ds2.Tables[0].Rows[0][0].ToString();
                        CategoryID = Convert.ToInt32(category);
                        conn2.Close();

                        //查出部门ID
                        string sqlStr3 = "select DepartmentID from Department where DepartmentName ='" + ClassDepartment + "'";
                        SqlConnection conn3 = new SqlConnection(connStr);
                        conn3.Open();         
                        SqlDataAdapter reader3 = new SqlDataAdapter(sqlStr3, conn3);
                        DataSet ds3 = new DataSet();
                        reader3.Fill(ds3, "Category");
                        string department = ds3.Tables[0].Rows[0][0].ToString();
                        DepartmentID = Convert.ToInt32(department);
                        

                        //将ClassID和ManagerID插入Manager_Class表
                        string sqlStr6 = "insert into Manager_Class(ManagerID,ClassID) values ('"+ course_managerid + "','" + ClassID + "')";
                        SqlCommand cmd6 = conn3.CreateCommand();
                        cmd6.CommandText = sqlStr6;
                        cmd6.ExecuteNonQuery();
                        conn3.Close(); 
                 

                        //根据ClassID将数据插入ClassCategory表
                        string sqlStr4 = " insert into Class_Category (ClassID,CategoryID) values ('" + ClassID + "','" + CategoryID + "')";
                        SqlConnection conn4 = new SqlConnection(connStr);
                        conn4.Open();
                        SqlCommand cmd4 = conn4.CreateCommand();
                        cmd4.CommandText = sqlStr4;
                        cmd4.ExecuteNonQuery();
                        conn4.Close();

                        //根据ClassID将数据插入到ClassDepartment表
                        string sqlStr5 = " insert into Class_Department (DepartmentID,ClassID) values ('" + DepartmentID + "','" + ClassID + "')";
                        SqlConnection conn5 = new SqlConnection(connStr);
                        conn5.Open();
                        SqlCommand cmd5 = conn5.CreateCommand();
                        cmd5.CommandText = sqlStr5;
                        cmd5.ExecuteNonQuery();
                        conn5.Close();
                    }
                    else
                    {
                        con.Close();
                        Response.Write("<script>window.location='上传课程.aspx';alert('已存在同名课程，请您更改课程名！');</script>");
                    }
                }
                catch (Exception ex)
                {
                    con.Close();
                    //两个异常，即两个DataSet为空，会执行删除操作
                    string sqlD = "delete from Class where ClassID = '" + ClassID + "'";
                    SqlConnection conD = new SqlConnection(connStr);
                    SqlCommand cmdD = new SqlCommand(sqlD, conD);
                    try
                    {
                        conD.Open();
                        cmdD.ExecuteNonQuery();
                        conD.Close();
                    }
                    catch (Exception exxx)
                    {
                        Console.WriteLine("{0} Exception caught.", exxx);
                    }
                    Response.Write("<script>window.location='上传课程.aspx';alert('添加课程失败！没有相应的部门和类别,或者课程名称已经存在，请您检查！');</script>");
                }                 

            }
            catch (Exception exx)
            {    
                Response.Write("<script>alert('添加课程失败，请您稍后再试！');</script>");
            }
            this.ClassName.Value = "";
            this.Category.Value = "";
            this.Department.Value = "";
            this.Class_info.Value = "";
            this.Price.Value = "";
            Response.Write("<script>window.location='上传课程.aspx';alert('添加成功！');</script>");
        }
        else
        {
            Response.Write("<script>alert('请您检查，以上信息不可留有空项！');</script>");
        }      
    }
    public int IfOpen()
    {

        if (text1.InnerText.ToString().Trim() == "开放")
        {
            ClassOpen = 1;
        }
        else
        {
            ClassOpen = 0;
        }
        return ClassOpen;
    }
    protected void file_Click(object sender, EventArgs e)
    {
        if (Coverload.PostedFile.ContentLength > 0)
        {
            string fileName = Coverload.FileName;
            FName = fileName;
            string fileExtention = Coverload.FileName.Substring(fileName.LastIndexOf("."));
            if (fileExtention == ".png" || fileExtention == ".jpg"||fileExtention==".jpeg")
            {
                string filePath = HttpContext.Current.Server.MapPath("~/ClassCoverImg\\") + fileName;
                Coverload.SaveAs(filePath);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('上传成功')</script>");
            }
            else
            {
                Response.Write("<script>alert('请选择正确格式的图片文件！');</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('请选择一张图片！');</script>"); 
        }
        
    }
}