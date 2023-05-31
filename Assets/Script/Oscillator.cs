using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    float movementFactor;
    [SerializeField] float period = 2f; //Time of 1 cycle

    void Start()
    {
        startingPosition = transform.position;

    }

    void Update()
    {
            if(period <= Mathf.Epsilon) return;
            float cycles = Time.time / period; //number of cycles past in time

            const float tau = Mathf.PI * 2; //Constant value of tau (6.283...)

            float rawSinWave = Mathf.Sin(cycles * tau); //Value going from -1 to 1 in time of 1 cycle

            movementFactor = (rawSinWave + 1f)/2f; // Recalculate rawSinWave to go from 0 to 1

            Vector3 offset = movementVector * movementFactor;
            transform.position = startingPosition + offset;   
    }




}
