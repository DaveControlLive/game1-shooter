using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] float animationSpeed = 1f;

    Vector2 offset;
    Material material;

    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    void Update()
    {
        offset = new Vector2(animationSpeed * Time.deltaTime, 0);
        material.mainTextureOffset += offset;
    }
}
