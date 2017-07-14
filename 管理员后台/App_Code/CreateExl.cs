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
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
/// <summary>
/// Class1 的摘要说明
/// </summary>
public  class CreateExcel :System.Web.UI.Page
{
    public CreateExcel()
    {
    }
   
		 public void Createxls(DataSet ds, string FileName,Page page1)
        {
            HttpResponse resp;
            resp = page1.Response;
            resp.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
            resp.AppendHeader("Content-Disposition", "attachment;filename=" + FileName);
            string colHeaders = "", ls_item = "";

            //定义表对象与行对象，同时用DataSet对其值进行初始化
            DataTable dt = ds.Tables[0];
            DataRow[] myRow = dt.Select();//可以类似dt.Select("id>10")之形式达到数据筛选目的
            int i = 0;
            int cl = dt.Columns.Count;


            //取得数据表各列标题，各标题之间以\t分割，最后一个列标题后加回车符
            for (i = 0; i < cl; i++)
            {
                if (i == (cl - 1))//最后一列，加\n
                {
                    colHeaders += dt.Columns[i].Caption.ToString() + "\n";
                }
                else
                {
                    colHeaders += dt.Columns[i].Caption.ToString() + "\t";
                }

            }
            resp.Write(colHeaders);
            //向HTTP输出流中写入取得的数据信息

            //逐行处理数据  
            foreach (DataRow row in myRow)
            {
                //当前行数据写入HTTP输出流，并且置空ls_item以便下行数据    
                for (i = 0; i < cl; i++)
                {
                    if (i == (cl - 1))//最后一列，加\n
                    {
                        ls_item += row[i].ToString() + "\n";
                    }
                    else
                    {
                        ls_item += row[i].ToString() + "\t";
                    }

                }
                resp.Write(ls_item);
                ls_item = "";

            }
            resp.End();
        }
	

}