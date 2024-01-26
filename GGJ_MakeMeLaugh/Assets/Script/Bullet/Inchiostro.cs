using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inchiostro : MonoBehaviour
{
    public Rigidbody rbInchiostro;
    public GameObject truck;

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
        spawnPosition.y += 4;
        Instantiate(truck, spawnPosition, truck.transform.rotation);
        Destroy(gameObject);
    }
}
