using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public float interval = 1.6f;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && interval >= 1.6f)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            interval = 0;
        }
        interval += Time.deltaTime;
    }
}
