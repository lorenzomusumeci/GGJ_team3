using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingBullet : MonoBehaviour
{
    public int damage = 1;
    public int radius;
    public GameObject explosionEffect;
    private int direction;

    private void Start()
    {
        direction = Random.Range(-180, 180);
    }

    private void Update()
    {
        transform.Rotate(Vector3.right * direction * 4 * Time.deltaTime); //
        transform.Rotate(Vector3.up * direction * 4 * Time.deltaTime);
    }

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
