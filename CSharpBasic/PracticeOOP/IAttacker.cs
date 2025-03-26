using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeOOP
{
    interface IAttacker
    {
        int AttackForce {  get; }

        void Attack(IDamageable target);
    }
}
