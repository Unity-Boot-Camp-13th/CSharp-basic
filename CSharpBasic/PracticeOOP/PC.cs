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


    abstract class PC : Character, IAttacker
    {
        // base 생성자 오버로드가 파라미터를 가진다면, 자식클래스는 생성자 오버로드를 정의하여 
        // base 생성자의 파라미터에 인수를 전달하여야 한다.
        public PC(string name, int hpMax, int attackForce) 
            : base(name, hpMax)
        {
            AttackForce = attackForce;
        }

        public CharacterClass CurrentClass { get; private set; }

        public int AttackForce { get; private set; }

        public void Attack(IDamageable target)
        {
            target.Damage(this, AttackForce);
        }
    }
}

    

