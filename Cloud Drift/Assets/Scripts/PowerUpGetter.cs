using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpGetter : MonoBehaviour
{

    UpgradeSwitcher upgradeSwitcher;

    int powerupType = 1;
    bool canGetPower = false;

    void Awake()
    {
        upgradeSwitcher = FindObjectOfType<UpgradeSwitcher>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && canGetPower)
        {
            PowerupGet();
        }
    }

    public void PowerupGet()
    {
        canGetPower = false;
        upgradeSwitcher.AddUpgrade(powerupType);
        Destroy(transform.parent.gameObject);
    }

    public void SetPowerup(int powerup)
    {
        canGetPower = true;
        powerupType = powerup;
    }
}
