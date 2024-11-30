using Unity.Cinemachine;
using UnityEngine;

/*
 Açıklama: Nesneye fiziksel bir kuvvet uygular, hızlanma sağlar.

 Avantajları:
    Gerçekçi hareketler oluşturur (ör. hızlanma ve yavaşlama).
    Fizik tabanlı hareketler için idealdir.
 Dezavantajları:
    Kontrol edilmesi zor olabilir (ani durma veya pozisyon belirleme zor).
    Çarpışmalarda kontrol kaybı olabilir.
 
 Kullanım Alanları: Araç simülasyonları, gerçekçi fizik gerektiren projeler.
 */

namespace Ebleme.KBB3DRunner
{
    [RequireComponent(typeof(Rigidbody))]
    public class MoveWithAddForce : MonoBehaviour
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
            
            Vector3 movement = new Vector3(moveX, 0, moveZ);

            rb.AddForce(movement * moveSpeed, ForceMode.Force);
        }
    }
}