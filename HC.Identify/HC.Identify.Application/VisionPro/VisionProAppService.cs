using HC.Identify.Dto.VisionPro;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Identify.Application.VisionPro
{
    public class VisionProAppService : IdentifyAppServiceBase
    {
        public string CsvDataPath { get; set; }

        public VisionProAppService(string csvDataPath)
        {
            this.CsvDataPath = csvDataPath;
        }

        /// <summary>
        /// 获取已注册产品规格数据
        /// </summary>
        /// <returns>
        /// key 产品规格 value 计算匹配模板数据
        /// </returns>
        public List<CsvSpecification> GetCsvSpecificationList()
        {
            var specList = new List<CsvSpecification>();
            using (StreamReader stream = new StreamReader(CsvDataPath, true))
            {
                while (stream.Peek() >= 0)
                {
                    string strLine = stream.ReadLine();//  读取一行字符并返回
                    string[] strColumns = strLine.Split(',');
                    var i = 0;
                    string spec = string.Empty;
                    List<double> value = new List<double>();
                    foreach (string colVal in strColumns)
                    {
                        if (colVal == "")
                        {
                            continue;
                        }

                        if (i == 0)
                        {
                            spec = colVal;
                        }
                        else
                        {
                            value.Add(Convert.ToDouble(colVal));
                        }
                        i++;
                    }
                    if (!string.IsNullOrEmpty(spec))
                    {
                        specList.Add(new CsvSpecification() { Specification = spec, Values = value.ToArray() });
                    }
                }
                return specList;
            }
        }

        /// <summary>
        /// 保存匹配结果日志
        /// </summary>
        public void SaveResultLog(string logFilePath, string matchedSpec, double maxScore)
        {
            if (!File.Exists(logFilePath))
            {
                File.Create(logFilePath);
            }
            using (StreamWriter logFile = new StreamWriter(logFilePath, true))
            {
                string log = string.Format("\r\n时间：{0} 匹配产品规格:{1} 匹配值：{2}", DateTime.Now.ToString("yyyyMMdd_HHmmssfff"), matchedSpec, maxScore.ToString("F3"));
                logFile.WriteLine(log);
            }
        }

        /// <summary>
        /// 注册产品型号
        /// </summary>
        public void SaveToCsvRegistered(string csvSpecs)
        {
            using (StreamWriter stream = new StreamWriter(CsvDataPath, true))
            {
                stream.WriteLine(csvSpecs);
            }
        }
    }
}
