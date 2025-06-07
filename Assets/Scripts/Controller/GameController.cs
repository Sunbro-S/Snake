using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class GameController : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject snakeHeadPrefab;
    public GameObject applePrefab;
    public GameObject bodyPartPrefab;
    public GameObject tailPrefab;

    [Header("Spawners")]
    public NavMeshSpawner appleSpawner;
    public List<GameObject> snakeSpawner;

    [Header("UI")]
    public UIAnimator loseScreenAnimator;
    public ScoreView scoreView;
    public PauseCanvas pauseCanvas;

    [Header("Audio")]
    public AudioManager audioManager;

    private ScoreModel scoreModel;

    private void Awake()
    {
        scoreModel = new ScoreModel();
    }


    private void OnEnable()
    {
        GameEvents.OnAppleEaten += OnAppleEaten;
        GameEvents.OnWallHit += OnWallHit;
    }

   

    private void OnDisable()
    {
        GameEvents.OnAppleEaten -= OnAppleEaten;
        GameEvents.OnWallHit -= OnWallHit;
    }

    private void Start()
    {
        audioManager.PlaySound(SoundType.Music);
        SpawnSnake();
        SpawnApple();
        SpawnApple();
        SpawnApple();
        SpawnApple();
        UpdateScoreView();
    }
    private void OnWallHit()
    {
        audioManager.PlaySound(SoundType.WallHit);
        audioManager.StopMusic();
        loseScreenAnimator.Show();
        audioManager.PlaySound(SoundType.Death);
    }
    private void OnAppleEaten()
    {
        scoreModel.AddPoint();
        UpdateScoreView();
        SpawnApple();
        audioManager.PlaySound(SoundType.Eat);
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
        if (snakeSpawner == null || snakeSpawner.Count == 0)
        {
            Debug.LogError("Нет доступных точек спавна змеи!");
            return;
        }

        int randomIndex = UnityEngine.Random.Range(0, snakeSpawner.Count);
        GameObject chosenSpawnPoint = snakeSpawner[randomIndex];

        GameObject snake = Instantiate(snakeHeadPrefab, chosenSpawnPoint.transform.position, chosenSpawnPoint.transform.rotation);
        SnakeController controller = snake.GetComponent<SnakeController>();
        pauseCanvas.SetSnake(controller);

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
