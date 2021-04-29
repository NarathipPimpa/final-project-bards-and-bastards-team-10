using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage_Blink : BaseAttack
{
    // defensive for mages to not die if they expect to get hit 
    // makes it so the next attack deals zero damage 
    public Mage_Blink()
    {
        attackName = "Blink";
        attackDescription = "Blink out of danger when you see the next attack, taking zero damage";
        attackDamage = 0f;
        attackCost = 3; 

    }
}
