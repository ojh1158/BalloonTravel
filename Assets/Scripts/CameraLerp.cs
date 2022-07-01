using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLerp : MonoBehaviour
{
    public Transform CamTarget;
    public float pLerp = 0.08f;
    public float rLerp = 0.1f;

    void Update()
    {  
        transform.position = Vector3.Lerp(transform.position, CamTarget.position, pLerp);
        transform.rotation = Quaternion.Lerp(transform.rotation, CamTarget.rotation, rLerp);
    }
}