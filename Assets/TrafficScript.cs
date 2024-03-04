using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficScript : MonoBehaviour
{
    public GameObject car;
    void Start()
    {
        car = GameObject.FindGameObjectWithTag("Car");
    }

    // Update is called once per frame
    void Update()
    {
        if (car.transform.position.z - transform.position.z > 100)
        {
            Destroy(gameObject);
        }
    }
}
