using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touch_addTorque : MonoBehaviour {


    //tween the trail thickness

    private bool touching = false;
    public float forceMultiplier = 100.0f;
    public int MidiNote = 70;

    Rigidbody body;

    // Use this for initialization
    void Start()
    {

        body = gameObject.GetComponent<Rigidbody>();
        
    }

    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            touching = true;

            
            Rigidbody body;
            body = gameObject.GetComponent<Rigidbody>();
            body.AddTorque(transform.up * forceMultiplier);
           // MidiOut.SendNoteOn(MidiChannel.Ch1, MidiNote, 0.9f);

            // body.add


        }

    }
 

    void OnTriggerExit(Collider other)
    {/*
        if (other.gameObject.tag == "Player")
        {
            part_behavior behavior;

            behavior = gameObject.GetComponent<part_behavior>();
            behavior.R_forceHight *= 0.1f;
            behavior.R_ForcePercentage = 0.1f;
        }*/

    }
}
