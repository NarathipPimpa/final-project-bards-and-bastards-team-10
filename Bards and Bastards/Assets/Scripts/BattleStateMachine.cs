using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BattleStateMachine : MonoBehaviour
{
    public enum PerformAction
    {
        WAIT,
        TAKEACTION,
        PERFORMACTION
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


    void Start()
    {
        battleStates = PerformAction.WAIT;
        EnemiesInBattle.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
        HeroesInBattle.AddRange(GameObject.FindGameObjectsWithTag("Hero"));


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
                        ESM.HeroToAttack = PerformList[0].AttackersTarget;
                        ESM.currentState = EnemyStateMachine.TurnState.ACTION;
                    }

                    if (PerformList[0].Type == "Hero")
                    {

                    }

                    battleStates = PerformAction.PERFORMACTION;

                    break;
                }

            case (PerformAction.PERFORMACTION):
                {

                    break;
                }

        }
    }


    public void CollectActions(HandleTurn input)
    {
        PerformList.Add(input);


    }



    void EnemyButtons()
    {
        foreach(GameObject enemy in EnemiesInBattle)
        {
            GameObject newButton = Instantiate(enemyButton) as GameObject;
            EnemySelectButton button = newButton.GetComponent<EnemySelectButton>();

            EnemyStateMachine current_enemy = enemy.GetComponent<EnemyStateMachine>();

            Text buttonText = newButton.transform.Find("Text").gameObject.GetComponent<Text>();
            buttonText.text = current_enemy.enemy.name;

            button.EnemyPrefab = enemy;

            newButton.transform.SetParent(Spacer, false);

        }


    }



}
