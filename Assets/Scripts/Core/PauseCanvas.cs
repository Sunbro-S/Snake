using UnityEngine;

public class PauseCanvas : CanvasManager
{
    public SnakeController snake;
    public void SetSnake(SnakeController snake)
    {
        this.snake = snake;
    }
    private void Start()
    {
        ThisCanvas.enabled = false;
    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("זלאכ");

            IsShown = !IsShown;
            SetCanvas();
        }

    }

    private void SetCanvas()
    {
        if (IsShown)
        {
            snake.enabled = false;
            ShowCanvas();
        }
        else
        {
            snake.enabled = true;
            CloseCanvas();
        }
    }

    public void OnCanvas()
    {
        IsShown = !IsShown;
        snake.enabled = false;
        ShowCanvas();
    }
    public void OffCanvas()
    {
        IsShown = !IsShown;
        snake.enabled = true;
        CloseCanvas();
    }
}
