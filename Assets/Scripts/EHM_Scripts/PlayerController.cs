using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const float BORDER_LEFT = -10f;
    private const float BORDER_RIGHT = 10f;

    [Header("Movement Settings")] [SerializeField]
    private float _movementSpeed = 10.0f;

    [SerializeField] private float _horizantalMovementSpeed = 7.5f;

    [SerializeField] private float _jumpForce = 600.0f;
    [SerializeField] private float _gravity = -2f;
    private CharacterController _characterController;
    private bool _isJumping;
    private bool _isGrounded;
    [SerializeField] private bool workOnce = false;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Debug.Log(_isGrounded);
        MovementPlayer();
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            Jump();
        }
    }

    private void MovementPlayer()
    {
        _characterController.Move(Vector3.forward * _movementSpeed * Time.deltaTime); //Foward movement)

        // Side movement with boundaries
        float horizontalInput = InputHandler.instance.GetMovementInputNormalized().x;
        Vector3 sideMovement = Vector3.right * horizontalInput * _horizantalMovementSpeed * Time.deltaTime;
        Vector3 newPosition = transform.position + sideMovement;

        newPosition.x = Mathf.Clamp(newPosition.x, BORDER_LEFT, BORDER_RIGHT);
        Vector3 movement = newPosition - transform.position;

        _characterController.Move(movement);
    }

    private void FixedUpdate()
    {
        CheckGrounded();
        ApplyGravity();
    }

    private void Jump()
    {
        _characterController.Move(Vector3.up * _jumpForce * Time.deltaTime);
        _isJumping = true;
        _characterController.transform.GetComponent<Animator>().SetBool("_isJump", true);
        _isGrounded = false;
    }

    private void CheckGrounded()
    {
        _isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.1f);
    }

    private void ApplyGravity()
    {
        if (!_isGrounded || _isJumping)
        {
            _characterController.Move(Vector3.up * _gravity * Time.fixedDeltaTime);
        }

        if (_isGrounded && _isJumping)
        {
            _isJumping = false;
            _characterController.transform.GetComponent<Animator>().SetBool("_isJump", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Check if the player touches to nextLevel Trigger
        if (other.CompareTag("LoadNextLevel") && workOnce)
        {
            GameManager.instance.LoadNextLevel = true;
            Debug.Log("LoadNextLevel");
            workOnce = false;
            if(_movementSpeed > 75f) return; // If player already reached max speed, no need to increase it again.
            _movementSpeed += 0.75f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("LoadNextLevel"))
        {
            workOnce = true;
        }
    }
}