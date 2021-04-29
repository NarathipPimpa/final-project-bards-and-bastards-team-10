using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunter : BaseClass
{
    public Hunter()
    {
        // hunter class - archer who uses a bow or crossbow to strike enemies as well as setting up traps to snare them 
        // standard survivability compared to usual classes, has multiple cc abilities to get rid of enemies for a long time 
        theName = "Hunter";
        baseHP = 100;
        currentHP = 100;
        baseMP = 100;
        currentMP = 100;
        baseATK = 15;
        currentATK = 15;
        // less defense and health than warrior 
        baseDEF = 0;
        currentDEF = 0;
        attacks = null;

    }

}

