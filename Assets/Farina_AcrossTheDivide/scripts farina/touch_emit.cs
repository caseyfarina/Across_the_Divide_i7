using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ez.Pooly;

public class touch_emit : MonoBehaviour
{

    public ParticleSystem parts;
    private bool touching;
    public int emitAmount = 5;
    public int midinote = 71;
    public GameObject fab_1;

    // Use this for initialization
    void Start()
    {
        touching = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (touching)
        {
            parts.Emit(5);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "tier_one")
        {
            //If the GameObject has the same tag as specified, output this message in the console
           // Debug.Log("Do something else here");
            Pooly.Spawn(fab_1.transform, gameObject.transform.position, Quaternion.identity);
        }
        foreach (ContactPoint contact in collision.contacts)
        {

            
        }
       
    }

}
