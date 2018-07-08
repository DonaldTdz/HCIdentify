using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HC.Identify.Application
{
    public class SocketServer
    {
        #region 单例

        /// <summary>
        /// Singleton instance.
        /// </summary>
        public static SocketServer Instance { get { return SingletonInstance; } }
        private static readonly SocketServer SingletonInstance = new SocketServer();

        #endregion
        //分别创建一个监听客户端的线程和套接字
        public Thread threadWatch = null;
        Socket socketWatch = null;

        public const int SendBufferSize = 2 * 1024;//发出字节
        public const int ReceiveBufferSize = 8 * 1024;//收到字节

        //用于保存所有通信客户端的Socket
        Dictionary<string, Socket> dicSocket = new Dictionary<string, Socket>();

        //创建与客户端建立连接的套接字
        Socket socConnection = null;
        string clientName = null; //创建访问客户端的名字
        IPAddress clientIP; //访问客户端的IP
        int clientPort; //访问客户端的端口号
        public void Open(int port = 6666)
        {
            IPAddress ipAddress = GetLocalIPv4Address();
            if (socketWatch == null)
            {
                //定义一个套接字用于监听客户端发来的信息  包含3个参数(IP4寻址协议,流式连接,TCP协议)
                socketWatch = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                //将IP地址和端口号绑定到网络节点endpoint上 
                IPEndPoint endpoint = new IPEndPoint(ipAddress, port);
                //将负责监听的套接字绑定网络端点
                socketWatch.Bind(endpoint);
                //将套接字的监听队列长度设置为20
                socketWatch.Listen(20);
                //创建一个负责监听客户端的线程 
                threadWatch = new Thread(WatchConnecting);
                //将窗体线程设置为与后台同步
                threadWatch.IsBackground = true;
                //启动线程
                threadWatch.Start();
            }
        }

        /// <summary>
        /// 获取本地IPv4地址
        /// </summary>
        /// <returns>本地IPv4地址</returns>
        public IPAddress GetLocalIPv4Address()
        {
            IPAddress localIPv4 = null;
            //获取本机所有的IP地址列表
            IPAddress[] ipAddressList = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress ipAddress in ipAddressList)
            {
                //判断是否是IPv4地址
                if (ipAddress.AddressFamily == AddressFamily.InterNetwork) //AddressFamily.InterNetwork表示IPv4 
                {
                    //if (ipAddress.Address.)
                    localIPv4 = ipAddress;
                }
                else
                {
                    continue;
                }
            }
            return localIPv4;
        }

        /// <summary>
        /// 持续不断监听客户端发来的请求, 用于不断获取客户端发送过来的连续数据信息
        /// </summary>
        private void WatchConnecting()
        {
            while (true)
            {
                socConnection = socketWatch.Accept();

                //获取访问客户端的IP
                clientIP = (socConnection.RemoteEndPoint as IPEndPoint).Address;
                //获取访问客户端的Port
                clientPort = (socConnection.RemoteEndPoint as IPEndPoint).Port;
                //创建访问客户端的唯一标识 由IP和端口号组成 
                clientName = "IP: " + clientIP + " Port: " + clientPort;
                // lstClients.Items.Add(clientName); //在客户端列表添加该访问客户端的唯一标识
                dicSocket.Add(clientName, socConnection); //将客户端名字和套接字添加到添加到数据字典中

                //创建通信线程 
                ParameterizedThreadStart pts = new ParameterizedThreadStart(ServerRecMsg);
                Thread thread = new Thread(pts);
                thread.IsBackground = true;
                //启动线程
                thread.Start(socConnection);
                //txtMsg.AppendText("IP: " + clientIP + " Port: " + clientPort + " 的客户端与您连接成功,现在你们可以开始通信了...\r\n");
                //CommHelper.WriteLog("IP: " + clientIP + " Port: " + clientPort + " 的客户端与您连接成功,现在你们可以开始通信了...\r\n");

            }
        }

        //  string strSRecMsg = null;
        /// <summary>
        /// 接收客户端发来的信息
        /// </summary>
        private void ServerRecMsg(object socketClientPara)
        {
            Socket socketServer = socketClientPara as Socket;
            //  long fileLength = 0;
            while (true)
            {
                //Thread.Sleep(2000);
                int firstReceived = 0;
                byte[] buffer = new byte[ReceiveBufferSize];
                //获取接收的数据,并存入内存缓冲区  返回一个字节数组的长度
                if (socketServer != null) firstReceived = socketServer.Receive(buffer);

                if (firstReceived > 0) //接受到的长度大于0 说明有信息或文件传来
                {
                    //string aa = Encoding.GetEncoding("GB2312").GetString(buffer, 0, firstReceived);
                    string str = Encoding.UTF8.GetString(buffer, 0, firstReceived);

                    //if (str.Contains("ABWW"))//说明是首次推送
                    //{
                    //}
                }
            }
        }
    }
}
