using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostJellyMover : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] float wobbleAmount = 1f;
    [SerializeField] float wobbleTime = 5f;
    [SerializeField] float yMax = 2.5f;
    [SerializeField] float yMin = -3.5f;

    WaveConfigSO waveConfig;
    EnemySpawner enemySpawner;
    bool wobbleSwitcher = true;
    bool wobble = true;
    bool moveUp = true;

    void Awake()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    void Start()
    {
        //waveConfig = enemySpawner.GetCurrentWave();
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

    public void Stop()
    {
        moveSpeed = 0;
    }

}
