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

public partial class index : System.Web.UI.Page
    
{
    public int intCount;
    public string laccount;
    public string lpassword;
    public int COMPANYID;
    public int MANAGERID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Write("alert('您还未登陆！');</script>");
            Response.Redirect("Login.aspx", true);
        }
        else
        {
            laccount = Session["Laccount"].ToString();
            lpassword = Session["Lpassword"].ToString();

            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["hongruanConnectionString"].ConnectionString;
            SqlConnection MyConn = new SqlConnection(connStr);
            MyConn.Open();

            //string sqlStr1 = "select CompanyID from Manager where (ManagerName = '" + laccount + "' and ManagerPassword = '" + lpassword + "')";
            string sqlStr1 = "select * from Manager where (ManagerName = '" + laccount + "' and ManagerPassword = '" + lpassword + "')";
            SqlDataAdapter adp1 = new SqlDataAdapter(sqlStr1, MyConn);
            DataSet ds1 = new DataSet();
            adp1.Fill(ds1);
            COMPANYID = int.Parse(ds1.Tables[0].Rows[0]["CompanyID"].ToString());
            MANAGERID = int.Parse(ds1.Tables[0].Rows[0]["ManagerID"].ToString());

            //SqlCommand cmd = MyConn.CreateCommand();
            //cmd.CommandText = sqlStr1;
            //SqlDataReader reader1 = cmd.ExecuteReader();
            //reader1.Read();
            //COMPANYID = reader1.GetInt32(reader1.GetOrdinal("CompanyID"));
            //Console.Read();
            //MyConn.Close();
            Session["CompanyID"] = COMPANYID;
            Session["ManagerID"] = MANAGERID;


            string strCount = "select count(*) as co from QandA left join Student on QandA.studentID=Student.StudentID left join Department on Student.DepartmentID=Department.DepartmentID where AnswerContent is NULL";
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
            MyConn.Close();
        }
    }
     
    public void CheckQuestion(Object sender, CommandEventArgs e)
    {
        
      
    }

}