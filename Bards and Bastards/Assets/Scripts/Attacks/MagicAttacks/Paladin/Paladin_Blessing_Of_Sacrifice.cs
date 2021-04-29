using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paladin_Blessing_Of_Sacrifice : BaseAttack
{
    // second defensive for paladin, tanking an attack for an ally
    // deals no damage lmao 
    public Paladin_Blessing_Of_Sacrifice()
    {
        attackName = "Blessing of Sacrifice";
        attackDescription = "Bless an ally, making it so the next attack instead hits the paladin";
        attackDamage = 0f;
        attackCost = 3;
    }


}
