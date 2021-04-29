using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior_Shield_Slam : BaseAttack
{
    public Warrior_Shield_Slam()
    {
        // main defensive ability for warrior, shield slamming gives you armor for 2 rounds, keeping you tanky
        // slightly more damage than sword slash, since this doesn't have a bleed, but the main use is to give you armor for future attacks 
        attackName = "Shield Slam";
        attackDescription = "Slam your shield into a target, dealing damage and granting armor for the next 2 rounds";
        attackDamage = 7f;
        attackCost = 3;
    }
}