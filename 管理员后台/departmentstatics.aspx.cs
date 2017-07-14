using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.Collections;



public partial class 课程统计 : System.Web.UI.Page
{
    public string data1, data2;
    int PageSize;
    int CurrentPage;
    int RecordCount;
    double PageCountdouble;
    int PageCount;
    public string depNum;
    public int companyid;
    public int managerid;
    string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["hongruanConnectionString"].ConnectionString;
    DataSet ds1 = new DataSet();
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
            managerid = int.Parse(Session["ManagerID"].ToString());
            PageSize = 10;
            SqlConnection con = new SqlConnection(connStr);
            con.Open();
            if (!Page.IsPostBack)
            {
                ListBind();
                CurrentPage = 0;
                ViewState["PageIndex"] = 0;
                lblRecordCount.Text = RecordCount.ToString();
                PageCountdouble = Math.Ceiling((double)RecordCount / (double)PageSize);
                PageCount = (int)PageCountdouble;
                lblPageCount.Text = PageCount.ToString();
                ViewState["PageCount"] = PageCount;
            }

            string sql1 = "select  Student.DepartmentID,max(department.DepartmentName)as departmentname,count(distinct Student.StudentID)as studentNum, count(case Collection.Compulsion when 1 then Collection.collectionid else null end) as tasknum,count(case Collection.IsCompleted when 1 then ( case Collection.Compulsion when 1 then Collection.collectionid else null end) else null  end)as taskDone,((Convert(decimal(10,2),(case(count(case Collection.Compulsion when 1 then Collection.collectionid else null end) ) when 0 then 0 else count(case Collection.IsCompleted when 1 then ( case Collection.Compulsion when 1 then Collection.collectionid else null end) else null  end)/(count(case Collection.Compulsion when 1 then Collection.collectionid else null end)+0.0)end)))*100)as taskratio from student full join Department_Company on Student.DepartmentID = Department_Company.DepartmentID full join Department on Department_Company.DepartmentID=Department.DepartmentID full join Collection on Collection.StudentID=Student.StudentID where Department_Company.CompanyID='" + companyid + "' group by Student.DepartmentID ";
            SqlDataAdapter adp = new SqlDataAdapter(sql1, con);
            DataSet ds = new DataSet();
            adp.Fill(ds);

            StringBuilder departname = new StringBuilder();
            StringBuilder ratio = new StringBuilder();

