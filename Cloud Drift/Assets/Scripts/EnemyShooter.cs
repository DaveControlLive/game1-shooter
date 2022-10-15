using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField] GameObject ghostJellyGuns;
    [SerializeField] GameObject ghostJellyAmmo;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float[] bullets;
    float projectileLifetime = 2f;

    EnemySpawner enemySpawner;
    WaveConfigSO currentWave;

    //enemyType 1 = Carrot, 2 = Ghost Jelly, enemyType 3 = Beholder. Passed in from WaveConfigSO
    int enemyType = 2;

    float shotDelay = 1f;
    bool waitForNextShot = false;
    bool isDying = false;

    void Awake()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    void Start()
    {
        currentWave = enemySpawner.GetCurrentWave();
        enemyType = currentWave.GetEnemyType(); 
    }

    void Update()
    {
        if (!waitForNextShot && !isDying)
        {
            StartCoroutine(ShootTimer());
        }
    }

    IEnumerator ShootTimer()
    {
        waitForNextShot = true;
        foreach (Transform gun in ghostJellyGuns.transform)
        {
            Shoot(gun);
        }
        yield return new WaitForSeconds(shotDelay);

        waitForNextShot = false;
    }

    void Shoot(Transform gun)
    {

        //rb.velocity = transform.forward isn't working for me, so above is an alternate method that's less ideal, I think.
        GameObject bullet = Instantiate(ghostJellyAmmo, gun.transform.position, Quaternion.identity);
        Vector2 direction = (gun.transform.localRotation * Vector2.left).normalized;
        bullet.GetComponent<BulletMover>().StartBullet(direction, projectileSpeed, projectileLifetime);

        //rb.velocity = transform.forward isn't working for me, so above is an alternate method that's less ideal, I think.
        //ShootAcross(bullet);
    }

    /*
    void ShootAcross(GameObject bullet)
    {
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = transform.forward * projectileSpeed;
        }
        Destroy(bullet, projectileLifetime);
    }
    */

    public void IsDying()
    {
        isDying = true;
    }
}
