using System;

namespace f
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<string> list = new LinkedList<string>();
            //키입력값받는 변수
            ConsoleKeyInfo cki;

            //#의 시작위치
            string name = "'주'";
            

            while (true)//무한루프    
            {
                //화면초기화
                //커서를 x,y의 위치로 이동
                //#을 입력
                cki = Console.ReadKey(true);
                //누르는 키를 입력받아 true값이면 넣음
                if (cki.Key == ConsoleKey.T)
                {
                    
                    Console.Write("            ");
                    string message = Console.ReadLine();
                    list.AddLast("[주] : " + message);
                    Console.Clear();
                    foreach (string chat in list)
                    {
                        Console.WriteLine(chat);                       
                    }
                }
                else
                {
                    Console.WriteLine("안눌림");
                }

                /*switch (cki.Key)
                {
                    case ConsoleKey.T: x--; break;

                    case ConsoleKey.RightArrow: x++; break;

                    case ConsoleKey.UpArrow: y--; break;

                    case ConsoleKey.DownArrow: y++; break;

                    case ConsoleKey.Q: return;
                }*/
            }
        }
    }
}

/*                    
                       cki = Console.ReadKey(true);
                       if (cki.Key != ConsoleKey.T)
                        {
                            Console.Write("T 키를 눌러주세요 ");
                            break;
                        }
                        if (cki.Key == ConsoleKey.T)
                        {
                            mutex.ReleaseMutex();
                            Console.WriteLine("움직여");
                            Console.SetCursorPosition(x, y);
                            Console.Write("채팅 :");
                            message = String.Empty;
                            NetworkStream stream = client.GetStream();

                            Thread client_listen = new Thread(() => Listen(list, stream, message, mutex, cki));
                            client_listen.Start();
                            Thread client_Write = new Thread(() => write(list, stream, message, mutex, cki));
                            client_Write.Start();

                            break;
                        }*/
/* //main에 ckil int로 위치 값 설정
        ConsoleKeyInfo cki;
        int x = 0, y = 28;*/