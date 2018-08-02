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
        private Socket clientSocket;
        public string Address { get; set; }
        public int Port { get; set; }
        public bool IsAction { get; set; }

        public SocketClient(string ipAddress, int port, bool isAction = false)
        {
            this.Address = ipAddress;
            this.Port = port;
            this.IsAction = isAction;
        }

        public void Open()
        {
            if (IsAction)
            {

                //设定服务器IP地址  
                IPAddress ip = IPAddress.Parse(this.Address);
                //clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                ////Socket串口通信测试
                clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                IPEndPoint endPoint = new IPEndPoint(ip, this.Port); // 用指定的ip和端口号初始化IPEndPoint实例
                clientSocket.Connect(endPoint);
            }
        }

        public void Send(string content)
        {
            if (IsAction)
            {
                clientSocket.Send(Encoding.Default.GetBytes(content.ToString()));
            }
        }
        public void Recive()
        {
            if (IsAction)
            {
                byte[] receive = new byte[1024];
                clientSocket.Receive(receive);
                var message = Encoding.Default.GetString(receive);
                MessageBox.Show(message);
            }
        }
    }
}
