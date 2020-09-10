using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerCharacterAnimator : MonoBehaviour
{
    [SerializeField] ThirdPersonMovement _thirdPersonMovement = null;
    // these names align with the naming in our Animator  node
    const string IdleState = "Idle";
    const string RunState = "Run";
    const string JumpState = "Jumping";
    const string FallState = "Falling";
    const string SprintState = "Sprinting";

    Animator _animator = null;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _thirdPersonMovement.Idle += OnIdle;
        _thirdPersonMovement.StartRunning += OnStartRunning;
        _thirdPersonMovement.StartJumping += OnStartJumping;
        _thirdPersonMovement.StartFalling += OnStartFalling;
        _thirdPersonMovement.StartSprinting += OnStartSprinting;
    }

    private void OnDisable()
    {
        _thirdPersonMovement.Idle -= OnIdle;
        _thirdPersonMovement.StartRunning -= OnStartRunning;
        _thirdPersonMovement.StartJumping -= OnStartJumping;
        _thirdPersonMovement.StartFalling -= OnStartFalling;
        _thirdPersonMovement.StartSprinting -= OnStartSprinting;
    }

    public void OnIdle()
    {
        _animator.CrossFadeInFixedTime(IdleState, .2f);
    }

    private void OnStartRunning()
    {
        _animator.CrossFadeInFixedTime(RunState, .2f);
    }

    private void OnStartJumping()
    {
        _animator.CrossFadeInFixedTime(JumpState, .2f);
    }

    private void OnStartFalling()
    {
        _animator.CrossFadeInFixedTime(FallState, .2f);
    }

    private void OnStartSprinting()
    {
        _animator.CrossFadeInFixedTime(SprintState, .2f);
    }
}
