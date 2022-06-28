using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public int angle = 45;


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            transform.Rotate(0, -angle, 0);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            transform.Rotate(0, angle, 0);
        }

    }
}
