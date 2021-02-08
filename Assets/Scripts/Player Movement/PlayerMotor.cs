using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    public float mouseHorizontalSensitivity = 10f;
    public Transform playerBody;

    public CharacterController controller;
    public float forwardMoveSpeed = 1f;

    public float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Rotates player left and right, based on horizontal mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseHorizontalSensitivity * Time.deltaTime;
        playerBody.Rotate(Vector3.up * mouseX);

        // Gets fwd/back/left/right inputs
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        // Moves player forward & back, strafes left & right
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * forwardMoveSpeed * Time.deltaTime);

        // Makes gravity affect player when not grounded
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        //// INCORRECT – DOESN'T USE CHARACTERCONTROLLER. Moves player forward and back, based on vertical input (w/s etc)
        //playerBody.Translate(Vector3.forward * Input.GetAxis("Vertical") * forwardMoveSpeed * Time.deltaTime);

        //// INCORRECT – DOESN'T USE CHARACTERCONTROLLER. Strafes player left & right, based on horizontal input (w/s etc)
        //playerBody.Translate(Vector3.right * Input.GetAxis("Horizontal") * forwardMoveSpeed * Time.deltaTime);
    }
}
