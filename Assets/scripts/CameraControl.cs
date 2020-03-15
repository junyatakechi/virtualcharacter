using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Camera bustCamera;
    public Camera wholeCamera;
    public Camera farCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switchCameara();
    }

    void switchCameara() {
        if (Input.GetKey(KeyCode.Y))
        {
            bustCamera.enabled = true;
            wholeCamera.enabled = false;
            farCamera.enabled = false;

        }
        else if (Input.GetKey(KeyCode.U))
        {
            bustCamera.enabled = false;
            wholeCamera.enabled = true;
            farCamera.enabled = false;

        }
        else if (Input.GetKey(KeyCode.I))
        {
            bustCamera.enabled = false;
            wholeCamera.enabled = false;
            farCamera.enabled = true;

        }
    }

}
