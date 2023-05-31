using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] AudioClip crashSound;
    [SerializeField] AudioClip LandingSound;
    [SerializeField] ParticleSystem crashParticles;

    AudioSource aus;
    bool isSequenceStarted = false;

    void Start() 
    {
        aus = GetComponent<AudioSource>();
    }
    
    float LevelLoadDelay = 1.5f;
    void OnCollisionEnter(Collision other) 
    {
        if(isSequenceStarted) return;

        switch(other.gameObject.tag){
            case "Friendly":
                break;
            case "Finish":
                LandingSequence();
                break;
            case "Start":
                break;
            default:
                CrashSequence();
                break;
        }
    }

    void CrashSequence()
    {
        isSequenceStarted = true;
        aus.Stop();
        aus.PlayOneShot(crashSound);
        crashParticles.Play();
        GetComponent<RocketMovement>().enabled = false;
        Invoke("ReloadLevel",LevelLoadDelay);
    }

    void LandingSequence()
    {
        isSequenceStarted = true;
        aus.Stop();
        aus.PlayOneShot(LandingSound);
        GetComponent<RocketMovement>().enabled = false;
        Invoke("LoadNextLevel",LevelLoadDelay);
    }

    void LoadNextLevel()
    {
        isSequenceStarted = false;
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        
        if(currentLevel == (SceneManager.sceneCountInBuildSettings-1)){
            Debug.Log(SceneManager.sceneCountInBuildSettings);
            Application.Quit();
        } 
        SceneManager.LoadScene((currentLevel + 1));
    }

    void ReloadLevel()
    {
        isSequenceStarted = false;
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentLevel);
    }

}
