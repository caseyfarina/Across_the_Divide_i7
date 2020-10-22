using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flicker_light : MonoBehaviour
{
    [Header("Noise Frequency Per Axis")]
    [Range(0f, 1000f)]
    public float xFrequency = 0f;
    [Range(0f, 1000000f)]
    public float xAmplitude = 0f;

    Light mylight;

    private float timeAccum = 0f;
    private float different = 0f;
    // Start is called before the first frame update
    void Start()
    {
        mylight = GetComponent<Light>();

        different = Random.Range(0f, 1000f);
        timeAccum += different;
    }

    // Update is called once per frame
    void Update()
    {
        timeAccum += Time.deltaTime;
        float dx = xAmplitude * (Perlin.Noise(timeAccum * xFrequency, 1f, 1f) + -0.5f);
        mylight.intensity = dx;
        Debug.Log(dx);
       
    }

}
