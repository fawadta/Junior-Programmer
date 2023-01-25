using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private PlayerController playerControllerScript;
    private float rotateSpeed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerControllerScript.gameOver)
        {
            transform.rotation = new Quaternion(rotateSpeed * Time.deltaTime, transform.rotation.y, transform.rotation.z, 1);
            Debug.Log(transform.rotation);
        }
    }
}
