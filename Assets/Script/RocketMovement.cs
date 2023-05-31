using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    [SerializeField] float thrustVelocity = 500f;
    [SerializeField] float maxThrustVelocity = 1500f;
    [SerializeField] float minThrustVelocity = 500f;

    [SerializeField] float acceleration = 200f;
    [SerializeField] float rotationVelocity = 100f;
    [SerializeField] ParticleSystem engineParticles;
    [SerializeField] ParticleSystem leftEngineParticles;
    [SerializeField] ParticleSystem rightEngineParticles;

    [SerializeField] AudioClip engineBoostSound;
    AudioSource aus;
    Rigidbody rocketRigidbody; 
    
    void Start()
    {
        rocketRigidbody = GetComponent<Rigidbody>();
        aus = GetComponent<AudioSource>();    
    }

    void Update()
    {
        RocketBoost();
        RocketRotation();
    }

    void RocketBoost()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            StartBoosting();
        }
        else if(thrustVelocity > minThrustVelocity)
        {
            EndBoosting();
        }
    }
    void StartBoosting()
    {
        if (engineParticles.isStopped) engineParticles.Play();
        if (!aus.isPlaying) aus.PlayOneShot(engineBoostSound);

        if (thrustVelocity < maxThrustVelocity)
        {
            thrustVelocity = thrustVelocity + (1 * Time.deltaTime * acceleration);
        }
        rocketRigidbody.AddRelativeForce(Vector3.up * Time.deltaTime * thrustVelocity);
    }
    void EndBoosting()
    {
        if (engineParticles.isPlaying) engineParticles.Stop();
        thrustVelocity = thrustVelocity - (1 * Time.deltaTime * acceleration * 2);
    }
    
    void RocketRotation()
    {
        if(Input.GetKey(KeyCode.A))
        {
            RotateLeft();
        }
        else if(Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }
        else
        {
            StopRotating();
        }
    }

    void RotateLeft()
    {
        if (!aus.isPlaying) aus.PlayOneShot(engineBoostSound);
        if (leftEngineParticles.isPlaying) leftEngineParticles.Stop();
        if (rightEngineParticles.isStopped) rightEngineParticles.Play();
        ApplyRotation(rotationVelocity);
    }

    void RotateRight()
    {
        if (!aus.isPlaying) aus.PlayOneShot(engineBoostSound);
        if (rightEngineParticles.isPlaying) rightEngineParticles.Stop();
        if (leftEngineParticles.isStopped) leftEngineParticles.Play();
        ApplyRotation(-rotationVelocity);
    }

    void ApplyRotation(float rotationSpeed)
    {
        // rocketRigidbody.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        // rocketRigidbody.freezeRotation = false;
    }

    void StopRotating()
    {
        leftEngineParticles.Stop();
        rightEngineParticles.Stop();
        if(!Input.GetKey(KeyCode.Space)) if (aus.isPlaying) aus.Stop();
    }

}
