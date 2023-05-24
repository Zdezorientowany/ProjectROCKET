using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] AudioClip crashSound;
    [SerializeField] AudioClip LandingSound;
    AudioSource aus;

    void Start() {
        aus = GetComponent<AudioSource>();
    }
    
    float LevelLoadDelay = 1.5f;
    void OnCollisionEnter(Collision other) {
        
        switch(other.gameObject.tag){
            case "Friendly":
                Debug.Log("Collision with friendly target");
                break;
            case "Finish":
                Debug.Log("Perfect Landing!");
                LoadNextLevel();
                break;
            case "Start":
                Debug.Log("On launching pad");
                break;
            default:
                Debug.Log("BOOM");
                CrashSequence();
                break;
        }

    }
    void CrashSequence(){
        aus.PlayOneShot(crashSound);
        GetComponent<RocketMovement>().enabled = false;
        Invoke("ReloadLevel",LevelLoadDelay);
    }

    void LandingSequence(){
        GetComponent<RocketMovement>().enabled = false;
        Invoke("LoadNextLevel",LevelLoadDelay);
    }
    void LoadNextLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene((currentLevel + 1));
    }

    void ReloadLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentLevel);
    }
}
