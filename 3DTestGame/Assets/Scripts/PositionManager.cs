using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PositionManager : MonoBehaviour
{
    [SerializeField] private Image positionDisplay;

    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform endPoint;

    void Update()
    {
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        positionDisplay.fillAmount = (playerTransform.position.z - startPoint.position.z) / (endPoint.position.z - startPoint.position.z);

    }
}
