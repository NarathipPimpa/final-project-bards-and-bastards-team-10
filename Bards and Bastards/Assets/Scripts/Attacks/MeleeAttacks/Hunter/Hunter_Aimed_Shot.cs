using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunter_Aimed_Shot : BaseAttack
{
 public Hunter_Aimed_Shot()
    {
        // basic attack for hunters, standard damage 
        attackName = "Aimed Shot";
        attackDescription = "Line up a shot, dealing large damage to an enemy";
        attackDamage = 15f;
        attackCost = 3; 
    }
}
