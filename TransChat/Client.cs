using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace TransChat
{
    class Client
    {

        private TcpClient _client;

        private NetworkStream _stream;

        public bool Connected => _client.Connected;

        public IPAddress IP => ((IPEndPoint) _client.Client.RemoteEndPoint).Address; 

        public string Name { get; set; }

        public void Connect(int port)
        {
            _client = new TcpClient();
            _client.Connect(IPAddress.Parse("127.0.0.1"), port);

            byte[] name = Encoding.ASCII.GetBytes(Name);
            _stream = _client.GetStream();
            _stream.Write(name, 0, name.Length);
        }

        private bool Verify(string password)
        {
            return true;
        }

        public void Send(string message)
        {
            byte[] data = Encoding.ASCII.GetBytes(message); 
            _stream.Write(data, 0, data.Length);
        }

        public void Receive()
        {
            byte[] receivedBytes = new byte[1024];
            int byteCount;

            while ((byteCount = _stream.Read(receivedBytes, 0, receivedBytes.Length)) > 0)
            {
                Console.Write(Encoding.ASCII.GetString(receivedBytes, 0, byteCount));
            }
            
        }

    }
}
