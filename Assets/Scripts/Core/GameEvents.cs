using System;
using UnityEngine;

public static class GameEvents
{
    public static Action OnAppleEaten;
    public static Action OnWallHit;
    public static Action OnPauseHit;
    public static Action<int, int> OnScoreChanged;
}