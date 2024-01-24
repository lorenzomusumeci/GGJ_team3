using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    public Rigidbody rb;

    public float moveSpeed;
    private float horizontalInput;
    private float verticalInput;
    private Vector3 moveDirection;
    public Transform orientation;

    public float groundDrag;

    public Transform firePoint;
    public GameObject prefabBullet;
    public int bulletSpeed = 10;
    public int cooldownShoot = 1;
    public bool canShoot;

    public bool knockbacked;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        rb.drag = groundDrag;
        canShoot = true;
        knockbacked = false;
    }

    void Update()
    {
        MyInput();

        if (Input.GetMouseButtonDown(0) && canShoot == true)
        {
            Sparo();
        }    
    }

    private void FixedUpdate()
    {
        if(knockbacked == false)
        {
            MovePlayer();
        }     
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        //direzione del movimento
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        rb.AddForce(moveDirection.normalized * moveSpeed * 5f, ForceMode.Force);
    }

    public void Sparo()
    {
        GameObject bullet = Instantiate(prefabBullet, firePoint.position, firePoint.rotation);

        // Ottenere il componente Rigidbody dal proiettile
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

        // Verifica se il componente Rigidbody è presente
        if (bulletRb != null)
        {
            // Applica la forza al proiettile
            bulletRb.AddForce(firePoint.forward * bulletSpeed, ForceMode.Impulse);
        }

        StartCoroutine("CooldownShoot");
    }

    public IEnumerator CooldownShoot()
    {
        canShoot = false;

        yield return new WaitForSeconds(cooldownShoot);

        canShoot = true;
    }
}
