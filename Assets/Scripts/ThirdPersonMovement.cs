using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ThirdPersonMovement : MonoBehaviour
{
    public event Action Idle = delegate { };
    public event Action StartRunning = delegate { };
    public event Action StartJumping= delegate { };
    public event Action StartFalling = delegate { };
    public event Action StartSprinting = delegate { };

    [SerializeField] CharacterController controller = null;

    [SerializeField] Transform cam = null;
    
    [SerializeField] float speed = 6f;
    [SerializeField] float sprintSpeed = 12f;

    [SerializeField] float turnSmoothTime = 0.1f;

    float turnSmoothVelocity;

    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;

    bool _isMoving = false;
    bool _isJumping = false;

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

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            controller.Move(move * Time.deltaTime * (playerSpeed + sprintSpeed));
            CheckIfStartedSprinting();
        }

        if (direction.magnitude >= 0.1f)
        {
            CheckIfStartedMoving();
  
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 movDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            
            controller.Move(movDir.normalized * speed * Time.deltaTime);
        }
        else
        {
            CheckIfStoppedMoving();
        }
    }

    private void CheckIfStartedMoving()
    {
        if(_isMoving == false)
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
        if(_isMoving == false)
        {
            StartJumping?.Invoke();
        }
        _isJumping = true;
    }

    private void CheckIfStartedSprinting()
    {
        if (_isMoving == false)
        {
            StartSprinting?.Invoke();
        }
        _isMoving = true;
    }
}
