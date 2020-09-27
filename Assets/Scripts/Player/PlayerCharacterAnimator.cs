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
    const string AimingState = "Aiming";
    const string TookDamageState = "TookDamage";
    const string DeadState = "Dead";
    const string MeleeState = "Melee";

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
        _thirdPersonMovement.StartAiming += OnStartAiming;
        _thirdPersonMovement.TookDamage += OnTookDamage;
        _thirdPersonMovement.Dead += OnDead;
        _thirdPersonMovement.StartMelee += OnStartMelee;
    }

    private void OnDisable()
    {
        _thirdPersonMovement.Idle -= OnIdle;
        _thirdPersonMovement.StartRunning -= OnStartRunning;
        _thirdPersonMovement.StartJumping -= OnStartJumping;
        _thirdPersonMovement.StartFalling -= OnStartFalling;
        _thirdPersonMovement.StartSprinting -= OnStartSprinting;
        _thirdPersonMovement.StartAiming -= OnStartAiming;
        _thirdPersonMovement.TookDamage -= OnTookDamage;
        _thirdPersonMovement.Dead -= OnDead;
        _thirdPersonMovement.StartMelee -= OnStartMelee;
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

    private void OnStartAiming()
    {
        _animator.CrossFadeInFixedTime(AimingState, .2f);
    }

    private void OnTookDamage()
    {
        _animator.CrossFadeInFixedTime(TookDamageState, .3f);
    }
    private void OnDead()
    {
        _animator.CrossFadeInFixedTime(DeadState, 2.0f);
    }

    private void OnStartMelee()
    {
        _animator.CrossFadeInFixedTime(MeleeState, .2f);
    }
}
