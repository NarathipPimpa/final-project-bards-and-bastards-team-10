using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Priest_Holy_Word_Radiance : BaseAttack
{
   // second ultimate for priest
    public Priest_Holy_Word_Radiance() {
        attackName = "Holy Word: Radiance";
        attackDescription = "Call upon the light to save your allies, restoring a large amount of health to everyone.";
        attackDamage = 0f;
        attackCost = 3; 
    }

}
