using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destoyer : MonoBehaviour {
    public int lifeTimeSeconds = 5;
    
	// Use this for initialization
	void Start () {
        if (gameObject != null)
        {
            
            Destroy(gameObject, lifeTimeSeconds);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    
}
