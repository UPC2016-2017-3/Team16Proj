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


public partial class ManagerDiscuss : System.Web.UI.Page
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
            managerid = int.Parse(Session["ManagerID"].ToString());
            PageSize = 10;
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

        }
    }
    public int CalculateRecord()
    {
        int intCount;

        string strCount = "select count(*) as co FROM Manager LEFT JOIN Manager_Class ON Manager_Class.ManagerID=Manager.ManagerID LEFT JOIN Class on Class.ClassID=Manager_Class.ClassID LEFT JOIN Unit on Unit.ClassID=Class.ClassID LEFT JOIN DiscussUnit on DiscussUnit.UnitID=Unit.UnitID LEFT JOIN Student on Student.StudentID=DiscussUnit.StudentID LEFT JOIN Department on Department.DepartmentID=Student.DepartmentID where (Manager.ManagerID='" + managerid + "' and DiscussUnit.DiscussContent is not null) ";

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
        string strSel = "SELECT Class.ClassName,Unit.UnitName,DiscussUnit.DiscussContent,DiscussUnit.DiscussTime,DiscussUnit.DisscusID,Student.StudentName,Department.DepartmentName FROM Manager LEFT JOIN Manager_Class ON Manager_Class.ManagerID=Manager.ManagerID LEFT JOIN Class on Class.ClassID=Manager_Class.ClassID LEFT JOIN Unit on Unit.ClassID=Class.ClassID LEFT JOIN DiscussUnit on DiscussUnit.UnitID=Unit.UnitID LEFT JOIN Student on Student.StudentID=DiscussUnit.StudentID LEFT JOIN Department on Department.DepartmentID=Student.DepartmentID where (Manager.ManagerID='" + managerid + "'and DiscussUnit.DiscussContent is not null) order by DiscussTime desc";
        DataSet ds = new DataSet();
        SqlDataAdapter MyAdapter = new SqlDataAdapter(strSel, MyConn);
        MyAdapter.Fill(ds, StartIndex, PageSize, "QandA");
        return ds.Tables["QandA"].DefaultView;
    }

    //初始
    public void ListBind()
    {
        DatalistDis.DataSource = CreateSource();
        DatalistDis.DataBind();
        lbnNextPage.Enabled = true;
        lbnPrevPage.Enabled = true;
        if (CurrentPage == (PageCount - 1)) lbnNextPage.Enabled = false;
        if (CurrentPage == 0) lbnPrevPage.Enabled = false;
        lblCurrentPage.Text = (CurrentPage + 1).ToString();
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


    //管理员删除评论
    public void Submit_OnClick(Object sender, CommandEventArgs e)
    {
        string connStr = "Data Source=59.110.235.44;Initial Catalog=hongruan;User ID=hrdev;Password=123hrdev456";

        try
        {
            int number_discussid = int.Parse(DiscussID.InnerText.ToString().Trim());

            string sqlStr1 = "delete from DiscussUnit where DisscusID='" + number_discussid + "'";
            //string sqlStr2 = "delete from Audio where UnitID='" + number_unitid + "'";
            //string sqlStr3 = "delete from Video where UnitID='" + number_unitid + "'";
            //string sqlStr = "delete from Unit where UnitID ='" + number_unitid + "'";

            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();

            SqlCommand cmd1 = conn.CreateCommand();
            cmd1.CommandText = sqlStr1;
            cmd1.ExecuteNonQuery();

            //SqlCommand cmd2 = conn.CreateCommand();
            //cmd2.CommandText = sqlStr2;
            //cmd2.ExecuteNonQuery();

            //SqlCommand cmd3 = conn.CreateCommand();
            //cmd3.CommandText = sqlStr3;
            //cmd3.ExecuteNonQuery();

            //SqlCommand cmd = conn.CreateCommand();
            //cmd2.CommandText = sqlStr;
            //cmd2.ExecuteNonQuery();

            conn.Close();
            Response.Write("<script>window.location='ManagerDiscuss.aspx';alert('删除成功！');</script>");

        }
        catch (Exception exx)
        {
            Response.Write("<script>alert('删除失败！');</script>");
        }
    }
    //字符长度控制
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
            string sqlStr = "SELECT Class.ClassName,Unit.UnitName,DiscussUnit.DiscussContent,DiscussUnit.DiscussTime,DiscussUnit.DisscusID,Student.StudentName,Department.DepartmentName FROM Manager LEFT JOIN Manager_Class ON Manager_Class.ManagerID=Manager.ManagerID LEFT JOIN Class on Class.ClassID=Manager_Class.ClassID LEFT JOIN Unit on Unit.ClassID=Class.ClassID LEFT JOIN DiscussUnit on DiscussUnit.UnitID=Unit.UnitID LEFT JOIN Student on Student.StudentID=DiscussUnit.StudentID LEFT JOIN Department on Department.DepartmentID=Student.DepartmentID where (Manager.ManagerID='" + managerid + "'and DiscussUnit.DiscussContent is not null)";
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter(sqlStr, conn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            DatalistDis.DataSource = ds;
            DatalistDis.DataBind();

        }
        else if (isSearchValid(searchStr))
        {
            //准备编写查询数据库，绑定datalist的代码
            //Response.Write(handleSearch(searchStr));
            string connStr = "Data Source=59.110.235.44;Initial Catalog=hongruan;User ID=hrdev;Password=123hrdev456";
            string sqlStr = "SELECT Class.ClassName,Unit.UnitName,DiscussUnit.DiscussContent,DiscussUnit.DiscussTime,DiscussUnit.DisscusID,Student.StudentName,Department.DepartmentName FROM Manager LEFT JOIN Manager_Class ON Manager_Class.ManagerID=Manager.ManagerID LEFT JOIN Class on Class.ClassID=Manager_Class.ClassID LEFT JOIN Unit on Unit.ClassID=Class.ClassID LEFT JOIN DiscussUnit on DiscussUnit.UnitID=Unit.UnitID LEFT JOIN Student on Student.StudentID=DiscussUnit.StudentID LEFT JOIN Department on Department.DepartmentID=Student.DepartmentID where (Manager.ManagerID='" + managerid + "'and DiscussUnit.DiscussContent is not null and DiscussContent like '" + handleSearch(searchStr) + "')";
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter(sqlStr, conn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            DatalistDis.DataSource = ds;
            DatalistDis.DataBind();
            if (sda == null)
            {
                Response.Write("<script>alert('对不起，没有您想要的内容')</script>");
            }
            conn.Close();
            Page1.Attributes.Add("style", "display:none");
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
