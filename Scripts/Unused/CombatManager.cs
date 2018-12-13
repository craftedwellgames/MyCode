using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class CombatManager : MonoBehaviour {

   /* public List<GameObject> players = new List<GameObject>();
    public List<GameObject> enemies = new List<GameObject>();
    PlayerStats ps;

     void Start()
    {
        players.Sort((p1, p2) => p1.gameObject.GetComponent<PlayerStats>().speed.CompareTo(p2.gameObject.GetComponent<PlayerStats>().speed));
        enemies.Sort((e1, e2) => e1.gameObject.GetComponent<PlayerStats>().speed.CompareTo(e2.gameObject.GetComponent<PlayerStats>().speed));
            
       
    }

    public void StartAttackButton()
    {
        StartCoroutine(PlayerWaitTime());
        StartCoroutine(EnemyWaitTime());
    }

    IEnumerator PlayerWaitTime()
    {
        while (players.Count > 5)
        {
            for (int i = 0; i < players.Count; i++)
            {
                int playerAtk = players[i].gameObject.GetComponent<PlayerStats>().attack;
                int playerDef = players[i].gameObject.GetComponent<PlayerStats>().defence;
                
                // this is where you put everything you want each player to do.
                Debug.Log("Im " + players[i].name + " Ive Atked");
               // players.Remove(players[1]); use this to remove players from the list
                yield return new WaitForSeconds(5);
            }
        }

    }
    IEnumerator EnemyWaitTime()
    {
        while (enemies.Count > 5)
        {
            for (int e = 0; e < enemies.Count; e++)
            {
                int enemyAtk = enemies[e].gameObject.GetComponent<PlayerStats>().attack;
                int enemyDef = enemies[e].gameObject.GetComponent<PlayerStats>().defence;
                // this is where you put everything you want each player to do.
                Debug.Log("Im " + enemies[e].name + " Ive Atked");
                // players.Remove(players[1]); use this to remove players from the list
                yield return new WaitForSeconds(5);
            }
        }

    }*/
}
