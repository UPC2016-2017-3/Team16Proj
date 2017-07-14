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

public partial class 注册 : System.Web.UI.Page
{
    string connStr = "Data Source=59.110.235.44;Initial Catalog=hongruan;User ID=hrdev;Password=123hrdev456";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
    }
    protected void button1_Click(object sender, EventArgs e)
    {
        string realname = username.Value.Trim();
        string telephone = Tel.Value.Trim();
        string name = Name.Value.Trim();
        string password = psd2.Value;
        string email = emailin.Value;
        string category = Category.InnerText.ToString();
        string sex = text1.InnerText.ToString();
        int DepartmentID;
        if (checkboxagree.Checked)
        {
            if (realname != String.Empty && telephone != String.Empty && password != String.Empty)
            {

                try
                {
                    //由姓名和电话号码唯一确定一个人
                    string sqlTel = "select * from Student where Telephone = '" + telephone + "'";
                    SqlConnection conTel = new SqlConnection(connStr);
                    conTel.Open();
                    SqlDataAdapter sdrTel = new SqlDataAdapter(sqlTel, conTel);
                    DataSet dsTel = new DataSet();
                    sdrTel.Fill(dsTel, "Student");
                    if (dsTel.Tables[0].Rows.Count == 1)
                    {
                        Response.Write("<script>alert('该手机号已被注册，请您更换手机号！');</script>");
                    }
                    else
                    {                   
                    //先从数据库查出对应的DepartmentID
                    string sqlStr = "select DepartmentID from Department where DepartmentName ='" + category + "'";
                    SqlConnection con = new SqlConnection(connStr);
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = sqlStr;
                    SqlDataReader reader1 = cmd.ExecuteReader();
                    reader1.Read();
                    DepartmentID = reader1.GetInt32(reader1.GetOrdinal("DepartmentID"));
                    Console.Read();
                    con.Close();

                    SqlConnection conn = new SqlConnection(connStr);
                    string sql = "insert into Student(StudentName,StudentSex,Telephone,StudentAccount,StudentPassword,StudentEmail,PasserBy,CompanyID,DepartmentID) values ('" + realname + "','" + sex + "','" + telephone + "','" + name + "','" + password + "','" + email + "','" + 1 + "','" + 4 + "','" + DepartmentID + "')";
                    conn.Open();
                    SqlCommand cmd1 = conn.CreateCommand();
                    cmd1.CommandText = sql;
                    cmd1.ExecuteNonQuery();
                    conn.Close();

                    Response.Write("<script>window.location='登录.aspx';alert('注册成功！');</script>");
                    }
                }
                catch
                {
                    Response.Write("<script>alert('注册失败，请您稍后再试！');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('请填写必填项！');</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('您还未同意《虹软云课堂用户使用协议》！');</script>");
        }
    }
}
