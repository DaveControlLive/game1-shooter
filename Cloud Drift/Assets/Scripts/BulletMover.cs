using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMover : MonoBehaviour
{
    Vector2 direction;
    Vector2 velocity;
    float bulletSpeed;

    bool goTime = false;

    void Update()
    {
        if (goTime)
        {
            velocity = direction * bulletSpeed;
        }
    }

    void FixedUpdate()
    {
        if (goTime)
        {
            Vector2 pos = transform.position;
            pos += velocity * Time.deltaTime;
            transform.position = pos;
        }
        CheckPosition();
    }

    void CheckPosition()
    {
        if (transform.position.x <= -9.5f || transform.position.x >= 9.5f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    public void StartBullet(Vector2 gunDirection, float speed, float lifeTime)
    {
        direction = gunDirection;
        bulletSpeed = speed;
        Destroy(gameObject, lifeTime);

        goTime = true;
    }
}
