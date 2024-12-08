using System;
using UnityEngine;

/// <summary>
/// Player hareketlerini sağlar
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;

    [SerializeField] private float moveSpeed = 10f;

    [SerializeField] private float swerveSpeed = 5f;

    [SerializeField] private Vector2 minMax = new Vector2(-3, 3);


    private bool isMoving = true;
    private float swerveInput;
    private float moveFactorX;
    private float lastFrameFingerPositionX;

    public void ChangeMoving(bool isMoving)
    {
        this.isMoving = isMoving;
    }

    private void Update()
    {
        swerveInput = -Input.GetAxis("Horizontal");
        
        HandleInput();
    }

    // void FixedUpdate()
    // {
    //     if (!isMoving)
    //         return;
    //     
    //     Vector3 movePos = moveSpeed * Time.fixedDeltaTime * Vector3.right;
    //     
    //     movePos.z = swerveInput * swerveSpeed * Time.fixedDeltaTime;
    //
    //     var newPos = rb.position + movePos;
    //     newPos.z = Mathf.Clamp(newPos.z, minMax.x, minMax.y);
    //     
    //     rb.MovePosition(newPos);
    // }


    void FixedUpdate()
    {
        if (!isMoving)
            return;

        Vector3 forwardMove = transform.forward * (moveSpeed * Time.fixedDeltaTime);

        // Swerve hareketi
        Vector3 horizontalMove = transform.right * moveFactorX;


        var newPos = rb.position + forwardMove + horizontalMove;
        newPos.z = Mathf.Clamp(newPos.z, minMax.x, minMax.y);

        // Rigidbody ile hareketi uygula
        rb.MovePosition(newPos);
    }

    void HandleInput()
    {
        // if (swerveInput != 0)
        // {
        //     // AD tuşları
        // }

#if UNITY_STANDALONE

        if (Input.GetMouseButtonDown(0)) // sol mouse basıldığında
        {
            lastFrameFingerPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0)) // sol mouse tuşu basılı tutulduğunda
        {
            float currentFrameFingerPositionX = Input.mousePosition.x;
            moveFactorX = (currentFrameFingerPositionX - lastFrameFingerPositionX) * swerveSpeed;
            lastFrameFingerPositionX = currentFrameFingerPositionX;
        }
        else if (Input.GetMouseButtonUp(0)) // sol mouse tuşu bırakıldığında
        {
            moveFactorX = 0f;
        }
    }

#elif UNITY_IOS || UNITY_ANDROID
        // Mobil cihazlar için touch inputu
        if (Input.touchCount > 0)
        {
            Debug.Log("Touch çalışıyor");
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                lastFrameFingerPositionX = touch.position.x;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                float currentFrameFingerPositionX = touch.position.x;
                moveFactorX = (currentFrameFingerPositionX - lastFrameFingerPositionX) * swerveSpeed;
                lastFrameFingerPositionX = currentFrameFingerPositionX;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                moveFactorX = 0f;
            }
        }
#endif
    }

}
