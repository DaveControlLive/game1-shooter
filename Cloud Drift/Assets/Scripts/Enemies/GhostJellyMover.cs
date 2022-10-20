using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostJellyMover : MonoBehaviour
{
    float moveSpeed = 1f;

    float wobbleAmount;
    float wobbleTime;
    float yMax;
    float yMin;

    WaveConfigSO waveConfig;
    EnemySpawner enemySpawner;
    bool wobbleSwitcher = true;
    bool wobble = true;

    void Awake()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    void Start()
    {
        waveConfig = enemySpawner.GetCurrentWave();
        wobbleAmount = waveConfig.GetWobbleAmount();
        wobbleTime = waveConfig.GetWobbleTime();
        yMax = waveConfig.GetYMax();
        yMin = waveConfig.GetYMin();
        moveSpeed = waveConfig.GetMoveSpeed();

    }

    void FixedUpdate()
    {
        MoveRightToLeft();
        if (wobbleSwitcher)
        {
            StartCoroutine(WobbleOn());
        }
    }

    void MoveRightToLeft()
    {
        Vector2 pos = transform.position;
        pos.x -= moveSpeed * Time.deltaTime;

        if(wobble)
        {
            pos.y += moveSpeed * wobbleAmount * Time.deltaTime;
        }

        transform.position = pos;

        if(transform.position.x < -10.5)
        {
            AutoDestruct();
        }
    }

    IEnumerator WobbleOn()
    {
        wobbleSwitcher = false;
        wobble = !wobble;

        int wobbleDirection = Random.Range(0, 2);
        if (wobbleDirection < 1)
        {
            wobbleAmount = -wobbleAmount;
        }
        if (wobbleAmount > 0 && transform.position.y >= yMax)
        {
            wobbleAmount = -wobbleAmount;
        }
        if (wobbleAmount < 0 && transform.position.y <= yMin)
        {
            wobbleAmount = -wobbleAmount;
        }

        yield return new WaitForSeconds(wobbleTime);

        wobbleSwitcher = true;

    }

    void AutoDestruct()
    {
        Destroy(gameObject);
    }

    public void Stop()
    {
        moveSpeed = 0;
    }

}
