using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using TLibrary.ObjectHelper;
using System.Net;

public partial class Login : System.Web.UI.Page
{
    public string rolename;
    int count;
    string connStr = "Data Source=59.110.235.44;Initial Catalog=hongruan;User ID=hrdev;Password=123hrdev456";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HttpCookie Cookie = CookiesHelper.GetCookie("UserInfo");
            if (Cookie != null)
            {
                this.account.Value = Cookie.Values["uName"];
                string psd = Cookie.Values["uPassword"];
                this.password.Attributes.Add("Value",psd);
            }
        }       
    }
    protected void Login_Click(object sender, EventArgs e)
    {
        string Account = this.account.Value.Trim();
        string Password = this.password.Text;
        //string Password = this.password.Value.Trim();
        //string Password = "123456";
        rolename = text1.InnerText.ToString();
        if (Account != String.Empty && Password != String.Empty)
        {

            if (rolename == "管理员")
            {
                string sql = "select * from Manager where ManagerName = '" + Account + "' and ManagerPassword = '" + Password + "'";
                SqlConnection con = new SqlConnection(connStr);
                con.Open();
                SqlDataAdapter sdr = new SqlDataAdapter(sql, con);
                DataSet ds = new DataSet();
                sdr.Fill(ds, "Manager");
                if (ds.Tables[0].Rows.Count == 1)
                {
                    if (remME.Checked)
                    //if (!string.IsNullOrEmpty(Request["remME"]))
                    {
                        HttpCookie Cookie = CookiesHelper.GetCookie("UserInfo");
                        if (Cookie == null)
                        {
                            Cookie = new HttpCookie("UserInfo");
                            Cookie.Values.Add("uName", Account);
                            Cookie.Values.Add("uPassword", Password);
                            //设置Cookie过期时间                    
                            Cookie.Expires = DateTime.Now.AddDays(365);
                            CookiesHelper.AddCookie(Cookie);
                        }
                        else if (!Cookie.Values["uName"].Equals(Account))
                            CookiesHelper.SetCookie("UserInfo", "uName", Account);
                        else if (!Cookie.Values["uPassword"].Equals(Password))
                        {
                            CookiesHelper.SetCookie("UserInfo", "uPassword", Password);
                        }
                    }
                    Response.Write("<script>alert('登陆成功！');</script>");
                    Session["UserID"] = ds.Tables[0].Rows[0]["managerid"].ToString();
                    Session["Laccount"]=Account;
                    Session["Lpassword"] = Password;
                    Response.Redirect("index.aspx", true);
                }


                else
                {
                    string sql1 = "select * from Manager where ManagerAccount = '" + Account + "' and ManagerPassword = '" + Password + "'";
                    //SqlConnection con = new SqlConnection(connStr);
                    //con.Open();
                    SqlDataAdapter sdr1 = new SqlDataAdapter(sql1, con);
                    DataSet ds1 = new DataSet();
                    sdr1.Fill(ds1, "Manager");
                    if (ds1.Tables[0].Rows.Count == 1)
                    {
                        if (remME.Checked)
                        //if (!string.IsNullOrEmpty(Request["remME"]))
                        {
                            HttpCookie Cookie = CookiesHelper.GetCookie("UserInfo");
                            if (Cookie == null)
                            {
                                Cookie = new HttpCookie("UserInfo");
                                Cookie.Values.Add("uName", Account);
                                Cookie.Values.Add("uPassword", Password);
                                //设置Cookie过期时间                    
                                Cookie.Expires = DateTime.Now.AddDays(365);
                                CookiesHelper.AddCookie(Cookie);
                            }
                            else if (!Cookie.Values["uName"].Equals(Account))
                                CookiesHelper.SetCookie("UserInfo", "uName", Account);
                            else if (!Cookie.Values["uPassword"].Equals(Password))
                            {
                                CookiesHelper.SetCookie("UserInfo", "uPassword", Password);
                            }
                        }
                        Session["Laccount"] = Account;
                        Session["Lpassword"] = Password;
                        Session["UserID"] = ds.Tables[0].Rows[0]["managerid"].ToString();
                        Response.Write("<script>alert('登陆成功！');</script>");
                        Response.Redirect("index.aspx", true);
                    }
                    else
                    {
                        Response.Write("<script>alert('用户名或密码错误！');</script>");
                        Response.Redirect("Login.aspx", true);
                    }
                }
            }
            else if (rolename == "学员")
            {
                string sql = "select * from Student where StudentName = '" + Account + "' and StudentPassword = '" + Password + "'";
                SqlConnection con = new SqlConnection(connStr);
                con.Open();
                SqlDataAdapter sdr = new SqlDataAdapter(sql, con);
                DataSet ds = new DataSet();
                sdr.Fill(ds, "Student");
                if (ds.Tables[0].Rows.Count == 1)
                {
                    if (remME.Checked)
                    //if (!string.IsNullOrEmpty(Request["remME"]))
                    {
                        HttpCookie Cookie = CookiesHelper.GetCookie("UserInfo");
                        if (Cookie == null)
                        {
                            Cookie = new HttpCookie("UserInfo");
                            Cookie.Values.Add("uName", Account);
                            Cookie.Values.Add("uPassword", Password);
                            //设置Cookie过期时间                    
                            Cookie.Expires = DateTime.Now.AddDays(7);
                            CookiesHelper.AddCookie(Cookie);
                        }
                        else if (!Cookie.Values["uName"].Equals(Account))
                            CookiesHelper.SetCookie("UserInfo", "uName", Account);
                        else if (!Cookie.Values["uPassword"].Equals(Password))
                        {
                            CookiesHelper.SetCookie("UserInfo", "uPassword", Password);
                        }
                    }
                    Session["Laccount"] = Account;
                    Session["Lpassword"] = Password;
                    Session["UserID"] = ds.Tables[0].Rows[0]["managerid"].ToString();
                    Response.Write("<script>alert('登陆成功！');</script>");
                    Response.Redirect("index.aspx", true);
                }
                else
                {
                    string sql1 = "select * from Student where Telephone = '" + Account + "' and StudentPassword = '" + Password + "'";
                    SqlDataAdapter sdr1 = new SqlDataAdapter(sql1, con);
                    DataSet ds1 = new DataSet();
                    sdr1.Fill(ds1, "Student");
                    if (ds1.Tables[0].Rows.Count == 1)
                    {
                        if (remME.Checked)
                        //if (!string.IsNullOrEmpty(Request["remME"]))
                        {
                            HttpCookie Cookie = CookiesHelper.GetCookie("UserInfo");
                            if (Cookie == null)
                            {
                                Cookie = new HttpCookie("UserInfo");
                                Cookie.Values.Add("uName", Account);
                                Cookie.Values.Add("uPassword", Password);
                                //设置Cookie过期时间                    
                                Cookie.Expires = DateTime.Now.AddDays(365);
                                CookiesHelper.AddCookie(Cookie);
                            }
                            else if (!Cookie.Values["uName"].Equals(Account))
                                CookiesHelper.SetCookie("UserInfo", "uName", Account);
                            else if (!Cookie.Values["uPassword"].Equals(Password))
                            {
                                CookiesHelper.SetCookie("UserInfo", "uPassword", Password);
                            }
                        }
                        Session["Laccount"] = Account;
                        Session["Lpassword"] = Password;
                        Session["UserID"] = ds.Tables[0].Rows[0]["managerid"].ToString();
                        Response.Write("alert('登陆成功！');</script>");
                        Response.Redirect("index.aspx", true);
                    }
                    else
                    {
                        Response.Write("<script>alert('用户名或密码错误！');</script>");
                        Response.Redirect("Login.aspx", true);
                    }
                }
            }
            else
            {
                Response.Write("<script>alert('请您选择角色！');</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('用户名和密码不可为空！');</script>");
        }
    }
}