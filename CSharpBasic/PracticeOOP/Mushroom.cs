using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticeOOP;

namespace PracticeOOP
{
    class Mushroom : Enemy, IAttacker
    {
        public Mushroom(string name, int hpMax, int attackForce) : base(name, hpMax)
        {
            AttackForce = attackForce;
        }

        public int AttackForce { get; private set; }

        public override char Symbol => '♣';
        public override ConsoleColor SymbolColor => ConsoleColor.Red;

        public void Attack(IDamageable target)
        {
            target.Damage(this, AttackForce);
        }
    }   
}
