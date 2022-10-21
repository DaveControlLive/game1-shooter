using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeholderShooter : MonoBehaviour
{
    [SerializeField] GameObject beam;
    [SerializeField] Transform beholderGun;
    float timeBetweenBeams = 2.8f;
    float chargeLength = 0.5f;
    float beamLength = 3f;

    EnemySpawner enemySpawner;
    WaveConfigSO waveConfig;

    bool autoFire = true;
    bool startNewBeam = true;
    bool isDead = false;

    void Awake()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    void Start()
    {
        waveConfig = enemySpawner.GetCurrentWave();
        SetUpValues();
    }

    void SetUpValues()
    {
        timeBetweenBeams = waveConfig.GetTimeBetweenBeams();
        chargeLength = waveConfig.GetChargeLength();
        beamLength = waveConfig.GetBeamLength();

        if (waveConfig.GetIsMiniBoss())
        {
            startNewBeam = false;
            autoFire = false;
        }
    }

    void Update()
    {
        if (!isDead)
        {
            CheckForDeath();
            if (startNewBeam)
            {
                StartCoroutine(WaitToShoot());
            }
        }
    }

    void CheckForDeath()
    {
        if(GetComponent<EnemyHealth>().IsDead())
        {
            isDead = true;
            Destroy(beholderGun.gameObject);
        }
    }

    IEnumerator WaitToShoot()
    {
        startNewBeam = false;
        yield return new WaitForSeconds(timeBetweenBeams);
        StartCoroutine(ChargeBeam());
    }

    IEnumerator ChargeBeam()
    {
        GameObject newBeam = Instantiate(beam, beholderGun.position, Quaternion.identity, beholderGun.transform);
        newBeam.GetComponent<BeholderBeam>().GetChargeLength(chargeLength);
        newBeam.GetComponent<BeholderBeam>().GetBeamLength(beamLength);
        yield return new WaitForSeconds(chargeLength + beamLength);
        if (autoFire)
        {
            startNewBeam = true;
        }
    }

    public void TurnOffAutoFire()
    {
        autoFire = false;
    }

    public void StartNewBeam()
    {
        startNewBeam = true;
    }
}
