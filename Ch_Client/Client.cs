using System.Net.Sockets;
using System.Text;
using System.Net;
using System.Threading;

public class MyTcpClient
{


    public static void Main()
    {
        Mutex mutex = new Mutex();
        LinkedList<string> list = new LinkedList<string>();
        LinkedList<string> Con = new LinkedList<string>();
        bool state = true;
        string message = String.Empty;


        Console.WriteLine("/cIP:Port를 입력해주세요");
        try
        {
            while (state = true)
            {
                string Port = "9000";
                string server = "127.0.0.1";
                string serverInput = Console.ReadLine();


                
                if (serverInput == $"/c {server}:{Port}")
                {
                    Int32 port = 9000;
                    TcpClient client = new TcpClient(server, port);
                    state = false;
                    Console.Clear();
                    list.AddLast("127.0.0.1:9000에 접속시도중... ");
                    
                    foreach (string chat in list)
                    {
                        Console.WriteLine(chat);
                    }
                    Console.Clear();
                    list.AddLast("'수'님께 연결되었습니다. ");
                    foreach (string chat in list)
                    {
                        Console.WriteLine(chat);
                    }
                    while (true)
                    {
                        message = String.Empty;

                        NetworkStream stream = client.GetStream();

                        Thread client_listen = new Thread(() => Listen(list, stream, message));
                        client_listen.Start();


                        Thread client_Write = new Thread(() => write(list, stream, message));
                        client_Write.Start();

                    }
                }
                else if (serverInput == "/q")
                {
                    /*client.Close();*/
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("서버가 연결되지 않았습니다 주소를 올바르게 입력했는지 확인해 주세요");
                    state = true;

                }
            }

        }
        catch (ArgumentNullException e)
        {
            Console.WriteLine("ArgumentNullException: {0}", e);
        }
        catch (SocketException e)
        {
            Console.WriteLine("SocketException: {0}", e);
        }

    }
    public static void Listen(LinkedList<string> list, NetworkStream stream, string message)
    {

        while (true)
        {
            Byte[] data = System.Text.Encoding.UTF8.GetBytes(message);
            data = new Byte[256];
            Int32 bytes = stream.Read(data, 0, data.Length);
            message = System.Text.Encoding.UTF8.GetString(data, 0, bytes);

            if (list.Count < 10)
            {
                Console.Clear();
                list.AddLast("[수] : " + message);
                foreach (string chat in list)
                {
                    Console.WriteLine(chat);
                }
            }
            else
            {
                Console.Clear();
                list.AddLast("[수] : " + message);
                foreach (string chat in list)
                {
                    Console.WriteLine(chat);
                }
                list.RemoveFirst();
            }

        }
    }
    public static void write(LinkedList<string> list, NetworkStream stream, string message)
    {
        while (true)
        {
            message = Console.ReadLine();
            if(message == "/q")
            {
                Environment.Exit(0);
            }
            byte[] byteData = new byte[message.Length];
            byteData = Encoding.Default.GetBytes(message);

            stream.Write(byteData, 0, byteData.Length);
            if (list.Count <= 10)
            {
                Console.Clear();
                list.AddLast("[주] : " + message);
                foreach (string chat in list)
                {
                    Console.WriteLine(chat);
                }
            }
            else if (list.Count > 10)
            {
                Console.Clear();
                list.AddLast("[주] : " + message);
                foreach (string chat in list)
                {
                    Console.WriteLine(chat);
                }
                list.RemoveFirst();
            }        
        }
    }
}
