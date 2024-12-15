using UnityEngine;

namespace Ebleme.KBB3DRunner.Ant
{
    public class PlayerParticleFX : MonoBehaviour
    {
        [SerializeField] private ParticleSystem smokeParticle;

        public void PlaySmoke()
        {
            smokeParticle.Play();
        }
    }
}