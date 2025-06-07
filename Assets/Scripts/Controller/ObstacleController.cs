using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SnakeController snake = other.GetComponent<SnakeController>();
            if (snake != null)
            {
                Debug.Log("���� ����� � �������-�����������!");
                snake.enabled = false;
                GameEvents.OnWallHit?.Invoke();
            }
        }
    }
}