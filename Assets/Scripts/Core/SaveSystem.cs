using UnityEngine;

public static class SaveSystem
{
    const string HighScoreKey = "HighScore";

    public static void SaveHighScore(int score)
    {
        PlayerPrefs.SetInt(HighScoreKey, score);
        PlayerPrefs.Save();
    }

    public static int LoadHighScore()
    {
        return PlayerPrefs.GetInt(HighScoreKey, 0);
    }
}