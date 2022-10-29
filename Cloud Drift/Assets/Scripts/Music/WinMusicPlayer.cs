using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinMusicPlayer : MonoBehaviour
{
    [Header("Intro")]
    [SerializeField] AudioClip winMusicClip;
    [SerializeField] [Range(0f, 1f)] float winMusicVolume;

    AudioPlayer audioPlayer;
    GameObject bossMusic;

    void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
        bossMusic = FindObjectOfType<BossMusicPlayer>().gameObject;

    }

    void Start()
    {
        if (bossMusic != null)
        {
            Destroy(bossMusic);
        }
        audioPlayer.GetComponent<AudioSource>().Stop();
        PlayWinMusic();
    }

    void PlayWinMusic()
    {
        audioPlayer.GetComponent<AudioSource>().volume = 1f;
        audioPlayer.GetComponent<AudioSource>().PlayOneShot(winMusicClip, winMusicVolume);

    }
}
