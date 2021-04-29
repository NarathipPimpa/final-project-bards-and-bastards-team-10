using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroStateMachine : MonoBehaviour
{
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
    //for progressbar
    private float current_cooldown = 0f;
    private float max_cooldown = 5f;
    private Image ProgressBar;
    public GameObject Selector;
    //IENumerator
    public GameObject EnemyToAttack;
    private bool actionStarted = false;
    private Vector3 startPosition;
    private float animSpeed = 10f;
    //dead
    private bool alive = true;
    //heroPanel
    private HeroPanelStats stats;
    public GameObject HeroPanel;
    private Transform HeroPanelSpacer;



    void Start()
    {
        //find spacer 
        HeroPanelSpacer = GameObject.Find("BattleCanvas").transform.Find("HeroPanel").transform.Find("HeroPanelSpacer");

        //create panel, fill in info
        CreateHeroPanel();

        startPosition = transform.position;
        current_cooldown = Random.Range(0, 2.5f);
        Selector.SetActive(false);
        BSM = GameObject.Find("BattleManager").GetComponent<BattleStateMachine>();
        currentState = TurnState.PROCESSING;

    }

  
    void Update()
    {

        //Debug.Log(currentState);
        switch(currentState)
        {
            case (TurnState.PROCESSING):
                {
                    UpgradeProgressBar();
                    break;
                }


            case (TurnState.ADDTOLIST):
                {
                    BSM.HeroesToManage.Add(this.gameObject);
                    currentState = TurnState.WAITING;
                    break;
                }

            case (TurnState.WAITING):
                {
                    //idle state
                    break;
                }

            case (TurnState.ACTION):
                {
                    StartCoroutine(TimeForAction());
                    break;
                }
            case (TurnState.DEAD):
                {
                    if (!alive)
                    {
                        return;
                    }
                    else
                    {
                        //change tag
                        this.gameObject.tag = "DeadHero";

                        //not attackable by enemy
                        BSM.HeroesInBattle.Remove(this.gameObject);

                        //not manageable
                        BSM.HeroesToManage.Remove(this.gameObject);

                        //deactivate the selector
                        Selector.SetActive(false);

                        //reset gui
                        BSM.AttackPanel.SetActive(false);
                        BSM.EnemySelectPanel.SetActive(false);

                        //remove item from performlist
                        if (BSM.HeroesInBattle.Count > 0)
                        {
                            for (int i = 0; i < BSM.PerformList.Count; i++)
                            {
                                if (BSM.PerformList[i].AttackersGameObject == this.gameObject)
                                {
                                    BSM.PerformList.Remove(BSM.PerformList[i]);
                                }

                                if (BSM.PerformList[i].AttackersTarget == this.gameObject)
                                {
                                    BSM.PerformList[i].AttackersTarget = BSM.HeroesInBattle[Random.Range(0, BSM.HeroesInBattle.Count)];
                                }

                            }
                        }

                        //change color / play animation
                        this.gameObject.GetComponent<MeshRenderer>().material.color = new Color32(100, 100, 100, 255);

                        //reset heroinput
                        BSM.battleStates = BattleStateMachine.PerformAction.CHECKALIVE;

                        alive = false;

                    }

                    break;
                }

        }
    }

    void UpgradeProgressBar()
    {
        current_cooldown = current_cooldown + Time.deltaTime;
        float calculate_cooldown = current_cooldown / max_cooldown;
        ProgressBar.transform.localScale = new Vector3(Mathf.Clamp(calculate_cooldown, 0 , 1), ProgressBar.transform.localScale.y, ProgressBar.transform.localScale.z);
        
        if (current_cooldown >= max_cooldown)
        {
            currentState = TurnState.ADDTOLIST;
        }
    }


    private IEnumerator TimeForAction()
    {
        if (actionStarted == true)
        {
            yield break;
        }

        actionStarted = true;

        //animate the enemy near the hero to attack
        Vector3 heroPosition = new Vector3(EnemyToAttack.transform.position.x-1, EnemyToAttack.transform.position.y, EnemyToAttack.transform.position.z);
        while (MoveTowardsEnemy(heroPosition)) { yield return null; }

        //wait a bit
        yield return new WaitForSeconds(0.5f);

        //do damage
        DoDamage();

        //animate back to startposition
        Vector3 firstPosition = startPosition;
        while (MoveTowardsStart(firstPosition)) { yield return null; }

        //remove this performer from the list in BSM
        BSM.PerformList.RemoveAt(0);

        //reset BSM -> Wait
        if (BSM.battleStates != BattleStateMachine.PerformAction.WIN && BSM.battleStates != BattleStateMachine.PerformAction.LOSE)
        {
            BSM.battleStates = BattleStateMachine.PerformAction.WAIT;
            //reset this enemy state
            current_cooldown = 0f;
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
        if (getDamageAmount > hero.currentDEF)
        {
            hero.currentHP = hero.currentHP - (getDamageAmount - hero.currentDEF);
        }
        

        if(hero.currentHP <= 0)
        {
            hero.currentHP = 0;
            currentState = TurnState.DEAD;
        }

        UpdateHeroPanel();
    }


    void CreateHeroPanel()
    {
        HeroPanel = Instantiate(HeroPanel) as GameObject;

        stats = HeroPanel.GetComponent<HeroPanelStats>();

        stats.HeroName.text = hero.theName;
        stats.HeroHP.text = "HP: " + hero.currentHP + " / " + hero.baseHP; //HP: # / #
        stats.HeroMP.text = "MP: " + hero.currentMP + " / " + hero.baseMP; //MP: # / #

        ProgressBar = stats.ProgressBar;
        HeroPanel.transform.SetParent(HeroPanelSpacer, false);


    }


    void UpdateHeroPanel()
    {
        stats.HeroHP.text = "HP: " + hero.currentHP + " / " + hero.baseHP; //HP: # / #
        stats.HeroMP.text = "MP: " + hero.currentMP + " / " + hero.baseMP; //MP: # / #
    }


    //do damage
    void DoDamage()
    {
        float calculate_damage = hero.currentATK + BSM.PerformList[0].choosenAttack.attackDamage;
        EnemyToAttack.GetComponent<EnemyStateMachine>().TakeDamage(calculate_damage);
    }

}
