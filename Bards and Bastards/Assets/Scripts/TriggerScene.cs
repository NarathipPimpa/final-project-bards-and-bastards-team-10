using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerScene : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hero")
        {
            Debug.Log("Load Scene Enemy1");
            SceneManager.LoadScene("Enemy1");

        }
    }
}
