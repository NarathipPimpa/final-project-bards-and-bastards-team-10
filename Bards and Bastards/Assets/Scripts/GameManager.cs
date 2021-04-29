using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject heroCharacter;

    // Start is called before the first frame update
    void Awake()
    {
        //check if instance exist
        if (instance == null)
        {
            //if not set the instance to this
            instance = this;
        }
        else if (instance != this) // if it exist but is not this instance
        {
            //destroy it
            Destroy(gameObject);
        }

        //set this to be not destroyable
        DontDestroyOnLoad(gameObject);

        

    }




}
