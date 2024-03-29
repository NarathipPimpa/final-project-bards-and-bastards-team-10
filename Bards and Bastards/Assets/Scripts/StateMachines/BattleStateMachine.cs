using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class BattleStateMachine : MonoBehaviour
{
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

    public List<HandleTurn> PerformList = new List<HandleTurn>();
    public List<GameObject> HeroesInBattle = new List<GameObject>();
    public List<GameObject> EnemiesInBattle = new List<GameObject>();
    
    public enum HeroGUI
    {
        ACTIVATE,
        WAITING,
        INPUT1,
        INPUT2,
        DONE
    }

    public HeroGUI HeroInput;

    public List<GameObject> HeroesToManage = new List<GameObject>();
    private HandleTurn HeroChoice;

    public GameObject enemyButton;
    public Transform Spacer;


    public GameObject AttackPanel;
    public GameObject EnemySelectPanel;
    public GameObject MagicPanel;


    //attack of heroes
    public Transform actionSpacer;
    public Transform magicSpacer;
    public GameObject actionButton;
    public GameObject magicButton;
    private List<GameObject> atkBtns = new List<GameObject>();

    //enemy buttons
    private List<GameObject> enemyBtns = new List<GameObject>();



    void Start()
    {
        battleStates = PerformAction.WAIT;
        EnemiesInBattle.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
        HeroesInBattle.AddRange(GameObject.FindGameObjectsWithTag("Hero"));
        HeroInput = HeroGUI.ACTIVATE;

        AttackPanel.SetActive(false);
        EnemySelectPanel.SetActive(false);
        MagicPanel.SetActive(false);

        EnemyButtons();
    }

    
    void Update()
    {
        switch(battleStates)
        {
            case (PerformAction.WAIT):
                {
                    if (PerformList.Count > 0)
                    {
                        battleStates = PerformAction.TAKEACTION;
                    }

                    break;
                }
                

            case (PerformAction.TAKEACTION):
                {
                    GameObject performer = GameObject.Find(PerformList[0].Attacker);

                    if (PerformList[0].Type == "Enemy")
                    {

                        EnemyStateMachine ESM = performer.GetComponent<EnemyStateMachine>();
                        for (int i = 0; i < HeroesInBattle.Count; i++)
                        {
                            if(PerformList[0].AttackersTarget == HeroesInBattle[i])
                            {
                                ESM.HeroToAttack = PerformList[0].AttackersTarget;
                                ESM.currentState = EnemyStateMachine.TurnState.ACTION;
                                break;
                            }
                            else
                            {
                                
                                PerformList[0].AttackersTarget = HeroesInBattle[Random.Range(0, HeroesInBattle.Count)];
                                ESM.HeroToAttack = PerformList[0].AttackersTarget;
                                ESM.currentState = EnemyStateMachine.TurnState.ACTION;
                            }
                        }
                        
                    }

                    if (PerformList[0].Type == "Hero")
                    {
                        HeroStateMachine HSM = performer.GetComponent<HeroStateMachine>();
                        HSM.EnemyToAttack = PerformList[0].AttackersTarget;
                        HSM.currentState = HeroStateMachine.TurnState.ACTION;
                    }

                    battleStates = PerformAction.PERFORMACTION;

                    break;
                }

            case (PerformAction.PERFORMACTION):
                {
                    //idle state
                    break;
                }

            case (PerformAction.CHECKALIVE):
                {
                    if (HeroesInBattle.Count < 1)
                    {
                        battleStates = PerformAction.LOSE;
                        //lose the game
                    }
                    else if(EnemiesInBattle.Count < 1)
                    {
                        battleStates = PerformAction.WIN;
                        //win battle
                    }
                    else
                    {
                        //call function
                        ClearAttackPanel();
                        HeroInput = HeroGUI.ACTIVATE;
                    }


                    break;
                }

            case (PerformAction.LOSE):
                {
                    Debug.Log("You Lost the Battle");
                    SceneManager.LoadScene("GameOver");
                    break;
                }

            case (PerformAction.WIN):
                {
                    Debug.Log("You Won the Battle");
                    for(int i = 0; i < HeroesInBattle.Count; i++)
                    {
                        HeroesInBattle[i].GetComponent<HeroStateMachine>().currentState = HeroStateMachine.TurnState.WAITING;
                    }

                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                    break;
                }



        }


        switch (HeroInput)
        {
            case (HeroGUI.ACTIVATE):
                {
                    if(HeroesToManage.Count > 0)
                    {

                        HeroesToManage[0].transform.Find("Selector").gameObject.SetActive(true);
                        HeroChoice = new HandleTurn();
                        AttackPanel.SetActive(true);
                        //populate action buttons
                        CreateAttackButtons();

                        HeroInput = HeroGUI.WAITING;

                    }


                    break;
                }

            case (HeroGUI.WAITING):
                {
                    //idle state
                    break;
                }

            case (HeroGUI.DONE):
                {
                    HeroInputDone();
                    break;
                }

        }


    }


    public void CollectActions(HandleTurn input)
    {
        PerformList.Add(input);


    }



    public void EnemyButtons()
    {
        //cleanup
        foreach(GameObject enemyBtn in enemyBtns)
        {
            Destroy(enemyBtn);
        }
        enemyBtns.Clear();
        //create buttons
        foreach(GameObject enemy in EnemiesInBattle)
        {
            GameObject newButton = Instantiate(enemyButton) as GameObject;
            EnemySelectButton button = newButton.GetComponent<EnemySelectButton>();

            EnemyStateMachine current_enemy = enemy.GetComponent<EnemyStateMachine>();

            Text buttonText = newButton.transform.Find("Text").gameObject.GetComponent<Text>();
            buttonText.text = current_enemy.enemy.theName;

            button.EnemyPrefab = enemy;

            newButton.transform.SetParent(Spacer, false);
            enemyBtns.Add(newButton);

        }


    }


    public void Input1()//attack button
    {
        HeroChoice.Attacker = HeroesToManage[0].name;
        HeroChoice.AttackersGameObject = HeroesToManage[0];
        HeroChoice.Type = "Hero";
        HeroChoice.choosenAttack = HeroesToManage[0].GetComponent<HeroStateMachine>().hero.attacks[0];

        AttackPanel.SetActive(false);
        EnemySelectPanel.SetActive(true);

    }

  


    public void Input2(GameObject choosenEnemy)//enemy selection
    {

        HeroChoice.AttackersTarget = choosenEnemy;
        HeroInput = HeroGUI.DONE;

    }

    void HeroInputDone()
    {
        PerformList.Add(HeroChoice);
        //clean the attackpanel
        ClearAttackPanel();


        HeroesToManage[0].transform.Find("Selector").gameObject.SetActive(false);
        HeroesToManage.RemoveAt(0);
        HeroInput = HeroGUI.ACTIVATE;
    }


    void ClearAttackPanel()
    {
        EnemySelectPanel.SetActive(false);
        AttackPanel.SetActive(false);
        MagicPanel.SetActive(false);

        foreach (GameObject atkbtn in atkBtns)
        {
            Destroy(atkbtn);
        }
        atkBtns.Clear();
    }


    void CreateAttackButtons()
    {
        GameObject AttackButton = Instantiate(actionButton) as GameObject;
        Text AttackButtonText = AttackButton.transform.Find("Text").gameObject.GetComponent<Text>();
        AttackButtonText.text = "Attack";
        AttackButton.GetComponent<Button>().onClick.AddListener(() => Input1());
        AttackButton.transform.SetParent(actionSpacer, false);
        atkBtns.Add(AttackButton);

        

        GameObject MagicAttackButton = Instantiate(actionButton) as GameObject;
        Text MagicAttackButtonText = MagicAttackButton.transform.Find("Text").gameObject.GetComponent<Text>();
        MagicAttackButtonText.text = "Magic";
        MagicAttackButton.GetComponent<Button>().onClick.AddListener(() => Input3());
        MagicAttackButton.transform.SetParent(actionSpacer, false);
        atkBtns.Add(MagicAttackButton);

        if (HeroesToManage[0].GetComponent<HeroStateMachine>().hero.MagicAttacks.Count > 0)
        {
            foreach (BaseAttack magicAtk in HeroesToManage[0].GetComponent<HeroStateMachine>().hero.MagicAttacks)
            {
                GameObject MagicButton = Instantiate(magicButton) as GameObject;
                Text MagicButtonText = MagicButton.transform.Find("Text").gameObject.GetComponent<Text>();
                MagicButtonText.text = magicAtk.attackName;

                AttackButton ATB = MagicButton.GetComponent<AttackButton>();
                ATB.magicAttackToPerform = magicAtk;
                MagicButton.transform.SetParent(magicSpacer, false);
                atkBtns.Add(MagicButton);

            }
        }
        else
        {
            MagicAttackButton.GetComponent<Button>().interactable = false;
        }

    }


    public void Input4(BaseAttack choosenMagic)//choosen magic attack
    {
        HeroChoice.Attacker = HeroesToManage[0].name;
        HeroChoice.AttackersGameObject = HeroesToManage[0];
        HeroChoice.Type = "Hero";

        HeroChoice.choosenAttack = choosenMagic;
        MagicPanel.SetActive(false);
        EnemySelectPanel.SetActive(true);


    }


    public void Input3()//switching to magic attacks
    {
        AttackPanel.SetActive(false);
        MagicPanel.SetActive(true);
    }
}
