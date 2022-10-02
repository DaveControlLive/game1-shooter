using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed;

    Vector2 moveDirection;


    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        float moveAmount = moveSpeed * Time.deltaTime;

        moveDirection.x = Input.GetAxisRaw("Horizontal") * moveAmount;
        moveDirection.y = Input.GetAxisRaw("Vertical") * moveAmount;

        transform.Translate(moveDirection.x, moveDirection.y, 0);
    }
}
