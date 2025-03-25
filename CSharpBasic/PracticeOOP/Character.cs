using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeOOP
{   
    abstract class Character
    {
        public string Name { get; private set; }

        public int hpMax { get; }

        public int hp { get; set; }
    }

}
