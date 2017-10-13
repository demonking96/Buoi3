using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
namespace NguyenHoDucNhan_Buoi2_Bai2
{
    public partial class Form1 : Form
    {
        Socket client;
        IPEndPoint ipep;
        EndPoint remote;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9050);
            remote = (EndPoint)ipep;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Kéo";
            int a = 0;
            byte[] send = BitConverter.GetBytes(a);
            client.SendTo(send, remote);
            byte[] rec = new byte[20];
            remote = (EndPoint)ipep;
            client.ReceiveFrom(rec, ref remote);
            textBox2.Text = Encoding.ASCII.GetString(rec);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Búa";
            int b = 1;
            byte[] send = BitConverter.GetBytes(b);
            client.SendTo(send, remote);
            byte[] rec = new byte[20];
            remote = (EndPoint)ipep;
            client.ReceiveFrom(rec, ref remote);
            textBox2.Text = Encoding.ASCII.GetString(rec);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Bao";
            int c = 2;
            byte[] send = BitConverter.GetBytes(c);
            client.SendTo(send, remote);
            byte[] rec = new byte[20];
            remote = (EndPoint)ipep;
            client.ReceiveFrom(rec, ref remote);
            textBox2.Text = Encoding.ASCII.GetString(rec);
        }
    }
}
