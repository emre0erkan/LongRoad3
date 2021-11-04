using System.Diagnostics;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    private GameObject[] obstacles;
    GroundSpawner groundSpawner;

    private void Start()
    {
        obstacles = new GameObject[4];
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        SpawnObstacle();
        SpawnCoins();
    }

    private void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile();
        Destroy(gameObject, 2);
    }

    void Update()
    {

    }

    public GameObject obstaclePrefab;
    public GameObject obstaclePrefab1;
    public GameObject obstaclePrefab2;
    public GameObject obstaclePrefab3;
    int arrayIndex;
    GameObject currentPoint;

    void SpawnObstacle()
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

    public GameObject coinPrefab;

    void SpawnCoins()
    {
            GameObject temp = Instantiate(coinPrefab, transform);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());

    }

    Vector3 GetRandomPointInCollider(Collider collider)
    {
        Vector3 point = new Vector3(Random.Range(collider.bounds.min.x, collider.bounds.max.x),
                                    Random.Range(collider.bounds.min.y, collider.bounds.max.y),
                                    Random.Range(collider.bounds.min.z, collider.bounds.max.z));

        if (point != collider.ClosestPoint(point))
        {
            point = GetRandomPointInCollider(collider);
        }

        point.y = 0.75f;
        return point;
    }

}