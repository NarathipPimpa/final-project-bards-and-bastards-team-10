using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paladin_Blessing_Of_Protection : BaseAttack
{
    // good defensive for paladin
    // can be cast on himself and other allies 
    // gives them 3 armor 
    public Paladin_Blessing_Of_Protection()
    {
        attackName = "Blessing of Protection";
        attackDescription = "Bless an ally, giving them armor for 3 rounds";
        attackDamage = 0f;
        attackCost = 3;
    }
}
