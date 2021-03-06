﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{
    [SerializeField] ThirdPersonMovement thirdPerson;
    [SerializeField] AudioSource _FallingSound;
    [SerializeField] ParticleSystem fallingParticleSystem;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            thirdPerson.GetComponent<Animator>().Play("Falling");
            _FallingSound.Play();
            fallingParticleSystem.Play();
        }
    }
}
