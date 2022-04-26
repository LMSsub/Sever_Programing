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
                // Set the TcpListener on port 13000. 포트 13000에서 TcpListener를 설정합니다.
                Int32 port = 9000;
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");

                // TcpListener server = new TcpListener(port); TcpListener 서버 = 새로운 TcpListener(포트);
                server = new TcpListener(localAddr, port);

                // Start listening for client requests. 클라이언트 요청 수신을 시작합니다.
                server.Start();

                // Buffer for reading data 데이터 읽기 버퍼
                Byte[] bytes = new Byte[256];
                String data = null;
                // Enter the listening loop. 수신 대기 루프를 입력합니다.
                if  (true)
                {
                    // Perform a blocking call to accept requests. 요청을 수락하려면 차단 호출을 수행합니다.
                    // You could also use server.AcceptSocket() here. 서버를 사용할 수도 있습니다.여기서 소켓()을 수락합니다.
                    TcpClient client = server.AcceptTcpClient();
                    list.AddLast("'수' 님이 127.0.0.1에서 접속하셨습니다");
                    Console.Clear();
                    foreach (string chat in list)
                {
                    Console.WriteLine(chat);
                }
                    // 읽고 쓰기 위한 스트림 객체 가져오기
                    NetworkStream stream = client.GetStream();
                    int i;
                    // 클라이언트가 보낸 모든 데이터를 수신하는 루프
                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                {  // Translate data bytes to a ASCII string.

                    data = System.Text.Encoding.UTF8.GetString(bytes, 0, i);


                    list.AddLast("[수] :" + data);
                    Console.Clear();
                    foreach (string chat in list)
                    {
                        Console.WriteLine(chat);
                    }
                    data = Console.ReadLine();
                    // Process the data sent by the client.

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
            // Stop listening for new clients.
            server.Stop();
        }

        Console.WriteLine("\n'수'님과의 연결이 끊어졌습니다...\nEnter를 눌러 콘솔창을 종료해주세요");
    }
}