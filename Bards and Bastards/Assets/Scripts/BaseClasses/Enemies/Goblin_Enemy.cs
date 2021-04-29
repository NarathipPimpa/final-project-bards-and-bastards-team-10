using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin_Enemy : BaseClass
{
    // small little scurriers that are hard to hit, but squishy and die easily 
    public Goblin_Enemy()
    {
        theName = "Goblin";
        baseHP = 50;
        currentHP = 50;

        baseMP = 0;
        currentMP = 0;

        baseATK = 5;
        currentATK = 5;

        baseDEF = 0;
        currentDEF = 0;
        attacks = null;
    }
}
