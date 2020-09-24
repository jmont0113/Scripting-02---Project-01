using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    private float landingTime = 1.0f;

    [SerializeField] AudioSource fireballSound;
    [SerializeField] AudioSource laserSound;
    [SerializeField] AudioSource walkingSound;
    [SerializeField] AudioSource jumpingSound;
    [SerializeField] AudioSource meleeSound;

    [SerializeField] ParticleSystem landing;

    void Start()
    {
        InvokeRepeating("PlaySound", 0.0f, 0.5f);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            fireballSound.Play();
        }

        if (Input.GetMouseButtonDown(0))
        {
            laserSound.Play();
        }
       
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpingSound.Play();
            StartCoroutine(Landing());
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            meleeSound.Play();
        }
    }
    void PlaySound()
    {
        if (Input.GetButton("Vertical") || Input.GetButton("Horizontal"))
        {
            walkingSound.Play();
        }
    }

    IEnumerator Landing()
    {
        yield return new WaitForSeconds(landingTime);
        landing.Play();
    }
}
