using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.Collections;
using System.Data;
using System.Text;
using Microsoft.Office.Core;
using Word = Microsoft.Office.Interop.Word;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using Microsoft.Office.Interop.Word;


//http://59.110.235.44/video/ga.mp4


public partial class Upload : System.Web.UI.Page
{
    public string fileName;
    // 不限制文件大小，最大可上传大小为2GB
    protected void Page_Load(object sender, EventArgs e)
    {
        //Session["Account"] = input1.Value;
        if (Session["UserID"] == null)
        {
            Response.Write("alert('您还未登陆！');</script>");
            Response.Redirect("Login.aspx", true);
        }
        else
        {
            if (this.IsPostBack)
            {
                UploadInfo uploadInfo = this.Session["UploadInfo"] as UploadInfo;
                uploadInfo.IsReady = false;
                if (this.fileUpload.PostedFile != null && this.fileUpload.PostedFile.ContentLength > 0)
                {
                    try
                    {//文件存取路径
                        string path = this.Server.MapPath(@"~/Uploads");
                        //文件名字
                        string fileName = Path.GetFileName(this.fileUpload.PostedFile.FileName);
                        //将文件名中的空格用-代替
                        fileName = fileName.Replace(" ", "-");
                        uploadInfo.ContentLength = this.fileUpload.PostedFile.ContentLength;
                        uploadInfo.FileName = fileName;
                        uploadInfo.UploadedLength = 0;
                        uploadInfo.IsReady = true;
                        Session["IFhasfile"] = uploadInfo.IsReady;
                        int bufferSize = 1;
                        byte[] buffer = new byte[bufferSize];
                        //Path.Combine(path, fileName)路径变为之前路径+文件名


                        using (FileStream fs = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                        {
                            //当文件已上传大小小于总大小时
                            while (uploadInfo.UploadedLength < uploadInfo.ContentLength)
                            {
                                int bytes = this.fileUpload.PostedFile.InputStream.Read(buffer, 0, bufferSize);
                                fs.Write(buffer, 0, bytes);
                                uploadInfo.UploadedLength += bytes;
                            }
                        }
                        const string js = "window.parent.onComplete('success', '{0} 已成功上传');";
                        //pdf转swf
                        string fileExtention = fileUpload.FileName.Substring(fileName.LastIndexOf("."));
                        //string savePath = HttpContext.Current.Server.MapPath("~/Uploads/");
                        string cmdStr = HttpContext.Current.Server.MapPath("~/SWFTools/pdf2swf.exe");
                        //string sourcePathw = @"" + savePath + fileName;
                        //string targetPathp = @"" + savePath + fileName.Substring(0, fileName.LastIndexOf(".")) + ".pdf";
                        //word转pdf
                        if (fileExtention == ".doc" || fileExtention == ".docx")
                        {
                            string savePath = HttpContext.Current.Server.MapPath("~/Uploads/");
                            string sourcePathw = @"" + savePath + fileName;
                            string targetPathp = @"" + savePath + fileName.Substring(0, fileName.LastIndexOf(".")) + ".pdf";

                            //Word转pdf,再转swf
                            if (DOCConvertToPDF(sourcePathw, targetPathp))
                            {
                                string sourcePath = @"""" + savePath + fileName.Substring(0, fileName.LastIndexOf(".")) + ".pdf" + @"""";
                                string targetPath = @"""" + HttpContext.Current.Server.MapPath("~/PPT/") + fileName.Substring(0, fileName.LastIndexOf(".")) + ".swf" + @"""";
                                //@"""" 四个双引号得到一个双引号，如果你所存放的文件所在文件夹名有空格的话，要在文件名的路径前后加上双引号，才能够成功
                                // -t 源文件的路径
                                // -s 参数化（也就是为pdf2swf.exe 执行添加一些窗外的参数(可省略)）               
                                string argsStr = "  -t " + sourcePath + " -s flashversion=9 -o " + targetPath;
                                ExcutedCmd(cmdStr, argsStr);
                                bool really = true;

                            }
                            else
                            {
                                bool really = false;
                            }
                        }
                        //PPT转pdf,再转swf
                        if (fileExtention == ".ppt" || fileExtention == ".pptx")
                        {
                            string savePath = HttpContext.Current.Server.MapPath("~/Uploads/");
                            string sourcePathw = @"" + savePath + fileName;
                            string targetPathp = @"" + savePath + fileName.Substring(0, fileName.LastIndexOf(".")) + ".pdf";
                            //pdf转swf
                            //string ii = PPTConvertToPDF(sourcePathw, targetPathp);
                            if (PPTConvertToPDF(sourcePathw, targetPathp))
                            {
                                string sourcePath = @"""" + savePath + fileName.Substring(0, fileName.LastIndexOf(".")) + ".pdf" + @"""";
                                string targetPath = @"""" + HttpContext.Current.Server.MapPath("~/PPT/") + fileName.Substring(0, fileName.LastIndexOf(".")) + ".swf" + @"""";
                                //@"""" 四个双引号得到一个双引号，如果你所存放的文件所在文件夹名有空格的话，要在文件名的路径前后加上双引号，才能够成功
                                // -t 源文件的路径
                                // -s 参数化（也就是为pdf2swf.exe 执行添加一些窗外的参数(可省略)）               
                                string argsStr = "  -t " + sourcePath + " -s flashversion=9 -o " + targetPath;
                                ExcutedCmd(cmdStr, argsStr);
                                //Response.Write("alert('zhuanhuanchenggong!')");
                            }
                            //Response.Write(ii);
                            else
                            {
                                //Response.Write("alert('zhuanhuanshibai!')");
                            }

                        }
                        if (fileExtention == ".pdf")
                        {
                            string savePath = HttpContext.Current.Server.MapPath("~/Uploads/");
                            string sourcePath = @"""" + savePath + fileName.Substring(0, fileName.LastIndexOf(".")) + ".pdf" + @"""";
                            string targetPath = @"""" + HttpContext.Current.Server.MapPath("~/PPT/") + fileName.Substring(0, fileName.LastIndexOf(".")) + ".swf" + @"""";
                            //@"""" 四个双引号得到一个双引号，如果你所存放的文件所在文件夹名有空格的话，要在文件名的路径前后加上双引号，才能够成功
                            // -t 源文件的路径
                            // -s 参数化（也就是为pdf2swf.exe 执行添加一些窗外的参数(可省略)）               
                            string argsStr = "  -t " + sourcePath + " -s flashversion=9 -o " + targetPath;
                            ExcutedCmd(cmdStr, argsStr);
                        }

                        ScriptManager.RegisterStartupScript(this, typeof(Upload), "progress", string.Format(js, fileName), true);
                        Application["filename"] = (Path.GetFileName(this.fileUpload.PostedFile.FileName)).Replace(" ", "-");
                        Application["filesize"] = this.fileUpload.PostedFile.ContentLength;
                        //String swfnm = fileUpload.FileName.Substring(fileName.LastIndexOf("."));
                        string[] swfn = (fileUpload.FileName).Replace(" ", "-").Split('.');
                        String swfnm = swfn[0];
                        Application["fileExtention"] = fileExtention;
                        Application["swfname"] = swfnm + ".swf";
                        //Server.Transfer("上传单元.aspx");
                    }
                    catch
                    {
                        Response.Write("alart('转换失败！')");
                    }
                }
                else
                {
                    Application["fileExtention"] = null;
                    const string js = "window.parent.onComplete('error', '上传文件出错');";
                    ScriptManager.RegisterStartupScript(this, typeof(Upload), "progress", js, true);
                }
                uploadInfo.IsReady = false;
            }
        }
    }
    private static void ExcutedCmd(string cmd, string args)
    {
        using (Process p = new Process())
        {
            ProcessStartInfo psi = new ProcessStartInfo(cmd, args);
            p.StartInfo = psi;
            p.Start();
            p.WaitForExit();
        }
    }
    //Word转换成pdf
    ///// <summary>
    /// 把Word文件转换成为PDF格式文件
    /// </summary>
    /// <param name="sourcePath">源文件路径</param>
    /// <param name="targetPath">目标文件路径</param>
    /// <returns>true=转换成功</returns>
    private bool DOCConvertToPDF(string sourcePath, string targetPath)
    {
        bool result = false;
        Word.WdExportFormat exportFormat = Word.WdExportFormat.wdExportFormatPDF;
        object paramMissing = Type.Missing;
        Word.ApplicationClass wordApplication = new Word.ApplicationClass();
        Word.Document wordDocument = null;
        try
        {
            object paramSourceDocPath = sourcePath;
            string paramExportFilePath = targetPath;

            Word.WdExportFormat paramExportFormat = exportFormat;
            bool paramOpenAfterExport = false;
            Word.WdExportOptimizeFor paramExportOptimizeFor = Word.WdExportOptimizeFor.wdExportOptimizeForPrint;
            Word.WdExportRange paramExportRange = Word.WdExportRange.wdExportAllDocument;
            int paramStartPage = 0;
            int paramEndPage = 0;
            Word.WdExportItem paramExportItem = Word.WdExportItem.wdExportDocumentContent;
            bool paramIncludeDocProps = true;
            bool paramKeepIRM = true;
            Word.WdExportCreateBookmarks paramCreateBookmarks = Word.WdExportCreateBookmarks.wdExportCreateWordBookmarks;
            bool paramDocStructureTags = true;
            bool paramBitmapMissingFonts = true;
            bool paramUseISO19005_1 = false;

            wordDocument = wordApplication.Documents.Open(
                            ref paramSourceDocPath, ref paramMissing, ref paramMissing,
                            ref paramMissing, ref paramMissing, ref paramMissing,
                            ref paramMissing, ref paramMissing, ref paramMissing,
                            ref paramMissing, ref paramMissing, ref paramMissing,
                            ref paramMissing, ref paramMissing, ref paramMissing,
                            ref paramMissing);

            if (wordDocument != null)
                wordDocument.ExportAsFixedFormat(paramExportFilePath,
                paramExportFormat, paramOpenAfterExport,
                paramExportOptimizeFor, paramExportRange, paramStartPage,
                paramEndPage, paramExportItem, paramIncludeDocProps,
                paramKeepIRM, paramCreateBookmarks, paramDocStructureTags,
                paramBitmapMissingFonts, paramUseISO19005_1,
                ref paramMissing);
            result = true;
        }
        catch
        {
            result = false;
        }
        finally
        {
            if (wordDocument != null)
            {
                wordDocument.Close(ref paramMissing, ref paramMissing, ref paramMissing);
                wordDocument = null;
            }
            if (wordApplication != null)
            {
                wordApplication.Quit(ref paramMissing, ref paramMissing, ref paramMissing);
                wordApplication = null;
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
        return result;
    }
    /// <summary>
    /// 把PowerPoing文件转换成PDF格式文件
    /// </summary>
    /// <param name="sourcePath">源文件路径</param>
    /// <param name="targetPath">目标文件路径</param>
    /// <returns>true=转换成功</returns>
    private bool PPTConvertToPDF(string sourcePath, string targetPath)
    {
        bool result=false;
        //string er = "";
        PowerPoint.PpSaveAsFileType targetFileType = PowerPoint.PpSaveAsFileType.ppSaveAsPDF;
        object missing = Type.Missing;
        PowerPoint.ApplicationClass application = null;
        PowerPoint.Presentation persentation = null;
        try
        {
            application = new PowerPoint.ApplicationClass();
            persentation = application.Presentations.Open(sourcePath, MsoTriState.msoTrue, MsoTriState.msoFalse, MsoTriState.msoFalse);
            persentation.SaveAs(targetPath, targetFileType, Microsoft.Office.Core.MsoTriState.msoTrue);
            result = true;
            //er = "1";
        }
        catch(Exception ex)
        {
             //er= ex.Message.ToString();
            result = false;
        }
        finally
        {
            if (persentation != null)
            {
                persentation.Close();
                persentation = null;
            }
            if (application != null)
            {
                application.Quit();
                application = null;
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            GC.WaitForPendingFinalizers();
           
        }
        return result;
    }
}