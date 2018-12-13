using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour {

    private BattleStateMachine BSM;
    public BaseEnemy enemy;
    

    public enum TurnState
    {
        PROCESSING,
        CHOOSEACTION,
        WAITING,
        ACTION,
        DEAD
    }



    public TurnState currentState;

    //for Progress bar
    private float curCooldown = 0f;
    private float maxCooldown = 5f;
    public float progressbar;
    //this gameobject
    private Vector3 startPosition;
    //timeforaction stuff
    private bool actionStarted = false;
    public GameObject HeroToAttack;
    private float animSpeed = 15f;
    private EnemyUIStats enemyStats;
    public GameObject enemyPanel;

    //alive
    private bool alive = true;

    void Start ()
    {
       // currentState = TurnState.PROCESSING;
        BSM = GameObject.Find("BattleManager").GetComponent<BattleStateMachine>();
        startPosition = transform.position;
        CreateEnemyPanel();
    }
	
	
	void Update ()
    {
        // Debug.Log(currentState);
        switch (currentState)
        {

            case (TurnState.PROCESSING):
                UpgradeProgressBar();
                break;

            case (TurnState.CHOOSEACTION):
                if (BSM.HerosInBattle.Count == 0)
                {
                  //  Debug.Log("No heros left");
                    break;
                }
                else
                {
                    ChooseAction();
                    currentState = TurnState.WAITING;
                }
                    break;
                

            case (TurnState.WAITING):
                //idle state
                break;

            case (TurnState.ACTION):
                StartCoroutine(TimeForAction());
                break;

            case (TurnState.DEAD):
                if (!alive)
                {
                    return;
                }
                else
                {
                    //change tag of enemy
                    this.gameObject.tag = "DeadEnemy";
                    //remove from enemy in battle list not attackable
                    BSM.EnemiesInBattle.Remove(this.gameObject);
                    //remove all inputs enemyattacks
                    for (int i = 0; i < BSM.PerformList.Count; i++)
                    {
                        if (BSM.PerformList[i].AttackingGameObject == this.gameObject)
                        {
                            BSM.PerformList.Remove(BSM.PerformList[i]);
                        }
                     //   if (BSM.PerformList[i].AttackersTarget == this.gameObject)
                      //  {
                      //      BSM.PerformList[i].AttackersTarget = BSM.HerosInBattle[0];
                     //   }
                    }
                    //change colour to grey / play dead animations
                    this.gameObject.GetComponent<MeshRenderer>().material.color = new Color32(105, 105, 105, 255);
                    //set alive to be false
                    alive = false;
                    //check alive
                    BSM.battleStates = BattleStateMachine.PerformAction.CHECKALIVE;

                }
                break;
        }
    }
    void UpgradeProgressBar()
    {
        curCooldown = curCooldown + Time.deltaTime;
        // float calcCooldown = curCooldown / maxCooldown;
        //progressbar.transform.localScale = new Vector3(Mathf.Clamp(calcCooldown, 0, 1), progressbar.transform.localScale.y, progressbar.transform.localScale.z);
        progressbar = curCooldown;
        if (curCooldown >= maxCooldown)
        {
            currentState = TurnState.CHOOSEACTION;
        }
    }

    void ChooseAction()
    {
        HandleTurns myAttack = new HandleTurns();
        myAttack.Attacker = enemy.theName;
        myAttack.Type = "Enemy";
        myAttack.AttackingGameObject = this.gameObject;
        myAttack.AttackersTarget = BSM.HerosInBattle[0];

        int num = Random.Range(0, enemy.attacks.Count);
        myAttack.choosenAttack = enemy.attacks[num];
       // Debug.Log(this.gameObject.name + "has choosen " + myAttack.choosenAttack.attackName + "and does " + myAttack.choosenAttack.attackDamage + "Damage!");

        BSM.CollectActions(myAttack);
    }

    private IEnumerator TimeForAction()
    {
        if (actionStarted)
        {
            yield break;
        }

        actionStarted = true;
        //animate the enemy near hero to attack
        Vector3 heroPosition = new Vector3 (HeroToAttack.transform.position.x + 4f, HeroToAttack.transform.position.y, HeroToAttack.transform.position.z);
        while (MoveTowardsEnemy(heroPosition))
        {
            yield return null;
        }
        // wait a bit
        yield return new WaitForSeconds(0.5f);

        //do damage
        DoDamage();
        // animate back to start position
        Vector3 firstPosition = startPosition;
        while (MoveTowardsStart(firstPosition))
        {
            yield return null;
        }

        // remove this performer from list in BSM
        BSM.PerformList.RemoveAt(0);

        // reset BSM -> wait
        BSM.battleStates = BattleStateMachine.PerformAction.WAIT;
        //end coroutine
        actionStarted = false;
        //reset this enemy state
        curCooldown = 0f;
        currentState = TurnState.PROCESSING;

    }

    private bool MoveTowardsEnemy(Vector3 target)

    {
        return target != (transform.position = Vector3.MoveTowards(transform.position, target, animSpeed * Time.deltaTime));
    }

    private bool MoveTowardsStart(Vector3 target)

    {
        return target != (transform.position = Vector3.MoveTowards(transform.position, target, animSpeed * Time.deltaTime));
    }

    void DoDamage()
    {
        //this is the calculation of damage based on whatever(levels, race, abilities) etc
        float calcDamage = enemy.currAtk + BSM.PerformList[0].choosenAttack.attackDamage;
        HeroToAttack.GetComponent<HerroStateMachine>().TakeDamage(calcDamage);
    }

    public void TakeDamage(float getDamageAmount)
    {
        enemy.currHp -= getDamageAmount;
        if (enemy.currHp <= 0)
        {
            enemy.currHp = 0;
            currentState = TurnState.DEAD;
        }
        UpdateEnemyPanel();
    }

    void CreateEnemyPanel()
    {
        enemyStats = enemyPanel.GetComponent<EnemyUIStats>();
        enemyStats.enemyName.text = enemy.theName;
        // stats.heroHP.value = hero.currHp;
        //  stats.heroMP.value = hero.currMp;
        enemyStats.enemyHP.maxValue = enemy.baseHp;
        enemyStats.enemyMP.maxValue = enemy.BaseMp;



    }
    //update stats or heal
    void UpdateEnemyPanel()
    {

        enemyStats.enemyHP.value = enemy.baseHp - enemy.currHp;

        enemyStats.enemyMP.value = enemy.BaseMp - enemy.currMp;

    }
}
