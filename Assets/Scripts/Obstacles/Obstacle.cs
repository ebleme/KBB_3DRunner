using System;
using Ebleme.KBB3DRunner.Ant;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    /*
     * 1 çarpma sağlansın
     * 2 dead animasyonu oynasın
     * 3 game over sesi
     * 4 particle oynasın
     * 5. Animasyon bittikten sonra game over paneli gösterilsin (sahneyi yenileyebiliriz)
     * 6. Reklam gösterebiliriz
     */
    
    
    
    private void OnCollisionEnter(Collision _collidedObject)
    {
        if (_collidedObject.gameObject.CompareTag("Ant"))
        {
            Debug.Log("karınca çarptı");

            var player = FindFirstObjectByType<Player>();

            if (player != null)
            {
                player.Dead();
                
               
            }
        }
    }
}
