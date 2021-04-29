using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_Attack : BaseAttack
{
    // Base attack for enemies 
    // used for simple enemies like kobolds and other fodder enemies 
    // low damage but spammable 
    // hits one target 
    public Light_Attack()
    {
        attackName = "Strike";
        attackDescription = "simple strike, dealing low damage.";
        attackDamage = 10f;
        attackCost = 0; 
    }
}
