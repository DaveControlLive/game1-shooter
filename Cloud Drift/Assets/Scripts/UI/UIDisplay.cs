using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    UpgradeSwitcher upgradeSwitcher;

    void Awake()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        upgradeSwitcher = FindObjectOfType<UpgradeSwitcher>();
    }

    void Start()
    {
        healthSlider.maxValue = playerHealth.GetCurrentHealth();
        powerSlider.maxValue = maxPower;
        speedSlider.maxValue = maxSpeed;
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
}
