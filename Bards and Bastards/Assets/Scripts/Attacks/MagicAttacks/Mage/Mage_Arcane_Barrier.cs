using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage_Arcane_Barrier : BaseAttack
{
    // second defensive for mages, gives them natural armor for multiple rounds 
    // lasts 5 rounds 
  public Mage_Arcane_Barrier()
    {
        attackName = "Arcane Barrier";
        attackDescription = "cover yourself in a magic aura , causing you to take less damage for the next 5 rounds";
        attackDamage = 0f;
        attackCost = 3; 
    }
}
