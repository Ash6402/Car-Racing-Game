using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelCanScript : MonoBehaviour
{
    public CarController carScript;
    // Start is called before the first frame update
    void Start()
    {
        carScript = GameObject.FindGameObjectWithTag("Car").GetComponent<CarController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        carScript.fuelText.text = "200";
        Destroy(gameObject);
    }
}
