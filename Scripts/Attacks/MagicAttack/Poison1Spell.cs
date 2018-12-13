using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison1Spell : BaseAttack {

    public Poison1Spell()
    {
        attackName = "Poison 1";
        attackDescription = "Basic poison Spell which does damage over time.";
        attackDamage = 25f;
        attackCost = 8f;
    }

}
