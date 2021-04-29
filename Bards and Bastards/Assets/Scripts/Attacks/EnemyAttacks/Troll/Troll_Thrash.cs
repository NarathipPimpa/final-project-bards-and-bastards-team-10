using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Troll_Thrash : BaseAttack
{
    // aoe ability for troll 
    // flails widly to hit everyone 
public Troll_Thrash()
    {
        attackName = "Thrash";
        attackDescription = "Thrashes widly, hitting everyone with his big club.";
        attackDamage = 15f;
        attackCost = 0; 
    }
}
