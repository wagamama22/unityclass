using UnityEngine;
using System.Collections.Generic;



public class EnemyPathing : MonoBehaviour
{
    List<Transform> waypointsList;
    [SerializeField] WaveConfig waveConfig;
    [SerializeField] float enemySpeed = 2f;

    //index to track the current wapoint:where i want to go next it will show me
    int waypointIndex = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //get the list of waypoints from the wave configuration
        waypointsList = waveConfig.GetPathPrefab();
        //set the enemy's position to the first waypoint
        transform.position = waypointsList[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();
    }
    void EnemyMove() 
    {
        if (waypointIndex < waypointsList.Count) 
        {
            //move the enemy towards the current waypoint
            var targetPosition = waypointsList[waypointIndex].transform.position;
            //ensure the z axis is 0 for 2d movement
            targetPosition.z = 0f;
            var movementThisFrame = enemySpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);
            //check if the enemy has reached the waypoint
            if (transform.position == targetPosition) 
            {
                waypointIndex++;
            }
            
        }
        else 
        {
            //destroy the enemy wnt it reaches the last waypoint
            Destroy(gameObject);
        }
    }
}
