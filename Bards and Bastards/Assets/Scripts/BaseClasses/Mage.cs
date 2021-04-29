using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : BaseClass
{
    public Mage()
    {
        // Mage class - controls the elements and the arcane to damage enemies, very squishy 
        theName = "Mage";
        // probably highest damage class in the game, but also very squishy, with no armor and reduced health
        // has some abilities to help him live  
        baseHP = 75;
        currentHP = 75;
        // magic class so they have a larger mana pool compared to the warrior or hunter 
        baseMP = 200;
        currentMP = 200;

        baseATK = 15;
        currentATK = 15;

        baseDEF = 0;
        currentDEF = 0;
      
        attacks = null;

    }
  
}
