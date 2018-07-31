using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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

        public COMServer(string portName, int baudRate, int dataBits, StopBits stopBits, Parity parity)
        {
            this.PortName = portName;
            this.BaudRate = baudRate;
            this.DataBits = dataBits;
            this.StopBits = stopBits;
            this.Parity = parity;
        }

        public void Open()
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
            IsOpen = true;
        }

        public void Send(byte[] sendByte)
        {
            COM.Write(sendByte, 0, sendByte.Length);
        }
        #region 测试
        public string Recive()
        {
            //创建接收字节数组
            Byte[] receivedData = new Byte[COM.BytesToRead];
            //读取数据GB2312
            COM.Read(receivedData, 0, receivedData.Length);
            //var resultData = new ASCIIEncoding().GetString(receivedData);ToBase64String
            var resultData = Encoding.ASCII.GetString(receivedData);
            return resultData;
        }

        public void Close()
        {
            COM.Close();
        }
      #endregion

    }
}
