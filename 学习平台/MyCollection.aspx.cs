using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class MyCollection : System.Web.UI.Page
{
    public string classid,studentid;
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
                studentid = "2";
                string connStr = "Data Source=59.110.235.44;Initial Catalog=hongruan;User ID=hrdev;Password=123hrdev456";
                SqlConnection con = new SqlConnection(connStr);
                string sqlL = "select  LearnClass.classid ,max(LearnClass.LearnDate) ,LearnClass.LearnTimeLength ,year(max(LearnClass.LearnDate)) as LearnDateY,month(max(LearnClass.LearnDate)) as LearnDateM,day(max(LearnClass.LearnDate)) as LearnDateD,Class.ClassName from LearnClass join class on Class.ClassID=LearnClass.ClassID where studentid= " + studentid + " group by LearnClass.classid ,LearnClass.LearnTimeLength ,Class.ClassName";
                //select distinct LearnClass.classid ,LearnClass.LearnDate ,LearnClass.LearnTimeLength ,Class.ClassName from LearnClass join class on Class.ClassID=LearnClass.ClassID where studentid=1 order by LearnClass.LearnDate,LearnClass.classid desc
                SqlDataAdapter adpL = new SqlDataAdapter(sqlL, con);
                DataSet dsL = new DataSet();
                adpL.Fill(dsL);
                datalistL.DataSource = dsL;
                datalistL.DataBind();

                //select class.classname  ,Collection.CollectionDate from Collection join class on class.classid = Collection.ClassID where studentid =1

                string sqlC = "select Collection.*,year(Collection.CollectionDate) as CollectionDateY,month(Collection.CollectionDate) as CollectionDateM,day(Collection.CollectionDate) as CollectionDateD,Class.ClassName from Collection full join Class on Class.ClassID=Collection.ClassID where StudentID=" + studentid + "  order by CollectionDate desc";
                SqlDataAdapter adpC = new SqlDataAdapter(sqlC, con);
                DataSet dsC = new DataSet();
                adpC.Fill(dsC);
                datalistC.DataSource = dsC;
                datalistC.DataBind();
            }
        }
    }

   protected void deleteCollection(object sender, CommandEventArgs e)
    {
        string connStr = "Data Source=59.110.235.44;Initial Catalog=hongruan;User ID=hrdev;Password=123hrdev456";
        int collectionID = Convert.ToInt32(e.CommandArgument);
        string sqlStr = "DELETE FROM Collection WHERE CollectionID = '"+collectionID+"'";
        SqlConnection conn = new SqlConnection(connStr);
        conn.Open();
        SqlCommand cmd = conn.CreateCommand();
        cmd.CommandText = sqlStr;
        cmd.ExecuteNonQuery();
        conn.Close();

        SqlConnection con = new SqlConnection(connStr);
        string sqlC = "select Collection.*,year(Collection.CollectionDate) as CollectionDateY,month(Collection.CollectionDate) as CollectionDateM,day(Collection.CollectionDate) as CollectionDateD,Class.ClassName from Collection full join Class on Class.ClassID=Collection.ClassID where StudentID=" + studentid + "  order by CollectionDate desc";
        SqlDataAdapter adpC = new SqlDataAdapter(sqlC, con);
        DataSet dsC = new DataSet();
        adpC.Fill(dsC);
        datalistC.DataSource = dsC;
        datalistC.DataBind();
    }

    protected void continueLearning (object sender, CommandEventArgs e)
    {
        int classID = Convert.ToInt32(e.CommandArgument);
        string ID = classID.ToString();
        Session["ClassID"] = ID;
        Response.Redirect("VideoPage.aspx?video="+ID);
    }
    protected void deleteLearn(object sender, CommandEventArgs e)
    {
            string connStr = "Data Source=59.110.235.44;Initial Catalog=hongruan;User ID=hrdev;Password=123hrdev456";
            int classID = Convert.ToInt32(e.CommandArgument);
            string sql = "delete from LearnClass where ClassId='" + classID + " '";
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            conn.Close();
            studentid = "2";

           
            SqlConnection con = new SqlConnection(connStr);
            string sqlL = "select  LearnClass.classid ,max(LearnClass.LearnDate) ,LearnClass.LearnTimeLength ,year(max(LearnClass.LearnDate)) as LearnDateY,month(max(LearnClass.LearnDate)) as LearnDateM,day(max(LearnClass.LearnDate)) as LearnDateD,Class.ClassName from LearnClass join class on Class.ClassID=LearnClass.ClassID where studentid= " + studentid + " group by LearnClass.classid ,LearnClass.LearnTimeLength ,Class.ClassName";
            //select distinct LearnClass.classid ,LearnClass.LearnDate ,LearnClass.LearnTimeLength ,Class.ClassName from LearnClass join class on Class.ClassID=LearnClass.ClassID where studentid=1 order by LearnClass.LearnDate,LearnClass.classid desc
            SqlDataAdapter adpL = new SqlDataAdapter(sqlL, con);
            DataSet dsL = new DataSet();
            adpL.Fill(dsL);
            datalistL.DataSource = dsL;
            datalistL.DataBind();

        }
    
    
}