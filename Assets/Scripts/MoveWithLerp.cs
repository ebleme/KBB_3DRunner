using Unity.Cinemachine;
using UnityEngine;

/*
 Lerp (Linear Interpolation)
 Açıklama: İki pozisyon arasında yumuşak geçiş sağlar.

 Avantajları:
    Pürüzsüz ve estetik bir hareket oluşturur.
    Kullanımı kolaydır.

 Dezavantajları:
    Kontrolü zor olabilir (ör. ani durma yapmak zor).
    Daha karmaşık hesaplamalar için uygun değildir.

 Kullanım Alanları: Kamera hareketleri veya yumuşak geçiş gerektiren animasyonlar.
 */

namespace Ebleme.KBB3DRunner
{
    public class MoveWithLerp : MonoBehaviour
    {
        public float moveSpeed = 5f; // Hareket hızı
        public float lerpSpeed = 5f; // Lerp hızı
        private Vector3 targetPosition;

        void Start()
        {
            targetPosition = transform.position;
            FindAnyObjectByType<CinemachineCamera>().Follow = transform;
        }

        void Update()
        {
            // WASD tuşlarından input al
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveZ = Input.GetAxisRaw("Vertical");

            // Eğer input varsa hedef pozisyonu güncelle
            if (moveX != 0 || moveZ != 0)
            {
                Vector3 movement = new Vector3(moveX, 0, moveZ) * moveSpeed * Time.deltaTime;
                targetPosition += movement;
            }

            // Pozisyonu Lerp ile hedefe doğru hareket ettir
            transform.position = Vector3.Lerp(transform.position, targetPosition, lerpSpeed * Time.deltaTime);
        }
    }
}