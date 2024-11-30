using Unity.Cinemachine;
using UnityEngine;

namespace Ebleme.KBB3DRunner
{
    [RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
    public class MoveWithNavMeshAgent : MonoBehaviour
    {
        public float moveSpeed = 5f;
        private UnityEngine.AI.NavMeshAgent agent;

        void Start()
        {
            agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
            agent.speed = moveSpeed;
            
            FindAnyObjectByType<CinemachineCamera>().Follow = transform;
        }

        void Update()
        {
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");
            
            if (moveX == 0 && moveZ == 0)
                return;
            
            Vector3 movement = new Vector3(moveX, 0, moveZ);

            if (movement.magnitude > 0)
            {
                agent.Move(movement * Time.deltaTime);
            }
        }
    }
}