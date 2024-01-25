using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingBullet : MonoBehaviour
{
    public int damage = 1;
    public int radius;
    public GameObject explosionEffect;

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);

        Collider [] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in colliders)
        {
            EnemyStats enemyStats = nearbyObject.GetComponent<EnemyStats>();

            if(enemyStats != null)
            {
                enemyStats.TakeDamage(damage);
            }
        }

        Destroy(gameObject);
    }
}
