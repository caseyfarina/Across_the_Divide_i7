using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class keyUI : MonoBehaviour
{

    public string inputName;
    //Button buttonMe;
    public GameObject[] myObjects;

    Toggle _mytoggle;
    // Use this for initialization
    void Start()
    {
       // buttonMe = GetComponent<Button>();
        _mytoggle = GetComponent<Toggle>();
    }

    void Update()
    {
        if (Input.GetButtonDown(inputName))
        {
           // buttonMe.onClick.Invoke();
            _mytoggle.isOn = true;
        }


    }
}