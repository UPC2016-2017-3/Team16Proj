using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class SelfInfo : System.Web.UI.Page
{
    public string Name;
    public string Account;
    public string Sex;
    public string Sex2;
    public string Email;
    public string Telephone;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Write("alert('您还未登陆！');</script>");
            Response.Redirect("Login.aspx", true);
        }
        else
        {
            string conStr = "Data Source=59.110.235.44;Initial Catalog=hongruan;User ID=hrdev;Password=123hrdev456";
            string sqlgetinfo = "select * from Student where StudentID="+ int.Parse(Session["UserID"].ToString());

            SqlConnection conn = new SqlConnection(conStr);
            SqlDataAdapter sda = new SqlDataAdapter(sqlgetinfo, conn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            Name = ds.Tables[0].Rows[0]["StudentName"].ToString();
            Account = ds.Tables[0].Rows[0]["StudentAccount"].ToString();
            Sex = ds.Tables[0].Rows[0]["StudentSex"].ToString();
            Email = ds.Tables[0].Rows[0]["StudentEmail"].ToString();
            Telephone = ds.Tables[0].Rows[0]["Telephone"].ToString();

            if (Sex.Equals("男"))
            {
                Sex2 = "女";
            }
            else
            {
                Sex2 = "男";
            }
        }
    }
}