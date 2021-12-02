using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickingObstacle : MonoBehaviour
{
    private GameObject[] obstacles = new GameObject[4];
    GroundSpawner groundSpawner;

    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] GameObject obstaclePrefab1;
    [SerializeField] GameObject obstaclePrefab2;
    [SerializeField] GameObject obstaclePrefab3;

    GameObject currentPoint;
    int arrayIndex;
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnObstacle()
    {

        obstacles[0] = obstaclePrefab;
        obstacles[1] = obstaclePrefab1;
        obstacles[2] = obstaclePrefab2;
        obstacles[3] = obstaclePrefab3;

        arrayIndex = Random.Range(0, obstacles.Length);

        currentPoint = obstacles[arrayIndex];

        //Choose a random point to spawn the obstacle
        int obstacleSpawnIndex = Random.Range(2, 6);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        //Spawn the obstacle at that position
        Instantiate(currentPoint, spawnPoint.position, Quaternion.identity, transform);
    }
}
