using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWithLandingPad : MonoBehaviour
{
    [SerializeField] ParticleSystem victoryParticles;
   void OnCollisionEnter(Collision other){
        if(other.gameObject.tag == "Player"){
            victoryParticles.Play();
        }
   }
}
