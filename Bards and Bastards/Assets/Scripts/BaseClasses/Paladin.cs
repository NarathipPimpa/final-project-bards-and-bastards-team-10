using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paladin : BaseClass
{
    // second tank class that can also heal a little 
    // mix between warrior and priest 
    public Paladin()
    {
        theName = "Paladin";
        // tank like the warrior, but slightly different stats, more health but less armor since he doesn't have a shield like the warrior does 
        baseHP = 150;
        currentHP = 150;
        // half magic class, larger pool than warriors but not as large as mages or priests
        baseMP = 150;
        currentMP = 150;
        // tank class, so similar to warrior in damage 
        baseATK = 10;
        currentATK = 10;

        baseDEF = 2;
        currentDEF = 2;

        attacks = null;
    }
}
