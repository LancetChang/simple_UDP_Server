using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public class UDPListener
{
    private int listenPort;
    private string listenIP;
    private bool shutDown = false;
    private UdpClient listener;
    private Socket socket;
    IPEndPoint groupEP;

    public delegate void StartEventHandler(object sender, EventArgs e);
    public static event StartEventHandler ServerStartEvent;

    Thread connectThread;

    public void Run()
    {
        listener = new UdpClient(listenPort);

        groupEP = new IPEndPoint(IPAddress.Parse(listenIP), listenPort);
        string received_data;
        byte[] receive_byte;
        try
        {
            ServerLog.GetInstance().AddItem("Listening...");
            ServerStartEvent.Invoke(null, null);
            while (!shutDown)
            {
                receive_byte = listener.Receive(ref groupEP);
                ServerLog.GetInstance().AddItem(string.Format("Received data from {0}", groupEP.ToString()));
                received_data = Encoding.ASCII.GetString(receive_byte, 0, receive_byte.Length);
                ServerLog.GetInstance().AddItem(string.Format("Data string: \n{0}\n\n", received_data));

                // sending back
                //Send(received_data);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }

        listener.Close();
        ServerLog.GetInstance().AddItem("Listening closed...");
        return;
    }

    public void Send(string sendStr)
    {
        byte[] sendData = new byte[sendStr.Length];
        sendData = Encoding.ASCII.GetBytes(sendStr);
        socket.SendTo(sendData, sendData.Length, SocketFlags.None, groupEP);
    }

    public void Start(string ip, int port)
    {
        listenIP = ip;
        listenPort = port;

        socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

        connectThread = new Thread(new ThreadStart(Run));
        connectThread.Start();
        shutDown = false;
    }

    public void Close()
    {
        shutDown = true;
        listener.Close();

        if (connectThread != null)
        {
            //connectThread.Interrupt();
            //connectThread.Abort();
            connectThread.Join();
        }
    }

    public bool IsAlive()
    {
        if (connectThread != null)
        {
            return connectThread.IsAlive;
        }
        else
        {
            return false;
        }
    }
}
