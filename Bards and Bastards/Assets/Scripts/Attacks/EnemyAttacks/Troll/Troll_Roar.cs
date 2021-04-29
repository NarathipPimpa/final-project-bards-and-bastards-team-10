using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Troll_Roar : BaseAttack
{
    // Troll main special ability 
    // does low aoe damage, but grants him armor for the next turn 
    public Troll_Roar()
    {
        attackName = "Roar";
        attackDescription = "the Troll Roars ferociously, dealing damage and granting him armor for the next turn.";
        attackDamage = 5f;
        attackCost = 0; 

    }
}
