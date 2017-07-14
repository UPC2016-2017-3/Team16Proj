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
using System.Text;


public partial class CourseList : System.Web.UI.Page
{
    public string searchStr;
    public string openness1;
    public int companyid;
    public int managerid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Write("alert('您还未登陆！');</script>");
            Response.Write("<script>   top.window.location.href = 'Login.aspx' ;</script>");
        }
        else
        {
            companyid = int.Parse(Session["CompanyID"].ToString());
            Session["CompanyID"] = companyid;
            managerid = int.Parse(Session["ManagerID"].ToString());
            string connStrA = "Data Source=59.110.235.44;Initial Catalog=hongruan;User ID=hrdev;Password=123hrdev456";
            SqlConnection con = new SqlConnection(connStrA);
            SqlCommand cmd = con.CreateCommand();
            // string strSqlQandAed = "SELECT StudentName,DepartmentName,QuestionTitle,QuestionContent,AnswerContent,AnswerTime, LEFT JOIN Manager ON QandA.ManagerID=Manager.ManagerID left join Student on Student.StudentID=QandA.StudentID left join Department on Department.DepartmentID=Student.DepartmentID where QandA.AnswerContent is not null order by AnswerTime desc";
            string strSqlCourse = "SELECT Class.ClassID,Category.CategoryName,Class.ClassName,Class.ClassInfo,Department.DepartmentName,Case Class.ClassOpenness when '1' then '开放' when '0' then '不开放' end as ClassOpenness,Class.ClassPrice FROM Class LEFT JOIN Class_Category on Class.ClassID=Class_Category.ClassID LEFT JOIN Category on Category.CategoryID=Class_Category.CategoryID LEFT JOIN Class_Department on Class_Department.ClassID=Class.ClassID LEFT JOIN Department on Department.DepartmentID=Class_Department.DepartmentID LEFT JOIN Manager_Class on Manager_Class.ClassID=Class.ClassID where Manager_Class.ManagerID='" + managerid + "' ";
            con.Open();


            SqlDataAdapter sda = new SqlDataAdapter(strSqlCourse, con);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            DataList_course.DataSource = ds;
            DataList_course.DataBind();


            con.Close();


        }
             
        
        

    }
    //搜索功能的实现
    public void Search_OnClick(Object sender, CommandEventArgs e)
    {
        
      
        string searchStr = SearchText.Value.Trim();
        if (searchStr == null || searchStr == "")
        {
            string connstr = "data source=59.110.235.44;initial catalog=hongruan;user id=hrdev;password=123hrdev456";
            string strSqlCourse1 = "SELECT Class.ClassID,Category.CategoryName,Class.ClassName,Class.ClassInfo,Department.DepartmentName,Case Class.ClassOpenness when '1' then '开放' when '0' then '不开放' end as ClassOpenness,Class.ClassPrice FROM Class LEFT JOIN Class_Category on Class.ClassID=Class_Category.ClassID LEFT JOIN Category on Category.CategoryID=Class_Category.CategoryID LEFT JOIN Class_Department on Class_Department.ClassID=Class.ClassID LEFT JOIN Department on Department.DepartmentID=Class_Department.DepartmentID LEFT JOIN Manager_Class on Manager_Class.ClassID=Class.ClassID where Manager_Class.ManagerID='"+managerid+"'";
            SqlConnection conn = new SqlConnection(connstr);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter(strSqlCourse1, conn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            DataList_course.DataSource = ds;
            DataList_course.DataBind();

        }
        else if (isSearchValid(searchStr))
        {
            //准备编写查询数据库，绑定datalist的代码
            //Response.Write(handleSearch(searchStr));
            string connStr = "Data Source=59.110.235.44;Initial Catalog=hongruan;User ID=hrdev;Password=123hrdev456";
            string sqlStr = "SELECT Class.ClassID,Category.CategoryName,Class.ClassName,Class.ClassInfo,Department.DepartmentName,Case Class.ClassOpenness when '1' then '开放' when '0' then '不开放' end as ClassOpenness,Class.ClassPrice FROM Class LEFT JOIN Class_Category on Class.ClassID=Class_Category.ClassID LEFT JOIN Category on Category.CategoryID=Class_Category.CategoryID LEFT JOIN Class_Department on Class_Department.ClassID=Class.ClassID LEFT JOIN Department on Department.DepartmentID=Class_Department.DepartmentID LEFT JOIN Manager_Class on Manager_Class.ClassID=Class.ClassID where Manager_Class.ManagerID='"+managerid+"'and (Class.ClassName like '" + handleSearch(searchStr) + "'or Class.ClassInfo like '" + handleSearch(searchStr) + "')";
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter(sqlStr, conn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            DataList_course.DataSource = ds;
            DataList_course.DataBind();
            if (sda == null)
            {
                Response.Write("<script>alert('对不起，没有您想要的内容')</script>");
            }
            conn.Close();
            //Page1.Attributes.Add("style", "display:none");
            //Page2.Attributes.Add("style", "display:none");
        }
        else
        {
            Response.Write("<script>alert('搜索内容含有恶意字符')</script>");
        }
    }
    private Boolean isSearchValid(string str)
    {
        string[] InvalidStr = new string[] { "select", "drop", "insert", "alert", "create", "from" };//定义非法字符串数组
        Boolean value = false;
        if (str != null) //判断传入的待搜索值非空
        {
            int flag = 0;
            for (int i = 0; i < InvalidStr.Length; i++)
            {
                if (str.Contains(InvalidStr[i]))
                {//判断字符串是否包括非法字符
                    flag++;
                }
            }
            if (flag == 0)
            {  //字符串没有包含任何非法字符
                value = true;
            }
        }
        return value;
    }
    private string handleSearch(string str)
    {
        str.Trim();
        str = str.Replace(" ", "");
        str = str.Replace("的", "");
        int number = str.Length;
        for (int i = number; i >= 0; i--)
        {
            str = str.Insert(i, "%");//将字符和字符之间插入%，以达到SQL模糊匹配的条件
        }
        return str;
    }
    //方法：课程信息多余字符省略号显示
    protected string FormatFoo(object arg)
    {
        if (arg == null) return " ";
        string str = arg.ToString();
        return str.Length > 50 ? str.Substring(0,50) + "..." : str;
    }

    //管理课程的跳转事件
    protected void Button1_Command(object sender, CommandEventArgs e)
    {
        int id = Convert.ToInt32(e.CommandArgument);
        string ID = id.ToString();
        Session["ClassID"] = ID;
        Response.Redirect("UnitList.aspx");

    }
}

