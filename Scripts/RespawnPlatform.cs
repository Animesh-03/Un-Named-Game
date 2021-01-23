using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnPlatform : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            ResetScene();
        }
    }
    void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
