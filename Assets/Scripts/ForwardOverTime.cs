using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardOverTime : MonoBehaviour
{
    float moveSpeed = 7f;
    Rigidbody rb;

    Vector3 moveDirection;

    void Update()
    {
        rb = GetComponent<Rigidbody>();
        moveDirection = (transform.position).normalized * moveSpeed;
        rb.velocity = transform.forward * moveSpeed;
        Destroy(gameObject, 3.0f);
    }

}