            if (ds.Tables[0] != null & ds.Tables[0].Rows.Count > 0)
            {
                departname.Append("'");
                departname.Append(ds.Tables[0].Rows[0]["departmentname"]);
                departname.Append("'");
                ratio.Append(ds.Tables[0].Rows[0]["taskratio"]);
                for (int i = 1; i < ds.Tables[0].Rows.Count; i++)
                {
                    departname.Append(",");
                    departname.Append("'");
                    departname.Append(ds.Tables[0].Rows[i]["departmentname"].ToString().Trim());
                    departname.Append("'");
                    ratio.Append(",");
                    ratio.Append(ds.Tables[0].Rows[i]["taskratio"].ToString().Trim());
                }
                data1 = departname.ToString();
                data2 = ratio.ToString();
            }


        }
    }
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

    ICollection CreateSource()
    {
               
        int StartIndex;
        //设定导入的起终地址
        StartIndex = CurrentPage * PageSize;
        string sql1 = "select  Student.DepartmentID,max(department.DepartmentName)as departmentname,count(distinct Student.StudentID)as studentNum, count(case Collection.Compulsion when 1 then Collection.collectionid else null end) as tasknum,count(case Collection.IsCompleted when 1 then ( case Collection.Compulsion when 1 then Collection.collectionid else null end) else null  end)as taskDone,((Convert(decimal(10,2),(case(count(case Collection.Compulsion when 1 then Collection.collectionid else null end) ) when 0 then 0 else count(case Collection.IsCompleted when 1 then ( case Collection.Compulsion when 1 then Collection.collectionid else null end) else null  end)/(count(case Collection.Compulsion when 1 then Collection.collectionid else null end)+0.0)end)))*100)as taskratio from student full join Department_Company on Student.DepartmentID = Department_Company.DepartmentID full join Department on Department_Company.DepartmentID=Department.DepartmentID full join Collection on Collection.StudentID=Student.StudentID where Department_Company.CompanyID='"+companyid+"'group by Student.DepartmentID ";
        SqlDataAdapter da1 = new SqlDataAdapter(sql1, connStr);       
        da1.Fill(ds1);
        RecordCount = ds1.Tables[0].Rows.Count;
        da1.Fill(ds1, StartIndex, PageSize, "a");
        return ds1.Tables["a"].DefaultView;

    }
    public void ListBind()
    {
        datalist1.DataSource = CreateSource();
        datalist1.DataBind();
        lbnNextPage.Enabled = true;
        lbnPrevPage.Enabled = true;
        if (CurrentPage == (PageCount - 1)) lbnNextPage.Enabled = false;
        if (CurrentPage == 0) lbnPrevPage.Enabled = false;
        lblCurrentPage.Text = (CurrentPage + 1).ToString();

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        
        SqlConnection con = new SqlConnection(connStr);
        //定义查询语句,这里最好将SQL语句在SQL中写好并验证正确确在复制粘贴过来（在对数据查询时最好只查所需的一些不需要的数据就不要取出，这样可以提高运行的效率）
        string strSql = "select  max(department.DepartmentName)as '部门',count(distinct Student.StudentID)as '员工数', count(case Collection.Compulsion when 1 then Collection.collectionid else null end) as '任务数',count(case Collection.IsCompleted when 1 then ( case Collection.Compulsion when 1 then Collection.collectionid else null end) else null  end)as '任务完成数',((Convert(decimal(10,2),(case(count(case Collection.Compulsion when 1 then Collection.collectionid else null end) ) when 0 then 0 else count(case Collection.IsCompleted when 1 then ( case Collection.Compulsion when 1 then Collection.collectionid else null end) else null  end)/(count(case Collection.Compulsion when 1 then Collection.collectionid else null end)+0.0)end)))*100)as '任务完成率' from student full join Department_Company on Student.DepartmentID = Department_Company.DepartmentID full join Department on Department_Company.DepartmentID=Department.DepartmentID full join Collection on Collection.StudentID=Student.StudentID where Department_Company.CompanyID='"+companyid +"' group by Student.DepartmentID ";
        con.Open();//打开数据库连接 (当然此句可以不写的)
        SqlDataAdapter sda = new SqlDataAdapter(strSql, con);
        DataSet ds = new DataSet();
        sda.Fill(ds);//把执行得到的数据放在数据集中
        con.Close();
        CreateExcel c = new CreateExcel();
        c.Createxls(ds, "部门统计信息.xls", Page);
    }
    protected void search_Click(object sender, EventArgs e)
    {
        string searchcontent = text.Value.ToString().Trim();
        string sql1 = "select  Student.DepartmentID,max(department.DepartmentName)as departmentname,count(distinct Student.StudentID)as studentNum, count(case Collection.Compulsion when 1 then Collection.collectionid else null end) as tasknum,count(case Collection.IsCompleted when 1 then ( case Collection.Compulsion when 1 then Collection.collectionid else null end) else null  end)as taskDone,((Convert(decimal(10,2),(case(count(case Collection.Compulsion when 1 then Collection.collectionid else null end) ) when 0 then 0 else count(case Collection.IsCompleted when 1 then ( case Collection.Compulsion when 1 then Collection.collectionid else null end) else null  end)/(count(case Collection.Compulsion when 1 then Collection.collectionid else null end)+0.0)end)))*100)as taskratio from student full join Department_Company on Student.DepartmentID = Department_Company.DepartmentID full join Department on Department_Company.DepartmentID=Department.DepartmentID full join Collection on Collection.StudentID=Student.StudentID where Department_Company.CompanyID='"+companyid+"'group by Student.DepartmentID ";
        SqlDataAdapter da1 = new SqlDataAdapter(sql1, connStr);
        da1.Fill(ds1);

        DataTable dt = ds1.Tables[0];
        string expression = "departmentname like '%" + searchcontent + "%'";
        dt.DefaultView.RowFilter = expression;
        int a =int.Parse(dt.Select(expression).Count().ToString());
        datalist1.DataSource = dt;
        datalist1.DataBind();
        CurrentPage = 0;
        ViewState["PageIndex"] = 0;
        lblRecordCount.Text = a.ToString();
        PageCountdouble = Math.Ceiling((double)a / (double)PageSize);
        PageCount = (int)PageCountdouble;
        lblPageCount.Text = PageCount.ToString();
        ViewState["PageCount"] = PageCount;
    }


}
