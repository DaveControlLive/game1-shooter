using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CinematicControlRemover : MonoBehaviour
{
    GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        if (player == null)
        {
            player = GameObject.FindWithTag("Cursor");
        }

        GetComponent<PlayableDirector>().played += DisableControl;
        GetComponent<PlayableDirector>().stopped += EnableControl;
    }

    void DisableControl(PlayableDirector pm)
    {
        if (player.tag == "Player")
        {
            player.GetComponent<PlayerController>().enabled = false;
        }
        if (player.tag == "Cursor")
        {
            player.GetComponent<CursorController>().enabled = false;
        }
    }

    void EnableControl(PlayableDirector pm)
    {
        if(player.tag == "Player")
        {
            player.GetComponent<PlayerController>().enabled = true;
        }
        if(player.tag == "Cursor")
        {
            player.GetComponent<CursorController>().enabled = true;
        }
    }
}
