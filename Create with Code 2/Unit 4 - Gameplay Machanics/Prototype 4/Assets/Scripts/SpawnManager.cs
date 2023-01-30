using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float spawnRange = 9.0f;
    public int enemyCount;
    public int waveNumber = 1;

    public GameObject powerupPrefab;
    public GameObject[] enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWaves(waveNumber);
        Instantiate(powerupPrefab, generateSpawnPosition(), powerupPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;

        if(enemyCount == 0)
        {
            waveNumber++;
            Instantiate(powerupPrefab, generateSpawnPosition(), powerupPrefab.transform.rotation);
            SpawnEnemyWaves(waveNumber);
        }
    }

    void SpawnEnemyWaves(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            int index = Random.Range(0, 2);
            if(index == 1)
                index = Random.Range(0, 2);
            Instantiate(enemyPrefab[index], generateSpawnPosition(), enemyPrefab[index].transform.rotation);
        }
    }

    private Vector3 generateSpawnPosition()
    {
        float spawnPosX = Random.Range(spawnRange, -spawnRange);
        float spawnPosZ = Random.Range(spawnRange, -spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }
}
