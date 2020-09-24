using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShot : MonoBehaviour
{
    float moveSpeed = 7f;
    Rigidbody rb;
    Vector3 moveDirection;
    private LineRenderer lr;
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Laser();
        LaserShooting();
    }

    public void LaserShooting()
    {
        lr.SetPosition(0, transform.position);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider)
            {
                lr.SetPosition(1, hit.point);
            }
        }
        else lr.SetPosition(1, transform.forward * 5000);
    }


    public void Laser()
    {
        moveDirection = (transform.position).normalized * moveSpeed;
        rb.velocity = transform.forward * moveSpeed;
        Destroy(gameObject, 2.0f);
    }
}
