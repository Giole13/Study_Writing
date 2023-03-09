using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame
{
    class Monster
    {
        Random rand = new Random();

        public string name;
        public int hp;
        public int damage;
        public int defence;
        public string[] item;


        public void Move(string name)
        {
            Console.WriteLine("{0}가 움직였다!", name);
        }
        public void Attack(string name, int damage)
        {
            Console.WriteLine("{0}이 공격하고 {1} 데미지를 주었다!.", name, damage);
        }
        public void MoveAndAttack()
        {
            this.Move(this.name);
            this.Attack(this.name, this.damage);
        }

        public string HpCheck()     //hp를 체크해서 0이하가 된다면 죽고 아이템을 반환
        {
            Console.WriteLine("==============================\n");
            Console.WriteLine("{0}가(이) 죽었다!!", this.name);
            return DropItem(rand.Next(0, 1 + 1));

        }

        private string DropItem(int index)      //아이템을 드랍하는 함수
        {
            Console.WriteLine("{0} 아이템을 떨어뜨렸다!", this.item[index]);
            Console.ReadLine();
            return this.item[index];
        }
    }

    class Slime : Monster
    {
        public Slime()
        {
            this.name = "슬라임";
            this.hp = 100;
            this.damage = 2;
            this.defence = 1;
            this.item = new string[] { "슬라임 핵", "끈적한 점액" };
        }
    }

    class Wolf : Monster
    {
        public Wolf()
        {
            this.name = "하얀 늑대";
            this.hp = 300;
            this.damage = 10;
            this.defence = 4;
            this.item = new string[] { "늑대의 털", "늑대의 송곳니" };
        }
    }

    class Zombie : Monster
    {
        public Zombie()
        {
            this.name = "좀비";
            this.hp = 200;
            this.damage = 20;
            this.defence = 1;
            this.item = new string[] { "좀비가 입었던 옷", "좀비가 신고있었던 신발" };
        }
    }

    class Player
    {
        public string name;
        public int hp;
        public int damage;
        public int defence;
        public string[] inventory;

        public Player(string name)      //이름을 입력 받는 함수 //생성자에서 이름 정함
        {
            this.name = name;
        }

        //아이템을 획득하는 함수
        public void AcquiredItem(string item)
        {
            for (int i = 0; i < inventory.Length; ++i)
            {
                if (string.IsNullOrEmpty(this.inventory[i]))
                {
                    this.inventory[i] = item;
                    Console.WriteLine("{0}번의 인벤토리에 {1}을(를) 저장했습니다!", i + 1, item);
                    break;
                }
            }
        }
    }       //class Player

    class BattleSystem
    {
        public bool BattleResult(string playerName, int playerHp, int playerAtk,
            string monsterName, int monsterHp, int monsterAtk, out int playerHpresult)      //배틀 결과를 bool 형식으로 반환하는 함수
        {
            bool result = false;    //플레이어의 승리 패배 반환 변수
            bool repeat = true;     //반복변수

            while (repeat)
            {
                Console.WriteLine("==============================\n");
                Console.WriteLine("{0}가(이) 공격했다!", playerName);     //플레이어 턴
                Console.ReadLine();
                Console.WriteLine("{0}에게 {1}만큼의 데미지를 주었다!", monsterName, playerAtk);
                monsterHp -= playerAtk;
                Console.WriteLine("{0}의 체력 {1}    {2}의 체력 {3}", playerName, playerHp, monsterName, monsterHp);
                Console.ReadLine();
                if (playerHp <= 0)      //플레이어가 죽을 시 false
                {
                    result = false;
                    playerHpresult = playerHp;
                    return result;
                    break;
                }
                else if (monsterHp <= 0)    //플레이어가 승리시 true
                {
                    result = true;
                    playerHpresult = playerHp;
                    return result;
                    break;
                }
                Console.WriteLine("==============================\n");
                Console.WriteLine("{0}가(이) 공격했다!", monsterName);    //몬스터 턴
                Console.ReadLine();
                Console.WriteLine("{0}에게 {1}만큼의 데미지를 주었다!", playerName, monsterAtk);
                playerHp -= monsterAtk;
                Console.WriteLine("{0}의 체력 {1}    {2}의 체력 {3}", playerName, playerHp, monsterName, monsterHp);
                Console.ReadLine();

                if (playerHp <= 0)      //플레이어가 죽을 시 false
                {
                    result = false;
                    playerHpresult = playerHp;
                    return result;
                    break;
                }
                else if (monsterHp <= 0)    //플레이어가 승리시 true
                {
                    result = true;
                    playerHpresult = playerHp;
                    return result;
                    break;
                }
            }       //loop: 플레이어나 몬스터의 체력이 0이 될때까지
            playerHpresult = playerHp;
            return result;
        }       //battleReslut();
    }
}       
