using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class destroyAfterTime : MonoBehaviour
{

    [Range(0.0f, 10f)]
    public float timeMin = 5f;
    [Range(0.01f, 30f)]
    public float timeMax = 10.0f;
    private part_parent_target thisPartParent;
    private GameObject targetStorage;
    public bool DestroyTarget = true;
    // Start is called before the first frame update
    void Start()
    {
        float lifetime = Random.Range(timeMin, timeMax);
        if(DestroyTarget)
        {
            thisPartParent = GetComponent<part_parent_target>();
            targetStorage = thisPartParent.MagnetObjects;
        }
        
        Invoke("shrink", lifetime);
        
    }



    void shrink()
    {
        transform.DOScale(Vector3.zero, .7f).SetEase(Ease.InOutQuad).OnComplete(eliminate);
    }
    void eliminate()
    {
        Destroy(transform.gameObject);
        if (DestroyTarget)
        {
            Destroy(targetStorage);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }

}
