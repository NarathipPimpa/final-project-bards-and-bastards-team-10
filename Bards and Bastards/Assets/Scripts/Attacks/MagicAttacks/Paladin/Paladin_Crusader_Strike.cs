using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paladin_Crusader_Strike : BaseAttack
{
    //Basic strike for paladin, standard damage 
    public Paladin_Crusader_Strike()
    {
        attackName = "Crusader Strike";
        attackDescription = "Attack an enemy, dealing damage";
        attackDamage = 10f;
        attackCost = 3;
    }


}