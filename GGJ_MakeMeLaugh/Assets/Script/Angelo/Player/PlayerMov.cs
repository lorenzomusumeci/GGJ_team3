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
    public Transform cameraPlayer;

    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        rb.MovePosition(transform.position + movement * Time.deltaTime * playerSpeed);

        if (Input.GetMouseButtonDown(0) && (GameObject.Find("PauseMenu").GetComponent<Pausa>().showPause == false))
        {
            Sparo();
        }    
    }

    public void Sparo()
    {
        GameObject bullet = Instantiate(prefabBullet, target.position, cameraPlayer.rotation);
        Vector3 direction = new Vector3(cameraPlayer.rotation.x, transform.rotation.y, 0);

        // Ottenere il componente Rigidbody dal proiettile
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

        // Verifica se il componente Rigidbody è presente
        if (bulletRb != null)
        {
            // Applica la forza al proiettile
            bulletRb.AddForce(direction * bulletSpeed, ForceMode.Impulse);
        }

    }

}
