using Unity.Cinemachine;
using Unity.Mathematics;
using UnityEngine;

namespace Ebleme.KBB3DRunner
{
    [RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
    public class MoveWithNavMeshAgent : MonoBehaviour
    {
        public float moveSpeed = 5f;
        private UnityEngine.AI.NavMeshAgent agent;

        public Transform findObject;

        bool isFindObject;
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
                agent.Move(movement * Time.deltaTime * moveSpeed);
            }

            if (movement.x > 0)
                transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
            else if (movement.x < 0)
                transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
            else if (movement.z > 0)
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            else if (movement.z < 0)
                transform.rotation = Quaternion.Euler(new Vector3(0, -180, 0));


            if (isFindObject)
            {
                if (agent.remainingDistance < 0.1f)
                {
                    agent.isStopped = true;
                    isFindObject = false;
                }
            }

        }


        [ContextMenu("Find Object")]
        public void GoToPosition()
        {

            agent.destination = findObject.position;
            agent.isStopped = false;

            isFindObject = true;
        }
    }
}