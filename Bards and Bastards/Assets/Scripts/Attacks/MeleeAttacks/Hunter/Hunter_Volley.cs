using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunter_Volley : BaseAttack
{
    Hunter_Volley()
    {
        // aoe ability with a small cooldown, maybe one to two rounds 
        attackName = "Volley";
        attackDescription = "Rain arrows upon your foes, dealing damage to all enemies ";
        attackDamage = 10f;
        attackCost = 3; 
    }
}
