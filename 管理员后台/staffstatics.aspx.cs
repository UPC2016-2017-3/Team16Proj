using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Configuration;
using System.Text;
using System.Collections;

public partial class 员工统计 : System.Web.UI.Page
{
    public string data1, data2,data3,data4;
    int PageSize;
    int CurrentPage;
    int RecordCount;
    double PageCountdouble;
    int PageCount;
    public string stuNum;
    public int companyid;
    public int managerid;
    DataSet ds1 = new DataSet();
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




            string strSql2 = "select top 10 Student.StudentID,max(Student.StudentName) as studentname,count(distinct (case LearnClass.IsCompleted when 1 then  LearnClass.ClassID  else null end))as learnnum,count ( distinct (case Collection.Compulsion when 1 then (case Collection.IsCompleted when 1 then Collection.collectionid else null end) else null end))as TskDoneNum from student left join LearnClass on Student.StudentID=LearnClass.StudentID full join Collection on Student.StudentID=Collection.StudentID where student.CompanyID='" + companyid + "'  group by Student.StudentID order by count(distinct (case LearnClass.IsCompleted when 1 then  LearnClass.ClassID  else null end)) desc";
            SqlDataAdapter adp2 = new SqlDataAdapter(strSql2, con);
            DataSet dataset2 = new DataSet();
            adp2.Fill(dataset2);
            StringBuilder studentname = new StringBuilder();
            StringBuilder learnnum = new StringBuilder();

            if (dataset2.Tables[0] != null & dataset2.Tables[0].Rows.Count > 0)
            {
                studentname.Append("'");
                studentname.Append(dataset2.Tables[0].Rows[0]["studentname"]);
                studentname.Append("'");
                learnnum.Append(dataset2.Tables[0].Rows[0]["learnnum"]);
                for (int i = 1; i < dataset2.Tables[0].Rows.Count; i++)
                {
                    studentname.Append(",");
                    studentname.Append("'");
                    studentname.Append(dataset2.Tables[0].Rows[i]["studentname"]);
                    studentname.Append("'");
                    learnnum.Append(",");
                    learnnum.Append(dataset2.Tables[0].Rows[i]["learnnum"]);

                }

                data1 = studentname.ToString();
                data2 = learnnum.ToString();
            }

            string strSql3 = "select top 10  Student.StudentID,max(Student.StudentName) as studentname,count(distinct (case LearnClass.IsCompleted when 1 then  LearnClass.ClassID  else null end))as learnnum,count ( distinct (case Collection.Compulsion when 1 then (case Collection.IsCompleted when 1 then Collection.collectionid else null end) else null end))as TskDoneNum from student left join LearnClass on Student.StudentID=LearnClass.StudentID full join Collection on Student.StudentID=Collection.StudentID where student.CompanyID='" + companyid + "'   group by Student.StudentID order by count ( distinct (case Collection.Compulsion when 1 then (case Collection.IsCompleted when 1 then Collection.collectionid else null end) else null end)) desc";
            SqlDataAdapter adp3 = new SqlDataAdapter(strSql3, con);
            DataSet dataset3 = new DataSet();
            adp3.Fill(dataset3);
            StringBuilder studentname1 = new StringBuilder();
            StringBuilder TskDoneNum = new StringBuilder();

