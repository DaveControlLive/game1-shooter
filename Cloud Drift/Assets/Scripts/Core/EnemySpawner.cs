using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveConfigs;
    WaveConfigSO currentWave;

    bool waitForNextWave = false;

    void Start()
    {
        StartCoroutine(SpawnEnemyWaves());
    }

    IEnumerator SpawnEnemyWaves()
    {
        foreach(WaveConfigSO wave in waveConfigs)
        {
            currentWave = wave;
            for (int i = 0; i < currentWave.GetEnemyCount(); i++)
            {
                Instantiate(currentWave.GetEnemyPrefab(i),
                currentWave.GetStartingPosition(),
                Quaternion.identity,
                transform);
                yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
            }

            if (currentWave.WaitForNextWave())
            {
                waitForNextWave = true;
            }

            while (waitForNextWave)
            {
                yield return null;
            }

            yield return new WaitForSeconds(currentWave.GetTimeBeforeNextWave());
        }
    }

    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }

    public bool WaitForNextWave()
    {
        return waitForNextWave;
    }

    public void WaveIsOver()
    {
        waitForNextWave = false;
    }

}
