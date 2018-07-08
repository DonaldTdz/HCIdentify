using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Identify.Application.Helpers
{
    public class CommHelper
    {
        public static void WriteLog(string appPath, string title, string msg)
        {
            string fileName = @"Log\" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
            string path = Path.Combine(appPath, fileName);
            if (!Directory.Exists(path + @"\Log"))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(path + @"\Log");
                directoryInfo.Create();

            }
            if (!File.Exists(path))
            {
                FileStream fs = new FileStream(path, FileMode.CreateNew);
                fs.Close();
            }

            StreamWriter writer = null;
            try
            {
                writer = File.AppendText(path);
                writer.WriteLine("===============================");
                writer.WriteLine("时间：{0}", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                writer.WriteLine("操作：{0}", title);
                writer.WriteLine("内容：{0}", msg);
                writer.WriteLine("===============================");
                writer.Flush();
            }
            catch (Exception ex)
            {
                //写日志失败不用抛出异常
                //MessageBox.Show(ex.Message, "异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }
        }

        //清除日志
        public static void ClearLog(string appPath, int day)
        {
            DateTime minDay = DateTime.Today.AddDays(day);
            string path = appPath + @"\Log\";
            if (Directory.Exists(path))
            {
                string[] files = Directory.GetFiles(path, "*", SearchOption.AllDirectories);
                foreach (string fileName in files)
                {
                    string strFileDate = Path.GetFileName(fileName);
                    try
                    {
                        DateTime fileDate = DateTime.ParseExact(strFileDate.Replace(".txt", ""), "yyyyMMdd", null);
                        if (fileDate < minDay)
                        {
                            File.Delete(fileName);
                        }
                    }
                    catch (Exception)
                    {
                        //删除失败不用处理
                    }
                }
            }
        }
    }
}
