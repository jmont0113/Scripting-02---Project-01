using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUI3D : MonoBehaviour
{
    [SerializeField] public Camera cam;
    [SerializeField] public GameObject objectToShow;

    void Start()
    {
        objectToShow.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, cam.transform.position.z + 2);
    }

    void Update()
    {
        objectToShow.transform.Rotate(Vector3.up * 2, Space.Self);
    }
}