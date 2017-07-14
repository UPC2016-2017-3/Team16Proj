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

public partial class 课程统计 : System.Web.UI.Page
{

    string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["hongruanConnectionString"].ConnectionString;
    public string data1, data2, data3, data4, data5;
    public string classNum;
    int PageSize;
    int CurrentPage;
    int RecordCount;
    double PageCountdouble;
    int PageCount;
    public int companyid;
    public int managerid;
    DataSet ds1 = new DataSet();
    protected string FormatFoo(object arg)
    {
        if (arg == null) return " ";
        string str = arg.ToString();
        return str.Length > 10 ? str.Substring(0, 10) + "..." : str;
    }

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



            //int companyID = 3;



            string strSql2 = "select class.classid,class.ClassName, class.ClassClickNum as clicknum  from class where class.CompanyID='" + companyid + "' order by Class.ClassClickNum desc";
            SqlDataAdapter adp2 = new SqlDataAdapter(strSql2, con);
            DataSet dataset2 = new DataSet();
            adp2.Fill(dataset2);

            StringBuilder classname = new StringBuilder();
            StringBuilder clicknum = new StringBuilder();

            if (dataset2.Tables[0] != null & dataset2.Tables[0].Rows.Count > 0)
            {
                string str1 = dataset2.Tables[0].Rows[0]["ClassName"].ToString();
                if (str1.Length < 5)
                {
                    classname.Append("'");
                    classname.Append(str1);
                    classname.Append("'");
                    clicknum.Append(dataset2.Tables[0].Rows[0]["clicknum"]);
                }
                if (str1.Length >= 5)
                {
                    string str2 = str1.Substring(0, 5);
                    classname.Append("'");
                    classname.Append(str2 + "...");
                    classname.Append("'");
                    clicknum.Append(dataset2.Tables[0].Rows[0]["clicknum"]);
                }

                for (int i = 1; i < 10; i++)
                {
                    string str3 = dataset2.Tables[0].Rows[i]["ClassName"].ToString();
                    if (str3.Length < 5)
                    {
                        classname.Append(",");
                        classname.Append("'");
                        classname.Append(str3);
                        classname.Append("'");
                        clicknum.Append(",");
                        clicknum.Append(dataset2.Tables[0].Rows[i]["clicknum"]);
                    }
                    if (str3.Length >= 5)
                    {
                        string str4 = str3.Substring(0, 5);
                        classname.Append(",");
                        classname.Append("'");
                        classname.Append(str4 + "...");
                        classname.Append("'");
                        clicknum.Append(",");
                        clicknum.Append(dataset2.Tables[0].Rows[i]["clicknum"]);
                    }

                }
                data1 = classname.ToString();
                data2 = clicknum.ToString();
            }

