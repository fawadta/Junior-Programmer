using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 200.0f;
    private Rigidbody playerRB;
    private float xBoundUp = 16;
    private float xBoundDown = -1;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        ConstrainPlayerPosition();
    }

    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        playerRB.AddForce(Vector3.back * horizontalInput * speed);
        playerRB.AddForce(Vector3.right * verticalInput * speed);
    }
    void ConstrainPlayerPosition()
    {
        if (transform.position.x > xBoundUp)
        {
            transform.position = new Vector3(xBoundUp, transform.position.y, transform.position.z);
        }
        if (transform.position.x < xBoundDown)
        {
            transform.position = new Vector3(xBoundDown, transform.position.y, transform.position.z);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Player has collided with Enemy");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
        }
    }
}
