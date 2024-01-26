using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seppia : ShootManager
{
    public override void Shoot()
    {
        GameObject bullet = Instantiate(prefabBullet, firePoint.position, firePoint.rotation);

        audioSource.Play();

        // Ottenere il componente Rigidbody dal proiettile
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

        // Verifica se il componente Rigidbody è presente
        if (bulletRb != null)
        {
            // Applica la forza al proiettile
            bulletRb.AddForce(firePoint.forward * bulletSpeed, ForceMode.Impulse);
        }

    }
}