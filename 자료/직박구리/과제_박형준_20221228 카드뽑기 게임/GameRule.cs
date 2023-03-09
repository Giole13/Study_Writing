using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardDrawingGame
{
    internal class GameRule
    {
        public bool Compare(int num1, int num2, int compare)
        {
            bool result = false;

            if(num1 < compare && compare < num2)
            {
                result = true;
            }
            else if(num1 > compare && compare > num2)
            {
                result = true;
            }
            else { result = false; }

            return result;
        }

        public int Correction(bool outcome, int battingMoney)
        {
            int result = 0;

            if(outcome == true)
            {
                result = battingMoney * 2;
            }
            else { result = battingMoney * -1; }

            return result;
        }
    }
}
