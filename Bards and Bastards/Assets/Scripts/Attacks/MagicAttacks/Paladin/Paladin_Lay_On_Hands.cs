using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paladin_Lay_On_Hands : BaseAttack
{
    // basic heal for paladin 
    // not as much as priest heal
    public Paladin_Lay_On_Hands()
    {
        attackName = "Lay on Hands";
        attackDescription = "infuse the light onto someone's wounds, healing them for a small amount";
        attackDamage = 15f;
        attackCost = 3;
    }


}
