using System.Net;
using System.Net.Sockets;


class MyTcpListener
{
    public static void Main()
    {

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

                Byte[] bytes = new Byte[256];
                String data = null;
                if  (true)
                {
                    TcpClient client = server.AcceptTcpClient();
                    list.AddLast("'수' 님이 127.0.0.1에서 접속하셨습니다");
                    Console.Clear();
                    foreach (string chat in list)
                {
                    Console.WriteLine(chat);
                }
                    NetworkStream stream = client.GetStream();
                    int i;
                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                {  

                    data = System.Text.Encoding.UTF8.GetString(bytes, 0, i);


                    list.AddLast("[수] :" + data);
                    Console.Clear();
                    foreach (string chat in list)
                    {
                        Console.WriteLine(chat);
                    }
                    data = Console.ReadLine();

                    byte[] msg = System.Text.Encoding.UTF8.GetBytes(data);
                    list.AddLast("[주] :" + data);
                    Console.Clear();
                    foreach (string chat in list)
                    {
                        Console.WriteLine(chat);
                    }

                    // Send back a response.
                    stream.Write(msg, 0, msg.Length);
                }
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
        finally
        {
            server.Stop();
        }

        Console.WriteLine("\n'수'님과의 연결이 끊어졌습니다...\nEnter를 눌러 콘솔창을 종료해주세요");
    }
}