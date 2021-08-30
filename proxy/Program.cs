using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

using System.Threading;

namespace kr2ks
{
    public class WebRequestGetExample
    {
        public static void Main()
        {


            TcpListener server = new TcpListener(IPAddress.Parse("127.0.0.2"), 13003);
            server.Start();
            while (true)
            {
                //server.AcceptSocket();
                TcpClient client = server.AcceptTcpClient();



                Console.WriteLine("Connected!");


                // Get a stream object for reading and writing

                NetworkStream stream = client.GetStream();
                Byte[] bytesClient = new Byte[256000];
                stream.Read(bytesClient, 0, bytesClient.Length);
                string ClientMessage = null;
                ClientMessage = System.Text.Encoding.ASCII.GetString(bytesClient, 0, bytesClient.Length);
                Console.WriteLine(ClientMessage);
                stream.Write(bytesClient, 0, bytesClient.Length);
                client.Close();

            }

        }
    }
}