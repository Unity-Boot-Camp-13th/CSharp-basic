using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticeOOP;

namespace PracticeOOP
{
    class TownNPC_VillageChief : TownNPC
    {
        public TownNPC_VillageChief(string name, int hpMax) : base(name, hpMax)
        {
        }

        public override void Interaction(PC pc)
        {
            SaySomething();
        }

        public void SaySomething()
        {

        }
    }
}
