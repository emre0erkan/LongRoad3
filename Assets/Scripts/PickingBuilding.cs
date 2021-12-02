using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickingBuilding : MonoBehaviour
{
    private GameObject[] obstacles = new GameObject[4];
    GroundSpawner groundSpawner;

    [SerializeField] GameObject buildingPrefab;
    [SerializeField] GameObject buildingPrefab1;
    [SerializeField] GameObject buildingPrefab2;
    [SerializeField] GameObject buildingPrefab3;
    [SerializeField] GameObject buildingPrefab4;

    GameObject currentPoint;
    int arrayIndex;
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
    }

    public void SpawnBuilding()
    {
        obstacles[0] = buildingPrefab;
        obstacles[1] = buildingPrefab1;
        obstacles[2] = buildingPrefab2;
        obstacles[3] = buildingPrefab3;
        obstacles[3] = buildingPrefab4;

        arrayIndex = Random.Range(0, obstacles.Length);

        currentPoint = obstacles[arrayIndex];
        Quaternion rotation = Quaternion.Euler(0, 90, 0);

        //Choose a random point to spawn the obstacle
        //int obstacleSpawnIndex = Random.Range(6, 8);
        Transform spawnPoint1 = transform.GetChild(6).transform;
        Transform spawnPoint2 = transform.GetChild(7).transform;

        //Spawn the obstacle at that position
        Instantiate(currentPoint, spawnPoint1.position, rotation, transform);
        Instantiate(currentPoint, spawnPoint2.position, rotation, transform);
    }
}
