using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class rotator : MonoBehaviour
{
    public float rotationSpeedMin = 3f;
    public float rotationSpeedMax = 11f;
    public float rotationDegreeDistance = 45f;
    public float punchScale = 1f;
    private float rotationSpeed;
    AudioSource thisAudio;
    private float previousRotation;
    Vector3 startingRotation;
    float rotationTime;
    private float rotationIncrement;

    // Start is called before the first frame update
    void Start()

    {
        // set the random starting rotation
        startingRotation = new Vector3(0, Random.Range(0, 360), 0);
        transform.eulerAngles = startingRotation;
        //set the rotation speed
        rotationSpeed = Random.Range(rotationSpeedMin, rotationSpeedMax);
        rotationTime = Random.Range(rotationSpeedMin, rotationSpeedMax);
        if (gameObject.GetComponent<AudioSource>() != null)
        {
            thisAudio = GetComponent<AudioSource>();
        }

        
        //transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);

        Vector3 currentScale = transform.localScale;
       

        rotationIncrement = Mathf.Floor(Random.Range(-9, 9)) * rotationDegreeDistance;
        Debug.Log("rot  " + rotationIncrement);
        
        if(rotationIncrement > 0f)
        {
            transform.GetChild(0).localEulerAngles = new Vector3(-90f, 0f, 0f);
        }
        else
        {
            transform.GetChild(0).localEulerAngles = new Vector3(90f, 0f, 0f);
        }
        
        InvokeRepeating("rotateSound", 0f, rotationTime);
    }

    // Update is called once per frame
    void Update()
    {/*
        transform.Rotate(new Vector3(0, rotationSpeed * Time.deltaTime, 0));

        
        if (gameObject.GetComponent<AudioSource>() != null)
        {
            if (transform.eulerAngles.y == 0f previousRotation)
            {
                thisAudio.Play();
                Vector3 currentScale = transform.localScale;
                transform.GetChild(0).transform.DOPunchScale(currentScale * 1.1f, 0.5f,0,1f);
            }

        }

            previousRotation = transform.eulerAngles.y;
       */ 
    }
    void rotateSound()
    {
        Vector3 targetRotation = new Vector3(0, rotationIncrement, 0);
        Tween spin = transform.DOLocalRotate(targetRotation, rotationTime, RotateMode.LocalAxisAdd).SetEase(Ease.InOutSine);
      
        Vector3 currentScale = transform.GetChild(0).localScale;
        transform.GetChild(0).transform.DOPunchScale(currentScale * punchScale, 0.5f, 0, 1f).SetDelay(rotationTime / 2f).OnPlay(playRotateSound);
        Debug.Log("spin");
    }

    void playRotateSound()
    {
        thisAudio.Play();
    }
}
