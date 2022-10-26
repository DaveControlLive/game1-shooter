using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Shooter.Core;

public class UIDisplay : MonoBehaviour
{
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

    void Awake()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
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
        UpdateHealth();
        UpdateUpgrades();
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
