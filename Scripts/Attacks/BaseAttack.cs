using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class BaseAttack : MonoBehaviour
{
    public string attackName;//name
    public string attackDescription;

    public float attackDamage;//base damage 15, mellee lvl 10 stamina 35  = base damage + lvl + stamina = 60 for eg
    public float attackCost; //manacost

	
}
