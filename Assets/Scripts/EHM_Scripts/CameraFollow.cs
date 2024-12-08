using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Camera mainCamera;
    private Transform playerTransform;
    private Vector3 offset;

    private void Awake()
    {
        mainCamera = Camera.main;
        playerTransform = GameObject.FindWithTag("Player").transform;
        offset = new Vector3(0f, 4f, -6f);
    }

    private void LateUpdate()
    {
        FollowPlayer(playerTransform);
    }
    private void FollowPlayer(Transform playerPosition)
    { // Adjust the offset as needed
        Vector3 targetPosition = playerPosition.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, 0.1f);
    }
}
