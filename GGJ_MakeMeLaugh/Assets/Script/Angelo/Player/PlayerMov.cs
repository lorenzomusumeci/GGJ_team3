using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    public float playerSpeed = 100.0f;
    public Rigidbody rb;
    public GameObject prefabBullet;
    public Transform target;
    public int bulletSpeed = 10;


    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        rb.MovePosition(transform.position + movement * Time.deltaTime * playerSpeed);

        if (Input.GetMouseButtonDown(0))
        {
            Sparo();
        }    
    }

    public void Sparo()
    {
        GameObject bullet = Instantiate(prefabBullet, target.position, target.rotation);

        // Ottenere il componente Rigidbody dal proiettile
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

        // Verifica se il componente Rigidbody è presente
        if (bulletRb != null)
        {
            // Applica la forza al proiettile
            bulletRb.AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
        }

    }

}
