using System.Collections.Generic;
using System.Windows.Forms;

class ServerLog:Form
{
    private static Queue<string> Log = new Queue<string>();
    private static ServerLog Instance;

    public static ServerLog GetInstance()
    {
        if (Instance == null)
        {
            Instance = new ServerLog();
        }

        return Instance;
    }

    public void AddItem(string str)
    {
        Log.Enqueue(str);
    }

    public string PopItem()
    {
        if (Log.Count > 0)
            return Log.Dequeue();
        else
            return null;
    }
}
