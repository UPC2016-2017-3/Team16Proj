using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Collections;
using System.Data.OleDb;
public partial class zonghe : System.Web.UI.Page
{
    public string data1,data2,data3,data4,data5;
    public string stuNum;
    string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["hongruanConnectionString"].ConnectionString;
    public String studentname, departmentname, questiontitle, questioncontent, answercontent, answertime, managername;
    int PageSize;
    int CurrentPage;
    int RecordCount;
    double PageCountdouble;
    int PageCount;
    public int managerid;
    public int companyid;
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
            PageSize = 10;
            SqlConnection con = new SqlConnection(connStr);
            con.Open();
            companyid = int.Parse(Session["CompanyID"].ToString());
            //Session["CompanyID"] = companyid;
            managerid = int.Parse(Session["ManagerID"].ToString());
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


            string sql3 = "select top 10 month(LearnClass.LearnDate) as months ,count(distinct LearnClass.LearnID) as learnnum from LearnClass join class on LearnClass.ClassID=class.ClassID  where class.CompanyID='" + companyid + "' and year(LearnClass.LearnDate)=year(GETDATE()) group by month(LearnClass.LearnDate) order by months";
            SqlDataAdapter adp3 = new SqlDataAdapter(sql3, con);
            DataSet ds3 = new DataSet();
            adp3.Fill(ds3);
            StringBuilder month = new StringBuilder();
            StringBuilder learnnum = new StringBuilder();
            if (ds3.Tables[0] != null & ds3.Tables[0].Rows.Count > 0)
            {
                month.Append("'");
                month.Append(ds3.Tables[0].Rows[0]["months"]);
                month.Append("'");
                learnnum.Append(ds3.Tables[0].Rows[0]["learnnum"]);
                for (int i = 1; i < ds3.Tables[0].Rows.Count; i++)
                {
                    month.Append(",");
                    month.Append("'");
                    month.Append(ds3.Tables[0].Rows[i]["months"].ToString().Trim());
                    month.Append("'");
                    learnnum.Append(",");
                    learnnum.Append(ds3.Tables[0].Rows[i]["learnnum"].ToString().Trim());
                }
                data1 = month.ToString();
                data2 = learnnum.ToString();
            }


            string sql4 = "select top 10 count(distinct clogrecord.recordid) as lognum  from clogrecord full join Student on student.StudentID=clogrecord.StudentID where student.CompanyID='" + companyid + "' and ClogRecord.ClogDate is not null group by ClogRecord.CLogDate";
            SqlDataAdapter adp4 = new SqlDataAdapter(sql4, con);
            DataSet ds4 = new DataSet();

            adp4.Fill(ds4);
            StringBuilder ClogNum = new StringBuilder();
            int a = ds4.Tables[0].Rows.Count;
            if (ds4.Tables[0] != null & ds4.Tables[0].Rows.Count > 0)
            {
                int i;
                ClogNum.Append(ds4.Tables[0].Rows[0]["lognum"]);
                for (i = 1; i < a; i++)
                {
                    ClogNum.Append(",");
                    ClogNum.Append(ds4.Tables[0].Rows[i]["lognum"]);
                }
                if (a < 10)
                {
                    for (; i < 10; i++)
                    {
                        ClogNum.Append(",");
                        ClogNum.Append("0");
                    }
                }
                data3 = ClogNum.ToString();
                data4 = "'1','2','3','4','5','6','7','8','9','10'";
            }


            con.Close();
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
        string sql2 = "select count(studentid)as StuNum from student where CompanyID='"+companyid+"'";
        SqlDataAdapter da2 = new SqlDataAdapter(sql2, connStr);
        DataSet ds2 = new DataSet();
        da2.Fill(ds2);
        stuNum = ds2.Tables[0].Rows[0]["StuNum"].ToString();
        double num1 = double.Parse(stuNum) + 0.0;
        string num = num1.ToString();
        string sql1 = "select  CONVERT(date,clogrecord.clogdate, 102) as clogdate ,count(distinct CLogRecord.StudentID) as LogNum ,Convert(decimal(10,2),(count(distinct CLogRecord.StudentID))/5.0*100) as Logratio, COUNT(distinct LearnClass.LearnID) as LearnNum,count(distinct Collection.collectionID) as collectionNum ,count(distinct DiscussUnit.DisscusID) as DisNum from ClogRecord FULL join  Student on CLogRecord.STUDENTID=Student.StudentID full join LearnClass on CLogRecord.CLogDate=LearnClass.LearnDate full join Collection on Collection.collectiondate= CLogRecord.CLogDate full join DiscussUnit on CLogRecord.CLogDate=DiscussUnit.DiscussTime where CLogRecord.CLogDate is not null and student.CompanyID='"+companyid+"' group by CLogRecord.CLogDate";

