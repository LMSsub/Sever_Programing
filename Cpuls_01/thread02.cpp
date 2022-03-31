// chatClient.cpp : 이 파일에는 'main' 함수가 포함됩니다. 거기서 프로그램 실행이 시작되고 종료됩니다.
//
//오버로딩이란 ?? 중첩해서 이름을 같이 쓰는 것
//오버라이딩이란?? 부모클래스의 매서드를 하위클래스가 재정의해서 사용

#include <iostream>
#include <thread>
//thread 스레드 라이브러리
#include <chrono>
//chrono 시간관련된 라이브러리
#include <string>
#include <mutex>

using namespace std;

string Atk = "공격적용";
mutex Atk_Damage;

void Hp(string Aname, string Bname)
{
	cout << "\n\n";
	cout << Aname << ":" << Bname << " 시도" << endl;
	cout << Aname << ":" << Bname << " 2회시도" << endl;
	this_thread::sleep_for(std::chrono::milliseconds(1000));
}


void GetDamage(string name) {
	Atk_Damage.lock();
	Atk = name;
	Hp("System", Atk);
	this_thread::sleep_for(std::chrono::milliseconds(5000));//5초
	cout << "System:" << name << " 성공했습습니다";
	Atk_Damage.unlock();
}

void main() {

	thread Alpa(GetDamage,  "Beta를 공격"); //thread2
	thread Beta(GetDamage,  "Alpa를 공격");//thre1

	Alpa.join();
	Beta.join();

}
