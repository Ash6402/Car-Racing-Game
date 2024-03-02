using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class CarController : MonoBehaviour
{
    public float motorTorque = 2000;
    public float brakeTorque = 2000;
    public float maxSpeed = 20;
    public float steeringRange = 30;
    public float steeringRangeAtMaxSpeed = 10;
    public WheelController[] wheels;

    public Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.centerOfMass += Vector3.up * -1f;
        wheels = GetComponentsInChildren<WheelController>();
    }

    // Update is called once per frame
    void Update()
    {
        float vInput = Input.GetAxis("Vertical");
        float hInput = Input.GetAxis("Horizontal");
            // transform.position = new Vector3(transform.position.x, transform.position.y, (transform.position.z + 1));
            // Debug.Log(rigidbody.velocity);
        float forwardSpeed = Vector3.Dot(transform.forward, rigidbody.velocity);
        float speedFactor = Mathf.InverseLerp(0, maxSpeed, forwardSpeed);
        float currentMotorTorque = Mathf.Lerp(motorTorque, 0, speedFactor);
        float currentSteeringRange = Mathf.Lerp(steeringRange, steeringRangeAtMaxSpeed, speedFactor);
        
        bool isAccelerating = Mathf.Sign(vInput) == Mathf.Sign(forwardSpeed);

        foreach (WheelController wheel in wheels)
        {
            if (wheel.steerable)
            {
                wheel.wheelCollider.steerAngle = hInput * currentSteeringRange;
            }

            if (isAccelerating)
            {
                if (wheel.motorized)
                {
                    wheel.wheelCollider.motorTorque = vInput * motorTorque;
                }

                wheel.wheelCollider.brakeTorque = 0;
            }
            else
            {
                wheel.wheelCollider.brakeTorque = Mathf.Abs(vInput) * brakeTorque;
                wheel.wheelCollider.motorTorque = 0;
            }
        }
    }
}
