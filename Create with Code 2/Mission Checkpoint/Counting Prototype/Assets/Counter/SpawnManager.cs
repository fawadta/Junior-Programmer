using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject spawnPrefab;
    [SerializeField] Vector3 mousePos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            //mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            Instantiate(spawnPrefab, transform.position, transform.rotation);
        }
    }
}
