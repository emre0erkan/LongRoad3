using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    CarMovement carMovement;

    void Start()
    {
        carMovement = GameObject.FindObjectOfType<CarMovement>();
    }

    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Car")
        {
            //Kill the player
            carMovement.Die();
        }


    }

}
