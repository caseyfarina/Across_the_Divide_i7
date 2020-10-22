using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControls : MonoBehaviour
{
    public GameObject[] cameras;

    private KeyCode[] keyCodes = {
         KeyCode.Alpha0,
         KeyCode.Alpha1,
         KeyCode.Alpha2,
         KeyCode.Alpha3,
         KeyCode.Alpha4,
         KeyCode.Alpha5,
         KeyCode.Alpha6,
         KeyCode.Alpha7,
         KeyCode.Alpha8,
         KeyCode.Alpha9
     };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(keyCodes[1]))
        {
            foreach(GameObject camera in cameras)
            {
                camera.SetActive(false);
            }
            cameras[0].SetActive(true); 
            
        }

        if (Input.GetKeyDown(keyCodes[2]))
        {
            foreach (GameObject camera in cameras)
            {
                camera.SetActive(false);
            }
            cameras[1].SetActive(true);
        }

        if (Input.GetKeyDown(keyCodes[3]))
        {
            foreach (GameObject camera in cameras)
            {
                camera.SetActive(false);
            }
            cameras[2].SetActive(true);
        }

        if (Input.GetKeyDown(keyCodes[4]))
        {
            foreach (GameObject camera in cameras)
            {
                camera.SetActive(false);
            }
            cameras[3].SetActive(true);
        }

        if (Input.GetKeyDown(keyCodes[5]))
        {
            foreach (GameObject camera in cameras)
            {
                camera.SetActive(false);
            }
            cameras[4].SetActive(true);
        }

        if (Input.GetKeyDown(keyCodes[6]))
        {
            foreach (GameObject camera in cameras)
            {
                camera.SetActive(false);
            }
            cameras[5].SetActive(true);
        }

        if (Input.GetKeyDown(keyCodes[7]))
        {
            foreach (GameObject camera in cameras)
            {
                camera.SetActive(false);
            }
            cameras[6].SetActive(true);
        }

        if (Input.GetKeyDown(keyCodes[8]))
        {
            foreach (GameObject camera in cameras)
            {
                camera.SetActive(false);
            }
            cameras[7].SetActive(true);
        }

        if (Input.GetKeyDown(keyCodes[9]))
        {
            foreach (GameObject camera in cameras)
            {
                camera.SetActive(false);
            }
            cameras[8].SetActive(true);
        }

        if (Input.GetKeyDown(keyCodes[0]))
        {
            foreach (GameObject camera in cameras)
            {
                camera.SetActive(false);
            }
            cameras[9].SetActive(true);
        }

    }
}
