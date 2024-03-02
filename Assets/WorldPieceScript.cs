using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldPieceScript : MonoBehaviour
{
    public GameObject car;

    private void Start()
    {
        car = GameObject.FindGameObjectWithTag("Car");
    }

    void Update()
    {
        if (car.transform.position.z - transform.position.z > 100)
        {
            Destroy(gameObject);
        }
    }
}
