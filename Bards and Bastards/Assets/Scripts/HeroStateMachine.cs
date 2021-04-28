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
    
    void Start()
    {

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

                    break;
                }

            case (TurnState.ACTION):
                {

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







}
