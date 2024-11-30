using UnityEngine;

namespace Ebleme.KBB3DRunner.MeshDrawing
{
    public class FullSprite : MonoBehaviour
    {
        private void Start()
        {
            Mesh mesh = new Mesh();

            // Sprite'ın dört köşe noktası
            Vector3[] vertices = new Vector3[]
            {
                new Vector3(0, 0, 0), // Köşe 1
                new Vector3(1, 0, 0), // Köşe 2
                new Vector3(0, 1, 0), // Köşe 3
                new Vector3(1, 1, 0)  // Köşe 4
            };

            // UV koordinatları
            Vector2[] uv = new Vector2[]
            {
                new Vector2(0, 0),
                new Vector2(1, 0),
                new Vector2(0, 1),
                new Vector2(1, 1)
            };

            // İki üçgenin indeksleri
            int[] triangles = new int[]
            {
                0, 1, 2, // Üçgen 1
                2, 1, 3  // Üçgen 2
            };

            // Mesh verilerini ayarla
            mesh.vertices = vertices;
            mesh.uv = uv;
            mesh.triangles = triangles;

            // Mesh'i bir GameObject'e ata
            MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
            MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
            meshFilter.mesh = mesh;

            // Material ekle (standart bir sprite shader kullan)
            meshRenderer.material = new Material(Shader.Find("Sprites/Default"));
        }
    }
}