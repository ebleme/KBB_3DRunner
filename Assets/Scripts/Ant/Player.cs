using System;
using UnityEngine;

namespace Ebleme.KBB3DRunner.Ant
{
    public class Player:MonoBehaviour
    {
        [SerializeField] private PlayerAnimation playerAnimation;
        [SerializeField] private PlayerMovement playerMovement;
        [SerializeField] private PlayerSounds playerSounds;
        [SerializeField] private PlayerParticleFX playerParticleFX;
        [SerializeField] private EnergyBar energyBar;
        
        
        private void Start()
        {
            playerAnimation.RunFast();
            energyBar.Set(100f);
        }

        [ContextMenu("Dead")]
        public void Dead()
        {
            // yürümeyi durdur
            playerMovement.ChangeMoving(false);
            // asnimasyon dead
            playerAnimation.Dead();
            
            // ses ölme sesi
            playerSounds.PlayerGameOver();
            
            // particle
            playerParticleFX.PlaySmoke();
        }

        private void Update()
        {
            // Movement Speed = */ EenrgyBar.Energy
            var energy = energyBar.CurrentEnergyForMoveFactor();
            Debug.Log(energy);
            playerMovement.SetMoveFactor(energy);
        }
    }
}