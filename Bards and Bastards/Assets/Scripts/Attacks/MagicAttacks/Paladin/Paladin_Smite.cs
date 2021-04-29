using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paladin_Smite : BaseAttack
{
    // does slightly more damage than crusader strike and has the chance to ignite an enemy
    // 1 round cd so crusader strike is used 
    public Paladin_Smite()
    {
        attackName = "Smite";
        attackDescription = "Strike an enemy with holy infused strike, dealing damage with a chance to ignite in holy fire";
        attackDamage = 15f;
        attackCost = 3;
    }


}