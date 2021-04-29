using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunter_Tar_Trap : BaseAttack
{
    Hunter_Tar_Trap()
    {
        // debuff for enemies to make them get hit more 
        // does zero damage 
        attackName = "Tar Trap";
        attackDescription = "Throw a trap at an enemy which covers them in sludge, making them more likely to be hit by attacks";
        attackDamage = 0f;
        attackCost = 3; 
    }
}
