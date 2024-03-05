using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelCanScript : MonoBehaviour
{
    public GameObject car;
    // Start is called before the first frame update
    private void Start()
    {
        car = GameObject.FindGameObjectWithTag("Car");
    }

    // Update is called once per frame
    private void Update()
    {
        if(car.transform.position.z - transform.position.z > 50)
            Destroy(gameObject);
    }
}
