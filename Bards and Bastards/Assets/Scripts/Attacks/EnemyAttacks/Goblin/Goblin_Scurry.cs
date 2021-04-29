using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin_Scurry : BaseAttack
{
    // defensive for goblin, making them more difficult to hit for a turn 
   public Goblin_Scurry()
    {
        attackName = "Scurry";
        attackDescription = "The Goblin runs around with his small body, making him more difficult to hit for a round";
        attackDamage = 0f;
        attackCost = 0; 
    }
}
