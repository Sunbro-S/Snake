public class ScoreModel
{
    public int CurrentScore { get; private set; } = 0;
    public int HighScore { get; private set; }

    public ScoreModel()
    {
        HighScore = SaveSystem.LoadHighScore();
    }

    public void AddPoint()
    {
        CurrentScore++;
        if (CurrentScore > HighScore)
        {
            HighScore = CurrentScore;
            SaveSystem.SaveHighScore(HighScore);
        }

        GameEvents.OnScoreChanged?.Invoke(CurrentScore, HighScore);
    }
}