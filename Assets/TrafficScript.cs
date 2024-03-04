using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using TreeEditor;
using UnityEngine;

public class TrafficScript : MonoBehaviour
{
    public GameObject car;
    private Rigidbody rb;
    void Start()
    {
        car = GameObject.FindGameObjectWithTag("Car");
        rb = GetComponent<Rigidbody>();
        transform.localScale = new Vector3(4, 4, 4);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.forward *= 10;
        if (car.transform.position.z - transform.position.z > 100)
        {
            Destroy(gameObject);
        }
    }
}
