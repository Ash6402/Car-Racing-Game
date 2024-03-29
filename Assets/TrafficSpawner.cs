using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TrafficSpawner : MonoBehaviour
{
    public GameObject car;
    public float offset;
    public GameObject[] cars;
    public GameObject fuelCan;
    public float[] spawnPoints;
    public float waitTime;
    public float fuelSpawnTime; 
    private float fuelSpawnElapsedTime = 0;
    private float elapsedTime = 0;
    private int previousPosition = -1;
    private Rigidbody carBody;
    private CarController carScript;

    private void Start()
    {
        carBody = car.GetComponent<Rigidbody>();
        carScript = car.GetComponent<CarController>();
    }

    void Update()
    {
        transform.position = new Vector3(0, 0, car.transform.position.z + offset);
        if (elapsedTime < waitTime)
        {
            elapsedTime += Time.deltaTime;
        }
        else 
        {
            elapsedTime = 0;
            if (carBody.velocity.z < 10) return;
            Spawn();
            AdjustSpawnTime();
        }

        if (carScript.fuelText.text.CompareTo("0") == 0) return;
        
        if (fuelSpawnElapsedTime < fuelSpawnTime)
        {
            fuelSpawnElapsedTime += Time.deltaTime;
        }
        else
        {
            SpawnFuel(spawnPoints[(int)((previousPosition + 2) % spawnPoints.Length)], transform.position.z);
            fuelSpawnElapsedTime = 0;
        }
    }

    public void Spawn()
    {
        GameObject car = cars[Random.Range(0, cars.Length-1)];
        int position;
        do
        {
            position = Random.Range(0, spawnPoints.Length);
            
        } while (position == previousPosition);
        Instantiate(car, new Vector3( spawnPoints[position], 0, transform.position.z), Quaternion.identity);
        previousPosition = position;

    }

    public void AdjustSpawnTime()
    {
        if (waitTime < 1 && carBody.velocity.z > 30) return;
        elapsedTime = 0;
        if (carBody.velocity.z > 30)
        {
            waitTime = 0.8f;
        }
        else
        {
            waitTime = 2f;
        }
    }

    public void SpawnFuel(float xPosition, float zPosition)
    {
        Instantiate(fuelCan, new Vector3(xPosition, 1, zPosition), Quaternion.identity).name = "Fuel Can";
    }
}
