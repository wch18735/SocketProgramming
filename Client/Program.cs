using System;
using System.Net;
using System.Net.Sockets;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Press Enter to Connect");
            Console.ReadLine();

            var endPoint = new IPEndPoint(IPAddress.Loopback, 9000);
            var socket = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            socket.Connect(endPoint);

            var networkStream = new NetworkStream(socket, true);

            var msg = "Hello World";

            var buffer = System.Text.Encoding.UTF8.GetBytes(msg);

            networkStream.Write(buffer, 0, buffer.Length);

            var response = new byte[1024];

            var bytesRead = networkStream.Read(response, 0, response.Length);
            var responseStr = System.Text.Encoding.UTF8.GetString(response);

            Console.WriteLine($"Received: {responseStr}");

        }
    }
}
