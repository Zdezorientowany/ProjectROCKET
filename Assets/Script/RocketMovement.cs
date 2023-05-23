using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovement : MonoBehaviour
{

    
    
    [SerializeField] float thrustVelocity = 500f;
    [SerializeField] float maxThrustVelocity = 1500f;
    [SerializeField] float minThrustVelocity = 500f;

    [SerializeField] float acceleration = 200f;
    [SerializeField] float rotationVelocity = 75f;

    [SerializeField] AudioClip engineBoostSound;
    AudioSource audiosource;
    Rigidbody rocketRigidbody; 
    // Start is called before the first frame update
    void Start(){
        rocketRigidbody = GetComponent<Rigidbody>();
        audiosource = GetComponent<AudioSource>();
        audiosource.clip = engineBoostSound;
        audiosource.Play();
    }

    // Update is called once per frame
    void Update(){

        RocketBoost();
        RocketRotation();

    }

    void RocketBoost(){

        if(Input.GetKey(KeyCode.Space)){
            if(!audiosource.isPlaying) {
                // audiosource.PlayOneShot(engineBoostSound);
            }
            if(thrustVelocity < maxThrustVelocity){
                thrustVelocity = thrustVelocity + (1 * Time.deltaTime * acceleration);
            }
            rocketRigidbody.AddRelativeForce(Vector3.up * Time.deltaTime * thrustVelocity);
        }else if(thrustVelocity > minThrustVelocity){
            // if(audiosource.isPlaying) audiosource.Stop();
            thrustVelocity = thrustVelocity - (1 * Time.deltaTime * acceleration * 2);
        }
    } 

    void RocketRotation(){

        if(Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationVelocity);
        }
        else if(Input.GetKey(KeyCode.D)){
            ApplyRotation(-rotationVelocity);
        }
    }
    //Method that manually rotate rocketby prompting value
    private void ApplyRotation(float rotationSpeed)
    {
        rocketRigidbody.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        rocketRigidbody.freezeRotation = false;
    }
}
