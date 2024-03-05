using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{
    public float motorTorque = 2000;
    public float brakeTorque = 2000;
    public float maxSpeed = 20;
    public float steeringRange = 30;
    public float steeringRangeAtMaxSpeed = 10;
    public WheelController[] wheels;
    public Rigidbody rigidbody;
    public bool hasCrashed = false;
    public LogicScript logicScript;
    public Text fuelText;
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
        float forwardSpeed = Vector3.Dot(transform.forward, rigidbody.velocity);
        float speedFactor = Mathf.InverseLerp(0, maxSpeed, forwardSpeed);
        float currentMotorTorque = Mathf.Lerp(motorTorque, 0, speedFactor);
        float currentSteeringRange = Mathf.Lerp(steeringRange, steeringRangeAtMaxSpeed, speedFactor);
        bool isAccelerating = Mathf.Sign(vInput) == Mathf.Sign(forwardSpeed);

        if (hasCrashed) return;
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
                    wheel.wheelCollider.motorTorque = vInput * currentMotorTorque;
                }

                wheel.wheelCollider.brakeTorque = 0;
            }
            else
            {
                wheel.wheelCollider.brakeTorque = Mathf.Abs(vInput) * brakeTorque;
                wheel.wheelCollider.motorTorque = 0;
            }

            if (rigidbody.velocity.z > 0)
            {
                fuelText.text = (float.Parse(fuelText.text) - 0.1f).ToString();
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.impulse.z > 500 || other.impulse.z < -500 || other.impulse.x > 500 || other.impulse.x < -500)
        {
            hasCrashed = true;
            logicScript.GameOver();
        }
        
    }
}
