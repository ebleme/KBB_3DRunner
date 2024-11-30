using Unity.Cinemachine;
using UnityEngine;

/*
 Açıklama: Fizik bileşeni (Rigidbody) kullanılarak pozisyonu fizik motoruyla uyumlu şekilde taşır.

 Avantajları:
    Fizik motoru ile uyumlu çalışır.
    Çarpışmalar ve fizik hesaplamalarıyla uyumludur.
 Dezavantajları:
    Transform.Translate'e göre daha fazla işlem maliyeti gerektirir.
    Fizik bileşenine bağlı olduğundan daha karmaşıktır.

 Kullanım Alanları: Fizik tabanlı oyunlar (ör. çarpışmaların önemli olduğu oyunlar).
 */

namespace Ebleme.KBB3DRunner
{
    [RequireComponent(typeof(Rigidbody))]
    public class MoveWithRigidbody : MonoBehaviour
    {
        public float moveSpeed = 5f;
        private Rigidbody rb;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
            FindAnyObjectByType<CinemachineCamera>().Follow = transform;
        }

        void FixedUpdate()
        {
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");

            if (moveX == 0 && moveZ == 0)
                return;
                
            Vector3 movement = new Vector3(moveX, 0, moveZ) * moveSpeed * Time.fixedDeltaTime;

            rb.MovePosition(rb.position + movement);
        }
    }
}