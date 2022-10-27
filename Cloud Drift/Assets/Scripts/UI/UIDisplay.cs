using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Shooter.Core;

namespace Shooter.UI
{
    public class UIDisplay : MonoBehaviour
    {
        Transform player;

        [Header("HUD Hide Alpha")]
        [SerializeField] float transparencyAmount = 0.5f;

        [Header("Health")]
        [SerializeField] Slider healthSlider;
        PlayerHealth playerHealth;

        [Header("PowerUp")]
        [SerializeField] Slider powerSlider;
        [SerializeField] int maxPower = 2;
        int currentPower;

        [Header("SpeedUp")]
        [SerializeField] Slider speedSlider;
        [SerializeField] int maxSpeed = 2;
        int currentSpeed;

        [Header("Lives")]
        [SerializeField] Transform[] livesDisplay;
        int currentLives = 3;

        UpgradeSwitcher upgradeSwitcher;
        GameSession gameSession;

        bool transparentUI = false;

        void Awake()
        {
            playerHealth = FindObjectOfType<PlayerHealth>();
            player = playerHealth.GetComponent<Transform>();
            upgradeSwitcher = FindObjectOfType<UpgradeSwitcher>();
            gameSession = FindObjectOfType<GameSession>();
        }

        void Start()
        {
            healthSlider.maxValue = playerHealth.GetMaxHealth();
            powerSlider.maxValue = maxPower;
            speedSlider.maxValue = maxSpeed;
            UpdateLives();
        }

        void Update()
        {
            UpdateTransparency();
            UpdateHealth();
            UpdateUpgrades();
        }

        void UpdateTransparency()
        {
            if (!transparentUI && player.position.x < -3.83 && player.position.y < -2.54)
            {
                GetComponent<CanvasGroup>().alpha = transparencyAmount;
                transparentUI = !transparentUI;
            }
            if (transparentUI && (player.position.x > -3.83 || player.position.y > -2.54))
            {
                GetComponent<CanvasGroup>().alpha = 1f;
                transparentUI = !transparentUI;
            }
        }

        void UpdateHealth()
        {
            healthSlider.value = playerHealth.GetCurrentHealth();
        }

        void UpdateUpgrades()
        {
            powerSlider.value = upgradeSwitcher.GetCurrentWeaponUpgrade();
            speedSlider.value = upgradeSwitcher.GetCurrentSpeedUpgrade();
        }

        void UpdateLives()
        {
            int newLives = gameSession.GetInstance().GetCurrentLives();
            if (currentLives != newLives)
            {
                livesDisplay[currentLives - 1].GetComponent<Image>().enabled = false;
                currentLives = newLives;
                livesDisplay[currentLives - 1].GetComponent<Image>().enabled = true;
            }
        }

        public void ResetValues()
        {
            playerHealth = FindObjectOfType<PlayerHealth>();
            upgradeSwitcher = FindObjectOfType<UpgradeSwitcher>();
            print(playerHealth.GetCurrentHealth());
        }
    }

}