using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : BaseClass
{
    public Warrior()
    {
        // warrior class - brusier tank with sword and shield, no magic, just brute force against enemies 
        theName = "Warrior";
        // somewhat increased health compared to other classes, most are going to start with only 100 health, while mages and priest only have 75 
        baseHP= 125;
        currentHP= 125;
        baseMP = 100;
        currentMP =100;
        baseATK=10;
        currentATK=10;

        // values for attack are not permanent
        // values for defense are zero for most classes, but warrior starts with some armor due to naturally being a tank
        baseDEF= 4 ;
        currentDEF= 4;
        // all attacks the warrior has have the class name infront of it
        attacks = null;
}
}
