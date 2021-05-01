using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTrigger : MonoBehaviour
{



    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy1"))
        {
            Debug.Log("Load Scene Enemy1");
            SceneManager.LoadScene("Enemy1");
            
        }

        if (other.tag == "Enemy2")
        {
            Debug.Log("Load Scene Enemy2");
            SceneManager.LoadScene("Enemy2");
        }

        if (other.tag == "Enemy3")
        {
            Debug.Log("Load Scene Enemy3");
            SceneManager.LoadScene("Enemy3");
        }

        if (other.tag == "Enemy4")
        {
            Debug.Log("Load Scene Enemy4");
            SceneManager.LoadScene("Enemy4");
        }

        if (other.tag == "Enemy5")
        {
            Debug.Log("Load Scene Enemy5");
            SceneManager.LoadScene("Enemy5");
        }

        if (other.tag == "Enemy6")
        {
            Debug.Log("Load Scene Enemy6");
            SceneManager.LoadScene("Enemy6");
        }

        if (other.tag == "Enemy7")
        {
            Debug.Log("Load Scene Enemy7");
            SceneManager.LoadScene("Enemy7");
        }

        if (other.tag == "Boss")
        {
            Debug.Log("Load Scene Boss");
            SceneManager.LoadScene("Boss");
        }

    }
}
