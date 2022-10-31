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

        int score;
        bool transparentUI = false;

        void Awake()
        {
            gameSession = FindObjectOfType<GameSession>();
            player = FindObjectOfType<PlayerHealth>().GetComponent<Transform>();
        }

        void Start()
        {
            UpdateScore();
        }

        void Update()
        {
            UpdateTransparency();
            UpdateScore();
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
            scoreText.text = score.ToString();
        }
    }

}