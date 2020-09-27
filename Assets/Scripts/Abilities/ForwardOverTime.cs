using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardOverTime : MonoBehaviour
{
    private float moveSpeed = 7f;
    private Rigidbody rb;

    private Vector3 moveDirection;

    void Update()
    {
        rb = GetComponent<Rigidbody>();
        moveDirection = (transform.position).normalized * moveSpeed;
        rb.velocity = transform.forward * moveSpeed;
        Destroy(gameObject, 3.0f);
    }

}

