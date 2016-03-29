using System;
using System.Windows.Forms;
using System.Threading;
using System.Timers;

namespace UdpServer
{
    public partial class Form1 : Form
    {
        private Thread UdpListenerThread;
        private System.Timers.Timer server_log_refresh_timer;

        public Form1()
        {
            InitializeComponent();

            // timer
            server_log_refresh_timer = new System.Timers.Timer(500);
            server_log_refresh_timer.Elapsed += OnTimedEvent;
            server_log_refresh_timer.AutoReset = true;
            server_log_refresh_timer.Enabled = true;

            // callback
            UDPListener.ServerStartEvent += new UDPListener.StartEventHandler(ServerStart);
        }

        private void ServerStart(object sender, EventArgs e)
        {

        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                string log = ServerLog.GetInstance().PopItem();
                if (log != null)
                {
                    server_log.Items.Add(log);
                }
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (UdpListenerThread != null && UdpListenerThread.IsAlive)
            {
                StopListening();

                Button btn = (Button)sender;
                btn.Text = "Start Server";
            }
            else
            {
                UDPListener.Start();
                UdpListenerThread = new Thread(new ThreadStart(UDPListener.Run));
                UdpListenerThread.Start();
                Button btn = (Button)sender;
                btn.Text = "Stop Server";
            }
        }

        private void StopListening()
        {
            Thread.Sleep(1);

            UDPListener.Close();

            UdpListenerThread.Join();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (UdpListenerThread.IsAlive)
            {
                StopListening();
            }

            server_log_refresh_timer.Stop();
            server_log_refresh_timer.Dispose();
        }
    }
}
