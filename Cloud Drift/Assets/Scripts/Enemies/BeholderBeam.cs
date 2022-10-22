using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeholderBeam : MonoBehaviour
{
    float chargeLength = 0.5f;
    float beamLength = 3f;

    bool isDead = false;
    GameObject beamParent;

    void Start()
    {
        StartCoroutine(ChargeBeam());
        beamParent = transform.parent.parent.gameObject;
    }

    void Update()
    {
        CheckForDeath();
    }

    IEnumerator ChargeBeam()
    {
        GetComponent<Animator>().SetBool("IsFiring", false);
        yield return new WaitForSeconds(chargeLength);
        ShootAndDie();
    }

    void ShootAndDie()
    {
        GetComponent<Animator>().SetBool("IsFiring", true);
        GetComponent<BoxCollider2D>().enabled = true;
        Destroy(gameObject, beamLength);
    }

    public void GetChargeLength(float charge)
    {
        chargeLength = charge;
    }

    public void GetBeamLength(float beam)
    {
        beamLength = beam;
    }

    void CheckForDeath()
    {
        isDead = beamParent.GetComponent<BeholderShooter>().GetIsDead();
        if (isDead)
        {
            Destroy(gameObject);
        }
    }

}
