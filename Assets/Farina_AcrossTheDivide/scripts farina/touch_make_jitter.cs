using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class touch_make_jitter : MonoBehaviour {

    public float jitterTime = 3.0f;
    //tween the trail thickness

    private bool touching = false;
    // public float forceMultiplier = 100.0f;

    TrailRenderer trail;
    part_behavior behavior;

    // Use this for initialization
    void Start()
    {
        
        trail = gameObject.GetComponent<TrailRenderer>();
        trail.time = 0.01f;
        trail.widthMultiplier = 0.0001f;
        behavior = gameObject.GetComponent<part_behavior>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            touching = true;
            
            /*
            Rigidbody body;
            body = gameObject.GetComponent<Rigidbody>();
            body.AddForce(new Vector3(
                Random.Range(-forceMultiplier, forceMultiplier),
                Random.Range(-forceMultiplier, forceMultiplier),
                Random.Range(-forceMultiplier, forceMultiplier)));
                */

            
            //behavior.R_forceHight *= forceMultiplier;
            behavior.R_ForcePercentage = 80.0f;


            trail.time = 2.0f;
            trail.widthMultiplier = 0.1f;
            Invoke("resetpart", jitterTime);



        }

    }
    void resetpart()
    {
        behavior.R_ForcePercentage = 1.0f ;
        trail.time = 0.01f;
        trail.widthMultiplier = 0.0001f;
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