            if (dataset3.Tables[0] != null & dataset3.Tables[0].Rows.Count > 0)
            {
                studentname1.Append("'");
                studentname1.Append(dataset3.Tables[0].Rows[0]["studentname"]);
                studentname1.Append("'");
                TskDoneNum.Append(dataset3.Tables[0].Rows[0]["TskDoneNum"]);
                for (int i = 1; i < dataset3.Tables[0].Rows.Count; i++)
                {
                    studentname1.Append(",");
                    studentname1.Append("'");
                    studentname1.Append(dataset3.Tables[0].Rows[i]["studentname"]);
                    studentname1.Append("'");
                    TskDoneNum.Append(",");
                    TskDoneNum.Append(dataset3.Tables[0].Rows[i]["TskDoneNum"]);

                }

                data3 = studentname1.ToString();
                data4 = TskDoneNum.ToString();
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
       
        string sql1 = "select Student.StudentID,max(Student.StudentName) as studentname,count(distinct LearnClass.ClassID)as classnum,count(distinct (case LearnClass.IsCompleted when 1 then  LearnClass.ClassID  else null end))as learnnum, (case (count(distinct LearnClass.ClassID)) when 0 then 0 else (convert(decimal(10,2),(count(distinct (case LearnClass.IsCompleted when 1 then  LearnClass.ClassID  else null end))/(count(distinct LearnClass.ClassID)+0.0)*100)))end)as LCratio, count ( distinct (case Collection.Compulsion when 1 then Collection.collectionid else null end))as tasknum , count ( distinct (case Collection.Compulsion when 1 then (case Collection.IsCompleted when 1 then Collection.collectionid else null end) else null end))as TskDoneNum,(case count ( distinct (case Collection.Compulsion when 1 then Collection.collectionid else null end)) when 0 then 0 else (convert (decimal(10,2),count ( distinct (case Collection.Compulsion when 1 then (case Collection.IsCompleted when 1 then Collection.collectionid else null end) else null end))/(count ( distinct (case Collection.Compulsion when 1 then Collection.collectionid else null end))+0.0)*100)) end ) as taskratio from student left join LearnClass on Student.StudentID=LearnClass.StudentID full join Collection on Student.StudentID=Collection.StudentID where student.CompanyID='"+companyid+"'   group by Student.StudentID";

        SqlDataAdapter da1 = new SqlDataAdapter(sql1, connStr);
        DataSet ds1 = new DataSet();
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
        string strSql = "select max(Student.StudentName) as '员工',count(distinct LearnClass.ClassID)as '学习课程',count(distinct (case LearnClass.IsCompleted when 1 then  LearnClass.ClassID  else null end))as '完成课程', (case (count(distinct LearnClass.ClassID)) when 0 then 0 else (convert(decimal(10,2),(count(distinct (case LearnClass.IsCompleted when 1 then  LearnClass.ClassID  else null end))/(count(distinct LearnClass.ClassID)+0.0)*100)))end)as '学习完成率', count ( distinct (case Collection.Compulsion when 1 then Collection.collectionid else null end))as '专题任务数' , count ( distinct (case Collection.Compulsion when 1 then (case Collection.IsCompleted when 1 then Collection.collectionid else null end) else null end))as '任务完成数',(case count ( distinct (case Collection.Compulsion when 1 then Collection.collectionid else null end)) when 0 then 0 else (convert (decimal(10,2),count ( distinct (case Collection.Compulsion when 1 then (case Collection.IsCompleted when 1 then Collection.collectionid else null end) else null end))/(count ( distinct (case Collection.Compulsion when 1 then Collection.collectionid else null end))+0.0)*100)) end ) as '任务完成率' from student left join LearnClass on Student.StudentID=LearnClass.StudentID full join Collection on Student.StudentID=Collection.StudentID where student.CompanyID='"+companyid+"'group by Student.StudentID";
        con.Open();//打开数据库连接 (当然此句可以不写的)
        SqlDataAdapter sda = new SqlDataAdapter(strSql, con);
        DataSet ds = new DataSet();
        sda.Fill(ds);//把执行得到的数据放在数据集中
        con.Close();
        CreateExcel c = new CreateExcel();
        c.Createxls(ds, "员工统计信息.xls", Page);
    }
    protected void search_Click(object sender, EventArgs e)
    {
        string searchcontent = text.Value.ToString().Trim();
        string sql1 = "select Student.StudentID,max(Student.StudentName) as studentname,count(distinct LearnClass.ClassID)as classnum,count(distinct (case LearnClass.IsCompleted when 1 then  LearnClass.ClassID  else null end))as learnnum, (case (count(distinct LearnClass.ClassID)) when 0 then 0 else (convert(decimal(10,2),(count(distinct (case LearnClass.IsCompleted when 1 then  LearnClass.ClassID  else null end))/(count(distinct LearnClass.ClassID)+0.0)*100)))end)as LCratio, count ( distinct (case Collection.Compulsion when 1 then Collection.collectionid else null end))as tasknum , count ( distinct (case Collection.Compulsion when 1 then (case Collection.IsCompleted when 1 then Collection.collectionid else null end) else null end))as TskDoneNum,(case count ( distinct (case Collection.Compulsion when 1 then Collection.collectionid else null end)) when 0 then 0 else (convert (decimal(10,2),count ( distinct (case Collection.Compulsion when 1 then (case Collection.IsCompleted when 1 then Collection.collectionid else null end) else null end))/(count ( distinct (case Collection.Compulsion when 1 then Collection.collectionid else null end))+0.0)*100)) end ) as taskratio from student left join LearnClass on Student.StudentID=LearnClass.StudentID full join Collection on Student.StudentID=Collection.StudentID where student.CompanyID='"+companyid+"'   group by Student.StudentID";
        SqlDataAdapter da1 = new SqlDataAdapter(sql1, connStr);
        da1.Fill(ds1);

        DataTable dt = ds1.Tables[0];
        string expression = "studentname like '%" + searchcontent + "%'";
        dt.DefaultView.RowFilter = expression;
        int a = int.Parse(dt.Select(expression).Count().ToString());
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
