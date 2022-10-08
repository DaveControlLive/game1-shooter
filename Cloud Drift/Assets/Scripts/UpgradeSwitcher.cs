using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSwitcher : MonoBehaviour
{
    [SerializeField] int currentUpgrade = 0;
    [SerializeField] GameObject upgradeAnim;

    Animator shipAnimator;

    void Start()
    {
        shipAnimator = GetComponent<Animator>();
        shipAnimator.SetInteger("UpgradeLevel", 0);
        SetUpgradeLevel();
    }

    void Update()
    {
        int previousUpgrade = currentUpgrade;

        ProcessKeyInput();

        if (previousUpgrade != currentUpgrade)
        {
            SetUpgradeLevel();
        }
    }

    void SetUpgradeLevel()
    {
        int upgradeIndex = 0;

        foreach (Transform upgrade in upgradeAnim.transform)
        {
            if (upgradeIndex <= currentUpgrade)
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
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentUpgrade = 0;
            shipAnimator.SetInteger("UpgradeLevel", 0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentUpgrade = 1;
            shipAnimator.SetInteger("UpgradeLevel", 1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentUpgrade = 2;
            shipAnimator.SetInteger("UpgradeLevel", 2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            currentUpgrade = 3;
            shipAnimator.SetInteger("UpgradeLevel", 2);
        }
    }

    public int GetCurrentUpgrade()
    {
        return currentUpgrade;
    }
}
