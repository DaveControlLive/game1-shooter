using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostJellyMover : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2f;

    [SerializeField] bool inverted = false;

    WaveConfigSO waveConfig;
    EnemySpawner enemySpawner;

    float sinCenterY;

    void Awake()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    void Start()
    {
        waveConfig = enemySpawner.GetCurrentWave();
        sinCenterY = transform.position.y;
    }

    void FixedUpdate()
    {
        MoveRightToLeft();
        SinMovement();
    }

    void MoveRightToLeft()
    {
        Vector2 pos = transform.position;
        pos.x -= moveSpeed * Time.deltaTime;
        transform.position = pos;
    }

    void SinMovement()
    {
        Vector2 pos = transform.position;
        float sin = Mathf.Sin(pos.x * waveConfig.GetFrequency()) * waveConfig.GetAmplitude();
        if (inverted)
        {
            sin *= -1;
        }
        pos.y = sinCenterY + sin;

        transform.position = pos;
    }

    public void Stop()
    {
        moveSpeed = 0;
    }
}
