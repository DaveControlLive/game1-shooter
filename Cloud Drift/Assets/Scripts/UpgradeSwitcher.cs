using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSwitcher : MonoBehaviour
{
    [SerializeField] int currentSpeedUpgrade = 0;
    [SerializeField] int currentGunUpgrade = 0;
    [SerializeField] Transform upgradeAnim;
    [SerializeField] GameObject currentGun;
    [SerializeField] int healthUpgrade = 10;

    PlayerHealth playerHealth;

    Animator shipAnimator;
    AudioPlayer audioPlayer;

    void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
        shipAnimator = GetComponent<Animator>();
        playerHealth = GetComponent<PlayerHealth>();
    }

    void Start()
    {
        shipAnimator.SetInteger("UpgradeLevel", 0);
        SetSpeedUpgradeLevel();
        SetGunUpgradeLevel();
    }

    void Update()
    {
        int previousSpeedUpgrade = currentSpeedUpgrade;
        int previousGunUpgrade = currentGunUpgrade;

        ProcessKeyInput();

        if (previousSpeedUpgrade != currentSpeedUpgrade)
        {
            SetSpeedUpgradeLevel();
        }
        if (previousGunUpgrade != currentGunUpgrade)
        {
            SetGunUpgradeLevel();
        }
    }

    void SetSpeedUpgradeLevel()
    {
        int upgradeIndex = 0;

        foreach (Transform upgrade in upgradeAnim)
        {
            if (upgradeIndex <= currentSpeedUpgrade)
            {
                upgrade.gameObject.SetActive(true);
            }
            else
            {
                upgrade.gameObject.SetActive(false);
            }
            upgradeIndex++;
        }

        if(shipAnimator == null) { return; }

        shipAnimator.SetInteger("UpgradeLevel", currentSpeedUpgrade);
    }

    void SetGunUpgradeLevel()
    {
        int upgradeIndex = 0;

        foreach (Transform upgrade in currentGun.transform)
        {
            if (upgradeIndex + 1 == currentGunUpgrade)
            {
                upgrade.gameObject.SetActive(true);
            }
            else
            {
                upgrade.gameObject.SetActive(false);
            }
            upgradeIndex++;
        }
    }

    void ProcessKeyInput()
    {
        if (shipAnimator == null) { return; }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentSpeedUpgrade = 0;
            shipAnimator.SetInteger("UpgradeLevel", 0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentSpeedUpgrade = 1;
            shipAnimator.SetInteger("UpgradeLevel", 1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentSpeedUpgrade = 2;
            shipAnimator.SetInteger("UpgradeLevel", 2);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            currentGunUpgrade = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            currentGunUpgrade = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            currentGunUpgrade = 2;
        }
    }

    public int GetCurrentSpeedUpgrade()
    {
        return currentSpeedUpgrade;
    }

    public int GetCurrentWeaponUpgrade()
    {
        return currentGunUpgrade;
    }

    public void AddUpgrade(int upgradeType)
    {
        //Health
        if (upgradeType == 1)
        {
            playerHealth.GetHealth(healthUpgrade);
        }
        //Speed
        if (upgradeType == 2 && currentSpeedUpgrade < 2)
        {
            currentSpeedUpgrade++;
            audioPlayer.PlayPlayerPowerupClip();
            SetSpeedUpgradeLevel();
        }
        //Gun
        if (upgradeType == 3 && currentGunUpgrade < 2)
        {
            currentGunUpgrade++;
            audioPlayer.PlayPlayerPowerupClip();
            SetGunUpgradeLevel();
        }
    }
}
