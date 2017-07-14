using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Net.Mail;

public partial class ForgotPassword : System.Web.UI.Page
{
    string connStr = "Data Source=59.110.235.44;Initial Catalog=hongruan;User ID=hrdev;Password=123hrdev456";
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void button1_Click(object sender, EventArgs e)
    {
        string realname = username.Value.Trim();
        string telephone = Tel.Value.Trim();       
        string password = psd2.Value;     
        if (realname != String.Empty && telephone != String.Empty)
        {
                try
                {
                    //由姓名和电话号码查找数据库，是否存在此人
                    string sqlTel = "select * from Student where Telephone = '" + telephone + "'";
                    SqlConnection conTel = new SqlConnection(connStr);
                    conTel.Open();
                    SqlDataAdapter sdrTel = new SqlDataAdapter(sqlTel, conTel);
                    DataSet dsTel = new DataSet();
                    sdrTel.Fill(dsTel, "Student");
                    //当count等于1时，证明存在这个人，执行更新密码操作
                    if (dsTel.Tables[0].Rows.Count == 1)
                    {
                        string sqlStr = "UPDATE Student SET StudentPassword='" + password + "'where StudentName='" + realname + "'and Telephone = '" + telephone + "'";
                        SqlConnection conn = new SqlConnection(connStr);
                        conn.Open();
                        SqlCommand cmd = conn.CreateCommand();
                        cmd.CommandText = sqlStr;
                        cmd.ExecuteNonQuery();
                        conn.Close();                   
                        Response.Write("<script>window.location='Login.aspx';alert('密码修改成功！');</script>");
                        //Response.Write("<script>alert('该手机号已被注册，请您更换手机号！');</script>");
                    }
                    else
                    {                      
                        Response.Write("<script>alert('对不起！系统无此用户');</script>");
                    }
                }
                catch
                {
                    Response.Write("<script>alert('修改密码失败，请您稍后再试！');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('请填写姓名和手机号！');</script>");
            }        
    }
}