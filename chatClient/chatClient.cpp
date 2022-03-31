//목요드라마 석 & 훈
#include <iostream>
#include <thread>
#include <mutex>
#include <string>
#include <chrono>
//3명의 데드락만들기
using namespace std;


class Actor
{
public:
	string name;
	thread th;
	mutex heart;

	Actor() {}
	virtual void Start(Actor* actor) {}
	virtual void Run(Actor* actor) {}
};


class Hoon : public Actor
{
public:
	void(Hoon::* RunPointer)(Actor* actor);

	Hoon()
	{
		name = "훈";
	}

	void Start(Actor* actor)
	{
		RunPointer = &Hoon::Run;
		th = thread(RunPointer, this, actor);
	}

	void Run(Actor* actor) {
		FallinLove(actor);
		Flirting(actor);
		Fuckyou(actor);
	}

	void FallinLove(Actor* actor)
	{
		this_thread::sleep_for(std::chrono::milliseconds(1000));
		cout << "훈 : (나 갑자기..." << actor->name << "을(를) 보니 너무 설렌다....)\n\n";
		
		this_thread::sleep_for(std::chrono::milliseconds(1000));
		heart.lock();
	}

	void Flirting(Actor* actor)
	{
		this_thread::sleep_for(std::chrono::milliseconds(1000));
		cout << "훈 : " << actor->name << "... 내방에서... 라면먹고갈래??\n\n";
	}

	void Fuckyou(Actor* actor)
	{
		this_thread::sleep_for(std::chrono::milliseconds(1000));
		cout << "훈 : (아..." << actor->name << "좀 그렇네)\n\n";
		this_thread::sleep_for(std::chrono::milliseconds(1000));
	}
	
};

class Seok : public Actor
{
public:
	void(Seok::* RunPointer)(Actor* actor);
public:
	Seok() {
		name = "석이";
	}
	void Start(Actor* actor)
	{
		RunPointer = &Seok::Run;
		th = thread(RunPointer, this, actor);
	}
	void Run(Actor* actor) {
		FallinLove(actor);
		Flirting(actor);
		Fuckyou(actor);
	}

	void FallinLove(Actor* actor)
	{
		this_thread::sleep_for(std::chrono::milliseconds(1000));
		cout << "훈 : (나 갑자기..." << actor->name << "을(를) 보니 너무 설렌다....)\n\n";

		this_thread::sleep_for(std::chrono::milliseconds(1000));
	}

	void Flirting(Actor* actor)
	{
		this_thread::sleep_for(std::chrono::milliseconds(1000));
		cout << "훈 : " << actor->name << "... 내방에서... 라면먹고갈래??\n\n";
	}

	void Fuckyou(Actor* actor)
	{
		this_thread::sleep_for(std::chrono::milliseconds(1000));
		cout << "훈 : (아..." << actor->name << "좀 그렇네)\n\n";
		this_thread::sleep_for(std::chrono::milliseconds(1000));
	}
};

class Su : public Actor
{
public:
	void(Su::* RunPointer)(Actor* actor);
public:

	Su()
	{
		name = "수";
	}
	void Start(Actor* actor)
	{
		RunPointer = &Su::Run;
		th = thread(RunPointer, this, actor);
	}
	void Run(Actor* actor) {
		FallinLove(actor);
		Flirting(actor);
		Fuckyou(actor);
	}

	void FallinLove(Actor* actor)
	{
		this_thread::sleep_for(std::chrono::milliseconds(1000));
		cout << "훈 : (나 갑자기..." << actor->name << "을(를) 보니 너무 설렌다....)\n\n";
		this_thread::sleep_for(std::chrono::milliseconds(1000));
	}

	void Flirting(Actor* actor)
	{
		this_thread::sleep_for(std::chrono::milliseconds(1000));
		cout << "훈 : " << actor->name << "... 내방에서... 라면먹고갈래??\n\n";
	}

	void Fuckyou(Actor* actor)
	{
		this_thread::sleep_for(std::chrono::milliseconds(1000));
		cout << "훈 : (아..." << actor->name << "좀 그렇네)\n\n";
		this_thread::sleep_for(std::chrono::milliseconds(1000));
	}
};

int main() //Thread0 PD : 이은석 (main)
{
	Actor* h = new Hoon();
	Actor* Se = new Seok();
	Actor* Su = new Seok();
	h->Start(h);
	Se->Start(Se);
	Su->Start(Su);
	this_thread::sleep_for(std::chrono::milliseconds(1000));
	delete(h);
	return 0;
}


//string taesu = "솔아..";
//mutex taesu_maum;
//
//void Propose(string my_name, string his_name)
//{
//	cout << "\n\n";
//	cout << my_name << ": " << his_name << ".. 당신을 진심으로 사랑합니다.." << endl;
//	cout << my_name << ": " << his_name << "..날 가져줘.." << endl;
//	this_thread::sleep_for(std::chrono::milliseconds(1000));
//}
//
//void GetLove(string name)
//{
//	taesu_maum.lock();
//	taesu = name;
//	Propose("수", taesu);
//	this_thread::sleep_for(std::chrono::milliseconds(5000));//5년
//	cout << "수 :" << name << " 우리 헤어져";
//	taesu_maum.unlock();
//}
//
//void main() //Thread0 PD : 이은석 (main)
//{
//	thread na_seok_hoon(GetLove, "석훈아.."); //Thread2
//	thread oh_jeong_seok(GetLove, "정석아.."); //Thread1 
//
//	na_seok_hoon.join();
//	oh_jeong_seok.join();
//}