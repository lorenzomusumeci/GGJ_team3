using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inchiostro : MonoBehaviour
{
<<<<<<< HEAD
    public Rigidbody rbInchiostro;
    public GameObject truck;
=======
    private int life = 5;

    public Rigidbody rbInchiostro;
    public GameObject airDrop;

    private void Start()
    {
        Destroy(gameObject, life);
    }
>>>>>>> main

    private void OnCollisionEnter(Collision collision)
    {
        rbInchiostro.isKinematic = true;
        gameObject.transform.SetParent(collision.gameObject.transform);

        StartCoroutine(SpawnAirDrop());
    }

    IEnumerator SpawnAirDrop()
    {
        yield return new WaitForSeconds(2);

        Vector3 spawnPosition = transform.position;
<<<<<<< HEAD
        spawnPosition.y += 4;
        Instantiate(truck, spawnPosition, truck.transform.rotation);
=======
        spawnPosition.y += 6;
        Instantiate(airDrop, spawnPosition, airDrop.transform.rotation);
>>>>>>> main
        Destroy(gameObject);
    }
}
