using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BattleStateMachine : MonoBehaviour {


    public enum PerformAction
    {
        WAIT,
        TAKEACTION,
        PERFORMACTION,
        CHECKALIVE,
        WIN,
        LOSE
    }

    public PerformAction battleStates;

    public List<HandleTurns> PerformList = new List<HandleTurns>();

    public List<GameObject> HerosInBattle = new List<GameObject>();
    public List<GameObject> EnemiesInBattle = new List<GameObject>();
    

    public enum HeroGUI
    {
        ACTIVATE,
        WAITING,
        INPUT1,
        INPUT2,
        DONE
    }

    //this is for hero input if needed in game
    public HeroGUI HeroInput;
    public List<GameObject> HerosToManage = new List<GameObject>();
    private HandleTurns HeroChoice;
    public GameObject battleCanvas;
    public GameObject battleGround;
    public GameObject winLoseText;

    
    //public GameObject attackPanel;
    //public GameObject enemySelectPanel;

    //this is for enemybutton if needed

    // public GameObject enemyButton;
    //public Transform spacer;

    void Start ()
    {
        battleStates = PerformAction.WAIT;
        EnemiesInBattle.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
        HerosInBattle.AddRange(GameObject.FindGameObjectsWithTag("Hero"));
        HerosToManage.AddRange(GameObject.FindGameObjectsWithTag("Hero"));
        HeroInput = HeroGUI.ACTIVATE;
        //attackpanel.setactive(false);
        //enemySelectPanel.Setactive(false);
        //EnemyButtons();
    }
	
	
	void FixedUpdate ()
    {
        switch (battleStates)
        {
            case (PerformAction.WAIT):
                if (PerformList.Count > 0)
                {
                    battleStates = PerformAction.TAKEACTION;
                }
                break;

            case (PerformAction.TAKEACTION):

                GameObject performer = GameObject.Find(PerformList[0].Attacker);
                if (PerformList[0].Type == "Enemy")
                {
                    EnemyStateMachine ESM = performer.GetComponent<EnemyStateMachine>();
                    for (int i = 0; i< HerosInBattle.Count; i++)
                    {
                        if (PerformList[0].AttackersTarget == HerosInBattle[i])
                        {
                            ESM.HeroToAttack = PerformList[0].AttackersTarget;
                            ESM.currentState = EnemyStateMachine.TurnState.ACTION;
                            break;
                        }
                        else
                        {
                            PerformList[0].AttackersTarget = HerosInBattle[0];
                            ESM.HeroToAttack = PerformList[0].AttackersTarget;
                            ESM.currentState = EnemyStateMachine.TurnState.ACTION;
                        }
                    }
                   
                }

                if (PerformList[0].Type == "Hero")
                {
                    HerroStateMachine HSM = performer.GetComponent<HerroStateMachine>();
                    
                    for (int i = 0; i < EnemiesInBattle.Count; i++)
                        
                    {
                        if (PerformList[0].AttackersTarget == EnemiesInBattle[i])
                        {
                            HSM.enemyToAttack = PerformList[0].AttackersTarget;
                            HSM.currentState = HerroStateMachine.TurnState.ACTION;
                            break;
                        }
                        else
                        {
                            PerformList[0].AttackersTarget = EnemiesInBattle[Random.Range(0, EnemiesInBattle.Count)];
                            HSM.enemyToAttack = PerformList[0].AttackersTarget;
                            HSM.currentState = HerroStateMachine.TurnState.ACTION;
                        }
                    }
                   
                }
                battleStates = PerformAction.PERFORMACTION;
                break;

            case (PerformAction.PERFORMACTION):
                //idle
                break;

            case (PerformAction.CHECKALIVE):
                if (HerosInBattle.Count < 1)
                {
                    battleStates = PerformAction.LOSE;
                    //lose battle

                }
                else if (EnemiesInBattle.Count < 1)
                {
                    battleStates = PerformAction.WIN;
                    //win battle
                }
                else
                {
                    // call function
                    HeroInput = HeroGUI.ACTIVATE;
                    battleStates = PerformAction.TAKEACTION;
                }
                break;

            case (PerformAction.WIN):
                {
                    Debug.Log("You win game");
                    for (int i = 0; i < HerosInBattle.Count; i++)
                    {
                        HerosInBattle[i].GetComponent<HerroStateMachine>().currentState = HerroStateMachine.TurnState.WAITING;
                    }
                    battleCanvas.SetActive(true);
                    battleGround.SetActive(false);
                    winLoseText.GetComponent<Text>().text = "YOU WIN!!";
                    winLoseText.SetActive(true);
                    HerosToManage.Clear();
                  
                }
                break;

            case (PerformAction.LOSE):
                {
                    Debug.Log("You lost game");
                    battleCanvas.SetActive(true);
                    battleGround.SetActive(false);
                    winLoseText.GetComponent<Text>().text = "YOU LOST!!";
                    winLoseText.SetActive(true);
                    HerosToManage.Clear();
                    
                }
                break;
        }
        switch (HeroInput)
        { 
            case (HeroGUI.ACTIVATE):
                if (HerosToManage.Count > 0)
                {
                   

                    HeroChoice = new HandleTurns();
                  
                    HeroInput = HeroGUI.WAITING;
                   
                }

                break;


            case (HeroGUI.WAITING):
                //idle
                HeroInput = HeroGUI.INPUT1;
                break;

            case (HeroGUI.INPUT1):
                Input1();
                break;

            case (HeroGUI.INPUT2):
               
                 Input2();
                break;
               

            case (HeroGUI.DONE):
              //  HeroInputDone();

                break;


        }
	}

    public void CollectActions(HandleTurns input)
    {
        PerformList.Add(input);
    }
    
   
    public void Input1() //attack button should be able to call this automatically
    {
        HeroChoice.Attacker = HerosToManage[0].name;
        HeroChoice.AttackingGameObject = HerosToManage[0];
        HeroChoice.Type = "Hero";
        int num = Random.Range(0, HerosToManage[0].GetComponent<HerroStateMachine>().hero.attacks.Count);
        HeroChoice.choosenAttack = HerosToManage[0].GetComponent<HerroStateMachine>().hero.attacks[num];
        HeroInput = HeroGUI.INPUT2;

       
       
        
    }
    public void Input2()
    {
        HeroChoice.AttackersTarget = EnemiesInBattle[0];//Random.Range(0, EnemiesInBattle.Count)];
       // PerformList.Add(HeroChoice);
       // HerosToManage.RemoveAt(0);
       // Debug.Log("Ive been removed");
        HeroInput = HeroGUI.ACTIVATE;

    }

    /* void HeroInputDone()
     {
         PerformList.Add(HeroChoice);
         HerosToManage.RemoveAt(0);
         Debug.Log("Ive been removed");
         HeroInput = HeroGUI.ACTIVATE;

     }*/
   
}
