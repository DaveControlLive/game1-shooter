using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 20f;
    [SerializeField] float projectileLifetime = 1f;

    [SerializeField] GameObject gunLocation;
    [SerializeField] GameObject gun1;
    [SerializeField] GameObject gun2;
    [SerializeField] GameObject gun3;

    public void Shoot(int currentWeaponUpgrade)
    {

        //Create a new instance of a bullet at the position of the gun
        if (currentWeaponUpgrade == 0)
        {
            GameObject instance = Instantiate(gun1, gunLocation.transform.position, Quaternion.identity);
            Destroy(instance, projectileLifetime);

            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = transform.right * projectileSpeed; //Shoot the bullet "right"
            }
        }
        else if (currentWeaponUpgrade == 1)
        {
            GameObject instance = Instantiate(gun2, gunLocation.transform.position, Quaternion.identity);
            Destroy(instance, projectileLifetime);

            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = transform.right * projectileSpeed; //Shoot the bullet "right"
            }
        }
        else if (currentWeaponUpgrade == 2)
        {
            GameObject instance = Instantiate(gun3, gunLocation.transform.position, Quaternion.identity);
            Destroy(instance, projectileLifetime);

            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = transform.right * projectileSpeed; //Shoot the bullet "right"
            }
        }
    }
}
