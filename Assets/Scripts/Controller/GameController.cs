using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject snakeHeadPrefab;
    public GameObject applePrefab;
    public GameObject bodyPartPrefab;
    public GameObject tailPrefab;

    [Header("Spawners")]
    public NavMeshSpawner appleSpawner;
    public GameObject snakeSpawner;

    [Header("UI")]
    public ScoreView scoreView;

    private ScoreModel scoreModel;

    private void Awake()
    {
        scoreModel = new ScoreModel();
    }

    private void OnEnable()
    {
        GameEvents.OnAppleEaten += OnAppleEaten;
    }

    private void OnDisable()
    {
        GameEvents.OnAppleEaten -= OnAppleEaten;
    }

    private void Start()
    {
        SpawnSnake();
        SpawnApple();
        UpdateScoreView();
    }

    private void OnAppleEaten()
    {
        scoreModel.AddPoint();
        UpdateScoreView();
        SpawnApple();
    }

    private void UpdateScoreView()
    {
        if (scoreView != null)
        {
            scoreView.UpdateScore(scoreModel.CurrentScore, scoreModel.HighScore);
        }
    }

    private void SpawnSnake()
    {
        GameObject snake = Instantiate(snakeHeadPrefab, snakeSpawner.transform.position, Quaternion.identity);
        SnakeController controller = snake.GetComponent<SnakeController>();

        if (controller != null)
        {
            controller.view.bodyPrefab = bodyPartPrefab.transform;
            controller.view.tailPrefab = tailPrefab.transform;
        }
    }

    private void SpawnApple()
    {
        appleSpawner.Spawn();
    }

}
