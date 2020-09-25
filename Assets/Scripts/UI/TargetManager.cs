using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class TargetManager : MonoBehaviour
{
    // Public Declarations
    public Transform playerReference;
    public Image indicatorReference;
    public List<Transform> targetList;
    // Private Declarations
    private Vector3 indicatorVector;
    private Text textReference;
    private int targetRange;
    private int targetIndex;
    private bool targetValidated;

    // --
    void Awake()
    {
        // Store Indicator Text Object Reference
        textReference = indicatorReference.GetComponentInChildren<Text>();
    }
    // --
    void Start()
    {
        // Set Default Values
        targetIndex = 0;
        targetRange = 5;
        // Validate Target List Count
        targetValidated = targetList.Count > 0;
    }
    // --
    void LateUpdate()
    {
        // Check Player Status
        if (targetValidated)
        {
            if (LinearDistance(playerReference.position, targetList[targetIndex].position) < targetRange)
            {
                targetIndex = (targetIndex + 1) % targetList.Count;
            }
            // Update Indicator Position
            UpdateTargetSystem(targetIndex);
        }
    }
    // --
    public void UpdateTargetSystem(int index)
    {
        if (targetValidated)
        {
            // Set Indicator Status
            indicatorReference.gameObject.SetActive(RelativePosition(playerReference, targetList[index]));
            // Check Indicator Active Flag
            if (targetList[index].gameObject.activeInHierarchy)
            {
                // Update Distance Text
                textReference.text = LinearDistance(playerReference.position, targetList[index].position) + "m";
                // Update Indicator Rect Transform Position
                indicatorVector = indicatorReference.rectTransform.anchorMin;
                indicatorVector.x = Camera.main.WorldToViewportPoint(targetList[index].position).x;
                indicatorReference.rectTransform.anchorMin = indicatorVector;
                indicatorReference.rectTransform.anchorMax = indicatorVector;
            }
        }
    }
    // --
    public int LinearDistance(Vector3 playerPosition, Vector3 targetPosition)
    {
        // Zero YAxis
        playerPosition.y = 0;
        targetPosition.y = 0;
        // Return Linear Distance
        return Mathf.RoundToInt(Vector3.Distance(playerPosition, targetPosition));
    }
    // --
    private bool RelativePosition(Transform player, Transform target)
    {
        // Calculate Relavtive Position
        return Vector3.Dot(Vector3.forward, player.InverseTransformPoint(target.position).normalized) > 0;
    }
}