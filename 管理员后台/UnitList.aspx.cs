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
using System.Text;

public partial class UnitList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Write("alert('您还未登陆！');</script>");
            Response.Write("<script>   top.window.location.href = 'Login.aspx' ;</script>");
        }
        else
        {
            if (Session["ClassID"] != null)
            {
                string id = Session["ClassID"].ToString();
                int id1 = int.Parse(id);

                string connStrA = "Data Source=59.110.235.44;Initial Catalog=hongruan;User ID=hrdev;Password=123hrdev456";
                SqlConnection con = new SqlConnection(connStrA);
                con.Open();

                SqlCommand cmd1 = con.CreateCommand();
                string strSqlClass = "SELECT Class.ClassName,Class.ClassInfo from Class where Class.ClassID='" + id1 + "'";
                SqlDataAdapter sda1 = new SqlDataAdapter(strSqlClass, con);
                DataSet ds1 = new DataSet();
                sda1.Fill(ds1);
                dddd.Text = ds1.Tables[0].Rows[0]["ClassName"].ToString();
                Label1.Text = ds1.Tables[0].Rows[0]["ClassInfo"].ToString();

                SqlCommand cmd = con.CreateCommand();
                string strSqlCourse = "SELECT Unit.UnitName,Unit.UnitRank,Unit.UnitID,Class.ClassID,Category.CategoryName,Class.ClassName,Class.ClassInfo,Department.DepartmentName,Case Class.ClassOpenness when '1' then '开放' when '0' then '不开放' end as ClassOpenness,Class.ClassPrice FROM Class LEFT JOIN Class_Category on Class.ClassID=Class_Category.ClassID LEFT JOIN Category on Category.CategoryID=Class_Category.CategoryID LEFT JOIN Class_Department on Class_Department.ClassID=Class.ClassID LEFT JOIN Department on Department.DepartmentID=Class_Department.DepartmentID  inner join Unit on Class.ClassID=Unit.ClassID where Class.ClassID='" + id1 + "'";
                SqlDataAdapter sda = new SqlDataAdapter(strSqlCourse, con);
                DataSet ds = new DataSet();
                sda.Fill(ds);


                UnitList_unit.DataSource = ds;
                UnitList_unit.DataBind();
                con.Close();

            }

        }
    }

    public void Delete_OnClick(Object sender, CommandEventArgs e)
    {
        //if (AnswerText.InnerText.ToString().Trim() != String.Empty)
        //{
        string connStr = "Data Source=59.110.235.44;Initial Catalog=hongruan;User ID=hrdev;Password=123hrdev456";

            try
            { 
                
                //string urank = UnitRank1.InnerText.ToString().Trim();
                //int number_urank = 0;
                //string num = null;
                //foreach (char item in urank)
                //{
                //    if (item >= 48 && item <= 58)
                //    {
                //        num += item;
                //    }
                //}
                //number_urank = int.Parse(num);
                int number_unitid =int.Parse(UnitIDID.InnerText.ToString().Trim());
                
                string sqlStr1 = "delete from PPT where UnitID='" + number_unitid + "'";
                string sqlStr2 = "delete from Audio where UnitID='" + number_unitid + "'";
                string sqlStr3 = "delete from Video where UnitID='" + number_unitid + "'";
                string sqlStr = "delete from Unit where UnitID ='" + number_unitid + "'";
                
                SqlConnection conn = new SqlConnection(connStr);
                conn.Open();

                SqlCommand cmd1 = conn.CreateCommand();
                cmd1.CommandText = sqlStr1;
                cmd1.ExecuteNonQuery();

                SqlCommand cmd2 = conn.CreateCommand();
                cmd2.CommandText = sqlStr2;
                cmd2.ExecuteNonQuery();

                SqlCommand cmd3 = conn.CreateCommand();
                cmd3.CommandText = sqlStr3;
                cmd3.ExecuteNonQuery();

                SqlCommand cmd = conn.CreateCommand();
                cmd2.CommandText = sqlStr;
                cmd2.ExecuteNonQuery();

                conn.Close();
                Response.Write("<script>window.location='UnitList.aspx';alert('删除成功！');</script>");

            }
            catch (Exception exx)
            {
                Response.Write("<script>alert('删除失败！');</script>");
            }
        }
        
    protected void Button1_Edit(object sender, CommandEventArgs e)
    {
        //int id = Convert.ToInt32(e.CommandArgument);
        //string ID = id.ToString();
        //Session["UnitID"] = ID;
        object[] arguments = e.CommandArgument.ToString().Split(',');
        //int unit_id = Convert.ToInt32(arguments[0].ToString());
        int unit_id = int.Parse(arguments[0].ToString());
        //string ID = unit_id.ToString();
        string ID = arguments[0].ToString();
        Session["UnitID"] = ID;

        int unit_rank = int.Parse(arguments[1].ToString());
        string ID2 = arguments[1].ToString();
        //int class_id = Convert.ToInt32(arguments[1]);
        //string ID2 = unit_id.ToString();
        Session["UnitRank"] = ID2;
        string unit_name = arguments[2].ToString();
        Session["UnitName"] = unit_name;
        Response.Redirect("编辑课时.aspx");


        


    }
    }
