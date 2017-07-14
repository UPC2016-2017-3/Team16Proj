using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class ClassPage : System.Web.UI.Page
{
    public int ClassNum;
    public string connStr = "Data Source=59.110.235.44;Initial Catalog=hongruan;User ID=hrdev;Password=123hrdev456";
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
                string sqlStr = "select Class.* ,Department.DepartmentName from Class left join Class_Department on Class.ClassID=Class_Department.ClassID left join Department on Class_Department.DepartmentID=Department.DepartmentID ";

                SqlConnection conn = new SqlConnection(connStr);
                SqlDataAdapter sda = new SqlDataAdapter(sqlStr, conn);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                ClassNum = ds.Tables[0].Rows.Count;
                datalist1.DataSource = ds;
                datalist1.DataBind();
                datalist2.DataSource = ds;
                datalist2.DataBind();
            }
        }
    }
     protected void Zonghe_Click(object sender, EventArgs e)
    {
        
            string sqlStr = "select Class.* ,Department.DepartmentName from Class left join Class_Department on Class.ClassID=Class_Department.ClassID left join Department on Class_Department.DepartmentID=Department.DepartmentID";

            SqlConnection conn = new SqlConnection(connStr);
           
            SqlDataAdapter sda = new SqlDataAdapter(sqlStr, conn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            ClassNum = ds.Tables[0].Rows.Count;
            datalist1.DataSource = ds;
            datalist1.DataBind();
            datalist2.DataSource = ds;
            datalist2.DataBind();

    }
    protected void Zuire_Click(object sender, EventArgs e)
    {
        
            string sqlStr = "select Class.* ,Department.DepartmentName from Class left join Class_Department on Class.ClassID=Class_Department.ClassID left join Department on Class_Department.DepartmentID=Department.DepartmentID order by ClassCollectionNum desc";
            SqlConnection conn = new SqlConnection(connStr);
            SqlDataAdapter sda = new SqlDataAdapter(sqlStr, conn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            ClassNum = ds.Tables[0].Rows.Count;
            datalist1.DataSource = ds;
            datalist1.DataBind();
            datalist2.DataSource = ds;
            datalist2.DataBind();

           
    }
    protected void Quanbu_Click(object sender, EventArgs e)
    {
        
            string sqlStr = "select Class.* ,Department.DepartmentName from Class left join Class_Department on Class.ClassID=Class_Department.ClassID left join Department on Class_Department.DepartmentID=Department.DepartmentID";

            SqlConnection conn = new SqlConnection(connStr);
            
            SqlDataAdapter sda = new SqlDataAdapter(sqlStr, conn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            ClassNum = ds.Tables[0].Rows.Count;
            datalist1.DataSource = ds;
            datalist1.DataBind();
            datalist2.DataSource = ds;
            datalist2.DataBind();

    }
    protected void Mianfei_Click(object sender, EventArgs e)
    {
        
            string sqlStr = "select Class.* ,Department.DepartmentName from Class left join Class_Department on Class.ClassID=Class_Department.ClassID left join Department on Class_Department.DepartmentID=Department.DepartmentID where Class.ClassPrice= 0";

            SqlConnection conn = new SqlConnection(connStr);
            
            SqlDataAdapter sda = new SqlDataAdapter(sqlStr, conn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            ClassNum = ds.Tables[0].Rows.Count;
            datalist1.DataSource = ds;
            datalist1.DataBind();
            datalist2.DataSource = ds;
            datalist2.DataBind();

    }
    protected void Fufei_Click(object sender, EventArgs e)
    {
       
            string sqlStr = "select Class.* ,Department.DepartmentName from Class left join Class_Department on Class.ClassID=Class_Department.ClassID left join Department on Class_Department.DepartmentID=Department.DepartmentID where Class.ClassPrice <> 0";

            SqlConnection conn = new SqlConnection(connStr);
            
            SqlDataAdapter sda = new SqlDataAdapter(sqlStr, conn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            ClassNum = ds.Tables[0].Rows.Count;
            datalist1.DataSource = ds;
            datalist1.DataBind();
            datalist2.DataSource = ds;
            datalist2.DataBind();

          
    }


}