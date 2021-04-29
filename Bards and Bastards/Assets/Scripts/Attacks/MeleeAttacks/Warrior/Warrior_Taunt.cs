using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior_Taunt : BaseAttack
{
    Warrior_Taunt()
    {
        // this ability does not do any damage, but instead changes how the ai is suppose to react, with them all targeting you instead of choosing an random teamate 
        attackName = "Taunt";
        attackDescription = "taunt your enemies, causing them to all target you with their attacks next round.";
        attackDamage = 0f; // confirmation that is suppose to do zero damage 
        attackCost = 3f; 
    }
}
