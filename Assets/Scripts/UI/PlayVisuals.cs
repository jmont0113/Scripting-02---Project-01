using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayVisuals : MonoBehaviour
{
    [SerializeField] public ParticleSystem runningParticleSystem;

    [SerializeField] public ParticleSystem sprintingParticleSystem;
    [SerializeField] public ParticleSystem aimingParticleSystem;

    [SerializeField] public ParticleSystem meleeParticleSystem;

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
