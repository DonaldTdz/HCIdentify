using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace HC.Identify.Application
{
    public class SocketClient
    {
        private byte[] result = new byte[1024];
        private Socket clientSocket;
        public string Address { get; set; }
        public int Port { get; set; }

        public SocketClient(string ipAddress, int port)
        {
            this.Address = ipAddress;
            this.Port = port;
        }

        public void Open()
        {
            //设定服务器IP地址  
            IPAddress ip = IPAddress.Parse(this.Address);
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void Send(string content)
        {
            clientSocket.Send(Encoding.Default.GetBytes(content.ToString()));
        }
    }
}
