using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;


namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 9050);
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            server.Bind(ipep);

            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
            EndPoint Remote = (EndPoint)(sender);

            byte[] data = new byte[4];
            server.ReceiveFrom(data, ref Remote);
            int clientChoosen = BitConverter.ToInt32(data, 0);
            int serverChoosen;
            Random rand = new Random();
            serverChoosen = rand.Next(0, 2);
            if (clientChoosen == serverChoosen)
            {
                byte[] send = Encoding.ASCII.GetBytes("Hòa");
                server.SendTo(send, Remote);
            }
            else if (clientChoosen == 0 && serverChoosen == 1)
            {
                byte[] send = Encoding.ASCII.GetBytes("Thua");
                server.SendTo(send, Remote);
            }
            else if (clientChoosen == 0 && serverChoosen == 2)
            {
                byte[] send = Encoding.ASCII.GetBytes("Thắng");
                server.SendTo(send, Remote);
            }
            else if (clientChoosen == 1 && serverChoosen == 00)
            {
                byte[] send = Encoding.ASCII.GetBytes("Thắng");
                server.SendTo(send, Remote);
            }
            else if (clientChoosen == 1 && serverChoosen == 2)
            {
                byte[] send = Encoding.ASCII.GetBytes("Thua");
                server.SendTo(send, Remote);
            }
            else if (clientChoosen == 2 && serverChoosen == 0)
            {
                byte[] send = Encoding.ASCII.GetBytes("Thua");
                server.SendTo(send, Remote);
            }
            else if (clientChoosen == 2 && serverChoosen == 1)
            {
                byte[] send = Encoding.ASCII.GetBytes("Thắng");
                server.SendTo(send, Remote);
            }
        }
    }
}
