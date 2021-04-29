using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage_Fireball : BaseAttack
{
    // basic mage attack 
    // could implement the chance to ignite if we have time in the future 
    // very strong compared to other attacks from other classes, but mages are naturally squishy 
    public Mage_Fireball()
    {
        attackName = "Fireball";
        attackDescription = "Launch a ball of fire at your enemy, dealing damage with a chance to ignite them";
        attackDamage = 20f;
        attackCost = 3;
    }


}
