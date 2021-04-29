using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunter_Explosive_Shot : BaseAttack
{
    Hunter_Explosive_Shot()
    {
        // ultimate hunter ability, deals damage to all enemies with a cooldown 
        attackName = "Explosive Shot";
        attackDescription = "Launch an arrow with an explosive, blowing up and dealing damage to all enemies.";
        attackDamage = 25f;
        attackCost = 3; 
    }
}
