using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Priest_Renew : BaseAttack
{
    // this is a hot, a heal over time 
    // put on allies that are already low, or on the tank who is about to press taunt 
    public Priest_Renew()
    {
        attackName = "Renew";
        attackDescription = "apply healing restoration to an ally, healing them over multiple rounds";
        // doing the same thing here that i did with heal, putting how much health it's suppose to restore instead of how much damage
        attackDamage = 7f;
        attackCost = 3; 
    }
}

