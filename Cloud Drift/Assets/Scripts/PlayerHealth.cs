using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 50;
    [SerializeField] int currentHealth = 50;

    Animator shipAnimator;
    UpgradeSwitcher upgradeSwitcher;
    AudioPlayer audioPlayer;

    bool isDead = false;

    void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    void Start()
    {
        shipAnimator = GetComponent<Animator>();
        upgradeSwitcher = GetComponent<UpgradeSwitcher>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0 && !isDead)
        {
            StartCoroutine(Die());
        }
        else
        {
            StartCoroutine(PlayerDamaged());
        }
    }

    public void GetHealth(int health)
    {
        currentHealth += health;
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

        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
        audioPlayer.PlayPlayerDeathClip();
        GetComponent<PlayerController>().enabled = false;
        shipAnimator.SetTrigger("PlayerDeathTrigger");
        yield return new WaitForSeconds(0.8f);
        Destroy(gameObject);
    }
}
