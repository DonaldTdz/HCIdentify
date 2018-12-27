using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HC.Identify.Application
{
    public class COMServer
    {
        public SerialPort COM = null;
        public bool IsOpen = false;//com是否连接
        public string PortName { get; set; }//com名称
        public int BaudRate { get; set; } //波特率
        public int DataBits { get; set; }
        public StopBits StopBits { get; set; }
        public Parity Parity { get; set; }
        public bool IsConnection = false;
        public bool IsAction { get; set; }
        public COMServer(string portName, int baudRate, int dataBits, StopBits stopBits, Parity parity, bool isAction)
        {
            PortName = portName;
            BaudRate = baudRate;
            DataBits = dataBits;
            StopBits = stopBits;
            Parity = parity;
            IsAction = isAction;
        }

        public void Open()
        {
            if (IsAction && !IsConnection)
            {
                try
                {
                    COM = new SerialPort();
                    COM.PortName = PortName;
                    COM.BaudRate = this.BaudRate; //9600;//注意 这里默认9600 
                    COM.DataBits = this.DataBits; //8;
                    COM.ReadTimeout = 500;
                    COM.WriteTimeout = 500;
                    COM.StopBits = this.StopBits;
                    COM.Parity = this.Parity;
                    COM.Open();
                    IsConnection = true;
                }
                catch (Exception ex)
                {
                    IsConnection = false;
                    MessageBox.Show("连接失败,错误信息：" + ex.Message);
                }
            }
        }

        public void Send(byte[] sendByte)
        {
            COM.Write(sendByte, 0, sendByte.Length);
        }
        #region 测试
        public string Recive()
        {
            if (IsAction && IsConnection)
            {
                //创建接收字节数组
                Byte[] receivedData = new Byte[COM.BytesToRead];
                //读取数据GB2312
                COM.Read(receivedData, 0, receivedData.Length);

                //var resultData = new ASCIIEncoding().GetString(receivedData);ToBase64String
                var resultData = Encoding.ASCII.GetString(receivedData);
                return resultData;
            }
            else
            {
                return "";
            }
        }

        public void Close()
        {
            COM.Close();
        }
        #endregion

    }
}
