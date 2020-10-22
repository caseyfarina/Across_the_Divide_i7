using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleOrbit : MonoBehaviour
{
    [Header("Initial State")]
    public bool toggleActive = true;
    [Header("Toggle Key")]
    //public string toggleKey;
    public KeyCode myKey;
    [Space(10)] // 10 pixels of spacing here.
    [Header("Rotation Speed")]
    [Range(-10f, 10)]
    public float rotationSpeed = 0f;

    public Vector3 myDirection = Vector3.up;

    [Header("center of rotation")]
    public GameObject OrbitalCenter;
    [Header("center of rotation")]
    public GameObject OrbitingObject;

    public float offset = 0;


    // Start is called before the first frame update
    void Start()
    {
        if (OrbitingObject == null)
        {
            OrbitingObject = this.gameObject;
        }
        
    }



    void Update()
    {
        
            {
                if (Input.GetKeyDown(myKey)) { toggleActive = !toggleActive; };
            }
            if (toggleActive)
            {
            //rotationObject_1.transform.Rotate(new Vector3(xRotation, yRotation, zRotation) * Time.deltaTime);
            OrbitingObject.transform.RotateAround(OrbitalCenter.transform.position, Vector3.up, rotationSpeed * Time.deltaTime + offset);
            }
        
    }

}
