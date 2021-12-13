using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField] GameObject groundTile;
    Vector3 nextSpawnPoint;

    public void SpawnTile(bool spawnItems)
    {
        GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;

        if (spawnItems)
        {                                                               //spawn;
            temp.GetComponent<PickingObstacle>().SpawnObstacle();       //obstacles,
            temp.GetComponent<GroundTile>().SpawnCoins();               //coins,
            temp.GetComponent<PickingBuilding>().SpawnBuilding();       //buildings
        }

    }

    private void Start()
    {
        for (int i = 0; i < 15; i++)      //spawning 15 roads at max
        {
            if (i < 3)
            {
                SpawnTile(false);        //spawning first obstacles and coins a little later
            }
            else
            {
                SpawnTile(true);
            }
        }

    }

}