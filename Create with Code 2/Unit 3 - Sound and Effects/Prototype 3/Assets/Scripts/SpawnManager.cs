using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefab;
    //private Vector3 spawnPos = new Vector3(25, 0, 0);
    private Vector3 spawnPos;
    private float startDelay = 2.0f;
    private float repeatRate = 2;
    private PlayerController playerControllerScript;
    private int randomObstacle;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnObstacle()
    {
        if (!playerControllerScript.gameOver)
        {
            randomObstacle = Random.Range(0, obstaclePrefab.Length);
            spawnPos = new Vector3(25, obstaclePrefab[randomObstacle].transform.position.y, obstaclePrefab[randomObstacle].transform.position.z);
            Instantiate(obstaclePrefab[randomObstacle], spawnPos, obstaclePrefab[randomObstacle].transform.rotation);
        }
    }
}
