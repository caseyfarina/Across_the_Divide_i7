using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerSoundAvoidance : MonoBehaviour
{
    AudioSource playSound;
    Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        playSound = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
       // anim.get;
            playSound.Play();


    }
}
