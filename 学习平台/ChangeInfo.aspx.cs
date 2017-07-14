using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class ChangeInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      
            

            string conStr = "Data Source=59.110.235.44;Initial Catalog=hongruan;User ID=hrdev;Password=123hrdev456";
            string sqlgetinfo = "select * from Student where StudentID=1";

            SqlConnection conn = new SqlConnection(conStr);
            SqlDataAdapter sda = new SqlDataAdapter(sqlgetinfo, conn);
            DataSet ds = new DataSet();
            sda.Fill(ds);

            string Account = ds.Tables[0].Rows[0]["StudentAccount"].ToString();
            string Sex = ds.Tables[0].Rows[0]["StudentSex"].ToString();
            string Email = ds.Tables[0].Rows[0]["StudentEmail"].ToString();
            string Telephone = ds.Tables[0].Rows[0]["Telephone"].ToString();
            string Password = ds.Tables[0].Rows[0]["StudentPassword"].ToString();


            Account = Request["Account"];
            Sex = Request["Sex"];
            Email = Request["Email"];
            Telephone = Request["Telephone"];
            string Password1 = Request["Password1"];
            string Password2 = Request["Password2"];
            string Password3 = Request["Password3"];

            if ((Password == Password1) && (Password2 == Password3) && (Password2 != null))
            {
                string strInsert = "Update Student set StudentAccount='" + Account + "',StudentSex='" + Sex + "',StudentEmail='" + Email + "',Telephone='" + Telephone + "',StudentPassword='" + Password2 + "' where StudentID=1";
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = strInsert;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                Response.Write("<script language='javascript'>alert('修改成功！');window.location.href='Home.aspx'</script>");
                //Response.Redirect("Home.aspx");
            }
            else if ((Password1 == "" || Password1 == null) && (Password2 == "" || Password2 == null) && (Password3 == "" || Password3 == null))
            {
                string strInsert = "Update Student set StudentAccount='" + Account + "',StudentSex='" + Sex + "',StudentEmail='" + Email + "',Telephone='" + Telephone + "' where StudentID=1";
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = strInsert;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                Response.Write("<script language='javascript'>alert('修改成功！');window.location.href='Home.aspx'</script>");
            }
            else
            {
                string strInsert = "Update Student set StudentAccount='" + Account + "',StudentSex='" + Sex + "',StudentEmail='" + Email + "',Telephone='" + Telephone + "',StudentPassword='" + Password + "' where StudentID=1";
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = strInsert;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                Response.Write("<script language=javascript>alert('修改密码失败！');window.location='SelfInfo.aspx'</script>");
            }
        }
    
}