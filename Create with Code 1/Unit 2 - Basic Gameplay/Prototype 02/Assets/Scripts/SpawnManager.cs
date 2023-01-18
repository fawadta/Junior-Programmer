using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnRangeX = 17;
    private float spawnPosZ = 20;
    private float spawnRangeZ = 14, minSpawnRangeZ = 1;
    private float spawnPosX = 28;
    private float startDelay = 2.0f;
    private float spawnDelay = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimalHorizontal", startDelay, spawnDelay);
        InvokeRepeating("SpawnRandomAnimalVertical", startDelay, spawnDelay+1);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SpawnRandomAnimalHorizontal()
    {
        // Psawn Horizontally
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }
    private void SpawnRandomAnimalVertical()
    {
        // Spawn Vertically
        Vector3 spawnPosL = new Vector3(spawnPosX, 0, Random.Range(minSpawnRangeZ, spawnRangeZ));
        Vector3 spawnPosR = new Vector3(-spawnPosX, 0, Random.Range(minSpawnRangeZ, spawnRangeZ));
        Vector3 rotation = new Vector3(0, 90, 0);
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Instantiate(animalPrefabs[animalIndex], spawnPosL, Quaternion.Euler(-rotation));
        Instantiate(animalPrefabs[animalIndex], spawnPosR, Quaternion.Euler(rotation));
    }
}
