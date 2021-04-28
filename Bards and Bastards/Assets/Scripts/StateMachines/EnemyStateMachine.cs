using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
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

    //for progressbar
    private float current_cooldown = 0f;
    private float max_cooldown = 10f;

    //this gameobject
    private Vector3 startposition;
    public GameObject Selector;
    //timeforaction stuff
    private bool actionStarted = false;

    public GameObject HeroToAttack;

    private float animSpeed = 10f;





    // Start is called before the first frame update
    void Start()
    {
        currentState = TurnState.PROCESSING;
        Selector.SetActive(false);
        BSM = GameObject.Find("BattleManager").GetComponent<BattleStateMachine>();
        startposition = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(currentState);
        switch (currentState)
        {
            case (TurnState.PROCESSING):
                {
                    UpgradeProgressBar();
                    break;
                }

            case (TurnState.CHOOSEACTION):
                {
                    ChooseAction();
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

        if (current_cooldown >= max_cooldown)
        {
                currentState = TurnState.CHOOSEACTION;
        }
    }


    void ChooseAction()
    {
        HandleTurn myAttack = new HandleTurn();
        myAttack.Attacker = enemy.theName;
        myAttack.Type = "Enemy";
        myAttack.AttackersGameObject = this.gameObject;
        myAttack.AttackersTarget = BSM.HeroesInBattle[Random.Range(0, BSM.HeroesInBattle.Count)];

        int num = Random.Range(0, enemy.attacks.Count);
        myAttack.choosenAttack = enemy.attacks[num];
        Debug.Log(this.gameObject.name + " has choosen " + myAttack.choosenAttack.attackName + " and do " + myAttack.choosenAttack.attackDamage + " damage!");
        BSM.CollectActions(myAttack);
    }

    private IEnumerator TimeForAction()
    {
        if (actionStarted == true)
        {
            yield break;
        }

        actionStarted = true;

        //animate the enemy near the hero to attack
        Vector3 enemyPosition = new Vector3(HeroToAttack.transform.position.x+1, HeroToAttack.transform.position.y, HeroToAttack.transform.position.z);
        while (MoveTowardsEnemy(enemyPosition)) { yield return null; }

        //wait a bit
        yield return new WaitForSeconds(0.5f);

        //do damage
        DoDamage();

        //animate back to startposition
        Vector3 firstPosition = startposition;
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


    void DoDamage()
    {
        float calculate_damage = enemy.currentATK + BSM.PerformList[0].choosenAttack.attackDamage;
        HeroToAttack.GetComponent<HeroStateMachine>().TakeDamage(calculate_damage);

    }
}
