using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Priest_Holy_Word_Barrier : BaseAttack
{
    // one ultimate of priest, gives everyone a lot of armor for 2 rounds
    // has a cd 
    // does zero damage 
    // gives 10 armor to all allies 
    public Priest_Holy_Word_Barrier()
    {
        attackName = "Holy Word:Barrier";
        attackDescription = "Call upon the light to create a shield around your allies, granting everyone armor for 2 rounds";
        attackDamage = 0f;
        attackCost = 3; 
    }
}
