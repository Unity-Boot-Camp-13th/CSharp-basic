using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeOOP
{   
    abstract class Character : GameObject, IDamageable
    {
        public Character(string name, int hpMax) // 파라미터 2개를 받는 생성자
        {
            Name = name;
            HpMax = hpMax;
            Hp = hpMax;
        }

        public string Name { get; private set; }

        public int HpMax { get; private set; }

        public int Hp { get; protected set; }

        public virtual void Damage(IAttacker attacker, int amount)
        {
            Hp -= amount;
        }
    }

}
