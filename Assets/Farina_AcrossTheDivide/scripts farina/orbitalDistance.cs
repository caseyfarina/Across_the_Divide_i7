using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orbitalDistance : MonoBehaviour
{
    public float orbitalMin = .2f;
    public float orbitalMax = 1f;
    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition = new Vector3(Random.Range(orbitalMin,orbitalMax), 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
