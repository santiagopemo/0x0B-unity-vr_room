using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputText : MonoBehaviour
{
    public Text inputTxt;
    public Text inputTxt2;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnGUI()
    {
        Event e = Event.current;
        if (e.isKey)
        {
            // Debug.Log("Detected key code: " + e.keyCode);
            inputTxt.text = e.keyCode.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown){ 
            inputTxt2.text = Input.inputString.ToString();
        }
        
    }
}
