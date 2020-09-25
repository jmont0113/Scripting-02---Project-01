using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayVisuals : MonoBehaviour
{
    [SerializeField] ParticleSystem runningParticleSystem;

    [SerializeField] ParticleSystem sprintingParticleSystem;
    [SerializeField] ParticleSystem aimingParticleSystem;

    [SerializeField] ParticleSystem meleeParticleSystem;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetMouseButtonDown(0))
        {
            aimingParticleSystem.Play();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            meleeParticleSystem.Play();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            sprintingParticleSystem.Play();
        }

        if (Input.GetButton("Vertical") || Input.GetButton("Horizontal"))
        {
            runningParticleSystem.Play();
        }
    }
}
