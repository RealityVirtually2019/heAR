using System.Collections;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class ControlForRaycast : MonoBehaviour {

    public Transform Controller;    
    public GameObject prefab;
    public Transform cTransform;
    private MLInputController _controller;

    // Use this for initialization
    void Start () {
        // Start accessing the ML World Ray API.
        MLWorldRays.Start();
    }

    void Awake()
    {
        MLInput.Start(); // to start receiving input from the controller
        // MLInput.OnControllerButtonDown += OnButtonDown; // set button down listener
        MLInput.OnControllerButtonDown += OnButtonDown; // Bumper button
        _controller = MLInput.GetController(MLInput.Hand.Left);
    }

    // Instantiate the prefab at the given point.
    // Rotate the prefab to match given normal.
    // Wait 2 seconds then destroy the prefab.
    private IEnumerator NormalMarker(Vector3 point, Vector3 normal)
    {
        Quaternion rotation = Quaternion.FromToRotation(Vector3.up, normal);
        GameObject bubble = Instantiate(prefab, point, rotation);
        bubble.transform.LookAt(cTransform);
        bubble.transform.position = transform.position + transform.up * .3f - transform.right * .1f;
        yield return new WaitForSeconds(3);
        Destroy(bubble);
    }

    // Use a callback to know when to run the NormalMaker() coroutine.
    void HandleOnReceiveRaycast(MLWorldRays.MLWorldRaycastResultState state, UnityEngine.Vector3 point, UnityEngine.Vector3 normal, float confidence)
    {
        if (state == MLWorldRays.MLWorldRaycastResultState.HitObserved)
        {
            StartCoroutine(NormalMarker(point, normal));
        }
    }

    // When the prefab is destroyed, stop MLWorldRays API from running.
    private void OnDestroy()
    {
        MLInput.OnControllerButtonDown -= OnButtonDown;
        MLInput.Stop();
        MLWorldRays.Stop();
    }

    void OnButtonDown(byte controller_id, MLInputControllerButton button)
    {
        if (button == MLInputControllerButton.Bumper)
        {
            Debug.Log("Place bubble");
            // Create a raycast parameters variable
            MLWorldRays.QueryParams _raycastParams = new MLWorldRays.QueryParams
            {
                // Update the parameters with our Camera's transform
                Position = Controller.position,
                Direction = Controller.forward,
                UpVector = Controller.up,
                // Provide a size of our raycasting array (1x1)
                Width = 1,
                Height = 1
            };

            // Feed our modified raycast parameters and handler to our raycast request
            MLWorldRays.GetWorldRays(_raycastParams, HandleOnReceiveRaycast);
        }
    }
}
