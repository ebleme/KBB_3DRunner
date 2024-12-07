using UnityEngine;

namespace Ebleme.KBB3DRunner
{
    public class SwerveHandleInputTest : MonoBehaviour
    {
        public float moveSpeed = 5f; // İleri hareket hızı
        public float swerveSpeed = 0.01f; // Yatay hareket hassasiyeti
        public float maxSwerveAmount = 2f; // Maksimum sağa-sola kayma mesafesi
        public Rigidbody rb; // Rigidbody referansı

        private float lastFrameFingerPositionX;
        private float moveFactorX;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        void Update()
        {
            HandleInput();
        }

        void FixedUpdate()
        {
            // İleri doğru fiziksel hareket
            Vector3 forwardMove = transform.forward * moveSpeed * Time.fixedDeltaTime;

            // Swerve hareketi
            Vector3 horizontalMove = transform.right * moveFactorX;

            // Rigidbody ile hareketi uygula
            rb.MovePosition(rb.position + forwardMove + horizontalMove);
        }

        void HandleInput()
        {
#if UNITY_EDITOR || UNITY_STANDALONE
            // PC veya Editör için mouse inputu
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
            else if (Input.GetMouseButtonUp(0))
            {
                moveFactorX = 0f;
            }
#elif UNITY_IOS || UNITY_ANDROID
        // Mobil cihazlar için touch inputu
        if (Input.touchCount > 0)
        {
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
}