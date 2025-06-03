using UnityEngine;
using UnityEngine.AI;

public class NavMeshSpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    public GameObject prefabToSpawn;
    public float spawnRadius = 10f;
    public int maxAttempts = 10;
    public float sampleRadius = 1.5f;

    public void Spawn()
    {
        for (int i = 0; i < maxAttempts; i++)
        {
            Vector3 randomDirection = Random.insideUnitSphere * spawnRadius;
            randomDirection.y = 0f;

            Vector3 randomPoint = transform.position + randomDirection;

            if (NavMesh.SamplePosition(randomPoint, out NavMeshHit hit, sampleRadius, NavMesh.AllAreas))
            {
                Instantiate(prefabToSpawn, hit.position, Quaternion.identity);
                return;
            }
        }

        Debug.LogWarning("NavMeshSpawner: Failed to find valid position after maxAttempts.");
    }
}
