using Unity.Cinemachine;
using UnityEngine;

/*
 Açıklama: Karakterlerin hareketini kontrol etmek için özel bir bileşen kullanır.
 
 Avantajları:
    Yerçekimi ve çarpışma gibi özelliklerle uyumlu çalışır.
    Fizik motorunu doğrudan kullanmaz, bu da daha pürüzsüz hareket sağlar.
 Dezavantajları:
    Rigidbody kadar esnek değildir.
    Yalnızca karakter kontrolüne odaklıdır.

 Kullanım Alanları: FPS, RPG gibi karakter odaklı oyunlar.

 */

namespace Ebleme.KBB3DRunner
{
    [RequireComponent(typeof(CharacterController))]
    public class MoveWithCharacterController : MonoBehaviour
    {
        public float moveSpeed = 5f;
        private CharacterController controller;

        void Start()
        {
            controller = GetComponent<CharacterController>();
            FindAnyObjectByType<CinemachineCamera>().Follow = transform;
        }

        void Update()
        {
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");
            
            if (moveX == 0 && moveZ == 0)
                return;
            
            Vector3 movement = new Vector3(moveX, 0, moveZ);

            controller.Move(movement * moveSpeed * Time.deltaTime);
        }
    }
}