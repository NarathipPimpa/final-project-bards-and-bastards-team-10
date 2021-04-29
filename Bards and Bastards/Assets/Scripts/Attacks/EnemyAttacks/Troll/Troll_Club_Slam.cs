using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Troll_Club_Slam : BaseAttack
{
    // Troll's basic attack 
    // big damage, but has a cooldown, so he must use basic attacks in between 
    public Troll_Club_Slam()
    {
        attackName = "Club Slam";
        attackDescription = "The Troll slams down his club, dealing massive damage";
        attackDamage = 25f;
        attackCost = 0; 
    }
}
