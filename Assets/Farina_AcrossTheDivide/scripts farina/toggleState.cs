using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleState : MonoBehaviour {
    
    [Header("Initial State")]
    public bool initialState_one = true;
    [Header("Toggle Key")]
    public KeyCode toggleKey;
    
    public GameObject[] onOffToggleObjects;
    


    // Use this for initialization
    void Start () {
        foreach (GameObject thing in onOffToggleObjects)
        {
            if (thing != null)
                {
                    thing.SetActive(initialState_one);
                }
        }
    }
	
	// Update is called once per frame
	void Update () {

        
        if (Input.GetKeyDown(toggleKey))
            {
                initialState_one = !initialState_one;
                foreach (GameObject thing in onOffToggleObjects)
                {
                   
                    thing.SetActive(initialState_one);
                }
            }
        }
        

      
    
}
