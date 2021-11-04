using UnityEngine;

public class WheelRotate : MonoBehaviour
{
    public static float RotateAmount = 10;
    void Update()
    {
        transform.Rotate(Vector3.right * RotateAmount);
    }
}

