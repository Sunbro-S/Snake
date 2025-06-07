using UnityEngine;
using TMPro;

public class ScoreView : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    private void OnEnable()
    {
        GameEvents.OnScoreChanged += UpdateScore;
    }

    private void OnDisable()
    {
        GameEvents.OnScoreChanged -= UpdateScore;
    }

    public void UpdateScore(int score, int highScore)
    {
        scoreText.text = $"{score}";
        highScoreText.text = $"{SaveSystem.LoadHighScore()}";
    }
}