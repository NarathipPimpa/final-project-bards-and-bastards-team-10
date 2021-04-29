using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior_Rallying_Cry : BaseAttack
{
    Warrior_Rallying_Cry()
    {
        // Warrior's defensive ultimate ability, giving the entire party current and max health for 2 rounds
        // counts as a heal after the two rounds, since you only will remove the max health and not the current health unless their current health would be above max health 
        attackName = "Rallying Cry";
        attackDescription = "Bolster your allies morale, giving everyone in your party current and maximum health";
        attackDamage = 0f;
        attackCost = 3f; 
    }
}
