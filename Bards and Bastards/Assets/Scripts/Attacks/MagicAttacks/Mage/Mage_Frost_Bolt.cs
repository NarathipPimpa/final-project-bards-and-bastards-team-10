using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage_Frost_Bolt : BaseAttack
{
    public Mage_Frost_Bolt()
    {
        // other basic attack for mages 
        // slightly less damage, but makes then easier to hit for 3 rounds 
        attackName = "Frost Bolt";
        attackDescription = "Launch a chunk of ice at an enemy, dealing damage and slowing them, making them easier to attack for 3 rounds";
        attackDamage = 13f;
        attackCost = 3; 

    }
}