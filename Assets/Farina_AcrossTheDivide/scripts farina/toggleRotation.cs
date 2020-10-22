using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleRotation : MonoBehaviour
{
    [Header("Initial State")]
    public bool toggleActive = true;
    [Header("Toggle Key")]
    public KeyCode myKey;
    [Space(10)] // 10 pixels of spacing here.
    [Header("Rotation Speed Per Axis")]
    [Range(-10f, 10f)]
    public float xRotation = 0f;
    [Range(-10f, 10f)]
    public float yRotation = 0f;
    [Range(-10f, 10f)]
    public float zRotation = 0f;
    [Header("Percentage of Variation")]
    [Range(0f, 1f)]
    public float variationPerc = 0f;
    private float[] variations;

    public GameObject[] spinners;

    // Start is called before the first frame update
    void Start()
    {
        variations = new float[spinners.Length];
        int i = 0;
        foreach (GameObject spinner in spinners)
        {
            float total_speed = xRotation + yRotation + zRotation;
            variations[i] = Random.Range(-total_speed * variationPerc, total_speed * variationPerc);
            i++;
        }
    }



    void Update()
    {
        
        {
            if (Input.GetKeyDown(myKey)) { toggleActive = !toggleActive; };
        }
        int i = 0;
        foreach (GameObject spinner in spinners) { 
            if (toggleActive)
                {
                
                    spinner.transform.Rotate(new Vector3(xRotation, yRotation, zRotation) * Time.deltaTime * (1f + variations[i]));
                
               
                }
            Debug.Log(variations[i]);
           i++;
           
        }
        
    }
    
}
