using UnityEngine;

public class Fractal3D : MonoBehaviour
{
    [Header("Fractal Settings")]
    public int maxDepth = 4;
    public float scaleFactor = 0.5f;
    public float spawnDistance = 1.5f;

    private int depth;

    void Start()
    {
        if (depth < maxDepth)
        {
            SpawnChildren();
        }
    }

    void SpawnChildren()
    {
        Vector3[] directions =
        {
            Vector3.up,
            Vector3.down,
            Vector3.left,
            Vector3.right,
            Vector3.forward,
            Vector3.back
        };

        foreach (Vector3 dir in directions)
        {
            GameObject child = Instantiate(
                gameObject,
                transform.position + dir * spawnDistance,
                Quaternion.identity
            );

            Fractal3D fractal = child.GetComponent<Fractal3D>();
            fractal.depth = depth + 1;

            child.transform.localScale = transform.localScale * scaleFactor;
        }
    }
}
