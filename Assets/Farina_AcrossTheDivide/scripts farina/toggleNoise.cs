using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleNoise : MonoBehaviour
{


    [Header("Initial State")]
    public bool toggleActive = true;
    [Header("Toggle Key")]
    public KeyCode myKey;
    [Space(10)] // 10 pixels of spacing here.
    [Header("Noise Frequency Per Axis")]
    [Range(0f, 1f)]
    public float xFrequency = 0f;
    [Range(0f, 100f)]
    public float xAmplitude = 0f;
    [Range(0f, 1f)]
    public float yFrequency = 0f;
    [Range(0f, 100f)]
    public float yAmplitude = 0f;
    [Range(0f, 1f)]
    public float zFrequency = 0f;
    [Range(0f, 100f)]
    public float zAmplitude = 0f;
    public GameObject noiseObject;
    private float timeAccum = 0f;
    private float different = 0f;

    private Vector3 refPos;
    // Start is called before the first frame update
    void Start()
    {
        if (noiseObject == null)
        {
            noiseObject = this.gameObject;
        }
        refPos = noiseObject.transform.position;

        different = Random.Range(0f, 1000f);
        timeAccum += different;
    }

    // Update is called once per frame
    void Update()
    {
        {
            if (Input.GetKeyDown(myKey)) { toggleActive = !toggleActive; };
        }

        if (toggleActive)
        {
            timeAccum += Time.deltaTime;
            float dx = xAmplitude * (Perlin.Noise(timeAccum * xFrequency, 1f, 1f) + -0.5f);
            float dy = yAmplitude * (Perlin.Noise(1f, timeAccum * yFrequency, 1f) + -0.5f);
            float dz = zAmplitude * (Perlin.Noise(1f, 1f, timeAccum * zFrequency) + -0.5f);
            Vector3 pos = new Vector3(refPos.x, refPos.y, refPos.z);
            pos = pos + noiseObject.transform.up * dy;
            pos = pos + noiseObject.transform.right * dx;
            pos = pos + noiseObject.transform.forward * dz;
            noiseObject.transform.position = pos;
        }
    }
}
