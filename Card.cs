using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Card
    {
        public int Num { get; set; }
        public char Symbol { get; set; }
        public bool IsDrawn { get; set; }

        public Card(int num, char symbol)
        {
            Num = num;
            Symbol = symbol;
            IsDrawn = false;
        }

        public override string ToString()
        {
            string str = "";
            switch(Num)
            {
                case (11):
                    str = "J";
                    break;
                case (12):
                    str = "Q";
                    break;
                case (13):
                    str = "K";
                    break;
                case (1):
                    str = "A";
                    break;
                default:
                    return Num + "  " + Symbol;
            }
            return str + "  " + Symbol;
        }
    }
}
