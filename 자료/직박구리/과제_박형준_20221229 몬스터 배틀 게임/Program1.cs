using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame
{
    internal class Program1
    {
        public static void Main()
        {
            /**
            * 인벤토리 구현 완료
            * 플레이어 및 몬스터 hp에 따른 승패 구현 완료
            * 몬스터가 죽으면 아이템을 드롭하고 드롭한 아이템을 인벤토리에 넣는 함수 구현완료
            * 플레이어의 hp가 0이 될 때까지 반복함
            */
            Slime monsterSlime = new Slime();           //몬스터들
            Zombie monsterZombie = new Zombie();
            Wolf monsterWolf = new Wolf();
            BattleSystem battleSystem = new BattleSystem(); //배틀 시스템 클래스
            bool playerLife = true;     //플레이어의 생명
            bool gameoutcome = false;   //플레이어가 승리했는지 패배했는지 알려주는 변수
            Random rand = new Random(); //랜덤클래스
            int randomMonster = 0;

            Console.WriteLine("Press Any Key!");
            Console.ReadLine();
            Console.Clear();

            Console.Write("당신의 이름을 입력해주세요! : ");

            Player playernum1 = new Player(Console.ReadLine()); //플레이어 이름 설정

            Console.WriteLine("당신의 이름은 {0}입니다!", playernum1.name);

            playernum1.hp = 1000;                       //플레이어 체력
            playernum1.damage = 50;                     //플레이어 데미지
            playernum1.inventory = new string[20];      //인벤토리 공간 개수 지정

            while (playerLife)      //플레이어의 생명이 false 되면 게임 오버
            {
                Console.Clear();
                Console.WriteLine("인벤토리\n");
                foreach (string item in playernum1.inventory)   //현재 인벤토리 출력
                {
                    Console.WriteLine(item);
                }

                randomMonster = rand.Next(1, 3 + 1);

                switch (randomMonster)      //몬스터 랜덤 스폰
                {
                    case 1:
                        gameoutcome = battleSystem.BattleResult(playernum1.name, playernum1.hp, playernum1.damage,
                            monsterSlime.name, monsterSlime.hp, monsterSlime.damage, out playernum1.hp);
                        if (gameoutcome == true)    //플레이어 승리!
                        {
                            playernum1.AcquiredItem(monsterSlime.HpCheck());
                        }
                        break;
                    case 2:
                        gameoutcome = battleSystem.BattleResult(playernum1.name, playernum1.hp, playernum1.damage,
                            monsterZombie.name, monsterZombie.hp, monsterZombie.damage, out playernum1.hp);
                        if (gameoutcome == true)    //플레이어 승리!
                        {
                            playernum1.AcquiredItem(monsterZombie.HpCheck());
                        }
                        break;
                    case 3:
                        gameoutcome = battleSystem.BattleResult(playernum1.name, playernum1.hp, playernum1.damage,
                            monsterWolf.name, monsterWolf.hp, monsterWolf.damage, out playernum1.hp);
                        if (gameoutcome == true)    //플레이어 승리!
                        {
                            playernum1.AcquiredItem(monsterWolf.HpCheck());
                        }
                        break;
                    default:
                        break;
                }

                if (gameoutcome == false)  //플레이어 패배
                {
                    playerLife = false;
                }
            }

            Console.Clear();
            Console.WriteLine("당신은 사망했습니다");
        }       //Main()
    }       //Class Program1
}

