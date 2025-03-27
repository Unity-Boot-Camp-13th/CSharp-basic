using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticeOOP;

namespace PracticeOOP
{
    class Slime : Enemy
    {
        public Slime(string name, int hpMax) : base(name, hpMax)
        {
        }

        public override char Symbol => '♠';

        public override ConsoleColor SymbolColor => ConsoleColor.DarkGreen;
    }
}
