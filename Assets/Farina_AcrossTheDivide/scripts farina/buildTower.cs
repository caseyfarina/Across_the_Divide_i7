using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildTower : MonoBehaviour
{
    public int towerHeight = 10;
    public float layerHeight = 1f;
    public float baseWidth = 2f;
    public float widthIncrement = 0.1f;
    public GameObject[] towerLayers;
    private float orbitalIncrement;
    // Start is called before the first frame update
    void Start()
    {
     
        for( int i = 0; i < towerHeight;i++)
        {
            int randomSelection = (int)Mathf.Floor(Random.Range(0, towerLayers.Length));
            float towerLayerHeight = i * layerHeight;
            Vector3 layerPosition = new Vector3(0, towerLayerHeight, 0);
            GameObject thisLayer = Instantiate(towerLayers[randomSelection], layerPosition, Quaternion.identity);
            orbitalIncrement = baseWidth + (i * widthIncrement);
            thisLayer.GetComponentInChildren<metricRotator>().orbitalDistance = orbitalIncrement;

        }
    }

   
}
