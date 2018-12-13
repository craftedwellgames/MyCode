using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire1Spell : BaseAttack {

    public Fire1Spell()
    {
        attackName = "Fire1";
        attackDescription = "Basic fire Spell which burns nothing.";
        attackDamage = 20f;
        attackCost = 10f;
    }
}
