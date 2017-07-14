using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Home : System.Web.UI.Page
{
    string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["hongruanConnectionString"].ConnectionString;
    public string category1, classinfo1, classinfo2, classinfo3, classinfo4, classname1, departmentname1, classprice1, category2, classname2, departmentname2, classprice2, category3, classname3, departmentname3, classprice3, category4, classname4, departmentname4, classprice4;
    public string category5, classinfo5, classinfo6, classinfo7, classinfo8, classname5, departmentname5, classprice5, category6, classname6, departmentname6, classprice6, category7, classname7, departmentname7, classprice7, category8, classname8, departmentname8, classprice8;
    public string classid1, classid2, classid3, classid4, classid5, classid6, classid7, classid8;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Write("alert('您还未登陆！');</script>");
            Response.Redirect("Login.aspx", true);
        }
        else
        {
            SqlConnection con = new SqlConnection(connStr);
            con.Open();
            string sqlRec = "select * from Recommend where StudentID=1";
            SqlDataAdapter sda1 = new SqlDataAdapter(sqlRec, con);
            DataSet ds2 = new DataSet();
            sda1.Fill(ds2);
            string sqlInfo = "select Category.CategoryName,Category.CategoryID,Class.ClassName,Class.ClassID,Class.ClassInfo,Class.ClassPrice,Class_Category.ClassID,Class_Category.CategoryID,Department.DepartmentName from Category inner join Class_Category on Category.CategoryID=Class_Category.CategoryID inner join Class on Class.ClassID=Class_Category.ClassID inner join Class_Department on Class.ClassID=Class_Department.ClassID inner join Department on Department.DepartmentID=Class_Department.DepartmentID where(Class.ClassID=" + ds2.Tables[0].Rows[0][1] + " or Class.ClassID=" + ds2.Tables[0].Rows[0][2] + " or Class.ClassID=" + ds2.Tables[0].Rows[0][3] + " or Class.ClassID=" + ds2.Tables[0].Rows[0][4] + ")";
            SqlDataAdapter adp = new SqlDataAdapter(sqlInfo, con);
            DataSet ds = new DataSet();
            adp.Fill(ds);

            category1 = ds.Tables[0].Rows[0]["CategoryName"].ToString();
            classid1 = ds.Tables[0].Rows[0]["ClassID"].ToString();
            classname1 = ds.Tables[0].Rows[0]["ClassName"].ToString();
            departmentname1 = ds.Tables[0].Rows[0]["DepartmentName"].ToString();
            classprice1 = ds.Tables[0].Rows[0]["ClassPrice"].ToString();
            classinfo1 = ds.Tables[0].Rows[0]["ClassInfo"].ToString();

            category2 = ds.Tables[0].Rows[1]["CategoryName"].ToString();
            classid2 = ds.Tables[0].Rows[1]["ClassID"].ToString();
            classname2 = ds.Tables[0].Rows[1]["ClassName"].ToString();
            departmentname2 = ds.Tables[0].Rows[1]["DepartmentName"].ToString();
            classprice2 = ds.Tables[0].Rows[1]["ClassPrice"].ToString();
            classinfo2 = ds.Tables[0].Rows[1]["ClassInfo"].ToString();

            category3 = ds.Tables[0].Rows[2]["CategoryName"].ToString();
            classid3 = ds.Tables[0].Rows[2]["ClassID"].ToString();
            classname3 = ds.Tables[0].Rows[2]["ClassName"].ToString();
            departmentname3 = ds.Tables[0].Rows[2]["DepartmentName"].ToString();
            classprice3 = ds.Tables[0].Rows[2]["ClassPrice"].ToString();
            classinfo3 = ds.Tables[0].Rows[2]["ClassInfo"].ToString();

            category4 = ds.Tables[0].Rows[3]["CategoryName"].ToString();
            classid4 = ds.Tables[0].Rows[3]["ClassID"].ToString();
            classname4 = ds.Tables[0].Rows[3]["ClassName"].ToString();
            departmentname4 = ds.Tables[0].Rows[3]["DepartmentName"].ToString();
            classprice4 = ds.Tables[0].Rows[3]["ClassPrice"].ToString();
            classinfo4 = ds.Tables[0].Rows[3]["ClassInfo"].ToString();


            con.Close();








            SqlConnection con1 = new SqlConnection(connStr);
            con1.Open();
            string sql1 = "select Category.CategoryName,Category.CategoryID,Class.ClassName,Class.ClassID,Class.ClassInfo,Class.ClassPrice,Class_Category.ClassID,Class_Category.CategoryID,Department.DepartmentName from Category inner join Class_Category on Category.CategoryID=Class_Category.CategoryID inner join Class on Class.ClassID=Class_Category.ClassID inner join Class_Department on Class.ClassID=Class_Department.ClassID inner join Department on Department.DepartmentID=Class_Department.DepartmentID where Class.ClassPrice=0";
            SqlDataAdapter adp1 = new SqlDataAdapter(sql1, con1);
            DataSet ds1 = new DataSet();
            adp1.Fill(ds1);

            category5 = ds1.Tables[0].Rows[0]["CategoryName"].ToString();
            classid5 = ds1.Tables[0].Rows[0]["ClassID"].ToString();
            classname5 = ds1.Tables[0].Rows[0]["ClassName"].ToString();
            departmentname5 = ds1.Tables[0].Rows[0]["DepartmentName"].ToString();
            classprice5 = ds1.Tables[0].Rows[0]["ClassPrice"].ToString();
            classinfo5 = ds1.Tables[0].Rows[0]["ClassInfo"].ToString();

            category6 = ds1.Tables[0].Rows[1]["CategoryName"].ToString();
            classid6 = ds1.Tables[0].Rows[1]["ClassID"].ToString();
            classname6 = ds1.Tables[0].Rows[1]["ClassName"].ToString();
            departmentname6 = ds1.Tables[0].Rows[1]["DepartmentName"].ToString();
            classprice6 = ds1.Tables[0].Rows[1]["ClassPrice"].ToString();
            classinfo6 = ds1.Tables[0].Rows[1]["ClassInfo"].ToString();

            category7 = ds1.Tables[0].Rows[2]["CategoryName"].ToString();
            classid7 = ds1.Tables[0].Rows[2]["ClassID"].ToString();
            classname7 = ds1.Tables[0].Rows[2]["ClassName"].ToString();
            departmentname7 = ds1.Tables[0].Rows[2]["DepartmentName"].ToString();
            classprice7 = ds1.Tables[0].Rows[2]["ClassPrice"].ToString();
            classinfo7 = ds1.Tables[0].Rows[2]["ClassInfo"].ToString();

            category8 = ds1.Tables[0].Rows[3]["CategoryName"].ToString();
            classid8 = ds1.Tables[0].Rows[3]["ClassID"].ToString();
            classname8 = ds1.Tables[0].Rows[3]["ClassName"].ToString();
            departmentname8 = ds1.Tables[0].Rows[3]["DepartmentName"].ToString();
            classprice8 = ds1.Tables[0].Rows[3]["ClassPrice"].ToString();
            classinfo8 = ds1.Tables[0].Rows[3]["ClassInfo"].ToString();


            con1.Close();
        }
    }
}


