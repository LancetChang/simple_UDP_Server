using System;
using System.Windows.Forms;
using System.Threading;
using System.Timers;

namespace UdpServer
{
    public partial class Form1 : Form
    {
        private System.Timers.Timer server_log_refresh_timer;
        private UDPListener updServer;

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
            int listenPort;
            bool isNumeric = int.TryParse(ListeningPort.Text, out listenPort);
            if (!isNumeric)
            {
                MessageBox.Show("Please enter Port");
                return;
            }

            if (ListeningIP.Text == "")
            {
                MessageBox.Show("Please enter IP");
                return;
            }

            if (updServer == null)
            {
                updServer = new UDPListener();
                updServer.Start(ListeningIP.Text, Convert.ToInt32(listenPort));

                Button btn = (Button)sender;
                btn.Text = "Stop Server";
            }
            else
            {
                StopListening();

                Button btn = (Button)sender;
                btn.Text = "Start Server";
            }
        }

        private void StopListening()
        {
            Thread.Sleep(1);

            updServer.Close();

            updServer = null;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            server_log_refresh_timer.Enabled = false;
            server_log_refresh_timer.Stop();
            server_log_refresh_timer.Dispose();

            if (updServer != null)
            {
                if (updServer.IsAlive())
                {
                    StopListening();
                }
            }
        }
    }
}
