using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamMov : MonoBehaviour
{
    public Slider sensitivitySlider;
    public float sensitivity = 100f; //sensibilita' mouse

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
        sensitivity = sensitivitySlider.value;
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        xRotation -= mouseY; // fa s� che il movimento non sia al contrario

        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // limite di rotazione

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);
    }
}