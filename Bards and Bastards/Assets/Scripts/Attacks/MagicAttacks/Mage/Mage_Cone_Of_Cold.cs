using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage_Cone_Of_Cold : BaseAttack
{
    // large aoe attack on all enemies 
    public Mage_Cone_Of_Cold()
    {
        attackName = "Cone of Cold";
        attackDescription = "Blast freezing air at the enemy, dealing damage to everyone";
        attackDamage = 20f;
        attackCost = 3f; 
    }

}

