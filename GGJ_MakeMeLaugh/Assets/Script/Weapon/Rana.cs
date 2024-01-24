using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rana : ShootManager
{
    public int bulletUpwardForce = 1;
    public override void Shoot()
    {
        GameObject bullet = Instantiate(prefabBullet, firePoint.position, firePoint.rotation);

        // Ottenere il componente Rigidbody dal proiettile
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

        // Verifica se il componente Rigidbody è presente
        if (bulletRb != null)
        {
            Vector3 forceToAdd = firePoint.forward * bulletSpeed + transform.up * bulletUpwardForce;
            // Applica la forza al proiettile
            bulletRb.AddForce(forceToAdd, ForceMode.Impulse);
        }

    }
}