using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client.Communication
{
    public class ClientHandler
    {
        byte[] buffer = new byte[512];
        TcpClient tcpCient = new TcpClient();
        Socket socket;
        Action<string> messageInformer;

        //Constructor
        public ClientHandler(Action<string> msgInformer)
        {
            messageInformer = msgInformer;
            tcpCient.Connect("localhost", 8090);
            socket = tcpCient.Client;
            StartReceive();
        }

        //Methods
        public void SendMessage(string message)
        {
            socket.Send(Encoding.UTF8.GetBytes(message));
        } 

        public void StartReceive()
        {
            //create a new thread
            Task.Factory.StartNew(Receive);
        }

        public void Receive()
        {
            string message = "";
            while (!message.Equals("@quit"))
            {
                int length = socket.Receive(buffer);
                message = Encoding.UTF8.GetString(buffer, 0, length);
                // inform Gui via delegate
                messageInformer(message);
            }
        }

        public void Close()
        {
            socket.Close();
        }

    }
}
