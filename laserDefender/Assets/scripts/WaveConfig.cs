using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "WaveConfig", menuName = "Scriptable Objects/WaveConfig")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab;
    //path on which to move the enemy
    [SerializeField] GameObject pathPrefab;
    //delay before spawning the next enemy
    [SerializeField] float timeBetweenSpawns = 0.5f;
    //number of enemies to spawn in this wave
    [SerializeField] int numberOfEnemies = 5;
    //speed at which the enemy moves
    [SerializeField] float enemyMoveSpeed = 2f;

    //encapsulate numberOfEnemies and all the serializeField above
    public int GetNumberOfEnemies()
    {
        return numberOfEnemies;
    }

    public GameObject GetEnemyPrefab()
    {
        return enemyPrefab;
    }

    public List<Transform> GetPathPrefab()
    {
        //creating a list of 5 variables called wavwWaypoints which will be updated everytime we change the wave
        //access the pathPrefab and get all its child transform
        List<Transform> waveWaypoints = new List<Transform>();
        foreach (Transform waypoint in pathPrefab.transform)
        {
            //add each waypoint to the list
            waveWaypoints.Add(waypoint);
        }
        return waveWaypoints;
    }

    public float GetTimeBetweenSpawns()
    {
        return timeBetweenSpawns;
    }

    public float GetEnemyMoveSpeed()
    {
        return enemyMoveSpeed;
    }
}
