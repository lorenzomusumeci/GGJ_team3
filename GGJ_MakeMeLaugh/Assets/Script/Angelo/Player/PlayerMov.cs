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

    public LayerMask whatIsGround;
    public float groundDrag;
    private bool grounded;

    public Transform firePoint;
    public GameObject prefabBullet;
    public int bulletSpeed = 10;
    public int cooldownShoot = 1;
    public bool canShoot;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        rb.drag = groundDrag;
        canShoot = true;
    }

    void Update()
    {
        MyInput();

        /*Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        rb.MovePosition(transform.position + movement * Time.deltaTime * playerSpeed);*/

        if (Input.GetMouseButtonDown(0) && canShoot == true)
        {
            Sparo();
        }    
    }

    private void FixedUpdate()
    {
        MovePlayer();
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

    IEnumerator CooldownShoot()
    {
        canShoot = false;

        yield return new WaitForSeconds(cooldownShoot);

        canShoot = true;
    }
}
