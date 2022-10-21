using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCollider : MonoBehaviour
{
    [SerializeField] Animator capsuleAnimator;
    [SerializeField] GameObject capsule;
    [SerializeField] GameObject powerUp;

    WaveConfigSO waveConfig;
    EnemySpawner enemySpawner;
    AudioPlayer audioPlayer;

    int powerupType;
    bool canGetPower;

    void Awake()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    void Start()
    {
        capsuleAnimator = GetComponent<Animator>();
        waveConfig = enemySpawner.GetCurrentWave();
        powerupType = waveConfig.GetPowerupType();

        ChangePowerup();
    }

    void ChangePowerup()
    {
        if (powerupType == 2)
        {
            capsuleAnimator.SetBool("SpeedUpgrade", true);
            powerUp.GetComponent<Animator>().SetBool("SpeedUpgrade", true);
        }
        if (powerupType == 3)
        {
            capsuleAnimator.SetBool("GunUpgrade", true);
            powerUp.GetComponent<Animator>().SetBool("GunUpgrade", true);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PlayerWeapon" && !canGetPower)
        {
            DamageDealer damageDealer = other.GetComponent<DamageDealer>();
            damageDealer.Hit();

            StartCoroutine(DestroyCapsule());
        }
    }

    IEnumerator DestroyCapsule()
    {
        GetComponent<PowerUpGetter>().SetPowerup(powerupType);
        GetComponent<PolygonCollider2D>().enabled = false;
        audioPlayer.PlayCapsuleDestroyed();
        canGetPower = true;

        capsuleAnimator.SetTrigger("CapsuleDestroyed");
        yield return new WaitForSeconds(0.5f);
        Destroy(capsule);
    }
}
