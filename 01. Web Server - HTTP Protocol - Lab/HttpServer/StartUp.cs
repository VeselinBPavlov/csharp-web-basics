namespace HttpServer
{
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            const string NewLine = "\r\n";

            TcpListener tcpListener = new TcpListener(IPAddress.Loopback, 12345);

            tcpListener.Start();

            while (true)
            {
                TcpClient client = tcpListener.AcceptTcpClient();
                using (NetworkStream stream = client.GetStream())
                {
                    byte[] requestBytes = new byte[10000];
                    int readBytes = stream.Read(requestBytes, 0, requestBytes.Length);
                    string stringRequest = Encoding.UTF8.GetString(requestBytes, 0, readBytes); 
                    Console.WriteLine(new string('=', 70));
                    Console.WriteLine(stringRequest);

                    string responseBody = "<h1>Hello, User!</h1>";   
                    var response = "HTTP/1.1 200 OK" + NewLine +
                                   "Content-Type: text/html" + NewLine +
                                   "Server: Custom Server/1.0" + NewLine +
                                   $"Content-Length: {responseBody.Length}" + NewLine + NewLine +
                                   responseBody;                                                  

                    byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                    stream.Write(responseBytes, 0, responseBytes.Length);
                }
            }
        }
    }
}
