using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior_Sword_Slash : BaseAttack
{
    public Warrior_Sword_Slash()
    {
        // basic attack for the warrior, low damage but puts a bleed on the target which will continue to damage them 
        // this allows the warrior to cast his other abilities and not feel like he is losing damage compared to other characters 
        // bleed is not coded yet, could be cut if we don't have enough time to implement before finals day. 
        attackName = "Sword Slash";
        attackDescription = "Cut an enemy with your sword, dealing damage and causing them to bleed for 5 rounds ";
        attackDamage = 5f;
        attackCost = 3;
        // not going to mess with attack cost for now 
    }
}
