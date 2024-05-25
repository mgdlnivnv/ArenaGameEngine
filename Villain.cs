using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGameEngine
{
    // - Has a 20% chance to avoid taking damage completely.
    // - Has a 40% chance to deal damage equal to 2 times his Strength.
    // - Gains 10% of the dealt damage as health recovery with each attack.
    internal class Villain
    {
        private static readonly Random random = new Random();

        public Villain(string name) : base(name)
        {

        }
                   public override int Attack()
        {
            int baseAttack = base.Attack();
            int chance = random.Next(100);

            if (chance < 40) // 40% chance to deal damage equal to 2 times his Strength
            {
                baseAttack = baseAttack * 2;
            }

            // Heal 10% of the attack damage
            this.Heal(baseAttack / 10);

            return baseAttack;
        }
        public override void TakeDamage(int incomingDamage)
        {
            int chance = random.Next(100);

            if (chance < 20) // 20% chance to avoid damage completely
            {
                incomingDamage = 0;
            }

            base.TakeDamage(incomingDamage);
        }

        private void Heal(int amount)
        {
            Health += amount;
            if (Health > 500) // Assuming 500 is the max health
            {
                Health = 500;
            }
        }
    }
}