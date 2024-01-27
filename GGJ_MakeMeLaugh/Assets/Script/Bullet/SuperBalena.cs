using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperBalena : MonoBehaviour
{
    public AudioSource audioSource;

    private void Start()
    {
        StartCoroutine(DestroyObject());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            EnemyStats enemyStats = collision.gameObject.GetComponent<EnemyStats>();

            enemyStats.Die();
        }
    }

    IEnumerator DestroyObject()
    {
        audioSource.Play();

        yield return new WaitForSeconds(2);

        Destroy(gameObject);
    }
}
