using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.VFX;

public class TriggerScript : MonoBehaviour
{
    public GameObject worldPiece;
    public LogicScript script;
    public GameObject car;

    
    // Start is called before the first frame update
    void Start()
    {
        script = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == car)
            Spawn();
    }

    private void Spawn()
    {
        Instantiate(worldPiece, new Vector3(0, 0, script.getOffset()), Quaternion.identity).name = "WorldPiece";
    }
}
