using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootManager : MonoBehaviour
{
    public int bulletSpeed = 10;
    public float fireRate = 1f;
    public float nextTimeToFire = 0f;

    public AudioSource audioSource;
    public Transform firePoint;
    public GameObject prefabBullet;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    public virtual void Shoot()
    {
        
    }
}