        SqlDataAdapter da1 = new SqlDataAdapter(sql1, connStr);
        DataSet ds1 = new DataSet();
        da1.Fill(ds1);

        RecordCount = ds1.Tables[0].Rows.Count;
        da1.Fill(ds1, StartIndex, PageSize, "a");
        return ds1.Tables["a"].DefaultView;
        
       
    }
    public void  ListBind()
    {
        zonghelist.DataSource = CreateSource();
        zonghelist.DataBind();
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
        string strSql = "select  CONVERT(date,clogrecord.clogdate, 102) as '日期' ,count(distinct CLogRecord.StudentID) as '活跃用户数' ,Convert(decimal(10,2),(count(distinct CLogRecord.StudentID))/5.0*100) as '活跃率', COUNT(distinct LearnClass.LearnID) as '学习课程',count(distinct Collection.collectionID) as '课程收藏' ,count(distinct DiscussUnit.DisscusID) as '评论数' from ClogRecord FULL join  Student on CLogRecord.STUDENTID=Student.StudentID full join LearnClass on CLogRecord.CLogDate=LearnClass.LearnDate full join Collection on Collection.collectiondate= CLogRecord.CLogDate full join DiscussUnit on CLogRecord.CLogDate=DiscussUnit.DiscussTime where CLogRecord.CLogDate is not null and student.CompanyID='"+companyid+"' group by CLogRecord.CLogDate"; 
        con.Open();//打开数据库连接 (当然此句可以不写的)
        SqlDataAdapter sda = new SqlDataAdapter(strSql, con);
        DataSet ds = new DataSet();
        sda.Fill(ds);//把执行得到的数据放在数据集中
        con.Close();
        CreateExcel c = new CreateExcel();
        c.Createxls(ds, "综合统计信息.xls", Page);
    }
    protected void search_Click(object sender, EventArgs e)
    {
        string b = text.Value.ToString().Trim();
        DateTime c;
        if (DateTime.TryParse(b, out c))
        {
            DateTime searchcontent = DateTime.Parse(b);
            string sql2 = "select count(studentid)as StuNum from student where CompanyID='"+companyid+"'";
            SqlDataAdapter da2 = new SqlDataAdapter(sql2, connStr);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            stuNum = ds2.Tables[0].Rows[0]["StuNum"].ToString();
            double num1 = double.Parse(stuNum) + 0.0;
            string num = num1.ToString();
            string sql1 = "select  clogrecord.clogdate as clogdate ,count(distinct CLogRecord.StudentID) as LogNum ,Convert(decimal(10,2),(count(distinct CLogRecord.StudentID))/5.0*100) as Logratio, COUNT(distinct LearnClass.LearnID) as LearnNum,count(distinct Collection.collectionID) as collectionNum ,count(distinct DiscussUnit.DisscusID) as DisNum from ClogRecord FULL join  Student on CLogRecord.STUDENTID=Student.StudentID full join LearnClass on CLogRecord.CLogDate=LearnClass.LearnDate full join Collection on Collection.collectiondate= CLogRecord.CLogDate full join DiscussUnit on CLogRecord.CLogDate=DiscussUnit.DiscussTime where CLogRecord.CLogDate is not null and student.CompanyID='"+companyid+"' group by CLogRecord.CLogDate";

            SqlDataAdapter da1 = new SqlDataAdapter(sql1, connStr);
            da1.Fill(ds1);
            DataTable dt = ds1.Tables[0];
            string expression = "clogdate ='" + searchcontent + "'";
            dt.DefaultView.RowFilter = expression;
            int a = int.Parse(dt.Select(expression).Count().ToString());
            zonghelist.DataSource = dt;
            zonghelist.DataBind();
            CurrentPage = 0;
            ViewState["PageIndex"] = 0;
            lblRecordCount.Text = a.ToString();
            PageCountdouble = Math.Ceiling((double)a / (double)PageSize);
            PageCount = (int)PageCountdouble;
            lblPageCount.Text = PageCount.ToString();
            ViewState["PageCount"] = PageCount;
        }
        else {
            Response.Write("<script language=javascript>alert('日期格式有误');</" + "script>"); 
        }
    }
}