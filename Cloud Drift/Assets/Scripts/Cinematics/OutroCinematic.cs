using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class OutroCinematic : MonoBehaviour
{
    [SerializeField] float playerMoveSpeed = 0.5f;
    [SerializeField] float timeUntilCutscene = 3f;

    Vector3 startingPosition;
    Vector3 endingPosition = new Vector3(0, 0, 0);
    GameObject player;
    float travelTimer = 0f;
    float cutsceneTimer = 0f;

    bool cutscenePlayed = false;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        player.GetComponent<PlayerController>().enabled = false;
        startingPosition = player.transform.localPosition;
        StartCoroutine(MoveToCenter());
    }

    void Update()
    {
        if (!cutscenePlayed && cutsceneTimer >= timeUntilCutscene)
        {
            cutscenePlayed = true;
            PlayCutscene();
        }

        UpdateTimers();
    }

    IEnumerator MoveToCenter()
    {
        float travelPercent = 0f;
        while (travelPercent < 1f && !cutscenePlayed)
        {
            Vector3 startPosition = player.transform.localPosition;
            Vector3 endPosition = new Vector3(0,0,0);
            player.transform.localPosition = Vector3.Lerp(startPosition, endPosition, travelPercent);
            travelPercent += Time.deltaTime * playerMoveSpeed;
            yield return new WaitForEndOfFrame();
        }
    }

    void PlayCutscene()
    {
        GetComponent<PlayableDirector>().Play();
    }

    void UpdateTimers()
    {
        travelTimer += Time.deltaTime * playerMoveSpeed;
        cutsceneTimer += Time.deltaTime;
    }
}
