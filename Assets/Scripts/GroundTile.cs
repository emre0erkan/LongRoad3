using System.Diagnostics;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;

    [SerializeField] GameObject coinPrefab;

    private void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
    }

    private void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile(true);
        Destroy(gameObject, 2);
    }

    public void SpawnCoins()
    {
        GameObject temp = Instantiate(coinPrefab, transform);                             //this is gonna be called in GroundSpawner and spawn coin
        temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());     //on a random point

    }

    Vector3 GetRandomPointInCollider(Collider collider)
    {
        Vector3 point = new Vector3(Random.Range(collider.bounds.min.x + 1, collider.bounds.max.x - 1),     //random spawn point shouldn't be outside of the road
                                    Random.Range(collider.bounds.min.y, collider.bounds.max.y),
                                    Random.Range(collider.bounds.min.z, collider.bounds.max.z));

        if (point != collider.ClosestPoint(point))
        {
            point = GetRandomPointInCollider(collider);
        }

        point.y = 0.6f;     //coins height
        return point;
    }

}