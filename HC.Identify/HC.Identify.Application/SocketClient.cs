using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HC.Identify.Application
{
    public class SocketClient
    {
        private byte[] result = new byte[1024];
        public Socket clientSocket;
        public string Address { get; set; }
        public int Port { get; set; }
        public bool IsAction { get; set; }
        public bool IsConnection = false;
        public SocketClient(string ipAddress, int port, bool isAction = false)
        {
            this.Address = ipAddress;
            this.Port = port;
            this.IsAction = isAction;
        }

        public void Open()
        {
            if (IsAction && !IsConnection)
            {
                try
                {
                    //设定服务器IP地址  
                    IPAddress ip = IPAddress.Parse(this.Address);
                    //clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    ////Socket串口通信测试
                    clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                    IPEndPoint endPoint = new IPEndPoint(ip, this.Port); // 用指定的ip和端口号初始化IPEndPoint实例
                    clientSocket.Connect(endPoint);
                    IsConnection = true;
                }
                catch (Exception ex)
                {
                    IsConnection = false;
                    MessageBox.Show("连接失败,错误信息：" + ex.Message);
                }

            }
        }

        public void Send(string content)
        {
            if (IsAction && IsConnection)
            {
                clientSocket.Send(Encoding.Default.GetBytes(content.ToString()));
            }
        }
        public string Recive()
        {
            if (IsAction && IsConnection)
            {
                byte[] receive = new byte[1024];
                var data = clientSocket.Receive(receive);
                //var message = Encoding.Default.GetString(receive); 
                var message = Encoding.UTF8.GetString(receive, 0, data);
                return message;
            }
            else
            {
                return "";
            }
        }

        public void Close()
        {

            //clientSocket.Dispose();
            //if (clientSocket.Connected)
            //{
            //    clientSocket.Shutdown(SocketShutdown.Both);
            //    //clientSocket.Close();
            //}
            if (IsConnection)
            {
                clientSocket.LingerState = new LingerOption(false, 5);
                clientSocket.Shutdown(SocketShutdown.Both);
                IsConnection = false;
                clientSocket.Close();
            }
        }
    }
}
