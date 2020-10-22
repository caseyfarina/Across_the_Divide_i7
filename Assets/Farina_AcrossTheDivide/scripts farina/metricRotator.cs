using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class metricRotator : MonoBehaviour
{
    public float orbitalDistance = 1f;
    public float animationDistance = 1f;
    public int[] pattern = new int[] { 1, 1, 1, 1, 1 };
    public float tempoBPM = 80f;
    public float subdivision = 1f;

    
    
    AudioSource thisAudio;
  
    Vector3 startingRotation;
    float rotationTime;
    GameObject child;
    // Start is called before the first frame update

    void Start()
    {
        //randomly flip direction
        if(Random.Range(0,100) < 50)
        {
            animationDistance = animationDistance * -1;
        }


        //cache the Child gameobject
        child = transform.GetChild(0).gameObject;
        //move that Child to the orbital distance
        child.transform.localPosition = new Vector3(0, 0, orbitalDistance);

        //calculate rotation time
        rotationTime = (60f / tempoBPM) * subdivision;
        Debug.Log(rotationTime);


        // set the random starting rotation
        startingRotation = new Vector3(0, Random.Range(0, 360), 0);
        transform.eulerAngles = startingRotation;
        //set the rotation speed
      
        //get the audioSource
        if (gameObject.GetComponent<AudioSource>() != null)
        {
            thisAudio = GetComponent<AudioSource>();
        }

        InvokeRepeating("rotateSound", 0f, rotationTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void rotateSound()
    {
        Vector3 targetRotation = new Vector3(0, 360f * animationDistance, 0);
        Tween spin = transform.DOLocalRotate(targetRotation, rotationTime, RotateMode.LocalAxisAdd).SetEase(Ease.InOutCirc);
        Vector3 currentScale = transform.localScale;
        transform.GetChild(0).transform.DOPunchScale(currentScale * 2f, rotationTime / 2f, 0, 1f).SetDelay(rotationTime / 2f).OnPlay(playRotateSound);
        Debug.Log("spin " + rotationTime);
    }
    void playRotateSound()
    {
        thisAudio.Play();
    }
}
