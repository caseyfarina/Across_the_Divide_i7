using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate_this_object : MonoBehaviour
{
    [Header("Initial State")]
    public bool toggleActive = true;
 
    [Space(10)] // 10 pixels of spacing here.
    [Header("Rotation Speed Per Axis")]
    [Range(0f, 90f)]
    public float xRotation = 0f;
    [Range(0f, 90f)]
    public float yRotation = 0f;
    [Range(0f, 90f)]
    public float zRotation = 0f;

    [Range(0f, 10f)]
    public float random_Range = 1f;

    //public GameObject rotationObject_1;
    private float rotation_multiplier = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rotation_multiplier = Random.Range(-random_Range, random_Range);
    }



    void Update()
    {
       
            transform.Rotate(new Vector3(xRotation, yRotation, zRotation) * Time.deltaTime * rotation_multiplier);
        

    }

}
