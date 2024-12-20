using Unity.Cinemachine;
using UnityEngine;

namespace Ebleme.KBB3DRunner
{
    [RequireComponent(typeof(Rigidbody))]
    public class MoveWithLerpRigidbody : MonoBehaviour
    {
        public float moveSpeed = 5f; // Hareket hızı
        public float lerpSpeed = 10f; // Yumuşatma hızı
        private Rigidbody rb;
        // private Vector3 movementInput; // Hareket yönü
        private Vector3 targetPosition;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
            FindAnyObjectByType<CinemachineCamera>().Follow = transform;

            targetPosition = transform.position;
        }

        // void Update()
        // {
        //     float moveX = Input.GetAxis("Horizontal");
        //     float moveZ = Input.GetAxis("Vertical");

        //     movementInput = new Vector3(moveX, 0, moveZ) * moveSpeed;
        // }

        void FixedUpdate()
        {
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");

            if (moveX == 0 && moveZ == 0)
                return;
        
            Vector3 movement = new Vector3(moveX, 0, moveZ);


            targetPosition = rb.position + movement * moveSpeed * Time.fixedDeltaTime;

            // Rigidbody'yi yumuşak bir şekilde hedef pozisyona taşı
            rb.MovePosition(Vector3.Lerp(rb.position, targetPosition, lerpSpeed * Time.fixedDeltaTime));
        }
    }
}