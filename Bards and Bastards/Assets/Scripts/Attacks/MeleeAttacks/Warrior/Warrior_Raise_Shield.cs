using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior_Raise_Shield : BaseAttack
{
    // big defensive ability for the warrior, causing him to take zero damage from the next ability 
    // could just make his armor a million or something to make him take essentially zero damage 
    // does zero damage to enemies
    Warrior_Raise_Shield()
    {
        attackName = "Raise Shield";
        attackDescription = "Raise your shield and block the next attack that comes at you, taking zero damage";
        attackDamage = 0f;
        attackCost = 3f; 
    }
}
