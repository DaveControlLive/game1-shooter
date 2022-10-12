using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotMover : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float amplitude = 2f;
    [SerializeField] float frequency = 0.5f;

    [SerializeField] bool inverted = false;

    float sinCenterY;

    void Start()
    {
        sinCenterY = transform.position.y;
    }

    void Update()
    {
        
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
        float sin = Mathf.Sin(pos.x * frequency) * amplitude;
        if (inverted)
        {
            sin *= -1;
        }
        pos.y = sinCenterY + sin;

        transform.position = pos;
    }
}
