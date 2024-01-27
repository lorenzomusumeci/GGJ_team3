using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class CamMov : MonoBehaviour
{
    public Slider sensibility;
    public float mouseSensitivity = 100f; //sensibilita' mouse
    public Transform playerBody; // riferimento al player

    float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // nasconde il mouse quando ruotiamo
    }

    // Update is called once per frame
    void Update()
    {
        mouseSensitivity = sensibility.value;

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY; // fa sì che il movimento non sia al contrario

        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // limite di rotazione

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);
    }

  
}