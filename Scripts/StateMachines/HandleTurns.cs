using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class HandleTurns {


    public string Attacker; //name of attacker
    public string Type;
    public GameObject AttackingGameObject; //which attacker
    public GameObject AttackersTarget; // who is getting attacked

    //which attack is performed 
    public BaseAttack choosenAttack;

   

}
