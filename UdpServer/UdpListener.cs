using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class UDPListener
{
    private const int listenPort = 7058;
    private static string ip = "192.168.137.1";
    private static bool done = false;
    private static UdpClient listener;

    public delegate void StartEventHandler(object sender, EventArgs e);
    public static event StartEventHandler ServerStartEvent;

    public static void Run()
    {
        listener = new UdpClient(listenPort);

        IPEndPoint groupEP = new IPEndPoint(IPAddress.Parse(ip), listenPort);
        string received_data;
        byte[] receive_byte;
        try
        {
            ServerLog.GetInstance().AddItem("Listening...");
            ServerStartEvent.Invoke(null, null);
            while (!done)
            {
                receive_byte = listener.Receive(ref groupEP);
                ServerLog.GetInstance().AddItem(string.Format("Received data from {0}", groupEP.ToString()));
                received_data = Encoding.ASCII.GetString(receive_byte, 0, receive_byte.Length);
                ServerLog.GetInstance().AddItem(string.Format("Data string: \n{0}\n\n", received_data));
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

    public static void Start()
    {
        done = false;
    }

    public static void Close()
    {
        done = true;
        listener.Close();
    }
}
