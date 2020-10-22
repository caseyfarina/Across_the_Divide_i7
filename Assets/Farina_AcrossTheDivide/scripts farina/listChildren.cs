using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class listChildren : MonoBehaviour
{
    public GameObject parent;
    //List<Transform> childrenOfParent = new List<Transform>();
    public Transform[] childrenOfParent;
    // Start is called before the first frame update
    void Awake()
    {
        childrenOfParent = GetComponentsInChildren<Transform>();
        
        foreach(Transform trans in childrenOfParent)
        {
            Debug.Log(trans.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
