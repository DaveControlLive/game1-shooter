using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMusicPlayer : MonoBehaviour
{
    [Header("Intro")]
    [SerializeField] AudioClip introBossClip;
    [SerializeField] [Range(0f, 1f)] float introBossVolume;
    [SerializeField] AudioClip bossMusicClip;
    [SerializeField] [Range(0f, 1f)] float bossMusicVolume;

    AudioPlayer audioPlayer;

    bool repeatBossMusic = false;

    void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    void Start()
    {
        audioPlayer.GetComponent<AudioSource>().Stop();
        StartCoroutine(PlayBossIntro());
    }

    void Update()
    {
        if (repeatBossMusic)
        {
            StartCoroutine(PlayBossMusic());
        }
    }

    IEnumerator PlayBossIntro()
    {
        audioPlayer.GetComponent<AudioSource>().volume = 1f;
        audioPlayer.GetComponent<AudioSource>().PlayOneShot(introBossClip, introBossVolume);
        yield return new WaitForSeconds(1.64f);
        repeatBossMusic = true;

    }

    IEnumerator PlayBossMusic()
    {
        repeatBossMusic = false;
        audioPlayer.GetComponent<AudioSource>().PlayOneShot(bossMusicClip, bossMusicVolume);
        yield return new WaitForSeconds(31.9f);
        repeatBossMusic = true;
    }
}
