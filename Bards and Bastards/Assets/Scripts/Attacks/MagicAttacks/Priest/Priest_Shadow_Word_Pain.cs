using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Priest_Shadow_Word_Pain : BaseAttack
{
    public Priest_Shadow_Word_Pain()
    {
        // puts a dot on enemies so you can deal damage while you heal for other rounds 
        attackName = "Shadow Word: Pain";
        attackDescription = "Speak dark magic onto an enemy, causing them to take damage for 5 rounds";
        attackDamage = 5f;
        attackCost = 3; 
    }
}
