using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class ThirdPersonMovement : MonoBehaviour
{
    public event Action Idle = delegate { };
    public event Action StartRunning = delegate { };
    public event Action StartJumping = delegate { };
    public event Action StartFalling = delegate { };
    public event Action StartSprinting = delegate { };
    public event Action StartAiming = delegate { };
    public event Action TookDamage = delegate { };
    public event Action Dead = delegate { };
    public event Action StartMelee = delegate { };

    [SerializeField] CharacterController controller = null;

    [SerializeField] Transform cam = null;

    [SerializeField] float turnSmoothTime = 0.1f;

    float turnSmoothVelocity;

    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerMoveSpeed = 2.0f;
    private float playerWalkSpeed = 2.0f;
    private float playerSprintSpeed = 12.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;

    bool _isMoving = false;
    bool _isAiming = false;

    bool _isRunning = false;
    bool _isSprinting = false;

    private void Start()
    {
        Idle?.Invoke();
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;

        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        if (move.magnitude >= 0.1f)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
            {
                CheckIfStartedSprinting();
            } else
            {
                CheckIfStartedMoving();
            }

            float targetAngle = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 movDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(movDir.normalized * playerMoveSpeed * Time.deltaTime);
        }
        else
        {
            CheckIfStoppedMoving();
        }

        Aiming();
        Jumping();
        Melee();
        Sprinting();
        StopSprinting();
    }

    private void Aiming()
    {
        if (Input.GetMouseButtonDown(0) && groundedPlayer || (Input.GetKeyDown(KeyCode.Alpha1) && groundedPlayer))
        {
            CheckIfStartedAiming();
        }
    }

    private void Sprinting()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            playerMoveSpeed = playerSprintSpeed;
        }
    }

    private void StopSprinting()
    {
        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
        {
            playerMoveSpeed = playerWalkSpeed;
        }
    }

    private void CheckIfStartedMoving()
    {
        if (_isMoving == false)
        {
            StartRunning?.Invoke();
            Debug.Log("Started");
        }
        _isMoving = true;
    }

    private void CheckIfStoppedMoving()
    {
        if (_isMoving == true)
        {
            Idle?.Invoke();
            Debug.Log("Stopped");
        }
        _isMoving = false;
    }

    private void CheckIfStartedSprinting()
    {
        if (_isRunning == false)
        {
            StartSprinting?.Invoke();
            Debug.Log("Start Sprinting");
        }
        _isSprinting = true;
    }

    private void CheckIfStartedAiming()
    {
        if (_isMoving == false)
        {
            StartAiming?.Invoke();
        }
        _isAiming = true;
    }

        private void Jumping()
    {
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            StartJumping?.Invoke();
        }
    }

    private void Melee()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartMelee?.Invoke();
        }
    }
}
