using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [Header("EnemyType")]
    [Tooltip("1 = Carrot, 2 = Ghost Jelly, 3 = Beholder")]
    [SerializeField] [Range(1,3)] int enemyType = 1;

    [Header("Power Up Type")]
    [Tooltip("1 = Health, 2 = Speed, 3 = Gun")]
    [SerializeField] [Range(1,3)] int powerupType = 1;

    [Header("Enemies in Wave")]
    [Tooltip("Add prefab(s) here of all of the enemies of 1 type you want in this wave.")]
    [SerializeField] List<GameObject> enemyPrefabs;

    [Header("All Enemies in Wave:")]
    [Tooltip ("Where the enemy starts, typically y is the thing you'll want to adjust.")]
    [SerializeField] Vector2 startingPosition = new Vector2(11, 0);
    [Tooltip("Movement speed of the enemy")]
    [SerializeField] float moveSpeed = 5f;
    [Tooltip("Amount of time in-between each enemy of the wave spawns")]
    [SerializeField] float timeBetweenEnemySpawns = 1f;
    [Tooltip("Spawn time variance allows a random amount of time they could within its range")]
    [SerializeField] float spawnTimeVariance = 0f;
    [SerializeField] float minimumSpawnTime = 0.2f;
    [Tooltip("Time before the next wave of enemies starts after final enemy of current wave is created")]
    [SerializeField] float timeBeforeNextWave = 0.5f;

    [Header("Carrot Enemy / Power Up")]
    [Tooltip("Amplitude of sinwave")]
    [SerializeField] float amplitude = 2f;
    [Tooltip("Frequency of sinwave")]
    [SerializeField] float frequency = 0.5f;
    [Tooltip("Invert the sinwave")]
    [SerializeField] bool inverted;

    [Header("Ghost Jelly Enemy")]
    [Tooltip ("How much does the Ghost Jelly travel up or down each wobble")]
    [SerializeField] float wobbleAmount = 1f;
    [Tooltip ("How frequently does the Ghost Jelly wobble")]
    [SerializeField] float wobbleTime = 5f;
    [Tooltip ("Max height on screen Ghost Jelly can travel")]
    [SerializeField] float yMax = 2.5f;
    [Tooltip ("Minimum height on screen Ghost Jelly can travel")]
    [SerializeField] float yMin = -3.5f;

    [Header("Beholder Enemy")]
    [Tooltip ("Add multiple paths here, and a random path will be chosen.")]
    [SerializeField] Transform[] pathPrefab;

    public int GetEnemyType()
    {
        return enemyType;
    }

    public Transform GetEnemyPosition(int index)
    {
        return enemyPrefabs[index].transform;
    }

    public Transform GetRandomPath()
    {
        int randomPath = Random.Range(0, pathPrefab.Length);
        Debug.Log(randomPath);

        return pathPrefab[randomPath];
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    public int GetEnemyCount()
    {
        return enemyPrefabs.Count;
    }

    public GameObject GetEnemyPrefab(int index)
    {
        return enemyPrefabs[index];
    }

    public float GetRandomSpawnTime()
    {
        float spawnTime = Random.Range(timeBetweenEnemySpawns - spawnTimeVariance,
                                       timeBetweenEnemySpawns + spawnTimeVariance);
        return Mathf.Clamp(spawnTime, minimumSpawnTime, float.MaxValue);
    }

    public float GetTimeBeforeNextWave()
    {
        return timeBeforeNextWave;
    }

    public float GetAmplitude()
    {
        return amplitude;
    }

    public float GetFrequency()
    {
        return frequency;
    }

    public bool GetInverted()
    {
        return inverted;
    }

    public Vector2 GetStartingPosition()
    {
        return startingPosition;
    }

    public float GetWobbleAmount()
    {
        return wobbleAmount;
    }

    public float GetWobbleTime()
    {
        return wobbleTime;
    }

    public float GetYMax()
    {
        return yMax;
    }

    public float GetYMin()
    {
        return yMin;
    }

    public int GetPowerupType()
    {
        return powerupType;
    }
}
