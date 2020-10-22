using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody))]

public class part_parent_target : MonoBehaviour
{
    public GameObject MagnetObjects;
    Rigidbody body;
    Transform tempMagnet;

    public float Atr_forcePercentage = 10f;
    public float attractionForceMax = 50f;

    public float magnetChangePercentage = 1f;

     void Start()
    {
        body = GetComponent<Rigidbody>();
      
    }
    
    


    // Update is called once per frame
    void FixedUpdate()
    {
       

        float attractiontest = Random.Range(0f, 100f);
       if (attractiontest < Atr_forcePercentage)
            {
                body.AddForce((MagnetObjects.transform.position - transform.localPosition) * (Random.Range(0, attractionForceMax)));

            }
       }

    }

