﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class TargetManager : MonoBehaviour
{
    [SerializeField] public Transform playerReference;
    [SerializeField] public Image indicatorReference;
    [SerializeField] public List<Transform> targetList;

    private Vector3 indicatorVector;
    private Text textReference;
    private int targetRange;
    private int targetIndex;
    private bool targetValidated;

    void Awake()
    {
        textReference = indicatorReference.GetComponentInChildren<Text>();
    }

    void Start()
    {

        targetIndex = 0;
        targetRange = 5;

        targetValidated = targetList.Count > 0;
    }

    void LateUpdate()
    {

        if (targetValidated)
        {
            if (LinearDistance(playerReference.position, targetList[targetIndex].position) < targetRange)
            {
                targetIndex = (targetIndex + 1) % targetList.Count;
            }
            UpdateTargetSystem(targetIndex);
        }
    }

    public void UpdateTargetSystem(int index)
    {
        if (targetValidated)
        {
            indicatorReference.gameObject.SetActive(RelativePosition(playerReference, targetList[index]));

            if (targetList[index].gameObject.activeInHierarchy)
            {
                textReference.text = LinearDistance(playerReference.position, targetList[index].position) + "m";

                indicatorVector = indicatorReference.rectTransform.anchorMin;
                indicatorVector.x = Camera.main.WorldToViewportPoint(targetList[index].position).x;
                indicatorReference.rectTransform.anchorMin = indicatorVector;
                indicatorReference.rectTransform.anchorMax = indicatorVector;
            }
        }
    }

    public int LinearDistance(Vector3 playerPosition, Vector3 targetPosition)
    {
        playerPosition.y = 0;
        targetPosition.y = 0;

        return Mathf.RoundToInt(Vector3.Distance(playerPosition, targetPosition));
    }

    private bool RelativePosition(Transform player, Transform target)
    {
        return Vector3.Dot(Vector3.forward, player.InverseTransformPoint(target.position).normalized) > 0;
    }
}