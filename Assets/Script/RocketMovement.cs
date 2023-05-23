using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovement : MonoBehaviour
{

    Rigidbody rocketRigidbody; 
    [SerializeField] float thrustVelocity = 750;
    [SerializeField] float maxThrustVelocity = 1250;
    [SerializeField] float minThrustVelocity = 750;
    [SerializeField] float rotationVelocity = 1000;

    // Start is called before the first frame update
    void Start(){
        rocketRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update(){

        RocketBoost();
        RocketRotation();


    }

    void RocketBoost(){

        if(Input.GetKey(KeyCode.Space)){
            if(thrustVelocity < maxThrustVelocity) thrustVelocity++;
            rocketRigidbody.AddRelativeForce(Vector3.up * Time.deltaTime * thrustVelocity);
        }else if(thrustVelocity > minThrustVelocity){

            thrustVelocity--;
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
