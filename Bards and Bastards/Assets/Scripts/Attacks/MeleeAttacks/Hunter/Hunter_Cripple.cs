using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunter_Cripple : BaseAttack
{
    Hunter_Cripple()
    {
        // small cc ability for hunter, making the target deal less damage 
        attackName = "Cripple";
        attackDescription = "shoot an enemey focusing on crippling their strikes, causing them to deal less damage on their next attack";
        attackDamage = 10f;
        attackCost = 3; 
    }
}
