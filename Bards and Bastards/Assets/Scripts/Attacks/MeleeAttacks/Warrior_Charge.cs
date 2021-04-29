using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior_Charge : BaseAttack
{
    Warrior_Charge()
    {
        // cc ability for warrior, guaranteed stun, but has a cooldown so it cannot be spammed 
        attackName = "Charge";
        attackDescription = " Charge your enemy and catch them by surprise, dealing damage and stunning them for a round";
        attackDamage = 15f; // since this is your first big ability, this does good damage compared to sword slash and shield slam which can be cast every round 
        attackCost = 3; 
    }
}
