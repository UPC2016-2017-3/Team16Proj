using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    private string searchStr;
    public int ClassNum;
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
                string searchStr = Request.QueryString["search"];
                if (searchStr == null || searchStr == "")
                {
                    Response.Write("<script>alert('搜索内容不能为空')</script>");
                }
                else if (isSearchValid(searchStr))
                {
                    //准备编写查询数据库，绑定datalist的代码
                    //Response.Write(handleSearch(searchStr));
                    string connStr = "Data Source=59.110.235.44;Initial Catalog=hongruan;User ID=hrdev;Password=123hrdev456";
                    string sqlStr=null;
                    if (Request.QueryString["type"] == "1")
                    {
                       sqlStr = "select Class.* ,Department.DepartmentName from Class full join Class_Department on Class.ClassID=Class_Department.ClassID full join Department on Class_Department.DepartmentID=Department.DepartmentID where ClassName like '" + handleSearch(searchStr) + "'";
                    }
                    else if (Request.QueryString["type"] == "2")
                    {
                        sqlStr = "select * from class join Class_Category on class.ClassID=Class_Category.ClassID join Category on Category.CategoryID = Class_Category.CategoryID join Class_Department on Class.ClassID=Class_Department.ClassID join Department on Department.DepartmentID=Class_Department.DepartmentID where Category.CategoryID=" + int.Parse(searchStr) ;
                    }
                    SqlConnection conn = new SqlConnection(connStr);
                    SqlCommand cmd = conn.CreateCommand();
                    SqlCommand cmd2 = conn.CreateCommand();
                  
                        cmd2.CommandText = "insert into SearchRecord (KeyWord,StudentID,SearchTime) values ('" + searchStr + "','1','" + DateTime.Now.ToString() + "')";
                    
                    
                        conn.Open();
                    cmd2.ExecuteNonQuery();
                    SqlDataAdapter sda = new SqlDataAdapter(sqlStr, conn);
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    ClassNum = ds.Tables[0].Rows.Count;
                    datalist1.DataSource = ds;
                    datalist1.DataBind();
                    datalist2.DataSource = ds;
                    datalist2.DataBind();

                    if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                    {
                        Response.Write("<script>alert('对不起，没有您想要的内容')</script>");
                    }
                    conn.Close();
                }
                else
                {
                    Response.Write("<script>alert('搜索内容含有恶意字符')</script>");
                }

            }
        }
    }
    private Boolean isSearchValid(string str)
    {
        string[] InvalidStr = new string[] {"select","drop","insert","alert","create","from"};//定义非法字符串数组
        Boolean value = false;
        if (str != null) //判断传入的待搜索值非空
        {
            int flag = 0;
            for(int i = 0; i < InvalidStr.Length;i++) {
                if (str.Contains(InvalidStr[i])){//判断字符串是否包括非法字符
                    flag++;
                }
            }
            if (flag == 0){  //字符串没有包含任何非法字符
                value = true;
            }
        }
        return value;
    }

    private string handleSearch(string str)
    {
        str.Trim();
        str=str.Replace(" ", "");
        str = str.Replace("的", "");
        int number = str.Length;
        for (int i = number; i >= 0; i--)
        {
            str = str.Insert(i, "%");//将字符和字符之间插入%，以达到SQL模糊匹配的条件
        }
        return str;
    }
    protected void Zonghe_Click(object sender, EventArgs e)
    {
        string searchStr = Request.QueryString["search"];
        if (searchStr == null || searchStr == "")
        {
            Response.Write("<script>alert('搜索内容不能为空')</script>");
        }
        else if (isSearchValid(searchStr))
        {
            //准备编写查询数据库，绑定datalist的代码
            //Response.Write(handleSearch(searchStr));
            string connStr = "Data Source=59.110.235.44;Initial Catalog=hongruan;User ID=hrdev;Password=123hrdev456";

            string sqlStr = "select Class.* ,Department.DepartmentName from Class full join Class_Department on Class.ClassID=Class_Department.ClassID full join Department on Class_Department.DepartmentID=Department.DepartmentID where ClassName like '" + handleSearch(searchStr) + "'";

            SqlConnection conn = new SqlConnection(connStr);
            
            SqlDataAdapter sda = new SqlDataAdapter(sqlStr, conn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            ClassNum = ds.Tables[0].Rows.Count;
            datalist1.DataSource = ds;
            datalist1.DataBind();
            datalist2.DataSource = ds;
            datalist2.DataBind();

            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            {
                Response.Write("<script>alert('对不起，没有您想要的内容')</script>");
            }
            conn.Close();
        }
        else
        {
            Response.Write("<script>alert('搜索内容含有恶意字符')</script>");
        }
    }
    protected void Zuire_Click(object sender, EventArgs e)
    {
        string searchStr = Request.QueryString["search"];
        if (searchStr == null || searchStr == "")
        {
            Response.Write("<script>alert('搜索内容不能为空')</script>");
        }
        else if (isSearchValid(searchStr))
        {
            //准备编写查询数据库，绑定datalist的代码
            //Response.Write(handleSearch(searchStr));
            string connStr = "Data Source=59.110.235.44;Initial Catalog=hongruan;User ID=hrdev;Password=123hrdev456";

            string sqlStr = "select Class.* ,Department.DepartmentName from Class full join Class_Department on Class.ClassID=Class_Department.ClassID full join Department on Class_Department.DepartmentID=Department.DepartmentID where ClassName like '" + handleSearch(searchStr) + "' order by ClassCollectionNum desc";

            SqlConnection conn = new SqlConnection(connStr);
           
            SqlDataAdapter sda = new SqlDataAdapter(sqlStr, conn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            ClassNum = ds.Tables[0].Rows.Count;
            datalist1.DataSource = ds;
            datalist1.DataBind();
            datalist2.DataSource = ds;
            datalist2.DataBind();

            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            {
                Response.Write("<script>alert('对不起，没有您想要的内容')</script>");
            }
            conn.Close();
        }
        else
        {
            Response.Write("<script>alert('搜索内容含有恶意字符')</script>");
        }
    }
    protected void Quanbu_Click(object sender, EventArgs e)
    {
        string searchStr = Request.QueryString["search"];
        if (searchStr == null || searchStr == "")
        {
            Response.Write("<script>alert('搜索内容不能为空')</script>");
        }
        else if (isSearchValid(searchStr))
        {
            //准备编写查询数据库，绑定datalist的代码
            //Response.Write(handleSearch(searchStr));
            string connStr = "Data Source=59.110.235.44;Initial Catalog=hongruan;User ID=hrdev;Password=123hrdev456";

            string sqlStr = "select Class.* ,Department.DepartmentName from Class full join Class_Department on Class.ClassID=Class_Department.ClassID full join Department on Class_Department.DepartmentID=Department.DepartmentID where ClassName like '" + handleSearch(searchStr) + "'";

            SqlConnection conn = new SqlConnection(connStr);
            
            SqlDataAdapter sda = new SqlDataAdapter(sqlStr, conn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            ClassNum = ds.Tables[0].Rows.Count;
            datalist1.DataSource = ds;
            datalist1.DataBind();
            datalist2.DataSource = ds;
            datalist2.DataBind();

            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            {
                Response.Write("<script>alert('对不起，没有您想要的内容')</script>");
            }
            conn.Close();
        }
        else
        {
            Response.Write("<script>alert('搜索内容含有恶意字符')</script>");
        }
    }
    protected void Mianfei_Click(object sender, EventArgs e)
    {
        string searchStr = Request.QueryString["search"];
        if (searchStr == null || searchStr == "")
        {
            Response.Write("<script>alert('搜索内容不能为空')</script>");
        }
        else if (isSearchValid(searchStr))
        {
            //准备编写查询数据库，绑定datalist的代码
            //Response.Write(handleSearch(searchStr));
            string connStr = "Data Source=59.110.235.44;Initial Catalog=hongruan;User ID=hrdev;Password=123hrdev456";

            string sqlStr = "select Class.* ,Department.DepartmentName from Class full join Class_Department on Class.ClassID=Class_Department.ClassID full join Department on Class_Department.DepartmentID=Department.DepartmentID where ClassName like '" + handleSearch(searchStr) + "' and Class.ClassPrice= 0";

            SqlConnection conn = new SqlConnection(connStr);
            
            SqlDataAdapter sda = new SqlDataAdapter(sqlStr, conn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            ClassNum = ds.Tables[0].Rows.Count;
            datalist1.DataSource = ds;
            datalist1.DataBind();
            datalist2.DataSource = ds;
            datalist2.DataBind();

            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            {
                Response.Write("<script>alert('对不起，没有您想要的内容')</script>");
            }
            conn.Close();
        }
        else
        {
            Response.Write("<script>alert('搜索内容含有恶意字符')</script>");
        }
    }
    protected void Fufei_Click(object sender, EventArgs e)
    {
        string searchStr = Request.QueryString["search"];
        if (searchStr == null || searchStr == "")
        {
            Response.Write("<script>alert('搜索内容不能为空')</script>");
        }
        else if (isSearchValid(searchStr))
        {
            //准备编写查询数据库，绑定datalist的代码
            //Response.Write(handleSearch(searchStr));
            string connStr = "Data Source=59.110.235.44;Initial Catalog=hongruan;User ID=hrdev;Password=123hrdev456";

            string sqlStr = "select Class.* ,Department.DepartmentName from Class full join Class_Department on Class.ClassID=Class_Department.ClassID full join Department on Class_Department.DepartmentID=Department.DepartmentID where ClassName like '" + handleSearch(searchStr) + "' and Class.ClassPrice <> 0";

            SqlConnection conn = new SqlConnection(connStr);
           
            SqlDataAdapter sda = new SqlDataAdapter(sqlStr, conn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            ClassNum = ds.Tables[0].Rows.Count;
            datalist1.DataSource = ds;
            datalist1.DataBind();
            datalist2.DataSource = ds;
            datalist2.DataBind();

            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            {
                Response.Write("<script>alert('对不起，没有您想要的内容')</script>");
            }
            conn.Close();
        }
        else
        {
            Response.Write("<script>alert('搜索内容含有恶意字符')</script>");
        }
    }

}