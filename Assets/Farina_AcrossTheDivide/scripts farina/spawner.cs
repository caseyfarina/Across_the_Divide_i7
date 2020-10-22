using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject prefabTospawn;
    public float spawnRadius = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Random.Range(0,100) < 1)
        {
            float locationX = Random.Range(spawnRadius, -spawnRadius);
            float locationZ = Random.Range(spawnRadius, -spawnRadius);
            Instantiate(prefabTospawn, new Vector3(locationX, Random.Range(0, 1), locationZ), Quaternion.identity,transform);
        }
    }
}
