using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [Header("EnemyType")]
    [SerializeField] int enemyType = 1;

    [Header("Enemies in Wave")]
    [SerializeField] List<GameObject> enemyPrefabs;

    [Header("All Enemies in Wave:")]
    [SerializeField] Vector2 startingPosition = new Vector2(11, 0);
    [SerializeField] float timeBetweenEnemySpawns = 1f;
    [SerializeField] float spawnTimeVariance = 0f;
    [SerializeField] float minimumSpawnTime = 0.2f;
    [SerializeField] float timeBeforeNextWave = 0.5f;

    [Header("Carrot Enemy")]
    [SerializeField] float amplitude = 2f;
    [SerializeField] float frequency = 0.5f;
    [SerializeField] bool inverted;

    [Header("Ghost Jelly Enemy")]
    [SerializeField] float wobbleAmount = 1f;
    [SerializeField] float wobbleTime = 5f;
    [SerializeField] float yMax = 2.5f;
    [SerializeField] float yMin = -3.5f;

    [Header("Other unused for now")]
    [SerializeField] Transform pathPrefab;
    [SerializeField] float moveSpeed = 5f;

    public int GetEnemyType()
    {
        return enemyType;
    }

    public Transform GetEnemyPosition(int index)
    {
        return enemyPrefabs[index].transform;
    }

    public Transform GetStartingWaypoint()
    {
        return pathPrefab.GetChild(0);
    }

    public List<Transform> GetWaypoints()
    {
        List<Transform> waypoints = new List<Transform>();

        foreach(Transform child in pathPrefab)
        {
            waypoints.Add(child);
        }

        return waypoints;
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
}
