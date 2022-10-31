using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shooter.Core;

public class CursorController : MonoBehaviour
{
    [SerializeField] bool startScreen;
    [SerializeField] Vector3 startPositionUp = new Vector3(-189, -249, 0);
    [SerializeField] Vector3 startPositionDown = new Vector3(-189, -312, 0);
    [SerializeField] Vector3 endPositionUp = new Vector3(-189, -104, 0);
    [SerializeField] Vector3 endPositionDOwn = new Vector3(-189, -169, 0);

    bool startGame = true;
    GameSession gameSession;

    Vector3 positionUp;
    Vector3 positionDown;

    void Awake()
    {
        gameSession = FindObjectOfType<GameSession>();
    }

    void Start()
    {
        SetupCursorPositions();
        GetComponent<RectTransform>().localPosition = positionUp;
    }

    void SetupCursorPositions()
    {
        if (startScreen)
        {
            positionUp = startPositionUp;
            positionDown = startPositionDown;
        }
        else
        {
            positionUp = endPositionUp;
            positionDown = endPositionDOwn;
        }
    }

    void Update()
    {
        MoveCursor();
    }

    void MoveCursor()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            GetComponent<RectTransform>().localPosition = positionDown;
            startGame = false;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            GetComponent<RectTransform>().localPosition = positionUp;
            startGame = true;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (startGame && startScreen)
            {
                gameSession.AccessNextLevel();
            }
            else if (!startGame && startScreen)
            {
                Application.Quit();
            }
            else if (startGame && !startScreen)
            {
                gameSession.StartLevelOne();
            }
            else
            {
                gameSession.StartTitleScreen();
            }
        }
    }
}
