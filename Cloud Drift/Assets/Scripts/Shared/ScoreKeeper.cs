using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shooter.Core;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] int points = 100;

    GameSession gameSession;

    void Awake()
    {
        gameSession = FindObjectOfType<GameSession>();
    }

    public void AddToScore()
    {
        gameSession.AddToScore(points);
    }
}
