using HC.Identify.Dto.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HC.Identify.Application.Helpers
{
    public class CommHelper
    {
        public static string _appPath;
        public static string _fileName;
        public static List<Logs> _logs = new List<Logs>();
        public static bool _isErrorLog;
        public CommHelper(string appPath, string fileName,bool isErrorLog)
        {
            _appPath = appPath;
            _fileName = fileName;
            _isErrorLog = isErrorLog;
            LogThread();
        }
        public static void WriteLog(string appPath, string title, string msg)
        {
            Task.Run(() =>
            {
                string fileName = @"Log\";
                //string fileName = @"Log\" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
                string path = Path.Combine(appPath, fileName);
                if (!Directory.Exists(path + @"\Log"))
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(path + @"\Log");
                    directoryInfo.Create();

                }
                path = path + DateTime.Now.ToString("yyyyMMdd") + ".txt";
                //if (!File.Exists(path))
                //{
                //    //FileStream fs = File.Create(fileName);  //创建文件
                //    //fs.Close();
                //    //FileStream fs = new FileStream(path, FileMode.CreateNew);
                //    FileStream fs = new FileStream(path, FileMode.CreateNew);
                //    fs.Close();
                //}
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
            });
        }

        /// <summary>
        /// 独立线程调用写日志
        /// </summary>
        public static void WriteLogByThread(List<Logs> wrLogs)
        {
            foreach (var item in wrLogs)
            {
                string fileName = string.IsNullOrEmpty(_fileName) ? @"Log\" : _fileName;
                string path = Path.Combine(_appPath, fileName);
                if (!Directory.Exists(path))
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(path);
                    directoryInfo.Create();

                }
                path = path + DateTime.Now.ToString("yyyyMMdd") + ".txt";
                StreamWriter writer = null;
                try
                {
                    writer = File.AppendText(path);
                    writer.WriteLine("===============================");
                    writer.WriteLine("时间：{0}", item.DateStr);
                    writer.WriteLine("操作：{0}", item.Title);
                    writer.WriteLine("内容：{0}", item.Msg);
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
        public void AddLogs(Logs log)
        {
            _logs.Add(log);
        }

        /// <summary>
        /// 日志线程
        /// </summary>
        public void LogThread()
        {
            var threadLog = new Thread(WriteLog);
            //后台线程
            threadLog.IsBackground = true;
            //启动处理读码结果线程
            threadLog.Start();
        }

        /// <summary>
        /// 写日志
        /// </summary>
        public void WriteLog()
        {
            while (true)
            {
                if (_isErrorLog)
                {
                    if (_logs.Count > 0)
                    {
                        Thread.Sleep(200);
                        var LogsWr = _logs;
                        WriteLogByThread(LogsWr);
                        _logs.RemoveRange(0, LogsWr.Count);
                        LogsWr.Clear();
                    }
                }
                else
                {
                    Thread.Sleep(30000);
                    var LogsWr = _logs;
                    WriteLogByThread(LogsWr);
                    _logs.RemoveRange(0, LogsWr.Count);
                    LogsWr.Clear();
                }
            }
        }
    }
}
