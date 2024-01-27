using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolla : MonoBehaviour
{
    public int life = 2;
    public int damage = 1;

    private void Update()
    {
        Destroy(gameObject, life);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
           
        }

        Destroy(gameObject);
    }
}
