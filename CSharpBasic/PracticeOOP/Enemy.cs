using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeOOP
{
    abstract class Enemy : NPC
    {
        
    }

    class Slime : Enemy
    {

    }

    class Mushroom : Enemy
    {
        public void Attack()
        {

        }
    }
}
