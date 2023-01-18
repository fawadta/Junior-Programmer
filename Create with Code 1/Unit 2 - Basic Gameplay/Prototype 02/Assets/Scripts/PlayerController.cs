using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput, verticalInput;
    private float speed = 30.0f;
    private float xRange = 18.0f;
    private float zRange = 12.0f;
    private float zRangeMin = 0.0f;
    public GameObject projectilePrefab;
    public Transform ProjectileSpawnPoint;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // horizontal
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(horizontalInput * speed * Time.deltaTime * Vector3.right);

        // vertical
        if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }
        if (transform.position.z < -zRangeMin)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRangeMin);
        }

        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(verticalInput * speed * Time.deltaTime * Vector3.forward);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Lunch a projectile from the player
            Instantiate(projectilePrefab, ProjectileSpawnPoint.position, projectilePrefab.transform.rotation);
        }
    }
}
