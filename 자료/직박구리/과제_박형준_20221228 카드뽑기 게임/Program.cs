using System;
using WhatIsClass;

namespace CardDrawingGame
{
    //   - 카드 뽑기 게임을 작성해서 제출.
    //- 컴퓨터가 2장을 뽑아서 보여줌(패스하려면 0포인트 배팅)
    //- 플레이어가 베팅을 함. (패스 가능)
    //- 플레이어가 뽑은 카드가 컴퓨터가 뽑은 2장의 카드 사이에 있는 카드라면
    //      플레이어가 2배 벌어감
    //- 플레이어가 뽑은 카드가 컴퓨터가 뽑은 2장의 카드 사이에 없다면
    //      플레이어는 베팅금액을 잃음.
    //- 플레이어는 10,000 포인트 들고 게임을 시작함.
    //- 카드의 대, 소 비교는 오직 숫자로만.
    //- 중복이 나오면 패스하는 걸로
    //- 게임 종료는 100,000 포인트를 벌거나, 모두 잃을 때 게임 종료
    public class Program
    {
        static void Main(string[] args)
        {
            int userMoney = 10_000;                //유저가 가지고 있는 돈의 수
            bool userLife = true;                  //유저의 돈에 따라 목숨 결정

            GameRule compare = new GameRule();     //비교클래스를 사용하기 위한 선언
            TrumpCard trump = new TrumpCard();     //트럼프 클래스를 사용하기 위한 선언

            while (userLife)
            {
                trump.SetupTrumpCard();             //트럼프 카드 준비

                int num1 = trump.ReRollCard();      //첫 카드
                int num2 = trump.ReRollCard();      //두번째 카드

                int battingMoney = 0;               //배팅금액 변수
                bool intWhether = false;            //숫자만 입력하게 만들 변수
                bool outcome = false;               //true 면 승리 false 면 패배



                Console.WriteLine("[당신은 총 {0} 원을 가지고 있습니다!]\n[총 10만원을 모으면 승리!!]\n[돈을 전부 잃어버리면 패배!!]\n[배팅을 하고싶지 않다면! 0원을 입력해주세요!]", userMoney);
                Console.Write("배팅 금액 : ");
                intWhether = int.TryParse(Console.ReadLine(), out battingMoney);


                while(intWhether == false || userMoney < battingMoney || battingMoney < 0)          //자신의 현재 금액보다 높거나 음수, 숫자가 아닌 것을 입력했을경우
                {
                    Console.Write("배팅할 금액을 다시 써주세요 !! : ");
                    intWhether = int.TryParse(Console.ReadLine(), out battingMoney);
                }

                if(battingMoney == 0)           //배팅 금액이 0원이라면? -> 패스
                {
                    Console.Clear();
                    Console.WriteLine("이번은 패스!");
                    continue;
                }

                Console.WriteLine();
                int compareCard = trump.ReRollCard();       //비교카드
                
                Console.Write("비교 카드가 나왔네요!\n");
                Console.ReadLine();

                //비교를 해서 게임 결과를 알려준 후에 승 패를 결정하자
                //승패를 반환하는 bool 함수
                outcome = compare.Compare(num1, num2, compareCard);         //카드 두장을 넣고 비교카드를 넣어서 승리하면 true 패배하면 false 반환

                //돈의 가감수를 결정하는 int 함수
                userMoney = userMoney + compare.Correction(outcome, battingMoney);

                if(outcome == true)         //게임 결과가 이겼다면?
                {
                    Console.WriteLine("이겼다!");
                    Console.WriteLine("배팅금액의 두배인 {0} 원을 벌었다!", battingMoney * 2);
                    Console.WriteLine("당신의 현 재산 : {0}", userMoney);
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("게임에서 졌다..");
                    Console.WriteLine("배팅금액을 모두 잃었다..");
                    Console.WriteLine("당신의 현 재산 : {0}", userMoney);
                    Console.ReadLine();
                }

                Console.Clear();                    //콘솔 비우기
                if (userMoney <= 0)                 //유저 머니가 없다면?
                {
                    userLife = false;
                    Console.WriteLine("당신은 돈이 없어서 게임에서 패배 하였습니다 ㅠㅠ");
                }
                else if (100000 <= userMoney)       //유저 머니가 10만원이 넘거나 같으면?
                {
                    userLife = false;
                    Console.WriteLine("당신은 부자가 되었습니다!! 와 !! 축하합니다! \n게임승리!");
                }
            }       //while(gameLife)



        }       //Main()
    }       //Class
}