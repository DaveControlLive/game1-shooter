using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter.Core
{
    public class LoadNextLevel : MonoBehaviour
    {
        GameSession gameSession;

        void Awake()
        {
            gameSession = FindObjectOfType<GameSession>();
        }

        void Start()
        {
            gameSession.AccessNextLevel();
        }
    }

}