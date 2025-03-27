using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticeOOP;

namespace PracticeOOP
{
    class Magician : PC
{
        public Magician(string name, int hpMax, int attackForce) : base(name, hpMax, attackForce)
        {
        }

        public override char Symbol => 'ⓜ';

        public override ConsoleColor SymbolColor => ConsoleColor.DarkBlue;

        public void Fireball()
        {

        }
}
}
