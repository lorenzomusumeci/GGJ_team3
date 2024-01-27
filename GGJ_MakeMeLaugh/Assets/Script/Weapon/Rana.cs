using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rana : ShootManager
{
    public int bulletUpwardForce = 1;
    public GameObject rana;
    public Animator anim;
    public ExplodingBullet explodingBullet;

    private void Start()
    {
        explodingBullet.damage = 2;
        explodingBullet.radius = 4;
    }

    public override void Shoot()
    {
        audioSource.Play();
        anim.SetTrigger("Shoot");
        StartCoroutine(SpawnRana());

        GameObject bullet = Instantiate(prefabBullet, firePoint.position, firePoint.rotation);

        // Ottenere il componente Rigidbody dal proiettile
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

        // Verifica se il componente Rigidbody è presente
        if (bulletRb != null)
        {
            Vector3 forceToAdd = firePoint.forward * bulletSpeed + firePoint.up * bulletUpwardForce;
            // Applica la forza al proiettile
            bulletRb.AddForce(forceToAdd, ForceMode.Impulse);
        }
    }

    IEnumerator SpawnRana()
    {
        rana.SetActive(false);
        yield return new WaitForSeconds(4);
        rana.SetActive(true);
    }
}