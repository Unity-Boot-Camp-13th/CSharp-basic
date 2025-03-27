﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace PracticeOOP
{
    class TreasureChest : GameObject, IDamageable
    {
        public TreasureChest(int hpMax)
        {
            HpMax = hpMax;
            Hp = hpMax;
        }

        public int HpMax { get; private set; }

        public int Hp
        {
            get => _hp;
            set
            {
                if (value > HpMax)
                    value = HpMax;

                _hp = value;
            }
        }

        public override char Symbol => '▤';

        public override ConsoleColor SymbolColor => ConsoleColor.DarkYellow;

        private int _hp;

        public void Damage(IAttacker attacker, int amount)
        {
            if (amount <= 0)
                return;

            if (_hp <= 0)
                return ;

            Hp -= 1;

            if (_hp <= 0)
            {
                if (attacker is PC pc)
                {
                    GiveReward(pc);
                }

                DestroySelf();
            }
        }

        private void GiveReward(PC pc)
        {

        }

        private void DestroySelf()
        {

        }

    }
}
