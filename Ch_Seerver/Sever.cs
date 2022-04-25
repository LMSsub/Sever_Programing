using System.Net;
using System.Net.Sockets;


class MyTcpListener
{
    public static void Main()
    {

        Console.WriteLine("Waiting Connection...");
        TcpListener server = null;
        while (true)
        {
            try
            {
                // Set the TcpListener on port 13000. 포트 13000에서 TcpListener를 설정합니다.
                Int32 port = 13000;
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");

                // TcpListener server = new TcpListener(port); TcpListener 서버 = 새로운 TcpListener(포트);
                server = new TcpListener(localAddr, port);

                // Start listening for client requests. 클라이언트 요청 수신을 시작합니다.
                server.Start();

                // Buffer for reading data
                Byte[] bytes = new Byte[256];
                String Cdata = null;

                // Enter the listening loop.
                while (true)
                {
                    Console.Write("잠시만 기다려 주세요 연결 중입니다.... \n");

                    // Perform a blocking call to accept requests.
                    // You could also use server.AcceptSocket() here.
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("'수' 님이 127.0.0.1에서 접속하셨습니다");

                    Cdata = null;
                    

                    // 읽고 쓰기 위한 스트림 객체 가져오기
                    NetworkStream stream = client.GetStream();

                    int i;

                    // 클라이언트가 보낸 모든 데이터를 수신하는 루프
                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        // Translate data bytes to a UTF8 string.
                        Cdata = System.Text.Encoding.UTF8.GetString(bytes, 0, i);
                        Console.WriteLine("[수]클라: {0}", Cdata);
                        // 클라이언트가 보낸 데이터를 처리합니다.
                        Cdata = Cdata.ToUpper();
                        string Sdata = Console.ReadLine();

                        byte[] msg = System.Text.Encoding.UTF8.GetBytes(Cdata);

                        // 응답을 다시 보냅니다.
                        stream.Write(msg, 0, msg.Length);
                        Console.WriteLine("[주]서버: {0}", Sdata);
                    }

                    // 종료 및 연결 종료
                    /*client.Close();*/
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
        }
        
       /* finally
        {
            // Stop listening for new clients.
            server.Stop();
        }*/

        /*Console.WriteLine("\nHit enter to continue...");
        Console.Read();*/
    }
}