using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mixamoSpawnerTarget : MonoBehaviour
{
    [Range(0f, 100f)]
    public float headPercentage = 1f;
    [Range(0f, 100f)]
    public float spinePercentage = 1f;
    [Range(0f, 100f)]
    public float rightArmPercentage = 1f;
    [Range(0f, 100f)]
    public float leftArmPercentage = 1f;
    [Range(0f, 100f)]
    public float rightLegPercentage = 1f;
    [Range(0f, 100f)]
    public float leftLegPercentage = 1f;
    [Range(0f, 1f)]
    public float spatialJitter = .01f;
    [Range(0f, 2f)]
    public float scaleJitterMin = .5f;
    [Range(0f, 2f)]
    public float scaleJitterMax = 1f;
    [Range(0f, 1f)]
    public float fibonacciScalePercentage = .01f;

    public string spawnTag = "clone";

    public GameObject[] spawns;
   // public GameObject[] chain;
   // public GameObject[] leftLeg;

    List<GameObject> leftLeg = new List<GameObject>();

    public string[] leftLegNames = {
    
    "mixamorig:LeftToe_End",
    "mixamorig:LeftToeBase",
    "mixamorig:LeftFoot",
    "mixamorig:LeftLeg",
    "mixamorig:LeftUpLeg",
    "mixamorig:Hips"
     };

    List<GameObject> rightLeg = new List<GameObject>();

    public string[] rightLegNames = {
    
    "mixamorig:RightToe_End",
    "mixamorig:RightToeBase",
    "mixamorig:RightFoot",
    "mixamorig:RightLeg",
    "mixamorig:RightUpLeg",
    "mixamorig:Hips"
     };

    List<GameObject> rightArm = new List<GameObject>();

    public string[] rightArmNames = {
    "mixamorig:RightHandIndex1",
    "mixamorig:RightHand",
    "mixamorig:RightForeArm",
    "mixamorig:RightArm",
    "mixamorig:RightShoulder"
     };

    List<GameObject> leftArm = new List<GameObject>();

    public string[] leftArmNames = {
    "mixamorig:LeftHandIndex1",
    "mixamorig:LeftHand",
    "mixamorig:LeftForeArm",
    "mixamorig:LeftArm",
    "mixamorig:LeftShoulder"
     };

    List<GameObject> spine = new List<GameObject>();

    public string[] spineNames = {
    "mixamorig:HeadTop_End",
    "mixamorig:Head",
    "mixamorig:Neck",
    "mixamorig:Spine2",
    "mixamorig:Spine1",
    "mixamorig:Spine",
    "mixamorig:Hips"
     };

    List<GameObject> head = new List<GameObject>();

    public string[] headNames = {
    "mixamorig:HeadTop_End",
    "mixamorig:Head",
    "mixamorig:Neck"
     };




    public float spawnresetRate = 2f;
    //public into_part_behavior behave;
    private int spawnset;
    private int spawnset2;
    public float spawnSetBalance = 70f;

    // Start is called before the first frame update
    void Start()
    {
        //leftLeg.Length = leftLegNames.Length;
        foreach (string name in leftLegNames)
        {
            leftLeg.Add(GameObject.Find(name));
        }

        foreach (string name in rightLegNames)
        {
            rightLeg.Add(GameObject.Find(name));
        }

        foreach (string name in rightArmNames)
        {
            rightArm.Add(GameObject.Find(name));
        }

        foreach (string name in leftArmNames)
        {
            leftArm.Add(GameObject.Find(name));
        }
        
        foreach (string name in spineNames)
        {
            spine.Add(GameObject.Find(name));
        }

        foreach (string name in headNames)
        {
            head.Add(GameObject.Find(name));
        }

        spawnset = Random.Range(0, spawns.Length);
        spawnset2 = Random.Range(0, spawns.Length);

    }

    // Update is called once per frame
    void Update()
    {

        if (Random.Range(0f, 100f) < spawnresetRate)
        {

            spawnreset();

        }

        if (Random.Range(0f, 100f) < headPercentage) { spawnOnLimb(head); }
        if (Random.Range(0f, 100f) < spinePercentage) { spawnOnLimb(spine); }
        if (Random.Range(0f, 100f) < rightArmPercentage) { spawnOnLimb(rightArm); }
        if (Random.Range(0f, 100f) < leftArmPercentage) { spawnOnLimb(leftArm); }
        if (Random.Range(0f, 100f) < rightLegPercentage) { spawnOnLimb(rightLeg); }
        if (Random.Range(0f, 100f) < leftLegPercentage) { spawnOnLimb(leftLeg); }



        


            /*
            // pick on node on the chain (not the last one) and store that node as "chainoffset"

            int chainsOffset = (int)Mathf.Floor(Random.Range(0f, (chain.Length) - 1));

            //pick a random point between that point on the chain and the next one
            
            Vector3 lerpPosition = (
                Vector3.Lerp(chain[chainsOffset].transform.position,
                chain[chainsOffset + 1].transform.position,
                Random.Range(0f, 1f)));

            lerpPosition += Random.insideUnitSphere * spatialJitter;

            //create a place for the new game object
            GameObject thisOne;

            //choose between the two preselected spawn prefabs in the entire set
            if (Random.Range(0f, 100f) < spawnSetBalance)
            {
                thisOne = Instantiate(spawns[spawnset], lerpPosition, transform.rotation);
            }
            else
            {
                thisOne = Instantiate(spawns[spawnset2], lerpPosition, transform.rotation);
            }
            //make the spawn a child of the base component of the chain selection
            thisOne.transform.SetParent(chain[chainsOffset].transform);
            //thisOne.transform.parent = ;
            //behave = thisOne.GetComponent<into_part_behavior>();
            //behave.Atr_forcePercentage = Random.Range(4f, 20f);
            //behave.Magnet = targets[Random.Range(0, targets.Length)].transform.gameObject;

            //scale up by the fib number if below scale percentage

            if (Random.Range(0f, 100f) < fibonacciScalePercentage)
            {
                thisOne.transform.localScale = Vector3.Scale(thisOne.transform.localScale, new Vector3(6.18f, 6.18f, 6.18f));
                //this is a great shortcut for randomly rotating an object randomly
                thisOne.transform.rotation = Random.rotation;
            }
            else
            {
                float tempScale = Random.Range(scaleJitterMin, scaleJitterMax);
                thisOne.transform.localScale = Vector3.Scale(thisOne.transform.localScale, new Vector3(tempScale, tempScale, tempScale));
                thisOne.transform.rotation = Random.rotation;
            }

    */
        
    }
    void spawnreset()
    {
        spawnset = Random.Range(0, spawns.Length);
        spawnset2 = Random.Range(0, spawns.Length);
    }

    void spawnOnLimb(List<GameObject> Limb)
    {
        int chainsOffset;
        // pick on node on the chain (not the last one) and store that node as "chainoffset"
        if (Limb.Count > 2)
        {
            chainsOffset = (int)Mathf.Floor(Random.Range(0f, (Limb.Count) - 1));
        }
        else
        {
            chainsOffset = 0;
        }

        //pick a random point between that point on the chain and the next one

        Vector3 lerpPosition = (
            Vector3.Lerp(Limb[chainsOffset].transform.position,
            Limb[chainsOffset + 1].transform.position,
            Random.Range(0f, 1f)));

        lerpPosition += Random.insideUnitSphere * spatialJitter;

        //create a place for the new game object
        GameObject thisOne;
       

        //choose between the two preselected spawn prefabs in the entire set
        if (Random.Range(0f, 100f) < spawnSetBalance)
        {
            thisOne = Instantiate(spawns[spawnset], lerpPosition, transform.rotation);
        }
        else
        {
            thisOne = Instantiate(spawns[spawnset2], lerpPosition, transform.rotation);
        }
        //make the spawn a child of the base component of the chain selection
        thisOne.transform.SetParent(Limb[chainsOffset+1].transform);
       
       // Debug.Log(Limb[chainsOffset + 1].transform);
        thisOne.tag = spawnTag;
        //thisOne.transform.parent = ;
        //behave = thisOne.GetComponent<into_part_behavior>();
        //behave.Atr_forcePercentage = Random.Range(4f, 20f);
        //behave.Magnet = targets[Random.Range(0, targets.Length)].transform.gameObject;

        //scale up by the fib number if below scale percentage

        if (Random.Range(0f, 100f) < fibonacciScalePercentage)
        {
            float tempScale = Random.Range(scaleJitterMin, scaleJitterMax);
            thisOne.transform.localScale = Vector3.Scale(thisOne.transform.localScale, new Vector3(tempScale * 6.18f, tempScale * 6.18f, tempScale * 6.18f));
            //this is a great shortcut for randomly rotating an object randomly
            thisOne.transform.rotation = Random.rotation;
        }
        else
        {
            float tempScale = Random.Range(scaleJitterMin, scaleJitterMax);
            thisOne.transform.localScale = Vector3.Scale(thisOne.transform.localScale, new Vector3(tempScale, tempScale, tempScale));
            thisOne.transform.rotation = Random.rotation;
        }
    }
}