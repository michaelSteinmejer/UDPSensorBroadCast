using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace UDPSensorBroadCast
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creates a UdpClient for reading incoming data.
            UdpClient udpClient = new UdpClient();


            //Creates an IPEndPoint to record the IP Address and port number of the sender.  
            IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Broadcast, 9876);

            try
            {
                // Blocks until a message is received on this socket from a remote host (a client).
                Console.WriteLine("Server is blocked");
                while (true)
                {


                    Random rnd = new Random();
                    double number =(double) rnd.Next(10000, 90000)/1000.00;

                    //Console.WriteLine("Received from: " + clientName.ToString() + " " + text.ToString());


                    Byte[] sendBytes = Encoding.ASCII.GetBytes("sensor" + number +"\r\n");

                    udpClient.Send(sendBytes, sendBytes.Length, RemoteIpEndPoint);

                    Thread.Sleep(100);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());

            }
        }
    }
}
