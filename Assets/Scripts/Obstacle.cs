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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Car")          //if car hits any obstacle
        {
            carMovement.Die();       //Kill the player
        }


    }

}
