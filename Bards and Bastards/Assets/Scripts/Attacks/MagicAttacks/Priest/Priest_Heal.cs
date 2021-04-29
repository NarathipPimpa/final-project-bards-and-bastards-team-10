using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Priest_Heal : BaseAttack
{
    // basic heal
    // that's it
    public Priest_Heal()
    {
        attackName = "Heal";
        attackDescription = "Restore health to an ally";
        // putting damage here to show how much health the heal is suppose to restore instead of how much damage it's suppose to do 
        // should make this target characters 
        attackDamage = 20f;
        attackCost = 3; 

    }
}
