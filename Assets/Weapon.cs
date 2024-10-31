using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject bulletPrefab;

    void Update()
    {
        // Check for Q key press to shoot
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);
    }
}
