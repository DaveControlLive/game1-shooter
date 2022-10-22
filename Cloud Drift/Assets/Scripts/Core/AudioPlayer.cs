using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Player Shooting")]
    [SerializeField] AudioClip shootingLevel0Clip;
    [SerializeField] [Range(0f, 1f)] float shootingLevel0Volume = 1f;
    [SerializeField] AudioClip shootingLevel1Clip;
    [SerializeField] [Range(0f, 1f)] float shootingLevel1Volume = 1f;
    [SerializeField] AudioClip shootingLevel2Clip;
    [SerializeField] [Range(0f, 1f)] float shootingLevel2Volume = 1f;

    [Header("Player Damage")]
    [SerializeField] AudioClip playerDamageClip;
    [SerializeField] [Range(0f, 1f)] float damageVolume = 1f;
    [SerializeField] AudioClip playerDeathClip;
    [SerializeField] [Range(0f, 1f)] float playerDeathVolume = 1f;

    [Header("Enemy Damage")]
    [SerializeField] AudioClip enemyDamageClip;
    [SerializeField] [Range(0f, 1f)] float enemyDamageVolume = 1f;
    [SerializeField] AudioClip beholderBeamClip;
    [SerializeField] [Range(0f, 1f)] float beholderBeamVolume = 1f;
    [SerializeField] AudioClip enemySmallDeath;
    [SerializeField] [Range(0f, 1f)] float enemySmallDeathVolume = 1f;
    [SerializeField] AudioClip enemyMediumDeath;
    [SerializeField] [Range(0f, 1f)] float enemyMediumDeathVolume = 1f;
    [SerializeField] AudioClip enemyLargeDeath;
    [SerializeField] [Range(0f, 1f)] float enemyLargeDeathVolume = 1f;

    [Header("Upgrades")]
    [SerializeField] AudioClip capsuleDestroyedClip;
    [SerializeField] [Range(0f, 1f)] float capsuleDestroyedVolume = 1f;
    [SerializeField] AudioClip playerHealthClip;
    [SerializeField] [Range(0f, 1f)] float playerHealthVolume = 1f;
    [SerializeField] AudioClip playerPowerupClip;
    [SerializeField] [Range(0f, 1f)] float playerPowerupVolume = 1f;
    [SerializeField] AudioClip playerSpeedupClip;
    [SerializeField] [Range(0f, 1f)] float playerSpeedupVolume = 1f;

    public void PlayShootingClip(int upgradeLevel)
    {
        if(upgradeLevel == 0)
        {
            PlayClip(shootingLevel0Clip, shootingLevel0Volume);
        }
        if (upgradeLevel == 1)
        {
            PlayClip(shootingLevel1Clip, shootingLevel1Volume);
        }
        if (upgradeLevel == 2)
        {
            PlayClip(shootingLevel2Clip, shootingLevel2Volume);
        }
    }

    public void PlayDamageClip()
    {
        PlayClip(playerDamageClip, damageVolume);
    }

    public void PlayPlayerDeathClip()
    {
        PlayClip(playerDeathClip, playerDeathVolume);
    }

    public void PlayEnemyHitClip()
    {
        PlayClip(enemyDamageClip, enemyDamageVolume);
    }

    public void PlayBeholderBeamClip()
    {
        PlayClip(beholderBeamClip, beholderBeamVolume);
    }

    public void StopBeholderBeamClip()
    {
        Destroy(beholderBeamClip);
    }

    public void PlayEnemyDeathClip(int enemyLevel)
    {
        if(enemyLevel == 1)
        {
            PlayClip(enemySmallDeath, enemySmallDeathVolume);
        }
        if (enemyLevel == 2)
        {
            PlayClip(enemyMediumDeath, enemyMediumDeathVolume);
        }
        if (enemyLevel == 3)
        {
            PlayClip(enemyLargeDeath, enemyLargeDeathVolume);
        }
    }

    public void PlayCapsuleDestroyed()
    {
        PlayClip(capsuleDestroyedClip, capsuleDestroyedVolume);
    }

    public void PlayPlayerHealthClip()
    {
        PlayClip(playerHealthClip, playerHealthVolume);
    }

    public void PlayPlayerPowerupClip()
    {
        PlayClip(playerPowerupClip, playerPowerupVolume);
    }

    public void PlaySpeedupClip()
    {
        PlayClip(playerSpeedupClip, playerSpeedupVolume);
    }

    void PlayClip(AudioClip clip, float volume)
    {
        if (clip != null)
        {
            Vector3 cameraPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, cameraPos, volume);
        }
    }
}
