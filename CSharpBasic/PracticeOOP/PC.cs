using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PracticeOOP
{
    enum CharacterClass
    {
        Nothing  = 0 << 0, // 0000
        Warrior  = 1 << 0, // 0001
        Magician = 1 << 1, // 0010
    }


    abstract class PC : Character
    {
        public void Attack()
        {

        }
    }


    
}

    

