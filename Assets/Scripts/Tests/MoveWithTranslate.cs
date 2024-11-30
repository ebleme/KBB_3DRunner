using System;
using Unity.Cinemachine;
using UnityEngine;

/*
 Nesneyi yerel eksenlere göre doğrudan hareket ettirir.
 Avantajları:
        Basit ve hızlıdır.
        Fizik veya karmaşık sistemler gerektirmez.
        
Dezavantajları:
        Nesne diğer fizik objeleriyle etkileşime giremez.
        Fizik kurallarını ihlal eder (duvarlardan geçebilir).
        
Kullanım Alanları: Basit mekanikler veya fizik gerektirmeyen oyunlar (ör. menülerde kamera hareketi).
 */

namespace Ebleme.KBB3DRunner
{
    public class MoveWithTranslate : MonoBehaviour
    {
        public float moveSpeed = 5f;

        private void Start()
        {
            FindAnyObjectByType<CinemachineCamera>().Follow = transform;
        }

        void Update()
        {
            float moveX = Input.GetAxis("Horizontal"); // A, D veya Sol/Sağ oklar
            float moveZ = Input.GetAxis("Vertical"); // W, S veya Yukarı/Aşağı oklar
            
            if (moveX == 0 && moveZ == 0)
                return;
            
            Vector3 movement = new Vector3(moveX, 0, moveZ);

            transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
        }
    }
}