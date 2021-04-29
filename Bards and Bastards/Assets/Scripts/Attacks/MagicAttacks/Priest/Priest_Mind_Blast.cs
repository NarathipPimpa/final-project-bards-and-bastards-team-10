using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Priest_Mind_Blast : BaseAttack
{
    public Priest_Mind_Blast()
    {
        // basic damage ability for priest 
        // low damage but better than nothing 
        attackName = "Mind Blast";
        attackDescription = "Strike your enemies pysche, dealing damage";
        attackDamage = 10f;
        attackCost = 3; 
    }
}
