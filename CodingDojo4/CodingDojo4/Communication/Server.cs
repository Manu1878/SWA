using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodingDojo4.Communication
{
    public class Server
    {
        public Socket serverSocket;
        public List<ClientHandler> clients = new List<ClientHandler>();
        public Action<string> informer;
        Thread acceptThread; //handles the accepting of new clients

        public Server(Action<string> informer)
        {
            this.informer = informer;
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(new IPEndPoint(IPAddress.Loopback, 8090));
            serverSocket.Listen(5);
        }

        public void StartAccepting()
        {
            acceptThread = new Thread(new ThreadStart(Accept));
            acceptThread.IsBackground = true;
            acceptThread.Start();
        }

        public void Accept()
        {
            while (acceptThread.IsAlive)
            {
                clients.Add(new ClientHandler(serverSocket.Accept(), new Action<string, Socket>(MessageReceive)));
            }
        }

        public void MessageReceive(string message, Socket senderSocket)
        {
            informer(message);
            foreach (var item in clients)
            {
                if(item.ClientSocket != senderSocket)
                {
                    item.SendMessage(message);
                }
            }
        }

        public void Stop()
        {
            serverSocket.Close();
            acceptThread.Abort();
            foreach (var item in clients)
            {
                item.Close();
            }
            clients.Clear();
        }

        public void DisconnectUser(string name)
        {
            foreach (var item in clients)
            {
                if (item.Name.Equals(name))
                {
                    item.Close();
                    clients.Remove(item);
                    break;
                }
            }
        }


    }
}
