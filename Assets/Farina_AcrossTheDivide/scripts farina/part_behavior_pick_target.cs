using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody))]

public class part_behavior_pick_target : MonoBehaviour
{
    public GameObject MagnetObjects;
    listChildren listOfMagnets;
    Rigidbody body;
    Transform tempMagnet;

    public float Atr_forcePercentage = 10f;

    public float magnetChangePercentage = 1f;

     void Start()
    {
        body = GetComponent<Rigidbody>();
        listOfMagnets = MagnetObjects.GetComponent<listChildren>();
        Debug.Log(listOfMagnets.childrenOfParent.Length);
        tempMagnet = listOfMagnets.childrenOfParent[Mathf.FloorToInt(Random.Range(0, listOfMagnets.childrenOfParent.Length))];
        
    }
    
    


    // Update is called once per frame
    void FixedUpdate()
    {
       float magnetChangeTest = Random.Range(0f, 100f);
        if(magnetChangeTest < magnetChangePercentage)
        {
            tempMagnet = listOfMagnets.childrenOfParent[Mathf.FloorToInt(Random.Range(0, listOfMagnets.childrenOfParent.Length))];

        }

        float attractiontest = Random.Range(0f, 100f);
       if (attractiontest < Atr_forcePercentage)
            {
                body.AddForce((tempMagnet.transform.position - transform.localPosition) * (Random.Range(0, 30)));

            }
       }

    }

