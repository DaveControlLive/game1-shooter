using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int damage = 10;

    bool turnedOn = true;

    public int GetDamage()
    {
        return damage;
    }

    public void Hit()
    {
        Destroy(gameObject);
    }

    public bool IsOn()
    {
        return turnedOn;
    }

    public void TurnOff()
    {
        turnedOn = false;
    }
}
