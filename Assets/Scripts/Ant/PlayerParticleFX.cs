using UnityEngine;

namespace Ebleme.KBB3DRunner.Ant
{
    public class PlayerParticleFX : MonoBehaviour
    {
        [SerializeField] private ParticleSystem smokeParticle;

        [SerializeField] private ParticleSystem collectibleFX;
        

        public void PlaySmoke()
        {
            smokeParticle.Play();
        }

        public void PlayCollectibleFX()
        {
            collectibleFX.Play();
        }
    }
}