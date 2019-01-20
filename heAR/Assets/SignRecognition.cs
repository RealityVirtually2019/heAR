using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
//using UnityEngine.Windows.
using System.IO;
using UnityEngine.XR.MagicLeap;
using UnityEngine.UI;

public class SignRecognition : MonoBehaviour
{
    private MLInputController _controller;
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(SendRequest());

    }

    void Awake()
    {
        MLInput.Start(); // to start receiving input from the controller
        // MLInput.OnControllerButtonDown += OnButtonDown; // set button down listener
        //MLInput.OnControllerButtonDown += OnButtonDown; // Bumper button
        _controller = MLInput.GetController(MLInput.Hand.Left);
    }

    void OnButtonDown(byte controller_id, MLInputControllerButton button)
    {
        Debug.Log("Button pressed");
        text.text = "Is it changed?";
        //StartCoroutine(SendRequest());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator SendRequest(byte[] imageData)
    {
        Debug.Log("Coroutine started");
        text.text = "It is not changed?";

        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        // Replace Image Data Here!
        //byte[] imageData = File.ReadAllBytes("/Users/JYO/Desktop/ASL.jpg");
        form.AddBinaryData("data", imageData);

        text.text = "It is not changed?";

        using (UnityWebRequest www = UnityWebRequest.Post("http://35.231.53.252:8080/GestureImage", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
                text.text = www.error;
            }
            else
            {
                Debug.Log("Form upload complete!");
                Debug.Log(www.downloadHandler.data);
                byte[] results = www.downloadHandler.data;
                var str = System.Text.Encoding.UTF8.GetString(results);
                Debug.Log(str);
                text.text = str;
            }
        }
    }
}