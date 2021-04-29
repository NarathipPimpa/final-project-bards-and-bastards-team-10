using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage_Pyroblast : BaseAttack
{
    // ultimate attack from mage 
    // hits all enemies and ignites them 
    // multi round cd 
    public Mage_Pyroblast()
    {
        attackName = "Pyroblast";
        attackDescription = "Launch a giant explosion at your foe, dealing a large amount of damage and igniting everyone.";
        attackDamage = 35f;
        attackCost = 3; 

    }
}
