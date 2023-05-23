using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    
    void OnCollisionEnter(Collision other) {
        
        switch(other.gameObject.tag){
            case "Friendly":
                Debug.Log("Collision with friendly target");
                break;
            case "Finish":
                Debug.Log("Perfect Landing!");
                SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex+1));
                break;
            case "Start":
                Debug.Log("On launching pad");
                break;
            default:
                Debug.Log("BOOM");
                ReloadLevel();
                break;
        }

    }

    private static void ReloadLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentLevel);
    }
}
