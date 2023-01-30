using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    private float powerUpStrength = 15.0f;
    private float harderEnemystrength = 7.0f;

    private Rigidbody playerRB;

    private GameObject focalPoint;
    public GameObject powerupIndicator;

    public bool hasPowerup;

    private Vector3 offset = new Vector3(0, -0.5f, 0);
    //public enum poweruptype { ring, fire };

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRB.AddForce(forwardInput * speed * focalPoint.transform.forward, ForceMode.Acceleration);
        powerupIndicator.transform.position = transform.position + offset;
        //if (transform.position.y < -1)
        //    transform.position = Vector3.zero;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            powerupIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
        }
    }
    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Harder Enemy")) && hasPowerup)
        {
            Rigidbody anemyRigidBody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;

            anemyRigidBody.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
            //Debug.Log("Collided with: " + collision.gameObject.name + " with Powerup set to: " + hasPowerup);
        }
        else if (collision.gameObject.CompareTag("Harder Enemy") && !hasPowerup)
        {
            Vector3 awayFromEnemy = transform.position - collision.gameObject.transform.position;

            playerRB.AddForce(awayFromEnemy * harderEnemystrength, ForceMode.Impulse);
        }
    }
}
