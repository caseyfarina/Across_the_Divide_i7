using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class key_button : MonoBehaviour
{

    public KeyCode _Key;

    private Button _button;

    private Toggle _toggle;
    // Start is called before the first frame update
    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(_Key))
        {
          //  _button.onClick.Invoke();
           // _toggle.OnPointerClick.Invoke();
           // _toggle.OnPointerDown.
        }
    }
}
