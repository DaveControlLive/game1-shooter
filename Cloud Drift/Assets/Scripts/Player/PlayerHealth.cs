using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shooter.Core;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 50;
    [SerializeField] int currentHealth = 50;

    Animator shipAnimator;
    UpgradeSwitcher upgradeSwitcher;
    AudioPlayer audioPlayer;
    CameraFX cameraFX;
    GameSession gameSession;

    bool isDead = false;

    void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
        cameraFX = Camera.main.GetComponent<CameraFX>();
        gameSession = FindObjectOfType<GameSession>();
    }

    void Start()
    {
        shipAnimator = GetComponent<Animator>();
        upgradeSwitcher = GetComponent<UpgradeSwitcher>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        ShakeCamera();
        UpdateAberration();
        if (currentHealth <= 0 && !isDead)
        {
            StartCoroutine(Die());
        }
        else
        {
            StartCoroutine(PlayerDamaged());
        }
    }

    void ShakeCamera()
    {
        if(cameraFX != null)
        {
            cameraFX.Play();
        }
    }

    void UpdateAberration()
    {
        if(cameraFX != null)
        {
            float healthDifference = ((float)currentHealth / (float)maxHealth);
            cameraFX.UpdateAberration(healthDifference);
        }
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    public void GetHealth(int health)
    {
        currentHealth += health;
        UpdateAberration();
        audioPlayer.PlayPlayerHealthClip();
        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        if (damageDealer != null)
        {
            if (other.tag == "Enemy")
            {
                if (damageDealer.IsOn())
                {
                    TakeDamage(damageDealer.GetDamage());
                }
            }
            if (other.tag == "Bullet")
            {
                TakeDamage(damageDealer.GetDamage());
                damageDealer.Hit();
            }
        }
    }

    IEnumerator PlayerDamaged()
    {
        audioPlayer.PlayDamageClip();
        GetComponent<SpriteRenderer>().material.SetFloat("_FlashAmount", 1f);
        yield return new WaitForSeconds(0.05f);
        GetComponent<SpriteRenderer>().material.SetFloat("_FlashAmount", 0f);
    }

    IEnumerator Die()
    {
        isDead = true;
        GetComponent<BoxCollider2D>().enabled = false;

        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
        audioPlayer.GetComponent<AudioSource>().Stop();
        audioPlayer.PlayPlayerDeathClip();
        GetComponent<PlayerController>().enabled = false;
        shipAnimator.SetTrigger("PlayerDeathTrigger");
        yield return new WaitForSeconds(0.8f);
        GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(2.5f);
        ResetLevel();
    }

    void ResetLevel()
    {
        gameSession.ProcessPlayerDeath();
    }
}
