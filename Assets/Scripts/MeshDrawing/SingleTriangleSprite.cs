using UnityEngine;

/*
 * Vertices, bir objenin geometrik yapısını oluşturmak için kullanılan noktalardır. Bu noktalar, 3D veya 2D bir objenin şeklini tanımlar.
 * UV, bir Mesh üzerindeki dokunun (texture) nasıl haritalanacağını tanımlayan koordinatlardır.
 * Triangles, bir mesh'in hangi köşe noktalarının bir araya getirilerek yüzey oluşturacağını tanımlar.
 */

namespace Ebleme.KBB3DRunner.MeshDrawing
{
    public class SingleTriangleSprite : MonoBehaviour
    {
        private void Start()
        {
            Mesh mesh = new Mesh();

            // Üçgenin köşe noktaları
            // Vertices, bir objenin geometrik yapısını oluşturmak için kullanılan noktalardır. Bu noktalar, 3D veya 2D bir objenin şeklini tanımlar.
            Vector3[] vertices = new Vector3[]
            {
                new Vector3(0, 0, 0), // Köşe 1
                new Vector3(1, 0, 0), // Köşe 2
                new Vector3(0, 1, 0) // Köşe 3
            };

            // Üçgenin UV koordinatları
            // UV, bir Mesh üzerindeki dokunun (texture) nasıl haritalanacağını tanımlayan koordinatlardır.
            Vector2[] uv = new Vector2[]
            {
                new Vector2(0, 0),
                new Vector2(1, 0),
                new Vector2(0, 1)
            };

            // Üçgenin indeksleri
            // Triangles, bir mesh'in hangi köşe noktalarının bir araya getirilerek yüzey oluşturacağını tanımlar.
            int[] triangles = new int[]
            {
                0, 1, 2 // Üçgen 1
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