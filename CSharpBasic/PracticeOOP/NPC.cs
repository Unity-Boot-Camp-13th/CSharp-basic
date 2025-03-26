using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeOOP
{
    abstract class NPC : Character
    {
        protected NPC(string name, int hpMax) : base(name, hpMax)
        {
        }
    }

}
