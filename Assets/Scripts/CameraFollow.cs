using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform car;
    Vector3 offset;
    
    void Start()
    {
        offset = transform.position - car.position;
    }


    void Update()
    {
        //Vector3 targetPos = car.position + offset;
        //targetPos.x = 0;
        //transform.position = targetPos;
        transform.position = new Vector3(0, car.position.y+5.3f, car.position.z-7);

    }
}
