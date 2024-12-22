using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    
    
    [SerializeField] private AudioClip gameOver;
    [SerializeField] private AudioClip success;

    [SerializeField] private AudioClip collected;
    

    public void PlayerGameOver()
    {
        audioSource.PlayOneShot(gameOver);
    }

    public void PlaySuccess()
    {
        audioSource.PlayOneShot(success);
    }

    public void PlayCollected()
    {
        audioSource.PlayOneShot(collected);
    }
}
