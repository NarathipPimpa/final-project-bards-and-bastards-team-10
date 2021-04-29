using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunter_Freezing_Trap : BaseAttack
{
    // cc ability for hunters 
    // allows them to take an enemy out of the fight for a long time, giving breathing room for the rest of the encounter 
    // does zero damage 
    public Hunter_Freezing_Trap()
    {
        attackName = "Freezing Trap";
        attackDescription = "Throw a trap at an enemy, causing them to be frozen solid, making them stunned for 5 turns. The stun will end early if they are attacked.";
        attackDamage = 0f;
        attackCost = 3; 
    }
}
