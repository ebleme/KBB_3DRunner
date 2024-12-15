using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    
    
    [SerializeField] private AudioClip gameOver;
    [SerializeField] private AudioClip success;


    public void PlayerGameOver()
    {
        audioSource.PlayOneShot(gameOver);
    }

    public void PlaSuccess()
    {
        audioSource.PlayOneShot(success);
    }
}
