using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] float turnSpeed = 90f;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Obstacle>() != null)
        {
            Destroy(gameObject);
            return;
        }

        //Check that the object we collided with is the player
        if (other.gameObject.name != "Car")
        {
            return;
        }
        //Add to the player's score
        GameManager.inst.IncrementScore();
        //Destroy this coing object
        Destroy(gameObject);
    }
    void Start()
    {

    }

    void Update()
    {
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
    }
}
