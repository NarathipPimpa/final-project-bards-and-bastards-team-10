using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin_Leg_Sweep : BaseAttack
{
    // fancy attack for the goblin 
    // 2 round cool down 
    public Goblin_Leg_Sweep()
    {
        attackName = "Leg Sweep";
        attackDescription = "The goblin goes for the legs, hitting a target and making them easier to hit for one turn";
        attackDamage = 10f;
        attackCost = 0; 

    }
}
