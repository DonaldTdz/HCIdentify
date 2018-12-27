using HC.Identify.Dto.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HC.Identify.Application.Common
{
    public class AboutLog
    {
        public string _appPath;
        public string _fileName;
        public List<Logs> _logs = new List<Logs>();
        public bool _isErrorLog;
        public AboutLog(string appPath, string fileName, bool isErrorLog)
        {
            _appPath = appPath;
            _fileName = fileName;
            _isErrorLog = isErrorLog;
            //LogThread();
        }
        /// <summary>
        /// 独立线程调用写日志
        /// </summary>
        public void WriteLogByThread(List<Logs> wrLogs)
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
