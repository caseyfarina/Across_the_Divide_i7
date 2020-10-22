using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody))]

public class part_behavior : MonoBehaviour {
    public float UnLocked_Perc = 50.0f;

    public float size_min = 0.2f;
    public float size_max = 0.8f;
    public float fibonacci_size_percentage = 1f;
    public float fibonacci_max_multiplier = 5f;
    public float R_ForcePercentage = 50.0f;
    public float R_forceLow = 10.0f;
    public float R_forceHight = 100.0f;

    public GameObject Magnet;
    public float Atr_forcePercentage = 50.0f;
    public float Atr_force_min = 1.0f;
    public float Atr_force_max = 2.0f;

    private float Original_Atr_force_min = 0f;
    private float Original_Atr_force_max = 0f;
    private float Original_mass = 0f;
    Rigidbody body;

    private void Awake()
    {
        body = GetComponent<Rigidbody>();

    }
    // Use this for initialization
    void Start () {
        
        //body = GetComponent<Rigidbody>();

        if (Random.Range(0.0f, 100.0f) < UnLocked_Perc)
        {
            body.constraints = RigidbodyConstraints.None;
        }
       // body.mass = body.mass * transform.localScale.x;
       //body.drag = body.drag * (1f * transform.localScale.x);
       // Atr_force_max = Atr_force_max * transform.localScale.x *.2f;
       //Atr_forcePercentage = Atr_forcePercentage * transform.localScale.x;
    }

    void OnSpawned()
    {   
        //generate a chance of fibonacci growth
        float fibonacci_chance = Random.Range(0.0f, 100.0f);

        body.mass = 1f;
        transform.localScale = Vector3.zero;
        float randomScale = Random.Range(size_min , size_max);
        Vector3 tempScale = new Vector3(randomScale, randomScale, randomScale);

        if(fibonacci_chance < fibonacci_size_percentage)
        {
            //if the fibonacci chance is triggered then multiply the random size by the fibonacci value and a random sizing integer
            float random_size_multiplier_int = Mathf.Floor(Random.Range(0f, fibonacci_max_multiplier));
            transform.DOScale(tempScale * 1.618f * random_size_multiplier_int, .7f).SetEase(Ease.OutBack);

            //store original values incase this clone is respawned
            Original_mass = body.mass;
            Original_Atr_force_max = Atr_force_max;
            Original_Atr_force_min = Atr_force_min;

            body.mass = 10f * fibonacci_max_multiplier;
            Atr_force_max *= 200f * fibonacci_max_multiplier;
            Atr_force_min *= 200f * fibonacci_max_multiplier;
            //Debug.Log("fib growth " + random_size_multiplier_int);
        }
        else
        {
            //else just use the reguslar size range
            transform.DOScale(tempScale, .7f).SetEase(Ease.OutBack);
        }
    }

    void OnDespawned()
    {
        body.velocity = new Vector3(0f, 0f, 0f);
        body.angularVelocity = new Vector3(0f, 0f, 0f);
        body.mass = Original_mass;
        Atr_force_max = Original_Atr_force_max;
        Atr_force_min = Original_Atr_force_min;
        transform.DOScale(Vector3.zero, .5f).SetEase(Ease.InElastic);
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        body = GetComponent<Rigidbody>();
        float tester = Random.Range(0.0f, 100.0f);
        float amount = Random.Range(R_forceLow, R_forceHight);
        if (tester < R_ForcePercentage)
        {
            body.AddForce(new Vector3(
                Random.Range(-amount, amount),
                Random.Range(-amount, amount),
                Random.Range(-amount, amount)));
        }

        float attractiontest = Random.Range(0f, 100f);

        if (Magnet != null)
        {
            if (attractiontest < Atr_forcePercentage)
            {
                body.AddForce((Magnet.transform.position - transform.localPosition) * (Random.Range(Atr_force_min, Atr_force_max)));

            }
        }


    }
}
