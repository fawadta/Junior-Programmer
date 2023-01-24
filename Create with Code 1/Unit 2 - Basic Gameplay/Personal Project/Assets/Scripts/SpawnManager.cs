using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject powerup;

    public float xSpawnRangeMax = 10.0f;
    public float xSpawnRangeMin = -1.0f;
    public float zEnemySpawn = 19.5f;
    public float zpowerupRange = 15.0f;
    public float ySpawn = 1.0f;

    private float powerupSpawnTime = 5.0f;
    private float enemySpawnTime = 1.0f;
    private float startDelay = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandonEnemy", startDelay, enemySpawnTime);
        InvokeRepeating("SpawnPowerup", startDelay, powerupSpawnTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRandonEnemy()
    {
        float randomZ = Random.Range(zEnemySpawn, -zEnemySpawn);
        int index = Random.Range(0, enemies.Length);

        Vector3 spawnPos = new Vector3(xSpawnRangeMax, ySpawn, randomZ);
        Instantiate(enemies[index], spawnPos, enemies[index].transform.rotation);
    }
    void SpawnPowerup()
    {
        float randomX = Random.Range(xSpawnRangeMax, -xSpawnRangeMin);
        float randomZ = Random.Range(zpowerupRange, -zpowerupRange);

        Vector3 spawnPos = new Vector3(randomX, ySpawn, randomZ);
        Instantiate(powerup, spawnPos, powerup.transform.rotation);
    }
}
