using System;
using Unity.Cinemachine;
using UnityEngine;

/*
 Açıklama: Nesnenin pozisyonunu doğrudan ayarlar.

 Avantajları:
    Kontrol edilebilir ve basittir.
    Matematiksel olarak tam pozisyon belirleme sağlar.
 
 Dezavantajları:
    Diğer fizik objeleriyle etkileşim mümkün değildir.
    Performans açısından sürekli pozisyon ayarlamak maliyetli olabilir.
 
 Kullanım Alanları: Fizik gerektirmeyen projelerde belirli pozisyonlara taşımak veya küçük hareketler.
 */

namespace Ebleme.KBB3DRunner
{
    public class MoveWithPosition : MonoBehaviour
    {
        public float moveSpeed = 5f;

        private void Start()
        {
            FindAnyObjectByType<CinemachineCamera>().Follow = transform;
        }

        void Update()
        {
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");
            
            if (moveX == 0 && moveZ == 0)
                return;
            
            Vector3 movement = new Vector3(moveX, 0, moveZ) * moveSpeed * Time.deltaTime;

            transform.position += movement;
        }
    }
}