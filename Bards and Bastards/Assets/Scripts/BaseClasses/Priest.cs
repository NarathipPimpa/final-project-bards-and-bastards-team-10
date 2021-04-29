using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Priest : BaseClass
{
    public Priest()
    {
        theName = "Priest";
        // Main healer of the game, with the only other consistent healing being from the paladin, which can't heal as much as the priest can 
        // fairly squishy but lots of abilities to help them survive 
        baseHP = 75;
        currentHP = 75;
        // magic class so they have a larger mana pool compared to the warrior or hunter 
        baseMP = 200;
        currentMP = 200;
        // class is meant for mending, not for combat, low damage 
        baseATK = 10;
        currentATK = 10;

        baseDEF = 0;
        currentDEF = 0;

        attacks = null;
    }
}
