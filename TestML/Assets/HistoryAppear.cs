using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class HistoryAppear : MonoBehaviour {

	// Use this for initialization
	void Start () {
       // GetComponent<Renderer>().enabled = false;

        MLInput.OnControllerButtonDown += OnButtonDown;
        MLInput.OnControllerButtonUp += OnButtonUp;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void Awake()
    {
        //GameObject.Find("Text: History").GetComponent<Renderer>().enabled  = false;

    }

    private void OnButtonDown(byte controllerId, MLInputControllerButton button)
    {
        if (button == MLInputControllerButton.Bumper) {
           // GetComponent<Renderer>().enabled = true;
        }
           // GameObject.Find("Text: History").GetComponent<Renderer>().enabled = true;

    }

    private void OnButtonUp(byte controllerId, MLInputControllerButton button)
    {
        if (button == MLInputControllerButton.Bumper) {
           // GetComponent<Renderer>().enabled = false;
        }
          //  GameObject.Find("Text: History").GetComponent<Renderer>().enabled = false;
    }
}
