using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Web.Security;
using System.IO;

/// <summary>
/// ExcleIntoSqlSever 的摘要说明
/// </summary>
public class ExcleIntoSqlSever
{
	public ExcleIntoSqlSever()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    public System.Data.DataSet ExcelSqlConnection(string kind, string filepath, string tableName)
    {
        string strCon = "";
        if (kind == ".xls")
        {
            strCon = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filepath + ";Extended Properties='Excel 8.0;HDR=YES;IMEX=1'";
        }
        else if (kind == ".xlsx")
        {
            strCon = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filepath + ";Extended Properties='Excel 12.0;HDR=Yes;IMEX=1;'";
        }
        else
        {
            return null;
        }
        OleDbConnection ExcelConn = new OleDbConnection(strCon);
        try
        {
            string strCom = string.Format("SELECT * FROM [Sheet1$]");
            ExcelConn.Open();
            OleDbDataAdapter myCommand = new OleDbDataAdapter(strCom, ExcelConn);
            DataSet ds = new DataSet();
            myCommand.Fill(ds, "[" + tableName + "$]");
            ExcelConn.Close();
            return ds;
        }
        catch
        {
            ExcelConn.Close();
            return null;
        }
    }
}