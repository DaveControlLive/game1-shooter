using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Shooter.Core;

namespace Shooter.UI
{
    public class UIScore : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI scoreText;
        [SerializeField] float transparencyAmount = 0.5f;

        GameSession gameSession;
        Transform player;
        PlayerHealth playerHealth;

        int score;
        bool transparentUI = false;
        bool playing = false;

        void Awake()
        {
            gameSession = FindObjectOfType<GameSession>();
            playerHealth = FindObjectOfType<PlayerHealth>();
            if (playerHealth != null)
            {
                player = playerHealth.GetComponent<Transform>();
                playing = true;
            }
        }

        void Start()
        {
            UpdateScore();
        }

        void Update()
        {
            if (playing)
            {
                UpdateTransparency();
                UpdateScore();
            }
        }

        void UpdateTransparency()
        {
            if (!transparentUI && (player.position.x > -3.27 && player.position.x < 2.92 &&
                                player.position.y > 4.01))
            {
                scoreText.alpha = transparencyAmount;
                transparentUI = !transparentUI;
            }
            if (transparentUI && (player.position.x < -3.27 || player.position.x > 2.92 ||
                                player.position.y < 4.01))
            {
                scoreText.alpha = 1f;
                transparentUI = !transparentUI;
            }
        }

        void UpdateScore()
        {
            score = gameSession.GetScore();
            if (playing)
            {
                scoreText.text = score.ToString();
            }
            else
            {
                scoreText.text = "SCORE: " + score.ToString();
            }
        }
    }

}