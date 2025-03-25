using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeOOP
{
    abstract class TownNPC : NPC
    {
        public abstract void Interaction(PC pc);
    }

    class TownNPC_VillageChief : TownNPC
    {
        public override void Interaction(PC pc)
        {
            throw new NotImplementedException();
        }

        public void SaySomething()
        {

        }
    }
}
