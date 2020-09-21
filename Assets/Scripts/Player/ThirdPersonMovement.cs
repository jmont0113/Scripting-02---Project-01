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

    [SerializeField] CharacterController controller = null;

    [SerializeField] Transform cam = null;

    //[SerializeField] float sprintSpeed = 2.0f;

    [SerializeField] float turnSmoothTime = 0.1f;

    float turnSmoothVelocity;

    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;

    bool _isMoving = false;
    bool _isJumping = false;
    bool _isAiming = false;

    float sprintSpeed = 12.0f;


    private void Start()
    {
        Idle?.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        groundedPlayer = controller.isGrounded;

        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            CheckIfStartedJumping();
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        if (Input.GetMouseButtonDown(0) && groundedPlayer)
        {
            CheckIfStartedAiming();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CheckIfStartedAiming();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            StartSprinting?.Invoke();
            playerSpeed = sprintSpeed;
            controller.Move(move * playerSpeed * Time.deltaTime);
        }

        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
        {
            StartRunning?.Invoke();
            playerSpeed = 2.0f;
            controller.Move(move * playerSpeed * Time.deltaTime);
        }

        if (move.magnitude >= 0.1f)
        {
            CheckIfStartedMoving();

            float targetAngle = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 movDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(movDir.normalized * playerSpeed * Time.deltaTime);
        }
        else
        {
            CheckIfStoppedMoving();
        }
    }

    private void CheckIfStartedMoving()
    {
        if (_isMoving == false)
        {
            // our velocity says we're moving but we previously were not
            // this means we've started moving!
            StartRunning?.Invoke();
            Debug.Log("Started");
        }
        _isMoving = true;
    }

    private void CheckIfStoppedMoving()
    {
        if (_isMoving == true)
        {
            // our velocity says we're not moving, but we previously were
            // this means we've stopped!
            Idle?.Invoke();
            Debug.Log("Stopped");
        }
        _isMoving = false;
    }

    private void CheckIfStartedJumping()
    {
        if (_isMoving == false)
        {
            StartJumping?.Invoke();
        }
        _isJumping = true;
    }

    private void CheckIfStartedSprinting()
    {
        if (_isMoving == true)
        {
            StartSprinting?.Invoke();
        }
    }

    private void CheckIfStartedAiming()
    {
        if (_isMoving == false)
        {
            StartAiming?.Invoke();
        }
        _isAiming = true;
    }

    public void PlayerDead()
    {
        Dead?.Invoke();
    }

    public void PlayerTookDamage()
    {
        TookDamage?.Invoke();
    }
}
