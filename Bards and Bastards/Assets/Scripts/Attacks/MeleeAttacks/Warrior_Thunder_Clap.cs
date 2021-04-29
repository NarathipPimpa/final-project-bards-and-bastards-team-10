using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior_Thunder_Clap : BaseAttack
{
    // essentially warrior's ultimate ability, dealing damage to all enemies and has a chance to stun them 
    Warrior_Thunder_Clap()
    {
        attackName = "ThunderClap";
        attackDescription = "Strike the ground so hard you cause an mini-earthquake, damaging all enemies with a chance to stun";
        attackDamage = 20f; // big damage since it's his ultimate ability, but very long cooldown 
        attackCost = 3f; // still not messing with ability cost, since for now we just want to show that things work 
    }
}
