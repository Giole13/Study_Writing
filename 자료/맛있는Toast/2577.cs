using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toast
{
    internal class _2577
    {
        public void Number()
        {
            //값 받기
            int number1 = 0;
            int number2 = 0;
            int number3 = 0;
            int.TryParse(Console.ReadLine(), out number1);
            int.TryParse(Console.ReadLine(), out number2);
            int.TryParse(Console.ReadLine(), out number3);
            int allMultiple = number1 * number2 * number3;
            string allMultistr = allMultiple.ToString();
            

            //비교배열
            int[] numCompare = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] result = new int[10];
            int index = 0;

            int[] numbers = new int[30];
            while (allMultiple > 0)
            {
                numbers[index] = allMultiple % 10;
                allMultiple = allMultiple / 10;
                ++index;
            }

            for (int index1 = 0; index1 < 10; ++index1)
            {
                for (int index2 = 0; index2 < allMultistr.Length; ++index2)
                {
                    if (numCompare[index1] == numbers[index2])
                    {
                        ++result[index1];
                    }
                }
            }

            foreach (int i in result)
            {
                Console.WriteLine(i);
            }


        }
    }
}
