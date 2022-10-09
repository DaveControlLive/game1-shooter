using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 50;
    [SerializeField] int currentHealth = 50;

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void GetHealth(int health)
    {
        currentHealth += health;
        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}
