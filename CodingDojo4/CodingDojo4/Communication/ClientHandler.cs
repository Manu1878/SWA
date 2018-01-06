using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodingDojo4.Communication
{
    public class ClientHandler
    {
        byte[] buffer = new byte[512];
        Action<string, Socket> action;
        Thread clientThread;
        string endMessage = "@quit";

        public string Name { get; set; }

        public Socket ClientSocket { get; set; }

        //Constructor
        public ClientHandler(Socket socket, Action<string, Socket> action)
        {
            ClientSocket = socket;
            this.action = action;
            clientThread = new Thread(Receive);
            clientThread.Start();
        }

        //Methode
        public void Receive()
        {
            string message = "";
            while (!message.Equals("@quit"))
            {
                int length = ClientSocket.Receive(buffer);
                message = Encoding.UTF8.GetString(buffer, 0, length);
                if(Name == null && message.Contains(":"))
                {
                    Name = message.Split(':')[0];
                }
                action(message, ClientSocket);
            }
            Close();
        }

        public void Close()
        {
            SendMessage(endMessage);
            ClientSocket.Close();
            clientThread.Abort();
        }

        public void SendMessage(string message)
        {
            ClientSocket.Send(Encoding.UTF8.GetBytes(message));
        }
    }
}
