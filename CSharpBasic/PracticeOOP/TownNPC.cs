using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeOOP
{
    abstract class TownNPC : NPC
    {
        protected TownNPC(string name, int hpMax) : base(name, hpMax)
        {
        }

        public abstract void Interaction(PC pc);
    }
}
