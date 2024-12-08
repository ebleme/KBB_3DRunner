using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Ebleme.KBB3DRunner.Ant
{
    public class Player:MonoBehaviour
    {
        [SerializeField] private PlayerAnimation playerAnimation;
        [SerializeField] private PlayerMovement playerMovement;

        private void Start()
        {
            playerAnimation.RunFast();
        }

        [ContextMenu("Dead")]
        public void Dead()
        {
            playerMovement.ChangeMoving(false);
            playerAnimation.Dead();
        }
    }
}