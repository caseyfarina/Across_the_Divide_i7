using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cinemachineEdit : MonoBehaviour
{
    public GameObject[] cameras;
    public float cutFrequency = 1f;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject cam in cameras)
        {
            cam.SetActive(false);
        }

        int edit = (int)Random.Range(0, cameras.Length);
        for (int i = 0; i < cameras.Length; i++)
        {
            if (i == edit)
            {
                cameras[i].SetActive(true);
            }
            else
            {
                cameras[i].SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Random.Range(0f, 100f) < cutFrequency)
        {
            int edit = (int)Random.Range(0, cameras.Length);
            for (int i = 0; i < cameras.Length; i++)
            {
                if (i == edit)
                {
                    cameras[i].SetActive(true);
                }
                else
                {
                    cameras[i].SetActive(false);
                }
            }

        }
    }
}

