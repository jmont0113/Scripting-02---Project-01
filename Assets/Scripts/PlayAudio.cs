using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    [SerializeField] AudioSource fireballSound;
    [SerializeField] AudioSource laserSound;

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
  
    }
}
