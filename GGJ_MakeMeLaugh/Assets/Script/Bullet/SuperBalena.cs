using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperBalena : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(DestroyObject());
    }

    private void OnCollisionEnter(Collision collision)
    {

    }

    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(2);

        Destroy(gameObject);
    }
}
