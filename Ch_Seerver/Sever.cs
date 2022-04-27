using System;
using System.Text;
using System.Net;
using System.Net.Sockets;



class MyTcpListener
{
    static string Exit = "/q";
    public static void Main()
    {
        ConsoleKeyInfo cki;
        Mutex mutex = new Mutex(false);
        LinkedList<string> list = new LinkedList<string>();

        list.AddLast("Waiting Connection...");
        Console.Clear();
        foreach (string chat in list)
        {
            Console.WriteLine(chat);
        }
        TcpListener server = null;
        try
        {
            Int32 port = 9000;
            IPAddress localAddr = IPAddress.Parse("127.0.0.1");

            server = new TcpListener(localAddr, port);

            server.Start();

            String data = null;

            string message = String.Empty;

            if (true)
            {
                TcpClient client = server.AcceptTcpClient();

                list.AddLast("'수' 님이 127.0.0.1에서 접속하셨습니다");
                Console.Clear();
                foreach (string chat in list)
                {
                    Console.WriteLine(chat);
                }

                while (true)
                {
                    cki = Console.ReadKey(true);
                    Byte[] bytes = System.Text.Encoding.Default.GetBytes(message);

                    NetworkStream stream = client.GetStream();

                    Thread server_listen = new Thread(() => Listen(list, bytes, stream,mutex,client,server));
                    server_listen.Start();

                    Thread client_write = new Thread(() => write(list, stream,mutex,cki));

                    client_write.Start();


                }
            }
        }
        catch (SocketException e)
        {
           /* Console.WriteLine("SocketException: {0}", e);*/
        }

        /*Console.WriteLine("\n'수'님과의 연결이 끊어졌습니다...\nEnter를 눌러 콘솔창을 종료해주세요");*/
    }



    public static void Listen(LinkedList<string> list, Byte[] bytes, NetworkStream stream, Mutex mutex, TcpClient client, TcpListener server)
    {
        while (true)
        {
            bytes = new Byte[256];

            String responseData = String.Empty;
            Int32 byt = stream.Read(bytes, 0, bytes.Length);
            responseData = System.Text.Encoding.UTF8.GetString(bytes, 0, byt);


            if (list.Count < 10)
            {
                if (responseData == Exit)
                {
                    Environment.Exit(0);
                }

                Console.Clear();
                list.AddLast("[주] : " + responseData);
                foreach (string chat in list)
                {
                    Console.WriteLine(chat);
                }
            }
            else
            {
                if (responseData == Exit)
                {
                    Environment.Exit(0);
                }
                list.AddLast("[주] : " + responseData);
                Console.Clear();
                foreach (string chat in list)
                {
                    Console.WriteLine(chat);
                }

                list.RemoveFirst();
            }
            break;
        }



    }
    public static void write(LinkedList<string> list, NetworkStream stream, Mutex mutex, ConsoleKeyInfo cki)
    {
        while (true)
        {
            if (cki.Key == ConsoleKey.T)
            {
                Console.SetCursorPosition(0, 29);
                Console.Write("채팅 :  ");
                string message = Console.ReadLine();
                byte[] byteData = new byte[message.Length];
                byteData = Encoding.Default.GetBytes(message);
                stream.Write(byteData, 0, byteData.Length);

                if (list.Count <= 10)
                {
                    if (message == Exit)
                    {
                        Environment.Exit(0);
                    }

                    list.AddLast("[수] : " + message);
                    Console.Clear();
                    foreach (string chat in list)
                    {
                        Console.WriteLine(chat);
                    }
                }
                else if (list.Count > 10)
                {
                    if (message == Exit)
                    {
                        Environment.Exit(0);
                    }

                    list.RemoveFirst();

                    list.AddLast("[수] : " + message);
                    Console.Clear();
                    foreach (string chat in list)
                    {
                        Console.WriteLine(chat);
                    }
                }
                break;
            }
            else
            {
                break;
            }
        }
    }
}