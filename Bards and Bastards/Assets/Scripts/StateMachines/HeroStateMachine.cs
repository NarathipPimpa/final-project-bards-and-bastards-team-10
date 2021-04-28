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
    public Image ProgressBar;
    public GameObject Selector;
    //IENumerator
    public GameObject EnemyToAttack;
    private bool actionStarted = false;
    private Vector3 startPosition;
    private float animSpeed = 10f;


    void Start()
    {
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
        

        //animate back to startposition
        Vector3 firstPosition = startPosition;
        while (MoveTowardsStart(firstPosition)) { yield return null; }

        //remove this performer from the list in BSM
        BSM.PerformList.RemoveAt(0);
        //reset BSM -> Wait
        BSM.battleStates = BattleStateMachine.PerformAction.WAIT;
        //end coroutine
        actionStarted = false;
        //reset this enemy state
        current_cooldown = 0f;
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


    public void TakeDamage(float getDamageAmount)
    {
        if (getDamageAmount > hero.currentDEF)
        {
            hero.currentHP = hero.currentHP - (getDamageAmount - hero.currentDEF);
        }
        

        if(hero.currentHP <= 0)
        {
            currentState = TurnState.DEAD;
        }
    }

}
