using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeholderCirclePath : MonoBehaviour
{
    WaveConfigSO waveConfig;
    EnemySpawner enemySpawner;

    [SerializeField] GameObject[] beholders;

    float circleMoveSpeed = 1f;
    float enterMoveSpeed = 0.005f;
    float rotationSpeed = 40;
    bool faceCenter = true;
    float leftBound = 0f;
    float rightBound = 4.5f;

    Vector3 rotater = new Vector3(0, 0, 1);

    Vector2 startLeft;
    Vector2 startRight;
    Vector2 startUp;
    Vector2 startDown;

    Vector2 endLeft;
    Vector2 endRight;
    Vector2 endUp;
    Vector2 endDown;

    bool moveLeft = true;

    void Awake()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    void Start()
    {
        GetWaveData();
        StartingPositions();
        CreateMiniBoss();
        if (faceCenter)
        {
            StartCoroutine(MoveIntoScene());
        }
        else
        {
            transform.position = new Vector2(14.5f, 0);
        }

    }

    void Update()
    {
        MoveLeftRight();
        RotateAround();
    }

    void GetWaveData()
    {
        waveConfig = enemySpawner.GetCurrentWave();
        circleMoveSpeed = waveConfig.GetCircleMoveSpeed();
        enterMoveSpeed = waveConfig.GetEnterMoveSpeed();
        rotationSpeed = waveConfig.GetRotationSpeed();
        faceCenter = waveConfig.GetFaceCenter();
        leftBound = waveConfig.GetLeftBound();
        rightBound = waveConfig.GetRightBound();
    }

    void StartingPositions()
    {
        if (faceCenter)
        {
            startLeft = new Vector2(-10.57f, 0);
            startRight = new Vector2(10.57f, 0);
            startUp = new Vector2(0, 10.57f);
            startDown = new Vector2(0, -10.57f);

            endLeft = new Vector2(-5.5f, 0);
            endRight = new Vector2(5.5f, 0);
            endUp = new Vector2(0, 5.5f);
            endDown = new Vector2(0, -5.5f);
        }
        else
        {
            startLeft = new Vector2(-3.5f, 0);
            startRight = new Vector2(3.5f, 0);
            startUp = new Vector2(0, 3.5f);
            startDown = new Vector2(0, -3.5f);
        }

        beholders[0].transform.position = startDown;
        beholders[1].transform.position = startLeft;
        beholders[2].transform.position = startUp;
        beholders[3].transform.position = startRight;
    }

    void CreateMiniBoss()
    {
        for (int i = 0; i < beholders.Length; i++)
        {
            beholders[i].GetComponent<EnemyHealth>().IsMiniBoss();
        }
    }

    IEnumerator MoveIntoScene()
    {
        float travelPercent = 0f;

        while (travelPercent < 1f)
        {
            for (int i = 0; i < beholders.Length; i++)
            {
                Vector3 startPosition = beholders[i].transform.localPosition;
                Vector3 endPosition = new Vector3();
                if (i == 0)
                {
                    endPosition = endDown;
                }
                if (i == 1)
                {
                    endPosition = endLeft;
                }
                if (i == 2)
                {
                    endPosition = endUp;
                }
                if (i == 3)
                {
                    endPosition = endRight;
                }
                    beholders[i].transform.localPosition = Vector3.Lerp(startPosition, endPosition, travelPercent);
            }
            travelPercent += Time.deltaTime * enterMoveSpeed;
            yield return new WaitForEndOfFrame();
        }
    }


    void MoveLeftRight()
    {
        if (!faceCenter)
        {
            if (moveLeft)
            {
                Vector2 newPos = new Vector2(transform.position.x - circleMoveSpeed * Time.deltaTime, transform.position.y);
                transform.position = newPos;
                if (transform.position.x <= leftBound)
                {
                    moveLeft = !moveLeft;
                }
            }
            else
            {
                Vector2 newPos = new Vector2(transform.position.x + circleMoveSpeed * Time.deltaTime, transform.position.y);
                transform.position = newPos;
                if (transform.position.x >= rightBound)
                {
                    moveLeft = !moveLeft;
                }
            }
        }
    }

    void RotateAround()
    {
        if (faceCenter)
        {
            //transform.RotateAround(transform.position, rotater, rotationSpeed * Time.deltaTime);
            transform.Rotate(rotater, rotationSpeed * Time.deltaTime);
        }

        if (!faceCenter)
        {
            transform.Rotate(rotater, rotationSpeed * Time.deltaTime);

            for (int i = 0; i < beholders.Length; i++)
            {
                if(beholders[i] == null) { return; }
                else
                {
                    beholders[i].transform.rotation = Quaternion.identity;
                }
            }

        }
    }

    public GameObject[] GetBeholders()
    {
        return beholders;
    }
}
