using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paladin_Wake_Of_Ashes : BaseAttack
{
    // damage ultimate for paladin
    // multi round cd 
    public Paladin_Wake_Of_Ashes()
    {
        attackName = "Wake of Ashes";
        attackDescription = "Infuse your weapon with holy fire, and then cleaving all enemies, dealing damage and igniting them ";
        attackDamage = 30f;
        attackCost = 3;
    }


}
