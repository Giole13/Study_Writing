using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatIsClass
{
    public class TrumpCard
    {
        private int[] trumpCardSet;         // 내가 사용할 카드 세트
        private string[] trumpCardMark;     // 트럼프 카드의 마크
        public void SetupTrumpCard()
        {
            trumpCardSet = new int[52];
            for (int i = 0; i < trumpCardSet.Length; i++)
            {
                trumpCardSet[i] = i + 1;
                
            }       //loop: 카드를 셋업하는 루프

            //트럼프 카드의 마크를 셋업
            trumpCardMark = new string[4] { "♥", "♠", "◆", "♣"};


        }       // SetupTrumpCard()

        //! 카드를 섞는 함수
        public void ShuffleCards()
        {
            ShuffleCards(200);
        }       // ShuffleCards 200

        //! 셔플 하고서 카드를 한 장 뽑아서 출력하는 함수
        public int ReRollCard()
        {
            ShuffleCards();
            int result = RollCard();
            return result;
        }

        //! 한장의 카드를 뽑아서 보여주는 함수
        public int RollCard()
        {
            int card = trumpCardSet[0];
            string cardMark = trumpCardMark[(card-1) / 13];
            string cardNumber = Math.Ceiling(card % 13.1).ToString();

            int result;
            int.TryParse(cardNumber, out result);
            switch (cardNumber)
            {
                case "11":
                    cardNumber = "J";
                    break;
                case "12":
                    cardNumber = "Q";
                    break;
                case "13":
                    cardNumber = "K";
                    break;
                default:
                    /*Do nothing*/
                    break;
            }       //switch

            Console.WriteLine("내가 뽑은 카드는 {0}{1} 입니다.", cardMark, cardNumber);
            Console.WriteLine(" ----");
            Console.WriteLine("|{0}{1} |", cardMark, cardNumber);
            Console.WriteLine("|    |");
            Console.WriteLine("|{0}{1} |",cardNumber, cardMark);
            Console.WriteLine(" ----");

            return result;

        }       //RollCard()

        public void PrintCardSet()
        {
            foreach(int card in trumpCardSet)
            {
                Console.Write("{0} ", card);
            }
        }       //PrintCardSet()






        //! 내부에서 사용하는 배열을 1번 
        private int[] shuffleOnce(int[] intArray)
        {
            Random random = new Random();
            int sourIndex = random.Next(0, intArray.Length);
            int destIndex = random.Next(0, intArray.Length);

            int tempVarible = intArray[sourIndex];
            intArray[sourIndex] = intArray[destIndex];
            intArray[destIndex] = tempVarible;

            return intArray;
        }       // SuffleOnce();

        private void ShuffleCards(int howmanyloop)
        {
            for (int i = 0; i < howmanyloop; i++)
            {
                trumpCardSet = shuffleOnce(trumpCardSet);
            }
        }       //ShuffleCards()

    }       // class TrumpCard
}
