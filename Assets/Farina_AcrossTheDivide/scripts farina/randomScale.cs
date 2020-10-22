using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomScale : MonoBehaviour
{
    public float scaleMin = .1f;
    public float scaleMax = 1f;
    // Start is called before the first frame update
    void Start()
    {
        float newScale = Random.Range(scaleMin, scaleMax);
        transform.localScale = new Vector3(newScale, newScale, newScale);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
