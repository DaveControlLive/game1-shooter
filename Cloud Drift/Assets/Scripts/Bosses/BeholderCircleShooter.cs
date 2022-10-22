using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeholderCircleShooter : MonoBehaviour
{
    EnemySpawner enemySpawner;
    WaveConfigSO waveConfig;

    float timeBetweenBeams = 2.8f;
    float chargeLength = 0.5f;
    float beamLength = 3f;

    int randomNumber;

    bool beholderDied = false;

    GameObject[] beholders;

    List<Transform> elements = new List<Transform>();

    bool fireNew = true;

    void Awake()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    void Start()
    {
        waveConfig = enemySpawner.GetCurrentWave();
        SetUpValues();
    }

    void SetUpValues()
    {
        timeBetweenBeams = waveConfig.GetTimeBetweenBeams();
        chargeLength = waveConfig.GetChargeLength();
        beamLength = waveConfig.GetBeamLength();
        beholders = GetComponent<BeholderCirclePath>().GetBeholders();
    }

    void Update()
    {
        GetRandomBeholder();
        CheckBeholderDeath();
    }

    void GetRandomBeholder()
    {
        if (fireNew)
        {
            randomNumber = Random.Range(0, beholders.Length);
            if (beholders[randomNumber].activeSelf == false) { return; }
            else
            {
                StartCoroutine(FireNewBeam());
            }

        }
    }

    IEnumerator FireNewBeam()
    {
        fireNew = false;
        beholders[randomNumber].GetComponent<BeholderShooter>().StartNewBeam();
        yield return new WaitForSeconds(timeBetweenBeams + chargeLength + beamLength);
        fireNew = true;
    }

    void CheckBeholderDeath()
    {
        if (beholderDied)
        {
            beholderDied = false;
            if (beholders[randomNumber].activeSelf == false)
            {
                StopAllCoroutines();
                fireNew = true;
            }
        }
    }

    public void BeholderDied()
    {
        beholderDied = true;
    }
}
