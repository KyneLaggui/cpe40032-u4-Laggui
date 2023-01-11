using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;//Prefab of the enemy
    public GameObject powerupPrefab;//Prefab for the powerup
    private float spawnRange = 9.0f;//Range to where the enemy will spawn
    public int enemyCount;//To count the enemy
    public int waveNumber = 1;//To count the wave so we can increase it later
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber); //To start the wave according to the wave number
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;//To count the enemies
        if(enemyCount ==0)//If the enemy reaches zero
        {
            waveNumber++;//It will add a wave
            SpawnEnemyWave(waveNumber);//Add enemies
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);//Instatiate the powerup
        }
          
    }
    void SpawnEnemyWave(int enemiesToSpawn)//To spawn enemy by waves
    {
        //Depending on the wave to how many enemies will spawn
        for (int i = 0; i < enemiesToSpawn; i++)//Loop of spawning the enemies
        {
            
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }  
    //It uses Vector 3 method to return a Vector 3 values
    private Vector3 GenerateSpawnPosition()//To generate a random spawn position
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);//Spawn in X axis
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);//Spawn in Z axis

        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);//Generate a new random position
        return randomPos;
    }
   
}
