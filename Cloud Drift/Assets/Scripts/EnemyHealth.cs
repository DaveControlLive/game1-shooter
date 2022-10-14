using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int enemyLevel = 1;
    [SerializeField] int totalHealth = 10;
    [SerializeField] SpriteRenderer spriteRenderer;
    int currentHealth;

    AudioPlayer audioPlayer;
    Animator enemyAnimator;

    bool isDead;

    void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
        enemyAnimator = GetComponent<Animator>();
    }

    void Start()
    {
        currentHealth = totalHealth;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PlayerWeapon" && !isDead)
        {
            DamageDealer damageDealer = other.GetComponent<DamageDealer>();

            if (damageDealer != null)
            {
                TakeDamage(damageDealer.GetDamage());
                damageDealer.Hit();
            }
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            StartCoroutine(Die());
        }
        else
        {
            audioPlayer.PlayEnemyHitClip();
            StartCoroutine(EnemyHitFlash());
        }
    }

    IEnumerator Die()
    {
        isDead = true;
        GetComponent<DamageDealer>().TurnOff();
        float animationWait = 0.4f;
        if (enemyLevel == 1)
        {
            animationWait = 0.4f;
            //GetComponent<CarrotMover>().Stop();
        }
        if (enemyLevel == 2)
        {
            animationWait = 0.5f;
        }
        if (enemyLevel == 3)
        {
            animationWait = 0.7f;
        }

        audioPlayer.PlayEnemyDeathClip(enemyLevel);
        enemyAnimator.SetTrigger("IsDead");

        yield return new WaitForSeconds(animationWait);
        Destroy(gameObject);
    }

    IEnumerator EnemyHitFlash()
    {
        spriteRenderer.material.SetFloat("_FlashAmount", 1f);
        yield return new WaitForSeconds(0.05f);
        spriteRenderer.material.SetFloat("_FlashAmount", 0f);
    }
}
