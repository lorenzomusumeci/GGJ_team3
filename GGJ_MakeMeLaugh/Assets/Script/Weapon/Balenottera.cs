using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balenottera : ShootManager
{
    public Bolla bolla;
    public Animator animator;

    private void Start()
    {
        bolla.damage = 1;
        fireRate = 1f;
    }

    public override void Shoot()
    {
        GameObject bullet = Instantiate(prefabBullet, firePoint.position, firePoint.rotation);

        audioSource.Play();
        animator.SetTrigger("A");

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
