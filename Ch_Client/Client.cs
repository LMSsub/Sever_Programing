using System.Net.Sockets;

public class MyTcpClient
{


    public static void Main()
    {
        bool state = true;
        
        Console.WriteLine("나는클라이언트 IP를 입력해주세요 127.0.0.1");
        try
        {
            while (state = true)
            {
                /*string server = "127.0.0.1";*/
                string server = Console.ReadLine();
            
                if (server == "127.0.0.1")
                {
                    state = false;
                    Console.WriteLine("127.0.0.1에 접속시도중... ");
                    Console.WriteLine("'주'님께 연결되었습니다.");
                    Int32 port = 13000;
                    TcpClient client = new TcpClient(server, port);
                    while (server == "127.0.0.1")
                    {
                        string message = Console.ReadLine();
                        // TcpClient를 만듭니다.
                        // 이 클라이언트가 작동하려면 TcpServer가 필요합니다.
                        // 서버, 포트에서 지정한 것과 동일한 주소에 연결
                        // combination.%
                        if (message == "/q")
                        {
                            client.Close();
                            Environment.Exit(0);
                        }
                        //전달된 메시지를 ASCII로 변환하고 바이트 배열로 저장합니다.
                        Byte[] data = System.Text.Encoding.Default.GetBytes(message);
                        
                        Console.WriteLine("[수]클라: {0}", message);
                        // 읽고 쓰기 위한 클라이언트 스트림을 가져옵니다.
                        // Stream stream = client.GetStream();
                        NetworkStream stream = client.GetStream();
                        // 연결된 TcpServer로 메시지를 보냅니다.
                        
                        stream.Write(data, 0, data.Length);
                        // TcpServer.response를 수신합니다.
                        // 응답 바이트를 저장할 버퍼입니다.
                        data = new Byte[256];
                        // 응답 UTF8 표현을 저장할 문자열입니다.
                        // TcpServer 응답 바이트의 첫 번째 배치를 읽습니다.
                        
                        String responseData = String.Empty;
                        Int32 bytes = stream.Read(data, 0, data.Length);
                        responseData = System.Text.Encoding.UTF8.GetString(data, 0, bytes);
                        Console.WriteLine("[주]서버: {0}", responseData);
                        /*string server = "127.0.0.1";*/
                        

                    }
                }
                else if (server == "/q")
                {
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
}