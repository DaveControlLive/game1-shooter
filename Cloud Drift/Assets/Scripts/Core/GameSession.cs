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
            SceneManager.LoadScene(0);
            Destroy(gameObject);
        }

        public int GetCurrentLives()
        {
            return playerLives;
        }
    }
}
