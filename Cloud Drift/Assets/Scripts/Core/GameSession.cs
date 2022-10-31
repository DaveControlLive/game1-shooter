using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Shooter.Core
{
    public class GameSession : MonoBehaviour
    {
        [SerializeField] int playerLives = 3;

        int playerHealth;
        int maxHealth;
        int currentPower;
        int score = 0;

        static GameSession instance;

        public GameSession GetInstance()
        {
            return instance;
        }

        void Awake()
        {
            //Create a Singleton
            ManageSingleton();
        }

        void ManageSingleton()
        {
            if (instance != null)
            {
                gameObject.SetActive(false);
                Destroy(gameObject);
            }
            else
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }


        public void ProcessPlayerDeath()
        {
            if (playerLives > 1)
            {
                TakeLife();
            }
            else
            {
                ResetGameSession();
            }
        }

        public void AccessNextLevel()
        {
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            SceneManager.LoadScene(nextSceneIndex);
        }

        void TakeLife()
        {
            playerLives--;
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
        }

        void ResetGameSession()
        {
            SceneManager.LoadScene("GameOver");
            Destroy(gameObject);
        }

        public void StartLevelOne()
        {
            SceneManager.LoadScene(1);
            Destroy(gameObject);
        }

        public void StartTitleScreen()
        {
            SceneManager.LoadScene(0);
            Destroy(gameObject);
        }

        public int GetCurrentLives()
        {
            return playerLives;
        }

        public void AddToScore(int points)
        {
            score += points;
        }

        public int GetScore()
        {
            return score;
        }
    }
}
