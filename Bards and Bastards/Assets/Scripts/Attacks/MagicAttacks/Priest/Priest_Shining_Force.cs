using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Priest_Shining_Force : BaseAttack
{
    // mostly a cc ability for priest, but does some damage 
    public Priest_Shining_Force()
    {
        attackName = "Shining Force";
        attackDescription = "Blast light all around you, blinding enemies and making them have a high chance to miss their next attack.";
        attackDamage = 10f;
        attackCost = 3; 
    }

}

