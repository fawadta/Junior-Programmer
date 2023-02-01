using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Windows.Speech;

public class PlayerController : MonoBehaviour
{
    // private varoables
    //[SerializeField] float speed = 15.0f;
    [SerializeField] float turnSpeed = 50;
    [SerializeField] private float horsepower;
    [SerializeField] float rpm;
    private float horizontalInput;
    private float forwardInput;
    private Rigidbody playerRb;
    [SerializeField] GameObject centerOfMass;
    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] TextMeshProUGUI rpmText;
    [SerializeField] float speed;
    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Player Input
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        // Move the vehicle forward
        //transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        playerRb.AddRelativeForce(Vector3.forward * horsepower * forwardInput);
        // Rotate the vehivcle 
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);
        speed = Mathf.RoundToInt(playerRb.velocity.magnitude * 3.6f);   // 2.237f for mph
        speedometerText.SetText("Speed: " + speed + " kph");
        rpm = (speed % 30) * 40;
        rpmText.SetText("Rpm: " + rpm);
        
    }
}
