using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationLock : MonoBehaviour
{
    void Update()
    {
        transform.eulerAngles = new Vector3(0, 0, 0);
    }
}
