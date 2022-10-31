using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shooter.Core;

public class CursorController : MonoBehaviour
{
    [SerializeField] Vector3 positionUp = new Vector3(-189, -249, 0);
    [SerializeField] Vector3 positionDown = new Vector3(-189, -312, 0);

    bool startGame = true;
    GameSession gameSession;

    void Awake()
    {
        gameSession = FindObjectOfType<GameSession>();
    }

    void Start()
    {
        GetComponent<RectTransform>().localPosition = positionUp;
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
            if (startGame)
            {
                gameSession.AccessNextLevel();
            }
            else
            {
                Application.Quit();
            }
        }
    }
}
