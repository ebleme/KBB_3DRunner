using Unity.Cinemachine;
using UnityEngine;

namespace Ebleme.KBB3DRunner
{
    [RequireComponent(typeof(Rigidbody))]
    public class MoveWithRolling : MonoBehaviour
    {
        public float moveSpeed = 5f; // Kuvvet hızı
        public float torqueSpeed = 5f; // Tork hızı
        private Rigidbody rb;

        // private Vector3 movementInput;

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

            // Kuvvet uygula
            Vector3 force = new Vector3(moveX, 0, moveZ) * moveSpeed;
            rb.AddForce(force);


            // Tork uygula
            Vector3 torque = new Vector3(moveZ, 0, -moveX) * torqueSpeed;
            rb.AddTorque(torque);
            
            // movementInput = new Vector3(moveX, 0, moveZ) * moveSpeed;

        }

        [ContextMenu("Stop")]
        public void Stop(){
             rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
        
        // void FixedUpdate()
        // {
        //     // Mevcut hızı Lerp ile yumuşat
        //     Vector3 currentVelocity = rb.velocity;
        //     Vector3 targetVelocity = Vector3.Lerp(currentVelocity, movementInput, lerpSpeed * Time.fixedDeltaTime);
        //
        //     // Rigidbody'ye hedef hızı uygula
        //     rb.velocity = targetVelocity;
        // }
    }
}