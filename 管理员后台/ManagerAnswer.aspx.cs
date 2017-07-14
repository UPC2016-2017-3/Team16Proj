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


public partial class ManagerQandA : System.Web.UI.Page
{
    public String studentname, departmentname, questiontitle, questioncontent, answercontent, answertime, managername;
    string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["hongruanConnectionString"].ConnectionString;
    int PageSize;
    int CurrentPage;
    int RecordCount;
    double PageCountdouble;
    int PageCount;
    public string searchStr;
    SqlConnection MyConn;
    //public int companyid;
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
            //companyid = int.Parse(Session["CompanyID"].ToString());
            //Session["CompanyID"] = companyid;
            managerid = int.Parse(Session["ManagerID"].ToString());
            PageSize = 7;
            MyConn = new SqlConnection(connStr);

            MyConn.Open();
            //第一次请求执行
            if (!Page.IsPostBack)
            {
                ListBind();
                CurrentPage = 0;
                ViewState["PageIndex"] = 0;
                //计算总共有多少记录
                RecordCount = CalculateRecord();
                lblRecordCount.Text = RecordCount.ToString();
                //计算总共有多少页
                PageCountdouble = Math.Ceiling((double)RecordCount / (double)PageSize);
                PageCount = (int)PageCountdouble;
                lblPageCount.Text = PageCount.ToString();
                ViewState["PageCount"] = PageCount;
            }
            string connStrA = "Data Source=59.110.235.44;Initial Catalog=hongruan;User ID=hrdev;Password=123hrdev456";
            SqlConnection con = new SqlConnection(connStrA);
            SqlCommand cmd = con.CreateCommand();
            string strSqlQandAed = "SELECT StudentName,DepartmentName,QuestionTitle,QuestionContent,AnswerContent,AnswerTime,ManagerName FROM QandA LEFT JOIN Manager ON QandA.ManagerID=Manager.ManagerID left join Student on Student.StudentID=QandA.StudentID left join Department on Department.DepartmentID=Student.DepartmentID where (QandA.AnswerContent is not null and QandA.ManagerID='" + managerid + "') order by AnswerTime desc";
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(strSqlQandAed, con);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            zonghelist.DataSource = ds;
            zonghelist.DataBind();
            con.Close();
        }
    }
    //计算总共有多少条记录
    public int CalculateRecord()
    {
        int intCount;
        string strCount = "select count(*) as co from QandA join unit on QandA.UnitID= Unit.UnitID join Class on Class.ClassID=Unit.ClassID join Manager_Class on Manager_Class.ClassID=Class.ClassID join Student on student.StudentID=QandA.StudentID join Department on Student.DepartmentID=Department.DepartmentID where (Manager_Class.ManagerID=1 and QandA.AnswerContent is  null)";
        SqlCommand MyComm = new SqlCommand(strCount, MyConn);
        SqlDataReader dr = MyComm.ExecuteReader();
        if (dr.Read())
        {
            intCount = Int32.Parse(dr["co"].ToString());
        }
        else
        {
            intCount = 0;
        }
        dr.Close();
        return intCount;
    }
   
    //初始
    ICollection CreateSource()
    {

        int StartIndex;
        //设定导入的起终地址
        StartIndex = CurrentPage * PageSize;
        string strSel = "select * from  QandA join unit on QandA.UnitID= Unit.UnitID join Class on Class.ClassID=Unit.ClassID join Manager_Class on Manager_Class.ClassID=Class.ClassID join Student on student.StudentID=QandA.StudentID join Department on Student.DepartmentID=Department.DepartmentID where (Manager_Class.ManagerID=1 and QandA.AnswerContent is  null)";
        DataSet ds = new DataSet();
        SqlDataAdapter MyAdapter = new SqlDataAdapter(strSel, MyConn);
        MyAdapter.Fill(ds,StartIndex,PageSize,"QandA");
        return ds.Tables["QandA"].DefaultView;
    }
    
    //初始
    public void ListBind()
    {
        DatalistQ.DataSource = CreateSource();
        DatalistQ.DataBind();
        lbnNextPage.Enabled = true;
        lbnPrevPage.Enabled = true;
        if(CurrentPage==(PageCount-1)) lbnNextPage.Enabled = false;
        if(CurrentPage==0) lbnPrevPage.Enabled = false;
        lblCurrentPage.Text = (CurrentPage+1).ToString();
    }
    
    //翻页事件
    public void Page_OnClick(Object sender, CommandEventArgs e)
    {
        CurrentPage = (int)ViewState["PageIndex"];
        PageCount = (int)ViewState["PageCount"];

        string cmd = e.CommandName;
        //判断cmd，以判定翻页方向
        switch (cmd)
        {
            case "next":
                if (CurrentPage < (PageCount - 1)) CurrentPage++;
                break;
            case "prev":
                if (CurrentPage > 0) CurrentPage--;
                break;
        }
        ViewState["PageIndex"] = CurrentPage;
        ListBind();
    }
    
  
    //管理员提交答案
    public void Submit_OnClick(Object sender, CommandEventArgs e)
    {
        if (AnswerText.InnerText.ToString().Trim() != String.Empty)
        {
           try
            {
                string QuestionT = QuestionTitle.InnerText.ToString().Trim();
                string QuestionC = QuestionContent.InnerText.ToString().Trim();
                string Answer = AnswerText.InnerText.ToString();
                //int managerID = 1;
                string dateStr = DateTime.Now.ToString();
                string sqlStr = "UPDATE QandA SET ManagerID='" + managerid + "',AnswerContent='" + Answer + "',AnswerTime='" + dateStr + "' where QuestionTitle ='" + QuestionT + "'and QuestionContent ='" + QuestionC + "'";
                SqlConnection conn = new SqlConnection(connStr);
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sqlStr;
                cmd.ExecuteNonQuery();
                conn.Close(); 
                this.AnswerText.Value = "";
                Response.Write("<script>window.location='ManagerAnswer.aspx';alert('回答成功！');</script>");

            }
            catch (Exception exx)
            {
                Response.Write("<script>alert('回答失败！');</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('答案不能为空！');</script>");
        }      
    }
    //已回答问题列表
    protected string FormatFoo(object arg)
    {
        if (arg == null) return " ";
        string str = arg.ToString();
        return str.Length > 10 ? str.Substring(0, 10) + "..." : str;
    }

    //搜索功能
    public void Search_OnClick(Object sender, CommandEventArgs e)
    {
        string searchStr = SearchText.Value.Trim();
        if (searchStr == null || searchStr == "")
        {
            string connStr = "Data Source=59.110.235.44;Initial Catalog=hongruan;User ID=hrdev;Password=123hrdev456";
            string sqlStr = "select * from QandA join unit on QandA.UnitID= Unit.UnitID join Class on Class.ClassID=Unit.ClassID join Manager_Class on Manager_Class.ClassID=Class.ClassID join Student on student.StudentID=QandA.StudentID join Department on Student.DepartmentID=Department.DepartmentID where (Manager_Class.ManagerID=1 and QandA.AnswerContent is  null)";
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter(sqlStr, conn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            DatalistQ.DataSource = ds;
            DatalistQ.DataBind();

        }
        else if (isSearchValid(searchStr))
        {
            //准备编写查询数据库，绑定datalist的代码
            //Response.Write(handleSearch(searchStr));
            string connStr = "Data Source=59.110.235.44;Initial Catalog=hongruan;User ID=hrdev;Password=123hrdev456";
            string sqlStr = "select * from QandA join unit on QandA.UnitID= Unit.UnitID join Class on Class.ClassID=Unit.ClassID join Manager_Class on Manager_Class.ClassID=Class.ClassID join Student on student.StudentID=QandA.StudentID join Department on Student.DepartmentID=Department.DepartmentID where (Manager_Class.ManagerID=1 and QandA.AnswerContent is  null and (QuestionTitle like '" + handleSearch(searchStr) + "' or QuestionContent like '" + handleSearch(searchStr) + "'))";
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();  
            SqlDataAdapter sda = new SqlDataAdapter(sqlStr, conn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            DatalistQ.DataSource = ds;
            DatalistQ.DataBind();
            if (sda == null)
            {
                Response.Write("<script>alert('对不起，没有您想要的内容')</script>");
            }
            conn.Close();
            Page1.Attributes.Add("style","display:none");
            Page2.Attributes.Add("style", "display:none");
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
    }
    