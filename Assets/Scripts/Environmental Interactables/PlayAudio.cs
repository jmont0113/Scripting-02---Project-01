using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    private float landingTime = 1.0f;

    //[SerializeField] AudioSource idleSound;
    [SerializeField] AudioSource fireballSound;
    [SerializeField] AudioSource laserSound;
    [SerializeField] AudioSource walkingSound;
    [SerializeField] AudioSource jumpingSound;
    [SerializeField] AudioSource meleeSound;
    [SerializeField] AudioSource sprintSound;

    [SerializeField] ParticleSystem landing;

    //[SerializeField] AudioSource meleeSound;

    void Start()
    {
        InvokeRepeating("PlayWalkingSound", 0.0f, 0.5f);
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

        if(Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            sprintSound.Play();
        }
    }
    void PlayWalkingSound()
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
