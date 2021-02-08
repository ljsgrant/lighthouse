using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseVerticalLook : MonoBehaviour
{
    public float mouseVerticalSensitivity = 10f;
    public Camera mainCamera;
    public int cameraFieldOfView;
    public float cameraNearClipPlane;
   

    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //        // Hides the cursor on Start
        //Cursor.lockState = CursorLockMode.Locked;
        mainCamera.fieldOfView = cameraFieldOfView;
        mainCamera.nearClipPlane = cameraNearClipPlane;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y") * mouseVerticalSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
