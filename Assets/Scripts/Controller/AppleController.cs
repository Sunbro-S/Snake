using UnityEngine;

public class AppleController : MonoBehaviour
{
    public AppleView view;
    public Vector3 spawnAreaSize = new Vector3(10, 0, 10);

    void Start()
    {
        Respawn();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameEvents.OnAppleEaten?.Invoke();
            Respawn();
        }
    }

    void Respawn()
    {
        Vector3 randomPos = new Vector3(
            Random.Range(-spawnAreaSize.x, spawnAreaSize.x),
            0.5f,
            Random.Range(-spawnAreaSize.z, spawnAreaSize.z)
        );

        view.transform.position = randomPos;
    }
}