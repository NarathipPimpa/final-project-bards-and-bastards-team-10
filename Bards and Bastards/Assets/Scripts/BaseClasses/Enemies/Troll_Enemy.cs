using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Troll_Enemy : BaseClass
{
    // big, slow, lumbering, and carries a large stick 
    // large health pools, but simple attacks that are easy to play around 
    public Troll_Enemy()
    {
        theName = "Lumbering Troll";
        baseHP = 500;
        currentHP = 500;

        baseMP = 0;
        currentMP = 0;

        baseATK = 15;
        currentATK = 15; 

        baseDEF = 0;
        currentDEF = 0;
        attacks = null; 
    }
}
