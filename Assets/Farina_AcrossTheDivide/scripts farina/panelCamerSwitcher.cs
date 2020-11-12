using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panelCamerSwitcher : MonoBehaviour
{
    public GameObject panelCameras;
    public GameObject FullCamera;
    public float switchChance = .1f;
    private bool cameraToggle  = true;
    // Start is called before the first frame update
    void Start()
    {
        panelCameras.SetActive(cameraToggle);
        FullCamera.SetActive(!cameraToggle);

        InvokeRepeating("flipCameras", 20f,20f);
    }

    // Update is called once per frame
    void Update()
    {/*
        if (Random.Range(0, 100) < switchChance)
        {
            cameraToggle = !cameraToggle;

            panelCameras.SetActive(cameraToggle);
            FullCamera.SetActive(!cameraToggle);
        }*/
    }
    void flipCameras()
    {
        cameraToggle = !cameraToggle;

        panelCameras.SetActive(cameraToggle);
        FullCamera.SetActive(!cameraToggle);
    }
}
