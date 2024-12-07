using System;
using UnityEngine;

public class SwerveMovementTest : MonoBehaviour
{
    [Header("Movement Parameters")]
    public float forwardSpeed = 10f; // Speed of forward motion

    public float swerveSpeed = 5f; // How fast to swerve left and right
    public float maxSwerveDistance = 3f; // Limits how far you can swerve left or right

    private Rigidbody rb;
    private float swerveInput;
    private Vector3 targetPosition = Vector3.zero;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Get horizontal input (e.g., from keyboard or touch)
        swerveInput = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        // Calculate swerve position
        float targetZ = Mathf.Clamp(transform.position.z + swerveInput * swerveSpeed * Time.fixedDeltaTime, -maxSwerveDistance, maxSwerveDistance);

        float xPos = rb.position.x  + forwardSpeed * Time.fixedDeltaTime;
        // Apply forward movement
        // Move the Rigidbody smoothly to the target swerve position
        Vector3 targetPosition = new Vector3( xPos, 0, targetZ);
        rb.MovePosition(targetPosition);
    }
}