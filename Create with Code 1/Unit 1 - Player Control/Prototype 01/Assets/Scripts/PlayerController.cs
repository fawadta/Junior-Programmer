using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // private varoables
    [SerializeField] float speed = 15.0f;
    [SerializeField] float turnSpeed = 50;
    private float horizontalInput;
    private float forwardInput;

    // Update is called once per frame
    void FixedUpdate()
    {
        // Player Input
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        // Move the vehicle forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        // Rotate the vehivcle 
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);
    }
}
