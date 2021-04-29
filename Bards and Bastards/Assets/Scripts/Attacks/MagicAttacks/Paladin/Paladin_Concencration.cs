using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paladin_Concencration : BaseAttack
{
    // first ultimate ability for paladin 
    // affects all characters in a fight 
    // deals damage to enemies and heals allies 
    public Paladin_Concencration()
    {
        attackName = "Concencration";
        attackDescription = "Hallows the ground below you, infusing it with light, damaging all enemies and healing all allies over 5 rounds";
        attackDamage = 10f;
        attackCost = 3;
    }
}
