using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parentPosition : MonoBehaviour
{
    public GameObject positionReference;
    public float yOffset = .2f;
    // Start is called before the first frame update
    void Start()
    {
        yOffset = Random.Range(-yOffset, yOffset);
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = new Vector3(
            positionReference.transform.position.x,
            positionReference.transform.position.y + yOffset,
            positionReference.transform.position.z
            );
    }
}