            string strSql3 = "select Category.CategoryID, Category.CategoryName,Class.ClassCollectionNum,COUNT(distinct LearnClass.LearnID) as LearnNum  from class full join Class_Category on class.ClassID=Class_Category.ClassID full join Category on Category.CategoryID=Class_Category.CategoryID full join LearnClass on LearnClass.ClassID=Class.ClassID where Class.CompanyID='" + companyid + "' group by Category.CategoryID,Category.CategoryName,Class.ClassCollectionNum";
            SqlDataAdapter adp3 = new SqlDataAdapter(strSql3, con);
            DataSet dataset3 = new DataSet();
            adp3.Fill(dataset3);
            StringBuilder CategoryName = new StringBuilder();
            StringBuilder CategoryCollection = new StringBuilder();
            StringBuilder CategoryLearnNum = new StringBuilder();
            if (dataset3.Tables[0] != null & dataset3.Tables[0].Rows.Count > 0)
            {
                CategoryName.Append("'");
                CategoryName.Append(dataset3.Tables[0].Rows[0]["CategoryName"].ToString().Trim());
                CategoryName.Append("'");
                CategoryCollection.Append(dataset3.Tables[0].Rows[0]["ClassCollectionNum"]);
                CategoryLearnNum.Append(dataset3.Tables[0].Rows[0]["LearnNum"]);

                for (int i = 1; i < 10; i++)
                {
                    CategoryName.Append(",");
                    CategoryName.Append("'");
                    CategoryName.Append(dataset3.Tables[0].Rows[i]["CategoryName"].ToString().Trim());
                    CategoryName.Append("'");
                    CategoryCollection.Append(",");
                    CategoryCollection.Append(dataset3.Tables[0].Rows[i]["ClassCollectionNum"]);
                    CategoryLearnNum.Append(",");
                    CategoryLearnNum.Append(dataset3.Tables[0].Rows[i]["LearnNum"]);
                }
                data3 = CategoryName.ToString();
                data4 = CategoryCollection.ToString();
                data5 = CategoryLearnNum.ToString();

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
        //int companyID = 3;
        //设定导入的起终地址
        StartIndex = CurrentPage * PageSize;
        
        string sql1 = "select class.ClassID,class.ClassName,Category.CategoryName,count(learnclass.LearnID)as learnNum,Class.ClassClickNum,Class.ClassCollectionNum,Class.ClassDiscussNum ,count(distinct Unit.UnitID) as UnitNum,count (QandA.QandAID) as Qnum from class full join LearnClass on class.ClassID=LearnClass.ClassID join Class_Category on Class.classid=Class_Category.ClassID join Category on Category.CategoryID=Class_Category.CategoryID full join Unit on Unit.ClassID=Class.ClassID full join QandA on QandA.UnitID=Unit.UnitID where Class.CompanyID=" + companyid + " group by class.classid,class.classname,Category.CategoryName,Class.ClassClickNum,Class.ClassCollectionNum,Class.ClassDiscussNum";

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
        //int companyID = 3;
        SqlConnection con = new SqlConnection(connStr);
        string strSql = "select class.ClassName as '课程名',Category.CategoryName as '所属类别',count(learnclass.LearnID)as '学习课程人数',Class.ClassClickNum as '总点击量',Class.ClassCollectionNum as '收藏人数',Class.ClassDiscussNum as '评论数' ,count(distinct Unit.UnitID) as '章节数',count (QandA.QandAID) as '提问数' from class full join LearnClass on class.ClassID=LearnClass.ClassID join Class_Category on Class.classid=Class_Category.ClassID join Category on Category.CategoryID=Class_Category.CategoryID full join Unit on Unit.ClassID=Class.ClassID full join QandA on QandA.UnitID=Unit.UnitID where Class.CompanyID=" + companyid + " group by class.classid,class.classname,Category.CategoryName,Class.ClassClickNum,Class.ClassCollectionNum,Class.ClassDiscussNum";
        con.Open();
        SqlDataAdapter sda = new SqlDataAdapter(strSql, con);
        DataSet ds = new DataSet();
        sda.Fill(ds);
        con.Close();
        CreateExcel c = new CreateExcel();
        c.Createxls(ds, "课程统计信息.xls", Page);
    }
    protected void search_Click(object sender, EventArgs e)
    {
        string searchcontent = text.Value.ToString().Trim();
        string sql1 = "select class.ClassID,class.ClassName,Category.CategoryName,count(learnclass.LearnID)as learnNum,Class.ClassClickNum,Class.ClassCollectionNum,Class.ClassDiscussNum ,count(distinct Unit.UnitID) as UnitNum,count (QandA.QandAID) as Qnum from class full join LearnClass on class.ClassID=LearnClass.ClassID join Class_Category on Class.classid=Class_Category.ClassID join Category on Category.CategoryID=Class_Category.CategoryID full join Unit on Unit.ClassID=Class.ClassID full join QandA on QandA.UnitID=Unit.UnitID where Class.CompanyID='"+companyid+"' group by class.classid,class.classname,Category.CategoryName,Class.ClassClickNum,Class.ClassCollectionNum,Class.ClassDiscussNum";
        SqlDataAdapter da1 = new SqlDataAdapter(sql1, connStr);
        da1.Fill(ds1);

        DataTable dt = ds1.Tables[0];
        string expression = "ClassName like '%" + searchcontent + "%'";
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
