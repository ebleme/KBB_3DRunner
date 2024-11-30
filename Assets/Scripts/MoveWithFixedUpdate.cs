using Unity.Cinemachine;
using UnityEngine;

namespace Ebleme.KBB3DRunner
{
    public class MoveWithFixedUpdate : MonoBehaviour
    {
        public float moveSpeed = 5f; // Hareket hızı
        public float lerpSpeed = 10f; // Yumuşak geçiş hızı
        private Rigidbody rb;

        private float moveX, moveZ;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
            FindAnyObjectByType<CinemachineCamera>().Follow = transform;
        }

        void FixedUpdate()
        {
            // WASD tuşlarından input al
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");

            // Eğer input yoksa, hareket etme
            if (moveX == 0 && moveZ == 0)
                return;

            // Hedef pozisyonu güncelle
            Vector3 movement = new Vector3(moveX, 0, moveZ).normalized * (moveSpeed * Time.fixedDeltaTime);
            var targetPosition = transform.position + movement;

            // Mevcut pozisyonu Lerp ile hedef pozisyona yaklaştır
            transform.position = targetPosition;
        }
    }
}