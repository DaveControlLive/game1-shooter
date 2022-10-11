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

    void PlayClip(AudioClip clip, float volume)
    {
        if (clip != null)
        {
            Vector3 cameraPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, cameraPos, volume);
        }
    }
}
