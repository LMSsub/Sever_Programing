//#include <iostream>
//#include <thread>
////thread 스레드 라이브러리
//#include <chrono>
////chrono 시간관련된 라이브러리
//using namespace std;
//
//int trigger;
//void Alpa()
//{
//    while (trigger == 0) {
//        cout << "알파\n";
//        this_thread::sleep_for(std::chrono::milliseconds(1000));
//    }
// }
//    
//void Beta()
//{
//    while (trigger == 0)
//    {
//        this_thread::sleep_for(std::chrono::milliseconds(500));
//        cout << "베타\n";
//        this_thread::sleep_for(std::chrono::milliseconds(500));
//    }
//    
//}
//
////cout은 콘솔창으로 내보내는 것이다
////cin은 입력을 받는 것
//int main()
//{
//    trigger = 0;
//    
//    std::thread A(Alpa);
//    std::thread B(Beta);
//
//    while (trigger ==0)
//    {
//        cin >> trigger;
//     }
//
//    A.join();
//    B.join();
//    //join은 스레드가 일을 다할때까지 기다려줌
//
//    cout << "준비 완료\n";
//    //join은 스레드가 죽을때까지 기다려주는 명령어
//
//    return 0;
//}
