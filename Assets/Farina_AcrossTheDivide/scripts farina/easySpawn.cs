using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class easySpawn : MonoBehaviour
{
    public GameObject thingToSpawn;
    public int numberOfSpawns = 100;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numberOfSpawns; i++)
        {
            Instantiate(thingToSpawn);
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
