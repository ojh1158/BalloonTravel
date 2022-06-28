using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public int angle = 45;
    public float rotateSpeed = 10f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            //GameManager.isCameraRotating = true;
            //Quaternion targetRotation = Quaternion.Euler(0, -angle, 0);
            //StartCoroutine(Rotate(targetRotation));


            transform.Rotate(0, -angle, 0);
            
            //transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotateSpeed);   <- ¾ÈµÊ

        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            //GameManager.isCameraRotating = true;
            //Quaternion targetRotation = Quaternion.Euler(0, angle, 0);
            //StartCoroutine(Rotate(targetRotation));


            transform.Rotate(0, angle, 0);

        }
    }

    //IEnumerator Rotate(Quaternion target)
    //{
    //    transform.rotation = Quaternion.Lerp(transform.rotation, target, Time.deltaTime * rotateSpeed);
    //    GameManager.isCameraRotating = false;

    //    yield return null;
    //}
}
