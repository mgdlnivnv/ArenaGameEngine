using ArenaGameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGameEngine
{
    internal class Fighter
    {
    }
}
// - Has a 25% chance to take only half damage.
// - Has a 30% chance to deal extra damage equal to his Strength with each attack.
// - Each successful attack temporarily reduces incoming damage by 10% for the next turn.
public class Fighter : Hero
{
    private static readonly Random random = new Random();
    private bool damageReductionActive;

    public Fighter() : this("Dobby") // By default, all fighters are named 'Dobby'
    {

    }
    public Fighter(string name) : base(name) 
    {
        damageReductionActive = false;
    }

    public override int Attack()
    {
        int baseAttack = base.Attack();
        int chance = random.Next(100);

        if (chance < 30) // 30% chance to deal extra damage equal to his Strength
        {
            baseAttack += this.Strength;
        }

        // Activate damage reduction for the next turn
        damageReductionActive = true;

        return baseAttack;
    }

    public override void TakeDamage(int incomingDamage)
    {
        int chance = random.Next(100);

        if (chance < 25) // 25% chance to take only half damage
        {
            incomingDamage /= 2;
        }

        if (damageReductionActive)
        {
            incomingDamage -= (incomingDamage * 10) / 100; // Reduce damage by 10%
            damageReductionActive = false; // Reset damage reduction
        }

        base.TakeDamage(incomingDamage);
    }
}