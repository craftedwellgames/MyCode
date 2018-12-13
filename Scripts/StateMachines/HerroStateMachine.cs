using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HerroStateMachine : MonoBehaviour {

    private BattleStateMachine BSM;
    public BaseHero hero;

    public enum TurnState
    {
        PROCESSING,
        ADDTOLIST,
        WAITING,
        SELECTING,
        ACTION,
        DEAD
    }

    public TurnState currentState;

    //for Progress bar
    private float curCooldown = 0f;
    private float maxCooldown = 5f;
    public float progressbar;
    //not needed
    //public GameObject selector;
    //ieNumerator
    public GameObject enemyToAttack;
    private bool actionStarted = false;
    private Vector3 startPosition;
    private float animSpeed = 15f;

    private bool alive = true;

    private HeroUIStats stats;
    public GameObject heroPanel;
	
	void Start ()
    {
        //find/create panel and fill infos
        CreateHeroPanel();
        startPosition = transform.position;
        //you can use speed for this
        curCooldown = Random.Range(0, 2.5f);
        currentState = TurnState.PROCESSING;
        BSM = GameObject.Find("BattleManager").GetComponent<BattleStateMachine>();
        //selectors.setActive(false);
    }
	
	
	void Update ()
    {
       // Debug.Log(currentState);
        switch (currentState)
        {
            
            case (TurnState.PROCESSING):
                UpgradeProgressBar();
                break;

            case (TurnState.ADDTOLIST):
                BSM.HerosToManage.Add(this.gameObject);
                ChooseAction();
                currentState = TurnState.WAITING;
                break;

            case (TurnState.WAITING):
              
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
                    //change tag
                    this.gameObject.tag = "DeadHero";
                    //not attackable by enemies
                    BSM.HerosInBattle.Remove(this.gameObject);
                    //not manageable
                    BSM.HerosToManage.Remove(this.gameObject);

                    //remove item from performlist

                   // if (BSM.HerosInBattle.Count > 0)
                    //{
                        for (int i = 0; i < BSM.PerformList.Count; i++)
                        {
                            if (BSM.PerformList[i].AttackingGameObject == this.gameObject)
                            {
                                BSM.PerformList.Remove(BSM.PerformList[i]);
                            }

                           // if (BSM.PerformList[i].AttackersTarget == this.gameObject)
                         //   {
                        //        BSM.PerformList[i].AttackersTarget = BSM.EnemiesInBattle[0];
                        //    }
                        }
                      //  }
                    //change colour/play animation
                    this.gameObject.GetComponent<MeshRenderer>().material.color = new Color32(105, 105, 105, 255);
                    //reset hero input
                    BSM.battleStates = BattleStateMachine.PerformAction.CHECKALIVE;
                    alive = false;

                   
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
            currentState = TurnState.ADDTOLIST;

        }
    }
   public void ChooseAction()
    {
        HandleTurns myAttack = new HandleTurns();
        myAttack.Attacker = hero.theName;
        myAttack.Type = "Hero";
        myAttack.AttackingGameObject = this.gameObject;
        myAttack.AttackersTarget = BSM.EnemiesInBattle[0];

        int num = Random.Range(0, hero.attacks.Count);
        myAttack.choosenAttack = hero.attacks[num];
      //  Debug.Log(this.gameObject.name + "has choosen " + myAttack.choosenAttack.attackName + "and does " + myAttack.choosenAttack.attackDamage + "Damage!");

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
        Vector3 enemyPosition = new Vector3(enemyToAttack.transform.position.x - 4f, enemyToAttack.transform.position.y, enemyToAttack.transform.position.z);
        while (MoveTowardsEnemy(enemyPosition))
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
        BSM.HerosToManage.RemoveAt(0);
        // reset BSM -> wait
        if (BSM.battleStates != BattleStateMachine.PerformAction.WIN && BSM.battleStates != BattleStateMachine.PerformAction.LOSE)
        {
            BSM.battleStates = BattleStateMachine.PerformAction.WAIT;
            //reset this enemy state
            curCooldown = 0f;
            currentState = TurnState.PROCESSING;
        }
        else
        {
            currentState = TurnState.WAITING;
        }
        //end coroutine
        actionStarted = false;

    }

    private bool MoveTowardsEnemy(Vector3 target)

    {
        return target != (transform.position = Vector3.MoveTowards(transform.position, target, animSpeed * Time.deltaTime));
    }

    private bool MoveTowardsStart(Vector3 target)

    {
        return target != (transform.position = Vector3.MoveTowards(transform.position, target, animSpeed * Time.deltaTime));
    }

    public void TakeDamage(float getDamageAmount)
    {
        hero.currHp -= getDamageAmount;
        if (hero.currHp <= 0)
        {
            hero.currHp = 0;
            currentState = TurnState.DEAD;
        }
        UpdateHeroPanel();
    }
    //do damage
    void DoDamage()
    {
        float calcdamage = hero.currAtk + BSM.PerformList[0].choosenAttack.attackDamage;
        enemyToAttack.GetComponent<EnemyStateMachine>().TakeDamage(calcdamage);
    }


    void CreateHeroPanel()
    {
        stats = heroPanel.GetComponent<HeroUIStats>();
        stats.heroName.text = hero.theName;
       // stats.heroHP.value = hero.currHp;
      //  stats.heroMP.value = hero.currMp;
        stats.heroHP.maxValue = hero.baseHp;
        stats.heroMP.maxValue = hero.BaseMp;
      


    }
    //update stats or heal
    void UpdateHeroPanel()
    {
       
        stats.heroHP.value = hero.baseHp - hero.currHp;
       
          stats.heroMP.value = hero.BaseMp - hero.currMp;
      
    }
}
