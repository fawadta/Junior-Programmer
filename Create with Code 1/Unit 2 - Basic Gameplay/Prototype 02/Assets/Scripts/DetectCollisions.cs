using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        // If collision occur, destroy the object(s)
        if (other.CompareTag("Player"))
        {
            Debug.Log("GameOver!");
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
