using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutroPlayer : MonoBehaviour
{
    OutroCinematic outroCinematic;

    void Awake()
    {
        outroCinematic = FindObjectOfType<OutroCinematic>();
    }

    void Start()
    {
        outroCinematic.enabled = true;
        Destroy(gameObject);
    }
}
