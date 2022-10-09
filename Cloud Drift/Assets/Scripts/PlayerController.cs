using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed;

    Vector2 moveDirection;

    [SerializeField] float paddingLeft;
    [SerializeField] float paddingRight;
    [SerializeField] float paddingTop;
    [SerializeField] float paddingBottom;

    Vector2 minBounds;
    Vector2 maxBounds;

    void Start()
    {
        InitBounds();
    }

    void Update()
    {
        MovePlayer();
    }

    //Set the bounds of the screen by using the camera viewport
    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0)); //Access bottom left of the screen
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1)); //Access top right of the screen
    }

    void MovePlayer()
    {
        //Calculate the speed & direction the player is moving and store it in moveDirection
        float moveAmount = moveSpeed * Time.deltaTime;
        moveDirection.x = Input.GetAxisRaw("Horizontal") * moveAmount;
        moveDirection.y = Input.GetAxisRaw("Vertical") * moveAmount;

        //Clamp the player into the bounds of the screen. Find the current position, add the moveSpeed + direction, then clamp
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + moveDirection.x, minBounds.x + paddingLeft, maxBounds.x - paddingRight);
        newPos.y = Mathf.Clamp(transform.position.y + moveDirection.y, minBounds.y + paddingBottom, maxBounds.y - paddingTop);

        //Set the new postion to be the player's movement within the new, clamped position
        transform.position = newPos;
    }

}
