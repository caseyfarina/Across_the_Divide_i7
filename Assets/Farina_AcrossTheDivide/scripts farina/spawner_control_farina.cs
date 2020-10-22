using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ez.Pooly;


public class spawner_control_farina : MonoBehaviour
{
    [Header("Spawn Probability per Frame")]
    [Space(10)]
    [Range(0f,100f)]
    public float fab_1Prob = 0f;
    public GameObject fab_1;
    [Space(10)]
    [Range(0f, 100f)]
    public float fab_2Prob = 0f;
    public GameObject fab_2;
    [Space(10)]
    [Range(0f, 100f)]
    public float fab_3Prob = 0f;
    public GameObject fab_3;
    [Space(10)]
    [Range(0f, 100f)]
    public float fab_4Prob = 0f;
    public GameObject fab_4;
    [Space(10)]
    [Range(0f, 100f)]
    public float fab_5Prob = 0f;
    public GameObject fab_5;

  

    void Awake()
    {
        

        
    }
    // Start is called before the first frame update
    void Start()
    { 

        
    }

    // Update is called once per frame
    void Update()
    {
        float spawnChance = Random.Range(0f, 100f);
        if (spawnChance < fab_1Prob) {

            Pooly.Spawn(fab_1.transform, Vector3.zero, Quaternion.identity);
        }

        spawnChance = Random.Range(0f, 100f);
        if (spawnChance < fab_2Prob)
        {

            Pooly.Spawn(fab_2.transform, Vector3.zero, Quaternion.identity);
        }

        spawnChance = Random.Range(0f, 100f);
        if (spawnChance < fab_3Prob)
        {

            Pooly.Spawn(fab_3.transform, Vector3.zero, Quaternion.identity);
        }

        spawnChance = Random.Range(0f, 100f);
        if (spawnChance < fab_4Prob)
        {

            Pooly.Spawn(fab_4.transform, Vector3.zero, Quaternion.identity);
        }

        spawnChance = Random.Range(0f, 100f);
        if (spawnChance < fab_5Prob)
        {

            Pooly.Spawn(fab_5.transform, Vector3.zero, Quaternion.identity);
        }

    }
}
