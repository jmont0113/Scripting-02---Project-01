using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownRotate : MonoBehaviour
{
    [SerializeField] public bool checkToRotate;
    [SerializeField] public float rotateSpeed = 15.0f;

    [SerializeField] public bool checkToFloat;
    [SerializeField] public float height = 0.5f;
    [SerializeField] public float upDownSpeed = 1f;

    private Vector3 startingPosition = new Vector3();
    private Vector3 tempPosition = new Vector3();

    void Start()
    {
        startingPosition = transform.position;
    }

    void Update()
    {
        if (checkToRotate)
        {
            transform.Rotate(new Vector3(0f, Time.deltaTime * rotateSpeed, 0f), Space.World);
        }

        if (checkToFloat)
        {
            tempPosition = startingPosition;
            tempPosition.y += Mathf.Sin(Time.fixedTime * Mathf.PI * upDownSpeed) * height;
            transform.position = tempPosition;
        }
    }
}
