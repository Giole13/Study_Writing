using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toast
{
    internal class _1337
    {
        public void CorrectArray()
        {
            //숫자 받기
            string repeatstr = Console.ReadLine();
            int repeatnum;
            int.TryParse(repeatstr, out repeatnum);
            int[] array = new int[100];
            int[] compare = new int[5];

            for (int i = 0; i < repeatnum; ++i)
            {
                repeatstr = Console.ReadLine();
                int.TryParse(repeatstr, out array[i]);
            }


            //준비단계
            int result = 0;
            int cnt = 0;
            //비교단계
            for (int x = 0; x < repeatnum; ++x)
            {
                int z = 0;
                for (int i = 0; i < 5; ++i)
                {
                    compare[i] = array[x] + i;
                }

                for (int i = 0; i < 5; ++i)
                {
                    if (compare[i] == array[z + 1])
                    {
                        ++z;
                        ++cnt;
                        break;
                    }
                }
                result = Math.Max(result,cnt);
            }


            
            Console.WriteLine(5-result);
        }
    }
}
