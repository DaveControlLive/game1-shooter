using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBossHealth : MonoBehaviour
{
    EnemySpawner enemySpawner;
    List<Transform> elements = new List<Transform>();

    int numDeaths = 0;

    void Awake()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    void Start()
    {
        AddElements();
    }

    void Update()
    {
        CheckForDeaths();
    }

    void AddElements()
    {
        foreach(Transform element in transform)
        {
            elements.Add(element);
        }
    }

    void CheckForDeaths()
    {
        if (numDeaths >= elements.Count)
        {
            Die();
        }
    }

    public void ElementDied()
    {
        numDeaths++;
        GetComponent<BeholderCircleShooter>().BeholderDied();
    }

    void Die()
    {
        if (enemySpawner.WaitForNextWave())
        {
            enemySpawner.WaveIsOver();
        }
        Destroy(gameObject);
    }
}
