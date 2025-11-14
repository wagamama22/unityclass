using System.Collections.Generic;
using UnityEngine;
using System;
using System.Collections;
using System.Threading;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] List<WaveConfig> waveConfigList;
    [SerializeField] int startingWave = 0;
    [SerializeField] bool looping = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //make start a coroutine
    IEnumerator Start()
    {
        WaveConfig currentWave = waveConfigList[startingWave];
        do
        {
            
            yield return StartCoroutine(SpawnAllWaves());
        }
        while (looping);
        
        //StartCoroutine(SpawnAllEnemiesInWaves(currentWave));
        StartCoroutine(SpawnAllWaves());
    }

    //method to spawn each wave one sfter the other
    IEnumerator SpawnAllEnemiesInWaves(WaveConfig waveConfig) //creating a new parameter/variale from WaveConfig script
    {

        for (int enemyCount = 1; enemyCount <= waveConfig.GetNumberOfEnemies(); enemyCount++)
        {
            //now we spaw by using instantiate(prefab, position, rotation)
            GameObject newEnemy = Instantiate(waveConfig.GetEnemyPrefab(), waveConfig.GetPathPrefab()[0].transform.position, Quaternion.identity);
            //apply coroutine delay

            //set the wave configuration for newly spawned enemy
            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);

            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnAllWaves() 
    {
        foreach (WaveConfig wave in waveConfigList) 
        {
            //wait untill all enemies in ther current wave are spawned
            //before starting the next wave
            yield return StartCoroutine(SpawnAllEnemiesInWaves(wave));
        }
    }

}

//Another way with parameterless coroutine

//using System.Collections.Generic;
//using UnityEngine;
//using System.Collections;

//public class EnemySpawner : MonoBehaviour
//{
//    [SerializeField] List<WaveConfig> waveConfigList;
//    [SerializeField] int startingWave = 0;

//    private WaveConfig currentWave; // Store current wave as a class member

//    void Start()
//    {
//        // Initialize currentWave
//        currentWave = waveConfigList[startingWave];
//        StartCoroutine(SpawnAllEnemiesInWaves());
//    }

//    // Coroutine without parameters, accessing currentWave directly
//    IEnumerator SpawnAllEnemiesInWaves()
//    {
//        for (int enemyCount = 1; enemyCount <= currentWave.GetNumberOfEnemies(); enemyCount++)
//        {
//            // Spawn enemy using data from currentWave
//            GameObject newEnemy = Instantiate(
//                currentWave.GetEnemyPrefab(),
//                currentWave.GetPathPrefab()[0].transform.position,
//                Quaternion.identity
//            );
//            // Wait between spawns
//            yield return new WaitForSeconds(currentWave.GetTimeBetweenSpawns());
//        }
//    }

//    // Update method if needed
//    void Update()
//    {
//        // Your update logic here
//    }
//}

//enemy sapawning on corresponding path
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class EnemySpawner : MonoBehaviour
//{
//    [SerializeField] List<WaveConfig> waveConfigList;
//    [SerializeField] int startingWave = 0;

//    void Start()
//    {
//        StartCoroutine(SpawnAllWaves());
//    }

//    IEnumerator SpawnAllWaves()
//    {
//        for (int waveIndex = startingWave; waveIndex < waveConfigList.Count; waveIndex++)
//        {
//            WaveConfig currentWave = waveConfigList[waveIndex];
//            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
//        }
//    }

//    IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
//    {
//        List<Transform> pathPrefabs = waveConfig.GetPathPrefab();
//        int totalPaths = pathPrefabs.Count;

//        for (int enemyIndex = 0; enemyIndex < waveConfig.GetNumberOfEnemies(); enemyIndex++)
//        {
//            int pathIndex = enemyIndex % totalPaths;
//            Vector3 spawnPosition = pathPrefabs[pathIndex].transform.position;

//            GameObject newEnemy = Instantiate(
//                waveConfig.GetEnemyPrefab(),
//                spawnPosition,
//                Quaternion.identity
//            );

//            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
//        }
//    }
//}


